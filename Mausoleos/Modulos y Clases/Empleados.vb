Public Class Empleados
    Inherits Persona
    Private Temp_Pwd As String
    Private Temp_Usr As String
    Private Temp_Activo As String
    Private Temp_Permisos As String
    Private Temp_Pregunta_Secreta As String
    Private Temp_Respuesta As String
    'Private Temp_Observaciones As String


    'Property Observaciones As String
    '    Get
    '        Return Temp_Observaciones

    '    End Get
    '    Set(value As String)
    '        Temp_Observaciones = value
    '    End Set
    'End Property
    Property Usr() As String
        Get
            Return Temp_Usr
        End Get
        Set(ByVal value As String)
            Temp_Usr = value

        End Set
    End Property
    Property Pwd() As String
        Get
            Return Temp_Pwd
        End Get
        Set(ByVal value As String)
            Temp_Pwd = value
        End Set
    End Property
    Property Activo() As String
        Get
            Return Temp_Activo
        End Get
        Set(value As String)
            Temp_Activo = value
        End Set
    End Property
    Property Permisos() As String
        Get
            Return Temp_Permisos
        End Get
        Set(ByVal value As String)
            Temp_Permisos = value
        End Set
    End Property

End Class
