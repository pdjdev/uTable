<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EveryTimeBrowserNew
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TableChecker = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TSLinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.CloseBT = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableChecker
        '
        Me.TableChecker.Interval = 500
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.WebView21)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(502, 684)
        Me.Panel1.TabIndex = 1
        '
        'WebView21
        '
        Me.WebView21.AllowExternalDrop = True
        Me.WebView21.CreationProperties = Nothing
        Me.WebView21.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebView21.Location = New System.Drawing.Point(0, 80)
        Me.WebView21.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WebView21.Name = "WebView21"
        Me.WebView21.Size = New System.Drawing.Size(502, 604)
        Me.WebView21.TabIndex = 30
        Me.WebView21.ZoomFactor = 1.0R
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TSLinkLabel1)
        Me.Panel2.Controls.Add(Me.CloseBT)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(502, 80)
        Me.Panel2.TabIndex = 33
        '
        'TSLinkLabel1
        '
        Me.TSLinkLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TSLinkLabel1.LinkColor = System.Drawing.Color.Maroon
        Me.TSLinkLabel1.Location = New System.Drawing.Point(0, 41)
        Me.TSLinkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TSLinkLabel1.Name = "TSLinkLabel1"
        Me.TSLinkLabel1.Size = New System.Drawing.Size(502, 35)
        Me.TSLinkLabel1.TabIndex = 30
        Me.TSLinkLabel1.TabStop = True
        Me.TSLinkLabel1.Text = "로그인에 문제가 있나요?"
        Me.TSLinkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CloseBT
        '
        Me.CloseBT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseBT.BackColor = System.Drawing.Color.White
        Me.CloseBT.Image = Global.uTable.My.Resources.Resources.closeicon_b
        Me.CloseBT.Location = New System.Drawing.Point(461, 4)
        Me.CloseBT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CloseBT.Name = "CloseBT"
        Me.CloseBT.Size = New System.Drawing.Size(38, 38)
        Me.CloseBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CloseBT.TabIndex = 29
        Me.CloseBT.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Noto Sans KR", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(502, 41)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "시간표를 불러 올 계정으로 로그인 해 주세요."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'EveryTimeBrowserNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(504, 686)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Noto Sans KR", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.uTable.My.Resources.Resources.ptable_icon
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "EveryTimeBrowserNew"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "에브리타임 시간표 불러오기"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.Panel1.ResumeLayout(False)
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableChecker As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents CloseBT As PictureBox
    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TSLinkLabel1 As LinkLabel
End Class
