Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Globalization

Public Class PagodeComisiones
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
    Dim clEmpresa As New ClassEmpresa
#End Region
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

    Private Sub PagodeComisiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQL_Str = "Select ID_Usuarios, Nombre from Usuarios  Where Activo = 'True'"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Empleados")
            With Me.ToolStripComboBox1.ComboBox
                .DataSource = DS.Tables("Empleados")
                .DisplayMember = "Nombre"
                .ValueMember = "Id_Usuarios"
            End With
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
        GeneraComisiones()
        Me.DataGridView1.Columns(0).ReadOnly = False
        Me.DataGridView1.Columns(1).ReadOnly = True
        Me.DataGridView1.Columns(2).ReadOnly = True
        Me.DataGridView1.Columns(3).ReadOnly = True
        Me.DataGridView1.Columns(4).ReadOnly = True
        Me.DataGridView1.Columns(5).ReadOnly = False
        Me.DataGridView1.Columns(6).ReadOnly = True
        Me.DataGridView1.Columns(7).ReadOnly = True
        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(0).Cells(0)
    End Sub
    Sub Genera_Excel()
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
            xlsheet.Range("A2").Font.Bold = True
            xlsheet.Range("A2").Font.Size = 18
            xlsheet.Range("A2").Interior.ColorIndex = 16
            xlsheet.Range("A2").Value = "Pago de Comisiones"
            xlsheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            xlsheet.Range("A2:E3").Merge()
            xlsheet.Range("A2:E3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )

            xlsheet.Cells(7, 1).Formula = "Contrato"
            xlsheet.Cells(7, 2).Formula = "Cliente"
            xlsheet.Cells(7, 3).Formula = "Ubicación"
            xlsheet.Cells(7, 4).Formula = "Comisiones a Pagar"
            xlsheet.Cells(7, 5).Formula = "Importe"
            xlsheet.Range("A7:E7").Font.Bold = True
            xlsheet.Range("A7:E7").Interior.ColorIndex = 16
            xlsheet.Range("A7:E7").Font.Size = 11
            xlsheet.Range("A7:E7").Borders().Color = 0
            xlsheet.Range("A7:E7").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            xlsheet.Range("A7:E7").Borders().Weight = 2
            xlsheet.Range("A7:E7").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A7:E7").WrapText = True


            'Crea un array

            'llena el array.
            Dim Total As Double = 0
            Dim iRow, aRow As Integer
            'Dim iCol As Integer
            Dim Seleccionados As Integer = 0
            For iRow = 0 To DataGridView1.RowCount - 1
                Dim Valor1 As Boolean = Me.DataGridView1(0, iRow).Value
                If Valor1 = True Then
                    Seleccionados = Seleccionados + 1
                End If
            Next
            Dim R As String = "A8:A" + CInt(Seleccionados + 8).ToString
            xlsheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Dim R1 As String = "D8:D" + CInt(Seleccionados + 8).ToString
            xlsheet.Range(R1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A1").EntireColumn.ColumnWidth = 8
            xlsheet.Range("B1").EntireColumn.ColumnWidth = 30
            xlsheet.Range("C1").EntireColumn.ColumnWidth = 16
            xlsheet.Range("D1").EntireColumn.ColumnWidth = 12
            xlsheet.Range("E1").EntireColumn.ColumnWidth = 15
            'Aqui obtengo el tamaño del datagrid y lo copio al excel
            Dim DGRows As Integer = Seleccionados
            Dim DGCols As Integer = 5
            range = xlsheet.Range("A8", Reflection.Missing.Value)
            range = range.Resize(DGRows, DGCols)
            range.Borders().Color = 0
            range.Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders().Weight = 2
            range.Font.Size = 9
            Dim saRet(Seleccionados, 5) As String
            aRow = 0
            For iRow = 0 To DataGridView1.RowCount - 1
                Dim Valor As Boolean = Me.DataGridView1(0, iRow).Value
                If Valor = True Then
                    Total = Total + DataGridView1.Rows(iRow).Cells(7).Value
                    'For iCol = 0 To DataGridView1.ColumnCount - 1.

                    SQL_Str = "SELECT Nombre, (Piso + '-' + Nicho) as Ubicacion" &
                        " FROM View_Listado_Clientes_1" &
                        " Where Contrato = @Id_Contrato"
                    Try
                        Cx.Open()
                        Dim Cmd As New SqlCommand(SQL_Str, Cx)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Parameters.AddWithValue("@Id_Contrato", DataGridView1.Rows(iRow).Cells(1).Value.ToString)
                        Dim Reader As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If Reader.HasRows Then
                            While Reader.Read
                                saRet(aRow, 1) = Reader.Item(0).ToString
                                saRet(aRow, 2) = Reader.Item(1).ToString
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

                    saRet(aRow, 0) = DataGridView1.Rows(iRow).Cells(1).Value
                    saRet(aRow, 3) = DataGridView1.Rows(iRow).Cells(5).Value
                    saRet(aRow, 4) = DataGridView1.Rows(iRow).Cells(7).Value
                    'Next iCol
                    aRow = aRow + 1
                End If
            Next
            xlsheet.Range("A4").Font.Bold = False
            xlsheet.Range("A4").Font.Size = 11
            xlsheet.Range("A4").Value = "Recibi de Mausoleos Divino Maestro, la Cantidad de $" & Total & " (" & NumeroATexto(Total) & "), por concepto de comisiones correspondientes a los siguientes clientes:"
            xlsheet.Range("A4").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A4").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            xlsheet.Range("A4:E6").Merge()
            xlsheet.Range("A4:E6").WrapText = True
            xlsheet.Range("A4:E6").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            xlsheet.Range("A4:E6").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )

            'establece el valor del rango del array.
            range.Value = saRet


            Dim R2 As String = "A" + CInt(Seleccionados + 10).ToString + ":E" + CInt(Seleccionados + 10).ToString
            xlsheet.Range("A" + CInt(Seleccionados + 10).ToString).font.bold = True
            xlsheet.Range("A" + CInt(Seleccionados + 10).ToString).Value = "Recibi"
            xlsheet.Range(R2).Merge()
            xlsheet.Range(R2).WrapText = True
            xlsheet.Range(R2).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter


            Dim R3 As String = "A" + CInt(Seleccionados + 13).ToString + ":E" + CInt(Seleccionados + 13).ToString
            xlsheet.Range("A" + CInt(Seleccionados + 13).ToString).font.bold = True
            xlsheet.Range("A" + CInt(Seleccionados + 13).ToString).Value = Me.ToolStripComboBox1.Text
            xlsheet.Range(R3).Merge()
            xlsheet.Range(R3).WrapText = True
            xlsheet.Range(R3).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
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
    Sub GeneraComisiones()
        Dim Contrato As Integer = 0
        Dim Mensualidades As Integer = 0
        Dim Pagadas As Integer = 0
        Dim Comisiones As Integer = 0
        Dim Vendedor As String = Nothing
        Dim Comision As Double = 0

        Dim Vendedor1 As String = Trim(Me.ToolStripComboBox1.ComboBox.Text)
        Me.DataGridView1.Rows.Clear()
        Me.DataGridView1.DataSource = Nothing

        Try
            SQL_Str = "Declare @TablaTemp Table(Id_Detalle_PlanPagos int,Id_Contrato int )" &
                        " Declare @TablaTotales as Table(Mensualidades int, Id_Contrato int)" &
                        " Declare @TablaEmpledos as Table(Nombre nvarchar(MAX), Id_Contrato int)" &
                        " Declare @ComisionesPagadas as Table(Total int, Id_Contrato int)" &
                        " Declare @PagosRealizados as Table(TotalPagados int, Id_Contrato int)" &
                        " Declare @Mensualidades as Table(Id_Contrato int, Mensualidades int, Nombre nvarchar(MAX))" &
                        " Declare @ComisionesyPagados as Table(Id_Contrato int, Comisiones int, TotalPagados int)" &
                        " Declare @Totales as Table(Id_Contrato int, Mensualidades int, Comisiones int, TotalPagados int , Nombre nvarchar(MAX))" &
                        " Insert into @TablaTemp Select D.Id_Detalle_PlanPagos, P.Id_Contrato from Detalle_PlanPagos as D," &
                        " PlanPagos as P Where P.Id_PlanPagos = d.Id_PlanPagos" &
                        " Insert into @TablaTotales Select COUNT(Id_Detalle_PlanPagos) as Total , Id_Contrato from @TablaTemp Group by Id_Contrato " &
                        " Insert into @TablaEmpledos Select U.Nombre, C.Id_Contrato from Usuarios as U, Contratos as C Where u.ID_Usuarios = C.Id_Empleado " &
                        " Insert into @ComisionesPagadas Select COUNT(Id_Comisiones) As Total, Id_Contrato from Comisiones GROUP BY Id_Contrato " &
                        " Insert into @PagosRealizados SELECT COUNT(dbo.Detalle_PlanPagos.Id_Detalle_PlanPagos) AS TotalPagados, dbo.PlanPagos.Id_Contrato" &
                        " FROM dbo.Detalle_PlanPagos INNER JOIN" &
                        " dbo.PlanPagos ON dbo.Detalle_PlanPagos.Id_PlanPagos = dbo.PlanPagos.Id_PlanPagos" &
                        " WHERE (dbo.Detalle_PlanPagos.Id_Detalle_PlanPagos IN" &
                        " (SELECT Id_Detalle_PlanPagos FROM dbo.Detalle_Recibos WHERE (Id_Recibo IN" &
                        " (SELECT Id_Recibo FROM dbo.Recibos WHERE(Estado_Actual in ('Recibo Pagado','Recibo Facturado'))))))" &
                        " GROUP BY dbo.PlanPagos.Id_Contrato" &
                        " Insert into @Mensualidades Select T.Id_Contrato, T.Mensualidades, E.Nombre From @TablaTotales as T" &
                        " Full Outer Join @TablaEmpledos as E on t.Id_Contrato = e.Id_Contrato " &
                        " Insert into @ComisionesyPagados Select P.Id_Contrato, C.Total as Comisiones, P.TotalPagados" &
                        " from @ComisionesPagadas as C Full Outer Join @PagosRealizados as P ON C.Id_Contrato=P.Id_Contrato " &
                        " Insert into @Totales Select M.Id_Contrato, M.Mensualidades, C.Comisiones, C.TotalPagados, M.Nombre From @Mensualidades as M " &
                        " FULL OUTER JOIN @ComisionesyPagados as C ON M.Id_Contrato = C.Id_Contrato Order by M.Nombre " &
                        " Select T.Id_Contrato, T.Mensualidades, T.TotalPagados, P.SaldoInicial, T.Comisiones, T.Nombre From @Totales as T " &
                        " Full Outer Join PlanPagos as P on T.Id_Contrato = P.Id_Contrato Where T.Nombre = @Vendedor and T.TotalPagados > 0"
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Vendedor", Vendedor1)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Dim ComisionesporPagar As Integer = 3
                    If Not IsDBNull(DR.Item("Id_Contrato")) Then
                        Contrato = DR.Item("Id_Contrato")
                        If IsDBNull(DR.Item("Mensualidades")) Then
                            Mensualidades = 0
                        Else
                            Mensualidades = DR.Item("Mensualidades")
                        End If
                        If Not IsDBNull(DR.Item("TotalPagados")) Then
                            Pagadas = DR.Item("TotalPagados")
                        Else
                            Pagadas = 0
                        End If
                        If Not IsDBNull(DR.Item("Comisiones")) Then
                            Comisiones = DR.Item("Comisiones")
                        Else
                            Comisiones = 0
                        End If
                        Vendedor = DR.Item("Nombre")
                        SaldoInicial = DR.Item("SaldoInicial") / 1.16
                        Dim Importe As Decimal = 0
                        If Pagadas > 0 Then
                            If Mensualidades <= 2 Then
                                If Pagadas >= 1 Then
                                    ComisionesporPagar = 1 - Comisiones
                                    If ComisionesporPagar > 0 Then
                                        Importe = SaldoInicial * 0.07
                                        Me.DataGridView1.Rows.Add(False, Contrato, Mensualidades, Pagadas, Comisiones, ComisionesporPagar, SaldoInicial, FormatCurrency(Importe, 2))
                                    End If
                                End If
                            Else
                                If Pagadas = 1 Then
                                    ComisionesporPagar = 1
                                    If ComisionesporPagar > 0 Then
                                        Importe = ComisionesporPagar * ((SaldoInicial * 0.07) / 3)
                                        Me.DataGridView1.Rows.Add(False, Contrato, Mensualidades, Pagadas, Comisiones, ComisionesporPagar, SaldoInicial, FormatCurrency(Importe, 2))
                                    End If
                                ElseIf Pagadas = 2 Then
                                    ComisionesporPagar = 2
                                    If ComisionesporPagar > 0 Then
                                        Importe = ComisionesporPagar * ((SaldoInicial * 0.07) / 3)
                                        Me.DataGridView1.Rows.Add(False, Contrato, Mensualidades, Pagadas, Comisiones, ComisionesporPagar, SaldoInicial, FormatCurrency(Importe, 2))
                                    End If
                                ElseIf Pagadas >= 3 Then
                                    ComisionesporPagar = ComisionesporPagar - Comisiones
                                    If ComisionesporPagar > 0 Then
                                        Importe = ComisionesporPagar * ((SaldoInicial * 0.07) / 3)
                                        Me.DataGridView1.Rows.Add(False, Contrato, Mensualidades, Pagadas, Comisiones, ComisionesporPagar, SaldoInicial, FormatCurrency(Importe, 2))
                                    End If
                                End If

                            End If
                        End If
                    End If
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
    End Sub
    Private Sub Button_PagarComision_Click(sender As Object, e As EventArgs) Handles Button_PagarComision.Click
        PagaComisiones()
        GeneraComisiones()
        Me.DataGridView1.Columns(0).ReadOnly = False
        Me.DataGridView1.Columns(1).ReadOnly = True
        Me.DataGridView1.Columns(2).ReadOnly = True
        Me.DataGridView1.Columns(3).ReadOnly = True
        Me.DataGridView1.Columns(4).ReadOnly = True
        Me.DataGridView1.Columns(5).ReadOnly = False
        Me.DataGridView1.Columns(6).ReadOnly = True
        Me.DataGridView1.Columns(7).ReadOnly = True
        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(0).Cells(0)
    End Sub
    Sub PagaComisiones()
        For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            If dr.Cells("Pagar").Value.ToString() = "True" Then
                Dim Renglon, Columna As Integer
                Columna = 5

                Renglon = dr.Cells("Pagar").RowIndex
                'Renglon = Me.DataGridView1.CurrentCellAddress.Y
                If Renglon < 0 Then
                    Exit Sub
                End If
                Dim TotalComisiones As Integer = Me.DataGridView1(Columna, Renglon).Value
                If TotalComisiones = 0 Then
                    Exit Sub
                End If
                Columna = 7
                Dim ImportedeComisiones As Decimal = Me.DataGridView1(Columna, Renglon).Value / TotalComisiones
                For X = 1 To TotalComisiones
                    Try
                        SQL_Str = "Insert into Comisiones (Id_Contrato, FechaPago, Importe, Concepto) Values (@Id_Contrato, @FechaPago, @Importe, @Concepto)"
                        Cx.Open()
                        Dim Cmd As New SqlCommand(SQL_Str, Cx)
                        Cmd.Parameters.AddWithValue("@Id_Contrato", Me.DataGridView1(1, Renglon).Value)
                        Cmd.Parameters.AddWithValue("@FechaPago", Now)
                        Cmd.Parameters.AddWithValue("@Importe", ImportedeComisiones)
                        Cmd.Parameters.AddWithValue("@Concepto", "Pago de Comisiones del Contrato " & Me.DataGridView1(1, Renglon).Value)
                        Cmd.ExecuteNonQuery()

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
                    'X = X + 1
                Next
            End If
        Next
        Genera_Excel()
    End Sub
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim Renglon, Columna As Integer
        Columna = Me.DataGridView1.CurrentCellAddress.X
        Renglon = Me.DataGridView1.CurrentCellAddress.Y
        If Renglon < 0 Or Columna < 0 Then
            Exit Sub
        End If
        If Columna = 0 Then
            Dim Valor As Boolean = Me.DataGridView1(Columna, Renglon).Value
            If Valor = True Then
                Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Renglon).Cells(5)
            End If
        ElseIf Columna = 5 Then
            Dim Mensualidades As Integer = Me.DataGridView1(2, Renglon).Value
            Dim Valor As Integer = Me.DataGridView1(Columna, Renglon).Value
            If Mensualidades < 3 Then
                If Valor > 1 Then
                    Me.DataGridView1(Columna, Renglon).Value = 1
                    Me.DataGridView1(7, Renglon).Value = Me.DataGridView1(5, Renglon).Value * (Me.DataGridView1(6, Renglon).Value * 0.07)
                End If
            Else
                If Valor > 3 Then
                    Me.DataGridView1(Columna, Renglon).Value = 3
                    Dim Comision2 As Double = Me.DataGridView1(5, Renglon).Value * ((Me.DataGridView1(6, Renglon).Value * 0.07) / 3)
                    Me.DataGridView1(7, Renglon).Value = FormatCurrency(Comision2, 2)
                Else
                    Dim Comision2 As Double = Me.DataGridView1(5, Renglon).Value * ((Me.DataGridView1(6, Renglon).Value * 0.07) / 3)
                    Me.DataGridView1(7, Renglon).Value = FormatCurrency(Comision2, 2)
                End If
            End If


        End If

    End Sub
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    ''' <summary>
    ''' Crea un archivo de texto delimitado con el contenido de
    ''' un objeto DataTable.
    ''' </summary>
    ''' <param name="fileName">Ruta y nombre del archivo de texto.</param>
    ''' <param name="dt">Un objeto DataTable válido.</param>
    ''' <param name="separatorChar">El carácter delimitador de los campos.</param>
    ''' <param name="hdr">Indica si la primera fila contiene el nombre de los campos.</param>
    ''' <param name="textDelimiter">Indica si los campos alfanuméricos deben aparecer
    ''' entre comillas dobles.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateTextDelimiterFile(ByVal fileName As String,
                                             ByVal dt As System.Data.DataTable,
                                             ByVal separatorChar As Char,
                                             ByVal hdr As Boolean,
                                             ByVal textDelimiter As Boolean) As Boolean

        ' Si no se ha especificado un nombre de archivo,
        ' o el objeto DataTable no es válido, provocamos
        ' una excepción de argumentos no válidos.
        '
        If (fileName = String.Empty) OrElse
           (dt Is Nothing) Then Throw New System.ArgumentException("Argumentos no válidos.")

        ' Si el archivo existe, solicito confirmación para sobreescribirlo.
        '
        If (IO.File.Exists(fileName)) Then
            If (MessageBox.Show("Ya existe un archivo de texto con el mismo nombre." & Environment.NewLine &
                               "¿Desea sobrescribirlo?",
                               "Crear archivo de texto delimitado",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information) = DialogResult.No) Then Return False
        End If

        Dim sw As System.IO.StreamWriter

        Try
            Dim col As Integer = 0
            Dim value As String = String.Empty

            ' Creamos el archivo de texto con la codificación por defecto.
            '
            sw = New IO.StreamWriter(fileName, False, System.Text.Encoding.Default)

            If (hdr) Then
                ' La primera línea del archivo de texto contiene
                ' el nombre de los campos.
                For Each dc As DataColumn In dt.Columns

                    If (textDelimiter) Then
                        ' Incluimos el nombre del campo entre el caracter
                        ' delimitador de texto especificado.
                        '
                        value &= """" & dc.ColumnName & """" & separatorChar

                    Else
                        ' No se incluye caracter delimitador de texto alguno.
                        '
                        value &= dc.ColumnName & separatorChar

                    End If

                Next

                sw.WriteLine(value.Remove(value.Length - 1, 1))
                value = String.Empty

            End If

            ' Recorremos todas las filas del objeto DataTable
            ' incluido en el conjunto de datos.
            '
            For Each dr As DataRow In dt.Rows

                For Each dc As DataColumn In dt.Columns

                    If ((dc.DataType Is System.Type.GetType("System.String")) And
                       (textDelimiter = True)) Then

                        ' Incluimos el dato alfanumérico entre el caracter
                        ' delimitador de texto especificado.
                        '
                        value &= """" & dr.Item(col).ToString & """" & separatorChar

                    Else
                        ' No se incluye caracter delimitador de texto alguno
                        '
                        value &= dr.Item(col).ToString & separatorChar

                    End If

                    ' Siguiente columna
                    col += 1

                Next

                ' Al escribir los datos en el archivo, elimino el
                ' último carácter delimitador de la fila.
                '
                sw.WriteLine(value.Remove(value.Length - 1, 1))
                value = String.Empty
                col = 0

            Next ' Siguiente fila

            ' Nos aseguramos de cerrar el archivo
            '
            sw.Close()

            ' Se ha creado con éxito el archivo de texto.
            '
            Return True

        Catch ex As Exception
            Return False

        Finally
            sw = Nothing

        End Try

    End Function

#Region "Numeros a Letras 2"
    Public Function NumeroATexto(ByVal d As Double) As String
        Dim parteEntera As Double = Math.Truncate(d)
        Dim parteDecimal As Double = Math.Truncate((d - parteEntera) * 100)
        If (parteDecimal > 0) Then
            Return Num2Text(parteEntera) + " Pesos " + CInt(parteDecimal).ToString + "/100 M.N."
        Else
            Return Num2Text(parteEntera) + " Pesos 00/100 M.N."
        End If

    End Function
    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function

#End Region
End Class