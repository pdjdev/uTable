Imports System.Net

Public Class DLLDownloader

    Dim colorMode As String = Nothing
    Dim WithEvents wc As New Net.WebClient
    Dim downComplete As Boolean = False

    Dim exeFullpath As String = Application.ExecutablePath
    Dim finalDir As String = exeFullpath.Substring(0, exeFullpath.LastIndexOf("\"))

    Const repoLink As String = "https://github.com/pdjdev/uTable/raw/master/res/webview2dlls/"

    Dim downList As New List(Of String) From
        {"Microsoft.Web.WebView2.Core.dll",
        "Microsoft.Web.WebView2.WinForms.dll",
        "WebView2Loader.dll"}

    Dim downCount As Integer = 1

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

        BackColor = edgeColor(colorMode)
        TitlePanel.BackColor = tableColor_1(colorMode)
        TitlePanel.ForeColor = textColor(colorMode)
        MainLabel.BackColor = mainColor(colorMode)
        MainLabel.ForeColor = textColor(colorMode)

    End Sub
    Sub DownloadFiles()
        For Each fileName In downList
            MainLabel.Text = $"다운로드 중... ({downCount}/{downList.Count}):" + vbCr + fileName
            Refresh()
            Threading.Thread.Sleep(100)
            Try
                Dim client As New WebClient()
                client.DownloadFile(repoLink & fileName, finalDir & "\" & fileName)
            Catch ex As Exception
                MainLabel.Text = $"작업 실패... ({downCount}/{downList.Count}):" + vbCr + fileName
            End Try
            downCount += 1
        Next
    End Sub

    Private Sub DLLDownloader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opacity = 0
        UpdateColor()
    End Sub

    Private Sub DLLDownloader_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        DownloadFiles()

        If Not (My.Computer.FileSystem.FileExists(finalDir + "\Microsoft.Web.WebView2.Core.dll") And
           My.Computer.FileSystem.FileExists(finalDir + "\Microsoft.Web.WebView2.WinForms.dll") And
           My.Computer.FileSystem.FileExists(finalDir + "\WebView2Loader.dll")) Then
            MsgBox("다운로드 실패!", vbExclamation)
            Close()
        Else
            EveryTimeBrowserNew.Close()
            EverytimeSemesterSelector.Close()
            EverytimeSemesterSelector.StartPosition = FormStartPosition.Manual
            EverytimeSemesterSelector.SetDesktopLocation(Form1.Location.X + (Form1.Width - EverytimeSemesterSelector.Width) / 2,
                                                         Form1.Location.Y + (Form1.Height - EverytimeSemesterSelector.Height) / 2)
            EverytimeSemesterSelector.Show()
            EverytimeSemesterSelector.TopMost = True
            Close()
        End If
    End Sub
End Class