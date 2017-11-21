Public Class PlanesServicios_Class
    Private Temp_Descripcion As String
    Private Temp_valorUnitario As Double
    Private Temp_Tipo As String
    Private Temp_Unidad As String
    Private Temp_Id As Integer
    Property Descripcion() As String
        Get
            Return Temp_Descripcion

        End Get
        Set(value As String)
            Temp_Descripcion = value
        End Set
    End Property
    Property valorUnitario As Double
        Get
            Return Temp_valorUnitario
        End Get
        Set(value As Double)
            Temp_valorUnitario = value
        End Set
    End Property
    Property Tipo As String
        Get
            Return Temp_Tipo
        End Get
        Set(value As String)
            Temp_Tipo = value
        End Set
    End Property
    Property Unidad As String
        Get
            Return Temp_Unidad
        End Get
        Set(value As String)
            Temp_Unidad = value
        End Set
    End Property
    Property Id As Integer
        Get
            Return Temp_Id
        End Get
        Set(value As Integer)
            Temp_Id = value
        End Set
    End Property


End Class
