Friend Class TableCourse
    '파일 안에서의 순서. UI가 가리키던 과목을 다시 로드한 시간표에서 찾을 때 사용한다.
    '직렬화되는 값은 아니다.
    Public Property SourceIndex As Integer = -1
    Public Property Day As Integer
    Public Property Name As String
    Public Property Professor As String
    Public Property Memo As String
    Public Property Start As Integer
    Public Property [End] As Integer
    Public Property Color As String
    Public Property IsChecked As Boolean
    Public Property CheckedSpecified As Boolean

    Public Function Identity() As String
        Return Day.ToString() + "-" + Start.ToString() + "-" + Name
    End Function

    Public Function HasSameData(other As TableCourse) As Boolean
        Return other IsNot Nothing AndAlso
            Day = other.Day AndAlso
            Name = other.Name AndAlso
            Professor = other.Professor AndAlso
            Memo = other.Memo AndAlso
            Start = other.Start AndAlso
            [End] = other.End AndAlso
            Color = other.Color AndAlso
            IsChecked = other.IsChecked AndAlso
            CheckedSpecified = other.CheckedSpecified
    End Function
End Class
