﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Paises
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
        Me.ListBox_Paises = New System.Windows.Forms.ListBox()
        Me.Btn_Borrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Textbox_Pais = New System.Windows.Forms.TextBox()
        Me.Btn_Cancelar = New System.Windows.Forms.Button()
        Me.Btn_Aceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBox_Paises
        '
        Me.ListBox_Paises.FormattingEnabled = True
        Me.ListBox_Paises.ItemHeight = 16
        Me.ListBox_Paises.Location = New System.Drawing.Point(19, 76)
        Me.ListBox_Paises.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox_Paises.Name = "ListBox_Paises"
        Me.ListBox_Paises.Size = New System.Drawing.Size(313, 228)
        Me.ListBox_Paises.TabIndex = 28
        '
        'Btn_Borrar
        '
        Me.Btn_Borrar.Location = New System.Drawing.Point(234, 41)
        Me.Btn_Borrar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Borrar.Name = "Btn_Borrar"
        Me.Btn_Borrar.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Borrar.TabIndex = 27
        Me.Btn_Borrar.Text = "Borrar"
        Me.Btn_Borrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 17)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Pais"
        '
        'Textbox_Pais
        '
        Me.Textbox_Pais.Location = New System.Drawing.Point(59, 9)
        Me.Textbox_Pais.Margin = New System.Windows.Forms.Padding(4)
        Me.Textbox_Pais.Name = "Textbox_Pais"
        Me.Textbox_Pais.Size = New System.Drawing.Size(275, 22)
        Me.Textbox_Pais.TabIndex = 25
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Location = New System.Drawing.Point(232, 317)
        Me.Btn_Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Cancelar.TabIndex = 24
        Me.Btn_Cancelar.Text = "Salir"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Aceptar
        '
        Me.Btn_Aceptar.Location = New System.Drawing.Point(123, 41)
        Me.Btn_Aceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Aceptar.Name = "Btn_Aceptar"
        Me.Btn_Aceptar.Size = New System.Drawing.Size(100, 28)
        Me.Btn_Aceptar.TabIndex = 23
        Me.Btn_Aceptar.Text = "Agregar"
        Me.Btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Paises
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 354)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListBox_Paises)
        Me.Controls.Add(Me.Btn_Borrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Textbox_Pais)
        Me.Controls.Add(Me.Btn_Cancelar)
        Me.Controls.Add(Me.Btn_Aceptar)
        Me.MaximumSize = New System.Drawing.Size(367, 401)
        Me.MinimumSize = New System.Drawing.Size(367, 401)
        Me.Name = "Paises"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paises"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListBox_Paises As ListBox
    Friend WithEvents Btn_Borrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Textbox_Pais As TextBox
    Friend WithEvents Btn_Cancelar As Button
    Friend WithEvents Btn_Aceptar As Button
End Class
