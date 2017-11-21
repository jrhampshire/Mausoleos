<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cobranza2
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.TextBox_Contrato = New System.Windows.Forms.TextBox()
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label_Localidad = New System.Windows.Forms.Label()
        Me.Label_Colonia = New System.Windows.Forms.Label()
        Me.Label_Direccion = New System.Windows.Forms.Label()
        Me.Label_RFC = New System.Windows.Forms.Label()
        Me.Label_NombreCte = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label_Ubicacion = New System.Windows.Forms.Label()
        Me.Button_BuscaContrato = New System.Windows.Forms.Button()
        Me.Button_SeleccionarPagos = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox_Cuenta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox_Metodo_Pago = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(338, 268)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(129, 22)
        Me.DateTimePicker1.TabIndex = 60
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Location = New System.Drawing.Point(869, 265)
        Me.Button_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Cancelar.TabIndex = 57
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'TextBox_Contrato
        '
        Me.TextBox_Contrato.Location = New System.Drawing.Point(87, 9)
        Me.TextBox_Contrato.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Contrato.Name = "TextBox_Contrato"
        Me.TextBox_Contrato.Size = New System.Drawing.Size(76, 22)
        Me.TextBox_Contrato.TabIndex = 50
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(721, 265)
        Me.Button_Aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(140, 28)
        Me.Button_Aceptar.TabIndex = 56
        Me.Button_Aceptar.Text = "Registrar Pago"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Contrato"
        '
        'Label_Localidad
        '
        Me.Label_Localidad.BackColor = System.Drawing.Color.White
        Me.Label_Localidad.Location = New System.Drawing.Point(541, 105)
        Me.Label_Localidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Localidad.Name = "Label_Localidad"
        Me.Label_Localidad.Size = New System.Drawing.Size(400, 28)
        Me.Label_Localidad.TabIndex = 9
        '
        'Label_Colonia
        '
        Me.Label_Colonia.BackColor = System.Drawing.Color.White
        Me.Label_Colonia.Location = New System.Drawing.Point(541, 75)
        Me.Label_Colonia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Colonia.Name = "Label_Colonia"
        Me.Label_Colonia.Size = New System.Drawing.Size(400, 28)
        Me.Label_Colonia.TabIndex = 8
        '
        'Label_Direccion
        '
        Me.Label_Direccion.BackColor = System.Drawing.Color.White
        Me.Label_Direccion.Location = New System.Drawing.Point(541, 46)
        Me.Label_Direccion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Direccion.Name = "Label_Direccion"
        Me.Label_Direccion.Size = New System.Drawing.Size(400, 28)
        Me.Label_Direccion.TabIndex = 7
        '
        'Label_RFC
        '
        Me.Label_RFC.BackColor = System.Drawing.Color.White
        Me.Label_RFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_RFC.Location = New System.Drawing.Point(76, 60)
        Me.Label_RFC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_RFC.Name = "Label_RFC"
        Me.Label_RFC.Size = New System.Drawing.Size(231, 28)
        Me.Label_RFC.TabIndex = 6
        '
        'Label_NombreCte
        '
        Me.Label_NombreCte.BackColor = System.Drawing.Color.White
        Me.Label_NombreCte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_NombreCte.Location = New System.Drawing.Point(76, 20)
        Me.Label_NombreCte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_NombreCte.Name = "Label_NombreCte"
        Me.Label_NombreCte.Size = New System.Drawing.Size(439, 28)
        Me.Label_NombreCte.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 62)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 17)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "RFC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(537, 22)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Dirección"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(222, 271)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 17)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Fecha de Pago"
        '
        'Label_Ubicacion
        '
        Me.Label_Ubicacion.BackColor = System.Drawing.Color.White
        Me.Label_Ubicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Ubicacion.Location = New System.Drawing.Point(316, 8)
        Me.Label_Ubicacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Ubicacion.Name = "Label_Ubicacion"
        Me.Label_Ubicacion.Size = New System.Drawing.Size(321, 28)
        Me.Label_Ubicacion.TabIndex = 58
        '
        'Button_BuscaContrato
        '
        Me.Button_BuscaContrato.Location = New System.Drawing.Point(172, 6)
        Me.Button_BuscaContrato.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_BuscaContrato.Name = "Button_BuscaContrato"
        Me.Button_BuscaContrato.Size = New System.Drawing.Size(36, 28)
        Me.Button_BuscaContrato.TabIndex = 52
        Me.Button_BuscaContrato.Text = "..."
        Me.Button_BuscaContrato.UseVisualStyleBackColor = True
        '
        'Button_SeleccionarPagos
        '
        Me.Button_SeleccionarPagos.Location = New System.Drawing.Point(39, 265)
        Me.Button_SeleccionarPagos.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_SeleccionarPagos.Name = "Button_SeleccionarPagos"
        Me.Button_SeleccionarPagos.Size = New System.Drawing.Size(161, 28)
        Me.Button_SeleccionarPagos.TabIndex = 53
        Me.Button_SeleccionarPagos.Text = "Seleccionar Recibo"
        Me.Button_SeleccionarPagos.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(235, 13)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 17)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Ubicación"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label_Localidad)
        Me.GroupBox1.Controls.Add(Me.Label_Colonia)
        Me.GroupBox1.Controls.Add(Me.Label_Direccion)
        Me.GroupBox1.Controls.Add(Me.Label_RFC)
        Me.GroupBox1.Controls.Add(Me.Label_NombreCte)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 45)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(953, 160)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cliente"
        '
        'TextBox_Cuenta
        '
        Me.TextBox_Cuenta.Location = New System.Drawing.Point(446, 228)
        Me.TextBox_Cuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Cuenta.Name = "TextBox_Cuenta"
        Me.TextBox_Cuenta.Size = New System.Drawing.Size(107, 22)
        Me.TextBox_Cuenta.TabIndex = 62
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(442, 209)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 17)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "Cuenta de Pago"
        '
        'ComboBox_Metodo_Pago
        '
        Me.ComboBox_Metodo_Pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Metodo_Pago.FormattingEnabled = True
        Me.ComboBox_Metodo_Pago.Items.AddRange(New Object() {"01 Efectivo", "02 Cheque nominativo", "03 Transferencia electrónica de fondos" & Global.Microsoft.VisualBasic.ChrW(9), "04 Tarjeta de crédito", "05 Monedero electrónico", "06 Dinero electrónico", "08 Vales de despensa", "28 Tarjeta de Débito", "29 Tarjeta de Servicio", "99 Otros"})
        Me.ComboBox_Metodo_Pago.Location = New System.Drawing.Point(27, 228)
        Me.ComboBox_Metodo_Pago.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Metodo_Pago.Name = "ComboBox_Metodo_Pago"
        Me.ComboBox_Metodo_Pago.Size = New System.Drawing.Size(405, 24)
        Me.ComboBox_Metodo_Pago.TabIndex = 61
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 209)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 17)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Metodo de Pago"
        '
        'Cobranza2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 306)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox_Cuenta)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComboBox_Metodo_Pago)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Button_Cancelar)
        Me.Controls.Add(Me.TextBox_Contrato)
        Me.Controls.Add(Me.Button_Aceptar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label_Ubicacion)
        Me.Controls.Add(Me.Button_BuscaContrato)
        Me.Controls.Add(Me.Button_SeleccionarPagos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Cobranza2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Pagos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Button_Cancelar As Button
    Friend WithEvents TextBox_Contrato As TextBox
    Friend WithEvents Button_Aceptar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label_Localidad As Label
    Friend WithEvents Label_Colonia As Label
    Friend WithEvents Label_Direccion As Label
    Friend WithEvents Label_RFC As Label
    Friend WithEvents Label_NombreCte As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label_Ubicacion As Label
    Friend WithEvents Button_BuscaContrato As Button
    Friend WithEvents Button_SeleccionarPagos As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox_Cuenta As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ComboBox_Metodo_Pago As ComboBox
    Friend WithEvents Label8 As Label
End Class
