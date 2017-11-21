Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class Listado_Gavetas
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Dim Sql_Str As String = Nothing

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Close()

    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim columna As Integer, fila As Integer
        Dim ID_Servicio As Integer = 0
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Try
            Dim Id_Gaveta As Integer = Me.DataGridView1(columna, fila).Value
            If Id_Gaveta = 0 Then
                MessageBox.Show("Debe seleccionar un nicho", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView1.Focus()
                Exit Sub
            Else
                Using Cx As New SqlConnection(CxSettings.ConnectionString)

                    Try
                        Cx.Open()
                        Sql_Str = "Delete Gavetas where id_Gaveta = @Id_Gaveta"
                        Dim Cmd As New SqlCommand(Sql_Str, Cx)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Parameters.AddWithValue("@Id_Gaveta", Id_Gaveta)
                        Cmd.ExecuteNonQuery()
                        Carga_Datos()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Finally
                        If Cx.State = ConnectionState.Open Then
                            Cx.Close()
                        End If
                    End Try
                End Using

            End If
        Catch ex As Exception
            MessageBox.Show("Debe seleccionar un nicho", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView1.Focus()
            Exit Sub
        End Try


    End Sub
    Sub Carga_Datos()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Sql_Str = "Declare @TableTemp Table(Nicho int, Planta nvarchar(100),Ubicacion nvarchar(100), Modulo int, Columna int, Fila nvarchar(10), Capacidad int, Observaciones nvarchar(MAX), Estado nvarchar(15))" &
                " Insert into @TableTemp Select Nicho, Planta,Ubicacion, Modulo, Columna, Fila, Capacidad , Observaciones, 'Disponible' from View_ListadoGavetas" &
                " Update @TableTemp Set Estado = 'Vendido' Where Nicho in(Select Id_Gaveta from Contratos Where Cancelado = 'False')" &
                " Select * from @TableTemp"
            Try
                Dim DA As New SqlDataAdapter(Sql_Str, Cx)
                Dim DS As New DataSet
                DA.Fill(DS, "Tabla")
                Me.DataGridView1.DataSource = DS.Tables("Tabla")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End Using
        With DataGridView1
            Dim Total As Integer = .RowCount
            If Total > 0 Then
                Dim Estado_Actual As String = Nothing
                Dim columna As Integer = 8
                Dim Fila As Integer = 0
                'For X = 0 To .RowCount - 1
                '    Fila = X
                '    Estado_Actual = Me.DataGridView1(columna, Fila).Value
                For Each Row As DataGridViewRow In DataGridView1.Rows
                    If Row.Cells(8).Value = "Vendido" Then
                        Row.DefaultCellStyle.BackColor = System.Drawing.Color.Red
                    End If
                Next

                'Next
            End If
        End With
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Dim frm As New Nueva_Gaveta
        frm.ShowDialog()
        Carga_Datos()

    End Sub

    Private Sub Listado_Gavetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Datos()

    End Sub

    Private Sub ToolStripButton_EditaNicho_Click(sender As Object, e As EventArgs) Handles ToolStripButton_EditaNicho.Click
        Dim columna As Integer, fila As Integer
        Dim ID_Servicio As Integer = 0
        columna = 0
        fila = Me.DataGridView1.CurrentCellAddress.Y
        Try
            Id_Gaveta_Actual = Me.DataGridView1(columna, fila).Value
            If Id_Gaveta_Actual = 0 Then
                MessageBox.Show("Debe seleccionar un nicho", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView1.Focus()
                Exit Sub
            Else
                Dim frm As New Edita_Gavetas
                frm.ShowDialog()
                Carga_Datos()
            End If
        Catch ex As Exception
            MessageBox.Show("Debe seleccionar un nicho", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView1.Focus()
            Exit Sub
        End Try
    End Sub
End Class