Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Globalization

Public Class Pagos_Recibidos
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
    Dim clEmpresa As New ClassEmpresa

#End Region


    Function UltimoDiaMes(Fecha As Date) As Date
        UltimoDiaMes = DateSerial(Year(Fecha), Month(Fecha) + 1, 0)
    End Function
    Function PrimerDiaMes(Fecha As Date) As Date
        PrimerDiaMes = DateSerial(Year(Fecha), Month(Fecha), 1)
    End Function
    Sub Carga_Datos()
        Try
            SQL_Str = "SELECT * FROM Funcion_RecibosPagados (@Fecha1 ,@Fecha2) NOLOCK"

            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.CommandTimeout = 600
            Dim Fecha1 As Date = Me.DateTimePicker_FechaInicio.Value
            Dim Fecha2 As Date = DateAdd(DateInterval.Day, 1, Me.DateTimePicker_FechaFin.Value)
            Cmd.Parameters.AddWithValue("@Fecha1", Fecha1)
            Cmd.Parameters.AddWithValue("@Fecha2", Fecha2)
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
        Dim Emisor As Integer = 0

        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            SQL_Str = "SELECT Empresa.Id_Emisor, Empresa.Logotipo, Empresa.Email, Empresa.Pwd_Llave_Privada, Empresa.Llave_Privada, Empresa.Certificado, " &
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
#Region "Excel"
    Private Sub Button_ExportaExcell_Click(sender As Object, e As EventArgs) Handles Button_ExportaExcell.Click
        With DataGridView1
            Dim Columnas As Integer = .ColumnCount
            If Columnas < 6 Then
                Excel2()
            Else
                Excel1()
            End If
        End With
    End Sub
    Sub Excel1()
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
            xlsheet.Cells(1, 7).Formula = Now
            'xlsheet.Range("A7").VerticalAlignment = Excel.XlVAlign.xlVAlignTop
            'xlsheet.Range("A7").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            xlsheet.Range("A2").Font.Bold = True
            xlsheet.Range("A2").Font.Size = 18
            xlsheet.Range("A2").Interior.ColorIndex = 16
            xlsheet.Range("A2").Value = "Pagos Recibidos"
            xlsheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            xlsheet.Range("A2:G3").Merge()
            xlsheet.Range("A2:G3").BorderAround(, Excel.XlBorderWeight.xlMedium,
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

            xlsheet.Cells(7, 1).Formula = "Recibo"
            xlsheet.Cells(7, 2).Formula = "Importe"
            xlsheet.Cells(7, 3).Formula = "Fecha de Pago"
            xlsheet.Cells(7, 4).Formula = "Estado"
            xlsheet.Cells(7, 5).Formula = "Concepto"
            xlsheet.Cells(7, 6).Formula = "Contrato"
            xlsheet.Cells(7, 7).Formula = "Cliente"
            Dim Rango_Titulos_Tabla As String = "A7:G7"
            xlsheet.Range(Rango_Titulos_Tabla).Font.Bold = True
            xlsheet.Range(Rango_Titulos_Tabla).Interior.ColorIndex = 16
            xlsheet.Range(Rango_Titulos_Tabla).Font.Size = 11
            xlsheet.Range(Rango_Titulos_Tabla).Borders().Color = 0
            xlsheet.Range(Rango_Titulos_Tabla).Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            xlsheet.Range(Rango_Titulos_Tabla).Borders().Weight = 2
            xlsheet.Range(Rango_Titulos_Tabla).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Dim R As String = "A7:A" + CInt(DataGridView1.RowCount + 5).ToString
            xlsheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A1").EntireColumn.ColumnWidth = 8
            xlsheet.Range("B1").EntireColumn.ColumnWidth = 8
            xlsheet.Range("C1").EntireColumn.ColumnWidth = 20
            xlsheet.Range("D1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("E1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("F1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("G1").EntireColumn.ColumnWidth = 35

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
    Sub Excel2()
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
            xlsheet.Range("A2").Value = "Acumulado de Pagos Recibidos"
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

            xlsheet.Cells(7, 1).Formula = "Contrato"
            xlsheet.Cells(7, 2).Formula = "Cliente"
            xlsheet.Cells(7, 3).Formula = "Saldo Inicial"
            xlsheet.Cells(7, 4).Formula = "Total Pagado"
            xlsheet.Cells(7, 5).Formula = "Saldo Actual"

            xlsheet.Range("A7:E7").Font.Bold = True
            xlsheet.Range("A7:E7").Interior.ColorIndex = 16
            xlsheet.Range("A7:E7").Font.Size = 11
            xlsheet.Range("A7:E7").Borders().Color = 0
            xlsheet.Range("A7:E7").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            xlsheet.Range("A7:E7").Borders().Weight = 2
            xlsheet.Range("A7:E7").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Dim R As String = "A7:A" + CInt(DataGridView1.RowCount + 5).ToString
            xlsheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A1").EntireColumn.ColumnWidth = 8
            xlsheet.Range("B1").EntireColumn.ColumnWidth = 40
            xlsheet.Range("C1").EntireColumn.ColumnWidth = 15
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
#End Region

    Sub releaseobject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub

    Private Sub Pagos_Recibidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Datos()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Carga_Datos2()
    End Sub
    Sub Carga_Datos2()
        Try

            SQL_Str = "AcumuladoPagos"
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandTimeout = 600
            Cmd.Parameters.AddWithValue("@Fecha1", Me.DateTimePicker_FechaInicio.Value)
            Cmd.Parameters.AddWithValue("@Fecha2", DateAdd(DateInterval.Day, 1, Me.DateTimePicker_FechaFin.Value))
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
End Class