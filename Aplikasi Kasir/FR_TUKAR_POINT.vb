Imports MySql.Data.MySqlClient

Public Class FR_TUKAR_POINT
    Dim CMD As MySqlCommand
    Dim RD As MySqlDataReader
    Dim STR As String

    Private Sub FR_TUKAR_POINT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TXTNAMABARANG.Select()
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        FR_MEMBER.Enabled = True
        Me.Close()
    End Sub

    Private Sub BTNBATAL_Click(sender As Object, e As EventArgs) Handles BTNBATAL.Click
        FR_MEMBER.Enabled = True
        Me.Close()
    End Sub

    Private Sub BTNTUKAR_Click(sender As Object, e As EventArgs) Handles BTNTUKAR.Click
        If String.IsNullOrWhiteSpace(TXTNAMABARANG.Text) Then
            MessageBox.Show("Nama barang harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TXTNAMABARANG.Select()
            Return
        End If

        If String.IsNullOrWhiteSpace(TXTPOINTDIGUNAKAN.Text) OrElse Not IsNumeric(TXTPOINTDIGUNAKAN.Text) Then
            MessageBox.Show("Point yang digunakan harus diisi dengan angka!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TXTPOINTDIGUNAKAN.Select()
            Return
        End If

        Dim pointDigunakan As Decimal = Convert.ToDecimal(TXTPOINTDIGUNAKAN.Text)
        Dim pointTersedia As Decimal = Convert.ToDecimal(LBPOINTTERSEDIA.Text.Replace(",", ""))

        If pointDigunakan > pointTersedia Then
            MessageBox.Show("Point tidak mencukupi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TXTPOINTDIGUNAKAN.Select()
            Return
        End If

        If pointDigunakan <= 0 Then
            MessageBox.Show("Point harus lebih dari 0!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TXTPOINTDIGUNAKAN.Select()
            Return
        End If

        Try
            ' Insert transaksi penukaran point
            STR = "INSERT INTO tbl_penukaran_point (Id_kasir, Id_member, Point, Nama_barang, Created_at) " &
                  "VALUES ('" & My.Settings.ID_ACCOUNT & "', '" & LBIDMEMBER.Text & "', " & pointDigunakan & ", " &
                  "'" & TXTNAMABARANG.Text.Replace("'", "''") & "', NOW())"
            KONEKSI.EXECUTE_NONQUERY(STR)

            ' Update point member
            STR = "UPDATE tbl_member SET Points = Points - " & pointDigunakan & ", " &
                  "Modified_at = NOW() WHERE Id = '" & LBIDMEMBER.Text & "'"
            KONEKSI.EXECUTE_NONQUERY(STR)

            MessageBox.Show("Penukaran point berhasil!" & vbCrLf &
                          "Member: " & LBNAMAMEMBER.Text & vbCrLf &
                          "Barang: " & TXTNAMABARANG.Text & vbCrLf &
                          "Point digunakan: " & pointDigunakan.ToString("###,##0"), 
                          "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear form dan refresh
            TXTNAMABARANG.Clear()
            TXTPOINTDIGUNAKAN.Clear()
            TXTNAMABARANG.Select()

            ' Update point tersedia
            Dim newPoint As Decimal = pointTersedia - pointDigunakan
            LBPOINTTERSEDIA.Text = newPoint.ToString("###,##0")

            ' Refresh riwayat dan tampilan member
            FR_MEMBER.TAMPIL()
            FR_MEMBER.LOAD_RIWAYAT()

        Catch ex As Exception
            MessageBox.Show("Error saat menyimpan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TXTPOINTDIGUNAKAN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPOINTDIGUNAKAN.KeyPress
        ' Hanya izinkan angka, backspace, dan enter
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> Chr(8) AndAlso e.KeyChar <> Chr(13) Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            BTNTUKAR.PerformClick()
        End If
    End Sub
End Class
