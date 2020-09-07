Imports System.Runtime.InteropServices

Public Class ViewCourse
    Dim BorderWidth As Integer = Form1.BorderWidth
    Private _resizeDir As ResizeDirection = ResizeDirection.None

    Dim prevData As New List(Of String)
    Dim daysname As String() = {"월", "화", "수", "목", "금", "토", "일"}
    Dim listcount As Integer = 0
    Dim colormode As String = Nothing

    Dim maxTitleSize As Single = 15.0!
    Dim maxSubSize As Single = 9.0!

    Public olddata As String = Nothing
    Public blacktext As Boolean = False

    Dim touched As Boolean = False
    Dim loaded As Boolean = False

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
    Private Const HTBORDER As Integer = 18
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14

    Public Enum ResizeDirection
        None = 0
        Left = 1
        TopLeft = 2
        Top = 3
        TopRight = 4
        Right = 5
        BottomRight = 6
        Bottom = 7
        BottomLeft = 8
    End Enum

    Public Property resizeDir() As ResizeDirection
        Get
            Return _resizeDir
        End Get
        Set(ByVal value As ResizeDirection)
            _resizeDir = value

            'Change cursor
            Select Case value
                Case ResizeDirection.Left
                    Me.Cursor = Cursors.SizeWE

                Case ResizeDirection.Right
                    Me.Cursor = Cursors.SizeWE

                Case ResizeDirection.Top
                    Me.Cursor = Cursors.SizeNS

                Case ResizeDirection.Bottom
                    Me.Cursor = Cursors.SizeNS

                Case ResizeDirection.BottomLeft
                    Me.Cursor = Cursors.SizeNESW

                Case ResizeDirection.TopRight
                    Me.Cursor = Cursors.SizeNESW

                Case ResizeDirection.BottomRight
                    Me.Cursor = Cursors.SizeNWSE

                Case ResizeDirection.TopLeft
                    Me.Cursor = Cursors.SizeNWSE

                Case Else
                    Me.Cursor = Cursors.Default
            End Select
        End Set
    End Property

    Private Sub MoveForm()
        ReleaseCapture()
        SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
    End Sub

    Private Sub ResizeForm(ByVal direction As ResizeDirection)
        Dim dir As Integer = -1

        Select Case direction
            Case ResizeDirection.Left
                dir = HTLEFT
            Case ResizeDirection.TopLeft
                dir = HTTOPLEFT
            Case ResizeDirection.Top
                dir = HTTOP
            Case ResizeDirection.TopRight
                dir = HTTOPRIGHT
            Case ResizeDirection.Right
                dir = HTRIGHT
            Case ResizeDirection.BottomRight
                dir = HTBOTTOMRIGHT
            Case ResizeDirection.Bottom
                dir = HTBOTTOM
            Case ResizeDirection.BottomLeft
                dir = HTBOTTOMLEFT
        End Select

        '마우스 릴리즈시
        If dir <> -1 Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, dir, 0)
        End If
    End Sub

    Private Sub MoveArea_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TitlePanel.MouseDown, UpperTitleLabel.MouseDown, SubTitleLabel.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And Me.WindowState <> FormWindowState.Maximized Then
            MoveForm()
        End If
    End Sub

    Private Sub Form1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UpperPanel.MouseDown, MainPanel.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And Me.WindowState <> FormWindowState.Maximized Then
            ResizeForm(resizeDir)
        End If
    End Sub

    Private Sub Edge_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UpperPanel.MouseMove, MainPanel.MouseMove

        Dim pos As Point = e.Location
        If sender Is MainPanel Then pos.Y += UpperPanel.Height

        If pos.X < BorderWidth And pos.Y < BorderWidth Then
            resizeDir = ResizeDirection.TopLeft

        ElseIf pos.X < BorderWidth And pos.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.BottomLeft

        ElseIf pos.X > Me.Width - BorderWidth And pos.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.BottomRight

        ElseIf pos.X > Me.Width - BorderWidth And pos.Y < BorderWidth Then
            resizeDir = ResizeDirection.TopRight

        ElseIf pos.X < BorderWidth Then
            resizeDir = ResizeDirection.Left

        ElseIf pos.X > Me.Width - BorderWidth Then
            resizeDir = ResizeDirection.Right

        ElseIf pos.Y < BorderWidth Then
            resizeDir = ResizeDirection.Top

        ElseIf pos.Y > Me.Height - BorderWidth Then
            resizeDir = ResizeDirection.Bottom

        Else
            resizeDir = ResizeDirection.None
        End If

    End Sub

    Private Sub Form1_MouseLeave(sender As Object, e As EventArgs) Handles UpperPanel.MouseLeave, MainPanel.MouseLeave
        Cursor = Cursors.Default
    End Sub
#End Region

    Private Sub FadeInEffect(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Refresh()

        MemoTB.SelectionLength = 0
        MemoTB.SelectionStart = MemoTB.Text.Length
        FadeIn(Me, 1)

        loaded = True
    End Sub

    Private Sub FadeOutEffect(sender As Object, e As EventArgs) Handles MyBase.Closing
        FadeOut(Me)
    End Sub

    Private Sub BT_MouseEnter(sender As Object, e As EventArgs) Handles CloseBT.MouseEnter, EditBT.MouseEnter
        sender.BackColor = ControlPaint.Light(TitlePanel.BackColor, 0.5)
    End Sub

    Private Sub BT_MouseLeave(sender As Object, e As EventArgs) Handles CloseBT.MouseLeave, EditBT.MouseLeave
        sender.BackColor = Color.Transparent
    End Sub

    Private Sub CloseBT_Click(sender As Object, e As EventArgs) Handles CloseBT.Click
        If touched Then

            Dim ask1 As MsgBoxResult = MsgBox("변경사항을 저장하시겠습니까?", vbYesNoCancel + vbQuestion)

            If ask1 = vbYes Then
                Apply()
            ElseIf ask1 = vbCancel Then
                Exit Sub
            End If
        End If

        Close()
    End Sub

    Sub UpdateColor()
        colormode = GetINI("SETTING", "ColorMode", "", ININamePath)

        BodyPanel.BackColor = tableColor_1(colormode)
        SaveBT.BackColor = tableColor_1(colormode)
        CancelBT.BackColor = tableColor_1(colormode)
        MemoTB.BackColor = tableColor_1(colormode)

        MainPanel.BackColor = edgeColor(colormode)
        MemoTB.ForeColor = textColor(colormode)
    End Sub

    Private Sub ViewCourse_Load(sender As Object, e As EventArgs) Handles Me.Load
        Opacity = 0

        If GetINI("SETTING", "CustomFont", "", ININamePath) = "1" And GetINI("SETTING", "ApplyAllGUIFonts", "", ININamePath) = "1" Then
            If Not GetINI("SETTING", "CustomFontName", "", ININamePath) = "" Then
                Dim fntname = GetINI("SETTING", "CustomFontName", "", ININamePath)
                ChangeToCustomFont(Me, fntname)
            End If
        End If

        UpdateColor()

        Dim colorMul As Single = 0.9
        Dim data = olddata

        Try
            UpperTitleLabel.Text = getData(data, "name")
            Text = UpperTitleLabel.Text
            SubTitleLabel.Text = getData(data, "prof") + ", "

            Dim startt As Integer = getData(data, "start")
            Dim endt As Integer = getData(data, "end")

            SubTitleLabel.Text += (startt \ 60).ToString + ":"
            If startt Mod 60 = 0 Then
                SubTitleLabel.Text += "00"
            Else
                SubTitleLabel.Text += (startt Mod 60).ToString("D2")
            End If

            SubTitleLabel.Text += "~"
            SubTitleLabel.Text += (endt \ 60).ToString + ":"

            If endt Mod 60 = 0 Then
                SubTitleLabel.Text += "00"
            Else
                SubTitleLabel.Text += (endt Mod 60).ToString("D2")
            End If

            SubTitleLabel.Text += ", " + daysname(Convert.ToInt16(getData(data, "day"))) + "요일"

            MemoTB.Text = getData(data, "memo")
            TitlePanel.BackColor = ColorTranslator.FromHtml(getData(data, "color"))

            Dim c As Color = Color.FromArgb(TitlePanel.BackColor.R * colorMul,
                                        TitlePanel.BackColor.G * colorMul,
                                        TitlePanel.BackColor.B * colorMul)

            UpperPanel.BackColor = c

            If blacktext Then
                Me.ForeColor = Color.Black
                UpperTitleLabel.ForeColor = Color.Black
                SubTitleLabel.ForeColor = Color.Black
                CloseBT.Image = My.Resources.closeicon_b2
                EditBT.Image = My.Resources.bt_edit_b
            End If

            '밝은 배경색에 다크 테마 or 어둑한 배경색에 화이트 테마 -> 배경색을 그대로 쓰기!
            If (blacktext And colormode = "Dark") Or (Not blacktext And Not colormode = "Dark") Then
                CancelBT.ForeColor = TitlePanel.BackColor
                SaveBT.ForeColor = TitlePanel.BackColor

            ElseIf Not blacktext And colormode = "Dark" Then '어둑한 배경색에 다크 테마 -> 배경색이 밝아야 한다
                CancelBT.ForeColor = ControlPaint.Light(TitlePanel.BackColor, 0.7)
                SaveBT.ForeColor = ControlPaint.Light(TitlePanel.BackColor, 0.7)

            Else '밝은 배경색에 화이트 테마 -> 배경색이 어두워야 한다
                CancelBT.ForeColor = c
                SaveBT.ForeColor = c
            End If

        Catch ex As Exception
            MsgBox("수업을 불러오는 도중 문제가 발생하였습니다." + vbCr + "해당 수업의 값이 올바른지 확인하고 삭제 후 다시 추가해 주세요.", vbCritical)

        End Try

        AdjustText(UpperTitleLabel, maxTitleSize)
        AdjustText(SubTitleLabel, maxSubSize)

        '글꼴이 자꾸 시스템 기본값으로 바뀌는것을 방지
        MemoTB.LanguageOption = RichTextBoxLanguageOptions.UIFonts

        'MemoTB.SelectAll()
        'MemoTB.SelectionFont = New Font(UpperTitleLabel.Font.FontFamily, 10, MemoTB.Font.Style)

    End Sub

    Private Sub AdjustText(lblQueue As Label, maxSize As Single)
        If Not lblQueue.Text = Nothing Then
            Dim Fit As Boolean = False
            Dim CurSize As Single
            Dim SizeStep As Single = 0.1
            Dim Padding As Integer = 3

            Do Until Fit
                CurSize += SizeStep
                Dim Fnt As Font = New Font(lblQueue.Font.Name, CurSize)
                Dim textSize As Size = TextRenderer.MeasureText(lblQueue.Text, Fnt)

                textSize.Height += Padding
                textSize.Width += Padding

                If textSize.Height >= lblQueue.Height Or textSize.Width >= lblQueue.Width Or lblQueue.Height = 0 Or lblQueue.Width = 0 Then
                    Fit = True
                    If textSize.Width > lblQueue.Width Then
                        CurSize -= SizeStep
                    End If
                    If textSize.Height > lblQueue.Height Then
                        CurSize -= SizeStep
                    End If
                End If
            Loop

            If CurSize > 6 Then
                'If Not maxSubSize = 0 Or Not maxTitleSize = 0 Then

                If CurSize > maxSize Then
                    lblQueue.Font = New Font(lblQueue.Font.Name, maxSize)
                    Application.DoEvents()
                    Exit Sub

                ElseIf lblQueue Is UpperTitleLabel And CurSize < 9 Then
                    lblQueue.Font = New Font(lblQueue.Font.Name, 9)
                    Application.DoEvents()
                    Exit Sub

                End If

                'End If
                lblQueue.Font = New Font(lblQueue.Font.Name, CurSize)
                Application.DoEvents()
            End If
        End If
    End Sub

    Private Sub ViewCourse_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        AdjustText(UpperTitleLabel, maxTitleSize)
        AdjustText(SubTitleLabel, maxSubSize)

    End Sub

    Private Sub EditBT_Click(sender As Object, e As EventArgs) Handles EditBT.Click
        SetCourse.Close()

        Dim appearPoint As Point = Location

        If appearPoint.X + SetCourse.Width > Form1.Location.X + Form1.Width Then
            appearPoint.X = Form1.Location.X + Form1.Width - SetCourse.Width
        End If

        If appearPoint.Y + SetCourse.Height > Form1.Location.Y + Form1.Height Then
            appearPoint.Y = Form1.Location.Y + Form1.Height - SetCourse.Height
        End If

        SetCourse.modifyMode = True
        SetCourse.olddata = olddata
        SetCourse.SetDesktopLocation(appearPoint.X, appearPoint.Y)

        SetCourse.touched = touched
        SetCourse.Show()
        SetCourse.MemoTB.Text = MemoTB.Text.Replace(vbLf, vbCrLf)
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles MemoTB.TextChanged
        If loaded Then touched = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles CancelBT.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles SaveBT.Click
        If Not touched Then
            Close()
            Exit Sub
        End If

        Apply()
    End Sub

    Sub Apply()
        Try
            Dim data As String = readTable()
            Dim count As Integer = 0

            For Each s As String In getDatas(data, "course")
                '이전설정 이름이 여러개 이미 있을때
                If getData(s, "name") = getData(olddata, "name") Then count += 1
            Next

            If count > 1 Then
                If MsgBox("같은 이름의 수업이 둘 이상 있습니다." + vbCr + "해당 수업의 메모 또한 모두 바꾸시겠습니까?", vbQuestion + vbYesNo) = vbYes Then
                    modifyAllCourse(readTable(), MemoTB.Text)
                Else
                    Dim newdata As String = olddata.Replace(getData_withkeys(olddata, "memo"), "<memo>" + MemoTB.Text + "</memo>")
                    writeTable(readTable.Replace(olddata, newdata))
                End If
            Else
                Dim newdata As String = olddata.Replace(getData_withkeys(olddata, "memo"), "<memo>" + MemoTB.Text + "</memo>")
                writeTable(readTable.Replace(olddata, newdata))
            End If

            Form1.updateCell()

        Catch ex As Exception
            MsgBox("적용 도중 오류가 발생했습니다." + vbCr + ex.Message, vbCritical)
        End Try

        Close()
    End Sub

    Sub modifyAllCourse(data As String, memo As String)
        'Dim data As String = readTable()
        Dim olddatas As List(Of String) = multipleMidReturn("<course>", "</course>", data)
        Dim tablename As String = Nothing

        If Not data.Contains("<tablename>") Then
            tablename = "이름 없는 시간표"
        Else
            If getData(data, "tablename") = "" Then
                tablename = "이름 없는 시간표"
            Else
                tablename = getData(data, "tablename")
            End If
        End If

        Dim newdata As String = ""
        Dim oldname As String = getData(olddata, "name")

        For Each i In olddatas
            Dim tmp As String = i
            If getData(i, "name") = oldname Then tmp = tmp.Replace("<memo>" + getData(i, "memo") + "</memo>", "<memo>" + memo + "</memo>")
            newdata += "<course>" + tmp + "</course>" + vbCrLf
        Next

        writeTable("<tablename>" + tablename + "</tablename>" + vbCrLf + newdata)
    End Sub

    Private Sub MemoTB_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles MemoTB.LinkClicked
        Process.Start(e.LinkText)
    End Sub
End Class