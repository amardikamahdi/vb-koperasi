Imports MySql.Data.MySqlClient

Public Class loginForm

    Private Sub loginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginButton.Click
        Call connection()
        Dim str As String
        Dim cmd As MySqlCommand
        Dim rd As MySqlDataReader

        str = "SELECT * FROM users WHERE username='" & txtUsername.Text & "' AND password='" & txtPassword.Text & "'"
        cmd = New MySqlCommand(str, conn)
        rd = cmd.ExecuteReader
        If rd.HasRows Then
            MessageBox.Show("Login berhasil. Selamat datang, " & txtUsername.Text & ".")
            formHome.Visible = True
            formHome.Enabled = True
            Me.Close()
        Else
            rd.Close()
            MessageBox.Show("Login gagal, silahkan cek data anda kembali.")
            txtUsername.Text = ""
            txtPassword.Text = ""
            txtUsername.Focus()
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class