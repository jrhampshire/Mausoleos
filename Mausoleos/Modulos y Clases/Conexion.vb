Imports System.Data.SqlClient

Public Class Conexion
    Public Shared Cxn As SqlConnection
    Public Shared strConn As String
    Public Sub Connection()

    End Sub
    Public Shared Function getConnection() As SqlConnection
        strConn = "Data Source=.\SQLEXPRESS;Initial Catalog=Mausoleos;Integrated Security=True"
        Cxn = New SqlConnection(strConn)
        Return Cxn
    End Function
End Class
