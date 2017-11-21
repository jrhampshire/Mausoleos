Public Class Conceptos_Class

    Private _Clave As String = Nothing
    Private _Descripcion As String = Nothing
    Private _Cantidad As Integer = 0
    Private _Precio As Decimal = 0
    Private _Unidad As Integer = 0
    Private _Impuesto As Decimal = 0
    Private _Subtotal As Decimal = 0
    Private _Tasa As Decimal = 0
    Private _Familia As Integer = 0
    Private _Total As Decimal = 0
    Function Total() As Decimal
        _Total = FormatNumber(_Subtotal + _Impuesto, 6)
        Return _Total
    End Function
    Property Familia As Integer
        Get
            Return _Familia
        End Get
        Set(value As Integer)
            If value = Nothing Then
                _Familia = 0
            Else
                _Familia = value
            End If

        End Set
    End Property
    Property Tasa As Decimal
        Get
            Return FormatNumber(_Tasa, 4)
        End Get
        Set(value As Decimal)
            If value = Nothing Then
                _Tasa = 0
            Else
                _Tasa = value
            End If

        End Set
    End Property
    Function Subtotal() As Decimal
        _Subtotal = FormatNumber(Cantidad * Precio, 6)
        Return _Subtotal
    End Function
    Function Impuesto() As Decimal
        _Impuesto = FormatNumber(Subtotal() * (Tasa - 1), 6)
        Return _Impuesto
    End Function
    Property Unidad As Integer
        Get
            Return _Unidad
        End Get
        Set(value As Integer)
            If value = Nothing Then
                _Unidad = 0
            Else
                _Unidad = value
            End If

        End Set
    End Property
    Property Precio As Decimal
        Get
            Return FormatNumber(_Precio, 6)
        End Get
        Set(value As Decimal)
            _Precio = value
        End Set
    End Property
    Property Cantidad As Integer
        Get
            Return FormatNumber(_Cantidad, 2)
        End Get
        Set(value As Integer)
            _Cantidad = value
        End Set
    End Property
    Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property
    Property Clave As String
        Get
            Return _Clave
        End Get
        Set(value As String)
            _Clave = value
        End Set
    End Property

End Class
