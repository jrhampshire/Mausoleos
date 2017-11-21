Public Class Sucursal
    Private Temp_Nombre As String = Nothing
    Private Temp_Clave As String = Nothing
    Private Temp_Telefono As String = Nothing
    Private Temp_email As String = Nothing
    Private Temp_Frontera As Boolean
    Private Temp_Calle As String = Nothing
    Private Temp_NumExt As String = Nothing
    Private Temp_NumInt As String = Nothing
    Private Temp_Referencia As String = Nothing
    Private Temp_CP As String = Nothing
    Private Temp_Colonia As String = Nothing
    Private Temp_Localidad As Integer = 0
    Private Temp_Municipio As Integer = 0
    Private Temp_Estado As Integer = 0
    Private Temp_Pais As Integer = 0
    Property Nombre As String
        Get
            Return Temp_Nombre
        End Get
        Set(value As String)
            Temp_Nombre = value
        End Set
    End Property
    Property Clave As String
        Get
            Return Temp_Clave
        End Get
        Set(value As String)
            Temp_Clave = value
        End Set
    End Property
    Property Telefono As String
        Get
            Return Temp_Telefono
        End Get
        Set(value As String)
            Temp_Telefono = value
        End Set
    End Property
    Property email As String
        Get
            Return Temp_email
        End Get
        Set(value As String)
            Temp_email = value
        End Set
    End Property
    Property Calle As String
        Get
            Return Temp_Calle
        End Get
        Set(value As String)
            Temp_Calle = value
        End Set
    End Property
    Property NumExt As String
        Get
            Return Temp_NumExt
        End Get
        Set(value As String)
            Temp_NumExt = value
        End Set

    End Property
    Property NumInt As String
        Get
            Return Temp_NumInt
        End Get
        Set(value As String)
            Temp_NumInt = value
        End Set
    End Property
    Property Referencia As String
        Get
            Return Temp_Referencia
        End Get
        Set(value As String)
            Temp_Referencia = value
        End Set
    End Property
    Property CP As String
        Get
            Return Temp_CP
        End Get
        Set(value As String)
            Temp_CP = value
        End Set
    End Property
    Property Frontera As Boolean
        Get
            Return Temp_Referencia
        End Get
        Set(value As Boolean)
            Temp_Referencia = value
        End Set
    End Property
    Property Colonia As String
        Get
            Return Temp_Colonia
        End Get
        Set(value As String)
            Temp_Colonia = value
        End Set
    End Property
    Property Localidad As Integer
        Get
            Return Temp_Localidad
        End Get
        Set(value As Integer)
            Temp_Localidad = value
        End Set
    End Property
    Property Municipio As Integer
        Get
            Return Temp_Municipio
        End Get
        Set(value As Integer)
            Temp_Municipio = value
        End Set
    End Property
    Property Estado As Integer
        Get
            Return Temp_Estado
        End Get
        Set(value As Integer)
            Temp_Estado = value
        End Set
    End Property
    Property Pais As Integer
        Get
            Return Temp_Pais
        End Get
        Set(value As Integer)
            Temp_Pais = value
        End Set
    End Property
End Class
