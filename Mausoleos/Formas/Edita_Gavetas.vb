Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Edita_Gavetas
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
#End Region
#Region "Carga Informacion"
    Sub Carga_Datos()


        SQL_Str = "Select * from Plantas order by Planta"
        Try
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Pisos")
            With Me.ComboBox_Piso
                .DataSource = DS.Tables("Pisos")
                .DisplayMember = "Planta"
                .ValueMember = "id_Planta"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        SQL_Str = "Select * from Ubicaciones order by Ubicacion"
        Try
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Ubicaciones")
            With Me.ComboBox_Ubicacion
                .DataSource = DS.Tables("Ubicaciones")
                .DisplayMember = "Ubicacion"
                .ValueMember = "id_Ubicacion"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        SQL_Str = "Select * from Filas order by Fila"
        Try
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Filas")
            With Me.ComboBox_Fila
                .DataSource = DS.Tables("Filas")
                .DisplayMember = "Fila"
                .ValueMember = "id_Fila"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        SQL_Str = "Select * from Modulos order by Modulo"
        Try
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Modulos")
            With Me.ComboBox_Modulo
                .DataSource = DS.Tables("Modulos")
                .DisplayMember = "Modulo"
                .ValueMember = "id_Modulo"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        SQL_Str = "Select * from Columnas order by Columna"
        Try
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Columnas")
            With Me.ComboBox_Columna
                .DataSource = DS.Tables("Columnas")
                .DisplayMember = "Columna"
                .ValueMember = "id_Columna"
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

    Sub Carga_Info_Gaveta()
        Try
            SQL_Str = "Select Gavetas.Id_Planta, Gavetas.Id_Ubicacion, Modulos.Id_Modulo, Filas.Id_Fila, Columnas.Id_Columna, Gavetas.Capacidad, Gavetas.Observaciones" &
                " FROM Gavetas, Modulos, Filas, Columnas" &
                " where Gavetas.Id_Gaveta = @ID_Gaveta" &
                " and Gavetas.Modulo  = Modulos.Modulo" &
                " and Gavetas.Fila = filas.Fila" &
                " and Gavetas.Columna = Columnas.Columna"
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@ID_Gaveta", Id_Gaveta_Actual)
            Dim Reader As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            With Reader
                If .HasRows Then
                    While .Read
                        Me.ComboBox_Piso.SelectedValue = .Item(0)
                        Me.ComboBox_Ubicacion.SelectedValue = .Item(1)
                        Me.ComboBox_Modulo.SelectedValue = .Item(2)
                        Me.ComboBox_Fila.SelectedValue = .Item(3)
                        Me.ComboBox_Columna.SelectedValue = .Item(4)
                        Me.TextBox_Capacidad.Text = .Item(5)
                        Me.TextBox_Observaciones.Text = .Item(6)
                    End While
                End If
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
#End Region

    Private Sub Edita_Gavetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Datos()
        Carga_Info_Gaveta()
    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()

    End Sub

    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        Dim Capacidad As Integer = 0
        Dim Observaciones As String = Nothing
        Dim Tipo As Integer = 0
        Dim Piso As Integer = 0
        Dim Modulo As String = Nothing
        Dim Ubicacion As Integer = 0
        Dim Columna As String = Nothing
        Dim Fila As String = Nothing

        Try
            Piso = Me.ComboBox_Piso.SelectedValue
        Catch ex As Exception
            MessageBox.Show("Este campo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Piso.Focus()
            Exit Sub
        End Try
        Try
            Modulo = Me.ComboBox_Modulo.Text
        Catch ex As Exception
            MessageBox.Show("Este campo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Modulo.Focus()
            Exit Sub
        End Try
        Try
            Ubicacion = Me.ComboBox_Ubicacion.SelectedValue
        Catch ex As Exception
            MessageBox.Show("Este campo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Ubicacion.Focus()
            Exit Sub
        End Try
        Try
            Columna = Me.ComboBox_Columna.Text
        Catch ex As Exception
            MessageBox.Show("Este campo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Columna.Focus()
            Exit Sub
        End Try
        Try
            Fila = Me.ComboBox_Fila.Text
        Catch ex As Exception
            MessageBox.Show("Este campo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Fila.Focus()
            Exit Sub
        End Try
        Observaciones = Me.TextBox_Observaciones.Text
        If Me.TextBox_Capacidad.Text = "" Then
            MessageBox.Show("Este campo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Capacidad = Me.TextBox_Capacidad.Text
            If Capacidad = 0 Then
                MessageBox.Show("Este campo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        Try
            Cx.Open()
            Dim Sql_Str As String = Nothing
            Sql_Str = "Update Gavetas set Id_Planta = @Id_Planta, Id_Ubicacion = @Id_Ubicacion, Modulo = @Modulo, Fila = @Fila, " &
                " Columna = @Columna, Capacidad = @Capacidad, Observaciones = @Observaciones" &
                " Where Id_Gaveta = @Id_Gaveta"
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Planta", Piso)
            Cmd.Parameters.AddWithValue("@Id_Ubicacion", Ubicacion)
            Cmd.Parameters.AddWithValue("@Modulo", Modulo)
            Cmd.Parameters.AddWithValue("@Fila", Fila)
            Cmd.Parameters.AddWithValue("@Columna", Columna)
            Cmd.Parameters.AddWithValue("@Capacidad", Capacidad)
            Cmd.Parameters.AddWithValue("@Observaciones", Observaciones)
            Cmd.Parameters.AddWithValue("@Id_Gaveta", Id_Gaveta_Actual)
            Cmd.ExecuteNonQuery()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

    End Sub
End Class