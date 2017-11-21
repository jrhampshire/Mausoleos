Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Pregunta_Secreta
    Dim SQL_Str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)

    Private Sub Button_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Button_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Aceptar.Click
        Guarda()

    End Sub
    Sub Guarda()
        Dim Pregunta As String = Me.ComboBox_Pregunta.SelectedItem
        Dim Respuesta As String = Me.TextBox_Respuesta.Text
        If Respuesta = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_Respuesta.Focus()
            Exit Sub
        End If
        SQL_Str = "UPDATE Usuarios SET Pregunta_Secreta = @Pregunta, Respuesta = @Respuesta" &
        " WHERE ID_Usuario = @Usuario"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Pregunta", Pregunta)
            Cmd.Parameters.AddWithValue("@Respuesta", Respuesta)
            Cmd.Parameters.AddWithValue("@Usuario", Usuario_Actual)
            Cmd.ExecuteNonQuery()
            MessageBox.Show("Su pregunta secreta se ha guardado con exito", "Pregunta Secreta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As SqlException
            MessageBox.Show("Error: " & ex.Message, "Pregunta Secreta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Pregunta Secreta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub
    Private Sub TextBox_Respuesta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox_Respuesta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Guarda()
        End If
    End Sub

End Class