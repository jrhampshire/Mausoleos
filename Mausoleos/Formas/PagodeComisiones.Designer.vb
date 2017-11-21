<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PagodeComisiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PagodeComisiones))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Pagar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Contrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mensualidades = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MensualidadesPagadas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComisionesPagadas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComisionesPorPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteInicial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteaPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.Button_Genera_Reporte = New System.Windows.Forms.ToolStripButton()
        Me.Button_PagarComision = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Button_Salir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(724, 457)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Comisiones por pagar"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pagar, Me.Contrato, Me.Mensualidades, Me.MensualidadesPagadas, Me.ComisionesPagadas, Me.ComisionesPorPagar, Me.ImporteInicial, Me.ImporteaPagar})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(718, 438)
        Me.DataGridView1.TabIndex = 0
        '
        'Pagar
        '
        Me.Pagar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Pagar.HeaderText = "Pagar"
        Me.Pagar.Name = "Pagar"
        Me.Pagar.Width = 41
        '
        'Contrato
        '
        Me.Contrato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Contrato.HeaderText = "Contrato"
        Me.Contrato.Name = "Contrato"
        Me.Contrato.Width = 72
        '
        'Mensualidades
        '
        Me.Mensualidades.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Mensualidades.HeaderText = "Mensualidades "
        Me.Mensualidades.Name = "Mensualidades"
        Me.Mensualidades.Width = 106
        '
        'MensualidadesPagadas
        '
        Me.MensualidadesPagadas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MensualidadesPagadas.HeaderText = "Mensualidades Pagadas"
        Me.MensualidadesPagadas.Name = "MensualidadesPagadas"
        Me.MensualidadesPagadas.Width = 135
        '
        'ComisionesPagadas
        '
        Me.ComisionesPagadas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ComisionesPagadas.HeaderText = "Comisiones Pagadas"
        Me.ComisionesPagadas.Name = "ComisionesPagadas"
        Me.ComisionesPagadas.Width = 119
        '
        'ComisionesPorPagar
        '
        Me.ComisionesPorPagar.HeaderText = "Comisiones a pagar"
        Me.ComisionesPorPagar.Name = "ComisionesPorPagar"
        '
        'ImporteInicial
        '
        Me.ImporteInicial.HeaderText = "ImporteInicial"
        Me.ImporteInicial.Name = "ImporteInicial"
        Me.ImporteInicial.Visible = False
        '
        'ImporteaPagar
        '
        Me.ImporteaPagar.HeaderText = "Importe a Pagar"
        Me.ImporteaPagar.Name = "ImporteaPagar"
        Me.ImporteaPagar.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripComboBox1, Me.Button_Genera_Reporte, Me.Button_PagarComision, Me.ToolStripSeparator1, Me.Button_Salir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(748, 55)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(58, 52)
        Me.ToolStripLabel1.Text = "Vendedor"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.AutoSize = False
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(221, 23)
        '
        'Button_Genera_Reporte
        '
        Me.Button_Genera_Reporte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_Genera_Reporte.Image = CType(resources.GetObject("Button_Genera_Reporte.Image"), System.Drawing.Image)
        Me.Button_Genera_Reporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_Genera_Reporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_Genera_Reporte.Name = "Button_Genera_Reporte"
        Me.Button_Genera_Reporte.Size = New System.Drawing.Size(52, 52)
        Me.Button_Genera_Reporte.Text = "Genera Reporte"
        '
        'Button_PagarComision
        '
        Me.Button_PagarComision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_PagarComision.Image = Global.Mausoleo_2014.My.Resources.Resources.Credit_Cards_48
        Me.Button_PagarComision.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_PagarComision.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_PagarComision.Name = "Button_PagarComision"
        Me.Button_PagarComision.Size = New System.Drawing.Size(52, 52)
        Me.Button_PagarComision.Text = "Pagar Comision"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'Button_Salir
        '
        Me.Button_Salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_Salir.Image = Global.Mausoleo_2014.My.Resources.Resources.Salir
        Me.Button_Salir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_Salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_Salir.Name = "Button_Salir"
        Me.Button_Salir.Size = New System.Drawing.Size(52, 52)
        Me.Button_Salir.Text = "Salir"
        '
        'PagodeComisiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 522)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximumSize = New System.Drawing.Size(764, 561)
        Me.MinimumSize = New System.Drawing.Size(764, 561)
        Me.Name = "PagodeComisiones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pago de Comisiones"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Button_Genera_Reporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Button_Salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Button_PagarComision As System.Windows.Forms.ToolStripButton
    Friend WithEvents Pagar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Contrato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mensualidades As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MensualidadesPagadas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComisionesPagadas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComisionesPorPagar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImporteInicial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImporteaPagar As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
