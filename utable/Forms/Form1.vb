Imports System.ComponentModel
Imports System.Runtime.InteropServices

' TODO
' 메모기능 손보기
' - memo.rtf로 저장하기
' - 자동저장기능 구현 (5초간 타이핑 대기 후 동기저장)
' - rtf가 이상하게 굴면 그냥 rtb대신 tb 넣고 txt파일로 저장

Public Class Form1

#Region "변수"

    ' ================== 스토어 에디션 여부!!! ==================
    Public Const isStore = False
    ' ===========================================================

    Dim starttime As Integer = 0
    Dim endtime As Integer = 0
    Dim updated As Boolean = False
    Dim courseData As New List(Of String)

    '슬라이딩 애니메이션용 변수
    Dim poscount As Integer = 0
    Dim prevloc As Point
    Dim tmp_opa As Double
    Dim hiding As Boolean = False

    Dim PrevDisp As String = Nothing
    Dim PrevDay As Date = Nothing
    Dim formshown As Boolean = False
    Dim snaptoedge As Boolean = False
    Dim titleEditMode As Boolean = False
    Dim colorMode As String = Nothing
    Public BorderWidth As Integer = dpicalc(Me, 6)
    Private _resizeDir As ResizeDirection = ResizeDirection.None

    '알림용
    'Dim tableData As String = Nothing '이거는 updateCell에서도 씀!!!
    Dim prevNotificationName As String = Nothing
    Dim prevTime As Date = Nothing

    'CellControl용 설정 변수
    Public FadeEffect As String = ""
    Public CustomFont As String = ""
    Public CustomFontName As String = ""
    Public AutoTextColor As String = ""
    Public _BlackText As String = ""
    Public _AlwaysExpand As String = ""
    Public ExpandCell As String = ""
    Public ShowMemo As String = ""
    Public ShowProf As String = ""
    Public _ShowChkBox As String = ""

    'Dim disablePatternDrawOnce As Boolean = False
    Public tablePatternSetting As String = Nothing

    Dim showSaturday As Boolean = False
    Dim showSunday As Boolean = False

    Public currentDPI As Integer = 96

    Dim isSizeDragging As Boolean = False
    Dim DragPosition As New Point

    '메모 자동저장 라벨용
    Dim o_color As Color = Color.DeepSkyBlue
    Dim Perc As Double = 1

    '코너 라운딩 사이즈
    Dim RndCorner As Boolean = True
    Dim RndSize As Integer = 6

#End Region

#Region "Aero 그림자 효과 (Vista이상)"

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        CreateDropShadow(Me)
        MyBase.OnHandleCreated(e)
    End Sub

#End Region

#Region "창 이동, 크기 조절, 붙기 관련"

    Private Function DoSnap(ByVal pos As Integer, ByVal edge As Integer) As Boolean
        Dim delta As Integer = pos - edge
        Return delta > 0 AndAlso delta <= dpicalc(Me, 20)
    End Function

    Protected Overrides Sub OnResizeEnd(ByVal e As EventArgs)
        If snaptoedge Then
            MyBase.OnResizeEnd(e)
            Dim scn As Screen = Screen.FromPoint(Me.Location)
            If DoSnap(Me.Left, scn.WorkingArea.Left) Then Me.Left = scn.WorkingArea.Left
            If DoSnap(Me.Top, scn.WorkingArea.Top) Then Me.Top = scn.WorkingArea.Top
            If DoSnap(scn.WorkingArea.Right, Me.Right) Then Me.Left = scn.WorkingArea.Right - Me.Width
            If DoSnap(scn.WorkingArea.Bottom, Me.Bottom) Then Me.Top = scn.WorkingArea.Bottom - Me.Height
        End If
    End Sub

    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTBORDER As Integer = 18
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14

    Public Enum ResizeDirection
        None = 0
        Left = 1
        TopLeft = 2
        Top = 3
        TopRight = 4
        Right = 5
        BottomRight = 6
        Bottom = 7
        BottomLeft = 8
    End Enum

    Public Property resizeDir() As ResizeDirection
        Get
            Return _resizeDir
        End Get
        Set(ByVal value As ResizeDirection)
            _resizeDir = value

            'Change cursor
            Select Case value
                Case ResizeDirection.Left
                    Me.Cursor = Cursors.SizeWE

                Case ResizeDirection.Right
                    Me.Cursor = Cursors.SizeWE

                Case ResizeDirection.Top
                    Me.Cursor = Cursors.SizeNS

                Case ResizeDirection.Bottom
                    Me.Cursor = Cursors.SizeNS

                Case ResizeDirection.BottomLeft
                    Me.Cursor = Cursors.SizeNESW

                Case ResizeDirection.TopRight
                    Me.Cursor = Cursors.SizeNESW

                Case ResizeDirection.BottomRight
                    Me.Cursor = Cursors.SizeNWSE

                Case ResizeDirection.TopLeft
                    Me.Cursor = Cursors.SizeNWSE

                Case Else
                    Me.Cursor = Cursors.Default
            End Select
        End Set
    End Property

    Private Sub MoveForm()
        ReleaseCapture()
        SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
    End Sub

    Private Sub ResizeForm(ByVal direction As ResizeDirection)
        Dim dir As Integer = -1

        Select Case direction
            Case ResizeDirection.Left
                dir = HTLEFT
            Case ResizeDirection.TopLeft
                dir = HTTOPLEFT
            Case ResizeDirection.Top
                dir = HTTOP
            Case ResizeDirection.TopRight
                dir = HTTOPRIGHT
            Case ResizeDirection.Right
                dir = HTRIGHT
            Case ResizeDirection.BottomRight
                dir = HTBOTTOMRIGHT
            Case ResizeDirection.Bottom
                dir = HTBOTTOM
            Case ResizeDirection.BottomLeft
                dir = HTBOTTOMLEFT
        End Select

        '마우스 릴리즈시
        If dir <> -1 Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, dir, 0)
            SuspendTable(False)
        End If
    End Sub

    Private Sub MoveArea_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TopPanel.MouseDown,
        MonPanel.MouseDown, TuePanel.MouseDown, WedPanel.MouseDown, ThuPanel.MouseDown, FriPanel.MouseDown,
        MonLabel.MouseDown, TueLabel.MouseDown, WedLabel.MouseDown, ThuLabel.MouseDown, FriLabel.MouseDown, TableTitleLabel.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And Me.WindowState <> FormWindowState.Maximized Then
            If Not GetINI("SETTING", "WindowLocked", "", ININamePath) = "1" Then MoveForm()
        End If

        '창붙기 설정 업데이트
        snaptoedge = (GetINI("SETTING", "SnapToEdge", "", ININamePath) = "1")
    End Sub

    Private Sub Form1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And Me.WindowState <> FormWindowState.Maximized Then
            If Not GetINI("SETTING", "WindowLocked", "", ININamePath) = "1" Then
                'TimeTable.SuspendLayout()
                SuspendTable(True)
                ResizeForm(resizeDir)
            End If
        End If
    End Sub

    Private Sub MainForm_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        'Calculate which direction to resize based on mouse position

        If e.Location.X < BorderWidth And e.Location.Y < BorderWidth Then
            resizeDir = ResizeDirection.TopLeft

        ElseIf e.Location.X < BorderWidth And e.Location.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.BottomLeft

        ElseIf e.Location.X > Me.Width - BorderWidth And e.Location.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.BottomRight

        ElseIf e.Location.X > Me.Width - BorderWidth And e.Location.Y < BorderWidth Then
            resizeDir = ResizeDirection.TopRight

        ElseIf e.Location.X < BorderWidth Then
            resizeDir = ResizeDirection.Left

        ElseIf e.Location.X > Me.Width - BorderWidth Then
            resizeDir = ResizeDirection.Right

        ElseIf e.Location.Y < BorderWidth Then
            resizeDir = ResizeDirection.Top

        ElseIf e.Location.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.Bottom

        Else
            resizeDir = ResizeDirection.None
        End If

    End Sub

    Private Sub MainForm_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged, MyBase.SizeChanged

        If formshown And Not hiding Then
            SetINI("SETTING", "WindowPosition", Location.X.ToString + "," + Location.Y.ToString, ININamePath)
            SetINI("SETTING", "WindowSize", Width.ToString + "," + Height.ToString, ININamePath)

            If Not PrevDisp = Screen.FromControl(Me).DeviceName.ToString Then
                SetINI("SETTING", "WindowScreen", Screen.FromControl(Me).DeviceName.ToString, ININamePath)
                PrevDisp = Screen.FromControl(Me).DeviceName.ToString
            End If

            'If Application.OpenForms().OfType(Of SetCourse).Any Then _
            ' If Not SetCourse.modifyMode Then SetCourse.SetDesktopLocation(Location.X + Button1.Location.X, Location.Y + DayTable.Location.Y)

        End If
    End Sub

    Private Sub Form1_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Sub SuspendTable(bool As Boolean)
        If bool Then
            TimeTable.Visible = False
            SizeLabel.Show()
            SizeLabel.Text = "드래그하여 크기를 조절하세요"
        Else
            TimeTable.Visible = True
            SizeLabel.Hide()
        End If
    End Sub

#End Region

#Region "GUI 색 업데이트/설정"

    Public Sub UpdateColor()

        colorMode = GetINI("SETTING", "ColorMode", "", ININamePath)

        BackColor = edgeColor(colorMode)

        TopPanel.BackColor = mainColor(colorMode)
        MainPanel.BackColor = mainColor(colorMode)

        ' ====== 시간표 색상 적용 =====

        MonLabel.BackColor = tableColor_1(colorMode)
        TueLabel.BackColor = tableColor_2(colorMode)
        WedLabel.BackColor = tableColor_1(colorMode)
        ThuLabel.BackColor = tableColor_2(colorMode)
        FriLabel.BackColor = tableColor_1(colorMode)
        SatLabel.BackColor = tableColor_2(colorMode)
        SunLabel.BackColor = tableColor_1(colorMode)

        MonLabel.ForeColor = lightTextColor(colorMode)
        TueLabel.ForeColor = lightTextColor(colorMode)
        WedLabel.ForeColor = lightTextColor(colorMode)
        ThuLabel.ForeColor = lightTextColor(colorMode)
        FriLabel.ForeColor = lightTextColor(colorMode)
        SatLabel.ForeColor = lightTextColor(colorMode)
        SunLabel.ForeColor = lightTextColor(colorMode)

        MonPanel.BackColor = tableColor_1(colorMode)
        TuePanel.BackColor = tableColor_2(colorMode)
        WedPanel.BackColor = tableColor_1(colorMode)
        ThuPanel.BackColor = tableColor_2(colorMode)
        FriPanel.BackColor = tableColor_1(colorMode)
        SatPanel.BackColor = tableColor_2(colorMode)
        SunPanel.BackColor = tableColor_1(colorMode)

        ' ====== 시간표 색상 끝 =====


        ' ====== 상단컨트롤 색상 적용 =====

        RefreshBT.FlatAppearance.BorderColor = BorderColor(colorMode)
        AddCourseBT.FlatAppearance.BorderColor = BorderColor(colorMode)
        MenuBT.FlatAppearance.BorderColor = BorderColor(colorMode)

        RefreshBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colorMode)
        AddCourseBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colorMode)
        MenuBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colorMode)

        RefreshBT.FlatAppearance.MouseDownBackColor = BorderColor(colorMode)
        AddCourseBT.FlatAppearance.MouseDownBackColor = BorderColor(colorMode)
        MenuBT.FlatAppearance.MouseDownBackColor = BorderColor(colorMode)

        RefreshBT.ForeColor = textColor(colorMode)
        AddCourseBT.ForeColor = textColor(colorMode)
        MenuBT.ForeColor = textColor(colorMode)

        TableTitleLabel.ForeColor = textColor(colorMode)

        ' ====== 상단컨트롤 색상 끝 =====


        ' ====== 메모패널 색상 적용 =====

        MemoPanel.BackColor = mainColor(colorMode)
        MemoPanel.ForeColor = textColor(colorMode)
        DragSizePanel.BackColor = dragBarColor(colorMode)
        DragSizePanel.ForeColor = textColor(colorMode)
        MemoRTB.BackColor = tableColor_2(colorMode)
        MemoRTB.ForeColor = textColor(colorMode)

        MemoZoomBT1.FlatAppearance.BorderColor = BorderColor(colorMode)
        MemoZoomBT2.FlatAppearance.BorderColor = BorderColor(colorMode)
        MemoZoomNumBT.FlatAppearance.BorderColor = BorderColor(colorMode)
        MemoMenuBT.FlatAppearance.BorderColor = BorderColor(colorMode)
        MemoCloseBT.FlatAppearance.BorderColor = BorderColor(colorMode)

        MemoZoomBT1.FlatAppearance.MouseOverBackColor = buttonActiveColor(colorMode)
        MemoZoomBT2.FlatAppearance.MouseOverBackColor = buttonActiveColor(colorMode)
        MemoZoomNumBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colorMode)
        MemoMenuBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colorMode)
        MemoCloseBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colorMode)

        MemoZoomBT1.FlatAppearance.MouseDownBackColor = BorderColor(colorMode)
        MemoZoomBT2.FlatAppearance.MouseDownBackColor = BorderColor(colorMode)
        MemoZoomNumBT.FlatAppearance.MouseDownBackColor = BorderColor(colorMode)
        MemoMenuBT.FlatAppearance.MouseDownBackColor = BorderColor(colorMode)
        MemoCloseBT.FlatAppearance.MouseDownBackColor = BorderColor(colorMode)

        MemoZoomBT1.ForeColor = textColor(colorMode)
        MemoZoomBT2.ForeColor = textColor(colorMode)
        MemoZoomNumBT.ForeColor = textColor(colorMode)
        MemoMenuBT.ForeColor = textColor(colorMode)
        MemoCloseBT.ForeColor = textColor(colorMode)
        MemoTitleLabel.ForeColor = activeDayColor(colorMode)

        ' ====== 메모패널 색상 끝 =====


        Select Case colorMode
            Case "Dark"
                MinBT.Image = My.Resources.minicon_w
                MemoMenuBT.BackgroundImage = My.Resources.menuicon_w
                MemoCloseBT.BackgroundImage = My.Resources.closeicon_w
                Menu_1_1.Checked = False
                Menu_1_2.Checked = True
            Case Else
                MinBT.Image = My.Resources.minicon_b
                MemoMenuBT.BackgroundImage = My.Resources.menuicon_b
                MemoCloseBT.BackgroundImage = My.Resources.closeicon_b
                Menu_1_1.Checked = True
                Menu_1_2.Checked = False
        End Select

        Select Case Now.DayOfWeek
            Case DayOfWeek.Monday
                MonLabel.BackColor = activeDayColor(colorMode)
                MonLabel.ForeColor = activeDayTextColor(colorMode)
            Case DayOfWeek.Tuesday
                TueLabel.BackColor = activeDayColor(colorMode)
                TueLabel.ForeColor = activeDayTextColor(colorMode)
            Case DayOfWeek.Wednesday
                WedLabel.BackColor = activeDayColor(colorMode)
                WedLabel.ForeColor = activeDayTextColor(colorMode)
            Case DayOfWeek.Thursday
                ThuLabel.BackColor = activeDayColor(colorMode)
                ThuLabel.ForeColor = activeDayTextColor(colorMode)
            Case DayOfWeek.Friday
                FriLabel.BackColor = activeDayColor(colorMode)
                FriLabel.ForeColor = activeDayTextColor(colorMode)
        End Select

        TimeTable.Refresh()
    End Sub

    Sub updateDateDraw()

        '요일 색상 초기화
        MonLabel.BackColor = tableColor_1(colorMode)
        TueLabel.BackColor = tableColor_2(colorMode)
        WedLabel.BackColor = tableColor_1(colorMode)
        ThuLabel.BackColor = tableColor_2(colorMode)
        FriLabel.BackColor = tableColor_1(colorMode)
        SatLabel.BackColor = tableColor_2(colorMode)
        SunLabel.BackColor = tableColor_1(colorMode)

        MonLabel.ForeColor = lightTextColor(colorMode)
        TueLabel.ForeColor = lightTextColor(colorMode)
        WedLabel.ForeColor = lightTextColor(colorMode)
        ThuLabel.ForeColor = lightTextColor(colorMode)
        FriLabel.ForeColor = lightTextColor(colorMode)
        SatLabel.ForeColor = lightTextColor(colorMode)
        SunLabel.ForeColor = lightTextColor(colorMode)

        '
        Select Case Now.DayOfWeek
            Case DayOfWeek.Monday
                MonLabel.BackColor = activeDayColor(colorMode)
                MonLabel.ForeColor = activeDayTextColor(colorMode)
            Case DayOfWeek.Tuesday
                TueLabel.BackColor = activeDayColor(colorMode)
                TueLabel.ForeColor = activeDayTextColor(colorMode)
            Case DayOfWeek.Wednesday
                WedLabel.BackColor = activeDayColor(colorMode)
                WedLabel.ForeColor = activeDayTextColor(colorMode)
            Case DayOfWeek.Thursday
                ThuLabel.BackColor = activeDayColor(colorMode)
                ThuLabel.ForeColor = activeDayTextColor(colorMode)
            Case DayOfWeek.Friday
                FriLabel.BackColor = activeDayColor(colorMode)
                FriLabel.ForeColor = activeDayTextColor(colorMode)
            Case DayOfWeek.Saturday
                If showSaturday Then
                    SatLabel.BackColor = activeDayColor(colorMode)
                    SatLabel.ForeColor = activeDayTextColor(colorMode)
                End If
            Case DayOfWeek.Sunday
                If showSunday Then
                    SunLabel.BackColor = activeDayColor(colorMode)
                    SunLabel.ForeColor = activeDayTextColor(colorMode)
                End If
        End Select

        Dim fdw As DateTime = DateTime.Today.AddDays(-Weekday(DateTime.Today, FirstDayOfWeek.System) + 2)
        MonLabel.Text = fdw.ToString("dd") + " 월요일"
        TueLabel.Text = fdw.AddDays(1).ToString("dd") + " 화요일"
        WedLabel.Text = fdw.AddDays(2).ToString("dd") + " 수요일"
        ThuLabel.Text = fdw.AddDays(3).ToString("dd") + " 목요일"
        FriLabel.Text = fdw.AddDays(4).ToString("dd") + " 금요일"
        SatLabel.Text = fdw.AddDays(5).ToString("dd") + " 토요일"
        SunLabel.Text = fdw.AddDays(6).ToString("dd") + " 일요일"

        MemoTitleLabel.Text = DateTime.Now.Year.ToString & "-" & DateTime.Now.Month.ToString & "-" & DateTime.Now.Day.ToString
    End Sub

#End Region

#Region "앱 주요 이벤트 (Load, Shown)"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each scrn In Screen.AllScreens
            If scrn.DeviceName = GetINI("SETTING", "WindowDisplay", "", ININamePath) Then
                Me.Location = scrn.Bounds.Location
                Exit For
            End If
        Next

        'DPI계산 (ChkBox 이미지같은거 좀 뚜렷하게 보이도록 전용 이미지 넣기)
        Dim g As Graphics = Me.CreateGraphics()
        currentDPI = g.DpiX

        'For Each scrn In Screen.AllScreens
        ' If scrn.DeviceName = GetINI("SETTING", "WindowDisplay", "", ININamePath) Then
        ' Me.Location = scrn.Bounds.Location
        ' Exit For
        ' End If
        'Next

        Opacity = 0
        UpdateColor()
        updateDateDraw()

        If GetINI("SETTING", "CustomFont", "", ININamePath) = "1" Then
            If Not GetINI("SETTING", "CustomFontName", "", ININamePath) = "" Then
                Dim fntname = GetINI("SETTING", "CustomFontName", "", ININamePath)
                ChangeToCustomFont(Me, fntname)

                'BT1_menu, Memo_menu 폰트 바꾸기 : 속성이 상속되지 않는지라 노가다해야함
                If GetINI("SETTING", "ApplyAllGUIFonts", "", ININamePath) = "1" Then
                    ClearCheckBoxItem.Font = New Font(fntname, ClearCheckBoxItem.Font.Size)
                    BT1MenuTitle.Font = New Font(fntname, BT1MenuTitle.Font.Size, FontStyle.Bold)
                    ChangeThemeItem.Font = New Font(fntname, ChangeThemeItem.Font.Size)
                    TopMostItem.Font = New Font(fntname, SnapToEdgeItem.Font.Size)
                    SnapToEdgeItem.Font = New Font(fntname, SnapToEdgeItem.Font.Size)
                    ColorSettingItem.Font = New Font(fntname, ColorSettingItem.Font.Size)
                    OpacitySelectItem.Font = New Font(fntname, OpacitySelectItem.Font.Size)
                    ShowMemoItem.Font = New Font(fntname, ShowMemoItem.Font.Size)
                    GetFromETItem.Font = New Font(fntname, GetFromETItem.Font.Size)
                    OptionItem.Font = New Font(fntname, OptionItem.Font.Size)
                    ExitItem.Font = New Font(fntname, ExitItem.Font.Size)

                    OpenTableTrayItem.Font = New Font(fntname, OpenTableTrayItem.Font.Size)
                    ExitTrayItem.Font = New Font(fntname, ExitTrayItem.Font.Size)

                    MemoDockItem.Font = New Font(fntname, ExitTrayItem.Font.Size)
                    MemoDockTopItem.Font = New Font(fntname, ExitTrayItem.Font.Size)
                    MemoDockBottomItem.Font = New Font(fntname, ExitTrayItem.Font.Size)
                    MemoDockLeftItem.Font = New Font(fntname, ExitTrayItem.Font.Size)
                    MemoDockRightItem.Font = New Font(fntname, ExitTrayItem.Font.Size)

                    MemoClearItem.Font = New Font(fntname, ExitTrayItem.Font.Size)
                    CloseMemoItem.Font = New Font(fntname, ExitTrayItem.Font.Size)

                    MemoFontSetItem.Font = New Font(fntname, ExitTrayItem.Font.Size)
                    MemoUndoItem.Font = New Font(fntname, ExitTrayItem.Font.Size)
                    MemoCopyItem.Font = New Font(fntname, ExitTrayItem.Font.Size)
                    MemoPasteItem.Font = New Font(fntname, ExitTrayItem.Font.Size)
                    MemoSelectAllItem.Font = New Font(fntname, ExitTrayItem.Font.Size)

                End If
            End If
        End If

        If GetINI("SETTING", "WindowPosition", "", ININamePath).Contains(",") Then
            Dim loc As String() = GetINI("SETTING", "WindowPosition", "", ININamePath).Split(",")
            'Location = New Point(Convert.ToInt16(loc(0)), Convert.ToInt16(loc(1)))
            SetDesktopLocation(Convert.ToInt16(loc(0)), Convert.ToInt16(loc(1)))
        Else
            CenterToScreen()
        End If

        If GetINI("SETTING", "WindowSize", "", ININamePath).Contains(",") Then
            Dim siz As String() = GetINI("SETTING", "WindowSize", "", ININamePath).Split(",")
            Width = Convert.ToInt16(siz(0))
            Height = Convert.ToInt16(siz(1))
        End If

        If GetINI("SETTING", "SnapToEdge", "", ININamePath) = "" Then
            SetINI("SETTING", "SnapToEdge", "1", ININamePath)
        End If

        If GetINI("SETTING", "FixStartTime", "", ININamePath) = "1" Then
            Dim fSTVal = GetINI("SETTING", "FixStartTimeValue", "", ININamePath)
            If IsNumeric(fSTVal) Then starttime = Convert.ToInt16(fSTVal)
        End If

        snaptoedge = (GetINI("SETTING", "SnapToEdge", "", ININamePath) = "1")
        tablePatternSetting = GetINI("SETTING", "TablePattern", "", ININamePath)
        ShowInTaskbar = Not (GetINI("SETTING", "AlwaysHideToTray", "", ININamePath) = "1")

        MemoOptionUpdate()

        updateCell()

    End Sub


    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        formshown = True
        Refresh()

        If Not IsOnScreen(Me) Then

            Dim scrn = Screen.GetWorkingArea(Me)
            Dim workArea = New Point(scrn.Location.X + scrn.Width, scrn.Location.Y + scrn.Height)
            Dim tmpLoc As New Point(0, 0)

            If Location.X < 0 Then
                tmpLoc.X = 0
            ElseIf Location.X > workArea.X - Me.Width Then
                tmpLoc.X = workArea.X - Me.Width
            End If

            If Location.Y < 0 Then
                tmpLoc.Y = 0
            ElseIf Location.Y > workArea.Y - Me.Height Then
                tmpLoc.Y = workArea.Y - Me.Height
            End If

            Location = tmpLoc '디스플레이 범위 밖일시 안으로 넣기
            'MsgBox("바운더리 밖입니다.")
        End If

        If GetINI("SETTING", "MinStart", "", ININamePath) = "1" Then
            WindowState = FormWindowState.Minimized
            Opacity = Convert.ToDouble(GetINI("SETTING", "Opacity", "", ININamePath))
        Else

            '강제 포커스
            TopMost = True
            Refresh()
            TopMost = False

            If IsNumeric(GetINI("SETTING", "Opacity", "", ININamePath)) Then
                FadeIn(Me, Convert.ToDouble(GetINI("SETTING", "Opacity", "", ININamePath)))
            Else
                FadeIn(Me, 1)
            End If
        End If

        If Not checkStartUp() Then
            If Not GetINI("SETTING", "NoStartupSuggestion", "", ININamePath) = "1" Then
                WindowState = FormWindowState.Normal
                StartupAsk.ShowDialog(Me)
            End If
        End If

        If Not updated Then
            MsgBox("설정값을 읽어올 수 없습니다." + vbCr + "(시간표를 설정해 주세요)" _
                   + vbCr + vbCr + "tip: 우측 상단의 메뉴(...) 버튼 > '에타에서 불러오기' 를 통해 에브리타임 시간표를 바로 불러올 수 있습니다.", vbInformation)
        Else
            If Not GetINI("SETTING", "TodaysCourseNotify", "", ININamePath) = "0" Then
                TodayCourseNotify()
            End If
        End If

        TopMost = (GetINI("SETTING", "TopMost", "", ININamePath) = "1")
    End Sub

#End Region

#Region "앱 WindowState 변경"

    Private Sub NotifyIcon1_BalloonTipClicked(sender As Object, e As EventArgs) Handles NotifyIcon1.BalloonTipClicked,
        NotifyIcon1.DoubleClick, OpenTableTrayItem.Click
        ReopenForm()
    End Sub

    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        Tray_menu.Show(Cursor.Position)
    End Sub

    Public Sub ReopenForm()
        Opacity = 0
        Show()
        WindowState = FormWindowState.Normal
        TopMost = True
        Refresh()
        TopMost = False
        FadeIn(Me, Convert.ToDouble(GetINI("SETTING", "Opacity", "", ININamePath)))
    End Sub

#End Region

#Region "버튼/도구상자/키 이벤트"
    Private Sub AddCourseBT_Click(sender As Object, e As EventArgs) Handles AddCourseBT.Click
        SetCourse.Close()
        SetCourse.SetDesktopLocation(Location.X + AddCourseBT.Location.X + AddCourseBT.Width - SetCourse.Width + MainPanel.Location.X,
                                     Location.Y + DayTable.Location.Y + MainPanel.Location.Y)
        SetCourse.Show()
    End Sub

    Private Sub RefreshBT_Click(sender As Object, e As EventArgs) Handles RefreshBT.Click
        updateCell()
    End Sub

    Private Sub MinBT_MouseEnter(sender As Object, e As EventArgs) Handles MinBT.MouseEnter
        MinBT.BackColor = buttonActiveColor(colorMode)
    End Sub

    Private Sub MinBT_MouseLeave(sender As Object, e As EventArgs) Handles MinBT.MouseLeave
        MinBT.BackColor = Color.Transparent
    End Sub

    Private Sub MinBT_Click(sender As Object, e As EventArgs) Handles MinBT.Click

        If GetINI("SETTING", "FadeEffect", "", ININamePath) = "0" Then
            WindowState = FormWindowState.Minimized
            If GetINI("SETTING", "HideToTray", "", ININamePath) = "1" Then Hide()
        Else
            hiding = True
            tmp_opa = Opacity
            prevloc = Me.Location
            hideani.Start()
        End If

    End Sub

    Private Sub TitleEditBT_MouseEnter(sender As Object, e As EventArgs) Handles TitleEditBT.MouseEnter
        TitleEditBT.BackColor = buttonActiveColor(colorMode)
    End Sub

    Private Sub TitleEditBT_MouseLeave(sender As Object, e As EventArgs) Handles TitleEditBT.MouseLeave
        TitleEditBT.BackColor = Color.Transparent
    End Sub

    Private Sub TitleEditBT_Click(sender As Object, e As EventArgs) Handles TitleEditBT.Click
        If titleEditMode Then
            TitleEditApply()
        Else
            titleEditMode = True
            RenameTitleTextBox.Width = TableTitleLabel.Width
            RenameTitleTextBox.Text = TableTitleLabel.Text
            TableTitleLabel.Visible = False
            RenameTitleTextBox.Visible = True
            TitleEditBT.Image = My.Resources.bt_titleapply
        End If
    End Sub


    Private Sub Menu_1_1_Click(sender As Object, e As EventArgs) Handles Menu_1_1.Click
        SetINI("SETTING", "ColorMode", "White", ININamePath)
        If Application.OpenForms().OfType(Of SetCourse).Any Then SetCourse.UpdateColor()
        UpdateColor()
    End Sub

    Private Sub Menu_1_2_Click(sender As Object, e As EventArgs) Handles Menu_1_2.Click
        SetINI("SETTING", "ColorMode", "Dark", ININamePath)
        If Application.OpenForms().OfType(Of SetCourse).Any Then SetCourse.UpdateColor()
        UpdateColor()
    End Sub

    Private Sub MenuBT_Click(sender As Object, e As EventArgs) Handles MenuBT.Click
        BT1_menu.Show(Cursor.Position.X - BT1_menu.Width, Cursor.Position.Y)
    End Sub

    Private Sub TopMostItem_Click(sender As Object, e As EventArgs) Handles TopMostItem.Click
        If TopMost = True Then
            SetINI("SETTING", "TopMost", "0", ININamePath)
            TopMost = False
        Else
            SetINI("SETTING", "TopMost", "1", ININamePath)
            TopMost = True
        End If
    End Sub

    Private Sub Menu_2_Click(sender As Object, e As EventArgs) Handles SnapToEdgeItem.Click
        If snaptoedge Then
            SetINI("SETTING", "SnapToEdge", "0", ININamePath)
        Else
            SetINI("SETTING", "SnapToEdge", "1", ININamePath)
        End If
    End Sub

    Private Sub BT1_menu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles BT1_menu.Opening

        Dim ver = My.Application.Info.Version.ToString.Split(".")
        BT1MenuTitle.Text = "uTable " + ver(0) + "." + ver(1) + "v"

        BT1_menu.BackColor = mainColor(colorMode)
        BT1MenuTitle.ForeColor = lightTextColor(colorMode)
        BT1_menu.ForeColor = textColor(colorMode)

        snaptoedge = (GetINI("SETTING", "SnapToEdge", "", ININamePath) = "1")
        ClearCheckBoxItem.Visible = Not (GetINI("SETTING", "ShowChkBox", "", ININamePath) = "0")

        If snaptoedge Then
            SnapToEdgeItem.Text = "창에 붙지 않기"
        Else
            SnapToEdgeItem.Text = "창에 붙기"
        End If

        If TopMost Then
            TopMostItem.Text = "항상 위에 표시 안함"
        Else
            TopMostItem.Text = "항상 위에 표시"
        End If

        Select Case GetINI("SETTING", "Opacity", "", ININamePath)
            Case "1"
                ToolStripComboBox1.SelectedIndex = 0
            Case "0.9"
                ToolStripComboBox1.SelectedIndex = 1
            Case "0.8"
                ToolStripComboBox1.SelectedIndex = 2
            Case "0.7"
                ToolStripComboBox1.SelectedIndex = 3
            Case "0.6"
                ToolStripComboBox1.SelectedIndex = 4
            Case "0.5"
                ToolStripComboBox1.SelectedIndex = 5
            Case "0.4"
                ToolStripComboBox1.SelectedIndex = 6
            Case "0.3"
                ToolStripComboBox1.SelectedIndex = 7
            Case "0.2"
                ToolStripComboBox1.SelectedIndex = 8
            Case Else
                ToolStripComboBox1.SelectedIndex = 0
        End Select

        If GetINI("SETTING", "MemoShow", "", ININamePath) = "1" Then
            ShowMemoItem.Text = "메모장 숨기기"
        Else
            ShowMemoItem.Text = "메모장 표시"
        End If
    End Sub

    Private Sub Tray_menu_Opening(sender As Object, e As CancelEventArgs) Handles Tray_menu.Opening
        Tray_menu.BackColor = mainColor(colorMode)
        Tray_menu.ForeColor = textColor(colorMode)
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        Select Case ToolStripComboBox1.SelectedIndex
            Case 0 '100
                Opacity = 1
            Case 1 '90
                Opacity = 0.9
            Case 2 '80
                Opacity = 0.8
            Case 3 '70
                Opacity = 0.7
            Case 4 '60
                Opacity = 0.6
            Case 5 '50
                Opacity = 0.5
            Case 6 '40
                Opacity = 0.4
            Case 7 '30
                Opacity = 0.3
            Case 8 '20
                Opacity = 0.2
        End Select

        SetINI("SETTING", "Opacity", Opacity.ToString, ININamePath)
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RenameTitleTextBox.KeyDown
        If e.KeyCode = Keys.Return Then
            TitleEditApply()
        End If
    End Sub

    Public Sub Menu_4_Click(sender As Object, e As EventArgs) Handles GetFromETItem.Click
        ' DLL 존재 여부 체크 (스토어에디션은 X)
        Dim DLLOK = False

        If Not isStore Then


            Dim exeFullpath As String = Application.ExecutablePath
            Dim finalDir As String = exeFullpath.Substring(0, exeFullpath.LastIndexOf("\"))

            If Not (My.Computer.FileSystem.FileExists(finalDir + "\Microsoft.Web.WebView2.Core.dll") And
           My.Computer.FileSystem.FileExists(finalDir + "\Microsoft.Web.WebView2.WinForms.dll") And
           My.Computer.FileSystem.FileExists(finalDir + "\WebView2Loader.dll")) Then
                If MsgBox("에브리타임 시간표를 불러오기 위해서는 추가적인 다운로드(0.6MB)가 필요합니다. 파일은 uTable이 실행된 위치에 저장됩니다." _
                   + vbCr + vbCr + "'확인'을 누르면 다운로드 및 불러오기 작업이 진행되며, '취소'를 누르면 작업이 중단됩니다.", vbOKCancel + vbInformation, "다운로드 필요") = vbOK Then
                    DLLDownloader.ShowDialog(Me)
                End If
            Else
                DLLOK = True
            End If

        Else
            DLLOK = True
        End If

        If DLLOK Then
            EveryTimeBrowserNew.Close()
            EverytimeSemesterSelector.Close()
            EverytimeSemesterSelector.ShowDialog(Me)
        End If
    End Sub

    Private Sub Menu_5_Click(sender As Object, e As EventArgs) Handles OptionItem.Click
        OptionForm.Close()
        OptionForm.SetDesktopLocation(Location.X + Width - OptionForm.Width, Location.Y + TopPanel.Location.Y + TopPanel.Height)
        OptionForm.ShowDialog(Me)
    End Sub

    Private Sub ExitItem_Click(sender As Object, e As EventArgs) Handles ExitItem.Click, ExitTrayItem.Click
        Application.Exit()
    End Sub

    Private Sub AllColorSetItem_Click(sender As Object, e As EventArgs) Handles AllColorSetItem.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            Dim tmp As String = ""
            For Each s As String In courseData
                s = s.Replace(getData(s, "color"), ColorTranslator.ToHtml(ColorDialog1.Color))
                tmp += "<course>" + s + "</course>" + vbCrLf
            Next
            writeTable(tmp)
            updateCell()
        End If
    End Sub

    Private Sub AllDarkerItem_Click(sender As Object, e As EventArgs) Handles AllDarkerItem.Click
        Dim tmp As String = "<tablename>" + TableTitleLabel.Text + "</tablename>" + vbCrLf
        For Each s As String In courseData
            Dim oldColor As Color = ColorTranslator.FromHtml(getData(s, "color"))
            s = s.Replace(getData(s, "color"), ColorTranslator.ToHtml(ControlPaint.Dark(oldColor, 0.01)))
            tmp += "<course>" + s + "</course>" + vbCrLf
        Next
        writeTable(tmp)
        updateCell()
    End Sub

    Private Sub AllBrighterItem_Click(sender As Object, e As EventArgs) Handles AllBrighterItem.Click
        Dim tmp As String = "<tablename>" + TableTitleLabel.Text + "</tablename>" + vbCrLf
        For Each s As String In courseData
            Dim oldColor As Color = ColorTranslator.FromHtml(getData(s, "color"))
            s = s.Replace(getData(s, "color"), ColorTranslator.ToHtml(ControlPaint.Light(oldColor, 0.3)))
            tmp += "<course>" + s + "</course>" + vbCrLf
        Next
        writeTable(tmp)
        updateCell()
    End Sub

    Private Sub ClearCheckBoxItem_Click(sender As Object, e As EventArgs) Handles ClearCheckBoxItem.Click
        Dim data As String = readTable()
        writeTable(data.Replace("<checked>True</checked>", "<checked>False</checked>"))
        updateCell()
    End Sub

    Private Sub ShowMemoItem_Click(sender As Object, e As EventArgs) Handles ShowMemoItem.Click
        If GetINI("SETTING", "MemoShow", "", ININamePath) = "1" Then
            SetINI("SETTING", "MemoShow", "0", ININamePath)
        Else
            SetINI("SETTING", "MemoShow", "1", ININamePath)
        End If

        MemoOptionUpdate()
    End Sub

#End Region

#Region "시간표 셀 관리"

    Public Sub updateCell()
        Try

            'CellControl 설정 변수 업데이트
            FadeEffect = GetINI("SETTING", "FadeEffect", "", ININamePath)
            CustomFont = GetINI("SETTING", "CustomFont", "", ININamePath)
            CustomFontName = GetINI("SETTING", "CustomFontName", "", ININamePath)
            AutoTextColor = GetINI("SETTING", "AutoTextColor", "", ININamePath)
            _BlackText = GetINI("SETTING", "BlackText", "", ININamePath)
            _AlwaysExpand = GetINI("SETTING", "AlwaysExpand", "", ININamePath)
            ExpandCell = GetINI("SETTING", "ExpandCell", "", ININamePath)
            ShowMemo = GetINI("SETTING", "ShowMemo", "", ININamePath)
            ShowProf = GetINI("SETTING", "ShowProf", "", ININamePath)
            _ShowChkBox = GetINI("SETTING", "ShowChkBox", "", ININamePath)

            TimeTable.Visible = False
            showSaturday = False
            showSunday = False

            '구성요소 초기화
            MonPanel.Controls.Clear()
            TuePanel.Controls.Clear()
            WedPanel.Controls.Clear()
            ThuPanel.Controls.Clear()
            FriPanel.Controls.Clear()
            SatPanel.Controls.Clear()
            SunPanel.Controls.Clear()
            updated = False

            Dim data = readTable()
            Dim min As Integer = 9999999
            Dim max As Integer = 0

            If data.Contains("<tablename>") Then
                TableTitleLabel.Text = xmlDecode(getData(data, "tablename"))
            Else
                TableTitleLabel.Text = "이름 없는 시간표"
            End If

            Text = TableTitleLabel.Text
            courseData.Clear()

            If data.Contains("<course>") Then
                courseData = getDatas(data, "course")

                '최대, 최소계산
                For Each s As String In courseData
                    If Convert.ToInt16(getData(s, "start")) < min Then min = Convert.ToInt16(getData(s, "start"))
                    If Convert.ToInt16(getData(s, "end")) > max Then max = Convert.ToInt16(getData(s, "end"))
                Next

                starttime = min
                endtime = max

                If GetINI("SETTING", "FixStartTime", "", ININamePath) = "1" Then
                    Dim fSTVal = GetINI("SETTING", "FixStartTimeValue", "", ININamePath)
                    If IsNumeric(fSTVal) Then starttime = Convert.ToInt16(fSTVal)
                End If

                '셀계산
                '여기서 xmldecode 하니까 꼭 눈여겨두자
                For Each s As String In courseData
                    addCell(Convert.ToInt16(getData(s, "start")),
                            Convert.ToInt16(getData(s, "end")),
                            getData(s, "day") + "-" + getData(s, "start") + "-" + getData(s, "name"),
                            xmlDecode(getData(s, "name")),
                            xmlDecode(getData(s, "prof")),
                            xmlDecode(getData(s, "memo")),
                            ColorTranslator.FromHtml(getData(s, "color")),
                            Convert.ToInt16(getData(s, "day")),
                            getData(s, "checked"))

                    If Convert.ToInt16(getData(s, "day")) = 5 Then '토요일 추가시
                        showSaturday = True
                    ElseIf Convert.ToInt16(getData(s, "day")) = 6 Then '일요일 추가시
                        showSunday = True
                    End If
                Next

                updated = True
            Else
                '맨 처음 창 열렸을때일시 = 불투명도 0일때 -> 일단 창 다 띄우고 나서 msgbox 띄우기 (그래야 포커스잡기 쉬움)
                If Not Opacity = 0 Then
                    MsgBox("설정값을 읽어올 수 없습니다." + vbCr + "(시간표를 설정해 주세요)" _
                       + vbCr + vbCr + "tip: 우측 상단의 메뉴(...) 버튼 > '에타에서 불러오기' 를 통해 에브리타임 시간표를 바로 불러올 수 있습니다.", vbInformation)
                End If
            End If

            DayTable.Visible = Not (GetINI("SETTING", "ShowDay", "", ININamePath) = "0")

            If showSunday Then '토+일요일 표시
                For i = 0 To 6
                    DayTable.ColumnStyles(i).SizeType = SizeType.Percent
                    DayTable.ColumnStyles(i).Width = 14.28
                    TimeTable.ColumnStyles(i).SizeType = SizeType.Percent
                    TimeTable.ColumnStyles(i).Width = 14.28
                Next
            ElseIf showSaturday Then '토요일 표시
                For i = 0 To 5
                    DayTable.ColumnStyles(i).SizeType = SizeType.Percent
                    DayTable.ColumnStyles(i).Width = 16.67
                    TimeTable.ColumnStyles(i).SizeType = SizeType.Percent
                    TimeTable.ColumnStyles(i).Width = 16.67
                Next
                DayTable.ColumnStyles(6).SizeType = SizeType.Absolute
                DayTable.ColumnStyles(6).Width = 0
                TimeTable.ColumnStyles(6).SizeType = SizeType.Absolute
                TimeTable.ColumnStyles(6).Width = 0
            Else '둘다 안표시
                For i = 0 To 4
                    DayTable.ColumnStyles(i).SizeType = SizeType.Percent
                    DayTable.ColumnStyles(i).Width = 20
                    TimeTable.ColumnStyles(i).SizeType = SizeType.Percent
                    TimeTable.ColumnStyles(i).Width = 20
                Next

                DayTable.ColumnStyles(5).SizeType = SizeType.Absolute
                DayTable.ColumnStyles(6).SizeType = SizeType.Absolute
                DayTable.ColumnStyles(5).Width = 0
                DayTable.ColumnStyles(6).Width = 0
                TimeTable.ColumnStyles(5).SizeType = SizeType.Absolute
                TimeTable.ColumnStyles(6).SizeType = SizeType.Absolute
                TimeTable.ColumnStyles(5).Width = 0
                TimeTable.ColumnStyles(6).Width = 0
            End If

            For Each s As String In courseData
                resizeCell(Convert.ToInt16(getData(s, "start")), Convert.ToInt16(getData(s, "end")),
                           getData(s, "day") + "-" + getData(s, "start") + "-" + getData(s, "name"))
            Next

        Catch ex As Exception

            MsgBox("시간표 데이터를 읽던 도중 오류가 발생했습니다." + vbCr + "(" + ex.Message + ")" + vbCr + vbCr _
                   + "시간표의 값이 올바르지 않거나, 값이 손상되었을 수 있습니다." + vbCr _
                   + "문제가 지속되면 시간표(" + TableSaveLocation(True) + ")를 지우고 다시 만들어 주세요.", vbCritical)

        End Try

        prevTime = Nothing
        TimeTable.Visible = True
    End Sub

    Sub addCell(startt As Integer, endt As Integer, name As String, title As String, prof As String, memo As String, color As Color, day As Integer, checked As String)

        Dim timelength As Integer = endtime - starttime
        Dim part As Double = (endt - startt) / timelength
        Dim cell As New CellControl

        cell.ForeColor = Color.White
        'cell.BackColor = color
        cell.goalColor = color

        With cell
            .FadeEffect = FadeEffect
            .CustomFont = CustomFont
            .CustomFontName = CustomFontName
            .AutoTextColor = AutoTextColor
            ._BlackText = _BlackText
            ._AlwaysExpand = _AlwaysExpand
            .ExpandCell = ExpandCell
            .ShowMemo = ShowMemo
            .ShowProf = ShowProf
            ._ShowChkBox = _ShowChkBox
        End With

        Select Case day
            Case 0
                MonPanel.Controls.Add(cell)
            Case 1
                TuePanel.Controls.Add(cell)
            Case 2
                WedPanel.Controls.Add(cell)
            Case 3
                ThuPanel.Controls.Add(cell)
            Case 4
                FriPanel.Controls.Add(cell)
            Case 5
                SatPanel.Controls.Add(cell)
            Case 6
                SunPanel.Controls.Add(cell)
        End Select

        cell.Location = New Point(0, ((startt - starttime) / timelength) * MonPanel.Height)
        'MsgBox(((startt - starttime) / timelength) * Panel1.Height)
        cell.Width = MonPanel.Width
        cell.Height = part * MonPanel.Height
        cell.defHeight = part * MonPanel.Height
        cell.dayNum = day

        'MsgBox(part * Panel1.Height)

        cell.TopTimeLabel.Text = (startt \ 60).ToString + ":"
        If startt Mod 60 = 0 Then
            cell.TopTimeLabel.Text += "00"
        Else
            cell.TopTimeLabel.Text += (startt Mod 60).ToString("D2")
        End If

        cell.BottomTimeLabel.Text = (endt \ 60).ToString + ":"

        If endt Mod 60 = 0 Then
            cell.BottomTimeLabel.Text += "00"
        Else
            cell.BottomTimeLabel.Text += (endt Mod 60).ToString("D2")
        End If

        If title.Length > 100 Then title = Mid(title, 1, 100) + "..."
        If prof.Length > 50 Then prof = Mid(prof, 1, 50) + "..."
        If memo.Length > 2000 Then memo = Mid(memo, 1, 2000) + "..."

        cell.TitleLabel.Text = title
        cell.ProfLabel.Text = prof
        cell.MemoLabel.Text = memo
        cell.Name = name

        cell.checked = (checked = "True")
    End Sub

    Sub resizeCell(startt As Integer, endt As Integer, name As String)
        Dim timelength As Integer = endtime - starttime
        Dim part As Double = (endt - startt) / timelength
        Dim cell As CellControl = TimeTable.Controls.Find(name, True).First

        cell.Location = New Point(0, ((startt - starttime) / timelength) * MonPanel.Height)
        cell.defLoc = ((startt - starttime) / timelength) * MonPanel.Height
        'MsgBox(((startt - starttime) / timelength) * Panel1.Height)
        cell.Width = MonPanel.Width
        cell.Height = part * MonPanel.Height
        cell.defHeight = part * MonPanel.Height

        If cell.alwaysExpand Then cell.ForceExpand()
    End Sub

#End Region

#Region "시간표 타이틀 관리"

    Private Sub TitleEditApply()
        Dim newtitle As String = RenameTitleTextBox.Text

        If newtitle = "" Then
            titleEditMode = False
            TableTitleLabel.Visible = True
            RenameTitleTextBox.Visible = False
            TitleEditBT.Image = My.Resources.bt_titleedit

        Else
            Try
                Dim data As String = readTable()
                If data.Contains("<tablename>") Then
                    Dim oldtitle As String = getData(data, "tablename")
                    data = data.Replace("<tablename>" + oldtitle + "</tablename>", "<tablename>" + xmlEncode(newtitle) + "</tablename>")
                    writeTable(data)
                Else
                    writeTable("<tablename>" + xmlEncode(newtitle) + "</tablename>" + vbCrLf + data)
                End If
            Catch ex As Exception
                MsgBox("이름 변경 도중 문제가 발생했습니다." + vbCr + ex.Message, vbCritical)
                Exit Sub
            End Try

            titleEditMode = False
            TableTitleLabel.Visible = True
            RenameTitleTextBox.Visible = False
            TitleEditBT.Image = My.Resources.bt_titleedit
            updateCell()
        End If
    End Sub

#End Region

#Region "시간표 그리기 관리 (크기비율, 점선배경)"

    Private Sub TimeTable_SizeChanged(sender As Object, e As EventArgs) Handles TimeTable.SizeChanged
        'TimeTable.ResumeLayout()

        If updated Then

            For Each s As String In courseData
                resizeCell(Convert.ToInt16(getData(s, "start")), Convert.ToInt16(getData(s, "end")),
                           getData(s, "day") + "-" + getData(s, "start") + "-" + getData(s, "name"))
            Next

            TimeTable.Visible = True

        End If
    End Sub

    Private Sub TablePanel_Paint(sender As Object, e As PaintEventArgs) Handles MonPanel.Paint, TuePanel.Paint, WedPanel.Paint,
        ThuPanel.Paint, FriPanel.Paint, SatPanel.Paint, SunPanel.Paint

        If Not showSaturday And sender Is SatPanel Then
            If Not showSunday Then Exit Sub
        ElseIf Not showSunday And sender Is SunPanel Then
            Exit Sub
        End If

        Dim panel As Panel = sender

        '시간표 시작과 끝 사이의 총 시간 길이
        Dim timeLength As Integer = endtime - starttime
        If Not timeLength > 0 Then Exit Sub

        Dim panelHeight As Integer = MonPanel.Height
        Dim panelWidth As Integer = MonPanel.Width
        Dim minLengh As Double = 1 / timeLength * panelHeight

        'Dim left As Integer = starttime Mod 60
        Dim thickness As Integer = 3 * (currentDPI / 96)

        Dim colorMul As Single = 0.9
        If colorMode = "Dark" Then
            colorMul = 1.35
        End If

        Dim c As Color = Color.FromArgb(panel.BackColor.R * colorMul,
                                        panel.BackColor.G * colorMul,
                                        panel.BackColor.B * colorMul)

        Dim g As Graphics = panel.CreateGraphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.Clear(panel.BackColor)


        'Win11용 코더라운딩
        Dim showRnd = False
        Dim isLeft = True

        '월요일일시
        If panel Is MonPanel Then
            showRnd = True
        Else '나머지
            If (Not showSaturday And panel Is FriPanel) Or (showSunday And panel Is SunPanel) Then
                showRnd = True
                isLeft = False
            End If
        End If

        If showRnd Then
            Dim edgeBrush = New SolidBrush(BackColor)
            Dim backBrush = New SolidBrush(panel.BackColor)
            Dim rndSize = Convert.ToInt16(Me.RndSize * (currentDPI / 96))

            If isLeft Then
                '좌측
                g.FillRectangle(edgeBrush, 0, panel.Height - rndSize, rndSize, rndSize)
                g.FillEllipse(backBrush, 0, panel.Height - rndSize * 2, rndSize * 2, rndSize * 2)
            Else
                '우측
                g.FillRectangle(edgeBrush, panel.Width - rndSize, panel.Height - rndSize, rndSize, rndSize)
                g.FillEllipse(backBrush, panel.Width - rndSize * 2, panel.Height - rndSize * 2, rndSize * 2, rndSize * 2)
            End If
        End If


        ' 점선 표시
        If Not tablePatternSetting = "None" Then

            Dim p As New Pen(c, thickness)
            'Dim g As Graphics = panel.CreateGraphics

            p.DashStyle = Drawing2D.DashStyle.Dot

            For j As Integer = starttime To endtime
                If j > 0 And j Mod 60 = 0 Then
                    Dim pos As Double = (j - starttime) * minLengh + thickness / 2
                    g.DrawLine(p, New Point(0, pos), New Point(panelWidth, pos))
                End If
            Next

            g.Dispose()
            p.Dispose()
        End If

    End Sub

#End Region

#Region "타이머 이벤트 (Animation, Checker)"

    Private Sub TimeCheck_Tick(sender As Object, e As EventArgs) Handles TimeCheck.Tick
        If PrevDay = Nothing Or Not PrevDay = Today Then
            updateDateDraw()
            PrevDay = Today
        End If

        '1분 전환때마다 조회하도록
        '근데 테이블 reload 할때는 바로 조회가능하게 prevTime을 Nothing으로 하자
        If prevTime = Nothing Or
            Not New Date(prevTime.Year, prevTime.Month, prevTime.Day, prevTime.Hour, prevTime.Minute, 0) _
            = New Date(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute, 0) Then

            'MsgBox(Now.ToString)
            If Not (GetINI("SETTING", "CourseNotify", "", ININamePath) = "0") Then CheckNotify()
            prevTime = Now
        End If

    End Sub


    Private Sub hideani_Tick(sender As Object, e As EventArgs) Handles hideani.Tick
        If poscount >= 15 Then
            Me.Opacity = 0
            poscount = 0
            hideani.Stop()
            Me.SetDesktopLocation(prevloc.X, prevloc.Y)
            WindowState = FormWindowState.Minimized
            Me.Opacity = tmp_opa
            hiding = False
            If GetINI("SETTING", "HideToTray", "", ININamePath) = "1" Then Hide()
        Else
            Me.SetDesktopLocation(Location.X, Location.Y + dpicalc(Me, poscount))
            poscount += 1
            Opacity -= tmp_opa / 15
        End If
    End Sub

#End Region

#Region "알림 설정"

    Sub CheckNotify()
        Try
            Dim dayData As New List(Of String)

            If courseData.Count > 0 Then
                For Each s As String In courseData
                    Dim tmp As String = getData(s, "day")
                    Dim day As String = ""

                    Select Case Today.DayOfWeek
                        Case DayOfWeek.Monday
                            day = "0"
                        Case DayOfWeek.Tuesday
                            day = "1"
                        Case DayOfWeek.Wednesday
                            day = "2"
                        Case DayOfWeek.Thursday
                            day = "3"
                        Case DayOfWeek.Friday
                            day = "4"
                        Case DayOfWeek.Saturday
                            day = "5"
                        Case DayOfWeek.Sunday
                            day = "6"
                    End Select

                    If tmp = day Then
                        dayData.Add(s)
                    End If
                Next

                Dim currentTime As Integer = Now.Hour * 60 + Now.Minute
                Dim notifyTime As List(Of String) = GetINI("SETTING", "NotifyMin", "", ININamePath).Split(",").ToList

                Dim notificationName As String = ""

                If dayData.Count > 0 Then
                    For Each s In dayData
                        Dim targetTime As Integer = Convert.ToInt16(getData(s, "start"))

                        If targetTime < currentTime Then Continue For

                        '수업 시간 됐을때
                        If targetTime = currentTime Then
                            notificationName = getData(s, "day") + "-" + getData(s, "start") + "-" + getData(s, "name") + "-0"

                            '수업 시작이 5분 이하 남았고 5분 옵션 체크됐을때
                        ElseIf notifyTime.Contains("5") And (targetTime - currentTime) <= 5 Then
                            notificationName = getData(s, "day") + "-" + getData(s, "start") + "-" + getData(s, "name") + "-5"

                            '수업 시작이 15분 이하 남았고 15분 옵션 체크됐을때
                        ElseIf notifyTime.Contains("15") And (targetTime - currentTime) <= 15 Then
                            notificationName = getData(s, "day") + "-" + getData(s, "start") + "-" + getData(s, "name") + "-15"

                            '수업 시작이 30분 이하 남았고 30분 옵션 체크됐을때
                        ElseIf notifyTime.Contains("30") And (targetTime - currentTime) <= 30 Then
                            notificationName = getData(s, "day") + "-" + getData(s, "start") + "-" + getData(s, "name") + "-30"

                        Else
                            Continue For

                        End If

                        '여기서부턴 위 if문에 뭐가 걸린것 -> 알림할 껀덕지가 있는거
                        ' but, 아래 조건에 해당하면 무시하고 마찬가지로 continue 해야함
                        ' 1. 이미 보낸 똑같은 알람
                        ' 2. 무시 조건에 해당하는 수업 (ex. memo에 (알림 무시) 포함)

                        Dim memo As String = getData(s, "memo")

                        If prevNotificationName = notificationName Then
                            Continue For

                        ElseIf memo.Contains("(알림 무시)") Or memo.Contains("(알림무시)") _
                            Or memo.Contains("(알림X)") Or memo.Contains("(알림x)") Then
                            Continue For

                        End If

                        'NotifyIcon1.Visible = True
                        '이제 진짜 푸시 보내기
                        prevNotificationName = notificationName
                        Dim message As String = ""

                        If targetTime = currentTime Then
                            message = "수업이 시작되었습니다." + vbCr + "아이콘을 눌러 시간표를 확인하세요."
                        Else
                            message = (targetTime - currentTime).ToString + "분 뒤 수업이 있습니다." + vbCr _
                                + "아이콘을 눌러 시간표를 확인하세요."
                        End If

                        If Not (GetINI("SETTING", "NotifySound", "", ININamePath) = "0") Then
                            Dim soundLocation As String = GetINI("SETTING", "NotifySoundFile", "", ININamePath)

                            If soundLocation = "" Or My.Computer.FileSystem.FileExists(soundLocation) = False Then _
                                soundLocation = "C:\Windows\Media\Ring01.wav"

                            Try
                                My.Computer.Audio.Play(soundLocation, AudioPlayMode.Background)
                            Catch ex As Exception
                                '소리 재생 실패
                            End Try
                        End If

                        NotifyIcon1.ShowBalloonTip(9999, xmlDecode(getData(s, "name")) _
                                                   + " (" + xmlDecode(getData(s, "prof")) + ")", message, ToolTipIcon.None)
                    Next

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub TodayCourseNotify()
        Try
            Dim dayData As New List(Of String)

            If courseData.Count > 0 Then
                For Each s As String In courseData
                    Dim tmp As String = getData(s, "day")
                    Dim day As String = ""

                    Select Case Today.DayOfWeek
                        Case DayOfWeek.Monday
                            day = "0"
                        Case DayOfWeek.Tuesday
                            day = "1"
                        Case DayOfWeek.Wednesday
                            day = "2"
                        Case DayOfWeek.Thursday
                            day = "3"
                        Case DayOfWeek.Friday
                            day = "4"
                        Case DayOfWeek.Saturday
                            day = "5"
                        Case DayOfWeek.Sunday
                            day = "6"
                    End Select

                    If tmp = day Then
                        dayData.Add(s)
                    End If
                Next

                If dayData.Count > 0 Then
                    Dim courses As New List(Of String)
                    Dim time As New List(Of Integer)

                    For Each s In dayData
                        courses.Add(xmlDecode(getData(s, "name")) + " (" + xmlDecode(getData(s, "prof")) + ")")
                        time.Add(Convert.ToInt16(getData(s, "start")))
                    Next

                    '표시 순서를 시작 시간 오름차순으로 정렬
                    Dim q = From x In courses.Zip(time, Function(t, sort) New With {.Obj = t, sort})
                            Order By x.sort Ascending
                            Select x.Obj

                    courses = q.ToList()
                    time.Sort()

                    Dim message As String = ""
                    Dim title As String = "오늘의 수업 (" & Today.Month & "월 " & Today.Day & "일 "

                    For i = 0 To time.Count - 1
                        message += String.Format("{0:00}:{1:00}", time(i) \ 60, time(i) Mod 60) + " " + courses(i) + vbCr
                    Next

                    Select Case Today.DayOfWeek
                        Case DayOfWeek.Monday
                            title += "월요일"
                        Case DayOfWeek.Tuesday
                            title += "화요일"
                        Case DayOfWeek.Wednesday
                            title += "수요일"
                        Case DayOfWeek.Thursday
                            title += "목요일"
                        Case DayOfWeek.Friday
                            title += "금요일"
                        Case DayOfWeek.Saturday
                            title += "토요일"
                        Case DayOfWeek.Sunday
                            title += "일요일"
                    End Select

                    title += ")"

                    'NotifyIcon1.Visible = True
                    NotifyIcon1.ShowBalloonTip(9999, title, message, ToolTipIcon.None)
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "공통 메모란 설정"
    Private Sub DragSizePanel_MouseDown(sender As Object, e As MouseEventArgs) Handles DragSizePanel.MouseDown
        isSizeDragging = True
        SuspendTable(True)
    End Sub

    Private Sub DragSizePanel_MouseMove(sender As Object, e As MouseEventArgs) Handles DragSizePanel.MouseMove
        If isSizeDragging Then

            Select Case MemoPanel.Dock
                Case DockStyle.Top
                    If Height - (MousePosition.Y - DesktopBounds.Location.Y) > TopPanel.Height Then
                        MemoPanel.Height = MousePosition.Y - DesktopBounds.Location.Y
                        SetINI("SETTING", "MemoSize", MemoPanel.Height.ToString, ININamePath)
                    End If
                Case DockStyle.Bottom
                    If MousePosition.Y - DesktopBounds.Location.Y > TopPanel.Height Then
                        MemoPanel.Height = Height - MousePosition.Y + DesktopBounds.Location.Y
                        SetINI("SETTING", "MemoSize", MemoPanel.Height.ToString, ININamePath)
                    End If

                Case DockStyle.Left
                    If Width - (MousePosition.X - DesktopBounds.Location.X) > MinBT.Width Then
                        MemoPanel.Width = MousePosition.X - DesktopBounds.Location.X
                        SetINI("SETTING", "MemoSize", MemoPanel.Width.ToString, ININamePath)
                    End If

                Case DockStyle.Right
                    If MousePosition.X - DesktopBounds.Location.X > MinBT.Width Then
                        MemoPanel.Width = Width - MousePosition.X + DesktopBounds.Location.X
                        SetINI("SETTING", "MemoSize", MemoPanel.Width.ToString, ININamePath)
                    End If

            End Select

            DragSizePanel.Refresh()

        End If
    End Sub

    Private Sub DragSizePanel_MouseUp(sender As Object, e As MouseEventArgs) Handles DragSizePanel.MouseUp
        isSizeDragging = False
        SuspendTable(False)
    End Sub

    Public Sub MemoOptionUpdate()
        If GetINI("SETTING", "MemoShow", "", ININamePath) = "1" Then

            ' 기본값
            If GetINI("SETTING", "MemoSize", "", ININamePath) = "" Then _
                SetINI("SETTING", "MemoSize", (110 * currentDPI / 96).ToString, ININamePath)

            Dim memosize As Double = Convert.ToDouble(GetINI("SETTING", "MemoSize", "", ININamePath))
            Dim memodock As String = GetINI("SETTING", "MemoDock", "", ININamePath)

            Select Case memodock
                Case "Top", "Bottom"
                    If memosize > Height - TopPanel.Height Then
                        memosize = Height - TopPanel.Height
                    End If
                Case "Left", "Right"
                    If memosize > Width - MinBT.Width Then
                        memosize = Width - MinBT.Width
                    End If
            End Select

            Select Case memodock
                Case "Top"
                    MemoFormDockSelector(DockStyle.Top)
                    MemoPanel.Height = memosize
                Case "Bottom"
                    MemoFormDockSelector(DockStyle.Bottom)
                    MemoPanel.Height = memosize
                Case "Left"
                    MemoFormDockSelector(DockStyle.Left)
                    MemoPanel.Width = memosize
                Case "Right"
                    MemoFormDockSelector(DockStyle.Right)
                    MemoPanel.Width = memosize
                Case Else
                    ' 기본값
                    MemoFormDockSelector(DockStyle.Bottom)
                    SetINI("SETTING", "MemoDock", "Bottom", ININamePath)
            End Select

            MemoContentUpdate()
        Else
            MemoPanel.Hide()
        End If

        Refresh()
    End Sub

    Public Sub MemoContentUpdate()
        Try
            Dim content As String = IO.File.ReadAllText(INIPath + "\memo.rtf", System.Text.Encoding.GetEncoding(949))
            Dim zoomft As String = GetINI("SETTING", "MemoZoom", "", ININamePath)
            MemoRTB.Rtf = content

            If Not zoomft = "" Then
                MemoRTB.ZoomFactor = Convert.ToDouble(zoomft)
                UpdateMemoZoomFactor()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub MemoFormDockSelector(style As DockStyle)

        Dim thickness As Integer = 12 * currentDPI / 96

        Select Case style
            Case DockStyle.Top
                MemoPanel.Dock = DockStyle.Top
                DragSizePanel.Dock = DockStyle.Bottom
                DragSizePanel.Height = thickness

            Case DockStyle.Bottom
                MemoPanel.Dock = DockStyle.Bottom
                DragSizePanel.Dock = DockStyle.Top
                DragSizePanel.Height = thickness

            Case DockStyle.Left
                MemoPanel.Dock = DockStyle.Left
                DragSizePanel.Dock = DockStyle.Right
                DragSizePanel.Width = thickness

            Case DockStyle.Right
                MemoPanel.Dock = DockStyle.Right
                DragSizePanel.Dock = DockStyle.Left
                DragSizePanel.Width = thickness

        End Select

        MemoPanel.Show()
    End Sub

    Private Sub DragSizePanel_Paint(sender As Object, e As PaintEventArgs) Handles DragSizePanel.Paint
        Dim thinkness As Integer = currentDPI / 96
        Dim pen As Pen = New Pen(DragSizePanel.ForeColor, thinkness)
        Dim linelength As Integer = 50 * currentDPI / 96
        linelength -= linelength Mod thinkness

        Dim p1, p2, p3, p4 As Point

        Select Case MemoPanel.Dock
            Case DockStyle.Top, DockStyle.Bottom
                p1 = New Point((DragSizePanel.Width - linelength) / 2, DragSizePanel.Height * 0.33)
                p2 = New Point((DragSizePanel.Width + linelength) / 2, DragSizePanel.Height * 0.33)
                p3 = New Point((DragSizePanel.Width - linelength) / 2, DragSizePanel.Height * 0.66)
                p4 = New Point((DragSizePanel.Width + linelength) / 2, DragSizePanel.Height * 0.66)
            Case Else
                p1 = New Point(DragSizePanel.Width * 0.33, (DragSizePanel.Height - linelength) / 2)
                p2 = New Point(DragSizePanel.Width * 0.33, (DragSizePanel.Height + linelength) / 2)
                p3 = New Point(DragSizePanel.Width * 0.66, (DragSizePanel.Height - linelength) / 2)
                p4 = New Point(DragSizePanel.Width * 0.66, (DragSizePanel.Height + linelength) / 2)
        End Select

        e.Graphics.DrawLine(pen, p1, p2)
        e.Graphics.DrawLine(pen, p3, p4)
    End Sub

    Private Sub DragSizePanel_SizeChanged(sender As Object, e As EventArgs) Handles DragSizePanel.SizeChanged
        DragSizePanel.Refresh()
    End Sub

    Private Sub MemoCloseButtons_Click(sender As Object, e As EventArgs) Handles CloseMemoItem.Click, MemoCloseBT.Click
        SetINI("SETTING", "MemoShow", "0", ININamePath)
        MemoOptionUpdate()
    End Sub

    Private Sub Memo_menu_Opening(sender As Object, e As CancelEventArgs) Handles Memo_menu.Opening
        Memo_menu.BackColor = mainColor(colorMode)
        Memo_menu.ForeColor = textColor(colorMode)

        MemoDockTopItem.Text = "위쪽"
        MemoDockBottomItem.Text = "아래쪽"
        MemoDockLeftItem.Text = "왼쪽"
        MemoDockRightItem.Text = "오른쪽"

        Select Case GetINI("SETTING", "MemoDock", "", ININamePath)
            Case "Top"
                MemoDockTopItem.Text += " (현재)"
            Case "Bottom"
                MemoDockBottomItem.Text += " (현재)"
            Case "Left"
                MemoDockLeftItem.Text += " (현재)"
            Case "Right"
                MemoDockRightItem.Text += " (현재)"
        End Select
    End Sub

    Private Sub MemoDockTopItem_Click(sender As Object, e As EventArgs) Handles MemoDockTopItem.Click,
        MemoDockBottomItem.Click, MemoDockLeftItem.Click, MemoDockRightItem.Click

        Select Case sender.Name
            Case MemoDockTopItem.Name
                SetINI("SETTING", "MemoDock", "Top", ININamePath)

            Case MemoDockBottomItem.Name
                SetINI("SETTING", "MemoDock", "Bottom", ININamePath)

            Case MemoDockLeftItem.Name
                SetINI("SETTING", "MemoDock", "Left", ININamePath)

            Case MemoDockRightItem.Name
                SetINI("SETTING", "MemoDock", "Right", ININamePath)

        End Select

        MemoOptionUpdate()

    End Sub

    Private Sub UpdateMemoZoomFactor()
        SetINI("SETTING", "MemoZoom", MemoRTB.ZoomFactor.ToString, ININamePath)
        MemoZoomNumBT.Text = Convert.ToInt32((MemoRTB.ZoomFactor * 100)).ToString + "%"
        If MemoRTB.ZoomFactor = 1 Then
            MemoZoomNumBT.ForeColor = Color.Gray
        Else
            MemoZoomNumBT.ForeColor = Color.DodgerBlue
        End If
    End Sub

    Private Sub MemoMenuBT_Click(sender As Object, e As EventArgs) Handles MemoMenuBT.Click
        Memo_menu.Show(Cursor.Position.X, Cursor.Position.Y)
    End Sub

    Private Sub MemoRTB_TextChanged(sender As Object, e As EventArgs) Handles MemoRTB.TextChanged
        MemoAutoSave()
    End Sub

    Private Sub MemoRTB_KeyDown(sender As Object, e As KeyEventArgs) Handles MemoRTB.KeyDown, Me.KeyDown
        UpdateMemoZoomFactor()
    End Sub

    Private Sub MemoRTB_KeyUp(sender As Object, e As KeyEventArgs) Handles MemoRTB.KeyUp, Me.KeyUp
        UpdateMemoZoomFactor()
    End Sub

    Private Sub MemoZoomNumBT_Click(sender As Object, e As EventArgs) Handles MemoZoomNumBT.Click
        MemoRTB.ZoomFactor = 1
        UpdateMemoZoomFactor()
    End Sub

    Private Sub MemoZoomBT1_Click(sender As Object, e As EventArgs) Handles MemoZoomBT1.Click
        If MemoRTB.ZoomFactor > 0.015625 + 0.2 Then
            MemoRTB.ZoomFactor -= 0.2
            UpdateMemoZoomFactor()
        End If
    End Sub

    Private Sub MemoZoomBT2_Click(sender As Object, e As EventArgs) Handles MemoZoomBT2.Click
        MemoRTB.ZoomFactor += 0.2
        UpdateMemoZoomFactor()
    End Sub

    Private Sub MemoAutoSave()
        MemoSavingLabel.Text = "변경사항 저장중..."
        MemoSavingLabel.ForeColor = o_color
        MemoAutoSaveTimer.Stop()
        MemoAutoSaveTimer.Start()
    End Sub

    Private Sub MemoAutoSaveTimer_Tick(sender As Object, e As EventArgs) Handles MemoAutoSaveTimer.Tick
        MemoAutoSaveAniTimer.Start()
        MemoAutoSaveTimer.Stop()

        ' === 저장 작업 시작 ===
        If GetINI("SETTING", "MemoShow", "", ININamePath) = "1" Then
            Try
                IO.File.WriteAllText(INIPath + "\memo.rtf", MemoRTB.Rtf, System.Text.Encoding.GetEncoding(949))
            Catch ex As Exception
                MemoSavingLabel.Text = "저장 실패 (" + ex.Message + ")"
            End Try
        End If

    End Sub

    Private Sub MemoAutoSaveAniTimer_Tick(sender As Object, e As EventArgs) Handles MemoAutoSaveAniTimer.Tick
        If Perc < 1.5 - 0.1 Then
            Perc += 0.1

            If colorMode = "Dark" Then
                MemoSavingLabel.ForeColor = ControlPaint.Dark(o_color, Perc - 1)
            Else
                MemoSavingLabel.ForeColor = ControlPaint.Light(o_color, Perc)
            End If

        Else
            MemoAutoSaveAniTimer.Stop()
            'MemoSavingLabel.Hide()
            MemoSavingLabel.Text = ""
            Perc = 1
        End If
    End Sub

    Private Sub DragSizePanel_MouseEnter(sender As Object, e As EventArgs) Handles DragSizePanel.MouseEnter
        Select Case MemoPanel.Dock
            Case DockStyle.Top, DockStyle.Bottom
                Cursor = Cursors.HSplit
            Case Else
                Cursor = Cursors.VSplit
        End Select
    End Sub

    Private Sub DragSizePanel_MouseLeave(sender As Object, e As EventArgs) Handles DragSizePanel.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub MemoClearItem_Click(sender As Object, e As EventArgs) Handles MemoClearItem.Click
        If MsgBox("메모 내용을 지우시겠습니까?", vbQuestion + vbYesNo) = vbYes Then MemoRTB.Clear()
    End Sub

    Private Sub MemoRTBMenu_Opening(sender As Object, e As CancelEventArgs) Handles MemoRTBMenu.Opening
        MemoRTBMenu.BackColor = mainColor(colorMode)
        MemoRTBMenu.ForeColor = textColor(colorMode)

        MemoCopyItem.Visible = MemoRTB.SelectedText.Length > 0
        MemoPasteItem.Visible = (Clipboard.ContainsText(TextDataFormat.Rtf) Or Clipboard.ContainsText(TextDataFormat.Text))
        MemoUndoItem.Visible = MemoRTB.CanUndo
        MemoSelectAllItem.Visible = MemoRTB.TextLength > 0

    End Sub

    Private Sub MemoFontSetItem_Click(sender As Object, e As EventArgs) Handles MemoFontSetItem.Click
        FontDialog1.ShowColor = True

        FontDialog1.Font = MemoRTB.SelectionFont
        FontDialog1.Color = MemoRTB.SelectionColor

        If FontDialog1.ShowDialog() = DialogResult.OK Then
            MemoRTB.SelectionFont = FontDialog1.Font
            MemoRTB.SelectionColor = FontDialog1.Color
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemoCopyItem.Click
        MemoRTB.Copy()
    End Sub

    Private Sub MemoUndoItem_Click(sender As Object, e As EventArgs) Handles MemoUndoItem.Click
        MemoRTB.Undo()
    End Sub

    Private Sub MemoPasteItem_Click(sender As Object, e As EventArgs) Handles MemoPasteItem.Click
        MemoRTB.Paste()
    End Sub

    Private Sub MemoSelectAllItem_Click(sender As Object, e As EventArgs) Handles MemoSelectAllItem.Click
        MemoRTB.SelectAll()
    End Sub

    Private Sub TopPanel_Paint(sender As Object, e As PaintEventArgs) Handles TopPanel.Paint
        Dim edgeBrush = New SolidBrush(BackColor)
        Dim backBrush = New SolidBrush(TopPanel.BackColor)
        Dim g As Graphics = TopPanel.CreateGraphics
        Dim rndSize = Convert.ToInt16(Me.RndSize * (currentDPI / 96))
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.Clear(TopPanel.BackColor)

        '좌측
        g.FillRectangle(edgeBrush, 0, 0, rndSize, rndSize)
        g.FillEllipse(backBrush, 0, 0, rndSize * 2, rndSize * 2)

        '우측
        g.FillRectangle(edgeBrush, TopPanel.Width - rndSize, 0, rndSize, rndSize)
        g.FillEllipse(backBrush, TopPanel.Width - rndSize * 2, 0, rndSize * 2, rndSize * 2)
    End Sub

#End Region

End Class
