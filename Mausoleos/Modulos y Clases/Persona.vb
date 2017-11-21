Public Class Persona
    Inherits Domicilios
    Private Temp_Id_Persona As Integer
    Private Temp_Nombre As String
    Private Temp_Id_Estado_Civil As Integer
    Private Temp_Tel_Particular As String
    Private Temp_Tel_Oficina As String
    Private Temp_Celular As String
    Private Temp_Email As String
    Private Temp_sexo As String
    Private Temp_Fecha_Nacimiento As Date
    Private Temp_CURP As String
    Private Temp_IFE As String
    Private Temp_Ocupacion As String
    Private Temp_Empresa_Trab As String
    Private Temp_Observaciones As String

    Property Observaciones As String
        Get
            Return Temp_Observaciones
        End Get
        Set(value As String)
            Temp_Observaciones = value
        End Set
    End Property

    Property Id_Persona() As Integer
        Get
            Return Temp_Id_Persona
        End Get
        Set(ByVal value As Integer)
            Temp_Id_Persona = value
        End Set
    End Property
    Property Nombre()
        Get
            Return Temp_Nombre
        End Get
        Set(ByVal value)
            Temp_Nombre = Trim(value)
        End Set
    End Property
    Property Id_Estado_Civil() As Integer
        Get
            Return Temp_Id_Estado_Civil
        End Get
        Set(value As Integer)
            Temp_Id_Estado_Civil = value
        End Set
    End Property
    Property Tel_Particular() As String
        Get
            Return Temp_Tel_Particular

        End Get
        Set(value As String)
            Temp_Tel_Particular = value
        End Set
    End Property
    Property Tel_Oficina() As String
        Get
            Return Temp_Tel_Oficina

        End Get
        Set(value As String)
            Temp_Tel_Oficina = value
        End Set
    End Property
    Property Celular() As String
        Get
            Return Temp_Celular

        End Get
        Set(value As String)
            Temp_Celular = value
        End Set
    End Property
    Property Email() As String
        Get
            Return Temp_Email

        End Get
        Set(value As String)
            Temp_Email = value
        End Set
    End Property
    Property Sexo() As String
        Get
            Return Temp_sexo
        End Get
        Set(value As String)
            Temp_sexo = value
        End Set
    End Property
    Property Fecha_Nacimiento()
        Get
            Return Temp_Fecha_Nacimiento
        End Get
        Set(ByVal value)
            Temp_Fecha_Nacimiento = value
        End Set
    End Property
    Function Edad()
        Edad = Year(Now) - Year(Fecha_Nacimiento)
    End Function
    Property CURP() As String
        Get
            Return Temp_CURP

        End Get
        Set(value As String)
            Temp_CURP = value
        End Set
    End Property
    Property IFE() As String
        Get
            Return Temp_IFE
        End Get
        Set(value As String)
            Temp_IFE = value
        End Set
    End Property
    Property Ocupacion() As String
        Get
            Return Temp_Ocupacion
        End Get
        Set(value As String)
            Temp_Ocupacion = value
        End Set
    End Property
    Property Empresa_Trab() As String
        Get
            Return Temp_Empresa_Trab
        End Get
        Set(value As String)
            Temp_Empresa_Trab = value
        End Set
    End Property
End Class
