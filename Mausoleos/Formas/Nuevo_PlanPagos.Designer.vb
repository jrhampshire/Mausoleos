<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nuevo_PlanPagos
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label_PrecioTotal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox_Anticipo = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox_Mensualidades = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label_Contrato = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(15, 75)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(140, 21)
        Me.CheckBox1.TabIndex = 24
        Me.CheckBox1.Text = "Pago de Contado"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label_PrecioTotal
        '
        Me.Label_PrecioTotal.BackColor = System.Drawing.Color.White
        Me.Label_PrecioTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_PrecioTotal.Location = New System.Drawing.Point(121, 42)
        Me.Label_PrecioTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_PrecioTotal.Name = "Label_PrecioTotal"
        Me.Label_PrecioTotal.Size = New System.Drawing.Size(89, 27)
        Me.Label_PrecioTotal.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 172)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Periodicidad"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Quincenal", "Mensual"})
        Me.ComboBox1.Location = New System.Drawing.Point(121, 169)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(99, 24)
        Me.ComboBox1.TabIndex = 18
        '
        'TextBox_Anticipo
        '
        Me.TextBox_Anticipo.Location = New System.Drawing.Point(121, 103)
        Me.TextBox_Anticipo.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Anticipo.Name = "TextBox_Anticipo"
        Me.TextBox_Anticipo.Size = New System.Drawing.Size(88, 22)
        Me.TextBox_Anticipo.TabIndex = 14
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(13, 199)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 28)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Aceptar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(121, 199)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox_Mensualidades
        '
        Me.TextBox_Mensualidades.Location = New System.Drawing.Point(121, 135)
        Me.TextBox_Mensualidades.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Mensualidades.Name = "TextBox_Mensualidades"
        Me.TextBox_Mensualidades.Size = New System.Drawing.Size(44, 22)
        Me.TextBox_Mensualidades.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 139)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Pagos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 106)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 17)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Pago inicial"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Precio Total"
        '
        'Label_Contrato
        '
        Me.Label_Contrato.BackColor = System.Drawing.Color.White
        Me.Label_Contrato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Contrato.Location = New System.Drawing.Point(121, 11)
        Me.Label_Contrato.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Contrato.Name = "Label_Contrato"
        Me.Label_Contrato.Size = New System.Drawing.Size(89, 27)
        Me.Label_Contrato.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Contrato"
        '
        'Nuevo_PlanPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(233, 238)
        Me.ControlBox = False
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label_PrecioTotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TextBox_Anticipo)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox_Mensualidades)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label_Contrato)
        Me.Controls.Add(Me.Label1)
        Me.MaximumSize = New System.Drawing.Size(251, 285)
        Me.MinimumSize = New System.Drawing.Size(251, 285)
        Me.Name = "Nuevo_PlanPagos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Plan de Pagos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label_PrecioTotal As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox_Anticipo As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox_Mensualidades As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label_Contrato As Label
    Friend WithEvents Label1 As Label
End Class
