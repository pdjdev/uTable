Imports System.Runtime.InteropServices

Module GUIModule

#Region "Aero 그림자 효과 (Vista이상)"
    Structure MARGINS
        Public Left, Right, Top, Bottom As Integer
    End Structure

    <DllImport("dwmapi.dll", PreserveSig:=True)>
    Private Function DwmSetWindowAttribute(hwnd As IntPtr, attr As Integer, ByRef attrValue As Integer, attrSize As Integer) As Integer
    End Function

    <DllImport("dwmapi.dll")>
    Private Function DwmExtendFrameIntoClientArea(hWnd As IntPtr, ByRef pMarInset As MARGINS) As Integer
    End Function

    Public Function CreateDropShadow(form As Form) As Boolean
        Try
            Dim val As Integer = 2
            Dim ret1 As Integer = DwmSetWindowAttribute(form.Handle, 2, val, 4)

            If ret1 = 0 Then
                Dim m As MARGINS = New MARGINS() With {
                            .Left = 0,
                            .Right = 0,
                            .Top = 1,
                            .Bottom = 0
                        }

                Dim ret2 As Integer = DwmExtendFrameIntoClientArea(form.Handle, m)
                Return ret2 = 0
            Else
                Return False
            End If
        Catch ex As Exception
            'dwmapi.dll 없음
            Return False
        End Try
    End Function

#End Region

#Region "DPI 계산 (고해상도 디스플레이용)"
    Public Function dpicalc(targetform As Form, size As Integer) As Integer
        Dim g As Graphics = targetform.CreateGraphics
        Dim dpi = g.DpiX.ToString()

        Dim current = dpi / 96
        Dim expand = current * size

        Return expand
    End Function
#End Region

#Region "창붙기 효과"
    Private Const mSnapOffset As Integer = 35
    Private Const WM_WINDOWPOSCHANGING As Integer = &H46

    <StructLayout(LayoutKind.Sequential)>
    Public Structure WINDOWPOS
        Public hwnd As IntPtr
        Public hwndInsertAfter As IntPtr
        Public x As Integer
        Public y As Integer
        Public cx As Integer
        Public cy As Integer
        Public flags As Integer
    End Structure

    Public Sub SnapToDesktopBorder(ByVal clientForm As Form, ByVal LParam As IntPtr, ByVal widthAdjustment As Integer)

        If clientForm Is Nothing Then
            ' Satisfies rule: Validate parameters
            Throw New ArgumentNullException("clientForm")
        End If

        ' Snap client to the top, left, bottom or right desktop border
        ' as the form is moved near that border.

        Try
            ' Marshal the LPARAM value which is a WINDOWPOS struct
            Dim NewPosition As New WINDOWPOS
            NewPosition = CType(Runtime.InteropServices.Marshal.PtrToStructure(
                LParam, GetType(WINDOWPOS)), WINDOWPOS)

            If NewPosition.y = 0 OrElse NewPosition.x = 0 Then
                Return ' Nothing to do!
            End If

            ' Adjust the client size for borders and caption bar
            Dim ClientRect As Rectangle =
                clientForm.RectangleToScreen(clientForm.ClientRectangle)
            ClientRect.Width +=
                SystemInformation.FrameBorderSize.Width - widthAdjustment - dpicalc(clientForm, 8)
            ClientRect.Height += (SystemInformation.FrameBorderSize.Height +
                                  SystemInformation.CaptionHeight - dpicalc(clientForm, 31))
            ' 임의로 포인트 변경

            ' Now get the screen working area (without taskbar)
            Dim WorkingRect As Rectangle =
                Screen.GetWorkingArea(clientForm.ClientRectangle)

            ' Left border
            If NewPosition.x >= WorkingRect.X - mSnapOffset AndAlso
                NewPosition.x <= WorkingRect.X + mSnapOffset Then
                NewPosition.x = WorkingRect.X
            End If

            ' Get screen bounds and taskbar height
            ' (when taskbar is horizontal)
            Dim ScreenRect As Rectangle =
                Screen.GetBounds(Screen.PrimaryScreen.Bounds)
            Dim TaskbarHeight As Integer =
                ScreenRect.Height - WorkingRect.Height

            ' Top border (check if taskbar is on top
            ' or bottom via WorkingRect.Y)
            If NewPosition.y >= -mSnapOffset AndAlso
                 (WorkingRect.Y > 0 AndAlso NewPosition.y <=
                 (TaskbarHeight + mSnapOffset)) OrElse
                 (WorkingRect.Y <= 0 AndAlso NewPosition.y <=
                 (mSnapOffset)) Then
                If TaskbarHeight > 0 Then
                    NewPosition.y = WorkingRect.Y ' Horizontal Taskbar
                Else
                    NewPosition.y = 0 ' Vertical Taskbar
                End If
            End If

            ' Right border
            If NewPosition.x + ClientRect.Width <=
                 WorkingRect.Right + mSnapOffset AndAlso
                 NewPosition.x + ClientRect.Width >=
                 WorkingRect.Right - mSnapOffset Then
                NewPosition.x = WorkingRect.Right - (ClientRect.Width +
                                SystemInformation.FrameBorderSize.Width)
            End If

            ' Bottom border
            If NewPosition.y + ClientRect.Height <=
                   WorkingRect.Bottom + mSnapOffset AndAlso
                   NewPosition.y + ClientRect.Height >=
                   WorkingRect.Bottom - mSnapOffset Then
                NewPosition.y = WorkingRect.Bottom - (ClientRect.Height +
                                SystemInformation.FrameBorderSize.Height)
            End If

            ' Marshal it back
            Runtime.InteropServices.Marshal.StructureToPtr(NewPosition,
                                                           LParam, True)
        Catch ex As ArgumentException
        End Try
    End Sub

#End Region

#Region "멀티 모니터 관리"
    Public Function IsOnScreen(ByVal form As Form) As Boolean
        Dim screens() As Screen = Screen.AllScreens

        For Each scrn As Screen In screens
            Dim formRectangle As Rectangle = New Rectangle(form.Left, form.Top, form.Width, form.Height)

            If scrn.WorkingArea.Contains(formRectangle) Then
                Return True
            End If
        Next

        Return False
    End Function
#End Region

#Region "컬러 관리"
    Public Function mainColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(60, 60, 60)
            Case Else
                Return Color.FromArgb(250, 250, 250)
        End Select

    End Function

    Public Function buttonColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(70, 70, 70)
            Case Else
                Return Color.FromArgb(240, 240, 240)
        End Select

    End Function

    Public Function buttonActiveColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(80, 80, 80)
            Case Else
                Return Color.FromArgb(220, 220, 220)
        End Select

    End Function

    Public Function edgeColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(45, 45, 45)
            Case Else
                Return Color.LightGray
        End Select

    End Function

    Public Function dragBarColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(38, 38, 38)
            Case Else
                Return Color.FromArgb(230, 230, 230)
        End Select

    End Function

    Public Function tableColor_1(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(55, 55, 55)
            Case Else
                Return Color.FromArgb(250, 250, 250)
        End Select

    End Function

    Public Function tableColor_2(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(50, 50, 50)
            Case Else
                Return Color.FromArgb(240, 240, 240)
        End Select

    End Function

    Public Function activeDayColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(50, 121, 192)
            Case Else
                Return Color.FromArgb(64, 64, 64)
        End Select

    End Function

    Public Function activeDayTextColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.White
            Case Else
                Return Color.White
        End Select

    End Function

    Public Function textColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(250, 250, 250)
            Case Else
                Return Color.FromArgb(64, 64, 64)
        End Select

    End Function

    Public Function lightTextColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.LightGray
            Case Else
                Return Color.Gray
        End Select

    End Function

    Public Function BorderColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(50, 50, 50)
            Case Else
                Return Color.White
        End Select

    End Function

    Public Function UnfocusedTabColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(150, 150, 150)
            Case Else
                Return Color.FromArgb(150, 150, 150)
        End Select

    End Function

    Public Function FocusedTabColor(mode As String) As Color
        Select Case mode
            Case "Dark"
                Return Color.FromArgb(250, 250, 250)
            Case Else
                Return Color.FromArgb(64, 64, 64)
        End Select

    End Function

    ' 색을 기반으로 흰색이 적합한지 검은색이 적합한지 판별
    ' https://stackoverflow.com/a/1855903
    Public Function CheckProperColor(ByVal color As Color) As Boolean
        Dim d As Integer = 0
        Dim luminance As Double = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255

        Return luminance > 0.5
    End Function

#End Region

    Public Function GetAll(ByVal control As Control, ByVal type As Type) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAll(ctrl, type)).Concat(controls).Where(Function(c) c.[GetType]() = type)
    End Function


#Region "창 페이드 인/아웃 효과"
    Public Sub FadeIn(Form As Form, goalopacity As Double)
        Form.Opacity = 0

        If Not GetINI("SETTING", "FadeEffect", "", ININamePath) = "0" Then
            Do While Form.Opacity < goalopacity - 0.1
                Form.Opacity += 0.1
                Threading.Thread.Sleep(10)
            Loop
        End If

        Form.Opacity = goalopacity
    End Sub

    Public Sub FadeOut(Form As Form)

        If Not GetINI("SETTING", "FadeEffect", "", ININamePath) = "0" Then
            Do While Not Form.Opacity = 0
                Form.Opacity = Form.Opacity - 0.1
                Threading.Thread.Sleep(10)
            Loop
        End If

    End Sub
#End Region


#Region "폰트 모듈"
    Public Sub ChangeToCustomFont(targetForm As Form, fontName As String)
        ChangeFontName(targetForm, New Font(fontName, 10))
    End Sub

    Public Sub ChangeFontName(ByVal aForm As Form, ByVal aFont As Font)

        For Each frm As Form In My.Application.OpenForms
            If frm.HasChildren = True Then
                For Each ctrl As Control In frm.Controls
                    ChangeFontName(ctrl, aFont)
                Next
            End If
        Next

        If aForm.IsMdiContainer = True Then
            For Each frm As Form In aForm.MdiChildren
                If frm.HasChildren = True Then
                    For Each ctrl As Control In frm.Controls
                        ChangeFontName(ctrl, aFont)
                    Next
                End If
            Next
        End If

    End Sub

    Public Sub ChangeFontName(ByVal aControl As Control, ByVal aFont As Font)

        If aControl.HasChildren = True Then
            For Each ctrl As Control In aControl.Controls
                ctrl.Font = New Font(aFont.Name, ctrl.Font.Size, ctrl.Font.Style, ctrl.Font.Unit, ctrl.Font.GdiCharSet, ctrl.Font.GdiVerticalFont)
                ChangeFontName(ctrl, aFont)
            Next
        End If

    End Sub

    Public Function GetStringSize(aControl As Control) As SizeF

        Return aControl.CreateGraphics.MeasureString(aControl.Text, aControl.Font)

    End Function
#End Region


End Module
