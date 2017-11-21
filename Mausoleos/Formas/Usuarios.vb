Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Usuarios
#Region "Variables"
    Dim Usr As New Empleados
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim Sql_str As String = ""
    Private DA As New SqlDataAdapter
    Private DS As New DataSet
    Private Permisos As String

#End Region
#Region "Codigo"

    Function Valida_Informacion() As Boolean

        Permisos = ""
        Valida_Informacion = False
        With Usr
            If Trim(Me.TextBox_Nombre.Text) = "" Then
                MessageBox.Show("Este dato es obligatorio", "Error 28", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.TextBox_Nombre.Focus()
                Exit Function
            Else
                .Nombre = Trim(Me.TextBox_Nombre.Text)
            End If
            If Me.txt_Usuario.Text = "" Then
                MessageBox.Show("Este dato es obligatorio", "Error 28", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txt_Usuario.Focus()
                Exit Function
            Else
                .Usr = Trim(Me.txt_Usuario.Text)
            End If
            If Me.txt_Pwd.Text = "" Then
                MessageBox.Show("Este dato es obligatorio", "Error 29", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.txt_Pwd.Focus()
                Exit Function
            Else
                If Me.txt_Pwd2.Text = "" Then
                    MessageBox.Show("Este dato es obligatorio", "Error 30", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.txt_Pwd2.Focus()
                    Exit Function
                Else
                    If Trim(Me.txt_Pwd.Text) <> Trim(Me.txt_Pwd2.Text) Then
                        MessageBox.Show("Las contraseñas no coinciden, intente nuevamente", "Error 31", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.txt_Pwd.Text = ""
                        Me.txt_Pwd2.Text = ""
                        Me.txt_Pwd.Focus()
                        Exit Function
                    Else
                        .Pwd = Trim(Me.txt_Pwd.Text)
                    End If
                End If
            End If
            If Me.RadioButton_Admon.Checked = True Then
                Permisos = "Administrador"
            ElseIf Me.RadioButton_User.Checked = True Then
                Permisos = "Ventas"

            End If
            Valida_Informacion = True
        End With
    End Function
    Sub Procesar()
        '////////////////////////////////////////////////////////////////
        'Valida la informacion que se acaba de capturar
        '////////////////////////////////////////////////////////////////
        If Valida_Informacion() = True Then
            '////////////////////////////////////////////////////////////////
            'Primero verifico que el usuario no se encuentre ya en la base de datos 
            '////////////////////////////////////////////////////////////////


            Dim Existe As Integer = Nothing
            'Try
            '    Cx.Open()
            '    Dim Cmd As New SqlCommand(Sql_str, Cx)
            '    Cmd.Parameters.AddWithValue("@Full_Name", Nombre)
            '    Existe = Cmd.ExecuteScalar()
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message, "Error 32", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'Finally
            '    If Cx.State = ConnectionState.Open Then
            '        Cx.Close()
            '    End If
            'End Try


            Try
                Cx.Open()
                Dim Cmd As New SqlCommand
                Cmd.Connection = Cx
                Cmd.CommandText = "select * from usuarios where usuario = @User_Name"
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@User_Name", Usr.Usr)
                Existe = Cmd.ExecuteScalar()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error 32", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try

            If Existe < 1 Then
                '///////////////////////////////////////
                'Aqui Guardo
                '///////////////////////////////////////
                Dim Seg As New Seguridad
                Dim Cmd1 As New SqlCommand
                Cmd1.Connection = Cx
                Cmd1.CommandText = "INSERT INTO usuarios (usuario,Pasword,Permisos,Activo,Observaciones,Nombre, Direccion, Tel_Particular, Tel_Celular)" &
                "Values(@usuario,@Pwd,@Permisos,@Activo,@Observaciones,@Nombre, @Direccion, @Tel_Particular, @Tel_Celular)"
                Cmd1.Parameters.AddWithValue("@Nombre", Usr.Nombre)
                Cmd1.Parameters.AddWithValue("@Usuario", Usr.Usr)
                Cmd1.Parameters.AddWithValue("@Pwd", Seg.Crear_Hash(Usr.Pwd))
                Cmd1.Parameters.AddWithValue("@Permisos", Permisos)
                Cmd1.Parameters.AddWithValue("@Activo", True)
                Cmd1.Parameters.AddWithValue("@Observaciones", Trim(Me.TextBox_Observaciones.Text))
                Cmd1.Parameters.AddWithValue("@Direccion", Trim(Me.TextBox_Direccion.Text))
                Cmd1.Parameters.AddWithValue("@Tel_Particular", Trim(Me.TextBox_Tel_Part.Text))
                Cmd1.Parameters.AddWithValue("@Tel_Celular", Trim(Me.TextBox_Tel_Cel.Text))
                Try
                    Cx.Open()
                    Cmd1.ExecuteNonQuery()
                    Dim Msg_Resp As DialogResult = MessageBox.Show("Desea agregar otro usuario?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If Msg_Resp = DialogResult.Yes Then
                        Limpiar()
                    Else
                        Me.Close()
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error 33", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    If (Cx.State = ConnectionState.Open) Then
                        Cx.Close()
                    End If
                End Try
            Else
                MessageBox.Show("Ya existe un usuario con este nombre", "Error 34", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.TextBox_Nombre.Focus()
                Me.TextBox_Nombre.SelectAll()
            End If
        End If
    End Sub
    Sub Limpiar()
        Me.TextBox_Nombre.Text = ""
        Me.txt_Pwd.Text = ""
        Me.txt_Pwd2.Text = ""
        Me.txt_Usuario.Text = ""
        Me.TextBox_Nombre.Focus()
    End Sub
    Private Sub txt_Nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.TextBox_Direccion.Focus()
        End If
    End Sub


    Private Sub txt_Usuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Usuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.txt_Pwd.Focus()

        End If
    End Sub

    Private Sub txt_Pwd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Pwd.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.txt_Pwd2.Focus()
        End If
    End Sub

    Private Sub txt_Pwd2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Pwd2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.RadioButton_Admon.Focus()
        End If
    End Sub



#End Region

    Private Sub TextBox_Num_Int_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.TextBox_Tel_Part.Focus()

        End If
    End Sub

    Private Sub TextBox_Tel_Part_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Tel_Part.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.TextBox_Tel_Cel.Focus()

        End If
    End Sub



    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        Procesar()
    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim Valor_Actual As Boolean = Me.CheckBox1.Checked
        If Valor_Actual = True Then
            Me.txt_Pwd.PasswordChar = ""
            Me.txt_Pwd2.PasswordChar = ""
        Else
            Me.txt_Pwd.PasswordChar = "*"
            Me.txt_Pwd2.PasswordChar = "*"
        End If
    End Sub
End Class