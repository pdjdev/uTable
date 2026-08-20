'시간표 과목의 메모리 표현 - 값은 기존 함수와 호환되도록 XML-encoded 상태로 보관
Friend Class TableCourse
    Public Property RawData As String
    Public Property Day As String
    Public Property Name As String
    Public Property Professor As String
    Public Property Memo As String
    Public Property Start As String
    Public Property [End] As String
    Public Property Color As String
    Public Property Checked As String

    Public Function Identity() As String
        Return Day + "-" + Start + "-" + Name
    End Function
End Class
