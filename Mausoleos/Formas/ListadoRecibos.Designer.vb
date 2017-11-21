<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoRecibos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadoRecibos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Button_AgregaRecibo = New System.Windows.Forms.ToolStripButton()
        Me.Button_Pagos = New System.Windows.Forms.ToolStripButton()
        Me.Button_Imprime = New System.Windows.Forms.ToolStripButton()
        Me.Facturar_Recibos = New System.Windows.Forms.ToolStripButton()
        Me.Button_CancelaRecibo = New System.Windows.Forms.ToolStripButton()
        Me.Button_ExportaExcell = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Button_Salir = New System.Windows.Forms.ToolStripButton()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker_FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker_FechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 116)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1156, 578)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Listado de Recibos"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(4, 19)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1148, 555)
        Me.DataGridView1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.Button_AgregaRecibo, Me.Button_Pagos, Me.Button_Imprime, Me.Facturar_Recibos, Me.Button_CancelaRecibo, Me.Button_ExportaExcell, Me.ToolStripSeparator1, Me.Button_Salir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1187, 55)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Button_AgregaRecibo
        '
        Me.Button_AgregaRecibo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_AgregaRecibo.Image = Global.Mausoleos.My.Resources.Resources.Add_48x48
        Me.Button_AgregaRecibo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_AgregaRecibo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_AgregaRecibo.Name = "Button_AgregaRecibo"
        Me.Button_AgregaRecibo.Size = New System.Drawing.Size(52, 52)
        Me.Button_AgregaRecibo.Text = "Nuevo Recibo"
        '
        'Button_Pagos
        '
        Me.Button_Pagos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_Pagos.Image = Global.Mausoleos.My.Resources.Resources.credit_cards_48
        Me.Button_Pagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_Pagos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_Pagos.Name = "Button_Pagos"
        Me.Button_Pagos.Size = New System.Drawing.Size(52, 52)
        Me.Button_Pagos.Text = "Registrar Pagos"
        '
        'Button_Imprime
        '
        Me.Button_Imprime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_Imprime.Image = Global.Mausoleos.My.Resources.Resources.Print_48x48
        Me.Button_Imprime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_Imprime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_Imprime.Name = "Button_Imprime"
        Me.Button_Imprime.Size = New System.Drawing.Size(52, 52)
        Me.Button_Imprime.Text = "ToolStripButton1"
        '
        'Facturar_Recibos
        '
        Me.Facturar_Recibos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Facturar_Recibos.Image = Global.Mausoleos.My.Resources.Resources.PDF_icon_48x48
        Me.Facturar_Recibos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Facturar_Recibos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Facturar_Recibos.Name = "Facturar_Recibos"
        Me.Facturar_Recibos.Size = New System.Drawing.Size(52, 52)
        Me.Facturar_Recibos.Text = "Facturar Recibo"
        '
        'Button_CancelaRecibo
        '
        Me.Button_CancelaRecibo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_CancelaRecibo.Image = Global.Mausoleos.My.Resources.Resources.Cancel_48x48
        Me.Button_CancelaRecibo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_CancelaRecibo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_CancelaRecibo.Name = "Button_CancelaRecibo"
        Me.Button_CancelaRecibo.Size = New System.Drawing.Size(52, 52)
        Me.Button_CancelaRecibo.Text = "Cancelar Recibo"
        '
        'Button_ExportaExcell
        '
        Me.Button_ExportaExcell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_ExportaExcell.Image = Global.Mausoleos.My.Resources.Resources.Excel_icon_48x48
        Me.Button_ExportaExcell.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_ExportaExcell.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_ExportaExcell.Name = "Button_ExportaExcell"
        Me.Button_ExportaExcell.Size = New System.Drawing.Size(52, 52)
        Me.Button_ExportaExcell.Text = "Exportar a Excell"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
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
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(174, 66)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Fecha de Fin"
        '
        'DateTimePicker_FechaFin
        '
        Me.DateTimePicker_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_FechaFin.Location = New System.Drawing.Point(173, 86)
        Me.DateTimePicker_FechaFin.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker_FechaFin.Name = "DateTimePicker_FechaFin"
        Me.DateTimePicker_FechaFin.Size = New System.Drawing.Size(127, 22)
        Me.DateTimePicker_FechaFin.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 66)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Fecha de Inicio"
        '
        'DateTimePicker_FechaInicio
        '
        Me.DateTimePicker_FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_FechaInicio.Location = New System.Drawing.Point(16, 86)
        Me.DateTimePicker_FechaInicio.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker_FechaInicio.Name = "DateTimePicker_FechaInicio"
        Me.DateTimePicker_FechaInicio.Size = New System.Drawing.Size(127, 22)
        Me.DateTimePicker_FechaInicio.TabIndex = 23
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Mausoleos.My.Resources.Resources.Refresh_48x48
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButton1.Text = "Refrescar"
        '
        'ListadoRecibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1187, 690)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker_FechaFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker_FechaInicio)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximumSize = New System.Drawing.Size(1205, 737)
        Me.MinimumSize = New System.Drawing.Size(1205, 737)
        Me.Name = "ListadoRecibos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado Recibos Generados"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Button_AgregaRecibo As ToolStripButton
    Friend WithEvents Button_Pagos As ToolStripButton
    Friend WithEvents Button_Imprime As ToolStripButton
    Friend WithEvents Facturar_Recibos As ToolStripButton
    Friend WithEvents Button_CancelaRecibo As ToolStripButton
    Friend WithEvents Button_ExportaExcell As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Button_Salir As ToolStripButton
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintDialog1 As PrintDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker_FechaFin As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker_FechaInicio As DateTimePicker
    Friend WithEvents ToolStripButton1 As ToolStripButton
End Class
