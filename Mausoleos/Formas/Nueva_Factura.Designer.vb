<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nueva_Factura
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
        Me.Button_Concepto = New System.Windows.Forms.Button()
        Me.Button_Borrar_Articulo = New System.Windows.Forms.Button()
        Me.Button_Agregar_Articulo = New System.Windows.Forms.Button()
        Me.Label_Total = New System.Windows.Forms.Label()
        Me.Label_IVA = New System.Windows.Forms.Label()
        Me.Label_SubTotal = New System.Windows.Forms.Label()
        Me.TextBox_Precio = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox_Cuenta = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox_Metodo_Pago = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label_Direccion2 = New System.Windows.Forms.Label()
        Me.Label_Direccion = New System.Windows.Forms.Label()
        Me.Label_RFC = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox_Cliente = New System.Windows.Forms.ComboBox()
        Me.TextBox_Cantidad = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label_Gran_Total = New System.Windows.Forms.Label()
        Me.Label_Gran_IVA = New System.Windows.Forms.Label()
        Me.Label_Gran_Subtotal = New System.Windows.Forms.Label()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label_Descripcion = New System.Windows.Forms.Label()
        Me.TextBox_Clave = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Concepto
        '
        Me.Button_Concepto.Location = New System.Drawing.Point(63, 48)
        Me.Button_Concepto.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Concepto.Name = "Button_Concepto"
        Me.Button_Concepto.Size = New System.Drawing.Size(29, 28)
        Me.Button_Concepto.TabIndex = 16
        Me.Button_Concepto.Text = "..."
        Me.Button_Concepto.UseVisualStyleBackColor = True
        '
        'Button_Borrar_Articulo
        '
        Me.Button_Borrar_Articulo.Location = New System.Drawing.Point(993, 52)
        Me.Button_Borrar_Articulo.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Borrar_Articulo.Name = "Button_Borrar_Articulo"
        Me.Button_Borrar_Articulo.Size = New System.Drawing.Size(100, 28)
        Me.Button_Borrar_Articulo.TabIndex = 8
        Me.Button_Borrar_Articulo.Text = "Borrar"
        Me.Button_Borrar_Articulo.UseVisualStyleBackColor = True
        '
        'Button_Agregar_Articulo
        '
        Me.Button_Agregar_Articulo.Location = New System.Drawing.Point(888, 52)
        Me.Button_Agregar_Articulo.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Agregar_Articulo.Name = "Button_Agregar_Articulo"
        Me.Button_Agregar_Articulo.Size = New System.Drawing.Size(100, 28)
        Me.Button_Agregar_Articulo.TabIndex = 7
        Me.Button_Agregar_Articulo.Text = "Agregar"
        Me.Button_Agregar_Articulo.UseVisualStyleBackColor = True
        '
        'Label_Total
        '
        Me.Label_Total.BackColor = System.Drawing.Color.White
        Me.Label_Total.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_Total.Location = New System.Drawing.Point(813, 52)
        Me.Label_Total.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Total.Name = "Label_Total"
        Me.Label_Total.Size = New System.Drawing.Size(67, 25)
        Me.Label_Total.TabIndex = 6
        '
        'Label_IVA
        '
        Me.Label_IVA.BackColor = System.Drawing.Color.White
        Me.Label_IVA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_IVA.Location = New System.Drawing.Point(739, 52)
        Me.Label_IVA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_IVA.Name = "Label_IVA"
        Me.Label_IVA.Size = New System.Drawing.Size(67, 25)
        Me.Label_IVA.TabIndex = 5
        '
        'Label_SubTotal
        '
        Me.Label_SubTotal.BackColor = System.Drawing.Color.White
        Me.Label_SubTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_SubTotal.Location = New System.Drawing.Point(664, 52)
        Me.Label_SubTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_SubTotal.Name = "Label_SubTotal"
        Me.Label_SubTotal.Size = New System.Drawing.Size(67, 25)
        Me.Label_SubTotal.TabIndex = 4
        '
        'TextBox_Precio
        '
        Me.TextBox_Precio.Location = New System.Drawing.Point(579, 52)
        Me.TextBox_Precio.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Precio.Name = "TextBox_Precio"
        Me.TextBox_Precio.Size = New System.Drawing.Size(55, 22)
        Me.TextBox_Precio.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(825, 25)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 17)
        Me.Label19.TabIndex = 10
        Me.Label19.Text = "Total"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(4, 19)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1081, 104)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox_Cuenta)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Metodo_Pago)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboBox_Cliente)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1105, 336)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Receptor"
        '
        'TextBox_Cuenta
        '
        Me.TextBox_Cuenta.Location = New System.Drawing.Point(980, 39)
        Me.TextBox_Cuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Cuenta.Name = "TextBox_Cuenta"
        Me.TextBox_Cuenta.Size = New System.Drawing.Size(107, 22)
        Me.TextBox_Cuenta.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(976, 20)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Cuenta de Pago"
        '
        'ComboBox_Metodo_Pago
        '
        Me.ComboBox_Metodo_Pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Metodo_Pago.FormattingEnabled = True
        Me.ComboBox_Metodo_Pago.Items.AddRange(New Object() {"01 Efectivo", "02 Cheque nominativo", "03 Transferencia electrónica de fondos", "04 Tarjeta de crédito", "05 Monedero electrónico", "06 Dinero electrónico", "08 Vales de despensa", "28 Tarjeta de Débito", "29 Tarjeta de Servicio", "99 Otros"})
        Me.ComboBox_Metodo_Pago.Location = New System.Drawing.Point(561, 39)
        Me.ComboBox_Metodo_Pago.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Metodo_Pago.Name = "ComboBox_Metodo_Pago"
        Me.ComboBox_Metodo_Pago.Size = New System.Drawing.Size(405, 24)
        Me.ComboBox_Metodo_Pago.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(557, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Metodo de Pago"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label_Direccion2)
        Me.GroupBox4.Controls.Add(Me.Label_Direccion)
        Me.GroupBox4.Controls.Add(Me.Label_RFC)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 73)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(537, 126)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        '
        'Label_Direccion2
        '
        Me.Label_Direccion2.BackColor = System.Drawing.Color.White
        Me.Label_Direccion2.Location = New System.Drawing.Point(8, 81)
        Me.Label_Direccion2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Direccion2.Name = "Label_Direccion2"
        Me.Label_Direccion2.Size = New System.Drawing.Size(519, 28)
        Me.Label_Direccion2.TabIndex = 0
        '
        'Label_Direccion
        '
        Me.Label_Direccion.BackColor = System.Drawing.Color.White
        Me.Label_Direccion.Location = New System.Drawing.Point(9, 53)
        Me.Label_Direccion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Direccion.Name = "Label_Direccion"
        Me.Label_Direccion.Size = New System.Drawing.Size(519, 28)
        Me.Label_Direccion.TabIndex = 1
        '
        'Label_RFC
        '
        Me.Label_RFC.BackColor = System.Drawing.Color.White
        Me.Label_RFC.Location = New System.Drawing.Point(9, 25)
        Me.Label_RFC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_RFC.Name = "Label_RFC"
        Me.Label_RFC.Size = New System.Drawing.Size(519, 28)
        Me.Label_RFC.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(571, 98)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(521, 100)
        Me.TextBox2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(557, 73)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Observaciones"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'ComboBox_Cliente
        '
        Me.ComboBox_Cliente.FormattingEnabled = True
        Me.ComboBox_Cliente.Location = New System.Drawing.Point(12, 39)
        Me.ComboBox_Cliente.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Cliente.Name = "ComboBox_Cliente"
        Me.ComboBox_Cliente.Size = New System.Drawing.Size(536, 24)
        Me.ComboBox_Cliente.TabIndex = 1
        '
        'TextBox_Cantidad
        '
        Me.TextBox_Cantidad.Location = New System.Drawing.Point(515, 52)
        Me.TextBox_Cantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Cantidad.Name = "TextBox_Cantidad"
        Me.TextBox_Cantidad.Size = New System.Drawing.Size(55, 22)
        Me.TextBox_Cantidad.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(755, 25)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 17)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "IVA"
        '
        'Label_Gran_Total
        '
        Me.Label_Gran_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Gran_Total.Location = New System.Drawing.Point(960, 665)
        Me.Label_Gran_Total.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Gran_Total.Name = "Label_Gran_Total"
        Me.Label_Gran_Total.Size = New System.Drawing.Size(133, 16)
        Me.Label_Gran_Total.TabIndex = 49
        Me.Label_Gran_Total.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label_Gran_IVA
        '
        Me.Label_Gran_IVA.Location = New System.Drawing.Point(960, 628)
        Me.Label_Gran_IVA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Gran_IVA.Name = "Label_Gran_IVA"
        Me.Label_Gran_IVA.Size = New System.Drawing.Size(133, 16)
        Me.Label_Gran_IVA.TabIndex = 48
        Me.Label_Gran_IVA.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label_Gran_Subtotal
        '
        Me.Label_Gran_Subtotal.Location = New System.Drawing.Point(960, 596)
        Me.Label_Gran_Subtotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Gran_Subtotal.Name = "Label_Gran_Subtotal"
        Me.Label_Gran_Subtotal.Size = New System.Drawing.Size(133, 16)
        Me.Label_Gran_Subtotal.TabIndex = 47
        Me.Label_Gran_Subtotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Location = New System.Drawing.Point(1011, 694)
        Me.Button_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Cancelar.TabIndex = 3
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(900, 694)
        Me.Button_Aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Aceptar.TabIndex = 2
        Me.Button_Aceptar.Text = "Aceptar"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(588, 665)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 17)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Total:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(587, 628)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 17)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "IVA:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(580, 596)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 17)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Subtotal:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button_Concepto)
        Me.GroupBox5.Controls.Add(Me.Button_Borrar_Articulo)
        Me.GroupBox5.Controls.Add(Me.Button_Agregar_Articulo)
        Me.GroupBox5.Controls.Add(Me.Label_Total)
        Me.GroupBox5.Controls.Add(Me.Label_IVA)
        Me.GroupBox5.Controls.Add(Me.Label_SubTotal)
        Me.GroupBox5.Controls.Add(Me.TextBox_Precio)
        Me.GroupBox5.Controls.Add(Me.TextBox_Cantidad)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label_Descripcion)
        Me.GroupBox5.Controls.Add(Me.TextBox_Clave)
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 358)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(1105, 212)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Conceptos"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(664, 25)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 17)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Subtotal"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(579, 25)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 17)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Importe"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(509, 25)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 17)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Cantidad"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(97, 25)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 17)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Descripcion"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 25)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 17)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Clave"
        '
        'Label_Descripcion
        '
        Me.Label_Descripcion.BackColor = System.Drawing.Color.White
        Me.Label_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label_Descripcion.Location = New System.Drawing.Point(101, 52)
        Me.Label_Descripcion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_Descripcion.Name = "Label_Descripcion"
        Me.Label_Descripcion.Size = New System.Drawing.Size(405, 25)
        Me.Label_Descripcion.TabIndex = 1
        '
        'TextBox_Clave
        '
        Me.TextBox_Clave.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Clave.Location = New System.Drawing.Point(12, 52)
        Me.TextBox_Clave.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox_Clave.Name = "TextBox_Clave"
        Me.TextBox_Clave.Size = New System.Drawing.Size(43, 20)
        Me.TextBox_Clave.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.DataGridView1)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 84)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Size = New System.Drawing.Size(1089, 127)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        '
        'Nueva_Factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1128, 734)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label_Gran_Total)
        Me.Controls.Add(Me.Label_Gran_IVA)
        Me.Controls.Add(Me.Label_Gran_Subtotal)
        Me.Controls.Add(Me.Button_Cancelar)
        Me.Controls.Add(Me.Button_Aceptar)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox5)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Nueva_Factura"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva_Factura"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Concepto As Button
    Friend WithEvents Button_Borrar_Articulo As Button
    Friend WithEvents Button_Agregar_Articulo As Button
    Friend WithEvents Label_Total As Label
    Friend WithEvents Label_IVA As Label
    Friend WithEvents Label_SubTotal As Label
    Friend WithEvents TextBox_Precio As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label_Direccion2 As Label
    Friend WithEvents Label_Direccion As Label
    Friend WithEvents Label_RFC As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox_Cliente As ComboBox
    Friend WithEvents TextBox_Cantidad As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label_Gran_Total As Label
    Friend WithEvents Label_Gran_IVA As Label
    Friend WithEvents Label_Gran_Subtotal As Label
    Friend WithEvents Button_Cancelar As Button
    Friend WithEvents Button_Aceptar As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label_Descripcion As Label
    Friend WithEvents TextBox_Clave As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents TextBox_Cuenta As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox_Metodo_Pago As ComboBox
    Friend WithEvents Label3 As Label
End Class
