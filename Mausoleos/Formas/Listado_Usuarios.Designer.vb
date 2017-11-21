<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Listado_Usuarios
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
        Me.ListBox = New System.Windows.Forms.ListBox()
        Me.Button_Editar = New System.Windows.Forms.Button()
        Me.Button_Borrar = New System.Windows.Forms.Button()
        Me.Button_Agregar = New System.Windows.Forms.Button()
        Me.Button_Salir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBox
        '
        Me.ListBox.FormattingEnabled = True
        Me.ListBox.ItemHeight = 16
        Me.ListBox.Location = New System.Drawing.Point(18, 9)
        Me.ListBox.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox.Name = "ListBox"
        Me.ListBox.Size = New System.Drawing.Size(808, 404)
        Me.ListBox.TabIndex = 15
        '
        'Button_Editar
        '
        Me.Button_Editar.Location = New System.Drawing.Point(511, 438)
        Me.Button_Editar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Editar.Name = "Button_Editar"
        Me.Button_Editar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Editar.TabIndex = 14
        Me.Button_Editar.Text = "Editar"
        Me.Button_Editar.UseVisualStyleBackColor = True
        '
        'Button_Borrar
        '
        Me.Button_Borrar.Location = New System.Drawing.Point(619, 438)
        Me.Button_Borrar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Borrar.Name = "Button_Borrar"
        Me.Button_Borrar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Borrar.TabIndex = 13
        Me.Button_Borrar.Text = "Borrar"
        Me.Button_Borrar.UseVisualStyleBackColor = True
        '
        'Button_Agregar
        '
        Me.Button_Agregar.Location = New System.Drawing.Point(403, 438)
        Me.Button_Agregar.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Agregar.Name = "Button_Agregar"
        Me.Button_Agregar.Size = New System.Drawing.Size(100, 28)
        Me.Button_Agregar.TabIndex = 12
        Me.Button_Agregar.Text = "Agregar"
        Me.Button_Agregar.UseVisualStyleBackColor = True
        '
        'Button_Salir
        '
        Me.Button_Salir.Location = New System.Drawing.Point(727, 438)
        Me.Button_Salir.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_Salir.Name = "Button_Salir"
        Me.Button_Salir.Size = New System.Drawing.Size(100, 28)
        Me.Button_Salir.TabIndex = 11
        Me.Button_Salir.Text = "Salir"
        Me.Button_Salir.UseVisualStyleBackColor = True
        '
        'Listado_Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 474)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListBox)
        Me.Controls.Add(Me.Button_Editar)
        Me.Controls.Add(Me.Button_Borrar)
        Me.Controls.Add(Me.Button_Agregar)
        Me.Controls.Add(Me.Button_Salir)
        Me.MaximumSize = New System.Drawing.Size(862, 521)
        Me.MinimumSize = New System.Drawing.Size(862, 521)
        Me.Name = "Listado_Usuarios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Usuarios"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBox As ListBox
    Friend WithEvents Button_Editar As Button
    Friend WithEvents Button_Borrar As Button
    Friend WithEvents Button_Agregar As Button
    Friend WithEvents Button_Salir As Button
End Class
