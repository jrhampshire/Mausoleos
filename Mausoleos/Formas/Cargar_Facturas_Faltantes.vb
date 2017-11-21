Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports System.Configuration
Imports System
Imports System.Xml
Imports System.Data.SqlTypes
'Imports Chilkat
Imports System.IO
Imports clsCFDIx
Imports System.IO.Compression
Imports System.Net.Mail
Imports System.Text

Public Class Cargar_Facturas_Faltantes
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Dim Sql_Str As String = Nothing
    Private Sub BTNAEXAMINAR_Click(sender As Object, e As EventArgs) Handles BTNAEXAMINAR.Click
        Dim dlgDestino As New FolderBrowserDialog
        With dlgDestino
            .Description = "Seleccione el directorio de destino:"
            .RootFolder = Environment.SpecialFolder.Desktop
            .SelectedPath = "C:\SiFact\Facturas"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim strDestino As String = .SelectedPath.ToString
                If Not strDestino.EndsWith("") Then
                    strDestino = strDestino & ""
                End If
                Me.txtdestino.Text = strDestino
            End If
        End With
    End Sub
    Private Sub Btnsalir_Click(sender As Object, e As EventArgs) Handles Btnsalir.Click
        Me.Close()

    End Sub

    Private Sub Btnrespaldar_Click(sender As Object, e As EventArgs) Handles Btnrespaldar.Click
        Dim Ruta As String = Me.txtdestino.Text
        Dim _XML As String = Nothing
        Dim _PDF As String = Nothing

        Dim param_XML As SqlXml

        If Directory.Exists(Ruta) Then
            Dim Arr As New ArrayList()
            Dim i As Integer

            For Each foundFile As String In My.Computer.FileSystem.GetFiles(
                    Ruta, FileIO.SearchOption.SearchAllSubDirectories, "*.xml")
                Arr.Add(foundFile)
            Next
            For i = 0 To Arr.Count - 1
                Dim F As New Facturas
                Dim Guardar As Boolean = True
                If Arr.Item(i).Contains(".xml") Then
                    _XML = Arr.Item(i)
                    _PDF = _XML.Replace("xml", "pdf")
                    Using reader As New XmlTextReader(_XML)
                        param_XML = New SqlXml(reader)
                    End Using
                    Dim path As String = _XML
                    Dim fs As FileStream = File.Create(path)

                    ' Add text to the file.
                    Dim info As Byte() = New UTF8Encoding(True).GetBytes(_XML)
                    fs.Write(info, 0, info.Length)
                    fs.Close()
                    Dim PDF_File As New clsCFDIx.clsFormatoImpresion
                    Dim NombreArchivo As String = "C:\SiFact\Facturas\" & _XML & ".xml"
                    Try
                        PDF_File.LlenaFormatoCfdiFactura(NombreArchivo, "", True, clsFormatoImpresion.eNavegador.iexplore,
                                                                         NombreArchivo.Replace(".xml", ".html"))
                    Catch ex As System.NotSupportedException
                        MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End Try




                End If
            Next
            MessageBox.Show("Se guardaron " & Arr.Count & " registros", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Ha ocurrido un error al intentar abrir la ruta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub
End Class