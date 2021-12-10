Public Class FR_KELUAR_KEMBALIAN
    Private Sub BTNTUTUP_Click(sender As Object, e As EventArgs) Handles BTNTUTUP.Click
        With FR_KELUAR
            .TXTBAYAR.Text = ""
            .TXTDISKON_PERSEN.Text = 0
            .DGTAMPIL.Rows.Clear()
            .TXTKEMBALIAN.Clear()
            .TOTAL_HARGA()
            .TXTKODE.Select()

            .Enabled = True
        End With
        Me.Close()
    End Sub

    Private Sub FR_KELUAR_KEMBALIAN_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                With FR_KELUAR
                    .TXTBAYAR.Text = ""
                    .TXTDISKON_PERSEN.Text = 0
                    .DGTAMPIL.Rows.Clear()
                    .TXTKEMBALIAN.Clear()
                    .TOTAL_HARGA()
                    .TXTKODE.Select()

                    .Enabled = True
                End With
                Me.Close()
        End Select
    End Sub
End Class