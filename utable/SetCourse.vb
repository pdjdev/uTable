Imports System.Runtime.InteropServices

Public Class SetCourse
    Dim prevData As New List(Of String)
    Dim daysname As String() = {"월", "화", "수", "목", "금"}
    Dim listcount As Integer = 0
    Dim colormode As String = Nothing

    Public modifyMode As Boolean = False
    Public olddata As String = Nothing

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
    End Sub

    Private Sub FadeOutEffect(sender As Object, e As EventArgs) Handles MyBase.Closing
        FadeOut(Me)
    End Sub

    Public Sub UpdateColor()

        colorMode = GetINI("SETTING", "ColorMode", "", ININamePath)

        BackColor = edgeColor(colormode)
        Panel1.BackColor = mainColor(colormode)
        Panel1.ForeColor = textColor(colormode)

        ApplyBT.BackColor = buttonColor(colormode)
        ApplyBT.FlatAppearance.BorderColor = BorderColor(colormode)
        ApplyBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colormode)
        ApplyBT.FlatAppearance.MouseDownBackColor = BorderColor(colormode)
        DeleteBT.BackColor = buttonColor(colormode)
        DeleteBT.FlatAppearance.BorderColor = BorderColor(colormode)
        DeleteBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colormode)
        DeleteBT.FlatAppearance.MouseDownBackColor = BorderColor(colormode)
        ColorCopyBT.BackColor = buttonColor(colormode)
        ColorCopyBT.FlatAppearance.BorderColor = BorderColor(colormode)
        ColorCopyBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colormode)
        ColorCopyBT.FlatAppearance.MouseDownBackColor = BorderColor(colormode)
        ColorPasteBT.BackColor = buttonColor(colormode)
        ColorPasteBT.FlatAppearance.BorderColor = BorderColor(colormode)
        ColorPasteBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colormode)
        ColorPasteBT.FlatAppearance.MouseDownBackColor = BorderColor(colormode)

        Select Case colorMode
            Case "Dark"
                CloseBT.Image = My.Resources.closeicon_w
            Case Else
                CloseBT.Image = My.Resources.closeicon_b
        End Select

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ColorButton.Click
        ColorDialog1.Color = ColorButton.BackColor

        If ColorDialog1.ShowDialog() = DialogResult.OK Then

            ColorButton.BackColor = ColorDialog1.Color

        End If
    End Sub

    Sub GetCourses()
        PrevSetCombo.Items.Clear()

        Dim data As String = readTable()
        If data.Contains("<course>") Then
            prevData = getDatas(data, "course")

            For Each s As String In prevData
                Dim itemname As String = getData(s, "name") + " (" + daysname(Convert.ToInt16(getData(s, "day"))) + "요일)"
                PrevSetCombo.Items.Add(itemname)
            Next
        End If
    End Sub

    Sub SaveCourse(day As Integer, name As String, prof As String, memo As String, start As Integer, endt As Integer, color As Color)
        Dim oldData As String = readTable()
        Dim tablename As String = Nothing

        If Not oldData.Contains("<tablename>") Then
            tablename = "이름 없는 시간표"
        Else
            If getData(oldData, "tablename") = "" Then
                tablename = "이름 없는 시간표"
            Else
                tablename = getData(oldData, "tablename")
            End If
        End If

        Dim data As String = "<course>" + vbCrLf
        data += vbTab + "<day>" + day.ToString + "</day>" + vbCrLf
        data += vbTab + "<name>" + name + "</name>" + vbCrLf
        data += vbTab + "<prof>" + prof + "</prof>" + vbCrLf
        data += vbTab + "<memo>" + memo + "</memo>" + vbCrLf
        data += vbTab + "<start>" + start.ToString + "</start>" + vbCrLf
        data += vbTab + "<end>" + endt.ToString + "</end>" + vbCrLf
        data += vbTab + "<color>" + ColorTranslator.ToHtml(color) + "</color>" + vbCrLf
        data += "</course>" + vbCrLf
        data = "<tablename>" + tablename + "</tablename>" + vbCrLf + oldData + data

        writeTable(data)
    End Sub

    Sub modifyCourse(day As Integer, name As String, prof As String, memo As String, start As Integer, endt As Integer, color As Color)
        Dim data As String = readTable()
        Dim newdata As String = vbCrLf
        newdata += vbTab + "<day>" + day.ToString + "</day>" + vbCrLf
        newdata += vbTab + "<name>" + name + "</name>" + vbCrLf
        newdata += vbTab + "<prof>" + prof + "</prof>" + vbCrLf
        newdata += vbTab + "<memo>" + memo + "</memo>" + vbCrLf
        newdata += vbTab + "<start>" + start.ToString + "</start>" + vbCrLf
        newdata += vbTab + "<end>" + endt.ToString + "</end>" + vbCrLf
        newdata += vbTab + "<color>" + ColorTranslator.ToHtml(color) + "</color>" + vbCrLf

        writeTable(data.Replace(olddata, newdata))
    End Sub

    Private Sub SetCourse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opacity = 0

        GetCourses()
        UpdateColor()

        If modifyMode Then
            TitleLabel.Text = "수업 수정"
            PrevSetCombo.Enabled = False
            ApplyBT.Text = "수정"
            DeleteBT.Visible = True

            Dim data = olddata

            CourseNameTB.Text = getData(data, "name")
            ProfTB.Text = getData(data, "prof")
            DayCombo.SelectedIndex = Convert.ToInt16(getData(data, "day"))
            StartTimePicker.Value = New DateTime(2001, 1, 1, Convert.ToInt16(getData(data, "start")) \ 60, Convert.ToInt16(getData(data, "start")) Mod 60, 0)
            EndTimePicker.Value = New DateTime(2001, 1, 1, Convert.ToInt16(getData(data, "end")) \ 60, Convert.ToInt16(getData(data, "end")) Mod 60, 0)
            MemoTB.Text = getData(data, "memo")
            ColorButton.BackColor = ColorTranslator.FromHtml(getData(data, "color"))
        Else
            TitleLabel.Text = "수업 추가"
            StartTimePicker.Value = Now
            EndTimePicker.Value = Now
            DeleteBT.Visible = False
        End If

        Text = TitleLabel.Text
    End Sub

    Private Sub ApplyBT_Click(sender As Object, e As EventArgs) Handles ApplyBT.Click
        If CourseNameTB.Text = Nothing Then
            MsgBox("수업명을 입력하세요.", vbExclamation)
            Exit Sub
        End If

        If ProfTB.Text = Nothing Then
            MsgBox("교수명을 입력하세요.", vbExclamation)
            Exit Sub
        End If

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

        For Each s As String In prevData

            If getData(s, "day") = DayCombo.SelectedIndex Then
                'MsgBox("인덱스 같음")
                Dim itemname As String = getData(s, "name") + " (" + daysname(Convert.ToInt16(getData(s, "day"))) + "요일)"

                If Not ((startt <= Convert.ToInt16(getData(s, "start")) And endt <= Convert.ToInt16(getData(s, "start"))) _
                    Or (startt >= Convert.ToInt16(getData(s, "end")) And endt >= Convert.ToInt16(getData(s, "end")))) Then

                    '수정 모드 아닐때
                    If Not modifyMode Then
                        MsgBox("다른 수업 (" + itemname + ")과 현재 설정한 수업의 시간이 겹칩니다.", vbExclamation)
                        Exit Sub

                        '수정일때 겹치는경우
                    Else
                        '근데 겹치는게 원래 고치려했던놈이 아닐때
                        If Not getData(s, "name") = getData(olddata, "name") Then
                            MsgBox("다른 수업 (" + itemname + ")과 현재 설정한 수업의 시간이 겹칩니다.", vbExclamation)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Next

        TopMost = False

        If Not modifyMode Then
            SaveCourse(DayCombo.SelectedIndex, CourseNameTB.Text, ProfTB.Text, MemoTB.Text, startt, endt, ColorButton.BackColor)
            Form1.updateCell()
            'MsgBox("추가되었습니다.", vbInformation)
        Else
            modifyCourse(DayCombo.SelectedIndex, CourseNameTB.Text, ProfTB.Text, MemoTB.Text, startt, endt, ColorButton.BackColor)
            Form1.updateCell()
            'MsgBox("수정되었습니다.", vbInformation)
            Close()

        End If

        TopMost = True
        GetCourses()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        MsgBox(DayCombo.SelectedIndex)
    End Sub

    Private Sub PrevSetCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PrevSetCombo.SelectedIndexChanged
        If Not PrevSetCombo.SelectedIndex = -1 Then
            If MsgBox("해당 수업의 값을 불러오시겠습니까?", vbQuestion + vbYesNo) = vbYes Then
                Dim data = prevData(PrevSetCombo.SelectedIndex)

                CourseNameTB.Text = getData(data, "name")
                ProfTB.Text = getData(data, "prof")
                DayCombo.SelectedIndex = Convert.ToInt16(getData(data, "day"))
                StartTimePicker.Value = New DateTime(2001, 1, 1, Convert.ToInt16(getData(data, "start")) \ 60, Convert.ToInt16(getData(data, "start")) Mod 60, 0)
                EndTimePicker.Value = New DateTime(2001, 1, 1, Convert.ToInt16(getData(data, "end")) \ 60, Convert.ToInt16(getData(data, "end")) Mod 60, 0)
                MemoTB.Text = getData(data, "memo")
                ColorButton.BackColor = ColorTranslator.FromHtml(getData(data, "color"))
            End If
            PrevSetCombo.SelectedIndex = -1
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub DeleteBT_Click(sender As Object, e As EventArgs) Handles DeleteBT.Click
        If MsgBox("정말로 지우시겠습니까?", vbQuestion + vbYesNo) = vbYes Then
            writeTable(readTable().Replace("<course>" + olddata + "</course>", Nothing))
            Form1.updateCell()
            Close()
        End If

    End Sub

    Private Sub CloseBT_MouseEnter(sender As Object, e As EventArgs) Handles CloseBT.MouseEnter
        CloseBT.BackColor = buttonActiveColor(colormode)
    End Sub

    Private Sub CloseBT_MouseLeave(sender As Object, e As EventArgs) Handles CloseBT.MouseLeave
        CloseBT.BackColor = Color.Transparent
    End Sub

    Private Sub CloseBT_Click(sender As Object, e As EventArgs) Handles CloseBT.Click
        Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles ColorCopyBT.Click
        Clipboard.SetText(ColorTranslator.ToHtml(ColorButton.BackColor))
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles ColorPasteBT.Click
        Try
            ColorButton.BackColor = ColorTranslator.FromHtml(Clipboard.GetText)
        Catch ex As Exception
            MsgBox("색상을 복사하지 않았거나 올바르지 않은 값을 복사하였습니다.", vbExclamation)
        End Try

    End Sub
End Class