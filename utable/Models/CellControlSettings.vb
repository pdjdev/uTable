Public Class CellControlSettings
    Public Property FadeEffect As Boolean = True
    Public Property UseCustomFont As Boolean = False
    Public Property CustomFontName As String = ""
    Public Property AutoTextColor As Boolean = True
    Public Property BlackText As Boolean = False
    Public Property AlwaysExpand As Boolean = False
    Public Property ExpandOnHover As Boolean = True
    Public Property ExpandAnimation As Boolean = True
    Public Property ShowMemo As Boolean = True
    Public Property ShowProfessor As Boolean = True
    Public Property ShowCheckBox As Boolean = True

    Public Shared Function FromIni() As CellControlSettings
        Return New CellControlSettings With {
            .FadeEffect = ReadEnabled("FadeEffect", True),
            .UseCustomFont = ReadEnabled("CustomFont", False),
            .CustomFontName = GetINI("SETTING", "CustomFontName", "", ININamePath),
            .AutoTextColor = ReadEnabled("AutoTextColor", True),
            .BlackText = ReadEnabled("BlackText", False),
            .AlwaysExpand = ReadEnabled("AlwaysExpand", False),
            .ExpandOnHover = ReadEnabled("ExpandCell", True),
            .ExpandAnimation = ReadEnabled("ExpandAnimation", True),
            .ShowMemo = ReadEnabled("ShowMemo", True),
            .ShowProfessor = ReadEnabled("ShowProf", True),
            .ShowCheckBox = ReadEnabled("ShowChkBox", True)
        }
    End Function

    Private Shared Function ReadEnabled(settingName As String, defaultValue As Boolean) As Boolean
        Dim value As String = GetINI("SETTING", settingName, "", ININamePath)
        If String.IsNullOrWhiteSpace(value) Then Return defaultValue
        Return value <> "0"
    End Function
End Class
