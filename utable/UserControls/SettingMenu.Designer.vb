<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingMenu
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.SettingLabel = New System.Windows.Forms.Label()
        Me.HighlightPanel = New System.Windows.Forms.Panel()
        Me.ColorTransitionTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.SettingLabel)
        Me.Panel6.Controls.Add(Me.HighlightPanel)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(126, 39)
        Me.Panel6.TabIndex = 2
        '
        'SettingLabel
        '
        Me.SettingLabel.BackColor = System.Drawing.Color.White
        Me.SettingLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SettingLabel.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SettingLabel.Location = New System.Drawing.Point(3, 0)
        Me.SettingLabel.Name = "SettingLabel"
        Me.SettingLabel.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.SettingLabel.Size = New System.Drawing.Size(123, 39)
        Me.SettingLabel.TabIndex = 2
        Me.SettingLabel.Text = "SettingsText"
        Me.SettingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HighlightPanel
        '
        Me.HighlightPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.HighlightPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.HighlightPanel.Location = New System.Drawing.Point(0, 0)
        Me.HighlightPanel.Name = "HighlightPanel"
        Me.HighlightPanel.Size = New System.Drawing.Size(3, 39)
        Me.HighlightPanel.TabIndex = 0
        '
        'ColorTransitionTimer
        '
        Me.ColorTransitionTimer.Interval = 10
        '
        'SettingMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.Panel6)
        Me.Name = "SettingMenu"
        Me.Size = New System.Drawing.Size(126, 39)
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel6 As Panel
    Friend WithEvents SettingLabel As Label
    Friend WithEvents HighlightPanel As Panel
    Friend WithEvents ColorTransitionTimer As Timer
End Class
