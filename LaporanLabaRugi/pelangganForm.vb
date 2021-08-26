Imports MySql.Data.MySqlClient

Public Class pelangganForm

    Private Sub pelangganForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call connection()
        RefreshForm()
    End Sub

    Private Sub loadComboValue()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Laki - Laki")
        ComboBox1.Items.Add("Perempuan")
    End Sub

    Private Sub loadTable()
        Dim da As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim productData As New DataTable

        cmd.Connection = conn
        cmd.CommandText = "SELECT * FROM customers"

        da.SelectCommand = cmd
        da.Fill(productData)
        With DataGridView1
            .DataSource = productData
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True

            .Columns(0).HeaderText = "ID Pelanggan"
            .Columns(1).HeaderText = "Nama Pelanggan"
            .Columns(2).HeaderText = "Alamat Pelanggan"
            .Columns(3).HeaderText = "Jenis Kelamin Pelanggan"
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        RefreshForm()
    End Sub

    Private Sub RefreshForm()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
        loadTable()
        loadComboValue()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim name, address, gender As String
        Dim cmd As New MySqlCommand

        name = TextBox2.Text
        address = TextBox3.Text
        gender = ComboBox1.Text

        str = "INSERT INTO customers VALUES('NULL','" & name & "', '" & address & "', '" & gender & "')"
        cmd.Connection = conn
        cmd.CommandText = str
        cmd.ExecuteNonQuery()
        MessageBox.Show("Data Pelanggan berhasil tersimpan!")
        RefreshForm()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim name, address, gender As String
        Dim id As Integer
        Dim cmd As New MySqlCommand

        id = TextBox1.Text
        name = TextBox2.Text
        address = TextBox3.Text
        gender = ComboBox1.Text

        str = "UPDATE customers SET name='" & name & "', address='" & address & "', gender='" & gender & "' WHERE id='" & id & "'"
        cmd.Connection = conn
        cmd.CommandText = str
        cmd.ExecuteNonQuery()
        MessageBox.Show("Data Pelanggan berhasil di update!")
        RefreshForm()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim id As Integer
        Dim cmd As New MySqlCommand

        id = TextBox1.Text
        str = "DELETE FROM customers WHERE id='" & id & "'"
        cmd.Connection = conn
        cmd.CommandText = str
        cmd.ExecuteNonQuery()
        MessageBox.Show("Data Pelanggan berhasil dihapus!")
        RefreshForm()
    End Sub
End Class