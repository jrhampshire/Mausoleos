<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pregunta_Secreta
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
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.TextBox_Respuesta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox_Pregunta = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Location = New System.Drawing.Point(446, 116)
        Me.Button_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Cancelar.TabIndex = 9
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(338, 116)
        Me.Button_Aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Aceptar.TabIndex = 7
        Me.Button_Aceptar.Text = "Aceptar"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'TextBox_Respuesta
        '
        Me.TextBox_Respuesta.Location = New System.Drawing.Point(15, 75)
        Me.TextBox_Respuesta.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Respuesta.Name = "TextBox_Respuesta"
        Me.TextBox_Respuesta.Size = New System.Drawing.Size(529, 22)
        Me.TextBox_Respuesta.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Respuesta"
        '
        'ComboBox_Pregunta
        '
        Me.ComboBox_Pregunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Pregunta.FormattingEnabled = True
        Me.ComboBox_Pregunta.Items.AddRange(New Object() {"Cual es la ciudad donde naciste", "Cual es tu color favorito", "Cual es la ciudad donde nacio tu padre", "Cual es la ciudad donde nacio tu madre", "Donde estudiaste la primaria", "Cual es el nombre de tu mascota ", "Cual es la marca de tu primer carro"})
        Me.ComboBox_Pregunta.Location = New System.Drawing.Point(15, 26)
        Me.ComboBox_Pregunta.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Pregunta.Name = "ComboBox_Pregunta"
        Me.ComboBox_Pregunta.Size = New System.Drawing.Size(529, 24)
        Me.ComboBox_Pregunta.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Pregunta Secreta"
        '
        'Pregunta_Secreta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 150)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button_Cancelar)
        Me.Controls.Add(Me.Button_Aceptar)
        Me.Controls.Add(Me.TextBox_Respuesta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox_Pregunta)
        Me.Controls.Add(Me.Label1)
        Me.MaximumSize = New System.Drawing.Size(578, 197)
        Me.MinimumSize = New System.Drawing.Size(578, 197)
        Me.Name = "Pregunta_Secreta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pregunta Secreta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Cancelar As Button
    Friend WithEvents Button_Aceptar As Button
    Friend WithEvents TextBox_Respuesta As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox_Pregunta As ComboBox
    Friend WithEvents Label1 As Label
End Class
