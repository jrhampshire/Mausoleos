<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ciudades
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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_Estado = New System.Windows.Forms.ComboBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Btn_Borrar = New System.Windows.Forms.Button()
        Me.Municipio = New System.Windows.Forms.Label()
        Me.CB_Municipio = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Ciudad = New System.Windows.Forms.TextBox()
        Me.Btn_Salir = New System.Windows.Forms.Button()
        Me.Btn_Agregar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(293, 73)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(37, 28)
        Me.Button3.TabIndex = 39
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(293, 40)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(37, 28)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(293, 6)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 28)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(97, 9)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(185, 24)
        Me.ComboBox1.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 17)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Pais"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Estado"
        '
        'CB_Estado
        '
        Me.CB_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Estado.FormattingEnabled = True
        Me.CB_Estado.Location = New System.Drawing.Point(97, 42)
        Me.CB_Estado.Margin = New System.Windows.Forms.Padding(4)
        Me.CB_Estado.Name = "CB_Estado"
        Me.CB_Estado.Size = New System.Drawing.Size(185, 24)
        Me.CB_Estado.TabIndex = 26
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(17, 179)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(312, 228)
        Me.ListBox1.TabIndex = 33
        '
        'Btn_Borrar
        '
        Me.Btn_Borrar.Location = New System.Drawing.Point(231, 143)
        Me.Btn_Borrar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Borrar.Name = "Btn_Borrar"
        Me.Btn_Borrar.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Borrar.TabIndex = 31
        Me.Btn_Borrar.Text = "Borrar"
        Me.Btn_Borrar.UseVisualStyleBackColor = True
        '
        'Municipio
        '
        Me.Municipio.AutoSize = True
        Me.Municipio.Location = New System.Drawing.Point(13, 79)
        Me.Municipio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Municipio.Name = "Municipio"
        Me.Municipio.Size = New System.Drawing.Size(74, 17)
        Me.Municipio.TabIndex = 32
        Me.Municipio.Text = "Municipios"
        '
        'CB_Municipio
        '
        Me.CB_Municipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Municipio.FormattingEnabled = True
        Me.CB_Municipio.Location = New System.Drawing.Point(97, 75)
        Me.CB_Municipio.Margin = New System.Windows.Forms.Padding(4)
        Me.CB_Municipio.Name = "CB_Municipio"
        Me.CB_Municipio.Size = New System.Drawing.Size(185, 24)
        Me.CB_Municipio.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 115)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Ciudad"
        '
        'Txt_Ciudad
        '
        Me.Txt_Ciudad.Location = New System.Drawing.Point(97, 111)
        Me.Txt_Ciudad.Margin = New System.Windows.Forms.Padding(4)
        Me.Txt_Ciudad.Name = "Txt_Ciudad"
        Me.Txt_Ciudad.Size = New System.Drawing.Size(232, 22)
        Me.Txt_Ciudad.TabIndex = 29
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Location = New System.Drawing.Point(231, 415)
        Me.Btn_Salir.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Salir.TabIndex = 34
        Me.Btn_Salir.Text = "Salir"
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Btn_Agregar
        '
        Me.Btn_Agregar.Location = New System.Drawing.Point(123, 143)
        Me.Btn_Agregar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Agregar.Name = "Btn_Agregar"
        Me.Btn_Agregar.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Agregar.TabIndex = 30
        Me.Btn_Agregar.Text = "Agregar"
        Me.Btn_Agregar.UseVisualStyleBackColor = True
        '
        'Ciudades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 448)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CB_Estado)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Btn_Borrar)
        Me.Controls.Add(Me.Municipio)
        Me.Controls.Add(Me.CB_Municipio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_Ciudad)
        Me.Controls.Add(Me.Btn_Salir)
        Me.Controls.Add(Me.Btn_Agregar)
        Me.MaximumSize = New System.Drawing.Size(362, 495)
        Me.MinimumSize = New System.Drawing.Size(362, 495)
        Me.Name = "Ciudades"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ciudades"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CB_Estado As ComboBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Btn_Borrar As Button
    Friend WithEvents Municipio As Label
    Friend WithEvents CB_Municipio As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Ciudad As TextBox
    Friend WithEvents Btn_Salir As Button
    Friend WithEvents Btn_Agregar As Button
End Class
