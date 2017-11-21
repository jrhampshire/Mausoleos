Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class clConexion

    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Public Function ProbarConexion(ByVal nuevaconexion As String) As Boolean
        Cx.ConnectionString = nuevaconexion
        If AbrirConexion() Then
            ProbarConexion = True
            CerrarConexion()
        Else
            ProbarConexion = False
        End If
    End Function
    Private Function AbrirConexion() As Boolean
        Try
            Cx.Open()
            AbrirConexion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            AbrirConexion = False
        End Try
    End Function
    Private Function CerrarConexion() As Boolean
        Try
            Cx.Close()
            CerrarConexion = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            CerrarConexion = False
        End Try
    End Function

End Class
