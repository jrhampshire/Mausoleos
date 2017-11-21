<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Conceptos
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
        Me.ComboBox_Unidades = New System.Windows.Forms.ComboBox()
        Me.TextBox_Descripcion = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox_Familia = New System.Windows.Forms.ComboBox()
        Me.TextBox_ValorUnitario = New System.Windows.Forms.TextBox()
        Me.TextBox_Clave = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ComboBox_Unidades
        '
        Me.ComboBox_Unidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Unidades.FormattingEnabled = True
        Me.ComboBox_Unidades.Location = New System.Drawing.Point(146, 93)
        Me.ComboBox_Unidades.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Unidades.Name = "ComboBox_Unidades"
        Me.ComboBox_Unidades.Size = New System.Drawing.Size(360, 24)
        Me.ComboBox_Unidades.TabIndex = 11
        '
        'TextBox_Descripcion
        '
        Me.TextBox_Descripcion.Location = New System.Drawing.Point(146, 40)
        Me.TextBox_Descripcion.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Descripcion.Multiline = True
        Me.TextBox_Descripcion.Name = "TextBox_Descripcion"
        Me.TextBox_Descripcion.Size = New System.Drawing.Size(360, 43)
        Me.TextBox_Descripcion.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(408, 189)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 28)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(300, 189)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox_Familia
        '
        Me.ComboBox_Familia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Familia.FormattingEnabled = True
        Me.ComboBox_Familia.Location = New System.Drawing.Point(146, 156)
        Me.ComboBox_Familia.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Familia.Name = "ComboBox_Familia"
        Me.ComboBox_Familia.Size = New System.Drawing.Size(360, 24)
        Me.ComboBox_Familia.TabIndex = 15
        '
        'TextBox_ValorUnitario
        '
        Me.TextBox_ValorUnitario.Location = New System.Drawing.Point(146, 124)
        Me.TextBox_ValorUnitario.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_ValorUnitario.Name = "TextBox_ValorUnitario"
        Me.TextBox_ValorUnitario.Size = New System.Drawing.Size(360, 22)
        Me.TextBox_ValorUnitario.TabIndex = 13
        '
        'TextBox_Clave
        '
        Me.TextBox_Clave.Location = New System.Drawing.Point(146, 8)
        Me.TextBox_Clave.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Clave.Name = "TextBox_Clave"
        Me.TextBox_Clave.Size = New System.Drawing.Size(177, 22)
        Me.TextBox_Clave.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 159)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Familia"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 127)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Valor Unitario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 95)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 17)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Unidad de Medida"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 44)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Descripción"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Clave"
        '
        'Conceptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 224)
        Me.ControlBox = False
        Me.Controls.Add(Me.ComboBox_Unidades)
        Me.Controls.Add(Me.TextBox_Descripcion)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox_Familia)
        Me.Controls.Add(Me.TextBox_ValorUnitario)
        Me.Controls.Add(Me.TextBox_Clave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximumSize = New System.Drawing.Size(538, 271)
        Me.MinimumSize = New System.Drawing.Size(538, 271)
        Me.Name = "Conceptos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conceptos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox_Unidades As ComboBox
    Friend WithEvents TextBox_Descripcion As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox_Familia As ComboBox
    Friend WithEvents TextBox_ValorUnitario As TextBox
    Friend WithEvents TextBox_Clave As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
