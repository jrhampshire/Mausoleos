<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Municipios
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.CB_Estado = New System.Windows.Forms.ComboBox()
        Me.Btn_Borrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Municipio = New System.Windows.Forms.TextBox()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(289, 37)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(37, 28)
        Me.Button2.TabIndex = 33
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(289, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 28)
        Me.Button1.TabIndex = 32
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(86, 6)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(193, 24)
        Me.ComboBox1.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 17)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Pais"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 49)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Estado"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(11, 154)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(313, 212)
        Me.ListBox1.TabIndex = 28
        '
        'CB_Estado
        '
        Me.CB_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Estado.FormattingEnabled = True
        Me.CB_Estado.Location = New System.Drawing.Point(86, 40)
        Me.CB_Estado.Margin = New System.Windows.Forms.Padding(4)
        Me.CB_Estado.Name = "CB_Estado"
        Me.CB_Estado.Size = New System.Drawing.Size(193, 24)
        Me.CB_Estado.TabIndex = 27
        '
        'Btn_Borrar
        '
        Me.Btn_Borrar.Location = New System.Drawing.Point(226, 118)
        Me.Btn_Borrar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Borrar.Name = "Btn_Borrar"
        Me.Btn_Borrar.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Borrar.TabIndex = 26
        Me.Btn_Borrar.Text = "Borrar"
        Me.Btn_Borrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 81)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 17)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Municipio"
        '
        'Txt_Municipio
        '
        Me.Txt_Municipio.Location = New System.Drawing.Point(86, 73)
        Me.Txt_Municipio.Margin = New System.Windows.Forms.Padding(4)
        Me.Txt_Municipio.Name = "Txt_Municipio"
        Me.Txt_Municipio.Size = New System.Drawing.Size(239, 22)
        Me.Txt_Municipio.TabIndex = 24
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Location = New System.Drawing.Point(226, 385)
        Me.Btn_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Cancelar.TabIndex = 23
        Me.Btn_Cancelar.Text = "Salir"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Location = New System.Drawing.Point(115, 118)
        Me.Btn_Aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Aceptar.TabIndex = 22
        Me.Btn_Aceptar.Text = "Agregar"
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Municipios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 416)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.CB_Estado)
        Me.Controls.Add(Me.Btn_Borrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_Municipio)
        Me.Controls.Add(Me.Btn_Cancelar)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.MaximumSize = New System.Drawing.Size(351, 463)
        Me.MinimumSize = New System.Drawing.Size(351, 463)
        Me.Name = "Municipios"
        Me.ShowInTaskbar = False
        Me.Text = "Municipios"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents CB_Estado As ComboBox
    Friend WithEvents Btn_Borrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Municipio As TextBox
    Friend WithEvents Btn_Cancelar As Button
    Friend WithEvents Btn_Aceptar As Button
End Class
