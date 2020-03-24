<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SetCourse
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetCourse))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CourseNameTB = New System.Windows.Forms.TextBox()
        Me.ApplyBT = New System.Windows.Forms.Button()
        Me.ProfTB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DayCombo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.MemoTB = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ColorButton = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PrevSetCombo = New System.Windows.Forms.ComboBox()
        Me.StartTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.EndTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.DeleteBT = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ColorPasteBT = New System.Windows.Forms.Button()
        Me.ColorCopyBT = New System.Windows.Forms.Button()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.CloseBT = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "수업명"
        '
        'CourseNameTB
        '
        Me.CourseNameTB.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CourseNameTB.Location = New System.Drawing.Point(18, 73)
        Me.CourseNameTB.Name = "CourseNameTB"
        Me.CourseNameTB.Size = New System.Drawing.Size(237, 25)
        Me.CourseNameTB.TabIndex = 1
        '
        'ApplyBT
        '
        Me.ApplyBT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ApplyBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ApplyBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ApplyBT.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ApplyBT.Location = New System.Drawing.Point(290, 299)
        Me.ApplyBT.Name = "ApplyBT"
        Me.ApplyBT.Size = New System.Drawing.Size(106, 32)
        Me.ApplyBT.TabIndex = 8
        Me.ApplyBT.Text = "추가"
        Me.ApplyBT.UseVisualStyleBackColor = False
        '
        'ProfTB
        '
        Me.ProfTB.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ProfTB.Location = New System.Drawing.Point(260, 73)
        Me.ProfTB.Name = "ProfTB"
        Me.ProfTB.Size = New System.Drawing.Size(136, 25)
        Me.ProfTB.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(257, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "교수명"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "수업 요일"
        '
        'DayCombo
        '
        Me.DayCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DayCombo.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DayCombo.FormattingEnabled = True
        Me.DayCombo.Items.AddRange(New Object() {"월요일", "화요일", "수요일", "목요일", "금요일", "토요일", "일요일"})
        Me.DayCombo.Location = New System.Drawing.Point(18, 131)
        Me.DayCombo.Name = "DayCombo"
        Me.DayCombo.Size = New System.Drawing.Size(121, 29)
        Me.DayCombo.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(142, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "수업 시작 시간"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label9.Location = New System.Drawing.Point(269, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 17)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "종료 시간"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 166)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(135, 17)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "메모 (강의실 위치 등)"
        '
        'MemoTB
        '
        Me.MemoTB.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MemoTB.Location = New System.Drawing.Point(18, 186)
        Me.MemoTB.Multiline = True
        Me.MemoTB.Name = "MemoTB"
        Me.MemoTB.Size = New System.Drawing.Size(378, 63)
        Me.MemoTB.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 265)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 17)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "지정 색상"
        '
        'ColorButton
        '
        Me.ColorButton.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColorButton.ForeColor = System.Drawing.Color.Gray
        Me.ColorButton.Location = New System.Drawing.Point(86, 264)
        Me.ColorButton.Name = "ColorButton"
        Me.ColorButton.Size = New System.Drawing.Size(75, 20)
        Me.ColorButton.TabIndex = 7
        Me.ColorButton.UseVisualStyleBackColor = False
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.FullOpen = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 289)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 15)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "기존 수업 불러오기..."
        '
        'PrevSetCombo
        '
        Me.PrevSetCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PrevSetCombo.FormattingEnabled = True
        Me.PrevSetCombo.Location = New System.Drawing.Point(21, 307)
        Me.PrevSetCombo.Name = "PrevSetCombo"
        Me.PrevSetCombo.Size = New System.Drawing.Size(215, 23)
        Me.PrevSetCombo.TabIndex = 9
        '
        'StartTimePicker
        '
        Me.StartTimePicker.CalendarFont = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.StartTimePicker.Checked = False
        Me.StartTimePicker.CustomFormat = "tt hh:mm"
        Me.StartTimePicker.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.StartTimePicker.Location = New System.Drawing.Point(145, 131)
        Me.StartTimePicker.Name = "StartTimePicker"
        Me.StartTimePicker.ShowUpDown = True
        Me.StartTimePicker.Size = New System.Drawing.Size(121, 29)
        Me.StartTimePicker.TabIndex = 4
        Me.StartTimePicker.Value = New Date(2001, 1, 1, 0, 0, 0, 0)
        '
        'EndTimePicker
        '
        Me.EndTimePicker.CalendarFont = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.EndTimePicker.CustomFormat = "tt hh:mm"
        Me.EndTimePicker.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EndTimePicker.Location = New System.Drawing.Point(272, 131)
        Me.EndTimePicker.Name = "EndTimePicker"
        Me.EndTimePicker.ShowUpDown = True
        Me.EndTimePicker.Size = New System.Drawing.Size(124, 29)
        Me.EndTimePicker.TabIndex = 5
        Me.EndTimePicker.Value = New Date(2001, 1, 1, 0, 0, 0, 0)
        '
        'DeleteBT
        '
        Me.DeleteBT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DeleteBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.DeleteBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeleteBT.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DeleteBT.Location = New System.Drawing.Point(290, 264)
        Me.DeleteBT.Name = "DeleteBT"
        Me.DeleteBT.Size = New System.Drawing.Size(106, 32)
        Me.DeleteBT.TabIndex = 10
        Me.DeleteBT.Text = "수업 삭제"
        Me.DeleteBT.UseVisualStyleBackColor = False
        Me.DeleteBT.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.ColorPasteBT)
        Me.Panel1.Controls.Add(Me.ColorCopyBT)
        Me.Panel1.Controls.Add(Me.CloseBT)
        Me.Panel1.Controls.Add(Me.TitleLabel)
        Me.Panel1.Controls.Add(Me.DeleteBT)
        Me.Panel1.Controls.Add(Me.EndTimePicker)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.StartTimePicker)
        Me.Panel1.Controls.Add(Me.CourseNameTB)
        Me.Panel1.Controls.Add(Me.PrevSetCombo)
        Me.Panel1.Controls.Add(Me.ApplyBT)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.ProfTB)
        Me.Panel1.Controls.Add(Me.ColorButton)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.MemoTB)
        Me.Panel1.Controls.Add(Me.DayCombo)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(15)
        Me.Panel1.Size = New System.Drawing.Size(414, 349)
        Me.Panel1.TabIndex = 26
        '
        'ColorPasteBT
        '
        Me.ColorPasteBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColorPasteBT.Font = New System.Drawing.Font("맑은 고딕", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ColorPasteBT.Location = New System.Drawing.Point(203, 264)
        Me.ColorPasteBT.Name = "ColorPasteBT"
        Me.ColorPasteBT.Size = New System.Drawing.Size(38, 20)
        Me.ColorPasteBT.TabIndex = 29
        Me.ColorPasteBT.Text = "적용"
        Me.ColorPasteBT.UseVisualStyleBackColor = True
        '
        'ColorCopyBT
        '
        Me.ColorCopyBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColorCopyBT.Font = New System.Drawing.Font("맑은 고딕", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ColorCopyBT.Location = New System.Drawing.Point(164, 264)
        Me.ColorCopyBT.Name = "ColorCopyBT"
        Me.ColorCopyBT.Size = New System.Drawing.Size(38, 20)
        Me.ColorCopyBT.TabIndex = 28
        Me.ColorCopyBT.Text = "복사"
        Me.ColorCopyBT.UseVisualStyleBackColor = True
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("맑은 고딕 Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(18, 15)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(153, 30)
        Me.TitleLabel.TabIndex = 26
        Me.TitleLabel.Text = "수업 추가/수정"
        '
        'CloseBT
        '
        Me.CloseBT.Image = Global.uTable.My.Resources.Resources.closeicon_b
        Me.CloseBT.Location = New System.Drawing.Point(364, 18)
        Me.CloseBT.Name = "CloseBT"
        Me.CloseBT.Size = New System.Drawing.Size(32, 32)
        Me.CloseBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CloseBT.TabIndex = 27
        Me.CloseBT.TabStop = False
        '
        'SetCourse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(416, 351)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SetCourse"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SetCourse"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents CourseNameTB As TextBox
    Friend WithEvents ApplyBT As Button
    Friend WithEvents ProfTB As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DayCombo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents MemoTB As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ColorButton As Button
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Label12 As Label
    Friend WithEvents PrevSetCombo As ComboBox
    Friend WithEvents StartTimePicker As DateTimePicker
    Friend WithEvents EndTimePicker As DateTimePicker
    Friend WithEvents DeleteBT As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CloseBT As PictureBox
    Friend WithEvents TitleLabel As Label
    Friend WithEvents ColorPasteBT As Button
    Friend WithEvents ColorCopyBT As Button
End Class
