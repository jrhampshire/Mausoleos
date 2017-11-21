<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cargar_Facturas_Faltantes
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
        Me.Btnrespaldar = New System.Windows.Forms.Button()
        Me.Btnsalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTNAEXAMINAR = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtdestino = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btnrespaldar
        '
        Me.Btnrespaldar.Location = New System.Drawing.Point(552, 91)
        Me.Btnrespaldar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btnrespaldar.Name = "Btnrespaldar"
        Me.Btnrespaldar.Size = New System.Drawing.Size(100, 28)
        Me.Btnrespaldar.TabIndex = 8
        Me.Btnrespaldar.Text = "Cargar Datos"
        Me.Btnrespaldar.UseVisualStyleBackColor = True
        '
        'Btnsalir
        '
        Me.Btnsalir.Location = New System.Drawing.Point(660, 92)
        Me.Btnsalir.Margin = New System.Windows.Forms.Padding(4)
        Me.Btnsalir.Name = "Btnsalir"
        Me.Btnsalir.Size = New System.Drawing.Size(100, 28)
        Me.Btnsalir.TabIndex = 9
        Me.Btnsalir.Text = "Salir"
        Me.Btnsalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNAEXAMINAR)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtdestino)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 17)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(748, 66)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ruta de CFDI"
        '
        'BTNAEXAMINAR
        '
        Me.BTNAEXAMINAR.Location = New System.Drawing.Point(683, 21)
        Me.BTNAEXAMINAR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTNAEXAMINAR.Name = "BTNAEXAMINAR"
        Me.BTNAEXAMINAR.Size = New System.Drawing.Size(37, 28)
        Me.BTNAEXAMINAR.TabIndex = 0
        Me.BTNAEXAMINAR.Text = "..."
        Me.BTNAEXAMINAR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Destino"
        '
        'txtdestino
        '
        Me.txtdestino.Location = New System.Drawing.Point(73, 23)
        Me.txtdestino.Margin = New System.Windows.Forms.Padding(4)
        Me.txtdestino.Name = "txtdestino"
        Me.txtdestino.ReadOnly = True
        Me.txtdestino.Size = New System.Drawing.Size(600, 22)
        Me.txtdestino.TabIndex = 1
        '
        'Cargar_Facturas_Faltantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 136)
        Me.Controls.Add(Me.Btnrespaldar)
        Me.Controls.Add(Me.Btnsalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(792, 183)
        Me.MinimumSize = New System.Drawing.Size(792, 183)
        Me.Name = "Cargar_Facturas_Faltantes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargar Facturas Faltantes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btnrespaldar As Button
    Friend WithEvents Btnsalir As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTNAEXAMINAR As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtdestino As TextBox
End Class
