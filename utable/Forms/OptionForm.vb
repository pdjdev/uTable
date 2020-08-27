Imports System.ComponentModel
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Web

Public Class OptionForm
    Public colormode As String = Nothing
    Dim loaded As Boolean = False
    Dim newVersion As String = Nothing

    Dim updateAvailabe As Boolean = False
    Dim downUrl As String = ""
    Dim updHtml As String = ""
    Dim WithEvents wc As New Net.WebClient

    Dim downComplete As Boolean = False

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

    Private Sub MoveArea_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TitlePanel.MouseDown, TitleLabel.MouseDown
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

    Private Sub CloseBT_MouseEnter(sender As Object, e As EventArgs) Handles CloseBT.MouseEnter
        CloseBT.BackColor = buttonActiveColor(colormode)
    End Sub

    Private Sub CloseBT_MouseLeave(sender As Object, e As EventArgs) Handles CloseBT.MouseLeave
        CloseBT.BackColor = Color.Transparent
    End Sub

    Private Sub CloseBT_Click(sender As Object, e As EventArgs) Handles CloseBT.Click
        Close()
    End Sub

    Private Sub OptionForm2_Load(sender As Object, e As EventArgs) Handles Me.Load
        UpdateColor()
        Opacity = 0

        SettingMenu1.index = 1
        SettingMenu2.index = 2
        SettingMenu3.index = 3
        SettingMenu4.index = 4
        SettingMenu5.index = 5

        SettingMenu1.SettingLabel.Text = "기본 설정"
        SettingMenu2.SettingLabel.Text = "시간표 설정"
        SettingMenu3.SettingLabel.Text = "데이터 설정"
        SettingMenu4.SettingLabel.Text = "업데이트"
        SettingMenu5.SettingLabel.Text = "프로그램 정보"

        SwitchMode(1)

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

        colormode = GetINI("SETTING", "ColorMode", "", ININamePath)

        BackColor = edgeColor(colormode)
        TitlePanel.BackColor = tableColor_1(colormode)
        TitleLabel.ForeColor = textColor(colormode)
        MainPanel.BackColor = mainColor(colormode)
        MainPanel.ForeColor = textColor(colormode)
        SidePanel.BackColor = buttonActiveColor(colormode)

        RichTextBox1.BackColor = mainColor(colormode)
        RichTextBox1.ForeColor = textColor(colormode)
        WebPageLabel.LinkColor = lightTextColor(colormode)
        FeedbackLabel.LinkColor = lightTextColor(colormode)

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

    Public Sub SwitchMode(mode As Integer)
        SettingMenu1.SelectionUpdate(False, colormode)
        SettingMenu2.SelectionUpdate(False, colormode)
        SettingMenu3.SelectionUpdate(False, colormode)
        SettingMenu4.SelectionUpdate(False, colormode)
        SettingMenu5.SelectionUpdate(False, colormode)

        Select Case mode
            Case 1
                SettingMenu1.SelectionUpdate(True, colormode)
                TabPage1.Visible = True
                TabPage2.Visible = False
                TabPage3.Visible = False
                TabPage4.Visible = False
                TabPage5.Visible = False

            Case 2
                SettingMenu2.SelectionUpdate(True, colormode)
                TabPage1.Visible = False
                TabPage2.Visible = True
                TabPage3.Visible = False
                TabPage4.Visible = False
                TabPage5.Visible = False

            Case 3
                SettingMenu3.SelectionUpdate(True, colormode)
                TabPage1.Visible = False
                TabPage2.Visible = False
                TabPage3.Visible = True
                TabPage4.Visible = False
                TabPage5.Visible = False

            Case 4
                SettingMenu4.SelectionUpdate(True, colormode)
                TabPage1.Visible = False
                TabPage2.Visible = False
                TabPage3.Visible = False
                TabPage4.Visible = True
                TabPage5.Visible = False

                If downUrl = "" And UpdateChecker.IsBusy = False Then
                    UpdateChecker.RunWorkerAsync()
                    UpdateChkButton.Enabled = False
                    DoUpdateButton.Enabled = False
                End If

            Case 5
                SettingMenu5.SelectionUpdate(True, colormode)
                TabPage1.Visible = False
                TabPage2.Visible = False
                TabPage3.Visible = False
                TabPage4.Visible = False
                TabPage5.Visible = True

        End Select

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

        SettingMenu1.first = True
        SettingMenu2.first = True
        SettingMenu3.first = True
        SettingMenu4.first = True
        SettingMenu5.first = True

        If Application.OpenForms().OfType(Of SetCourse).Any Then SetCourse.UpdateColor()
        Form1.UpdateColor()
        UpdateColor()
        SwitchMode(1)
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles WebPageLabel.LinkClicked
        MsgBox("현재 버전은 " + My.Application.Info.Version.ToString + " 입니다." + vbCr + vbCr + "확인 버튼을 누르면 프로그램 페이지로 이동합니다.", vbInformation)
        Process.Start("https://sw.pbj.kr/apps/utable")
    End Sub


    Sub InfoCopy()
        Dim cominfo As String = ""

        If MsgBox("프로그램 설정값을 복사하시겠습니까?" + vbCr + vbCr _
                  + "오류 보고일 경우, 더욱 정확한 조사를 위해 '예'를 눌러 복사해 주시기 바랍니다." _
                  + vbCr + "(시간표와 같은 민감한 개인 정보는 다음 대화 상자에서 포함 여부를 설정하실 수 있습니다.)",
                  vbQuestion + vbYesNo) = vbYes Then
            Dim g As Graphics = Me.CreateGraphics
            Dim dpi = g.DpiX.ToString()

            cominfo += "[Device Information]" _
                + vbCr + "AppName: " + My.Application.Info.ProductName _
                + vbCr + "AppVersion: " + My.Application.Info.Version.ToString _
                + vbCr + "OS fullname: " + My.Computer.Info.OSFullName.ToString _
                + vbCr + "OS version: " + My.Computer.Info.OSVersion.ToString _
                + vbCr + "OS Platform: " + My.Computer.Info.OSPlatform.ToString _
                + vbCr + "TotalPhysicalMemory: " + My.Computer.Info.TotalPhysicalMemory.ToString _
                + vbCr + "ScreenDPI: " + dpi _
                + vbCr + "OS type: "
            If My.Computer.FileSystem.DirectoryExists("C:\Program Files (x86)") Then
                cominfo = cominfo + "64Bit OS"
            Else
                cominfo = cominfo + "32Bit OS"
            End If

            cominfo += vbCr + vbCr + "[Application Settings Value]" + vbCr
            '설정값 나열
            If My.Computer.FileSystem.FileExists(ININamePath) Then
                'My.Settings.defalutTable = OptionSave()
                cominfo += My.Computer.FileSystem.ReadAllText(ININamePath, System.Text.Encoding.GetEncoding(949))
            Else
                cominfo += "(None)"
            End If

            If MsgBox("현재 적용된 시간표 내용(Default.udata)도 포함하시겠습니까?" + vbCr _
                      + vbCr + "(해당 설정은 프로그램 오류 조사시에만 사용됩니다." _
                      + "하지만 해당 정보는 민감한 개인 정보이기 때문에 제공하기 원치 않으신 경우 " _
                      + "'아니오'를 누르시면 해당 정보는 제외된 채 정보가 복사됩니다)",
                      vbQuestion + vbYesNo) = vbYes Then
                cominfo += vbCr + vbCr + "[uTable Default Data]" + vbCr
                cominfo += readTable()
                cominfo += vbCr + "[End of Data]"
            End If

            cominfo += vbCr + vbCr

            cominfo += "[Report Time]" + vbCr + DateTime.Now.ToString
            Clipboard.SetText(cominfo)

            MsgBox("복사가 완료되었습니다.", vbInformation)
        End If


    End Sub

    Private Sub FeedbackLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles FeedbackLabel.LinkClicked
        InfoCopy()
        Process.Start("https://sw.pbj.kr/apps/utable/report")
    End Sub

    Private Sub RichTextBox_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        Process.Start(e.LinkText)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles UpdateChkButton.Click
        If UpdateChecker.IsBusy = False Then
            newVersion = Nothing
            updateAvailabe = False
            downUrl = ""
            updHtml = ""
            wc = New Net.WebClient

            Label11.Text = "확인 중입니다..."
            Label10.Text = "확인 중입니다..."

            UpdateChecker.RunWorkerAsync()
            UpdateChkButton.Enabled = False
            DoUpdateButton.Enabled = False
        End If
    End Sub

    Private Sub UpdateChecker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles UpdateChecker.DoWork
        Threading.Thread.Sleep(500)

        Try
            Dim source As String = webget("https://github.com/pdjdev/utable/releases.atom")
            Dim entry As String = getData(source, "entry")
            downUrl = "https://github.com/pdjdev/uTable/releases/download/" + getData(entry, "title") + "/uTable.exe"
            updHtml = midReturn("<content type=""html"">", "</content>", entry)

            Dim version = From c In getData(entry, "title")
                          Where Char.IsDigit(c) OrElse c = "."
                          Select num = c.ToString

            newVersion = Join(version.ToArray, "")
            updateAvailabe = Convert.ToDouble(newVersion) > GetAppVersion()
        Catch ex As Exception
            downUrl = "error"
        End Try

        Threading.Thread.Sleep(500)
    End Sub

    Function GetAppVersion() As Double
        Dim tmp As String = My.Application.Info.Version.Major.ToString + "." _
            + My.Application.Info.Version.Minor.ToString _
            + My.Application.Info.Version.Build.ToString _
            + My.Application.Info.Version.Revision.ToString

        Return Convert.ToDouble(tmp)
    End Function

    Private Sub UpdateChecker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles UpdateChecker.RunWorkerCompleted
        If Not downUrl = "error" Then
            Label10.Text = GetAppVersion().ToString + "v"
            Label11.Text = newVersion + "v"

            If updateAvailabe Then
                Label10.Text += " (최신 버전이 아닙니다!)"
            Else
                Label10.Text += " (최신 버전입니다)"
            End If

            WebBrowser1.Navigate("about:blank") '브라우저 초기화
            WebBrowser1.Document.Write("<font face=""맑은 고딕"" size=""2"">" + HttpUtility.HtmlDecode(updHtml))
            WebBrowser1.Refresh()

            DoUpdateButton.Enabled = updateAvailabe
            UpdateChkButton.Enabled = True
        Else
            Label10.Text = "오류 발생"
            Label11.Text = "(인터넷 연결을 확인해주세요)"

            UpdateChkButton.Enabled = True
        End If
    End Sub

    Private Sub DoUpdateButton_Click(sender As Object, e As EventArgs) Handles DoUpdateButton.Click
        If downComplete Then
            DoUpdateTask()
        Else
            If MsgBox("다운로드 후 뜨게 될 작업창을 닫지 마시고 기다려주시면 자동으로 업데이트가 완료됩니다." + vbCr _
                  + "만일 업데이트를 실패했다면 직접 다운로드 페이지로 가서 받으시기 바랍니다. (시간표, 설정 값은 그대로 유지됩니다)" + vbCr + vbCr _
                  + "계속하시려면 '예' 를 눌러주세요.", vbYesNo + vbInformation) = vbYes Then
                wc.CancelAsync()
                DoUpdateButton.Enabled = False

                Try
                    wc.DownloadFileAsync(New Uri(downUrl), "tmp.exe")
                Catch ex As Exception
                    MsgBox("다운로드에 실패하였습니다. 인터넷 연결을 확인해 주시고 다시 시도해 주세요.", vbCritical)
                    DoUpdateButton.Text = "다시 시도"
                    DoUpdateButton.Enabled = True
                    downComplete = False
                End Try
            End If
        End If
    End Sub

    Private Sub wc_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles wc.DownloadProgressChanged
        DoUpdateButton.Text = e.ProgressPercentage.ToString + "%"
    End Sub

    Private Sub wc_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles wc.DownloadFileCompleted
        DoUpdateButton.Text = "작업 중..."
        downComplete = True

        DoUpdateTask()
    End Sub

    Sub DoUpdateTask()
        Try
            Dim procStartInfo As New ProcessStartInfo
            Dim procExecuting As New Process

            With procStartInfo
                .UseShellExecute = True
                .FileName = "cmd.exe"
                .WindowStyle = ProcessWindowStyle.Normal
                .Verb = "runas" 'add this to prompt for elevation
                .Arguments = "/k @echo off & echo 잠시만 기다려 주세요... & taskkill /f /im utable.exe >nul " _
                    + "& cd " + Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\")) _
                    + " & timeout /t 2 /nobreak >nul" _
                    + " & del /f uTable.exe & timeout /t 1 >nul" _
                    + " & rename tmp.exe uTable.exe" _
                    + " & timeout /t 1 /nobreak >nul" _
                    + " & start uTable.exe & exit"
            End With

            procExecuting = Process.Start(procStartInfo)
        Catch ex As Exception
            MsgBox("업데이트 작업에 실패했습니다." + vbCr + vbCr + "사용자 계정 컨트롤 창에서 '예'를 클릭하셨는지 확인해 주시고 다시 시도해 주세요.", vbCritical)
            DoUpdateButton.Text = "다시 시도"
            DoUpdateButton.Enabled = True
        End Try
    End Sub

    Private Sub ForceUpd_CheckedChanged(sender As Object, e As EventArgs) Handles ForceUpdChk.CheckedChanged
        If Not downUrl = "" And ForceUpdChk.Checked Or updateAvailabe Then
            DoUpdateButton.Enabled = True
        Else
            DoUpdateButton.Enabled = False
        End If
    End Sub
End Class