Module Variables_Globales
    Public Usuario_Actual As Integer = 0
    Public Usuario_Edicion As Integer = 0
    Public Nombre_Usuario As String = Nothing
    Public Permisos As String = Nothing
    Public Id_Contrato As Integer = 0
    Public Beneficiarios_List As New List(Of Beneficiarios_Class)(8)
    Public Producto As String = Nothing
    Public Boton_Actual As String = Nothing
    Public SaldoInicial As Decimal = 0
    Public Anticipo As Decimal = 0
    Public Mensualidades As Integer = 0
    Public SaldoActual As Decimal = 0
    Public Mensualidad As Decimal = 0
    Public Id_Gaveta_Actual As Integer = 0
    Public ID_Recibos() As String
    Public TitularSubstituto As String = Nothing
    Public ParentescoTitular As String = Nothing
    Public Clave_Servicio As String = Nothing
    Public Fecha_Recibos As Date = Nothing
    Public Fecha_Inicio_Recibos As Date = Nothing
    Public _DiaPago As Integer = 0
    Public Producto_Actual As String = Nothing
    Public GuardarPDF As Boolean = False
    Public RutaSrv As String = "C:\SiFact"
    'Public RutaSrv As String = "\\SRVMAUSOLEO\SiFact"
End Module
