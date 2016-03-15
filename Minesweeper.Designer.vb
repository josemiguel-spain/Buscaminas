<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Minesweeper
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.components = New System.ComponentModel.Container()
        Me.tmrClock = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'tmrClock
        '
        Me.tmrClock.Enabled = True
        '
        'Minesweeper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Name = "Minesweeper"
        Me.Size = New System.Drawing.Size(685, 376)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrClock As System.Windows.Forms.Timer

End Class
