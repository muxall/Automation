<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.BtnConnect = New System.Windows.Forms.Button()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.TxtConnectIpAddr = New System.Windows.Forms.TextBox()
        Me.TxtConnectPort = New System.Windows.Forms.TextBox()
        Me.TxtSend = New System.Windows.Forms.TextBox()
        Me.TxtResp = New System.Windows.Forms.TextBox()
        Me.TimerRecv = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'BtnConnect
        '
        Me.BtnConnect.Location = New System.Drawing.Point(336, 33)
        Me.BtnConnect.Name = "BtnConnect"
        Me.BtnConnect.Size = New System.Drawing.Size(99, 23)
        Me.BtnConnect.TabIndex = 0
        Me.BtnConnect.Text = "Connect"
        Me.BtnConnect.UseVisualStyleBackColor = True
        '
        'BtnSend
        '
        Me.BtnSend.Location = New System.Drawing.Point(336, 72)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(99, 23)
        Me.BtnSend.TabIndex = 1
        Me.BtnSend.Text = "Send"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'TxtConnectIpAddr
        '
        Me.TxtConnectIpAddr.Location = New System.Drawing.Point(89, 33)
        Me.TxtConnectIpAddr.Name = "TxtConnectIpAddr"
        Me.TxtConnectIpAddr.Size = New System.Drawing.Size(132, 22)
        Me.TxtConnectIpAddr.TabIndex = 2
        Me.TxtConnectIpAddr.Text = "192.168.1.76"
        '
        'TxtConnectPort
        '
        Me.TxtConnectPort.Location = New System.Drawing.Point(227, 33)
        Me.TxtConnectPort.Name = "TxtConnectPort"
        Me.TxtConnectPort.Size = New System.Drawing.Size(87, 22)
        Me.TxtConnectPort.TabIndex = 3
        Me.TxtConnectPort.Text = "22"
        '
        'TxtSend
        '
        Me.TxtSend.Location = New System.Drawing.Point(89, 72)
        Me.TxtSend.Name = "TxtSend"
        Me.TxtSend.Size = New System.Drawing.Size(225, 22)
        Me.TxtSend.TabIndex = 4
        '
        'TxtResp
        '
        Me.TxtResp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtResp.Location = New System.Drawing.Point(31, 121)
        Me.TxtResp.Multiline = True
        Me.TxtResp.Name = "TxtResp"
        Me.TxtResp.Size = New System.Drawing.Size(380, 224)
        Me.TxtResp.TabIndex = 5
        '
        'TimerRecv
        '
        Me.TimerRecv.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 373)
        Me.Controls.Add(Me.TxtResp)
        Me.Controls.Add(Me.TxtSend)
        Me.Controls.Add(Me.TxtConnectPort)
        Me.Controls.Add(Me.TxtConnectIpAddr)
        Me.Controls.Add(Me.BtnSend)
        Me.Controls.Add(Me.BtnConnect)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnConnect As Button
    Friend WithEvents BtnSend As Button
    Friend WithEvents TxtConnectIpAddr As TextBox
    Friend WithEvents TxtConnectPort As TextBox
    Friend WithEvents TxtSend As TextBox
    Friend WithEvents TxtResp As TextBox
    Friend WithEvents TimerRecv As Timer
End Class
