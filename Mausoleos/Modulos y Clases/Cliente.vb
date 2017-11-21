
Public Class Cliente
    Inherits Domicilios
    Private _Observaciones As String = Nothing
    Private _RFC As String
    Private _Razon_Social As String
    Private _Telefono As String = Nothing
    Private _email As String = Nothing
    Private _Descrp_Localidad As String = Nothing
    Private _Nombre_Cte As String = Nothing
    Private _Celular As String = Nothing
    Private Temp_Id_Receptor As Integer = 0

    Property Id_Receptor As Integer
        Get
            Return Temp_Id_Receptor
        End Get
        Set(value As Integer)
            Temp_Id_Receptor = value
        End Set
    End Property
    Property Celular As String
        Get
            Return _Celular

        End Get
        Set(value As String)
            _Celular = value
        End Set
    End Property
    Property Nombre_Cte As String
        Get
            Return _Nombre_Cte
        End Get
        Set(value As String)
            _Nombre_Cte = value
        End Set
    End Property
    Property Descrp_Localidad As String
        Get
            Return _Descrp_Localidad
        End Get
        Set(value As String)
            _Descrp_Localidad = value
        End Set
    End Property
    Property Observaciones As String
        Get
            Return _Observaciones

        End Get
        Set(value As String)
            _Observaciones = Trim(value)
        End Set
    End Property
    Property Telefono As String
        Get
            Return _Telefono
        End Get
        Set(value As String)
            _Telefono = Trim(value)
        End Set
    End Property
    Property RFC As String
        Get
            Return _RFC
        End Get
        Set(value As String)
            _RFC = Trim(value)
        End Set
    End Property
    Property Razon_Social As String
        Get
            Return _Razon_Social
        End Get
        Set(value As String)
            _Razon_Social = Trim(value)
        End Set
    End Property
    Property email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = Trim(value)
        End Set
    End Property
 
End Class
