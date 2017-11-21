Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class Series
    Dim SQL_Str As String = Nothing
    Dim CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Private Sub Series_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Items.Clear()
        Carga_Series()

    End Sub
    Sub Carga_Series()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            SQL_Str = "Select * from Series Order by Serie"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Series")
                With ListBox1
                    .DataSource = DS.Tables(0)
                    .DisplayMember = "Serie"
                    .ValueMember = "Id_Serie"
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub


    Sub Guarda_Datos()
        Dim Serie As String = Nothing
        Serie = Trim(Me.TextBox1.Text)
        If Serie = "" Then
            MessageBox.Show("Este dato es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox1.Focus()
            Exit Sub

        End If
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            SQL_Str = "Insert into Series (Serie) Values (@Serie)"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Serie", Serie)
                Cmd.ExecuteNonQuery()

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

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Guarda_Datos()
            Carga_Series()
        End If
    End Sub

    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        Guarda_Datos()
        Carga_Series()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button_Borrar_Click(sender As Object, e As EventArgs) Handles Button_Borrar.Click
        Dim Id_Serie As Integer = 0
        Id_Serie = Me.ListBox1.SelectedValue
        If Id_Serie = 0 Then
            MessageBox.Show("Debe de seleccionar una Serie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Using Cx As New SqlConnection(CxSettings.ConnectionString)
                Try

                    Cx.Open()
                    Dim SQL_Str As String = "Delete from Series where Id_Serie = @Id_Serie"
                    Dim Cmd_Borra As SqlCommand = New SqlCommand(SQL_Str, Cx)
                    Cmd_Borra.CommandType = CommandType.Text
                    Cmd_Borra.Parameters.AddWithValue("@Id_Serie", Id_Serie)
                    Cmd_Borra.ExecuteNonQuery()
                    Cx.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End Using
            Carga_Series()
        End If
    End Sub
End Class