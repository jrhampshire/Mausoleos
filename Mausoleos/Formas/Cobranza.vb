Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.IO
Imports System.Globalization

Public Class Cobranza

#Region "Variables"
    Dim SQL_Str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)
    Dim Id_Detalle_PlanPagos As String = Nothing
    Dim Concepto As String = Nothing
    Dim Metodo_Pago As String = Nothing
    Dim Cuenta_Pago As String = Nothing
#End Region

    Private Sub Button_SeleccionarPagos_Click(sender As Object, e As EventArgs) Handles Button_SeleccionarPagos.Click
        Dim Frm As New PagosPendientes
        Frm.ShowDialog()
        Carga_Pagos()
        Calcula_Totales()
    End Sub

    Sub Carga_Datos_Cliente()
        SQL_Str = "SELECT  Contratos.Id_Contrato, Receptor.nombre, Receptor.rfc," &
            " Plantas.Planta, Ubicaciones.Ubicacion + '-' + rtrim(ltrim(cast(Gavetas.Modulo as Char(2)))) + '-' + rtrim(ltrim(cast(Gavetas.Columna as Char(2)))) + '-' + Gavetas.Fila AS Ubicacion, (Domicilio.Calle + ' No. ' + Domicilio.noExterior + ' ' + " &
            " Domicilio.noInterior) as Direccion, (Domicilio.colonia + ' C.P. ' + Domicilio.codigoPostal) as Colonia, Localidad.Localidad" &
            " FROM Personas INNER JOIN" &
            " Domicilio INNER JOIN" &
            " Receptor ON Domicilio.ID_Domicilio = Receptor.Id_Domicilio INNER JOIN" &
            " Localidad ON Domicilio.Id_localidad = Localidad.ID_Localidad ON Personas.Id_Receptor = Receptor.ID_Receptor INNER JOIN" &
            " Contratos INNER JOIN" &
            " Gavetas ON Contratos.Id_Gaveta = Gavetas.Id_Gaveta INNER JOIN" &
            " Plantas ON Gavetas.Id_Planta = Plantas.Id_Planta INNER JOIN" &
            " Ubicaciones ON Gavetas.Id_Ubicacion = Ubicaciones.Id_Ubicacion ON Personas.ID_Personas = Contratos.Id_Cliente" &
            " WHERE (Contratos.Id_Contrato = @Id_Contrato);" &
            " Select Municipio from Municipio where Id_Municipio = (Select Id_MUnicipio from Localidad where Id_Localidad = (Select Id_Localidad from Domicilio where Id_Domicilio = (" &
            " Select Id_Domicilio from Receptor where Id_Receptor = (Select Id_Receptor from Personas where Id_Personas = (Select Id_Cliente from Contratos Where Id_Contrato =@Id_Contrato)))))"

        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    Me.Label_NombreCte.Text = DR.Item(1)
                    Me.Label_RFC.Text = DR.Item(2)
                    Dim Piso As String = DR.Item(3)
                    If Piso = "Planta Baja" Then
                        Piso = "PB"
                    End If
                    Me.Label_Ubicacion.Text = Piso & "-" & DR.Item(4)
                    Me.Label_Direccion.Text = DR.Item(5)
                    Me.Label_Colonia.Text = DR.Item(6)
                    Me.Label_Localidad.Text = DR.Item(7)
                End While
            End If
            DR.NextResult()
            If DR.HasRows Then
                While DR.Read
                    Me.Label_Localidad.Text = Label_Localidad.Text & ", " & DR.Item(0)
                End While
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Sub Calcula_Totales()
        Dim Subtotal As Decimal = 0
        With Me.DataGridView_EstadoCuenta
            Dim Registros As Integer = .RowCount
            For i = 0 To Registros - 1
                Dim columna As Integer, fila As Integer
                columna = 4
                fila = i
                Subtotal = Subtotal + Me.DataGridView_EstadoCuenta(3, fila).Value
            Next
        End With
        Me.Label_Gran_Subtotal.Text = FormatNumber(Subtotal, 2)
        'Me.Label_Gran_Total.Text = FormatNumber(CDec(Me.Label_Gran_Subtotal.Text) + FormatNumber(CDec (Subtotal * (clProducto.Tasa - 1), 2))
        Me.Label_Gran_Total.Text = FormatNumber(CDec(Me.Label_Gran_Subtotal.Text) + FormatNumber(Subtotal), 2)
    End Sub

    Sub Carga_Pagos()
        Try
            Dim Total_Recibos As Integer = ID_Recibos.Count
            If Total_Recibos > 1 Then
                Id_Detalle_PlanPagos = String.Join(", ", ID_Recibos.ToArray())
            ElseIf Total_Recibos = 1 Then
                Id_Detalle_PlanPagos = ID_Recibos(0)
            Else
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try


        SQL_Str = "Select Id_Detalle_PlanPagos as ID, Fecha_Vencimiento, Detalle, Importe" &
   " From Detalle_PlanPagos Where Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato)" &
   " AND Id_Detalle_PlanPagos in (" & Id_Detalle_PlanPagos & ")"


        'SQL_Str = "Select Id_Detalle_PlanPagos as ID, Fecha_Vencimiento, Detalle, Importe" & _
        '   " From Detalle_PlanPagos Where Id_PlanPagos = (Select Id_PlanPagos from PlanPagos where Id_Contrato = @Id_Contrato)" & _
        '   " AND Id_Detalle_PlanPagos in (@Id_Detalle_PlanPagos)"
        Try
            Cx.Open()
            Dim Cmd As New SqlCommand(SQL_Str, Cx)
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@Id_Contrato", Id_Contrato)
            Cmd.Parameters.AddWithValue("@Id_Detalle_PlanPagos", Id_Detalle_PlanPagos)
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            With DataGridView_EstadoCuenta
                .DataSource = DS.Tables("Tabla")
            End With
            Dim Fecha_Temp As Date
            Fecha_Temp = Me.DataGridView_EstadoCuenta(1, 0).Value()
            Me.TextBox_Fecha_Vencimiento.Text = Fecha_Temp.ToString("dd-MM-yyyy", CultureInfo.CreateSpecificCulture("es-MX"))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_Cancelar_Click(sender As Object, e As EventArgs) Handles Button_Cancelar.Click
        Me.Close()
    End Sub

    Private ImpresoraActual As New Printing.PrinterSettings
    Private Lector As StreamReader
    Private Sub Button_Aceptar_Click(sender As Object, e As EventArgs) Handles Button_Aceptar.Click
        'Primero Selecciona la impresora
        Try
            Metodo_Pago = Me.ComboBox_Metodo_Pago.Text
        Catch ex As Exception
            MessageBox.Show("Este dato es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.ComboBox_Metodo_Pago.Focus()
            Exit Sub
        End Try
        Dim _Imprime_Doc As Boolean = False
        If CheckBox_Imprime.Checked = True Then
            _Imprime_Doc = True
        End If
        If _Imprime_Doc = True Then
            Try
                PrintDialog1.PrinterSettings = ImpresoraActual
                If PrintDialog1.ShowDialog = DialogResult.OK Then
                    ImpresoraActual = PrintDialog1.PrinterSettings
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
            End Try

            'Asigno el tamaño de la pagina
            Dim TamañoPersonal As Printing.PaperSize
            Dim Ancho As Short
            Dim Alto As Short
            Try
                '1 mm = 39.37 milesimas de pulgada, entonces el ancho de una hoja de 216 mm = 850.39 milesimas de pulgada
                Ancho = 850.39
                Alto = 429.3

                TamañoPersonal = New Printing.PaperSize("Recibos", Ancho, Alto)

                ' Asignamos la impresora seleccionada
                PrintDocument1.PrinterSettings = ImpresoraActual
                ' Asignamos el tamaño personalizado de papel
                PrintDocument1.DefaultPageSettings.PaperSize = TamañoPersonal
                'MessageBox.Show("Nuevo tamaño asignado a documento")
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
            End Try

            PrintDocument1.Print()
        Else
            'Aqui verifica cuantas mensualidades se van a pagar para armar el concepto
            If Me.DataGridView_EstadoCuenta.RowCount = 1 Then
                Concepto = Concepto & Me.DataGridView_EstadoCuenta(2, 0).Value.ToString

            ElseIf Me.DataGridView_EstadoCuenta.RowCount > 1 Then
                Dim Registros As Integer = Me.DataGridView_EstadoCuenta.RowCount
                For i = 0 To Registros - 1
                    Dim columna As Integer, fila As Integer
                    columna = 4
                    fila = i
                    If i = Registros - 1 Then
                        Concepto = Concepto & Me.DataGridView_EstadoCuenta(2, fila).Value.ToString

                    ElseIf i = 0 Then
                        Concepto = Concepto & Me.DataGridView_EstadoCuenta(2, fila).Value.ToString & ", "
                    Else
                        Concepto = Concepto & Me.DataGridView_EstadoCuenta(2, fila).Value.ToString & ", "
                    End If
                Next
            Else

            End If
        End If
        Guarda_Datos()
        Close()
    End Sub
    Sub Guarda_Datos()
        Dim ID() = Id_Detalle_PlanPagos.Split(",")
        Dim Total_Guarda As Integer = ID.Count
        Dim Id_Recibo As Integer

        Cuenta_Pago = Trim(TextBox_Cuenta.Text)
        If IsDBNull(Cuenta_Pago) Then
            Cuenta_Pago = ""
        End If

        Try
                Cx.Open()
                SQL_Str = "Alta_Recibos"
                Dim Cmd As New SqlCommand(SQL_Str, Cx)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@Descripcion", Concepto)
                Cmd.Parameters.AddWithValue("@Estado_Actual", "Recibo Generado")
                Cmd.Parameters.AddWithValue("@Metodo_Pago", Metodo_Pago)
                Cmd.Parameters.AddWithValue("@Cuenta_Pago", Cuenta_Pago)
                Cmd.Parameters.Add("@ID", SqlDbType.Int)
                Cmd.Parameters("@ID").Direction = ParameterDirection.Output
                Cmd.ExecuteNonQuery()
                Id_Recibo = Cmd.Parameters("@ID").Value.ToString()
                GuardarPDF = True
            Catch ex As SqlException
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
            End Try
            For i = 0 To Total_Guarda - 1
                Try
                    Cx.Open()
                    SQL_Str = "Alta_Detalle_Recibos"
                    Dim Cmd As New SqlCommand(SQL_Str, Cx)
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.AddWithValue("@Id_Detalle_PlanPagos", ID(i))
                    Cmd.Parameters.AddWithValue("@Id_Recibo", Id_Recibo)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK)
                Finally
                    If Cx.State = ConnectionState.Open Then
                        Cx.Close()
                    End If
                End Try
            Next

    End Sub
    Private Sub Button_BuscaContrato_Click(sender As Object, e As EventArgs) Handles Button_BuscaContrato.Click
        Dim frm As New Listado_Contratos
        frm.ShowDialog()
        TextBox_Contrato.Text = Id_Contrato
        If Trim(TextBox_Contrato.Text) = "" Then
            Exit Sub
        Else
            Carga_Datos_Cliente()
        End If
    End Sub
    Private Sub TextBox_Contrato_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_Contrato.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Trim(TextBox_Contrato.Text) = "" Then
                Exit Sub
            Else
                Id_Contrato = Trim(TextBox_Contrato.Text)
                Carga_Datos_Cliente()
            End If
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim AjusteX As Integer = 0
        Dim AjusteY As Integer = 0
        Dim ValorConversion As Double = 34.5
        Dim ValorConversion2 As Double = 37.7
        Dim Concepto2 As String = Nothing
        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left
        ' La fuente a usar
        Dim prFont As New Font("Arial", 8, FontStyle.Regular)
        ' la posición superior
        Dim yPos As Single = prFont.GetHeight(e.Graphics)
        Dim Fecha As DateTime = Now.ToLongDateString
        ' imprimimos la cadena
        e.Graphics.DrawString(Me.Label_NombreCte.Text, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + (4.6 * ValorConversion))
        e.Graphics.DrawString(Me.Label_RFC.Text, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + (5.5 * ValorConversion))
        e.Graphics.DrawString(Me.Label_Direccion.Text, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + (6.8 * ValorConversion))
        e.Graphics.DrawString(Me.Label_Colonia.Text, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + ((6.8 * ValorConversion) + 15))
        e.Graphics.DrawString(Me.Label_Localidad.Text, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + ((6.8 * ValorConversion) + 30))
        Dim Fecha2 As DateTime = Nothing
        Dim Fecha2Txt As String = Nothing
        'Aqui verifica cuantas mensualidades se van a pagar para armar el concepto
        If Me.DataGridView_EstadoCuenta.RowCount = 1 Then
            Concepto = Concepto & Me.DataGridView_EstadoCuenta(2, 0).Value.ToString
            e.Graphics.DrawString("Pago mensualidad " & Concepto, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + (8.6 * ValorConversion))
            Concepto2 = Concepto
            Fecha2 = Me.DataGridView_EstadoCuenta(1, 0).Value
            Fecha2 = Fecha2.ToShortDateString
            Fecha2Txt = Fecha2.ToString("d", CultureInfo.CreateSpecificCulture("es-MX"))
        ElseIf Me.DataGridView_EstadoCuenta.RowCount > 1 Then
            Dim Registros As Integer = Me.DataGridView_EstadoCuenta.RowCount
            For i = 0 To Registros - 1
                Dim columna As Integer, fila As Integer
                columna = 4
                fila = i
                If i = Registros - 1 Then
                    Concepto = Concepto & Me.DataGridView_EstadoCuenta(2, fila).Value.ToString
                    Fecha2 = Me.DataGridView_EstadoCuenta(1, fila).Value
                    Fecha2 = Fecha2.ToShortDateString
                    Fecha2Txt = Fecha2.ToString("d", CultureInfo.CreateSpecificCulture("es-MX"))
                ElseIf i = 0 Then
                    Concepto = Concepto & Me.DataGridView_EstadoCuenta(2, fila).Value.ToString & ", "
                Else
                    Concepto = Concepto & Me.DataGridView_EstadoCuenta(2, fila).Value.ToString & ", "
                End If
            Next
            e.Graphics.DrawString("Pago " & Concepto, prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + (8.6 * ValorConversion))
        Else

        End If

        Dim _Gran_Total As Double = 0
        _Gran_Total = Sumar("Importe", Me.DataGridView_EstadoCuenta)

        e.Graphics.DrawString("San Luis Potosí, S.L.P.  " & Fecha.ToString("dd \de MMMM \de yyyy", CultureInfo.CreateSpecificCulture("es-MX")), prFont, Brushes.Black, AjusteX + (4 * ValorConversion), AjusteY + (9.7 * ValorConversion))
        e.Graphics.DrawString(Me.TextBox_Contrato.Text, prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (4.1 * ValorConversion))
        'e.Graphics.DrawString(Me.Label_Ubicacion.Text, prFont, Brushes.Black, AjusteX + (18.5 * (ValorConversion2 - 0.3)), AjusteY + (4.85 * ValorConversion))
        e.Graphics.DrawString(Me.Label_Ubicacion.Text, prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (4.85 * ValorConversion))
        'e.Graphics.DrawString(Me.DataGridView_EstadoCuenta(2, 0).Value, prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (5.55 * ValorConversion))
        e.Graphics.DrawString(Concepto, prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (5.55 * ValorConversion))
        'e.Graphics.DrawString(Fecha2.ToString("d", CultureInfo.CreateSpecificCulture("es-MX")), prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (6.4 * ValorConversion))
        e.Graphics.DrawString(Trim(Me.TextBox_Fecha_Vencimiento.Text), prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (6.4 * ValorConversion))
        e.Graphics.DrawString(FormatNumber(_Gran_Total, 2, , , Microsoft.VisualBasic.TriState.True), prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (7 * ValorConversion))
        'e.Graphics.DrawString(FormatNumber(Me.DataGridView_EstadoCuenta.Columns(3, 0).Value, 2, , , Microsoft.VisualBasic.TriState.True), prFont, Brushes.Black, AjusteX + (18.5 * ValorConversion2), AjusteY + (7 * ValorConversion))
        Dim CantidadconLetras As String = NumeroATexto(_Gran_Total)
        'Dim CantidadconLetras As String = NumeroATexto(Me.DataGridView_EstadoCuenta(3, 0).Value)
        CantidadconLetras = StrConv(CantidadconLetras, VbStrConv.Uppercase)
        Dim Largo_CantidadLetras As Integer = CantidadconLetras.Length
        If Largo_CantidadLetras > 55 Then
            Dim Cadena1 As String = Mid(CantidadconLetras, 1, 55)
            Dim Cadena2 As String = Mid(CantidadconLetras, 56, Largo_CantidadLetras)
            e.Graphics.DrawString(Cadena1 + " -", prFont, Brushes.Black, AjusteX + (14.3 * ValorConversion), AjusteY + (8.2 * ValorConversion))
            e.Graphics.DrawString(Cadena2, prFont, Brushes.Black, AjusteX + (15.3 * ValorConversion), AjusteY + ((8.2 * ValorConversion) + 15))
        Else
            e.Graphics.DrawString(CantidadconLetras, prFont, Brushes.Black, AjusteX + (14.3 * ValorConversion), AjusteY + (8.2 * ValorConversion))
        End If

        ' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False
    End Sub
    Private Function Sumar(
       ByVal nombre_Columna As String,
       ByVal Dgv As DataGridView) As Double

        Dim total As Double = 0

        ' recorrer las filas y obtener los items de la columna indicada en "nombre_Columna"
        Try
            For i As Integer = 0 To Dgv.RowCount - 1
                total = total + CDbl(Dgv.Item(nombre_Columna.ToLower, i).Value)
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        ' retornar el valor
        Return total

    End Function
    Public Function CortarCadenaPorPalabras(CadenaEntrada As String, NumCaracteresEnParrafo As Integer) As IList(Of String)

        Dim retorno As List(Of String) = New List(Of String)    'lista con los parrafos
        Dim palabra As String
        Dim contenedor As String

        If CadenaEntrada.Length = 0 Then
            'si la cadena de entrada esta vacia devolvemos una coleccion vacia.
            Return retorno
        ElseIf CadenaEntrada.Length <= NumCaracteresEnParrafo Then
            'si la cadena tiene [NumCaracteresEnParrafo] caracteres o menos, devolvemos sólo un elemento con la cadena entera
            retorno.Add(CadenaEntrada)
            Return retorno
        End If

        'contenedor para almacenar las palabras mientras que la longitud del párrafo sea menor que [NumCaracteresEnParrafo] 
        contenedor = ""
        For Each palabra In CadenaEntrada.Split(" "c)

            'si la palabra tiene más de [NumCaracteresEnParrafo] caracteres seguidos, se trozea
            If palabra.Length >= NumCaracteresEnParrafo Then
                If contenedor.Length > 0 Then retorno.Add(contenedor)
                Do
                    Dim trozo As String = palabra.Substring(0, NumCaracteresEnParrafo - 1)
                    retorno.Add(trozo)
                    palabra = palabra.Remove(0, NumCaracteresEnParrafo - 1)
                Loop While palabra.Length >= NumCaracteresEnParrafo
            End If

            If palabra.Length > 0 Then
                If contenedor.Length + palabra.Length + 1 > NumCaracteresEnParrafo Then
                    retorno.Add(contenedor)
                    contenedor = palabra
                Else
                    contenedor = contenedor & " " & palabra
                End If
            End If
        Next
        If contenedor.Length > 0 Then retorno.Add(contenedor)

        Return retorno
    End Function
#Region "Numeros a Letras 2"
    Public Function NumeroATexto(ByVal d As Double) As String
        Dim parteEntera As Double = Math.Truncate(d)
        Dim parteDecimal As Double = Math.Truncate((d - parteEntera) * 100)
        If (parteDecimal > 0) Then
            Return Num2Text(parteEntera) + " Pesos " + CInt(parteDecimal).ToString + "/100 M.N."
        Else
            Return Num2Text(parteEntera) + " Pesos 00/100 M.N."
        End If

    End Function
    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function








#End Region



End Class