Imports System.IO
'Imports System.Text.RegularExpressions
'Imports System.Xml

Module DataModule
    'web에서 문자열 가져오는 함수
    Public Function webget(url As String)
        Dim source = New System.Net.WebClient()
        source.Encoding = System.Text.Encoding.UTF8
        'MsgBox(url)

        Dim sourcestr As String = Nothing
        sourcestr = source.DownloadString(url)

        Return sourcestr
    End Function

    'xml형식 파일을 전체값에서 따로 추출하는 함수
    Public Function getData(datastr As String, name As String) As String

        Return midReturn("<" + name + ">", "</" + name + ">", datastr)

    End Function

    Public Function getDatas(datastr As String, name As String) As List(Of String)

        Return multipleMidReturn("<" + name + ">", "</" + name + ">", datastr)

    End Function

    'HEX색상값을 RGB로 바꿔주는 함수
    Public Function ConvertToRbg(ByVal HexColor As String) As Color
        Dim Red As String
        Dim Green As String
        Dim Blue As String
        HexColor = Replace(HexColor, "#", "")
        Red = Val("&H" & Mid(HexColor, 1, 2))
        Green = Val("&H" & Mid(HexColor, 3, 2))
        Blue = Val("&H" & Mid(HexColor, 5, 2))
        Return Color.FromArgb(Red, Green, Blue)
    End Function

    '중간의 문자열을 리턴하는 함수
    Public Function midReturn(ByVal first As String, ByVal last As String, ByVal total As String) As String
        If total.Contains(first) Then
            Dim FirstStart As Long = total.IndexOf(first) + first.Length + 1
            Return Trim(Mid$(total, FirstStart, total.Substring(FirstStart).IndexOf(last) + 1))
        Else
            Return Nothing
        End If
    End Function

    '중간의 문자열을 여러개 List로 리턴하는 함수
    Public Function multipleMidReturn(ByVal first As String, ByVal last As String, ByRef total As String) As List(Of String)
        If total.Contains(first) Then
            Dim tmptotal = total
            Dim res As New List(Of String)

            While tmptotal.Contains(first) = True
                Dim FirstStart As Long = tmptotal.IndexOf(first) + first.Length + 1
                res.Add(Trim(Mid$(tmptotal, FirstStart, tmptotal.Substring(FirstStart).IndexOf(last) + 1)))
                tmptotal = Mid(tmptotal, FirstStart, tmptotal.Length)
            End While

            Return res
        Else
            Return Nothing
        End If
    End Function

    Public Sub writeTable(data As String)
        My.Computer.FileSystem.WriteAllText(TableSaveLocation(), data, False, System.Text.Encoding.GetEncoding(949))
    End Sub

    Public Function readTable() As String
        If My.Computer.FileSystem.FileExists(TableSaveLocation()) Then
            'My.Settings.defalutTable = OptionSave()
            Return My.Computer.FileSystem.ReadAllText(TableSaveLocation(), System.Text.Encoding.GetEncoding(949))
        Else
            Return ""
        End If
    End Function

    Public Function TableSaveLocation() As String
        Dim exeFullpath As String = Application.ExecutablePath
        Dim finalDir As String = exeFullpath.Substring(0, exeFullpath.LastIndexOf("\"))
        Dim finalName As String = "\default.utdata"

        '임의 경로 옵션 활성화시
        If GetINI("SETTING", "CustomSaveDir", "", ININamePath) = "1" Then
            Dim usrDir As String = GetINI("SETTING", "SaveDirectory", "", ININamePath)
            Dim usrSaveName As String = GetINI("SETTING", "SaveName", "", ININamePath)

            '사용자가 지정한 디렉토리가 존재할때
            If My.Computer.FileSystem.DirectoryExists(usrDir) Then
                finalDir = usrDir
                '존재 안함 -> 기본 디렉토리 (같은 폴더) 결정
            End If

            '파일명이 암것도 아닌게 아닐때
            If Not usrSaveName = "" Then
                finalName = "\" + usrSaveName + ".utdata"
            End If
        End If

        Return finalDir + finalName
    End Function

    Public Function FilenameIsOK(ByVal fileNameAndPath As String) As Boolean
        Try
            Dim fileName = Path.GetFileName(fileNameAndPath)
            Dim directory = Path.GetDirectoryName(fileNameAndPath)
            For Each c In Path.GetInvalidFileNameChars()
                If fileName.Contains(c) Then
                    Return False
                End If
            Next
            For Each c In Path.GetInvalidPathChars()
                If directory.Contains(c) Then
                    Return False
                End If
            Next
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function
End Module
