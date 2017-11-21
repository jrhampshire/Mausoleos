Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
''' <summary>
''' Falta Editar Productos y Borrar
''' tambien falta la busqueda por palabra
''' Falta Exportar a Excell
''' </summary>
''' <remarks></remarks>
Public Class Listado_Productos_Servicios
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Dim Sql_Str As String = Nothing

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim frm As New Conceptos
        frm.ShowDialog()
        Carga_Productos()

    End Sub

    Private Sub Listado_Productos_Servicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Carga_Productos()

    End Sub
    Sub Carga_Productos()
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Sql_Str = "Select P.Clave, P.Descripcion, U.Descripcion as Unidad, P.valorUnitario , F.Descripcion as Familia " &
                " From ProductosyServicios as P, Unidades as U, Familias as F" &
                " Where P.Id_Unidad = U.Id_Unidad and P.Id_Familia = F.Id_Familia AND P.Activo = 'True'" &
                " Order by P.Descripcion"
            Try
                Dim DA As New SqlDataAdapter(Sql_Str, Cx)
                Dim DS As New DataSet
                DA.Fill(DS, "Tabla")
                Me.DataGridView.DataSource = DS.Tables("Tabla")
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

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView.CurrentCellAddress.Y
        Clave_Servicio = Me.DataGridView(columna, fila).Value
        If Clave_Servicio = Nothing Or Clave_Servicio = "" Then
            MessageBox.Show("Debe seleccionar un producto para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView.Focus()
            Exit Sub
        Else
            Dim frm As New Edita_Productos
            frm.ShowDialog()
            Carga_Productos()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Borra_Producto()

    End Sub
    Sub Borra_Producto()
        Dim result As DialogResult = MessageBox.Show(Me, "Esta a punto de eliminar un producto o Servicio, ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Dim columna As Integer, fila As Integer

            columna = 0
            Using Cx As New SqlConnection(CxSettings.ConnectionString)
                fila = Me.DataGridView.CurrentCellAddress.Y
                Dim Registros_Encontrados As Integer = 0

                If Clave_Servicio = Nothing Or Clave_Servicio = "" Then
                    MessageBox.Show("Debe seleccionar un Servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DataGridView.Focus()
                    Exit Sub
                Else
                    Try
                        Sql_Str = "Select count(noIdentificacion) from concepto where noIdentificacion = @Clave"
                        Cx.Open()
                        Dim Cmd As New SqlCommand(Sql_Str, Cx)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Parameters.AddWithValue("@Clave", Clave_Servicio)
                        Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        If DR.HasRows Then
                            While DR.Read
                                If IsDBNull(DR.Item(0)) Then
                                    Registros_Encontrados = 0
                                Else
                                    Registros_Encontrados = CInt(DR.Item(0))
                                End If
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
                    If Registros_Encontrados = 0 Then
                        Try
                            Cx.Open()
                            Sql_Str = "Update ProductosyServicios set Activo = 'False' where Clave = @Clave"
                            Dim Cmd2 As New SqlCommand(Sql_Str, Cx)
                            Cmd2.CommandType = CommandType.Text
                            Cmd2.Parameters.AddWithValue("@Clave", Clave_Servicio)
                            Cmd2.ExecuteNonQuery()

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
                    Else

                        MessageBox.Show("No se puede eliminar el Producto o Servicio ya que existen una o mas facturas con el mismo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            End Using
            Carga_Productos()
        End If
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Busca()

    End Sub
    Sub Busca()
        Dim Busqueda As String = Me.Txt_Busca.Text
        If Busqueda = "" Then
            MessageBox.Show("Introdusca su busqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Txt_Busca.Focus()
            Exit Sub
        End If
        Using Cx As New SqlConnection(CxSettings.ConnectionString)
            Try
                Sql_Str = "Select P.Clave, P.Descripcion, U.Descripcion as Unidad, P.valorUnitario , F.Descripcion as Familia " &
                " From ProductosyServicios as P, Unidades as U, Familias as F" &
                " Where P.Id_Unidad = U.Id_Unidad and P.Id_Familia = F.Id_Familia and P.Descripcion like '%" & Busqueda & "%'" &
                " Order by P.Descripcion"

                Cx.Open()
                Dim DA As New SqlDataAdapter(Sql_Str, Cx)
                Dim DS As New DataSet
                DA.Fill(DS, "Tabla")
                Me.DataGridView.DataSource = DS.Tables("Tabla")
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
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



    Private Sub Txt_Busca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Busca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Busca()
        End If
    End Sub

    Private Sub Button_Servicios_Click(sender As Object, e As EventArgs) Handles Button_Servicios.Click
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView.CurrentCellAddress.Y
        Clave_Servicio = Me.DataGridView(columna, fila).Value
        If Clave_Servicio = Nothing Or Clave_Servicio = "" Then
            MessageBox.Show("Debe seleccionar un producto para agregar servicios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView.Focus()
            Exit Sub
        Else
            Producto_Actual = Me.DataGridView(1, fila).Value
            Dim frm As New Servicios
            frm.ShowDialog()
            Carga_Productos()
        End If
    End Sub

    Private Sub Button_EditaServicios_Click(sender As Object, e As EventArgs) Handles Button_EditaServicios.Click
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView.CurrentCellAddress.Y
        Clave_Servicio = Me.DataGridView(columna, fila).Value
        If Clave_Servicio = Nothing Or Clave_Servicio = "" Then
            MessageBox.Show("Debe seleccionar un producto para editar los servicios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView.Focus()
            Exit Sub
        Else
            Dim frm As New Edita_Servicios_X_Producto
            frm.ShowDialog()
            Carga_Productos()
        End If
    End Sub
End Class