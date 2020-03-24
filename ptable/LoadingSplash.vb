Public Class LoadingSplash
    Public highColor As New Color
    Public lowColor As New Color
    Dim activePos As Integer = 1

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Select Case activePos
            Case 1
                P1.BackColor = highColor
                P2.BackColor = lowColor
                P3.BackColor = lowColor
                P4.BackColor = lowColor
                activePos = 2
            Case 2
                P1.BackColor = lowColor
                P2.BackColor = highColor
                P3.BackColor = lowColor
                P4.BackColor = lowColor
                activePos = 3
            Case 3
                P1.BackColor = lowColor
                P2.BackColor = lowColor
                P3.BackColor = lowColor
                P4.BackColor = highColor
                activePos = 4
            Case 4
                P1.BackColor = lowColor
                P2.BackColor = lowColor
                P3.BackColor = highColor
                P4.BackColor = lowColor
                activePos = 1
        End Select
    End Sub
End Class
