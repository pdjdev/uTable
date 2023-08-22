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
        CloseBT.BackColor = buttonActiveColor(colorMode)
    End Sub

    Private Sub CloseBT_MouseLeave(sender As Object, e As EventArgs) Handles CloseBT.MouseLeave
        CloseBT.BackColor = Color.Transparent
    End Sub

    Private Sub CloseBT_Click(sender As Object, e As EventArgs) Handles CloseBT.Click
        Close()
    End Sub

    Public Sub UpdateColor()

        colorMode = GetINI("SETTING", "ColorMode", "", ININamePath)

        BackColor = edgeColor(colorMode)
        Panel1.BackColor = mainColor(colorMode)
        Panel1.ForeColor = textColor(colorMode)
        NextBT.ForeColor = textColor(colorMode)
        Label3.ForeColor = textColor(colorMode)
        Label4.ForeColor = textColor(colorMode)
        autoChk.ForeColor = textColor(colorMode)
        AgreementRTB.BackColor = mainColor(colorMode)
        AgreementRTB.ForeColor = textColor(colorMode)
        tipLabel.ForeColor = lightTextColor(colorMode)

        NextBT.BackColor = buttonColor(colorMode)
        NextBT.FlatAppearance.BorderColor = BorderColor(colorMode)
        NextBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colorMode)
        NextBT.FlatAppearance.MouseDownBackColor = BorderColor(colorMode)

        Select Case colorMode
            Case "Dark"
                CloseBT.Image = My.Resources.closeicon_w
            Case Else
                CloseBT.Image = My.Resources.closeicon_b
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
                EveryTimeBrowserNew.ShowDialog(Form1)
                Close()
        End Select
    End Sub
End Class