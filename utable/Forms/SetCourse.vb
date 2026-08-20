Imports System.Runtime.InteropServices

Public Class SetCourse
    Dim prevCourses As New List(Of TableCourse)
    Dim daysname As String() = {"월", "화", "수", "목", "금", "토", "일"}
    Dim listcount As Integer = 0
    Dim colormode As String = Nothing

    Public modifyMode As Boolean = False
    Friend currentCourse As TableCourse = Nothing

    Public touched As Boolean = False
    Dim loaded As Boolean = False

#Region "Aero 그림자 효과 (Vista이상)"

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        CreateDropShadow(Me)
        MyBase.OnHandleCreated(e)
    End Sub

#End Region

#Region "창 이동, 크기 조절, 붙기 관련"

    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2

    Private Sub MoveForm()
        ReleaseCapture()
        SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
    End Sub

    Private Sub MoveArea_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And Me.WindowState <> FormWindowState.Maximized Then
            MoveForm()
        End If
    End Sub

#End Region

    Private Sub FadeInEffect(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Refresh()
        FadeIn(Me, 1)

        loaded = True
    End Sub

    Private Sub FadeOutEffect(sender As Object, e As EventArgs) Handles MyBase.Closing
        FadeOut(Me)
    End Sub

    Public Sub UpdateColor()

        colormode = GetINI("SETTING", "ColorMode", "", ININamePath)
        Dim theme As ThemeColors = ThemeColors.FromMode(colormode)

        BackColor = theme.Edge
        Panel1.BackColor = theme.Background
        Panel1.ForeColor = theme.Text

        ApplyButtonTheme(theme, ApplyBT, DeleteBT, ColorCopyBT, ColorPasteBT)

        Select Case colormode
            Case "Dark"
                CloseBT.Image = My.Resources.closeicon_w
            Case Else
                CloseBT.Image = My.Resources.closeicon_b
        End Select

    End Sub

    Private Sub ApplyButtonTheme(theme As ThemeColors, ParamArray buttons() As Button)
        For Each button As Button In buttons
            button.BackColor = theme.Button
            button.FlatAppearance.BorderColor = theme.Border
            button.FlatAppearance.MouseOverBackColor = theme.ButtonHover
            button.FlatAppearance.MouseDownBackColor = theme.Border
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ColorButton.Click
        ColorDialog1.Color = ColorButton.BackColor

        If ColorDialog1.ShowDialog() = DialogResult.OK Then

            touched = True
            ColorButton.BackColor = ColorDialog1.Color

        End If
    End Sub

    Sub GetCourses()
        PrevSetCombo.Items.Clear()
        prevCourses = LoadSchedule().Courses

        For Each course As TableCourse In prevCourses
            PrevSetCombo.Items.Add(course.Name + " (" + daysname(course.Day) + "요일)")
        Next
    End Sub

    Private Sub FillInputs(course As TableCourse)
        CourseNameTB.Text = course.Name
        ProfTB.Text = course.Professor
        DayCombo.SelectedIndex = course.Day
        StartTimePicker.Value = New DateTime(2001, 1, 1, course.Start \ 60, course.Start Mod 60, 0)
        EndTimePicker.Value = New DateTime(2001, 1, 1, course.End \ 60, course.End Mod 60, 0)
        MemoTB.Text = course.Memo
        ColorButton.BackColor = ColorTranslator.FromHtml(course.Color)
    End Sub

    Private Sub UpdateCourse(course As TableCourse, day As Integer, name As String, professor As String,
                             memo As String, startMinutes As Integer, endMinutes As Integer, color As Color)
        course.Day = day
        course.Name = name
        course.Professor = professor
        course.Memo = memo
        course.Start = startMinutes
        course.End = endMinutes
        course.Color = ColorTranslator.ToHtml(color)
    End Sub

    Private Sub SetCourse_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Opacity = 0

        If GetINI("SETTING", "CustomFont", "", ININamePath) = "1" And GetINI("SETTING", "ApplyAllGUIFonts", "", ININamePath) = "1" Then
            If Not GetINI("SETTING", "CustomFontName", "", ININamePath) = "" Then
                Dim fntname = GetINI("SETTING", "CustomFontName", "", ININamePath)
                ChangeToCustomFont(Me, fntname)
            End If
        End If

        GetCourses()
        UpdateColor()

        If modifyMode Then
            TitleLabel.Text = "수업 수정"
            PrevSetCombo.Enabled = False
            ApplyBT.Text = "수정"
            DeleteBT.Visible = True

            Try
                If currentCourse Is Nothing Then Throw New InvalidOperationException("수정할 수업 정보가 없습니다.")
                FillInputs(currentCourse)

            Catch ex As Exception
                MsgBox("수업을 불러오는 도중 문제가 발생하였습니다." + vbCr + "해당 수업의 값이 올바른지 확인하고 삭제 후 다시 추가해 주세요.", vbCritical)

            End Try


        Else
            TitleLabel.Text = "수업 추가"
            StartTimePicker.Value = Now
            EndTimePicker.Value = Now
            DeleteBT.Visible = False
        End If

        Text = TitleLabel.Text
    End Sub

    Private Sub ApplyBT_Click(sender As Object, e As EventArgs) Handles ApplyBT.Click
        Apply()
    End Sub

    Private Sub Apply()
        If CourseNameTB.Text = Nothing Then
            MsgBox("수업명을 입력하세요.", vbExclamation)
            Exit Sub
        End If

        'If ProfTB.Text = Nothing Then
        '    MsgBox("교수명을 입력하세요.", vbExclamation)
        '    Exit Sub
        'End If

        If DayCombo.Text = Nothing Then
            MsgBox("요일을 선택하세요.", vbExclamation)
            Exit Sub
        End If

        Dim startt As Integer = StartTimePicker.Value.Hour * 60 + StartTimePicker.Value.Minute
        Dim endt As Integer = EndTimePicker.Value.Hour * 60 + EndTimePicker.Value.Minute

        If startt > endt Then
            MsgBox("수업 시작 시간은 종료 시간보다 빨라야 합니다.", vbExclamation)
            Exit Sub
        End If

        If endt - startt < 10 Then
            MsgBox("수업 시간은 10분보다 길어야 합니다.", vbExclamation)
            Exit Sub
        End If

        For Each course As TableCourse In prevCourses
            If course.Day <> DayCombo.SelectedIndex Then Continue For
            If modifyMode AndAlso currentCourse IsNot Nothing AndAlso
                course.SourceIndex = currentCourse.SourceIndex AndAlso course.HasSameData(currentCourse) Then Continue For

            If startt < course.End AndAlso endt > course.Start Then
                Dim itemname As String = course.Name + " (" + daysname(course.Day) + "요일)"
                MsgBox("다른 수업 (" + itemname + ")과 현재 설정한 수업의 시간이 겹칩니다.", vbExclamation)
                Exit Sub
            End If
        Next

        TopMost = False
        Dim schedule As TableSchedule = LoadSchedule()
        If String.IsNullOrEmpty(schedule.Name) Then schedule.Name = "이름 없는 시간표"

        If modifyMode Then
            Dim target As TableCourse = FindCourse(schedule, currentCourse)
            If target Is Nothing Then
                MsgBox("수정할 수업을 현재 시간표에서 찾지 못했습니다. 시간표를 새로고침한 후 다시 시도해 주세요.", vbExclamation)
                Exit Sub
            End If

            Dim oldName As String = currentCourse.Name
            Dim updateAll As Boolean = schedule.Courses.Where(Function(course) course.Name = oldName).Count() > 1 AndAlso
                MsgBox("같은 이름의 수업이 둘 이상 있습니다." + vbCr + "해당 수업 또한 모두 바꾸시겠습니까? (시간, 요일 제외)", vbQuestion + vbYesNo) = vbYes

            UpdateCourse(target, DayCombo.SelectedIndex, CourseNameTB.Text, ProfTB.Text, MemoTB.Text, startt, endt, ColorButton.BackColor)
            If updateAll Then
                For Each course As TableCourse In schedule.Courses.Where(Function(item) item.Name = oldName AndAlso item IsNot target)
                    course.Name = CourseNameTB.Text
                    course.Professor = ProfTB.Text
                    course.Memo = MemoTB.Text
                    course.Color = ColorTranslator.ToHtml(ColorButton.BackColor)
                Next
            End If
        Else
            Dim course As New TableCourse()
            UpdateCourse(course, DayCombo.SelectedIndex, CourseNameTB.Text, ProfTB.Text, MemoTB.Text, startt, endt, ColorButton.BackColor)
            schedule.Courses.Add(course)
        End If

        SaveSchedule(schedule)
        TableForm.updateCell()
        If modifyMode Then Close()

        TopMost = True
        GetCourses()
        touched = False
    End Sub

    Private Sub PrevSetCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PrevSetCombo.SelectedIndexChanged
        If Not PrevSetCombo.SelectedIndex = -1 Then

            If touched Then
                If MsgBox("기존의 값은 지워집니다. 계속하시겠습니까?", vbQuestion + vbYesNo) = vbNo Then Exit Sub
            End If

            loaded = False
            FillInputs(prevCourses(PrevSetCombo.SelectedIndex))

            loaded = True
            touched = False
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub DeleteBT_Click(sender As Object, e As EventArgs) Handles DeleteBT.Click
        If MsgBox("정말로 지우시겠습니까?", vbQuestion + vbYesNo) = vbYes Then
            Dim schedule As TableSchedule = LoadSchedule()
            Dim target As TableCourse = FindCourse(schedule, currentCourse)
            If target Is Nothing Then
                MsgBox("삭제할 수업을 현재 시간표에서 찾지 못했습니다. 시간표를 새로고침한 후 다시 시도해 주세요.", vbExclamation)
                Exit Sub
            End If

            schedule.Courses.Remove(target)
            SaveSchedule(schedule)
            TableForm.updateCell()
            Close()
        End If

    End Sub

    Private Sub CloseBT_MouseEnter(sender As Object, e As EventArgs) Handles CloseBT.MouseEnter
        CloseBT.BackColor = ThemeColors.FromMode(colormode).ButtonHover
    End Sub

    Private Sub CloseBT_MouseLeave(sender As Object, e As EventArgs) Handles CloseBT.MouseLeave
        CloseBT.BackColor = Color.Transparent
    End Sub

    Private Sub CloseBT_Click(sender As Object, e As EventArgs) Handles CloseBT.Click
        If touched Then
            If modifyMode Then
                Dim ask1 As MsgBoxResult = MsgBox("변경사항을 저장하시겠습니까?", vbYesNoCancel + vbQuestion)

                If ask1 = vbYes Then
                    Apply()
                ElseIf ask1 = vbCancel Then
                    Exit Sub
                End If
            Else
                If MsgBox("저장하지 않은 값은 지워집니다. 계속하시겠습니까?", vbQuestion + vbYesNo) = vbNo Then Exit Sub
            End If
        End If

        Close()
    End Sub

    Private Sub ColorCopyBT_Click(sender As Object, e As EventArgs) Handles ColorCopyBT.Click
        Clipboard.SetText(ColorTranslator.ToHtml(ColorButton.BackColor))
    End Sub

    Private Sub ColorPasteBT_Click(sender As Object, e As EventArgs) Handles ColorPasteBT.Click
        Try
            ColorButton.BackColor = ColorTranslator.FromHtml(Clipboard.GetText)
            touched = True
        Catch ex As Exception
            MsgBox("색상을 복사하지 않았거나 올바르지 않은 값을 복사하였습니다.", vbExclamation)
        End Try

    End Sub

    Private Sub TouchedEvents(sender As Object, e As EventArgs) Handles CourseNameTB.TextChanged, ProfTB.TextChanged,
        DayCombo.TextChanged, StartTimePicker.ValueChanged, EndTimePicker.ValueChanged, MemoTB.TextChanged

        If loaded Then
            touched = True
            If Not PrevSetCombo.SelectedIndex = -1 Then PrevSetCombo.SelectedIndex = -1
        End If

    End Sub
End Class
