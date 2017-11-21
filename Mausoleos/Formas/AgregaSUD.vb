Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class AgregaSUD
#Region "Variables"
    Dim SQL_Str As String = Nothing
    Dim CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Dim Servicios_Cargados As Boolean = False
#End Region
    Private Sub AgregaSUD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Combobox()
    End Sub

#Region "Carga Datos"
    Sub Carga_Combobox()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)

            Try
                Cx.Open()
                Dim Cmd As New SqlCommand
                Cmd.Connection = Cx
                Cmd.CommandText = "Select Servicio, Id_Servicio from Servicios Where Id_Servicio in" &
                " (Select Id_Servicio from Servicios_UtilizadosyDisponibles Where id_Contrato = @Id_Contrato)"
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
                Dim DA As New SqlDataAdapter(Cmd)
                Dim DS As New DataSet
                DA.Fill(DS, "Tabla")
                With ComboBox1
                    .DataSource = DS.Tables("Tabla")
                    .DisplayMember = "Servicio"
                    .ValueMember = "Id_Servicio"
                End With
                Servicios_Cargados = True
                Carga_Disponibles()

            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using
    End Sub
    Sub Carga_Disponibles()
        Dim Id_Serv As Integer = 0
        Dim SrvDisp As Integer = 0
        Try
            Id_Serv = Me.ComboBox1.SelectedValue
        Catch ex As Exception
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox1.Focus()
            Exit Sub
        End Try
        Using Cx As New SqlConnection(CxSettings.ConnectionString)

            Try
                Cx.Open()
                Dim Cmd As New SqlCommand
                Cmd.Connection = Cx
                Cmd.CommandText = "Select (Disponibles - Utilizados) as Total from Servicios_UtilizadosyDisponibles Where Id_Contrato = @id_Contrato and Id_Servicio = @Id_Servicio"
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Id_Servicio", Id_Serv)
                Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
                Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If DR.HasRows Then
                    While DR.Read
                        SrvDisp = DR.Item(0)
                    End While
                End If
                Me.NumericUpDown1.Maximum = SrvDisp
            Catch ex As SqlException
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End Try
        End Using
    End Sub
#End Region

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Servicios_Cargados = True Then
            Carga_Disponibles()
        End If
    End Sub

    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        Dim Id_Srv As Integer = 0
        Dim Cant As Integer = 0
        Dim SrvDisp As Integer = 0
        Try
            Id_Srv = Me.ComboBox1.SelectedValue
        Catch ex As Exception
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox1.Focus()
            Exit Sub
        End Try
        Cant = Me.NumericUpDown1.Value
        If Cant = 0 Then
            MessageBox.Show("Este dato debe ser mayor de cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.NumericUpDown1.Focus()
            Exit Sub
        Else
            Using Cx As New SqlConnection(CxSettings.ConnectionString)
                Try
                    Cx.Open()
                    SQL_Str = "Update Servicios_UtilizadosyDisponibles Set Utilizados = Utilizados + @Utilizados" &
                        " Where Id_Contrato = @Id_Contrato and Id_Servicio = @Id_Servicio"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Parameters.AddWithValue("@Utilizados", Cant)
                    Cmd.Parameters.AddWithValue("@Id_Servicio", Id_Srv)
                    Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
                    Cmd.ExecuteNonQuery()

                Catch ex As SqlException
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Finally
                    Try
                        Close()
                    Catch ex As ObjectDisposedException
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Catch ex As InvalidOperationException
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End Try
                End Try
            End Using
        End If
    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()

    End Sub
End Class