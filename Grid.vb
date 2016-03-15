Public Class Board

    Private BoardWidth As Integer
    Private BoardHeight As Integer

    Public Sub Board(ByVal boardTemplate As String)


    End Sub

    Property Width As Integer

        Get
            Return BoardWidth
        End Get

        Set(ByVal newWidth As Integer)
            BoardWidth = newWidth
        End Set

    End Property

    Property Height As Integer

        Get
            Return BoardWidth
        End Get

        Set(ByVal newHeight As Integer)
            BoardHeight = newHeight
        End Set

    End Property

End Class
