Imports System.Drawing.Text

Public Class CellControl
    Public defHeight As Integer = 0
    Public defLoc As Integer = 0
    Public alwaysExpand As Boolean = False
    Public checked As Boolean = False
    Public dayNum As Integer = 0

    Public StartText As String = ""
    Public EndText As String = ""
    Public CourseTitle As String = ""
    Public ProfessorText As String = ""
    Public MemoText As String = ""

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
    Public UsesSharedFadeClock As Boolean = False
    Public goalColor As Color = Nothing
    Public Event FadeStarted As EventHandler

    Private ReadOnly Property HorizontalPadding As Integer
        Get
            Return ScaleValue(3)
        End Get
    End Property

    Private ReadOnly Property VerticalPadding As Integer
        Get
            Return ScaleValue(0)
        End Get
    End Property

    Private ReadOnly Property NotchHeight As Integer
        Get
            Return ScaleValue(2)
        End Get
    End Property

    Private ReadOnly Property CheckSize As Integer
        Get
            Return ScaleValue(20)
        End Get
    End Property

    Private doExpand As Boolean = True
    Private showChkBox As Boolean = True
    Private showMemoText As Boolean = True
    Private showProfessor As Boolean = True
    Private blackText As Boolean = False
    Private hovered As Boolean = False
    Private checkHovered As Boolean = False
    Private checkPressed As Boolean = False
    Private titleHovered As Boolean = False
    Private fadeInProgress As Boolean = False
    Private deltaColor_R As Integer = 1
    Private deltaColor_G As Integer = 1
    Private deltaColor_B As Integer = 1
    Private titleBounds As Rectangle = Rectangle.Empty
    Private titleHoverBounds As Rectangle = Rectangle.Empty

    Private timeFont As Font
    Private titleFont As Font
    Private titleStrikeoutFont As Font
    Private bodyFont As Font
    Private memoFont As Font

    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Private Sub CellControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not AutoTextColor = "0" Then
            blackText = CheckProperColor(goalColor)
        Else
            blackText = (_BlackText = "1")
        End If

        ForeColor = If(blackText, Color.Black, Color.White)
        alwaysExpand = (_AlwaysExpand = "1")
        doExpand = Not (ExpandCell = "0")
        showMemoText = Not (ShowMemo = "0")
        showProfessor = Not (ShowProf = "0")
        showChkBox = Not (_ShowChkBox = "0")
        CreateRenderFonts()

        If alwaysExpand Then ForceExpand()

        If Not FadeEffect = "0" AndAlso UsesSharedFadeClock Then
            BackColor = If(dayNum Mod 2 = 0, TableForm.MonPanel.BackColor, TableForm.TuePanel.BackColor)
            BeginFade()
        Else
            BackColor = goalColor
        End If
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        If ClientSize.Width <= 0 OrElse ClientSize.Height <= 0 Then Return

        EnsureRenderFonts()
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        Using notchBrush As New SolidBrush(ControlPaint.Light(BackColor, 0.3))
            e.Graphics.FillRectangle(notchBrush, New Rectangle(0, 0, ClientSize.Width, NotchHeight))
        End Using

        Dim contentWidth As Integer = Math.Max(1, ClientSize.Width - HorizontalPadding * 2)
        Dim y As Integer = NotchHeight + VerticalPadding
        Dim checkBounds As New Rectangle(HorizontalPadding, y, CheckSize, CheckSize)
        Dim timeX As Integer = HorizontalPadding

        If showChkBox Then
            DrawCheckBox(e.Graphics, checkBounds)
            timeX += CheckSize + 3
        End If

        Using leftFormat As New StringFormat(StringFormatFlags.NoWrap), textBrush As New SolidBrush(ForeColor)
            leftFormat.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(StartText, timeFont, textBrush, New RectangleF(timeX, y, Math.Max(1, ClientSize.Width - timeX - HorizontalPadding), CheckSize), leftFormat)
        End Using

        y += Math.Max(CheckSize, timeFont.Height) + VerticalPadding
        titleBounds = New Rectangle(HorizontalPadding, y, contentWidth, MeasureTextHeight(CourseTitle, titleFont, contentWidth))
        titleHoverBounds = titleBounds

        If titleHovered Then
            Using titleHoverBrush As New SolidBrush(ControlPaint.Light(BackColor, 0.25))
                e.Graphics.FillRectangle(titleHoverBrush, titleHoverBounds)
            End Using
        End If

        DrawWrappedText(e.Graphics, CourseTitle, If(checked, titleStrikeoutFont, titleFont), titleBounds)
        y += titleBounds.Height

        If showProfessor AndAlso Not String.IsNullOrEmpty(ProfessorText) Then
            Dim professorBounds As New Rectangle(HorizontalPadding, y, contentWidth, MeasureTextHeight(ProfessorText, bodyFont, contentWidth))
            DrawWrappedText(e.Graphics, ProfessorText, bodyFont, professorBounds)
            y += professorBounds.Height
        End If

        If showMemoText AndAlso Not String.IsNullOrEmpty(MemoText) Then
            Dim memoBounds As New Rectangle(HorizontalPadding, y, contentWidth, MeasureTextHeight(MemoText, memoFont, contentWidth))
            DrawWrappedText(e.Graphics, MemoText, memoFont, memoBounds)
        End If

        Dim backdropHeight As Integer = ScaleValue(40)
        Dim backdropTop As Integer = Math.Max(NotchHeight, ClientSize.Height - backdropHeight)
        Dim backdropTrim As Integer = Math.Min(ScaleValue(2), Math.Max(0, ClientSize.Height - backdropTop - 1))
        Dim endTimeBackdrop As New Rectangle(0,
                                              backdropTop + backdropTrim,
                                              ClientSize.Width,
                                              Math.Max(1, ClientSize.Height - backdropTop - backdropTrim))

        DrawEndTimeBackdrop(e.Graphics, endTimeBackdrop)

        Using rightFormat As New StringFormat(StringFormatFlags.NoWrap), textBrush As New SolidBrush(ForeColor)
            rightFormat.Alignment = StringAlignment.Far
            rightFormat.LineAlignment = StringAlignment.Far
            e.Graphics.DrawString(EndText, timeFont, textBrush, New RectangleF(HorizontalPadding, NotchHeight, contentWidth, ClientSize.Height - NotchHeight - VerticalPadding), rightFormat)
        End Using
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        Using backgroundBrush As New SolidBrush(BackColor)
            e.Graphics.FillRectangle(backgroundBrush, ClientRectangle)
        End Using
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        Dim mouseLocation As Point = PointToClient(Cursor.Position)
        checkHovered = showChkBox AndAlso New Rectangle(HorizontalPadding, NotchHeight + VerticalPadding, CheckSize, CheckSize).Contains(mouseLocation)
        titleHovered = titleHoverBounds.Contains(mouseLocation)
        SetHovered(True)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        checkHovered = False
        checkPressed = False
        titleHovered = False
        SetHovered(False)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim newCheckHovered As Boolean = showChkBox AndAlso New Rectangle(HorizontalPadding, NotchHeight + VerticalPadding, CheckSize, CheckSize).Contains(e.Location)
        Dim newTitleHovered As Boolean = titleHoverBounds.Contains(e.Location)
        If checkHovered <> newCheckHovered OrElse titleHovered <> newTitleHovered Then
            checkHovered = newCheckHovered
            titleHovered = newTitleHovered
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button <> MouseButtons.Left Then Return

        Dim checkBounds As New Rectangle(HorizontalPadding, NotchHeight + VerticalPadding, CheckSize, CheckSize)
        If showChkBox AndAlso checkBounds.Contains(e.Location) Then
            checkPressed = True
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If checkPressed Then
            checkPressed = False
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        MyBase.OnMouseClick(e)
        If e.Button <> MouseButtons.Left Then Return

        Dim checkBounds As New Rectangle(HorizontalPadding, NotchHeight + VerticalPadding, CheckSize, CheckSize)
        If showChkBox AndAlso (checkBounds.Contains(e.Location) OrElse e.Location.Y < titleBounds.Top) Then
            ToggleCheck()
        ElseIf titleBounds.Contains(e.Location) Then
            OpenCourseDetails()
        ElseIf showChkBox Then
            ToggleCheck()
        End If
    End Sub

    Private Sub SetHovered(value As Boolean)
        If hovered = value Then Return
        hovered = value
        Dim previousBounds As Rectangle = Bounds

        If hovered Then
            BringToFront()
            If doExpand Then
                Dim fullHeight As Integer = GetRequiredHeight()
                Dim parentHeight As Integer = If(Parent Is Nothing, Height, Parent.ClientSize.Height)

                If Location.Y + fullHeight > parentHeight Then
                    Height = fullHeight
                    Location = New Point(0, Math.Max(0, parentHeight - fullHeight))
                ElseIf defHeight < fullHeight Then
                    Height = fullHeight
                End If
            End If
        Else
            If doExpand AndAlso Not alwaysExpand Then Height = defHeight
            Location = New Point(0, defLoc)
        End If

        Invalidate()
        If Parent IsNot Nothing AndAlso previousBounds <> Bounds Then
            Parent.Invalidate(previousBounds)
            Parent.Invalidate(Bounds)
        End If
    End Sub

    Public Sub ForceExpand()
        Dim fullHeight As Integer = GetRequiredHeight()
        If Height < fullHeight Then Height = fullHeight
    End Sub

    Private Sub ToggleCheck()
        checked = Not checked
        If Name <> "DemoCellControl" Then ModifyCheck(Name, checked)
        Invalidate()
    End Sub

    Private Sub OpenCourseDetails()
        If Name = "DemoCellControl" Then Return

        Dim appearPoint As New Point(Cursor.Position)
        ViewCourse.Close()
        If appearPoint.X + ViewCourse.Width > TableForm.Location.X + TableForm.Width Then appearPoint.X = TableForm.Location.X + TableForm.Width - ViewCourse.Width
        If appearPoint.Y + ViewCourse.Height > TableForm.Location.Y + TableForm.Height Then appearPoint.Y = TableForm.Location.Y + TableForm.Height - ViewCourse.Height

        ViewCourse.olddata = TryCast(Tag, String)
        If String.IsNullOrEmpty(ViewCourse.olddata) Then Return

        ViewCourse.blacktext = blackText
        ViewCourse.SetDesktopLocation(appearPoint.X, appearPoint.Y)
        ViewCourse.Show()
    End Sub

    Private Function GetRequiredHeight() As Integer
        EnsureRenderFonts()
        Dim contentWidth As Integer = Math.Max(1, ClientSize.Width - HorizontalPadding * 2)
        Dim result As Integer = NotchHeight + VerticalPadding + Math.Max(CheckSize, timeFont.Height) + VerticalPadding
        result += MeasureTextHeight(CourseTitle, titleFont, contentWidth)
        If showProfessor Then result += MeasureTextHeight(ProfessorText, bodyFont, contentWidth)
        If showMemoText Then result += MeasureTextHeight(MemoText, memoFont, contentWidth)
        result += timeFont.Height + VerticalPadding
        Return result
    End Function

    Private Function MeasureTextHeight(value As String, fontToMeasure As Font, width As Integer) As Integer
        If String.IsNullOrEmpty(value) Then Return 0
        Return TextRenderer.MeasureText(value, fontToMeasure, New Size(Math.Max(1, width), Integer.MaxValue), TextFormatFlags.WordBreak Or TextFormatFlags.NoPadding).Height
    End Function

    Private Sub DrawWrappedText(graphics As Graphics, value As String, fontToDraw As Font, bounds As Rectangle)
        If String.IsNullOrEmpty(value) OrElse bounds.Height <= 0 Then Return
        Using textBrush As New SolidBrush(ForeColor), textFormat As New StringFormat()
            textFormat.Trimming = StringTrimming.EllipsisCharacter
            graphics.DrawString(value, fontToDraw, textBrush, bounds, textFormat)
        End Using
    End Sub

    Private Sub DrawEndTimeBackdrop(graphics As Graphics, bounds As Rectangle)
        If bounds.Width <= 0 OrElse bounds.Height <= 0 Then Return

        Dim lastRow As Integer = Math.Max(1, bounds.Height - 1)
        For row As Integer = 0 To bounds.Height - 1
            Dim progress As Double = row / CDbl(lastRow)
            Dim alpha As Integer
            If progress <= 0.05 Then
                alpha = 0
            ElseIf progress < 1.0 Then
                alpha = CInt(Math.Round(255 * ((progress - 0.05) / 0.95)))
            Else
                alpha = 255
            End If

            If alpha = 0 Then Continue For

            Using backdropBrush As New SolidBrush(Color.FromArgb(alpha, BackColor))
                graphics.FillRectangle(backdropBrush, bounds.X, bounds.Y + row, bounds.Width, 1)
            End Using
        Next
    End Sub

    Private Sub DrawCheckBox(graphics As Graphics, bounds As Rectangle)
        If checkHovered OrElse checkPressed Then
            Using hoverBrush As New SolidBrush(ControlPaint.Light(BackColor, 0.3))
                graphics.FillRectangle(hoverBrush, bounds)
            End Using
        End If

        Dim image As Image
        If checked Then
            image = If(blackText, If(TableForm.currentDPI = 96, My.Resources.check1_b_96, My.Resources.check1_b), If(TableForm.currentDPI = 96, My.Resources.check1_w_96, My.Resources.check1_w))
        Else
            image = If(blackText, If(TableForm.currentDPI = 96, My.Resources.check0_b_96, My.Resources.check0_b), If(TableForm.currentDPI = 96, My.Resources.check0_w_96, My.Resources.check0_w))
        End If

        graphics.DrawImage(image, bounds)
    End Sub

    Public Sub ModifyCheck(name As String, value As Boolean)
        Dim data As String = readTable()
        Dim olddata As String = TryCast(Tag, String)
        If String.IsNullOrEmpty(olddata) Then Return

        Dim newdata As String = olddata
        If newdata.Contains("<checked>") Then
            Dim tmp As String = "<checked>" + getTableData(newdata, "checked") + "</checked>"
            newdata = newdata.Replace(tmp, "<checked>" + value.ToString + "</checked>")
        Else
            newdata += vbTab + "<checked>" + value.ToString + "</checked>" + vbCrLf
        End If

        writeTable(data.Replace(olddata, newdata))
        Tag = newdata
    End Sub

    Private Sub BeginFade()
        deltaColor_R = CInt(Math.Abs((CInt(goalColor.R) - CInt(BackColor.R)) / 10))
        deltaColor_G = CInt(Math.Abs((CInt(goalColor.G) - CInt(BackColor.G)) / 10))
        deltaColor_B = CInt(Math.Abs((CInt(goalColor.B) - CInt(BackColor.B)) / 10))
        fadeInProgress = True
        RaiseEvent FadeStarted(Me, EventArgs.Empty)
    End Sub

    Public Function AdvanceFade() As Boolean
        If Not fadeInProgress Then Return False

        Dim red As Byte = MoveToward(BackColor.R, goalColor.R, deltaColor_R)
        Dim green As Byte = MoveToward(BackColor.G, goalColor.G, deltaColor_G)
        Dim blue As Byte = MoveToward(BackColor.B, goalColor.B, deltaColor_B)
        BackColor = Color.FromArgb(red, green, blue)

        If goalColor = BackColor Then fadeInProgress = False
        Return fadeInProgress
    End Function

    Private Function MoveToward(currentValue As Byte, targetValue As Byte, delta As Integer) As Byte
        If targetValue - delta > currentValue Then Return CByte(currentValue + delta)
        If targetValue + delta < currentValue Then Return CByte(currentValue - delta)
        Return targetValue
    End Function

    Private Function ScaleValue(value As Integer) As Integer
        Return Math.Max(1, CInt(Math.Round(value * DeviceDpi / 96.0)))
    End Function

    Private Sub EnsureRenderFonts()
        If timeFont Is Nothing Then CreateRenderFonts()
    End Sub

    Private Sub CreateRenderFonts()
        DisposeRenderFonts()
        Dim familyName As String = If(CustomFont = "1" AndAlso Not String.IsNullOrWhiteSpace(CustomFontName), CustomFontName, Font.FontFamily.Name)
        timeFont = New Font(familyName, 9.75F, FontStyle.Bold)
        titleFont = New Font(familyName, 11.25F, FontStyle.Bold)
        titleStrikeoutFont = New Font(familyName, 11.25F, FontStyle.Bold Or FontStyle.Strikeout)
        bodyFont = New Font(familyName, 9.75F, FontStyle.Regular)
        memoFont = New Font(familyName, 9.0F, FontStyle.Regular)
    End Sub

    Private Sub DisposeRenderFonts()
        If timeFont IsNot Nothing Then timeFont.Dispose()
        If titleFont IsNot Nothing Then titleFont.Dispose()
        If titleStrikeoutFont IsNot Nothing Then titleStrikeoutFont.Dispose()
        If bodyFont IsNot Nothing Then bodyFont.Dispose()
        If memoFont IsNot Nothing Then memoFont.Dispose()
        timeFont = Nothing
        titleFont = Nothing
        titleStrikeoutFont = Nothing
        bodyFont = Nothing
        memoFont = Nothing
    End Sub
End Class
