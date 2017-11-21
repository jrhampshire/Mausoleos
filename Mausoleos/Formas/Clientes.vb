Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Configuration
Public Class Clientes
    Dim Sql_str As String = Nothing
    Public CxSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("Cadena")
    Public Cx As New SqlConnection(CxSettings.ConnectionString)

    Dim objApp As Excel.Application
    Dim objBook As Excel._Workbook
    Private Sub Agenda_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Carga_Todo()
    End Sub
    ''' <summary>
    ''' Aqui carga toda la informacion de los contactos en el Datagrid y la despliega en orden alfabetico
    ''' </summary>
    ''' <remarks></remarks>
    Sub Carga_Todo()
        Try

            Cx.Open()
            Dim Cmd As New SqlCommand
            Cmd.Connection = Cx
            Cmd.CommandText = "Select * from View_Listado_Clientes Order by Contrato"
            Cmd.CommandType = CommandType.Text
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_Todo_Click(sender As System.Object, e As System.EventArgs) Handles Button_Todo.Click
        Carga_Todo()
    End Sub
    ''' <summary>
    ''' Aqui carga toda la informacion de los contactos en el Datagrid y la despliega en orden alfabetico pero unicamente de la letra seleccionada
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Button_a_Click(sender As System.Object, e As System.EventArgs) Handles Button_a.Click
        Try

            Cx.Open()
            Dim Cmd As New SqlCommand
            Cmd.Connection = Cx
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select * from View_Listado_Clientes Where Nombre like 'a%' Order by Nombre"
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_b_Click(sender As System.Object, e As System.EventArgs) Handles Button_b.Click
        Try

            Cx.Open()
            Dim Cmd As New SqlCommand
            Cmd.Connection = Cx
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select * from View_Listado_Clientes Where Nombre like 'b%' Order by Nombre"
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_c_Click(sender As System.Object, e As System.EventArgs) Handles Button_c.Click
        Try

            Cx.Open()
            Dim Cmd As New SqlCommand
            Cmd.Connection = Cx
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select * from View_Listado_Clientes Where Nombre like 'c%' Order by Nombre"
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_d_Click(sender As System.Object, e As System.EventArgs) Handles Button_d.Click
        Try

            Cx.Open()
            Dim Cmd As New SqlCommand
            Cmd.Connection = Cx
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select * from View_Listado_Clientes Where Nombre like 'd%' Order by Nombre"
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_e_Click(sender As System.Object, e As System.EventArgs) Handles Button_e.Click
        Try

            Cx.Open()
            Dim Cmd As New SqlCommand
            Cmd.Connection = Cx
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select * from View_Listado_Clientes Where Nombre like 'e%' Order by Nombre"
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_f_Click(sender As System.Object, e As System.EventArgs) Handles Button_f.Click
        Try

            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select * from View_Listado_Clientes Where Nombre like 'f%' Order by Nombre"
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_g_Click(sender As System.Object, e As System.EventArgs) Handles Button_g.Click
        Try

            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select * from View_Listado_Clientes Where Nombre like 'g%' Order by Nombre"
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_h_Click(sender As System.Object, e As System.EventArgs) Handles Button_h.Click
        Try

            Cx.Open()
            Dim Cmd As New SqlCommand()
            Cmd.Connection = Cx
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "Select * from View_Listado_Clientes Where Nombre like 'h%' Order by Nombre"
            Dim DA As New SqlDataAdapter(Cmd)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_i_Click(sender As System.Object, e As System.EventArgs) Handles Button_i.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'i%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_j_Click(sender As System.Object, e As System.EventArgs) Handles Button_j.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'j%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_k_Click(sender As System.Object, e As System.EventArgs) Handles Button_k.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'k%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_l_Click(sender As System.Object, e As System.EventArgs) Handles Button_l.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'l%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_m_Click(sender As System.Object, e As System.EventArgs) Handles Button_m.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'm%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_n_Click(sender As System.Object, e As System.EventArgs) Handles Button_n.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'n%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_ñ_Click(sender As System.Object, e As System.EventArgs) Handles Button_ñ.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'ñ%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_o_Click(sender As System.Object, e As System.EventArgs) Handles Button_o.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'o%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_p_Click(sender As System.Object, e As System.EventArgs) Handles Button_p.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'p%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_q_Click(sender As System.Object, e As System.EventArgs) Handles Button_q.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'q%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_r_Click(sender As System.Object, e As System.EventArgs) Handles Button_r.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'r%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_s_Click(sender As System.Object, e As System.EventArgs) Handles Button_s.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 's%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_t_Click(sender As System.Object, e As System.EventArgs) Handles Button_t.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 't%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_u_Click(sender As System.Object, e As System.EventArgs) Handles Button_u.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'u%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_v_Click(sender As System.Object, e As System.EventArgs) Handles Button_v.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'v%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_w_Click(sender As System.Object, e As System.EventArgs) Handles Button_w.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'w%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_x_Click(sender As System.Object, e As System.EventArgs) Handles Button_x.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'x%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Button_y_Click(sender As System.Object, e As System.EventArgs) Handles Button_y.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'y%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
                Me.Txt_Busca.Text = ""
            End If
        End Try
    End Sub

    Private Sub Button_z_Click(sender As System.Object, e As System.EventArgs) Handles Button_z.Click
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Nombre like 'z%' Order by Nombre"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub



    ''' <summary>
    ''' Al dar doble click sobre una celda del datagrid se carga el formulario de Editar Contactos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellDoubleClick
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView.CurrentCellAddress.Y
        Try
            Id_Contrato = Me.DataGridView(columna, fila).Value
            If Id_Contrato = 0 Then
                MessageBox.Show("Debe seleccionar un Contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView.Focus()
                Exit Sub
            Else
                Dim Status As Boolean = Nothing
                Status = Me.DataGridView(7, fila).Value
                If Status = True Then
                    Dim frm As New Contratos_Cancelados
                    frm.ShowDialog()
                    Carga_Todo()
                Else
                    Dim frm As New Edita_Cliente
                    frm.ShowDialog()
                    Carga_Todo()
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' Aqui se borra el contrato que esta seleccionado
    ''' </summary>
    ''' <remarks></remarks>
    Sub Borra_Contacto()
        Dim result As DialogResult = MessageBox.Show(Me, "Esta a punto de cancelar un Contrato, ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Dim columna As Integer, fila As Integer
            'Dim ID As Integer = 0
            Dim Id_Contrato As Integer = 0
            columna = 0
            fila = Me.DataGridView.CurrentCellAddress.Y
            Dim Cmd As SqlCommand = Cx.CreateCommand
            Dim transaction As SqlTransaction = Nothing
            Try
                Id_Contrato = Me.DataGridView(columna, fila).Value
                If Id_Contrato = 0 Then
                    MessageBox.Show("Debe seleccionar un Contrato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DataGridView.Focus()
                    Exit Sub
                Else
                    Sql_str = "Update Contratos set Cancelado = 'True' where id_Contrato = @ID"
                    Cx.Open()
                    transaction = Cx.BeginTransaction("Borrado_Contratos")
                    Cmd.Connection = Cx
                    Cmd.Transaction = transaction
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = Sql_str
                    Dim Param As SqlParameter = Cmd.Parameters.AddWithValue("@ID", Id_Contrato)
                    Cmd.ExecuteNonQuery()
                    transaction.Commit()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Try
                    transaction.Rollback()

                Catch ex2 As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try
            Finally
                If Cx.State = ConnectionState.Open Then
                    Cx.Close()
                End If
                Carga_Todo()
            End Try
        End If
    End Sub
    ''' <summary>
    ''' al presionar la tecla Supr manda llamar la funcion de borrado
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridView.KeyDown
        If e.KeyCode = Keys.Delete Then
            Borra_Contacto()
        End If
    End Sub




    'Private Sub ImprimirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
    '    Dim columna As Integer, fila As Integer
    '    columna = 0
    '    fila = Me.DataGridView.CurrentCellAddress.Y
    '    Id_Contrato = Me.DataGridView(columna, fila).Value
    '    Dim frm As New Loader
    '    frm.Show()
    'End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim Frm_Contrato As New NuevoCliente
        Frm_Contrato.ShowDialog()
        Carga_Todo()

    End Sub

    ''' <summary>
    ''' Aqui exporta toda el listado que se encuentra en el datagrid a excel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dim objBooks As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range
        Dim DireccionImagenLogo As String = Nothing
        Try
            Cx.Open()
            Sql_str = "Select * from Empresa"
            Dim Cmd As New SqlCommand(Sql_str, Cx)
            Cmd.CommandType = CommandType.Text
            Dim DR As SqlDataReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If DR.HasRows Then
                While DR.Read
                    DireccionImagenLogo = DR.Item("Logotipo")
                End While
            End If
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try


        ' Crea una nueva Instancia o Excel y un nuevo workbook.
        objApp = New Excel.Application()
        objBooks = objApp.Workbooks
        objBook = objBooks.Add
        objSheets = objBook.Worksheets
        objSheet = objSheets(1)
        If File.Exists(DireccionImagenLogo) Then
            objSheet.Shapes.AddPicture(DireccionImagenLogo, CType(False, Microsoft.Office.Core.MsoTriState), CType(True, Microsoft.Office.Core.MsoTriState), 5, 5, 130, 55)
        End If
        objSheet.Range("A1").EntireRow.RowHeight = 65
        objSheet.Cells(1, 8).Formula = Now
        objSheet.Range("A7").VerticalAlignment = Excel.XlVAlign.xlVAlignTop
        objSheet.Range("A7").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        objSheet.Range("A2").Font.Bold = True
        objSheet.Range("A2").Font.Size = 18
        objSheet.Range("A2").Interior.ColorIndex = 16
        objSheet.Range("A2").Value = "Contratos"
        objSheet.Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        objSheet.Range("A2").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        objSheet.Range("A2:H3").Merge()
        objSheet.Range("A2:H3").BorderAround(, Excel.XlBorderWeight.xlMedium,
                Excel.XlColorIndex.xlColorIndexAutomatic, )
        objSheet.Cells(5, 1).Formula = "Contrato"
        objSheet.Cells(5, 2).Formula = "Nombre del Titular"
        objSheet.Cells(5, 3).Formula = "Fecha de Contratacion"
        objSheet.Cells(5, 4).Formula = "Piso"
        objSheet.Cells(5, 5).Formula = "Nicho"
        objSheet.Cells(5, 6).Formula = "Teléfono"
        objSheet.Cells(5, 7).Formula = "Correo"
        objSheet.Cells(5, 8).Formula = "Cancelado"
        objSheet.Range("A5:H5").Font.Bold = True
        objSheet.Range("A5:H5").Interior.ColorIndex = 16
        objSheet.Range("A5:H5").Font.Size = 11
        objSheet.Range("A5:H5").Borders().Color = 0
        objSheet.Range("A5:H5").Borders().LineStyle = Excel.XlLineStyle.xlContinuous
        objSheet.Range("A5:H5").Borders().Weight = 2
        objSheet.Range("A5:H5").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Dim R As String = "A5:A" + CInt(DataGridView.RowCount + 5).ToString
        objSheet.Range(R).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        objSheet.Range("A1").EntireColumn.ColumnWidth = 10
        objSheet.Range("B1").EntireColumn.ColumnWidth = 50
        objSheet.Range("C1").EntireColumn.ColumnWidth = 25
        objSheet.Range("D1").EntireColumn.ColumnWidth = 13
        objSheet.Range("E1").EntireColumn.ColumnWidth = 10
        objSheet.Range("F1").EntireColumn.ColumnWidth = 20
        objSheet.Range("G1").EntireColumn.ColumnWidth = 40
        objSheet.Range("H1").EntireColumn.ColumnWidth = 15

        'Aqui obtengo el tamaño del datagrid y lo copio al excel
        Dim DGRows As Integer = Me.DataGridView.RowCount
        Dim DGCols As Integer = Me.DataGridView.ColumnCount
        range = objSheet.Range("A7", Reflection.Missing.Value)
        range = range.Resize(DGRows, DGCols)
        range.Borders().Color = 0
        range.Borders().LineStyle = Excel.XlLineStyle.xlContinuous
        range.Borders().Weight = 2
        range.Font.Size = 9
        'Crea un array
        Dim saRet(DGRows, DGCols) As String
        'llena el array.
        Dim iRow As Integer
        Dim iCol As Integer
        For iRow = 0 To DataGridView.RowCount - 1
            For iCol = 0 To DataGridView.ColumnCount - 1
                saRet(iRow, iCol) = DataGridView.Rows(iRow).Cells(iCol).Value.ToString
            Next iCol
        Next iRow
        'establece el valor del rango del array.
        range.Value = saRet
        'Regresa el control del Excel al usuario
        objApp.Visible = True
        objApp.UserControl = True
        'Limpia
        range = Nothing
        objSheet = Nothing
        objSheets = Nothing
        objBooks = Nothing
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Borra_Contacto()
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' al presionar este boton se hace un filtrado dependiendo de la busqueda realizada
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        Busca()

    End Sub

    Sub Busca()
        Dim Busqueda As String = Me.Txt_Busca.Text
        If Busqueda = "" Then
            MessageBox.Show("Introduzca su busqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Txt_Busca.Focus()
            Exit Sub
        End If
        Try
            Sql_str = "Select * from View_Listado_Clientes Where Contrato in  (Select ID_Contrato from  Vista_Info where Info like '%" & Busqueda & "%')"
            Cx.Open()
            Dim DA As New SqlDataAdapter(Sql_str, Cx)
            Dim DS As New DataSet
            DA.Fill(DS, "Tabla")
            Me.DataGridView.DataSource = DS.Tables("Tabla")
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error: " & ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If Cx.State = ConnectionState.Open Then
                Cx.Close()
            End If
        End Try
    End Sub

    Private Sub Txt_Busca_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Busca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Busca()
        End If
    End Sub


    Private Sub ToolStripButton_Editar_Click(sender As Object, e As EventArgs) Handles ToolStripButton_Editar.Click
        Dim columna As Integer, fila As Integer
        columna = 0
        fila = Me.DataGridView.CurrentCellAddress.Y
        Try
            Id_Contrato = Me.DataGridView(columna, fila).Value
            If Id_Contrato = 0 Then
                MessageBox.Show("Debe seleccionar un Contrato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DataGridView.Focus()
                Exit Sub
            Else
                Dim Status As Boolean = Nothing
                Status = Me.DataGridView(7, fila).Value
                If Status = True Then
                    MessageBox.Show("Este contrato no se puede editar ya que esta cancelado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    Dim frm As New Edita_Cliente
                    frm.ShowDialog()
                    Carga_Todo()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Debe seleccionar un Contrato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DataGridView.Focus()
            Exit Sub
        End Try
    End Sub

    Private Sub DataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellContentClick

    End Sub
End Class