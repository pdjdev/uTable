<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DLLDownloader
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MainLabel = New System.Windows.Forms.Label()
        Me.TitlePanel = New System.Windows.Forms.Panel()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.TitlePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainLabel
        '
        Me.MainLabel.BackColor = System.Drawing.Color.White
        Me.MainLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainLabel.Font = New System.Drawing.Font("맑은 고딕", 10.0!)
        Me.MainLabel.Location = New System.Drawing.Point(1, 28)
        Me.MainLabel.Name = "MainLabel"
        Me.MainLabel.Size = New System.Drawing.Size(287, 84)
        Me.MainLabel.TabIndex = 0
        Me.MainLabel.Text = "잠시만 기다려 주세요..!"
        Me.MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TitlePanel
        '
        Me.TitlePanel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TitlePanel.Controls.Add(Me.TitleLabel)
        Me.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TitlePanel.Location = New System.Drawing.Point(1, 1)
        Me.TitlePanel.Name = "TitlePanel"
        Me.TitlePanel.Size = New System.Drawing.Size(287, 27)
        Me.TitlePanel.TabIndex = 1
        '
        'TitleLabel
        '
        Me.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleLabel.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TitleLabel.Location = New System.Drawing.Point(0, 0)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.TitleLabel.Size = New System.Drawing.Size(287, 27)
        Me.TitleLabel.TabIndex = 29
        Me.TitleLabel.Text = "구성요소 다운로드"
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DLLDownloader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(289, 113)
        Me.ControlBox = False
        Me.Controls.Add(Me.MainLabel)
        Me.Controls.Add(Me.TitlePanel)
        Me.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.uTable.My.Resources.Resources.ptable_icon
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DLLDownloader"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "구성요소 다운로드"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.TitlePanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MainLabel As Label
    Friend WithEvents TitlePanel As Panel
    Friend WithEvents TitleLabel As Label
End Class
