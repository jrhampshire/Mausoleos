Public Class Domicilios
    Private Temp_Id_Domicilio As Integer
    Private Temp_Calle As String
    Private Temp_noExterior As String
    Private Temp_noInterior As String
    Private Temp_colonia As String
    Private Temp_localidad As String
    Private Temp_referencia As String
    Private Temp_municipio As String
    Private Temp_estado As String
    Private Temp_pais As String
    Private Temp_codigoPostal As String
    Private _Id_Localidad As Integer
    Property Id_Localidad As Integer
        Get
            Return _Id_Localidad
        End Get
        Set(value As Integer)
            _Id_Localidad = value
        End Set
    End Property

    Property Id_Domicilio() As Integer
        Get
            Return Temp_Id_Domicilio
        End Get
        Set(value As Integer)
            Temp_Id_Domicilio = value

        End Set
    End Property
    Property Calle() As String
        Get
            Return Temp_Calle

        End Get
        Set(value As String)
            Temp_Calle = value
        End Set
    End Property
    Property noExterior() As String
        Get
            Return Temp_noExterior
        End Get
        Set(value As String)
            Temp_noExterior = value
        End Set
    End Property
    Property noInterior() As String
        Get
            Return Temp_noInterior
        End Get
        Set(value As String)
            Temp_noInterior = value
        End Set
    End Property
    Property colonia() As String
        Get
            Return Temp_colonia
        End Get
        Set(value As String)
            Temp_colonia = value
        End Set
    End Property
    Property localidad() As String
        Get
            Return Temp_localidad
        End Get
        Set(value As String)
            Temp_localidad = value
        End Set
    End Property
    Property referencia() As String
        Get
            Return Temp_referencia
        End Get
        Set(value As String)
            Temp_referencia = value
        End Set
    End Property
    Property municipio() As String
        Get
            Return Temp_municipio
        End Get
        Set(value As String)
            Temp_municipio = value
        End Set
    End Property
    Property estado() As String
        Get
            Return Temp_estado
        End Get
        Set(value As String)
            Temp_estado = value
        End Set
    End Property
    Property pais() As String
        Get
            Return Temp_pais
        End Get
        Set(value As String)
            Temp_pais = value
        End Set
    End Property
    Property codigoPostal() As String
        Get
            Return Temp_codigoPostal
        End Get
        Set(value As String)
            Temp_codigoPostal = value
        End Set
    End Property

End Class
