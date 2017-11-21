Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Ciudades
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim Paises_Cargados As Boolean = False
    Dim Estados_Cargados As Boolean = False
    Dim Municipios_Cargados As Boolean = False
#Region "Codigo"
    Private Sub Btn_Agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar.Click
        Guarda()
    End Sub
    Private Sub Ciudades_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Paises()
    End Sub
    Sub Cargar_Paises()
        Dim SQL_Str As String = "Select * from Paises order by Pais"
        Try
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Paises")
            With Me.ComboBox1
                .DataSource = DS.Tables("Paises")
                .DisplayMember = "Pais"
                .ValueMember = "ID_Paises"
            End With
            Paises_Cargados = True
            ComboBox1.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Municipio.SelectedIndexChanged
        If Municipios_Cargados = True Then
            Carga_Ciudades()
        End If

    End Sub
    Private Sub Btn_Borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Borrar.Click
        Dim Ciudad As String = ""
        Dim Municipio_Actual As String = ""
        Municipio_Actual = Me.CB_Municipio.Text
        If Municipio_Actual = "" Then
            MessageBox.Show("Debe Seleccionar primero un Municipio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        Ciudad = Me.ListBox1.SelectedValue
        If Ciudad = "" Then
            MessageBox.Show("Debe Seleccionar una Ciudad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Try
                Cx.Open()
                Dim SQL_Str As String = "Delete Localidad where Id_Localidad = @Ciudad"
                Dim Cmd_Borra As SqlCommand = New SqlCommand(SQL_Str, Cx)
                Cmd_Borra.CommandType = CommandType.Text
                Cmd_Borra.Parameters.AddWithValue("@Ciudad", Ciudad)
                Cmd_Borra.ExecuteNonQuery()
                Cx.Close()
                Carga_Ciudades()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If

            End Try
        End If
    End Sub
    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub
    Sub Carga_Estados()
        Dim SQL_Str As String = "Select * from Estado where id_Paises = @ID_Pais order by estado"
        Dim Id_Pais As Integer = 0
        Try
            Id_Pais = Me.ComboBox1.SelectedValue
        Catch ex As Exception
            MessageBox.Show("Debe Seleccionar un Pais", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox1.Focus()
            Exit Sub
        End Try
        Try
            Cx.Open()
            Dim Cmd As SqlCommand = New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@ID_Pais", Id_Pais)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Estados")
            With CB_Estado
                .DataSource = DS.Tables("Estados")
                .DisplayMember = "Estado"
                .ValueMember = "Id_Estado"
            End With
            Estados_Cargados = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub
    Sub Carga_Municipios()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim SQL_Str As String = Nothing
            Dim Id_Estado As Integer
            Try
                Id_Estado = Me.CB_Estado.SelectedValue
            Catch ex As Exception
                MessageBox.Show("Se debe de seleccionar un Estado primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.CB_Estado.Focus()
                Exit Sub
            End Try

            SQL_Str = "Select * from Municipio where id_Estado = @IdEstado order by Municipio"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@IdEstado", Id_Estado)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Municipios")
                With CB_Municipio
                    .DataSource = DS.Tables("Municipios")
                    .DisplayMember = "Municipio"
                    .ValueMember = "Id_Municipio"
                End With
                Municipios_Cargados = True
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
            Dim SQL_Str As String = Nothing
            Dim Id_Municipio As Integer
            Try
                Id_Municipio = Me.CB_Municipio.SelectedValue
            Catch ex As Exception
                MessageBox.Show("Se debe de seleccionar un Municipio primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.CB_Estado.Focus()
                Exit Sub
            End Try

            SQL_Str = "Select * from Localidad where Id_Municipio = @Id_Municipio order by Localidad"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Id_Municipio", Id_Municipio)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Localidad")
                With ListBox1
                    .DataSource = DS.Tables("Localidad")
                    .DisplayMember = "Localidad"
                    .ValueMember = "Id_Localidad"
                End With
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using
    End Sub
    Private Sub CB_Estado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Estado.SelectedIndexChanged
        If Estados_Cargados = True Then
            Carga_Municipios()
        End If
    End Sub
    Sub Guarda()
        Dim SQL_Str As String = ""
        Dim Municipio_Actual As String = ""
        Dim Ciudad As String = ""

        Municipio_Actual = Me.CB_Municipio.Text

        If Municipio_Actual = "" Then
            MessageBox.Show("Debe de seleccionar primero un Municipio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.CB_Municipio.Focus()
            Exit Sub
        Else
            Ciudad = Me.Txt_Ciudad.Text
            If Ciudad = "" Then
                MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Txt_Ciudad.Focus()
                Exit Sub
            Else
                Try
                    Cx.Open()
                    SQL_Str = "Select id_Municipio from municipio where Municipio = @Municipio"
                    Dim Cmd_Municipio As SqlCommand = New SqlCommand(SQL_Str, Cx)
                    Cmd_Municipio.Parameters.AddWithValue("@Municipio", Municipio_Actual)
                    Cmd_Municipio.CommandType = CommandType.Text
                    Dim DR_Municipio As SqlDataReader = Cmd_Municipio.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR_Municipio
                        If .HasRows Then
                            Dim Cmd_Ejecuta As SqlCommand
                            Dim Cx1 As New SqlConnection(CxSettings.ConnectionString)
                            While .Read
                                Cx1.Open()
                                SQL_Str = "Insert into Localidad (Localidad,Id_Municipio) Values (@Ciudad,@ID_Municipio)"
                                Cmd_Ejecuta = New SqlCommand(SQL_Str, Cx1)
                                Cmd_Ejecuta.CommandType = CommandType.Text
                                Cmd_Ejecuta.Parameters.AddWithValue("@Ciudad", Ciudad)
                                Cmd_Ejecuta.Parameters.AddWithValue("@ID_Municipio", DR_Municipio.Item("id_Municipio"))
                                Cmd_Ejecuta.ExecuteNonQuery()
                                Cx1.Close()
                            End While
                        End If
                    End With
                    Cx.Close()
                    Me.Txt_Ciudad.Text = ""
                    Me.Txt_Ciudad.Focus()
                    Carga_Ciudades()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
        End If
    End Sub
    Private Sub Txt_Ciudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Ciudad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Guarda()
        End If
    End Sub
#End Region

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Paises_Cargados = True Then
            Carga_Estados()
        End If

    End Sub

    Private Sub Txt_Ciudad_TextChanged(sender As Object, e As EventArgs) Handles Txt_Ciudad.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Frm As New Paises
        Frm.ShowDialog()
        Cargar_Paises()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Frm As New Estados
        Frm.ShowDialog()
        Carga_Estados()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Frm As New Municipios
        Frm.ShowDialog()
        Carga_Municipios()

    End Sub

End Class