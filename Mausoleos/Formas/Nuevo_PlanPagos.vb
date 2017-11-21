Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Nuevo_PlanPagos
    Dim Sql_str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub Nuevo_PlanPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Label_Contrato.Text = Id_Contrato
        Me.Label_PrecioTotal.Text = SaldoInicial
    End Sub
    Function UltimoDiaMes(Fecha As Date) As Date
        UltimoDiaMes = DateSerial(Year(Fecha), Month(Fecha) + 1, 0)
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Trim(Me.Label_PrecioTotal.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Label_PrecioTotal.Focus()
            Exit Sub
        Else
            SaldoInicial = CDec(Trim(Me.Label_PrecioTotal.Text))
        End If

        If Trim(Me.TextBox_Anticipo.Text) = "" Then
            Anticipo = 0
        Else
            Anticipo = CDec(Trim(Me.TextBox_Anticipo.Text))
        End If
        If Trim(Me.TextBox_Mensualidades.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_Mensualidades.Focus()
            Exit Sub
        Else
            Mensualidades = Trim(Me.TextBox_Mensualidades.Text)
        End If

        Dim Periodicidad As String = Nothing
        If Me.ComboBox1.Text = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox1.Focus()
            Exit Sub
        Else
            Periodicidad = Me.ComboBox1.Text
        End If
        Dim Id_PlanPagos As Integer = 0
        If Me.CheckBox1.Checked = True Then
            Dim Transaccion As SqlTransaction = Nothing
            Try
                Cx.Open()
                Transaccion = Cx.BeginTransaction("Inserta Plan de Pagos")
                Sql_str = "Insert into PlanPagos (Id_Contrato, Fecha_Inicio, SaldoInicial)" &
                    " Values(@Id_Contrato, @Fecha_Inicio, @SaldoInicial);" &
                    " Select @ID = @@Identity"
                Dim Cmd As New SqlCommand(Sql_str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Transaction = Transaccion
                Dim FechaActual As Date = Fecha_Inicio_Recibos
                Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
                Cmd.Parameters.AddWithValue("@Fecha_Inicio", Format(FechaActual, "yyyy-MM-ddTHH:mm:ss"))
                Cmd.Parameters.AddWithValue("@SaldoInicial", SaldoInicial)
                Cmd.Parameters.Add("@ID", SqlDbType.Int)
                Cmd.Parameters("@ID").Direction = ParameterDirection.Output
                Cmd.ExecuteNonQuery()
                Id_PlanPagos = Cmd.Parameters("@ID").Value.ToString()
                Dim Detalle As String = Nothing
                If Anticipo <> 0 Then
                    Detalle = "1/" & Mensualidades
                    'Detalle = "Pago inicial"
                    Sql_str = "Insert into Detalle_PlanPagos(Id_PlanPagos, Fecha_Vencimiento, Importe, Detalle)" &
                    "Values(@Id_PlanPagos, @Fecha_Vencimiento, @Importe, @Detalle)"
                    Cmd.CommandText = Sql_str
                    Cmd.Parameters.AddWithValue("@Id_PlanPagos", Id_PlanPagos)
                    Cmd.Parameters.AddWithValue("@Fecha_Vencimiento", Format(FechaActual, "yyyy-MM-ddTHH:mm:ss"))
                    Cmd.Parameters.AddWithValue("@Importe", Anticipo)
                    Cmd.Parameters.AddWithValue("@Detalle", Detalle)
                    Cmd.ExecuteNonQuery()
                End If
                Transaccion.Commit()
                Me.Close()
            Catch ex As SqlException
                Transaccion.Rollback()
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                Transaccion.Rollback()
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        Else
            SaldoActual = SaldoInicial - Anticipo
            Mensualidad = SaldoActual / (Mensualidades - 1)
            Dim Transaccion As SqlTransaction = Nothing
            Try
                Cx.Open()
                Transaccion = Cx.BeginTransaction("Inserta Plan de Pagos")
                Sql_str = "Insert into PlanPagos (Id_Contrato, Fecha_Inicio, SaldoInicial)" &
                    " Values(@Id_Contrato, @Fecha_Inicio, @SaldoInicial);" &
                    " Select @ID = @@Identity"
                Dim Cmd As New SqlCommand(Sql_str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Transaction = Transaccion
                Dim FechaActual As Date = Fecha_Inicio_Recibos
                Dim Dia As Integer = FechaActual.Day
                Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
                Cmd.Parameters.AddWithValue("@Fecha_Inicio", Format(FechaActual, "yyyy-MM-ddTHH:mm:ss"))
                Cmd.Parameters.AddWithValue("@SaldoInicial", SaldoInicial)
                Cmd.Parameters.Add("@ID", SqlDbType.Int)
                Cmd.Parameters("@ID").Direction = ParameterDirection.Output
                Cmd.ExecuteNonQuery()
                Id_PlanPagos = Cmd.Parameters("@ID").Value.ToString()
                Dim Detalle As String = Nothing
                If Anticipo <> 0 Then
                    Detalle = "1/" & Mensualidades
                    'Detalle = "Pago inicial"
                    Sql_str = "Insert into Detalle_PlanPagos(Id_PlanPagos, Fecha_Vencimiento, Importe, Detalle)" &
                    "Values(@Id_PlanPagos, @Fecha_Vencimiento, @Importe, @Detalle)"
                    Cmd.CommandText = Sql_str
                    Cmd.Parameters.AddWithValue("@Id_PlanPagos", Id_PlanPagos)
                    Cmd.Parameters.AddWithValue("@Fecha_Vencimiento", Format(FechaActual, "yyyy-MM-ddTHH:mm:ss"))
                    Cmd.Parameters.AddWithValue("@Importe", Anticipo)
                    Cmd.Parameters.AddWithValue("@Detalle", Detalle)
                    Cmd.ExecuteNonQuery()
                End If
                FechaActual = Fecha_Recibos
                Dim MensualidadActual As Integer = 2

                'If Dia > 20 Then
                '    FechaActual = DateAdd(DateInterval.Month, 1, FechaActual)
                'End If
                Do While MensualidadActual <= Mensualidades
                    Detalle = MensualidadActual & "/" & Mensualidades
                    Sql_str = "Insert into Detalle_PlanPagos(Id_PlanPagos, Fecha_Vencimiento, Importe,Detalle)" &
                        "Values(@Id_PlanPagos" & MensualidadActual & ", @Fecha_Vencimiento" & MensualidadActual & ", @Importe" & MensualidadActual & ",@Detalle" & MensualidadActual & ")"
                    If Periodicidad = "Mensual" Then
                        If _DiaPago <> Fecha_Recibos.Day And Fecha_Recibos.Month = 2 And FechaActual.Month = 2 Then
                            Dim Dias As Integer = _DiaPago - Fecha_Recibos.Day
                            FechaActual = DateAdd(DateInterval.Month, 1, FechaActual)
                            FechaActual = DateAdd(DateInterval.Day, Dias, FechaActual)
                        Else
                            If FechaActual.Day = 28 And FechaActual.Month = 2 Then
                                FechaActual = DateAdd(DateInterval.Month, 1, FechaActual)
                                FechaActual = DateAdd(DateInterval.Day, 2, FechaActual)

                            ElseIf FechaActual.Day = 29 And FechaActual.Month = 2 Then
                                FechaActual = DateAdd(DateInterval.Month, 1, FechaActual)
                                FechaActual = DateAdd(DateInterval.Day, 1, FechaActual)
                            Else
                                FechaActual = DateAdd(DateInterval.Month, 1, FechaActual)
                            End If

                        End If

                    ElseIf Periodicidad = "Quincenal" Then
                        FechaActual = DateAdd(DateInterval.Day, 15, FechaActual)
                    End If

                    Cmd.CommandText = Sql_str
                    Cmd.Parameters.AddWithValue("@Id_PlanPagos" & MensualidadActual, Id_PlanPagos)
                    Cmd.Parameters.AddWithValue("@Fecha_Vencimiento" & MensualidadActual, Format(FechaActual, "yyyy-MM-ddTHH:mm:ss"))
                    Cmd.Parameters.AddWithValue("@Importe" & MensualidadActual, Mensualidad)
                    Cmd.Parameters.AddWithValue("@Detalle" & MensualidadActual, Detalle)
                    Cmd.ExecuteNonQuery()
                    MensualidadActual = MensualidadActual + 1
                Loop
                Transaccion.Commit()
                Me.Close()

            Catch ex As SqlException
                Transaccion.Rollback()
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                Transaccion.Rollback()
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            Me.TextBox_Anticipo.Text = Label_PrecioTotal.Text
            Me.TextBox_Mensualidades.Text = 1
            Me.ComboBox1.Text = "Mensual"
            Me.Button2.Focus()
        Else
            Me.TextBox_Anticipo.Text = ""
            Me.TextBox_Mensualidades.Text = ""
            Me.ComboBox1.Text = ""
            Me.TextBox_Anticipo.Focus()
        End If
    End Sub
End Class