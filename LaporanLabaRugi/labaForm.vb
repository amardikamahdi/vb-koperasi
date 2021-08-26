Imports MySql.Data.MySqlClient

Public Class labaForm

    Private Sub labaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call connection()
        loadTable()
    End Sub

    Private Sub loadTable()
        Dim str As String
        Dim cmd As New MySqlCommand
        Dim da As New MySqlDataAdapter
        Dim checkoutDetailsData As New DataTable

        str = "SELECT checkouts.id, checkouts.total, checkouts.pay, checkouts.change, COUNT(*) as checkoutItems, SUM(products.cost_price), SUM(products.sell_price) FROM checkouts INNER JOIN checkout_details ON checkouts.id = checkout_details.checkout_id INNER JOIN products ON checkout_details.product_name = products.name GROUP BY checkouts.id"
        cmd.Connection = conn
        cmd.CommandText = str
        da.SelectCommand = cmd
        da.Fill(checkoutDetailsData)
        With DataGridView1
            .DataSource = checkoutDetailsData
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
        End With
    End Sub
End Class