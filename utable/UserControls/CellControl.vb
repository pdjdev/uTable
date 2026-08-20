Imports System.Drawing.Text
Imports System.Drawing.Imaging
Imports System.Diagnostics

Public Class CellControl
    Public defHeight As Integer = 0
    Public defLoc As Integer = 0
    Public StartMinutes As Integer = 0
    Public checked As Boolean = False
    Public dayNum As Integer = 0

    Public StartText As String = ""
    Public EndText As String = ""
    Public CourseTitle As String = ""
    Public ProfessorText As String = ""
    Public MemoText As String = ""

    Public Property Settings As New CellControlSettings()
    Public Property IsDemo As Boolean = False
    Public UsesSharedFadeClock As Boolean = False
    Public goalColor As Color = Nothing
    Public Event FadeStarted As EventHandler
    Public Event HoverEnded As EventHandler

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
            Return ScaleValue(3)
        End Get
    End Property

    Private ReadOnly Property CheckSize As Integer
        Get
            Return ScaleValue(20)
        End Get
    End Property

    Private blackText As Boolean = False
    Private hovered As Boolean = False
    Public ReadOnly Property IsHovered As Boolean
        Get
            Return hovered
        End Get
    End Property
    Private checkHovered As Boolean = False
    Private checkPressed As Boolean = False
    Private titleHovered As Boolean = False
    Private fadeInProgress As Boolean = False
    Private deltaColor_R As Integer = 1
    Private deltaColor_G As Integer = 1
    Private deltaColor_B As Integer = 1
    Private goalTextColor As Color = Color.Empty
    Private deltaTextColor_R As Integer = 1
    Private deltaTextColor_G As Integer = 1
    Private deltaTextColor_B As Integer = 1
    Private checkBoxFadeAlpha As Byte = 255
    Private checkBoxFadeAlphaStep As Integer = 26
    Private titleBounds As Rectangle = Rectangle.Empty
    Private titleHoverBounds As Rectangle = Rectangle.Empty

    Private Const HoverAnimationDurationMilliseconds As Integer = 180
    Private ReadOnly hoverAnimationTimer As New Timer With {.Interval = 10}
    Private ReadOnly hoverAnimationClock As New Stopwatch()
    Private hoverAnimationStartBounds As Rectangle
    Private hoverAnimationTargetBounds As Rectangle

    Private timeFont As Font
    Private titleFont As Font
    Private titleStrikeoutFont As Font
    Private bodyFont As Font
    Private memoFont As Font

    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        AddHandler hoverAnimationTimer.Tick, AddressOf HoverAnimationTimer_Tick
    End Sub

    Private Sub CellControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Settings.AutoTextColor Then
            blackText = CheckProperColor(goalColor)
        Else
            blackText = Settings.BlackText
        End If

        ForeColor = If(blackText, Color.Black, Color.White)
        CreateRenderFonts()

        If Settings.AlwaysExpand Then ForceExpand()

        If Settings.FadeEffect AndAlso UsesSharedFadeClock Then
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
        'ClearType 대신 가독성 좋은 AntiAliasGridFit 사용
        e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit

        Using notchBrush As New SolidBrush(ControlPaint.Light(BackColor, 0.3))
            e.Graphics.FillRectangle(notchBrush, New Rectangle(0, 0, ClientSize.Width, NotchHeight))
        End Using

        Dim contentWidth As Integer = Math.Max(1, ClientSize.Width - HorizontalPadding * 2)
        Dim y As Integer = NotchHeight + VerticalPadding
        Dim checkBounds As New Rectangle(HorizontalPadding, y, CheckSize, CheckSize)
        Dim timeX As Integer = HorizontalPadding

        If Settings.ShowCheckBox Then
            DrawCheckBox(e.Graphics, checkBounds)
            timeX += CheckSize + 3
        End If

        Using leftFormat As New StringFormat(StringFormatFlags.NoWrap), textBrush As New SolidBrush(ForeColor)
            leftFormat.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(StartText, timeFont, textBrush, New RectangleF(timeX, y, Math.Max(1, ClientSize.Width - timeX - HorizontalPadding), CheckSize), leftFormat)
        End Using

        y += Math.Max(CheckSize, timeFont.Height) + VerticalPadding
        titleBounds = New Rectangle(HorizontalPadding, y, contentWidth, MeasureTextHeight(e.Graphics, CourseTitle, titleFont, contentWidth))
        titleHoverBounds = titleBounds

        If titleHovered Then
            Using titleHoverBrush As New SolidBrush(ControlPaint.Light(BackColor, 0.25))
                e.Graphics.FillRectangle(titleHoverBrush, titleHoverBounds)
            End Using
        End If

        DrawWrappedText(e.Graphics, CourseTitle, If(checked, titleStrikeoutFont, titleFont), titleBounds)
        y += titleBounds.Height

        If Settings.ShowProfessor AndAlso Not String.IsNullOrEmpty(ProfessorText) Then
            Dim professorBounds As New Rectangle(HorizontalPadding, y, contentWidth, MeasureTextHeight(e.Graphics, ProfessorText, bodyFont, contentWidth))
            DrawWrappedText(e.Graphics, ProfessorText, bodyFont, professorBounds)
            y += professorBounds.Height
        End If

        If Settings.ShowMemo AndAlso Not String.IsNullOrEmpty(MemoText) Then
            Dim memoBounds As New Rectangle(HorizontalPadding, y, contentWidth, MeasureTextHeight(e.Graphics, MemoText, memoFont, contentWidth))
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
        checkHovered = Settings.ShowCheckBox AndAlso New Rectangle(HorizontalPadding, NotchHeight + VerticalPadding, CheckSize, CheckSize).Contains(mouseLocation)
        titleHovered = titleHoverBounds.Contains(mouseLocation)
        SetHovered(True)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)

        '위쪽으로 확장되는 셀을 이동하면 새로 계산된 영역 안에 포인터가 있어도
        'WinForms가 MouseLeave를 발생시킬 수 있음
        If ClientRectangle.Contains(PointToClient(Cursor.Position)) Then Return

        checkHovered = False
        checkPressed = False
        titleHovered = False
        SetHovered(False)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim newCheckHovered As Boolean = Settings.ShowCheckBox AndAlso New Rectangle(HorizontalPadding, NotchHeight + VerticalPadding, CheckSize, CheckSize).Contains(e.Location)
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
        If Settings.ShowCheckBox AndAlso checkBounds.Contains(e.Location) Then
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
        If Settings.ShowCheckBox AndAlso (checkBounds.Contains(e.Location) OrElse e.Location.Y < titleBounds.Top) Then
            ToggleCheck()
        ElseIf titleBounds.Contains(e.Location) Then
            OpenCourseDetails()
        ElseIf Settings.ShowCheckBox Then
            ToggleCheck()
        End If
    End Sub

    Private Sub SetHovered(value As Boolean)
        If hovered = value Then Return
        hovered = value

        If hovered Then
            BringToFront()
        End If

        If Settings.ExpandOnHover OrElse Settings.AlwaysExpand Then
            '항상 확장 상태도 평소에는 실제 시작 시간(defLoc)을 유지하고,
            '호버 중에만 시간표 하단을 넘는 경우 위쪽으로 이동한다.
            Dim targetBounds As Rectangle = If(hovered,
                                               GetExpandedBounds(),
                                               If(Settings.AlwaysExpand, GetAlwaysExpandedBounds(), GetDefaultBounds()))
            If Settings.ExpandAnimation Then
                StartHoverAnimation(targetBounds)
            Else
                hoverAnimationTimer.Stop()
                Dim previousBounds As Rectangle = Bounds
                Bounds = targetBounds
                If Parent IsNot Nothing Then
                    Parent.Invalidate(Rectangle.Union(previousBounds, Bounds), True)
                End If
                If Not hovered Then RaiseEvent HoverEnded(Me, EventArgs.Empty)
            End If
        ElseIf Not hovered Then
            RaiseEvent HoverEnded(Me, EventArgs.Empty)
        End If

        Invalidate()
    End Sub

    Private Function GetDefaultBounds() As Rectangle
        Return New Rectangle(0, defLoc, Width, defHeight)
    End Function

    Private Function GetExpandedBounds() As Rectangle
        Dim fullHeight As Integer = GetRequiredHeight()
        Dim defaultBounds As Rectangle = GetDefaultBounds()

        If defaultBounds.Height >= fullHeight Then Return defaultBounds

        Dim parentHeight As Integer = If(Parent Is Nothing, defaultBounds.Bottom, Parent.ClientSize.Height)
        Dim targetY As Integer = defaultBounds.Y
        If defaultBounds.Bottom - defaultBounds.Height + fullHeight > parentHeight Then
            targetY = Math.Max(0, parentHeight - fullHeight)
        End If

        Return New Rectangle(0, targetY, defaultBounds.Width, fullHeight)
    End Function

    Private Function GetAlwaysExpandedBounds() As Rectangle
        Dim defaultBounds As Rectangle = GetDefaultBounds()
        Return New Rectangle(0, defaultBounds.Y, defaultBounds.Width, Math.Max(defaultBounds.Height, GetRequiredHeight()))
    End Function

    Private Sub StartHoverAnimation(targetBounds As Rectangle)
        If Bounds = targetBounds Then
            hoverAnimationTimer.Stop()
            If Not hovered Then RaiseEvent HoverEnded(Me, EventArgs.Empty)
            Return
        End If

        hoverAnimationStartBounds = Bounds
        hoverAnimationTargetBounds = targetBounds
        hoverAnimationClock.Restart()
        hoverAnimationTimer.Start()
    End Sub

    Private Sub HoverAnimationTimer_Tick(sender As Object, e As EventArgs)
        Dim progress As Double = Math.Min(1.0, hoverAnimationClock.Elapsed.TotalMilliseconds / HoverAnimationDurationMilliseconds)
        'Smoothstep: 양 끝에서 속도가 0이 되는 ease-in-out 보간
        Dim easedProgress As Double = progress * progress * (3.0 - 2.0 * progress)
        Dim previousBounds As Rectangle = Bounds
        Dim nextBounds As Rectangle = InterpolateBounds(hoverAnimationStartBounds, hoverAnimationTargetBounds, easedProgress)

        If previousBounds <> nextBounds Then
            Bounds = nextBounds
            Invalidate()
            If Parent IsNot Nothing Then
                Parent.Invalidate(Rectangle.Union(previousBounds, nextBounds), True)
            End If
        End If

        If progress >= 1.0 Then
            hoverAnimationTimer.Stop()
            If Not hovered Then RaiseEvent HoverEnded(Me, EventArgs.Empty)
        End If
    End Sub

    Private Function InterpolateBounds(fromBounds As Rectangle, toBounds As Rectangle, progress As Double) As Rectangle
        Return New Rectangle(InterpolateValue(fromBounds.X, toBounds.X, progress),
                             InterpolateValue(fromBounds.Y, toBounds.Y, progress),
                             InterpolateValue(fromBounds.Width, toBounds.Width, progress),
                             InterpolateValue(fromBounds.Height, toBounds.Height, progress))
    End Function

    Private Function InterpolateValue(fromValue As Integer, toValue As Integer, progress As Double) As Integer
        Return CInt(Math.Round(fromValue + (toValue - fromValue) * progress))
    End Function

    Public Sub ForceExpand()
        hoverAnimationTimer.Stop()
        Dim expandedBounds As Rectangle = GetAlwaysExpandedBounds()
        If Bounds <> expandedBounds Then
            Dim previousBounds As Rectangle = Bounds
            Bounds = expandedBounds
            If Parent IsNot Nothing Then
                Parent.Invalidate(Rectangle.Union(previousBounds, Bounds), True)
            End If
        End If
    End Sub

    Protected Overrides Sub OnHandleDestroyed(e As EventArgs)
        hoverAnimationTimer.Stop()
        MyBase.OnHandleDestroyed(e)
    End Sub

    Private Sub ToggleCheck()
        checked = Not checked
        If Not IsDemo Then ModifyCheck(checked)
        Invalidate()
    End Sub

    Private Sub OpenCourseDetails()
        If IsDemo Then Return

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

        Using graphics As Graphics = CreateGraphics()
            result += MeasureTextHeight(graphics, CourseTitle, titleFont, contentWidth)
            If Settings.ShowProfessor Then result += MeasureTextHeight(graphics, ProfessorText, bodyFont, contentWidth)
            If Settings.ShowMemo Then result += MeasureTextHeight(graphics, MemoText, memoFont, contentWidth)
        End Using

        result += timeFont.Height + VerticalPadding
        Return result
    End Function

    Private Function MeasureTextHeight(graphics As Graphics, value As String, fontToMeasure As Font, width As Integer) As Integer
        If String.IsNullOrEmpty(value) Then Return 0

        Using textFormat As StringFormat = CreateWrappedTextFormat()
            Return CInt(Math.Ceiling(graphics.MeasureString(value, fontToMeasure, Math.Max(1, width), textFormat).Height))
        End Using
    End Function

    Private Sub DrawWrappedText(graphics As Graphics, value As String, fontToDraw As Font, bounds As Rectangle)
        If String.IsNullOrEmpty(value) OrElse bounds.Height <= 0 Then Return

        Using textBrush As New SolidBrush(ForeColor), textFormat As StringFormat = CreateWrappedTextFormat()
            graphics.DrawString(value, fontToDraw, textBrush, bounds, textFormat)
        End Using
    End Sub

    Private Shared Function CreateWrappedTextFormat() As StringFormat
        Dim textFormat As New StringFormat()
        textFormat.Trimming = StringTrimming.EllipsisCharacter
        Return textFormat
    End Function

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

        If checkBoxFadeAlpha = 255 Then
            graphics.DrawImage(image, bounds)
            Return
        End If

        Using imageAttributes As New ImageAttributes()
            Dim colorMatrix As New ColorMatrix()
            colorMatrix.Matrix33 = checkBoxFadeAlpha / 255.0F
            imageAttributes.SetColorMatrix(colorMatrix)
            graphics.DrawImage(image, bounds, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes)
        End Using
    End Sub

    Public Sub ModifyCheck(value As Boolean)
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
        deltaColor_R = CalculateFadeStep(BackColor.R, goalColor.R)
        deltaColor_G = CalculateFadeStep(BackColor.G, goalColor.G)
        deltaColor_B = CalculateFadeStep(BackColor.B, goalColor.B)

        '텍스트는 초기 배경색에서 최종 글자색으로 함께 전환한다.
        goalTextColor = If(blackText, Color.Black, Color.White)
        ForeColor = BackColor
        deltaTextColor_R = CalculateFadeStep(ForeColor.R, goalTextColor.R)
        deltaTextColor_G = CalculateFadeStep(ForeColor.G, goalTextColor.G)
        deltaTextColor_B = CalculateFadeStep(ForeColor.B, goalTextColor.B)
        checkBoxFadeAlpha = 0
        checkBoxFadeAlphaStep = CInt(Math.Ceiling(255 / 10.0))

        fadeInProgress = True
        RaiseEvent FadeStarted(Me, EventArgs.Empty)
    End Sub

    Public Function AdvanceFade() As Boolean
        If Not fadeInProgress Then Return False

        Dim red As Byte = MoveToward(BackColor.R, goalColor.R, deltaColor_R)
        Dim green As Byte = MoveToward(BackColor.G, goalColor.G, deltaColor_G)
        Dim blue As Byte = MoveToward(BackColor.B, goalColor.B, deltaColor_B)
        Dim nextBackColor As Color = Color.FromArgb(red, green, blue)
        Dim backgroundChanged As Boolean = (BackColor.ToArgb() <> nextBackColor.ToArgb())
        If backgroundChanged Then BackColor = nextBackColor

        Dim textRed As Byte = MoveToward(ForeColor.R, goalTextColor.R, deltaTextColor_R)
        Dim textGreen As Byte = MoveToward(ForeColor.G, goalTextColor.G, deltaTextColor_G)
        Dim textBlue As Byte = MoveToward(ForeColor.B, goalTextColor.B, deltaTextColor_B)
        Dim nextForeColor As Color = Color.FromArgb(textRed, textGreen, textBlue)
        Dim textChanged As Boolean = (ForeColor.ToArgb() <> nextForeColor.ToArgb())
        If textChanged Then ForeColor = nextForeColor

        Dim previousCheckBoxFadeAlpha As Byte = checkBoxFadeAlpha
        checkBoxFadeAlpha = CByte(Math.Min(255, CInt(checkBoxFadeAlpha) + checkBoxFadeAlphaStep))

        Dim backgroundComplete As Boolean = (red = goalColor.R AndAlso green = goalColor.G AndAlso blue = goalColor.B)
        Dim textComplete As Boolean = (textRed = goalTextColor.R AndAlso textGreen = goalTextColor.G AndAlso textBlue = goalTextColor.B)
        fadeInProgress = Not (backgroundComplete AndAlso textComplete AndAlso checkBoxFadeAlpha = 255)

        'BackColor/ForeColor 변경은 컨트롤 자체를 무효화한다. 체크박스 알파만 바뀐 경우만 직접 요청한다.
        If Not backgroundChanged AndAlso
           Not textChanged AndAlso
           previousCheckBoxFadeAlpha <> checkBoxFadeAlpha Then
            Invalidate()
        End If
        Return fadeInProgress
    End Function

    Private Shared Function CalculateFadeStep(currentValue As Byte, targetValue As Byte) As Integer
        Dim distance As Integer = Math.Abs(CInt(targetValue) - CInt(currentValue))
        If distance = 0 Then Return 0
        Return Math.Max(1, CInt(Math.Ceiling(distance / 10.0)))
    End Function

    Private Function MoveToward(currentValue As Byte, targetValue As Byte, delta As Integer) As Byte
        If currentValue = targetValue Then Return targetValue

        '잘못된 호출에서 delta가 0이어도 애니메이션이 영원히 멈춰 있지 않게 한다.
        Dim safeDelta As Integer = Math.Max(1, delta)
        If currentValue < targetValue Then
            Return CByte(Math.Min(CInt(targetValue), CInt(currentValue) + safeDelta))
        End If
        Return CByte(Math.Max(CInt(targetValue), CInt(currentValue) - safeDelta))
    End Function

    Private Function ScaleValue(value As Integer) As Integer
        Return Math.Max(1, CInt(Math.Round(value * DeviceDpi / 96.0)))
    End Function

    Private Sub EnsureRenderFonts()
        If timeFont Is Nothing Then CreateRenderFonts()
    End Sub

    Private Sub CreateRenderFonts()
        DisposeRenderFonts()
        Dim familyName As String = If(Settings.UseCustomFont AndAlso Not String.IsNullOrWhiteSpace(Settings.CustomFontName), Settings.CustomFontName, Font.FontFamily.Name)
        timeFont = New Font(familyName, 9.75F, FontStyle.Bold)
        titleFont = New Font(familyName, 11.0F, FontStyle.Bold)
        titleStrikeoutFont = New Font(familyName, 11.0F, FontStyle.Bold Or FontStyle.Strikeout)
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
