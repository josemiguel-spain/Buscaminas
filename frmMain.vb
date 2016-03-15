Imports System.IO

Public Class frmMain

    Dim gameLoaded As Boolean = False
    Dim intLevel As Integer = 1

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


#If DEBUG Then

        MsgBox("El programa ha sido compilado para depuración. Esta versión podría contener fallos. No redistribuir.", MsgBoxStyle.Critical, Application.ProductName)

#End If

        ' Cargamos el archivo de música de fondo.
        AxWindowsMediaPlayer1.URL = Path.GetDirectoryName(Application.ExecutablePath) + "\media\background.mp3"
        AxWindowsMediaPlayer1.settings.setMode("loop", True)

        ' Cargamos la configuración actual.
        chkMusica.Checked = My.Settings.backgroundmusic
        cmbLevel.SelectedIndex = My.Settings.lastGame

        Minesweeper1.BoardHeight = My.Settings.customHeight
        Minesweeper1.BoardWidth = My.Settings.customWidth
        Minesweeper1.MinesAmount = My.Settings.customMines

#If DEBUG Then

        ' Los trucos solo son visibles en modo de depuración.
        cmdTrucos.Visible = True

#End If

    End Sub

    Private Sub Minesweeper1_CellClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Minesweeper1.CellClick

        ' Actualizamos el contador de minas.
        lblLeft.Text = Minesweeper1.MinesLeft.ToString

    End Sub

    Private Sub Minesweeper1_GameEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Minesweeper1.GameEnd

        ' Actualizamos el record actual si es necesario. No se registra el record para los niveles personalizados.
        Select Case Minesweeper1.Level

            Case 1

                If CDbl(My.Settings.easyRecord) >= Minesweeper1.Seconds And Minesweeper1.actualGameStatus = Minesweeper.GameStatus.gameWon Then My.Settings.easyRecord = Minesweeper1.Seconds

            Case 2

                If CDbl(My.Settings.mediumRecord) >= Minesweeper1.Seconds And Minesweeper1.actualGameStatus = Minesweeper.GameStatus.gameWon Then My.Settings.mediumRecord = Minesweeper1.Seconds

            Case 3

                If CDbl(My.Settings.hardRecord) >= Minesweeper1.Seconds And Minesweeper1.actualGameStatus = Minesweeper.GameStatus.gameWon Then My.Settings.hardRecord = Minesweeper1.Seconds

            Case Else

        End Select

    End Sub

    Private Sub Minesweeper1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Minesweeper1.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ' Minesweeper1.IRWINNER()

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint




    End Sub

    Private Sub Minesweeper1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Minesweeper1.Tick

        lblTime.Text = Minesweeper1.Seconds.ToString

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecords.Click
        frmRecords.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReiniciar.Click
        My.Settings.Reset()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTrucos.Click
        Minesweeper1.cheat()
    End Sub

    Private Sub cmbLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLevel.SelectedIndexChanged

        If cmbLevel.SelectedIndex < 3 Or gameLoaded = False Then

            intLevel = cmbLevel.SelectedIndex + 1

        Else

            frmCustom.ShowDialog()

            If frmCustom.formResult = True Then

                Minesweeper1.BoardHeight = frmCustom.boardHeight
                Minesweeper1.BoardWidth = frmCustom.boardWidth
                Minesweeper1.MinesAmount = frmCustom.minesAmount

                My.Settings.customHeight = Minesweeper1.BoardHeight
                My.Settings.customWidth = Minesweeper1.BoardWidth
                My.Settings.customMines = Minesweeper1.MinesAmount

            Else

                cmbLevel.SelectedIndex = intLevel - 1

            End If

        End If

        If gameLoaded = True Then My.Settings.lastGame = cmbLevel.SelectedIndex

    End Sub

    Private Sub cmdEmpezar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmpezar.Click

        Minesweeper1.start(cmbLevel.SelectedIndex + 1)

        lblLeft.Text = Minesweeper1.MinesLeft.ToString

    End Sub

    Private Sub chkMusica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMusica.CheckedChanged

        If chkMusica.Checked = True Then
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        Else
            AxWindowsMediaPlayer1.Ctlcontrols.pause()
        End If

    End Sub

    Private Sub frmMain_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        gameLoaded = True

    End Sub

End Class
