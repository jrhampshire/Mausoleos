Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class PagosPendientes
#Region "Variables"
    Dim SQL_Str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
#End Region

    Private Sub PagosPendientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQL_Str = "Select Id_Detalle_PlanPagos as ID, Fecha_Vencimiento, Detalle, Importe from Detalle_PlanPagos Where Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato)"

        'SQL_Str = "Select Id_Detalle_PlanPagos as ID, Fecha_Vencimiento, Detalle, Importe " & _
        '    " from Detalle_PlanPagos Where Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato) " & _
        '    " and Id_Detalle_PlanPagos not in(Select Id_Detalle_PlanPagos from Detalle_Recibos Where " & _
        '    " Id_Recibo in(Select Id_Recibo from Recibos Where Estado_Actual = 'Cancelado'))"

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With DataGridView1
                .DataSource = DS.Tables("Tabla")
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
        Pinta_Grid()

    End Sub
    Sub Pinta_Grid()
        ' Primero pinta los Recibos Pagados y luego los recibos vencidos
        SQL_Str = "Select Id_Detalle_PlanPagos as ID" &
            " from Detalle_PlanPagos Where Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato) " &
            " and Id_Detalle_PlanPagos in(Select Id_Detalle_PlanPagos from Detalle_Recibos Where " &
            " Id_Recibo in(Select Id_Recibo from Recibos Where Estado_Actual in ('Recibo Pagado','Recibo Facturado')))"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Dim ID As Integer = 0
            Dim TotalFilas_Recibos As Integer = Me.DataGridView1.RowCount

            If DR.HasRows Then
                While DR.Read
                    ID = DR.Item(0)
                    For Each Row As DataGridViewRow In DataGridView1.Rows
                        If Row.Cells(0).Value = ID Then
                            Row.DefaultCellStyle.BackColor = Color.LightGreen
                        End If
                    Next

                End While
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
        SQL_Str = "Select Id_Detalle_PlanPagos as ID" &
            " from Detalle_PlanPagos Where Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato) " &
            " and Id_Detalle_PlanPagos in(Select Id_Detalle_PlanPagos from Detalle_Recibos Where " &
            " Id_Recibo in(Select Id_Recibo from Recibos Where Estado_Actual = 'Recibo Generado'))" &
            " and DATEDIFF(mm, Fecha_Vencimiento, GETDATE()) >1 "
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Dim ID As Integer = 0
            Dim TotalFilas_Recibos As Integer = Me.DataGridView1.RowCount

            If DR.HasRows Then
                While DR.Read
                    ID = DR.Item(0)
                    For Each Row As DataGridViewRow In DataGridView1.Rows
                        If Row.Cells(0).Value = ID Then
                            Row.DefaultCellStyle.BackColor = Color.Red
                        End If
                    Next

                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click

        Dim selectedRowCount As Integer = DataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected)
        ReDim ID_Recibos(selectedRowCount - 1)
        If selectedRowCount > 0 Then
            Dim i As Integer
            Dim columna As Integer, fila As Integer
            columna = 0
            For i = 0 To selectedRowCount - 1
                fila = DataGridView1.SelectedRows(i).Index()
                ID_Recibos(i) = (Me.DataGridView1(columna, fila).Value).ToString
            Next i
        End If
        Me.Close()

    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()

    End Sub
End Class