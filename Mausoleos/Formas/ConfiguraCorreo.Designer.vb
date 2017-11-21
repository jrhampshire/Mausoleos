<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguraCorreo
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox_Puerto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_Usuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_Pwd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_Servidor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox_Puerto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBox_Usuario)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBox_Pwd)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBox_Servidor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(353, 112)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Correo"
        '
        'TextBox_Puerto
        '
        Me.TextBox_Puerto.Location = New System.Drawing.Point(187, 86)
        Me.TextBox_Puerto.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox_Puerto.Name = "TextBox_Puerto"
        Me.TextBox_Puerto.Size = New System.Drawing.Size(44, 20)
        Me.TextBox_Puerto.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 86)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Número de puerto del servidor"
        '
        'TextBox_Usuario
        '
        Me.TextBox_Usuario.Location = New System.Drawing.Point(187, 41)
        Me.TextBox_Usuario.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox_Usuario.Name = "TextBox_Usuario"
        Me.TextBox_Usuario.Size = New System.Drawing.Size(163, 20)
        Me.TextBox_Usuario.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 41)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombre de usuario:"
        '
        'TextBox_Pwd
        '
        Me.TextBox_Pwd.Location = New System.Drawing.Point(187, 63)
        Me.TextBox_Pwd.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox_Pwd.Name = "TextBox_Pwd"
        Me.TextBox_Pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Pwd.Size = New System.Drawing.Size(163, 20)
        Me.TextBox_Pwd.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Contraseña"
        '
        'TextBox_Servidor
        '
        Me.TextBox_Servidor.Location = New System.Drawing.Point(187, 18)
        Me.TextBox_Servidor.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox_Servidor.Name = "TextBox_Servidor"
        Me.TextBox_Servidor.Size = New System.Drawing.Size(163, 20)
        Me.TextBox_Servidor.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Servidor de correo saliente (SMTP):"
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Location = New System.Drawing.Point(287, 126)
        Me.Button_Cancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cancelar.TabIndex = 3
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(208, 126)
        Me.Button_Aceptar.Margin = New System.Windows.Forms.Padding(2)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Button_Aceptar.TabIndex = 5
        Me.Button_Aceptar.Text = "Aceptar"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'ConfiguraCorreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 158)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button_Cancelar)
        Me.Controls.Add(Me.Button_Aceptar)
        Me.MaximumSize = New System.Drawing.Size(387, 197)
        Me.MinimumSize = New System.Drawing.Size(387, 197)
        Me.Name = "ConfiguraCorreo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configura Correo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox_Puerto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_Usuario As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_Pwd As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox_Servidor As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button_Cancelar As Button
    Friend WithEvents Button_Aceptar As Button
End Class
