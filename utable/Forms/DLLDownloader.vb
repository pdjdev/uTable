Imports System.Net

Imports System.IO
Imports System.IO.Compression

Public Class DLLDownloader

    Dim colorMode As String = Nothing
    Dim exeFullpath As String = Application.ExecutablePath
    Dim finalDir As String = exeFullpath.Substring(0, exeFullpath.LastIndexOf("\"))

    ' WebView2 SDK의 공식 NuGet 패키지
    Const webView2PackageUrl As String = "https://api.nuget.org/v3-flatcontainer/microsoft.web.webview2/1.0.1774.30/microsoft.web.webview2.1.0.1774.30.nupkg"

#Region "Aero 그림자 효과 (Vista이상)"

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        CreateDropShadow(Me)
        MyBase.OnHandleCreated(e)
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
        Dim theme As ThemeColors = ThemeColors.FromMode(colorMode)

        BackColor = theme.Edge
        TitlePanel.BackColor = theme.TablePrimary
        TitlePanel.ForeColor = theme.Text
        MainLabel.BackColor = theme.Background
        MainLabel.ForeColor = theme.Text

    End Sub
    Private Function DownloadFiles() As Boolean
        Dim packagePath = Path.Combine(Path.GetTempPath(), "uTable-WebView2-" & Guid.NewGuid().ToString("N") & ".nupkg")
        Dim files As New Dictionary(Of String, String) From {
            {"lib/net45/Microsoft.Web.WebView2.Core.dll", "Microsoft.Web.WebView2.Core.dll"},
            {"lib/net45/Microsoft.Web.WebView2.WinForms.dll", "Microsoft.Web.WebView2.WinForms.dll"},
            {"runtimes/win-x86/native/WebView2Loader.dll", "runtimes/win-x86/native/WebView2Loader.dll"},
            {"runtimes/win-x64/native/WebView2Loader.dll", "runtimes/win-x64/native/WebView2Loader.dll"},
            {"runtimes/win-arm64/native/WebView2Loader.dll", "runtimes/win-arm64/native/WebView2Loader.dll"}
        }

        Try
            MainLabel.Text = "필요 요소 다운로드 중..." + vbCr + "Microsoft.Web.WebView2"
            Refresh()
            Using client As New WebClient()
                client.DownloadFile(webView2PackageUrl, packagePath)
            End Using

            Using package = ZipFile.OpenRead(packagePath)
                Dim count = 1
                For Each file In files
                    MainLabel.Text = $"필요 요소 설치 중... ({count}/{files.Count}):" + vbCr + Path.GetFileName(file.Value)
                    Refresh()
                    Dim entry = package.GetEntry(file.Key)
                    If entry Is Nothing Then Throw New InvalidDataException("WebView2 패키지에 필요한 파일이 없습니다: " & file.Key)

                    Dim destination = Path.Combine(finalDir, file.Value.Replace("/", "\"))
                    Directory.CreateDirectory(Path.GetDirectoryName(destination))
                    entry.ExtractToFile(destination, True)
                    count += 1
                Next
            End Using
            Return True
        Catch ex As Exception
            MainLabel.Text = "작업 실패: " + ex.Message
            Return False
        Finally
            If File.Exists(packagePath) Then File.Delete(packagePath)
        End Try
    End Function

    Private Sub DLLDownloader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opacity = 0
        UpdateColor()
    End Sub

    Private Sub DLLDownloader_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Not DownloadFiles() Then
            MsgBox("다운로드 실패! 인터넷 연결과 실행 폴더의 쓰기 권한을 확인해 주세요.", vbExclamation)
            Close()
            Return
        End If

        If Not (My.Computer.FileSystem.FileExists(finalDir + "\Microsoft.Web.WebView2.Core.dll") And
           My.Computer.FileSystem.FileExists(finalDir + "\Microsoft.Web.WebView2.WinForms.dll") And
           My.Computer.FileSystem.FileExists(finalDir + "\runtimes\win-x86\native\WebView2Loader.dll") And
           My.Computer.FileSystem.FileExists(finalDir + "\runtimes\win-x64\native\WebView2Loader.dll") And
           My.Computer.FileSystem.FileExists(finalDir + "\runtimes\win-arm64\native\WebView2Loader.dll")) Then
            MsgBox("다운로드 실패!", vbExclamation)
            Close()
        Else
            EveryTimeBrowserNew.Close()
            EverytimeSemesterSelector.Close()
            EverytimeSemesterSelector.StartPosition = FormStartPosition.Manual
            EverytimeSemesterSelector.SetDesktopLocation(TableForm.Location.X + (TableForm.Width - EverytimeSemesterSelector.Width) / 2,
                                                         TableForm.Location.Y + (TableForm.Height - EverytimeSemesterSelector.Height) / 2)
            EverytimeSemesterSelector.Show()
            EverytimeSemesterSelector.TopMost = True
            Close()
        End If
    End Sub
End Class
