﻿Imports System.Runtime.InteropServices

Public Class OptionForm
    Dim colormode As String = Nothing
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

    Private Sub MoveArea_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseDown
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

    Private Sub OptionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Opacity = 0
        UpdateColor()
        ModeSelect(1)

        '설정 체크
        StartupChk.Checked = checkStartUp()

        '최소화설정 기본값 = 0
        MinStartChk.Checked = (GetINI("SETTING", "MinStart", "", ININamePath) = "1")

        '모서리 달라붙기 기본값 = 1
        If GetINI("SETTING", "SnapToEdge", "", ININamePath) = "0" Then
            SnapToEdgeChk.Checked = False
        Else
            SnapToEdgeChk.Checked = True
        End If

        '페이드 효과 기본값 = 1
        If GetINI("SETTING", "FadeEffect", "", ININamePath) = "0" Then
            FadeEffectChk.Checked = False
        Else
            FadeEffectChk.Checked = True
        End If

        '표확장 기본값 = 1
        If GetINI("SETTING", "ExpandCell", "", ININamePath) = "0" Then
            ExpandCellChk.Checked = False
        Else
            ExpandCellChk.Checked = True
        End If

        '항상확장 기본값 = 0
        AlwaysExpandChk.Checked = (GetINI("SETTING", "AlwaysExpand", "", ININamePath) = "1")

        '요일표시 기본값 = 1
        If GetINI("SETTING", "ShowDay", "", ININamePath) = "0" Then
            ShowDayChk.Checked = False
        Else
            ShowDayChk.Checked = True
        End If

        '교수명표시 기본값 = 1
        If GetINI("SETTING", "ShowProf", "", ININamePath) = "0" Then
            ShowProfChk.Checked = False
        Else
            ShowProfChk.Checked = True
        End If

        '메모표시 기본값 = 1
        If GetINI("SETTING", "ShowMemo", "", ININamePath) = "0" Then
            ShowMemoChk.Checked = False
        Else
            ShowMemoChk.Checked = True
        End If

        '텍스트색상반전 기본값 = 0
        BlackTextChk.Checked = (GetINI("SETTING", "BlackText", "", ININamePath) = "1")

        '커스텀폰트 기본값 = 0
        CustomFontChk.Checked = (GetINI("SETTING", "CustomFont", "", ININamePath) = "1")
        CustomFontBT.Enabled = CustomFontChk.Checked

        Select Case GetINI("SETTING", "ColorMode", "", ININamePath)
            Case "Dark"
                D_ThemeRbt.Checked = True
            Case Else
                W_ThemeRbt.Checked = True
        End Select

        If Not GetINI("SETTING", "CustomFontName", "", ININamePath) = "" Then
            Dim fntname = GetINI("SETTING", "CustomFontName", "", ININamePath)
            FontPrevLabel.Font = New Font(fntname, FontPrevLabel.Font.Size)
            CustomFontBT.Text = fntname
        End If

        loaded = True
    End Sub

    Public Sub UpdateColor()

        colorMode = GetINI("SETTING", "ColorMode", "", ININamePath)

        BackColor = edgeColor(colormode)
        Panel2.BackColor = mainColor(colormode)
        Panel2.ForeColor = textColor(colormode)
        TabBT1.BackColor = mainColor(colormode)
        TabBT2.BackColor = mainColor(colormode)
        TabBT3.BackColor = mainColor(colormode)
        RichTextBox1.BackColor = mainColor(colormode)
        RichTextBox1.ForeColor = textColor(colormode)

        CustomFontBT.BackColor = buttonColor(colormode)
        CustomFontBT.FlatAppearance.BorderColor = BorderColor(colormode)
        CustomFontBT.FlatAppearance.MouseOverBackColor = buttonActiveColor(colormode)
        CustomFontBT.FlatAppearance.MouseDownBackColor = BorderColor(colormode)

        Select Case colormode
            Case "Dark"
                BannerPictureBox.Image = My.Resources.uTable_banner_dark
                CloseBT.Image = My.Resources.closeicon_w
            Case Else
                BannerPictureBox.Image = My.Resources.uTable_banner
                CloseBT.Image = My.Resources.closeicon_b
        End Select
    End Sub

    Public Sub ModeSelect(page As Integer)
        Select Case page
            Case 1
                TabPage1.Visible = True
                TabPage2.Visible = False
                TabPage3.Visible = False
                TabBT1.Font = New Font(TabBT1.Font, FontStyle.Bold)
                TabBT2.Font = New Font(TabBT1.Font, FontStyle.Regular)
                TabBT3.Font = New Font(TabBT1.Font, FontStyle.Regular)
                TabBTB1.BackColor = FocusedTabColor(colormode)
                TabBTB2.BackColor = UnfocusedTabColor(colormode)
                TabBTB3.BackColor = UnfocusedTabColor(colormode)
                TabBT1.ForeColor = FocusedTabColor(colormode)
                TabBT2.ForeColor = UnfocusedTabColor(colormode)
                TabBT3.ForeColor = UnfocusedTabColor(colormode)

            Case 2
                TabPage1.Visible = False
                TabPage2.Visible = True
                TabPage3.Visible = False
                TabBT1.Font = New Font(TabBT1.Font, FontStyle.Regular)
                TabBT2.Font = New Font(TabBT1.Font, FontStyle.Bold)
                TabBT3.Font = New Font(TabBT1.Font, FontStyle.Regular)
                TabBTB1.BackColor = UnfocusedTabColor(colormode)
                TabBTB2.BackColor = FocusedTabColor(colormode)
                TabBTB3.BackColor = UnfocusedTabColor(colormode)
                TabBT1.ForeColor = UnfocusedTabColor(colormode)
                TabBT2.ForeColor = FocusedTabColor(colormode)
                TabBT3.ForeColor = UnfocusedTabColor(colormode)

            Case 3
                TabPage1.Visible = False
                TabPage2.Visible = False
                TabPage3.Visible = True
                TabBT1.Font = New Font(TabBT1.Font, FontStyle.Regular)
                TabBT2.Font = New Font(TabBT1.Font, FontStyle.Regular)
                TabBT3.Font = New Font(TabBT1.Font, FontStyle.Bold)
                TabBTB1.BackColor = UnfocusedTabColor(colormode)
                TabBTB2.BackColor = UnfocusedTabColor(colormode)
                TabBTB3.BackColor = FocusedTabColor(colormode)
                TabBT1.ForeColor = UnfocusedTabColor(colormode)
                TabBT2.ForeColor = UnfocusedTabColor(colormode)
                TabBT3.ForeColor = FocusedTabColor(colormode)

        End Select
    End Sub

    Private Sub TabBT1_Click(sender As Object, e As EventArgs) Handles TabBT1.Click
        ModeSelect(1)
    End Sub

    Private Sub TabBT2_Click(sender As Object, e As EventArgs) Handles TabBT2.Click
        ModeSelect(2)
    End Sub

    Private Sub TabBT3_Click(sender As Object, e As EventArgs) Handles TabBT3.Click
        ModeSelect(3)
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

    Private Sub StartupChk_CheckedChanged(sender As Object, e As EventArgs) Handles StartupChk.CheckedChanged

        Try
            If StartupChk.Checked Then
                SetStartup()
            Else
                RemoveStartup()
            End If
        Catch ex As Exception
            MsgBox("시작프로그램 설정 도중 오류가 발생했습니다. 실행 권한을 확인해 보시기 바랍니다.", vbCritical)
        End Try

    End Sub

    Private Sub ExpandCellChk_CheckedChanged(sender As Object, e As EventArgs) Handles ExpandCellChk.CheckedChanged
        ApplySetting("ExpandCell", ExpandCellChk.Checked)
    End Sub

    Private Sub AlwaysExpandChk_CheckedChanged(sender As Object, e As EventArgs) Handles AlwaysExpandChk.CheckedChanged
        ApplySetting("AlwaysExpand", AlwaysExpandChk.Checked)
        ExpandCellChk.Enabled = Not AlwaysExpandChk.Checked
    End Sub

    Private Sub ShowDayChk_CheckedChanged(sender As Object, e As EventArgs) Handles ShowDayChk.CheckedChanged
        ApplySetting("ShowDay", ShowDayChk.Checked)
    End Sub

    Private Sub ShowProfChk_CheckedChanged(sender As Object, e As EventArgs) Handles ShowProfChk.CheckedChanged
        ApplySetting("ShowProf", ShowProfChk.Checked)
    End Sub

    Private Sub ShowMemoChk_CheckedChanged(sender As Object, e As EventArgs) Handles ShowMemoChk.CheckedChanged
        ApplySetting("ShowMemo", ShowMemoChk.Checked)
    End Sub

    Private Sub BlackTextChk_CheckedChanged(sender As Object, e As EventArgs) Handles BlackTextChk.CheckedChanged
        ApplySetting("BlackText", BlackTextChk.Checked)
    End Sub

    Private Sub CustomFontChk_CheckedChanged(sender As Object, e As EventArgs) Handles CustomFontChk.CheckedChanged
        ApplySetting("CustomFont", CustomFontChk.Checked)
        CustomFontBT.Enabled = CustomFontChk.Checked
    End Sub

    Private Sub MinStartChk_CheckedChanged(sender As Object, e As EventArgs) Handles MinStartChk.CheckedChanged
        ApplySetting("MinStart", MinStartChk.Checked)
    End Sub

    Private Sub SnapToEdgeChk_CheckedChanged(sender As Object, e As EventArgs) Handles SnapToEdgeChk.CheckedChanged
        ApplySetting("SnapToEdge", SnapToEdgeChk.Checked)
    End Sub

    Private Sub FadeEffectChk_CheckedChanged(sender As Object, e As EventArgs) Handles FadeEffectChk.CheckedChanged
        ApplySetting("FadeEffect", FadeEffectChk.Checked)
    End Sub

    '바로 적용 보여주기 위해 시간표 새로고침
    Private Sub TableRelatedOptionCheckboxes_CheckedChanged(sender As Object, e As EventArgs) Handles ExpandCellChk.CheckedChanged,
        AlwaysExpandChk.CheckedChanged, ShowDayChk.CheckedChanged, ShowMemoChk.CheckedChanged, ShowProfChk.CheckedChanged, BlackTextChk.CheckedChanged
        If loaded Then Form1.updateCell()
    End Sub

    Private Sub D_ThemeRbt_CheckedChanged(sender As Object, e As EventArgs) Handles D_ThemeRbt.CheckedChanged
        If D_ThemeRbt.Checked Then
            SetINI("SETTING", "ColorMode", "Dark", ININamePath)
        Else
            SetINI("SETTING", "ColorMode", "White", ININamePath)
        End If

        If Application.OpenForms().OfType(Of SetCourse).Any Then SetCourse.UpdateColor()
        Form1.UpdateColor()
        UpdateColor()
        ModeSelect(1)
    End Sub

    Sub ApplySetting(key As String, value As Boolean)
        If loaded Then
            If value Then
                SetINI("SETTING", key, "1", ININamePath)
            Else
                SetINI("SETTING", key, "0", ININamePath)
            End If
        End If
    End Sub

    Private Sub CustomFontBT_Click(sender As Object, e As EventArgs) Handles CustomFontBT.Click
        If FontDialog1.ShowDialog = DialogResult.OK Then
            FontPrevLabel.Font = New Font(FontDialog1.Font.Name, FontPrevLabel.Font.Size)
            SetINI("SETTING", "CustomFontName", FontDialog1.Font.Name, ININamePath)
            CustomFontBT.Text = FontDialog1.Font.Name
        End If
    End Sub
End Class