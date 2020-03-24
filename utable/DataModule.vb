Imports System.Text.RegularExpressions

Module DataModule
    Dim defaultLoc As String = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\")) + "\default.utdata"

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
    Public Function getData(datastr As String, name As String)

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
            Return ErrorToString("{ERROR}")
        End If
    End Function

    Public Function multipleMidReturn(ByVal first As String, ByVal last As String, ByRef total As String) As List(Of String)
        If total.Contains(first) Then
            Dim tmptotal = total
            Dim res As New List(Of String)

ret:
            If tmptotal.Contains(first) = True Then
                Dim FirstStart As Long = tmptotal.IndexOf(first) + first.Length + 1
                res.Add(Trim(Mid$(tmptotal, FirstStart, tmptotal.Substring(FirstStart).IndexOf(last) + 1)))
                tmptotal = Mid(tmptotal, FirstStart, tmptotal.Length)
                GoTo ret
            End If

            Return res
        Else
            Return Nothing
        End If
    End Function

    Public Sub writeTable(data As String)
        My.Computer.FileSystem.WriteAllText(defaultLoc, data, False, System.Text.Encoding.GetEncoding(949))
    End Sub

    Public Function readTable()
        If My.Computer.FileSystem.FileExists(defaultLoc) Then
            'My.Settings.defalutTable = OptionSave()
            Return My.Computer.FileSystem.ReadAllText(defaultLoc, System.Text.Encoding.GetEncoding(949))
        Else
            Return ""
        End If
    End Function

End Module
