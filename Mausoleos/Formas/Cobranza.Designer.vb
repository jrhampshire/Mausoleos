<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cobranza
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cobranza))
        Me.TextBox_Fecha_Vencimiento = New System.Windows.Forms.TextBox()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button_BuscaContrato = New System.Windows.Forms.Button()
        Me.Label_Gran_Total = New System.Windows.Forms.Label()
        Me.Button_SeleccionarPagos = New System.Windows.Forms.Button()
        Me.Label_Gran_Subtotal = New System.Windows.Forms.Label()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.DataGridView_EstadoCuenta = New System.Windows.Forms.DataGridView()
        Me.Label_Ubicacion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label_Localidad = New System.Windows.Forms.Label()
        Me.Label_Colonia = New System.Windows.Forms.Label()
        Me.Label_Direccion = New System.Windows.Forms.Label()
        Me.Label_RFC = New System.Windows.Forms.Label()
        Me.Label_NombreCte = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox_Contrato = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox_Imprime = New System.Windows.Forms.CheckBox()
        Me.TextBox_Cuenta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox_Metodo_Pago = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.DataGridView_EstadoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox_Fecha_Vencimiento
        '
        Me.TextBox_Fecha_Vencimiento.Location = New System.Drawing.Point(383, 277)
        Me.TextBox_Fecha_Vencimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Fecha_Vencimiento.Name = "TextBox_Fecha_Vencimiento"
        Me.TextBox_Fecha_Vencimiento.Size = New System.Drawing.Size(175, 22)
        Me.TextBox_Fecha_Vencimiento.TabIndex = 55
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(223, 281)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 17)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Fecha de Vencimiento"
        '
        'Button_BuscaContrato
        '
        Me.Button_BuscaContrato.Location = New System.Drawing.Point(172, 8)
        Me.Button_BuscaContrato.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_BuscaContrato.Name = "Button_BuscaContrato"
        Me.Button_BuscaContrato.Size = New System.Drawing.Size(36, 28)
        Me.Button_BuscaContrato.TabIndex = 42
        Me.Button_BuscaContrato.Text = "..."
        Me.Button_BuscaContrato.UseVisualStyleBackColor = True
        '
        'Label_Gran_Total
        '
        Me.Label_Gran_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Gran_Total.Location = New System.Drawing.Point(504, 510)
        Me.Label_Gran_Total.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Gran_Total.Name = "Label_Gran_Total"
        Me.Label_Gran_Total.Size = New System.Drawing.Size(133, 16)
        Me.Label_Gran_Total.TabIndex = 53
        Me.Label_Gran_Total.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label_Gran_Total.Visible = False
        '
        'Button_SeleccionarPagos
        '
        Me.Button_SeleccionarPagos.Location = New System.Drawing.Point(16, 274)
        Me.Button_SeleccionarPagos.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_SeleccionarPagos.Name = "Button_SeleccionarPagos"
        Me.Button_SeleccionarPagos.Size = New System.Drawing.Size(161, 28)
        Me.Button_SeleccionarPagos.TabIndex = 44
        Me.Button_SeleccionarPagos.Text = "Seleccionar Pagos"
        Me.Button_SeleccionarPagos.UseVisualStyleBackColor = True
        '
        'Label_Gran_Subtotal
        '
        Me.Label_Gran_Subtotal.Location = New System.Drawing.Point(504, 474)
        Me.Label_Gran_Subtotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Gran_Subtotal.Name = "Label_Gran_Subtotal"
        Me.Label_Gran_Subtotal.Size = New System.Drawing.Size(133, 16)
        Me.Label_Gran_Subtotal.TabIndex = 52
        Me.Label_Gran_Subtotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label_Gran_Subtotal.Visible = False
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Location = New System.Drawing.Point(868, 505)
        Me.Button_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Cancelar.TabIndex = 48
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(760, 505)
        Me.Button_Aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Aceptar.TabIndex = 46
        Me.Button_Aceptar.Text = "Aceptar"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(259, 510)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 17)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Total:"
        Me.Label12.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(251, 474)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 17)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Subtotal:"
        Me.Label14.Visible = False
        '
        'DataGridView_EstadoCuenta
        '
        Me.DataGridView_EstadoCuenta.AllowUserToAddRows = False
        Me.DataGridView_EstadoCuenta.AllowUserToDeleteRows = False
        Me.DataGridView_EstadoCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_EstadoCuenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView_EstadoCuenta.Location = New System.Drawing.Point(4, 19)
        Me.DataGridView_EstadoCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView_EstadoCuenta.Name = "DataGridView_EstadoCuenta"
        Me.DataGridView_EstadoCuenta.ReadOnly = True
        Me.DataGridView_EstadoCuenta.Size = New System.Drawing.Size(945, 127)
        Me.DataGridView_EstadoCuenta.TabIndex = 0
        '
        'Label_Ubicacion
        '
        Me.Label_Ubicacion.BackColor = System.Drawing.Color.White
        Me.Label_Ubicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_Ubicacion.Location = New System.Drawing.Point(316, 8)
        Me.Label_Ubicacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Ubicacion.Name = "Label_Ubicacion"
        Me.Label_Ubicacion.Size = New System.Drawing.Size(321, 28)
        Me.Label_Ubicacion.TabIndex = 49
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(235, 15)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 17)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Ubicación"
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.DataGridView_EstadoCuenta)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 309)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(953, 150)
        Me.GroupBox2.TabIndex = 45
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pagos"
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
        Me.GroupBox1.Location = New System.Drawing.Point(16, 47)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(953, 147)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Cliente"
        '
        'TextBox_Contrato
        '
        Me.TextBox_Contrato.Location = New System.Drawing.Point(87, 11)
        Me.TextBox_Contrato.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Contrato.Name = "TextBox_Contrato"
        Me.TextBox_Contrato.Size = New System.Drawing.Size(76, 22)
        Me.TextBox_Contrato.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Contrato"
        '
        'CheckBox_Imprime
        '
        Me.CheckBox_Imprime.AutoSize = True
        Me.CheckBox_Imprime.Checked = True
        Me.CheckBox_Imprime.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Imprime.Location = New System.Drawing.Point(629, 279)
        Me.CheckBox_Imprime.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_Imprime.Name = "CheckBox_Imprime"
        Me.CheckBox_Imprime.Size = New System.Drawing.Size(127, 21)
        Me.CheckBox_Imprime.TabIndex = 56
        Me.CheckBox_Imprime.Text = "Imprimir Recibo"
        Me.CheckBox_Imprime.UseVisualStyleBackColor = True
        '
        'TextBox_Cuenta
        '
        Me.TextBox_Cuenta.Location = New System.Drawing.Point(439, 226)
        Me.TextBox_Cuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Cuenta.Name = "TextBox_Cuenta"
        Me.TextBox_Cuenta.Size = New System.Drawing.Size(107, 22)
        Me.TextBox_Cuenta.TabIndex = 58
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(435, 207)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 17)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Cuenta de Pago"
        '
        'ComboBox_Metodo_Pago
        '
        Me.ComboBox_Metodo_Pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Metodo_Pago.FormattingEnabled = True
        Me.ComboBox_Metodo_Pago.Items.AddRange(New Object() {"01 Efectivo", "02 Cheque nominativo", "03 Transferencia electrónica de fondos" & Global.Microsoft.VisualBasic.ChrW(9), "04 Tarjeta de crédito", "05 Monedero electrónico", "06 Dinero electrónico", "08 Vales de despensa", "28 Tarjeta de Débito", "29 Tarjeta de Servicio", "99 Otros"})
        Me.ComboBox_Metodo_Pago.Location = New System.Drawing.Point(20, 226)
        Me.ComboBox_Metodo_Pago.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Metodo_Pago.Name = "ComboBox_Metodo_Pago"
        Me.ComboBox_Metodo_Pago.Size = New System.Drawing.Size(405, 24)
        Me.ComboBox_Metodo_Pago.TabIndex = 57
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 207)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 17)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Metodo de Pago"
        '
        'Cobranza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 545)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox_Cuenta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBox_Metodo_Pago)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CheckBox_Imprime)
        Me.Controls.Add(Me.TextBox_Fecha_Vencimiento)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button_BuscaContrato)
        Me.Controls.Add(Me.Label_Gran_Total)
        Me.Controls.Add(Me.Button_SeleccionarPagos)
        Me.Controls.Add(Me.Label_Gran_Subtotal)
        Me.Controls.Add(Me.Button_Cancelar)
        Me.Controls.Add(Me.Button_Aceptar)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label_Ubicacion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextBox_Contrato)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Cobranza"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobranza"
        CType(Me.DataGridView_EstadoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox_Fecha_Vencimiento As TextBox
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents Label7 As Label
    Friend WithEvents Button_BuscaContrato As Button
    Friend WithEvents Label_Gran_Total As Label
    Friend WithEvents Button_SeleccionarPagos As Button
    Friend WithEvents Label_Gran_Subtotal As Label
    Friend WithEvents Button_Cancelar As Button
    Friend WithEvents Button_Aceptar As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents DataGridView_EstadoCuenta As DataGridView
    Friend WithEvents Label_Ubicacion As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label_Localidad As Label
    Friend WithEvents Label_Colonia As Label
    Friend WithEvents Label_Direccion As Label
    Friend WithEvents Label_RFC As Label
    Friend WithEvents Label_NombreCte As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox_Contrato As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBox_Imprime As CheckBox
    Friend WithEvents TextBox_Cuenta As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox_Metodo_Pago As ComboBox
    Friend WithEvents Label8 As Label
End Class
