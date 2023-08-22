Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports Microsoft.Web.WebView2.Core

Public Class EveryTimeBrowserNew
    Dim colorMode As String = Nothing '시간표 채울때 색상에 맞추도록
    Public targetUrl As String
    Dim webdone As Boolean = False
    Dim source As String

    Dim dpivalue As Integer = 100
    Dim trialCount As Integer = 0

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

    Private Sub MoveArea_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And Me.WindowState <> FormWindowState.Maximized Then
            MoveForm()
        End If
    End Sub

#End Region

    Private Sub FadeInEffect(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoadingSplash1.BackColor = Color.White
        LoadingSplash1.Location = New Point((Width - LoadingSplash1.Width) / 2, (Height - LoadingSplash1.Height) / 2)
        LoadingSplash1.highColor = Color.DarkGray
        LoadingSplash1.lowColor = Color.LightGray

        Me.Refresh()
        dpivalue = dpicalc(Me, 100)
        'FadeIn(Me, 1)
    End Sub

    Private Sub FadeOutEffect(sender As Object, e As EventArgs) Handles MyBase.Closing
        FadeOut(Me)
    End Sub


    Private Sub CloseBT_Click(sender As Object, e As EventArgs) Handles CloseBT.Click
        Close()
    End Sub

    Private Async Sub EveryTimeBrowserNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cachePath As String = System.IO.Path.Combine(System.IO.Path.GetTempPath, "uTable")
        Dim options = New CoreWebView2EnvironmentOptions()
        Dim env = Await CoreWebView2Environment.CreateAsync(Nothing, cachePath, options)
        Await WebView21.EnsureCoreWebView2Async(env)

        colorMode = GetINI("SETTING", "ColorMode", "", ININamePath)

        If GetINI("SETTING", "CustomFont", "", ININamePath) = "1" And GetINI("SETTING", "ApplyAllGUIFonts", "", ININamePath) = "1" Then
            If Not GetINI("SETTING", "CustomFontName", "", ININamePath) = "" Then
                Dim fntname = GetINI("SETTING", "CustomFontName", "", ININamePath)
                ChangeToCustomFont(Me, fntname)
            End If
        End If

        WebView21.Source = New Uri(targetUrl)
        trialCount = 0

        Refresh()
    End Sub

    Private Sub WebView2_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WebView21.NavigationCompleted
        'MsgBox("done!!")
        'source = Await getTableData()
        LoadingSplash1.Visible = False

        If WebView21.Source.ToString.Contains("/timetable") Then
            Debug.Print("Detected!!" + vbCrLf)
            Label1.Text = "시간표를 불러오는 중..."
            'PerformZoom(WebBrowser1, dpivalue)
            WebView21.Visible = False
            WebView21.Dock = DockStyle.None
            WebView21.Width = 1920
            TableChecker.Start()
        Else
            'PerformZoom(WebBrowser1, Convert.ToInt32(dpivalue * dpivalue / 100))
            Debug.Print("Not detected!!" + vbCrLf)
        End If
    End Sub

    Private Async Sub TableChecker_Tick(sender As Object, e As EventArgs) Handles TableChecker.Tick

        Dim source As String = Await getTableData()
        Dim tabledata As String = ""

        Debug.Print(vbCrLf + source)

        If source.Contains("class=""subject") Then

            TableChecker.Stop()

            Dim day As Integer = 0
            Dim tables As List(Of String) = multipleMidReturn("<div class=""cols""", "<div class=""grids"">", source)

            For Each s As String In tables

                If s.Contains("<div") Then
                    Dim courses As List(Of String) = multipleMidReturn("<div", "</div>", s)

                    For Each c As String In courses

                        Dim name As String = midReturn("<h3>", "</h3>", c)
                        Dim start As Integer = Convert.ToInt16(midReturn("top:", ";", c).Replace("px", ""))
                        Dim len As Integer = Convert.ToInt16(midReturn("height:", ";", c).Replace("px", "")) - 1
                        Dim prof As String = getData(c, "em")
                        Dim memo As String = getData(c, "span")
                        Dim color As New Color

                        '컬러 추출
                        Select Case midReturn("subject color", """", c)
                            Case "1"
                                color = Color.FromArgb(240, 134, 118)
                            Case "2"
                                color = Color.FromArgb(251, 171, 102)
                            Case "3"
                                color = Color.FromArgb(236, 195, 105)
                            Case "4"
                                color = Color.FromArgb(167, 202, 112)
                            Case "5"
                                color = Color.FromArgb(118, 203, 136)
                            Case "6"
                                color = Color.FromArgb(125, 209, 193)
                            Case "7"
                                color = Color.FromArgb(122, 165, 233)
                            Case "8"
                                color = Color.FromArgb(61, 103, 173)
                            Case "9"
                                color = Color.FromArgb(159, 134, 225)
                            Case Else
                                color = Color.DarkGray
                        End Select

                        '다크 모드로 설정되었을시 어둡게 설정하기
                        If colorMode = "Dark" Then
                            color = ControlPaint.Dark(color, 0.2)
                        End If

                        tabledata += "<course>" + vbCrLf
                        tabledata += vbTab + "<day>" + day.ToString + "</day>" + vbCrLf
                        tabledata += vbTab + "<name>" + name + "</name>" + vbCrLf
                        tabledata += vbTab + "<prof>" + prof + "</prof>" + vbCrLf
                        tabledata += vbTab + "<memo>" + memo + "</memo>" + vbCrLf
                        tabledata += vbTab + "<start>" + start.ToString + "</start>" + vbCrLf
                        tabledata += vbTab + "<end>" + (start + len).ToString + "</end>" + vbCrLf
                        tabledata += vbTab + "<color>" + ColorTranslator.ToHtml(color) + "</color>" + vbCrLf
                        tabledata += "</course>" + vbCrLf

                    Next
                End If

                day += 1

                If day > 6 Then
                    Exit For
                End If

            Next

            Threading.Thread.Sleep(3000)
            WebView21.Source = New Uri("https://everytime.kr/user/logout")

            If MsgBox("불러오기가 완료되었습니다. 바로 적용하시겠습니까?" + vbCr + "기존 시간표는 지워집니다!",
                      vbQuestion + vbYesNo) = vbYes Then
                writeTable("<tablename>에타에서 불러온 시간표</tablename>" + vbCrLf + tabledata)
                Form1.updateCell()
                Close()
            End If

        Else
            trialCount += 1

            If trialCount = 15 Then
                TableChecker.Stop()
                MsgBox("시간표가 불러와지지 않는 것 같습니다.." + vbCr + vbCr _
                       + "현재 시간표가 비어 있거나 인터넷 연결이 원활하지 않거나 에브리타임 사이트 구조 변경으로 인해 프로그램이 시간표 값을 읽는 데 문제가 발생한 것일 수 있습니다." _
                       + vbCr + vbCr + "시간표가 비어 있는지 확인해 보시고 시간표가 채워져 있는데도 여전히 불러올 수 없다면 최신 버전을 확인해 보시고, 최신 버전인데도 같은 문제가 발생한다면 '프로그램 설정' > '정보' > '오류 보고/피드백 남기기' 텍스트를 클릭하셔서 접수해주시면 가능한 빨리 업데이트하도록 하겠습니다.", vbInformation)
                Close()
            End If
        End If

    End Sub

    Private Async Function getTableData() As Task(Of String)
        Dim html = Await WebView21.ExecuteScriptAsync("document.querySelector('table.tablebody').innerHTML")
        html = Regex.Unescape(html)
        html = html.Remove(0, 1)
        html = html.Remove(html.Length - 1, 1)
        Return html
    End Function

    Private Sub WebView21_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles WebView21.NavigationStarting
        LoadingSplash1.Visible = True
    End Sub
End Class