Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Linq

Module DataModule
    Private Const TableFragmentRootName As String = "utable-fragment"
    Private ReadOnly Utf8WithoutBom As New System.Text.UTF8Encoding(False)
    Private ReadOnly StrictUtf8 As New System.Text.UTF8Encoding(False, True)

    '시간표 파일(.utdata)은 UTF-8로 저장하고, 구버전 CP949 파일을 읽을 수 있다.
    Public Function ReadTableFile(filePath As String) As String
        Dim bytes As Byte() = File.ReadAllBytes(filePath)

        Try
            Dim content As String = StrictUtf8.GetString(bytes)

            'UTF-8 BOM이 있는 파일도 UTF-8로 읽되, 문자열에 BOM 문자를 남기지 않는다.
            If content.Length > 0 AndAlso content(0) = ChrW(&HFEFF) Then
                Return content.Substring(1)
            End If

            Return content
        Catch ex As System.Text.DecoderFallbackException
            Return System.Text.Encoding.GetEncoding(949).GetString(bytes)
        End Try
    End Function

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
        Dim settings As New XmlWriterSettings With {
            .ConformanceLevel = ConformanceLevel.Fragment,
            .Indent = True,
            .IndentChars = vbTab,
            .NewLineChars = vbCrLf,
            .NewLineHandling = NewLineHandling.None,
            .OmitXmlDeclaration = True
        }
        Dim output As New StringBuilder()

        Using writer As XmlWriter = XmlWriter.Create(output, settings)
            For Each element As XElement In document.Root.Elements()
                '입력 파일에 남아 있는 서식용 공백은 버리고 실제 요소 구조만 다시 들여쓴다.
                '값만 있는 요소의 공백은 데이터일 수 있으므로 그대로 보존한다.
                Dim formattedElement As New XElement(element)
                For Each container As XElement In formattedElement.DescendantsAndSelf().Where(Function(item) item.HasElements)
                    container.Nodes().OfType(Of XText)().Where(Function(node) String.IsNullOrWhiteSpace(node.Value)).Remove()
                Next

                formattedElement.WriteTo(writer)
            Next
        End Using

        Return output.ToString().TrimEnd(ControlChars.Cr, ControlChars.Lf)
    End Function

    Private Function GetRequiredChildValue(element As XElement, name As String) As String
        Dim child As XElement = element.Element(name)
        If child Is Nothing Then Throw New InvalidDataException("과목에 <" + name + "> 값이 없습니다.")
        Return child.Value
    End Function

    Private Function ToTableCourse(element As XElement) As TableCourse
        Dim checkedElement As XElement = element.Element("checked")
        Return New TableCourse With {
            .Day = Integer.Parse(GetRequiredChildValue(element, "day")),
            .Name = GetRequiredChildValue(element, "name"),
            .Professor = GetRequiredChildValue(element, "prof"),
            .Memo = GetRequiredChildValue(element, "memo"),
            .Start = Integer.Parse(GetRequiredChildValue(element, "start")),
            .End = Integer.Parse(GetRequiredChildValue(element, "end")),
            .Color = GetRequiredChildValue(element, "color"),
            .IsChecked = checkedElement IsNot Nothing AndAlso String.Equals(checkedElement.Value, "True", StringComparison.OrdinalIgnoreCase),
            .CheckedSpecified = checkedElement IsNot Nothing
        }
    End Function

    Private Function ToCourseElement(course As TableCourse) As XElement
        Dim element As New XElement("course",
            New XElement("day", course.Day),
            New XElement("name", course.Name),
            New XElement("prof", course.Professor),
            New XElement("memo", course.Memo),
            New XElement("start", course.Start),
            New XElement("end", course.End),
            New XElement("color", course.Color))

        If course.CheckedSpecified Then
            element.Add(New XElement("checked", course.IsChecked.ToString()))
        End If

        Return element
    End Function

    Public Function ParseSchedule(data As String) As TableSchedule
        Dim document As XDocument = ParseTableFragment(data)
        Dim schedule As New TableSchedule()
        Dim nameElement As XElement = document.Root.Element("tablename")
        If nameElement IsNot Nothing Then schedule.Name = nameElement.Value

        Dim index As Integer = 0
        For Each element As XElement In document.Root.Elements("course")
            Dim course As TableCourse = ToTableCourse(element)
            course.SourceIndex = index
            schedule.Courses.Add(course)
            index += 1
        Next

        Return schedule
    End Function

    Public Function SerializeSchedule(schedule As TableSchedule) As String
        If schedule Is Nothing Then Throw New ArgumentNullException(NameOf(schedule))

        Dim root As New XElement(TableFragmentRootName)
        If schedule.Name IsNot Nothing Then root.Add(New XElement("tablename", schedule.Name))
        For Each course As TableCourse In schedule.Courses
            root.Add(ToCourseElement(course))
        Next

        Return SerializeTableFragment(New XDocument(root))
    End Function

    Public Function LoadSchedule() As TableSchedule
        Dim filePath As String = TableSaveLocation(False)
        If Not File.Exists(filePath) Then Return New TableSchedule()
        Return ParseSchedule(ReadTableFile(filePath))
    End Function

    Public Sub SaveSchedule(schedule As TableSchedule)
        Dim filePath As String = TableSaveLocation(False)
        File.WriteAllText(filePath, SerializeSchedule(schedule), Utf8WithoutBom)
    End Sub

    Public Function FindCourse(schedule As TableSchedule, reference As TableCourse) As TableCourse
        If schedule Is Nothing OrElse reference Is Nothing Then Return Nothing

        If reference.SourceIndex >= 0 AndAlso reference.SourceIndex < schedule.Courses.Count Then
            Dim indexedCourse As TableCourse = schedule.Courses(reference.SourceIndex)
            If indexedCourse.HasSameData(reference) Then Return indexedCourse
        End If

        Return schedule.Courses.FirstOrDefault(Function(course) course.HasSameData(reference))
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

    Public Function ReadScheduleData() As String
        Dim filePath As String = TableSaveLocation(False)
        If File.Exists(filePath) Then
            Dim data As String = ReadTableFile(filePath)
            Return SerializeTableFragment(ParseTableFragment(data))
        Else
            Return ""
        End If
    End Function

    Public Function TableSaveLocation(filenameOnly As Boolean) As String
        ' 기본 저장소는 INIPath와 동일하다. Store 패키지에서는 AppData\\uTable,
        ' 일반/포터블 실행에서는 실행 파일 폴더다.
        Dim finalDir As String = INIPath
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
            Return Path.Combine(finalDir, finalName)
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

End Module
