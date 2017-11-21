Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Beneficiarios
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
    Dim Paises_Cargados As Boolean = False
    Dim Estados_Cargados As Boolean = False
    Dim Municipios_Cargados As Boolean = False
    Private Sub Beneficiarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Parentescos()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            Me.GroupBox1.Enabled = True
            Carga_Paises()
            Me.TextBox_Calle.Focus()
        Else
            Me.GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub Button_Registrar_Click(sender As Object, e As EventArgs) Handles Button_Registrar.Click
        Dim Temp_Bene As New Beneficiarios_Class
        Dim Id_Domicilio, Id_Persona
        Dim Transaccion As SqlTransaction = Nothing
        Try
            With Temp_Bene
                If Me.CheckBox1.Checked = True Then
                    If Valida1() = True And Valida2() = True Then
                        .Nombre = Trim(Me.TextBox_Nombre.Text)
                        .Parentesco = Me.ComboBox_Parentesco.SelectedValue
                        .Fecha_Nac = Me.DateTimePicker1.Value
                        .Sexo = Me.ComboBox_Sexo.Text
                        .Calle = Trim(Me.TextBox_Calle.Text)
                        .Num_Ext = Trim(Me.TextBox_Num_Ext.Text)
                        .Num_Int = Trim(Me.TextBox_Num_Int.Text)
                        .Colonia = Trim(Me.TextBox_Colonia.Text)
                        .Localidad = Me.ComboBox_Localidad.SelectedValue
                        .Telefono = Trim(Me.TextBox_Telefono.Text)
                        .Celular = Trim(Me.TextBox_Cel.Text)
                        .CP = Trim(Me.TextBox_CP.Text)
                        .Notas = Trim(Me.TextBox_Notas.Text)
                        Dim TitularSubs As Boolean = False
                        If Me.CheckBox_Titular.Checked = True Then
                            TitularSubs = True
                        Else
                            TitularSubs = False
                        End If
                        Cx.Open()
                        Transaccion = Cx.BeginTransaction("Inserta Beneficiario")
                        SQL_Str = "Insert into Domicilio(Calle, noExterior, noInterior, colonia, Id_Localidad, referencia, codigoPostal)" &
                            " Values(@Calle, @noExterior, @noInterior, @colonia, @Id_Localidad, @referencia, @codigoPostal);" &
                            " Select @ID = @@Identity"

                        Dim Cmd As New SqlCommand(SQL_Str, Cx)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Transaction = Transaccion
                        Cmd.Parameters.AddWithValue("@Calle", .Calle)
                        Cmd.Parameters.AddWithValue("@noExterior", .Num_Ext)
                        Cmd.Parameters.AddWithValue("@noInterior", .Num_Int)
                        Cmd.Parameters.AddWithValue("@colonia", .Colonia)
                        Cmd.Parameters.AddWithValue("@Id_Localidad", .Localidad)
                        Cmd.Parameters.AddWithValue("@referencia", "")
                        Cmd.Parameters.AddWithValue("@codigoPostal", .CP)
                        Cmd.Parameters.Add("@ID", SqlDbType.Int)
                        Cmd.Parameters("@ID").Direction = ParameterDirection.Output
                        Cmd.ExecuteNonQuery()
                        Id_Domicilio = Cmd.Parameters("@ID").Value.ToString()
                        SQL_Str = "Insert into Personas (Id_Domicilio, Nombre) Values(@Id_Domicilio,@Nombre);" &
                            " Select @IDPersona = @@Identity"
                        Cmd.CommandText = SQL_Str
                        Cmd.Parameters.AddWithValue("@Id_Domicilio", Id_Domicilio)
                        Cmd.Parameters.AddWithValue("@Nombre", .Nombre)
                        Cmd.Parameters.Add("@IDPersona", SqlDbType.Int)
                        Cmd.Parameters("@IDPersona").Direction = ParameterDirection.Output
                        Cmd.ExecuteNonQuery()
                        Id_Persona = Cmd.Parameters("@IDPersona").Value.ToString()
                        SQL_Str = "Insert into Beneficiarios (Id_Contrato, Id_Persona, Id_Parentesco, Observaciones, TitularSustituto)" &
                            "Values(@Id_Contrato, @Id_Persona, @Id_Parentesco, @Observaciones, @TitularSustituto)"
                        Cmd.CommandText = SQL_Str
                        Cmd.Parameters.AddWithValue("@Id_Persona", Id_Persona)
                        Cmd.Parameters.AddWithValue("@Id_Parentesco", .Parentesco)
                        Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
                        Cmd.Parameters.AddWithValue("@Observaciones", .Notas)
                        Cmd.Parameters.AddWithValue("@TitularSustituto", TitularSubs)
                        Cmd.ExecuteNonQuery()
                        Transaccion.Commit()
                    Else
                        Exit Sub
                    End If
                Else
                    If Valida1() = True Then
                        .Nombre = Trim(Me.TextBox_Nombre.Text)
                        .Parentesco = Me.ComboBox_Parentesco.SelectedValue
                        .Fecha_Nac = Me.DateTimePicker1.Value
                        .Sexo = Me.ComboBox_Sexo.Text
                        .Notas = Trim(Me.TextBox_Notas.Text)
                        Dim TitularSubs As Boolean = False
                        If Me.CheckBox_Titular.Checked = True Then
                            TitularSubs = True
                            TitularSubstituto = Me.TextBox_Nombre.Text
                            ParentescoTitular = Me.ComboBox_Parentesco.Text
                        Else
                            TitularSubs = False
                        End If
                        Cx.Open()
                        Transaccion = Cx.BeginTransaction("Inserta Beneficiario")
                        SQL_Str = "Insert into Personas ( Nombre) Values(@Nombre);" &
                            " Select @IDPersona = @@Identity"
                        Dim Cmd As New SqlCommand(SQL_Str, Cx)
                        Cmd.Transaction = Transaccion
                        Cmd.Parameters.AddWithValue("@Nombre", .Nombre)
                        Cmd.Parameters.Add("@IDPersona", SqlDbType.Int)
                        Cmd.Parameters("@IDPersona").Direction = ParameterDirection.Output
                        Cmd.ExecuteNonQuery()
                        Id_Persona = Cmd.Parameters("@IDPersona").Value.ToString()
                        SQL_Str = "Insert into Beneficiarios (Id_Contrato, Id_Persona, Id_Parentesco, Observaciones, TitularSustituto)" &
                            "Values(@Id_Contrato, @Id_Persona, @Id_Parentesco, @Observaciones, @TitularSustituto)"
                        Cmd.CommandText = SQL_Str
                        Cmd.Parameters.AddWithValue("@Id_Persona", Id_Persona)
                        Cmd.Parameters.AddWithValue("@Id_Parentesco", .Parentesco)
                        Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
                        Cmd.Parameters.AddWithValue("@Observaciones", .Notas)
                        Cmd.Parameters.AddWithValue("@TitularSustituto", TitularSubs)
                        Cmd.ExecuteNonQuery()
                        Transaccion.Commit()
                    Else
                        Exit Sub
                    End If
                End If
            End With
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
        Me.Close()
    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

#Region "Valida Datos"
    Function Valida1() As Boolean
        Dim Valor As Boolean = True
        If Trim(Me.TextBox_Nombre.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_Nombre.Focus()
            Valor = False
        End If
        If Trim(Me.ComboBox_Parentesco.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Parentesco.Focus()
            Valor = False
        End If
        If Trim(Me.ComboBox_Sexo.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Sexo.Focus()
            Valor = False
        End If
        Return Valor
    End Function
    Function Valida2() As Boolean
        Dim Valor As Boolean = True
        If Trim(Me.TextBox_Calle.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_Calle.Focus()
            Valor = False
        End If
        If Trim(Me.TextBox_CP.Text) = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TextBox_CP.Focus()
            Valor = False
        End If
        Return Valor
    End Function

    Private Sub TextBox_CP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_CP.KeyPress
        'Aqui verificamos si la tecla presionada es una letra si es asi entonces no se tomara o no se mostrara la letra.
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            'Aqui verifica si se ha presionado alguna tecla de control, puede ser backspace,tabulardor, si es asi lo dejara pasar normal pork puedes borrar.
            If Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                'Aqui verifica si es un separador o espacio en blanco, si es asi no lo dejara pasar.
                If Char.IsSeparator(e.KeyChar) Then
                    e.Handled = True
                Else
                    'Aqui Verifica si la tecla presionada es un número, si es asi normal lo deja pasar.
                    If Char.IsDigit(e.KeyChar) Then
                        e.Handled = False
                    Else
                        e.Handled = True
                    End If
                End If
            End If
        End If
    End Sub

#End Region

#Region "Carga Datos"

    Sub Carga_Parentescos()

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select * from Parentescos order by Parentesco"
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Parentescos")
            With ComboBox_Parentesco
                .DataSource = DS.Tables(0)
                .DisplayMember = "Parentesco"
                .ValueMember = "Id_Parentesco"
            End With
            ComboBox_Pais.Text = ""
            Paises_Cargados = True
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

    End Sub

    Sub Carga_Paises()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)

            Try
                Cx.Open()
                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "Select * from Paises order by Pais"
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Paises")
                With ComboBox_Pais
                    .DataSource = DS.Tables(0)
                    .DisplayMember = "Pais"
                    .ValueMember = "Id_Paises"
                End With
                ComboBox_Pais.Text = ""
                Paises_Cargados = True
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using
    End Sub

    Sub Carga_Estados()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Id_Pais As Integer = 0
            Try
                Id_Pais = Me.ComboBox_Pais.SelectedValue
            Catch ex As Exception
                ' MessageBox.Show("Se debe de seleccionar un pais primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ComboBox_Pais.Focus()
                Exit Sub
            End Try

            Try
                Cx.Open()
                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = "Select * from Estado where id_Paises = @IdPais order by estado"
                Cmd.Parameters.AddWithValue("@IdPais", Id_Pais)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Estados")
                With ComboBox_Estado
                    .DataSource = DS.Tables(0)
                    .DisplayMember = "Estado"
                    .ValueMember = "Id_Estado"
                End With
                ComboBox_Estado.Text = ""
                Estados_Cargados = True
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using

    End Sub

    Sub Carga_Municipios()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Id_Estado As Integer
            Try
                Id_Estado = Me.ComboBox_Estado.SelectedValue
            Catch ex As Exception
                ' MessageBox.Show("Se debe de seleccionar un Estado primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ComboBox_Estado.Focus()
                Exit Sub
            End Try


            Try
                Cx.Open()
                Dim Cmd As New SqlCommand
                Cmd.Connection = Cx
                Cmd.CommandText = "Select * from Municipio where id_Estado = @IdEstado order by Municipio"
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@IdEstado", Id_Estado)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Municipios")
                With ComboBox_Municipio
                    .DataSource = DS.Tables(0)
                    .DisplayMember = "Municipio"
                    .ValueMember = "Id_Municipio"
                End With
                ComboBox_Municipio.Text = ""
                Municipios_Cargados = True
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using

    End Sub

    Sub Carga_Ciudades()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Dim Id_Cd As Integer
            Try
                Id_Cd = Me.ComboBox_Municipio.SelectedValue
            Catch ex As Exception
                'MessageBox.Show("Se debe de seleccionar una Ciudad primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ComboBox_Estado.Focus()
                Exit Sub
            End Try


            Try
                Cx.Open()
                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandText = "Select * from Localidad where id_Municipio = @IdMunicipio order by Localidad"
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@IdMunicipio", Id_Cd)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Ciudades")
                With ComboBox_Localidad
                    .DataSource = DS.Tables(0)
                    .DisplayMember = "Localidad"
                    .ValueMember = "Id_Localidad"
                End With
                ComboBox_Localidad.Text = ""
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using


    End Sub

    Private Sub ComboBox_Pais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox_Pais.KeyPress
        Me.ComboBox_Pais.Text = ""
        Me.ComboBox_Pais.Focus()
    End Sub

    Private Sub ComboBox_Pais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Pais.SelectedIndexChanged
        If Paises_Cargados = True Then
            Carga_Estados()
        End If
        Me.ComboBox_Estado.Focus()
    End Sub

    Private Sub ComboBox_Estado_KeyPress(sender As Object, e As KeyPressEventArgs)
        Me.ComboBox_Estado.Text = ""
        Me.ComboBox_Estado.Focus()
    End Sub

    Private Sub ComboBox_Municipio_KeyPress(sender As Object, e As KeyPressEventArgs)
        Me.ComboBox_Municipio.Text = ""
        Me.ComboBox_Municipio.Focus()
    End Sub

    Private Sub ComboBox_Estado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Estado.SelectedIndexChanged
        If Estados_Cargados = True Then
            Carga_Municipios()
        End If
        Me.ComboBox_Municipio.Focus()
    End Sub

    Private Sub ComboBox_Municipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Municipio.SelectedIndexChanged
        If Municipios_Cargados = True Then
            Carga_Ciudades()
        End If
        Me.ComboBox_Localidad.Focus()
    End Sub

#End Region


End Class