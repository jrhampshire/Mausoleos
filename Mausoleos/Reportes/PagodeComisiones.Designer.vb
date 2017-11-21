<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PagodeComisiones
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
        Me.Button_Salir = New System.Windows.Forms.ToolStripButton()
        Me.Button_PagarComision = New System.Windows.Forms.ToolStripButton()
        Me.Button_Genera_Reporte = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImporteaPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteInicial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComisionesPagadas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MensualidadesPagadas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mensualidades = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Contrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pagar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ComisionesPorPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_Salir
        '
        Me.Button_Salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_Salir.Image = Global.Mausoleos.My.Resources.Resources.Log_Out_48x48
        Me.Button_Salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_Salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_Salir.Name = "Button_Salir"
        Me.Button_Salir.Size = New System.Drawing.Size(52, 52)
        Me.Button_Salir.Text = "Salir"
        '
        'Button_PagarComision
        '
        Me.Button_PagarComision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_PagarComision.Image = Global.Mausoleos.My.Resources.Resources.credit_cards_48
        Me.Button_PagarComision.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_PagarComision.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_PagarComision.Name = "Button_PagarComision"
        Me.Button_PagarComision.Size = New System.Drawing.Size(52, 52)
        Me.Button_PagarComision.Text = "Pagar Comision"
        '
        'Button_Genera_Reporte
        '
        Me.Button_Genera_Reporte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_Genera_Reporte.Image = Global.Mausoleos.My.Resources.Resources.Refresh_48x48
        Me.Button_Genera_Reporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_Genera_Reporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_Genera_Reporte.Name = "Button_Genera_Reporte"
        Me.Button_Genera_Reporte.Size = New System.Drawing.Size(52, 52)
        Me.Button_Genera_Reporte.Text = "Genera Reporte"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.AutoSize = False
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(293, 28)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(73, 52)
        Me.ToolStripLabel1.Text = "Vendedor"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripComboBox1, Me.Button_Genera_Reporte, Me.Button_PagarComision, Me.ToolStripSeparator1, Me.Button_Salir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(995, 55)
        Me.ToolStrip1.TabIndex = 20
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'ImporteaPagar
        '
        Me.ImporteaPagar.HeaderText = "Importe a Pagar"
        Me.ImporteaPagar.Name = "ImporteaPagar"
        Me.ImporteaPagar.ReadOnly = True
        '
        'ImporteInicial
        '
        Me.ImporteInicial.HeaderText = "ImporteInicial"
        Me.ImporteInicial.Name = "ImporteInicial"
        Me.ImporteInicial.Visible = False
        '
        'ComisionesPagadas
        '
        Me.ComisionesPagadas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ComisionesPagadas.HeaderText = "Comisiones Pagadas"
        Me.ComisionesPagadas.Name = "ComisionesPagadas"
        Me.ComisionesPagadas.Width = 154
        '
        'MensualidadesPagadas
        '
        Me.MensualidadesPagadas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MensualidadesPagadas.HeaderText = "Mensualidades Pagadas"
        Me.MensualidadesPagadas.Name = "MensualidadesPagadas"
        Me.MensualidadesPagadas.Width = 175
        '
        'Mensualidades
        '
        Me.Mensualidades.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Mensualidades.HeaderText = "Mensualidades "
        Me.Mensualidades.Name = "Mensualidades"
        Me.Mensualidades.Width = 136
        '
        'Contrato
        '
        Me.Contrato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Contrato.HeaderText = "Contrato"
        Me.Contrato.Name = "Contrato"
        Me.Contrato.Width = 91
        '
        'Pagar
        '
        Me.Pagar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Pagar.HeaderText = "Pagar"
        Me.Pagar.Name = "Pagar"
        Me.Pagar.Width = 52
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pagar, Me.Contrato, Me.Mensualidades, Me.MensualidadesPagadas, Me.ComisionesPagadas, Me.ComisionesPorPagar, Me.ImporteInicial, Me.ImporteaPagar})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(4, 19)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(957, 539)
        Me.DataGridView1.TabIndex = 0
        '
        'ComisionesPorPagar
        '
        Me.ComisionesPorPagar.HeaderText = "Comisiones a pagar"
        Me.ComisionesPorPagar.Name = "ComisionesPorPagar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 71)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(965, 562)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Comisiones por pagar"
        '
        'PagodeComisiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 633)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(1013, 680)
        Me.MinimumSize = New System.Drawing.Size(1013, 680)
        Me.Name = "PagodeComisiones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago de Comisiones"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Salir As ToolStripButton
    Friend WithEvents Button_PagarComision As ToolStripButton
    Friend WithEvents Button_Genera_Reporte As ToolStripButton
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ImporteaPagar As DataGridViewTextBoxColumn
    Friend WithEvents ImporteInicial As DataGridViewTextBoxColumn
    Friend WithEvents ComisionesPagadas As DataGridViewTextBoxColumn
    Friend WithEvents MensualidadesPagadas As DataGridViewTextBoxColumn
    Friend WithEvents Mensualidades As DataGridViewTextBoxColumn
    Friend WithEvents Contrato As DataGridViewTextBoxColumn
    Friend WithEvents Pagar As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ComisionesPorPagar As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
End Class
