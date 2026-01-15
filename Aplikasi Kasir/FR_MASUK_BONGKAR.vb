Imports MySql.Data.MySqlClient

Public Class FR_MASUK_BONGKAR
    Dim STR As String
    Dim CMD As MySqlCommand
    Dim RD As MySqlDataReader
    Dim DA As MySqlDataAdapter

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        With FR_MASUK_HISTORY
            .Enabled = True
        End With
        Me.Close()
    End Sub

    Dim JML_MAKS As Double
    Dim HARGA As Integer
    Dim KODE As String

    Private Sub FR_MASUK_BONGKAR_Load(sender As Object, e As EventArgs) Handles Me.Load
        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                       " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                       " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                       " RTRIM(tbl_barang.Satuan) AS 'Satuan'," &
                       " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                       " Stok AS 'Stok Sisa'" &
                       " FROM tbl_transaksi_child" &
                       " INNER JOIN tbl_barang ON tbl_transaksi_child.Kode=tbl_barang.Kode" &
                       " WHERE tbl_transaksi_child.Id = '" & TXT_IDBRG.Text & "'"
        CMD = New MySqlCommand(STR, CONN)
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXT_ID.Text = RD.Item("ID Transaksi")
            TXT_BARANGAWAL.Text = RD.Item("Nama Barang") & " (" & RD.Item("Satuan") & ")"
            TXT_JML.Text = Format(RD.Item("Stok Sisa"), "##0.##")
            JML_MAKS = RD.Item("Stok Sisa")
            HARGA = RD.Item("Harga Partai")
            KODE = RD.Item("Kode Barang")
            RD.Close()
        End If
        RD.Close()
    End Sub

    Private Sub TXT_JML_Validated(sender As Object, e As EventArgs) Handles TXT_JML.Validated
        Dim JML As Double = 0
        If TXT_JML.Text <> "" Then
            JML = Convert.ToDouble(TXT_JML.Text)
        End If
        If JML > JML_MAKS Then
            MsgBox("Jumlah melebihi stok yang tersedia")
            TXT_JML.Select()
        End If
    End Sub

    Private Sub BTN_CARIBARANG_Click(sender As Object, e As EventArgs) Handles BTN_CARIBARANG.Click
        With FR_KELUAR_TAMPIL
            .Show()
            .LB_TITLE.Text = "FR_MASUK_BONGKAR"
        End With
        Me.Enabled = False
    End Sub

    Sub CARI_PRODUK()
        STR = "SELECT Kode, RTRIM(Barang) AS 'Nama Barang', RTRIM(Satuan) AS 'Satuan'" &
                       " FROM tbl_barang" &
                       " WHERE Kode = '" & TXT_KODEBARANG.Text & "'"
        CMD = New MySqlCommand(STR, CONN)
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXT_BARANGTUJUAN.Text = RD.Item("Nama Barang") & " (" & RD.Item("Satuan") & ")"
            RD.Close()
        Else
            MsgBox("Barang tidak ditemukan")
            TXT_BARANGTUJUAN.Text = ""
            TXT_KODEBARANG.Clear()
            TXT_KODEBARANG.Select()
        End If
        RD.Close()
    End Sub

    Private Sub TXT_KODEBARANG_Validated(sender As Object, e As EventArgs) Handles TXT_KODEBARANG.Validated
        If TXT_KODEBARANG.Text <> "" Then
            CARI_PRODUK()
        End If
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If TXT_JML.Text = "" Or TXT_IDBRG.Text = "" Or TXT_JMLBRG.Text = "" Then
            MsgBox("Isi data dengan lengkap!")
        Else
            Dim JML_BARANG As Integer = TXT_JML.Text.ToString.Replace(",", ".") * TXT_JMLBRG.Text.ToString.Replace(",", ".")
            Dim HARGA_PARTAI As Integer = HARGA / TXT_JMLBRG.Text.ToString.Replace(",", ".")
            STR = "INSERT INTO tbl_transaksi_child (Id_trans, Kode, Jumlah, Harga, Stok, Created_at) VALUES" &
                        " ('" & TXT_ID.Text & "'," &
                        " '" & TXT_KODEBARANG.Text & "'," &
                        " " & JML_BARANG & "," &
                        " '" & HARGA_PARTAI & "'," &
                        " '" & JML_BARANG & "'," &
                        " '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"
            CMD = New MySqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            STR = "UPDATE tbl_transaksi_parent SET Jumlah_item = Jumlah_item - " & TXT_JML.Text.ToString.Replace(",", ".") & " + " & JML_BARANG & ", " &
                    " Modified_at = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                    " WHERE Id_trans='" & TXT_ID.Text & "'"
            CMD = New MySqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            STR = "UPDATE tbl_transaksi_child SET Stok = Stok - " & TXT_JML.Text.ToString.Replace(",", ".") & ", " &
                    " Modified_at = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                    " WHERE Id='" & TXT_IDBRG.Text & "'"
            CMD = New MySqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            STR = "UPDATE tbl_stok SET Stok = Stok + " & JML_BARANG & ", " &
                    " Modified_at = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                    " WHERE Kode='" & TXT_KODEBARANG.Text & "'"
            CMD = New MySqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            STR = "UPDATE tbl_stok SET Stok = Stok - " & TXT_JML.Text.ToString.Replace(",", ".") & ", " &
                    " Modified_at = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                    " WHERE Kode='" & KODE & "'"
            CMD = New MySqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Bongkar barang berhasil disimpan!")
            FR_MASUK_HISTORY.Enabled = True
            FR_MASUK_HISTORY.TAMPIL()
            Me.Close()
        End If
    End Sub

    Private Sub TXT_JML_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_JML.KeyPress
        If e.KeyChar = Chr(13) Then
            TXT_IDBRG.Select()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "," Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXT_KODEBARANG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_KODEBARANG.KeyPress
        If e.KeyChar = Chr(13) Then
            TXT_JMLBRG.Select()
        End If
    End Sub

    Private Sub TXT_JMLBRG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_JMLBRG.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "," Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXT_KODEBARANG_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_KODEBARANG.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                BTN_CARIBARANG.PerformClick()
        End Select
    End Sub
End Class