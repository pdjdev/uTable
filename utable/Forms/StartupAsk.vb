Imports System.Runtime.InteropServices

Public Class StartupAsk
    Dim colorMode As String = Nothing

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
    End Sub

    Private Sub FadeOutEffect(sender As Object, e As EventArgs) Handles MyBase.Closing
        FadeOut(Me)
    End Sub

    Private Sub StartupAsk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opacity = 0
        UpdateColor()
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

    Public Sub UpdateColor()

        colorMode = GetINI("SETTING", "ColorMode", "", ININamePath)

        BackColor = edgeColor(colorMode)
        Panel1.BackColor = mainColor(colorMode)
        Panel1.ForeColor = textColor(colorMode)
        ApplyBT.ForeColor = textColor(colorMode)
        NoBT.ForeColor = textColor(colorMode)
        TxtLabel.ForeColor = textColor(colorMode)
        Label1.ForeColor = lightTextColor(colorMode)

        ApplyBT.BackColor = buttonColor(colorMode)
        ApplyBT.FlatAppearance.BorderColor = BorderColor(colorMode)
        ApplyBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colorMode)
        ApplyBT.FlatAppearance.MouseDownBackColor = BorderColor(colorMode)

        NoBT.BackColor = buttonColor(colorMode)
        NoBT.FlatAppearance.BorderColor = BorderColor(colorMode)
        NoBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colorMode)
        NoBT.FlatAppearance.MouseDownBackColor = BorderColor(colorMode)

        Select Case colorMode
            Case "Dark"
                CloseBT.Image = My.Resources.closeicon_w
            Case Else
                CloseBT.Image = My.Resources.closeicon_b
        End Select
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            SetINI("SETTING", "NoStartupSuggestion", "1", ININamePath)
        Else
            SetINI("SETTING", "NoStartupSuggestion", "0", ININamePath)
        End If
    End Sub

    Private Sub ApplyBT_Click(sender As Object, e As EventArgs) Handles ApplyBT.Click
        Try
            SetStartup()
        Catch ex As Exception
            MsgBox("시작프로그램 설정 도중 오류가 발생했습니다. 실행 권한을 확인해 보시기 바랍니다.", vbCritical)
        End Try

        Close()
    End Sub

    Private Sub NoBT_Click(sender As Object, e As EventArgs) Handles NoBT.Click
        Close()
    End Sub
End Class