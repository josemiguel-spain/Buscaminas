Public Class frmCustom

    Public boardWidth As Integer
    Public boardHeight As Integer
    Public formResult As Boolean
    Public minesAmount As Integer
    Dim minimumAmountOfMines As Integer = 10

    Private Sub txtHeight_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHeight.Leave

        Try

            boardHeight = CInt(txtHeight.Text)

        Catch ex As Exception

            boardHeight = Minesweeper.MINIMUM_BOARD_SIZE
            txtHeight.Text = boardHeight.ToString

        End Try

        If CInt(txtHeight.Text) < Minesweeper.MINIMUM_BOARD_SIZE Then txtHeight.Text = Minesweeper.MINIMUM_BOARD_SIZE.ToString
        If CInt(txtHeight.Text) > Minesweeper.MAXIMUM_BOARD_HEIGHT Then txtHeight.Text = Minesweeper.MAXIMUM_BOARD_HEIGHT.ToString

        boardHeight = CInt(txtHeight.Text)

        checkMinesAmount()

    End Sub


    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        formResult = True

    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click

        formResult = False

    End Sub

    Private Sub txtWidth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWidth.Leave

        Try

            boardWidth = CInt(txtWidth.Text)

        Catch ex As Exception

            boardWidth = Minesweeper.MINIMUM_BOARD_SIZE
            txtWidth.Text = boardWidth.ToString

        End Try

        If CInt(txtWidth.Text) < Minesweeper.MINIMUM_BOARD_SIZE Then txtWidth.Text = Minesweeper.MINIMUM_BOARD_SIZE.ToString
        If CInt(txtWidth.Text) > Minesweeper.MAXIMUM_BOARD_SIZE Then txtWidth.Text = Minesweeper.MAXIMUM_BOARD_SIZE.ToString

        boardWidth = CInt(txtWidth.Text)

        checkMinesAmount()

    End Sub

    Private Sub frmCustom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtHeight.Text = frmMain.Minesweeper1.BoardHeight.ToString
        txtWidth.Text = frmMain.Minesweeper1.BoardWidth.ToString
        txtMines.Text = frmMain.Minesweeper1.MinesAmount.ToString

        boardHeight = frmMain.Minesweeper1.BoardHeight
        boardWidth = frmMain.Minesweeper1.BoardWidth
        minesAmount = frmMain.Minesweeper1.MinesAmount

    End Sub

    Private Sub checkMinesAmount()

        Dim maximumAmount As Integer = boardWidth * boardHeight * 85 \ 100 '- biggest(boardHeight, boardWidth * 2)

        If minesAmount < minimumAmountOfMines Then minesAmount = minimumAmountOfMines
        If minesAmount > maximumAmount Then minesAmount = maximumAmount

        txtMines.Text = minesAmount.ToString

    End Sub

    Private Function biggest(ByVal number1 As Integer, ByVal number2 As Integer) As Integer

        If number1 > number2 Then Return number1 Else Return number2

    End Function

    Private Sub txtMines_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMines.Leave

        Try

            minesAmount = CInt(txtMines.Text)

        Catch ex As Exception

            minesAmount = minimumAmountOfMines
            txtWidth.Text = minesAmount.ToString

        End Try

        checkMinesAmount()

    End Sub

End Class