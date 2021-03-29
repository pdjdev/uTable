Public Class CellControl
    Public defHeight As Integer = 0
    Public defLoc As Integer = 0
    Public alwaysExpand As Boolean = False
    Public checked As Boolean = False
    Public dayNum As Integer = 0
    Dim doExpand As Boolean = True
    Dim showChkBox As Boolean = True
    Dim blackText As Boolean = False

    Dim hovered As Boolean = False
    Dim prev_hove As Boolean = False

    '설정값
    Public FadeEffect As String = ""
    Public CustomFont As String = ""
    Public CustomFontName As String = ""
    Public AutoTextColor As String = ""
    Public _BlackText As String = ""
    Public _AlwaysExpand As String = ""
    Public ExpandCell As String = ""
    Public ShowMemo As String = ""
    Public ShowProf As String = ""
    Public _ShowChkBox As String = ""

    '(실험적) 컬러 전환 크기
    Dim deltaColor_R As Integer = 1
    Dim deltaColor_G As Integer = 1
    Dim deltaColor_B As Integer = 1
    Public goalColor As Color = Nothing

    Private Sub UserControl1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        TitleLabel.MaximumSize() = New Size(Width, 0)
        ProfLabel.MaximumSize() = New Size(Width, 0)
        MemoLabel.MaximumSize() = New Size(Width, 0)
        'TopTimeLabel.MinimumSize() = New Size(Width, 0)
        BottomTimeLabel.MinimumSize() = New Size(Width, 0)
    End Sub

    Private Sub TitleLabel_Click(sender As Object, e As EventArgs) Handles TitleLabel.Click
        If Name = "DemoCellControl" Then Exit Sub

        Dim appearPoint As New Point(Cursor.Position)
        'SetCourse.Close()
        ViewCourse.Close()

        If appearPoint.X + ViewCourse.Width > Form1.Location.X + Form1.Width Then
            appearPoint.X = Form1.Location.X + Form1.Width - ViewCourse.Width
        End If

        If appearPoint.Y + ViewCourse.Height > Form1.Location.Y + Form1.Height Then
            appearPoint.Y = Form1.Location.Y + Form1.Height - ViewCourse.Height
        End If

        'SetCourse.modifyMode = True
        For Each s As String In getDatas(readTable(), "course")
            If getData(s, "day") + "-" + getData(s, "start") + "-" + getData(s, "name") = Name Then
                ViewCourse.olddata = s
                Exit For
            End If
        Next

        ViewCourse.blacktext = blackText 

        ViewCourse.SetDesktopLocation(appearPoint.X, appearPoint.Y)
        ViewCourse.Show()
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
        If CustomFont = "1" Then
            If Not CustomFontName = "" Then
                Dim fntname = CustomFontName

                ChangeFont(Me, fntname, FontStyle.Regular)
                ChangeFont(TopTimeLabel, fntname, FontStyle.Bold)
                ChangeFont(BottomTimeLabel, fntname, FontStyle.Bold)
                ChangeFont(TitleLabel, fntname, FontStyle.Bold)
                ChangeFont(ProfLabel, fntname, FontStyle.Regular)
                ChangeFont(MemoLabel, fntname, FontStyle.Regular)
            End If
        End If

        If Not AutoTextColor = "0" Then
            blackText = CheckProperColor(goalColor)
        ElseIf _BlackText = "1" Then
            blackText = True
        End If

        If blackText Then
            Me.ForeColor = Color.Black
            TopTimeLabel.ForeColor = Color.Black
            BottomTimeLabel.ForeColor = Color.Black
            TitleLabel.ForeColor = Color.Black
            ProfLabel.ForeColor = Color.Black
            MemoLabel.ForeColor = Color.Black
        End If

        alwaysExpand = (_AlwaysExpand = "1")
        doExpand = Not (ExpandCell = "0")
        MemoLabel.Visible = Not (ShowMemo = "0")
        ProfLabel.Visible = Not (ShowProf = "0")
        showChkBox = Not (_ShowChkBox = "0")

        ChkBox1.Visible = showChkBox
        If showChkBox Then CheckStateUpdate()

        If alwaysExpand Then
            Dim fullheight As Integer = TopTimeLabel.Height + TitleLabel.Height + BottomTimeLabel.Height
            If ProfLabel.Visible Then fullheight += ProfLabel.Height
            If MemoLabel.Visible Then fullheight += MemoLabel.Height

            If Height < fullheight Then
                Height = fullheight
            End If
        End If

        If Not FadeEffect = "0" Then
            If dayNum Mod 2 = 0 Then
                BackColor = Form1.MonPanel.BackColor
            Else
                BackColor = Form1.TuePanel.BackColor
            End If

            deltaColor_R = Int(Math.Abs((Int(goalColor.R) - Int(BackColor.R)) / 10))
            deltaColor_G = Int(Math.Abs((Int(goalColor.G) - Int(BackColor.G)) / 10))
            deltaColor_B = Int(Math.Abs((Int(goalColor.B) - Int(BackColor.B)) / 10))

            AniTimer.Start()

        Else
            BackColor = goalColor
        End If


    End Sub

    Public Sub ForceExpand()
        Dim fullheight As Integer = TopTimeLabel.Height + TitleLabel.Height + BottomTimeLabel.Height
        If ProfLabel.Visible Then fullheight += ProfLabel.Height
        If MemoLabel.Visible Then fullheight += MemoLabel.Height

        If Height < fullheight Then
            Height = fullheight
        End If
    End Sub

    Sub ChangeFont(ctrl As Control, fntname As String, style As FontStyle)
        ctrl.Font = New Font(fntname, ctrl.Font.Size, style)
    End Sub

    'Private Sub TopNotchPanel_Paint(sender As Object, e As PaintEventArgs) Handles TopNotchPanel.Paint
    '    TopNotchPanel.BackColor = ControlPaint.Light(BackColor, 0.3)
    'End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If prev_hove = hovered Then
            Exit Sub
        Else
            prev_hove = hovered
        End If

        If hovered Then
            Dim fullheight As Integer = TopTimeLabel.Height + TitleLabel.Height + BottomTimeLabel.Height
            If ProfLabel.Visible Then fullheight += ProfLabel.Height
            If MemoLabel.Visible Then fullheight += MemoLabel.Height

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
            '쪼그라들때
            If doExpand And Not alwaysExpand Then
                Height = defHeight
            End If

            Location() = New Point(0, defLoc)
            'If Not Name = "DemoCellControl" Then Form1.DrawTablePattern(dayNum)

        End If
    End Sub

    'Private Sub TopTimeLabel_SizeChanged(sender As Object, e As EventArgs) Handles TopTimeLabel.SizeChanged
    '    TopPanel.Height = TopTimeLabel.Height
    'End Sub

    'Private Sub TopPanel_SizeChanged(sender As Object, e As EventArgs) Handles TopPanel.SizeChanged
    '    ChkBox1.Width = TopPanel.Height
    'End Sub

    Private Sub ChkBox1_Click(sender As Object, e As EventArgs) Handles ChkBox1.Click, TopTimeLabel.Click,
        Panel1.Click, ProfLabel.Click, MemoLabel.Click
        If showChkBox Then
            checked = Not checked
            If Not Name = "DemoCellControl" Then ModifyCheck(Name, checked)
            CheckStateUpdate()
        End If
    End Sub

    Private Sub Chk_Enter(sender As Object, e As EventArgs) Handles ChkBox1.MouseEnter, TopTimeLabel.MouseEnter,
        Panel1.MouseEnter, ProfLabel.MouseEnter, MemoLabel.MouseEnter, ChkBox1.MouseUp, TopTimeLabel.MouseUp,
        Panel1.MouseUp, ProfLabel.MouseUp, MemoLabel.MouseUp
        If showChkBox Then
            ChkBox1.BackColor = ControlPaint.Light(BackColor, 0.3)
        End If
    End Sub

    Private Sub Chk_Down(sender As Object, e As EventArgs) Handles ChkBox1.MouseDown, TopTimeLabel.MouseDown,
        Panel1.MouseDown, ProfLabel.MouseDown, MemoLabel.MouseDown, ChkBox1.MouseLeave, TopTimeLabel.MouseLeave,
        Panel1.MouseLeave, ProfLabel.MouseLeave, MemoLabel.MouseLeave
        If showChkBox Then
            ChkBox1.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub CheckStateUpdate()
        If checked Then
            If blackText Then
                If Form1.currentDPI = 96 Then
                    ChkBox1.Image = My.Resources.check1_b_96
                Else
                    ChkBox1.Image = My.Resources.check1_b
                End If
            Else
                If Form1.currentDPI = 96 Then
                    ChkBox1.Image = My.Resources.check1_w_96
                Else
                    ChkBox1.Image = My.Resources.check1_w
                End If
            End If
            TitleLabel.Font = New Font(TitleLabel.Font.Name, TitleLabel.Font.Size, FontStyle.Strikeout)
        Else
            If blackText Then
                If Form1.currentDPI = 96 Then
                    ChkBox1.Image = My.Resources.check0_b_96
                Else
                    ChkBox1.Image = My.Resources.check0_b
                End If
            Else
                If Form1.currentDPI = 96 Then
                    ChkBox1.Image = My.Resources.check0_w_96
                Else
                    ChkBox1.Image = My.Resources.check0_w
                End If
            End If
            TitleLabel.Font = New Font(TitleLabel.Font.Name, TitleLabel.Font.Size, FontStyle.Bold)
        End If
    End Sub

    Public Sub ModifyCheck(name As String, checked As Boolean)
        Dim data As String = readTable()

        Dim olddata As String = ""

        For Each s As String In getDatas(data, "course")
            If getData(s, "day") + "-" + getData(s, "start") + "-" + getData(s, "name") = name Then
                olddata = s
                Exit For
            End If
        Next

        Dim newdata As String = olddata

        If Not newdata = "" Then
            If newdata.Contains("<checked>") Then
                Dim tmp As String = "<checked>" + getData(newdata, "checked") + "</checked>"
                newdata = newdata.Replace(tmp, "<checked>" + checked.ToString + "</checked>")
            Else 'check 데이터가 없을때
                newdata += vbTab + "<checked>" + checked.ToString + "</checked>" + vbCrLf
            End If
        End If

        writeTable(data.Replace(olddata, newdata))
    End Sub

    Private Sub AniTimer_Tick(sender As Object, e As EventArgs) Handles AniTimer.Tick

        Dim R As Byte = BackColor.R
        Dim G As Byte = BackColor.G
        Dim B As Byte = BackColor.B

        If goalColor.R - deltaColor_R > R Then
            R += deltaColor_R
        ElseIf goalColor.R + deltaColor_R < R Then
            R -= deltaColor_R
        Else
            R = goalColor.R
        End If

        If goalColor.G - deltaColor_G > G Then
            G += deltaColor_G
        ElseIf goalColor.G + deltaColor_G < G Then
            G -= deltaColor_G
        Else
            G = goalColor.G
        End If

        If goalColor.B - deltaColor_B > B Then
            B += deltaColor_B
        ElseIf goalColor.B + deltaColor_B < B Then
            B -= deltaColor_B
        Else
            B = goalColor.B
        End If

        BackColor = Color.FromArgb(R, G, B)
        TopNotchPanel.BackColor = ControlPaint.Light(BackColor, 0.3)

        If goalColor = BackColor Then
            AniTimer.Stop()
        End If
    End Sub
End Class
