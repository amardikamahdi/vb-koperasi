Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class penjualanForm

    Private Sub penjualanForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call connection()
        TextBox1.Text = 0
        TextBox4.Text = 0
        TextBox5.Text = 0
        loadCustomers()
        loadProducts()
        Button3.Enabled = False
    End Sub

    Private Sub loadCustomers()
        Dim da As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim rd As MySqlDataReader

        cmd.Connection = conn
        cmd.CommandText = "SELECT name FROM customers"
        rd = cmd.ExecuteReader()
        ComboBox1.Items.Clear()
        While (rd.Read())
            ComboBox1.Items.Add(rd.GetString(0))
        End While
        rd.Close()
    End Sub

    Private Sub loadProducts()
        Dim da As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim rd As MySqlDataReader

        cmd.Connection = conn
        cmd.CommandText = "SELECT * FROM products"

        rd = cmd.ExecuteReader()
        ListBox1.Items.Clear()
        While (rd.Read())
            ListBox1.Items.Add(rd.GetString(1) + " - Rp. " + rd.GetString(3))
        End While
        rd.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer

        For i = 1 To ListBox1.SelectedItems.Count
            ListBox2.Items.Add(ListBox1.SelectedItems.Item(i - 1))
            TextBox1.Text = TextBox1.Text + Integer.Parse(Regex.Replace(ListBox1.SelectedItems.Item(i - 1), "[^\d]", ""))
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim da As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim rd As MySqlDataReader

        cmd.Connection = conn
        cmd.CommandText = "SELECT * FROM customers WHERE name='" & ComboBox1.Text & "'"

        rd = cmd.ExecuteReader
        While (rd.Read())
            TextBox2.Text = rd.GetString(2)
            TextBox3.Text = rd.GetString(3)
        End While
        rd.Close()
    End Sub

    Private Sub refreshForm()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        If ComboBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            TextBox4.Text = 0
            TextBox5.Text = 0
            Button3.Enabled = False
        Else
            If Integer.Parse(TextBox4.Text) < Integer.Parse(TextBox1.Text) Then
                Button3.Enabled = False
                TextBox5.Text = 0
            ElseIf Integer.Parse(TextBox4.Text) >= Integer.Parse(TextBox1.Text) Then
                Button3.Visible = True
                Button3.Enabled = True
                TextBox5.Text = Integer.Parse(TextBox4.Text) - Integer.Parse(TextBox1.Text)
            Else
                TextBox5.Text = 0
                Button3.Enabled = False
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Text = "0"
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = "0"
        TextBox5.Text = "0"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim username As String
        Dim total, pay, change As Integer
        Dim cmd As New MySqlCommand

        username = ComboBox1.Text
        total = TextBox1.Text
        pay = TextBox4.Text
        change = TextBox5.Text

        str = "INSERT INTO checkouts VALUES('NULL','" & total & "', '" & pay & "', '" & change & "', '" & username & "'); SELECT LAST_INSERT_ID()"
        cmd.Connection = conn
        cmd.CommandText = str
        Dim cmd_checkout As Integer = CInt(cmd.ExecuteScalar())
        For i = 1 To ListBox2.Items.Count
            Dim product = ListBox2.Items.Item(i - 1)
            Dim productName = product.Substring(0, product.IndexOf("-"))
            Dim checkoutDetailsInsert = "INSERT INTO checkout_details VALUES('NULL', '" & cmd_checkout & "', '" & productName & "')"
            cmd.Connection = conn
            cmd.CommandText = checkoutDetailsInsert
            cmd.ExecuteNonQuery()
        Next
        MessageBox.Show("Data Belanja berhasil")
    End Sub
End Class