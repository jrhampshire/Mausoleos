<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RestauraSQL
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
        Me.Btnrespaldar = New System.Windows.Forms.Button()
        Me.Btnsalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTNAEXAMINAR = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtruta = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btnrespaldar
        '
        Me.Btnrespaldar.Enabled = False
        Me.Btnrespaldar.Location = New System.Drawing.Point(555, 87)
        Me.Btnrespaldar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btnrespaldar.Name = "Btnrespaldar"
        Me.Btnrespaldar.Size = New System.Drawing.Size(100, 28)
        Me.Btnrespaldar.TabIndex = 7
        Me.Btnrespaldar.Text = "Restaurar"
        Me.Btnrespaldar.UseVisualStyleBackColor = True
        '
        'Btnsalir
        '
        Me.Btnsalir.Location = New System.Drawing.Point(663, 89)
        Me.Btnsalir.Margin = New System.Windows.Forms.Padding(4)
        Me.Btnsalir.Name = "Btnsalir"
        Me.Btnsalir.Size = New System.Drawing.Size(100, 28)
        Me.Btnsalir.TabIndex = 8
        Me.Btnsalir.Text = "Salir"
        Me.Btnsalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNAEXAMINAR)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtruta)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(748, 66)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Recuperar Respaldo"
        '
        'BTNAEXAMINAR
        '
        Me.BTNAEXAMINAR.Location = New System.Drawing.Point(683, 21)
        Me.BTNAEXAMINAR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTNAEXAMINAR.Name = "BTNAEXAMINAR"
        Me.BTNAEXAMINAR.Size = New System.Drawing.Size(37, 28)
        Me.BTNAEXAMINAR.TabIndex = 0
        Me.BTNAEXAMINAR.Text = "..."
        Me.BTNAEXAMINAR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ruta"
        '
        'txtruta
        '
        Me.txtruta.Location = New System.Drawing.Point(73, 23)
        Me.txtruta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtruta.Name = "txtruta"
        Me.txtruta.ReadOnly = True
        Me.txtruta.Size = New System.Drawing.Size(600, 22)
        Me.txtruta.TabIndex = 1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'RestauraSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 130)
        Me.ControlBox = False
        Me.Controls.Add(Me.Btnrespaldar)
        Me.Controls.Add(Me.Btnsalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(798, 177)
        Me.MinimumSize = New System.Drawing.Size(798, 177)
        Me.Name = "RestauraSQL"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Restaura Base de Datos SQL"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btnrespaldar As Button
    Friend WithEvents Btnsalir As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTNAEXAMINAR As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtruta As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
