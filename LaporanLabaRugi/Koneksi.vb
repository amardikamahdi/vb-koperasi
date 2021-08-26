Imports MySql.Data.MySqlClient

Public Module Koneksi
    Public conn As MySqlConnection
    Public str As String

    Public Sub connection()
        Try
            Dim str As String = "Server=localhost;user id=root; password=; database=koperasi"
            conn = New MySqlConnection(str)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Module
