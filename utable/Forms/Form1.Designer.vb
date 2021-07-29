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
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.SizeLabel = New System.Windows.Forms.Label()
        Me.BT1_menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BT1MenuTitle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClearCheckBoxItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeThemeItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_1_1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_1_2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorSettingItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllColorSetItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllDarkerItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllBrighterItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpacitySelectItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.GetFromETItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TopMostItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnapToEdgeItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowMemoItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OptionItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimeCheck = New System.Windows.Forms.Timer(Me.components)
        Me.hideani = New System.Windows.Forms.Timer(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Tray_menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenTableTrayItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitTrayItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoPanel = New System.Windows.Forms.Panel()
        Me.MemoRTB = New System.Windows.Forms.RichTextBox()
        Me.MemoRTBMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MemoFontSetItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MemoUndoItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoCopyItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoPasteItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoSelectAllItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoToolPanel = New System.Windows.Forms.Panel()
        Me.MemoTitleLabel = New System.Windows.Forms.Label()
        Me.MemoSavingLabel = New System.Windows.Forms.Label()
        Me.MemoCloseBT = New System.Windows.Forms.Button()
        Me.MemoZoomBT2 = New System.Windows.Forms.Button()
        Me.MemoZoomNumBT = New System.Windows.Forms.Button()
        Me.MemoZoomBT1 = New System.Windows.Forms.Button()
        Me.MemoMenuBT = New System.Windows.Forms.Button()
        Me.DragSizePanel = New System.Windows.Forms.Panel()
        Me.Memo_menu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MemoDockItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoDockTopItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoDockBottomItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoDockLeftItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoDockRightItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoClearItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseMemoItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoAutoSaveTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MemoAutoSaveAniTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.TimeTable.SuspendLayout()
        Me.TopPanel.SuspendLayout()
        CType(Me.TitleEditBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DayTable.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        Me.BT1_menu.SuspendLayout()
        Me.Tray_menu.SuspendLayout()
        Me.MemoPanel.SuspendLayout()
        Me.MemoRTBMenu.SuspendLayout()
        Me.MemoToolPanel.SuspendLayout()
        Me.Memo_menu.SuspendLayout()
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
        Me.TimeTable.Location = New System.Drawing.Point(0, 88)
        Me.TimeTable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TimeTable.Name = "TimeTable"
        Me.TimeTable.RowCount = 1
        Me.TimeTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TimeTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 550.0!))
        Me.TimeTable.Size = New System.Drawing.Size(1018, 550)
        Me.TimeTable.TabIndex = 0
        '
        'SunPanel
        '
        Me.SunPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SunPanel.Location = New System.Drawing.Point(870, 0)
        Me.SunPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.SunPanel.Name = "SunPanel"
        Me.SunPanel.Size = New System.Drawing.Size(148, 550)
        Me.SunPanel.TabIndex = 6
        '
        'SatPanel
        '
        Me.SatPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SatPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SatPanel.Location = New System.Drawing.Point(725, 0)
        Me.SatPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.SatPanel.Name = "SatPanel"
        Me.SatPanel.Size = New System.Drawing.Size(145, 550)
        Me.SatPanel.TabIndex = 5
        '
        'FriPanel
        '
        Me.FriPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FriPanel.Location = New System.Drawing.Point(580, 0)
        Me.FriPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.FriPanel.Name = "FriPanel"
        Me.FriPanel.Size = New System.Drawing.Size(145, 550)
        Me.FriPanel.TabIndex = 4
        '
        'ThuPanel
        '
        Me.ThuPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ThuPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ThuPanel.Location = New System.Drawing.Point(435, 0)
        Me.ThuPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ThuPanel.Name = "ThuPanel"
        Me.ThuPanel.Size = New System.Drawing.Size(145, 550)
        Me.ThuPanel.TabIndex = 3
        '
        'WedPanel
        '
        Me.WedPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WedPanel.Location = New System.Drawing.Point(290, 0)
        Me.WedPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.WedPanel.Name = "WedPanel"
        Me.WedPanel.Size = New System.Drawing.Size(145, 550)
        Me.WedPanel.TabIndex = 2
        '
        'TuePanel
        '
        Me.TuePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TuePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TuePanel.Location = New System.Drawing.Point(145, 0)
        Me.TuePanel.Margin = New System.Windows.Forms.Padding(0)
        Me.TuePanel.Name = "TuePanel"
        Me.TuePanel.Size = New System.Drawing.Size(145, 550)
        Me.TuePanel.TabIndex = 1
        '
        'MonPanel
        '
        Me.MonPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MonPanel.Location = New System.Drawing.Point(0, 0)
        Me.MonPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MonPanel.Name = "MonPanel"
        Me.MonPanel.Size = New System.Drawing.Size(145, 550)
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
        Me.TopPanel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Padding = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.TopPanel.Size = New System.Drawing.Size(1018, 50)
        Me.TopPanel.TabIndex = 1
        '
        'TitleEditBT
        '
        Me.TitleEditBT.BackColor = System.Drawing.Color.Transparent
        Me.TitleEditBT.Dock = System.Windows.Forms.DockStyle.Left
        Me.TitleEditBT.Image = Global.uTable.My.Resources.Resources.bt_titleedit
        Me.TitleEditBT.Location = New System.Drawing.Point(421, 6)
        Me.TitleEditBT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TitleEditBT.Name = "TitleEditBT"
        Me.TitleEditBT.Size = New System.Drawing.Size(25, 38)
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
        Me.TableTitleLabel.Location = New System.Drawing.Point(228, 6)
        Me.TableTitleLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TableTitleLabel.Name = "TableTitleLabel"
        Me.TableTitleLabel.Size = New System.Drawing.Size(193, 37)
        Me.TableTitleLabel.TabIndex = 29
        Me.TableTitleLabel.Text = "TableTitleLabel"
        '
        'RenameTitleTextBox
        '
        Me.RenameTitleTextBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.RenameTitleTextBox.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.RenameTitleTextBox.Location = New System.Drawing.Point(6, 6)
        Me.RenameTitleTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RenameTitleTextBox.Name = "RenameTitleTextBox"
        Me.RenameTitleTextBox.Size = New System.Drawing.Size(222, 39)
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
        Me.RefreshBT.Location = New System.Drawing.Point(734, 6)
        Me.RefreshBT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RefreshBT.Name = "RefreshBT"
        Me.RefreshBT.Size = New System.Drawing.Size(92, 38)
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
        Me.AddCourseBT.Location = New System.Drawing.Point(826, 6)
        Me.AddCourseBT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AddCourseBT.Name = "AddCourseBT"
        Me.AddCourseBT.Size = New System.Drawing.Size(108, 38)
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
        Me.MenuBT.Location = New System.Drawing.Point(934, 6)
        Me.MenuBT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MenuBT.Name = "MenuBT"
        Me.MenuBT.Size = New System.Drawing.Size(40, 38)
        Me.MenuBT.TabIndex = 32
        Me.MenuBT.Text = "..."
        Me.MenuBT.UseVisualStyleBackColor = False
        '
        'MinBT
        '
        Me.MinBT.BackColor = System.Drawing.Color.Transparent
        Me.MinBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.MinBT.Image = Global.uTable.My.Resources.Resources.minicon_b
        Me.MinBT.Location = New System.Drawing.Point(974, 6)
        Me.MinBT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MinBT.Name = "MinBT"
        Me.MinBT.Size = New System.Drawing.Size(38, 38)
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
        Me.DayTable.Location = New System.Drawing.Point(0, 50)
        Me.DayTable.Margin = New System.Windows.Forms.Padding(0)
        Me.DayTable.Name = "DayTable"
        Me.DayTable.RowCount = 1
        Me.DayTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.DayTable.Size = New System.Drawing.Size(1018, 38)
        Me.DayTable.TabIndex = 3
        '
        'SunLabel
        '
        Me.SunLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SunLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SunLabel.ForeColor = System.Drawing.Color.Gray
        Me.SunLabel.Location = New System.Drawing.Point(870, 0)
        Me.SunLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.SunLabel.Name = "SunLabel"
        Me.SunLabel.Size = New System.Drawing.Size(148, 38)
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
        Me.SatLabel.Location = New System.Drawing.Point(725, 0)
        Me.SatLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.SatLabel.Name = "SatLabel"
        Me.SatLabel.Size = New System.Drawing.Size(145, 38)
        Me.SatLabel.TabIndex = 5
        Me.SatLabel.Text = "토요일"
        Me.SatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FriLabel
        '
        Me.FriLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FriLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FriLabel.ForeColor = System.Drawing.Color.Gray
        Me.FriLabel.Location = New System.Drawing.Point(580, 0)
        Me.FriLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.FriLabel.Name = "FriLabel"
        Me.FriLabel.Size = New System.Drawing.Size(145, 38)
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
        Me.ThuLabel.Location = New System.Drawing.Point(435, 0)
        Me.ThuLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.ThuLabel.Name = "ThuLabel"
        Me.ThuLabel.Size = New System.Drawing.Size(145, 38)
        Me.ThuLabel.TabIndex = 3
        Me.ThuLabel.Text = "목요일"
        Me.ThuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WedLabel
        '
        Me.WedLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WedLabel.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.WedLabel.ForeColor = System.Drawing.Color.Gray
        Me.WedLabel.Location = New System.Drawing.Point(290, 0)
        Me.WedLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.WedLabel.Name = "WedLabel"
        Me.WedLabel.Size = New System.Drawing.Size(145, 38)
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
        Me.TueLabel.Location = New System.Drawing.Point(145, 0)
        Me.TueLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.TueLabel.Name = "TueLabel"
        Me.TueLabel.Size = New System.Drawing.Size(145, 38)
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
        Me.MonLabel.Size = New System.Drawing.Size(145, 38)
        Me.MonLabel.TabIndex = 0
        Me.MonLabel.Text = "월요일"
        Me.MonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MainPanel
        '
        Me.MainPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.MainPanel.Controls.Add(Me.TimeTable)
        Me.MainPanel.Controls.Add(Me.SizeLabel)
        Me.MainPanel.Controls.Add(Me.DayTable)
        Me.MainPanel.Controls.Add(Me.TopPanel)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(5, 5)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(1018, 638)
        Me.MainPanel.TabIndex = 4
        '
        'SizeLabel
        '
        Me.SizeLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SizeLabel.Font = New System.Drawing.Font("맑은 고딕", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SizeLabel.ForeColor = System.Drawing.Color.Gray
        Me.SizeLabel.Location = New System.Drawing.Point(0, 88)
        Me.SizeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SizeLabel.Name = "SizeLabel"
        Me.SizeLabel.Size = New System.Drawing.Size(1018, 550)
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
        Me.BT1_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BT1MenuTitle, Me.ToolStripSeparator4, Me.ClearCheckBoxItem, Me.ChangeThemeItem, Me.ColorSettingItem, Me.OpacitySelectItem, Me.GetFromETItem, Me.ToolStripSeparator2, Me.TopMostItem, Me.SnapToEdgeItem, Me.ShowMemoItem, Me.ToolStripSeparator1, Me.OptionItem, Me.ExitItem})
        Me.BT1_menu.Name = "BT1_menu"
        Me.BT1_menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.BT1_menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BT1_menu.ShowImageMargin = False
        Me.BT1_menu.Size = New System.Drawing.Size(219, 352)
        '
        'BT1MenuTitle
        '
        Me.BT1MenuTitle.Enabled = False
        Me.BT1MenuTitle.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BT1MenuTitle.Name = "BT1MenuTitle"
        Me.BT1MenuTitle.Size = New System.Drawing.Size(218, 30)
        Me.BT1MenuTitle.Text = "uTable 0.1v"
        Me.BT1MenuTitle.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(215, 6)
        '
        'ClearCheckBoxItem
        '
        Me.ClearCheckBoxItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ClearCheckBoxItem.Name = "ClearCheckBoxItem"
        Me.ClearCheckBoxItem.Size = New System.Drawing.Size(218, 30)
        Me.ClearCheckBoxItem.Text = "체크상자 비우기"
        Me.ClearCheckBoxItem.Visible = False
        '
        'ChangeThemeItem
        '
        Me.ChangeThemeItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_1_1, Me.Menu_1_2})
        Me.ChangeThemeItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ChangeThemeItem.Name = "ChangeThemeItem"
        Me.ChangeThemeItem.Size = New System.Drawing.Size(218, 30)
        Me.ChangeThemeItem.Text = "테마 바꾸기"
        '
        'Menu_1_1
        '
        Me.Menu_1_1.Name = "Menu_1_1"
        Me.Menu_1_1.Size = New System.Drawing.Size(212, 30)
        Me.Menu_1_1.Text = "화이트 (기본)"
        '
        'Menu_1_2
        '
        Me.Menu_1_2.Name = "Menu_1_2"
        Me.Menu_1_2.Size = New System.Drawing.Size(212, 30)
        Me.Menu_1_2.Text = "다크"
        '
        'ColorSettingItem
        '
        Me.ColorSettingItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllColorSetItem, Me.AllDarkerItem, Me.AllBrighterItem, Me.MessageItem})
        Me.ColorSettingItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ColorSettingItem.Name = "ColorSettingItem"
        Me.ColorSettingItem.Size = New System.Drawing.Size(218, 30)
        Me.ColorSettingItem.Text = "색상 설정"
        '
        'AllColorSetItem
        '
        Me.AllColorSetItem.Name = "AllColorSetItem"
        Me.AllColorSetItem.Size = New System.Drawing.Size(248, 30)
        Me.AllColorSetItem.Text = "전체 색상 설정"
        '
        'AllDarkerItem
        '
        Me.AllDarkerItem.Name = "AllDarkerItem"
        Me.AllDarkerItem.Size = New System.Drawing.Size(248, 30)
        Me.AllDarkerItem.Text = "모두 어둡게"
        '
        'AllBrighterItem
        '
        Me.AllBrighterItem.Name = "AllBrighterItem"
        Me.AllBrighterItem.Size = New System.Drawing.Size(248, 30)
        Me.AllBrighterItem.Text = "모두 밝게"
        '
        'MessageItem
        '
        Me.MessageItem.Enabled = False
        Me.MessageItem.Font = New System.Drawing.Font("맑은 고딕 Semilight", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MessageItem.Name = "MessageItem"
        Me.MessageItem.Size = New System.Drawing.Size(248, 30)
        Me.MessageItem.Text = "주의: 본 설정은 되돌릴 수 없습니다"
        '
        'OpacitySelectItem
        '
        Me.OpacitySelectItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1})
        Me.OpacitySelectItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.OpacitySelectItem.Name = "OpacitySelectItem"
        Me.OpacitySelectItem.Size = New System.Drawing.Size(218, 30)
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
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 31)
        '
        'GetFromETItem
        '
        Me.GetFromETItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GetFromETItem.Name = "GetFromETItem"
        Me.GetFromETItem.Size = New System.Drawing.Size(218, 30)
        Me.GetFromETItem.Text = "에타에서 불러오기"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(215, 6)
        '
        'TopMostItem
        '
        Me.TopMostItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TopMostItem.Name = "TopMostItem"
        Me.TopMostItem.Size = New System.Drawing.Size(218, 30)
        Me.TopMostItem.Text = "항상 위에 표시"
        '
        'SnapToEdgeItem
        '
        Me.SnapToEdgeItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.SnapToEdgeItem.Name = "SnapToEdgeItem"
        Me.SnapToEdgeItem.Size = New System.Drawing.Size(218, 30)
        Me.SnapToEdgeItem.Text = "창에 붙기"
        '
        'ShowMemoItem
        '
        Me.ShowMemoItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!)
        Me.ShowMemoItem.Name = "ShowMemoItem"
        Me.ShowMemoItem.Size = New System.Drawing.Size(218, 30)
        Me.ShowMemoItem.Text = "메모칸 표시"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(215, 6)
        '
        'OptionItem
        '
        Me.OptionItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.OptionItem.Name = "OptionItem"
        Me.OptionItem.Size = New System.Drawing.Size(218, 30)
        Me.OptionItem.Text = "uTable 설정/정보"
        '
        'ExitItem
        '
        Me.ExitItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ExitItem.Name = "ExitItem"
        Me.ExitItem.Size = New System.Drawing.Size(218, 30)
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
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.Tray_menu
        Me.NotifyIcon1.Icon = Global.uTable.My.Resources.Resources.ptable_icon
        Me.NotifyIcon1.Text = "uTable"
        Me.NotifyIcon1.Visible = True
        '
        'Tray_menu
        '
        Me.Tray_menu.BackColor = System.Drawing.Color.White
        Me.Tray_menu.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Tray_menu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Tray_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenTableTrayItem, Me.ExitTrayItem})
        Me.Tray_menu.Name = "ContextMenuStrip1"
        Me.Tray_menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Tray_menu.ShowImageMargin = False
        Me.Tray_menu.Size = New System.Drawing.Size(147, 60)
        '
        'OpenTableTrayItem
        '
        Me.OpenTableTrayItem.Name = "OpenTableTrayItem"
        Me.OpenTableTrayItem.Size = New System.Drawing.Size(146, 28)
        Me.OpenTableTrayItem.Text = "시간표 열기"
        '
        'ExitTrayItem
        '
        Me.ExitTrayItem.Name = "ExitTrayItem"
        Me.ExitTrayItem.Size = New System.Drawing.Size(146, 28)
        Me.ExitTrayItem.Text = "uTable 종료"
        '
        'MemoPanel
        '
        Me.MemoPanel.Controls.Add(Me.MemoRTB)
        Me.MemoPanel.Controls.Add(Me.MemoToolPanel)
        Me.MemoPanel.Controls.Add(Me.DragSizePanel)
        Me.MemoPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MemoPanel.Location = New System.Drawing.Point(5, 643)
        Me.MemoPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MemoPanel.MinimumSize = New System.Drawing.Size(38, 38)
        Me.MemoPanel.Name = "MemoPanel"
        Me.MemoPanel.Size = New System.Drawing.Size(1018, 162)
        Me.MemoPanel.TabIndex = 33
        '
        'MemoRTB
        '
        Me.MemoRTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MemoRTB.ContextMenuStrip = Me.MemoRTBMenu
        Me.MemoRTB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MemoRTB.Location = New System.Drawing.Point(0, 46)
        Me.MemoRTB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MemoRTB.Name = "MemoRTB"
        Me.MemoRTB.Size = New System.Drawing.Size(1018, 116)
        Me.MemoRTB.TabIndex = 1
        Me.MemoRTB.Text = ""
        '
        'MemoRTBMenu
        '
        Me.MemoRTBMenu.BackColor = System.Drawing.Color.White
        Me.MemoRTBMenu.Font = New System.Drawing.Font("맑은 고딕", 11.0!)
        Me.MemoRTBMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MemoRTBMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MemoFontSetItem, Me.ToolStripSeparator3, Me.MemoUndoItem, Me.MemoCopyItem, Me.MemoPasteItem, Me.MemoSelectAllItem})
        Me.MemoRTBMenu.Name = "MemoRTBMenu"
        Me.MemoRTBMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MemoRTBMenu.ShowImageMargin = False
        Me.MemoRTBMenu.Size = New System.Drawing.Size(143, 160)
        '
        'MemoFontSetItem
        '
        Me.MemoFontSetItem.Name = "MemoFontSetItem"
        Me.MemoFontSetItem.Size = New System.Drawing.Size(142, 30)
        Me.MemoFontSetItem.Text = "글꼴 설정"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(139, 6)
        '
        'MemoUndoItem
        '
        Me.MemoUndoItem.Name = "MemoUndoItem"
        Me.MemoUndoItem.Size = New System.Drawing.Size(142, 30)
        Me.MemoUndoItem.Text = "실행 취소"
        '
        'MemoCopyItem
        '
        Me.MemoCopyItem.Name = "MemoCopyItem"
        Me.MemoCopyItem.Size = New System.Drawing.Size(142, 30)
        Me.MemoCopyItem.Text = "복사"
        '
        'MemoPasteItem
        '
        Me.MemoPasteItem.Name = "MemoPasteItem"
        Me.MemoPasteItem.Size = New System.Drawing.Size(142, 30)
        Me.MemoPasteItem.Text = "붙여넣기"
        '
        'MemoSelectAllItem
        '
        Me.MemoSelectAllItem.Name = "MemoSelectAllItem"
        Me.MemoSelectAllItem.Size = New System.Drawing.Size(142, 30)
        Me.MemoSelectAllItem.Text = "모두 선택"
        '
        'MemoToolPanel
        '
        Me.MemoToolPanel.Controls.Add(Me.MemoTitleLabel)
        Me.MemoToolPanel.Controls.Add(Me.MemoSavingLabel)
        Me.MemoToolPanel.Controls.Add(Me.MemoCloseBT)
        Me.MemoToolPanel.Controls.Add(Me.MemoZoomBT2)
        Me.MemoToolPanel.Controls.Add(Me.MemoZoomNumBT)
        Me.MemoToolPanel.Controls.Add(Me.MemoZoomBT1)
        Me.MemoToolPanel.Controls.Add(Me.MemoMenuBT)
        Me.MemoToolPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MemoToolPanel.Location = New System.Drawing.Point(0, 15)
        Me.MemoToolPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MemoToolPanel.Name = "MemoToolPanel"
        Me.MemoToolPanel.Padding = New System.Windows.Forms.Padding(2)
        Me.MemoToolPanel.Size = New System.Drawing.Size(1018, 31)
        Me.MemoToolPanel.TabIndex = 2
        '
        'MemoTitleLabel
        '
        Me.MemoTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MemoTitleLabel.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MemoTitleLabel.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.MemoTitleLabel.Location = New System.Drawing.Point(149, 2)
        Me.MemoTitleLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MemoTitleLabel.Name = "MemoTitleLabel"
        Me.MemoTitleLabel.Size = New System.Drawing.Size(726, 27)
        Me.MemoTitleLabel.TabIndex = 35
        Me.MemoTitleLabel.Text = "MemoTitle"
        Me.MemoTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MemoSavingLabel
        '
        Me.MemoSavingLabel.Dock = System.Windows.Forms.DockStyle.Right
        Me.MemoSavingLabel.Font = New System.Drawing.Font("맑은 고딕", 7.0!)
        Me.MemoSavingLabel.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.MemoSavingLabel.Location = New System.Drawing.Point(875, 2)
        Me.MemoSavingLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MemoSavingLabel.Name = "MemoSavingLabel"
        Me.MemoSavingLabel.Size = New System.Drawing.Size(115, 27)
        Me.MemoSavingLabel.TabIndex = 8
        Me.MemoSavingLabel.Text = "변경사항 저장중..."
        Me.MemoSavingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MemoCloseBT
        '
        Me.MemoCloseBT.BackColor = System.Drawing.Color.Transparent
        Me.MemoCloseBT.BackgroundImage = Global.uTable.My.Resources.Resources.closeicon_b
        Me.MemoCloseBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MemoCloseBT.Dock = System.Windows.Forms.DockStyle.Right
        Me.MemoCloseBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.MemoCloseBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MemoCloseBT.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MemoCloseBT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MemoCloseBT.Location = New System.Drawing.Point(990, 2)
        Me.MemoCloseBT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MemoCloseBT.Name = "MemoCloseBT"
        Me.MemoCloseBT.Size = New System.Drawing.Size(26, 27)
        Me.MemoCloseBT.TabIndex = 34
        Me.MemoCloseBT.UseVisualStyleBackColor = False
        '
        'MemoZoomBT2
        '
        Me.MemoZoomBT2.BackColor = System.Drawing.Color.Transparent
        Me.MemoZoomBT2.Dock = System.Windows.Forms.DockStyle.Left
        Me.MemoZoomBT2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.MemoZoomBT2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MemoZoomBT2.Font = New System.Drawing.Font("맑은 고딕", 8.0!)
        Me.MemoZoomBT2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MemoZoomBT2.Location = New System.Drawing.Point(123, 2)
        Me.MemoZoomBT2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MemoZoomBT2.Name = "MemoZoomBT2"
        Me.MemoZoomBT2.Size = New System.Drawing.Size(26, 27)
        Me.MemoZoomBT2.TabIndex = 7
        Me.MemoZoomBT2.Text = "+"
        Me.MemoZoomBT2.UseVisualStyleBackColor = False
        '
        'MemoZoomNumBT
        '
        Me.MemoZoomNumBT.BackColor = System.Drawing.Color.Transparent
        Me.MemoZoomNumBT.Dock = System.Windows.Forms.DockStyle.Left
        Me.MemoZoomNumBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.MemoZoomNumBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MemoZoomNumBT.Font = New System.Drawing.Font("맑은 고딕", 8.0!)
        Me.MemoZoomNumBT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MemoZoomNumBT.Location = New System.Drawing.Point(54, 2)
        Me.MemoZoomNumBT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MemoZoomNumBT.Name = "MemoZoomNumBT"
        Me.MemoZoomNumBT.Size = New System.Drawing.Size(69, 27)
        Me.MemoZoomNumBT.TabIndex = 6
        Me.MemoZoomNumBT.Text = "100%"
        Me.MemoZoomNumBT.UseVisualStyleBackColor = False
        '
        'MemoZoomBT1
        '
        Me.MemoZoomBT1.BackColor = System.Drawing.Color.Transparent
        Me.MemoZoomBT1.Dock = System.Windows.Forms.DockStyle.Left
        Me.MemoZoomBT1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.MemoZoomBT1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MemoZoomBT1.Font = New System.Drawing.Font("맑은 고딕", 8.0!)
        Me.MemoZoomBT1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MemoZoomBT1.Location = New System.Drawing.Point(28, 2)
        Me.MemoZoomBT1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MemoZoomBT1.Name = "MemoZoomBT1"
        Me.MemoZoomBT1.Size = New System.Drawing.Size(26, 27)
        Me.MemoZoomBT1.TabIndex = 5
        Me.MemoZoomBT1.Text = "-"
        Me.MemoZoomBT1.UseVisualStyleBackColor = False
        '
        'MemoMenuBT
        '
        Me.MemoMenuBT.BackColor = System.Drawing.Color.Transparent
        Me.MemoMenuBT.BackgroundImage = Global.uTable.My.Resources.Resources.menuicon_b
        Me.MemoMenuBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MemoMenuBT.Dock = System.Windows.Forms.DockStyle.Left
        Me.MemoMenuBT.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.MemoMenuBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MemoMenuBT.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MemoMenuBT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MemoMenuBT.Location = New System.Drawing.Point(2, 2)
        Me.MemoMenuBT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MemoMenuBT.Name = "MemoMenuBT"
        Me.MemoMenuBT.Size = New System.Drawing.Size(26, 27)
        Me.MemoMenuBT.TabIndex = 33
        Me.MemoMenuBT.UseVisualStyleBackColor = False
        '
        'DragSizePanel
        '
        Me.DragSizePanel.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.DragSizePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.DragSizePanel.Location = New System.Drawing.Point(0, 0)
        Me.DragSizePanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DragSizePanel.Name = "DragSizePanel"
        Me.DragSizePanel.Size = New System.Drawing.Size(1018, 15)
        Me.DragSizePanel.TabIndex = 0
        '
        'Memo_menu
        '
        Me.Memo_menu.BackColor = System.Drawing.Color.White
        Me.Memo_menu.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Memo_menu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.Memo_menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MemoDockItem, Me.MemoClearItem, Me.ToolStripSeparator5, Me.CloseMemoItem})
        Me.Memo_menu.Name = "BT1_menu"
        Me.Memo_menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Memo_menu.ShowImageMargin = False
        Me.Memo_menu.Size = New System.Drawing.Size(162, 100)
        '
        'MemoDockItem
        '
        Me.MemoDockItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MemoDockTopItem, Me.MemoDockBottomItem, Me.MemoDockLeftItem, Me.MemoDockRightItem})
        Me.MemoDockItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MemoDockItem.Name = "MemoDockItem"
        Me.MemoDockItem.Size = New System.Drawing.Size(161, 30)
        Me.MemoDockItem.Text = "표시 방향"
        '
        'MemoDockTopItem
        '
        Me.MemoDockTopItem.Name = "MemoDockTopItem"
        Me.MemoDockTopItem.Size = New System.Drawing.Size(155, 30)
        Me.MemoDockTopItem.Text = "위쪽"
        '
        'MemoDockBottomItem
        '
        Me.MemoDockBottomItem.Name = "MemoDockBottomItem"
        Me.MemoDockBottomItem.Size = New System.Drawing.Size(155, 30)
        Me.MemoDockBottomItem.Text = "아래쪽"
        '
        'MemoDockLeftItem
        '
        Me.MemoDockLeftItem.Name = "MemoDockLeftItem"
        Me.MemoDockLeftItem.Size = New System.Drawing.Size(155, 30)
        Me.MemoDockLeftItem.Text = "왼쪽"
        '
        'MemoDockRightItem
        '
        Me.MemoDockRightItem.Name = "MemoDockRightItem"
        Me.MemoDockRightItem.Size = New System.Drawing.Size(155, 30)
        Me.MemoDockRightItem.Text = "오른쪽"
        '
        'MemoClearItem
        '
        Me.MemoClearItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MemoClearItem.Name = "MemoClearItem"
        Me.MemoClearItem.Size = New System.Drawing.Size(161, 30)
        Me.MemoClearItem.Text = "내용 비우기"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(158, 6)
        '
        'CloseMemoItem
        '
        Me.CloseMemoItem.Font = New System.Drawing.Font("맑은 고딕", 11.25!)
        Me.CloseMemoItem.Name = "CloseMemoItem"
        Me.CloseMemoItem.Size = New System.Drawing.Size(161, 30)
        Me.CloseMemoItem.Text = "메모칸 닫기"
        '
        'MemoAutoSaveTimer
        '
        Me.MemoAutoSaveTimer.Interval = 1000
        '
        'MemoAutoSaveAniTimer
        '
        Me.MemoAutoSaveAniTimer.Interval = 30
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(1028, 810)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.MemoPanel)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.uTable.My.Resources.Resources.ptable_icon
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(625, 500)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Text = "uTable"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.TimeTable.ResumeLayout(False)
        Me.TopPanel.ResumeLayout(False)
        Me.TopPanel.PerformLayout()
        CType(Me.TitleEditBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DayTable.ResumeLayout(False)
        Me.MainPanel.ResumeLayout(False)
        Me.BT1_menu.ResumeLayout(False)
        Me.Tray_menu.ResumeLayout(False)
        Me.MemoPanel.ResumeLayout(False)
        Me.MemoRTBMenu.ResumeLayout(False)
        Me.MemoToolPanel.ResumeLayout(False)
        Me.Memo_menu.ResumeLayout(False)
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
    Friend WithEvents MainPanel As Panel
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
    Friend WithEvents ClearCheckBoxItem As ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents Tray_menu As ContextMenuStrip
    Friend WithEvents OpenTableTrayItem As ToolStripMenuItem
    Friend WithEvents ExitTrayItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TopMostItem As ToolStripMenuItem
    Friend WithEvents MemoPanel As Panel
    Friend WithEvents DragSizePanel As Panel
    Friend WithEvents ShowMemoItem As ToolStripMenuItem
    Friend WithEvents MemoToolPanel As Panel
    Friend WithEvents MemoSavingLabel As Label
    Friend WithEvents MemoZoomBT2 As Button
    Friend WithEvents MemoZoomNumBT As Button
    Friend WithEvents MemoZoomBT1 As Button
    Friend WithEvents Memo_menu As ContextMenuStrip
    Friend WithEvents MemoDockItem As ToolStripMenuItem
    Friend WithEvents MemoDockTopItem As ToolStripMenuItem
    Friend WithEvents MemoDockBottomItem As ToolStripMenuItem
    Friend WithEvents MemoClearItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents CloseMemoItem As ToolStripMenuItem
    Friend WithEvents MemoDockLeftItem As ToolStripMenuItem
    Friend WithEvents MemoDockRightItem As ToolStripMenuItem
    Friend WithEvents MemoMenuBT As Button
    Friend WithEvents MemoAutoSaveTimer As Timer
    Friend WithEvents MemoAutoSaveAniTimer As Timer
    Friend WithEvents MemoRTB As RichTextBox
    Friend WithEvents MemoCloseBT As Button
    Friend WithEvents MemoTitleLabel As Label
    Friend WithEvents MemoRTBMenu As ContextMenuStrip
    Friend WithEvents MemoFontSetItem As ToolStripMenuItem
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents MemoCopyItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents MemoUndoItem As ToolStripMenuItem
    Friend WithEvents MemoPasteItem As ToolStripMenuItem
    Friend WithEvents MemoSelectAllItem As ToolStripMenuItem
End Class
