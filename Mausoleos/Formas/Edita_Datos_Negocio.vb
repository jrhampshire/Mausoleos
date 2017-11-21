Imports System
Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration


Public Class Edita_Datos_Negocio
#Region "Variables"
    Dim SQL_Str As String = Nothing
    Dim CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Dim Paises_Cargados As Boolean = False
    Dim Estados_Cargados As Boolean = False
    Dim Municipios_Cargados As Boolean = False
    Dim clEmpresa As New ClassEmpresa
    Dim Emisor As Integer = 0

#End Region
    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()

    End Sub
#Region "Carga Datos"

    Private Sub Edita_Datos_Negocio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Paises()
        Carga_Estados()
        Carga_Municipios()
        Carga_Ciudades()
        Carga_Empresa()

    End Sub
    Sub Carga_Paises()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            SQL_Str = "Select * from Paises order by Pais"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Paises")
                With ComboBox_Pais
                    .DataSource = DS.Tables("Paises")
                    .DisplayMember = "Pais"
                    .ValueMember = "Id_Paises"
                End With
                Paises_Cargados = True
                Me.ComboBox_Pais.Text = ""
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End Using
    End Sub

    Sub Carga_Estados()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Id_Pais As Integer = 0
            Try
                Id_Pais = Me.ComboBox_Pais.SelectedValue
            Catch ex As Exception
                MessageBox.Show("Se debe de seleccionar un pais primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ComboBox_Pais.Focus()
                Exit Sub
            End Try
            SQL_Str = "Select * from Estado where id_Paises = @IdPais order by estado"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@IdPais", Id_Pais)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Estados")
                With ComboBox_Estado
                    .DataSource = DS.Tables("Estados")
                    .DisplayMember = "Estado"
                    .ValueMember = "Id_Estado"
                End With
                Estados_Cargados = True
                Me.ComboBox_Estado.Text = ""

            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End Using

    End Sub

    Sub Carga_Municipios()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Id_Estado As Integer
            Try
                Id_Estado = Me.ComboBox_Estado.SelectedValue
            Catch ex As Exception
                MessageBox.Show("Se debe de seleccionar un Estado primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ComboBox_Estado.Focus()
                Exit Sub
            End Try

            SQL_Str = "Select * from Municipio where id_Estado = @IdEstado order by Municipio"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@IdEstado", Id_Estado)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Municipios")
                With ComboBox_Municipio
                    .DataSource = DS.Tables("Municipios")
                    .DisplayMember = "Municipio"
                    .ValueMember = "Id_Municipio"
                End With
                Municipios_Cargados = True
                Me.ComboBox_Municipio.Text = ""
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End Using

    End Sub

    Sub Carga_Ciudades()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Id_Cd As Integer
            Try
                Id_Cd = Me.ComboBox_Estado.SelectedValue
            Catch ex As Exception
                MessageBox.Show("Se debe de seleccionar una Ciudad primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ComboBox_Estado.Focus()
                Exit Sub
            End Try

            SQL_Str = "Select * from Localidad where id_Municipio = @IdMunicipio order by Localidad"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@IdMunicipio", Id_Cd)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Ciudades")
                With ComboBox_Localidad
                    .DataSource = DS.Tables("Ciudades")
                    .DisplayMember = "Localidad"
                    .ValueMember = "Id_Localidad"
                End With
                Me.ComboBox_Localidad.Text = ""
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            SQL_Str = "SELECT Empresa.Id_Emisor, Empresa.Logotipo, Empresa.Email, Empresa.Pwd_Llave_Privada, Empresa.Llave_Privada, Empresa.Certificado, " &
                "Empresa.CURP, Empresa.Telefono, Empresa.PaginaWeb, Empresa.eslogan, " &
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
                            .noInterior = DR.Item("noInterior")
                            .localidad = DR.Item("Localidad")
                            .municipio = DR.Item("Municipio")
                            .estado = DR.Item("Estado")
                            .pais = DR.Item("Pais")
                            .codigoPostal = DR.Item("codigoPostal")
                            .Pwd = DR.Item("PWD_Llave_Privada")
                            .Ruta_Llave = DR.Item("Llave_Privada")
                            .Ruta_Certificado = DR.Item("Certificado")
                            Emisor = DR.Item("Id_Emisor")
                            .email = DR.Item("Email")
                            .eslogan = DR.Item("eslogan")
                            .colonia = DR.Item("colonia")
                            .curp = DR.Item("CURP")
                            .telefono = DR.Item("Telefono")
                            If Not IsDBNull(DR.Item("PaginaWeb")) Then
                                .paginaWeb = DR.Item("PaginaWeb")
                            Else
                                .paginaWeb = ""
                            End If

                        End With
                    End While
                    With clEmpresa
                        Me.TextBox_Logo.Text = .Logotipo
                        Me.TextBox_RazonSocial.Text = .Razon_Social
                        Me.TextBox_RFC.Text = .RFC
                        Me.TextBox_Calle.Text = .Calle
                        Me.TextBox_NumExt.Text = .noExterior
                        Me.TextBox_NumInt.Text = .noInterior
                        Me.ComboBox_Localidad.Text = .localidad
                        Me.ComboBox_Municipio.Text = .municipio
                        Me.ComboBox_Estado.Text = .estado
                        Me.ComboBox_Pais.Text = .pais
                        Me.TextBox_CP.Text = .codigoPostal
                        Me.TextBox_Email.Text = .email
                        Me.TextBox_Eslogan.Text = .eslogan
                        Me.TextBox_Colonia.Text = .colonia
                        Me.TextBox_CURP.Text = .curp
                        Me.TextBox_Telefono.Text = .telefono
                        Me.TextBox_PagWeb.Text = .paginaWeb
                    End With
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
                            'If .Regimen = "" Then
                            .Regimen = DR.Item("Regimen")
                            'Else
                            '    .Regimen = .Regimen + ", " + DR.Item("Regimen")
                            'End If
                            Select Case .Regimen
                                Case "Actividades Comerciales"
                                    Me.CheckBox_Act_Comerciales.Checked = True
                                Case "Adquisicion de bienes"
                                    Me.CheckBox_AdquisicionBienes.Checked = True
                                Case "Arrendamiento de bienes inmuebles"
                                    Me.CheckBox_Arrendamiento.Checked = True
                                Case "Dividendos y ganancias distribuidas por personas morales"
                                    Me.CheckBox_DividendosyGanancias.Checked = True
                                Case "Intereses"
                                    Me.CheckBox_Intereses.Checked = True
                                Case "Intermedio"
                                    Me.CheckBox_Intermedio.Checked = True
                                Case "Obtencion de premios"
                                    Me.CheckBox_ObtPremios.Checked = True
                                Case "Otros ingresos para personas fisicas"
                                    Me.CheckBox_OtrosIngresosPF.Checked = True
                                Case "Prestacion de servicios"
                                    Me.CheckBox_PrestacionServicios.Checked = True
                                Case "Pequeño contribuyente (REPECO)"
                                    Me.CheckBox_REPECO.Checked = True
                                Case "Regimen de personas fisicas con actividades empresariales y profesionales"
                                    Me.CheckBox_RPersonasFisicasAEP.Checked = True
                                Case "Regimen de personas fisicas con actividades empresariales"
                                    Me.CheckBox_RIntermedioPersonasFisicasAE.Checked = True
                                Case "Trabajar por salarios"
                                    Me.CheckBox_Salarios.Checked = True
                                Case "Personas Morales Regimen General de Ley"
                                    Me.CheckBox_PersonasMoralesRegimenGeneraldeLey.Checked = True
                            End Select
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


    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        Dim Logotipo As String = Nothing
        Dim RFC As String = Nothing
        Dim Razon_Social As String = Nothing
        Dim Tipo_Persona As String = Nothing
        Dim CURP As String = Nothing
        Dim Dir As New Domicilios
        Dim Telefono As String = Nothing
        Dim PagWeb As String = Nothing
        Dim email As String = Nothing
        Dim Slogan As String = Nothing
        Dim Regimen As New List(Of Integer)
        Dim Id_DomicilioFiscal As Integer = 0
        Dim Id_Emisor As Integer = 0
        Logotipo = Me.TextBox_Logo.Text
        RFC = Trim(Me.TextBox_RFC.Text)
        If RFC = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_RFC.Focus()
            Exit Sub
        Else
            Dim Guion As Integer = 0
            Dim Espacio As Integer = 0
            Dim SearchString, SearchChar As String
            SearchString = Trim(RFC)
            SearchChar = Trim("-")
            Guion = InStr(SearchString, SearchChar)
            Espacio = InStr(RFC, " ")
            If Guion <> 0 Or Espacio <> 0 Then
                MessageBox.Show("Introdusca el RFC sin guiones ni espacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If (Not String.IsNullOrEmpty(TextBox_RFC.Text)) Then
                    TextBox_RFC.SelectionStart = 0
                    TextBox_RFC.SelectionLength = TextBox_RFC.Text.Length
                End If
                Me.TextBox_RFC.Focus()
                Exit Sub
            End If
            If Len(RFC) < 12 Or Len(RFC) > 13 Then
                MessageBox.Show("RFC Invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If (Not String.IsNullOrEmpty(TextBox_RFC.Text)) Then
                    TextBox_RFC.SelectionStart = 0
                    TextBox_RFC.SelectionLength = TextBox_RFC.Text.Length
                End If
                Me.TextBox_RFC.Focus()
                Exit Sub
            End If
        End If
        Razon_Social = Me.TextBox_RazonSocial.Text
        If Me.RadioButton_PersonaFisica.Checked = True Then
            Tipo_Persona = "Persona Fisica"
        ElseIf Me.RadioButton_PersonaMoral.Checked = True Then
            Tipo_Persona = "Persona Moral"
        End If
        CURP = Me.TextBox_CURP.Text
        With Dir
            .Calle = Me.TextBox_Calle.Text
            .codigoPostal = Me.TextBox_CP.Text
            .colonia = Me.TextBox_Colonia.Text
            .noExterior = Me.TextBox_NumExt.Text
            .noInterior = Me.TextBox_NumInt.Text
            .referencia = Me.TextBox_Referencia.Text
            .localidad = Me.ComboBox_Localidad.SelectedValue
        End With
        email = Me.TextBox_Email.Text
        Telefono = Me.TextBox_Telefono.Text
        Slogan = Me.TextBox_Eslogan.Text
        PagWeb = Me.TextBox_PagWeb.Text



        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            If Me.CheckBox_Act_Comerciales.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Actividades Comerciales")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_AdquisicionBienes.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Adquisicion de bienes")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_Arrendamiento.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Arrendamiento de bienes inmuebles")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_DividendosyGanancias.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Dividendos y ganancias distribuidas por personas morales")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_Intereses.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Intereses")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_Intermedio.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Intermedio")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_ObtPremios.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Obtencion de premios")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_OtrosIngresosPF.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Otros ingresos para personas fisicas")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_PrestacionServicios.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Prestacion de servicios")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_REPECO.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Pequeño contribuyente (REPECO)")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_RIntermedioPersonasFisicasAE.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Regimen Intermedio de las personas fisicas con actividades empresariales")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_RPersonasFisicasAEP.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Regimen de personas fisicas con actividades empresariales y profesionales")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_Salarios.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Trabajar por salarios")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            If Me.CheckBox_PersonasMoralesRegimenGeneraldeLey.Checked = True Then
                Try
                    Cx.Open()
                    SQL_Str = "Select Id_RegimenFiscal from RegimenFiscal where Regimen = @RegimenFiscal"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = SQL_Str
                    Cmd.Parameters.AddWithValue("@RegimenFiscal", "Personas Morales Regimen General de Ley")
                    Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    With DR
                        If .HasRows Then
                            While .Read
                                Regimen.Add(DR("Id_RegimenFiscal"))
                            End While
                        End If
                    End With
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
            Dim Transaccion As SqlTransaction = Nothing
            Try
                Cx.Open()
                Transaccion = Cx.BeginTransaction("Actualiza Negocio")
                SQL_Str = "Update ExpedidoEn set Calle = @Calle2, noExterior = @noExterior2, noInterior = @noInterior2, Colonia = @Colonia2, Id_Localidad = @Id_Localidad2," &
                    " referencia = @referencia2, codigoPostal = @codigoPostal2,Nombre = @nombre2, Clave = @clave2, Telefono = @Telefono2, email = @email2" &
                    " Where Id_ExpedidoEn = (Select Id_ExpedidoEn from Emisor Where Id_Emisor = @IdEmisor)"
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Transaction = Transaccion
                Cmd.Parameters.AddWithValue("@Calle2", Dir.Calle)
                Cmd.Parameters.AddWithValue("@noExterior2", Dir.noExterior)
                Cmd.Parameters.AddWithValue("@noInterior2", Dir.noInterior)
                Cmd.Parameters.AddWithValue("@Colonia2", Dir.colonia)
                Cmd.Parameters.AddWithValue("@Id_Localidad2", Dir.localidad)
                Cmd.Parameters.AddWithValue("@referencia2", Dir.referencia)
                Cmd.Parameters.AddWithValue("@codigoPostal2", Dir.codigoPostal)
                Cmd.Parameters.AddWithValue("@nombre2", "Matriz")
                Cmd.Parameters.AddWithValue("@clave2", "Matriz")
                Cmd.Parameters.AddWithValue("@Telefono2", Telefono)
                Cmd.Parameters.AddWithValue("@email2", email)
                Cmd.Parameters.AddWithValue("@IdEmisor", Emisor)
                Cmd.ExecuteNonQuery()

                SQL_Str = "Update Emisor set rfc= @rfc, nombre =@nombre" &
                    " Where Id_Emisor = @Id_Emisor1"
                Cmd.CommandText = SQL_Str
                Cmd.CommandType = CommandType.Text
                Cmd.Transaction = Transaccion
                Cmd.Parameters.AddWithValue("@rfc", RFC)
                Cmd.Parameters.AddWithValue("@nombre", Razon_Social)
                Cmd.Parameters.AddWithValue("@ID_Emisor1", Emisor)
                Cmd.ExecuteNonQuery()

                SQL_Str = "Update DomicilioFiscal set Calle = @Calle, noExterior = @noExterior, noInterior = @noInterior, Colonia = @Colonia," &
                    " Id_Localidad = @Id_Localidad, referencia = @referencia, codigoPostal = @codigoPostal" &
                    " Where Id_DomicilioFiscal = (Select Id_DomicilioFiscal from Emisor where id_Emisor = @Id_Emisor2)"

                Cmd.CommandType = CommandType.Text
                Cmd.Transaction = Transaccion
                Cmd.CommandText = SQL_Str
                Cmd.Parameters.AddWithValue("@Calle", Dir.Calle)
                Cmd.Parameters.AddWithValue("@noExterior", Dir.noExterior)
                Cmd.Parameters.AddWithValue("@noInterior", Dir.noInterior)
                Cmd.Parameters.AddWithValue("@Colonia", Dir.colonia)
                Cmd.Parameters.AddWithValue("@Id_Localidad", Dir.localidad)
                Cmd.Parameters.AddWithValue("@referencia", Dir.referencia)
                Cmd.Parameters.AddWithValue("@codigoPostal", Dir.codigoPostal)
                Cmd.Parameters.AddWithValue("@ID_Emisor2", Emisor)
                Cmd.ExecuteNonQuery()


                SQL_Str = "Update Empresa Set Logotipo = @Logotipo, email = @email, tipo_Persona = @tipo_Persona, CURP = @CURP, Telefono = @Telefono, Eslogan = @Eslogan ,Folios = @Folios" &
                    " Where Id_Emisor = @Id_Emisor3"
                Cmd.CommandText = SQL_Str
                Cmd.CommandType = CommandType.Text
                Cmd.Transaction = Transaccion
                Cmd.CommandText = SQL_Str
                Cmd.Parameters.AddWithValue("@Id_Emisor3", Id_Emisor)
                Cmd.Parameters.AddWithValue("@Logotipo", Logotipo)
                Cmd.Parameters.AddWithValue("@email", email)
                Cmd.Parameters.AddWithValue("@tipo_Persona", Tipo_Persona)
                Cmd.Parameters.AddWithValue("@CURP", CURP)
                Cmd.Parameters.AddWithValue("@Telefono", Telefono)
                Cmd.Parameters.AddWithValue("@Eslogan", Slogan)
                Cmd.Parameters.AddWithValue("@Folios", 0)

                Cmd.ExecuteNonQuery()

                SQL_Str = "Delete RegimenxEmisor Where Id_Emisor = @Id_Emisor4"
                Cmd.CommandText = SQL_Str
                Cmd.CommandType = CommandType.Text
                Cmd.Transaction = Transaccion
                Cmd.CommandText = SQL_Str
                Cmd.Parameters.AddWithValue("@Id_Emisor4", Id_Emisor)
                Cmd.ExecuteNonQuery()

                For Each Registro As Integer In Regimen
                    SQL_Str = "Insert into RegimenxEmisor (Id_Emisor, Id_RegimenFiscal)" &
                    " Values (" & Emisor & "," & Registro & ")"
                    Cmd.CommandText = SQL_Str
                    Cmd.CommandType = CommandType.Text
                    Cmd.Transaction = Transaccion
                    Cmd.CommandText = SQL_Str
                    Cmd.ExecuteNonQuery()
                Next
                Transaccion.Commit()
                Dim RutaLogo As String = Nothing

                Me.Close()
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
        End Using
    End Sub
End Class