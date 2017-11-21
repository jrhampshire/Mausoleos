Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Listado_Contratos
#Region "Variables"
    Dim SQL_Str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
#End Region
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
    Sub Carga_Datos()
        Try
            SQL_Str = "Select * from View_Listado_Clientes_1 Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(SQL_Str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With Me.DataGridView_Contratos
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
    Private Sub ToolStripButton_Aceptar_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Aceptar.Click
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView_Contratos.CurrentCellAddress.Y
        Try
            Id_Contrato = Me.DataGridView_Contratos(columna, fila).Value
            If Id_Contrato = 0 Then
                MessageBox.Show("Debe seleccionar un Contrato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView_Contratos.Focus()
                Exit Sub
            Else
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Debe seleccionar un Contrato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView_Contratos.Focus()
            Exit Sub
        End Try
    End Sub

    Private Sub Listado_Contratos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Datos()

    End Sub


End Class