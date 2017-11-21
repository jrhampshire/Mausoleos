Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration



Public Class Listado_Usuarios

    Dim SQL_Str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)

    Private Sub Button_Salir_Click(sender As Object, e As EventArgs) Handles Button_Salir.Click
        Me.Close()
    End Sub

    Private Sub Button_Agregar_Click(sender As Object, e As EventArgs) Handles Button_Agregar.Click
        Dim frm As New Usuarios
        frm.ShowDialog()
        Carga_Datos()
    End Sub

    Private Sub Listado_Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Datos()
    End Sub

    Sub Carga_Datos()
        SQL_Str = "Select * from View_ListadoUsuarios"
        Try
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Usuarios")
            With Me.ListBox
                .DataSource = DS.Tables("Usuarios")
                .DisplayMember = "Nombre"
                .ValueMember = "Id_Usuarios"
            End With
        Catch ex As SqlException
            Beep()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            Beep()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_Editar_Click(sender As Object, e As EventArgs) Handles Button_Editar.Click
        Try
            Usuario_Edicion = CInt(Me.ListBox.SelectedValue.ToString)
        Catch ex As Exception
            Exit Sub
        End Try

        If Usuario_Edicion = 0 Then
            MessageBox.Show("Debe de Seleccionar un Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ListBox.Focus()
            Exit Sub
        Else
            Dim Frm_Edita As New Edita_Usuarios
            Frm_Edita.ShowDialog()
        End If
        Carga_Datos()
    End Sub
    ''' <summary>
    ''' No se borran los usuarios, solo se marcan como Activos = False
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button_Borrar_Click(sender As Object, e As EventArgs) Handles Button_Borrar.Click
        Try
            Usuario_Actual = CInt(Me.ListBox.SelectedValue.ToString)
        Catch ex As Exception
            Exit Sub
        End Try

        If Usuario_Actual = 0 Then
            MessageBox.Show("Debe de Seleccionar un Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ListBox.Focus()
            Exit Sub
        Else
            SQL_Str = "Update Usuarios set Activo = 'False' where id_Usuarios = @Id_Usuario"
            Try
                Cx.Open()
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Id_Usuario", Usuario_Actual)
                Cmd.ExecuteNonQuery()
            Catch ex As SqlException
                Beep()
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                Beep()
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
            Carga_Datos()
        End If
    End Sub
End Class