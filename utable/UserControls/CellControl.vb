Public Class CellControl
    Public defHeight As Integer = 0
    Public defLoc As Integer = 0
    Dim alwaysExpand As Boolean = False
    Dim doExpand As Boolean = True

    Dim hovered As Boolean = False

    Private Sub UserControl1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        TitleLabel.MaximumSize() = New Size(Width, 0)
        ProfLabel.MaximumSize() = New Size(Width, 0)
        MemoLabel.MaximumSize() = New Size(Width, 0)
        TopTimeLabel.MinimumSize() = New Size(Width, 0)
        BottomTimeLabel.MinimumSize() = New Size(Width, 0)
    End Sub

    Private Sub TitleLabel_Click(sender As Object, e As EventArgs) Handles TitleLabel.Click
        SetCourse.Close()

        Dim appearPoint As New Point(Cursor.Position)

        If appearPoint.X + SetCourse.Width > Form1.Location.X + Form1.Width Then
            appearPoint.X = Form1.Location.X + Form1.Width - SetCourse.Width
        End If

        If appearPoint.Y + SetCourse.Height > Form1.Location.Y + Form1.Height Then
            appearPoint.Y = Form1.Location.Y + Form1.Height - SetCourse.Height
        End If

        SetCourse.modifyMode = True

        For Each s As String In getDatas(readTable(), "course")
            If getData(s, "day") + "-" + getData(s, "name") = Name Then
                SetCourse.olddata = s
            End If
        Next

        SetCourse.SetDesktopLocation(appearPoint.X, appearPoint.Y)
        SetCourse.Show()
    End Sub

    Private Sub TopTimeLabel_MouseEnter(sender As Object, e As EventArgs) Handles TopTimeLabel.MouseEnter,
        TitleLabel.MouseEnter, ProfLabel.MouseEnter, Panel1.MouseEnter, MemoLabel.MouseEnter, BottomTimeLabel.MouseEnter

        hovered = True
    End Sub

    Private Sub CellControl_MouseLeave(sender As Object, e As EventArgs) Handles TopTimeLabel.MouseLeave,
        TitleLabel.MouseLeave, ProfLabel.MouseLeave, Panel1.MouseLeave, MemoLabel.MouseLeave, BottomTimeLabel.MouseLeave

        hovered = False
    End Sub

    Private Sub TitleLabel_MouseEnter(sender As Object, e As EventArgs) Handles TitleLabel.MouseEnter
        TitleLabel.BackColor = ControlPaint.Light(BackColor, 0.5)

    End Sub

    Private Sub TitleLabel_MouseLeave(sender As Object, e As EventArgs) Handles TitleLabel.MouseLeave
        TitleLabel.BackColor = Color.Transparent

    End Sub

    Private Sub CellControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GetINI("SETTING", "CustomFont", "", ININamePath) = "1" Then
            If Not GetINI("SETTING", "CustomFontName", "", ININamePath) = "" Then
                Dim fntname = GetINI("SETTING", "CustomFontName", "", ININamePath)

                ChangeFont(Me, fntname, FontStyle.Regular)
                ChangeFont(TopTimeLabel, fntname, FontStyle.Regular)
                ChangeFont(BottomTimeLabel, fntname, FontStyle.Regular)
                ChangeFont(TitleLabel, fntname, FontStyle.Bold)
                ChangeFont(ProfLabel, fntname, FontStyle.Regular)
                ChangeFont(MemoLabel, fntname, FontStyle.Regular)
            End If
        End If

        If GetINI("SETTING", "BlackText", "", ININamePath) = "1" Then
            Me.ForeColor = Color.Black
            TopTimeLabel.ForeColor = Color.Black
            BottomTimeLabel.ForeColor = Color.Black
            TitleLabel.ForeColor = Color.Black
            ProfLabel.ForeColor = Color.Black
            MemoLabel.ForeColor = Color.Black
        End If

        alwaysExpand = (GetINI("SETTING", "AlwaysExpand", "", ININamePath) = "1")
        doExpand = Not (GetINI("SETTING", "ExpandCell", "", ININamePath) = "0")
        MemoLabel.Visible = Not (GetINI("SETTING", "ShowMemo", "", ININamePath) = "0")
        ProfLabel.Visible = Not (GetINI("SETTING", "ShowProf", "", ININamePath) = "0")

        If alwaysExpand Then
            If Height < TopTimeLabel.Height + TitleLabel.Height + ProfLabel.Height + MemoLabel.Height + BottomTimeLabel.Height Then
                Height = TopTimeLabel.Height + TitleLabel.Height + ProfLabel.Height + MemoLabel.Height + BottomTimeLabel.Height
            End If
        End If
    End Sub

    Sub ChangeFont(ctrl As Control, fntname As String, style As FontStyle)
        ctrl.Font = New Font(fntname, ctrl.Font.Size, style)
    End Sub

    Private Sub TopNotchPanel_Paint(sender As Object, e As PaintEventArgs) Handles TopNotchPanel.Paint

        TopNotchPanel.BackColor = ControlPaint.Light(BackColor, 0.3)
    End Sub

    Private Sub MemoLabel_Click(sender As Object, e As EventArgs) Handles MemoLabel.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If hovered Then
            Dim fullheight As Integer = TopTimeLabel.Height + TitleLabel.Height + ProfLabel.Height + MemoLabel.Height + BottomTimeLabel.Height
            BringToFront()

            If doExpand Then
                '확장을 하려는데 아래공간이 모자랄때
                If Location.Y + fullheight > Form1.TimeTable.Height Then
                    Height = fullheight
                    Location() = New Point(0, Form1.TimeTable.Height - fullheight)
                ElseIf defHeight < fullheight Then
                    Height = fullheight
                End If
            End If

        Else
            If doExpand And Not alwaysExpand Then
                Height = defHeight
            End If

            Location() = New Point(0, defLoc)

        End If
    End Sub
End Class
