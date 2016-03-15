<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkMusica = New System.Windows.Forms.CheckBox()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblLeft = New System.Windows.Forms.Label()
        Me.cmdTrucos = New System.Windows.Forms.Button()
        Me.cmdReiniciar = New System.Windows.Forms.Button()
        Me.cmdRecords = New System.Windows.Forms.Button()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.cmbLevel = New System.Windows.Forms.ComboBox()
        Me.cmdEmpezar = New System.Windows.Forms.Button()
        Me.Minesweeper1 = New Nonogram.Minesweeper()
        Me.Panel1.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Panel1.Controls.Add(Me.chkMusica)
        Me.Panel1.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblLeft)
        Me.Panel1.Controls.Add(Me.cmdTrucos)
        Me.Panel1.Controls.Add(Me.cmdReiniciar)
        Me.Panel1.Controls.Add(Me.cmdRecords)
        Me.Panel1.Controls.Add(Me.lblTime)
        Me.Panel1.Controls.Add(Me.cmbLevel)
        Me.Panel1.Controls.Add(Me.cmdEmpezar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(130, 715)
        Me.Panel1.TabIndex = 1
        '
        'chkMusica
        '
        Me.chkMusica.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkMusica.AutoSize = True
        Me.chkMusica.Location = New System.Drawing.Point(15, 625)
        Me.chkMusica.Name = "chkMusica"
        Me.chkMusica.Size = New System.Drawing.Size(60, 17)
        Me.chkMusica.TabIndex = 7
        Me.chkMusica.Text = "Música"
        Me.chkMusica.UseVisualStyleBackColor = True
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(5, 535)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(115, 48)
        Me.AxWindowsMediaPlayer1.TabIndex = 2
        Me.AxWindowsMediaPlayer1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Nonogram.My.Resources.board.p11
        Me.PictureBox1.Location = New System.Drawing.Point(15, 155)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'lblLeft
        '
        Me.lblLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblLeft.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeft.Location = New System.Drawing.Point(55, 155)
        Me.lblLeft.Name = "lblLeft"
        Me.lblLeft.Size = New System.Drawing.Size(60, 35)
        Me.lblLeft.TabIndex = 5
        Me.lblLeft.Text = "0"
        Me.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdTrucos
        '
        Me.cmdTrucos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdTrucos.Location = New System.Drawing.Point(15, 595)
        Me.cmdTrucos.Name = "cmdTrucos"
        Me.cmdTrucos.Size = New System.Drawing.Size(100, 23)
        Me.cmdTrucos.TabIndex = 4
        Me.cmdTrucos.Text = "&Activar trucos"
        Me.cmdTrucos.UseVisualStyleBackColor = True
        Me.cmdTrucos.Visible = False
        '
        'cmdReiniciar
        '
        Me.cmdReiniciar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdReiniciar.Location = New System.Drawing.Point(15, 680)
        Me.cmdReiniciar.Name = "cmdReiniciar"
        Me.cmdReiniciar.Size = New System.Drawing.Size(100, 23)
        Me.cmdReiniciar.TabIndex = 3
        Me.cmdReiniciar.Text = "R&einiciar records"
        Me.cmdReiniciar.UseVisualStyleBackColor = True
        '
        'cmdRecords
        '
        Me.cmdRecords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdRecords.Location = New System.Drawing.Point(15, 650)
        Me.cmdRecords.Name = "cmdRecords"
        Me.cmdRecords.Size = New System.Drawing.Size(100, 23)
        Me.cmdRecords.TabIndex = 2
        Me.cmdRecords.Text = "&Records"
        Me.cmdRecords.UseVisualStyleBackColor = True
        '
        'lblTime
        '
        Me.lblTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTime.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(15, 115)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(100, 35)
        Me.lblTime.TabIndex = 2
        Me.lblTime.Text = "0"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbLevel
        '
        Me.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLevel.FormattingEnabled = True
        Me.cmbLevel.Items.AddRange(New Object() {"Fácil", "Medio", "Difícil", "Personalizado..."})
        Me.cmbLevel.Location = New System.Drawing.Point(15, 15)
        Me.cmbLevel.Name = "cmbLevel"
        Me.cmbLevel.Size = New System.Drawing.Size(100, 21)
        Me.cmbLevel.TabIndex = 2
        '
        'cmdEmpezar
        '
        Me.cmdEmpezar.Location = New System.Drawing.Point(15, 45)
        Me.cmdEmpezar.Name = "cmdEmpezar"
        Me.cmdEmpezar.Size = New System.Drawing.Size(100, 60)
        Me.cmdEmpezar.TabIndex = 0
        Me.cmdEmpezar.Text = "&Empezar"
        Me.cmdEmpezar.UseVisualStyleBackColor = True
        '
        'Minesweeper1
        '
        Me.Minesweeper1.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Minesweeper1.BackgroundImage = CType(resources.GetObject("Minesweeper1.BackgroundImage"), System.Drawing.Image)
        Me.Minesweeper1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Minesweeper1.BoardHeight = 20
        Me.Minesweeper1.BoardWidth = 10
        Me.Minesweeper1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Minesweeper1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Minesweeper1.Location = New System.Drawing.Point(130, 0)
        Me.Minesweeper1.MinesAmount = 10
        Me.Minesweeper1.Name = "Minesweeper1"
        Me.Minesweeper1.Size = New System.Drawing.Size(772, 715)
        Me.Minesweeper1.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(902, 715)
        Me.Controls.Add(Me.Minesweeper1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Buscaminas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Minesweeper1 As Nonogram.Minesweeper
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdEmpezar As System.Windows.Forms.Button
    Friend WithEvents cmbLevel As System.Windows.Forms.ComboBox
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents cmdRecords As System.Windows.Forms.Button
    Friend WithEvents cmdReiniciar As System.Windows.Forms.Button
    Friend WithEvents cmdTrucos As System.Windows.Forms.Button
    Friend WithEvents lblLeft As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents chkMusica As System.Windows.Forms.CheckBox

End Class
