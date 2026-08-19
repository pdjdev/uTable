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
            'Compose the grid and every course cell off-screen before presenting a frame.
            parameters.ExStyle = parameters.ExStyle Or WsExComposited
            Return parameters
        End Get
    End Property
End Class
