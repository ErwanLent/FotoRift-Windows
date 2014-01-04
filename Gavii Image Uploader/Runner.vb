Imports System.Runtime.InteropServices
Imports System.Text

Public Class Runner

    'Hot Key Virtual Key Codes
    Private Const ModAlt As Integer = &H1 'Alt key
    Private Const WmHotkey As Integer = &H312

    <DllImport("User32.dll")> _
    Public Shared Function RegisterHotKey(ByVal hwnd As IntPtr, _
                        ByVal id As Integer, ByVal fsModifiers As Integer, _
                        ByVal vk As Integer) As Integer
    End Function

    Protected Overrides Sub WndProc(ByRef message As Windows.Forms.Message)

        If message.Msg = WmHotkey Then
            Dim id As IntPtr = message.WParam
            If id.ToString.Equals("100") Then
                StartApplication(True)
            ElseIf id.ToString.Equals("200") Then
                StartApplication(False)
            End If
        End If

        MyBase.WndProc(message)

    End Sub

    Private Sub StartApplication(ByVal isRegion As Boolean)
        MainWindow.RegionShot = isRegion
        MainWindow.Show()
    End Sub

    Private Sub Runner_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Check For Multiple Instances
        If UBound(Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName)) > 0 Then
            MsgBox("Foto Rift Already Running. Press ALT + R to take a screenshot.")
            End
        End If

        RegisterHotKey(Handle, 100, ModAlt, Keys.R)
        RegisterHotKey(Handle, 200, ModAlt, Keys.A)

    End Sub

    Private Sub Runner_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Hide()
    End Sub

    Private Sub ScreenshotMenuItem_Click(sender As Object, e As EventArgs) Handles ScreenshotMenuItem.Click
        MainWindow.RegionShot = True
        MainWindow.Show()
    End Sub

    Private Shared Sub HelpMenuItem_Click(sender As Object, e As EventArgs) Handles HelpMenuItem.Click

        Dim helpBuilder As New StringBuilder("Foto Rift Image Uploader Hotkeys:")
        helpBuilder.AppendLine()
        helpBuilder.AppendLine("ALT + R - Select Region Of Screen To Upload")
        helpBuilder.AppendLine("ALT + A - Upload Screenshot Of Entire Screen")

        MessageBox.Show(helpBuilder.ToString, "Foto Rift Image Uploader")

    End Sub

    Private Shared Sub ExitMenuItem_Click(sender As Object, e As EventArgs) Handles ExitMenuItem.Click
        End
    End Sub

End Class