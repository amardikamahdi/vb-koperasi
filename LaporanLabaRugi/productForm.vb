Imports MySql.Data.MySqlClient

Public Class productForm

    Private Sub productForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call connection()
        RefreshForm()
    End Sub

    Private Sub loadComboValue()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Kecantikan")
        ComboBox1.Items.Add("Sparepart")
    End Sub

    Private Sub loadTable()
        Dim da As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim productData As New DataTable

        cmd.Connection = conn
        cmd.CommandText = "SELECT * FROM products"

        da.SelectCommand = cmd
        da.Fill(productData)
        With DataGridView1
            .DataSource = productData
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True

            .Columns(0).HeaderText = "ID Produk"
            .Columns(1).HeaderText = "Nama Produk"
            .Columns(2).HeaderText = "Harga Awal Produk"
            .Columns(3).HeaderText = "Harga Jual Produk"
            .Columns(4).HeaderText = "Kategori Produk"
            .Columns(5).HeaderText = "Stok Produk"
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
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
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
        loadTable()
        loadComboValue()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim name, category As String
        Dim first_price, sell_price, stock As Integer
        Dim cmd As New MySqlCommand

        name = TextBox2.Text
        category = ComboBox1.Text
        first_price = TextBox3.Text
        sell_price = TextBox5.Text
        stock = TextBox4.Text

        str = "INSERT INTO products VALUES('NULL','" & name & "', '" & first_price & "', '" & sell_price & "', '" & category & "','" & stock & "')"
        cmd.Connection = conn
        cmd.CommandText = str
        cmd.ExecuteNonQuery()
        MessageBox.Show("Data Produk berhasil tersimpan!")
        RefreshForm()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim name, category As String
        Dim id, first_price, sell_price, stock As Integer
        Dim cmd As New MySqlCommand

        id = TextBox1.Text
        name = TextBox2.Text
        category = ComboBox1.Text
        first_price = TextBox3.Text
        sell_price = TextBox5.Text
        stock = TextBox4.Text

        str = "UPDATE products SET name='" & name & "', cost_price='" & first_price & "', sell_price='" & sell_price & "', category='" & category & "', stock='" & stock & "' WHERE id='" & id & "'"
        cmd.Connection = conn
        cmd.CommandText = str
        cmd.ExecuteNonQuery()
        MessageBox.Show("Data Produk berhasil di update!")
        RefreshForm()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim id As Integer
        Dim cmd As New MySqlCommand

        id = TextBox1.Text
        str = "DELETE FROM products WHERE id='" & id & "'"
        cmd.Connection = conn
        cmd.CommandText = str
        cmd.ExecuteNonQuery()
        MessageBox.Show("Data Produk berhasil dihapus!")
        RefreshForm()
    End Sub
End Class