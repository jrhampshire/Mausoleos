Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Cargar_ProductosyServicios
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Dim SQL_Str As String = Nothing

    Private Sub Cargar_ProductosyServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Try
                SQL_Str = "Select Clave,Descripcion from ProductosyServicios Where Activo = 'true' order by Clave"
                Dim DA As New SqlDataAdapter(SQL_Str, Cx)
                Dim DS As New DataSet
                DA.Fill(DS, "Tabla")
                Me.DataGridView1.DataSource = DS.Tables("Tabla")

            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using
    End Sub

    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Producto = Me.DataGridView1(columna, fila).Value
        If Producto = Nothing Then
            MessageBox.Show("Debe seleccionar un producto o servicio para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView1.Focus()
            Exit Sub
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub
End Class