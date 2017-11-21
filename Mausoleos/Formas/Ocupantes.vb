Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration


Public Class Ocupantes
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
#End Region

#Region "Carga de Datos"
    Sub Carga_Beneficiarios()
        Try
            SQL_Str = "SELECT        Personas.ID_Personas, Beneficiarios.Id_Persona, Personas.Nombre" &
                " FROM            Personas INNER JOIN" &
                " Beneficiarios ON Personas.ID_Personas = Beneficiarios.Id_Persona" &
                " WHERE        (Beneficiarios.Id_Contrato = @Contrato)"
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Contrato", Id_Contrato)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.ComboBox_Nombre
                .DataSource = DS.Tables("Tabla")
                .DisplayMember = "Nombre"
                .ValueMember = "Id_Personas"
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        Dim Ocupante As Integer = 0
        Dim Fecha_Defuncion As DateTime = Nothing
        Dim Fecha_Ingreso As DateTime = Nothing
        Dim Formato_Autorizacion As Boolean = False
        Dim Certificado_Cremacion As Boolean = False
        Dim Acta_Defuncion As Boolean = False
        If CheckBox_Autorizacion.Checked = True Then
            Formato_Autorizacion = True
        Else
            Formato_Autorizacion = False
        End If
        If CheckBox_Cremacion.Checked = True Then
            Certificado_Cremacion = True
        Else
            Certificado_Cremacion = False

        End If
        If CheckBox_Defuncion.Checked = True Then
            Acta_Defuncion = True
        Else
            Acta_Defuncion = False
        End If
        Fecha_Defuncion = Me.DateTimePicker_Defuncion.Value
        Fecha_Ingreso = Me.DateTimePicker_Ingreso.Value
        Ocupante = Me.ComboBox_Nombre.SelectedValue
        If Ocupante = 0 Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Nombre.Focus()
            Exit Sub
        End If
        Try
            SQL_Str = "Insert into Ocupantes(Id_Contrato, Id_Persona, Fecha_Defuncion, Fecha_Ingreso, Certificado_Cremacion, Acta_Defuncion, Formato_Autorizacion)" &
                " Values(@Id_Contrato, @Id_Persona, @Fecha_Defuncion, @Fecha_Ingreso, @Certificado_Cremacion, @Acta_Defuncion, @Formato_Autorizacion)"
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Cmd.Parameters.AddWithValue("@Id_Persona", Ocupante)
            Cmd.Parameters.AddWithValue("@Fecha_Defuncion", Fecha_Defuncion)
            Cmd.Parameters.AddWithValue("@Fecha_Ingreso", Fecha_Ingreso)
            Cmd.Parameters.AddWithValue("@Certificado_Cremacion", Certificado_Cremacion)
            Cmd.Parameters.AddWithValue("@Acta_Defuncion", Acta_Defuncion)
            Cmd.Parameters.AddWithValue("@Formato_Autorizacion", Formato_Autorizacion)
            Cmd.ExecuteNonQuery()
            Me.Close()

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

    Private Sub Ocupantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Beneficiarios()


    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        Dim Frm As New AgregaSUD
        Frm.ShowDialog()
        Carga_SUD()
    End Sub
    Sub Carga_SUD()
        Try
            Cx.Open()
            SQL_Str = "Select SUD.Id_SUD, S.Servicio, SUD.Disponibles as Total, SUD.Utilizados, (SUD.Disponibles - SUD.Utilizados) as Disponibles" &
                " from Servicios_UtilizadosyDisponibles as SUD, Servicios as S" &
                " Where SUD.Id_Contrato = @Id_Contrato and SUD.Id_Servicio = S.Id_Servicio"
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
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

    Private Sub Button_Quitar_Click(sender As Object, e As EventArgs) Handles Button_Quitar.Click
        Dim Frm As New Edita_Servicios
        Frm.ShowDialog()
        Carga_SUD()
    End Sub
End Class