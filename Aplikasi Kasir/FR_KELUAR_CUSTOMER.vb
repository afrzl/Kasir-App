Public Class FR_KELUAR_CUSTOMER
    Private Sub FR_KELUAR_CUSTOMER_Load(sender As Object, e As EventArgs) Handles Me.Load
        TXTKASIR.Text = NAMA_LOGIN
        TXTPEMBELI.Text = FR_KELUAR.TXTPEMBELI.Text
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")

        PEWAKTU.Enabled = True
    End Sub

    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub DGTAMPIL_SelectionChanged(sender As Object, e As EventArgs) Handles DGTAMPIL.SelectionChanged
        DGTAMPIL.ClearSelection()
    End Sub
End Class