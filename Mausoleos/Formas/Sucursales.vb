Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Sucursales
    Dim Sc As New Sucursal
    Dim SQL_Str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim Paises_Cargados As Boolean = False
    Dim Estados_Cargados As Boolean = False
    Dim Municipios_Cargados As Boolean = False
    Dim Ciudades_Cargadas As Boolean = False
    Private Sub Sucursales_Load(sender As Object, e As EventArgs)
        Carga_Paises()
    End Sub
    Sub Guarda_Datos()
        With Sc
            If Me.TextBox_Nombre.Text = "" Then
                MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.TextBox_Nombre.Focus()
                Exit Sub
            Else
                .Nombre = Me.TextBox_Nombre.Text
            End If

            .Clave = Me.TextBox_Clave.Text
            .Telefono = Me.TextBox_Telefono.Text
            If Me.TextBox_Calle.Text = "" Then
                MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.TextBox_Calle.Focus()
                Exit Sub
            Else
                .Calle = Me.TextBox_Calle.Text
            End If
            .email = Me.TextBox_email.Text
            .NumExt = Me.TextBox_NumExt.Text
            .NumInt = Me.TextBox_NumInt.Text
            .Referencia = Me.TextBox_Referencia.Text
            .CP = Me.TextBox_CP.Text
            .Colonia = Me.TextBox_Colonia.Text
            .Localidad = Me.ComboBox_Localidad.SelectedValue
            If .Localidad = 0 Then
                MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.TextBox_Calle.Focus()
                Exit Sub
            End If
            .Municipio = Me.ComboBox_Municipio.SelectedValue
            .Estado = Me.ComboBox_Estado.SelectedValue
            .Pais = Me.ComboBox_Estado.SelectedValue

            Try
                Cx.Open()

                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandText = "Insert into ExpedidoEn (Id_localidad, Nombre, Telefono, calle, clave, codigoPostal, colonia, email, noExterior, noInterior, referencia)" &
                    "Values (@Id_localidad, @Nombre, @Telefono, @calle, @clave, @codigoPostal, @colonia, @email, @noExterior, @noInterior, @referencia)"
                Cmd.Parameters.AddWithValue("@Id_localidad", .Localidad)
                Cmd.Parameters.AddWithValue("@Nombre", .Nombre)
                Cmd.Parameters.AddWithValue("@Telefono", .Telefono)
                Cmd.Parameters.AddWithValue("@calle", .Calle)
                Cmd.Parameters.AddWithValue("@clave", .Clave)
                Cmd.Parameters.AddWithValue("@codigoPostal", .CP)
                Cmd.Parameters.AddWithValue("@colonia", .Colonia)
                Cmd.Parameters.AddWithValue("@email", .email)
                Cmd.Parameters.AddWithValue("@noExterior", .NumExt)
                Cmd.Parameters.AddWithValue("@noInterior", .NumInt)
                Cmd.Parameters.AddWithValue("@referencia", .Referencia)
                Cmd.ExecuteNonQuery()
                Me.Close()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End With
    End Sub
    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        Guarda_Datos()

    End Sub
    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()

    End Sub

    Private Sub ComboBox_Pais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Pais.SelectedIndexChanged

    End Sub
    Sub Carga_Paises()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)

            Try
                Cx.Open()
                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandText = "Select * from Paises order by Pais"
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Paises")
                With ComboBox_Pais
                    .DataSource = DS.Tables(0)
                    .DisplayMember = "Pais"
                    .ValueMember = "Id_Paises"
                End With
                Me.ComboBox_Pais.Text = ""
                Paises_Cargados = True
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using
    End Sub

    Sub Carga_Estados()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Id_Pais As Integer = 0
            Try
                Id_Pais = Me.ComboBox_Pais.SelectedValue
            Catch ex As Exception
                MessageBox.Show("Se debe de seleccionar un pais primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ComboBox_Pais.Focus()
                Exit Sub
            End Try

            Try
                Cx.Open()
                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandText = "Select * from Estado where id_Paises = @IdPais order by estado"

                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@IdPais", Id_Pais)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Estados")
                With ComboBox_Estado
                    .DataSource = DS.Tables(0)
                    .DisplayMember = "Estado"
                    .ValueMember = "Id_Estado"
                End With
                Estados_Cargados = True
                Me.ComboBox_Estado.Text = ""
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using

    End Sub

    Sub Carga_Municipios()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Id_Estado As Integer
            Try
                Id_Estado = Me.ComboBox_Estado.SelectedValue
            Catch ex As Exception
                MessageBox.Show("Se debe de seleccionar un Estado primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ComboBox_Estado.Focus()
                Exit Sub
            End Try


            Try
                Cx.Open()
                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandText = "Select * from Municipio where id_Estado = @IdEstado order by Municipio"
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@IdEstado", Id_Estado)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Municipios")
                With ComboBox_Municipio
                    .DataSource = DS.Tables(0)
                    .DisplayMember = "Municipio"
                    .ValueMember = "Id_Municipio"
                End With
                Municipios_Cargados = True
                ComboBox_Municipio.Text = ""
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using

    End Sub

    Sub Carga_Ciudades()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Id_Cd As Integer
            Try
                Id_Cd = Me.ComboBox_Estado.SelectedValue
            Catch ex As Exception
                MessageBox.Show("Se debe de seleccionar una Ciudad primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ComboBox_Estado.Focus()
                Exit Sub
            End Try


            Try
                Cx.Open()
                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandText = "Select * from Localidad where id_Municipio = @IdMunicipio order by Localidad"
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@IdMunicipio", Id_Cd)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Ciudades")
                With ComboBox_Localidad
                    .DataSource = DS.Tables("Ciudades")
                    .DisplayMember = "Localidad"
                    .ValueMember = "Id_Localidad"
                End With
                Ciudades_Cargadas = True
                ComboBox_Localidad.Text = ""
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End Using


    End Sub

    Private Sub ComboBox_Estado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Estado.SelectedIndexChanged

    End Sub

    Private Sub ComboBox_Municipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Municipio.SelectedIndexChanged

    End Sub
End Class