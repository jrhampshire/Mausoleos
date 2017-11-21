<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RespaldaSQL
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
        Me.txtdestino = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTNAEXAMINAR = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Btnrespaldar = New System.Windows.Forms.Button()
        Me.Btnsalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNAEXAMINAR)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtdestino)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(748, 66)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Crear Respaldo"
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
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(303, 93)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(242, 21)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Mandar base de datos por correo"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Btnrespaldar
        '
        Me.Btnrespaldar.Location = New System.Drawing.Point(555, 88)
        Me.Btnrespaldar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btnrespaldar.Name = "Btnrespaldar"
        Me.Btnrespaldar.Size = New System.Drawing.Size(100, 28)
        Me.Btnrespaldar.TabIndex = 5
        Me.Btnrespaldar.Text = "Respaldar"
        Me.Btnrespaldar.UseVisualStyleBackColor = True
        '
        'Btnsalir
        '
        Me.Btnsalir.Location = New System.Drawing.Point(663, 89)
        Me.Btnsalir.Margin = New System.Windows.Forms.Padding(4)
        Me.Btnsalir.Name = "Btnsalir"
        Me.Btnsalir.Size = New System.Drawing.Size(100, 28)
        Me.Btnsalir.TabIndex = 6
        Me.Btnsalir.Text = "Salir"
        Me.Btnsalir.UseVisualStyleBackColor = True
        '
        'RespaldaSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 130)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Btnrespaldar)
        Me.Controls.Add(Me.Btnsalir)
        Me.MaximumSize = New System.Drawing.Size(798, 177)
        Me.MinimumSize = New System.Drawing.Size(798, 177)
        Me.Name = "RespaldaSQL"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Respalda Base de Datos SQL"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtdestino As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTNAEXAMINAR As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Btnrespaldar As Button
    Friend WithEvents Btnsalir As Button
End Class
