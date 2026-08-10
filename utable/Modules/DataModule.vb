Imports System.IO
Imports System.Security
Imports System.Web
Imports System.Xml
Imports System.Xml.Linq

Friend Class ReleaseFeedEntry
    Public Property Title As String
    Public Property ContentHtml As String
End Class

Module DataModule
    Private Const TableFragmentRootName As String = "utable-fragment"

    '시간표 파일은 하위 호환성을 위해 루트 없는 XML fragment로 저장한다.
    '파싱할 때만 임시 루트를 붙여 표준 XML 파서에 전달한다.
    Private Function ParseTableFragment(fragment As String) As XDocument
        If fragment Is Nothing Then fragment = ""

        Dim settings As New XmlReaderSettings With {
            .DtdProcessing = DtdProcessing.Prohibit,
            .XmlResolver = Nothing,
            .IgnoreWhitespace = False
        }

        Using input As New StringReader("<" + TableFragmentRootName + ">" + fragment + "</" + TableFragmentRootName + ">")
            Using reader As XmlReader = XmlReader.Create(input, settings)
                Return XDocument.Load(reader, LoadOptions.PreserveWhitespace)
            End Using
        End Using
    End Function

    Private Function SerializeTableFragment(document As XDocument) As String
        Return String.Concat(document.Root.Nodes().Select(Function(node) node.ToString(SaveOptions.DisableFormatting))).Trim()
    End Function

    Private Function GetElementInnerXml(element As XElement) As String
        Return String.Concat(element.Nodes().Select(Function(node) node.ToString(SaveOptions.DisableFormatting)))
    End Function

    '시간표 XML fragment에서 최상위 태그의 내용을 추출한다.
    Public Function getTableData(datastr As String, name As String) As String
        Dim element As XElement = ParseTableFragment(datastr).Root.Element(name)

        If element Is Nothing Then Return Nothing

        Return GetElementInnerXml(element)
    End Function

    '시간표 XML fragment에서 최상위 태그 전체를 추출한다.
    Public Function getTableData_withkeys(datastr As String, name As String) As String
        Dim element As XElement = ParseTableFragment(datastr).Root.Element(name)

        If element Is Nothing Then Return Nothing

        Return element.ToString(SaveOptions.DisableFormatting)
    End Function

    '시간표 XML fragment에서 같은 최상위 태그의 내용을 모두 추출한다.
    Public Function getTableDatas(datastr As String, name As String) As List(Of String)
        Dim elements = ParseTableFragment(datastr).Root.Elements(name).ToList()

        If elements.Count = 0 Then Return Nothing

        Return elements.Select(Function(element) GetElementInnerXml(element).Trim()).ToList()
    End Function

    'web에서 문자열 가져오는 함수
    Public Function webget(url As String)
        Dim source = New System.Net.WebClient()
        source.Encoding = System.Text.Encoding.UTF8
        'MsgBox(url)

        Dim sourcestr As String = Nothing
        sourcestr = source.DownloadString(url)

        Return sourcestr
    End Function

    Public Function GetLatestReleaseEntry(feedXml As String) As ReleaseFeedEntry
        If String.IsNullOrWhiteSpace(feedXml) Then
            Throw New InvalidDataException("릴리스 피드가 비어 있습니다.")
        End If

        Dim settings As New XmlReaderSettings With {
            .DtdProcessing = DtdProcessing.Prohibit,
            .XmlResolver = Nothing
        }

        Dim document As XDocument
        Using input As New StringReader(feedXml)
            Using reader As XmlReader = XmlReader.Create(input, settings)
                document = XDocument.Load(reader)
            End Using
        End Using

        Dim entry = document.Descendants().FirstOrDefault(Function(element) element.Name.LocalName = "entry")
        If entry Is Nothing Then
            Throw New InvalidDataException("릴리스 항목을 찾을 수 없습니다.")
        End If

        Dim title = entry.Elements().FirstOrDefault(Function(element) element.Name.LocalName = "title")
        Dim content = entry.Elements().FirstOrDefault(Function(element) element.Name.LocalName = "content")
        If title Is Nothing OrElse content Is Nothing Then
            Throw New InvalidDataException("릴리스 항목이 완전하지 않습니다.")
        End If

        Return New ReleaseFeedEntry With {
            .Title = title.Value,
            .ContentHtml = content.Value
        }
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

    Public Sub writeTable(data As String)
        Dim normalizedData As String = SerializeTableFragment(ParseTableFragment(data))
        My.Computer.FileSystem.WriteAllText(TableSaveLocation(False), normalizedData, False, System.Text.Encoding.GetEncoding(949))
    End Sub

    Public Function readTable() As String
        If My.Computer.FileSystem.FileExists(TableSaveLocation(False)) Then
            'My.Settings.defalutTable = OptionSave()
            Dim data As String = My.Computer.FileSystem.ReadAllText(TableSaveLocation(False), System.Text.Encoding.GetEncoding(949))
            Return SerializeTableFragment(ParseTableFragment(data))
        Else
            Return ""
        End If
    End Function

    Public Function TableSaveLocation(filenameOnly As Boolean) As String
        Dim exeFullpath As String = Application.ExecutablePath
        Dim finalDir As String = exeFullpath.Substring(0, exeFullpath.LastIndexOf("\"))
        Dim finalName As String = "default.utdata"

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
                finalName = usrSaveName + ".utdata"
            End If
        End If

        If filenameOnly Then
            Return finalName
        Else
            Return finalDir + "\" + finalName
        End If
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

    Public Function xmlEncode(value As String) As String
        Return SecurityElement.Escape(value)
    End Function

    Public Function xmlDecode(value As String) As String
        Return HttpUtility.HtmlDecode(value)
    End Function
End Module
