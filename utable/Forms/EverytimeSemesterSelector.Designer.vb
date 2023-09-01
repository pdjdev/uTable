<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EverytimeSemesterSelector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EverytimeSemesterSelector))
        Me.NextBT = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Step1Panel = New System.Windows.Forms.Panel()
        Me.tipLabel = New System.Windows.Forms.Label()
        Me.autoChk = New System.Windows.Forms.CheckBox()
        Me.semesterCombo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.yearUpd = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Step2Panel = New System.Windows.Forms.Panel()
        Me.AgreementRTB = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.CloseBT = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Step1Panel.SuspendLayout()
        CType(Me.yearUpd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Step2Panel.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NextBT
        '
        Me.NextBT.BackColor = System.Drawing.Color.Transparent
        Me.NextBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.NextBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.NextBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NextBT.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.NextBT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NextBT.Location = New System.Drawing.Point(260, 10)
        Me.NextBT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NextBT.Name = "NextBT"
        Me.NextBT.Size = New System.Drawing.Size(98, 36)
        Me.NextBT.TabIndex = 3
        Me.NextBT.Text = "다음"
        Me.NextBT.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(15)
        Me.Panel1.Size = New System.Drawing.Size(388, 224)
        Me.Panel1.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Step1Panel)
        Me.Panel3.Controls.Add(Me.Step2Panel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(15, 47)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(358, 116)
        Me.Panel3.TabIndex = 34
        '
        'Step1Panel
        '
        Me.Step1Panel.Controls.Add(Me.tipLabel)
        Me.Step1Panel.Controls.Add(Me.autoChk)
        Me.Step1Panel.Controls.Add(Me.semesterCombo)
        Me.Step1Panel.Controls.Add(Me.Label3)
        Me.Step1Panel.Controls.Add(Me.yearUpd)
        Me.Step1Panel.Controls.Add(Me.Label4)
        Me.Step1Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Step1Panel.Location = New System.Drawing.Point(0, 0)
        Me.Step1Panel.Name = "Step1Panel"
        Me.Step1Panel.Size = New System.Drawing.Size(358, 116)
        Me.Step1Panel.TabIndex = 39
        '
        'tipLabel
        '
        Me.tipLabel.AutoSize = True
        Me.tipLabel.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.tipLabel.ForeColor = System.Drawing.Color.Gray
        Me.tipLabel.Location = New System.Drawing.Point(3, 100)
        Me.tipLabel.Name = "tipLabel"
        Me.tipLabel.Size = New System.Drawing.Size(282, 13)
        Me.tipLabel.TabIndex = 39
        Me.tipLabel.Text = "※ 해당 학기에서 기본으로 지정한 시간표를 불러옵니다"
        '
        'autoChk
        '
        Me.autoChk.AutoSize = True
        Me.autoChk.Checked = True
        Me.autoChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.autoChk.Location = New System.Drawing.Point(5, 78)
        Me.autoChk.Name = "autoChk"
        Me.autoChk.Size = New System.Drawing.Size(246, 19)
        Me.autoChk.TabIndex = 38
        Me.autoChk.Text = "자동으로 현재 기준 시간표를 불러옵니다"
        Me.autoChk.UseVisualStyleBackColor = True
        '
        'semesterCombo
        '
        Me.semesterCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.semesterCombo.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.semesterCombo.FormattingEnabled = True
        Me.semesterCombo.Items.AddRange(New Object() {"1학기", "여름학기", "2학기", "겨울학기"})
        Me.semesterCombo.Location = New System.Drawing.Point(115, 39)
        Me.semesterCombo.Name = "semesterCombo"
        Me.semesterCombo.Size = New System.Drawing.Size(135, 28)
        Me.semesterCombo.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(1, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(310, 20)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "우선, 불러올 시간표의 학기를 선택해 주세요."
        '
        'yearUpd
        '
        Me.yearUpd.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.yearUpd.Location = New System.Drawing.Point(5, 40)
        Me.yearUpd.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.yearUpd.Minimum = New Decimal(New Integer() {2010, 0, 0, 0})
        Me.yearUpd.Name = "yearUpd"
        Me.yearUpd.Size = New System.Drawing.Size(72, 27)
        Me.yearUpd.TabIndex = 34
        Me.yearUpd.Value = New Decimal(New Integer() {2010, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(83, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 21)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "년"
        '
        'Step2Panel
        '
        Me.Step2Panel.Controls.Add(Me.AgreementRTB)
        Me.Step2Panel.Controls.Add(Me.Label1)
        Me.Step2Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Step2Panel.Location = New System.Drawing.Point(0, 0)
        Me.Step2Panel.Name = "Step2Panel"
        Me.Step2Panel.Size = New System.Drawing.Size(358, 116)
        Me.Step2Panel.TabIndex = 0
        '
        'AgreementRTB
        '
        Me.AgreementRTB.BackColor = System.Drawing.Color.White
        Me.AgreementRTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AgreementRTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AgreementRTB.ForeColor = System.Drawing.Color.Black
        Me.AgreementRTB.Location = New System.Drawing.Point(0, 29)
        Me.AgreementRTB.Name = "AgreementRTB"
        Me.AgreementRTB.ReadOnly = True
        Me.AgreementRTB.Size = New System.Drawing.Size(358, 87)
        Me.AgreementRTB.TabIndex = 38
        Me.AgreementRTB.Text = resources.GetString("AgreementRTB.Text")
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.Label1.Size = New System.Drawing.Size(358, 29)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "다음 참고사항을 읽은 후 '로그인하기' 를 눌러 주세요."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.NextBT)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(15, 163)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.Panel4.Size = New System.Drawing.Size(358, 46)
        Me.Panel4.TabIndex = 35
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TitleLabel)
        Me.Panel2.Controls.Add(Me.CloseBT)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(15, 15)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(358, 32)
        Me.Panel2.TabIndex = 31
        '
        'TitleLabel
        '
        Me.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TitleLabel.Font = New System.Drawing.Font("맑은 고딕 Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(0, 0)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(326, 32)
        Me.TitleLabel.TabIndex = 28
        Me.TitleLabel.Text = "에브리타임 시간표 불러오기"
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CloseBT
        '
        Me.CloseBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.CloseBT.Image = Global.uTable.My.Resources.Resources.closeicon_b
        Me.CloseBT.Location = New System.Drawing.Point(326, 0)
        Me.CloseBT.Name = "CloseBT"
        Me.CloseBT.Size = New System.Drawing.Size(32, 32)
        Me.CloseBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CloseBT.TabIndex = 29
        Me.CloseBT.TabStop = False
        '
        'EverytimeSemesterSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(390, 226)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.uTable.My.Resources.Resources.ptable_icon
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "EverytimeSemesterSelector"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "에브리타임 시간표 불러오기"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Step1Panel.ResumeLayout(False)
        Me.Step1Panel.PerformLayout()
        CType(Me.yearUpd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Step2Panel.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NextBT As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TitleLabel As Label
    Friend WithEvents CloseBT As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Step2Panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Step1Panel As Panel
    Friend WithEvents autoChk As CheckBox
    Friend WithEvents semesterCombo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents yearUpd As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents AgreementRTB As RichTextBox
    Friend WithEvents tipLabel As Label
    Friend WithEvents Panel4 As Panel
End Class
