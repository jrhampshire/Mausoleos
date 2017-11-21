Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration


Public Class Parentescos
#Region "Variables"
    Dim Id_Parentesco As Integer
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)

#End Region
    Private Sub Parentescos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_Parentescos()
    End Sub
    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Guarda()
    End Sub
    Sub Guarda()
        Dim Parentesco As String = Nothing
        Dim Sql_str As String = Nothing
        Parentesco = Me.Textbox_Pais.Text
        If Parentesco = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Textbox_Pais.Focus()
            Exit Sub
        Else
            Try
                Cx.Open()
                '////////////////////////////////////////////////////
                'Verifico que no exista el Parentesco
                '////////////////////////////////////////////////////
                Sql_str = "Select * from Parentescos where Parentesco = @Parentesco"
                Dim Cmd_Revisa As SqlCommand = New SqlCommand(Sql_str, Cx)
                Cmd_Revisa.Parameters.AddWithValue("@Parentesco", Parentesco)
                Dim Tot As Integer = 0
                Cmd_Revisa.CommandType = CommandType.Text
                Tot = CInt(Cmd_Revisa.ExecuteScalar)
                Cx.Close()
                If Tot >= 1 Then
                    MessageBox.Show("Ya existe este Parentesco en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                '////////////////////////////////////////////////////
                'Si no existe el Parentesco lo guardo
                '////////////////////////////////////////////////////
                If Cx.State = ConnectionState.Closed Then
                    Cx.Open()
                End If
                Sql_str = "Insert into Parentescos (Parentesco) Values(@Parentesco)"
                Dim Cmd_Inserta As SqlCommand = New SqlCommand(Sql_str, Cx)
                Cmd_Inserta.Parameters.AddWithValue("@Parentesco", Parentesco)
                Cmd_Inserta.CommandType = CommandType.Text
                Cmd_Inserta.ExecuteNonQuery()
                '////////////////////////////////////////////////////
                'ya que guarde el el Parentesco en la Base de Datos lo agrego al listbox
                '////////////////////////////////////////////////////
                'Me.ListBox.Items.Clear()
                Cx.Close()
                Cargar_Parentescos()
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
    Sub Cargar_Parentescos()
        Dim SQL_Str As String = "Select * from Parentescos order by Parentesco"
        Try
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Parentescos")
            With Me.ListBox_Parentesco
                .DataSource = DS.Tables("Parentescos")
                .DisplayMember = "Parentesco"
                .ValueMember = "id_Parentesco"
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

        Dim Id_Parentesco As Integer = 0
        Id_Parentesco = Me.ListBox_Parentesco.SelectedValue
        If Id_Parentesco = 0 Then
            MessageBox.Show("Debe de seleccionar un Parentesco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Try
                Cx.Open()
                Dim SQL_Str As String = "Delete from Parentescos where id_Parentesco = @Parentesco"
                Dim Cmd_Borra As SqlCommand = New SqlCommand(SQL_Str, Cx)
                Cmd_Borra.CommandType = CommandType.Text
                Cmd_Borra.Parameters.AddWithValue("@Parentesco", Id_Parentesco)
                Cmd_Borra.ExecuteNonQuery()
                Cx.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
                Cargar_Parentescos()
            End Try
        End If
    End Sub

    Private Sub Textbox_Pais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Textbox_Pais.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Guarda()
        End If
    End Sub

End Class