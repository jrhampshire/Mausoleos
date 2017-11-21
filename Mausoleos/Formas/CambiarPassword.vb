Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class CambiarPassword
    Dim Contador As Integer = 0
    Dim SQL_Str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim respuesta As String = Nothing


    Private Sub CambiarPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim Existe As Integer = 0
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand
            Cmd.Connection = Cx
            Cmd.CommandText = "Select count (usuario) from Usuarios where Usuario =@Usuario"
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Usuario", Nombre_Usuario)
            Existe = Cmd.ExecuteScalar
            If Existe < 1 Then
                MessageBox.Show("El Usuario no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
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


        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Select Pregunta_Secreta, Respuesta from Usuarios where Usuario = @Usuario"
            Dim Seg As New Seguridad
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Usuario", Nombre_Usuario)
            Dim Reader As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            With Reader
                If .HasRows Then
                    While .Read
                        respuesta = .Item("Respuesta")
                        Label1.Text = .Item("Pregunta_Secreta")
                    End While
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Error al intentar validar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Dim Resp_actual As String = Nothing
        Resp_actual = Trim(Me.TextBox2.Text)

        If Validar() = True Then
            If Resp_actual = respuesta Then

                Try
                    Cx.Open()
                    Dim Cmd As New SqlCommand()
                    Cmd.Connection = Cx
                    Cmd.CommandText = "Update Usuarios set Contraseña = @Psw where Usuario = @Usuario"
                    Dim Seg As New Seguridad
                    Cmd.CommandType = CommandType.Text
                    Cmd.Parameters.AddWithValue("@Usuario", Nombre_Usuario)
                    Cmd.Parameters.AddWithValue("@Psw", Seg.Crear_Hash(TextBox3.Text))
                    Cmd.ExecuteNonQuery()
                    Cx.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Usuarios Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
                Limpia()
                MessageBox.Show("Se ha realizado el cambio de contraseñas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        End If


    End Sub
    Function Validar() As Boolean
        Dim Resp_actual As String = Nothing
        Resp_actual = Trim(Me.TextBox2.Text)
        Dim Psw As String = Nothing
        Psw = Me.TextBox3.Text
        Dim Psw2 As String = Nothing
        Psw2 = Me.TextBox4.Text

        Validar = False
        If Resp_actual = "" Then
            MessageBox.Show("Tienes que escribir tu Respuesta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox2.Focus()
            Exit Function
        Else
            If Psw = "" Then
                MessageBox.Show("La Contraseña es Obligatoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.TextBox2.Focus()
                Exit Function
            Else
                If Len(Psw) < 6 Then
                    MessageBox.Show("La contraseña debe tener mas de 6 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.TextBox2.Focus()
                    Exit Function
                Else
                    If Psw2 = "" Then
                        MessageBox.Show("La Confirmacion es Obligatoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.TextBox2.Focus()
                        Exit Function
                    Else
                        If Trim(Psw) <> Trim(Psw2) Then
                            MessageBox.Show("Las contraseñas no coinciden, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.TextBox3.Text = ""
                            Me.TextBox4.Text = ""
                            Me.TextBox3.Focus()
                            Exit Function
                        End If
                    End If
                End If
            End If
        End If
        Validar = True
    End Function
    Sub Limpia()
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""
        Me.TextBox4.Text = ""
        Me.TextBox2.Focus()
    End Sub
End Class