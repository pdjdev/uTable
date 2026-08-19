Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' 애플리케이션의 라이트 테마와 다크 테마에서 사용하는 색상 팔레트
''' </summary>
Public NotInheritable Class ThemeColors
    Public Shared ReadOnly Light As New ThemeColors(
        Color.FromArgb(250, 250, 250), Color.FromArgb(240, 240, 240), Color.FromArgb(220, 220, 220),
        Color.LightGray, Color.FromArgb(230, 230, 230), Color.FromArgb(250, 250, 250),
        Color.FromArgb(240, 240, 240), Color.FromArgb(64, 64, 64), Color.White, Color.Gray,
        Color.FromArgb(64, 64, 64), Color.White, Color.FromArgb(64, 64, 64))

    Public Shared ReadOnly Dark As New ThemeColors(
        Color.FromArgb(60, 60, 60), Color.FromArgb(70, 70, 70), Color.FromArgb(80, 80, 80),
        Color.FromArgb(45, 45, 45), Color.FromArgb(38, 38, 38), Color.FromArgb(55, 55, 55),
        Color.FromArgb(50, 50, 50), Color.FromArgb(50, 121, 192), Color.White, Color.LightGray,
        Color.FromArgb(250, 250, 250), Color.FromArgb(50, 50, 50), Color.FromArgb(250, 250, 250))

    Public ReadOnly Property Background As Color
    Public ReadOnly Property Button As Color
    Public ReadOnly Property ButtonHover As Color
    Public ReadOnly Property Edge As Color
    Public ReadOnly Property DragHandle As Color
    Public ReadOnly Property TablePrimary As Color
    Public ReadOnly Property TableAlternate As Color
    Public ReadOnly Property Accent As Color
    Public ReadOnly Property AccentText As Color
    Public ReadOnly Property Text As Color
    Public ReadOnly Property TextMuted As Color
    Public ReadOnly Property Border As Color
    Public ReadOnly Property TabActive As Color

    Private Sub New(background As Color, button As Color, buttonHover As Color, edge As Color,
                    dragHandle As Color, tablePrimary As Color, tableAlternate As Color,
                    accent As Color, accentText As Color, textMuted As Color, text As Color, border As Color,
                    tabActive As Color)
        Me.Background = background
        Me.Button = button
        Me.ButtonHover = buttonHover
        Me.Edge = edge
        Me.DragHandle = dragHandle
        Me.TablePrimary = tablePrimary
        Me.TableAlternate = tableAlternate
        Me.Accent = accent
        Me.AccentText = accentText
        Me.TextMuted = textMuted
        Me.Text = text
        Me.Border = border
        Me.TabActive = tabActive
    End Sub

    Public Shared Function FromMode(mode As String) As ThemeColors
        Return If(String.Equals(mode, "Dark", System.StringComparison.OrdinalIgnoreCase), Dark, Light)
    End Function
End Class

''' <summary>
''' 활성 애플리케이션 팔레트를 사용하여 ToolStrip 메뉴의 모든 계층을 그립니다
''' Windows 시스템 렌더러는 드롭다운 메뉴의 BackColor/ForeColor를 무시합니다
''' </summary>
Public NotInheritable Class MenuThemeRenderer
    Inherits ToolStripProfessionalRenderer

    Public Sub New(theme As ThemeColors)
        MyBase.New(New MenuColorTable(theme))
    End Sub

    Public Shared Sub Apply(menu As ContextMenuStrip, theme As ThemeColors)
        Dim renderer As New MenuThemeRenderer(theme)
        ApplyToStrip(menu, renderer, theme)
    End Sub

    Private Shared Sub ApplyToStrip(menu As ToolStrip, renderer As ToolStripRenderer, theme As ThemeColors)
        menu.Renderer = renderer
        menu.BackColor = theme.Background
        menu.ForeColor = theme.Text

        For Each item As ToolStripItem In menu.Items
            item.ForeColor = theme.Text

            'ToolStripComboBox는 호스트 항목과 실제 ComboBox의 색상이 별도로 관리된다.
            '호스트의 ForeColor만 변경하면 다크 모드에서 드롭다운은 흰 배경을 유지해
            '목록 글자가 보이지 않게 된다.
            Dim comboBoxItem As ToolStripComboBox = TryCast(item, ToolStripComboBox)
            If comboBoxItem IsNot Nothing Then
                comboBoxItem.BackColor = theme.Background
                comboBoxItem.ForeColor = theme.Text
                comboBoxItem.ComboBox.BackColor = theme.Background
                comboBoxItem.ComboBox.ForeColor = theme.Text
            End If

            Dim menuItem As ToolStripMenuItem = TryCast(item, ToolStripMenuItem)
            If menuItem IsNot Nothing AndAlso menuItem.HasDropDownItems Then
                ApplyToStrip(menuItem.DropDown, renderer, theme)
            End If
        Next
    End Sub

    Private NotInheritable Class MenuColorTable
        Inherits ProfessionalColorTable

        Private ReadOnly theme As ThemeColors

        Public Sub New(theme As ThemeColors)
            Me.theme = theme
            UseSystemColors = False
        End Sub

        Public Overrides ReadOnly Property ToolStripDropDownBackground As Color
            Get
                Return theme.Background
            End Get
        End Property

        Public Overrides ReadOnly Property MenuBorder As Color
            Get
                Return theme.Border
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemBorder As Color
            Get
                Return theme.Border
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemSelected As Color
            Get
                Return theme.ButtonHover
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemSelectedGradientBegin As Color
            Get
                Return theme.ButtonHover
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemSelectedGradientEnd As Color
            Get
                Return theme.ButtonHover
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemPressedGradientBegin As Color
            Get
                Return theme.Button
            End Get
        End Property

        Public Overrides ReadOnly Property MenuItemPressedGradientEnd As Color
            Get
                Return theme.Button
            End Get
        End Property

        Public Overrides ReadOnly Property SeparatorDark As Color
            Get
                Return theme.ButtonHover
            End Get
        End Property

        Public Overrides ReadOnly Property SeparatorLight As Color
            Get
                Return theme.ButtonHover
            End Get
        End Property

        Public Overrides ReadOnly Property ImageMarginGradientBegin As Color
            Get
                Return theme.Background
            End Get
        End Property

        Public Overrides ReadOnly Property ImageMarginGradientMiddle As Color
            Get
                Return theme.Background
            End Get
        End Property

        Public Overrides ReadOnly Property ImageMarginGradientEnd As Color
            Get
                Return theme.Background
            End Get
        End Property
    End Class
End Class
