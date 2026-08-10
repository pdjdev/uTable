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
        Me.CloseBT = New System.Windows.Forms.PictureBox()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Noto Sans KR", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(22, 66)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "수업명"
        '
        'CourseNameTB
        '
        Me.CourseNameTB.Font = New System.Drawing.Font("Noto Sans KR", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CourseNameTB.Location = New System.Drawing.Point(22, 91)
        Me.CourseNameTB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CourseNameTB.MaxLength = 1000
        Me.CourseNameTB.Name = "CourseNameTB"
        Me.CourseNameTB.Size = New System.Drawing.Size(295, 31)
        Me.CourseNameTB.TabIndex = 1
        '
        'ApplyBT
        '
        Me.ApplyBT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ApplyBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ApplyBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ApplyBT.Font = New System.Drawing.Font("Noto Sans KR", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ApplyBT.Location = New System.Drawing.Point(362, 374)
        Me.ApplyBT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ApplyBT.Name = "ApplyBT"
        Me.ApplyBT.Size = New System.Drawing.Size(132, 40)
        Me.ApplyBT.TabIndex = 8
        Me.ApplyBT.Text = "추가"
        Me.ApplyBT.UseVisualStyleBackColor = False
        '
        'ProfTB
        '
        Me.ProfTB.Font = New System.Drawing.Font("Noto Sans KR", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ProfTB.Location = New System.Drawing.Point(325, 91)
        Me.ProfTB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ProfTB.MaxLength = 1000
        Me.ProfTB.Name = "ProfTB"
        Me.ProfTB.Size = New System.Drawing.Size(169, 31)
        Me.ProfTB.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Noto Sans KR", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(321, 66)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "교수명"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Noto Sans KR", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(22, 139)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 21)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "수업 요일"
        '
        'DayCombo
        '
        Me.DayCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DayCombo.Font = New System.Drawing.Font("Noto Sans KR", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DayCombo.FormattingEnabled = True
        Me.DayCombo.Items.AddRange(New Object() {"월요일", "화요일", "수요일", "목요일", "금요일", "토요일", "일요일"})
        Me.DayCombo.Location = New System.Drawing.Point(22, 164)
        Me.DayCombo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DayCombo.Name = "DayCombo"
        Me.DayCombo.Size = New System.Drawing.Size(150, 37)
        Me.DayCombo.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Noto Sans KR", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(178, 139)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 21)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "수업 시작 시간"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Noto Sans KR", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(336, 139)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 21)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "종료 시간"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Noto Sans KR", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(22, 208)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 21)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "메모 (강의실 위치 등)"
        '
        'MemoTB
        '
        Me.MemoTB.Font = New System.Drawing.Font("Noto Sans KR", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MemoTB.Location = New System.Drawing.Point(22, 232)
        Me.MemoTB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MemoTB.MaxLength = 20000
        Me.MemoTB.Multiline = True
        Me.MemoTB.Name = "MemoTB"
        Me.MemoTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.MemoTB.Size = New System.Drawing.Size(472, 78)
        Me.MemoTB.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Noto Sans KR", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(22, 330)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 21)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "지정 색상"
        '
        'ColorButton
        '
        Me.ColorButton.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColorButton.ForeColor = System.Drawing.Color.Gray
        Me.ColorButton.Location = New System.Drawing.Point(98, 330)
        Me.ColorButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ColorButton.Name = "ColorButton"
        Me.ColorButton.Size = New System.Drawing.Size(94, 25)
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
        Me.Label12.Font = New System.Drawing.Font("Noto Sans KR", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label12.Location = New System.Drawing.Point(22, 361)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(142, 21)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "기존 수업 불러오기..."
        '
        'PrevSetCombo
        '
        Me.PrevSetCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PrevSetCombo.FormattingEnabled = True
        Me.PrevSetCombo.Location = New System.Drawing.Point(26, 384)
        Me.PrevSetCombo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PrevSetCombo.Name = "PrevSetCombo"
        Me.PrevSetCombo.Size = New System.Drawing.Size(268, 29)
        Me.PrevSetCombo.TabIndex = 9
        '
        'StartTimePicker
        '
        Me.StartTimePicker.CalendarFont = New System.Drawing.Font("Noto Sans KR", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.StartTimePicker.Checked = False
        Me.StartTimePicker.CustomFormat = "tt hh:mm"
        Me.StartTimePicker.Font = New System.Drawing.Font("Noto Sans KR", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.StartTimePicker.Location = New System.Drawing.Point(181, 164)
        Me.StartTimePicker.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.StartTimePicker.Name = "StartTimePicker"
        Me.StartTimePicker.ShowUpDown = True
        Me.StartTimePicker.Size = New System.Drawing.Size(150, 36)
        Me.StartTimePicker.TabIndex = 4
        Me.StartTimePicker.Value = New Date(2001, 1, 1, 0, 0, 0, 0)
        '
        'EndTimePicker
        '
        Me.EndTimePicker.CalendarFont = New System.Drawing.Font("Noto Sans KR", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.EndTimePicker.CustomFormat = "tt hh:mm"
        Me.EndTimePicker.Font = New System.Drawing.Font("Noto Sans KR", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EndTimePicker.Location = New System.Drawing.Point(340, 164)
        Me.EndTimePicker.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EndTimePicker.Name = "EndTimePicker"
        Me.EndTimePicker.ShowUpDown = True
        Me.EndTimePicker.Size = New System.Drawing.Size(154, 36)
        Me.EndTimePicker.TabIndex = 5
        Me.EndTimePicker.Value = New Date(2001, 1, 1, 0, 0, 0, 0)
        '
        'DeleteBT
        '
        Me.DeleteBT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.DeleteBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.DeleteBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DeleteBT.Font = New System.Drawing.Font("Noto Sans KR", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DeleteBT.Location = New System.Drawing.Point(362, 330)
        Me.DeleteBT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DeleteBT.Name = "DeleteBT"
        Me.DeleteBT.Size = New System.Drawing.Size(132, 40)
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
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(19, 19, 19, 19)
        Me.Panel1.Size = New System.Drawing.Size(518, 437)
        Me.Panel1.TabIndex = 26
        '
        'ColorPasteBT
        '
        Me.ColorPasteBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColorPasteBT.Font = New System.Drawing.Font("Noto Sans KR", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ColorPasteBT.Location = New System.Drawing.Point(244, 330)
        Me.ColorPasteBT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ColorPasteBT.Name = "ColorPasteBT"
        Me.ColorPasteBT.Size = New System.Drawing.Size(48, 25)
        Me.ColorPasteBT.TabIndex = 29
        Me.ColorPasteBT.Text = "적용"
        Me.ColorPasteBT.UseVisualStyleBackColor = True
        '
        'ColorCopyBT
        '
        Me.ColorCopyBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColorCopyBT.Font = New System.Drawing.Font("Noto Sans KR", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ColorCopyBT.Location = New System.Drawing.Point(195, 330)
        Me.ColorCopyBT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ColorCopyBT.Name = "ColorCopyBT"
        Me.ColorCopyBT.Size = New System.Drawing.Size(48, 25)
        Me.ColorCopyBT.TabIndex = 28
        Me.ColorCopyBT.Text = "복사"
        Me.ColorCopyBT.UseVisualStyleBackColor = True
        '
        'CloseBT
        '
        Me.CloseBT.Image = Global.uTable.My.Resources.Resources.closeicon_b
        Me.CloseBT.Location = New System.Drawing.Point(455, 22)
        Me.CloseBT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CloseBT.Name = "CloseBT"
        Me.CloseBT.Size = New System.Drawing.Size(40, 40)
        Me.CloseBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CloseBT.TabIndex = 27
        Me.CloseBT.TabStop = False
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Noto Sans KR", 14.0!)
        Me.TitleLabel.Location = New System.Drawing.Point(21, 23)
        Me.TitleLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(163, 35)
        Me.TitleLabel.TabIndex = 26
        Me.TitleLabel.Text = "수업 추가/수정"
        '
        'SetCourse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(520, 439)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Noto Sans KR", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.uTable.My.Resources.Resources.ptable_icon
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SetCourse"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "수업 추가/수정"
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
    Friend WithEvents ColorPasteBT As Button
    Friend WithEvents ColorCopyBT As Button
    Friend WithEvents CloseBT As PictureBox
    Friend WithEvents TitleLabel As Label
End Class
