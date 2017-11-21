Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Globalization

Public Class Reporte_de_Saldos
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
    Dim clEmpresa As New ClassEmpresa

#End Region
    Sub Carga_Datos()
        Try
            SQL_Str = "Declare @Tabla Table(Id_Contrato int, Pagado Decimal(18,2))" &
                " Insert into @Tabla Select P.Id_Contrato, Sum(Cast(D.Importe as decimal)) as Pagado from PlanPagos as P ,Detalle_PlanPagos as D" &
                " Where P.Id_PlanPagos = D.Id_PlanPagos and D.Id_Detalle_PlanPagos in (Select Id_detalle_PlanPagos from Detalle_Recibos where Id_Recibo in (Select Id_Recibo from Recibos where Estado_Actual in('Recibo Pagado','Recibo Facturado')))" &
                " Group by p.Id_PlanPagos,P.Id_Contrato" &
                " SELECT V.Contrato,V.Nombre,V.Fecha_Alta as 'Fecha de Alta',V.Piso,V.Nicho,FORMAT( V.SaldoInicial, 'C') as 'Saldo Inicial',Format((V.SaldoInicial - T.Pagado),'C') as 'Saldo Actual' FROM View_NichosVendidos as V, @Tabla as T" &
                " Where V.Contrato = T.Id_Contrato Order by T.Id_Contrato"
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
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
    Sub Carga_Datos2()
        Dim Fecha_Corte As DateTime = Nothing
        Fecha_Corte = Me.DateTimePicker1.Value

        Try
            SQL_Str = "Declare @Tabla Table(Id_Contrato int, Pagado Decimal(18,2))" &
                " Insert into @Tabla Select P.Id_Contrato, Sum(Cast(D.Importe as decimal)) as Pagado from PlanPagos as P ,Detalle_PlanPagos as D" &
                " Where P.Id_PlanPagos = D.Id_PlanPagos and D.Id_Detalle_PlanPagos in (Select Id_detalle_PlanPagos from Detalle_Recibos where Id_Recibo in (Select Id_Recibo from Recibos where Estado_Actual in('Recibo Pagado','Recibo Facturado') and Fecha_Pago <= @Fecha))" &
                " Group by p.Id_PlanPagos,P.Id_Contrato" &
                " SELECT V.Contrato,V.Nombre,V.Fecha_Alta as 'Fecha de Alta',V.Piso,V.Nicho,FORMAT( V.SaldoInicial, 'C') as 'Saldo Inicial',Format((V.SaldoInicial - T.Pagado),'C') as 'Saldo Actual' FROM View_NichosVendidos as V, @Tabla as T" &
                " Where V.Contrato = T.Id_Contrato Order by T.Id_Contrato"
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Fecha", Fecha_Corte)
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
            xlsheet.Range("A2").Font.Bold = True
            xlsheet.Range("A2").Font.Size = 18
            xlsheet.Range("A2").Interior.ColorIndex = 16
            Dim Fecha_Temp As Date
            Fecha_Temp = FormatDateTime(Me.DateTimePicker1.Value, DateFormat.ShortDate)
            xlsheet.Range("A2").Value = "Reporte de Saldos al " & Fecha_Temp.ToString("dd \de MMMM \de yyyy", CultureInfo.CreateSpecificCulture("es-MX"))
            xlsheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            xlsheet.Range("A2:G3").Merge()
            xlsheet.Range("A2:G3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )
            xlsheet.Cells(6, 1).Formula = "Contrato"
            xlsheet.Cells(6, 2).Formula = "Cliente"
            xlsheet.Cells(6, 3).Formula = "Fecha de Alta"
            xlsheet.Cells(6, 4).Formula = "Piso"
            xlsheet.Cells(6, 5).Formula = "Nicho"
            xlsheet.Cells(6, 6).Formula = "Saldo Inicial"
            xlsheet.Cells(6, 7).Formula = "Saldo Actual"
            xlsheet.Range("A6:G6").Font.Bold = True
            xlsheet.Range("A6:G6").Interior.ColorIndex = 16
            xlsheet.Range("A6:G6").Font.Size = 11
            xlsheet.Range("A6:G6").Borders().Color = 0
            xlsheet.Range("A6:G6").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            xlsheet.Range("A6:G6").Borders().Weight = 2
            xlsheet.Range("A6:G6").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Dim R As String = "A7:A" + CInt(DataGridView1.RowCount + 5).ToString
            xlsheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A1").EntireColumn.ColumnWidth = 8
            xlsheet.Range("B1").EntireColumn.ColumnWidth = 40
            xlsheet.Range("C1").EntireColumn.ColumnWidth = 20
            xlsheet.Range("D1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("E1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("F1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("G1").EntireColumn.ColumnWidth = 15


            'Aqui obtengo el tamaño del datagrid y lo copio al excel
            Dim DGRows As Integer = Me.DataGridView1.RowCount
            Dim DGCols As Integer = Me.DataGridView1.ColumnCount
            range = xlsheet.Range("A7", Reflection.Missing.Value)
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

    Private Sub Reporte_de_Saldos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Datos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Carga_Datos2()

    End Sub
End Class