<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nueva_Gaveta
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
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.ComboBox_Fila = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Columna = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Modulo = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Ubicacion = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Piso = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_Observaciones = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox_Capacidad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(374, 243)
        Me.Button_Aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Aceptar.TabIndex = 26
        Me.Button_Aceptar.Text = "Aceptar"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'ComboBox_Fila
        '
        Me.ComboBox_Fila.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Fila.FormattingEnabled = True
        Me.ComboBox_Fila.Location = New System.Drawing.Point(95, 155)
        Me.ComboBox_Fila.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Fila.Name = "ComboBox_Fila"
        Me.ComboBox_Fila.Size = New System.Drawing.Size(160, 24)
        Me.ComboBox_Fila.TabIndex = 23
        '
        'ComboBox_Columna
        '
        Me.ComboBox_Columna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Columna.FormattingEnabled = True
        Me.ComboBox_Columna.Location = New System.Drawing.Point(95, 123)
        Me.ComboBox_Columna.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Columna.Name = "ComboBox_Columna"
        Me.ComboBox_Columna.Size = New System.Drawing.Size(160, 24)
        Me.ComboBox_Columna.TabIndex = 22
        '
        'ComboBox_Modulo
        '
        Me.ComboBox_Modulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Modulo.FormattingEnabled = True
        Me.ComboBox_Modulo.Location = New System.Drawing.Point(95, 90)
        Me.ComboBox_Modulo.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Modulo.Name = "ComboBox_Modulo"
        Me.ComboBox_Modulo.Size = New System.Drawing.Size(160, 24)
        Me.ComboBox_Modulo.TabIndex = 21
        '
        'ComboBox_Ubicacion
        '
        Me.ComboBox_Ubicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Ubicacion.FormattingEnabled = True
        Me.ComboBox_Ubicacion.Location = New System.Drawing.Point(95, 57)
        Me.ComboBox_Ubicacion.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Ubicacion.Name = "ComboBox_Ubicacion"
        Me.ComboBox_Ubicacion.Size = New System.Drawing.Size(160, 24)
        Me.ComboBox_Ubicacion.TabIndex = 20
        '
        'ComboBox_Piso
        '
        Me.ComboBox_Piso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Piso.FormattingEnabled = True
        Me.ComboBox_Piso.Location = New System.Drawing.Point(96, 23)
        Me.ComboBox_Piso.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Piso.Name = "ComboBox_Piso"
        Me.ComboBox_Piso.Size = New System.Drawing.Size(160, 24)
        Me.ComboBox_Piso.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 165)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 17)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Fila"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 127)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 17)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Columna"
        '
        'TextBox_Observaciones
        '
        Me.TextBox_Observaciones.Location = New System.Drawing.Point(323, 97)
        Me.TextBox_Observaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Observaciones.Multiline = True
        Me.TextBox_Observaciones.Name = "TextBox_Observaciones"
        Me.TextBox_Observaciones.Size = New System.Drawing.Size(255, 138)
        Me.TextBox_Observaciones.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(319, 73)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 17)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Observaciones"
        '
        'TextBox_Capacidad
        '
        Me.TextBox_Capacidad.Location = New System.Drawing.Point(405, 31)
        Me.TextBox_Capacidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Capacidad.Name = "TextBox_Capacidad"
        Me.TextBox_Capacidad.Size = New System.Drawing.Size(32, 22)
        Me.TextBox_Capacidad.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 94)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Modulo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Ubicacion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Piso"
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Location = New System.Drawing.Point(482, 243)
        Me.Button_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Cancelar.TabIndex = 25
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(319, 34)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 17)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Capacidad"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox_Fila)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Columna)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Modulo)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Ubicacion)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Piso)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 7)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(265, 198)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubicacion"
        '
        'Nueva_Gaveta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 279)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button_Aceptar)
        Me.Controls.Add(Me.TextBox_Observaciones)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox_Capacidad)
        Me.Controls.Add(Me.Button_Cancelar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(615, 326)
        Me.MinimumSize = New System.Drawing.Size(615, 326)
        Me.Name = "Nueva_Gaveta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Nicho"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Aceptar As Button
    Friend WithEvents ComboBox_Fila As ComboBox
    Friend WithEvents ComboBox_Columna As ComboBox
    Friend WithEvents ComboBox_Modulo As ComboBox
    Friend WithEvents ComboBox_Ubicacion As ComboBox
    Friend WithEvents ComboBox_Piso As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_Observaciones As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox_Capacidad As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button_Cancelar As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
