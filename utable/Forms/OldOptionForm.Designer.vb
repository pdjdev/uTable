<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OldOptionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OldOptionForm))
        Me.TabBT1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabBTB3 = New System.Windows.Forms.Panel()
        Me.TabBT3 = New System.Windows.Forms.Label()
        Me.TabBTB2 = New System.Windows.Forms.Panel()
        Me.TabBT2 = New System.Windows.Forms.Label()
        Me.TabBTB1 = New System.Windows.Forms.Panel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TabPage3 = New System.Windows.Forms.Panel()
        Me.FeedbackLabel = New System.Windows.Forms.LinkLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SnapToEdgeChk = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StartupChk = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.D_ThemeRbt = New System.Windows.Forms.RadioButton()
        Me.W_ThemeRbt = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FadeEffectChk = New System.Windows.Forms.CheckBox()
        Me.MinStartChk = New System.Windows.Forms.CheckBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TabPage2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ShowProfChk = New System.Windows.Forms.CheckBox()
        Me.FontPrevLabel = New System.Windows.Forms.Label()
        Me.CustomFontBT = New System.Windows.Forms.Button()
        Me.ShowMemoChk = New System.Windows.Forms.CheckBox()
        Me.ShowDayChk = New System.Windows.Forms.CheckBox()
        Me.CustomFontChk = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BlackTextChk = New System.Windows.Forms.CheckBox()
        Me.AlwaysExpandChk = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ExpandCellChk = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.WebPageLabel = New System.Windows.Forms.LinkLabel()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.CloseBT = New System.Windows.Forms.PictureBox()
        Me.BannerPictureBox = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabBTB3.SuspendLayout()
        Me.TabBTB2.SuspendLayout()
        Me.TabBTB1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BannerPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabBT1
        '
        Me.TabBT1.BackColor = System.Drawing.Color.White
        Me.TabBT1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabBT1.Font = New System.Drawing.Font("맑은 고딕", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TabBT1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TabBT1.Location = New System.Drawing.Point(0, 0)
        Me.TabBT1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabBT1.Name = "TabBT1"
        Me.TabBT1.Size = New System.Drawing.Size(102, 28)
        Me.TabBT1.TabIndex = 2
        Me.TabBT1.Text = "기본 설정"
        Me.TabBT1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TabBTB3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabBTB2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TabBTB1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(18, 18)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(271, 32)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TabBTB3
        '
        Me.TabBTB3.BackColor = System.Drawing.Color.DimGray
        Me.TabBTB3.Controls.Add(Me.TabBT3)
        Me.TabBTB3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabBTB3.Location = New System.Drawing.Point(215, 0)
        Me.TabBTB3.Margin = New System.Windows.Forms.Padding(0)
        Me.TabBTB3.Name = "TabBTB3"
        Me.TabBTB3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.TabBTB3.Size = New System.Drawing.Size(56, 30)
        Me.TabBTB3.TabIndex = 5
        '
        'TabBT3
        '
        Me.TabBT3.BackColor = System.Drawing.Color.White
        Me.TabBT3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabBT3.Font = New System.Drawing.Font("맑은 고딕", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TabBT3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TabBT3.Location = New System.Drawing.Point(0, 0)
        Me.TabBT3.Margin = New System.Windows.Forms.Padding(0)
        Me.TabBT3.Name = "TabBT3"
        Me.TabBT3.Size = New System.Drawing.Size(56, 28)
        Me.TabBT3.TabIndex = 2
        Me.TabBT3.Text = "정보"
        Me.TabBT3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabBTB2
        '
        Me.TabBTB2.BackColor = System.Drawing.Color.DimGray
        Me.TabBTB2.Controls.Add(Me.TabBT2)
        Me.TabBTB2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabBTB2.Location = New System.Drawing.Point(102, 0)
        Me.TabBTB2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabBTB2.Name = "TabBTB2"
        Me.TabBTB2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.TabBTB2.Size = New System.Drawing.Size(113, 30)
        Me.TabBTB2.TabIndex = 4
        '
        'TabBT2
        '
        Me.TabBT2.BackColor = System.Drawing.Color.White
        Me.TabBT2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabBT2.Font = New System.Drawing.Font("맑은 고딕", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TabBT2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TabBT2.Location = New System.Drawing.Point(0, 0)
        Me.TabBT2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabBT2.Name = "TabBT2"
        Me.TabBT2.Size = New System.Drawing.Size(113, 28)
        Me.TabBT2.TabIndex = 2
        Me.TabBT2.Text = "시간표 설정"
        Me.TabBT2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabBTB1
        '
        Me.TabBTB1.BackColor = System.Drawing.Color.DimGray
        Me.TabBTB1.Controls.Add(Me.TabBT1)
        Me.TabBTB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabBTB1.Location = New System.Drawing.Point(0, 0)
        Me.TabBTB1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabBTB1.Name = "TabBTB1"
        Me.TabBTB1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.TabBTB1.Size = New System.Drawing.Size(102, 30)
        Me.TabBTB1.TabIndex = 3
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Black
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 45)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(473, 129)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.RichTextBox1)
        Me.TabPage3.Controls.Add(Me.FeedbackLabel)
        Me.TabPage3.Controls.Add(Me.BannerPictureBox)
        Me.TabPage3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabPage3.Location = New System.Drawing.Point(0, 0)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(473, 187)
        Me.TabPage3.TabIndex = 3
        '
        'FeedbackLabel
        '
        Me.FeedbackLabel.AutoSize = True
        Me.FeedbackLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FeedbackLabel.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FeedbackLabel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FeedbackLabel.Location = New System.Drawing.Point(0, 174)
        Me.FeedbackLabel.MinimumSize = New System.Drawing.Size(473, 0)
        Me.FeedbackLabel.Name = "FeedbackLabel"
        Me.FeedbackLabel.Size = New System.Drawing.Size(473, 13)
        Me.FeedbackLabel.TabIndex = 6
        Me.FeedbackLabel.TabStop = True
        Me.FeedbackLabel.Text = "오류 보고/피드백 남기기"
        Me.FeedbackLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 20)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "모양 설정"
        '
        'SnapToEdgeChk
        '
        Me.SnapToEdgeChk.AutoSize = True
        Me.SnapToEdgeChk.Location = New System.Drawing.Point(8, 113)
        Me.SnapToEdgeChk.Name = "SnapToEdgeChk"
        Me.SnapToEdgeChk.Size = New System.Drawing.Size(210, 19)
        Me.SnapToEdgeChk.TabIndex = 6
        Me.SnapToEdgeChk.Text = "화면 모서리에 자동으로 붙게 하기"
        Me.SnapToEdgeChk.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(250, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 45)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "※ 실행 파일(.exe)의 위치가" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "변경되는 경우 다시 설정하셔야" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "합니다."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "시작 설정"
        '
        'StartupChk
        '
        Me.StartupChk.AutoSize = True
        Me.StartupChk.Location = New System.Drawing.Point(8, 36)
        Me.StartupChk.Name = "StartupChk"
        Me.StartupChk.Size = New System.Drawing.Size(227, 19)
        Me.StartupChk.TabIndex = 3
        Me.StartupChk.Text = "Windows 시작 시 같이 프로그램 실행"
        Me.StartupChk.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.FadeEffectChk)
        Me.TabPage1.Controls.Add(Me.MinStartChk)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.SnapToEdgeChk)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.StartupChk)
        Me.TabPage1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabPage1.Location = New System.Drawing.Point(0, 0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(473, 187)
        Me.TabPage1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.D_ThemeRbt)
        Me.Panel1.Controls.Add(Me.W_ThemeRbt)
        Me.Panel1.Location = New System.Drawing.Point(251, 111)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(199, 53)
        Me.Panel1.TabIndex = 11
        '
        'D_ThemeRbt
        '
        Me.D_ThemeRbt.AutoSize = True
        Me.D_ThemeRbt.Location = New System.Drawing.Point(3, 24)
        Me.D_ThemeRbt.Name = "D_ThemeRbt"
        Me.D_ThemeRbt.Size = New System.Drawing.Size(49, 19)
        Me.D_ThemeRbt.TabIndex = 1
        Me.D_ThemeRbt.TabStop = True
        Me.D_ThemeRbt.Text = "다크"
        Me.D_ThemeRbt.UseVisualStyleBackColor = True
        '
        'W_ThemeRbt
        '
        Me.W_ThemeRbt.AutoSize = True
        Me.W_ThemeRbt.Location = New System.Drawing.Point(3, 3)
        Me.W_ThemeRbt.Name = "W_ThemeRbt"
        Me.W_ThemeRbt.Size = New System.Drawing.Size(97, 19)
        Me.W_ThemeRbt.TabIndex = 0
        Me.W_ThemeRbt.TabStop = True
        Me.W_ThemeRbt.Text = "화이트 (기본)"
        Me.W_ThemeRbt.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(249, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "테마 선택"
        '
        'FadeEffectChk
        '
        Me.FadeEffectChk.AutoSize = True
        Me.FadeEffectChk.Location = New System.Drawing.Point(8, 135)
        Me.FadeEffectChk.Name = "FadeEffectChk"
        Me.FadeEffectChk.Size = New System.Drawing.Size(199, 19)
        Me.FadeEffectChk.TabIndex = 9
        Me.FadeEffectChk.Text = "페이드 인/아웃 애니메이션 적용"
        Me.FadeEffectChk.UseVisualStyleBackColor = True
        '
        'MinStartChk
        '
        Me.MinStartChk.AutoSize = True
        Me.MinStartChk.Location = New System.Drawing.Point(8, 58)
        Me.MinStartChk.Name = "MinStartChk"
        Me.MinStartChk.Size = New System.Drawing.Size(146, 19)
        Me.MinStartChk.TabIndex = 8
        Me.MinStartChk.Text = "최소화 된 상태로 시작"
        Me.MinStartChk.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TabPage2)
        Me.Panel5.Controls.Add(Me.TabPage3)
        Me.Panel5.Controls.Add(Me.TabPage1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(15, 58)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(473, 187)
        Me.Panel5.TabIndex = 3
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.ShowProfChk)
        Me.TabPage2.Controls.Add(Me.FontPrevLabel)
        Me.TabPage2.Controls.Add(Me.CustomFontBT)
        Me.TabPage2.Controls.Add(Me.ShowMemoChk)
        Me.TabPage2.Controls.Add(Me.ShowDayChk)
        Me.TabPage2.Controls.Add(Me.CustomFontChk)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.BlackTextChk)
        Me.TabPage2.Controls.Add(Me.AlwaysExpandChk)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.ExpandCellChk)
        Me.TabPage2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabPage2.Location = New System.Drawing.Point(0, 0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(473, 187)
        Me.TabPage2.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(6, 162)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(388, 15)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "※ 사용자 지정 글꼴은 프로그램을 다시 시작하여야 완전히 적용됩니다."
        '
        'ShowProfChk
        '
        Me.ShowProfChk.AutoSize = True
        Me.ShowProfChk.Location = New System.Drawing.Point(376, 36)
        Me.ShowProfChk.Name = "ShowProfChk"
        Me.ShowProfChk.Size = New System.Drawing.Size(90, 19)
        Me.ShowProfChk.TabIndex = 19
        Me.ShowProfChk.Text = "교수명 표시"
        Me.ShowProfChk.UseVisualStyleBackColor = True
        '
        'FontPrevLabel
        '
        Me.FontPrevLabel.AutoSize = True
        Me.FontPrevLabel.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FontPrevLabel.Location = New System.Drawing.Point(329, 132)
        Me.FontPrevLabel.Name = "FontPrevLabel"
        Me.FontPrevLabel.Size = New System.Drawing.Size(104, 20)
        Me.FontPrevLabel.TabIndex = 18
        Me.FontPrevLabel.Text = "Abc가나다012"
        '
        'CustomFontBT
        '
        Me.CustomFontBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CustomFontBT.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CustomFontBT.Location = New System.Drawing.Point(160, 132)
        Me.CustomFontBT.Name = "CustomFontBT"
        Me.CustomFontBT.Size = New System.Drawing.Size(163, 22)
        Me.CustomFontBT.TabIndex = 17
        Me.CustomFontBT.Text = "사용자 지정 글꼴 선택..."
        Me.CustomFontBT.UseVisualStyleBackColor = True
        '
        'ShowMemoChk
        '
        Me.ShowMemoChk.AutoSize = True
        Me.ShowMemoChk.Location = New System.Drawing.Point(286, 57)
        Me.ShowMemoChk.Name = "ShowMemoChk"
        Me.ShowMemoChk.Size = New System.Drawing.Size(78, 19)
        Me.ShowMemoChk.TabIndex = 16
        Me.ShowMemoChk.Text = "메모 표시"
        Me.ShowMemoChk.UseVisualStyleBackColor = True
        '
        'ShowDayChk
        '
        Me.ShowDayChk.AutoSize = True
        Me.ShowDayChk.Location = New System.Drawing.Point(286, 36)
        Me.ShowDayChk.Name = "ShowDayChk"
        Me.ShowDayChk.Size = New System.Drawing.Size(78, 19)
        Me.ShowDayChk.TabIndex = 15
        Me.ShowDayChk.Text = "요일 표시"
        Me.ShowDayChk.UseVisualStyleBackColor = True
        '
        'CustomFontChk
        '
        Me.CustomFontChk.AutoSize = True
        Me.CustomFontChk.Location = New System.Drawing.Point(8, 135)
        Me.CustomFontChk.Name = "CustomFontChk"
        Me.CustomFontChk.Size = New System.Drawing.Size(146, 19)
        Me.CustomFontChk.TabIndex = 14
        Me.CustomFontChk.Text = "사용자 지정 글꼴 설정"
        Me.CustomFontChk.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "스타일 설정"
        '
        'BlackTextChk
        '
        Me.BlackTextChk.AutoSize = True
        Me.BlackTextChk.Location = New System.Drawing.Point(8, 113)
        Me.BlackTextChk.Name = "BlackTextChk"
        Me.BlackTextChk.Size = New System.Drawing.Size(170, 19)
        Me.BlackTextChk.TabIndex = 12
        Me.BlackTextChk.Text = "표 글씨 색상 반전 (검은색)"
        Me.BlackTextChk.UseVisualStyleBackColor = True
        '
        'AlwaysExpandChk
        '
        Me.AlwaysExpandChk.AutoSize = True
        Me.AlwaysExpandChk.Location = New System.Drawing.Point(8, 58)
        Me.AlwaysExpandChk.Name = "AlwaysExpandChk"
        Me.AlwaysExpandChk.Size = New System.Drawing.Size(266, 19)
        Me.AlwaysExpandChk.TabIndex = 11
        Me.AlwaysExpandChk.Text = "수업 시간에 상관없이 내용에 맞춰 표 늘이기"
        Me.AlwaysExpandChk.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "표시 설정"
        '
        'ExpandCellChk
        '
        Me.ExpandCellChk.AutoSize = True
        Me.ExpandCellChk.Location = New System.Drawing.Point(8, 36)
        Me.ExpandCellChk.Name = "ExpandCellChk"
        Me.ExpandCellChk.Size = New System.Drawing.Size(210, 19)
        Me.ExpandCellChk.TabIndex = 9
        Me.ExpandCellChk.Text = "마우스 올리면 가린 내용 확장하기"
        Me.ExpandCellChk.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.WebPageLabel)
        Me.Panel2.Controls.Add(Me.CloseBT)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(15)
        Me.Panel2.Size = New System.Drawing.Size(503, 260)
        Me.Panel2.TabIndex = 1
        '
        'WebPageLabel
        '
        Me.WebPageLabel.AutoSize = True
        Me.WebPageLabel.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.WebPageLabel.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.WebPageLabel.Location = New System.Drawing.Point(324, 21)
        Me.WebPageLabel.Name = "WebPageLabel"
        Me.WebPageLabel.Size = New System.Drawing.Size(125, 26)
        Me.WebPageLabel.TabIndex = 5
        Me.WebPageLabel.TabStop = True
        Me.WebPageLabel.Text = "프로그램 페이지로 가기" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(최신 버전 확인)"
        Me.WebPageLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'FontDialog1
        '
        Me.FontDialog1.ShowEffects = False
        '
        'CloseBT
        '
        Me.CloseBT.Location = New System.Drawing.Point(454, 18)
        Me.CloseBT.Name = "CloseBT"
        Me.CloseBT.Size = New System.Drawing.Size(32, 32)
        Me.CloseBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CloseBT.TabIndex = 4
        Me.CloseBT.TabStop = False
        '
        'BannerPictureBox
        '
        Me.BannerPictureBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.BannerPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.BannerPictureBox.Name = "BannerPictureBox"
        Me.BannerPictureBox.Size = New System.Drawing.Size(473, 45)
        Me.BannerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BannerPictureBox.TabIndex = 4
        Me.BannerPictureBox.TabStop = False
        '
        'OptionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(505, 262)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = My.Resources.ptable_icon
        Me.MaximumSize = New System.Drawing.Size(505, 262)
        Me.Name = "OptionForm"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "InfoForm"
        Me.TransparencyKey = System.Drawing.Color.Magenta
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabBTB3.ResumeLayout(False)
        Me.TabBTB2.ResumeLayout(False)
        Me.TabBTB1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.CloseBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BannerPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabBT1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TabBTB1 As Panel
    Friend WithEvents BannerPictureBox As PictureBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents SnapToEdgeChk As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents StartupChk As CheckBox
    Friend WithEvents TabPage1 As Panel
    Friend WithEvents CloseBT As PictureBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TabPage3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabBTB3 As Panel
    Friend WithEvents TabBT3 As Label
    Friend WithEvents TabBTB2 As Panel
    Friend WithEvents TabBT2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents D_ThemeRbt As RadioButton
    Friend WithEvents W_ThemeRbt As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents FadeEffectChk As CheckBox
    Friend WithEvents MinStartChk As CheckBox
    Friend WithEvents TabPage2 As Panel
    Friend WithEvents ShowMemoChk As CheckBox
    Friend WithEvents ShowDayChk As CheckBox
    Friend WithEvents CustomFontChk As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BlackTextChk As CheckBox
    Friend WithEvents AlwaysExpandChk As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ExpandCellChk As CheckBox
    Friend WithEvents FontPrevLabel As Label
    Friend WithEvents CustomFontBT As Button
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents ShowProfChk As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents WebPageLabel As LinkLabel
    Friend WithEvents FeedbackLabel As LinkLabel
End Class
