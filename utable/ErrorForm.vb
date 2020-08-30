Public Class ErrorForm
    Dim count = 10
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        count -= 1
        Button1.Text = "다시 시작 (" + count.ToString + " 초후 실행)"

        If count <= 0 Then
            '다시 시작
            Process.Start(Application.ExecutablePath)
            Application.Exit()
        End If
    End Sub

    Private Sub ErrorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetDesktopLocation(Form1.Location.X + (Form1.Width - Width) / 2, Form1.Location.Y + (Form1.Height - Height) / 2)
        TopMost = True

        Button1.Text = "다시 시작 (" + count.ToString + " 초후 실행)"
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("설정 파일을 삭제하시겠습니까? (API 키 또한 삭제됩니다)", vbQuestion + vbYesNo) = vbYes Then
            My.Computer.FileSystem.DeleteFile(ININamePath)
            Application.Exit()
        End If
    End Sub

    Private Sub RichTextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles RichTextBox1.MouseClick
        Button1.Text = "다시 시작"
        Timer1.Stop()
    End Sub

    Private Sub RichTextBox1_VScroll(sender As Object, e As EventArgs) Handles RichTextBox1.VScroll
        Button1.Text = "다시 시작"
        Timer1.Stop()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '다시 시작
        Process.Start(Application.ExecutablePath)
        Application.Exit()
    End Sub
End Class