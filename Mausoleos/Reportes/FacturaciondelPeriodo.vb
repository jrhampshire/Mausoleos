Imports System
Imports clsCFDIx.CFDx
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Globalization
Imports System.Xml
Imports System.Xml.Schema
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Net.Mail
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates




Public Class FacturaciondelPeriodo
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
    Dim clEmpresa As New ClassEmpresa
    Dim clCliente As New Cliente
    Dim clPersona As New Persona
    Dim Cliente_Actual As Integer = 0
    Dim Emisor As Integer = 0
    Dim xdoc As XmlDocument = Nothing
    Dim x509_2 As X509Certificate2 = Nothing
    Dim RFC As String = Nothing
    Dim UUID As String = Nothing
    Dim Timbrado_Usr As String = Nothing
    Dim Timbrado_Pwd As String = Nothing
    Dim xmlFile As String = IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "CFDv32 " & Today.ToString("yyyy-MMM-dd ss") & ".xml")
    Dim Gran_Subtotal As Double = 0
    Dim Gran_Total As Double = 0
    Dim Concepto_Recibo As String = Nothing
    Dim Recibo_Facturado As Boolean = False
    Dim Metodo_Pago As String = Nothing
    Dim Cuenta_Pago As String = Nothing
#End Region


    Function UltimoDiaMes(Fecha As Date) As Date
        UltimoDiaMes = DateSerial(Year(Fecha), Month(Fecha) + 1, 0)
    End Function
    Function PrimerDiaMes(Fecha As Date) As Date
        PrimerDiaMes = DateSerial(Year(Fecha), Month(Fecha), 1)
    End Function
    Private Sub FacturaciondelPeriodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Datos()
    End Sub
    Sub Carga_Datos()
        Try
            SQL_Str = "Select c.serie + '-' + c.folio as Factura,c.fecha as Fecha, R.Nombre as Cliente, r.rfc as RFC, c.total as Total from" &
                " Comprobante as c, Receptor as R" &
                " where c.Id_Receptor  =r.ID_Receptor" &
                " and c.fecha between @fecha1 and @fecha2"
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Fecha1", Me.DateTimePicker_FechaInicio.Value)
            Cmd.Parameters.AddWithValue("@Fecha2", Me.DateTimePicker_FechaFin.Value)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            DataGridView1.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

    End Sub
    Private Sub Button_Salir_Click(sender As Object, e As EventArgs) Handles Button_Salir.Click
        Me.Close()
    End Sub
    Private Sub Button_Genera_Reporte_Click(sender As Object, e As EventArgs) Handles Button_Genera_Reporte.Click
        Carga_Datos()
    End Sub
    Sub Carga_Empresa()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            SQL_Str = "SELECT Empresa.Id_Emisor, Empresa.Servidor_SMTP, Empresa.Puerto_SMTP, Empresa.Pwd_Email, Empresa.Logotipo, Empresa.Email, Empresa.Pwd_Llave_Privada, Empresa.Llave_Privada, Empresa.Certificado, " &
            "Empresa.Timbrado_Usr, Empresa.Timbrado_Pwd, Empresa.Folios, Emisor.rfc, Emisor.nombre, DomicilioFiscal.Calle, DomicilioFiscal.noExterior, " &
            "DomicilioFiscal.noInterior, DomicilioFiscal.colonia, DomicilioFiscal.codigoPostal, Localidad.Localidad, Municipio.Municipio, Estado.Estado, " &
            "Paises.Pais FROM Empresa INNER JOIN " &
            "Emisor ON Empresa.Id_Emisor = Emisor.ID_Emisor INNER JOIN " &
            "DomicilioFiscal ON Emisor.Id_DomicilioFiscal = DomicilioFiscal.ID_DomicilioFiscal INNER JOIN " &
            "Localidad ON DomicilioFiscal.Id_localidad = Localidad.ID_Localidad INNER JOIN " &
            "Municipio ON Localidad.Id_Municipio = Municipio.ID_Municipio INNER JOIN " &
            "Estado ON Municipio.Id_Estado = Estado.ID_Estado INNER JOIN " &
            "Paises ON Estado.Id_Paises = Paises.ID_Paises"


            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If DR.HasRows Then
                    While DR.Read
                        With clEmpresa
                            .Logotipo = DR.Item("Logotipo")
                            .Razon_Social = DR.Item("nombre")
                            .RFC = DR.Item("rfc")
                            .Calle = DR.Item("calle")
                            .noExterior = DR.Item("noExterior")
                            .localidad = DR.Item("Localidad")
                            .municipio = DR.Item("Municipio")
                            .estado = DR.Item("Estado")
                            .pais = DR.Item("Pais")
                            .codigoPostal = DR.Item("codigoPostal")
                            .Pwd = DR.Item("PWD_Llave_Privada")
                            .Ruta_Llave = DR.Item("Llave_Privada")
                            .Ruta_Certificado = DR.Item("Certificado")
                            Emisor = DR.Item("Id_Emisor")
                            .Servidor_SMTP = DR.Item("Servidor_SMTP")
                            .Puerto_SMTP = DR.Item("Puerto_SMTP")
                            .Pwd_Email = DR.Item("Pwd_Email")
                            'Timbrado_Usr = DR.Item("Timbrado_Usr")
                            'Timbrado_Pwd = DR.Item("Timbrado_Pwd")
                            'Timbrado_Usr = "0000000001"
                            'Timbrado_Pwd = "pwd"
                        End With
                    End While
                End If
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
            SQL_Str = "Select * from RegimenFiscal where id_RegimenFiscal in (Select id_RegimenFiscal from RegimenXEmisor where id_Emisor = @Id_Emisor)"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Id_Emisor", Emisor)
                Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If DR.HasRows Then
                    While DR.Read
                        With clEmpresa
                            If .Regimen = "" Then
                                .Regimen = DR.Item("Regimen")
                            Else
                                .Regimen = .Regimen + ", " + DR.Item("Regimen")
                            End If
                        End With
                    End While
                End If
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End Using
    End Sub
#Region "Factura"
    Sub Carga_Datos_Factura(ByVal Factura As String)

    End Sub
#End Region

#Region "Datos Cliente"
    Sub Carga_Datos_Cliente(ByVal Factura As String)

        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            SQL_Str = "SELECT Receptor.nombre, Receptor.rfc, Domicilio.calle, Domicilio.noExterior," &
                " Domicilio.noInterior, Domicilio.colonia, Localidad.Localidad, Municipio.Municipio, " &
                " Estado.Estado, Paises.Pais, Domicilio.referencia, Domicilio.codigoPostal, Personas.Tel_Particular, Personas.email, Personas.Observaciones " &
                " FROM Receptor INNER JOIN" &
                " Domicilio ON Receptor.Id_Domicilio = Domicilio.ID_Domicilio INNER JOIN" &
                " Personas ON Receptor.ID_Receptor = Personas.Id_Receptor INNER JOIN" &
                " Localidad ON Domicilio.Id_localidad = Localidad.ID_Localidad INNER JOIN" &
                " Municipio ON Localidad.Id_Municipio = Municipio.ID_Municipio INNER JOIN" &
                " Estado ON Municipio.Id_Estado = Estado.ID_Estado INNER JOIN" &
                " Paises ON Estado.Id_Paises = Paises.ID_Paises" &
                " WHERE Receptor.Id_Receptor = @Cliente_Actual ORDER BY Receptor.nombre"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Cliente_Actual", clCliente.Id_Receptor)
                Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If DR.HasRows Then
                    While DR.Read
                        With clCliente
                            .Razon_Social = DR.Item("nombre")
                            .RFC = DR.Item("rfc")
                            .Calle = DR.Item("calle")
                            .noExterior = DR.Item("noExterior")
                            .noInterior = DR.Item("noInterior")
                            .colonia = DR.Item("colonia")
                            .Descrp_Localidad = DR.Item("Localidad")
                            .municipio = DR.Item("Municipio")
                            .estado = DR.Item("Estado")
                            .pais = DR.Item("Pais")
                            .referencia = DR.Item("referencia")
                            .codigoPostal = DR.Item("codigoPostal")
                            .Telefono = DR.Item("Tel_Particular")
                            .email = DR.Item("email")
                            .Observaciones = DR.Item("Observaciones")
                        End With
                    End While
                End If
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try

        End Using
    End Sub
#End Region
    Private Sub Button_ExportaExcell_Click(sender As Object, e As EventArgs) Handles Button_ExportaExcell.Click

        Dim DireccionImagenLogo As String = Nothing
        Try
            Cx.Open()
            SQL_Str = "Select * from Empresa"
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    DireccionImagenLogo = DR.Item("Logotipo")
                End While
            End If
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
        Dim app As Object
        Dim xlbook As Object
        Dim xlsheet As Object
        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim thisThread As System.Threading.Thread = System.Threading.Thread.CurrentThread
        Dim originalCulture As System.Globalization.CultureInfo = thisThread.CurrentCulture
        Try
            app = CreateObject("Excel.Application")
            xlbook = app.Workbooks.Add()
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            xlsheet = xlbook.ActiveSheet
            Dim range As Excel.Range
            ' Crea una nueva Instancia o Excel y un nuevo workbook.
            thisThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            If File.Exists(DireccionImagenLogo) Then
                xlsheet.Shapes.AddPicture(DireccionImagenLogo, CType(False, Microsoft.Office.Core.MsoTriState), CType(True, Microsoft.Office.Core.MsoTriState), 5, 5, 130, 55)
            End If
            xlsheet.Range("A1").EntireRow.RowHeight = 65
            xlsheet.Cells(1, 5).Formula = Now
            'xlsheet.Range("A7").VerticalAlignment = Excel.XlVAlign.xlVAlignTop
            'xlsheet.Range("A7").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            xlsheet.Range("A2").Font.Bold = True
            xlsheet.Range("A2").Font.Size = 18
            xlsheet.Range("A2").Interior.ColorIndex = 16
            xlsheet.Range("A2").Value = "Facturación del Periodo"
            xlsheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            xlsheet.Range("A2:E3").Merge()
            xlsheet.Range("A2:E3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )

            xlsheet.Range("A4").Font.Bold = True
            xlsheet.Range("A4").Font.Size = 12
            xlsheet.Range("A4").Value = "Periodo:"
            xlsheet.Range("A5").Font.Bold = False
            xlsheet.Range("A5").Font.Size = 12
            Dim Fecha1 As DateTime = Me.DateTimePicker_FechaInicio.Value
            Dim Fecha1Txt As String = Nothing

            Fecha1Txt = Fecha1.ToString("d", CultureInfo.CreateSpecificCulture("es-MX"))
            Dim Fecha2 As DateTime = Me.DateTimePicker_FechaFin.Value
            Dim Fecha2Txt As String = Nothing
            Fecha2Txt = Fecha2.ToString("d", CultureInfo.CreateSpecificCulture("es-MX"))
            xlsheet.Range("A5").Value = Fecha1Txt & " a " & Fecha2Txt

            xlsheet.Cells(7, 1).Formula = "Factura"
            xlsheet.Cells(7, 2).Formula = "Fecha de Facturación"
            xlsheet.Cells(7, 3).Formula = "Cliente"
            xlsheet.Cells(7, 4).Formula = "RFC"
            xlsheet.Cells(7, 5).Formula = "Total Facturado"
            xlsheet.Range("A7:E7").Font.Bold = True
            xlsheet.Range("A7:E7").Interior.ColorIndex = 16
            xlsheet.Range("A7:E7").Font.Size = 11
            xlsheet.Range("A7:E7").Borders().Color = 0
            xlsheet.Range("A7:E7").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            xlsheet.Range("A7:E7").Borders().Weight = 2
            xlsheet.Range("A7:E7").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Dim R As String = "A7:A" + CInt(DataGridView1.RowCount + 5).ToString
            xlsheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("B1").EntireColumn.ColumnWidth = 20
            xlsheet.Range("C1").EntireColumn.ColumnWidth = 35
            xlsheet.Range("D1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("E1").EntireColumn.ColumnWidth = 15


            'Aqui obtengo el tamaño del datagrid y lo copio al excel
            Dim DGRows As Integer = Me.DataGridView1.RowCount
            Dim DGCols As Integer = Me.DataGridView1.ColumnCount
            range = xlsheet.Range("A8", Reflection.Missing.Value)
            range = range.Resize(DGRows, DGCols)
            range.Borders().Color = 0
            range.Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders().Weight = 2
            range.Font.Size = 9
            'Crea un array
            Dim saRet(DGRows, DGCols) As String
            'llena el array.
            Dim iRow As Integer
            Dim iCol As Integer
            For iRow = 0 To DataGridView1.RowCount - 1
                For iCol = 0 To DataGridView1.ColumnCount - 1
                    saRet(iRow, iCol) = DataGridView1.Rows(iRow).Cells(iCol).Value.ToString
                Next iCol
            Next iRow
            'establece el valor del rango del array.
            range.Value = saRet
            'Regresa el control del Excel al usuario y Limpia
            range = Nothing
            app.Visible = True
            app.UserControl = True
            releaseobject(app)
            releaseobject(xlbook)
            releaseobject(xlsheet)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            thisThread.CurrentCulture = originalCulture
        End Try

    End Sub
    Sub releaseobject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim columna As Integer, fila As Integer
        Dim Factura As String = Nothing
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Try
            Factura = Trim(Me.DataGridView1(columna, fila).Value)
            If Factura = "" Then
                MessageBox.Show("Debe seleccionar una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView1.Focus()
                Exit Sub
            Else
                'Primero Busca el archivo PDF 
                If File.Exists(RutaSrv + "\Facturas\CFDI_" & Factura & "_TIMBRADO.pdf") Then
                    Dim loPSI As New ProcessStartInfo
                    Dim loProceso As New Process
                    loPSI.FileName = RutaSrv + "\Facturas\CFDI_" & Factura & "_TIMBRADO.pdf"
                    Try
                        loProceso = Process.Start(loPSI)
                    Catch Exp As Exception
                        MessageBox.Show(Exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try

                    'En el caso de que no encuentre el PDF busca el html para intentar generar de nuevo el PDF
                ElseIf File.Exists(RutaSrv + "\Facturas\CFDI_" & Factura & "_TIMBRADO.html") Then

                    GuardaFormatoPDF(RutaSrv + "\Facturas\CFDI_" & Factura & "_TIMBRADO.html")
                    Dim result As System.IO.WaitForChangedResult
                    Dim watcher As New System.IO.FileSystemWatcher(RutaSrv + "\Facturas\")
                    result = watcher.WaitForChanged(System.IO.WatcherChangeTypes.Created)
                    Dim loPSI As New ProcessStartInfo
                    Dim loProceso As New Process
                    loPSI.FileName = RutaSrv + "\Facturas\CFDI_" & Factura & "_TIMBRADO.pdf"
                    Try
                        loProceso = Process.Start(loPSI)
                    Catch Exp As Exception
                        MessageBox.Show(Exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try

                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    'En caso de que no encuentre el PDF lo Genero de nuevo
                    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////



                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView1.Focus()
            Exit Sub
        End Try

    End Sub
    'Private Sub Facturar(ByVal Factura As String)
    '    Dim CERT_SIS As String = clEmpresa.Ruta_Certificado
    '    Dim CerNo As String
    '    Dim CerSAT As System.Security.Cryptography.X509Certificates.X509Certificate
    '    CerSAT = System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromCertFile(CERT_SIS)
    '    CerNo = StrReverse(System.Text.Encoding.ASCII.GetString(CerSAT.GetSerialNumber))
    '    Dim Fecha As String = DateTime.Now.ToString("yyyyMMddThhmmss").ToString
    '    Dim Folio_Actual As Integer = 0
    '    Dim _TipoDeCambio As String = Nothing
    '    _TipoDeCambio = ""
    '    Dim _Descuento As Decimal = 0
    '    Dim _motivoDescuento As String = ""
    '    Dim _FolioFiscalOriginal As String = ""
    '    Dim _SerieFolioFiscalOrig As String = ""
    '    Dim _FechaFolioFiscalOrig As Date = Nothing
    '    Dim _Aduana As String = Nothing
    '    Dim _FechaAduana As DateTime = Nothing
    '    Dim _AduanaPedimento As String = Nothing
    '    Dim Id_Conceptos As Integer = 63
    '    Dim Id_Concepto As Integer = 0
    '    Dim Guardar_Folio As Boolean = False
    '    Dim Serie As String = Nothing
    '    Dim Id_Comprobante As Integer = 0
    '    Dim Credito As Integer = 0
    '    Dim Condiciones_Pago As String = "Contado"
    '    Dim Fecha_Factura As DateTime

    '    If Condiciones_Pago = "Contado" Then
    '        Condiciones_Pago = "Contado"
    '    End If
    '    If Credito > 0 Then
    '        Condiciones_Pago = "Credito " & Credito & " dias"
    '    End If
    '    Using Cx As New SqlConnection(CxSettings.ConnectionString)
    '        SQL_Str = "Select * From Datos_Factura"
    '        Try
    '            Cx.Open()
    '            Dim Cmd As New SqlCommand(SQL_Str, Cx)
    '            Cmd.CommandType = CommandType.StoredProcedure
    '            Cmd.Parameters.AddWithValue("@Factura", Factura)
    '            Dim DR1 As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
    '            If DR1.HasRows Then
    '                While DR1.Read
    '                    With clCliente
    '                        .Razon_Social = DR1.Item("nombre")
    '                        .RFC = DR1.Item("rfc")
    '                        .Calle = DR1.Item("calle")
    '                        .noExterior = DR1.Item("noExterior")
    '                        .noInterior = DR1.Item("noInterior")
    '                        .colonia = DR1.Item("colonia")
    '                        .Descrp_Localidad = DR1.Item("Localidad")
    '                        .municipio = DR1.Item("Municipio")
    '                        .estado = DR1.Item("Estado")
    '                        .pais = DR1.Item("Pais")
    '                        .referencia = DR1.Item("referencia")
    '                        .codigoPostal = DR1.Item("codigoPostal")
    '                        .Telefono = DR1.Item("Tel_Particular")
    '                        .email = DR1.Item("email")
    '                        .Observaciones = DR1.Item("Observaciones")
    '                    End With
    '                    Folio_Actual = DR1.Item("folio")
    '                    Gran_Total = DR1.Item("total")
    '                    Gran_Subtotal = Gran_Total / 1.16
    '                    Fecha_Factura = DR1.Item("fecha")
    '                    Condiciones_Pago = DR1.Item("condicionesDePago")
    '                    Metodo_Pago = DR1.Item("metodoDePago")
    '                    _TipoDeCambio = DR1.Item("TipoCambio")
    '                    _Descuento = DR1.Item("descuento")
    '                    _motivoDescuento = DR1.Item("motivoDescuento")
    '                    Cuenta_Pago = DR1.Item("NumCtaPago")
    '                    _Fol
    '                End While
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    End Using
    '    '//////////////////////////////////////////////////////////////////////
    '    '**********************************************************************
    '    'Aqui se crea el CFDI
    '    '**********************************************************************
    '    '//////////////////////////////////////////////////////////////////////
    '    Dim CFDs As New clsCFDIx.CFDx

    '    With CFDs
    '        .Comprobante(VersionCFD.CFDv3_2, Folio_Actual, FormatDateTime(Now, DateFormat.GeneralDate), Condiciones_Pago _
    '                      , Gran_Subtotal, Gran_Total, clsCFDIx.ComprobanteTipoDeComprobante.ingreso, Metodo_Pago _
    '                      , clEmpresa.pais, "A", _TipoDeCambio, Condiciones_Pago, _Descuento, _motivoDescuento, "M.N." _
    '                      , Cuenta_Pago, _FolioFiscalOriginal, _SerieFolioFiscalOrig, _FechaFolioFiscalOrig)
    '        .AgregaEmisor(clEmpresa.RFC, clEmpresa.Calle, clEmpresa.municipio, clEmpresa.estado, clEmpresa.pais, clEmpresa.codigoPostal,
    '                      clEmpresa.Razon_Social, clEmpresa.noExterior, clEmpresa.noInterior, clEmpresa.colonia, clEmpresa.Descrp_Localidad, clEmpresa.referencia)
    '        .AgregaReceptor(clCliente.RFC, clCliente.Razon_Social, clCliente.Calle, clCliente.municipio, clCliente.estado, clCliente.pais, clCliente.codigoPostal,
    '                        clCliente.noExterior, clCliente.noInterior, clCliente.colonia, clCliente.Descrp_Localidad, clCliente.referencia)
    '        .AgregaRegimenFiscal(clEmpresa.Regimen)
    '        Dim Registros1 As Integer = 1
    '        For i = 0 To Registros1 - 1
    '            Dim _Cantidad As Decimal = 0
    '            Dim _Descripcion As String = Nothing

    '            Dim _Clave As String = Nothing
    '            Dim _Unidad As String = Nothing
    '            Dim _valorUnitario As Decimal = 0
    '            Dim fila As Integer
    '            fila = i
    '            _Cantidad = 1
    '            _Descripcion = "Pago por derecho de uso de nicho del contrato No " & Cont.Contrato
    '            _Clave = "PMC-01"
    '            _Unidad = "N/A"
    '            _valorUnitario = Gran_Total

    '            .AgregaConcepto(_Cantidad, _Unidad, _Descripcion, _valorUnitario, _Clave)
    '        Next

    '        .AgregaComprobanteImpuestoTraslado(clsCFDIx.ComprobanteImpuestosTrasladoImpuesto.IVA, (1.16 - 1) * 100, Gran_Subtotal * (1.16 - 1))
    '    End With
    '    Dim CertFile As String = clEmpresa.Ruta_Certificado
    '    Dim KeyFile As String = clEmpresa.Ruta_Llave
    '    Dim KeyPass As String = clEmpresa.Pwd
    '    Dim Errores As String = ""
    '    Dim _NombreArchivo As String = RutaSrv + "\Facturas\CFDI_A-" & Folio_Actual.ToString & ".xml"

    '    If CFDs.CreaFacturaXML(KeyFile, KeyPass, CertFile, Errores, _NombreArchivo, , eComplemento.Comprobante) = False Then
    '        MsgBox("Se encontraron los siguientes Errores:" & vbNewLine & Errores, MsgBoxStyle.Exclamation)
    '    Else
    '        Dim _error, _user, _pass, _uri As String
    '        _error = ""
    '        _user = Timbrado_Usr
    '        _pass = Timbrado_Pwd
    '        _uri = "https://cfdi.timbrado.com.mx/cfdi/wstimbrado.asmx"
    '        CFDs.TimbrarCFDI(_NombreArchivo, ePAC.ATEB, _user, _pass, _error, _uri)

    '        If _error <> "" Then
    '            MsgBox(_error)
    '            Exit Sub
    '        Else
    '            Guardar_Folio = True
    '            Recibo_Facturado = True
    '        End If

    '    End If

    '    If Guardar_Folio = True Then
    '        Dim PDF_File As New clsCFDIx.clsFormatoImpresion
    '        PDF_File.LlenaFormatoCfdiFactura(_NombreArchivo, clEmpresa.Logotipo, True, clsCFDIx.clsFormatoImpresion.eNavegador.iexplore,
    '                                         _NombreArchivo.Replace(".xml", ".html"))

    '        MsgBox("Su Factura ha sido Generada", MsgBoxStyle.Information)
    '    End If
    '    Me.Close()

    'End Sub
    Public Sub GuardaFormatoPDF(ByRef _htm As String)
        Dim proc As New ProcessStartInfo("HtmlToPDF\wkhtmltopdf.exe")

        proc.Arguments = _htm + " " + _htm.Replace(".html", ".pdf")
        proc.WindowStyle = ProcessWindowStyle.Hidden

        Process.Start(proc)
    End Sub
    Private Sub ToolStripButton_Cancela_Fact_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Cancela_Fact.Click
        Dim columna As Integer, fila As Integer
        Dim Factura As String = Nothing
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Try
            Factura = Trim(Me.DataGridView1(columna, fila).Value)
            If Factura = "" Then
                MessageBox.Show("Debe seleccionar una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView1.Focus()
                Exit Sub
            Else
                If isOnline() = False Then
                    MessageBox.Show("Para cancelar una factura se requiere una conexion a internet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                Else
                    Cancela_Factura()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error al intentar cancelar la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView1.Focus()
            Exit Sub
        End Try
    End Sub
    Sub Cancela_Factura()
        Dim columna As Integer, fila As Integer
        Dim Factura As String = Nothing

        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Try
            Factura = Trim(Me.DataGridView1(columna, fila).Value)
            If Factura = "" Then
                MessageBox.Show("Debe seleccionar una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView1.Focus()
                Exit Sub
            Else
                xdoc = New XmlDocument()
                Dim xCan As XmlElement = xdoc.CreateElement("", "Cancelacion", "http://cancelacfd.sat.gob.mx")
                Dim xAttr As XmlAttribute = xdoc.CreateAttribute("xmlns", "xsd", "http://www.w3.org/2000/xmlns/")
                xAttr.InnerText = "http://www.w3.org/2001/XMLSchema"
                xCan.Attributes.Append(xAttr)
                xAttr = xdoc.CreateAttribute("xmlns", "xsi", "http://www.w3.org/2000/xmlns/")
                xAttr.InnerText = "http://www.w3.org/2001/XMLSchema-instance"
                xCan.Attributes.Append(xAttr)
                xAttr = xdoc.CreateAttribute("RfcEmisor")
                xAttr.Value = RFC
                xCan.Attributes.Append(xAttr)
                xAttr = xdoc.CreateAttribute("Fecha")
                xAttr.Value = DateTime.Now.ToString("s")
                xCan.Attributes.Append(xAttr)

                Dim xFolios As XmlElement = xdoc.CreateElement("Folios", "http://cancelacfd.sat.gob.mx")
                Dim xUuid As XmlElement = xdoc.CreateElement("UUID", "http://cancelacfd.sat.gob.mx")
                xUuid.InnerText = UUID
                xFolios.AppendChild(xUuid)
                xCan.AppendChild(xFolios)

                xdoc.AppendChild(xdoc.CreateXmlDeclaration("1.0", "", ""))
                xdoc.AppendChild(xCan)
                Try
                    'Create a UnicodeEncoder to convert between byte array and string.
                    Dim ByteConverter As New UnicodeEncoding()

                    'Create byte arrays to hold original, encrypted, and decrypted data.
                    Dim dataToEncrypt As Byte() = ByteConverter.GetBytes("Data to Encrypt")
                    Dim encryptedData() As Byte

                    'Create a new instance of RSACryptoServiceProvider to generate
                    'public and private key data.
                    Using RSA As New RSACryptoServiceProvider

                        'Pass the data to ENCRYPT, the public key information 
                        '(using RSACryptoServiceProvider.ExportParameters(false),
                        'and a boolean flag specifying no OAEP padding.
                        encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(False), False)

                    End Using
                Catch e As ArgumentNullException
                    'Catch this exception in case the encryption did
                    'not succeed.
                    Console.WriteLine("Encryption failed.")
                End Try

            End If
        Catch ex As Exception
            MessageBox.Show("Error al intentar cancelar la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView1.Focus()
            Exit Sub
        End Try




    End Sub

    Public Shared Function RSAEncrypt(ByVal DataToEncrypt() As Byte, ByVal RSAKeyInfo As RSAParameters, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            Dim encryptedData() As Byte
            'Create a new instance of RSACryptoServiceProvider.
            Using RSA As New RSACryptoServiceProvider

                'Import the RSA Key information. This only needs
                'toinclude the public key information.
                RSA.ImportParameters(RSAKeyInfo)

                'Encrypt the passed byte array and specify OAEP padding.  
                'OAEP padding is only available on Microsoft Windows XP or
                'later.  
                encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding)
            End Using
            Return encryptedData
            'Catch and display a CryptographicException  
            'to the console.
        Catch e As CryptographicException
            Console.WriteLine(e.Message)

            Return Nothing
        End Try
    End Function
    Public Shared Function RSADecrypt(ByVal DataToDecrypt() As Byte, ByVal RSAKeyInfo As RSAParameters, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            Dim decryptedData() As Byte
            'Create a new instance of RSACryptoServiceProvider.
            Using RSA As New RSACryptoServiceProvider
                'Import the RSA Key information. This needs
                'to include the private key information.
                RSA.ImportParameters(RSAKeyInfo)

                'Decrypt the passed byte array and specify OAEP padding.  
                'OAEP padding is only available on Microsoft Windows XP or
                'later.  
                decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding)
                'Catch and display a CryptographicException  
                'to the console.
            End Using
            Return decryptedData
        Catch e As CryptographicException
            Console.WriteLine(e.ToString())

            Return Nothing
        End Try
    End Function
    Public Function isOnline() As Boolean
        Dim Url As New System.Uri("http://www.google.com")
        Dim oWebReq As System.Net.WebRequest
        oWebReq = System.Net.WebRequest.Create(Url)
        Dim oResp As System.Net.WebResponse = Nothing
        Try
            oResp = oWebReq.GetResponse
            oResp.Close()
            oWebReq = Nothing
            Return True
        Catch ex As Exception
            oResp = Nothing
            oWebReq = Nothing
            Return False
        End Try
    End Function
    Public Sub SignXml(xmlDoc As XmlDocument, Key As RSA)
        ' Check arguments.
        If xmlDoc Is Nothing Then
            Throw New ArgumentException("xmlDoc")
        End If
        If Key Is Nothing Then
            Throw New ArgumentException("Key")
        End If
        ' Create a SignedXml object.
        Dim signedXml As New SignedXml(xmlDoc)
        ' Add the key to the SignedXml document.
        signedXml.SigningKey = Key
        ' Create a reference to be signed.
        Dim reference As New Reference()
        reference.Uri = ""
        ' Add an enveloped transformation to the reference.
        Dim env As New XmlDsigEnvelopedSignatureTransform()
        reference.AddTransform(env)
        ' Add the reference to the SignedXml object.
        signedXml.AddReference(reference)
        Dim ki As New KeyInfo()
        Dim clause As New KeyInfoX509Data()
        clause.AddCertificate(x509_2)
        clause.AddIssuerSerial(x509_2.Issuer, x509_2.GetSerialNumberString())
        ki.AddClause(clause)
        signedXml.KeyInfo = ki
        ' Compute the signature.
        signedXml.ComputeSignature()
        ' Get the XML representation of the signature and save
        ' it to an XmlElement object.
        Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()
        'xmlDoc.Save("antes_firma.xml");
        ' Append the element to the XML document.
        xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, True))
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
            smtpMail.Send(oMsg)
            smtpMail.Port = PuertoSmtp
            smtpMail.EnableSsl = True

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
    Private Sub Button_EMail_Click(sender As Object, e As EventArgs) Handles Button_EMail.Click
        Dim columna As Integer, fila As Integer
        Dim Factura As String = Nothing
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Try
            Factura = Trim(Me.DataGridView1(columna, fila).Value)
            If Factura = "" Then
                MessageBox.Show("Debe seleccionar una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView1.Focus()
                Exit Sub
            Else
                'Carga la informacion de envio de Correos
                'Datos de la empresa y del cliente 
                SQL_Str = "Select email from Personas Where Id_Receptor = (Select Id_Receptor from Comprobante where  (c.serie + '-' + c.folio)= @Factura)"
                Dim CorreoE As String = Nothing
                Try
                    Cx.Open()
                    Dim cmd As New SqlCommand(SQL_Str, Cx)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@Factura", Factura)
                    Dim Reader As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With Reader
                        If .HasRows Then
                            While .Read
                                CorreoE = .Item("email")
                            End While
                        End If
                    End With
                Catch ex As SqlException
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try

                Dim _NombreArchivo As String
                _NombreArchivo = Factura & "_TIMBRADO"
                Carga_Empresa()
                'Carga_Clientes()
                Dim txtHTML As String
                txtHTML = "<!DOCTYPE html><html lang=" & Chr(34) & "es" & Chr(34) & " ><head><meta charset=" & Chr(34) & "utf-8" & Chr(34) & " /><title>Correo CFDI</title><style type=" & Chr(34) & "text/css" & Chr(34) & ">" &
                    " body {font-family: Arial; font-size: 12px; line-height: 110%; margin: 0px; padding: 0px; width: 1080px; } " &
                    " #encabezado {margin-top: 0px;} " &
                    " #logo, #datos-emisor{display: inline-block; margin: 10px; vertical-align: top; } " &
                    " #datos-emisor { width: 43%; line-height: 70%; text-align: center; }" &
                    " </style></head><body><header id=" & Chr(34) & "encabezado" & Chr(34) & "><section id=" & Chr(34) & "logo" & Chr(34) & "> " &
                    " <img src=" & Chr(34) & "cid:Pic1" & Chr(34) & " title=" & Chr(34) & "Logo de la Empresa" & Chr(34) & " height=" & Chr(34) & "160" & Chr(34) & " width=" & Chr(34) & "180" & Chr(34) & " /> " &
                    " </section><section id=" & Chr(34) & "datos-emisor" & Chr(34) & "><h4>" & clEmpresa.Razon_Social & "</h4><h5>" & clEmpresa.RFC & "</h5><p>" & clEmpresa.Calle & " No " & clEmpresa.noExterior & "</p> </section></body>"

                Dim ArchivosAdjuntos As New List(Of String)()
                ArchivosAdjuntos.Add(RutaSrv + "\Facturas\CFDI_" & _NombreArchivo & ".pdf")
                ArchivosAdjuntos.Add(RutaSrv + "\Facturas\CFDI_" & _NombreArchivo & ".xml")
                'MsgBox("Su Factura ha sido Generada y sera enviada", MsgBoxStyle.Information)
                enviarCorreoE(clEmpresa.email, CorreoE, "A recibido un nuevo CFDI de " &
                              clEmpresa.Razon_Social, txtHTML,
                              ArchivosAdjuntos, clEmpresa.Servidor_SMTP, clEmpresa.Puerto_SMTP, True)


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class