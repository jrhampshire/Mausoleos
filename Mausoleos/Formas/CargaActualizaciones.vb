Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Windows.Forms

Public Class CargaActualizaciones
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim Sql_str As String = Nothing
    Dim NumActualizacion As Integer = 0
#End Region

    Private Sub CargaActualizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Revisa si se ha aplicado alguna actualizacion en caso contrario ejecuta la actualizacion inicial


        Dim Total_Actualizaciones = 0
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Select Count(Actualizacion) as total from Actualizaciones"
            Cmd.CommandType = CommandType.Text
            Total_Actualizaciones = Cmd.ExecuteScalar

        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
        If Total_Actualizaciones = 0 Then
            Actualizacion(0)
        Else


            Try
                Cx.Open()
                Dim Cmd As New SqlCommand()
                Cmd.Connection = Cx
                Cmd.CommandText = "Select max(Actualizacion) as total from Actualizaciones"
                Cmd.CommandType = CommandType.Text
                NumActualizacion = Cmd.ExecuteScalar

            Catch ex As SqlException
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        End If
        NumActualizacion = NumActualizacion + 1
        Actualizacion(NumActualizacion)

        ' Cuenta()



    End Sub




    Sub Actualizacion(ByVal [Act] As Integer)

        If Act = 0 Then
            'La Actualizacion 0 agrega vistas a la base de datos para visualizar el reporte de gavetas vendidas
            Actualizacion0()

        ElseIf Act = 1 Then
            ' La Actualizacion 1 carga los recibos generados 
            Actualizacion1()

        ElseIf Act = 2 Then
            ' La Actualizacion 2 Modifica el Procedimiento Almacenado RecibosPendientesPago
            Actualizacion2()

        ElseIf Act = 3 Then
            ' La Actualizacion 3 elimina informacion redundante que puede causar problemas en la tabla de regimenfiscal
            Actualizacion3()

        ElseIf Act = 4 Then
            ' La Actualizacion 4 agraga las vistas para los reportes
            Actualizacion4()

        ElseIf Act = 5 Then
            ' La Actualizacion 5 Inserta Contratos que fueron borrados por error
            Actualizacion5()

        ElseIf Act = 6 Then
            ' La Actualizacion 5 Inserta Contratos que fueron borrados por error
            Actualizacion6()
        ElseIf Act = 7 Then
            ' La Actualizacion 5 Inserta Contratos que fueron borrados por error
            Actualizacion7()
        ElseIf Act = 8 Then
            ' La Actualizacion 8 
            'Actualizacion8()
        ElseIf Act = 9 Then
            ' La Actualizacion 9 Crea la tabla de Servicios_x_Producto
            Actualizacion9()
        ElseIf Act = 10 Then
            ' La Actualizacion 10 Crea la tabla de Servicios_UtilizadosyDisponibles
            Actualizacion10()
        ElseIf Act = 11 Then
            ' La Actualizacion 11 Crea la tabla de Facturas
            Actualizacion11()
        ElseIf Act = 12 Then
            Actualizacion12()
        ElseIf Act = 13 Then
            Actualizacion13()
        ElseIf Act = 14 Then
            Actualizacion14()
        ElseIf Act = 15 Then
            Actualizacion15()
        Else
            Me.Close()
        End If
        Button_Salir.Enabled = True
        Button_Salir.Focus()
    End Sub

    ''' <summary>
    ''' La Actualizacion 0 agrega vistas a la base de datos para visualizar el reporte de gavetas vendidas
    ''' La Actualizacion 1 carga los recibos generados previamente
    ''' La Actualizacion 2 Modifica el Procedimiento Almacenado RecibosPendientesPago 
    ''' La Actualizacion 3 Borra registro duplicado en la tabla RegimenFiscal
    ''' La Actualizacion 4 Agrega Vista para Reporte
    ''' La Actualizacion 5 Inserta Contratos que fueron borrados por error
    ''' La Actualizacion 7 carga los recibos generados previamente
    ''' La Actualizacion 8 
    ''' La Actualizacion 9 Crea la tabla de Servicios_x_Producto
    ''' La Actualizacion 10 Crea la tabla de Servicios_UtilizadosyDisponibles
    ''' La Actualizacion 11 Crea la tabla de Facturas
    ''' La Actualizacion 12 Corrige errores de captura de productos y servicios
    ''' La Actualizacion 13 corrige errores en fechas de plan de pagos
    ''' La Actualizacion 14 corrige errores en fechas de plan de pagos contratos 101 y 102
    ''' La Actualizacion 15 Agrega Funciones y Procedimientos Almacenados para el reporte de Recibos pagados
    ''' </summary>
    ''' <remarks></remarks>
    '''
#Region "Actualizaciones"
    Sub Actualizacion0()
        Label1.Text = "Realizando cambios en Base de Datos ..."

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Create View Gavetas_Totales_x_Columna as (SELECT COUNT(Fila) AS Totales, Modulo, Columna" &
            " FROM dbo.Gavetas GROUP BY Id_Planta, Modulo, Columna)"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()


        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Create View Gavetas_Vendidas_x_Columna as (SELECT COUNT(Fila) AS Vendidos, Modulo, Columna FROM dbo.Gavetas WHERE" &
            " (Id_Gaveta IN (SELECT Id_Gaveta FROM dbo.Contratos WHERE (Cancelado = 'False'))) GROUP BY Id_Planta, Modulo, Columna)"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()


        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Create View View_NichosVendidos as (SELECT dbo.Contratos.Id_Contrato AS Contrato, dbo.Personas.Nombre, dbo.Contratos.Fecha_Alta, dbo.Plantas.Planta AS Piso, " &
            " LTRIM(RTRIM(CAST(dbo.Gavetas.Modulo AS char(2)))) + '-' + LTRIM(RTRIM(CAST(dbo.Gavetas.Columna AS char(2)))) + '-' + dbo.Gavetas.Fila AS Nicho, " &
            " dbo.PlanPagos.SaldoInicial, dbo.PlanPagos.Fecha_Inicio" &
            " FROM dbo.Contratos INNER JOIN" &
            " dbo.Personas ON dbo.Contratos.Id_Cliente = dbo.Personas.ID_Personas INNER JOIN" &
            " dbo.Gavetas ON dbo.Contratos.Id_Gaveta = dbo.Gavetas.Id_Gaveta INNER JOIN" &
            " dbo.Plantas ON dbo.Gavetas.Id_Planta = dbo.Plantas.Id_Planta INNER JOIN" &
            " dbo.PlanPagos ON dbo.Contratos.Id_Contrato = dbo.PlanPagos.Id_Contrato" &
            " WHERE (dbo.Contratos.Cancelado = 'False'))"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()


        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
        Label1.Text = "Guardando datos de actualizacion"

        Try

            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(0,'Aplicada')"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()

            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion1()

        Label1.Text = "Cargando recibos a la Base de Datos ..."
        Guarda_Datos_Recibos_1()
        Label1.Text = "Cambios realizados con exito"
    End Sub
    Sub Actualizacion2()
        Label1.Text = "Realizando cambios en Base de Datos ..."

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "ALTER Procedure [dbo].[RecibosPendientesPago]" &
            " (@Id_Contrato int)" &
            " as" &
            " SELECT Recibos.Id_Recibo, Recibos.Fecha_Pago, Recibos.Estado_Actual, Recibos.Descripcion, Detalle_PlanPagos.Importe," &
            " Detalle_PlanPagos.Fecha_Vencimiento" &
            " FROM PlanPagos INNER JOIN" &
            " Recibos INNER JOIN" &
            " Detalle_Recibos ON Recibos.Id_Recibo = Detalle_Recibos.Id_Recibo INNER JOIN" &
            " Detalle_PlanPagos ON Detalle_Recibos.Id_Detalle_PlanPagos = Detalle_PlanPagos.Id_Detalle_PlanPagos ON " &
            " PlanPagos.Id_PlanPagos = Detalle_PlanPagos.Id_PlanPagos" &
            " WHERE (Recibos.Estado_Actual <> 'Cancelado') AND (Recibos.Fecha_Pago IS NULL) AND (PlanPagos.Id_Contrato = @Id_Contrato)"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "ALTER Procedure [dbo].[Actualiza_Recibo]" &
            " (" &
            " @Id_Recibo int," &
            " @Fecha_Pago datetime2," &
            " @Estado_Actual nvarchar(50)" &
            " )" &
            " as " &
            " Update Recibos set Fecha_Pago=@Fecha_Pago, Estado_Actual = @Estado_Actual" &
            " Where Id_Recibo =@Id_Recibo"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
        Label1.Text = "Guardando datos de actualizacion"

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(2,'Aplicada')"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion3()

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Delete RegimenFiscal where ID_RegimenFiscal = 28"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(3,'Aplicada')"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion4()


        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "CREATE VIEW [dbo].[View_NichosVendidos]" &
            " AS" &
            " SELECT dbo.Contratos.Id_Contrato AS Contrato, dbo.Personas.Nombre, dbo.Contratos.Fecha_Alta, dbo.Plantas.Planta AS Piso, LTRIM(RTRIM(CAST(dbo.Gavetas.Modulo AS char(2))))" &
            " + '-' + LTRIM(RTRIM(CAST(dbo.Gavetas.Columna AS char(2)))) + '-' + dbo.Gavetas.Fila AS Nicho, dbo.PlanPagos.SaldoInicial" &
            " FROM dbo.Contratos INNER JOIN" &
            " dbo.Gavetas ON dbo.Contratos.Id_Gaveta = dbo.Gavetas.Id_Gaveta INNER JOIN" &
            " dbo.Personas ON dbo.Contratos.Id_Cliente = dbo.Personas.ID_Personas INNER JOIN" &
            " dbo.Plantas ON dbo.Gavetas.Id_Planta = dbo.Plantas.Id_Planta INNER JOIN" &
            " dbo.Ubicaciones ON dbo.Gavetas.Id_Ubicacion = dbo.Ubicaciones.Id_Ubicacion INNER JOIN" &
            " dbo.PlanPagos ON dbo.Contratos.Id_Contrato = dbo.PlanPagos.Id_Contrato"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(4,'Aplicada')"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion5()


        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "SET IDENTITY_INSERT Contratos ON" &
" INSERT INTO Contratos (Id_Contrato,Id_Gaveta,Id_Cliente,Forma_Pago,Id_Empleado,Precio,Enganche,Mensualidades,Dia_Pago,Fecha_Alta,Cancelado,LugarPago,Descuento,Motivo_Descuento,NumCtaPago,metodoDePago)" &
" VALUES(121,1,1,'No Identificado',1,0,0,0,1,GETDATE(),'true','Pago en Oficina MDM',0,'','','Credito')" &
" INSERT INTO Contratos (Id_Contrato,Id_Gaveta,Id_Cliente,Forma_Pago,Id_Empleado,Precio,Enganche,Mensualidades,Dia_Pago,Fecha_Alta,Cancelado,LugarPago,Descuento,Motivo_Descuento,NumCtaPago,metodoDePago)" &
" VALUES(123,1,1,'No Identificado',1,0,0,0,1,GETDATE(),'true','Pago en Oficina MDM',0,'','','Credito')" &
" SET IDENTITY_INSERT Contratos OFF"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(5,'Aplicada')"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion6()



        Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Create Table Comisiones" &
            " (" &
            " Id_Comisiones int not null identity (1,1)," &
            " Id_Contrato int null," &
            " FechaPago datetime2 null," &
            " Importe decimal null," &
            " Concepto nvarchar(Max) null," &
            " Constraint PK_Id_Comisiones Primary key (Id_Comisiones)" &
            " )"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(6,'Aplicada')"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion7()
        Label1.Text = "Cargando recibos a la Base de Datos ..."
        Guarda_Datos_Recibos_1()
        Label1.Text = "Cambios realizados con exito"
    End Sub
    Sub Actualizacion9()
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Create Table Servicios_x_Producto" &
            " (" &
            " Id_Servicios_x_Producto int not null identity (1,1)," &
            " Id_Servicio int not null," &
            " Id_Producto int not null," &
            " Cantidad int not null" &
            " Constraint PK_Id_Servicios_x_Producto Primary key (Id_Servicios_x_Producto)" &
            " )"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(9,'Aplicada')"
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion10()



        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Create Table Servicios_UtilizadosyDisponibles" &
            " (" &
            " Id_SUD int not null identity (1,1)," &
            " Id_Servicio int not null," &
            " Id_Contrato int not null," &
            " Disponibles int not null," &
            " Utilizados int not null" &
            " Constraint PK_Id_SUD Primary key (Id_SUD)" &
            " )"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(10,'Aplicada')"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion11()


        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "CREATE TABLE Facturas" &
            " (" &
            " Id_Factura int Identity(1,1) not null," &
            " Serie nvarchar(20) null," &
            " Folio int not null," &
            " PDF varbinary(Max)" &
            " CONSTRAINT PK_Id_Factura PRIMARY KEY (Id_Factura)" &
            " )"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(11,'Aplicada')"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion12()

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Update ProductosyServicios set Activo = 'False' where clave = 'N2P'"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Update ProductosyServicios set Activo = 'True' where Id_ProductosyServicios = 1"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "update ServiciosXContrato Set Id_ProductosyServicios = 1 Where Id_ProductosyServicios = 42"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Delete ProductosyServicios Where Activo = 'False'"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(12,'Aplicada')"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion13()

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Update Detalle_PlanPagos SET Fecha_Vencimiento = EOMONTH(Fecha_Vencimiento)" &
            " Where  Id_PlanPagos IN (SELECT Id_PlanPagos FROM PlanPagos WHERE Id_Contrato IN(115,145,153,186,206)) and MONTH(fecha_Vencimiento) = 2"

            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try


        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Update Detalle_PlanPagos SET Fecha_Vencimiento = DateAdd(DAY,2, Fecha_Vencimiento)" &
            " WHERE Id_PlanPagos IN (SELECT Id_PlanPagos FROM PlanPagos WHERE Id_Contrato IN(115,145,153,186,206))" &
            " and MONTH(fecha_Vencimiento) <> 2 and DAY(fecha_Vencimiento) = 28"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(13,'Aplicada')"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion14()
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Update Detalle_PlanPagos SET Fecha_Vencimiento = DateAdd(DAY,-1, Fecha_Vencimiento)" &
            " WHERE Id_PlanPagos IN (SELECT Id_PlanPagos FROM PlanPagos WHERE Id_Contrato IN(101,102))" &
            " and DAY(fecha_Vencimiento) = 31"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(14,'Aplicada')"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Actualizacion15()
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "CREATE FUNCTION dbo.Funcion_RecibosPagados(@Fecha1 datetime2,@Fecha2 datetime2)" &
                " RETURNS @TablaTemp TABLE" &
                " (Id_Recibo int Not null, Fecha_Pago datetime2 null, Estado_Actual nvarchar(100) null, Descripcion nvarchar(MAX) null,	Contrato int null default 0,Cliente nvarchar(MAX) null default 0,Importe decimal(18,2) null default 0)" &
                " AS BEGIN" &
                " Insert Into @TablaTemp Select Id_Recibo, Fecha_Pago, Estado_Actual, Descripcion ,0,0,0 from Recibos Where Estado_Actual in ('Recibo Facturado', 'Recibo Pagado') and Fecha_Pago between @Fecha1 and @Fecha2" &
                " Declare @Recibo int" &
                " Declare Recibos Cursor Read_Only for Select Id_Recibo from @TablaTemp" &
                " Open Recibos Fetch Next From Recibos INTO @Recibo While @@FETCH_STATUS = 0" &
                " Begin" &
                " Update @TablaTemp Set Contrato = (Select Id_Contrato as Contrato from Contratos Where Cancelado = 'False'" &
                " And Id_Contrato = (Select Id_Contrato from PlanPagos Where Id_PlanPagos =(Select Distinct(Id_PlanPagos) From Detalle_PlanPagos" &
                " Where Id_Detalle_PlanPagos in (Select Id_Detalle_PlanPagos from Detalle_Recibos Where Id_Recibo = @Recibo))))," &
                " Cliente = (Select P.Nombre as Cliente from Contratos as C, Personas as P" &
                " Where C.Id_Cliente = P.ID_Personas And C.Cancelado = 'False'" &
                " And C.Id_Contrato = (Select Id_Contrato from PlanPagos Where Id_PlanPagos =(Select Distinct(Id_PlanPagos) From Detalle_PlanPagos" &
                " Where Id_Detalle_PlanPagos in (Select Id_Detalle_PlanPagos from Detalle_Recibos Where Id_Recibo = @Recibo))))," &
                " Importe = (Select sum(Importe) as Importe from Detalle_PlanPagos where Id_Detalle_PlanPagos in (Select Id_Detalle_PlanPagos from Detalle_Recibos where Id_Recibo = @Recibo))" &
                " Where Id_Recibo = @Recibo" &
                " Fetch Next From Recibos INTO @Recibo" &
                " End Close Recibos Deallocate Recibos" &
                " RETURN END"

            Cmd.ExecuteNonQuery()
            Label1.Text = "Aplicando Cambios"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandText = "CREATE PROCEDURE AcumuladoPagos (@Fecha1 datetime2,@Fecha2 datetime2) AS BEGIN SET NOCOUNT ON; Declare @TablaReporte Table(Contrato int, Cliente nvarchar(MAX), Pagado decimal(18,2)) Insert into @TablaReporte Select Contrato, Cliente,Sum(Importe) as Pagado from Funcion_RecibosPagados (@Fecha1 ,@Fecha2) NOLOCK where Contrato is not null Group by Contrato,Cliente  Declare @TablaFinal Table(Contrato int, Cliente nvarchar(MAX), SaldoInicial decimal(18,2), Pagado decimal(18,2), SaldoActual decimal(18,2)) Insert into @TablaFinal Select Contrato, Cliente, SaldoInicial, Pagado, (SaldoInicial - Pagado) as SaldoActual from @TablaReporte, PlanPagos Where Contrato = Id_Contrato  Select Contrato, Cliente, SaldoInicial, Pagado, SaldoActual from @TablaFinal Order by Contrato END "
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(15,'Aplicada')"
            Cmd.ExecuteNonQuery()
            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub

#End Region

#Region "Guarda Recibos"
    Sub Guarda_Datos_Recibos_1()
        Dim x As Integer = 0
        For x = 174 To 315

            Dim Tiene_Datos As Boolean = False
            Dim Fecha_Pago As DateTime = Nothing
            Dim Concepto As String = Nothing
            Dim Contrato As Integer = 0
            Dim Id_Detalle_PlanPagos As Integer = 0

            Try
                Cx.Open()
                Dim Cmd As New SqlCommand()
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = Cx
                Cmd.CommandText = "Select Fecha, Id_Contrato, Concepto from TemRecibos where Id_Recibo = @Id"
                Cmd.Parameters.AddWithValue("@Id", x)
                Dim Reader As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If Reader.HasRows Then
                    While Reader.Read
                        Tiene_Datos = True
                        Fecha_Pago = Reader.Item("Fecha")
                        Concepto = Reader.Item("Concepto")
                        Contrato = Reader.Item("Id_Contrato")
                    End While
                Else
                    Tiene_Datos = False
                    Fecha_Pago = Now
                    Concepto = "Cancelado"
                    Contrato = 0
                End If
            Catch ex As SqlException
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
            If Tiene_Datos = True Then
                Dim ID() = Concepto.Split(",")
                Dim Total_Guarda As Integer = ID.Count
                Dim Id_Recibo As Integer
                Try
                    Cx.Open()

                    Dim Cmd As New SqlCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = Cx
                    Cmd.CommandText = "Insert into Recibos (Fecha_Pago, Descripcion , Estado_Actual) Values (@Fecha_Pago, @Descripcion, @Estado_Actual); Select @ID = @@Identity"
                    Cmd.Parameters.AddWithValue("@Descripcion", Concepto)
                    Cmd.Parameters.AddWithValue("@Estado_Actual", "Recibo Pagado")
                    Cmd.Parameters.AddWithValue("@Fecha_Pago", Fecha_Pago)
                    Cmd.Parameters.Add("@ID", SqlDbType.Int)
                    Cmd.Parameters("@ID").Direction = ParameterDirection.Output
                    Cmd.ExecuteNonQuery()
                    Id_Recibo = Cmd.Parameters("@ID").Value.ToString()
                Catch ex As SqlException
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
                For i = 0 To Total_Guarda - 1

                    Try
                        Cx.Open()
                        Dim Cmd As New SqlCommand()
                        Cmd.CommandType = CommandType.Text
                        Cmd.Connection = Cx
                        Cmd.CommandText = "Select Id_detalle_PlanPagos from Detalle_PlanPagos where Id_PlanPagos in (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Contrato)" &
                        " and detalle = @Concepto"
                        Cmd.Parameters.AddWithValue("@Contrato", Contrato)
                        Cmd.Parameters.AddWithValue("@Concepto", ID(i))
                        Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        With DR
                            If .HasRows Then
                                While .Read
                                    Id_Detalle_PlanPagos = .Item("Id_Detalle_PlanPagos")
                                End While
                            End If
                        End With
                    Catch ex As SqlException
                        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                    Finally
                        If Cx.State = ConnectionState.Open Then
                            Cx.Close()
                        End If

                    End Try
                    Try
                        Cx.Open()
                        Sql_str = "Insert into Detalle_Recibos (Id_Detalle_PlanPagos, Id_Recibo)" &
                            " Values (@Id_Detalle_PlanPagos, @Id_Recibo)"
                        Dim Cmd As New SqlCommand(Sql_str, Cx)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Parameters.AddWithValue("@Id_Detalle_PlanPagos", Id_Detalle_PlanPagos)
                        Cmd.Parameters.AddWithValue("@Id_Recibo", Id_Recibo)
                        Cmd.ExecuteNonQuery()
                    Catch ex As SqlException
                        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                    Finally
                        If Cx.State = ConnectionState.Open Then
                            Cx.Close()
                        End If
                    End Try
                Next
            Else
                Try
                    Cx.Open()

                    Dim Cmd As New SqlCommand()
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = Cx
                    Cmd.CommandText = "Insert into Recibos (Descripcion , Estado_Actual) Values (@Descripcion, @Estado_Actual)"
                    Cmd.Parameters.AddWithValue("@Descripcion", Concepto)
                    Cmd.Parameters.AddWithValue("@Estado_Actual", "Cancelado")
                    Cmd.Parameters.AddWithValue("@Fecha_Pago", Fecha_Pago)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            End If
        Next


        Try
            Cx.Open()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.Connection = Cx
            cmd.CommandText = "Drop Table TemRecibos"
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

        Label1.Text = "Guardando datos de actualizacion"

        Try

            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Insert into Actualizaciones (Actualizacion, Estado) Values(7,'Aplicada')"
            Cmd.ExecuteNonQuery()

            Label1.Text = "Cambios realizados con exito"
        Catch ex As SqlException
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If

        End Try
    End Sub
    Sub Guarda_Datos_Recibos_2(ByVal Contrato As Integer, ByVal Fecha As String, ByVal Pagos As String, ByVal Concepto As String, ByVal Metodo_Pago As String)
        Dim Id_Recibo As Integer
        Dim Cuenta_Pago As String = ""
        If IsDBNull(Cuenta_Pago) Then
            Cuenta_Pago = ""
        End If
        Dim Temp_Str As String = ""
        Dim ID As New List(Of Integer)
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Cx
            Cmd.CommandText = "Select Id_Detalle_PlanPagos from Detalle_PlanPagos " &
                "where Id_PlanPagos =(Select Id_PlanPagos from PlanPagos where Id_Contrato = @Contrato) And Detalle in (@Pagos)"
            Cmd.Parameters.AddWithValue("@Contrato", Contrato)
            Cmd.Parameters.AddWithValue("@Pagos", Pagos)

            Dim Reader As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If Reader.HasRows Then
                While Reader.Read
                    ID.Add(Reader.Item("Id_Detalle_PlanPagos"))
                End While
            End If
        Catch ex As SqlException
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
        Dim Total_Guarda As Integer = ID.Count
        Try
            Cx.Open()
            Sql_str = "Alta_Recibos"
            Dim Cmd As New SqlCommand(Sql_str, Cx)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@Descripcion", Concepto)
            Cmd.Parameters.AddWithValue("@Estado_Actual", "Recibo Pagado")
            Cmd.Parameters.AddWithValue("@Metodo_Pago", Metodo_Pago)
            Cmd.Parameters.AddWithValue("@Cuenta_Pago", Cuenta_Pago)
            Cmd.Parameters.Add("@ID", SqlDbType.Int)
            Cmd.Parameters("@ID").Direction = ParameterDirection.Output
            Cmd.ExecuteNonQuery()
            Id_Recibo = Cmd.Parameters("@ID").Value.ToString()
            GuardarPDF = True
        Catch ex As SqlException
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
        For i = 0 To Total_Guarda - 1
            Try
                Cx.Open()
                Sql_str = "Alta_Detalle_Recibos"
                Dim Cmd As New SqlCommand(Sql_str, Cx)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@Id_Detalle_PlanPagos", ID(i))
                Cmd.Parameters.AddWithValue("@Id_Recibo", Id_Recibo)
                Cmd.ExecuteNonQuery()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
        Next

    End Sub
#End Region

    Private Sub Button_Salir_Click(sender As Object, e As EventArgs) Handles Button_Salir.Click
        Me.Close()
    End Sub
End Class