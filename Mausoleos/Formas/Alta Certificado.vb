Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Alta_Certificado
    Dim SQL_Str As String = Nothing
    Dim CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")




    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        Dim Ruta_Key_Fin As String = Nothing
        Dim Ruta_Cer_Fin As String = Nothing
        Dim Pwd As String = Nothing
        Dim Timbre_Usr As String = Nothing
        Dim Timbre_Pwd As String = Nothing
        If Trim(Me.TextBox_Key.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_Key.Focus()
            Exit Sub
        Else
            Dim Ruta_Key As String = Trim(Me.TextBox_Key.Text)
            Dim result As String
            result = Path.GetFileName(Ruta_Key)
            Dim DirectorioInicio As String = Nothing
            DirectorioInicio = System.AppDomain.CurrentDomain.BaseDirectory()
            Ruta_Key_Fin = RutaSrv + "\ArchivosSAT\" & result
            System.IO.File.Copy(Ruta_Key, Ruta_Key_Fin, True)
        End If

        If Trim(Me.TextBox_Cer.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_Pwd.Focus()
            Exit Sub
        Else
            Dim Ruta_Cer As String = Trim(Me.TextBox_Cer.Text)
            Dim result As String
            result = Path.GetFileName(Ruta_Cer)
            Dim DirectorioInicio As String = Nothing
            DirectorioInicio = System.AppDomain.CurrentDomain.BaseDirectory()
            Ruta_Cer_Fin = RutaSrv + "\ArchivosSAT\" & result
            System.IO.File.Copy(Ruta_Cer, Ruta_Cer_Fin, True)
        End If
        If Trim(Me.TextBox_Pwd.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_Pwd.Focus()
            Exit Sub
        Else
            Pwd = Trim(Me.TextBox_Pwd.Text)
        End If

        If Trim(Me.TextBox_Timbrado_Usr.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_Timbrado_Usr.Focus()
            Exit Sub
        Else
            Timbre_Usr = Trim(Me.TextBox_Timbrado_Usr.Text)
        End If

        If Trim(Me.TextBox_Timbrado_Pwd.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_Timbrado_Pwd.Focus()
            Exit Sub
        Else
            Timbre_Pwd = Trim(Me.TextBox_Timbrado_Pwd.Text)
        End If


        Using Cx As New SqlConnection(CxSettings.ConnectionString)

            Try
                Cx.Open()
                Dim Cmd As New SqlCommand
                Cmd.Connection = Cx
                Cmd.CommandText = "Update Empresa Set Pwd_Llave_Privada = @Pwd_Llave, Llave_Privada = @Llave_Privada, Certificado = @Certificado, Timbrado_Usr = @Timbre_Usr, Timbrado_Pwd = @Timbre_Pwd"
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Pwd_Llave", Pwd)
                Cmd.Parameters.AddWithValue("@Llave_Privada", Ruta_Key_Fin)
                Cmd.Parameters.AddWithValue("@Certificado", Ruta_Cer_Fin)
                Cmd.Parameters.AddWithValue("@Timbre_Usr", Timbre_Usr)
                Cmd.Parameters.AddWithValue("@Timbre_Pwd", Timbre_Pwd)
                Cmd.ExecuteNonQuery()

            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally

                Me.Close()
            End Try
        End Using
    End Sub
    'Function ObtenerCertificado(ByVal Certificado As String) As String
    '    '1. RutaCFD debe ser una ruta cualquiera en donde este el OpenSSL.exe 
    '    '2. Certificado es una variable de cadena que aloja la ruta completa de donde se encuentre tu archivo .cer (ponlo con todo y la extension)
    '    '3. La funcion devuelve una cadena con el certificado ya en base64 para que lo manipules a tu antojo,
    '    ' o bien te crea un txt en la ruta que le endiques en RutaCFD, para que no lo borre solo comenta o elimina la linea del KILL.
    '    Try
    '        Dim StrCer As String
    '        StrCer = RutaCFD & "openssl enc -base64 -in " & Certificado & " -out " & RutaCFD & "certificado.txt"
    '        Shell(StrCer, AppWinStyle.Hide, True)
    '        StrCer = My.Computer.FileSystem.ReadAllText(RutaCFD & "certificado.txt")
    '        StrCer = Replace(StrCer, Chr(10), "")
    '        StrCer = Replace(StrCer, Chr(13), "")
    '        StrCer = Replace(StrCer, " ", "")
    '        StrCer = Replace(StrCer, "-", "")
    '        StrCer = Replace(StrCer, "END", "")
    '        StrCer = Replace(StrCer, "BEGIN", "")
    '        StrCer = Replace(StrCer, "CERTIFICATE", "")
    '        Kill(RutaCFD & "certificado.txt")
    '        ObtenerCertificado = StrCer
    '    Catch ex As Exception
    '        MsgBox(Err.Number & " - " & Err.Description)
    '        ObtenerCertificado = Nothing
    '    End Try
    'End Function



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim myStream As String = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "cer files (*.cer)|*.cer"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.FileName
                If (myStream IsNot Nothing) Then
                    Me.TextBox_Cer.Text = myStream.ToString
                    ' Insert code to read the stream here.
                End If
            Catch Ex As Exception
                MessageBox.Show("No se puede leer el archivo. Error: " & Ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim myStream As String = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "key files (*.key)|*.key"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.FileName
                If (myStream IsNot Nothing) Then
                    ' Insert code to read the stream here.
                    Me.TextBox_Key.Text = myStream.ToString
                End If
            Catch Ex As Exception
                MessageBox.Show("No se puede leer el archivo. Error: " & Ex.Message)
            End Try
        End If
    End Sub

    Private Sub Alta_Certificado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class