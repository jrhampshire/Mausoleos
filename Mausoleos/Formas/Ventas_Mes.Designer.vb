<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventas_Mes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ventas_Mes))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker_FechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker_FechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Button_Genera_Reporte = New System.Windows.Forms.ToolStripButton()
        Me.Button_ExportaExcell = New System.Windows.Forms.ToolStripButton()
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(898, 448)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Listado de Pagos Recibidos"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(892, 429)
        Me.DataGridView1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(130, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Fecha de Fin"
        '
        'DateTimePicker_FechaFin
        '
        Me.DateTimePicker_FechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_FechaFin.Location = New System.Drawing.Point(129, 83)
        Me.DateTimePicker_FechaFin.Name = "DateTimePicker_FechaFin"
        Me.DateTimePicker_FechaFin.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker_FechaFin.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Fecha de Inicio"
        '
        'DateTimePicker_FechaInicio
        '
        Me.DateTimePicker_FechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker_FechaInicio.Location = New System.Drawing.Point(11, 83)
        Me.DateTimePicker_FechaInicio.Name = "DateTimePicker_FechaInicio"
        Me.DateTimePicker_FechaInicio.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker_FechaInicio.TabIndex = 13
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Button_Genera_Reporte, Me.Button_ExportaExcell, Me.ToolStripSeparator1, Me.Button_Salir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(922, 55)
        Me.ToolStrip1.TabIndex = 12
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Button_Genera_Reporte
        '
        Me.Button_Genera_Reporte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Button_Genera_Reporte.Image = CType(resources.GetObject("Button_Genera_Reporte.Image"), System.Drawing.Image)
        Me.Button_Genera_Reporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Button_Genera_Reporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Button_Genera_Reporte.Name = "Button_Genera_Reporte"
        Me.Button_Genera_Reporte.Size = New System.Drawing.Size(52, 52)
        Me.Button_Genera_Reporte.Text = "Detalle de Pagos"
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
        'Ventas_Mes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 570)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker_FechaFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker_FechaInicio)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximumSize = New System.Drawing.Size(938, 609)
        Me.MinimumSize = New System.Drawing.Size(938, 609)
        Me.Name = "Ventas_Mes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas del Mes"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker_FechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker_FechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Button_Genera_Reporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button_ExportaExcell As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Button_Salir As System.Windows.Forms.ToolStripButton
End Class
