Imports System.Data.SqlClient

Public Class FR_KELUAR
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub BTNMIN_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Function CARI_HARGA(ByVal QTY As Integer)
        Dim STR As String = "SELECT * FROM tbl_barang" &
            " WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            Dim END1 As Integer = CInt(RD.Item("End1"))
            Dim START2 As Integer = CInt(RD.Item("Start2"))
            Dim END2 As Integer = CInt(RD.Item("End2"))
            Dim START3 As Integer = CInt(RD.Item("Start3"))
            Dim END3 As Integer = CInt(RD.Item("End3"))
            Dim START4 As Integer = CInt(RD.Item("Start4"))
            Dim END4 As Integer = CInt(RD.Item("End4"))
            Dim START5 As Integer = CInt(RD.Item("Start5"))

            If Not QTY = 0 Then
                If Not END1 = 0 Then
                    If Not END2 = 0 Then
                        If Not END3 = 0 Then
                            If Not END4 = 0 Then
                                If QTY <= END1 Then
                                    CARI_HARGA = CInt(RD.Item("Harga1"))
                                ElseIf QTY <= END2 And QTY >= START2 Then
                                    CARI_HARGA = CInt(RD.Item("Harga2"))
                                ElseIf QTY <= END3 And QTY >= START3 Then
                                    CARI_HARGA = CInt(RD.Item("Harga3"))
                                ElseIf QTY <= END4 And QTY >= START4 Then
                                    CARI_HARGA = CInt(RD.Item("Harga4"))
                                Else
                                    CARI_HARGA = CInt(RD.Item("Harga5"))
                                End If
                            Else
                                If QTY <= END1 Then
                                    CARI_HARGA = CInt(RD.Item("Harga1"))
                                ElseIf QTY <= END2 And QTY >= START2 Then
                                    CARI_HARGA = CInt(RD.Item("Harga2"))
                                ElseIf QTY <= END3 And QTY >= START3 Then
                                    CARI_HARGA = CInt(RD.Item("Harga3"))
                                Else
                                    CARI_HARGA = CInt(RD.Item("Harga4"))
                                End If
                            End If
                        Else
                            If QTY <= END1 Then
                                CARI_HARGA = CInt(RD.Item("Harga1"))
                            ElseIf QTY <= END2 And QTY >= START2 Then
                                CARI_HARGA = CInt(RD.Item("Harga2"))
                            Else
                                CARI_HARGA = CInt(RD.Item("Harga3"))
                            End If
                        End If
                    Else
                        If QTY <= END1 Then
                            CARI_HARGA = CInt(RD.Item("Harga1"))
                        Else
                            CARI_HARGA = CInt(RD.Item("Harga2"))
                        End If
                    End If
                Else
                    CARI_HARGA = CInt(RD.Item("Harga1"))
                End If
            Else
                CARI_HARGA = 0
            End If
            RD.Close()
        Else
            RD.Close()
        End If
    End Function

    Sub MASUK_DATA()
        Dim ADA_DATA As Boolean = False
        Dim BARIS_DATA As Integer = 0

        For N = 0 To DGTAMPIL.Rows.Count - 1
            Dim Kode As String = DGTAMPIL.Item("Kode", N).Value
            If Kode = TXTKODE.Text Then
                ADA_DATA = True
                BARIS_DATA = N
                Exit For
            End If
        Next

        If ADA_DATA = True Then
            DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value = DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value + CInt(TXTQTY.Text)
            Dim JUMLAH_QTY As Integer = DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value
            DGTAMPIL.Rows(BARIS_DATA).Cells("Harga").Value = CARI_HARGA(JUMLAH_QTY)
            DGTAMPIL.Rows(BARIS_DATA).Cells("Diskon").Value = (CInt(TXTDISKON.Text) / 100 * DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Harga").Value) * DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Qty").Value
            DGTAMPIL.Rows(BARIS_DATA).Cells("Total").Value = (DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value * DGTAMPIL.Rows(BARIS_DATA).Cells("Harga").Value) - DGTAMPIL.Rows(BARIS_DATA).Cells("Diskon").Value
        Else
            DGTAMPIL.Rows.Add()
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Kode").Value = TXTKODE.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Barang").Value = TXTBARANG.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Satuan").Value = TXTSATUAN.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Harga").Value = TXTHARGA.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Diskon").Value = CInt(TXTDISKON.Text) / 100 * DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Harga").Value
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Qty").Value = TXTQTY.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Total").Value = TXTHARGA.Text - DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Diskon").Value
        End If

        TOTAL_HARGA()
    End Sub

    Private Sub DGTAMPIL_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellEndEdit
        If e.ColumnIndex = 4 Then
            Dim QTY As String = ""
            QTY = DGTAMPIL.Item("Qty", e.RowIndex).Value
            Dim KODEBR As String = DGTAMPIL.Item("Kode", e.RowIndex).Value
            If IsNumeric(QTY) Then
                If CARI_STOK(KODEBR) < 0 Then
                    MsgBox("Stok barang tidak mencukupi!")
                    DGTAMPIL.Item("Qty", e.RowIndex).Value = QTY_AWAL
                Else
                    DGTAMPIL.Item("Total", e.RowIndex).Value = QTY * DGTAMPIL.Item("Harga", e.RowIndex).Value
                    TOTAL_HARGA()
                End If
            Else
                MsgBox("QTY tidak valid!")
                DGTAMPIL.Item("Qty", e.RowIndex).Value = QTY_AWAL
            End If
        End If
    End Sub

    Dim QTY_AWAL As Integer = 0
    Private Sub DGTAMPIL_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DGTAMPIL.CellBeginEdit
        If e.ColumnIndex = 4 Then
            QTY_AWAL = DGTAMPIL.Item("Qty", e.RowIndex).Value
        End If
    End Sub

    Private Function CARI_STOK(ByVal Kode As String) As Integer
        CARI_STOK = 0
        Dim STR As String

        STR = "SELECT Kode, RTRIM(Barang) as Barang, RTRIM(Satuan) as Satuan," &
                "(SELECT COALESCE(SUM(Stok),0) FROM tbl_transaksi_child WHERE Kode=tbl_barang.Kode And LEFT(Id_trans,1)='M') as Stok" &
                " From tbl_barang WHERE kode='" & Kode & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader

        Dim STOK_DATA As Integer = 0
        If RD.HasRows Then
            RD.Read()
            STOK_DATA = RD.Item("Stok")
            RD.Close()
        Else
            RD.Close()
            STOK_DATA = 0
        End If

        Dim STOK_ORDER As Integer = CInt(TXTQTY.Text)
        For N = 0 To DGTAMPIL.RowCount - 1
            If DGTAMPIL.Item("Kode", N).Value = Kode Then
                STOK_ORDER = STOK_ORDER + DGTAMPIL.Item("QTY", N).Value
                Exit For
            End If
        Next

        CARI_STOK = STOK_DATA - STOK_ORDER
    End Function

    Sub TOTAL_HARGA()
        Dim TOT_HARGA As Integer = 0
        For N = 0 To DGTAMPIL.Rows.Count - 1
            TOT_HARGA = TOT_HARGA + DGTAMPIL.Item("Total", N).Value
        Next

        LBTOTAL.Text = Format(TOT_HARGA, "##,##0")
        TXTSUBTOTAL.Text = TOT_HARGA

        If Not LBTOTAL.Text = 0 Then
            TXTBAYAR.ReadOnly = False
        Else
            TXTBAYAR.ReadOnly = True
        End If
    End Sub

    Private Sub FR_KELUAR_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                TXTBAYAR.Select()
        End Select
    End Sub

    Private Sub TXTTUNAI_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            If CInt(TXTKEMBALIAN.Text) >= 0 Then
                INPUT_DB()
            Else
                MsgBox("Pembayaran Kurang!")
            End If
        End If
    End Sub

    Private Sub DGTAMPIL_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGTAMPIL.CellMouseClick
        TXTKODE.ReadOnly = True
        TXTQTY.ReadOnly = False

        TXTKODE.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Kode").Value
        TXTHARGA.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Harga").Value
        TXTQTY.Text = DGTAMPIL.Rows(e.RowIndex).Cells("QTY").Value
        TXTTOTAL.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Total").Value

        TXTQTY.Select()
    End Sub

    Private Sub HapusBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusBarangToolStripMenuItem.Click
        For Each ECELL As DataGridViewCell In DGTAMPIL.SelectedCells
            DGTAMPIL.Rows.RemoveAt(ECELL.RowIndex)
        Next
        TOTAL_HARGA()
    End Sub

    Private Sub FR_KELUAR_Load(sender As Object, e As EventArgs) Handles Me.Load
        TXTKODE.Select()
        TXTKASIR.Text = NAMA_LOGIN
        TXTPEMBELI.Text = "USER"
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")

        PEWAKTU.Enabled = True
    End Sub

    Sub INPUT_DB()
        If DGTAMPIL.Rows.Count <= 0 Then Exit Sub
        Dim SUBTOTAL As Integer = TXTSUBTOTAL.Text
        Dim DISKON As Integer = TXTDISKON_RUPIAH.Text
        Dim HARGA_AKHIR As Integer = TXTTOTALHARGA.Text
        Dim BAYAR As Integer = TXTBAYAR.Text
        Dim KEMBALIAN As Integer = TXTKEMBALIAN.Text
        Dim ID_TRANS As String = AUTOID()
        Dim JUMLAH_ITEM As Integer = 0
        For Each EROW As DataGridViewRow In DGTAMPIL.Rows
            JUMLAH_ITEM += EROW.Cells("QTY").Value
        Next

        Dim STR As String = "INSERT INTO tbl_transaksi_parent" &
            " (Id_trans, Id_kasir, Tgl, Jenis, Person, Harga, Diskon, Jumlah_item, Harga_total, Harga_tunai, Harga_kembali)" &
            " VALUES('" & ID_TRANS & "'," &
            " '" & My.Settings.ID_ACCOUNT & "'," &
            " '" & Format(Date.Now, "MM/dd/yyyy HH:mm:ss") & "'," &
            " 'K'," &
            " '" & TXTPEMBELI.Text & "'," &
            " '" & SUBTOTAL & "'," &
            " '" & DISKON & "'," &
            " '" & JUMLAH_ITEM & "'," &
            " '" & HARGA_AKHIR & "'," &
            " '" & BAYAR & "'," &
            " '" & KEMBALIAN & "')"
        Dim CMD As New SqlCommand(STR, CONN)
        CMD.ExecuteNonQuery()

        For Each EROW As DataGridViewRow In DGTAMPIL.Rows
            Dim KODE_PRODUK As String = EROW.Cells("Kode").Value
            Dim JUMLAH_PRODUK As Integer = EROW.Cells("QTY").Value
            Dim HARGA_PRODUK As Integer = EROW.Cells("Harga").Value * JUMLAH_PRODUK
            Dim DISKON_PRODUK As Integer = EROW.Cells("Diskon").Value
            Dim HARGA_AKHIR_PRODUK As Integer = HARGA_PRODUK - DISKON_PRODUK
            Dim HARGA_BELI_PRODUK As Integer = 0

            If Not JUMLAH_PRODUK = 1 Then
                For N As Integer = 1 To JUMLAH_PRODUK
                    HARGA_BELI_PRODUK += CARI_HARGA_BELI(KODE_PRODUK)
                Next N
            Else
                HARGA_BELI_PRODUK = CARI_HARGA_BELI(KODE_PRODUK)
            End If

            STR = "INSERT INTO tbl_transaksi_child (Id_trans, Kode, Jumlah, Harga_beli, Harga, Diskon, Harga_akhir) VALUES" &
                    " ('" & ID_TRANS & "'," &
                    " '" & KODE_PRODUK & "'," &
                    " '" & JUMLAH_PRODUK & "'," &
                    " '" & HARGA_BELI_PRODUK & "'," &
                    " '" & HARGA_PRODUK & "'," &
                    " '" & DISKON_PRODUK & "'," &
                    " '" & HARGA_AKHIR_PRODUK & "')"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
        Next

        MsgBox("Transaksi Berhasil Dilakukan")
        DGTAMPIL.Rows.Clear()
        TOTAL_HARGA()
        TXTKODE.Select()
    End Sub

    Private Function CARI_HARGA_BELI(ByVal KODE As String) As Integer
        Dim STR As String = "SELECT TOP 1 (Id_trans) AS Id_trans, Harga, Stok FROM tbl_transaksi_child WHERE LEFT(Id_trans,1)='M' AND Kode='" & KODE & "' AND Stok != 0 ORDER BY Id ASC"
        Dim ID_TRANS As String = ""
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            Dim STOK_AKHIR As Integer = RD.Item("Stok") - 1
            ID_TRANS = RD.Item("Id_trans").ToString.Trim
            CARI_HARGA_BELI = RD.Item("Harga")
            RD.Close()
            STR = "UPDATE tbl_transaksi_child SET Stok='" & STOK_AKHIR & "' WHERE Id_trans='" & ID_TRANS & "'"
        End If
        CMD = New SqlCommand(STR, CONN)
        CMD.ExecuteNonQuery()
    End Function

    Private Function AUTOID() As String
        Dim ID_AWAL As String = Format(Date.Now, "yyMMdd")
        Dim STR As String = "SELECT TOP 1 (Id_trans) AS Id_trans FROM tbl_transaksi_parent WHERE LEFT(Id_trans,1)='K' ORDER BY Id DESC"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            If Mid(RD.Item("Id_trans"), 2, 6) = ID_AWAL Then
                Dim ID As Integer = Mid(RD.Item("Id_trans"), 8, 3) + 1
                RD.Close()
                AUTOID = "K" + ID_AWAL + Format(ID, "000")
            Else
                RD.Close()
                AUTOID = "K" + ID_AWAL + Format(1, "000")
            End If
        Else
            RD.Close()
            AUTOID = "K" + ID_AWAL + Format(1, "000")
        End If
        RD.Close()
    End Function

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        Dim FR As New FR_MENU
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub TXTDISKON_PERSEN_TextChanged(sender As Object, e As EventArgs) Handles TXTDISKON_PERSEN.TextChanged
        HITUNGDISKON_RUPIAH()
    End Sub

    Sub HITUNGDISKON_RUPIAH()
        Dim SUBTOTAL As Integer = 0
        Dim DISKON As Integer = 0
        If Not TXTSUBTOTAL.Text = "" Then
            SUBTOTAL = CInt(TXTSUBTOTAL.Text)
        End If
        If Not TXTDISKON_PERSEN.Text = "" Then
            DISKON = CInt(TXTDISKON_PERSEN.Text)
        End If

        TXTDISKON_RUPIAH.Text = SUBTOTAL * DISKON / 100
        TXTTOTALHARGA.Text = SUBTOTAL - CInt(TXTDISKON_RUPIAH.Text)
        LBTOTAL.Text = Format(CInt(TXTTOTALHARGA.Text), "##,##0")
    End Sub

    Private Sub TXTBAYAR_TextChanged(sender As Object, e As EventArgs) Handles TXTBAYAR.TextChanged
        Dim BAYAR As Integer = 0
        If Not TXTBAYAR.Text = "" Then
            BAYAR = CInt(TXTBAYAR.Text)
        End If
        Dim TOTALHARGA As Integer = 0
        If Not TXTTOTALHARGA.Text = "" Then
            TOTALHARGA = CInt(TXTTOTALHARGA.Text)
        End If
        TXTKEMBALIAN.Text = BAYAR - TOTALHARGA
    End Sub

    Private Sub TXTBAYAR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTBAYAR.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTKEMBALIAN.Text >= "0" Then
                INPUT_DB()
                TXTBAYAR.Text = ""
                TXTDISKON_PERSEN.Text = 0
            Else
                MsgBox("Pembayaran Kurang!")
            End If
        End If
    End Sub

    Private Sub TXTSUBTOTAL_TextChanged(sender As Object, e As EventArgs) Handles TXTSUBTOTAL.TextChanged
        HITUNGDISKON_RUPIAH()
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim HARGA As Integer = 0
            If Not TXTHARGA.Text = "" Then
                HARGA = CInt(TXTHARGA.Text)
            End If
            Dim JUMLAH_QTY As Integer = 0
            If Not TXTQTY.Text = "" Then
                JUMLAH_QTY = CInt(TXTQTY.Text)
            End If

            If JUMLAH_QTY = 0 Then
                Dim BARIS_DATA As Integer = 0
                For N = 0 To DGTAMPIL.Rows.Count - 1
                    Dim Kode As String = DGTAMPIL.Item("Kode", N).Value
                    If Kode = TXTKODE.Text Then
                        BARIS_DATA = N
                        Exit For
                    End If
                Next
                DGTAMPIL.Rows.RemoveAt(BARIS_DATA)
                TOTAL_HARGA()
                TXTQTY.ReadOnly = True
                TXTKODE.ReadOnly = False
                TXTKODE.Clear()
                TXTKODE.Select()
            Else
                Dim QTY As Integer = CInt(TXTQTY.Text)
                Dim BARIS_DATA As Integer = 0
                For N = 0 To DGTAMPIL.Rows.Count - 1
                    Dim Kode As String = DGTAMPIL.Item("Kode", N).Value
                    If Kode = TXTKODE.Text Then
                        BARIS_DATA = N
                        Exit For
                    End If
                Next
                TXTQTY.Text = CInt(TXTQTY.Text) - DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value

                If CARI_STOK(TXTKODE.Text) < 0 Then
                    TXTQTY.Text = QTY
                    MsgBox("Stok barang tidak mencukupi!")
                    TXTQTY.Select()
                Else
                    MASUK_DATA()
                    TXTKODE.ReadOnly = False
                    TXTKODE.ReadOnly = False
                    TXTQTY.Text = QTY
                    TXTQTY.ReadOnly = True
                    TXTKODE.Clear()
                    TXTKODE.Select()
                End If
            End If
        End If
    End Sub

    Private Sub TXTQTY_TextChanged(sender As Object, e As EventArgs) Handles TXTQTY.TextChanged
        Dim HARGA As Integer = 0
        If Not TXTHARGA.Text = "" Then
            HARGA = CInt(TXTHARGA.Text)
        End If
        Dim JUMLAH_QTY As Integer = 0
        If Not TXTQTY.Text = "" Then
            JUMLAH_QTY = CInt(TXTQTY.Text)
        End If
        TXTHARGA.Text = CARI_HARGA(JUMLAH_QTY)
        HARGA = CInt(TXTHARGA.Text)
        TXTTOTAL.Text = HARGA * JUMLAH_QTY * (100 - CInt(TXTDISKON.Text)) / 100
    End Sub

    Private Sub TXTKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTQTY.Text = 1
            Dim JUMLAH_QTY As Integer = 0
            If Not TXTQTY.Text = "" Then
                JUMLAH_QTY = CInt(TXTQTY.Text)
            End If

            TXTHARGA.Text = CARI_HARGA(JUMLAH_QTY)
            If CARI_STOK(TXTKODE.Text) < 0 Then
                MsgBox("Stok barang tidak mencukupi!")
                TXTKODE.Clear()
            Else
                MASUK_DATA()
                TXTKODE.Clear()
                TXTKODE.Select()
            End If
        End If
    End Sub

    Sub CARI_DATA()
        Dim TGL_SKRG As String = Format(Date.Now, "yyyy-MM-dd")

        Dim STR As String = "SELECT * FROM tbl_barang" &
            " WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTBARANG.Text = RD.Item("Barang").ToString.Trim
            TXTSATUAN.Text = RD.Item("Satuan").ToString.Trim
            RD.Close()
            STR = "SELECT Diskon FROM tbl_diskon" &
                " WHERE Kode='" & TXTKODE.Text & "'" &
                " AND Tgl_awal <= '" & TGL_SKRG & "'" &
                " And Tgl_akhir >= '" & TGL_SKRG & "'"
            CMD = New SqlCommand(STR, CONN)
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Read()
                TXTDISKON.Text = RD.Item("Diskon")
                RD.Close()
            Else
                TXTDISKON.Text = 0
                RD.Close()
            End If
            TXTQTY.Text = 1
        Else
            RD.Close()
        End If
    End Sub

    Private Sub TXTKODE_TextChanged(sender As Object, e As EventArgs) Handles TXTKODE.TextChanged
        CARI_DATA()
        Dim HARGA As Integer = 0
        Dim JUMLAH_QTY As Integer = 0
        Dim DISKON As Integer = 0
        If Not TXTDISKON.Text = "" Then
            DISKON = CInt(TXTDISKON.Text)
        End If
        If Not TXTQTY.Text = "" Then
            JUMLAH_QTY = CInt(TXTQTY.Text)
        End If
        TXTHARGA.Text = CARI_HARGA(JUMLAH_QTY)
        If Not TXTHARGA.Text = "" Then
            HARGA = CInt(TXTHARGA.Text)
        End If
        TXTTOTAL.Text = HARGA * JUMLAH_QTY * (100 - DISKON) / 100
    End Sub
End Class