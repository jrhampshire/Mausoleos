Imports System.Data.SqlClient

Public Class GlobalClass
    Public Shared sqlConn As SqlConnection
    Public Shared sqlDA As SqlDataAdapter
    Public Shared sqlCmd As SqlCommand
    Public Shared sqlCb As SqlCommandBuilder
    Public Shared DT As DataTable
    Public Shared DS As DataSet
    Public Shared Cmgr As CurrencyManager
    Public Shared CmdQuery As String

End Class
