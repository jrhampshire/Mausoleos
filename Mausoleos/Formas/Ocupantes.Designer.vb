<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ocupantes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox_Autorizacion = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Defuncion = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Cremacion = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker_Ingreso = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker_Defuncion = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox_Nombre = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataGridView_SUD = New System.Windows.Forms.DataGridView()
        Me.Button_Agregar = New System.Windows.Forms.Button()
        Me.Button_Quitar = New System.Windows.Forms.Button()
        Me.Button_Aceptar = New System.Windows.Forms.Button()
        Me.Button_Cancelar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView_SUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox_Autorizacion)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Defuncion)
        Me.GroupBox1.Controls.Add(Me.CheckBox_Cremacion)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 114)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(595, 68)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Documentos Entregados"
        '
        'CheckBox_Autorizacion
        '
        Me.CheckBox_Autorizacion.AutoSize = True
        Me.CheckBox_Autorizacion.Location = New System.Drawing.Point(371, 23)
        Me.CheckBox_Autorizacion.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_Autorizacion.Name = "CheckBox_Autorizacion"
        Me.CheckBox_Autorizacion.Size = New System.Drawing.Size(184, 21)
        Me.CheckBox_Autorizacion.TabIndex = 2
        Me.CheckBox_Autorizacion.Text = "Formato de Autorización"
        Me.CheckBox_Autorizacion.UseVisualStyleBackColor = True
        '
        'CheckBox_Defuncion
        '
        Me.CheckBox_Defuncion.AutoSize = True
        Me.CheckBox_Defuncion.Location = New System.Drawing.Point(209, 23)
        Me.CheckBox_Defuncion.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_Defuncion.Name = "CheckBox_Defuncion"
        Me.CheckBox_Defuncion.Size = New System.Drawing.Size(146, 21)
        Me.CheckBox_Defuncion.TabIndex = 1
        Me.CheckBox_Defuncion.Text = "Acta de Defunción"
        Me.CheckBox_Defuncion.UseVisualStyleBackColor = True
        '
        'CheckBox_Cremacion
        '
        Me.CheckBox_Cremacion.AutoSize = True
        Me.CheckBox_Cremacion.Location = New System.Drawing.Point(9, 25)
        Me.CheckBox_Cremacion.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox_Cremacion.Name = "CheckBox_Cremacion"
        Me.CheckBox_Cremacion.Size = New System.Drawing.Size(188, 21)
        Me.CheckBox_Cremacion.TabIndex = 0
        Me.CheckBox_Cremacion.Text = "Certificado de Cremación"
        Me.CheckBox_Cremacion.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(320, 61)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(173, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Fecha de Ingreso al Nicho"
        '
        'DateTimePicker_Ingreso
        '
        Me.DateTimePicker_Ingreso.Location = New System.Drawing.Point(324, 81)
        Me.DateTimePicker_Ingreso.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker_Ingreso.Name = "DateTimePicker_Ingreso"
        Me.DateTimePicker_Ingreso.Size = New System.Drawing.Size(265, 22)
        Me.DateTimePicker_Ingreso.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 61)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Fecha de Defunción"
        '
        'DateTimePicker_Defuncion
        '
        Me.DateTimePicker_Defuncion.Location = New System.Drawing.Point(21, 81)
        Me.DateTimePicker_Defuncion.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker_Defuncion.Name = "DateTimePicker_Defuncion"
        Me.DateTimePicker_Defuncion.Size = New System.Drawing.Size(265, 22)
        Me.DateTimePicker_Defuncion.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Nombre"
        '
        'ComboBox_Nombre
        '
        Me.ComboBox_Nombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Nombre.FormattingEnabled = True
        Me.ComboBox_Nombre.Location = New System.Drawing.Point(21, 32)
        Me.ComboBox_Nombre.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox_Nombre.Name = "ComboBox_Nombre"
        Me.ComboBox_Nombre.Size = New System.Drawing.Size(589, 24)
        Me.ComboBox_Nombre.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView_SUD)
        Me.GroupBox2.Controls.Add(Me.Button_Agregar)
        Me.GroupBox2.Controls.Add(Me.Button_Quitar)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 189)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(596, 174)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Servicios Ocupados"
        '
        'DataGridView_SUD
        '
        Me.DataGridView_SUD.AllowUserToAddRows = False
        Me.DataGridView_SUD.AllowUserToDeleteRows = False
        Me.DataGridView_SUD.AllowUserToOrderColumns = True
        Me.DataGridView_SUD.AllowUserToResizeColumns = False
        Me.DataGridView_SUD.AllowUserToResizeRows = False
        Me.DataGridView_SUD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView_SUD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView_SUD.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView_SUD.Location = New System.Drawing.Point(13, 59)
        Me.DataGridView_SUD.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView_SUD.MultiSelect = False
        Me.DataGridView_SUD.Name = "DataGridView_SUD"
        Me.DataGridView_SUD.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_SUD.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView_SUD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView_SUD.Size = New System.Drawing.Size(575, 107)
        Me.DataGridView_SUD.TabIndex = 6
        '
        'Button_Agregar
        '
        Me.Button_Agregar.Location = New System.Drawing.Point(13, 23)
        Me.Button_Agregar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Agregar.Name = "Button_Agregar"
        Me.Button_Agregar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Agregar.TabIndex = 5
        Me.Button_Agregar.Text = "Agregar"
        Me.Button_Agregar.UseVisualStyleBackColor = True
        '
        'Button_Quitar
        '
        Me.Button_Quitar.Location = New System.Drawing.Point(121, 23)
        Me.Button_Quitar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Quitar.Name = "Button_Quitar"
        Me.Button_Quitar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Quitar.TabIndex = 4
        Me.Button_Quitar.Text = "Quitar"
        Me.Button_Quitar.UseVisualStyleBackColor = True
        '
        'Button_Aceptar
        '
        Me.Button_Aceptar.Location = New System.Drawing.Point(404, 369)
        Me.Button_Aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Aceptar.Name = "Button_Aceptar"
        Me.Button_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Aceptar.TabIndex = 18
        Me.Button_Aceptar.Text = "Aceptar"
        Me.Button_Aceptar.UseVisualStyleBackColor = True
        '
        'Button_Cancelar
        '
        Me.Button_Cancelar.Location = New System.Drawing.Point(512, 370)
        Me.Button_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Cancelar.Name = "Button_Cancelar"
        Me.Button_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Cancelar.TabIndex = 17
        Me.Button_Cancelar.Text = "Cancelar"
        Me.Button_Cancelar.UseVisualStyleBackColor = True
        '
        'Ocupantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 410)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker_Ingreso)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker_Defuncion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox_Nombre)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button_Aceptar)
        Me.Controls.Add(Me.Button_Cancelar)
        Me.MinimumSize = New System.Drawing.Size(646, 457)
        Me.Name = "Ocupantes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ocupantes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView_SUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBox_Autorizacion As CheckBox
    Friend WithEvents CheckBox_Defuncion As CheckBox
    Friend WithEvents CheckBox_Cremacion As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker_Ingreso As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker_Defuncion As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox_Nombre As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DataGridView_SUD As DataGridView
    Friend WithEvents Button_Agregar As Button
    Friend WithEvents Button_Quitar As Button
    Friend WithEvents Button_Aceptar As Button
    Friend WithEvents Button_Cancelar As Button
End Class
