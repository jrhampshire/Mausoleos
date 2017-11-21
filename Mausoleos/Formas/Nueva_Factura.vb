Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml
Imports System.Security
Imports System.Windows.Forms
Imports System.Drawing
Imports clsCFDIx
Imports clsCFDIx.CFDx
Imports clsTimbrado
Imports clsTimbrado.clsTimbradoATEB
Imports System.Data.SqlTypes

Public Class Nueva_Factura
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public ConceptosList As List(Of Conceptos)
    Dim cfdi As String = ""
    Dim clCliente As New Cliente
    Dim Sql_Str As String = Nothing
    Dim _TemporalID As Integer = 0
    Dim clProducto As New Conceptos_Class
    Dim clEmpresa As New ClassEmpresa
    Dim Timbrado_Usr As String = Nothing
    Dim Timbrado_Pwd As String = Nothing
    Dim xmlFile As String = IO.Path.Combine(Application.StartupPath, "CFDv32 " & Today.ToString("yyyy-MMM-dd ss") & ".xml")
    Dim No_Pedido As String = Nothing
    Dim No_Proveedor As String = Nothing
    Dim No_Contrarecibo As String = Nothing
    Dim Contacto_Dpto As String = Nothing
    Dim GLN_Emisor As String = Nothing
    Dim GLN_Receptor As String = Nothing
    Dim Porcentaje_Descuento As Decimal = 0
    Dim Emisor As Integer = 0
    Dim Cliente_Actual As Integer = 0
#End Region
#Region "CargaDeDatos"
    Private Sub Nueva_Factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If isOnline() = False Then
            MessageBox.Show("Para facturar se requiere una conexion a internet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
        Carga_Clientes()
        Carga_Empresa()

        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Sql_Str = "Insert into TemporalID (fecha) values (@fecha);" &
                " Select @ID = @@Identity"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(Sql_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@fecha", Now)
                Cmd.Parameters.Add("@ID", SqlDbType.Int)
                Cmd.Parameters("@ID").Direction = ParameterDirection.Output
                Cmd.ExecuteNonQuery()
                _TemporalID = Cmd.Parameters("@ID").Value.ToString
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
#Region "Productos a Facturar"
    Sub Carga_Concepto()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Total As Integer = 0
            Sql_Str = "Select Count(id_ProductosyServicios) as Total from ProductosyServicios where Clave = @Clave and Activo = 'true'"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(Sql_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Clave", Trim(Me.TextBox_Clave.Text))
                Total = Cmd.ExecuteScalar
                If Total < 1 Then Exit Sub
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
            Sql_Str = "SELECT ProductosyServicios.Descripcion, ProductosyServicios.Clave, ProductosyServicios.valorUnitario, " &
                " Unidades.Descripcion AS Unidad , Familias.tasa FROM Unidades INNER JOIN " &
                " ProductosyServicios ON Unidades.Id_Unidad = ProductosyServicios.Id_Unidad  INNER JOIN" &
                " Familias ON ProductosyServicios.Id_Familia = Familias.Id_Familia" &
                " WHERE (ProductosyServicios.Clave = @Clave) and (ProductosyServicios.Activo = 'True')"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(Sql_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Clave", Trim(Me.TextBox_Clave.Text))
                Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)

                If DR.HasRows Then
                    While DR.Read
                        With clProducto
                            .Descripcion = DR.Item("Descripcion")
                            .Cantidad = 1
                            .Clave = DR.Item("Clave")
                            .Precio = CDbl(DR.Item("valorUnitario"))
                            .Tasa = CDbl(DR.Item("Tasa"))
                        End With
                    End While
                    Me.Label_Descripcion.Text = clProducto.Descripcion
                    Me.TextBox_Clave.Text = clProducto.Clave
                    Me.TextBox_Cantidad.Text = clProducto.Cantidad
                    Me.TextBox_Precio.Text = clProducto.Precio
                    Me.Label_SubTotal.Text = clProducto.Subtotal
                    Me.Label_IVA.Text = clProducto.Impuesto
                    Me.Label_Total.Text = clProducto.Total
                    Me.TextBox_Cantidad.Focus()
                    Me.TextBox_Cantidad.SelectAll()

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
    Private Sub TextBox_Clave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Clave.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Carga_Articulo()
        End If
    End Sub
    Sub Carga_Articulo()
        Dim Clave As String = Nothing
        Clave = Trim(Me.TextBox_Clave.Text)
        If Clave = "" Then
            Dim Frm As New Cargar_ProductosyServicios
            Frm.ShowDialog()
        Else
            Carga_Concepto()
        End If
    End Sub
    Private Sub Button_Agregar_Articulo_Click(sender As Object, e As EventArgs) Handles Button_Agregar_Articulo.Click


        Agrega_Producto_a_Listado()
        Carga_Productos_Datagrid()
        Sumar_Subtotales()
    End Sub
    Sub Carga_Productos_Datagrid()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Try
                Sql_Str = "SELECT ProductosyServicios.Clave, ProductosyServicios.Descripcion,  Productos_x_Facturar.Cantidad," &
                    " Unidades.Descripcion AS Unidad,ProductosyServicios.valorUnitario," &
                    " (Productos_x_Facturar.Cantidad *ProductosyServicios.valorUnitario) as Subtotal " &
                    " FROM TemporalID INNER JOIN" &
                    " Productos_x_Facturar ON TemporalID.Id_TemporalID = Productos_x_Facturar.Id_TemporalID INNER JOIN" &
                    " Unidades INNER JOIN" &
                    " ProductosyServicios ON Unidades.Id_Unidad = ProductosyServicios.Id_Unidad ON Productos_x_Facturar.Clave = ProductosyServicios.Clave" &
                    " WHERE        (TemporalID.Id_TemporalID = @TemporalID) and (ProductosyServicios.Activo = 'True')"
                Cx.Open()
                Dim Cmd As New SqlCommand(Sql_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@TemporalID", _TemporalID)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Tabla")
                With DataGridView1
                    .DataSource = DS.Tables("Tabla")
                End With
                Me.TextBox_Clave.Text = ""
                Me.Label_Descripcion.Text = ""
                Me.TextBox_Cantidad.Text = ""
                Me.TextBox_Precio.Text = ""
                Me.Label_SubTotal.Text = ""
                Me.Label_IVA.Text = ""
                Me.Label_Total.Text = ""
                Me.TextBox_Clave.Focus()

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
    Private Sub Button_Concepto_Click(sender As Object, e As EventArgs) Handles Button_Concepto.Click
        Dim Frm As New Cargar_ProductosyServicios
        Frm.ShowDialog()
        Me.TextBox_Clave.Text = Producto
        Carga_Concepto()
    End Sub
    Sub Sumar_Subtotales()
        Dim Subtotal As Decimal = 0
        With Me.DataGridView1
            Dim Registros As Integer = .RowCount

            For i = 0 To Registros - 1
                Dim columna As Integer, fila As Integer
                columna = 5
                fila = i
                Subtotal = Subtotal + Me.DataGridView1(columna, fila).Value
            Next
        End With
        Me.Label_Gran_Subtotal.Text = FormatNumber(Subtotal, 2)
        Me.Label_Gran_IVA.Text = FormatNumber(Subtotal * (clProducto.Tasa - 1), 2)
        Me.Label_Gran_Total.Text = FormatNumber(CDec(Me.Label_Gran_Subtotal.Text) + CDec(Me.Label_Gran_IVA.Text), 2)
    End Sub
    Sub Agrega_Producto_a_Listado()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)

            Try
                Cx.Open()
                Sql_Str = "Insert into Productos_x_Facturar (Id_TemporalID, Clave,Cantidad)" &
                    " Values(@Id_TemporalID, @Clave, @Cantidad)"
                Dim Cmd As New SqlCommand(Sql_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Id_TemporalID", _TemporalID)
                Cmd.Parameters.AddWithValue("@Clave", clProducto.Clave)
                Cmd.Parameters.AddWithValue("@Cantidad", clProducto.Cantidad)
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
        End Using
    End Sub
#End Region
#Region "Datos Cliente"
    Sub Carga_Datos_Cliente()

        Try
            Cliente_Actual = Me.ComboBox_Cliente.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Sql_Str = "SELECT Receptor.nombre, Receptor.rfc, Domicilio.calle, Domicilio.noExterior," &
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
                Dim Cmd As New SqlCommand(Sql_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Cliente_Actual", Cliente_Actual)
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
                Me.Label_RFC.Text = clCliente.RFC
                Me.Label_Direccion.Text = clCliente.Calle & " " & clCliente.noExterior & " " & clCliente.noInterior & " C.P." & clCliente.codigoPostal
                Me.Label_Direccion2.Text = clCliente.Descrp_Localidad & ", " & clCliente.estado & ", " & clCliente.pais
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
    Private Sub ComboBox_Cliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Cliente.SelectedIndexChanged
        Carga_Datos_Cliente()
    End Sub
    Sub Carga_Clientes()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Sql_Str = "Select * From Receptor Order by Nombre"

            Try
                Dim DA As New SqlDataAdapter(Sql_Str, Cx)
                Dim DS As New DataSet
                DA.Fill(DS, "Receptor")
                With Me.ComboBox_Cliente
                    .DataSource = DS.Tables("Receptor")
                    .DisplayMember = "Nombre"
                    .ValueMember = "Id_Receptor"
                End With
                Me.ComboBox_Cliente.Text = ""
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
#Region "Factura"
    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
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
        Dim Id_Conceptos As Integer = 0
        Dim Id_Concepto As Integer = 0
        Dim Guardar_Folio As Boolean = False
        Dim Serie As String = Nothing
        Dim Id_Comprobante As Integer = 0
        Using cx As New SqlConnection(CxSettings.ConnectionString)
            Sql_Str = "Select Max(CAST(folio as int)) from Comprobante Where Serie = 'A'; Select Serie from Series"
            Try
                cx.Open()
                Dim Cmd As New SqlCommand(Sql_Str, cx)
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
                          , Me.Label_Gran_Subtotal.Text, Me.Label_Gran_Total.Text, clsCFDIx.ComprobanteTipoDeComprobante.ingreso, ComboBox_Metodo_Pago.Text _
                          , clEmpresa.pais, "A", _TipoDeCambio, Condiciones_Pago, _Descuento, _motivoDescuento, "M.N." _
                          , Trim(TextBox_Cuenta.Text), _FolioFiscalOriginal, _SerieFolioFiscalOrig, _FechaFolioFiscalOrig)
            .AgregaEmisor(clEmpresa.RFC, clEmpresa.Calle, clEmpresa.municipio, clEmpresa.estado, clEmpresa.pais, clEmpresa.codigoPostal,
                          clEmpresa.Razon_Social, clEmpresa.noExterior, clEmpresa.noInterior, clEmpresa.colonia, clEmpresa.Descrp_Localidad, clEmpresa.referencia)
            .AgregaReceptor(clCliente.RFC, clCliente.Razon_Social, clCliente.Calle, clCliente.municipio, clCliente.estado, clCliente.pais, clCliente.codigoPostal,
                            clCliente.noExterior, clCliente.noInterior, clCliente.colonia, clCliente.Descrp_Localidad, clCliente.referencia)
            .AgregaRegimenFiscal(clEmpresa.Regimen)
            Dim Registros1 As Integer = Me.DataGridView1.RowCount
            For i = 0 To Registros1 - 1
                Dim _Cantidad As Decimal = 0
                Dim _Descripcion As String = Nothing
                Dim _Clave As String = Nothing
                Dim _Unidad As String = Nothing
                Dim _valorUnitario As Decimal = 0
                Dim fila As Integer
                fila = i
                _Cantidad = Me.DataGridView1(2, fila).Value
                _Descripcion = Trim(Me.DataGridView1(1, fila).Value)
                _Clave = Me.DataGridView1(0, fila).Value
                _Unidad = Me.DataGridView1(3, fila).Value
                _valorUnitario = Me.DataGridView1(4, fila).Value
                .AgregaConcepto(_Cantidad, _Unidad, _Descripcion, _valorUnitario, _Clave)
            Next
            .AgregaComprobanteImpuestoTraslado(clsCFDIx.ComprobanteImpuestosTrasladoImpuesto.IVA, (clProducto.Tasa - 1) * 100, Me.Label_Gran_Subtotal.Text * (clProducto.Tasa - 1))

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
            Guardar_Folio = True
            If _error <> "" Then
                MsgBox(_error)
                Exit Sub
            End If

        End If



        If Guardar_Folio = True Then
            Dim PDF_File As New clsCFDIx.clsFormatoImpresion
            PDF_File.LlenaFormatoCfdiFactura(_NombreArchivo, clEmpresa.Logotipo, True, clsCFDIx.clsFormatoImpresion.eNavegador.iexplore,
                                             _NombreArchivo.Replace(".xml", ".html"))
            Using cx As New SqlConnection(CxSettings.ConnectionString)
                Try
                    cx.Open()
                    Sql_Str = "Select Max(Id_Conceptos) as ID from Conceptos"
                    Dim Cmd As New SqlCommand(Sql_Str, cx)
                    Dim Reader As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With Reader
                        If .HasRows Then
                            While .Read
                                If IsDBNull(Reader("Id")) Then
                                    Id_Conceptos = 0
                                Else
                                    Id_Conceptos = Reader("Id")
                                End If
                            End While
                        End If
                        .Close()
                    End With
                    Id_Conceptos = Id_Conceptos + 1

                    Dim Registros2 As Integer = Me.DataGridView1.RowCount
                    For i = 0 To Registros2 - 1
                        Dim _Cantidad As Decimal = 0
                        Dim _Descripcion As String = Nothing
                        Dim _Clave As String = Nothing
                        Dim _Unidad As String = Nothing
                        Dim _valorUnitario As Decimal = 0
                        Dim fila As Integer
                        fila = i
                        _Cantidad = Me.DataGridView1(2, fila).Value
                        _Descripcion = Me.DataGridView1(1, fila).Value
                        _Clave = Me.DataGridView1(0, fila).Value
                        _Unidad = Me.DataGridView1(3, fila).Value
                        _valorUnitario = Me.DataGridView1(4, fila).Value
                        '//////////////////////////////////////////////////////////////////////
                        '**********************************************************************
                        'Primero agrego el concepto, leo el Id y lo agrego a Conceptos
                        '**********************************************************************
                        '//////////////////////////////////////////////////////////////////////
                        Sql_Str = "Insert into Concepto" &
                            " (cantidad, unidad, noIdentificacion, descripcion, valorUnitario, importe)" &
                            " Values(" & _Cantidad & ", '" & _Unidad & "', '" & _Clave & "', '" & _Descripcion & "', " & _valorUnitario & ", " & _Cantidad * _valorUnitario & ");" &
                            " Select @ConceptoID" & i & " = @@Identity"
                        If cx.State = ConnectionState.Closed Then
                            cx.Open()
                        End If
                        Cmd.CommandText = Sql_Str
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql_Str
                        Cmd.Parameters.Add("@ConceptoID" & i, SqlDbType.Int)
                        Cmd.Parameters("@ConceptoID" & i).Direction = ParameterDirection.Output
                        Cmd.ExecuteNonQuery()
                        Id_Concepto = Cmd.Parameters("@ConceptoID" & i).Value.ToString() + 1
                        Sql_Str = "Insert into Conceptos (Id_Conceptos,Id_Concepto)Values (" & Id_Conceptos & " ," & Id_Concepto & ")"
                        Cmd.CommandText = Sql_Str
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = Sql_Str
                        Cmd.ExecuteNonQuery()
                        If cx.State = ConnectionState.Open Then
                            cx.Close()
                        End If
                    Next

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
                    Sql_Str = "Insert into Comprobante(versionXML, serie, folio, fecha, sello, formaDePago, noCertificado, certificado, condicionesDePago," &
                        " subTotal, descuento, motivoDescuento, TipoCambio, Moneda, total, tipoDeComprobante, metodoDePago, LugarExpedicion, NumCtaPago, FolioFiscalOrig, SerieFolioFiscalOrig," &
                        " FechaFolioFiscalOrig, MontoFolioFiscalOrig, Id_Emisor, Id_Receptor, Id_Conceptos, Id_Impuestos,  Dias_Credito) " &
                        " Values(@versionXML, @serie, @folio, @fecha, @sello, @formaDePago, @noCertificado, @certificado, @condicionesDePago," &
                        " @subTotal, @descuento, @motivoDescuento, @TipoCambio, @Moneda, @total, @tipoDeComprobante, @metodoDePago, @LugarExpedicion, @NumCtaPago, @FolioFiscalOrig, @SerieFolioFiscalOrig," &
                        " @FechaFolioFiscalOrig, @MontoFolioFiscalOrig, @Id_Emisor, @Id_Receptor, @Id_Conceptos, @Id_Impuestos,  @Dias_Credito)"
                    Cmd.CommandText = Sql_Str
                    Cmd.CommandType = CommandType.Text
                    ' Cmd.Transaction = Transaccion
                    Cmd.CommandText = Sql_Str
                    Cmd.Parameters.AddWithValue("@versionXML", "3.2")
                    Cmd.Parameters.AddWithValue("@serie", "A")
                    Cmd.Parameters.AddWithValue("@Folio", Folio_Actual)
                    Cmd.Parameters.AddWithValue("@fecha", _fecha)
                    Cmd.Parameters.AddWithValue("@sello", _Sello)
                    Cmd.Parameters.AddWithValue("@formaDePago", _formaDePago)
                    Cmd.Parameters.AddWithValue("@noCertificado", _noCertificado)
                    Cmd.Parameters.AddWithValue("@certificado", _certificado)
                    Cmd.Parameters.AddWithValue("@condicionesDePago", _condicionesDePago)
                    Cmd.Parameters.AddWithValue("@subTotal", CDec(Me.Label_Gran_Subtotal.Text))
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
                    Cmd.Parameters.AddWithValue("@Id_Receptor", Cliente_Actual)
                    Cmd.Parameters.AddWithValue("@Id_Conceptos", Id_Conceptos)
                    Cmd.Parameters.AddWithValue("@Id_Impuestos", 1)
                    'Cmd.Parameters.AddWithValue("@Id_Complemento", Id_Complemento)
                    'Cmd.Parameters.AddWithValue("@Id_Addenda", 0)
                    Cmd.Parameters.AddWithValue("@Dias_Credito", 0)
                    Cmd.Parameters.AddWithValue("@total", CDec(Me.Label_Gran_Total.Text))
                    Cmd.ExecuteNonQuery()

                    If cx.State = ConnectionState.Open Then
                        cx.Close()
                    End If

                    Dim PDF_Bytes As Byte()

                    PDF_Bytes = File.ReadAllBytes(_NombreArchivo.Replace(".xml", ".pdf"))

                    If File.Exists(RutaSrv + "\Facturas\CFDI_" & _NombreArchivo & ".pdf") Then
                        Sql_Str = "Insert into Facturas(Serie,Folio,PDF,XML) Values(@Serie,@Folio,@PDF,@XML)"
                        If cx.State = ConnectionState.Closed Then
                            cx.Open()
                        End If
                        Cmd.CommandText = Sql_Str
                        Cmd.CommandType = CommandType.Text
                        ' Cmd.Transaction = Transaccion
                        Cmd.CommandText = Sql_Str
                        Cmd.Parameters.AddWithValue("@serie", "B")
                        Cmd.Parameters.AddWithValue("@Folio", Folio_Actual)
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
                        If File.Exists(RutaSrv + "\Facturas\CFDI_" & _NombreArchivo & ".pdf") Then
                            Sql_Str = "Insert into Facturas(Serie,Folio,PDF,XML) Values(@Serie,@Folio,@PDF,@XML)"
                            If cx.State = ConnectionState.Closed Then
                                cx.Open()
                            End If
                            Cmd.CommandText = Sql_Str
                            Cmd.CommandType = CommandType.Text
                            ' Cmd.Transaction = Transaccion
                            Cmd.CommandText = Sql_Str
                            Cmd.Parameters.AddWithValue("@serie", "B")
                            Cmd.Parameters.AddWithValue("@Folio", Folio_Actual)
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

        End If


        MsgBox("Su Factura ha sido Generada", MsgBoxStyle.Information)

        Me.Close()

    End Sub
#End Region
#Region "Codigo Complementario"
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
    Private Sub TextBox_Cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Cantidad.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            clProducto.Cantidad = Me.TextBox_Cantidad.Text
            Me.Label_SubTotal.Text = clProducto.Subtotal
            Me.Label_IVA.Text = clProducto.Impuesto
            Me.Label_Total.Text = clProducto.Total
            Me.TextBox_Precio.Focus()
            Me.TextBox_Precio.SelectAll()

        End If
    End Sub
    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()

    End Sub
    Private Sub TextBox_Precio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Precio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            clProducto.Precio = Me.TextBox_Precio.Text
            Me.Label_SubTotal.Text = clProducto.Subtotal
            Me.Label_IVA.Text = clProducto.Impuesto
            Me.Label_Total.Text = clProducto.Total
            Me.Button_Agregar_Articulo.Focus()
        End If
    End Sub
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
#End Region
    Sub Borrar_Producto_del_Listado()
        Dim Clave As String = Nothing
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Try
            Clave = Me.DataGridView1(columna, fila).Value
            If Clave = "" Then
                MessageBox.Show("Debe selecccionar un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Using Cx As New SqlConnection(CxSettings.ConnectionString)

            Try
                Cx.Open()
                Sql_Str = "Delete Productos_x_Facturar" &
                    " Where Id_TemporalID = @Id_TemporalID And Clave = @Clave"
                Dim Cmd As New SqlCommand(Sql_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Id_TemporalID", _TemporalID)
                Cmd.Parameters.AddWithValue("@Clave", Clave)
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
        End Using
    End Sub
    Private Sub Button_Borrar_Articulo_Click(sender As Object, e As EventArgs) Handles Button_Borrar_Articulo.Click
        Borrar_Producto_del_Listado()
        Carga_Productos_Datagrid()
        Sumar_Subtotales()
    End Sub
End Class

