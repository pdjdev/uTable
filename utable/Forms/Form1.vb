Imports System.Runtime.InteropServices

Public Class Form1
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
    Dim formshown As Boolean = False
    Dim snaptoedge As Boolean = False
    Dim titleEditMode As Boolean = False
    Dim colorMode As String = Nothing
    Public BorderWidth As Integer = dpicalc(Me, 6)
    Private _resizeDir As ResizeDirection = ResizeDirection.None

    'CellControl용 설정 변수
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
            TimeTable.Visible = True
            SizeLabel.Hide()
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
                TimeTable.Visible = False
                SizeLabel.Show()
                SizeLabel.Text = "드래그하여 크기를 조절하세요"

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

#End Region

    Public Sub UpdateColor()

        colorMode = GetINI("SETTING", "ColorMode", "", ININamePath)

        BackColor = edgeColor(colorMode)

        TopPanel.BackColor = mainColor(colorMode)
        Panel7.BackColor = mainColor(colorMode)

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

        Select Case colorMode
            Case "Dark"
                MinBT.Image = My.Resources.minicon_w
                Menu_1_1.Checked = False
                Menu_1_2.Checked = True
            Case Else
                MinBT.Image = My.Resources.minicon_b
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

                'BT1_menu 폰트 바꾸기 : 속성이 상속되지 않는지라 노가다해야함
                If GetINI("SETTING", "ApplyAllGUIFonts", "", ININamePath) = "1" Then
                    ClearCheckBoxItem.Font = New Font(fntname, ClearCheckBoxItem.Font.Size)
                    BT1MenuTitle.Font = New Font(fntname, BT1MenuTitle.Font.Size)
                    ChangeThemeItem.Font = New Font(fntname, ChangeThemeItem.Font.Size)
                    SnapToEdgeItem.Font = New Font(fntname, SnapToEdgeItem.Font.Size)
                    ColorSettingItem.Font = New Font(fntname, ColorSettingItem.Font.Size)
                    OpacitySelectItem.Font = New Font(fntname, OpacitySelectItem.Font.Size)
                    GetFromETItem.Font = New Font(fntname, GetFromETItem.Font.Size)
                    OptionItem.Font = New Font(fntname, OptionItem.Font.Size)
                    ExitItem.Font = New Font(fntname, ExitItem.Font.Size)
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

        snaptoedge = (GetINI("SETTING", "SnapToEdge", "", ININamePath) = "1")
        tablePatternSetting = GetINI("SETTING", "TablePattern", "", ININamePath)

        updateCell()
    End Sub

    Public Sub updateCell()

        'CellControl 설정 변수 업데이트
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

        Dim data As String = readTable()
        Dim min As Integer = 9999999
        Dim max As Integer = 0

        If data.Contains("<tablename>") Then
            TableTitleLabel.Text = getData(data, "tablename")
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

            '셀계산
            For Each s As String In courseData
                addCell(Convert.ToInt16(getData(s, "start")),
                        Convert.ToInt16(getData(s, "end")),
                        getData(s, "day") + "-" + getData(s, "start") + "-" + getData(s, "name"),
                        getData(s, "name"),
                        getData(s, "prof"),
                        getData(s, "memo"),
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
                DayTable.ColumnStyles(i).Width = 14.28
                TimeTable.ColumnStyles(i).Width = 14.28
            Next
        ElseIf showSaturday Then '토요일 표시
            For i = 0 To 5
                DayTable.ColumnStyles(i).Width = 16.67
                TimeTable.ColumnStyles(i).Width = 16.67
            Next
            DayTable.ColumnStyles(6).Width = 0
            TimeTable.ColumnStyles(6).Width = 0
        Else '둘다 안표시
            For i = 0 To 4
                DayTable.ColumnStyles(i).Width = 20
                TimeTable.ColumnStyles(i).Width = 20
            Next
            DayTable.ColumnStyles(5).Width = 0
            DayTable.ColumnStyles(6).Width = 0
            TimeTable.ColumnStyles(5).Width = 0
            TimeTable.ColumnStyles(6).Width = 0
        End If

        For Each s As String In courseData
            resizeCell(Convert.ToInt16(getData(s, "start")), Convert.ToInt16(getData(s, "end")),
                       getData(s, "day") + "-" + getData(s, "start") + "-" + getData(s, "name"))
        Next

        TimeTable.Visible = True
    End Sub

    Sub addCell(startt As Integer, endt As Integer, name As String, title As String, prof As String, memo As String, color As Color, day As Integer, checked As String)

        Dim timelength As Integer = endtime - starttime
        Dim part As Double = (endt - startt) / timelength
        Dim cell As New CellControl

        cell.ForeColor = Color.White
        cell.BackColor = color

        With cell
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

    Private Sub AddCourseBT_Click(sender As Object, e As EventArgs) Handles AddCourseBT.Click
        SetCourse.Close()
        SetCourse.SetDesktopLocation(Location.X + AddCourseBT.Location.X + AddCourseBT.Width - SetCourse.Width, Location.Y + DayTable.Location.Y)
        SetCourse.Show()
    End Sub

    Private Sub RefreshBT_Click(sender As Object, e As EventArgs) Handles RefreshBT.Click
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
            Opacity = 1
        Else
            If IsNumeric(GetINI("SETTING", "Opacity", "", ININamePath)) Then
                FadeIn(Me, Convert.ToDouble(GetINI("SETTING", "Opacity", "", ININamePath)))
            Else
                FadeIn(Me, 1)
            End If
        End If

        If Not checkStartUp() Then
            If Not GetINI("SETTING", "NoStartupSuggestion", "0", ININamePath) = 1 Then
                WindowState = FormWindowState.Normal
                StartupAsk.ShowDialog(Me)
            End If
        End If

        If Not updated Then
            MsgBox("설정값을 읽어올 수 없습니다." + vbCr + "(시간표를 설정해 주세요)" _
                   + vbCr + vbCr + "tip: 우측 상단의 메뉴(...) 버튼 > '에타에서 불러오기' 를 통해 에브리타임 시간표를 바로 불러올 수 있습니다.", vbInformation)
        End If
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
                        data = data.Replace("<tablename>" + oldtitle + "</tablename>", "<tablename>" + newtitle + "</tablename>")
                        writeTable(data)
                    Else
                        writeTable("<tablename>" + newtitle + "</tablename>" + vbCrLf + data)
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
        BT1_menu.ForeColor = textColor(colorMode)
        BT1MenuTitle.ForeColor = lightTextColor(colorMode)

        snaptoedge = (GetINI("SETTING", "SnapToEdge", "", ININamePath) = "1")
        ClearCheckBoxItem.Visible = Not (GetINI("SETTING", "ShowChkBox", "", ININamePath) = "0")

        If snaptoedge Then
            SnapToEdgeItem.Text = "창에 붙지 않기"
        Else
            SnapToEdgeItem.Text = "창에 붙기"
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

    Private Sub TimeCheck_Tick(sender As Object, e As EventArgs) Handles TimeCheck.Tick
        updateDateDraw()
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
    End Sub

    Private Sub Menu_4_Click(sender As Object, e As EventArgs) Handles GetFromETItem.Click
        EveryTimeBrowser.Close()
        EverytimeSemesterSelector.Close()
        EverytimeSemesterSelector.ShowDialog(Me)

    End Sub

    Private Sub Menu_5_Click(sender As Object, e As EventArgs) Handles OptionItem.Click
        OptionForm.Close()
        OptionForm.SetDesktopLocation(Location.X + Width - OptionForm.Width, Location.Y + TopPanel.Location.Y + TopPanel.Height)
        OptionForm.ShowDialog(Me)
    End Sub

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

    Private Sub hideani_Tick(sender As Object, e As EventArgs) Handles hideani.Tick
        If poscount >= 15 Then
            Me.Opacity = 0
            poscount = 0
            hideani.Stop()
            Me.SetDesktopLocation(prevloc.X, prevloc.Y)
            WindowState = FormWindowState.Minimized
            Me.Opacity = tmp_opa
            hiding = False
        Else
            Me.SetDesktopLocation(Location.X, Location.Y + dpicalc(Me, poscount))
            poscount += 1
            Opacity -= tmp_opa / 15
        End If
    End Sub

    Private Sub ExitItem_Click(sender As Object, e As EventArgs) Handles ExitItem.Click
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
        Dim hrlength As Double = 60 / timeLength * panelHeight

        Dim left As Integer = starttime Mod 60
        Dim thickness As Integer = 3 * (currentDPI / 96)

        Dim colorMul As Single = 0.9
        If colorMode = "Dark" Then
            colorMul = 1.35
        End If

        Dim c As Color = Color.FromArgb(panel.BackColor.R * colorMul,
                                        panel.BackColor.G * colorMul,
                                        panel.BackColor.B * colorMul)

        If Not tablePatternSetting = "None" Then

            Dim p As New Pen(c, thickness)
            Dim g As Graphics = Panel.CreateGraphics
            p.DashStyle = Drawing2D.DashStyle.Dot

            For j As Integer = starttime To endtime
                If j > 0 And j Mod 60 = 0 Then
                    Dim y As Integer = ((endtime - j + left) / timeLength) * panelHeight + thickness / 2

                    g.DrawLine(p, New Point(0, y), New Point(panelWidth, y))
                End If
            Next

            g.Dispose()
            p.Dispose()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ViewCourse.Show()
    End Sub
End Class
