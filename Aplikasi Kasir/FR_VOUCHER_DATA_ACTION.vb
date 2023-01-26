Imports System.Data.SqlClient

Public Class FR_VOUCHER_DATA_ACTION

    Dim CMD As SqlCommand
    Dim RD As SqlDataReader
    Dim DA As SqlDataAdapter
    Dim STR As String

    Sub CLOSE_FORM()
        With FR_VOUCHER_DATA
            .Enabled = True
            .TAMPIL()
        End With
        Me.Close()
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        CLOSE_FORM()
    End Sub

    Private Sub CB_JENIS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_JENIS.SelectedIndexChanged
        If CB_JENIS.SelectedIndex > 0 Then
            If CB_JENIS.SelectedIndex = 1 Then
                Label3.Visible = True
                TXTHARGA_JUAL.Visible = True
            Else
                Label3.Visible = False
                TXTHARGA_JUAL.Visible = False
            End If
        End If
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If CB_JENIS.SelectedIndex = 0 Or TXTNAMA.Text = "" Or TXTHARGA.Text = "" Then
            MsgBox("Data tidak lengkap!")
            CB_JENIS.Select()
        Else
            If CB_JENIS.SelectedIndex = 1 Then
                If TXTHARGA_JUAL.Text = "" Then
                    MsgBox("Data tidak lengkap!")
                    TXTHARGA_JUAL.Select()
                Else
                    If LBL_ID.Text = "" Then
                        STR = "INSERT INTO tbl_data_voucher (Jenis, Nama, Harga, Harga_jual) VALUES (" &
                            "'" & CB_JENIS.Text & "'," &
                            "'" & TXTNAMA.Text & "'," &
                            "'" & TXTHARGA.Text & "'," &
                            "'" & TXTHARGA_JUAL.Text & "'" &
                            ")"
                        CMD = New SqlCommand(STR, CONN)
                        CMD.ExecuteNonQuery()

                        MsgBox("Data voucher berhasil disimpan.")
                    Else
                        STR = "UPDATE tbl_data_voucher SET" &
                            " Jenis = '" & CB_JENIS.Text & "'," &
                            " Nama = '" & TXTNAMA.Text & "'," &
                            " Harga = '" & TXTHARGA.Text & "'," &
                            " Harga_jual = '" & TXTHARGA_JUAL.Text & "'" &
                            " WHERE Id = '" & LBL_ID.Text & "'"
                        CMD = New SqlCommand(STR, CONN)
                        CMD.ExecuteNonQuery()

                        MsgBox("Data voucher berhasil diubah.")
                    End If
                    CLOSE_FORM()
                End If
            Else
                If LBL_ID.Text = "" Then
                    STR = "INSERT INTO tbl_data_voucher (Jenis, Nama, Harga) VALUES (" &
                            "'" & CB_JENIS.Text & "'," &
                            "'" & TXTNAMA.Text & "'," &
                            "'" & TXTHARGA.Text & "'" &
                            ")"
                    CMD = New SqlCommand(STR, CONN)
                    CMD.ExecuteNonQuery()

                    MsgBox("Data voucher berhasil disimpan.")
                Else
                    STR = "UPDATE tbl_data_voucher SET" &
                            " Jenis = '" & CB_JENIS.Text & "'," &
                            " Nama = '" & TXTNAMA.Text & "'," &
                            " Harga = '" & TXTHARGA.Text & "'," &
                            " Harga_jual = NULL" &
                            " WHERE Id = '" & LBL_ID.Text & "'"
                    CMD = New SqlCommand(STR, CONN)
                    CMD.ExecuteNonQuery()

                    MsgBox("Data voucher berhasil diubah.")
                End If
                CLOSE_FORM()
            End If
        End If
    End Sub

    Sub CARI_DATA()
        STR = "SELECT * FROM tbl_data_voucher WHERE Id = '" & LBL_ID.Text & "'"
        CMD = New SqlCommand(STR, CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            For i As Integer = 1 To CB_JENIS.Items.Count - 1
                If CB_JENIS.Items(i).ToString = RTrim(RD.Item("Jenis")) Then
                    CB_JENIS.SelectedIndex = i
                End If
            Next

            TXTNAMA.Text = RTrim(RD.Item("Nama"))
            TXTHARGA.Text = Format(RD.Item("Harga"), "##0")
            TXTHARGA_JUAL.Text = Format(RD.Item("Harga_jual"), "##0")
            RD.Close()
        Else
            RD.Close()
        End If
    End Sub

    Private Sub CB_JENIS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CB_JENIS.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TXTNAMA.Select()
        End If
    End Sub

    Private Sub TXTNAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNAMA.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TXTHARGA.Select()
        End If
    End Sub

    Private Sub TXTHARGA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            If CB_JENIS.SelectedIndex = 0 Then
                TXTHARGA_JUAL.Select()
            Else
                BTNSIMPAN.Select()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTHARGA_JUAL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA_JUAL.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            BTNSIMPAN.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub
End Class