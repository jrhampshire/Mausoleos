Public Class Beneficiarios_Class
    Private Temp_Nombre As String = Nothing
    Private Temp_Parentesco As Integer = 0
    Private Temp_Calle As String = Nothing
    Private Temp_Num_Int As String = Nothing
    Private Temp_Num_Ext As String = Nothing
    Private Temp_Colonia As String = Nothing
    Private Temp_Localidad As String = Nothing
    Private Temp_Telefono As String = Nothing
    Private Temp_Celular As String = Nothing
    Private Temp_Fecha_Nac As Date = Nothing
    Private Temp_Sexo As String = Nothing
    Private Temp_Notas As String = Nothing
    Private Temp_CP As Integer = 0
    Property CP As Integer
        Get
            Return Temp_CP
        End Get
        Set(value As Integer)
            Temp_CP = value
        End Set
    End Property
    Property Nombre As String
        Get
            Return Temp_Nombre

        End Get
        Set(value As String)
            Temp_Nombre = value
        End Set
    End Property
    Property Parentesco As Integer
        Get
            Return Temp_Parentesco
        End Get
        Set(value As Integer)
            Temp_Parentesco = value
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
    Property Num_Int As String
        Get
            Return Temp_Num_Int
        End Get
        Set(value As String)
            Temp_Num_Int = value
        End Set
    End Property
    Property Num_Ext As String
        Get
            Return Temp_Num_Ext
        End Get
        Set(value As String)
            Temp_Num_Ext = value
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
    Property Localidad As String
        Get
            Return Temp_Localidad
        End Get
        Set(value As String)
            Temp_Localidad = value
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
    Property Celular As String
        Get
            Return Temp_Celular
        End Get
        Set(value As String)
            Temp_Celular = value
        End Set
    End Property
    Property Fecha_Nac As Date
        Get
            Return Temp_Fecha_Nac
        End Get
        Set(value As Date)
            Temp_Fecha_Nac = value
        End Set
    End Property
    Property Sexo As String
        Get
            Return Temp_Sexo
        End Get
        Set(value As String)
            Temp_Sexo = value
        End Set
    End Property
    Property Notas As String
        Get
            Return Temp_Notas
        End Get
        Set(value As String)
            Temp_Notas = value
        End Set
    End Property
End Class
