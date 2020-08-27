<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.TimeTable = New System.Windows.Forms.TableLayoutPanel()
        Me.SunPanel = New System.Windows.Forms.Panel()
        Me.SatPanel = New System.Windows.Forms.Panel()
        Me.FriPanel = New System.Windows.Forms.Panel()
        Me.ThuPanel = New System.Windows.Forms.Panel()
        Me.WedPanel = New System.Windows.Forms.Panel()
        Me.TuePanel = New System.Windows.Forms.Panel()
        Me.MonPanel = New System.Windows.Forms.Panel()
        Me.TopPanel = New System.Windows.Forms.Panel()
        Me.TitleEditBT = New System.Windows.Forms.PictureBox()
        Me.TableTitleLabel = New System.Windows.Forms.Label()
        Me.RenameTitleTextBox = New System.Windows.Forms.TextBox()
        Me.RefreshBT = New System.Windows.Forms.Button()
        Me.AddCourseBT = New System.Windows.Forms.Button()
        Me.MenuBT = New System.Windows.Forms.Button()
        Me.MinBT = New System.Windows.Forms.PictureBox()
        Me.DayTable = New System.Windows.Forms.TableLayoutPanel()
        Me.SunLabel = New System.Windows.Forms.Label()
        Me.SatLabel = New System.Windows.Forms.Label()
        Me.FriLabel = New System.Windows.Forms.Label()
        Me.ThuLabel = New System.Windows.Forms.Label()
        Me.WedLabel = New System.Windows.Forms.Label()
        Me.TueLabel = New System.Windows.Forms.Label()
        Me.MonLabel = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.SizeLabel = New System.Windows.Forms.Label()
        Me.BT1_menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BT1MenuTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangeThemeItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_1_1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_1_2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnapToEdgeItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorSettingItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllColorSetItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllDarkerItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllBrighterItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpacitySelectItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.GetFromETItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OptionItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimeCheck = New System.Windows.Forms.Timer(Me.components)
        Me.hideani = New System.Windows.Forms.Timer(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.TimeTable.SuspendLayout()
        Me.TopPanel.SuspendLayout()
        CType(Me.TitleEditBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DayTable.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.BT1_menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'TimeTable
        '
        Me.TimeTable.ColumnCount = 7
        Me.TimeTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TimeTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TimeTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TimeTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TimeTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TimeTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TimeTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TimeTable.Controls.Add(Me.SunPanel, 6, 0)
        Me.TimeTable.Controls.Add(Me.SatPanel, 5, 0)
        Me.TimeTable.Controls.Add(Me.FriPanel, 4, 0)
        Me.TimeTable.Controls.Add(Me.ThuPanel, 3, 0)
        Me.TimeTable.Controls.Add(Me.WedPanel, 2, 0)
        Me.TimeTable.Controls.Add(Me.TuePanel, 1, 0)
        Me.TimeTable.Controls.Add(Me.MonPanel, 0, 0)
        Me.TimeTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TimeTable.Location = New System.Drawing.Point(0, 70)
        Me.TimeTable.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TimeTable.Name = "TimeTable"
        Me.TimeTable.RowCount = 1
        Me.TimeTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TimeTable.Size = New System.Drawing.Size(814, 570)
        Me.TimeTable.TabIndex = 0
        '
        'SunPanel
        '
        Me.SunPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SunPanel.Location = New System.Drawing.Point(696, 0)
        Me.SunPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.SunPanel.Name = "SunPanel"
        Me.SunPanel.Size = New System.Drawing.Size(118, 570)
        Me.SunPanel.TabIndex = 6
        '
        'SatPanel
        '
        Me.SatPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SatPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SatPanel.Location = New System.Drawing.Point(580, 0)
        Me.SatPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.SatPanel.Name = "SatPanel"
        Me.SatPanel.Size = New System.Drawing.Size(116, 570)
        Me.SatPanel.TabIndex = 5
        '
        'FriPanel
        '
        Me.FriPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FriPanel.Location = New System.Drawing.Point(464, 0)
        Me.FriPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.FriPanel.Name = "FriPanel"
        Me.FriPanel.Size = New System.Drawing.Size(116, 570)
        Me.FriPanel.TabIndex = 4
        '
        'ThuPanel
        '
        Me.ThuPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ThuPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ThuPanel.Location = New System.Drawing.Point(348, 0)
        Me.ThuPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ThuPanel.Name = "ThuPanel"
        Me.ThuPanel.Size = New System.Drawing.Size(116, 570)
        Me.ThuPanel.TabIndex = 3
        '
        'WedPanel
        '
        Me.WedPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WedPanel.Location = New System.Drawing.Point(232, 0)
        Me.WedPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.WedPanel.Name = "WedPanel"
        Me.WedPanel.Size = New System.Drawing.Size(116, 570)
        Me.WedPanel.TabIndex = 2
        '
        'TuePanel
        '
        Me.TuePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TuePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TuePanel.Location = New System.Drawing.Point(116, 0)
        Me.TuePanel.Margin = New System.Windows.Forms.Padding(0)
        Me.TuePanel.Name = "TuePanel"
        Me.TuePanel.Size = New System.Drawing.Size(116, 570)
        Me.TuePanel.TabIndex = 1
        '
        'MonPanel
        '
        Me.MonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MonPanel.Location = New System.Drawing.Point(0, 0)
        Me.MonPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MonPanel.Name = "MonPanel"
        Me.MonPanel.Size = New System.Drawing.Size(116, 570)
        Me.MonPanel.TabIndex = 0
        '
        'TopPanel
        '
        Me.TopPanel.Controls.Add(Me.TitleEditBT)
        Me.TopPanel.Controls.Add(Me.TableTitleLabel)
        Me.TopPanel.Controls.Add(Me.RenameTitleTextBox)
        Me.TopPanel.Controls.Add(Me.RefreshBT)
        Me.TopPanel.Controls.Add(Me.AddCourseBT)
        Me.TopPanel.Controls.Add(Me.MenuBT)
        Me.TopPanel.Controls.Add(Me.MinBT)
        Me.TopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopPanel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Padding = New System.Windows.Forms.Padding(5)
        Me.TopPanel.Size = New System.Drawing.Size(814, 40)
        Me.TopPanel.TabIndex = 1
        '
        'TitleEditBT
        '
        Me.TitleEditBT.BackColor = System.Drawing.Color.Transparent
        Me.TitleEditBT.Dock = System.Windows.Forms.DockStyle.Left
        Me.TitleEditBT.Image = Global.uTable.My.Resources.Resources.bt_titleedit
        Me.TitleEditBT.Location = New System.Drawing.Point(368, 5)
        Me.TitleEditBT.Name = "TitleEditBT"
        Me.TitleEditBT.Size = New System.Drawing.Size(20, 30)
        Me.TitleEditBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.TitleEditBT.TabIndex = 31
        Me.TitleEditBT.TabStop = False
        '
        'TableTitleLabel
        '
        Me.TableTitleLabel.AutoSize = True
        Me.TableTitleLabel.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableTitleLabel.Font = New System.Drawing.Font("맑은 고딕 Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TableTitleLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableTitleLabel.Location = New System.Drawing.Point(183, 5)
        Me.TableTitleLabel.Name = "TableTitleLabel"
        Me.TableTitleLabel.Size = New System.Drawing.Size(185, 30)
        Me.TableTitleLabel.TabIndex = 29
        Me.TableTitleLabel.Text = "2020-1학기 시간표"
        '
        'RenameTitleTextBox
        '
        Me.RenameTitleTextBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.RenameTitleTextBox.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.RenameTitleTextBox.Location = New System.Drawing.Point(5, 5)
        Me.RenameTitleTextBox.Name = "RenameTitleTextBox"
        Me.RenameTitleTextBox.Size = New System.Drawing.Size(178, 33)
        Me.RenameTitleTextBox.TabIndex = 30
        Me.RenameTitleTextBox.Visible = False
        '
        'RefreshBT
        '
        Me.RefreshBT.BackColor = System.Drawing.Color.Transparent
        Me.RefreshBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.RefreshBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.RefreshBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RefreshBT.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.RefreshBT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RefreshBT.Location = New System.Drawing.Point(587, 5)
        Me.RefreshBT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RefreshBT.Name = "RefreshBT"
        Me.RefreshBT.Size = New System.Drawing.Size(74, 30)
        Me.RefreshBT.TabIndex = 3
        Me.RefreshBT.Text = "새로고침"
        Me.RefreshBT.UseVisualStyleBackColor = False
        '
        'AddCourseBT
        '
        Me.AddCourseBT.BackColor = System.Drawing.Color.Transparent
        Me.AddCourseBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.AddCourseBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.AddCourseBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddCourseBT.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.AddCourseBT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AddCourseBT.Location = New System.Drawing.Point(661, 5)
        Me.AddCourseBT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AddCourseBT.Name = "AddCourseBT"
        Me.AddCourseBT.Size = New System.Drawing.Size(86, 30)
        Me.AddCourseBT.TabIndex = 2
        Me.AddCourseBT.Text = "수업 추가"
        Me.AddCourseBT.UseVisualStyleBackColor = False
        '
        'MenuBT
        '
        Me.MenuBT.BackColor = System.Drawing.Color.Transparent
        Me.MenuBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.MenuBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.MenuBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MenuBT.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MenuBT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MenuBT.Location = New System.Drawing.Point(747, 5)
        Me.MenuBT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MenuBT.Name = "MenuBT"
        Me.MenuBT.Size = New System.Drawing.Size(32, 30)
        Me.MenuBT.TabIndex = 32
        Me.MenuBT.Text = "..."
        Me.MenuBT.UseVisualStyleBackColor = False
        '
        'MinBT
        '
        Me.MinBT.BackColor = System.Drawing.Color.Transparent
        Me.MinBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.MinBT.Image = Global.uTable.My.Resources.Resources.minicon_b
        Me.MinBT.Location = New System.Drawing.Point(779, 5)
        Me.MinBT.Name = "MinBT"
        Me.MinBT.Size = New System.Drawing.Size(30, 30)
        Me.MinBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.MinBT.TabIndex = 28
        Me.MinBT.TabStop = False
        '
        'DayTable
        '
        Me.DayTable.ColumnCount = 7
        Me.DayTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.DayTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.DayTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.DayTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.DayTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.DayTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.DayTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.DayTable.Controls.Add(Me.SunLabel, 6, 0)
        Me.DayTable.Controls.Add(Me.SatLabel, 5, 0)
        Me.DayTable.Controls.Add(Me.FriLabel, 4, 0)
        Me.DayTable.Controls.Add(Me.ThuLabel, 3, 0)
        Me.DayTable.Controls.Add(Me.WedLabel, 2, 0)
        Me.DayTable.Controls.Add(Me.TueLabel, 1, 0)
        Me.DayTable.Controls.Add(Me.MonLabel, 0, 0)
        Me.DayTable.Dock = System.Windows.Forms.DockStyle.Top
        Me.DayTable.Location = New System.Drawing.Point(0, 40)
        Me.DayTable.Margin = New System.Windows.Forms.Padding(0)
        Me.DayTable.Name = "DayTable"
        Me.DayTable.RowCount = 1
        Me.DayTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.DayTable.Size = New System.Drawing.Size(814, 30)
        Me.DayTable.TabIndex = 3
        '
        'SunLabel
        '
        Me.SunLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SunLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SunLabel.ForeColor = System.Drawing.Color.Gray
        Me.SunLabel.Location = New System.Drawing.Point(696, 0)
        Me.SunLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.SunLabel.Name = "SunLabel"
        Me.SunLabel.Size = New System.Drawing.Size(118, 30)
        Me.SunLabel.TabIndex = 6
        Me.SunLabel.Text = "일요일"
        Me.SunLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SatLabel
        '
        Me.SatLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SatLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SatLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SatLabel.ForeColor = System.Drawing.Color.Gray
        Me.SatLabel.Location = New System.Drawing.Point(580, 0)
        Me.SatLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.SatLabel.Name = "SatLabel"
        Me.SatLabel.Size = New System.Drawing.Size(116, 30)
        Me.SatLabel.TabIndex = 5
        Me.SatLabel.Text = "토요일"
        Me.SatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FriLabel
        '
        Me.FriLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FriLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FriLabel.ForeColor = System.Drawing.Color.Gray
        Me.FriLabel.Location = New System.Drawing.Point(464, 0)
        Me.FriLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.FriLabel.Name = "FriLabel"
        Me.FriLabel.Size = New System.Drawing.Size(116, 30)
        Me.FriLabel.TabIndex = 4
        Me.FriLabel.Text = "금요일"
        Me.FriLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ThuLabel
        '
        Me.ThuLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ThuLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ThuLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ThuLabel.ForeColor = System.Drawing.Color.Gray
        Me.ThuLabel.Location = New System.Drawing.Point(348, 0)
        Me.ThuLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.ThuLabel.Name = "ThuLabel"
        Me.ThuLabel.Size = New System.Drawing.Size(116, 30)
        Me.ThuLabel.TabIndex = 3
        Me.ThuLabel.Text = "목요일"
        Me.ThuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WedLabel
        '
        Me.WedLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WedLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.WedLabel.ForeColor = System.Drawing.Color.Gray
        Me.WedLabel.Location = New System.Drawing.Point(232, 0)
        Me.WedLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.WedLabel.Name = "WedLabel"
        Me.WedLabel.Size = New System.Drawing.Size(116, 30)
        Me.WedLabel.TabIndex = 2
        Me.WedLabel.Text = "수요일"
        Me.WedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TueLabel
        '
        Me.TueLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TueLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TueLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TueLabel.ForeColor = System.Drawing.Color.Gray
        Me.TueLabel.Location = New System.Drawing.Point(116, 0)
        Me.TueLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.TueLabel.Name = "TueLabel"
        Me.TueLabel.Size = New System.Drawing.Size(116, 30)
        Me.TueLabel.TabIndex = 1
        Me.TueLabel.Text = "화요일"
        Me.TueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MonLabel
        '
        Me.MonLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MonLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MonLabel.ForeColor = System.Drawing.Color.Gray
        Me.MonLabel.Image = Global.uTable.My.Resources.Resources.shadow1
        Me.MonLabel.Location = New System.Drawing.Point(0, 0)
        Me.MonLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.MonLabel.Name = "MonLabel"
        Me.MonLabel.Size = New System.Drawing.Size(116, 30)
        Me.MonLabel.TabIndex = 0
        Me.MonLabel.Text = "월요일"
        Me.MonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel7.Controls.Add(Me.TimeTable)
        Me.Panel7.Controls.Add(Me.SizeLabel)
        Me.Panel7.Controls.Add(Me.DayTable)
        Me.Panel7.Controls.Add(Me.TopPanel)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(4, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(814, 640)
        Me.Panel7.TabIndex = 4
        '
        'SizeLabel
        '
        Me.SizeLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SizeLabel.Font = New System.Drawing.Font("맑은 고딕", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SizeLabel.ForeColor = System.Drawing.Color.Gray
        Me.SizeLabel.Location = New System.Drawing.Point(0, 70)
        Me.SizeLabel.Name = "SizeLabel"
        Me.SizeLabel.Size = New System.Drawing.Size(814, 570)
        Me.SizeLabel.TabIndex = 4
        Me.SizeLabel.Text = "드래그하여 크기를 조절하세요."
        Me.SizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.SizeLabel.Visible = False
        '
        'BT1_menu
        '
        Me.BT1_menu.BackColor = System.Drawing.Color.White
        Me.BT1_menu.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BT1_menu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BT1_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BT1MenuTitle, Me.ToolStripSeparator4, Me.ChangeThemeItem, Me.SnapToEdgeItem, Me.ColorSettingItem, Me.OpacitySelectItem, Me.GetFromETItem, Me.ToolStripSeparator1, Me.OptionItem, Me.ExitItem})
        Me.BT1_menu.Name = "BT1_menu"
        Me.BT1_menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.BT1_menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BT1_menu.ShowImageMargin = False
        Me.BT1_menu.Size = New System.Drawing.Size(180, 208)
        '
        'BT1MenuTitle
        '
        Me.BT1MenuTitle.Enabled = False
        Me.BT1MenuTitle.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BT1MenuTitle.Name = "BT1MenuTitle"
        Me.BT1MenuTitle.Size = New System.Drawing.Size(179, 24)
        Me.BT1MenuTitle.Text = "uTable 0.1v"
        Me.BT1MenuTitle.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(176, 6)
        '
        'ChangeThemeItem
        '
        Me.ChangeThemeItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_1_1, Me.Menu_1_2})
        Me.ChangeThemeItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ChangeThemeItem.Name = "ChangeThemeItem"
        Me.ChangeThemeItem.Size = New System.Drawing.Size(179, 24)
        Me.ChangeThemeItem.Text = "테마 바꾸기"
        '
        'Menu_1_1
        '
        Me.Menu_1_1.Name = "Menu_1_1"
        Me.Menu_1_1.Size = New System.Drawing.Size(168, 24)
        Me.Menu_1_1.Text = "화이트 (기본)"
        '
        'Menu_1_2
        '
        Me.Menu_1_2.Name = "Menu_1_2"
        Me.Menu_1_2.Size = New System.Drawing.Size(168, 24)
        Me.Menu_1_2.Text = "다크"
        '
        'SnapToEdgeItem
        '
        Me.SnapToEdgeItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SnapToEdgeItem.Name = "SnapToEdgeItem"
        Me.SnapToEdgeItem.Size = New System.Drawing.Size(179, 24)
        Me.SnapToEdgeItem.Text = "창에 붙기"
        '
        'ColorSettingItem
        '
        Me.ColorSettingItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllColorSetItem, Me.AllDarkerItem, Me.AllBrighterItem, Me.MessageItem})
        Me.ColorSettingItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ColorSettingItem.Name = "ColorSettingItem"
        Me.ColorSettingItem.Size = New System.Drawing.Size(179, 24)
        Me.ColorSettingItem.Text = "색상 설정"
        '
        'AllColorSetItem
        '
        Me.AllColorSetItem.Name = "AllColorSetItem"
        Me.AllColorSetItem.Size = New System.Drawing.Size(198, 24)
        Me.AllColorSetItem.Text = "전체 색상 설정"
        '
        'AllDarkerItem
        '
        Me.AllDarkerItem.Name = "AllDarkerItem"
        Me.AllDarkerItem.Size = New System.Drawing.Size(198, 24)
        Me.AllDarkerItem.Text = "모두 어둡게"
        '
        'AllBrighterItem
        '
        Me.AllBrighterItem.Name = "AllBrighterItem"
        Me.AllBrighterItem.Size = New System.Drawing.Size(198, 24)
        Me.AllBrighterItem.Text = "모두 밝게"
        '
        'MessageItem
        '
        Me.MessageItem.Enabled = False
        Me.MessageItem.Font = New System.Drawing.Font("맑은 고딕 Semilight", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MessageItem.Name = "MessageItem"
        Me.MessageItem.Size = New System.Drawing.Size(198, 24)
        Me.MessageItem.Text = "주의: 본 설정은 되돌릴 수 없습니다"
        '
        'OpacitySelectItem
        '
        Me.OpacitySelectItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1})
        Me.OpacitySelectItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.OpacitySelectItem.Name = "OpacitySelectItem"
        Me.OpacitySelectItem.Size = New System.Drawing.Size(179, 24)
        Me.OpacitySelectItem.Text = "투명도"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.BackColor = System.Drawing.Color.White
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.ToolStripComboBox1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"100% (불투명)", "90%", "80%", "70%", "60%", "50%", "40%", "30%", "20%"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 25)
        '
        'GetFromETItem
        '
        Me.GetFromETItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GetFromETItem.Name = "GetFromETItem"
        Me.GetFromETItem.Size = New System.Drawing.Size(179, 24)
        Me.GetFromETItem.Text = "에타에서 불러오기"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(176, 6)
        '
        'OptionItem
        '
        Me.OptionItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.OptionItem.Name = "OptionItem"
        Me.OptionItem.Size = New System.Drawing.Size(179, 24)
        Me.OptionItem.Text = "uTable 설정/정보"
        '
        'ExitItem
        '
        Me.ExitItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ExitItem.Name = "ExitItem"
        Me.ExitItem.Size = New System.Drawing.Size(179, 24)
        Me.ExitItem.Text = "uTable 종료"
        '
        'TimeCheck
        '
        Me.TimeCheck.Enabled = True
        Me.TimeCheck.Interval = 5000
        '
        'hideani
        '
        Me.hideani.Interval = 10
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.FullOpen = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(822, 648)
        Me.Controls.Add(Me.Panel7)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.uTable.My.Resources.Resources.ptable_icon
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(500, 400)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(4)
        Me.Text = "uTable"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.TimeTable.ResumeLayout(False)
        Me.TopPanel.ResumeLayout(False)
        Me.TopPanel.PerformLayout()
        CType(Me.TitleEditBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DayTable.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.BT1_menu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TimeTable As TableLayoutPanel
    Friend WithEvents TopPanel As Panel
    Friend WithEvents AddCourseBT As Button
    Friend WithEvents DayTable As TableLayoutPanel
    Friend WithEvents FriLabel As Label
    Friend WithEvents ThuLabel As Label
    Friend WithEvents WedLabel As Label
    Friend WithEvents TueLabel As Label
    Friend WithEvents RefreshBT As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents FriPanel As Panel
    Friend WithEvents ThuPanel As Panel
    Friend WithEvents WedPanel As Panel
    Friend WithEvents TuePanel As Panel
    Friend WithEvents MonPanel As Panel
    Friend WithEvents MinBT As PictureBox
    Friend WithEvents TableTitleLabel As Label
    Friend WithEvents TitleEditBT As PictureBox
    Friend WithEvents RenameTitleTextBox As TextBox
    Friend WithEvents MenuBT As Button
    Friend WithEvents BT1_menu As ContextMenuStrip
    Friend WithEvents BT1MenuTitle As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ChangeThemeItem As ToolStripMenuItem
    Friend WithEvents SnapToEdgeItem As ToolStripMenuItem
    Friend WithEvents OpacitySelectItem As ToolStripMenuItem
    Friend WithEvents Menu_1_1 As ToolStripMenuItem
    Friend WithEvents Menu_1_2 As ToolStripMenuItem
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents TimeCheck As Timer
    Friend WithEvents GetFromETItem As ToolStripMenuItem
    Friend WithEvents OptionItem As ToolStripMenuItem
    Friend WithEvents MonLabel As Label
    Friend WithEvents SizeLabel As Label
    Friend WithEvents hideani As Timer
    Friend WithEvents ExitItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SunPanel As Panel
    Friend WithEvents SatPanel As Panel
    Friend WithEvents SunLabel As Label
    Friend WithEvents SatLabel As Label
    Friend WithEvents ColorSettingItem As ToolStripMenuItem
    Friend WithEvents AllColorSetItem As ToolStripMenuItem
    Friend WithEvents AllDarkerItem As ToolStripMenuItem
    Friend WithEvents AllBrighterItem As ToolStripMenuItem
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents MessageItem As ToolStripMenuItem
End Class
