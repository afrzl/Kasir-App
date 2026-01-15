Public Class FR_KONEKSI
    Private Sub BTNEXIT_Click(sender As Object, e As EventArgs) Handles BTNEXIT.Click
        End
    End Sub
    Private Sub BTNCONNECT_Click(sender As Object, e As EventArgs) Handles BTNCONNECT.Click
        If TXTSERVER.Text = "" Or TXTUSER.Text = "" Or TXTDATABASE.Text = "" Then
            MsgBox("Data harus diisi semua!")
        Else
            With My.Settings
                .SERVER = TXTSERVER.Text
                .USER = TXTUSER.Text
                .PASSWORD = TXTPASSWORD.Text
                .DATABASE = TXTDATABASE.Text
                .Save()
                .Reload()
            End With

            Try
                KONEKAN()
                MsgBox("Koneksi berhasil!")

                ' Tutup form koneksi dan buka login
                Me.Hide()
                Dim FR As New FR_LOGIN
                FR.Show()

            Catch ex As Exception
                MsgBox("Koneksi gagal: " & ex.Message)
                ' Jangan tutup form jika koneksi gagal
            End Try
        End If
    End Sub
End Class