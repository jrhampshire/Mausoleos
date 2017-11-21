<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Edita_Productos
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
        Me.Label_Clave = New System.Windows.Forms.Label()
        Me.ComboBox_Unidades = New System.Windows.Forms.ComboBox()
        Me.TextBox_Descripcion = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox_Familia = New System.Windows.Forms.ComboBox()
        Me.TextBox_ValorUnitario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label_Clave
        '
        Me.Label_Clave.BackColor = System.Drawing.Color.White
        Me.Label_Clave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Clave.Location = New System.Drawing.Point(144, 5)
        Me.Label_Clave.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Clave.Name = "Label_Clave"
        Me.Label_Clave.Size = New System.Drawing.Size(133, 25)
        Me.Label_Clave.TabIndex = 31
        '
        'ComboBox_Unidades
        '
        Me.ComboBox_Unidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Unidades.FormattingEnabled = True
        Me.ComboBox_Unidades.Location = New System.Drawing.Point(144, 87)
        Me.ComboBox_Unidades.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Unidades.Name = "ComboBox_Unidades"
        Me.ComboBox_Unidades.Size = New System.Drawing.Size(360, 24)
        Me.ComboBox_Unidades.TabIndex = 23
        '
        'TextBox_Descripcion
        '
        Me.TextBox_Descripcion.Location = New System.Drawing.Point(144, 34)
        Me.TextBox_Descripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Descripcion.Multiline = True
        Me.TextBox_Descripcion.Name = "TextBox_Descripcion"
        Me.TextBox_Descripcion.Size = New System.Drawing.Size(360, 43)
        Me.TextBox_Descripcion.TabIndex = 21
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(406, 183)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 28)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(298, 183)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox_Familia
        '
        Me.ComboBox_Familia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Familia.FormattingEnabled = True
        Me.ComboBox_Familia.Location = New System.Drawing.Point(144, 150)
        Me.ComboBox_Familia.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Familia.Name = "ComboBox_Familia"
        Me.ComboBox_Familia.Size = New System.Drawing.Size(360, 24)
        Me.ComboBox_Familia.TabIndex = 27
        '
        'TextBox_ValorUnitario
        '
        Me.TextBox_ValorUnitario.Location = New System.Drawing.Point(144, 118)
        Me.TextBox_ValorUnitario.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_ValorUnitario.Name = "TextBox_ValorUnitario"
        Me.TextBox_ValorUnitario.Size = New System.Drawing.Size(360, 22)
        Me.TextBox_ValorUnitario.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 154)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Familia"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 122)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 17)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Valor Unitario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 90)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 17)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Unidad de Medida"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 38)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Clave"
        '
        'Edita_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 217)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label_Clave)
        Me.Controls.Add(Me.ComboBox_Unidades)
        Me.Controls.Add(Me.TextBox_Descripcion)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox_Familia)
        Me.Controls.Add(Me.TextBox_ValorUnitario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximumSize = New System.Drawing.Size(534, 264)
        Me.MinimumSize = New System.Drawing.Size(534, 264)
        Me.Name = "Edita_Productos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edición de Productos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label_Clave As Label
    Friend WithEvents ComboBox_Unidades As ComboBox
    Friend WithEvents TextBox_Descripcion As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox_Familia As ComboBox
    Friend WithEvents TextBox_ValorUnitario As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
