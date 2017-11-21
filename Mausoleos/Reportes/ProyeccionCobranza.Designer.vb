<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProyeccionCobranza
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
        Me.Button_Imprimir = New System.Windows.Forms.Button()
        Me.Total_Anual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Diciembre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Noviembre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Octubre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Septiembre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Julio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button_Salir = New System.Windows.Forms.Button()
        Me.Junio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abril = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marzo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Febrero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Enero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Mayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Imprimir
        '
        Me.Button_Imprimir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Imprimir.Location = New System.Drawing.Point(1118, 537)
        Me.Button_Imprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Imprimir.Name = "Button_Imprimir"
        Me.Button_Imprimir.Size = New System.Drawing.Size(100, 28)
        Me.Button_Imprimir.TabIndex = 5
        Me.Button_Imprimir.Text = "Imprimir"
        Me.Button_Imprimir.UseVisualStyleBackColor = True
        '
        'Total_Anual
        '
        Me.Total_Anual.HeaderText = "Total Anual"
        Me.Total_Anual.Name = "Total_Anual"
        Me.Total_Anual.ReadOnly = True
        Me.Total_Anual.Width = 109
        '
        'Diciembre
        '
        Me.Diciembre.HeaderText = "Diciembre"
        Me.Diciembre.Name = "Diciembre"
        '
        'Noviembre
        '
        Me.Noviembre.HeaderText = "Noviembre"
        Me.Noviembre.Name = "Noviembre"
        Me.Noviembre.Width = 105
        '
        'Octubre
        '
        Me.Octubre.HeaderText = "Octubre"
        Me.Octubre.Name = "Octubre"
        Me.Octubre.Width = 88
        '
        'Septiembre
        '
        Me.Septiembre.HeaderText = "Septiembre"
        Me.Septiembre.Name = "Septiembre"
        Me.Septiembre.Width = 109
        '
        'Agosto
        '
        Me.Agosto.HeaderText = "Agosto"
        Me.Agosto.Name = "Agosto"
        Me.Agosto.Width = 81
        '
        'Julio
        '
        Me.Julio.HeaderText = "Julio"
        Me.Julio.Name = "Julio"
        Me.Julio.Width = 66
        '
        'Button_Salir
        '
        Me.Button_Salir.Location = New System.Drawing.Point(1226, 537)
        Me.Button_Salir.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Salir.Name = "Button_Salir"
        Me.Button_Salir.Size = New System.Drawing.Size(100, 28)
        Me.Button_Salir.TabIndex = 4
        Me.Button_Salir.Text = "Salir"
        Me.Button_Salir.UseVisualStyleBackColor = True
        '
        'Junio
        '
        Me.Junio.HeaderText = "Junio"
        Me.Junio.Name = "Junio"
        Me.Junio.Width = 71
        '
        'Abril
        '
        Me.Abril.HeaderText = "Abril"
        Me.Abril.Name = "Abril"
        Me.Abril.Width = 65
        '
        'Marzo
        '
        Me.Marzo.HeaderText = "Marzo"
        Me.Marzo.Name = "Marzo"
        Me.Marzo.Width = 76
        '
        'Febrero
        '
        Me.Febrero.HeaderText = "Febrero"
        Me.Febrero.Name = "Febrero"
        Me.Febrero.Width = 87
        '
        'Enero
        '
        Me.Enero.HeaderText = "Enero"
        Me.Enero.Name = "Enero"
        Me.Enero.Width = 75
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.HeaderText = "Precio Unitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.ReadOnly = True
        Me.PrecioUnitario.Width = 130
        '
        'Producto
        '
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        Me.Producto.Width = 94
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Producto, Me.PrecioUnitario, Me.Enero, Me.Febrero, Me.Marzo, Me.Abril, Me.Mayo, Me.Junio, Me.Julio, Me.Agosto, Me.Septiembre, Me.Octubre, Me.Noviembre, Me.Diciembre, Me.Total_Anual})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(4, 19)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1304, 494)
        Me.DataGridView1.TabIndex = 0
        '
        'Mayo
        '
        Me.Mayo.HeaderText = "Mayo"
        Me.Mayo.Name = "Mayo"
        Me.Mayo.Width = 71
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1312, 517)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Proyección"
        '
        'ProyeccionCobranza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1341, 578)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button_Imprimir)
        Me.Controls.Add(Me.Button_Salir)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(1359, 625)
        Me.MinimumSize = New System.Drawing.Size(1359, 625)
        Me.Name = "ProyeccionCobranza"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProyeccionCobranza"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button_Imprimir As Button
    Friend WithEvents Total_Anual As DataGridViewTextBoxColumn
    Friend WithEvents Diciembre As DataGridViewTextBoxColumn
    Friend WithEvents Noviembre As DataGridViewTextBoxColumn
    Friend WithEvents Octubre As DataGridViewTextBoxColumn
    Friend WithEvents Septiembre As DataGridViewTextBoxColumn
    Friend WithEvents Agosto As DataGridViewTextBoxColumn
    Friend WithEvents Julio As DataGridViewTextBoxColumn
    Friend WithEvents Button_Salir As Button
    Friend WithEvents Junio As DataGridViewTextBoxColumn
    Friend WithEvents Abril As DataGridViewTextBoxColumn
    Friend WithEvents Marzo As DataGridViewTextBoxColumn
    Friend WithEvents Febrero As DataGridViewTextBoxColumn
    Friend WithEvents Enero As DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents Producto As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Mayo As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
End Class
