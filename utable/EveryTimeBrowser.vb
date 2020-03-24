Public Class EveryTimeBrowser
    Dim source As String

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

    Private Sub EveryTimeBrowser_Load(sender As Object, e As EventArgs) Handles Me.Load
        Opacity = 0

        LoadingSplash1.BackColor = Color.White
        LoadingSplash1.Location = New Point((Width - LoadingSplash1.Width) / 2, (Height - LoadingSplash1.Height) / 2)
        LoadingSplash1.highColor = Color.DarkGray
        LoadingSplash1.lowColor = Color.LightGray
        Refresh()
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        source = WebBrowser1.Document.Body.InnerHtml
        LoadingSplash1.Visible = False

        If source.Contains("<div class=""tablebody"">") Then
            WebBrowser1.Visible = False
            WebBrowser1.Dock = DockStyle.None
            WebBrowser1.Width = 1920
            TableChecker.Start()
        End If

    End Sub

    Private Sub TableChecker_Tick(sender As Object, e As EventArgs) Handles TableChecker.Tick

        Dim source As String = WebBrowser1.Document.Body.InnerHtml
        Dim tabledata As String = ""

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

                If day > 4 Then
                    Exit For
                End If

            Next

            WebBrowser1.Navigate("https://everytime.kr/user/logout")

            If MsgBox("불러오기가 완료되었습니다. 바로 적용하시겠습니까?" + vbCr + "기존 시간표는 지워집니다!",
                      vbQuestion + vbYesNo) = vbYes Then
                writeTable("<tablename>에타에서 불러온 시간표</tablename>" + vbCrLf + tabledata)
                Form1.updateCell()
                Close()
            End If

        End If

    End Sub

    Private Sub CloseBT_Click(sender As Object, e As EventArgs) Handles CloseBT.Click
        Close()
    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        LoadingSplash1.Visible = True
    End Sub
End Class