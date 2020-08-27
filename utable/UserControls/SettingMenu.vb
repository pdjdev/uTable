Public Class SettingMenu
    Public index As Integer = 0
    Dim goalColor As Color = Nothing
    Dim colormode As String = Nothing
    Public first As Boolean = True
    Dim selected As Boolean = False

    Public Sub SelectionUpdate(selection As Boolean, cm As String)
        selected = selection
        colormode = cm
        If selected Then
            HighlightPanel.BackColor = FocusedTabColor(colormode)
            SettingLabel.Font = New Font(SettingLabel.Font, FontStyle.Bold)
            SettingLabel.ForeColor = textColor(colormode)
            goalColor = OptionForm.MainPanel.BackColor
        Else
            HighlightPanel.BackColor = Color.Transparent
            SettingLabel.Font = New Font(SettingLabel.Font, FontStyle.Regular)
            SettingLabel.ForeColor = lightTextColor(colormode)
            goalColor = OptionForm.SidePanel.BackColor
        End If

        If first Then
            SettingLabel.BackColor = goalColor
            first = False
        End If
    End Sub

    Private Sub SettingLabel_Click(sender As Object, e As EventArgs) Handles SettingLabel.Click
        OptionForm.SwitchMode(index)
    End Sub

    Private Sub ColorTransitionTimer_Tick(sender As Object, e As EventArgs) Handles ColorTransitionTimer.Tick
        If Not goalColor = Nothing And Not goalColor = SettingLabel.BackColor Then
            Dim deltaColor As Integer = 2

            Dim R As Byte = SettingLabel.BackColor.R
            Dim G As Byte = SettingLabel.BackColor.G
            Dim B As Byte = SettingLabel.BackColor.B

            If goalColor.R - deltaColor > R Then
                R += deltaColor
            ElseIf goalColor.R + deltaColor < R Then
                R -= deltaColor
            Else
                R = goalColor.R
            End If

            If goalColor.G - deltaColor > G Then
                G += deltaColor
            ElseIf goalColor.G + deltaColor < G Then
                G -= deltaColor
            Else
                G = goalColor.G
            End If

            If goalColor.B - deltaColor > B Then
                B += deltaColor
            ElseIf goalColor.B + deltaColor < B Then
                B -= deltaColor
            Else
                B = goalColor.B
            End If

            SettingLabel.BackColor = Color.FromArgb(R, G, B)
            Panel6.BackColor = Color.FromArgb(R, G, B)
        End If
    End Sub

    Private Sub SettingMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        goalColor = OptionForm.SidePanel.BackColor
        SettingLabel.BackColor = goalColor
        ColorTransitionTimer.Start()
    End Sub

    Private Sub SettingLabel_MouseEnter(sender As Object, e As EventArgs) Handles SettingLabel.MouseEnter
        If Not selected Then
            If colormode = "Dark" Then
                goalColor = ControlPaint.Light(OptionForm.SidePanel.BackColor, 0.3)
            Else
                goalColor = ControlPaint.Light(OptionForm.SidePanel.BackColor, 0.8)
            End If
        End If
    End Sub

    Private Sub SettingLabel_MouseLeave(sender As Object, e As EventArgs) Handles SettingLabel.MouseLeave
        If selected Then
            goalColor = OptionForm.MainPanel.BackColor
        Else
            goalColor = OptionForm.SidePanel.BackColor
        End If
    End Sub
End Class
