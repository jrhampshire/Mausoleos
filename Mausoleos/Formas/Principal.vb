Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Public Class Principal
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim SQL_Str As String = Nothing
#End Region

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DirectorioInicio As String = Nothing
        DirectorioInicio = System.AppDomain.CurrentDomain.BaseDirectory()
        'If Not My.Computer.FileSystem.DirectoryExists("\\192.168.1.253\SiFact") Then
        '    My.Computer.FileSystem.CreateDirectory("\\192.168.1.253\SiFact")
        'End If
        If Not My.Computer.FileSystem.DirectoryExists("C:\SiFact") Then
            My.Computer.FileSystem.CreateDirectory("C:\SiFact")
        End If
        If Not My.Computer.FileSystem.DirectoryExists("C:\SiFact\Facturas") Then
            My.Computer.FileSystem.CreateDirectory("C:\SiFact\Facturas")
        End If
        If Not My.Computer.FileSystem.DirectoryExists("C:\SiFact\ArchivosSAT") Then
            My.Computer.FileSystem.CreateDirectory("C:\SiFact\ArchivosSAT")
        End If
        If Not My.Computer.FileSystem.DirectoryExists("C:\SiFact\Plantillas") Then
            My.Computer.FileSystem.CreateDirectory("C:\SiFact\Plantillas")
        End If
        If Not My.Computer.FileSystem.DirectoryExists("C:\SiFact\Contratos") Then
            My.Computer.FileSystem.CreateDirectory("C:\SiFact\Contratos")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(DirectorioInicio & "\Documentos") Then
            My.Computer.FileSystem.CreateDirectory(DirectorioInicio & "\Documentos")
        End If
        If Not My.Computer.FileSystem.DirectoryExists("C:\SiFact\RespBaseDeDatos") Then
            My.Computer.FileSystem.CreateDirectory("C:\SiFact\RespBaseDeDatos")
        End If
        If Not My.Computer.FileSystem.DirectoryExists("C:\SiFact\RespBaseDeDatos\Original") Then
            My.Computer.FileSystem.CreateDirectory("C:\SiFact\RespBaseDeDatos\Original")
        End If
        If Not My.Computer.FileSystem.DirectoryExists("C:\SiFact\RespBaseDeDatos\Zip") Then
            My.Computer.FileSystem.CreateDirectory("C:\SiFact\RespBaseDeDatos\Zip")
        End If
        'Dim LoginFrm As New LoginForm
        'LoginFrm.ShowDialog()
        Dim FrmActualiza As New CargaActualizaciones
        FrmActualiza.ShowDialog()

    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Dim frm As New AboutBox1
        frm.ShowDialog()
    End Sub


    Private Sub PaquetesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim frm As New Paquetes
        frm.ShowDialog()

    End Sub

    Private Sub EstadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadosToolStripMenuItem.Click
        Dim Frm As New Estados
        Frm.ShowDialog()

    End Sub

    Private Sub MunicipiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MunicipiosToolStripMenuItem.Click
        Dim Frm As New Municipios
        Frm.ShowDialog()

    End Sub

    Private Sub CiudadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CiudadesToolStripMenuItem.Click
        Dim Frm As New Ciudades
        Frm.ShowDialog()

    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim Frm As New Clientes
        Frm.ShowDialog()

    End Sub

    Private Sub PaisesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaisesToolStripMenuItem.Click
        Dim Frm As New Paises
        Frm.ShowDialog()

    End Sub

    Private Sub ParentescosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParentescosToolStripMenuItem.Click
        Dim Frm As New Parentescos
        Frm.ShowDialog()
    End Sub

    Private Sub GavetasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GavetasToolStripMenuItem.Click
        Dim Frm As New Listado_Gavetas
        Frm.ShowDialog()

    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.Click
        Dim Frm As New Listado_Usuarios
        Frm.ShowDialog()
    End Sub

    Private Sub SoporteRemotoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SoporteRemotoToolStripMenuItem.Click

        Try
            If File.Exists("C:\Program Files (x86)\TeamViewer\Version9\TeamViewer.exe") Then
                Process.Start("C:\Program Files (x86)\TeamViewer\Version9\TeamViewer.exe")
            ElseIf File.Exists("C:\Program Files (x86)\TeamViewer\TeamViewer.exe") Then
                Process.Start("C:\Program Files (x86)\TeamViewer\TeamViewer.exe")
            Else
                MessageBox.Show("Para poder acceder al soporte remoto debe tener instalado TeamViewer en su equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub



    Private Sub SucursalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SucursalesToolStripMenuItem.Click
        Dim Frm As New Listado_Sucursales
        Frm.ShowDialog()

    End Sub



    Private Sub SeriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeriesToolStripMenuItem.Click
        Dim Frm As New Series
        Frm.ShowDialog()

    End Sub



    Private Sub RegistrarPagosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarPagosToolStripMenuItem.Click
        Dim Frm As New Cobranza2
        Frm.ShowDialog()

    End Sub



    Private Sub NichosVendidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NichosVendidosToolStripMenuItem.Click
        Dim frm As New Nichos_Vendidos
        frm.ShowDialog()

    End Sub

    Private Sub EditaEmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditaEmpresaToolStripMenuItem.Click
        Dim frm As New Edita_Datos_Negocio
        frm.ShowDialog()

    End Sub

    Private Sub NuevaEmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaEmpresaToolStripMenuItem.Click
        Dim Frm As New Datos_Negocio
        Frm.ShowDialog()
    End Sub

    Private Sub AltaDeCertificadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaDeCertificadosToolStripMenuItem.Click
        Dim Frm As New Alta_Certificado
        Frm.ShowDialog()
    End Sub

    Private Sub RecibosPendientesDeCobroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibosPendientesDeCobroToolStripMenuItem.Click
        Dim frm As New RecibosPendientesPago
        frm.ShowDialog()

    End Sub

    Private Sub PagosRecibidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagosRecibidosToolStripMenuItem.Click
        Dim frm As New Pagos_Recibidos
        frm.ShowDialog()

    End Sub

    Private Sub CobranzaVencidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobranzaVencidaToolStripMenuItem.Click
        Dim Frm As New CobranzaVencida
        Frm.ShowDialog()

    End Sub

    Private Sub RecibosGeneradosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibosGeneradosToolStripMenuItem.Click
        Dim Frm As New ListadoRecibos
        Frm.ShowDialog()

    End Sub

    Private Sub PagoDeComisionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagoDeComisionesToolStripMenuItem.Click
        Dim Frm As New PagodeComisiones
        Frm.ShowDialog()

    End Sub

    Private Sub CancelarReciboEnBlancoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelarReciboEnBlancoToolStripMenuItem.Click
        SQL_Str = "Select Max(Id_Recibo) + 1 as Id_Recibo from Recibos"
        Dim ReciboMax As Int32 = 0
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            ReciboMax = Convert.ToInt32(Cmd.ExecuteScalar())
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
        Try

            Dim Respuesta As DialogResult = Nothing
            Respuesta = MessageBox.Show("Esta a punto de Cancelar el Recibo: " & ReciboMax & " ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Select Case Respuesta
                Case System.Windows.Forms.DialogResult.Yes
                    Using Cx As New SqlConnection(CxSettings.ConnectionString)
                        SQL_Str = "Insert into Recibos (Estado_Actual,Descripcion) Values('Cancelado','Cancelado')"
                        Try
                            Cx.Open()
                            Dim Cmd As New SqlCommand(SQL_Str, Cx)
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
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
                Case System.Windows.Forms.DialogResult.No
                    Exit Sub
            End Select

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

    Private Sub ServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiciosToolStripMenuItem.Click
        Dim frm As New Listado_Productos_Servicios
        frm.ShowDialog()
    End Sub

    Private Sub ServiciosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ServiciosToolStripMenuItem1.Click
        Dim Frm As New Listado_Servicios
        Frm.ShowDialog()
    End Sub

    Private Sub ReporteDeSaldosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeSaldosToolStripMenuItem.Click
        Dim Frm As New Reporte_de_Saldos
        Frm.ShowDialog()
    End Sub

    Private Sub RespaldoDeBaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RespaldoDeBaseDeDatosToolStripMenuItem.Click
        Dim Frm As New RespaldaSQL
        Frm.ShowDialog()

    End Sub

    Private Sub RestaurarBaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestaurarBaseDeDatosToolStripMenuItem.Click
        Dim Frm As New RestauraSQL
        Frm.ShowDialog()
    End Sub

    Private Sub NotaDeCreditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDeCreditoToolStripMenuItem.Click
        Dim Frm As New NotadeCredito
        Frm.ShowDialog()
    End Sub

    Private Sub FacturacionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem1.Click
        Dim Frm As New Nueva_Factura
        Frm.ShowDialog()
    End Sub

    Private Sub FacturacionToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem2.Click
        Dim frm As New FacturaciondelPeriodo
        frm.ShowDialog()

    End Sub

    Private Sub PlanoDeNichosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanoDeNichosToolStripMenuItem.Click
        Dim frm As New Plano2
        frm.ShowDialog()
    End Sub

    Private Sub ProyeccionDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProyeccionDeVentasToolStripMenuItem.Click
        Dim Frm As New ProyeccionCobranza
        Frm.ShowDialog()

    End Sub

    Private Sub VentasDelPeriodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasDelPeriodoToolStripMenuItem.Click
        Dim Frm As New Ventas_Mes
        Frm.ShowDialog()

    End Sub

    Private Sub ProyeccionDeCobranzaA3060Y90DiasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProyeccionDeCobranzaA3060Y90DiasToolStripMenuItem.Click
        Dim Frm As New Cobranza30_60_90
        Frm.ShowDialog()

    End Sub

    Private Sub ConfigurarCorreoToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Dim Frm As New ConfiguraCorreo
        Frm.ShowDialog()

    End Sub

    Private Sub CargarFacturasFaltantesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarFacturasFaltantesToolStripMenuItem.Click
        Dim Frm As New Cargar_Facturas_Faltantes
        Frm.ShowDialog()

    End Sub
End Class

