<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecords
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblHard = New System.Windows.Forms.Label()
        Me.lblNormal = New System.Windows.Forms.Label()
        Me.lblEasy = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 50)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fácil:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 50)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Normal:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 50)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Difícil:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHard
        '
        Me.lblHard.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHard.Location = New System.Drawing.Point(180, 132)
        Me.lblHard.Name = "lblHard"
        Me.lblHard.Size = New System.Drawing.Size(145, 50)
        Me.lblHard.TabIndex = 6
        Me.lblHard.Text = "999"
        Me.lblHard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNormal
        '
        Me.lblNormal.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNormal.Location = New System.Drawing.Point(180, 77)
        Me.lblNormal.Name = "lblNormal"
        Me.lblNormal.Size = New System.Drawing.Size(145, 50)
        Me.lblNormal.TabIndex = 5
        Me.lblNormal.Text = "999"
        Me.lblNormal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEasy
        '
        Me.lblEasy.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEasy.Location = New System.Drawing.Point(180, 22)
        Me.lblEasy.Name = "lblEasy"
        Me.lblEasy.Size = New System.Drawing.Size(145, 50)
        Me.lblEasy.TabIndex = 4
        Me.lblEasy.Text = "999"
        Me.lblEasy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Location = New System.Drawing.Point(130, 217)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCerrar.TabIndex = 7
        Me.cmdCerrar.Text = "&Cerrar"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'frmRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.lblHard)
        Me.Controls.Add(Me.lblNormal)
        Me.Controls.Add(Me.lblEasy)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmRecords"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblHard As System.Windows.Forms.Label
    Friend WithEvents lblNormal As System.Windows.Forms.Label
    Friend WithEvents lblEasy As System.Windows.Forms.Label
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
End Class
