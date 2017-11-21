Imports clsCFDIx
Imports clsCFDIx.CFDx
Imports clsTimbrado
Imports clsTimbrado.clsTimbradoATEB
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.ComponentModel

Public Class ListadoRecibos
#Region "Variables"
    Private ImpresoraActual As New Printing.PrinterSettings
    Private Lector As StreamReader
    Private prFont As System.Drawing.Font
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
    Dim clEmpresa As New ClassEmpresa
    Dim clCliente As New Cliente
    Dim clPersona As New Persona
    Dim Cont As New Contrato
    Dim Cliente_Actual As Integer = 0
    Dim Emisor As Integer = 0
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


    Private Sub Button_Genera_Reporte_Click(sender As Object, e As EventArgs)
        Carga_Datos()
    End Sub

    Private Sub ListadoRecibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateTimePicker_FechaInicio.Value = PrimerDiaMes(Now)
        Me.DateTimePicker_FechaFin.Value = UltimoDiaMes(Now)

        Carga_Datos()
        Carga_Empresa()

    End Sub

    Private Sub Button_AgregaRecibo_Click(sender As Object, e As EventArgs) Handles Button_AgregaRecibo.Click
        Dim Frm As New Cobranza
        Frm.ShowDialog()
        Carga_Datos()
    End Sub

    Private Sub Button_Salir_Click(sender As Object, e As EventArgs) Handles Button_Salir.Click
        Try
            Close()
        Catch ex As ObjectDisposedException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Button_CancelaRecibo_Click(sender As Object, e As EventArgs) Handles Button_CancelaRecibo.Click
        Dim Id_Recibo As Integer = 0
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Try
            Id_Recibo = Me.DataGridView1(columna, fila).Value
        Catch ex As Exception
            Exit Sub
        End Try
        If Id_Recibo = 0 Then
            MessageBox.Show("Debe seleccionar un Recibo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView1.Focus()
            Exit Sub
        Else
            Dim Estado_Actual As String = Me.DataGridView1(2, fila).Value
            If Estado_Actual = "Cancelado" Then
                MessageBox.Show("Este recibo ya esta Cancelado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView1.Focus()
                Exit Sub
            ElseIf Estado_Actual = "Recibo Facturado" Then
                MessageBox.Show("No se puede cancelar este recibo ya que tiene una factura registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView1.Focus()
                Exit Sub
            ElseIf Estado_Actual = "Recibo Pagado" Then
                MessageBox.Show("Este Recibo ya tiene una factura registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView1.Focus()
                Exit Sub
            Else
                Dim Respuesta As DialogResult = Nothing
                Respuesta = MessageBox.Show("Esta a punto de Cancelar el Recibo: " & Id_Recibo & " ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Select Case Respuesta
                    Case System.Windows.Forms.DialogResult.Yes
                        Using Cx As New SqlConnection(CxSettings.ConnectionString)
                            SQL_Str = "Update Recibos Set Estado_Actual = 'Cancelado',Fecha_Pago = getdate(), Descripcion = 'Cancelado' Where Id_Recibo = @Id_Recibo"
                            '"Delete Detalle_Recibos Where Id_Recibo = @Id_Recibo"
                            Try
                                Cx.Open()
                                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                                Cmd.CommandType = CommandType.Text
                                Cmd.Parameters.AddWithValue("@Id_Recibo", Id_Recibo)
                                Cmd.ExecuteNonQuery()
                                Me.DataGridView1(2, fila).Value = "Cancelado"
                                Me.DataGridView1(3, fila).Value = "Cancelado"
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
                    Case System.Windows.Forms.DialogResult.No
                        Exit Sub
                End Select
            End If
        End If
        'Carga_Datos()

    End Sub

    Private Sub Button_Pagos_Click(sender As Object, e As EventArgs) Handles Button_Pagos.Click
        Dim Id_Recibo As Integer = 0
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Try
            Id_Recibo = Me.DataGridView1(columna, fila).Value
        Catch ex As Exception
            Exit Sub
        End Try
        Try
            If Id_Recibo = 0 Then
                MessageBox.Show("Debe seleccionar un Contrato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView1.Focus()
                Exit Sub
            Else
                Dim Estado_Actual As String = Me.DataGridView1(2, fila).Value
                If Estado_Actual = "Cancelado" Then
                    MessageBox.Show("No se puede registrar el pago de este recibo ya que esta Cancelado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DataGridView1.Focus()
                    Exit Sub
                ElseIf Estado_Actual = "Recibo Pagado" Then
                    MessageBox.Show("Este Recibo ya tiene un pago registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DataGridView1.Focus()
                    Exit Sub
                Else
                    Dim Respuesta As DialogResult = Nothing
                    Respuesta = MessageBox.Show("Desea registrar un pago para el recibo: " & Id_Recibo, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Respuesta = System.Windows.Forms.DialogResult.Yes Then
                        Using Cx As New SqlConnection(CxSettings.ConnectionString)
                            Try
                                Dim Fecha As Date = Now
                                Cx.Open()
                                SQL_Str = "Actualiza_Recibo2"
                                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                                Cmd.CommandType = CommandType.StoredProcedure
                                Cmd.Parameters.AddWithValue("@Id_Recibo", Id_Recibo)
                                Cmd.Parameters.AddWithValue("@Fecha_Pago", Fecha)
                                Cmd.Parameters.AddWithValue("@Estado_Actual", "Recibo Pagado")
                                Cmd.ExecuteNonQuery()
                                Me.DataGridView1(1, fila).Value = Fecha
                                Me.DataGridView1(2, fila).Value = "Recibo Pagado"
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

                    ElseIf Respuesta = System.Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
            End If
            ' Carga_Datos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Button_Imprime_Click(sender As Object, e As EventArgs) Handles Button_Imprime.Click
        Dim Id_Recibo As Integer = 0
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Try
            Id_Recibo = Me.DataGridView1(columna, fila).Value
        Catch ex As Exception
            Exit Sub
        End Try
        If Id_Recibo = 0 Then
            MessageBox.Show("Debe seleccionar un nicho", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView1.Focus()
            Exit Sub
        Else
            Dim Respuesta As DialogResult = Nothing
            Respuesta = MessageBox.Show("Desea reimprimir el recibo: " & Id_Recibo, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Select Case Respuesta
                Case System.Windows.Forms.DialogResult.Yes
                    Try


                        Try
                            PrintDialog1.PrinterSettings = ImpresoraActual
                            If PrintDialog1.ShowDialog = DialogResult.OK Then
                                ImpresoraActual = PrintDialog1.PrinterSettings
                            Else
                                Exit Sub
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                        End Try

                        'Asigno el tamaño de la pagina
                        Dim TamañoPersonal As Printing.PaperSize
                        Dim Ancho As Short
                        Dim Alto As Short
                        Try
                            '1 mm = 39.37 milesimas de pulgada, entonces el ancho de una hoja de 216 mm = 850.39 milesimas de pulgada
                            Ancho = 850.39
                            Alto = 429.3

                            TamañoPersonal = New Printing.PaperSize("Recibos", Ancho, Alto)

                            ' Asignamos la impresora seleccionada
                            PrintDocument1.PrinterSettings = ImpresoraActual
                            ' Asignamos el tamaño personalizado de papel
                            PrintDocument1.DefaultPageSettings.PaperSize = TamañoPersonal
                            'MessageBox.Show("Nuevo tamaño asignado a documento")
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                        End Try

                        PrintDocument1.Print()

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
                Case System.Windows.Forms.DialogResult.No
                    Exit Sub
            End Select
        End If
        Carga_Datos()
    End Sub

#Region "Carga Datos del Contrato"
    Sub Carga_Datos_Contrato()

        'Aqui carga la informacion del recibo

        'Aqui carga la informacion del contrato
        SQL_Str = "Select Id_Gaveta, Id_Cliente, Id_Empleado, Forma_Pago, Dia_Pago," &
            " LugarPago, Descuento,Motivo_Descuento,NumCtaPago,metodoDePago," &
            " Convert(date,Fecha_Alta,112) as Fecha_Alta from  Contratos where Id_Contrato = @Id_Contrato"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Contrato", Cont.Contrato)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Cont.Fecha_Alta = New DateTime(CDate(DR.Item("Fecha_Alta")).Year, CDate(DR.Item("Fecha_Alta")).Month, CDate(DR.Item("Fecha_Alta")).Day)
                    Cont.Gaveta = DR.Item("Id_Gaveta")
                    Cliente_Actual = DR.Item("Id_Cliente")
                    Cont.Id_Agente = DR.Item("Id_Empleado")
                    Cont.FormaPago = DR.Item("Forma_Pago")
                    Cont.DiaPago = DR.Item("Dia_Pago")
                    Cont.LugarPago = DR.Item("LugarPago")
                    Cont.Descuento = DR.Item("Descuento")
                    Cont.Motivo_Descuento = DR.Item("Motivo_Descuento")
                    Cont.NumeroCta = DR.Item("NumCtaPago")
                    Cont.MetodoPago = DR.Item("metodoDePago")
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
        'Aqui carga la informacion de la Persona
        SQL_Str = "Select Nombre, Sexo, CONVERT(date,Fecha_Nacimiento,112) as Fecha_Nacimiento," &
            " email, Id_REceptor, Tel_Particular, Celular, Observaciones from Personas where Id_Personas = @Id_Personas"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Personas", Cliente_Actual)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    clPersona.Nombre = DR.Item("Nombre")
                    clPersona.Sexo = DR.Item("Sexo")
                    clPersona.Fecha_Nacimiento = DR.Item("Fecha_Nacimiento")
                    clPersona.Email = DR.Item("email")
                    clCliente.Id_Receptor = DR.Item("Id_Receptor")
                    clPersona.Tel_Particular = DR.Item("Tel_Particular")
                    clPersona.Celular = DR.Item("Celular")
                    clPersona.Observaciones = DR.Item("Observaciones")
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
        'Aqui carga la informacion del Receptor
        SQL_Str = "Select * from  Receptor where Id_Receptor = @Id_Receptor"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Receptor", clCliente.Id_Receptor)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    clCliente.RFC = DR.Item("rfc")
                    clCliente.Razon_Social = DR.Item("nombre")
                    clCliente.Id_Domicilio = DR.Item("Id_Domicilio")
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
        'Aqui carga la informacion del Domicilio
        SQL_Str = "Select * from  Domicilio where Id_Domicilio = @Id_Domicilio"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Domicilio", clCliente.Id_Domicilio)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    clCliente.Calle = DR.Item("calle")
                    clCliente.noExterior = DR.Item("noExterior")
                    clCliente.noInterior = DR.Item("noInterior")
                    clCliente.colonia = DR.Item("colonia")
                    clCliente.codigoPostal = DR.Item("codigoPostal")
                    clCliente.Id_Localidad = DR.Item("Id_Localidad")

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
        SQL_Str = "Select Estado from Estado where Id_Estado in (Select Id_Estado from Municipio where Id_Municipio in (Select Id_Municipio from Localidad where Id_Localidad = @Id_Localidad))"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Localidad", clCliente.Id_Localidad)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    clCliente.estado = DR.Item("Estado")

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

#End Region
    Sub Carga_Datos()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Fecha_Inicio As Date, Fecha_Fin As Date
            Try
                Fecha_Inicio = Format(Me.DateTimePicker_FechaInicio.Value, "yyyy-MM-dd")
                Fecha_Fin = Format(Me.DateTimePicker_FechaFin.Value, "yyyy-MM-dd")
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.HResult.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Try
                SQL_Str = "Declare @TablaTemp Table(Id_Recibo int, Fecha_Pago datetime2, Estado_Actual nvarchar(100)," &
                    " Descripcion nvarchar(MAX), Contrato int, Cliente nvarchar(MAX))" &
                    " Insert Into @TablaTemp Select Id_Recibo, Fecha_Pago, Estado_Actual, Descripcion ,0,0 from Recibos" &
                    " Where (Fecha_Pago BETWEEN CONVERT(DATETIME, @Fecha10, 102) AND CONVERT(DATETIME, @Fecha20, 102))" &
                    " Declare @Recibo int" &
                    " Declare Recibos Cursor Read_Only for Select Id_Recibo from @TablaTemp" &
                    " Open Recibos" &
                    " Fetch Next From Recibos INTO @Recibo" &
                    " While @@FETCH_STATUS = 0" &
                    " Begin" &
                    " Update @TablaTemp Set Contrato = (Select Id_Contrato as Contrato from Contratos Where Cancelado = 'False'" &
                    " And Id_Contrato = (Select Id_Contrato from PlanPagos Where Id_PlanPagos =(Select Distinct(Id_PlanPagos) From Detalle_PlanPagos" &
                    " Where Id_Detalle_PlanPagos in (Select Id_Detalle_PlanPagos from Detalle_Recibos Where Id_Recibo = @Recibo))))," &
                    " Cliente = (Select P.Nombre as Cliente from Contratos as C, Personas as P" &
                    " Where C.Id_Cliente = P.ID_Personas and C.Cancelado = 'False'" &
                    " And C.Id_Contrato = (Select Id_Contrato from PlanPagos Where Id_PlanPagos =(Select Distinct(Id_PlanPagos) From Detalle_PlanPagos" &
                    " Where Id_Detalle_PlanPagos in (Select Id_Detalle_PlanPagos from Detalle_Recibos Where Id_Recibo = @Recibo))))" &
                    " Where Id_Recibo = @Recibo " &
                    " Fetch Next From Recibos INTO @Recibo" &
                    " End" &
                    " Close Recibos" &
                    " Deallocate Recibos" &
                    " Select Id_Recibo as Recibo, Fecha_Pago, Estado_Actual as Estado, Descripcion as Concepto, Contrato, Cliente" &
                    " from @TablaTemp"


                Cx.Open()
                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandText = SQL_Str
                Cmd.Parameters.AddWithValue("@Fecha10", Fecha_Inicio)
                Cmd.Parameters.AddWithValue("@Fecha20", Fecha_Fin)
                Cmd.CommandType = CommandType.Text
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Tabla")
                DataGridView1.DataSource = DS.Tables("Tabla")
                DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Descending)
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
    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim AjusteX As Integer = 0
        Dim AjusteY As Integer = 0
        Dim ValorConversion As Double = 34.5
        Dim ValorConversion2 As Double = 37.7
        Dim Concepto2 As String = Nothing
        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left
        ' La fuente a usar
        prFont = New System.Drawing.Font("Arial", 8, FontStyle.Regular)
        ' la posición superior
        Dim yPos As Single = prFont.GetHeight(e.Graphics)
        Dim Fecha As DateTime = Now.ToLongDateString
        Dim Id_Recibo As Integer = 0
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Try
            Id_Recibo = Me.DataGridView1(columna, fila).Value
        Catch ex As Exception
            Exit Sub
        End Try
        If Id_Recibo = 0 Then
            MessageBox.Show("Debe seleccionar un nicho", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView1.Focus()
            Exit Sub
        Else
            Dim Importe As Double = 0
            Dim Fecha_Venc As DateTime = Nothing
            Dim Ubicacion As String = Nothing
            Dim RFC As String = Nothing
            Dim Domicilio As String = Nothing
            Dim Colonia As String = Nothing
            Dim Localidad As String = Nothing
            Try
                Cx.Open()
                SQL_Str = "Select Importe, Fecha_Vencimiento from Detalle_PlanPagos where Id_Detalle_PlanPagos = (Select Id_Detalle_PlanPagos from Detalle_Recibos  where Id_Recibo = @Recibo)"
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Recibo", Id_Recibo)
                Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If DR.HasRows Then
                    While DR.Read
                        Importe = DR.Item(0)
                        Fecha_Venc = DR.Item(1)
                    End While
                End If
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
                SQL_Str = "Select Piso + ' ' + Nicho as Ubicacion from View_Listado_Clientes_1  where Contrato = @Contrato"
                Cx.Open()
                Cmd = New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Contrato", Me.DataGridView1(4, fila).Value)
                DR = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If DR.HasRows Then
                    While DR.Read
                        Ubicacion = DR.Item(0)
                    End While
                End If
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
                SQL_Str = "Select R.RFC, d.Calle + ' ' + d.noExterior + ' ' + d.noInterior as Domicilio, d.colonia, l.Localidad" &
                    " From Receptor as R, Domicilio as D, Localidad as L" &
                    " Where R.ID_Receptor = (Select Id_Receptor from Personas Where ID_Personas = (Select Id_Cliente from Contratos Where Id_Contrato = @Contrato))" &
                    " And d.ID_Domicilio = r.Id_Domicilio" &
                    " And l.ID_Localidad = d.Id_localidad"
                Cx.Open()
                Cmd = New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Contrato", Me.DataGridView1(4, fila).Value)
                DR = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If DR.HasRows Then
                    While DR.Read
                        RFC = DR.Item(0)
                        Domicilio = DR.Item(1)
                        Colonia = DR.Item(2)
                        Localidad = DR.Item(3)
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

            e.Graphics.DrawString(Me.DataGridView1(5, fila).Value, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + (4.6 * ValorConversion))
            e.Graphics.DrawString(RFC, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + (5.5 * ValorConversion))
            e.Graphics.DrawString(Domicilio, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + (6.8 * ValorConversion))
            e.Graphics.DrawString(Colonia, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + ((6.8 * ValorConversion) + 15))
            e.Graphics.DrawString(Localidad, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + ((6.8 * ValorConversion) + 30))
            Dim Fecha2 As DateTime = Nothing
            Dim Fecha2Txt As String = Nothing
            'Aqui verifica cuantas mensualidades se van a pagar para armar el concepto
            e.Graphics.DrawString("Pago " & Me.DataGridView1(3, fila).Value, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + (8.6 * ValorConversion))
            e.Graphics.DrawString("San Luis Potosí, S.L.P. a " & Fecha.ToString("dd \de MMMM \de yyyy", CultureInfo.CreateSpecificCulture("es-MX")), prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + (9.7 * ValorConversion))
            e.Graphics.DrawString(Me.DataGridView1(4, fila).Value, prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (4.1 * ValorConversion))
            'e.Graphics.DrawString(Me.Label_Ubicacion.Text, prFont, Brushes.Black, AjusteX + (18.5 * (ValorConversion2 - 0.3)), AjusteY + (4.85 * ValorConversion))
            e.Graphics.DrawString(Ubicacion, prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (4.85 * ValorConversion))
            'e.Graphics.DrawString(Me.DataGridView_EstadoCuenta(2, 0).Value, prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (5.55 * ValorConversion))
            e.Graphics.DrawString(Me.DataGridView1(3, fila).Value, prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (5.55 * ValorConversion))
            'e.Graphics.DrawString(Fecha2.ToString("d", CultureInfo.CreateSpecificCulture("es-MX")), prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (6.4 * ValorConversion))
            e.Graphics.DrawString(Fecha_Venc, prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (6.4 * ValorConversion))
            e.Graphics.DrawString(FormatNumber(Importe, 2, , , Microsoft.VisualBasic.TriState.True), prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (7 * ValorConversion))
            'e.Graphics.DrawString(FormatNumber(Me.DataGridView_EstadoCuenta.Columns(3, 0).Value, 2, , , Microsoft.VisualBasic.TriState.True), prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (7 * ValorConversion))
            Dim CantidadconLetras As String = NumeroATexto(Importe)
            'Dim CantidadconLetras As String = NumeroATexto(Me.DataGridView_EstadoCuenta(3, 0).Value)
            CantidadconLetras = StrConv(CantidadconLetras, VbStrConv.ProperCase)
            Dim Largo_CantidadLetras As Integer = CantidadconLetras.Length
            If Largo_CantidadLetras > 55 Then
                Dim Cadena1 As String = Mid(CantidadconLetras, 1, 55)
                Dim Cadena2 As String = Mid(CantidadconLetras, 56, Largo_CantidadLetras)
                e.Graphics.DrawString(Cadena1 + " -", prFont, Brushes.Black, AjusteX + (14.3 * ValorConversion), AjusteY + (8.2 * ValorConversion))
                e.Graphics.DrawString(Cadena2, prFont, Brushes.Black, AjusteX + (15.3 * ValorConversion), AjusteY + ((8.2 * ValorConversion) + 15))
            Else
                e.Graphics.DrawString(CantidadconLetras, prFont, Brushes.Black, AjusteX + (14.3 * ValorConversion), AjusteY + (8.2 * ValorConversion))
            End If

            ' indicamos que ya no hay nada más que imprimir
            ' (el valor predeterminado de esta propiedad es False)
            e.HasMorePages = False

        End If

        ' imprimimos la cadena

    End Sub
    Private Function Sumar(
     ByVal nombre_Columna As String,
     ByVal Dgv As DataGridView) As Double

        Dim total As Double = 0

        ' recorrer las filas y obtener los items de la columna indicada en "nombre_Columna"
        Try
            For i As Integer = 0 To Dgv.RowCount - 1
                total = total + CDbl(Dgv.Item(nombre_Columna.ToLower, i).Value)
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        ' retornar el valor
        Return total

    End Function
    Public Function CortarCadenaPorPalabras(CadenaEntrada As String, NumCaracteresEnParrafo As Integer) As IList(Of String)

        Dim retorno As List(Of String) = New List(Of String)    'lista con los parrafos
        Dim palabra As String
        Dim contenedor As String

        If CadenaEntrada.Length = 0 Then
            'si la cadena de entrada esta vacia devolvemos una coleccion vacia.
            Return retorno
        ElseIf CadenaEntrada.Length <= NumCaracteresEnParrafo Then
            'si la cadena tiene [NumCaracteresEnParrafo] caracteres o menos, devolvemos sólo un elemento con la cadena entera
            retorno.Add(CadenaEntrada)
            Return retorno
        End If

        'contenedor para almacenar las palabras mientras que la longitud del párrafo sea menor que [NumCaracteresEnParrafo] 
        contenedor = ""
        For Each palabra In CadenaEntrada.Split(" "c)

            'si la palabra tiene más de [NumCaracteresEnParrafo] caracteres seguidos, se trozea
            If palabra.Length >= NumCaracteresEnParrafo Then
                If contenedor.Length > 0 Then retorno.Add(contenedor)
                Do
                    Dim trozo As String = palabra.Substring(0, NumCaracteresEnParrafo - 1)
                    retorno.Add(trozo)
                    palabra = palabra.Remove(0, NumCaracteresEnParrafo - 1)
                Loop While palabra.Length >= NumCaracteresEnParrafo
            End If

            If palabra.Length > 0 Then
                If contenedor.Length + palabra.Length + 1 > NumCaracteresEnParrafo Then
                    retorno.Add(contenedor)
                    contenedor = palabra
                Else
                    contenedor = contenedor & " " & palabra
                End If
            End If
        Next
        If contenedor.Length > 0 Then retorno.Add(contenedor)

        Return retorno
    End Function
#Region "Reporte de Excel"

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
            xlsheet.Cells(1, 6).Formula = Now
            'xlsheet.Range("A7").VerticalAlignment = Excel.XlVAlign.xlVAlignTop
            'xlsheet.Range("A7").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            xlsheet.Range("A2").Font.Bold = True
            xlsheet.Range("A2").Font.Size = 18
            xlsheet.Range("A2").Interior.ColorIndex = 16
            xlsheet.Range("A2").Value = "Recibos Generados"
            xlsheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            xlsheet.Range("A2:F3").Merge()
            xlsheet.Range("A2:F3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )
            xlsheet.Range("A5").Font.Bold = False
            xlsheet.Range("A5").Font.Size = 12
            xlsheet.Cells(7, 1).Formula = "Recibo"
            xlsheet.Cells(7, 2).Formula = "Fecha de Pago"
            xlsheet.Cells(7, 3).Formula = "Estado"
            xlsheet.Cells(7, 4).Formula = "Concepto"
            xlsheet.Cells(7, 5).Formula = "Contrato"
            xlsheet.Cells(7, 6).Formula = "Cliente"
            xlsheet.Range("A7:F7").Font.Bold = True
            xlsheet.Range("A7:F7").Interior.ColorIndex = 16
            xlsheet.Range("A7:F7").Font.Size = 11
            xlsheet.Range("A7:F7").Borders().Color = 0
            xlsheet.Range("A7:F7").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            xlsheet.Range("A7:F7").Borders().Weight = 2
            xlsheet.Range("A7:F7").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Dim R As String = "A7:A" + CInt(DataGridView1.RowCount + 5).ToString
            xlsheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A1").EntireColumn.ColumnWidth = 8
            xlsheet.Range("B1").EntireColumn.ColumnWidth = 20
            xlsheet.Range("C1").EntireColumn.ColumnWidth = 15
            xlsheet.Range("D1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("E1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("F1").EntireColumn.ColumnWidth = 35

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
#End Region
#Region "Datos Cliente"
    Sub Carga_Datos_Cliente()
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
    Sub Carga_Empresa()

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
                            .Descrp_Localidad = DR.Item("Localidad")
                            .municipio = DR.Item("Municipio")
                            .estado = DR.Item("Estado")
                            .pais = DR.Item("Pais")
                            .codigoPostal = DR.Item("codigoPostal")
                            .Pwd = DR.Item("PWD_Llave_Privada")
                            .Ruta_Llave = DR.Item("Llave_Privada")
                            .Ruta_Certificado = DR.Item("Certificado")
                            Emisor = DR.Item("Id_Emisor")
                            .email = DR.Item("Email")
                            '.Usuario_Email = DR.Item("Usuario_Email")
                            '.Pwd_Email = DR.Item("Pwd_Email")
                            '.Servidor_SMTP = DR.Item("Servidor_SMTP")
                            '.Puerto_SMTP = DR.Item("Puerto_SMTP")
                            Timbrado_Usr = DR.Item("Timbrado_Usr")
                            Timbrado_Pwd = DR.Item("Timbrado_Pwd")

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
    Private Sub Facturar_Recibos_Click(sender As Object, e As EventArgs) Handles Facturar_Recibos.Click
        Dim Id_Recibo As Integer = 0
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        'Verifica que se haya seleccionado un recibo
        Try
            Id_Recibo = Me.DataGridView1(columna, fila).Value
        Catch ex As Exception
            Exit Sub
        End Try
        'En caso de que el Id del recibo sea 0 o nulo se sale del proceso
        Try
            If Id_Recibo = 0 Then
                MessageBox.Show("Debe seleccionar un Recibo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView1.Focus()
                Exit Sub
            Else
                'Lee el estado actual del recibo y solo factura en caso de que ya este pagado y que la fecha del contrato sea mayor al 
                ' 01/01/2016 
                Dim Estado_Actual As String = Me.DataGridView1(2, fila).Value
                If Estado_Actual = "Cancelado" Then
                    MessageBox.Show("No se puede facturar este recibo ya que esta Cancelado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DataGridView1.Focus()
                    Exit Sub
                ElseIf Estado_Actual = "Recibo Facturado" Then
                    MessageBox.Show("Este Recibo ya tiene una factura registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DataGridView1.Focus()
                    Exit Sub
                Else
                    If Estado_Actual = "Recibo Pagado" Then
                        Dim DatosLeidos As Boolean = False

                        'si el recibo ya esta pagado pregunta una ultima vez si realmente desea facturar
                        Dim Respuesta As DialogResult = Nothing
                        Respuesta = MessageBox.Show("Desea facturar el recibo: " & Id_Recibo, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If Respuesta = System.Windows.Forms.DialogResult.Yes Then
                            Cont.Contrato = Me.DataGridView1(4, fila).Value
                            Concepto_Recibo = Me.DataGridView1(3, fila).Value
                            'Aqui carga el importe del recibo
                            Using Cx1 As New SqlConnection(CxSettings.ConnectionString)
                                Try
                                    Cx1.Open()
                                    SQL_Str = "Select Count(Id_Detalle_PlanPagos) as Mensualidades," &
                                        " Sum(Importe) as Total from Detalle_PlanPagos" &
                                        " where Id_Detalle_PlanPagos in (Select Id_Detalle_PlanPagos from Detalle_Recibos where Id_Recibo  = @Id_Recibo);" &
                                        " Select * from Recibos where Id_Recibo  = @Id_Recibo"
                                    Dim Cmd As New SqlCommand(SQL_Str, Cx1)
                                    Cmd.Parameters.AddWithValue("@Id_Recibo", Id_Recibo)
                                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                                    If DR.HasRows Then
                                        While DR.Read
                                            Gran_Total = DR.Item("Total")
                                            Gran_Subtotal = FormatNumber(Gran_Total / 1.16, 2)
                                        End While
                                        DR.NextResult()
                                        While DR.Read
                                            Metodo_Pago = DR.Item("Metodo_Pago")
                                            Cuenta_Pago = DR.Item("Cuenta_Pago")
                                        End While
                                        DatosLeidos = True
                                    Else
                                        MessageBox.Show("No se ha podido obtener el Importe del Recibo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    End If
                                Catch ex As SqlException
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                Finally
                                    If Cx1.State = ConnectionState.Open Then
                                        Cx1.Close()
                                    End If
                                End Try
                            End Using
                            If DatosLeidos = True Then
                                Carga_Datos_Contrato()
                                Carga_Datos_Cliente()
                                If Cont.Fecha_Alta < "01-01-2016" Then
                                    MessageBox.Show("No se pueden facturar recibos de contratos realizados antes del 01/01/2016", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                Else
                                    Facturar()

                                    If Recibo_Facturado = True Then
                                        Using Cx As New SqlConnection(CxSettings.ConnectionString)
                                            Try
                                                Dim FechaPago As Date = Me.DataGridView1(1, fila).Value
                                                Cx.Open()
                                                SQL_Str = "Actualiza_Recibo2"
                                                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                                                Cmd.CommandType = CommandType.StoredProcedure
                                                Cmd.Parameters.AddWithValue("@Id_Recibo", Id_Recibo)
                                                Cmd.Parameters.AddWithValue("@Fecha_Pago", FechaPago)
                                                Cmd.Parameters.AddWithValue("@Estado_Actual", "Recibo Facturado")
                                                Cmd.ExecuteNonQuery()
                                                Me.DataGridView1(2, fila).Value = "Recibo Facturado"
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
                                    End If
                                End If
                            End If

                        ElseIf Respuesta = System.Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("El Recibo debe de estar pagado para poder facturar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.DataGridView1.Focus()
                        Exit Sub
                    End If
                End If
            End If
            ' Carga_Datos()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub Facturar()
        Dim CERT_SIS As String = clEmpresa.Ruta_Certificado
        Dim CerNo As String
        Dim CerSAT As System.Security.Cryptography.X509Certificates.X509Certificate
        CerSAT = System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromCertFile(CERT_SIS)
        CerNo = StrReverse(System.Text.Encoding.ASCII.GetString(CerSAT.GetSerialNumber))
        Dim Fecha As String = DateTime.Now.ToString("yyyyMMddThhmmss").ToString
        Dim Folio_Actual As Integer = 0
        Dim _TipoDeCambio As String = Nothing
        _TipoDeCambio = ""
        Dim _Descuento As Decimal = 0
        Dim _motivoDescuento As String = ""
        Dim _FolioFiscalOriginal As String = ""
        Dim _SerieFolioFiscalOrig As String = ""
        Dim _FechaFolioFiscalOrig As Date = Nothing
        Dim _Aduana As String = Nothing
        Dim _FechaAduana As DateTime = Nothing
        Dim _AduanaPedimento As String = Nothing
        Dim Id_Conceptos As Integer = 63
        Dim Id_Concepto As Integer = 0
        Dim Guardar_Folio As Boolean = False
        Dim Serie As String = Nothing
        Dim Id_Comprobante As Integer = 0
        Using cx As New SqlConnection(CxSettings.ConnectionString)
            SQL_Str = "Select Max(CAST(folio as int)) from Comprobante Where Serie = 'A'; Select Serie from Series"
            Try
                cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, cx)
                Cmd.CommandType = CommandType.Text
                Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If DR.HasRows Then
                    While DR.Read
                        If IsDBNull(DR.Item(0)) Then
                            Folio_Actual = 0 + 1
                        Else
                            Folio_Actual = CInt(DR.Item(0)) + 1
                        End If
                    End While
                End If
                DR.NextResult()
                If DR.HasRows Then
                    While DR.Read
                        Serie = DR.Item(0)
                    End While
                End If
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cx.State = ConnectionState.Open Then
                    cx.Close()
                End If
            End Try
        End Using
        Dim Credito As Integer = 0
        Dim Condiciones_Pago As String = "Contado"
        If Condiciones_Pago = "Contado" Then
            Condiciones_Pago = "Contado"
        End If
        If Credito > 0 Then
            Condiciones_Pago = "Credito " & Credito & " dias"
        End If

        '//////////////////////////////////////////////////////////////////////
        '**********************************************************************
        'Aqui se crea el CFDI
        '**********************************************************************
        '//////////////////////////////////////////////////////////////////////
        Dim CFDs As New clsCFDIx.CFDx

        With CFDs
            .Comprobante(VersionCFD.CFDv3_2, Folio_Actual, FormatDateTime(Now, DateFormat.GeneralDate), Condiciones_Pago _
                          , Gran_Subtotal, Gran_Total, clsCFDIx.ComprobanteTipoDeComprobante.ingreso, Metodo_Pago _
                          , clEmpresa.pais, "A", _TipoDeCambio, Condiciones_Pago, _Descuento, _motivoDescuento, "M.N." _
                          , Cuenta_Pago, _FolioFiscalOriginal, _SerieFolioFiscalOrig, _FechaFolioFiscalOrig)
            .AgregaEmisor(clEmpresa.RFC, clEmpresa.Calle, clEmpresa.municipio, clEmpresa.estado, clEmpresa.pais, clEmpresa.codigoPostal,
                          clEmpresa.Razon_Social, clEmpresa.noExterior, clEmpresa.noInterior, clEmpresa.colonia, clEmpresa.Descrp_Localidad, clEmpresa.referencia)
            .AgregaReceptor(clCliente.RFC, clCliente.Razon_Social, clCliente.Calle, clCliente.municipio, clCliente.estado, clCliente.pais, clCliente.codigoPostal,
                            clCliente.noExterior, clCliente.noInterior, clCliente.colonia, clCliente.Descrp_Localidad, clCliente.referencia)
            .AgregaRegimenFiscal(clEmpresa.Regimen)
            'Dim Registros1 As Integer = Me.DataGridView1.RowCount
            Dim Registros1 As Integer = 1
            For i = 0 To Registros1 - 1
                Dim _Cantidad As Decimal = 0
                Dim _Descripcion As String = Nothing

                Dim _Clave As String = Nothing
                Dim _Unidad As String = Nothing
                Dim _valorUnitario As Decimal = 0
                Dim fila As Integer
                fila = i
                '_Cantidad = Me.DataGridView1(2, fila).Value
                '_Descripcion = Trim(Me.DataGridView1(1, fila).Value)
                '_Clave = Me.DataGridView1(0, fila).Value
                '_Unidad = Me.DataGridView1(3, fila).Value
                '_valorUnitario = Me.DataGridView1(4, fila).Value
                _Cantidad = 1
                If Concepto_Recibo = "1/1" Then
                    _Descripcion = "Pago por derecho de uso de nicho del contrato No " & Cont.Contrato
                Else
                    _Descripcion = "Pago mensual por derecho de uso de nicho del contrato No " & Cont.Contrato & " (" & Concepto_Recibo & ")"
                End If

                _Clave = "PMC-01"
                _Unidad = "N/A"
                _valorUnitario = Gran_Total

                .AgregaConcepto(_Cantidad, _Unidad, _Descripcion, _valorUnitario, _Clave)
            Next
            '.AgregaComprobanteImpuestoTraslado(clsCFDIx.ComprobanteImpuestosTrasladoImpuesto.IVA, (clProducto.Tasa - 1) * 100, Gran_Subtotal * (clProducto.Tasa - 1))
            .AgregaComprobanteImpuestoTraslado(clsCFDIx.ComprobanteImpuestosTrasladoImpuesto.IVA, (1.16 - 1) * 100, Gran_Subtotal * (1.16 - 1))
        End With
        Dim CertFile As String = clEmpresa.Ruta_Certificado
        Dim KeyFile As String = clEmpresa.Ruta_Llave
        Dim KeyPass As String = clEmpresa.Pwd
        Dim Errores As String = ""
        Dim _NombreArchivo As String = RutaSrv + "\Facturas\CFDI_A-" & Folio_Actual.ToString & ".xml"

        If CFDs.CreaFacturaXML(KeyFile, KeyPass, CertFile, Errores, _NombreArchivo, , eComplemento.Comprobante) = False Then
            MsgBox("Se encontraron los siguientes Errores:" & vbNewLine & Errores, MsgBoxStyle.Exclamation)
        Else
            Dim _error, _user, _pass, _uri As String
            _error = ""
            _user = Timbrado_Usr
            _pass = Timbrado_Pwd
            _uri = "https://cfdi.timbrado.com.mx/cfdi/wstimbrado.asmx"
            CFDs.TimbrarCFDI(_NombreArchivo, ePAC.ATEB, _user, _pass, _error, _uri)

            If _error <> "" Then
                MsgBox(_error)
                Exit Sub
            Else
                Guardar_Folio = True
                Recibo_Facturado = True
            End If

        End If

        If Guardar_Folio = True Then
            Dim PDF_File As New clsCFDIx.clsFormatoImpresion
            PDF_File.LlenaFormatoCfdiFactura(_NombreArchivo, clEmpresa.Logotipo, True, clsCFDIx.clsFormatoImpresion.eNavegador.iexplore,
                                             _NombreArchivo.Replace(".xml", ".html"))
            Using cx As New SqlConnection(CxSettings.ConnectionString)
                Try
                    'cx.Open()
                    'SQL_Str = "Select Max(Id_Conceptos) as ID from Conceptos"
                    Dim Cmd As New SqlCommand
                    'Dim Reader As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    'With Reader
                    '    If .HasRows Then
                    '        While .Read
                    '            If IsDBNull(Reader("Id")) Then
                    '                Id_Conceptos = 0
                    '            Else
                    '                Id_Conceptos = Reader("Id")
                    '            End If
                    '        End While
                    '    End If
                    '    .Close()
                    'End With
                    'Id_Conceptos = Id_Conceptos + 1
                    'Dim Registros2 As Integer = Me.DataGridView1.RowCount
                    'Dim Registros2 As Integer = 1
                    'For i = 0 To Registros2 - 1
                    '    Dim _Cantidad As Decimal = 0
                    '    Dim _Descripcion As String = Nothing
                    '    Dim _Clave As String = Nothing
                    '    Dim _Unidad As String = Nothing
                    '    Dim _valorUnitario As Decimal = 0
                    '    Dim fila As Integer
                    '    fila = i
                    '    _Cantidad = 1
                    '    _Descripcion = "Pago mensual por derecho de uso del contrato No " & Cont.Contrato & " (" & Concepto_Recibo & ")"
                    '    _Clave = "PMC-01"
                    '    _Unidad = "N/A"
                    '    _valorUnitario = Gran_Total
                    '    '//////////////////////////////////////////////////////////////////////
                    '    '**********************************************************************
                    '    'Primero agrego el concepto, leo el Id y lo agrego a Conceptos
                    '    '**********************************************************************
                    '    '//////////////////////////////////////////////////////////////////////
                    '    SQL_Str = "Insert into Concepto" &
                    '        " (cantidad, unidad, noIdentificacion, descripcion, valorUnitario, importe)" &
                    '        " Values(" & _Cantidad & ", '" & _Unidad & "', '" & _Clave & "', '" & _Descripcion & "', " & _valorUnitario & ", " & _Cantidad * _valorUnitario & ");" &
                    '        " Select @ConceptoID" & i & " = @@Identity"
                    '    If cx.State = ConnectionState.Closed Then
                    '        cx.Open()
                    '    End If
                    '    Cmd.CommandText = SQL_Str
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = SQL_Str
                    '    Cmd.Parameters.Add("@ConceptoID" & i, SqlDbType.Int)
                    '    Cmd.Parameters("@ConceptoID" & i).Direction = ParameterDirection.Output
                    '    Cmd.ExecuteNonQuery()
                    '    Id_Concepto = Cmd.Parameters("@ConceptoID" & i).Value.ToString() + 1
                    '    SQL_Str = "Insert into Conceptos (Id_Conceptos,Id_Concepto)Values (" & Id_Conceptos & " ," & Id_Concepto & ")"
                    '    Cmd.CommandText = SQL_Str
                    '    Cmd.CommandType = CommandType.Text
                    '    Cmd.CommandText = SQL_Str
                    '    Cmd.ExecuteNonQuery()
                    '    If cx.State = ConnectionState.Open Then
                    '        cx.Close()
                    '    End If
                    'Next

                    '////////////////////////////////////////////////////////////////////////////////
                    '********************************************************************************
                    'Leo los datos que me faltan directamente del XML
                    '********************************************************************************
                    '////////////////////////////////////////////////////////////////////////////////
                    Dim _Sello As String = Nothing
                    Dim _formaDePago As String = Nothing
                    Dim _noCertificado As String = Nothing
                    Dim _certificado As String = Nothing
                    Dim _condicionesDePago As String = Nothing
                    Dim _fecha As Date = Nothing

                    Try
                        Dim XMLreader As XmlTextReader = New XmlTextReader(_NombreArchivo)
                        XMLreader.WhitespaceHandling = WhitespaceHandling.None
                        XMLreader.Read()
                        XMLreader.Read()
                        _Sello = XMLreader.GetAttribute("sello")
                        _formaDePago = XMLreader.GetAttribute("formaDePago")
                        _noCertificado = XMLreader.GetAttribute("noCertificado")
                        _certificado = XMLreader.GetAttribute("certificado")
                        _condicionesDePago = XMLreader.GetAttribute("condicionesDePago")
                        _fecha = XMLreader.GetAttribute("fecha").ToString
                        _FechaFolioFiscalOrig = XMLreader.GetAttribute("FechaFolioFiscalOrig").ToString
                        _fecha = CDate(Mid(_fecha, 1, 10) + " " + Mid(_fecha, 12, 8))
                        _FechaFolioFiscalOrig = CDate(Mid(_fecha, 1, 10) + " " + Mid(_fecha, 12, 8))

                    Catch ex As Exception
                        MessageBox.Show("Error al intentar cargar el archivo xml," & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    If cx.State = ConnectionState.Closed Then
                        cx.Open()
                    End If
                    SQL_Str = "Insert into Comprobante(versionXML, serie, folio, fecha, sello, formaDePago, noCertificado, certificado, condicionesDePago," &
                        " subTotal, descuento, motivoDescuento, TipoCambio, Moneda, total, tipoDeComprobante, metodoDePago, LugarExpedicion, NumCtaPago, FolioFiscalOrig, SerieFolioFiscalOrig," &
                        " FechaFolioFiscalOrig, MontoFolioFiscalOrig, Id_Emisor, Id_Receptor, Id_Conceptos, Id_Impuestos,  Dias_Credito) " &
                        " Values(@versionXML, @serie, @folio, @fecha, @sello, @formaDePago, @noCertificado, @certificado, @condicionesDePago," &
                        " @subTotal, @descuento, @motivoDescuento, @TipoCambio, @Moneda, @total, @tipoDeComprobante, @metodoDePago, @LugarExpedicion, @NumCtaPago, @FolioFiscalOrig, @SerieFolioFiscalOrig," &
                        " @FechaFolioFiscalOrig, @MontoFolioFiscalOrig, @Id_Emisor, @Id_Receptor, @Id_Conceptos, @Id_Impuestos,  @Dias_Credito)"
                    Cmd.Connection = cx
                    Cmd.CommandText = SQL_Str
                    Cmd.CommandType = CommandType.Text
                    ' Cmd.Transaction = Transaccion
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@versionXML", "3.2")
                    Cmd.Parameters.AddWithValue("@serie", "A")
                    Cmd.Parameters.AddWithValue("@Folio", Folio_Actual)
                    Cmd.Parameters.AddWithValue("@fecha", _fecha)
                    Cmd.Parameters.AddWithValue("@sello", _Sello)
                    Cmd.Parameters.AddWithValue("@formaDePago", _formaDePago)
                    Cmd.Parameters.AddWithValue("@noCertificado", _noCertificado)
                    Cmd.Parameters.AddWithValue("@certificado", _certificado)
                    Cmd.Parameters.AddWithValue("@condicionesDePago", _condicionesDePago)
                    Cmd.Parameters.AddWithValue("@subTotal", CDec(Gran_Subtotal))
                    Cmd.Parameters.AddWithValue("@descuento", _Descuento)
                    Cmd.Parameters.AddWithValue("@motivoDescuento", _motivoDescuento)
                    Cmd.Parameters.AddWithValue("@TipoCambio", _TipoDeCambio)
                    Cmd.Parameters.AddWithValue("@Moneda", "M.N.")
                    Cmd.Parameters.AddWithValue("@tipoDeComprobante", "Ingreso")
                    Cmd.Parameters.AddWithValue("@metodoDePago", "No Identificado")
                    Cmd.Parameters.AddWithValue("@LugarExpedicion", "Mexico")
                    Cmd.Parameters.AddWithValue("@NumCtaPago", "")
                    Cmd.Parameters.AddWithValue("@FolioFiscalOrig", _FolioFiscalOriginal)
                    Cmd.Parameters.AddWithValue("@SerieFolioFiscalOrig", _SerieFolioFiscalOrig)
                    Cmd.Parameters.AddWithValue("@FechaFolioFiscalOrig", _FechaFolioFiscalOrig)
                    Cmd.Parameters.AddWithValue("@MontoFolioFiscalOrig", 0)
                    Cmd.Parameters.AddWithValue("@Id_Emisor", Emisor)
                    Cmd.Parameters.AddWithValue("@Id_Receptor", clCliente.Id_Receptor)
                    Cmd.Parameters.AddWithValue("@Id_Conceptos", Id_Conceptos)
                    Cmd.Parameters.AddWithValue("@Id_Impuestos", 1)
                    'Cmd.Parameters.AddWithValue("@Id_Complemento", Id_Complemento)
                    'Cmd.Parameters.AddWithValue("@Id_Addenda", 0)
                    Cmd.Parameters.AddWithValue("@Dias_Credito", 0)
                    Cmd.Parameters.AddWithValue("@total", CDec(Gran_Total))
                    Cmd.ExecuteNonQuery()

                    If cx.State = ConnectionState.Open Then
                        cx.Close()
                    End If

                    Dim PDF_Bytes As Byte()

                    PDF_Bytes = File.ReadAllBytes(_NombreArchivo.Replace(".xml", ".pdf"))
                    Temp_NobreArchivo = _NombreArchivo
                    Temp_FolioActual = Folio_Actual

                    'If File.Exists(RutaSrv + "\Facturas\CFDI_" & _NombreArchivo & ".pdf") Then
                    '    SQL_Str = "Insert into Facturas(Serie,Folio,PDF,XML) Values(@Serie,@Folio,@PDF,@XML)"
                    '    If cx.State = ConnectionState.Closed Then
                    '        cx.Open()
                    '    End If
                    '    Cmd.CommandText = SQL_Str
                    '    Cmd.CommandType = CommandType.Text
                    '    ' Cmd.Transaction = Transaccion
                    '    Cmd.CommandText = SQL_Str
                    '    Cmd.Parameters.AddWithValue("@serie", "A")
                    '    Cmd.Parameters.AddWithValue("@Folio", Folio_Actual)
                    '    Cmd.Parameters.AddWithValue("@PDF", PDF_Bytes)
                    '    Using xmlreader As New XmlTextReader("C:\Temporal\Archivo.xml")
                    '        ' Creamos el parámetro SqlXml
                    '        Dim param1 As New SqlXml(xmlreader)
                    '        ' Añadimos el parámetro al comando
                    '        Cmd.Parameters.AddWithValue("@XML", param1)
                    '    End Using
                    '    Cmd.ExecuteNonQuery()
                    'Else
                    '    Dim result As System.IO.WaitForChangedResult
                    '    Dim watcher As New System.IO.FileSystemWatcher(RutaSrv + "\Facturas\")
                    '    result = watcher.WaitForChanged(WatcherChangeTypes.Created)
                    '    If File.Exists(RutaSrv + "\Facturas\CFDI_" & _NombreArchivo & ".pdf") Then
                    '        SQL_Str = "Insert into Facturas(Serie,Folio,PDF,XML) Values(@Serie,@Folio,@PDF,@XML)"
                    '        If cx.State = ConnectionState.Closed Then
                    '            cx.Open()
                    '        End If
                    '        Cmd.CommandText = SQL_Str
                    '        Cmd.CommandType = CommandType.Text
                    '        ' Cmd.Transaction = Transaccion
                    '        Cmd.CommandText = SQL_Str
                    '        Cmd.Parameters.AddWithValue("@serie", "A")
                    '        Cmd.Parameters.AddWithValue("@Folio", Folio_Actual)
                    '        Cmd.Parameters.AddWithValue("@PDF", PDF_Bytes)
                    '        Using xmlreader As New XmlTextReader("C:\Temporal\Archivo.xml")
                    '            ' Creamos el parámetro SqlXml
                    '            Dim param1 As New SqlXml(xmlreader)
                    '            ' Añadimos el parámetro al comando
                    '            Cmd.Parameters.AddWithValue("@XML", param1)
                    '        End Using
                    '        Cmd.ExecuteNonQuery()
                    '    End If
                    'End If
                Catch ex As SqlException
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    If cx.State = ConnectionState.Open Then
                        cx.Close()
                    End If
                End Try
            End Using
            MsgBox("Su Factura ha sido Generada", MsgBoxStyle.Information)
        End If
        Me.Close()

    End Sub
    Dim PDF_Bytes As Byte()
    Dim Temp_NobreArchivo As String = Nothing
    Dim Temp_FolioActual As Integer = 0
    Sub GuardaPDF()

        Using cx As New SqlConnection(CxSettings.ConnectionString)
            Try
                Dim Cmd As New SqlCommand(SQL_Str, cx)
                If File.Exists(RutaSrv + "\Facturas\CFDI_" & Temp_NobreArchivo & ".pdf") Then
                    SQL_Str = "Insert into Facturas(Serie,Folio,PDF,XML) Values(@Serie,@Folio,@PDF,@XML)"
                    If cx.State = ConnectionState.Closed Then
                        cx.Open()
                    End If
                    Cmd.CommandText = SQL_Str
                    Cmd.CommandType = CommandType.Text
                    ' Cmd.Transaction = Transaccion
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@serie", "A")
                    Cmd.Parameters.AddWithValue("@Folio", Temp_FolioActual)
                    Cmd.Parameters.AddWithValue("@PDF", PDF_Bytes)
                    Using xmlreader As New XmlTextReader("C:\Temporal\Archivo.xml")
                        ' Creamos el parámetro SqlXml
                        Dim param1 As New SqlXml(xmlreader)
                        ' Añadimos el parámetro al comando
                        Cmd.Parameters.AddWithValue("@XML", param1)
                    End Using
                    Cmd.ExecuteNonQuery()
                Else
                    Dim result As System.IO.WaitForChangedResult
                    Dim watcher As New System.IO.FileSystemWatcher(RutaSrv + "\Facturas\")
                    result = watcher.WaitForChanged(System.IO.WatcherChangeTypes.Created)
                    If File.Exists(RutaSrv + "\Facturas\CFDI_" & Temp_NobreArchivo & ".pdf") Then
                        SQL_Str = "Insert into Facturas(Serie,Folio,PDF,XML) Values(@Serie,@Folio,@PDF,@XML)"
                        If cx.State = ConnectionState.Closed Then
                            cx.Open()
                        End If
                        Cmd.CommandText = SQL_Str
                        Cmd.CommandType = CommandType.Text
                        ' Cmd.Transaction = Transaccion
                        Cmd.CommandText = SQL_Str
                        Cmd.Parameters.AddWithValue("@serie", "A")
                        Cmd.Parameters.AddWithValue("@Folio", Temp_FolioActual)
                        Cmd.Parameters.AddWithValue("@PDF", PDF_Bytes)
                        Using xmlreader As New XmlTextReader("C:\Temporal\Archivo.xml")
                            ' Creamos el parámetro SqlXml
                            Dim param1 As New SqlXml(xmlreader)
                            ' Añadimos el parámetro al comando
                            Cmd.Parameters.AddWithValue("@XML", param1)
                        End Using
                        Cmd.ExecuteNonQuery()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cx.State = ConnectionState.Open Then
                    cx.Close()
                End If
            End Try

        End Using
    End Sub
#End Region
#Region "Codigo Complementario"
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
    Public Shared Function GetCadenaOriginal(ByVal xmlDoc As String, ByVal fileXSLT As String) As String
        Dim strCadenaOriginal As String
        Dim newFile = Path.GetTempFileName()
        Try
            Dim Xsl = New Xsl.XslCompiledTransform()
            Xsl.Load(fileXSLT)
            Xsl.Transform(xmlDoc, newFile)
            Xsl = Nothing

            Dim sr = New IO.StreamReader(newFile)
            strCadenaOriginal = sr.ReadToEnd
            sr.Close()

            'Eliminamos el archivo Temporal
            System.IO.File.Delete(newFile)

            fileXSLT = Nothing
            newFile = Nothing
            Xsl = Nothing
            sr.Dispose()

            Return strCadenaOriginal

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras As String = Nothing
        Dim entero As String = Nothing
        Dim dec As String = Nothing
        Dim flag As String = Nothing


        '********Declara variables de tipo entero***********
        Dim num As Integer = 0
        Dim x As Integer = 0
        Dim y As Integer = 0


        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & "con " & dec
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function
    Private Function CantidadLetra(ByVal value As Double) As String
        Dim Num2Text As String = Nothing
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
            Case 101 To 199 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case 201 To 999 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case 1001 To 1999 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case 2001 To 999999 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case 1000000 To 1999999 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case 2000000 To 999999999999 : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case 1000000000001.0# To 19999999999999 : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)

        End Select
        CantidadLetra = Num2Text

    End Function
    Private Function PrecioLetra(ByVal value As Decimal) As String
        Dim vEntero, vEntero2 As Integer
        Dim vDecimal As Decimal
        Dim vCadena1, vCadena2, vCadenaFinal As String

        vEntero = Math.Truncate(value)
        vDecimal = value - vEntero
        vCadena1 = Letras(vEntero)
        vEntero2 = Math.Truncate((vDecimal * 100))
        vCadena2 = vEntero2
        If vCadena2.Length = 1 Then
            vCadena2 = "0" & vCadena2
        End If
        vCadenaFinal = vCadena1 & " PESOS " & vCadena2 & "/100 M.N."

        Return vCadenaFinal
    End Function
    Function UltimoDiaMes(Fecha As Date) As Date
        UltimoDiaMes = DateSerial(Year(Fecha), Month(Fecha) + 1, 0)
    End Function
    Function PrimerDiaMes(Fecha As Date) As Date
        PrimerDiaMes = DateSerial(Year(Fecha), Month(Fecha), 1)
    End Function

    Private Sub ListadoRecibos_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'If GuardarPDF = True Then
        '    GuardaPDF()
        'End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Carga_Datos()
    End Sub
#End Region


End Class