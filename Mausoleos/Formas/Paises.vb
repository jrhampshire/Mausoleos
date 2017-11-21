Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Paises
#Region "Variables"
    Dim Id_Pais As Integer
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)

#End Region
    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Guarda()
    End Sub
    Sub Guarda()
        Dim Pais As String = Nothing
        Dim Sql_str As String = Nothing
        Pais = Me.Textbox_Pais.Text
        If Pais = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Textbox_Pais.Focus()
            Exit Sub
        Else
            Try
                Cx.Open()
                '////////////////////////////////////////////////////
                'Verifico que no exista el Pais
                '////////////////////////////////////////////////////
                Sql_str = "Select * from Paises where Pais = @Pais"
                Dim Cmd_Revisa As SqlCommand = New SqlCommand(Sql_str, Cx)
                Cmd_Revisa.Parameters.AddWithValue("@Pais", Pais)
                Dim Tot As Integer = 0
                Cmd_Revisa.CommandType = CommandType.Text
                Tot = CInt(Cmd_Revisa.ExecuteScalar)
                Cx.Close()
                If Tot >= 1 Then
                    MessageBox.Show("Ya existe este Pais en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                '////////////////////////////////////////////////////
                'Si no existe el Pais lo guardo
                '////////////////////////////////////////////////////
                If Cx.State = ConnectionState.Closed Then
                    Cx.Open()
                End If
                Sql_str = "Insert into Paises (Pais) Values(@Pais)"
                Dim Cmd_Inserta As SqlCommand = New SqlCommand(Sql_str, Cx)
                Cmd_Inserta.Parameters.AddWithValue("@Pais", Pais)
                Cmd_Inserta.CommandType = CommandType.Text
                Cmd_Inserta.ExecuteNonQuery()
                '////////////////////////////////////////////////////
                'ya que guarde el el Pais en la Base de Datos lo agrego al listbox
                '////////////////////////////////////////////////////
                'Me.ListBox.Items.Clear()
                Cx.Close()
                Cargar_Paises()
                Me.Textbox_Pais.Text = ""
                Me.Textbox_Pais.Focus()
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

    Private Sub Estados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Paises()
    End Sub
    Sub Cargar_Paises()
        Dim SQL_Str As String = "Select * from Paises order by Pais"
        Try
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Paises")
            With Me.ListBox_Paises
                .DataSource = DS.Tables("Paises")
                .DisplayMember = "Pais"
                .ValueMember = "id_paises"
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

    Private Sub Btn_Borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Borrar.Click

        Dim Id_Pais As Integer = 0
        Id_Pais = Me.ListBox_Paises.SelectedValue
        If Id_Pais = 0 Then
            MessageBox.Show("Debe de seleccionar un Pais", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Try
                Cx.Open()
                Dim SQL_Str As String = "Delete from Paises where id_Paises = @Pais"
                Dim Cmd_Borra As SqlCommand = New SqlCommand(SQL_Str, Cx)
                Cmd_Borra.CommandType = CommandType.Text
                Cmd_Borra.Parameters.AddWithValue("@Pais", Id_Pais)
                Cmd_Borra.ExecuteNonQuery()
                Cx.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
                Cargar_Paises()
            End Try
        End If
    End Sub

    Private Sub Textbox_Pais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textbox_Pais.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Guarda()
        End If
    End Sub

    Private Sub Textbox_Pais_TextChanged(sender As Object, e As EventArgs) Handles Textbox_Pais.TextChanged

    End Sub
End Class