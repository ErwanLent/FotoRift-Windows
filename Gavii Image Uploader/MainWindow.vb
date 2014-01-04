Imports System.IO
Imports System.Text
Imports System.Net

Public Class MainWindow

    'Development By Erwan Lent

    Public RegionShot As Boolean

    Private ReadOnly _savePath As String = Path.GetTempPath & "fotorift.png"
    Private ReadOnly _myBrush As New SolidBrush(Color.Fuchsia)

    Private _formGraphics As Graphics
    Private _start As Point
    Private _area As Rectangle
    Private _isDown As Boolean = False

    Private Sub TakeScreenShot(ByVal window As Rectangle)

        'Take screen shot based on given region
        Hide()

        Dim shot As Bitmap
        Dim screenShotBounds As Rectangle = window
        shot = New Bitmap(screenShotBounds.Width, screenShotBounds.Height, Imaging.PixelFormat.Format32bppArgb)

        Dim graphics As Graphics = graphics.FromImage(shot)
        graphics.CopyFromScreen(screenShotBounds.Location, New Point(0, 0), screenShotBounds.Size, CopyPixelOperation.SourceCopy)

        ' Delete last image to save HDD space
        If File.Exists(_savePath) Then
            File.Delete(_savePath)
        End If

        ' Save and upload image
        shot.Save(_savePath)
        PostImage()
        Close()

    End Sub

    Private Sub DrawRectangle(ByVal startPoint As Point, ByVal endPoint As Point)

        'Draws Transparent Rectangle With Given Bounds
        Refresh()
        _formGraphics = CreateGraphics()

        Dim rectangleWidth As Integer = (endPoint.X - startPoint.X)
        Dim rectangleHeight As Integer = (endPoint.Y - startPoint.Y)

        'Account For Reverse Rectangles
        If rectangleWidth < 0 Then
            startPoint.X = endPoint.X
            ' EndPoint.X = temp
            rectangleWidth = Math.Abs(rectangleWidth)
        End If

        If rectangleHeight < 0 Then
            startPoint.Y = endPoint.Y
            ' EndPoint.Y = temp
            rectangleHeight = Math.Abs(rectangleHeight)
        End If

        ' Draw highlighted region
        _area = New Rectangle(startPoint.X, startPoint.Y, rectangleWidth, rectangleHeight)
        _formGraphics.FillRectangle(_myBrush, _area)
        _formGraphics.DrawRectangle(Pens.White, _area)

    End Sub

    Private Sub MainWindow_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If _isDown Then
            DrawRectangle(_start, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub MainWindow_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        _start = New Point(e.X, e.Y)
        _isDown = True
    End Sub

    Private Sub MainWindow_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        _isDown = False
        If (_area <> Nothing) Then TakeScreenShot(_area) Else Me.Close()
    End Sub

    Private Sub PostImage()

        Try
            Dim encodedString As String = Base64Encode()
            If Not encodedString = Nothing Then PostRequest(Base64Encode) Else MessageBox.Show("Image file missing. Please try again.", "Image Error")
        Catch ex As Exception
            MessageBox.Show("Foto Rift ran into an issue when uploading. Please check your internet connection and try again.", "Uploading Error")
        End Try

    End Sub

    Private Function Base64Encode()

        'Encode Image Into String To Post
        If File.Exists(_savePath) Then
            Dim imageBytes As Byte() = File.ReadAllBytes(_savePath)
            Dim encodedImage As String = Convert.ToBase64String(imageBytes)
            Return encodedImage
        Else
            Return Nothing
        End If

    End Function

    Private Sub PostRequest(ByVal encodedImage As String)

        Dim postData As String = "data=" & encodedImage.Replace("+", "%2B")
        Dim encoding As New UTF8Encoding
        Dim byteData As Byte() = encoding.GetBytes(postData)

        Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://fotorift.com/php/windowsUpload.php"), 
            HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        Dim reqstream As Stream = request.GetRequestStream()
        reqstream.Write(byteData, 0, byteData.Length)
        reqstream.Close()

        Dim response As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)

        Dim reader As New StreamReader(response.GetResponseStream)
        Dim source As String = reader.ReadToEnd.Trim

        My.Computer.Clipboard.SetText(source)
        Process.Start(source)

    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If RegionShot = False Then
            TakeScreenShot(New Rectangle(New Point(0, 0), New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)))
        End If
    End Sub

    Private Sub MainWindow_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(27) Then
            Close()
        End If
    End Sub
End Class