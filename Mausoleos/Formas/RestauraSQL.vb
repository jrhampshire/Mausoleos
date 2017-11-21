Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports System.Configuration
Imports System
Public Class RestauraSQL

    Private Sub Btnrespaldar_Click(sender As Object, e As EventArgs) Handles Btnrespaldar.Click
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Dim CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
        Dim _Cadcon As String = ConfigurationManager.ConnectionStrings("Cadena").ToString
        Dim _Inicio As Int32 = InStr(_Cadcon, "=")
        Dim _Fin As Int32 = InStr(_Cadcon, ";")
        Dim _DataSource As String = _Cadcon.Substring(_Inicio, (_Fin - (_Inicio + 1)))
        Dim backupFile As String = Me.txtruta.Text
        Dim sBackup As String = "USE Master;" &
            " ALTER DATABASE Mausoleos SET SINGLE_USER With ROLLBACK IMMEDIATE;" &
            " RESTORE DATABASE Mausoleos FROM DISK = '" & backupFile & "' WITH REPLACE"

        'comando para restaurar o base de dados
        Dim csb As New SqlConnectionStringBuilder
        csb.DataSource = _DataSource
        ' Es mejor abrir la conexión con la base Master
        csb.InitialCatalog = "master"
        csb.IntegratedSecurity = True

        Using con As New SqlConnection(csb.ConnectionString)
            Try
                con.Open()
                Dim cmdBackUp As New SqlCommand(sBackup, con)
                cmdBackUp.ExecuteNonQuery()
                MessageBox.Show("Se ha restaurado la copia de la base de datos.",
                                "Restaurar base de datos",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                con.Close()
            Catch ex As SqlException
                MessageBox.Show(ex.Message,
                                "Error al restaurar la base de datos",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message,
                                "Error al restaurar la base de datos",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub BTNAEXAMINAR_Click(sender As Object, e As EventArgs) Handles BTNAEXAMINAR.Click
        Dim myStream As String = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "key files (*.bak)|*.bak"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.FileName
                If (myStream IsNot Nothing) Then
                    ' Insert code to read the stream here.
                    Me.txtruta.Text = myStream.ToString
                    Me.Btnrespaldar.Enabled = True
                End If
            Catch Ex As Exception
                MessageBox.Show("No se puede leer el archivo. Error: " & Ex.Message)
            End Try
        End If
    End Sub

    Private Sub Btnsalir_Click(sender As Object, e As EventArgs) Handles Btnsalir.Click
        Me.Close()
    End Sub
End Class