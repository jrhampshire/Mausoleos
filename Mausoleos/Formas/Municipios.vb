Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Municipios
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim Paises_Cargados As Boolean = False
    Dim Estados_Cargados As Boolean = False
#End Region
#Region "Codigo"
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Guarda()
    End Sub
    Sub Guarda()
        Dim SQL_Str As String = ""
        Dim Estado_Actual As Integer = 0
        Dim Municipio As String = ""
        Try
            Estado_Actual = Me.CB_Estado.SelectedValue
        Catch ex As Exception
            MessageBox.Show("Debe de seleccionar primero un Estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        Municipio = Me.Txt_Municipio.Text
        If Municipio = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Txt_Municipio.Focus()
            Exit Sub
        Else

            SQL_Str = "Select Count(Municipio) from Municipio Where Municipio = @Municipio and id_Estado = @ID_Estado"
            Dim Existe As Integer = 0
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Municipio", Municipio)
                Cmd.Parameters.AddWithValue("@ID_Estado", Estado_Actual)
                Existe = Cmd.ExecuteScalar
                If Existe > 0 Then
                    MessageBox.Show("El Municipio ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
            If Existe < 1 Then
                Try
                    Cx.Open()
                    SQL_Str = "Insert into Municipio (Municipio,Id_Estado) Values (@Municipio,@ID_Estado)"
                    Dim Cmd_Ejecuta As SqlCommand = New SqlCommand(SQL_Str, Cx)
                    Cmd_Ejecuta.CommandType = CommandType.Text
                    Cmd_Ejecuta.Parameters.AddWithValue("@Municipio", Municipio)
                    Cmd_Ejecuta.Parameters.AddWithValue("@ID_Estado", Estado_Actual)
                    Cmd_Ejecuta.ExecuteNonQuery()
                    Cx.Close()
                    Me.Txt_Municipio.Text = ""
                    Me.Txt_Municipio.Focus()
                    Carga_Municipios()
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
    Private Sub Municipios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Estado.SelectedIndexChanged
        Me.ListBox1.Items.Clear()
        If Estados_Cargados = True Then
            Carga_Municipios()
        End If

    End Sub
    Private Sub Btn_Borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Borrar.Click
        Dim Municipio As String = ""
        Dim Estado_Actual As String = ""
        Estado_Actual = Me.CB_Estado.Text
        If Estado_Actual = "" Then
            MessageBox.Show("Debe Seleccionar primero un Estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If
        Municipio = Me.ListBox1.SelectedValue
        If Municipio = "" Then
            MessageBox.Show("Debe Seleccionar un Municipio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Try
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
                Cx.Open()
                Dim SQL_Str As String = "Delete Municipio where id_Municipio = @Municipio"
                Dim Cmd_Borra As SqlCommand = New SqlCommand(SQL_Str, Cx)
                Cmd_Borra.CommandType = CommandType.Text
                Cmd_Borra.Parameters.AddWithValue("@Municipio", Municipio)
                Cmd_Borra.ExecuteNonQuery()
                Cx.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
                Carga_Municipios()
            End Try

        End If
    End Sub
    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
    Sub Carga_Estados()
        Dim Id_Pais As Integer = 0
        Try
            Id_Pais = Me.ComboBox1.SelectedValue
        Catch ex As Exception
            MessageBox.Show("Se debe de seleccionar un pais primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox1.Focus()
            Exit Sub
        End Try
        Dim SQL_Str As String = "Select * from Estado where Id_Paises = @Id_Pais order by Estado"
        Try
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Pais", Id_Pais)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Estados")
            With Me.CB_Estado
                .DataSource = DS.Tables("Estados")
                .DisplayMember = "Estado"
                .ValueMember = "ID_Estado"
            End With
            Estados_Cargados = True
            Me.CB_Estado.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
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
                With ListBox1
                    .DataSource = DS.Tables("Municipios")
                    .DisplayMember = "Municipio"
                    .ValueMember = "Id_Municipio"
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
        End Using
    End Sub
    Private Sub Txt_Municipio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Municipio.KeyPress
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
End Class