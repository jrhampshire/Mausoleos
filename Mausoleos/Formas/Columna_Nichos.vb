Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Columna_Nichos
#Region "Variables"
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Public Cx1 As New SqlConnection(CxSettings.ConnectionString)

    Dim SQL_Str As String = Nothing
#End Region



    Private Sub Columna_Nichos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Pintar()

    End Sub

    Sub Pintar()
        Dim ModuloColumna(1) As String
        ModuloColumna = Boton_Actual.Split("-")

        'Primero pinta todos los botones de verde
        For Each c As Control In Me.Controls
            If TypeOf (c) Is Button Then
                If c.Name <> "Button9" Then
                    c.BackColor = Color.LightGreen
                End If

            End If
        Next
        Dim SQL_Str1 As String = Nothing
        'Aqui pinta los que ya estan todos vendidos en rojo

        SQL_Str = "Select Id_Gaveta, Fila from Gavetas where Modulo = @Modulo and Columna = @Columna" &
            " and Id_Gaveta in (Select Id_Gaveta from contratos where Cancelado = 'False')"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Modulo", ModuloColumna(0))
            Cmd.Parameters.AddWithValue("@Columna", ModuloColumna(1))
            Dim Reader As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            With Reader
                If .HasRows Then
                    While .Read
                        For Each c As Control In Me.Controls
                            If TypeOf (c) Is Button Then
                                If c.Text = .Item("Fila").ToString Then
                                    c.BackColor = Color.Red
                                    c.Enabled = False
                                    Dim Boton = c.Text

                                    SQL_Str1 = "Select Nombre from Personas where ID_Personas = (Select Id_Cliente from Contratos where Id_Gaveta = " & .Item("Id_Gaveta") & ")"
                                    Try
                                        Cx1.Open()
                                        Dim Cmd1 As New SqlCommand(SQL_Str1, Cx1)
                                        Cmd1.CommandType = CommandType.Text
                                        Dim R As SqlDataReader = Cmd1.ExecuteReader(CommandBehavior.CloseConnection)
                                        With R
                                            If .HasRows Then
                                                While .Read
                                                    For Each l As Control In Me.Controls
                                                        If TypeOf (l) Is Label Then
                                                            If l.Name = Boton Then
                                                                l.Text = .Item("Nombre")
                                                            End If
                                                        End If
                                                    Next
                                                End While
                                            End If
                                        End With
                                        Cx1.Close()
                                    Catch ex1 As SqlException
                                        MessageBox.Show("Error: " & ex1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    Catch ex1 As Exception
                                        MessageBox.Show("Error: " & ex1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    Finally
                                        If Cx1.State = ConnectionState.Open Then
                                            Cx1.Close()
                                        End If
                                    End Try
                                End If
                            End If
                        Next
                    End While
                End If
            End With
        Catch ex As SqlException
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Boton_Actual = Boton_Actual & "-" & Me.Button1.Text
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Boton_Actual = Boton_Actual & "-" & Me.Button2.Text
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Boton_Actual = Boton_Actual & "-" & Me.Button3.Text
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Boton_Actual = Boton_Actual & "-" & Me.Button4.Text
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Boton_Actual = Boton_Actual & "-" & Me.Button5.Text
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Boton_Actual = Boton_Actual & "-" & Me.Button6.Text
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Boton_Actual = Boton_Actual & "-" & Me.Button7.Text
        Me.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Boton_Actual = Boton_Actual & "-" & Me.Button8.Text
        Me.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Boton_Actual = ""
        Me.Close()
    End Sub
End Class