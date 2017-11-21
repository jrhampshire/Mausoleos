Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient



Public Class Conceptos
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Dim Sql_Str As String = Nothing
    Private Sub Conceptos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Familias()
        Carga_Unidades()

    End Sub
    Sub Carga_Unidades()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Sql_Str = "Select * from Unidades order by descripcion"
            Try
                Dim DA As New SqlDataAdapter(Sql_Str, Cx)
                Dim DS As New DataSet
                DA.Fill(DS, "Unidades")
                With Me.ComboBox_Unidades
                    .DataSource = DS.Tables("Unidades")
                    .DisplayMember = "Descripcion"
                    .ValueMember = "Id_Unidad"
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End Using
    End Sub

    Sub Carga_Familias()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Sql_Str = "Select * from Familias order by descripcion"
            Try
                Dim DA As New SqlDataAdapter(Sql_Str, Cx)
                Dim DS As New DataSet
                DA.Fill(DS, "Familias")
                With Me.ComboBox_Familia
                    .DataSource = DS.Tables("Familias")
                    .DisplayMember = "Descripcion"
                    .ValueMember = "id_Familia"
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End Using
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
    ''' <summary>
    ''' Falta Guardar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Producto As New Conceptos_Class
        With Producto
            .Clave = Trim(Me.TextBox_Clave.Text)
            .Descripcion = Trim(Me.TextBox_Descripcion.Text)
            .Precio = CDec(Me.TextBox_ValorUnitario.Text)
            Try
                .Unidad = Me.ComboBox_Unidades.SelectedValue
            Catch ex As Exception
                MessageBox.Show("Debe seleccionar una Unidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            Try
                .Familia = Me.ComboBox_Familia.SelectedValue
            Catch ex As Exception
                MessageBox.Show("Debe seleccionar una Familia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            If .Clave = "" Then
                MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.TextBox_Clave.Focus()
                Exit Sub
            End If
            If .Descripcion = "" Then
                MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.TextBox_Descripcion.Focus()
                Exit Sub
            End If
            Using Cx As New SqlConnection(CxSettings.ConnectionString)
                Try
                    Dim Total As Integer = 0
                    Sql_Str = "Select Count(Clave) as Total from ProductosyServicios Where Clave = @Clave"

                    Cx.Open()
                    Dim Cmd As New SqlCommand(Sql_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Parameters.AddWithValue("@Clave", .Clave)
                    Total = Cmd.ExecuteScalar
                    If Total >= 1 Then
                        MessageBox.Show("Ya existe un producto con esa clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Me.TextBox_Clave.SelectAll()
                        Me.TextBox_Clave.Focus()
                        Exit Sub
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

                Try
                    Sql_Str = "Insert into ProductosyServicios (Clave, Descripcion, ValorUnitario, Id_Familia, Id_Unidad)" &
                        " Values(@Clave, @Descripcion, @ValorUnitario, @Id_Familia, @Id_Unidad)"
                    Cx.Open()
                    Dim Cmd As New SqlCommand(Sql_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Parameters.AddWithValue("@Clave", .Clave)
                    Cmd.Parameters.AddWithValue("@Descripcion", .Descripcion)
                    Cmd.Parameters.AddWithValue("@ValorUnitario", .Precio)
                    Cmd.Parameters.AddWithValue("@Id_Familia", .Familia)
                    Cmd.Parameters.AddWithValue("@Id_Unidad", .Unidad)
                    Cmd.ExecuteNonQuery()

                    Me.Close()
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
            End Using
        End With
    End Sub
End Class