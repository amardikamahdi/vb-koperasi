Public Class formHome

    Private Sub productButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles productButton.Click
        productForm.Show()
    End Sub

    Private Sub formHome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Enabled = False
        Me.Visible = False
        loginForm.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        pelangganForm.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        penjualanForm.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        labaForm.Show()
    End Sub
End Class
