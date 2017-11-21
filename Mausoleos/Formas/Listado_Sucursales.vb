Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class Listado_Sucursales
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Listado_Sucursales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Datos()
    End Sub
    Sub Carga_Datos()
        SQL_Str = "Select * from ExpedidoEn order by Nombre"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Sucursales")
            With ListBox1
                .DataSource = DS.Tables("Sucursales")
                .DisplayMember = "Nombre"
                .ValueMember = "Id_ExpedidoEn"
            End With
        Catch ex As SqlException
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub
    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        Dim Frm As New Sucursales
        Frm.ShowDialog()
        Carga_Datos()
    End Sub

    Private Sub Button_Borrar_Click(sender As Object, e As EventArgs) Handles Button_Borrar.Click
        Dim Sucursal_Actual As Integer = 0
        Try
            Sucursal_Actual = Me.ListBox1.SelectedValue
            SQL_Str = "Delete ExpedidoEn where nombre not in(Select LugarExpedicion from Comprobante) and Id_ExpedidoEn = @ID"
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@ID", Sucursal_Actual)
            Cmd.ExecuteNonQuery()

        Catch ex As SqlException
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
        Carga_Datos()
    End Sub
End Class