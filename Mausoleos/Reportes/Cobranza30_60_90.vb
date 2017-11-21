Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Globalization

Public Class Cobranza30_60_90
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
    Sub Carga_Datos_Saldos()
        Try
            SQL_Str = "Declare @TablaTemp Table(Contrato int, Cliente nvarchar(MAX), Concepto nvarchar(MAX), Fecha datetime2, Importe decimal(18, 6), Id_Detalle_PlanPagos int)" &
                " Insert into @TablaTemp Select 0,' ',Detalle as Concepto, Fecha_Vencimiento as Fecha, Importe, id_Detalle_PlanPagos  from Detalle_PlanPagos" &
                " Where Fecha_Vencimiento < GETDATE() And" &
                " DateDiff(Month, Fecha_Vencimiento, getdate()) > 0 " &
                " AND Id_Detalle_PlanPagos not in (Select Id_Detalle_PlanPagos from Detalle_Recibos where Id_Recibo in(Select Id_Recibo  from Recibos Where Estado_Actual in ('Recibo Pagado','Recibo Facturado')))" &
                " Declare @Id int" &
                " Declare Id Cursor Read_Only for Select Id_Detalle_PlanPagos from @TablaTemp" &
                " Open Id" &
                " Fetch Next from Id into @ID" &
                " While @@FETCH_STATUS = 0" &
                " Begin" &
                " Update @TablaTemp Set Contrato = (Select Id_Contrato from PlanPagos where Id_PlanPagos = (Select Id_PlanPagos from Detalle_PlanPagos Where Id_Detalle_PlanPagos = @Id))," &
                " Cliente = (Select Nombre from Personas Where ID_Personas = (Select Id_Cliente from Contratos Where Id_Contrato =(Select Id_Contrato from PlanPagos where Id_PlanPagos = (Select Id_PlanPagos from Detalle_PlanPagos Where Id_Detalle_PlanPagos = @Id))))" &
                " Where Id_Detalle_PlanPagos = @Id" &
                " Fetch Next From ID INTO @id" &
                " End" &
                " Close id" &
                " Deallocate id" &
                " Select Contrato, Cliente, Concepto, Fecha, Importe from @TablaTemp Where Contrato not in (Select Id_Contrato from Contratos where Cancelado = 'True')" &
                " Order by Contrato"
            Cx.Open()
            Dim DS As New DataSet
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            DA.Fill(DS, "Tabla4")
            DataGridView4.DataSource = DS.Tables("Tabla4")
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
    Sub Carga_Datos()
        Try
            SQL_Str = "Declare @TablaTemp Table(Contrato int, Cliente nvarchar(MAX), Concepto nvarchar(MAX), Fecha datetime2, Importe decimal(18, 6), Id_Detalle_PlanPagos int)" &
                " Insert into @TablaTemp Select 0,' ',Detalle as Concepto, Fecha_Vencimiento as Fecha, Importe, id_Detalle_PlanPagos  from Detalle_PlanPagos" &
                " Where Fecha_Vencimiento > GETDATE() And" &
                " DateDiff(Day, dateadd(Day,0,getdate()), Fecha_Vencimiento) > 0 " &
                " AND DATEDIFF(Day,dateadd(Day,0,getdate()), Fecha_Vencimiento) <= 30" &
                " AND Id_Detalle_PlanPagos not in (Select Id_Detalle_PlanPagos from Detalle_Recibos where Id_Recibo in(Select Id_Recibo  from Recibos Where Estado_Actual in ('Recibo Pagado','Recibo Facturado')))" &
                " Declare @Id int" &
                " Declare Id Cursor Read_Only for Select Id_Detalle_PlanPagos from @TablaTemp" &
                " Open Id" &
                " Fetch Next from Id into @ID" &
                " While @@FETCH_STATUS = 0" &
                " Begin" &
                " Update @TablaTemp Set Contrato = (Select Id_Contrato from PlanPagos where Id_PlanPagos = (Select Id_PlanPagos from Detalle_PlanPagos Where Id_Detalle_PlanPagos = @Id))," &
                " Cliente = (Select Nombre from Personas Where ID_Personas = (Select Id_Cliente from Contratos Where Id_Contrato =(Select Id_Contrato from PlanPagos where Id_PlanPagos = (Select Id_PlanPagos from Detalle_PlanPagos Where Id_Detalle_PlanPagos = @Id))))" &
                " Where Id_Detalle_PlanPagos = @Id" &
                " Fetch Next From ID INTO @id" &
                " End" &
                " Close id" &
                " Deallocate id" &
                " Select Contrato, Cliente, Concepto, Fecha, Importe from @TablaTemp Where Contrato not in (Select Id_Contrato from Contratos where Cancelado = 'True')" &
                " Order by Contrato"
            Cx.Open()
            Dim DS As New DataSet
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            DA.Fill(DS, "Tabla1a3")

            SQL_Str = "Declare @TablaTemp Table(Contrato int, Cliente nvarchar(MAX), Concepto nvarchar(MAX), Fecha datetime2, Importe decimal(18, 6), Id_Detalle_PlanPagos int)" &
                " Insert into @TablaTemp Select 0,' ',Detalle as Concepto, Fecha_Vencimiento as Fecha, Importe, id_Detalle_PlanPagos  from Detalle_PlanPagos" &
                " Where Fecha_Vencimiento > GETDATE() And" &
                " DateDiff(Day, dateadd(Day,30,getdate()), Fecha_Vencimiento) > 0 " &
                " AND DATEDIFF(Day,dateadd(Day,30,getdate()), Fecha_Vencimiento) <= 30" &
                " AND Id_Detalle_PlanPagos not in (Select Id_Detalle_PlanPagos from Detalle_Recibos where Id_Recibo in(Select Id_Recibo  from Recibos Where Estado_Actual in ('Recibo Pagado','Recibo Facturado')))" &
                " Declare @Id int" &
                " Declare Id Cursor Read_Only for Select Id_Detalle_PlanPagos from @TablaTemp" &
                " Open Id" &
                " Fetch Next from Id into @ID" &
                " While @@FETCH_STATUS = 0" &
                " Begin" &
                " Update @TablaTemp Set Contrato = (Select Id_Contrato from PlanPagos where Id_PlanPagos = (Select Id_PlanPagos from Detalle_PlanPagos Where Id_Detalle_PlanPagos = @Id))," &
                " Cliente = (Select Nombre from Personas Where ID_Personas = (Select Id_Cliente from Contratos Where Id_Contrato =(Select Id_Contrato from PlanPagos where Id_PlanPagos = (Select Id_PlanPagos from Detalle_PlanPagos Where Id_Detalle_PlanPagos = @Id))))" &
                " Where Id_Detalle_PlanPagos = @Id" &
                " Fetch Next From ID INTO @id" &
                " End" &
                " Close id" &
                " Deallocate id" &
                " Select Contrato, Cliente, Concepto, Fecha, Importe from @TablaTemp Where Contrato not in (Select Id_Contrato from Contratos where Cancelado = 'True')" &
                " Order by Contrato"

            DA.SelectCommand.CommandText = SQL_Str
            DA.Fill(DS, "Tabla3a6")

            SQL_Str = "Declare @TablaTemp Table(Contrato int, Cliente nvarchar(MAX), Concepto nvarchar(MAX), Fecha datetime2, Importe decimal(18, 6), Id_Detalle_PlanPagos int)" &
                " Insert into @TablaTemp Select 0,' ',Detalle as Concepto, Fecha_Vencimiento as Fecha, Importe, id_Detalle_PlanPagos  from Detalle_PlanPagos" &
                " Where Fecha_Vencimiento > GETDATE() And" &
                " DateDiff(Day, dateadd(Day,60,getdate()), Fecha_Vencimiento) > 0 " &
                " AND DATEDIFF(Day,dateadd(Day,60,getdate()), Fecha_Vencimiento) <= 30" &
                " AND Id_Detalle_PlanPagos not in (Select Id_Detalle_PlanPagos from Detalle_Recibos where Id_Recibo in(Select Id_Recibo  from Recibos Where Estado_Actual in ('Recibo Pagado','Recibo Facturado')))" &
                " Declare @Id int" &
                " Declare Id Cursor Read_Only for Select Id_Detalle_PlanPagos from @TablaTemp" &
                " Open Id" &
                " Fetch Next from Id into @ID" &
                " While @@FETCH_STATUS = 0" &
                " Begin" &
                " Update @TablaTemp Set Contrato = (Select Id_Contrato from PlanPagos where Id_PlanPagos = (Select Id_PlanPagos from Detalle_PlanPagos Where Id_Detalle_PlanPagos = @Id))," &
                " Cliente = (Select Nombre from Personas Where ID_Personas = (Select Id_Cliente from Contratos Where Id_Contrato =(Select Id_Contrato from PlanPagos where Id_PlanPagos = (Select Id_PlanPagos from Detalle_PlanPagos Where Id_Detalle_PlanPagos = @Id))))" &
                " Where Id_Detalle_PlanPagos = @Id" &
                " Fetch Next From ID INTO @id" &
                " End" &
                " Close id" &
                " Deallocate id" &
                " Select Contrato, Cliente, Concepto, Fecha, Importe from @TablaTemp Where Contrato not in (Select Id_Contrato from Contratos where Cancelado = 'True')" &
                " Order by Contrato"

            DA.SelectCommand.CommandText = SQL_Str
            DA.Fill(DS, "TablaMas6")

            DataGridView1.DataSource = DS.Tables("Tabla1a3")
            DataGridView2.DataSource = DS.Tables("Tabla3a6")
            DataGridView3.DataSource = DS.Tables("TablaMas6")

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
    Private Sub Button_Genera_Reporte_Click(sender As Object, e As EventArgs)
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
        Dim oExcel As Object
        Dim oBook As Excel.Workbook
        Dim oSheet As Excel.Worksheet


        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        Dim thisThread As System.Threading.Thread = System.Threading.Thread.CurrentThread
        Dim originalCulture As System.Globalization.CultureInfo = thisThread.CurrentCulture
        Try
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Add
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
            'xlsheet = oBook.ActiveSheet
            If oExcel.Application.Sheets.Count() < 1 Then
                oSheet = CType(oBook.WolkSheets.Add(), Excel.Worksheet)
            Else
                oSheet = oExcel.Worksheets(1)
            End If
            oSheet.Name = "Cobranza a 30 dias"
            Dim range As Excel.Range
            ' Crea una nueva Instancia o Excel y un nuevo workbook.
            thisThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            If File.Exists(DireccionImagenLogo) Then
                oSheet.Shapes.AddPicture(DireccionImagenLogo, CType(False, Microsoft.Office.Core.MsoTriState), CType(True, Microsoft.Office.Core.MsoTriState), 5, 5, 130, 55)
            End If
            oSheet.Range("A1").EntireRow.RowHeight = 65
            oSheet.Cells(1, 5).Formula = Now
            oSheet.Range("A2").Font.Bold = True
            oSheet.Range("A2").Font.Size = 18
            oSheet.Range("A2").Interior.ColorIndex = 16
            oSheet.Range("A2").Value = "Cobranza a 30 dias"
            oSheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            oSheet.Range("A2:E3").Merge()
            oSheet.Range("A2:E3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )


            oSheet.Range("A5").Font.Bold = True
            oSheet.Range("A5").Font.Size = 12
            oSheet.Range("A5").Interior.ColorIndex = 16
            oSheet.Range("A5").Value = "30 Dias"
            oSheet.Range("A5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            oSheet.Range("A5:E5").Merge()
            oSheet.Range("A5:E5").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )
            oSheet.Cells(6, 1).Formula = "Contrato"
            oSheet.Cells(6, 2).Formula = "Cliente"
            oSheet.Cells(6, 3).Formula = "Concepto"
            oSheet.Cells(6, 4).Formula = "Fecha"
            oSheet.Cells(6, 5).Formula = "Importe"
            oSheet.Range("A6:E6").Font.Bold = True
            oSheet.Range("A6:E6").Interior.ColorIndex = 16
            oSheet.Range("A6:E6").Font.Size = 11
            oSheet.Range("A6:E6").Borders().Color = 0
            oSheet.Range("A6:E6").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            oSheet.Range("A6:E6").Borders().Weight = 2
            oSheet.Range("A6:E6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Dim R As String = "A7:A" + CInt(DataGridView1.RowCount + 5).ToString
            oSheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A1").EntireColumn.ColumnWidth = 8
            oSheet.Range("B1").EntireColumn.ColumnWidth = 35
            oSheet.Range("C1").EntireColumn.ColumnWidth = 10
            oSheet.Range("D1").EntireColumn.ColumnWidth = 18
            oSheet.Range("E1").EntireColumn.ColumnWidth = 15

            'Aqui obtengo el tamaño del datagrid y lo copio al excel
            Dim DGRows As Integer = Me.DataGridView1.RowCount
            Dim DGCols As Integer = Me.DataGridView1.ColumnCount
            Dim saRet(0, 0) As String
            If DGRows > 0 Then
                range = oSheet.Range("A7", Reflection.Missing.Value)
                range = range.Resize(DGRows, DGCols)
                range.Borders().Color = 0
                range.Borders().LineStyle = Excel.XlLineStyle.xlContinuous
                range.Borders().Weight = 2
                range.Font.Size = 9

                ReDim saRet(DGRows, DGCols)
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
            End If
            'Aqui paso a la 2a Pagina
            If oExcel.Application.Sheets.Count() < 2 Then
                oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
            Else
                oSheet = oExcel.Worksheets(2)
            End If
            oSheet.Name = "Cobranza a 60 dias"
            'Dim range2 As Excel.Range
            ' Crea una nueva Instancia o Excel y un nuevo workbook.
            thisThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            If File.Exists(DireccionImagenLogo) Then
                oSheet.Shapes.AddPicture(DireccionImagenLogo, CType(False, Microsoft.Office.Core.MsoTriState), CType(True, Microsoft.Office.Core.MsoTriState), 5, 5, 130, 55)
            End If
            oSheet.Range("A1").EntireRow.RowHeight = 65
            oSheet.Cells(1, 5).Formula = Now
            oSheet.Range("A2").Font.Bold = True
            oSheet.Range("A2").Font.Size = 18
            oSheet.Range("A2").Interior.ColorIndex = 16
            oSheet.Range("A2").Value = "Cobranza a 60 dias"
            oSheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            oSheet.Range("A2:E3").Merge()
            oSheet.Range("A2:E3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )


            oSheet.Range("A5").Font.Bold = True
            oSheet.Range("A5").Font.Size = 12
            oSheet.Range("A5").Interior.ColorIndex = 16
            oSheet.Range("A5").Value = "60 Dias"
            oSheet.Range("A5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            oSheet.Range("A5:E5").Merge()
            oSheet.Range("A5:E5").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )
            oSheet.Cells(6, 1).Formula = "Contrato"
            oSheet.Cells(6, 2).Formula = "Cliente"
            oSheet.Cells(6, 3).Formula = "Concepto"
            oSheet.Cells(6, 4).Formula = "Fecha"
            oSheet.Cells(6, 5).Formula = "Importe"
            oSheet.Range("A6:E6").Font.Bold = True
            oSheet.Range("A6:E6").Interior.ColorIndex = 16
            oSheet.Range("A6:E6").Font.Size = 11
            oSheet.Range("A6:E6").Borders().Color = 0
            oSheet.Range("A6:E6").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            oSheet.Range("A6:E6").Borders().Weight = 2
            oSheet.Range("A6:E6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            R = "A7:A" + CInt(DataGridView2.RowCount + 5).ToString
            oSheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A1").EntireColumn.ColumnWidth = 8
            oSheet.Range("B1").EntireColumn.ColumnWidth = 35
            oSheet.Range("C1").EntireColumn.ColumnWidth = 10
            oSheet.Range("D1").EntireColumn.ColumnWidth = 18
            oSheet.Range("E1").EntireColumn.ColumnWidth = 15

            'Aqui obtengo el tamaño del datagrid y lo copio al excel
            DGRows = Me.DataGridView2.RowCount
            DGCols = Me.DataGridView2.ColumnCount
            If DGRows > 0 Then
                range = oSheet.Range("A7", Reflection.Missing.Value)
                range = range.Resize(DGRows, DGCols)
                range.Borders().Color = 0
                range.Borders().LineStyle = Excel.XlLineStyle.xlContinuous
                range.Borders().Weight = 2
                range.Font.Size = 9
                'Crea un array
                ReDim saRet(DGRows, DGCols)
                'llena el array.

                For iRow = 0 To DataGridView2.RowCount - 1
                    For iCol = 0 To DataGridView2.ColumnCount - 1
                        saRet(iRow, iCol) = DataGridView2.Rows(iRow).Cells(iCol).Value.ToString
                    Next iCol
                Next iRow
                'establece el valor del rango del array.
                range.Value = saRet
            End If
            oSheet.Move(After:=oBook.Worksheets(oBook.Worksheets.Count))
            'Aqui paso a la 3a Pagina
            If oExcel.Application.Sheets.Count() < 3 Then
                oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
            Else
                oSheet = oExcel.Worksheets(3)
            End If
            oSheet.Name = "Cobranza a 90 dias"
            'Dim range2 As Excel.Range
            ' Crea una nueva Instancia o Excel y un nuevo workbook.
            thisThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            If File.Exists(DireccionImagenLogo) Then
                oSheet.Shapes.AddPicture(DireccionImagenLogo, CType(False, Microsoft.Office.Core.MsoTriState), CType(True, Microsoft.Office.Core.MsoTriState), 5, 5, 130, 55)
            End If
            oSheet.Range("A1").EntireRow.RowHeight = 65
            oSheet.Cells(1, 5).Formula = Now
            oSheet.Range("A2").Font.Bold = True
            oSheet.Range("A2").Font.Size = 18
            oSheet.Range("A2").Interior.ColorIndex = 16
            oSheet.Range("A2").Value = "Cobranza a 90 dias"
            oSheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            oSheet.Range("A2:E3").Merge()
            oSheet.Range("A2:E3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )


            oSheet.Range("A5").Font.Bold = True
            oSheet.Range("A5").Font.Size = 12
            oSheet.Range("A5").Interior.ColorIndex = 16
            oSheet.Range("A5").Value = "90 Dias"
            oSheet.Range("A5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            oSheet.Range("A5:E5").Merge()
            oSheet.Range("A5:E5").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )
            oSheet.Cells(6, 1).Formula = "Contrato"
            oSheet.Cells(6, 2).Formula = "Cliente"
            oSheet.Cells(6, 3).Formula = "Concepto"
            oSheet.Cells(6, 4).Formula = "Fecha"
            oSheet.Cells(6, 5).Formula = "Importe"
            oSheet.Range("A6:E6").Font.Bold = True
            oSheet.Range("A6:E6").Interior.ColorIndex = 16
            oSheet.Range("A6:E6").Font.Size = 11
            oSheet.Range("A6:E6").Borders().Color = 0
            oSheet.Range("A6:E6").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            oSheet.Range("A6:E6").Borders().Weight = 2
            oSheet.Range("A6:E6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            R = "A7:A" + CInt(DataGridView3.RowCount + 5).ToString
            oSheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A1").EntireColumn.ColumnWidth = 8
            oSheet.Range("B1").EntireColumn.ColumnWidth = 35
            oSheet.Range("C1").EntireColumn.ColumnWidth = 10
            oSheet.Range("D1").EntireColumn.ColumnWidth = 18
            oSheet.Range("E1").EntireColumn.ColumnWidth = 15

            'Aqui obtengo el tamaño del datagrid y lo copio al excel
            DGRows = Me.DataGridView3.RowCount
            DGCols = Me.DataGridView3.ColumnCount
            If DGRows > 0 Then
                range = oSheet.Range("A7", Reflection.Missing.Value)
                range = range.Resize(DGRows, DGCols)
                range.Borders().Color = 0
                range.Borders().LineStyle = Excel.XlLineStyle.xlContinuous
                range.Borders().Weight = 2
                range.Font.Size = 9
                'Crea un array
                ReDim saRet(DGRows, DGCols)
                'llena el array.

                For iRow = 0 To DataGridView3.RowCount - 1
                    For iCol = 0 To DataGridView3.ColumnCount - 1
                        saRet(iRow, iCol) = DataGridView3.Rows(iRow).Cells(iCol).Value.ToString
                    Next iCol
                Next iRow
                'establece el valor del rango del array.
                range.Value = saRet
            End If
            oSheet.Move(After:=oBook.Worksheets(oBook.Worksheets.Count))

            'Aqui paso a la 4a Pagina
            If oExcel.Application.Sheets.Count() < 4 Then
                oSheet = CType(oBook.Worksheets.Add(), Excel.Worksheet)
            Else
                oSheet = oExcel.Worksheets(4)
            End If
            oSheet.Name = "Saldo Vencido"
            'Dim range2 As Excel.Range
            ' Crea una nueva Instancia o Excel y un nuevo workbook.
            thisThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
            If File.Exists(DireccionImagenLogo) Then
                oSheet.Shapes.AddPicture(DireccionImagenLogo, CType(False, Microsoft.Office.Core.MsoTriState), CType(True, Microsoft.Office.Core.MsoTriState), 5, 5, 130, 55)
            End If
            oSheet.Range("A1").EntireRow.RowHeight = 65
            oSheet.Cells(1, 5).Formula = Now
            oSheet.Range("A2").Font.Bold = True
            oSheet.Range("A2").Font.Size = 18
            oSheet.Range("A2").Interior.ColorIndex = 16
            oSheet.Range("A2").Value = "Saldo Vencido"
            oSheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            oSheet.Range("A2:E3").Merge()
            oSheet.Range("A2:E3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )


            oSheet.Range("A5").Font.Bold = True
            oSheet.Range("A5").Font.Size = 12
            oSheet.Range("A5").Interior.ColorIndex = 16
            oSheet.Range("A5").Value = "Saldo Vencido"
            oSheet.Range("A5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A5").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            oSheet.Range("A5:E5").Merge()
            oSheet.Range("A5:E5").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )
            oSheet.Cells(6, 1).Formula = "Contrato"
            oSheet.Cells(6, 2).Formula = "Cliente"
            oSheet.Cells(6, 3).Formula = "Concepto"
            oSheet.Cells(6, 4).Formula = "Fecha"
            oSheet.Cells(6, 5).Formula = "Importe"
            oSheet.Range("A6:E6").Font.Bold = True
            oSheet.Range("A6:E6").Interior.ColorIndex = 16
            oSheet.Range("A6:E6").Font.Size = 11
            oSheet.Range("A6:E6").Borders().Color = 0
            oSheet.Range("A6:E6").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            oSheet.Range("A6:E6").Borders().Weight = 2
            oSheet.Range("A6:E6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            R = "A7:A" + CInt(DataGridView4.RowCount + 5).ToString
            oSheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            oSheet.Range("A1").EntireColumn.ColumnWidth = 8
            oSheet.Range("B1").EntireColumn.ColumnWidth = 35
            oSheet.Range("C1").EntireColumn.ColumnWidth = 10
            oSheet.Range("D1").EntireColumn.ColumnWidth = 18
            oSheet.Range("E1").EntireColumn.ColumnWidth = 15

            'Aqui obtengo el tamaño del datagrid y lo copio al excel
            DGRows = Me.DataGridView4.RowCount
            DGCols = Me.DataGridView4.ColumnCount
            If DGRows > 0 Then
                range = oSheet.Range("A7", Reflection.Missing.Value)
                range = range.Resize(DGRows, DGCols)
                range.Borders().Color = 0
                range.Borders().LineStyle = Excel.XlLineStyle.xlContinuous
                range.Borders().Weight = 2
                range.Font.Size = 9
                'Crea un array
                ReDim saRet(DGRows, DGCols)
                'llena el array.

                For iRow = 0 To DataGridView4.RowCount - 1
                    For iCol = 0 To DataGridView4.ColumnCount - 1
                        saRet(iRow, iCol) = DataGridView4.Rows(iRow).Cells(iCol).Value.ToString
                    Next iCol
                Next iRow
                'establece el valor del rango del array.
                range.Value = saRet
            End If
            oSheet.Move(After:=oBook.Worksheets(oBook.Worksheets.Count))

            'Regresa el control del Excel al usuario y Limpia
            range = Nothing
            oExcel.Visible = True
            oExcel.UserControl = True
            releaseobject(oExcel)
            releaseobject(oBook)
            releaseobject(oSheet)
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

    Private Sub Cobranza30_60_90_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Datos()
        Carga_Datos_Saldos()


    End Sub
End Class