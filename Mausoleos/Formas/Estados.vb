Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class Estados
#Region "Variables"
    Dim Id_Pais As Integer
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)

#End Region
    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Me.Close()
    End Sub
    Private Sub Btn_Aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Aceptar.Click
        Guarda()
    End Sub
    Sub Guarda()
        Dim Estado As String = ""
        Dim Sql_str As String = ""
        Estado = Me.Txt_Estado.Text
        If Estado = "" Then
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Try
                Cx.Open()
                '////////////////////////////////////////////////////
                'Verifico que no exista el estado
                '////////////////////////////////////////////////////
                Sql_str = "Select * from Estado where Estado = @Descr and id_paises = @id_pais"
                Dim Cmd_Revisa As SqlCommand = New SqlCommand(Sql_str, Cx)
                Cmd_Revisa.Parameters.AddWithValue("@Descr", Estado)
                Cmd_Revisa.Parameters.AddWithValue("@Id_Pais", Id_Pais)
                Dim Tot As Integer = 0
                Cmd_Revisa.CommandType = CommandType.Text
                Tot = CInt(Cmd_Revisa.ExecuteScalar)
                Cx.Close()
                If Tot >= 1 Then
                    MessageBox.Show("Ya existe este Estado en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                '////////////////////////////////////////////////////
                'Si no existe el Estado lo guardo
                '////////////////////////////////////////////////////
                If Cx.State = ConnectionState.Closed Then
                    Cx.Open()
                End If
                Sql_str = "Insert into Estado (Estado,Id_Paises) Values(@Estado,@Pais)"
                Dim Cmd_Inserta As SqlCommand = New SqlCommand(Sql_str, Cx)
                Cmd_Inserta.Parameters.AddWithValue("@Estado", Estado)
                Cmd_Inserta.Parameters.AddWithValue("@Pais", Id_Pais)
                Cmd_Inserta.CommandType = CommandType.Text
                Cmd_Inserta.ExecuteNonQuery()
                '////////////////////////////////////////////////////
                'ya que guarde el el Estado en la Base de Datos lo agrego al listbox
                '////////////////////////////////////////////////////
                'Me.ListBox.Items.Clear()
                Cx.Close()
                Cargar_Estados()
                Me.Txt_Estado.Text = ""
                Me.Txt_Estado.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End If
    End Sub
    Private Sub Txt_Estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Estado.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Guarda()
        End If
    End Sub
    Private Sub Estados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Paises()
        Cargar_Estados()
    End Sub
    Sub Cargar_Paises()
        Dim SQL_Str As String = "Select * from Paises order by Pais"
        Try
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Paises")
            With Me.ComboBox1
                .DataSource = DS.Tables("Paises")
                .DisplayMember = "Pais"
                .ValueMember = "ID_Paises"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
        Me.Txt_Estado.Text = ""
        Me.Txt_Estado.Focus()
    End Sub
    Sub Cargar_Estados()
        Try
            Id_Pais = Me.ComboBox1.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try

        Dim SQL_Str As String = "Select * from Estado where Id_Paises = " & Id_Pais & " order by Estado"
        Try
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Estados")
            With Me.ListBox
                .DataSource = DS.Tables("Estados")
                .DisplayMember = "Estado"
                .ValueMember = "Id_Estado"
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
    Private Sub Btn_Borrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Borrar.Click
        Dim Pais As Integer = Me.ComboBox1.SelectedValue
        Dim Estado As Integer = 0
        Estado = Me.ListBox.SelectedValue
        If Estado = 0 Then
            MessageBox.Show("Debe de seleccionar un Estado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Try
                Cx.Open()
                Dim SQL_Str As String = "Delete from Estado where id_Estado = @Estado and id_Paises = @Pais"
                Dim Cmd_Borra As SqlCommand = New SqlCommand(SQL_Str, Cx)
                Cmd_Borra.CommandType = CommandType.Text
                Cmd_Borra.Parameters.AddWithValue("@Estado", Estado)
                Cmd_Borra.Parameters.AddWithValue("@Pais", Pais)
                Cmd_Borra.ExecuteNonQuery()
                Cx.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
                Cargar_Estados()
            End Try
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Cargar_Estados()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New Paises
        frm.ShowDialog()
        Cargar_Paises()

    End Sub
End Class