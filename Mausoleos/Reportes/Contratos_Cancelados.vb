Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Configuration
Imports System.IO
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml
Imports System.Security
Imports System.Drawing
Imports clsCFDIx.CFDx
Imports clsTimbrado
Imports clsTimbrado.clsTimbradoATEB
Imports System.Globalization
Public Class Contratos_Cancelados
#Region "Variables"
    Public ConceptosList As List(Of Conceptos)
    ' Dim Auth As New mx.com.timbrado.cfdi.AuthenticationHeader
    'Dim ws As New mx.com.timbrado.cfdi.ServicioTimbradoPruebas

    Dim cfdi As String = ""
    Dim Sql_Str As String = Nothing
    Dim _TemporalID As Integer = 0
    Dim clProducto As New Conceptos_Class
    Dim clEmpresa As New ClassEmpresa
    Dim Timbrado_Usr As String = Nothing
    Dim Timbrado_Pwd As String = Nothing
    'Dim xmlFile As String = IO.Path.Combine(Application.StartupPath, "CFDv32 " & Today.ToString("yyyy-MMM-dd ss") & ".xml")
    Dim No_Pedido As String = Nothing
    Dim No_Proveedor As String = Nothing
    Dim No_Contrarecibo As String = Nothing
    Dim Contacto_Dpto As String = Nothing
    Dim GLN_Emisor As String = Nothing
    Dim GLN_Receptor As String = Nothing
    Dim Porcentaje_Descuento As Decimal = 0
    Dim Emisor As Integer = 0
    Dim Cliente_Actual As Integer = 0
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim Cont As New Contrato
    Dim Benef(8) As Beneficiarios_Class
    Dim Cli As New Cliente
    Dim Per As New Persona

    'Dim objApp As Object
    'Dim objBook As Excel._Workbook

    Dim _Id_Gaveta, _Id_Cliente, _Id_Empleado, _Id_Receptor, _Id_Domicilio As Integer
#End Region
    Private Sub Contratos_Cancelados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Vendedores()
        Carga_Localidades()
        Carga_Formas_Pago()
        Carga_Empresa()
        Carga_Datos_Contrato()
        'Me.ComboBox_Descuento.Text = 0
        Carga_Saldos()
        Sumar_Subtotales()
        Carga_SUD()
        Me.GroupBox1.Enabled = False
        Me.GroupBox3.Enabled = False
        Me.GroupBox4.Enabled = False
    End Sub
    Sub Carga_Saldos()
        Sql_Str = "Select Sum(Cast(Importe as decimal)) as Total from Detalle_PlanPagos " &
            " where  Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato)" &
            " and Id_Detalle_PlanPagos in (Select Id_detalle_PlanPagos from Detalle_Recibos where Id_Recibo in" &
            " (Select Id_Recibo from Recibos where Estado_Actual in ('Recibo Pagado','Recibo Facturado')));" &
            " Select SaldoInicial  from PlanPagos where Id_Contrato = @Id_Contrato;" &
            " Select Count(Id_Detalle_PlanPagos) as Total from Detalle_PlanPagos " &
            " where  Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato)" &
            " and Id_Detalle_PlanPagos in (Select Id_detalle_PlanPagos from Detalle_Recibos where Id_Recibo in" &
            " (Select Id_Recibo from Recibos where Estado_Actual in ('Recibo Pagado','Recibo Facturado')));" &
            " Select Count(Id_Detalle_PlanPagos) as Total from Detalle_PlanPagos " &
            " where Id_Detalle_PlanPagos not in (Select Id_detalle_PlanPagos from Detalle_Recibos where Id_Recibo in" &
            " (Select Id_Recibo from Recibos where Estado_Actual in ('Recibo Pagado','Recibo Facturado')))" &
            " and Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato)"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim dr As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.HasRows Then
                While dr.Read
                    If IsDBNull(dr.Item(0)) Then
                        Me.Label_Pagado.Text = 0
                    Else
                        Me.Label_Pagado.Text = FormatNumber(dr.Item(0), 2)
                    End If
                End While
            Else
                Me.Label_Pagado.Text = 0
            End If
            dr.NextResult()
            If dr.HasRows Then
                While dr.Read
                    Me.Label_SaldoInicial.Text = FormatNumber(dr.Item(0), 2)
                End While
            Else
                Me.Label_SaldoInicial.Text = 0
            End If
            dr.NextResult()
            If dr.HasRows Then
                While dr.Read
                    Me.Label_Mens_Pagadas.Text = dr.Item(0)
                End While
            Else
                Me.Label_Mens_Pagadas.Text = 0
            End If
            dr.NextResult()
            If dr.HasRows Then
                While dr.Read
                    Me.Label_Mens_Pendientes.Text = dr.Item(0)
                End While
            Else
                Me.Label_Mens_Pendientes.Text = "N/D"
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
        If Me.Label_SaldoInicial.Text = 0 Then
            Me.Label_SaldoActual.Text = FormatNumber(Me.Label_SaldoInicial.Text, 2)
        Else
            Me.Label_SaldoActual.Text = FormatNumber(Me.Label_SaldoInicial.Text - Me.Label_Pagado.Text, 2)
        End If
    End Sub
#Region "Carga Datos del Contrato"
    Sub Carga_Datos_Contrato()
        Me.Label_Contrato.Text = Id_Contrato
        Cont.Contrato = Id_Contrato
        'Aqui carga la informacion del contrato
        Sql_Str = "Select Id_Gaveta, Id_Cliente, Id_Empleado, Forma_Pago, Dia_Pago, LugarPago, Descuento,Motivo_Descuento,NumCtaPago,metodoDePago, Convert(date,Fecha_Alta,112) as Fecha_Alta from  Contratos where Id_Contrato = @Id_Contrato"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)

            If DR.HasRows Then
                While DR.Read
                    Me.DateTimePicker_FechaAlta.Value = New DateTime(CDate(DR.Item("Fecha_Alta")).Year, CDate(DR.Item("Fecha_Alta")).Month, CDate(DR.Item("Fecha_Alta")).Day)
                    _Id_Gaveta = DR.Item("Id_Gaveta")
                    _Id_Cliente = DR.Item("Id_Cliente")
                    _Id_Empleado = DR.Item("Id_Empleado")
                    Me.ComboBox_FormaPago.Text = DR.Item("Forma_Pago")
                    Me.ComboBox_DiaPago.Text = DR.Item("Dia_Pago")
                    Me.ComboBox_LugarPago.Text = DR.Item("LugarPago")
                    Me.ComboBox_Descuento.Text = DR.Item("Descuento")
                    Me.TextBox_MotivoDescuento.Text = DR.Item("Motivo_Descuento")
                    Me.TextBox_NumCta.Text = DR.Item("NumCtaPago")
                    Me.ComboBox_MetodoPago.Text = DR.Item("metodoDePago")
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
        Sql_Str = "Select Nombre, Sexo, CONVERT(date,Fecha_Nacimiento,112) as Fecha_Nacimiento, email, Id_REceptor, Tel_Particular, Celular, Observaciones from Personas where Id_Personas = @Id_Personas"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Personas", _Id_Cliente)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Me.TextBox1_NombreCte.Text = DR.Item("Nombre")
                    Me.ComboBox_Sexo.Text = DR.Item("Sexo")
                    Me.DateTimePicker_FechaNac.Value = DR.Item("Fecha_Nacimiento")
                    'Me.DateTimePicker_FechaNac.Value = New DateTime(CDate(DR.Item("Fecha_Nacimiento")).Year, CDate(DR.Item("Fecha_Nacimiento")).Month, CDate(DR.Item("Fecha_Nacimiento")).Day)
                    Me.TextBox_EmailCte.Text = DR.Item("email")
                    _Id_Receptor = DR.Item("Id_Receptor")
                    Me.TextBox_TelDomicilio.Text = DR.Item("Tel_Particular")
                    Me.TextBox_Celular.Text = DR.Item("Celular")
                    Me.TextBox_Observaciones.Text = DR.Item("Observaciones")
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
        Sql_Str = "Select * from  Receptor where Id_Receptor = @Id_Receptor"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Receptor", _Id_Receptor)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Me.TextBox_RFC.Text = DR.Item("rfc")
                    Me.TextBox_RazonSocial.Text = DR.Item("nombre")
                    _Id_Domicilio = DR.Item("Id_Domicilio")
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
        Sql_Str = "Select * from  Domicilio where Id_Domicilio = @Id_Domicilio"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Domicilio", _Id_Domicilio)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Me.TextBox_CalleCte.Text = DR.Item("calle")
                    Me.TextBox_NumExtCte.Text = DR.Item("noExterior")
                    Me.Textbox_NumInt.Text = DR.Item("noInterior")
                    Me.TextBox_ColoniaCte.Text = DR.Item("colonia")
                    Me.TextBox_CP.Text = DR.Item("codigoPostal")
                    Me.ComboBox_Localidad.SelectedValue = DR.Item("Id_Localidad")

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
        Sql_Str = "Select Estado from Estado where Id_Estado in (Select Id_Estado from Municipio where Id_Municipio in (Select Id_Municipio from Localidad where Id_Localidad = @Id_Localidad))"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Localidad", Me.ComboBox_Localidad.SelectedValue)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Cli.estado = DR.Item("Estado")

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
        'Aqui carga la informacion del Vendedor
        Sql_Str = "Select * from  Usuarios where Id_Usuarios = @Id_Usuarios"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Usuarios", _Id_Empleado)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Me.ComboBox_Agente.Text = DR.Item("Nombre")
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
        'Aqui carga la informacion del Nicho
        Sql_Str = "Select rtrim(ltrim(cast(Modulo as char(2)))) + '-' + rtrim(ltrim(cast(Columna as char(2)))) + '-' + Fila as MCF from  Gavetas where Id_Gaveta = @Id_Gaveta"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.Parameters.AddWithValue("@Id_Gaveta", _Id_Gaveta)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Label_Gaveta.Text = DR.Item(0)
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

        Carga_Beneficiarios()
        Carga_Ocupantes()
        Carga_PlanPagos()
        Carga_Servicios()
    End Sub

#End Region
    Function UltimoDiaMes(Fecha As Date) As Date
        UltimoDiaMes = DateSerial(Year(Fecha), Month(Fecha) + 1, 0)
    End Function
    Sub Carga_Beneficiarios()
        Try
            Cx.Open()
            Sql_Str = "Select Personas.Id_Personas as ID, Personas.Nombre, Parentescos.Parentesco, Beneficiarios.Observaciones, Beneficiarios.TitularSustituto as TS" &
                " From Personas , Parentescos, Beneficiarios " &
                " where Personas.id_Personas = Beneficiarios.Id_Persona and" &
                " Beneficiarios.Id_Contrato = @IdContrato and Beneficiarios.id_Parentesco = Parentescos.Id_Parentesco"
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@IdContrato", Id_Contrato)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.DataGridView_Beneficiarios
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
    End Sub
    Sub Carga_Servicios()
        Try
            Cx.Open()
            Sql_Str = "Select Clave,Unidad, Descripcion,Disponibles as Cantidad, valorUnitario as Precio from View_ListadoServicios where Id_Contrato = @Id_Contrato"
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.DataGridView_Servicios
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
    End Sub
    Sub Carga_PlanPagos()
        Try
            Cx.Open()
            Sql_Str = "Declare @TablaTemp Table(Id_Detalle_PlanPagos int,  Fecha_Vencimiento datetime2, Detalle nvarchar(100), Importe decimal(18,2))" &
                " Insert Into @TablaTemp Select Id_Detalle_PlanPagos as ID,  Fecha_Vencimiento as Fecha, Detalle, Importe  from Detalle_PlanPagos" &
                " Where Id_PlanPagos = (Select Id_PlanPagos from PlanPagos Where Id_Contrato = @Id_Contrato)" &
                " Declare @TablaRecibos Table (Fecha_Pago datetime2, Id_Detalle_PlanPagos int)" &
                " Insert into @TablaRecibos Select R.Fecha_Pago, DR.Id_Detalle_PlanPagos from Recibos as R, Detalle_Recibos as DR Where r.Id_Recibo = dr.Id_Recibo and r.Estado_Actual in ('Recibo Pagado','Recibo Facturado')" &
                " Select TT.Id_Detalle_PlanPagos as ID, TT.Detalle as Concepto, TT.Fecha_Vencimiento as Vencimiento, TR.Fecha_Pago as Pagado, TT.Importe " &
                " From @TablaTemp as TT" &
                " Left JOIN @TablaRecibos as TR on TT.Id_Detalle_PlanPagos= TR.Id_Detalle_PlanPagos" &
                " Order by TT.Id_Detalle_PlanPagos"
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.DataGridView_PlanPagos
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
    Sub Sumar_Subtotales()
        Dim Subtotal As Decimal = 0
        Dim Subtotal1 As Decimal = 0
        With Me.DataGridView_Servicios
            Dim Registros As Integer = .RowCount
            For i = 0 To Registros - 1
                Dim columna As Integer, fila As Integer
                columna = 4
                fila = i
                Subtotal = Subtotal + (Me.DataGridView_Servicios(columna, fila).Value * Me.DataGridView_Servicios(columna - 1, fila).Value)
            Next
        End With
        Subtotal1 = Subtotal / 1.16
        Me.Label_Subtotal_sin_Descuento.Text = Subtotal1
        If Me.ComboBox_Descuento.Text >= 1 Then
            Subtotal1 = Subtotal1 - ((CDbl(Me.ComboBox_Descuento.Text) * Subtotal1) / 100)
        End If
        Me.Label_Gran_Subtotal.Text = FormatNumber(Subtotal1, 2)
        Me.Label_Gran_IVA.Text = FormatNumber(((16 * CDec(Me.Label_Gran_Subtotal.Text)) / 100), 2)
        Me.Label_Gran_Total.Text = FormatNumber(CDec(Me.Label_Gran_Subtotal.Text) + CDec(Me.Label_Gran_IVA.Text), 2)
    End Sub
    Sub Carga_Ocupantes()
        Try
            Cx.Open()
            Sql_Str = "Select Personas.Id_Personas as ID, Personas.Nombre, Ocupantes.fecha_Defuncion, Ocupantes.fecha_Ingreso" &
                " From Personas, Ocupantes where Personas.id_Personas = Ocupantes.Id_Persona and  Ocupantes.Id_Contrato = @IdContrato"
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@IdContrato", Id_Contrato)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.DataGridView_Ocupantes
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
    End Sub
#Region "Carga Informacion General"
    Sub Carga_Vendedores()
        Try
            Sql_Str = "Select * from Usuarios where Activo = 'True'"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.ComboBox_Agente
                .DataSource = DS.Tables("Tabla")
                .DisplayMember = "Nombre"
                .ValueMember = "Id_Usuarios"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub
    Sub Carga_Localidades()
        Try
            Sql_Str = "Select * from Localidad"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.ComboBox_Localidad
                .DataSource = DS.Tables("Tabla")
                .DisplayMember = "Localidad"
                .ValueMember = "Id_Localidad"
            End With
            Me.ComboBox_Localidad.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub
    Sub Carga_Formas_Pago()
        Try
            Sql_Str = "Select * from Formas_Pago"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.ComboBox_FormaPago
                .DataSource = DS.Tables("Tabla")
                .DisplayMember = "Forma_Pago"
                .ValueMember = "Id_Formas_Pago"
            End With
            Me.ComboBox_Localidad.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub
    Sub Carga_Empresa()

        Using Cx As New SqlConnection(CxSettings.ConnectionString)

            Sql_Str = "SELECT Empresa.Id_Emisor, Empresa.Logotipo, Empresa.Email, Empresa.Pwd_Llave_Privada, Empresa.Llave_Privada, Empresa.Certificado, " &
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
                Dim Cmd As New SqlCommand(Sql_Str, Cx)
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
            Sql_Str = "Select * from RegimenFiscal where id_RegimenFiscal in (Select id_RegimenFiscal from RegimenXEmisor where id_Emisor = @Id_Emisor)"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(Sql_Str, Cx)
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
#End Region
    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        If TabControl1.SelectedTab Is TabPage2 Then

            Pinta_Grid()
        End If
    End Sub
    Sub Carga_SUD()

        Try
            Cx.Open()
            Sql_Str = "Select SUD.Id_SUD, S.Servicio, SUD.Disponibles as Total, SUD.Utilizados, (SUD.Disponibles - SUD.Utilizados) as Disponibles" &
                " from Servicios_UtilizadosyDisponibles as SUD, Servicios as S" &
                " Where SUD.Id_Contrato = @Id_Contrato and SUD.Id_Servicio = S.Id_Servicio"
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView_SUD.DataSource = DS.Tables("Tabla")

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
#Region "Pinta Grid"
    Sub Pinta_Grid()
        ' Primero pinta los Recibos Pagados y luego los recibos vencidos
        Sql_Str = "Select Id_Detalle_PlanPagos as ID" &
            " from Detalle_PlanPagos Where Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato) " &
            " and Id_Detalle_PlanPagos in(Select Id_Detalle_PlanPagos from Detalle_Recibos Where " &
            " Id_Recibo in(Select Id_Recibo from Recibos Where Estado_Actual in ('Recibo Pagado','Recibo Facturado')))"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Dim ID As Integer = 0
            Dim TotalFilas_Recibos As Integer = Me.DataGridView_PlanPagos.RowCount
            If DR.HasRows Then
                While DR.Read
                    ID = DR.Item(0)
                    For Each Row As DataGridViewRow In DataGridView_PlanPagos.Rows
                        If Row.Cells(0).Value = ID Then
                            'DataGridView_PlanPagos.RowTemplate.DefaultCellStyle.BackColor = Color.LightGreen
                            Row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen
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
        Sql_Str = "Select Id_Detalle_PlanPagos as ID" &
            " from Detalle_PlanPagos Where Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato) " &
            " and Id_Detalle_PlanPagos in(Select Id_Detalle_PlanPagos from Detalle_Recibos Where " &
            " Id_Recibo in(Select Id_Recibo from Recibos Where Estado_Actual = 'Recibo Generado'))" &
            " and DATEDIFF(mm, Fecha_Vencimiento, GETDATE()) >1 "
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Dim ID As Integer = 0
            Dim TotalFilas_Recibos As Integer = Me.DataGridView_PlanPagos.RowCount

            If DR.HasRows Then
                While DR.Read
                    ID = DR.Item(0)
                    For Each Row As DataGridViewRow In DataGridView_PlanPagos.Rows
                        If Row.Cells(0).Value = ID Then
                            Row.DefaultCellStyle.BackColor = System.Drawing.Color.Red
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
#End Region

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim DireccionImagenLogo As String = Nothing
        Try
            Cx.Open()
            Sql_Str = "Select * from Empresa"
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
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
            xlsheet.Range("A2").Value = "Plan de Pagos"
            xlsheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            xlsheet.Range("A2:E3").Merge()
            xlsheet.Range("A2:E3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )

            xlsheet.Range("A4").Font.Bold = True
            xlsheet.Range("A4").Font.Size = 12
            xlsheet.Range("A4").Value = "Contrato Cancelado " & Id_Contrato
            xlsheet.Range("A5").Font.Bold = True
            xlsheet.Range("A5").Font.Size = 12
            xlsheet.Range("A5").Value = "Contratante " & Me.TextBox1_NombreCte.Text
            xlsheet.Range("A6").Font.Bold = True
            xlsheet.Range("A6").Font.Size = 12
            xlsheet.Range("A6").Value = "Saldo Inicial " & Me.Label_SaldoInicial.Text
            xlsheet.Range("A7").Font.Bold = True
            xlsheet.Range("A7").Font.Size = 12
            xlsheet.Range("A7").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            xlsheet.Range("A7").Value = "Total Pagado " & Me.Label_Pagado.Text
            xlsheet.Range("A8").Font.Bold = True
            xlsheet.Range("A8").Font.Size = 12
            xlsheet.Range("A8").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            xlsheet.Range("A8").Value = "Saldo Actual " & Me.Label_SaldoActual.Text

            xlsheet.Cells(10, 1).Formula = "ID"
            xlsheet.Cells(10, 2).Formula = "Mensualidad"
            xlsheet.Cells(10, 3).Formula = "Fecha Vencimiento"
            xlsheet.Cells(10, 4).Formula = "Fecha Pago"
            xlsheet.Cells(10, 5).Formula = "Importe"
            xlsheet.Range("A10:E10").Font.Bold = True
            xlsheet.Range("A10:E10").Interior.ColorIndex = 16
            xlsheet.Range("A10:E10").Font.Size = 11
            xlsheet.Range("A10:E10").Borders().Color = 0
            xlsheet.Range("A10:E10").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            xlsheet.Range("A10:E10").Borders().Weight = 2
            xlsheet.Range("A10:E10").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Dim R As String = "A10:A" + CInt(DataGridView_PlanPagos.RowCount + 5).ToString
            xlsheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("B1").EntireColumn.ColumnWidth = 20
            xlsheet.Range("C1").EntireColumn.ColumnWidth = 30
            xlsheet.Range("D1").EntireColumn.ColumnWidth = 30
            xlsheet.Range("E1").EntireColumn.ColumnWidth = 20

            'Aqui obtengo el tamaño del datagrid y lo copio al excel
            Dim DGRows As Integer = Me.DataGridView_PlanPagos.RowCount
            Dim DGCols As Integer = Me.DataGridView_PlanPagos.ColumnCount
            range = xlsheet.Range("A11", Reflection.Missing.Value)
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
            For iRow = 0 To DataGridView_PlanPagos.RowCount - 1
                For iCol = 0 To DataGridView_PlanPagos.ColumnCount - 1
                    saRet(iRow, iCol) = DataGridView_PlanPagos.Rows(iRow).Cells(iCol).Value.ToString
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