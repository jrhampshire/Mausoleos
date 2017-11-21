<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Edita_Usuarios
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Pwd2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Pwd = New System.Windows.Forms.TextBox()
        Me.txt_Usuario = New System.Windows.Forms.TextBox()
        Me.RadioButton_User = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Admon = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox_Observaciones = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox_Nombre = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox_Direccion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox_Tel_Cel = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_Tel_Part = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 114)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(170, 17)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Validacion de Contraseña"
        '
        'txt_Pwd2
        '
        Me.txt_Pwd2.Location = New System.Drawing.Point(12, 134)
        Me.txt_Pwd2.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Pwd2.Name = "txt_Pwd2"
        Me.txt_Pwd2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Pwd2.Size = New System.Drawing.Size(157, 22)
        Me.txt_Pwd2.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 66)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Contraseña"
        '
        'txt_Pwd
        '
        Me.txt_Pwd.Location = New System.Drawing.Point(12, 86)
        Me.txt_Pwd.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Pwd.Name = "txt_Pwd"
        Me.txt_Pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_Pwd.Size = New System.Drawing.Size(157, 22)
        Me.txt_Pwd.TabIndex = 1
        '
        'txt_Usuario
        '
        Me.txt_Usuario.Location = New System.Drawing.Point(12, 39)
        Me.txt_Usuario.Margin = New System.Windows.Forms.Padding(4)
        Me.txt_Usuario.Name = "txt_Usuario"
        Me.txt_Usuario.Size = New System.Drawing.Size(157, 22)
        Me.txt_Usuario.TabIndex = 0
        '
        'RadioButton_User
        '
        Me.RadioButton_User.AutoSize = True
        Me.RadioButton_User.Location = New System.Drawing.Point(8, 52)
        Me.RadioButton_User.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton_User.Name = "RadioButton_User"
        Me.RadioButton_User.Size = New System.Drawing.Size(142, 21)
        Me.RadioButton_User.TabIndex = 3
        Me.RadioButton_User.TabStop = True
        Me.RadioButton_User.Text = "Agente de Ventas"
        Me.RadioButton_User.UseVisualStyleBackColor = True
        '
        'RadioButton_Admon
        '
        Me.RadioButton_Admon.AutoSize = True
        Me.RadioButton_Admon.Location = New System.Drawing.Point(8, 23)
        Me.RadioButton_Admon.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton_Admon.Name = "RadioButton_Admon"
        Me.RadioButton_Admon.Size = New System.Drawing.Size(116, 21)
        Me.RadioButton_Admon.TabIndex = 2
        Me.RadioButton_Admon.TabStop = True
        Me.RadioButton_Admon.Text = "Administrador"
        Me.RadioButton_Admon.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre de Usuario"
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(464, 396)
        Me.Button_Aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Aceptar.TabIndex = 9
        Me.Button_Aceptar.Text = "Aceptar"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox_Observaciones)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 191)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(657, 199)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Usuario"
        '
        'TextBox_Observaciones
        '
        Me.TextBox_Observaciones.Location = New System.Drawing.Point(400, 43)
        Me.TextBox_Observaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Observaciones.Multiline = True
        Me.TextBox_Observaciones.Name = "TextBox_Observaciones"
        Me.TextBox_Observaciones.Size = New System.Drawing.Size(244, 148)
        Me.TextBox_Observaciones.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(396, 23)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 17)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Observaciones"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(227, 113)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(129, 21)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "Ver Contraseña"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton_User)
        Me.GroupBox3.Controls.Add(Me.RadioButton_Admon)
        Me.GroupBox3.Location = New System.Drawing.Point(219, 23)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(165, 82)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Permisos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txt_Pwd2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txt_Pwd)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txt_Usuario)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 23)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(199, 166)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de ingreso"
        '
        'TextBox_Nombre
        '
        Me.TextBox_Nombre.Location = New System.Drawing.Point(12, 39)
        Me.TextBox_Nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Nombre.Name = "TextBox_Nombre"
        Me.TextBox_Nombre.Size = New System.Drawing.Size(487, 22)
        Me.TextBox_Nombre.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 20)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 17)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Nombre:"
        '
        'TextBox_Direccion
        '
        Me.TextBox_Direccion.Location = New System.Drawing.Point(12, 87)
        Me.TextBox_Direccion.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Direccion.Name = "TextBox_Direccion"
        Me.TextBox_Direccion.Size = New System.Drawing.Size(487, 22)
        Me.TextBox_Direccion.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 68)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 17)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Dirección:"
        '
        'TextBox_Tel_Cel
        '
        Me.TextBox_Tel_Cel.Location = New System.Drawing.Point(160, 135)
        Me.TextBox_Tel_Cel.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Tel_Cel.Name = "TextBox_Tel_Cel"
        Me.TextBox_Tel_Cel.Size = New System.Drawing.Size(123, 22)
        Me.TextBox_Tel_Cel.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(156, 116)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Teléfono Celular"
        '
        'TextBox_Tel_Part
        '
        Me.TextBox_Tel_Part.Location = New System.Drawing.Point(12, 135)
        Me.TextBox_Tel_Part.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Tel_Part.Name = "TextBox_Tel_Part"
        Me.TextBox_Tel_Part.Size = New System.Drawing.Size(123, 22)
        Me.TextBox_Tel_Part.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 116)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Teléfono Particular"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextBox_Tel_Cel)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.TextBox_Tel_Part)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.TextBox_Direccion)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.TextBox_Nombre)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 10)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(657, 174)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos Generales"
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Location = New System.Drawing.Point(572, 396)
        Me.Button_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Cancelar.TabIndex = 10
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Edita_Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 434)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button_Aceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button_Cancelar)
        Me.MaximumSize = New System.Drawing.Size(705, 481)
        Me.MinimumSize = New System.Drawing.Size(705, 481)
        Me.Name = "Edita_Usuarios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edita Usuarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents txt_Pwd2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_Pwd As TextBox
    Friend WithEvents txt_Usuario As TextBox
    Friend WithEvents RadioButton_User As RadioButton
    Friend WithEvents RadioButton_Admon As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Button_Aceptar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox_Observaciones As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBox_Nombre As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox_Direccion As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox_Tel_Cel As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_Tel_Part As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Button_Cancelar As Button
End Class
