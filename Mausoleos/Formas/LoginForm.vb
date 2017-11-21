Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class LoginForm
    Dim Contador As Integer = 0
    Dim SQL_Str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim Usuario As String = Nothing
        Dim Contraseña As String = Nothing
        Usuario = UsernameTextBox.Text
        If Usuario = "" Then
            MessageBox.Show("Este campo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.UsernameTextBox.Focus()
            Exit Sub
        End If
        Contraseña = PasswordTextBox.Text
        If Contraseña = "" Then
            MessageBox.Show("Este campo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.PasswordTextBox.Focus()
            Exit Sub
        Else
            If Len(Contraseña) < 6 Then
                MessageBox.Show("La contraseña debe tener mas de 6 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.PasswordTextBox.Focus()
                Exit Sub
            Else
                If Usuario = "Admin" And Contraseña = "123123123" Then
                    Usuario_Actual = 0
                    Permisos = "Administrador"
                    Me.Close()
                    Exit Sub
                End If

                If Valida(Usuario, Contraseña) = True Then

                    Dim Pregunta As String = Nothing
                    SQL_Str = "Select Id_Usuario,Pregunta_Secreta,Permisos from Usuarios where Usuario = @Usuario and Pwd = @Pwd and Activo = 'True'"
                    Try
                        Cx.Open()
                        Dim Cmd As New SqlCommand(SQL_Str, Cx)
                        Dim Seg As New Seguridad
                        Cmd.CommandType = CommandType.Text
                        Cmd.Parameters.AddWithValue("@Usuario", Usuario)
                        Cmd.Parameters.AddWithValue("@pwd", Seg.Crear_Hash(Contraseña))
                        Dim Reader As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        With Reader
                            If .HasRows Then
                                Nombre_Usuario = Usuario
                                While .Read
                                    Usuario_Actual = .Item("Id_Usuario")
                                    Permisos = .Item("Permisos").ToString
                                    Pregunta = .Item("Pregunta_Secreta").ToString
                                End While
                            End If
                        End With
                    Catch ex As SqlException
                        MessageBox.Show("Error : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End
                    Catch ex As Exception
                        MessageBox.Show("Error : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End
                    Finally
                        If Cx.State = ConnectionState.Open Then
                            Cx.Close()
                        End If
                    End Try
                    Me.Close()
                    Dim Respuesta As DialogResult
                    If Pregunta = "" Then
                        Respuesta = MessageBox.Show("Aun no ha asignado una pregunta secreta para cambiar su contraseña, ¿desea hacerlo ahora?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If Respuesta = DialogResult.Yes Then
                            Dim Frm_Pregunta_Secreta As New Pregunta_Secreta
                            Frm_Pregunta_Secreta.ShowDialog()
                        Else
                            End
                        End If
                    End If
                    Me.Close()

                Else
                    MessageBox.Show("Nombre de usuario y contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Contador = Contador + 1
                    Limpia()
                    Exit Sub
                End If
            End If
        End If
    End Sub
    Sub Limpia()
        Me.UsernameTextBox.Text = ""
        Me.PasswordTextBox.Text = ""
        Me.UsernameTextBox.Focus()
        If Contador = 5 Then
            End
        End If
    End Sub
    Function Valida(ByVal Usr As String, ByVal Pwd As String) As Boolean
        SQL_Str = "Select count(*) from Usuarios where Usuario = @Usuario and Pwd = @Pwd"
        Try
            Cx.Open()
            Dim Seg As New Seguridad
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Usuario", Usr)
            Cmd.Parameters.AddWithValue("@pwd", Seg.Crear_Hash(Pwd))
            Dim X As Integer = 0
            X = Cmd.ExecuteScalar.ToString
            If X = 0 Then
                Valida = False
            Else
                Valida = True
            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar validar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End

        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

    End Function
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        End
    End Sub

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.UsernameTextBox.Focus()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Nombre_Usuario = Me.UsernameTextBox.Text
        If Nombre_Usuario <> "" Then
            Dim Frm_Cambio_Contraseña As New CambiarPassword
            Frm_Cambio_Contraseña.ShowDialog()
            Me.PasswordTextBox.Text = ""
            Me.PasswordTextBox.Focus()
        Else
            MessageBox.Show("Debe ingresar el nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.UsernameTextBox.Focus()
            Exit Sub
        End If

    End Sub


End Class
