Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports System.Configuration
Imports System
'Imports Chilkat
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Threading
Imports System.ComponentModel




Public Class RespaldaSQL
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    ' Dim zip As New Chilkat.Zip()
    'Dim _continua As Boolean = True
    Dim Archivo As String
    Dim DESTINO As String
    Dim Destino2 As String
    Dim ArchivoZip As String
#End Region
    Private Sub btnrespaldar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnrespaldar.Click
        Respalda()
    End Sub
    Sub Respalda()
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            If txtdestino.Text = "" Then
                MsgBox("Escoja la ubicación para guardar la copia de seguridad")
            Else
                DESTINO = txtdestino.Text
                Destino2 = DESTINO & Replace(Archivo, ".bak'", "")
                My.Computer.FileSystem.CreateDirectory(Destino2)
                'Este Query se encarga de hacer el backup en la ruta que escojiste 
                Dim cmd As New SqlCommand("BACKUP DATABASE Mausoleos TO DISK = '" & Destino2 & Archivo, Cx)
                Using Cx
                    Cx.Open()
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    Cx.Close()
                    Cx.Dispose()
                End Using
                If Me.CheckBox1.Checked = True Then
                    Comprime()
                End If
                MessageBox.Show("Respaldo realizado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As SqlException
            MsgBox(ex.Message, MsgBoxStyle.Critical, AcceptButton)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, AcceptButton)
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Cursor = System.Windows.Forms.Cursors.Default
        Close()

    End Sub

    Sub Comprime()
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim StartPath As String = Destino2

        Dim ZipPath As String = RutaSrv + "\RespBaseDeDatos\Zip" & Replace(ArchivoZip, ".bak'", ".zip")

        Try
            Dim _Remitente As String = "soporte@lhconsultores.com"
            Dim _Destinatario As String = "soporte@lhconsultores.com"
            Dim _Puerto As Integer = 587
            Dim _Servidor As String = "geo.websitewelcome.com"
            Dim _Usuario As String = "soporte@lhconsultores.com"

            ZipFile.CreateFromDirectory(StartPath, ZipPath)
            If File.Exists(RutaSrv + "\RespBaseDeDatos\Zip" & Replace(ArchivoZip, ".bak'", ".zip")) Then
                Dim ArchivosAdjuntos As New List(Of String)()
                Try

                    ArchivosAdjuntos.Add(ZipPath)
                    enviarCorreoE(_Remitente, _Destinatario, "Respaldo DB Mausoleos",
                                  "Respaldo DB Mausoleos", ArchivosAdjuntos, _Servidor, _Puerto, True)

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, AcceptButton)
                End Try
                Cursor = System.Windows.Forms.Cursors.Default
            Else
                Dim result As System.IO.WaitForChangedResult
                Dim watcher As New System.IO.FileSystemWatcher(RutaSrv + "\RespBaseDeDatos\Zip\")
                result = watcher.WaitForChanged(System.IO.WatcherChangeTypes.Created)
                Dim ArchivosAdjuntos As New List(Of String)()
                Try

                    ArchivosAdjuntos.Add(ZipPath)
                    enviarCorreoE(_Remitente, _Destinatario, "Respaldo DB Mausoleos",
                                  "Respaldo DB Mausoleos", ArchivosAdjuntos, _Servidor, _Puerto, True)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, AcceptButton)
                End Try
                Cursor = System.Windows.Forms.Cursors.Default
            End If

        Catch ex As ArgumentException
            MsgBox(ex.Message, MsgBoxStyle.Critical, AcceptButton)
        Catch ex As PathTooLongException
            MsgBox(ex.Message, MsgBoxStyle.Critical, AcceptButton)
        Catch ex As DirectoryNotFoundException
            MsgBox(ex.Message, MsgBoxStyle.Critical, AcceptButton)
        Catch ex As IOException
            MsgBox(ex.Message, MsgBoxStyle.Critical, AcceptButton)
        Catch ex As UnauthorizedAccessException
            MsgBox(ex.Message, MsgBoxStyle.Critical, AcceptButton)
        Catch ex As NotSupportedException
            MsgBox(ex.Message, MsgBoxStyle.Critical, AcceptButton)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, AcceptButton)
        End Try

    End Sub

    Private Sub BTNAEXAMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAEXAMINAR.Click

        Dim dlgDestino As New FolderBrowserDialog
        With dlgDestino
            .Description = "Seleccione el directorio de destino:"
            .RootFolder = Environment.SpecialFolder.Desktop
            .SelectedPath = RutaSrv + "\RespBaseDeDatos\Original"
            If .ShowDialog = DialogResult.OK Then

                Dim strDestino As String = .SelectedPath.ToString
                If Not strDestino.EndsWith("") Then
                    strDestino = strDestino & ""
                End If
                Me.txtdestino.Text = strDestino
            End If
        End With
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnsalir.Click
        Close()
    End Sub

    Private Sub RespaldaSQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtdestino.Text = RutaSrv + "\RespBaseDeDatos\Original"
        Archivo = "\BACKUP" & Now.ToString("yyyyMMddTHHmmss") & ".bak'"
        ArchivoZip = Replace(Archivo, "BACKUP", "BDComprimida").ToString
        DESTINO = txtdestino.Text
    End Sub

    Public Sub enviarCorreoE(ByVal Remitente As String,
                                      ByVal Destinatario As String,
                                      ByVal Asunto As String,
                                      ByVal Cuerpo As String,
                                      ByVal RutaArchivos As List(Of String),
                                      ByVal ServidorSmtp As String,
                                      ByRef PuertoSmtp As Integer,
                                      Optional ByVal MostrarMensajeOK As Boolean = False)

        Try
            Dim smtpMail As New SmtpClient
            Dim oMsg As New System.Net.Mail.MailMessage(Remitente, Destinatario, Asunto, Cuerpo)
            oMsg.IsBodyHtml = True
            Dim i As Integer = 0
            Dim ruta As List(Of String) = New List(Of String)

            If RutaArchivos.Count > 0 Then
                While (i < RutaArchivos.Count)
                    Dim sFile As String = RutaArchivos(i)
                    Dim oAttch As Net.Mail.Attachment = New Net.Mail.Attachment(sFile, "")
                    oMsg.Attachments.Add(oAttch)
                    i = i + 1
                End While
            End If

            smtpMail.Host = ServidorSmtp
            smtpMail.Credentials = New System.Net.NetworkCredential(Remitente, "esm9708")
            smtpMail.Port = PuertoSmtp
            smtpMail.EnableSsl = True
            smtpMail.Send(oMsg)
            'smtpMail.Timeout= 
            If MostrarMensajeOK Then

                MsgBox("MENSAJE ENVIADO CORRECTAMENTE",
                                MsgBoxStyle.Information)
            End If

        Catch ex As SmtpFailedRecipientException
            If MostrarMensajeOK Then
                MsgBox("ERROR: " & ex.Message & "  - MENSAJE NO ENVIADO")
            End If
        Catch ex As SmtpException
            If MostrarMensajeOK Then
                MsgBox("ERROR: " & ex.Message & "  - MENSAJE NO ENVIADO")
            End If
        Catch ex As Exception
            If MostrarMensajeOK Then
                MsgBox("ERROR: " & ex.Message & "  - MENSAJE NO ENVIADO")
            End If
        End Try
    End Sub
End Class