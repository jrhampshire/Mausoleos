Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.IO
Public Class Cobranza2
#Region "Variables"
    Dim SQL_Str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim Id_Recibo As String = Nothing
    Dim Metodo_Pago As String = Nothing
    Dim Cuenta_Pago As String = ""
#End Region
#Region "Datos Generales del Cliente"
    Private Sub TextBox_Contrato_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Contrato.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Trim(TextBox_Contrato.Text) = "" Then
                Exit Sub
            Else
                Id_Contrato = Trim(TextBox_Contrato.Text)
                Carga_Datos_Cliente()
            End If
        End If
    End Sub
    Private Sub Button_BuscaContrato_Click(sender As Object, e As EventArgs) Handles Button_BuscaContrato.Click
        Dim frm As New Listado_Contratos
        frm.ShowDialog()
        TextBox_Contrato.Text = Id_Contrato
        If Trim(TextBox_Contrato.Text) = "" Then
            Exit Sub
        Else
            Carga_Datos_Cliente()
        End If
    End Sub
    Sub Carga_Datos_Cliente()
        SQL_Str = "SELECT        Contratos.Id_Contrato, Receptor.nombre, Receptor.rfc," &
            " Plantas.Planta, Ubicaciones.Ubicacion + '-' + rtrim(ltrim(cast(Gavetas.Modulo as Char(2)))) + '-' + rtrim(ltrim(cast(Gavetas.Columna as Char(2)))) + '-' + Gavetas.Fila AS Ubicacion, (Domicilio.Calle + ' No.' + Domicilio.noExterior + ' ' + " &
            " Domicilio.noInterior) as Direccion, (Domicilio.colonia + ' C.P. ' + Domicilio.codigoPostal) as Colonia, Localidad.Localidad" &
            " FROM Personas INNER JOIN" &
            " Domicilio INNER JOIN" &
            " Receptor ON Domicilio.ID_Domicilio = Receptor.Id_Domicilio INNER JOIN" &
            " Localidad ON Domicilio.Id_localidad = Localidad.ID_Localidad ON Personas.Id_Receptor = Receptor.ID_Receptor INNER JOIN" &
            " Contratos INNER JOIN" &
            " Gavetas ON Contratos.Id_Gaveta = Gavetas.Id_Gaveta INNER JOIN" &
            " Plantas ON Gavetas.Id_Planta = Plantas.Id_Planta INNER JOIN" &
            " Ubicaciones ON Gavetas.Id_Ubicacion = Ubicaciones.Id_Ubicacion ON Personas.ID_Personas = Contratos.Id_Cliente" &
            " WHERE (Contratos.Id_Contrato = @Id_Contrato)"

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Me.Label_NombreCte.Text = DR.Item(1)
                    Me.Label_RFC.Text = DR.Item(2)
                    Dim Piso As String = DR.Item(3)
                    If Piso = "Planta Baja" Then
                        Piso = "PB"
                    End If
                    Me.Label_Ubicacion.Text = Piso & "-" & DR.Item(4)
                    Me.Label_Direccion.Text = DR.Item(5)
                    Me.Label_Colonia.Text = DR.Item(6)
                    Me.Label_Localidad.Text = DR.Item(7)
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
#End Region
#Region "Datos de pagos"
    Private Sub Button_SeleccionarPagos_Click(sender As Object, e As EventArgs) Handles Button_SeleccionarPagos.Click
        Dim Frm As New PagosPendientes2
        Frm.ShowDialog()
    End Sub
#End Region
    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        Guarda_Datos()
    End Sub

    Sub Guarda_Datos()
        Dim Total_Recibos As Integer = ID_Recibos.Count
        Dim Fecha_Pago As Date = Nothing
        Fecha_Pago = Me.DateTimePicker1.Value
        Try
            Metodo_Pago = Me.ComboBox_Metodo_Pago.Text
        Catch ex As Exception
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Metodo_Pago.Focus()
            Exit Sub
        End Try
        Cuenta_Pago = Trim(TextBox_Cuenta.Text)
        If IsDBNull(Cuenta_Pago) Then
            Cuenta_Pago = ""
        End If
        If Total_Recibos > 1 Then
            ' Id_Recibo = String.Join(", ", ID_Recibos.ToArray())
            Dim Pasada As Integer = 1
            Do While Pasada <= Total_Recibos
                Id_Recibo = ID_Recibos(Pasada - 1)
                Try
                    Cx.Open()
                    SQL_Str = "Actualiza_Recibo3"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.AddWithValue("@Id_Recibo", Id_Recibo)
                    Cmd.Parameters.AddWithValue("@Fecha_Pago", Fecha_Pago)
                    Cmd.Parameters.AddWithValue("@Estado_Actual", "Recibo Pagado")
                    Cmd.Parameters.AddWithValue("@Metodo_Pago", Metodo_Pago)
                    Cmd.Parameters.AddWithValue("@Cuenta_Pago", Cuenta_Pago)
                    Cmd.ExecuteNonQuery()
                    ' Me.Close()
                Catch ex As SqlException
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
                Pasada = Pasada + 1
            Loop
        Else
            Id_Recibo = ID_Recibos(0)
            Try
                Cx.Open()
                SQL_Str = "Actualiza_Recibo3"
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@Id_Recibo", Id_Recibo)
                Cmd.Parameters.AddWithValue("@Fecha_Pago", Fecha_Pago)
                Cmd.Parameters.AddWithValue("@Estado_Actual", "Recibo Pagado")
                Cmd.Parameters.AddWithValue("@Metodo_Pago", Metodo_Pago)
                Cmd.Parameters.AddWithValue("@Cuenta_Pago", Cuenta_Pago)
                Cmd.ExecuteNonQuery()
               ' Me.Close()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End If
        Me.Close()

    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()

    End Sub


End Class