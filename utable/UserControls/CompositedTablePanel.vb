Public Class CompositedTablePanel
    Inherits Panel

    Private Const WsExComposited As Integer = &H2000000

    Public Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        DoubleBuffered = True
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim parameters As CreateParams = MyBase.CreateParams
            '화면에 프레임을 표시하기 전에 격자와 모든 과목 셀을 오프스크린에서 합성한다
            parameters.ExStyle = parameters.ExStyle Or WsExComposited
            Return parameters
        End Get
    End Property
End Class
