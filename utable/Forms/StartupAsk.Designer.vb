<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartupAsk
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartupAsk))
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtLabel = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ApplyBT = New System.Windows.Forms.Button()
        Me.NoBT = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CloseBT = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TitleLabel
        '
        Me.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleLabel.Font = New System.Drawing.Font("맑은 고딕 Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(0, 0)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(353, 32)
        Me.TitleLabel.TabIndex = 28
        Me.TitleLabel.Text = "시작프로그램 설정"
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MainPanel)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel1.Size = New System.Drawing.Size(405, 192)
        Me.Panel1.TabIndex = 30
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.Label1)
        Me.MainPanel.Controls.Add(Me.TxtLabel)
        Me.MainPanel.Controls.Add(Me.PictureBox2)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(10, 42)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(2)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.MainPanel.Size = New System.Drawing.Size(385, 104)
        Me.MainPanel.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(79, 64)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(13, 5, 0, 3)
        Me.Label1.Size = New System.Drawing.Size(296, 40)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "(실행 파일의 위치가 변경되어" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "설정이 해지되었을 수도 있습니다)"
        '
        'TxtLabel
        '
        Me.TxtLabel.BackColor = System.Drawing.Color.Transparent
        Me.TxtLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TxtLabel.ForeColor = System.Drawing.Color.Black
        Me.TxtLabel.Location = New System.Drawing.Point(79, 0)
        Me.TxtLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TxtLabel.Name = "TxtLabel"
        Me.TxtLabel.Padding = New System.Windows.Forms.Padding(13, 0, 0, 3)
        Me.TxtLabel.Size = New System.Drawing.Size(296, 64)
        Me.TxtLabel.TabIndex = 10
        Me.TxtLabel.Text = "현재 uTable이 시작프로그램으로" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "설정되지 않은 것 같습니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "시작프로그램으로 설정하시겠습니까?"
        Me.TxtLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox2.Image = Global.uTable.My.Resources.Resources.utable_icon
        Me.PictureBox2.Location = New System.Drawing.Point(10, 0)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 104)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 7
        Me.PictureBox2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ApplyBT)
        Me.Panel3.Controls.Add(Me.NoBT)
        Me.Panel3.Controls.Add(Me.CheckBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(10, 146)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(385, 36)
        Me.Panel3.TabIndex = 31
        '
        'ApplyBT
        '
        Me.ApplyBT.BackColor = System.Drawing.Color.Transparent
        Me.ApplyBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.ApplyBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ApplyBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ApplyBT.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ApplyBT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ApplyBT.Location = New System.Drawing.Point(151, 0)
        Me.ApplyBT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ApplyBT.Name = "ApplyBT"
        Me.ApplyBT.Size = New System.Drawing.Size(134, 36)
        Me.ApplyBT.TabIndex = 9
        Me.ApplyBT.Text = "네, 설정하겠습니다"
        Me.ApplyBT.UseVisualStyleBackColor = False
        '
        'NoBT
        '
        Me.NoBT.BackColor = System.Drawing.Color.Transparent
        Me.NoBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.NoBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.NoBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NoBT.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.NoBT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NoBT.Location = New System.Drawing.Point(285, 0)
        Me.NoBT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NoBT.Name = "NoBT"
        Me.NoBT.Size = New System.Drawing.Size(100, 36)
        Me.NoBT.TabIndex = 8
        Me.NoBT.Text = "괜찮습니다"
        Me.NoBT.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(10, 9)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(106, 19)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "다시 표시 안함"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TitleLabel)
        Me.Panel2.Controls.Add(Me.CloseBT)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(10, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(385, 32)
        Me.Panel2.TabIndex = 30
        '
        'CloseBT
        '
        Me.CloseBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.CloseBT.Image = Global.uTable.My.Resources.Resources.closeicon_b
        Me.CloseBT.Location = New System.Drawing.Point(353, 0)
        Me.CloseBT.Name = "CloseBT"
        Me.CloseBT.Size = New System.Drawing.Size(32, 32)
        Me.CloseBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CloseBT.TabIndex = 29
        Me.CloseBT.TabStop = False
        '
        'StartupAsk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(407, 194)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = My.Resources.ptable_icon
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "StartupAsk"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "시작프로그램 설정"
        Me.TransparencyKey = System.Drawing.Color.Magenta
        Me.Panel1.ResumeLayout(False)
        Me.MainPanel.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CloseBT As PictureBox
    Friend WithEvents TitleLabel As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents MainPanel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtLabel As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ApplyBT As Button
    Friend WithEvents NoBT As Button
End Class
