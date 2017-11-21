<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Alta_Certificado
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox_Timbrado_Pwd = New System.Windows.Forms.TextBox()
        Me.TextBox_Timbrado_Usr = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox_Cer = New System.Windows.Forms.TextBox()
        Me.TextBox_Key = New System.Windows.Forms.TextBox()
        Me.TextBox_Pwd = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox_Timbrado_Pwd)
        Me.GroupBox2.Controls.Add(Me.TextBox_Timbrado_Usr)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 144)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(308, 89)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Timbrado"
        '
        'TextBox_Timbrado_Pwd
        '
        Me.TextBox_Timbrado_Pwd.Location = New System.Drawing.Point(113, 53)
        Me.TextBox_Timbrado_Pwd.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Timbrado_Pwd.Name = "TextBox_Timbrado_Pwd"
        Me.TextBox_Timbrado_Pwd.Size = New System.Drawing.Size(156, 22)
        Me.TextBox_Timbrado_Pwd.TabIndex = 3
        '
        'TextBox_Timbrado_Usr
        '
        Me.TextBox_Timbrado_Usr.Location = New System.Drawing.Point(113, 21)
        Me.TextBox_Timbrado_Usr.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Timbrado_Usr.Name = "TextBox_Timbrado_Usr"
        Me.TextBox_Timbrado_Usr.Size = New System.Drawing.Size(156, 22)
        Me.TextBox_Timbrado_Usr.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 57)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 17)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Contraseña"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 25)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Usuario"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox_Cer)
        Me.GroupBox1.Controls.Add(Me.TextBox_Key)
        Me.GroupBox1.Controls.Add(Me.TextBox_Pwd)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 11)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(676, 126)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Certificación"
        '
        'TextBox_Cer
        '
        Me.TextBox_Cer.Location = New System.Drawing.Point(225, 89)
        Me.TextBox_Cer.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Cer.Name = "TextBox_Cer"
        Me.TextBox_Cer.Size = New System.Drawing.Size(317, 22)
        Me.TextBox_Cer.TabIndex = 18
        '
        'TextBox_Key
        '
        Me.TextBox_Key.Location = New System.Drawing.Point(225, 57)
        Me.TextBox_Key.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Key.Name = "TextBox_Key"
        Me.TextBox_Key.Size = New System.Drawing.Size(317, 22)
        Me.TextBox_Key.TabIndex = 17
        '
        'TextBox_Pwd
        '
        Me.TextBox_Pwd.Location = New System.Drawing.Point(225, 25)
        Me.TextBox_Pwd.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Pwd.Name = "TextBox_Pwd"
        Me.TextBox_Pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Pwd.Size = New System.Drawing.Size(317, 22)
        Me.TextBox_Pwd.TabIndex = 16
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(552, 54)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(100, 28)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Examinar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(552, 86)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 28)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Examinar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 92)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Certificado(.Cer)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Llave Privada(.Key)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Contraseña de Llave Privada"
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Location = New System.Drawing.Point(568, 204)
        Me.Button_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Cancelar.TabIndex = 14
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(460, 205)
        Me.Button_Aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Aceptar.TabIndex = 13
        Me.Button_Aceptar.Text = "Aceptar"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'Alta_Certificado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 245)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button_Cancelar)
        Me.Controls.Add(Me.Button_Aceptar)
        Me.MaximumSize = New System.Drawing.Size(726, 292)
        Me.MinimumSize = New System.Drawing.Size(726, 292)
        Me.Name = "Alta_Certificado"
        Me.ShowInTaskbar = False
        Me.Text = "Certificacion y Timbrado"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBox_Timbrado_Pwd As TextBox
    Friend WithEvents TextBox_Timbrado_Usr As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox_Cer As TextBox
    Friend WithEvents TextBox_Key As TextBox
    Friend WithEvents TextBox_Pwd As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button_Cancelar As Button
    Friend WithEvents Button_Aceptar As Button
End Class
