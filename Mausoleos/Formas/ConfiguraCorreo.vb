Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient


Public Class ConfiguraCorreo
#Region "Variables Globales"
    Dim SQL_Str As String = Nothing
    Dim CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
#End Region
#Region "Carga Informacion"
    Sub Carga_Info()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Transaccion As SqlTransaction = Nothing
            Try
                Cx.Open()
                SQL_Str = "Select Servidor_SMTP, Puerto_SMTP, Usuario_Email, Pwd_Email From Empresa"
                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = SQL_Str
                Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                With DR
                    If .HasRows Then
                        While .Read
                            TextBox_Servidor.Text = .Item("Servidor_SMTP")
                            TextBox_Usuario.Text = .Item("Usuario_Email")
                            TextBox_Pwd.Text = .Item("Pwd_Email")
                            TextBox_Puerto.Text = .Item("Puerto_SMTP")
                        End While
                    End If
                End With
            Catch ex As SqlException
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Try
                    Transaccion.Rollback()
                Catch ex2 As Exception
                    MessageBox.Show("Message: {0}" + ex2.Message, "Rollback Exception Type: {0}" & ex2.GetType.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Try
                    Transaccion.Rollback()
                Catch ex2 As Exception
                    MessageBox.Show("Message: {0}" + ex2.Message, "Rollback Exception Type: {0}" & ex2.GetType.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End Using
    End Sub
#End Region
    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Close()
    End Sub
    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        Dim TotalRegistros As Int16 = 0
        Dim query As String = "SELECT COUNT(Id_Empresa) AS rollcount FROM Empresa"
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Cx.Open()
            Using cmd As New SqlCommand()
                With cmd
                    .Connection = Cx
                    .CommandText = query
                    .CommandType = CommandType.Text
                End With
                Try
                    TotalRegistros = Convert.ToInt16(cmd.ExecuteScalar())

                Catch ex As SqlException
                Catch ex As Exception
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End Using
        End Using
        Dim Servidor As String = Nothing
        Dim Usr As String = Nothing
        Dim Pwd As String = Nothing
        Dim Puerto As Integer = 0

        Servidor = Trim(TextBox_Servidor.Text)
        If Servidor = "" Then
            MessageBox.Show("Este dato es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox_Servidor.Focus()
            Exit Sub
        End If
        Usr = Trim(TextBox_Usuario.Text)
        If Usr = "" Then
            MessageBox.Show("Este dato es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox_Usuario.Focus()
            Exit Sub
        End If
        Pwd = Trim(TextBox_Pwd.Text)
        If Pwd = "" Then
            MessageBox.Show("Este dato es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox_Pwd.Focus()
            Exit Sub
        End If
        If (TextBox_Puerto.Text = Nothing Or TextBox_Puerto.Text = "") Then
            MessageBox.Show("Este dato es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox_Puerto.Focus()
            Exit Sub
        Else
            Puerto = TextBox_Puerto.Text
        End If
        'Aqui guarda la informacion en la base de datos

        If TotalRegistros = 1 Then
            Using Cx As New SqlConnection(CxSettings.ConnectionString)
                Dim Transaccion As SqlTransaction = Nothing
                Try
                    Cx.Open()
                    Transaccion = Cx.BeginTransaction("Configura Correo")
                    SQL_Str = "Update Empresa set Servidor_SMTP = @Servidor, Puerto_SMTP = @Puerto," &
                        " Usuario_Email = @Usr, Pwd_Email = @Pwd"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandText = SQL_Str
                    Cmd.CommandType = CommandType.Text
                    Cmd.Transaction = Transaccion
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@Servidor", Servidor)
                    Cmd.Parameters.AddWithValue("@Usr", Usr)
                    Cmd.Parameters.AddWithValue("@Pwd", Pwd)
                    Cmd.Parameters.AddWithValue("@Puerto", Puerto)
                    Cmd.ExecuteNonQuery()
                    Transaccion.Commit()
                    Me.Close()
                Catch ex As SqlException
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Try
                        Transaccion.Rollback()
                    Catch ex2 As Exception
                        MessageBox.Show("Message: {0}" + ex2.Message, "Rollback Exception Type: {0}" & ex2.GetType.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Exit Sub
                Catch ex As Exception
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Try
                        Transaccion.Rollback()
                    Catch ex2 As Exception
                        MessageBox.Show("Message: {0}" + ex2.Message, "Rollback Exception Type: {0}" & ex2.GetType.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Exit Sub
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End Using
            MessageBox.Show("Se han actualizado los datos correctamente", "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub
    Private Sub TextBox_Puerto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Puerto.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub ConfiguraCorreo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Info()

    End Sub
End Class