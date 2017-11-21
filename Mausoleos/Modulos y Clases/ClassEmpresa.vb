Public Class ClassEmpresa
    Inherits Domicilios
    Private _RFC As String = Nothing
    Private _Regimen As String = Nothing
    Private _Pwd As String = Nothing
    Private _Ruta_Llave As String = Nothing
    Private _Ruta_Certificado As String = Nothing
    Private _Razon_Social As String = Nothing
    Private _Logotipo As String = Nothing
    Private _Timbre_Usr As String = Nothing
    Private _Timbre_Pwd As String = Nothing
    Private _email As String = Nothing
    Private _eslogan As String = Nothing
    Private _curp As String = Nothing
    Private _telefono As String = Nothing
    Private _paginaWeb As String = Nothing
    Private _Descrp_Localidad As String = Nothing
    Private _Servidor_SMTP As String = Nothing
    Private _Puerto_SMTP As Integer = 0
    Private _Pwd_Email As String = Nothing
    Property Pwd_Email As String
        Get
            Return _Pwd_Email
        End Get
        Set(value As String)
            _Pwd_Email = value
        End Set
    End Property
    Property Puerto_SMTP As Integer
        Get
            Return _Puerto_SMTP
        End Get
        Set(value As Integer)
            _Puerto_SMTP = value
        End Set
    End Property
    Property Servidor_SMTP As String
        Get
            Return _Servidor_SMTP
        End Get
        Set(value As String)
            _Servidor_SMTP = value
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

    Property paginaWeb As String
        Get
            Return _paginaWeb
        End Get
        Set(value As String)
            _paginaWeb = value
        End Set
    End Property
    Property telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property
    Property curp As String
        Get
            Return _curp
        End Get
        Set(value As String)
            _curp = value
        End Set
    End Property
    Property eslogan As String
        Get
            Return _eslogan
        End Get
        Set(value As String)
            _eslogan = value
        End Set
    End Property
    Property email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property
    Property Logotipo As String
        Get
            Return _Logotipo
        End Get
        Set(value As String)
            _Logotipo = value
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
    Property Ruta_Certificado As String

        Get
            Return _Ruta_Certificado
        End Get
        Set(value As String)
            _Ruta_Certificado = value
        End Set
    End Property
    Property Ruta_Llave As String
        Get
            Return _Ruta_Llave
        End Get
        Set(value As String)
            _Ruta_Llave = value
        End Set
    End Property
    Property Pwd As String
        Get
            Return _Pwd
        End Get
        Set(value As String)
            _Pwd = value
        End Set
    End Property
    Property Regimen As String
        Get
            Return _Regimen
        End Get
        Set(value As String)
            _Regimen = Trim(value)
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
End Class
