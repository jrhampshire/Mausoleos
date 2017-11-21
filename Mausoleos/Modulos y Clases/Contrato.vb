Public Class Contrato
    Private _Contrato As Integer = 0
    Private _FechaAlta As DateTime = Nothing
    Private _Gaveta As String = Nothing
    Private _Agente As String = Nothing
    Private _Id_Agente As Integer = 0
    Private _ObservacionesGenerales As String = Nothing
    Private _Id_Gaveta As Integer = 0
    Private _ubicacion As String = Nothing
    Private _Piso As String = Nothing
    Private _modulo As String = Nothing
    Private _IdTipoGaveta As Integer = 0
    Private _Fila As String = Nothing
    Private _Columna As String = Nothing
    Private _CapacidadGaveta As Integer = 0
    Private _GavetaHabilitada As Boolean
    Private _ObservacionesGaveta As String = Nothing
    Private _Precio As Decimal
    Private _MetodoPago As String = Nothing
    Private _Anticipo As Decimal = 0
    Private _Mensualidades As Integer = 0
    Private _IdFormaPago As Integer = 0
    Private _FormaPago As String = Nothing
    Private _DiaPago As Integer = 0
    Private _NumeroCta As String = Nothing
    Private _LugarPago As String = Nothing
    Private _Descuento As Integer = 0
    Private _Motivo_Descuento As String = Nothing
    Property Descuento As Integer
        Get
            Return _Descuento
        End Get
        Set(value As Integer)
            _Descuento = value
        End Set
    End Property
    Property Motivo_Descuento As String
        Get
            Return _Motivo_Descuento
        End Get
        Set(value As String)
            _Motivo_Descuento = value
        End Set
    End Property
    Property LugarPago As String
        Get
            Return _LugarPago
        End Get
        Set(value As String)
            _LugarPago = value
        End Set
    End Property
    Property NumeroCta As String
        Get
            Return _NumeroCta
        End Get
        Set(value As String)
            _NumeroCta = value
        End Set
    End Property
    Property DiaPago As Integer
        Get
            Return _DiaPago
        End Get
        Set(value As Integer)
            _DiaPago = value
        End Set
    End Property
    Property FormaPago As String
        Get
            Return _FormaPago
        End Get
        Set(value As String)
            _FormaPago = value
        End Set
    End Property
    Property IdFormaPago As Integer
        Get
            Return _IdFormaPago
        End Get
        Set(value As Integer)
            _IdFormaPago = value
        End Set
    End Property
    Property Mensualidades As Integer
        Get
            Return _Mensualidades
        End Get
        Set(value As Integer)
            _Mensualidades = value
        End Set
    End Property
    Property Anticipo As Decimal
        Get
            Return _Anticipo
        End Get
        Set(value As Decimal)
            _Anticipo = value
        End Set
    End Property
    Property Precio As Decimal
        Get
            Return _Precio
        End Get
        Set(value As Decimal)
            _Precio = value
        End Set
    End Property
    Property MetodoPago As String
        Get
            Return _MetodoPago
        End Get
        Set(value As String)
            _MetodoPago = value
        End Set
    End Property
    Property Modulo As String
        Get
            Return _modulo
        End Get
        Set(value As String)
            _modulo = value
        End Set
    End Property
    Property ObservacionesGaveta As String
        Get
            Return _ObservacionesGaveta
        End Get
        Set(value As String)
            _ObservacionesGaveta = value
        End Set
    End Property

    Property GavetaHabilitada As Boolean
        Get
            Return _GavetaHabilitada
        End Get
        Set(value As Boolean)
            _GavetaHabilitada = value
        End Set
    End Property

    Property CapacidadGaveta As Integer
        Get
            Return _CapacidadGaveta
        End Get
        Set(value As Integer)
            _CapacidadGaveta = value
        End Set
    End Property
    Property Columna As String
        Get
            Return _Columna
        End Get
        Set(value As String)
            _Columna = value
        End Set
    End Property
    Property Fila As String
        Get
            Return _Fila

        End Get
        Set(value As String)
            _Fila = value
        End Set
    End Property
    Property IdTipoGaveta As Integer
        Get
            Return _IdTipoGaveta
        End Get
        Set(value As Integer)
            _IdTipoGaveta = value
        End Set
    End Property

    Property Piso As String
        Get
            Return _Piso
        End Get
        Set(value As String)
            _Piso = value
        End Set
    End Property

    Property Ubicacion As String
        Get
            Return _ubicacion
        End Get
        Set(value As String)
            _ubicacion = value

        End Set
    End Property
    Property Id_Gaveta As Integer
        Get
            Return _Id_Gaveta
        End Get
        Set(value As Integer)
            _Id_Gaveta = value
        End Set
    End Property
    Property Contrato
        Get
            Return _Contrato
        End Get
        Set(value)
            _Contrato = value
        End Set
    End Property
    Property Fecha_Alta As DateTime
        Get
            Return _FechaAlta
        End Get
        Set(value As DateTime)
            _FechaAlta = value
        End Set
    End Property
    Property Gaveta As String
        Get
            Return _Gaveta

        End Get
        Set(value As String)
            _Gaveta = value
        End Set
    End Property
    Property Agente As String
        Get
            Return _Agente
        End Get
        Set(value As String)
            _Agente = value
        End Set
    End Property
    Property Id_Agente As Integer
        Get
            Return _Id_Agente
        End Get
        Set(value As Integer)
            _Id_Agente = value
        End Set
    End Property
    Property ObservacionesGenerales As String
        Get
            Return _ObservacionesGenerales
        End Get
        Set(value As String)
            _ObservacionesGenerales = value
        End Set
    End Property
End Class
