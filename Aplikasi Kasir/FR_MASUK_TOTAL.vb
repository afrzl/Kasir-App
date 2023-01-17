Public Class FR_MASUK_TOTAL
    Private Sub BTNTUTUP_Click(sender As Object, e As EventArgs) Handles BTNTUTUP.Click
        With FR_MASUK
            .DGTAMPIL.Rows.Clear()
            .TOTAL_HARGA()

            .Enabled = True
        End With
        Me.Close()
    End Sub

    Private Sub FR_KELUAR_KEMBALIAN_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                With FR_MASUK
                    .DGTAMPIL.Rows.Clear()
                    .TOTAL_HARGA()

                    .Enabled = True
                End With
                Me.Close()
        End Select
    End Sub

    Private Sub BTN_CETAKNOTA_Click(sender As Object, e As EventArgs) Handles BTN_CETAKNOTA.Click
        With FR_MASUK
            .PRINT_NOTA()
            .DGTAMPIL.Rows.Clear()
            .TOTAL_HARGA()

            .Enabled = True
        End With
        Me.Close()
    End Sub
End Class