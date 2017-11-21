<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacturaciondelPeriodo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FacturaciondelPeriodo))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker_FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker_FechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Button_Genera_Reporte = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Cancela_Fact = New System.Windows.Forms.ToolStripButton()
        Me.Button_ExportaExcell = New System.Windows.Forms.ToolStripButton()
        Me.Button_Salir = New System.Windows.Forms.ToolStripButton()
        Me.Button_EMail = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Button_Genera_Reporte, Me.ToolStripButton1, Me.Button_EMail, Me.ToolStripButton_Cancela_Fact, Me.Button_ExportaExcell, Me.ToolStripSeparator1, Me.Button_Salir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(886, 55)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(867, 457)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Listado de Pagos Recibidos"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(861, 438)
        Me.DataGridView1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(128, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Fecha de Fin"
        '
        'DateTimePicker_FechaFin
        '
        Me.DateTimePicker_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_FechaFin.Location = New System.Drawing.Point(127, 70)
        Me.DateTimePicker_FechaFin.Name = "DateTimePicker_FechaFin"
        Me.DateTimePicker_FechaFin.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker_FechaFin.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Fecha de Inicio"
        '
        'DateTimePicker_FechaInicio
        '
        Me.DateTimePicker_FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_FechaInicio.Location = New System.Drawing.Point(9, 70)
        Me.DateTimePicker_FechaInicio.Name = "DateTimePicker_FechaInicio"
        Me.DateTimePicker_FechaInicio.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker_FechaInicio.TabIndex = 12
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Mausoleo_2014.My.Resources.Resources.gnome_mime_application_pdf
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton_Cancela_Fact
        '
        Me.ToolStripButton_Cancela_Fact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Cancela_Fact.Enabled = False
        Me.ToolStripButton_Cancela_Fact.Image = Global.Mausoleo_2014.My.Resources.Resources.Cancel_48x48
        Me.ToolStripButton_Cancela_Fact.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton_Cancela_Fact.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Cancela_Fact.Name = "ToolStripButton_Cancela_Fact"
        Me.ToolStripButton_Cancela_Fact.Size = New System.Drawing.Size(52, 52)
        Me.ToolStripButton_Cancela_Fact.Text = "Cancelar Factura"
        '
        'Button_ExportaExcell
        '
        Me.Button_ExportaExcell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_ExportaExcell.Image = CType(resources.GetObject("Button_ExportaExcell.Image"), System.Drawing.Image)
        Me.Button_ExportaExcell.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_ExportaExcell.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_ExportaExcell.Name = "Button_ExportaExcell"
        Me.Button_ExportaExcell.Size = New System.Drawing.Size(36, 52)
        Me.Button_ExportaExcell.Text = "Exportar a Excell"
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
        'Button_EMail
        '
        Me.Button_EMail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_EMail.Image = Global.Mausoleo_2014.My.Resources.Resources.Mail_48x48
        Me.Button_EMail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_EMail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_EMail.Name = "Button_EMail"
        Me.Button_EMail.Size = New System.Drawing.Size(52, 52)
        Me.Button_EMail.Text = "ToolStripButton2"
        '
        'FacturaciondelPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 565)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker_FechaFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker_FechaInicio)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(902, 604)
        Me.MinimumSize = New System.Drawing.Size(902, 604)
        Me.Name = "FacturaciondelPeriodo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturacion del Periodo"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Button_Genera_Reporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button_ExportaExcell As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Button_Salir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker_FechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker_FechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Cancela_Fact As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button_EMail As System.Windows.Forms.ToolStripButton
End Class
