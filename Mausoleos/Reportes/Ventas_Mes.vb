Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Globalization

Public Class Ventas_Mes
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
    Dim clEmpresa As New ClassEmpresa
    Function UltimoDiaMes(Fecha As Date) As Date
        UltimoDiaMes = DateSerial(Year(Fecha), Month(Fecha) + 1, 0)
    End Function
    Function PrimerDiaMes(Fecha As Date) As Date
        PrimerDiaMes = DateSerial(Year(Fecha), Month(Fecha), 1)
    End Function
    Private Sub Ventas_Mes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateTimePicker_FechaInicio.Value = PrimerDiaMes(Now)
        Me.DateTimePicker_FechaFin.Value = UltimoDiaMes(Now)
        Carga_Reporte()

    End Sub
    Sub Carga_Reporte()
        Dim Fecha_Inicio As Date, Fecha_Fin As Date
        Try
            Fecha_Inicio = Format(Me.DateTimePicker_FechaInicio.Value, "yyyy-MM-dd")
            Fecha_Fin = Format(Me.DateTimePicker_FechaFin.Value, "yyyy-MM-dd")
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.HResult.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Try
            Cx.Open()
            Dim Cmd As New SqlCommand
            Cmd.Connection = Cx
            Cmd.CommandText = "Select [Contrato],[Nombre],[Fecha_Alta] as [Fecha de Alta],[Piso],[Nicho],CONVERT(varchar, Cast(SaldoInicial/1.16 as Money),1) AS Importe,CONVERT(varchar," &
            " Cast(SaldoInicial*.16 as Money),1) as IVA,CONVERT(varchar, Cast(SaldoInicial as Money),1) as Total,metodoDePago AS [Forma de Pago] FROM [Mausoleos].[dbo].[View_NichosVendidos]" &
            " Where Fecha_Alta between @Fecha_Inicio and @Fecha_Fin" &
            " Order by Contrato"
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Fecha_Inicio", Fecha_Inicio)
            Cmd.Parameters.AddWithValue("@Fecha_Fin", Fecha_Fin)
            Cmd.ExecuteNonQuery()
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With DataGridView1
                .DataSource = DS.Tables(0)
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

    Private Sub Button_Genera_Reporte_Click(sender As Object, e As EventArgs) Handles Button_Genera_Reporte.Click
        Carga_Reporte()

    End Sub

    Private Sub Button_Salir_Click(sender As Object, e As EventArgs) Handles Button_Salir.Click
        Me.Close()

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
            xlsheet.Cells(1, 9).Formula = Now
            'xlsheet.Range("A7").VerticalAlignment = Excel.XlVAlign.xlVAlignTop
            'xlsheet.Range("A7").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            xlsheet.Range("A2").Font.Bold = True
            xlsheet.Range("A2").Font.Size = 18
            xlsheet.Range("A2").Interior.ColorIndex = 16
            xlsheet.Range("A2").Value = "Ventas del Mes"
            xlsheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            xlsheet.Range("A2:I3").Merge()
            xlsheet.Range("A2:I3").BorderAround(, Excel.XlBorderWeight.xlMedium,
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
            xlsheet.Cells(7, 2).Formula = "Nombre"
            xlsheet.Cells(7, 3).Formula = "Fecha de Alta"
            xlsheet.Cells(7, 4).Formula = "Piso"
            xlsheet.Cells(7, 5).Formula = "Nicho"
            xlsheet.Cells(7, 6).Formula = "Importe"
            xlsheet.Cells(7, 7).Formula = "Iva"
            xlsheet.Cells(7, 8).Formula = "Total"
            xlsheet.Cells(7, 9).Formula = "Forma de Pago"
            Dim Rango_Titulos_Tabla As String = "A7:I7"
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
            xlsheet.Range("B1").EntireColumn.ColumnWidth = 30
            xlsheet.Range("C1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("D1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("E1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("F1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("G1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("H1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("I1").EntireColumn.ColumnWidth = 20
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
End Class