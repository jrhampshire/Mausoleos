
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Nueva_Gaveta
#Region "Variables"
    Dim Id_Parentesco As Integer
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing

#End Region

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
    Private Sub Nueva_Gaveta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Datos()
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
            Sql_Str = "Insert into Gavetas (Id_Planta, Id_Ubicacion,Modulo,Fila,Columna,Capacidad,Observaciones) " &
                " Values (@Id_Planta,  @Id_Ubicacion, @Modulo, @Fila, @Columna, @Capacidad, @Observaciones)"
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Planta", Piso)
            Cmd.Parameters.AddWithValue("@Id_Ubicacion", Ubicacion)
            Cmd.Parameters.AddWithValue("@Modulo", Modulo)
            Cmd.Parameters.AddWithValue("@Fila", Fila)
            Cmd.Parameters.AddWithValue("@Columna", Columna)
            Cmd.Parameters.AddWithValue("@Capacidad", Capacidad)
            Cmd.Parameters.AddWithValue("@Observaciones", Observaciones)
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

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class
