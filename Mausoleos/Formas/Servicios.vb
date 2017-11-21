Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Servicios
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
    Dim Id_Producto As Integer = 0

    Private Sub Servicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Producto_Actual
        Try
            SQL_Str = "Select * from ProductosyServicios where Clave = @Clave"
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Clave", Clave_Servicio)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Id_Producto = DR.Item("Id_ProductosyServicios")
                End While
            End If
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
        Carga_Datos()
        Me.TextBox1.Text = 1
        Carga_Datos_DatagridView()
    End Sub
    Sub Carga_Datos()
        SQL_Str = "Select * from Servicios order by Servicio"
        Try
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
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

    End Sub
    Sub Carga_Datos_DatagridView()
        SQL_Str = "Select Id_Servicios_x_Producto as ID, Servicios.Servicio, Servicios_x_Producto.Cantidad " &
            " from Servicios_x_Producto, Servicios Where Servicios_x_Producto.Id_Servicio = Servicios.Id_Servicio and Servicios_x_Producto.Id_Producto = @Id_Producto"
        Try
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Producto", Id_Producto)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.DataGridView1
                .DataSource = DS.Tables("Tabla")

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub
    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        Dim Descripcion As String = Nothing
        Dim Id_Servicio As Integer = 0
        Dim Cantidad As Integer = 0
        If Trim(Me.TextBox1.Text) = "" Then
            MessageBox.Show("Este dato  es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox1.Focus()
            Exit Sub
        Else
            Cantidad = Me.TextBox1.Text
        End If


        If Trim(Me.ComboBox1.Text) = "" Then
            MessageBox.Show("Este dato  es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox1.Focus()
            Exit Sub
        Else
            Descripcion = Trim(Me.ComboBox1.Text)
            Id_Servicio = Me.ComboBox1.SelectedValue
        End If

        SQL_Str = "Insert into Servicios_x_Producto (Id_Servicio, Id_Producto, Cantidad) Values(@Id_Servicio, @Id_Producto, @Cantidad)"
        Try
            Cx.Open()
            Dim Cmd_Inserta As New SqlCommand(SQL_Str, Cx)
            Cmd_Inserta.Parameters.AddWithValue("@Id_Servicio", Id_Servicio)
            Cmd_Inserta.Parameters.AddWithValue("@Id_Producto", Id_Producto)
            Cmd_Inserta.Parameters.AddWithValue("@Cantidad", Cantidad)
            Cmd_Inserta.CommandType = CommandType.Text
            Cmd_Inserta.ExecuteNonQuery()
            '////////////////////////////////////////////////////
            'ya que guarde el el Estado en la Base de Datos lo agrego al listbox
            '////////////////////////////////////////////////////
            'Me.ListBox.Items.Clear()
            Cx.Close()
            Carga_Datos_DatagridView()
            Me.ComboBox1.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_Borrar_Click(sender As Object, e As EventArgs)
        SQL_Str = "Select Count(id_Serviciosxcontrato) from ServiciosXContrato where Id_ProductosyServicios = @id"
        Dim Total As Int32 = 0
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@id", Id_Producto)
            Total = Convert.ToInt32(Cmd.ExecuteScalar)

        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Dim Clave As String = Nothing
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Clave = Me.DataGridView1(columna, fila).Value
        If Clave = "" Then
            MessageBox.Show("Debe seleccionar un Servicio para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView1.Focus()
            Exit Sub
        Else
            If Total > 0 Then
                MessageBox.Show("No se puede eliminar el servicio ya que esta registrado en un contrato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                SQL_Str = "Delete Servicios_x_Producto Where Id_"
            End If
        End If

    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

End Class