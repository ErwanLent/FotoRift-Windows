<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Runner
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Runner))
        Me.FotoRiftTrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.FotoRiftMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ScreenshotMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FotoRiftMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'FotoRiftTrayIcon
        '
        Me.FotoRiftTrayIcon.ContextMenuStrip = Me.FotoRiftMenu
        Me.FotoRiftTrayIcon.Icon = CType(resources.GetObject("FotoRiftTrayIcon.Icon"), System.Drawing.Icon)
        Me.FotoRiftTrayIcon.Text = "Foto Rift Image Uploader"
        Me.FotoRiftTrayIcon.Visible = True
        '
        'FotoRiftMenu
        '
        Me.FotoRiftMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ScreenshotMenuItem, Me.HelpMenuItem, Me.ExitMenuItem})
        Me.FotoRiftMenu.Name = "GaviiMenu"
        Me.FotoRiftMenu.Size = New System.Drawing.Size(129, 70)
        '
        'ScreenshotMenuItem
        '
        Me.ScreenshotMenuItem.Name = "ScreenshotMenuItem"
        Me.ScreenshotMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ScreenshotMenuItem.Text = "Screenshot"
        '
        'HelpMenuItem
        '
        Me.HelpMenuItem.Name = "HelpMenuItem"
        Me.HelpMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.HelpMenuItem.Text = "Help"
        '
        'ExitMenuItem
        '
        Me.ExitMenuItem.Name = "ExitMenuItem"
        Me.ExitMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ExitMenuItem.Text = "Exit"
        '
        'Runner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(10, 10)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Runner"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Foto Rift"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.FotoRiftMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FotoRiftTrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents FotoRiftMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ScreenshotMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
