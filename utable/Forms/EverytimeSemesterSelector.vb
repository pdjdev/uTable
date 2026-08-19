Imports System.Runtime.InteropServices

Public Class EverytimeSemesterSelector
    Dim colorMode As String = Nothing
    Dim step_num As Integer = 1

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

    Private Sub MoveArea_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TitleLabel.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And Me.WindowState <> FormWindowState.Maximized Then
            MoveForm()
        End If
    End Sub

#End Region

    Private Sub FadeInEffect(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Refresh()
        FadeIn(Me, 1)
        TopMost = False
    End Sub

    Private Sub FadeOutEffect(sender As Object, e As EventArgs) Handles MyBase.Closing
        FadeOut(Me)
    End Sub

    Private Sub EverytimeSemesterSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AgreementRTB.Text = AgreementRTB.Text.Replace("[FileName]", TableSaveLocation(True))

        Step1Panel.Visible = True
        Step2Panel.Visible = False

        yearUpd.Value = Now.Year
        Opacity = 0
        UpdateColor()
    End Sub

    Private Sub CloseBT_MouseEnter(sender As Object, e As EventArgs) Handles CloseBT.MouseEnter
        CloseBT.BackColor = ThemeColors.FromMode(colorMode).ButtonHover
    End Sub

    Private Sub CloseBT_MouseLeave(sender As Object, e As EventArgs) Handles CloseBT.MouseLeave
        CloseBT.BackColor = Color.Transparent
    End Sub

    Private Sub CloseBT_Click(sender As Object, e As EventArgs) Handles CloseBT.Click
        Close()
    End Sub

    Public Sub UpdateColor()

        colorMode = GetINI("SETTING", "ColorMode", "", ININamePath)
        Dim theme As ThemeColors = ThemeColors.FromMode(colorMode)

        BackColor = theme.Edge
        Panel1.BackColor = theme.Background
        Panel1.ForeColor = theme.Text
        NextBT.ForeColor = theme.Text
        Label3.ForeColor = theme.Text
        Label4.ForeColor = theme.Text
        autoChk.ForeColor = theme.Text
        AgreementRTB.BackColor = theme.Background
        AgreementRTB.ForeColor = theme.Text
        tipLabel.ForeColor = theme.TextMuted

        NextBT.BackColor = theme.Button
        NextBT.FlatAppearance.BorderColor = theme.Border
        NextBT.FlatAppearance.MouseOverBackColor = theme.ButtonHover
        NextBT.FlatAppearance.MouseDownBackColor = theme.Border

        Select Case colorMode
            Case "Dark"
                CloseBT.Image = My.Resources.closeicon_w

                ' 옵션 컨트롤 내에 있는 모든 체크박스, 라디오버튼에 다크 모드 테마 적용
                For Each chk As CheckBox In GetAll(Me, GetType(CheckBox))
                    SetWindowTheme(chk.Handle, "DarkMode_Explorer", Nothing)
                Next

                For Each rdo As RadioButton In GetAll(Me, GetType(RadioButton))
                    SetWindowTheme(rdo.Handle, "DarkMode_Explorer", Nothing)
                Next

                SetWindowTheme(AgreementRTB.Handle, "DarkMode_Explorer", Nothing)
                AgreementRTB.BackColor = Color.FromArgb(30, 30, 30)

            Case Else
                CloseBT.Image = My.Resources.closeicon_b

                ' 옵션 컨트롤 내에 있는 모든 체크박스, 라디오버튼에 다크 모드 테마 적용
                For Each chk As CheckBox In GetAll(Me, GetType(CheckBox))
                    SetWindowTheme(chk.Handle, "Explorer", Nothing)
                Next

                For Each rdo As RadioButton In GetAll(Me, GetType(RadioButton))
                    SetWindowTheme(rdo.Handle, "Explorer", Nothing)
                Next

                SetWindowTheme(AgreementRTB.Handle, "Explorer", Nothing)
        End Select
    End Sub

    Private Sub autoChk_CheckedChanged(sender As Object, e As EventArgs) Handles autoChk.CheckedChanged
        semesterCombo.Enabled = Not autoChk.Checked
        yearUpd.Enabled = Not autoChk.Checked
    End Sub

    Private Sub NextBT_Click(sender As Object, e As EventArgs) Handles NextBT.Click
        Select Case step_num
            Case 1
                If semesterCombo.SelectedIndex = -1 And Not autoChk.Checked Then
                    MsgBox("학기를 선택해 주세요.", vbExclamation)
                    Exit Sub
                End If

                Height += dpicalc(Me, 100)
                SetDesktopLocation(Location.X, Location.Y - dpicalc(Me, 100) / 2)

                Step1Panel.Visible = False
                Step2Panel.Visible = True

                NextBT.Text = "로그인하기"

                step_num += 1
            Case 2
                Select Case semesterCombo.SelectedIndex
                    Case 0 '1학기
                        EveryTimeBrowserNew.targetUrl = "https://everytime.kr/timetable/" + yearUpd.Value.ToString + "/1"
                    Case 1 '여름학기
                        EveryTimeBrowserNew.targetUrl = "https://everytime.kr/timetable/" + yearUpd.Value.ToString + "/%EC%97%AC%EB%A6%84"
                    Case 2 '2학기
                        EveryTimeBrowserNew.targetUrl = "https://everytime.kr/timetable/" + yearUpd.Value.ToString + "/2"
                    Case 3 '겨울학기
                        EveryTimeBrowserNew.targetUrl = "https://everytime.kr/timetable/" + yearUpd.Value.ToString + "/%EA%B2%A8%EC%9A%B8"
                    Case Else
                        EveryTimeBrowserNew.targetUrl = "https://everytime.kr/timetable"
                End Select

                FadeOut(Me)
                Hide()
                Try
                    EveryTimeBrowserNew.ShowDialog(TableForm)
                Catch ex As Exception
                    If MsgBox("브라우저 실행 중 문제가 발생했습니다." + vbCr _
                              + "(" + ex.Message + ")" + vbCr + vbCr _
                              + "문제 해결 페이지로 이동하시겠습니까?", vbExclamation + vbYesNo) = vbYes Then
                        TopMost = False
                        Process.Start("https://utable.sw.pbj.kr/everytime-troubleshooting")
                        Close()
                    End If
                End Try

                Close()
        End Select
    End Sub
End Class
