Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class ProyeccionCobranza

    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing

    Private Sub Button_Salir_Click(sender As Object, e As EventArgs) Handles Button_Salir.Click
        Me.Close()
    End Sub
    Private Sub ProyeccionCobranza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Datos()
        Me.DataGridView1.Columns(0).ReadOnly = True
        Me.DataGridView1.Columns(1).ReadOnly = True
        Me.DataGridView1.Columns(2).ReadOnly = False
        Me.DataGridView1.Columns(3).ReadOnly = False
        Me.DataGridView1.Columns(4).ReadOnly = False
        Me.DataGridView1.Columns(5).ReadOnly = False
        Me.DataGridView1.Columns(6).ReadOnly = False
        Me.DataGridView1.Columns(7).ReadOnly = False
        Me.DataGridView1.Columns(8).ReadOnly = False
        Me.DataGridView1.Columns(9).ReadOnly = False
        Me.DataGridView1.Columns(10).ReadOnly = False
        Me.DataGridView1.Columns(11).ReadOnly = False
        Me.DataGridView1.Columns(12).ReadOnly = False
        Me.DataGridView1.Columns(13).ReadOnly = False
        Me.DataGridView1.Columns(14).ReadOnly = True

        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(0).Cells(2)
    End Sub
    Sub Carga_Datos()
        Try
            SQL_Str = "Select Descripcion, ValorUnitario from ProductosyServicios Order by Descripcion"
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Dim Reader As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            With Reader
                If .HasRows Then
                    While .Read
                        Me.DataGridView1.Rows.Add(.Item("Descripcion"), .Item("ValorUnitario"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                    End While
                End If
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
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim Renglon, Columna As Integer
        Columna = Me.DataGridView1.CurrentCellAddress.X
        Renglon = Me.DataGridView1.CurrentCellAddress.Y
        If Renglon < 0 Or Columna < 0 Then
            Exit Sub
        End If
        Dim Importe As Decimal = Me.DataGridView1(1, Renglon).Value
        Importe = Importe / 48
        Dim ValorEnero As Decimal = Me.DataGridView1(2, Renglon).Value
        Dim ValorFebrero As Decimal = Me.DataGridView1(3, Renglon).Value
        Dim ValorMarzo As Decimal = Me.DataGridView1(4, Renglon).Value
        Dim ValorAbril As Decimal = Me.DataGridView1(5, Renglon).Value
        Dim ValorMayo As Decimal = Me.DataGridView1(6, Renglon).Value
        Dim ValorJunio As Decimal = Me.DataGridView1(7, Renglon).Value
        Dim ValorJulio As Decimal = Me.DataGridView1(8, Renglon).Value
        Dim ValorAgosto As Decimal = Me.DataGridView1(9, Renglon).Value
        Dim ValorSeptiembre As Decimal = Me.DataGridView1(10, Renglon).Value
        Dim ValorOctubre As Decimal = Me.DataGridView1(11, Renglon).Value
        Dim ValorNoviembre As Decimal = Me.DataGridView1(12, Renglon).Value
        Dim ValorDiciembre As Decimal = Me.DataGridView1(13, Renglon).Value

        ValorEnero = ValorEnero * 12 * Importe
        ValorFebrero = ValorFebrero * 11 * Importe
        ValorMarzo = ValorMarzo * 10 * Importe
        ValorAbril = ValorAbril * 9 * Importe
        ValorMayo = ValorMayo * 8 * Importe
        ValorJunio = ValorJunio * 7 * Importe
        ValorJulio = ValorJulio * 6 * Importe
        ValorAgosto = ValorAgosto * 5 * Importe
        ValorSeptiembre = ValorSeptiembre * 4 * Importe
        ValorOctubre = ValorOctubre * 3 * Importe
        ValorNoviembre = ValorNoviembre * 2 * Importe
        ValorDiciembre = ValorDiciembre * 1 * Importe

        Dim ValorTotal As Decimal = ValorEnero + ValorFebrero + ValorMarzo + ValorAbril + ValorMayo + ValorJunio + ValorJulio + ValorAgosto + ValorSeptiembre + ValorOctubre + ValorNoviembre + ValorDiciembre
        Me.DataGridView1(14, Renglon).Value = FormatNumber(ValorTotal, 2)

    End Sub
    Private Sub Button_Imprimir_Click(sender As Object, e As EventArgs) Handles Button_Imprimir.Click
        Genera_Excel()
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
            xlsheet.Cells(1, 15).Formula = Now
            xlsheet.Range("A2").Font.Bold = True
            xlsheet.Range("A2").Font.Size = 18
            xlsheet.Range("A2").Interior.ColorIndex = 16
            xlsheet.Range("A2").Value = "Proyeccion de Cobranza Anual"
            xlsheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            xlsheet.Range("A2:O3").Merge()
            xlsheet.Range("A2:O3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )

            xlsheet.Cells(4, 1).Formula = "Producto"
            xlsheet.Cells(4, 2).Formula = "Precio"
            xlsheet.Cells(4, 3).Formula = "Enero"
            xlsheet.Cells(4, 4).Formula = "Febrero"
            xlsheet.Cells(4, 5).Formula = "Marzo"
            xlsheet.Cells(4, 6).Formula = "Abril"
            xlsheet.Cells(4, 7).Formula = "Mayo"
            xlsheet.Cells(4, 8).Formula = "Junio"
            xlsheet.Cells(4, 9).Formula = "Julio"
            xlsheet.Cells(4, 10).Formula = "Agosto"
            xlsheet.Cells(4, 11).Formula = "Septiembre"
            xlsheet.Cells(4, 12).Formula = "Octubre"
            xlsheet.Cells(4, 13).Formula = "Noviembre"
            xlsheet.Cells(4, 14).Formula = "Diciembre"
            xlsheet.Cells(4, 15).Formula = "Importe Total"
            xlsheet.Range("A4:O4").Font.Bold = True
            xlsheet.Range("A4:O4").Interior.ColorIndex = 16
            xlsheet.Range("A4:O4").Font.Size = 11
            xlsheet.Range("A4:O4").Borders().Color = 0
            xlsheet.Range("A4:O4").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            xlsheet.Range("A4:O4").Borders().Weight = 2
            xlsheet.Range("A4:O4").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A4:O4").WrapText = True
            Dim R As String = "A4:A" + CInt(DataGridView1.RowCount + 5).ToString
            xlsheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A1").EntireColumn.ColumnWidth = 40
            xlsheet.Range("B1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("C1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("D1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("E1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("F1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("G1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("H1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("I1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("J1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("K1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("L1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("M1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("N1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("O1").EntireColumn.ColumnWidth = 15
            'Aqui obtengo el tamaño del datagrid y lo copio al excel
            Dim DGRows As Integer = Me.DataGridView1.RowCount
            Dim DGCols As Integer = Me.DataGridView1.ColumnCount
            range = xlsheet.Range("A5", Reflection.Missing.Value)
            range = range.Resize(DGRows, DGCols)
            range.Borders().Color = 0
            range.Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            range.Borders().Weight = 2
            range.Font.Size = 9
            'Crea un array
            Dim saRet(DGRows, DGCols) As String
            'llena el array.

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