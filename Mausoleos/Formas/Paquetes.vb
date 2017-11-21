Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Paquetes
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
    Dim Fila As Integer = 0
    Dim Columna As Integer = 0

    Private Sub Paquetes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_Datos()

    End Sub
    Sub Cargar_Datos()
        SQL_Str = "Select * from Servicios order by Servicio"
        Try
            Cx.Open()

            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.ComboBox1
                .DataSource = DS.Tables("Tabla")
                .DisplayMember = "Servicio"
                .ValueMember = "Id_Servicio"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub


    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        If Me.TextBox_Descripcion.Text = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Me.ListView1.Items.Add(Me.TextBox_Cantidad.Text)
            Me.ListView1.Items.Item(Fila).SubItems.Add(Me.TextBox_Descripcion.Text)
            Fila = Fila + 1

        End If
    End Sub
End Class