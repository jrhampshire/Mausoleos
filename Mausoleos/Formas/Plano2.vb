Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration


Public Class Plano2
#Region "Variables"
    Dim SQL_Str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
#End Region
#Region "Codigo General"
    Private Sub Plano2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Pintar()
        For Each Btn In GroupBox1.Controls.OfType(Of Button)()
            AddHandler Btn.Click, AddressOf My_Click
        Next

    End Sub
    Sub My_Click()
        Dim Frm_Detalle As New Columna_Nichos
        Frm_Detalle.ShowDialog()

    End Sub
    Sub Pintar()
        For Each c As Control In Me.GroupBox1.Controls

            'For Each c As Control In Me.Controls
            If TypeOf (c) Is Button Then
                c.BackColor = Color.LightGreen
            End If
        Next

        'Aqui pinta los botones dependiendo de la cantidad de vendidos
        'SQL_Str = "Select V.Modulo, V.Columna, V.Vendidos, T.Totales From View_Gavetas_Vendidas as V, View_Gavetas_Totales as T Where V.Modulo = T.Modulo and V.Columna= T.Columna"
        SQL_Str = "Select Modulo, Columna, Sum(Vendidos)as Vendidos from View_Gavetas_Vendidas group by Modulo,columna"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Dim Reader As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            With Reader
                If .HasRows Then
                    While .Read
                        For Each c As Control In Me.GroupBox1.Controls
                            If TypeOf (c) Is Button Then
                                If c.Text = .Item(0).ToString & "-" & .Item(1) Or c.AccessibleDescription = .Item(0).ToString & "-" & .Item(1) Then
                                    If .Item(2).ToString >= 1 And .Item(2) < 8 Then
                                        c.BackColor = Color.Yellow
                                    ElseIf .Item(2) = 8 Then
                                        c.BackColor = Color.Red
                                    Else
                                        c.BackColor = Color.LightGreen
                                    End If
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
#End Region

#Region "Codigo Botones"
    Private Sub Button_1_1_Click(sender As Object, e As EventArgs) Handles Button_1_1.Click
        Boton_Actual = Button_1_1.Text
    End Sub
    Private Sub Button_1_2_Click(sender As Object, e As EventArgs) Handles Button_1_2.Click
        Boton_Actual = Button_1_2.Text

    End Sub

    Private Sub Button_1_3_Click(sender As Object, e As EventArgs) Handles Button_1_3.Click
        Boton_Actual = Button_1_3.Text
    End Sub

    Private Sub Button_1_4_Click(sender As Object, e As EventArgs) Handles Button_1_4.Click
        Boton_Actual = Button_1_4.Text
    End Sub

    Private Sub Button_1_5_Click(sender As Object, e As EventArgs) Handles Button_1_5.Click
        Boton_Actual = Button_1_5.Text
    End Sub

    Private Sub Button_1_6_Click(sender As Object, e As EventArgs) Handles Button_1_6.Click
        Boton_Actual = Button_1_6.Text
    End Sub

    Private Sub Button_1_7_Click(sender As Object, e As EventArgs) Handles Button_1_7.Click
        Boton_Actual = Button_1_7.Text
    End Sub

    Private Sub Button_1_8_Click(sender As Object, e As EventArgs) Handles Button_1_8.Click
        Boton_Actual = Button_1_8.Text
    End Sub

    Private Sub Button_1_9_Click(sender As Object, e As EventArgs) Handles Button_1_9.Click
        Boton_Actual = Button_1_9.Text
    End Sub

    Private Sub Button_6_1_Click(sender As Object, e As EventArgs) Handles Button_6_1.Click
        Boton_Actual = Button_6_1.Text
    End Sub

    Private Sub Button_6_2_Click(sender As Object, e As EventArgs) Handles Button_6_2.Click
        Boton_Actual = Button_6_2.Text
    End Sub

    Private Sub Button_6_3_Click(sender As Object, e As EventArgs) Handles Button_6_3.Click
        Boton_Actual = Button_6_3.Text
    End Sub

    Private Sub Button_6_4_Click(sender As Object, e As EventArgs) Handles Button_6_4.Click
        Boton_Actual = Button_6_4.Text
    End Sub

    Private Sub Button_6_5_Click(sender As Object, e As EventArgs) Handles Button_6_5.Click
        Boton_Actual = Button_6_5.Text
    End Sub

    Private Sub Button_6_6_Click(sender As Object, e As EventArgs) Handles Button_6_6.Click
        Boton_Actual = Button_6_6.Text
    End Sub

    Private Sub Button_6_7_Click(sender As Object, e As EventArgs) Handles Button_6_7.Click
        Boton_Actual = Button_6_7.Text
    End Sub

    Private Sub Button_6_8_Click(sender As Object, e As EventArgs) Handles Button_6_8.Click
        Boton_Actual = Button_6_8.Text
    End Sub

    Private Sub Button_7_1_Click(sender As Object, e As EventArgs) Handles Button_7_1.Click
        Boton_Actual = Button_7_1.Text
    End Sub

    Private Sub Button_7_2_Click(sender As Object, e As EventArgs) Handles Button_7_2.Click
        Boton_Actual = Button_7_2.Text
    End Sub

    Private Sub Button_7_3_Click(sender As Object, e As EventArgs) Handles Button_7_3.Click
        Boton_Actual = Button_7_3.Text
    End Sub

    Private Sub Button_7_4_Click(sender As Object, e As EventArgs) Handles Button_7_4.Click
        Boton_Actual = Button_7_4.Text
    End Sub

    Private Sub Button_7_5_Click(sender As Object, e As EventArgs) Handles Button_7_5.Click
        Boton_Actual = Button_7_5.Text
    End Sub

    Private Sub Button_7_6_Click(sender As Object, e As EventArgs) Handles Button_7_6.Click
        Boton_Actual = Button_7_6.Text
    End Sub

    Private Sub Button_7_7_Click(sender As Object, e As EventArgs) Handles Button_7_7.Click
        Boton_Actual = Button_7_7.Text
    End Sub

    Private Sub Button_8_1_Click(sender As Object, e As EventArgs) Handles Button_8_1.Click
        Boton_Actual = "8-1"
    End Sub

    Private Sub Button_8_2_Click(sender As Object, e As EventArgs) Handles Button_8_2.Click
        Boton_Actual = "8-2"
    End Sub

    Private Sub Button_8_3_Click(sender As Object, e As EventArgs) Handles Button_8_3.Click
        Boton_Actual = "8-3"
    End Sub

    Private Sub Button_8_4_Click(sender As Object, e As EventArgs) Handles Button_8_4.Click
        Boton_Actual = "8-4"
    End Sub

    Private Sub Button_8_5_Click(sender As Object, e As EventArgs) Handles Button_8_5.Click
        Boton_Actual = "8-5"
    End Sub

    Private Sub Button_8_6_Click(sender As Object, e As EventArgs) Handles Button_8_6.Click
        Boton_Actual = "8-6"
    End Sub

    Private Sub Button_8_7_Click(sender As Object, e As EventArgs) Handles Button_8_7.Click
        Boton_Actual = "8-7"
    End Sub

    Private Sub Button_8_8_Click(sender As Object, e As EventArgs) Handles Button_8_8.Click
        Boton_Actual = "8-8"
    End Sub

    Private Sub Button_8_9_Click(sender As Object, e As EventArgs) Handles Button_8_9.Click
        Boton_Actual = "8-9"
    End Sub

    Private Sub Button_8_10_Click(sender As Object, e As EventArgs) Handles Button_8_10.Click
        Boton_Actual = "8-10"
    End Sub

    Private Sub Button_8_11_Click(sender As Object, e As EventArgs) Handles Button_8_11.Click
        Boton_Actual = "8-11"
    End Sub

    Private Sub Button_8_12_Click(sender As Object, e As EventArgs) Handles Button_8_12.Click
        Boton_Actual = "8-12"
    End Sub

    Private Sub Button_9_1_Click(sender As Object, e As EventArgs) Handles Button_9_1.Click
        Boton_Actual = Button_9_1.Text
    End Sub

    Private Sub Button_9_2_Click(sender As Object, e As EventArgs) Handles Button_9_2.Click
        Boton_Actual = Button_9_2.Text
    End Sub

    Private Sub Button_9_3_Click(sender As Object, e As EventArgs) Handles Button_9_3.Click
        Boton_Actual = Button_9_3.Text
    End Sub

    Private Sub Button_9_4_Click(sender As Object, e As EventArgs) Handles Button_9_4.Click
        Boton_Actual = Button_9_4.Text
    End Sub

    Private Sub Button_9_5_Click(sender As Object, e As EventArgs) Handles Button_9_5.Click
        Boton_Actual = Button_9_5.Text
    End Sub

    Private Sub Button_9_6_Click(sender As Object, e As EventArgs) Handles Button_9_6.Click
        Boton_Actual = Button_9_6.Text
    End Sub

    Private Sub Button_9_7_Click(sender As Object, e As EventArgs) Handles Button_9_7.Click
        Boton_Actual = Button_9_7.Text
    End Sub

    Private Sub Button_9_8_Click(sender As Object, e As EventArgs) Handles Button_9_8.Click
        Boton_Actual = Button_9_8.Text
    End Sub

    Private Sub Button_9_9_Click(sender As Object, e As EventArgs) Handles Button_9_9.Click
        Boton_Actual = Button_9_9.Text
    End Sub

    Private Sub Button_9_10_Click(sender As Object, e As EventArgs) Handles Button_9_10.Click
        Boton_Actual = Button_9_10.Text
    End Sub

    Private Sub Button_9_11_Click(sender As Object, e As EventArgs) Handles Button_9_11.Click
        Boton_Actual = Button_9_11.Text
    End Sub

    Private Sub Button_9_12_Click(sender As Object, e As EventArgs) Handles Button_9_12.Click
        Boton_Actual = Button_9_12.Text
    End Sub

    Private Sub Button_10_1_Click(sender As Object, e As EventArgs) Handles Button_10_1.Click
        Boton_Actual = "10-1"
    End Sub

    Private Sub Button_10_2_Click(sender As Object, e As EventArgs) Handles Button_10_2.Click
        Boton_Actual = "10-2"
    End Sub

    Private Sub Button_10_3_Click(sender As Object, e As EventArgs) Handles Button_10_3.Click
        Boton_Actual = "10-3"
    End Sub

    Private Sub Button_10_4_Click(sender As Object, e As EventArgs) Handles Button_10_4.Click
        Boton_Actual = "10-4"
    End Sub

    Private Sub Button_10_5_Click(sender As Object, e As EventArgs) Handles Button_10_5.Click
        Boton_Actual = "10-5"
    End Sub

    Private Sub Button_10_6_Click(sender As Object, e As EventArgs) Handles Button_10_6.Click
        Boton_Actual = "10-6"
    End Sub

    Private Sub Button_10_7_Click(sender As Object, e As EventArgs) Handles Button_10_7.Click
        Boton_Actual = "10-7"
    End Sub

    Private Sub Button_10_8_Click(sender As Object, e As EventArgs) Handles Button_10_8.Click
        Boton_Actual = "10-8"
    End Sub

    Private Sub Button_10_9_Click(sender As Object, e As EventArgs) Handles Button_10_9.Click
        Boton_Actual = "10-9"
    End Sub

    Private Sub Button_10_10_Click(sender As Object, e As EventArgs) Handles Button_10_10.Click
        Boton_Actual = "10-10"
    End Sub

    Private Sub Button_10_11_Click(sender As Object, e As EventArgs) Handles Button_10_11.Click
        Boton_Actual = "10-11"
    End Sub

    Private Sub Button_10_12_Click(sender As Object, e As EventArgs) Handles Button_10_12.Click
        Boton_Actual = "10-12"
    End Sub

    Private Sub Button_10_13_Click(sender As Object, e As EventArgs) Handles Button_10_13.Click
        Boton_Actual = "10-13"
    End Sub

    Private Sub Button_10_14_Click(sender As Object, e As EventArgs) Handles Button_10_14.Click
        Boton_Actual = "10-14"
    End Sub

    Private Sub Button_10_15_Click(sender As Object, e As EventArgs) Handles Button_10_15.Click
        Boton_Actual = "10-15"
    End Sub

    Private Sub Button_10_16_Click(sender As Object, e As EventArgs) Handles Button_10_16.Click
        Boton_Actual = "10-16"
    End Sub

    Private Sub Button_11_1_Click(sender As Object, e As EventArgs) Handles Button_11_1.Click
        Boton_Actual = Button_11_1.Text
    End Sub

    Private Sub Button_11_2_Click(sender As Object, e As EventArgs) Handles Button_11_2.Click
        Boton_Actual = Button_11_2.Text
    End Sub

    Private Sub Button_11_3_Click(sender As Object, e As EventArgs) Handles Button_11_3.Click
        Boton_Actual = Button_11_3.Text
    End Sub

    Private Sub Button102_Click(sender As Object, e As EventArgs) Handles Button102.Click
        Boton_Actual = Button102.Text
    End Sub

    Private Sub Button101_Click(sender As Object, e As EventArgs) Handles Button101.Click
        Boton_Actual = Button101.Text
    End Sub

    Private Sub Button100_Click(sender As Object, e As EventArgs) Handles Button100.Click
        Boton_Actual = Button100.Text
    End Sub

    Private Sub Button99_Click(sender As Object, e As EventArgs) Handles Button99.Click
        Boton_Actual = Button99.Text
    End Sub

    Private Sub Button107_Click(sender As Object, e As EventArgs) Handles Button107.Click
        Boton_Actual = Button107.Text
    End Sub

    Private Sub Button108_Click(sender As Object, e As EventArgs) Handles Button108.Click
        Boton_Actual = Button108.Text
    End Sub

    Private Sub Button98_Click(sender As Object, e As EventArgs) Handles Button98.Click
        Boton_Actual = Button98.Text
    End Sub

    Private Sub Button105_Click(sender As Object, e As EventArgs) Handles Button105.Click
        Boton_Actual = Button105.Text
    End Sub

    Private Sub Button186_Click(sender As Object, e As EventArgs) Handles Button186.Click
        Boton_Actual = "30-1"
    End Sub

    Private Sub Button185_Click(sender As Object, e As EventArgs) Handles Button185.Click
        Boton_Actual = "30-2"
    End Sub

    Private Sub Button184_Click(sender As Object, e As EventArgs) Handles Button184.Click
        Boton_Actual = "30-3"
    End Sub

    Private Sub Button183_Click(sender As Object, e As EventArgs) Handles Button183.Click
        Boton_Actual = "30-4"
    End Sub

    Private Sub Button190_Click(sender As Object, e As EventArgs) Handles Button190.Click
        Boton_Actual = "30-5"
    End Sub

    Private Sub Button189_Click(sender As Object, e As EventArgs) Handles Button189.Click
        Boton_Actual = "30-6"
    End Sub

    Private Sub Button188_Click(sender As Object, e As EventArgs) Handles Button188.Click
        Boton_Actual = "30-7"
    End Sub

    Private Sub Button187_Click(sender As Object, e As EventArgs) Handles Button187.Click
        Boton_Actual = "30-8"
    End Sub

    Private Sub Button180_Click(sender As Object, e As EventArgs) Handles Button180.Click
        Boton_Actual = Button180.Text
    End Sub

    Private Sub Button173_Click(sender As Object, e As EventArgs) Handles Button173.Click
        Boton_Actual = Button173.Text
    End Sub

    Private Sub Button172_Click(sender As Object, e As EventArgs) Handles Button172.Click
        Boton_Actual = Button172.Text
    End Sub

    Private Sub Button171_Click(sender As Object, e As EventArgs) Handles Button171.Click
        Boton_Actual = Button171.Text
    End Sub

    Private Sub Button174_Click(sender As Object, e As EventArgs) Handles Button174.Click
        Boton_Actual = Button174.Text
    End Sub

    Private Sub Button175_Click(sender As Object, e As EventArgs) Handles Button175.Click
        Boton_Actual = Button175.Text
    End Sub

    Private Sub Button176_Click(sender As Object, e As EventArgs) Handles Button176.Click
        Boton_Actual = Button176.Text
    End Sub

    Private Sub Button177_Click(sender As Object, e As EventArgs) Handles Button177.Click
        Boton_Actual = Button177.Text
    End Sub

    Private Sub Button178_Click(sender As Object, e As EventArgs) Handles Button178.Click
        Boton_Actual = Button178.Text
    End Sub

    Private Sub Button179_Click(sender As Object, e As EventArgs) Handles Button179.Click
        Boton_Actual = Button179.Text
    End Sub

    Private Sub Button182_Click(sender As Object, e As EventArgs) Handles Button182.Click
        Boton_Actual = Button182.Text
    End Sub

    Private Sub Button_13_1_Click(sender As Object, e As EventArgs) Handles Button_13_1.Click
        Boton_Actual = Button_13_1.Text
    End Sub

    Private Sub Button_13_2_Click(sender As Object, e As EventArgs) Handles Button_13_2.Click
        Boton_Actual = Button_13_2.Text
    End Sub

    Private Sub Button_13_3_Click(sender As Object, e As EventArgs) Handles Button_13_3.Click
        Boton_Actual = Button_13_3.Text
    End Sub

    Private Sub Button_13_4_Click(sender As Object, e As EventArgs) Handles Button_13_4.Click
        Boton_Actual = Button_13_4.Text
    End Sub

    Private Sub Button_13_5_Click(sender As Object, e As EventArgs) Handles Button_13_5.Click
        Boton_Actual = Button_13_5.Text
    End Sub

    Private Sub Button_13_6_Click(sender As Object, e As EventArgs) Handles Button_13_6.Click
        Boton_Actual = Button_13_6.Text
    End Sub

    Private Sub Button_13_7_Click(sender As Object, e As EventArgs) Handles Button_13_7.Click
        Boton_Actual = Button_13_7.Text
    End Sub

    Private Sub Button_13_8_Click(sender As Object, e As EventArgs) Handles Button_13_8.Click
        Boton_Actual = Button_13_8.Text
    End Sub

    Private Sub Button_13_9_Click(sender As Object, e As EventArgs) Handles Button_13_9.Click
        Boton_Actual = Button_13_9.Text
    End Sub

    Private Sub Button_14_1_Click(sender As Object, e As EventArgs) Handles Button_14_1.Click
        Boton_Actual = Button_14_1.Text
    End Sub

    Private Sub Button_14_2_Click(sender As Object, e As EventArgs) Handles Button_14_2.Click
        Boton_Actual = Button_14_2.Text
    End Sub

    Private Sub Button_14_3_Click(sender As Object, e As EventArgs) Handles Button_14_3.Click
        Boton_Actual = Button_14_3.Text
    End Sub

    Private Sub Button_14_4_Click(sender As Object, e As EventArgs) Handles Button_14_4.Click
        Boton_Actual = Button_14_4.Text
    End Sub

    Private Sub Button_14_5_Click(sender As Object, e As EventArgs) Handles Button_14_5.Click
        Boton_Actual = Button_14_5.Text
    End Sub

    Private Sub Button_14_6_Click(sender As Object, e As EventArgs) Handles Button_14_6.Click
        Boton_Actual = Button_14_6.Text
    End Sub

    Private Sub Button_14_7_Click(sender As Object, e As EventArgs) Handles Button_14_7.Click
        Boton_Actual = Button_14_7.Text
    End Sub

    Private Sub Button_14_8_Click(sender As Object, e As EventArgs) Handles Button_14_8.Click
        Boton_Actual = Button_14_8.Text
    End Sub

    Private Sub Button_14_9_Click(sender As Object, e As EventArgs) Handles Button_14_9.Click
        Boton_Actual = Button_14_9.Text
    End Sub

    Private Sub Button70_Click(sender As Object, e As EventArgs) Handles Button70.Click
        Boton_Actual = Button70.Text
    End Sub

    Private Sub Button63_Click(sender As Object, e As EventArgs) Handles Button63.Click
        Boton_Actual = Button63.Text
    End Sub

    Private Sub Button64_Click(sender As Object, e As EventArgs) Handles Button64.Click
        Boton_Actual = Button64.Text
    End Sub

    Private Sub Button65_Click(sender As Object, e As EventArgs) Handles Button65.Click
        Boton_Actual = Button65.Text
    End Sub

    Private Sub Button66_Click(sender As Object, e As EventArgs) Handles Button66.Click
        Boton_Actual = Button66.Text
    End Sub

    Private Sub Button67_Click(sender As Object, e As EventArgs) Handles Button67.Click
        Boton_Actual = Button67.Text
    End Sub

    Private Sub Button68_Click(sender As Object, e As EventArgs) Handles Button68.Click
        Boton_Actual = Button68.Text
    End Sub

    Private Sub Button69_Click(sender As Object, e As EventArgs) Handles Button69.Click
        Boton_Actual = Button69.Text
    End Sub

    Private Sub Button71_Click(sender As Object, e As EventArgs) Handles Button71.Click
        Boton_Actual = Button71.Text
    End Sub

    Private Sub Button62_Click(sender As Object, e As EventArgs) Handles Button62.Click
        Boton_Actual = Button62.Text
    End Sub

    Private Sub Button60_Click(sender As Object, e As EventArgs) Handles Button60.Click
        Boton_Actual = Button60.Text
    End Sub

    Private Sub Button59_Click(sender As Object, e As EventArgs) Handles Button59.Click
        Boton_Actual = Button59.Text
    End Sub

    Private Sub Button58_Click(sender As Object, e As EventArgs) Handles Button58.Click
        Boton_Actual = Button58.Text
    End Sub

    Private Sub Button57_Click(sender As Object, e As EventArgs) Handles Button57.Click
        Boton_Actual = Button57.Text
    End Sub

    Private Sub Button56_Click(sender As Object, e As EventArgs) Handles Button56.Click
        Boton_Actual = Button56.Text
    End Sub

    Private Sub Button55_Click(sender As Object, e As EventArgs) Handles Button55.Click
        Boton_Actual = Button55.Text
    End Sub

    Private Sub Button54_Click(sender As Object, e As EventArgs) Handles Button54.Click
        Boton_Actual = Button54.Text
    End Sub

    Private Sub Button61_Click(sender As Object, e As EventArgs) Handles Button61.Click
        Boton_Actual = Button61.Text
    End Sub

    Private Sub Button88_Click(sender As Object, e As EventArgs) Handles Button88.Click
        Boton_Actual = Button88.Text
    End Sub

    Private Sub Button81_Click(sender As Object, e As EventArgs) Handles Button81.Click
        Boton_Actual = Button81.Text
    End Sub

    Private Sub Button82_Click(sender As Object, e As EventArgs) Handles Button82.Click
        Boton_Actual = Button82.Text
    End Sub

    Private Sub Button83_Click(sender As Object, e As EventArgs) Handles Button83.Click
        Boton_Actual = Button83.Text
    End Sub

    Private Sub Button84_Click(sender As Object, e As EventArgs) Handles Button84.Click
        Boton_Actual = Button84.Text
    End Sub

    Private Sub Button85_Click(sender As Object, e As EventArgs) Handles Button85.Click
        Boton_Actual = Button85.Text
    End Sub

    Private Sub Button86_Click(sender As Object, e As EventArgs) Handles Button86.Click
        Boton_Actual = Button86.Text
    End Sub

    Private Sub Button87_Click(sender As Object, e As EventArgs) Handles Button87.Click
        Boton_Actual = Button87.Text
    End Sub

    Private Sub Button79_Click(sender As Object, e As EventArgs) Handles Button79.Click
        Boton_Actual = Button79.Text
    End Sub

    Private Sub Button72_Click(sender As Object, e As EventArgs) Handles Button72.Click
        Boton_Actual = Button72.Text
    End Sub

    Private Sub Button73_Click(sender As Object, e As EventArgs) Handles Button73.Click
        Boton_Actual = Button73.Text
    End Sub

    Private Sub Button74_Click(sender As Object, e As EventArgs) Handles Button74.Click
        Boton_Actual = Button74.Text
    End Sub

    Private Sub Button75_Click(sender As Object, e As EventArgs) Handles Button75.Click
        Boton_Actual = Button75.Text
    End Sub

    Private Sub Button76_Click(sender As Object, e As EventArgs) Handles Button76.Click
        Boton_Actual = Button76.Text
    End Sub

    Private Sub Button77_Click(sender As Object, e As EventArgs) Handles Button77.Click
        Boton_Actual = Button77.Text
    End Sub

    Private Sub Button78_Click(sender As Object, e As EventArgs) Handles Button78.Click
        Boton_Actual = Button78.Text
    End Sub

    Private Sub Button80_Click(sender As Object, e As EventArgs) Handles Button80.Click
        Boton_Actual = Button80.Text
    End Sub

    Private Sub Button124_Click(sender As Object, e As EventArgs) Handles Button124.Click
        Boton_Actual = "29-1"
    End Sub

    Private Sub Button125_Click(sender As Object, e As EventArgs) Handles Button125.Click
        Boton_Actual = "29-2"
    End Sub

    Private Sub Button126_Click(sender As Object, e As EventArgs) Handles Button126.Click
        Boton_Actual = "29-3"
    End Sub

    Private Sub Button127_Click(sender As Object, e As EventArgs) Handles Button127.Click
        Boton_Actual = "29-4"
    End Sub

    Private Sub Button128_Click(sender As Object, e As EventArgs) Handles Button128.Click
        Boton_Actual = "29-5"
    End Sub

    Private Sub Button129_Click(sender As Object, e As EventArgs) Handles Button129.Click
        Boton_Actual = "29-6"
    End Sub

    Private Sub Button130_Click(sender As Object, e As EventArgs) Handles Button130.Click
        Boton_Actual = "29-7"
    End Sub

    Private Sub Button115_Click(sender As Object, e As EventArgs) Handles Button115.Click
        Boton_Actual = "29-8"
    End Sub

    Private Sub Button116_Click(sender As Object, e As EventArgs) Handles Button116.Click
        Boton_Actual = "29-9"
    End Sub

    Private Sub Button117_Click(sender As Object, e As EventArgs) Handles Button117.Click
        Boton_Actual = "29-10"
    End Sub

    Private Sub Button118_Click(sender As Object, e As EventArgs) Handles Button118.Click
        Boton_Actual = "29-11"
    End Sub

    Private Sub Button119_Click(sender As Object, e As EventArgs) Handles Button119.Click
        Boton_Actual = "29-12"
    End Sub

    Private Sub Button120_Click(sender As Object, e As EventArgs) Handles Button120.Click
        Boton_Actual = "29-13"
    End Sub

    Private Sub Button121_Click(sender As Object, e As EventArgs) Handles Button121.Click
        Boton_Actual = "29-14"
    End Sub

    Private Sub Button122_Click(sender As Object, e As EventArgs) Handles Button122.Click
        Boton_Actual = "29-15"
    End Sub

    Private Sub Button111_Click(sender As Object, e As EventArgs) Handles Button111.Click
        Boton_Actual = "29-16"
    End Sub

    Private Sub Button112_Click(sender As Object, e As EventArgs) Handles Button112.Click
        Boton_Actual = "29-17"
    End Sub

    Private Sub Button113_Click(sender As Object, e As EventArgs) Handles Button113.Click
        Boton_Actual = "29-18"
    End Sub

    Private Sub Button114_Click(sender As Object, e As EventArgs) Handles Button114.Click
        Boton_Actual = "29-19"
    End Sub

    Private Sub Button109_Click(sender As Object, e As EventArgs) Handles Button109.Click
        Boton_Actual = "29-20"
    End Sub

    Private Sub Button110_Click(sender As Object, e As EventArgs) Handles Button110.Click
        Boton_Actual = "29-21"
    End Sub

    Private Sub Button97_Click(sender As Object, e As EventArgs) Handles Button97.Click
        Boton_Actual = "29-22"
    End Sub

    Private Sub Button95_Click(sender As Object, e As EventArgs) Handles Button95.Click
        Boton_Actual = "29-23"
    End Sub


#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class