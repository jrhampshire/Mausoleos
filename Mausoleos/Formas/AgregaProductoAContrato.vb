Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class AgregaProductoAContrato
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Dim Sql_Str As String = Nothing
    Private Sub AgregaProductoAContrato_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaServicios()
    End Sub

    Sub CargaServicios()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Try
                Sql_Str = "Select * from ProductosyServicios Where Activo = 'True' Order by Descripcion"

                Dim DA As New SqlDataAdapter(Sql_Str, Cx)
                Dim DS As New DataSet
                DA.Fill(DS, "ProductosyServicios")
                With Me.ComboBox1
                    .DataSource = DS.Tables("ProductosyServicios")
                    .DisplayMember = "Descripcion"
                    .ValueMember = "Id_ProductosyServicios"
                End With
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using
    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Try
            Close()
        Catch ex As ObjectDisposedException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        Dim Id_Servicio As Integer = 0
        Dim Cantidad As Integer = 0
        Dim Observaciones As String = Nothing

        Try
            Id_Servicio = Me.ComboBox1.SelectedValue
        Catch ex As Exception
            MessageBox.Show("Este dato es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox1.Focus()
            Exit Sub
        End Try
        If Me.TextBox1.Text = "" Then
            MessageBox.Show("Este dato es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox1.Focus()
            Exit Sub
        Else
            Cantidad = Me.TextBox1.Text
        End If
        Observaciones = Me.TextBox2.Text

        Using Cx As New SqlConnection(CxSettings.ConnectionString)


            Dim Transaccion As SqlTransaction = Nothing
            Try
                Cx.Open()
                Transaccion = Cx.BeginTransaction("Agrega Servicios y Productos")
                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandText = "Insert into ServiciosXContrato(Id_Contrato, Id_ProductosyServicios, Disponibles, Utilizados, Observaciones)" &
                    " Values (@Id_Contrato, @Id_ProductosyServicios, @Disponibles, @Utilizados, @Observaciones)"
                Cmd.CommandType = CommandType.Text
                Cmd.Transaction = Transaccion
                Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
                Cmd.Parameters.AddWithValue("@Id_ProductosyServicios", Id_Servicio)
                Cmd.Parameters.AddWithValue("@Disponibles", Cantidad)
                Cmd.Parameters.AddWithValue("@Observaciones", Observaciones)
                Cmd.Parameters.AddWithValue("@Utilizados", 0)
                Cmd.ExecuteNonQuery()
                Cmd.CommandText = "Insert into Servicios_UtilizadosyDisponibles(Id_Contrato, Id_Servicio, Disponibles, Utilizados)" &
                    "(Select @Id_Contrato,id_Servicio, Cantidad,0 from Servicios_x_Producto Where Id_Producto in(Select Id_ProductosyServicios  from ServiciosXContrato  Where Id_Contrato = @Id_Contrato1))"
                Cmd.Parameters.AddWithValue("@Id_Contrato1", Id_Contrato)
                Cmd.ExecuteNonQuery()
                Transaccion.Commit()
                MessageBox.Show("Se a agregado un Producto", "Producto Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                Transaccion.Rollback()
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                Transaccion.Rollback()
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using
        Try
            Close()
        Catch ex As ObjectDisposedException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If InStr(1, "0123456789", e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        ComboBox1.Text = ""
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New Listado_Productos_Servicios
        frm.ShowDialog()
        CargaServicios()
    End Sub
End Class