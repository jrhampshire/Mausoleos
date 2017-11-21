<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Estados
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBox = New System.Windows.Forms.ListBox()
        Me.Btn_Borrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Estado = New System.Windows.Forms.TextBox()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(292, 1)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 28)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(71, 3)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(211, 24)
        Me.ComboBox1.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 7)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 17)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Pais"
        '
        'ListBox
        '
        Me.ListBox.FormattingEnabled = True
        Me.ListBox.ItemHeight = 16
        Me.ListBox.Location = New System.Drawing.Point(11, 107)
        Me.ListBox.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox.Name = "ListBox"
        Me.ListBox.Size = New System.Drawing.Size(317, 212)
        Me.ListBox.TabIndex = 19
        '
        'Btn_Borrar
        '
        Me.Btn_Borrar.Location = New System.Drawing.Point(229, 71)
        Me.Btn_Borrar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Borrar.Name = "Btn_Borrar"
        Me.Btn_Borrar.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Borrar.TabIndex = 18
        Me.Btn_Borrar.Text = "Borrar"
        Me.Btn_Borrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 45)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Estado"
        '
        'Txt_Estado
        '
        Me.Txt_Estado.Location = New System.Drawing.Point(71, 37)
        Me.Txt_Estado.Margin = New System.Windows.Forms.Padding(4)
        Me.Txt_Estado.Name = "Txt_Estado"
        Me.Txt_Estado.Size = New System.Drawing.Size(257, 22)
        Me.Txt_Estado.TabIndex = 16
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Location = New System.Drawing.Point(229, 338)
        Me.Btn_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Cancelar.TabIndex = 15
        Me.Btn_Cancelar.Text = "Salir"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Location = New System.Drawing.Point(119, 71)
        Me.Btn_Aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Aceptar.TabIndex = 14
        Me.Btn_Aceptar.Text = "Agregar"
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Estados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 366)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBox)
        Me.Controls.Add(Me.Btn_Borrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_Estado)
        Me.Controls.Add(Me.Btn_Cancelar)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.MaximumSize = New System.Drawing.Size(357, 413)
        Me.MinimumSize = New System.Drawing.Size(357, 413)
        Me.Name = "Estados"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estados"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBox As ListBox
    Friend WithEvents Btn_Borrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Estado As TextBox
    Friend WithEvents Btn_Cancelar As Button
    Friend WithEvents Btn_Aceptar As Button
End Class
