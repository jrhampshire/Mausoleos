<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProyeccionCobranza
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Enero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Febrero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marzo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abril = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mayo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Junio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Julio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Septiembre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Octubre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Noviembre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Diciembre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total_Anual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button_Salir = New System.Windows.Forms.Button()
        Me.Button_Imprimir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(984, 420)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Proyección"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Producto, Me.PrecioUnitario, Me.Enero, Me.Febrero, Me.Marzo, Me.Abril, Me.Mayo, Me.Junio, Me.Julio, Me.Agosto, Me.Septiembre, Me.Octubre, Me.Noviembre, Me.Diciembre, Me.Total_Anual})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(978, 401)
        Me.DataGridView1.TabIndex = 0
        '
        'Producto
        '
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        Me.Producto.Width = 75
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.HeaderText = "Precio Unitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.ReadOnly = True
        Me.PrecioUnitario.Width = 101
        '
        'Enero
        '
        Me.Enero.HeaderText = "Enero"
        Me.Enero.Name = "Enero"
        Me.Enero.Width = 60
        '
        'Febrero
        '
        Me.Febrero.HeaderText = "Febrero"
        Me.Febrero.Name = "Febrero"
        Me.Febrero.Width = 68
        '
        'Marzo
        '
        Me.Marzo.HeaderText = "Marzo"
        Me.Marzo.Name = "Marzo"
        Me.Marzo.Width = 61
        '
        'Abril
        '
        Me.Abril.HeaderText = "Abril"
        Me.Abril.Name = "Abril"
        Me.Abril.Width = 52
        '
        'Mayo
        '
        Me.Mayo.HeaderText = "Mayo"
        Me.Mayo.Name = "Mayo"
        Me.Mayo.Width = 58
        '
        'Junio
        '
        Me.Junio.HeaderText = "Junio"
        Me.Junio.Name = "Junio"
        Me.Junio.Width = 57
        '
        'Julio
        '
        Me.Julio.HeaderText = "Julio"
        Me.Julio.Name = "Julio"
        Me.Julio.Width = 53
        '
        'Agosto
        '
        Me.Agosto.HeaderText = "Agosto"
        Me.Agosto.Name = "Agosto"
        Me.Agosto.Width = 65
        '
        'Septiembre
        '
        Me.Septiembre.HeaderText = "Septiembre"
        Me.Septiembre.Name = "Septiembre"
        Me.Septiembre.Width = 85
        '
        'Octubre
        '
        Me.Octubre.HeaderText = "Octubre"
        Me.Octubre.Name = "Octubre"
        Me.Octubre.Width = 70
        '
        'Noviembre
        '
        Me.Noviembre.HeaderText = "Noviembre"
        Me.Noviembre.Name = "Noviembre"
        Me.Noviembre.Width = 83
        '
        'Diciembre
        '
        Me.Diciembre.HeaderText = "Diciembre"
        Me.Diciembre.Name = "Diciembre"
        Me.Diciembre.Width = 79
        '
        'Total_Anual
        '
        Me.Total_Anual.HeaderText = "Total Anual"
        Me.Total_Anual.Name = "Total_Anual"
        Me.Total_Anual.ReadOnly = True
        Me.Total_Anual.Width = 86
        '
        'Button_Salir
        '
        Me.Button_Salir.Location = New System.Drawing.Point(921, 438)
        Me.Button_Salir.Name = "Button_Salir"
        Me.Button_Salir.Size = New System.Drawing.Size(75, 23)
        Me.Button_Salir.TabIndex = 1
        Me.Button_Salir.Text = "Salir"
        Me.Button_Salir.UseVisualStyleBackColor = True
        '
        'Button_Imprimir
        '
        Me.Button_Imprimir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button_Imprimir.Location = New System.Drawing.Point(840, 438)
        Me.Button_Imprimir.Name = "Button_Imprimir"
        Me.Button_Imprimir.Size = New System.Drawing.Size(75, 23)
        Me.Button_Imprimir.TabIndex = 2
        Me.Button_Imprimir.Text = "Imprimir"
        Me.Button_Imprimir.UseVisualStyleBackColor = True
        '
        'ProyeccionCobranza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button_Imprimir
        Me.ClientSize = New System.Drawing.Size(1008, 470)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button_Imprimir)
        Me.Controls.Add(Me.Button_Salir)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1024, 768)
        Me.MinimizeBox = False
        Me.Name = "ProyeccionCobranza"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Proyeccion de Cobranza anual"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button_Salir As System.Windows.Forms.Button
    Friend WithEvents Button_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Enero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Febrero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marzo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Abril As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mayo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Junio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Julio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Septiembre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Octubre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Noviembre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Diciembre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total_Anual As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
