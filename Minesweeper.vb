Imports System.Resources

Public Class Minesweeper

    Private Declare Function BitBlt Lib "gdi32" (ByVal hDestDC As Long, ByVal x As Long, ByVal y As Long, ByVal nWidth As Long, ByVal nHeight As Long, ByVal hSrcDC As Long, ByVal xSrc As Long, ByVal ySrc As Long, ByVal dwRop As Long) As Long

    ' Cantidad mínima de minas que habrá en cualquier tablero.
    Public Const MINIMUM_AMOUNT_OF_MINES As Integer = 10
    ' Tamaño mínimo de los tablerls (ancho y largo)
    Public Const MINIMUM_BOARD_SIZE As Integer = 10
    ' Tamaño máximo de los tableros
    Public Const MAXIMUM_BOARD_SIZE = 25
    Public Const MAXIMUM_BOARD_HEIGHT = 20

    ' Posibles estados del juego.
    Public Enum GameStatus
        gameNothing = 0
        gamePlaying = 1
        gameLost = 2
        gameWon = 3
    End Enum

    ' Niveles de dificultad disponibles.
    Public Enum GameDifficulty
        custom = -1
        easy = 1
        medium = 2
        hard = 3
    End Enum

    'Const easy As Integer = 1
    'Const medium As Integer = 2
    'Const hard As Integer = 3

    Dim dateStarted As DateTime
    Dim intSeconds As Integer

    Public actualGameStatus As Integer = GameStatus.gameNothing

    Dim generated As Boolean = False
    Dim firstClick As Boolean = True

    Dim mines As New ArrayList
    Dim specialButtons(-1) As Integer

    Dim boxSize As Integer = 0

    Dim pointZero As Point

    Dim intBoardHeight As Integer = 10
    Dim intBoardWidth As Integer = 5
    Dim intMinesAmount As Integer = 0
    Dim intFlags As Integer = 0
    Dim intCellsCleared As Integer = 0

    Dim gameLevel As GameDifficulty

    Const normalButton As Integer = 0
    Const noMines As Integer = 9
    Const buttonHightlighted = 10
    Const pressedButton As Integer = 10
    Const wrongButton As Integer = 11

    Private Function numberButton(ByVal number As Integer) As String

        Return "button" + number.ToString

    End Function

    ReadOnly Property Level() As Integer
        Get
            Return gameLevel
        End Get
    End Property

    ReadOnly Property MinesLeft As Integer
        Get
            Return intMinesAmount - intFlags
        End Get
    End Property

    ReadOnly Property Seconds() As Integer
        Get
            Return intSeconds
        End Get
    End Property

    ReadOnly Property Status() As Integer
        Get
            Return actualGameStatus
        End Get
    End Property

    Property BoardHeight() As Integer
        Get

            Return intBoardHeight

        End Get
        Set(ByVal value As Integer)

            ' The minimum height of the board is 10
            If value < MINIMUM_BOARD_SIZE Then value = MINIMUM_BOARD_SIZE
            If value > MAXIMUM_BOARD_HEIGHT Then value = MAXIMUM_BOARD_HEIGHT
            intBoardHeight = value
            ReDim specialButtons(intBoardHeight * intBoardWidth)

            checkMinesAmount()
            locateBoxes()

        End Set
    End Property

    Property BoardWidth() As Integer

        Get
            Return intBoardWidth
        End Get
        Set(ByVal value As Integer)

            'The minimum width of the board is 10
            If value < MINIMUM_BOARD_SIZE Then value = MINIMUM_BOARD_SIZE
            If value > MAXIMUM_BOARD_SIZE Then value = MAXIMUM_BOARD_SIZE
            intBoardWidth = value
            ReDim specialButtons(intBoardHeight * intBoardWidth)

            checkMinesAmount()
            locateBoxes()

        End Set

    End Property

    Property MinesAmount As Integer
        Get

            Return Me.intMinesAmount

        End Get
        Set(ByVal value As Integer)

            Me.intMinesAmount = value
            checkMinesAmount()

        End Set
    End Property

    Private Sub createMines(ByVal minesAmount As Integer)

        Randomize()

        Dim choosenOne As Integer

        Dim i As Integer

        For i = 1 To minesAmount

            Do

                choosenOne = CInt((Rnd() * (Me.intBoardHeight * Me.intBoardWidth - 1)) + 1)

            Loop Until mines.IndexOf(choosenOne) < 0

            mines.Add(choosenOne)

        Next

    End Sub

    Private Function getRow(ByVal cell As Integer) As Integer

        Return ((cell - 1) \ Me.intBoardWidth)

    End Function

    Private Function getColumn(ByVal cell As Integer) As Integer

        Return cell - (getRow(cell) * Me.intBoardWidth) - 1

    End Function

    ''' <summary>
    ''' Recreates the board.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub createBoard()

        ReDim specialButtons(Me.intBoardWidth * Me.intBoardHeight)

        Dim i As Integer

        For i = 0 To specialButtons.Length - 1

            specialButtons(i) = 0

        Next

        generated = True

    End Sub

    Private Sub locateBoxes()

        If specialButtons.Length < 1 Then Exit Sub

        Me.SuspendLayout()
        Dim originalBitmap As Bitmap = New Bitmap(Me.Width, Me.Height)

        If Me.Width / Me.intBoardWidth > Me.Height / Me.intBoardHeight Then

            boxSize = Me.Height \ Me.intBoardHeight
            pointZero = New Point((Me.Width - boxSize * Me.intBoardWidth) \ 2, (Me.Height - boxSize * Me.intBoardHeight) \ 2)

        Else

            boxSize = Me.Width \ Me.intBoardWidth
            pointZero = New Point((Me.Width - boxSize * Me.intBoardWidth) \ 2, (Me.Height - boxSize * Me.intBoardHeight) \ 2)

        End If

        Debug.WriteLine("Point zero: " + pointZero.ToString)
        Debug.WriteLine("Box size: " + boxSize.ToString)

        Dim i As Integer

        For i = 1 To Me.intBoardWidth * Me.intBoardHeight

            originalBitmap = paintBox(originalBitmap, i, specialButtons(i), True)

        Next

        If actualGameStatus = GameStatus.gameWon Then originalBitmap = paintWinner(CType(originalBitmap, Bitmap))

        Me.BackgroundImage = originalBitmap
        Me.ResumeLayout()

    End Sub

    Private Function paintBox(ByVal originalBitmap As Bitmap, ByVal boxNumber As Integer, ByVal boxStatus As Integer, Optional ByVal justReturn As Boolean = False) As Bitmap

        'If Array.IndexOf(mines, boxNumber) > -1 Then Return originalBitmap

        Dim mineGraphic As Graphics

        Dim actualRow As Integer = getRow(boxNumber)
        Dim actualColumn As Integer = getColumn(boxNumber)

        Dim boxLocation As Point = New Point(pointZero.X + actualColumn * boxSize, pointZero.Y + actualRow * boxSize)

        Dim imageMine As New Bitmap(DirectCast(My.Resources.board.ResourceManager.GetObject("p" + boxStatus.ToString), Image))

        If justReturn = True Then
            mineGraphic = Graphics.FromImage(originalBitmap)
        Else
            mineGraphic = Graphics.FromImage(Me.BackgroundImage)
        End If

        mineGraphic.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        mineGraphic.DrawImage(imageMine, boxLocation.X, boxLocation.Y, boxSize, boxSize)



        Return originalBitmap

    End Function

    Private Function paintWinner(ByVal originalBitmap As Bitmap) As Bitmap

        Dim newWidth As Integer
        Dim newHeight As Integer

        Dim mineGraphic As Graphics

        Dim imageMine As New Bitmap(DirectCast(My.Resources.board.ResourceManager.GetObject("win"), Image))

        newWidth = CInt(Me.intBoardWidth * boxSize * 0.8)
        newHeight = CInt((newWidth / imageMine.Width) * imageMine.Height)

        Dim boxLocation As Point = New Point(pointZero.X + (Me.intBoardWidth * boxSize - newWidth) \ 2, pointZero.Y + (Me.BoardHeight * boxSize - newHeight) \ 2)

        mineGraphic = Graphics.FromImage(originalBitmap)

        mineGraphic.InterpolationMode = Drawing2D.InterpolationMode.Low
        mineGraphic.DrawImage(imageMine, boxLocation.X, boxLocation.Y, newWidth, newHeight)

        Return originalBitmap
        Me.Refresh()

    End Function

    Private Sub checkMinesAmount()

        Dim maximumAmount As Integer = Me.intBoardWidth * Me.intBoardHeight * 85 \ 100

        If Me.intMinesAmount < MINIMUM_AMOUNT_OF_MINES Then Me.intMinesAmount = MINIMUM_AMOUNT_OF_MINES
        If Me.intMinesAmount > maximumAmount Then Me.intMinesAmount = maximumAmount

    End Sub

    Private Sub Minesweeper_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click

    End Sub

    Private Sub Minesweeper_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick


    End Sub

    Private Sub Minesweeper_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub

    Private Sub Minesweeper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.DoubleBuffered = True
        'start()

    End Sub

    Public Sub start()

        actualGameStatus = GameStatus.gamePlaying
        dateStarted = Now

        intCellsCleared = 0
        intFlags = 0
        createBoard()
        mines.Clear()
        createMines(intMinesAmount)
        locateBoxes()
        Me.firstClick = True

        intSeconds = 0
        tmrClock.Enabled = True

    End Sub
    ''' <summary>
    ''' Empieza la partida.
    ''' </summary>
    ''' <param name="level">Nivel de la partida. -1 para personalizado.</param>
    ''' <remarks></remarks>
    Public Sub start(ByVal level As Integer)

        ' Inciamos una partida cargando un nivel de dificultad determinado.
        ' 1:  fácil
        ' 2:  medio
        ' 3:  difícil
        ' -1: personalizado
        Select Case level

            Case 1

                Me.BoardWidth = 10
                Me.BoardHeight = 10
                Me.MinesAmount = MINIMUM_AMOUNT_OF_MINES
                gameLevel = GameDifficulty.easy

            Case 2

                Me.BoardWidth = 16
                Me.BoardHeight = 16
                Me.MinesAmount = 40
                gameLevel = GameDifficulty.medium

            Case 3

                Me.BoardWidth = 30
                Me.BoardHeight = 16
                Me.MinesAmount = 99
                gameLevel = GameDifficulty.hard

            Case Else

                gameLevel = GameDifficulty.custom

        End Select


        start()

    End Sub

    ''' <summary>
    ''' Hace clic con el botón derecho en todas las casillas que tienen una mina para marcarlas.
    ''' </summary>
    ''' <remarks>Solo funciona en modo de depuración.</remarks>
    Public Sub cheat()

#If DEBUG Then

        Dim i As Integer
        Dim j(0) As Integer

        ' Recorremos la lista de casillas con minas.
        For Each i In mines

            j(0) = i
            clickCell(CType(Me.BackgroundImage, Bitmap), j, True, True)
            Me.Refresh()

        Next

#End If

    End Sub
    ''' <summary>
    ''' Al pasar el cursor sobre las casillas nos mostrará si hay una mina o no.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Solo funciona en modo de depuración.</remarks>
    Private Sub Minesweeper_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

#If DEBUG Then

        If mines.IndexOf(getButton(e.Location)) > -1 Then Me.Cursor = Cursors.No Else Me.Cursor = Cursors.Default

#End If

    End Sub

    Private Sub Minesweeper_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp

        ' Identificador de la celda sobre la que se ha hecho clic
        Dim actualCell(0) As Integer
        ' Imagen del tablero
        Dim originalBitmap As Bitmap = New Bitmap(Me.BackgroundImage)
        ' Controlamos si se ha hecho clic con el botón derecho
        Dim rightClick As Boolean = (e.Button = MouseButtons.Right)

        ' Si no hay una partida activa no hay nada que hacer.
        If actualGameStatus = GameStatus.gameLost Or actualGameStatus = GameStatus.gameWon Then Exit Sub

        'Obtenemos la celda sobre la que se ha hecho clic
        actualCell(0) = getButton(e.Location)

        ' Si se ha hecho clic sobre una celda y no un espacio vacío ejecutamos la acción.
        If actualCell(0) > -1 Then Me.BackgroundImage = clickCell(originalBitmap, actualCell, rightClick, True)

        ' Actualizamos la imágen de fondo.
        Me.Refresh()

        ' Si la partida ha terminado desencadenamos el evento asociado.
        If actualGameStatus = GameStatus.gameWon Or actualGameStatus = GameStatus.gameLost Then raiseGameEnd()

    End Sub
    ''' <summary>
    ''' Hace click en las casillas especificadas.
    ''' </summary>
    ''' <param name="originalBitmap">Bitmap donde se pintarán las casillas.</param>
    ''' <param name="cell">Lista de casillas.</param>
    ''' <param name="rightButton">Si se ha hecho clic con el botón derecho se marca. En caso contrario se descubre el contenido.</param>
    ''' <param name="firstJump">Indica si el click lo ha hecho el usuario o es un click indirecto.</param>
    ''' <returns>Imagen con las nuevas casillas dibujadas.</returns>
    ''' <remarks></remarks>
    Private Function clickCell(ByVal originalBitmap As Bitmap, ByVal cell() As Integer, ByVal rightButton As Boolean, Optional ByVal firstJump As Boolean = False) As Bitmap

        If actualGameStatus <> GameStatus.gamePlaying Then

            start()
            Me.BackgroundImage = clickCell(originalBitmap, cell, rightButton, firstJump)
            Me.Refresh()

        End If

        Dim minesAround As Integer
        Dim i As Integer = 0

        ' Si el usuario pulsa con el botón derecho pondremos o retiraremos una bandera según la tenga o no.
        If rightButton = True Then

            Debug.Write("El usuario ha hecho clic en la casilla " + cell(0).ToString + " con el botón derecho.")

            ' Si la casilla tiene una bandera la quitamos, si no la tiene se la ponemos.
            If specialButtons(cell(0)) = 0 Then
                specialButtons(cell(0)) = 10
                intFlags += 1
                Debug.WriteLine("Hemos insertado una bandera.")
            Else
                Debug.WriteLine("Hemos eliminado una bandera.")
                If specialButtons(cell(0)) = 10 Then specialButtons(cell(0)) = 0
                intFlags -= 1
            End If

            ' Pintamos la casilla.
            originalBitmap = paintBox(originalBitmap, cell(0), specialButtons(cell(0)), True)

        End If

        ' El usuario ha hecho click con el izquierdo.
        If rightButton = False Then

            Debug.WriteLine("Se ha hecho clic con el botón izquierdo en la casilla " + cell(i).ToString + ".")

            For i = 0 To cell.Length - 1

                ' Si la casilla está marcada ignoramos el click
                If specialButtons(cell(i)) = 10 Then
                    Debug.WriteLine("La casilla está marcada. Ignoramos el click.")
                    Continue For
                End If

                ' Si el la casilla está en la lista de casillas con mina
                If checkMine(cell(i), False) > 0 Then

                    Debug.WriteLine("La casilla tiene mina.")

                    ' Si es el primer click crearemos una nueva mina y eliminaremos la actual.
                    If firstClick = True Then

                        Debug.WriteLine("Es el primer clic así que la cambiamos de lugar.")

                        ' Creamos la mina.
                        createMines(1)
                        ' Eliminamos esta mina.
                        mines.Remove(cell(i))
                        ' Hacemos clic en la casilla.
                        clickCell(originalBitmap, cell, rightButton)

                        ' Si no es el primer click
                    Else

                        Debug.WriteLine("Se acabó la partida.")

                        tmrClock.Enabled = False

                        ' Pintamos todas las minas en el tablero.
                        For Each posicionMina As Integer In mines
                            ' Pintamos la casilla con la mina.
                            originalBitmap = paintBox(originalBitmap, posicionMina, 11, True)

                        Next
                        ' Se acabó la partida.
                        My.Computer.Audio.Play(My.Resources.board.explosion, AudioPlayMode.Background)
                        actualGameStatus = GameStatus.gameLost

                        Exit For

                    End If

                End If

                ' Las casillas con número solo se activan a través del usuario, no a través de este método.
                If specialButtons(cell(i)) > 0 And firstJump = False Then Continue For

                ' Si la casilla era una casilla en blanco sin minas
                If specialButtons(cell(i)) = 0 And checkMine(cell(i), False) = 0 Then

                    ' Contamos cuantas minas hay alrededor
                    minesAround = countMines(cell(i))
                    ' Establecemos el valor de esta casilla según cuantas minas tiene alrededor.
                    specialButtons(cell(i)) = minesAround

                    ' Pintamos la casilla
                    originalBitmap = paintBox(originalBitmap, cell(i), specialButtons(cell(i)), True)

                    ' Si no tiene minas alrededor haremos clic en todas esas casillas.
                    If minesAround = noMines Then
                        originalBitmap = clickCell(originalBitmap, lookAround(cell(i)), False)
                    End If

                    ' Establecemos la imagen para esta casilla.
                    specialButtons(cell(i)) = minesAround

                    ' Incrementamos el contador de casillas reveladas.
                    Me.intCellsCleared += 1

                    'Exit For

                End If

                ' Si el usuario ha hecho clic en una casilla con número y esta tiene al su alrededor tantas marcas
                ' como minas tiene la casilla haremos clic en todas las casillas que tenga alrededor sin marca.
                If specialButtons(cell(i)) > 0 And specialButtons(cell(i)) < 10 And actualGameStatus = GameStatus.gamePlaying Then
                    If countMines(cell(i), True) = specialButtons(cell(i)) Then clickCell(originalBitmap, lookAround(cell(i)), False)
                End If

                ' Pintamos la casilla
                'originalBitmap = paintBox(originalBitmap, cell(i), countMines(cell(i)))

                If firstJump = True And actualGameStatus <> GameStatus.gameLost Then My.Computer.Audio.Play(My.Resources.board.click, AudioPlayMode.Background)

            Next i

        End If

        ' Si el número de casillas reveladas es igual al número de casillas sin minas la partida ha terminado.
        If Me.intCellsCleared >= Me.intBoardWidth * Me.intBoardHeight - intMinesAmount And firstJump = True And actualGameStatus = GameStatus.gamePlaying Then

            actualGameStatus = GameStatus.gameWon
            tmrClock.Enabled = False
            originalBitmap = paintWinner(originalBitmap)
            Debug.WriteLine("Pintando pantalla...")

        End If

        ' Si este era el primer click ya no lo es.
        If firstClick = True Then

            firstClick = False

        End If

        RaiseEvent CellClick(Me, EventArgs.Empty)

        Return originalBitmap

    End Function
    ''' <summary>
    ''' Redibuja el tablero al cambiarle el tamaño.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Minesweeper_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Me.Height = 0 Or Me.Width = 0 Then Exit Sub
        locateBoxes()

    End Sub
    ''' <summary>
    ''' Obtiene el número de casilla correspondiente a unas coordenadas determinadas.
    ''' </summary>
    ''' <param name="position">Coordenadas.</param>
    ''' <returns>Número de casilla. Si se ha hecho clic fuera de la zona de casillas devuelve -1.</returns>
    ''' <remarks></remarks>
    Private Function getButton(ByVal position As Point) As Integer

        Dim relativePoint As New Point(position.X - pointZero.X, position.Y - pointZero.Y)
        Dim actualColumn As Integer
        Dim actualRow As Integer

        actualColumn = (relativePoint.X - 1) \ boxSize
        actualRow = (relativePoint.Y - 1) \ boxSize

        Debug.WriteLine(actualColumn.ToString + ";" + actualRow.ToString)

        If position.X < pointZero.X Or position.Y < pointZero.Y Or position.X > position.X + Me.BoardWidth * boxSize Or position.Y > pointZero.Y + Me.BoardHeight * boxSize Then
            Return -1
        Else
            Return getCell(actualRow, actualColumn)
        End If

    End Function
    ''' <summary>
    ''' Devuelve el número de casilla por su fila y columna
    ''' </summary>
    ''' <param name="actualRow">Número de fila</param>
    ''' <param name="actualColumn">Número de columna</param>
    ''' <returns>Número de casilla</returns>
    ''' <remarks></remarks>
    Private Function getCell(ByVal actualRow As Integer, ByVal actualColumn As Integer) As Integer

        Return actualRow * intBoardWidth + actualColumn + 1

    End Function
    ''' <summary>
    ''' Devuelve una lista con las casillas existentes alrededor de una casilla determinada.
    ''' </summary>
    ''' <param name="cell">Número de la celda.</param>
    ''' <returns>Lista de casillas.</returns>
    ''' <remarks></remarks>
    Private Function lookAround(ByVal cell As Integer) As Integer()

        'Obtenemos la fila y la columna.
        Dim actualRow As Integer = getRow(cell)
        Dim actualColumn As Integer = getColumn(cell)

        'Lista de casillas
        Dim casillas(-1) As Integer

        'Si no estamos en la primera fila recogemos las casillas de la fila superior.
        If actualRow > 0 Then
            If actualColumn > 0 Then insertIntoArray(casillas, getCell(actualRow - 1, actualColumn - 1))
            insertIntoArray(casillas, getCell(actualRow - 1, actualColumn))
            If actualColumn < Me.BoardWidth - 1 Then insertIntoArray(casillas, getCell(actualRow - 1, actualColumn + 1))

        End If

        'Si no estamos en la primera columna cogemos la casilla anterior. Si no estamos en la última cogemos la siguiente.
        If actualColumn > 0 Then insertIntoArray(casillas, getCell(actualRow, actualColumn - 1))
        If actualColumn < Me.BoardWidth - 1 Then insertIntoArray(casillas, getCell(actualRow, actualColumn + 1))

        'Si no estamos en la última fila cogemos las casillas de la fila inferior.
        If actualRow < Me.BoardHeight - 1 Then
            If actualColumn > 0 Then insertIntoArray(casillas, getCell(actualRow + 1, actualColumn - 1))
            insertIntoArray(casillas, getCell(actualRow + 1, actualColumn))
            If actualColumn < Me.BoardWidth - 1 Then insertIntoArray(casillas, getCell(actualRow + 1, actualColumn + 1))

        End If

        'Devolvemos la lista con las casillas recogidas.
        Return casillas

    End Function
    ''' <summary>
    ''' Contamos las minas que hay alrededor de una casilla.
    ''' </summary>
    ''' <param name="cell">Celda de referencia para la búsqueda.</param>
    ''' <param name="lookForFlag">Si es verdadero contaremos las banderas en lugar de las minas.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function countMines(ByVal cell As Integer, Optional ByVal lookForFlag As Boolean = False) As Integer

        Dim minesFound = 0

        Dim casillas() As Integer = lookAround(cell)

        Dim i As Integer = 0

        For i = 0 To casillas.Length - 1

            minesFound += checkMine(casillas(i), lookForFlag)

        Next

        If minesFound = 0 Then minesFound = noMines

        Return minesFound

    End Function
    ''' <summary>
    ''' Comprobamos si la casilla especificada tiene una mina
    ''' </summary>
    ''' <param name="cell">Casilla a comprobar</param>
    ''' <param name="lookForFlag">Si es verdadero comprobaremos si tiene una bandera</param>
    ''' <returns>1 en caso de que haya una mina, 0 en caso contrario.</returns>
    ''' <remarks></remarks>
    Private Function checkMine(ByVal cell As Integer, ByVal lookForFlag As Boolean) As Integer

        If lookForFlag = False Then

            If mines.IndexOf(cell) > -1 Then Return 1 Else Return 0

        Else

            If specialButtons(cell) = 10 Then Return 1 Else Return 0

        End If

    End Function
    ''' <summary>
    ''' Inserta un elemento en un array.
    ''' </summary>
    ''' <param name="myArray">Array donde insertar el elemento.</param>
    ''' <param name="newValue">Elemento.</param>
    ''' <remarks></remarks>
    Private Sub insertIntoArray(ByRef myArray As Integer(), ByVal newValue As Integer)

        Array.Resize(myArray, myArray.Length + 1)

        myArray(myArray.Length - 1) = newValue

    End Sub
    ''' <summary>
    ''' Desencadena el evento tick.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmrClock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrClock.Tick

        ' Si no hay una partida empezada en curso no hacemos nada.
        If actualGameStatus <> GameStatus.gamePlaying Or firstClick = True Then Exit Sub
        ' La variable se llama 'segundos' pero medimos las centésimas.
        intSeconds = CInt((Now - dateStarted).TotalMilliseconds / 10)
        ' Aquí es donde desencadenamos el evento.
        RaiseEvent Tick(Me, EventArgs.Empty)

    End Sub

    Public Event GameEnd As EventHandler

    Public Event Tick As EventHandler

    Public Event CellClick As EventHandler
    ''' <summary>
    ''' Este evento se activa cuando la partida acaba.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub raiseGameEnd()

        RaiseEvent GameEnd(Me, EventArgs.Empty)

    End Sub

End Class
