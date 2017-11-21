Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Edita_Usuarios
#Region "Variables"
    Dim Usr As New Empleados
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim Sql_str As String = ""
    Private DA As New SqlDataAdapter
    Private DS As New DataSet
    Private Permisos As String

#End Region
    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()

    End Sub

    Private Sub Edita_Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaDatos()

    End Sub
    Sub CargaDatos()
        Dim e As New Empleados

        Try
            Sql_str = "Select * from Usuarios Where Id_Usuarios = @Id_Usuarios"
            Using Cx As New SqlConnection(CxSettings.ConnectionString)
                Cx.Open()
                Dim Cmd As New SqlCommand(Sql_str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Id_Usuarios", Usuario_Edicion)
                Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If DR.HasRows Then
                    While DR.Read
                        e.Usr = DR.Item("Usuario")
                        e.Pwd = DR.Item("pasword")
                        e.Permisos = DR.Item("Permisos")
                        e.Observaciones = DR.Item("Observaciones")
                        e.Nombre = DR.Item("nombre")
                        e.Calle = DR.Item("direccion")
                        e.Tel_Particular = ("Tel_Particular")
                        e.Celular = ("")
                    End While
                End If
                Me.TextBox_Nombre.Text = e.Nombre
                Me.TextBox_Observaciones.Text = e.Observaciones
                Me.TextBox_Direccion.Text = e.Calle


            End Using
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
End Class