Public Class Facturas
    Dim _Razon_Social_Proveedor As String = Nothing
    Dim _Proveedor As Integer = 0
    Dim _Folio_Fiscal As String = Nothing
    Dim _FechaCFDI As Date = Nothing
    'Dim _FechaFolioFiscalOrig As Date = Nothing
    Dim _subTotal As Double = 0
    Dim _IVA As Double = 0
    Dim _Total As Double = 0
    Property Razon_Social_Proveedor As String
        Get
            Return _Razon_Social_Proveedor
        End Get
        Set(value As String)
            _Razon_Social_Proveedor = value
        End Set
    End Property
    Property Proveedor As Integer
        Get
            Return _Proveedor
        End Get
        Set(value As Integer)
            _Proveedor = value
        End Set
    End Property
    Property Folio_Fiscal As String
        Get
            Return _Folio_Fiscal
        End Get
        Set(value As String)
            _Folio_Fiscal = value
        End Set
    End Property
    Property FechaCFDI As Date
        Get
            Return _FechaCFDI
        End Get
        Set(value As Date)
            _FechaCFDI = value
        End Set
    End Property
    Property subTotal As Double
        Get
            Return _subTotal
        End Get
        Set(value As Double)
            _subTotal = value
        End Set
    End Property
    Property Total As Double
        Get
            Return _Total
        End Get
        Set(value As Double)
            _Total = value
        End Set
    End Property
    Function IVA()
        _IVA = Total - subTotal
        Return _IVA
    End Function
End Class
