Imports System
Imports System.Data
Imports System.Data.SqlClient
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
'Imports Gma.QrCodeNet.Encoding
Imports System.Drawing
Imports clsCFDIx.CFDx
Imports clsTimbrado
Imports clsTimbrado.clsTimbradoATEB
Imports System.Globalization
Imports System.Data.SqlTypes

Public Class NuevoCliente
#Region "Variables"
    Public ConceptosList As List(Of Conceptos)
    ' Dim Auth As New mx.com.timbrado.cfdi.AuthenticationHeader
    'Dim ws As New mx.com.timbrado.cfdi.ServicioTimbradoPruebas
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
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
    Dim Cont As New Contrato
    Dim Benef(8) As Beneficiarios_Class
    Dim Cli As New Cliente
    Dim Per As New Persona

#End Region


    Private Sub Button_CargaGaveta_Click(sender As Object, e As EventArgs) Handles Button_CargaGaveta.Click
        Dim frm As New Plano1
        frm.ShowDialog()
        Label_Gaveta.Text = Boton_Actual
    End Sub

    Private Sub NuevoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Vendedores()
        Carga_Localidades()
        Carga_Formas_Pago()
        Carga_Empresa()
        Carga_CP()
        Me.ComboBox_Descuento.Text = 0
        ToolStripButton13.Enabled = False
        ToolStripButton17.Enabled = False
        Carga_SUD()
    End Sub


#Region "Contrato"
    ''' <summary>
    ''' Este boton permite Guardar los datos generales del contrato y genera el id del contrato para posteriormente poder guardar el plan de pagos, 
    ''' los beneficiarios, los ocupantes y los datos de facturacion
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        ToolStripButton2.Enabled = True
        ToolStripButton_Factura.Enabled = False

        Dim ModuloColumnaFila(2) As String
        If Trim(Me.TextBox_RFC.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_RFC.Focus()
            Exit Sub
        Else
            Cli.RFC = Trim(Me.TextBox_RFC.Text)
        End If
        If Trim(Me.TextBox_RazonSocial.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_RazonSocial.Focus()
            Exit Sub
        Else
            Cli.Razon_Social = Trim(Me.TextBox_RazonSocial.Text)
        End If
        If Trim(Me.TextBox1_NombreCte.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox1_NombreCte.Focus()
            Exit Sub

        Else
            Per.Nombre = Me.TextBox1_NombreCte.Text
        End If
        Try
            Per.Sexo = Me.ComboBox_Sexo.Text
        Catch ex As Exception
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Sexo.Focus()
            Exit Sub
        End Try
        Try
            Cont.Descuento = Me.ComboBox_Descuento.Text
        Catch ex As Exception
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Descuento.Focus()
            Exit Sub
        End Try

        Per.Fecha_Nacimiento = DateTimePicker_FechaNac.Value
        Per.Email = Me.TextBox_EmailCte.Text
        Per.Calle = Me.TextBox_CalleCte.Text
        Per.noExterior = Me.TextBox_NumExtCte.Text
        Per.noInterior = Me.Textbox_NumInt.Text
        Per.colonia = Me.TextBox_ColoniaCte.Text
        Try
            Per.Id_Localidad = Me.ComboBox_Localidad.SelectedValue
            Per.localidad = Me.ComboBox_Localidad.Text
        Catch ex As Exception
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Localidad.Focus()
            Exit Sub
        End Try
        Per.Tel_Particular = Me.TextBox_TelDomicilio.Text
        Per.Celular = Me.TextBox_Celular.Text


        Try
            Cont.Agente = Me.ComboBox_Agente.Text
        Catch ex As Exception
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Agente.Focus()
            Exit Sub
        End Try

        Cont.Id_Agente = Me.ComboBox_Agente.SelectedValue
        If Trim(Me.Label_Gaveta.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Button_CargaGaveta.Focus()
            Exit Sub
        Else
            Cont.Gaveta = Me.Label_Gaveta.Text
        End If

        ModuloColumnaFila = Split(Cont.Gaveta, "-")
        Try
            Cont.Fecha_Alta = Me.DateTimePicker_FechaAlta.Value
        Catch ex As Exception
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DateTimePicker_FechaAlta.Focus()
            Exit Sub
        End Try
        Cont.ObservacionesGenerales = Me.TextBox_Observaciones.Text
        Try
            Cont.IdFormaPago = Me.ComboBox_FormaPago.SelectedValue
            Cont.FormaPago = Me.ComboBox_FormaPago.Text
        Catch ex As Exception
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_FormaPago.Focus()
            Exit Sub
        End Try
        If Me.ComboBox_LugarPago.Text = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_LugarPago.Focus()
            Exit Sub
        Else
            Cont.LugarPago = Me.ComboBox_LugarPago.Text
        End If
        If ComboBox_DiaPago.Text = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_DiaPago.Focus()
            Exit Sub
        Else
            Cont.DiaPago = ComboBox_DiaPago.Text
        End If
        If Trim(Me.ComboBox_MetodoPago.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_MetodoPago.Focus()
            Exit Sub
        Else
            Cont.MetodoPago = Me.ComboBox_MetodoPago.Text
        End If

        Cont.NumeroCta = Trim(Me.TextBox_NumCta.Text)
        If Cont.FormaPago = "Efectivo" Or Cont.FormaPago = "No Identificado" Then

        Else

            Dim Total_Digitos As Integer = 0
            Total_Digitos = Cont.NumeroCta.Length
            If Total_Digitos < 4 Then
                MessageBox.Show("Se requieren los 4 ultimos digitos de la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.TextBox_NumCta.Focus()
                Exit Sub
            End If

        End If
        Cont.Motivo_Descuento = Me.TextBox_MotivoDescuento.Text

        Try
            Sql_Str = "Select CP from Cat_CP where Id_CP = @ID_CP"
        Catch ex As Exception

        End Try
        Per.codigoPostal = CP
        Dim Fecha_Temp As String = Nothing
        If Cont.DiaPago > 28 And Now.Month = 2 Then
            Fecha_Temp = UltimoDiaMes(Now)
        Else
            Fecha_Temp = Cont.DiaPago & "/" & Now.Month & "/" & Now.Year
        End If


        Fecha_Recibos = CDate(Fecha_Temp)
        Fecha_Inicio_Recibos = Me.DateTimePicker_FechaAlta.Value
        Using cx As New SqlConnection(CxSettings.ConnectionString)
            Sql_Str = "SELECT Municipio.Municipio, Estado.Estado, Paises.Pais" &
                " FROM Localidad INNER JOIN" &
                " Municipio ON Localidad.Id_Municipio = Municipio.ID_Municipio INNER JOIN " &
                " Estado ON Municipio.Id_Estado = Estado.ID_Estado INNER JOIN" &
                " Paises ON Estado.Id_Paises = Paises.ID_Paises" &
                " WHERE        (Localidad.ID_Localidad = " & Per.Id_Localidad & ")"
            Try
                cx.Open()
                Dim Cmd As New SqlCommand(Sql_Str, cx)
                Cmd.CommandType = CommandType.Text
                Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If DR.HasRows Then
                    While DR.Read
                        Cli.municipio = DR.Item(0)
                        Cli.estado = DR.Item(1)
                        Cli.pais = DR.Item(2)
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

        Try
            Cx.Open()
            Sql_Str = "Select * from Gavetas where modulo = @modulo and Columna = @columna and fila = @fila and id_Planta = (Select id_Planta from Plantas where Planta = @Piso);" &
                "Select ubicacion from Ubicaciones where Id_Ubicacion = (Select Id_Ubicacion from Gavetas where modulo = @modulo and Columna = @columna and fila = @fila and id_Planta = (Select id_Planta from Plantas where Planta = @Piso))"
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Piso", "Planta Baja")
            Cmd.Parameters.AddWithValue("@modulo", ModuloColumnaFila(0))
            Cmd.Parameters.AddWithValue("@columna", ModuloColumnaFila(1))
            Cmd.Parameters.AddWithValue("@fila", ModuloColumnaFila(2))
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Cont.Id_Gaveta = DR.Item("Id_Gaveta")
                    Cont.Piso = DR.Item("Id_Planta").ToString
                    Cont.Ubicacion = DR.Item("Id_Ubicacion")
                    Cont.Modulo = DR.Item("Modulo")
                    Cont.Fila = DR.Item("Fila")
                    Cont.Columna = DR.Item("Columna")
                    Cont.CapacidadGaveta = DR.Item("Capacidad")
                    Cont.ObservacionesGaveta = DR.Item("Observaciones")
                End While
            End If
            DR.NextResult()
            If DR.HasRows Then
                While DR.Read
                    Cont.Ubicacion = DR.Item("Ubicacion")
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

        Dim Transaccion As SqlTransaction = Nothing
        Try
            Cx.Open()

            Transaccion = Cx.BeginTransaction("Inserta Cliente")
            Sql_Str = "Insert into Domicilio (Calle, NoExterior, NoInterior, Colonia, Id_Localidad, Referencia, codigoPostal) " &
                " Values(@Calle, @NoExterior, @NoInterior, @Colonia, @Id_Localidad, @Referencia, @codigoPostal);" &
                " Select @ID = @@Identity"
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Transaccion
            Cmd.CommandText = Sql_Str
            Cmd.Parameters.AddWithValue("@Calle", Per.Calle)
            Cmd.Parameters.AddWithValue("@NoExterior", Per.noExterior)
            Cmd.Parameters.AddWithValue("@NoInterior", Per.noInterior)
            Cmd.Parameters.AddWithValue("@Colonia", Per.colonia)
            Cmd.Parameters.AddWithValue("@Id_Localidad", Per.Id_Localidad)
            Cmd.Parameters.AddWithValue("@Referencia", "")
            Cmd.Parameters.AddWithValue("@codigoPostal", Per.codigoPostal)
            Cmd.Parameters.Add("@ID", SqlDbType.Int)
            Cmd.Parameters("@ID").Direction = ParameterDirection.Output
            Cmd.ExecuteNonQuery()
            Per.Id_Domicilio = Cmd.Parameters("@ID").Value.ToString()
            Sql_Str = "Insert into Receptor (RFC,Nombre,Id_Domicilio) Values(@RFC,@Nombre,@Id_Domicilio);" &
                " Select @ID_Receptor2 = @@Identity"
            Cmd.CommandText = Sql_Str
            Cmd.Parameters.AddWithValue("@RFC", Cli.RFC)
            Cmd.Parameters.AddWithValue("@Nombre", Cli.Razon_Social)
            Cmd.Parameters.AddWithValue("@Id_Domicilio", Per.Id_Domicilio)
            Cmd.Parameters.Add("@ID_Receptor2", SqlDbType.Int)
            Cmd.Parameters("@ID_Receptor2").Direction = ParameterDirection.Output
            Cmd.ExecuteNonQuery()
            Dim Id_Receptor As Integer = Cmd.Parameters("@ID_Receptor2").Value.ToString()
            Sql_Str = "Insert into Personas (Id_Receptor,Nombre, Sexo, Tel_Particular,Celular,Fecha_Nacimiento, email,Observaciones)" &
                " Values(@Id_Receptor,@Nombre2, @Sexo, @Telefono,@Celular,@Fecha_Nacimiento,@email,@Observaciones);" &
                " Select @ID_Persona = @@Identity"
            Cmd.CommandText = Sql_Str
            Cmd.Parameters.AddWithValue("@Id_Receptor", Id_Receptor)
            Cmd.Parameters.AddWithValue("@Nombre2", Per.Nombre)
            Cmd.Parameters.AddWithValue("@Telefono", Per.Tel_Particular)
            Cmd.Parameters.AddWithValue("@Celular", Per.Celular)
            Cmd.Parameters.AddWithValue("@Sexo", Per.Sexo)
            Cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Per.Fecha_Nacimiento)
            Cmd.Parameters.AddWithValue("@Observaciones", Cont.ObservacionesGenerales)
            Cmd.Parameters.AddWithValue("@email", Per.Email)
            Cmd.Parameters.Add("@ID_Persona", SqlDbType.Int)
            Cmd.Parameters("@ID_Persona").Direction = ParameterDirection.Output
            Cmd.ExecuteNonQuery()
            Dim Id_Persona As Integer = Cmd.Parameters("@Id_Persona").Value.ToString()
            Sql_Str = "Insert into Contratos (Id_Gaveta, Id_Cliente, Forma_Pago, Id_Empleado, Dia_Pago, Fecha_Alta, LugarPago, Descuento, Motivo_Descuento, NumCtaPago, metodoDePago)" &
                " Values(@Id_Gaveta, @Id_Cliente, @Forma_Pago, @Id_Empleado, @Dia_Pago, @Fecha_Alta, @LugarPago,@Descuento, @Motivo_Descuento,  @NumCtaPago, @metodoDePago);" &
                " Select @ID_Contrato = @@Identity"
            Cmd.CommandText = Sql_Str
            Cmd.Parameters.AddWithValue("@Id_Gaveta", Cont.Id_Gaveta)
            Cmd.Parameters.AddWithValue("@Id_Cliente", Id_Persona)
            Cmd.Parameters.AddWithValue("@Forma_Pago", Cont.FormaPago)
            Cmd.Parameters.AddWithValue("@Id_Empleado", Cont.Id_Agente)
            Cmd.Parameters.AddWithValue("@Dia_Pago", Cont.DiaPago)
            Cmd.Parameters.AddWithValue("@Fecha_Alta", Cont.Fecha_Alta)
            Cmd.Parameters.AddWithValue("@LugarPago", Cont.LugarPago)
            Cmd.Parameters.AddWithValue("@Descuento", Cont.Descuento)
            Cmd.Parameters.AddWithValue("@Motivo_Descuento", Cont.Motivo_Descuento)
            Cmd.Parameters.AddWithValue("@NumCtaPago", Cont.NumeroCta)
            Cmd.Parameters.AddWithValue("@metodoDePago", Cont.MetodoPago)
            Cmd.Parameters.Add("@ID_Contrato", SqlDbType.Int)
            Cmd.Parameters("@ID_Contrato").Direction = ParameterDirection.Output
            Cmd.ExecuteNonQuery()
            Cont.Contrato = Cmd.Parameters("@ID_Contrato").Value.ToString()
            Id_Contrato = Cont.Contrato
            Me.Label_Contrato.Text = Id_Contrato
            Transaccion.Commit()
            ToolStripButton6.Enabled = False
            Me.GroupBox2.Enabled = True
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Try
                Transaccion.Rollback()
            Catch ex2 As Exception
                MessageBox.Show("Message: {0}" + ex2.Message, "Rollback Exception Type: {0}" & ex2.GetType.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Try
                Transaccion.Rollback()
            Catch ex2 As Exception
                MessageBox.Show("Message: {0}" + ex2.Message, "Rollback Exception Type: {0}" & ex2.GetType.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub
#End Region
    ''' <summary>
    ''' Aqui genera e imprime la caratula y el contrato
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "Genera Caratula, Contrato y Factura"

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim MSWord As New Word.Application
        Dim Documento As New Word.Document
        Dim DocContrato As New Word.Document
        Dim myStream As String = Nothing
        Dim Archivo As String = Nothing
        Dim Piso As String = "Planta Baja"
        Dim FuenteCaratula As String = RutaSrv + "\Plantillas\CÁRATULA MAUSOLEO DIVINO MAESTRO.docx"
        Dim DestinoCaratula As String = RutaSrv + "\Contratos\CÁRATULA " & Cont.Gaveta & ".docx"
        If My.Computer.FileSystem.FileExists(RutaSrv + "\Contratos\CÁRATULA " & Cont.Gaveta & ".docx") Then
            Dim Respuesta As DialogResult = MessageBox.Show("Ya existe un contrato y una caratula con este nombre desea substituirlos", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Respuesta = System.Windows.Forms.DialogResult.Yes Then
                Try
                    File.Delete(DestinoCaratula)
                    File.Delete(RutaSrv + "\Contratos\" & Cont.Gaveta & ".docx")
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End Try

            Else
                Exit Sub
            End If
        End If
        ToolStripButton2.Enabled = False
        FileCopy(FuenteCaratula, DestinoCaratula)
        Try
            Documento = MSWord.Documents.Open(DestinoCaratula)
            With Documento
                .Bookmarks.Item("contrato").Range.Text = Cont.Contrato
                .Bookmarks.Item("ubicacion").Range.Text = Cont.Ubicacion.ToUpper
                .Bookmarks.Item("capacidad").Range.Text = Cont.CapacidadGaveta
                .Bookmarks.Item("piso").Range.Text = Piso.ToUpper
                .Bookmarks.Item("modulo").Range.Text = Cont.Modulo
                .Bookmarks.Item("columna").Range.Text = Cont.Columna
                .Bookmarks.Item("letra").Range.Text = Cont.Fila
                .Bookmarks.Item("nombre").Range.Text = Per.Nombre
                .Bookmarks.Item("direccion").Range.Text = Per.Calle & " No. " & Per.noExterior & Per.noInterior
                .Bookmarks.Item("colonia").Range.Text = Per.colonia
                .Bookmarks.Item("ciudad").Range.Text = Per.localidad
                .Bookmarks.Item("estado").Range.Text = Cli.estado
                .Bookmarks.Item("cp").Range.Text = Per.codigoPostal
                .Bookmarks.Item("telpart").Range.Text = Per.Tel_Particular
                .Bookmarks.Item("telof").Range.Text = Per.Tel_Oficina
                .Bookmarks.Item("celular").Range.Text = Per.Celular
                Dim Fecha_N As Date = Per.Fecha_Nacimiento
                .Bookmarks.Item("fechanacimiento").Range.Text = Fecha_N.ToString("dd \de MMMM \de yyyy", CultureInfo.CreateSpecificCulture("es-MX"))
                .Bookmarks.Item("rfc").Range.Text = Cli.RFC
                .Bookmarks.Item("email").Range.Text = Per.Email
                Dim TotalBeneficiarios As Integer = 0
                While TotalBeneficiarios <= Me.DataGridView_Beneficiarios.RowCount - 1
                    .Bookmarks.Item("b" & TotalBeneficiarios + 1).Range.Text = Me.DataGridView_Beneficiarios(1, TotalBeneficiarios).Value
                    .Bookmarks.Item("p" & TotalBeneficiarios + 1).Range.Text = Me.DataGridView_Beneficiarios(2, TotalBeneficiarios).Value
                    TotalBeneficiarios = TotalBeneficiarios + 1
                End While
                .Bookmarks.Item("TitularSustituto").Range.Text = TitularSubstituto
                .Bookmarks.Item("parentescotitular").Range.Text = ParentescoTitular
                .Bookmarks.Item("precio").Range.Text = SaldoInicial
                '.Bookmarks.Item("precioletra").Range.Text = Letras(SaldoInicial)
                .Bookmarks.Item("precioletra").Range.Text = NumeroATexto(CDbl(SaldoInicial))
                If Cont.MetodoPago = "Contado" Then
                    .Bookmarks.Item("contado").Range.Text = "X"
                Else
                    .Bookmarks.Item("credito").Range.Text = "X"
                End If
                .Bookmarks.Item("abono").Range.Text = FormatNumber(Anticipo, 2, , , Microsoft.VisualBasic.TriState.True)
                .Bookmarks.Item("mensualidades").Range.Text = Mensualidades - 1
                .Bookmarks.Item("mensualidad").Range.Text = FormatNumber(Mensualidad, 2, , , Microsoft.VisualBasic.TriState.True)
                .Bookmarks.Item("formapago").Range.Text = Cont.FormaPago
                .Bookmarks.Item("diapago").Range.Text = Cont.DiaPago

            End With

            Documento.Save()
            'MSWord.Visible = True

            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.InitialDirectory = RutaSrv + "\Plantillas\"
            openFileDialog1.Filter = "Archivos de Word (*.docx)|*.docx"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True

            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    myStream = openFileDialog1.FileName
                    If (myStream IsNot Nothing) Then
                        ' Insert code to read the stream here.
                        Archivo = myStream.ToString
                    End If
                Catch Ex As Exception
                    MessageBox.Show("No se puede leer el archivo. Error: " & Ex.Message)
                    Exit Sub
                End Try
            End If
            Dim Fuente As String = Archivo
            Dim Destino As String = RutaSrv + "\Contratos\" & Cont.Gaveta & ".docx"
            FileCopy(Fuente, Destino)
            DocContrato = MSWord.Documents.Open(Destino)
            With DocContrato
                .Bookmarks.Item("domicilio").Range.Text = Per.Calle & " No. " & Per.noExterior & Per.noInterior & " Colonia: " & Per.colonia & "  C.P. " & Per.codigoPostal
                .Bookmarks.Item("ubicacion").Range.Text = Cont.Ubicacion
                .Bookmarks.Item("piso").Range.Text = Piso
                .Bookmarks.Item("modulo").Range.Text = Cont.Modulo
                .Bookmarks.Item("columna").Range.Text = Cont.Columna
                .Bookmarks.Item("letra").Range.Text = Cont.Fila
                Dim Fecha_A As Date = Cont.Fecha_Alta
                .Bookmarks.Item("fecha").Range.Text = Fecha_A.ToString("dd \de MMMM \de yyyy", CultureInfo.CreateSpecificCulture("es-MX"))
                .Bookmarks.Item("cliente").Range.Text = Per.Nombre
            End With
            DocContrato.Save()
            MSWord.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

#End Region
#Region "Numeros a Letras"
    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras As String = 0
        Dim entero As String = 0
        Dim dec As String = 0
        Dim flag As String = 0


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
#End Region
#Region "Numeros a Letras 2"
    Public Function NumeroATexto(ByVal d As Double) As String
        Dim parteEntera As Double = Math.Truncate(d)
        Dim parteDecimal As Double = Math.Truncate((d - parteEntera) * 100)
        If (parteDecimal > 0) Then
            Return Num2Text(parteEntera) + " CON " + Num2Text(parteDecimal) + "CENTAVOS"
        Else
            Return Num2Text(parteEntera)
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
#Region "Plan de Pagos"
    Sub Carga_PlanPagos()
        Try
            Cx.Open()
            Sql_Str = "Select Id_Detalle_PlanPagos as ID,  Fecha_Vencimiento as Fecha, Detalle, Importe  from Detalle_PlanPagos" &
                " Where Id_PlanPagos = (Select Id_PlanPagos from PlanPagos Where Id_Contrato = @Id_Contrato)" &
                " Order by Id_Detalle_PlanPagos"
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
    End Sub
    ''' <summary>
    ''' Este boton permite agregar un plan de pagos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Dim SrvDG As Integer = 0
        SrvDG = DataGridView_Servicios.RowCount
        Dim columna As Integer = 4
        Dim fila As Integer = 0
        SaldoInicial = 0
        If SrvDG > 0 Then
            SaldoInicial = Label_Gran_Total.Text
        Else
            MessageBox.Show("Debe de Capturar primero los servicios incluidos en el contrato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Fecha_Inicio_Recibos = Me.DateTimePicker_FechaAlta.Value
        Dim Fecha_Temp As String = Nothing
        _DiaPago = Cont.DiaPago
        Fecha_Temp = Cont.DiaPago & "/" & Fecha_Inicio_Recibos.Month & "/" & Fecha_Inicio_Recibos.Year
        If Cont.DiaPago > 28 And Fecha_Inicio_Recibos.Month = 2 Then
            Fecha_Temp = UltimoDiaMes(Fecha_Inicio_Recibos)
        End If
        If _DiaPago < 15 And Fecha_Inicio_Recibos.Day > 20 Then
            Fecha_Temp = DateAdd(DateInterval.Month, 1, CDate(Fecha_Temp))
        End If

        Fecha_Recibos = CDate(Fecha_Temp)
        Dim Frm As New Nuevo_PlanPagos
        Frm.ShowDialog()
        Carga_PlanPagos()
        Carga_Saldos()
    End Sub
    Function UltimoDiaMes(Fecha As Date) As Date
        UltimoDiaMes = DateSerial(Year(Fecha), Month(Fecha) + 1, 0)
    End Function
    Sub Carga_Saldos()
        Sql_Str = "Select Sum(Cast(Importe as decimal)) as Total from Detalle_PlanPagos " &
            " where  Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato)" &
            " and Id_Detalle_PlanPagos in (Select Id_detalle_PlanPagos from Detalle_Recibos where Id_Recibo in" &
            " (Select Id_Recibo from Recibos where Estado_Actual in('Recibo Pagado','Recibo Facturado')));" &
            " Select SaldoInicial  from PlanPagos where Id_Contrato = @Id_Contrato;" &
            " Select Count(Id_Detalle_PlanPagos) as Total from Detalle_PlanPagos " &
            " where  Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato)" &
            " and Id_Detalle_PlanPagos in (Select Id_detalle_PlanPagos from Detalle_Recibos where Id_Recibo in" &
            " (Select Id_Recibo from Recibos where Estado_Actual in('Recibo Pagado','Recibo Facturado')));" &
            " Select Count(Id_Detalle_PlanPagos) as Total from Detalle_PlanPagos " &
            " where Id_Detalle_PlanPagos not in (Select Id_detalle_PlanPagos from Detalle_Recibos where Id_Recibo in" &
            " (Select Id_Recibo from Recibos where Estado_Actual in('Recibo Pagado','Recibo Facturado')))" &
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
    ''' <summary>
    ''' Este boton borra el plan de pagos
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        Dim Transaccion As SqlTransaction = Nothing
        Try
            Cx.Open()
            Transaccion = Cx.BeginTransaction("Borra Plan de Pagos")
            Sql_Str = "Delete Detalle_PlanPagos where Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato)"
            Dim Cmd As New SqlCommand(Sql_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Transaction = Transaccion
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Cmd.ExecuteNonQuery()
            Sql_Str = "Delete PlanPagos where Id_Contrato = @Id_Contrato1"
            Cmd.CommandText = Sql_Str
            Cmd.Parameters.AddWithValue("@Id_Contrato1", Id_Contrato)
            Cmd.ExecuteNonQuery()
            Transaccion.Commit()

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
        Carga_PlanPagos()
    End Sub
    ''' <summary>
    ''' Exporta a Excell el plan de pagos 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs)
        'Falta
    End Sub
#End Region
#Region "Beneficiarios"
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
    ''' <summary>
    ''' Este boton carga el formulario de Beneficiarios para agregar uno nuevo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton_AgregaBeneficiario_Click(sender As Object, e As EventArgs) Handles ToolStripButton_AgregaBeneficiario.Click
        'If Me.DataGridView_Beneficiarios.RowCount >= Cont.CapacidadGaveta Then
        '    MessageBox.Show("A alcanzado el cupo maximo de este nicho", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        Dim Frm As New Beneficiarios
        Frm.ShowDialog()
        Carga_Beneficiarios()
    End Sub
    ''' <summary>
    ''' Este boton borra un beneficiario de la base de datos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton_BorraBeneficiario_Click(sender As Object, e As EventArgs) Handles ToolStripButton_BorraBeneficiario.Click
        Dim Respuesta As DialogResult = MessageBox.Show("Desea eliminar el beneficiario", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Respuesta = System.Windows.Forms.DialogResult.Yes Then
            Dim Id_Persona As Integer
            Dim columna As Integer, fila As Integer
            columna = 0
            fila = Me.DataGridView_Beneficiarios.CurrentCellAddress.Y
            Id_Persona = Me.DataGridView_Beneficiarios(columna, fila).Value
            If Id_Persona = 0 Then
                MessageBox.Show("Debe seleccionar un Beneficiario para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView_Beneficiarios.Focus()
                Exit Sub
            Else
                Try
                    Cx.Open()
                    Sql_Str = "Delete Beneficiarios where Id_Contrato = @Id_Contrato and Id_Persona = @Id_Persona"
                    Dim Cmd As New SqlCommand(Sql_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
                    Cmd.Parameters.AddWithValue("@Id_Persona", Id_Persona)
                    Cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try

                Carga_Beneficiarios()
            End If
        Else
            Exit Sub
        End If
    End Sub
#End Region
#Region "Servicios"
    ''' <summary>
    ''' Agrega un nuevo servicio
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        Dim frm As New AgregaProductoAContrato
        frm.ShowDialog()
        Carga_Servicios()
        If Me.DataGridView_Servicios.RowCount >= 1 Then
            ToolStripButton13.Enabled = True
            ToolStripButton17.Enabled = True
        End If
        Sumar_Subtotales()
        Carga_SUD()
    End Sub
    Sub Carga_Servicios()
        Try
            Cx.Open()
            Sql_Str = "Select Clave,Unidad, Descripcion,Disponibles, valorUnitario from View_ListadoServicios where Id_Contrato = @Id_Contrato"
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
    ''' <summary>
    ''' Borra Servicios
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        Dim Respuesta As DialogResult = MessageBox.Show("Desea eliminar el servicio", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Respuesta = System.Windows.Forms.DialogResult.Yes Then
            Dim Clave As String = Nothing
            Dim columna As Integer, fila As Integer
            columna = 0
            fila = Me.DataGridView_Servicios.CurrentCellAddress.Y
            Clave = Me.DataGridView_Servicios(columna, fila).Value
            If Clave = "" Then
                MessageBox.Show("Debe seleccionar un Servicio para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView_Servicios.Focus()
                Exit Sub
            Else
                Try
                    Cx.Open()
                    Sql_Str = "Delete ServiciosXContrato where Id_Contrato = @Id_Contrato " &
                        " and Id_ProductosyServicios = (Select Id_ProductosyServicios from ProductosyServicios where Clave = @Clave)"
                    Dim Cmd As New SqlCommand(Sql_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
                    Cmd.Parameters.AddWithValue("@Clave", Clave)
                    Cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
                Try
                    Cx.Open()
                    Sql_Str = "Delete Servicios_UtilizadosyDisponibles where Id_Contrato = @Id_Contrato "
                    Dim Cmd As New SqlCommand(Sql_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
                    Cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
                Carga_Servicios()
                Sumar_Subtotales()
                Carga_SUD()
            End If
        Else
            Exit Sub
        End If
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
#End Region
#Region "Ocupantes"
    ''' <summary>
    ''' Nuevo Ocupante
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Dim frm As New Ocupantes
        frm.ShowDialog()
        Carga_Ocupantes()
    End Sub
    ''' <summary>
    ''' Borra Ocupantes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        Dim Respuesta As DialogResult = MessageBox.Show("Desea eliminar el Ocupante", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Respuesta = System.Windows.Forms.DialogResult.Yes Then
            Dim Id_Persona As Integer
            Dim columna As Integer, fila As Integer
            columna = 0
            fila = Me.DataGridView_Ocupantes.CurrentCellAddress.Y
            Id_Persona = Me.DataGridView_Ocupantes(columna, fila).Value
            If Id_Persona = 0 Then
                MessageBox.Show("Debe seleccionar un Ocupante para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView_Ocupantes.Focus()
                Exit Sub
            Else
                Try
                    Cx.Open()
                    Sql_Str = "Delete Ocupantes where Id_Contrato = @Id_Contrato and Id_Persona = @Id_Persona"
                    Dim Cmd As New SqlCommand(Sql_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Parameters.AddWithValue("@IdContrato", Id_Contrato)
                    Cmd.Parameters.AddWithValue("@Id_Persona", Id_Persona)

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try

                Carga_Ocupantes()
            End If
        Else
            Exit Sub
        End If
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
#End Region
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
                            .Calle = .Calle & "  "
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
    Sub Carga_CP()

        Try
            Sql_Str = "Select * from Cat_CP Order by CP"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.ComboBox_CP
                .DataSource = DS.Tables("Tabla")
                .DisplayMember = "CP"
                .ValueMember = "Id_CP"
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
#Region "Facturacion"
    Private Sub ToolStripButton_Factura_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Factura.Click
        If isOnline() = False Then
            MessageBox.Show("Para facturar se requiere una conexion a internet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Else
            Factura()
            Me.ToolStripButton_Factura.Enabled = False
        End If

    End Sub

    Sub Factura()
        Dim CERT_SIS As String = clEmpresa.Ruta_Certificado
        Dim CerNo As String
        Dim CerSAT As System.Security.Cryptography.X509Certificates.X509Certificate
        Try
            CerSAT = System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromCertFile(CERT_SIS)
            CerNo = StrReverse(System.Text.Encoding.ASCII.GetString(CerSAT.GetSerialNumber))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al intentar cargar el Certificado del SAT", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        'Dim CerSAT As System.Security.Cryptography.X509Certificates.X509Certificate
        'CerSAT = System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromCertFile(CERT_SIS)
        'CerNo = StrReverse(System.Text.Encoding.ASCII.GetString(CerSAT.GetSerialNumber))
        Dim Fecha As String = DateTime.Now.ToString("yyyyMMddThhmmss").ToString
        Dim Folio_Actual As Integer = 0
        Dim _TipoDeCambio As String = Nothing
        Dim _formaDePago As String = Nothing
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
            Sql_Str = "Select Max(CAST(folio as int)) from Comprobante Where Serie = 'A'; Select Serie from Series;" &
                " SELECT Municipio.Municipio, Estado.Estado, Paises.Pais" &
                " FROM Localidad INNER JOIN" &
                " Municipio ON Localidad.Id_Municipio = Municipio.ID_Municipio INNER JOIN " &
                " Estado ON Municipio.Id_Estado = Estado.ID_Estado INNER JOIN" &
                " Paises ON Estado.Id_Paises = Paises.ID_Paises" &
                " WHERE        (Localidad.ID_Localidad = " & Per.Id_Localidad & ")"
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
                DR.NextResult()
                If DR.HasRows Then
                    While DR.Read
                        Cli.municipio = DR.Item(0)
                        Cli.estado = DR.Item(1)
                        Cli.pais = DR.Item(2)
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
        Dim Condiciones_Pago As String = Me.ComboBox_MetodoPago.Text
        _formaDePago = Me.ComboBox_FormaPago.Text
        If _formaDePago = "Contado" Then
            _formaDePago = "Pago en una sola exhibición"
        End If
        _Descuento = Me.ComboBox_Descuento.Text
        _motivoDescuento = Me.TextBox_MotivoDescuento.Text
        '//////////////////////////////////////////////////////////////////////
        '**********************************************************************
        'Aqui se crea el CFDI
        '**********************************************************************
        '//////////////////////////////////////////////////////////////////////
        Dim CFDs As New clsCFDIx.CFDx
        With CFDs
            .Comprobante(VersionCFD.CFDv3_2, Folio_Actual, FormatDateTime(Now, DateFormat.GeneralDate), _formaDePago _
                          , Me.Label_Subtotal_sin_Descuento.Text, Me.Label_Subtotal_sin_Descuento.Text * 1.16, clsCFDIx.ComprobanteTipoDeComprobante.ingreso, Me.ComboBox_FormaPago.Text _
                          , clEmpresa.pais, Serie, _TipoDeCambio, Condiciones_Pago, _Descuento, _motivoDescuento, "M.N." _
                          , Me.TextBox_NumCta.Text, _FolioFiscalOriginal, _SerieFolioFiscalOrig, _FechaFolioFiscalOrig)
            .AgregaEmisor(clEmpresa.RFC, clEmpresa.Calle, clEmpresa.municipio, clEmpresa.estado, clEmpresa.pais, clEmpresa.codigoPostal,
                          clEmpresa.Razon_Social, clEmpresa.noExterior, clEmpresa.noInterior, clEmpresa.colonia, clEmpresa.localidad, clEmpresa.referencia)
            .AgregaReceptor(Cli.RFC, Cli.Razon_Social, Per.Calle, Cli.municipio, Cli.estado, Cli.pais, Per.codigoPostal,
                                Per.noExterior, Per.noInterior, Per.colonia, Per.localidad, Per.referencia)
            .AgregaRegimenFiscal(clEmpresa.Regimen)
            Dim Registros1 As Integer = Me.DataGridView_Servicios.RowCount
            For i = 0 To Registros1 - 1
                Dim _Cantidad As Decimal = 0
                Dim _Descripcion As String = Nothing
                Dim _Clave As String = Nothing
                Dim _Unidad As String = Nothing
                Dim _valorUnitario As Decimal = 0
                Dim fila As Integer
                fila = i
                _Cantidad = Me.DataGridView_Servicios(3, fila).Value
                _Descripcion = Trim(Me.DataGridView_Servicios(2, fila).Value)
                _Clave = Me.DataGridView_Servicios(0, fila).Value
                _Unidad = Me.DataGridView_Servicios(1, fila).Value
                _valorUnitario = Me.DataGridView_Servicios(4, fila).Value
                .AgregaConcepto(_Cantidad, _Unidad, _Descripcion, _valorUnitario, _Clave)
            Next
            .AgregaComprobanteImpuestoTraslado(clsCFDIx.ComprobanteImpuestosTrasladoImpuesto.IVA, (1.16 - 1) * 100, Me.Label_Subtotal_sin_Descuento.Text * (1.16 - 1))
        End With
        Dim CertFile As String = clEmpresa.Ruta_Certificado
        Dim KeyFile As String = clEmpresa.Ruta_Llave
        Dim KeyPass As String = clEmpresa.Pwd
        Dim Errores As String = ""
        Dim _NombreArchivo As String = RutaSrv + "\Facturas\CFDI_" & Serie & "-" & Folio_Actual.ToString & ".xml"
        If CFDs.CreaFacturaXML(KeyFile, KeyPass, CertFile, Errores, _NombreArchivo) = False Then
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
                ' Dim Transaccion As SqlTransaction = Nothing
                Try
                    cx.Open()
                    'Transaccion = cx.BeginTransaction("Guarda_Factura")
                    Sql_Str = "Select Max(Id_Conceptos) as ID from Conceptos"
                    Dim Cmd As New SqlCommand(Sql_Str, cx)
                    'Cmd.Transaction = Transaccion
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

                    Dim Registros2 As Integer = Me.DataGridView_Servicios.RowCount
                    For i = 0 To Registros2 - 1
                        Dim _Cantidad As Decimal = 0
                        Dim _Descripcion As String = Nothing
                        Dim _Clave As String = Nothing
                        Dim _Unidad As String = Nothing
                        Dim _valorUnitario As Decimal = 0
                        Dim fila As Integer
                        fila = i
                        _Cantidad = Me.DataGridView_Servicios(3, fila).Value
                        _Descripcion = Me.DataGridView_Servicios(2, fila).Value
                        _Clave = Me.DataGridView_Servicios(0, fila).Value
                        _Unidad = Me.DataGridView_Servicios(1, fila).Value
                        _valorUnitario = Me.DataGridView_Servicios(4, fila).Value
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
                        ' Cmd.Transaction = Transaccion
                        Cmd.CommandText = Sql_Str
                        Cmd.Parameters.Add("@ConceptoID" & i, SqlDbType.Int)
                        Cmd.Parameters("@ConceptoID" & i).Direction = ParameterDirection.Output
                        Cmd.ExecuteNonQuery()
                        Id_Concepto = Cmd.Parameters("@ConceptoID" & i).Value.ToString() + 1
                        Sql_Str = "Insert into Conceptos (Id_Conceptos,Id_Concepto)Values (" & Id_Conceptos & " ," & Id_Concepto & ")"
                        Cmd.CommandText = Sql_Str
                        Cmd.CommandType = CommandType.Text
                        ' Cmd.Transaction = Transaccion
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

                    Dim _noCertificado As String = Nothing
                    Dim _certificado As String = Nothing
                    Dim _condicionesDePago As String = Nothing
                    'Dim _FechaFolioFiscalOrig As String = Nothing
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
                        " @FechaFolioFiscalOrig, @MontoFolioFiscalOrig, @Id_Emisor, @Id_Receptor, @Id_Conceptos, @Id_Impuestos, @Dias_Credito);" &
                        " Select @ID_Comprobante = @@Identity"

                    Cmd.CommandText = Sql_Str
                    Cmd.CommandType = CommandType.Text
                    ' Cmd.Transaction = Transaccion
                    Cmd.CommandText = Sql_Str
                    Cmd.Parameters.AddWithValue("@versionXML", "3.2")
                    Cmd.Parameters.AddWithValue("@serie", Serie)
                    Cmd.Parameters.AddWithValue("@Folio", Folio_Actual)
                    Cmd.Parameters.AddWithValue("@fecha", _fecha)
                    Cmd.Parameters.AddWithValue("@sello", _Sello)
                    Cmd.Parameters.AddWithValue("@formaDePago", _formaDePago)
                    Cmd.Parameters.AddWithValue("@noCertificado", _noCertificado)
                    Cmd.Parameters.AddWithValue("@certificado", _certificado)
                    Cmd.Parameters.AddWithValue("@condicionesDePago", _condicionesDePago)
                    'Cmd.Parameters.AddWithValue("@subTotal", CDec(Me.Label_Gran_Subtotal.Text))
                    Cmd.Parameters.AddWithValue("@subTotal", CDec(Me.Label_Subtotal_sin_Descuento.Text))
                    Cmd.Parameters.AddWithValue("@descuento", _Descuento)
                    Cmd.Parameters.AddWithValue("@motivoDescuento", _motivoDescuento)
                    Cmd.Parameters.AddWithValue("@TipoCambio", _TipoDeCambio)
                    Cmd.Parameters.AddWithValue("@Moneda", "M.N.")
                    Cmd.Parameters.AddWithValue("@tipoDeComprobante", "Ingreso")
                    Cmd.Parameters.AddWithValue("@metodoDePago", Me.ComboBox_FormaPago.Text)
                    Cmd.Parameters.AddWithValue("@LugarExpedicion", clEmpresa.pais)
                    Cmd.Parameters.AddWithValue("@NumCtaPago", Me.TextBox_NumCta.Text)
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
                    Cmd.Parameters.Add("@ID_Comprobante", SqlDbType.Int)
                    Cmd.Parameters("@ID_Comprobante").Direction = ParameterDirection.Output
                    Cmd.ExecuteNonQuery()
                    Id_Comprobante = Cmd.Parameters("@ID_Comprobante").Value.ToString()
                    'Transaccion.Commit()
                    Sql_Str = "Insert into Contratos_Factura (Id_Contrato, Id_Comprobante) Values (@Id_Contrato, @Id_Comprobante1)"
                    If cx.State = ConnectionState.Closed Then
                        cx.Open()
                    End If
                    Cmd.CommandText = Sql_Str
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql_Str
                    Cmd.Parameters.AddWithValue("@Id_Comprobante1", Id_Comprobante)
                    Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
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
                        Cmd.Parameters.AddWithValue("@serie", "A")
                        Cmd.Parameters.AddWithValue("@Folio", Folio_Actual)
                        Cmd.Parameters.AddWithValue("@PDF", PDF_Bytes)
                        Using xmlreader As New XmlTextReader(RutaSrv + "\Facturas\CFDI_" & _NombreArchivo & ".xml")
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
                            Cmd.Parameters.AddWithValue("@serie", "A")
                            Cmd.Parameters.AddWithValue("@Folio", Folio_Actual)
                            Cmd.Parameters.AddWithValue("@PDF", PDF_Bytes)
                            Using xmlreader As New XmlTextReader(RutaSrv + "\Facturas\CFDI_" & _NombreArchivo & ".xml")
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

        End If

        'Me.Close()
    End Sub
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
#End Region
#Region "Selecciona Texto de Textbox"
    Private Sub TextBox1_NombreCte_GotFocus(sender As Object, e As EventArgs) Handles TextBox1_NombreCte.GotFocus
        TextBox1_NombreCte.SelectAll()
    End Sub

    Private Sub TextBox_EmailCte_GotFocus(sender As Object, e As EventArgs) Handles TextBox_EmailCte.GotFocus
        TextBox_EmailCte.SelectAll()
    End Sub

    Private Sub TextBox_CalleCte_GotFocus(sender As Object, e As EventArgs) Handles TextBox_CalleCte.GotFocus
        TextBox_CalleCte.SelectAll()
    End Sub

    Private Sub TextBox_NumExtCte_GotFocus(sender As Object, e As EventArgs) Handles TextBox_NumExtCte.GotFocus
        TextBox_NumExtCte.SelectAll()
    End Sub

    Private Sub Textbox_NumInt_GotFocus(sender As Object, e As EventArgs) Handles Textbox_NumInt.GotFocus
        Me.Textbox_NumInt.SelectAll()
    End Sub

    Private Sub TextBox_ColoniaCte_GotFocus(sender As Object, e As EventArgs) Handles TextBox_ColoniaCte.GotFocus
        Me.TextBox_ColoniaCte.SelectAll()
    End Sub



    Private Sub TextBox_RazonSocial_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles TextBox_RazonSocial.GiveFeedback
        Me.TextBox_RazonSocial.SelectAll()
    End Sub

    Private Sub TextBox_RFC_GotFocus(sender As Object, e As EventArgs) Handles TextBox_RFC.GotFocus
        Me.TextBox_RFC.SelectAll()
    End Sub

    Private Sub TextBox_TelDomicilio_GotFocus(sender As Object, e As EventArgs) Handles TextBox_TelDomicilio.GotFocus
        Me.TextBox_TelDomicilio.SelectAll()
    End Sub

    Private Sub TextBox_Celular_GotFocus(sender As Object, e As EventArgs) Handles TextBox_Celular.GotFocus
        Me.TextBox_Celular.SelectAll()
    End Sub

    Private Sub TextBox_NumCta_GotFocus(sender As Object, e As EventArgs) Handles TextBox_NumCta.GotFocus
        Me.TextBox_NumCta.SelectAll()
    End Sub
#End Region

    Private Sub ToolStripButton4_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub

#Region "Imprime Plan de Pagos"
    Private Sub ToolStripButton_Imprime_Plan_Pagos_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Imprime_Plan_Pagos.Click
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
            xlsheet.Cells(1, 4).Formula = Now
            'xlsheet.Range("A7").VerticalAlignment = Excel.XlVAlign.xlVAlignTop
            'xlsheet.Range("A7").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            xlsheet.Range("A2").Font.Bold = True
            xlsheet.Range("A2").Font.Size = 18
            xlsheet.Range("A2").Interior.ColorIndex = 16
            xlsheet.Range("A2").Value = "Plan de Pagos"
            xlsheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            xlsheet.Range("A2:D3").Merge()
            xlsheet.Range("A2:D3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic, )

            xlsheet.Range("A4").Font.Bold = True
            xlsheet.Range("A4").Font.Size = 12
            xlsheet.Range("A4").Value = "Contrato " & Id_Contrato
            xlsheet.Range("A5").Font.Bold = True
            xlsheet.Range("A5").Font.Size = 12
            xlsheet.Range("A5").Value = "Contratante " & Me.TextBox1_NombreCte.Text
            xlsheet.Range("A6").Font.Bold = True
            xlsheet.Range("A6").Font.Size = 12
            xlsheet.Range("A6").Value = "Saldo Inicial " & Me.Label_SaldoInicial.Text
            xlsheet.Range("A7").Font.Bold = True
            xlsheet.Range("A7").Font.Size = 12
            xlsheet.Range("A7").Value = "Total Pagado " & Me.Label_Pagado.Text
            xlsheet.Range("A8").Font.Bold = True
            xlsheet.Range("A8").Font.Size = 12
            xlsheet.Range("A8").Value = "Saldo Actual " & Me.Label_SaldoActual.Text

            xlsheet.Cells(10, 1).Formula = "ID"
            xlsheet.Cells(10, 2).Formula = "Fecha"
            xlsheet.Cells(10, 3).Formula = "Mensualidad"
            xlsheet.Cells(10, 4).Formula = "Importe"
            xlsheet.Range("A10:D10").Font.Bold = True
            xlsheet.Range("A10:D10").Interior.ColorIndex = 16
            xlsheet.Range("A10:D10").Font.Size = 11
            xlsheet.Range("A10:D10").Borders().Color = 0
            xlsheet.Range("A10:D10").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
            xlsheet.Range("A10:D10").Borders().Weight = 2
            xlsheet.Range("A10:D10").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Dim R As String = "A10:A" + CInt(DataGridView_PlanPagos.RowCount + 5).ToString
            xlsheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlsheet.Range("A1").EntireColumn.ColumnWidth = 10
            xlsheet.Range("B1").EntireColumn.ColumnWidth = 30
            xlsheet.Range("C1").EntireColumn.ColumnWidth = 20
            xlsheet.Range("D1").EntireColumn.ColumnWidth = 20

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
#End Region


#Region "Servicios Disponibles y Utilizados"
    Private Sub Button_Agrega_SUD_Click(sender As Object, e As EventArgs) Handles Button_Agrega_SUD.Click
        Dim Frm As New AgregaSUD
        Frm.ShowDialog()
        Carga_SUD()
    End Sub

    Private Sub Button_Borra_SUD_Click(sender As Object, e As EventArgs) Handles Button_Borra_SUD.Click
        Dim Frm As New Edita_Servicios
        Frm.ShowDialog()
        Carga_SUD()
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

#End Region
End Class