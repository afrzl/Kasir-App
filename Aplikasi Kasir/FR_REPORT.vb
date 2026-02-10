Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FR_REPORT
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        Select Case ROLE
            Case 1
                BUKA_FORM(FR_MENU)
            Case 2
                BUKA_FORM(FR_OPS_DASHBOARD)
            Case 3
                BUKA_FORM(FR_KASIR_DASHBOARD)
        End Select
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        If MsgBox("Apakah anda yakin akan logout?", vbYesNo) = vbYes Then
            Dim FR As New FR_LOGIN
            My.Settings.ID_ACCOUNT = 0
            FR.Show()
            Me.Close()
        End If
    End Sub

    Private Sub FR_REPORT_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case ROLE
            Case 1
                PNADMIN.Visible = True
                PNKASIR.Visible = False
                PNOPS.Visible = False
                Label3.Text = "Administrator"
                CBJENIS.Items.Clear()
                With CBJENIS
                    .Items.Add("Harga")
                    .Items.Add("Stok")
                    .Items.Add("Transaksi Masuk")
                    .Items.Add("Transaksi Keluar")
                    .Items.Add("Penjualan")
                    .Items.Add("Penjualan Harian")
                    .Items.Add("Penjualan Barang")
                    .Items.Add("Grafik Penjualan Harian")
                    .Items.Add("Grafik Penjualan Bulanan")
                    .Items.Add("Grafik Penjualan Barang")
                    .Items.Add("Grafik Laba Harian")
                    .Items.Add("Grafik Laba Bulanan")
                End With
            Case 2
                PNADMIN.Visible = False
                PNKASIR.Visible = False
                PNOPS.Visible = True
                Label3.Text = "Operator"
                CBJENIS.Items.Clear()
                With CBJENIS
                    .Items.Add("Harga")
                    .Items.Add("Stok")
                    .Items.Add("Transaksi Masuk")
                    .Items.Add("Transaksi Keluar")
                End With
            Case 3
                PNADMIN.Visible = False
                PNKASIR.Visible = True
                PNOPS.Visible = False
                Label3.Text = "Kasir"
                CBJENIS.Items.Clear()
                With CBJENIS
                    .Items.Add("Stok")
                    .Items.Add("Transaksi Masuk")
                    .Items.Add("Transaksi Keluar")
                End With
        End Select
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN

        KONDISI_AWAL()

        CBJENIS.SelectedIndex() = 0
        BTNTAMPIL.PerformClick()
    End Sub


    Dim STR As String = ""
    Dim TBL As New DataTable
    Dim DT As New DataTable
    Dim TOTALLABA As Integer = 0
    Dim TOTALITEM As Double = 0
    Dim TOTALPEMBELIAN As Integer = 0
    Dim TOTALPENJUALAN As Long = 0

    Dim ADA_TRANSAKSI As Boolean
    Sub TAMPIL()
        Try
            BUKA_KONEKSI()
        Catch ex As Exception
            MsgBox("Koneksi database gagal: " & ex.Message, vbCritical)
            Return
        End Try

        TOTALLABA = 0
        Dim TGL_SKRG As String = Format(Date.Now, "yyyy-MM-dd")
        Select Case ROLE
            Case 1
                Select Case CBJENIS.SelectedIndex
                    Case 0
                        STR = "SELECT RTRIM(tbl_barang.Kode) AS 'Kode', " &
                        " RTRIM(tbl_barang.Barang) as Barang," &
                        " RTRIM(tbl_barang.Satuan) as Satuan," &
                        " tbl_barang.Harga1," &
                        " tbl_barang.End1," &
                        " tbl_barang.Harga2," &
                        " tbl_barang.End2," &
                        " tbl_barang.Harga3," &
                        " tbl_barang.End3," &
                        " tbl_barang.Harga4," &
                        " tbl_barang.End4," &
                        " tbl_barang.Harga5," &
                        " (tbl_diskon.Tgl_awal) as 'Tgl_awal'," &
                        " (tbl_diskon.Tgl_akhir) as 'Tgl_akhir'," &
                        " (tbl_diskon.Diskon) as 'Diskon'" &
                        " FROM tbl_barang" &
                        " LEFT JOIN tbl_diskon ON (tbl_barang.Kode = tbl_diskon.Kode AND tbl_diskon.Tgl_awal <= '" & TGL_SKRG & "' AND tbl_diskon.Tgl_akhir >= '" & TGL_SKRG & "')" &
                        " ORDER BY tbl_barang.Barang ASC"
                    Case 1
                        STR = "SELECT tbl_barang.Kode AS 'Kode Barang'," &
                        " tbl_barang.Barang AS 'Nama Barang'," &
                        " tbl_barang.Satuan AS 'Satuan'," &
                        " COALESCE(masuk.total_masuk, 0) AS 'Barang Masuk'," &
                        " COALESCE(keluar.total_keluar, 0) AS 'Barang Keluar'" &
                        " FROM tbl_barang" &
                        " LEFT JOIN (SELECT tc.Kode, SUM(tc.Jumlah) AS total_masuk FROM tbl_transaksi_child tc" &
                        " INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans" &
                        " WHERE tp.Jenis IN ('M','R') GROUP BY tc.Kode) masuk ON tbl_barang.Kode = masuk.Kode" &
                        " LEFT JOIN (SELECT tc.Kode, SUM(tc.Jumlah) AS total_keluar FROM tbl_transaksi_child tc" &
                        " INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans" &
                        " WHERE tp.Jenis IN ('K','C') GROUP BY tc.Kode) keluar ON tbl_barang.Kode = keluar.Kode" &
                        " ORDER BY tbl_barang.Barang ASC"
                    Case 2
                        STR = "SELECT RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                    " RTRIM(tbl_transaksi_parent.Jenis) AS 'Jenis'," &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " RTRIM(tbl_karyawan.Nama) AS 'Kasir'," &
                    " RTRIM(tbl_transaksi_parent.Person) AS 'Supplier'," &
                    " tbl_transaksi_child.Jumlah AS 'Jumlah_item'," &
                    " RTRIM(tbl_transaksi_child.Kode) As 'Kode Barang'," &
                    " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                    " tbl_transaksi_child.Harga  AS 'Harga QTY'," &
                    " tbl_transaksi_child.Jumlah AS 'Stok Masuk'," &
                    " (tbl_transaksi_child.Harga * tbl_transaksi_child.Jumlah) AS 'Harga'," &
                    " tbl_transaksi_child.Stok AS 'Sisa Stok'" &
                    " From tbl_transaksi_child" &
                    " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " LEFT JOIN tbl_karyawan ON tbl_transaksi_parent.Id_kasir = tbl_karyawan.Id" &
                    " LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                    " WHERE tbl_transaksi_parent.Jenis IN ('M','R')" &
                    " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                    " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                    " ORDER BY tbl_transaksi_parent.Tgl DESC, tbl_transaksi_child.Id DESC"
                    Case 3
                        STR = "SELECT tbl_transaksi_child.Id_trans AS 'ID Transaksi'," &
                    " tbl_transaksi_parent.Jenis AS 'Jenis'," &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " tbl_karyawan.Nama AS 'Kasir'," &
                    " tbl_transaksi_parent.Person AS 'Pembeli'," &
                    " tbl_transaksi_parent.Jumlah_item AS 'Jumlah_item'," &
                    " tbl_transaksi_child.Kode As 'Kode Barang'," &
                    " tbl_barang.Barang AS 'Nama Barang'," &
                    " (tbl_transaksi_child.Harga / tbl_transaksi_child.Jumlah) AS 'Harga QTY'," &
                    " tbl_transaksi_child.Jumlah AS 'QTY'," &
                    " tbl_transaksi_child.Harga AS 'Harga Jual'," &
                    " tbl_transaksi_child.Diskon AS 'Diskon'," &
                    " tbl_transaksi_child.Harga_akhir AS 'Harga'," &
                    " tbl_transaksi_parent.Harga AS 'Total'," &
                    " tbl_transaksi_parent.Diskon AS 'Diskon Transaksi'," &
                    " tbl_transaksi_parent.Harga_total AS 'Total Akhir'," &
                    " tbl_transaksi_parent.Harga_tunai AS 'Bayar'," &
                    " tbl_transaksi_parent.Harga_kembali AS 'Kembalian'," &
                    " (tbl_transaksi_child.Harga_akhir - tbl_transaksi_child.Harga_beli) AS 'Laba Item'," &
                    " (COALESCE(laba_trans.total_laba, 0) - tbl_transaksi_parent.Diskon) AS 'Laba'" &
                    " FROM tbl_transaksi_child" &
                    " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " LEFT JOIN tbl_karyawan ON tbl_transaksi_parent.Id_kasir = tbl_karyawan.Id" &
                    " LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                    " LEFT JOIN (SELECT tc2.Id_trans, SUM(tc2.Harga_akhir - tc2.Harga_beli) AS total_laba FROM tbl_transaksi_child tc2" &
                    " INNER JOIN tbl_transaksi_parent tp2 ON tc2.Id_trans = tp2.Id_trans" &
                    " WHERE tp2.Jenis IN ('K','C')" &
                    " AND tp2.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                    " AND tp2.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                    " GROUP BY tc2.Id_trans) laba_trans ON laba_trans.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " WHERE tbl_transaksi_parent.Jenis IN ('K','C')" &
                    " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                    " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                    " ORDER BY tbl_transaksi_parent.Tgl DESC, tbl_transaksi_child.Id DESC"
                    Case 4
                        STR = "SELECT tbl_transaksi_child.Id_trans AS 'ID Transaksi'," &
                                " tbl_transaksi_child.Kode AS 'Kode Barang'," &
                                " tbl_barang.Barang AS 'Nama Barang'," &
                                " tbl_transaksi_parent.Tgl AS 'Tanggal', " &
                                " tbl_transaksi_child.Jumlah AS 'Jumlah Item'," &
                                " tbl_transaksi_child.Harga_beli AS 'Harga Beli'," &
                                " tbl_transaksi_child.Harga / tbl_transaksi_child.Jumlah AS 'Harga Jual'," &
                                " tbl_transaksi_child.Diskon AS 'Diskon'," &
                                " tbl_transaksi_parent.Diskon AS 'Diskon Trans'" &
                                " FROM tbl_transaksi_child" &
                                " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                                " LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                                " WHERE tbl_transaksi_parent.Jenis IN ('K','C')" &
                                " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                                " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                                " ORDER BY tbl_transaksi_parent.Tgl DESC, tbl_transaksi_child.Id DESC"
                    Case 5
                        STR = "SELECT tbl_transaksi_parent.Id_trans AS 'ID Transaksi'," &
                                " tbl_transaksi_parent.Tgl AS 'Tanggal', " &
                                " tbl_transaksi_parent.Jumlah_item AS 'Jumlah Item'," &
                                " COALESCE(beli_trans.total_beli, 0) AS 'Harga Beli'," &
                                " tbl_transaksi_parent.Harga_total AS 'Harga Jual'" &
                                " FROM tbl_transaksi_parent" &
                                " LEFT JOIN (SELECT tc2.Id_trans, SUM(tc2.Harga_beli) AS total_beli FROM tbl_transaksi_child tc2" &
                                " INNER JOIN tbl_transaksi_parent tp2 ON tc2.Id_trans = tp2.Id_trans" &
                                " WHERE tp2.Jenis IN ('K','C')" &
                                " AND tp2.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                                " AND tp2.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                                " GROUP BY tc2.Id_trans) beli_trans ON beli_trans.Id_trans = tbl_transaksi_parent.Id_trans" &
                                " WHERE tbl_transaksi_parent.Jenis IN ('K','C')" &
                                " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                                " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                                " ORDER BY tbl_transaksi_parent.Tgl DESC"
                    Case 6
                        STR = "SELECT tbl_transaksi_child.Id_trans AS 'ID Transaksi'," &
                                " tbl_transaksi_child.Kode AS 'Kode Barang'," &
                                " tbl_barang.Barang AS 'Nama Barang'," &
                                " tbl_transaksi_parent.Tgl AS 'Tanggal', " &
                                " tbl_transaksi_child.Jumlah AS 'Jumlah Item'," &
                                " tbl_transaksi_child.Harga_beli AS 'Harga Beli'," &
                                " tbl_transaksi_child.Harga_akhir AS 'Harga Jual'," &
                                " tbl_transaksi_parent.Diskon AS 'Diskon'" &
                                " FROM tbl_transaksi_child" &
                                " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                                " LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                                " WHERE tbl_transaksi_parent.Jenis IN ('K','C')" &
                                " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                                " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                                " ORDER BY tbl_transaksi_parent.Tgl DESC, tbl_transaksi_child.Id DESC"
                    Case 7
                        STR = "SELECT" &
                    " Tgl AS 'Tanggal'," &
                    " Jumlah_item AS 'Jumlah_item'" &
                    " FROM tbl_transaksi_parent" &
                    " WHERE (Jenis = 'K' OR Jenis = 'C')" &
                    " AND Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                    " AND Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                    " ORDER BY Tgl DESC"
                    Case 8
                        Dim LASTDAYOFMONTH = DateTime.DaysInMonth(TXTTGLAKHIR.Value.ToString("yyyy"), TXTTGLAKHIR.Value.ToString("MM"))
                        STR = "SELECT" &
                    " Tgl AS 'Tanggal'," &
                    " Jumlah_item AS 'Jumlah_item'" &
                    " FROM tbl_transaksi_parent" &
                    " WHERE (Jenis = 'K' OR Jenis = 'C')" &
                    " AND Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM") & "-01 00:00:00'" &
                    " AND Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-" & LASTDAYOFMONTH) & " 23:59:59'" &
                    " ORDER BY Tgl DESC"
                    Case 9
                        STR = "SELECT " &
                   " tbl_transaksi_child.Kode AS 'Kode Barang'," &
                   " tbl_barang.Barang AS 'Nama Barang'," &
                   " tbl_transaksi_child.Jumlah AS 'Jumlah_item'" &
                   " FROM tbl_transaksi_child" &
                   " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                   " LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                   " WHERE tbl_transaksi_parent.Jenis IN ('K','C')" &
                   " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                   " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                   " ORDER BY tbl_transaksi_parent.Tgl DESC"
                    Case 10
                        STR = "SELECT tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " (COALESCE(laba_trans.total_laba, 0) - tbl_transaksi_parent.Diskon) AS 'Laba'" &
                    " FROM tbl_transaksi_parent" &
                    " LEFT JOIN (SELECT tc2.Id_trans, SUM(tc2.Harga_akhir - tc2.Harga_beli) AS total_laba FROM tbl_transaksi_child tc2" &
                    " INNER JOIN tbl_transaksi_parent tp2 ON tc2.Id_trans = tp2.Id_trans" &
                    " WHERE tp2.Jenis IN ('K','C')" &
                    " AND tp2.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                    " AND tp2.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                    " GROUP BY tc2.Id_trans) laba_trans ON laba_trans.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " WHERE tbl_transaksi_parent.Jenis IN ('K','C')" &
                    " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                    " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                    " ORDER BY tbl_transaksi_parent.Tgl DESC"
                    Case 11
                        Dim LASTDAYOFMONTH = DateTime.DaysInMonth(TXTTGLAKHIR.Value.ToString("yyyy"), TXTTGLAKHIR.Value.ToString("MM"))
                        STR = "SELECT tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " (COALESCE(laba_trans.total_laba, 0) - tbl_transaksi_parent.Diskon) AS 'Laba'" &
                    " FROM tbl_transaksi_parent" &
                    " LEFT JOIN (SELECT tc2.Id_trans, SUM(tc2.Harga_akhir - tc2.Harga_beli) AS total_laba FROM tbl_transaksi_child tc2" &
                    " INNER JOIN tbl_transaksi_parent tp2 ON tc2.Id_trans = tp2.Id_trans" &
                    " WHERE tp2.Jenis IN ('K','C')" &
                    " AND tp2.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-01") & " 00:00:00'" &
                    " AND tp2.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-" & LASTDAYOFMONTH) & " 23:59:59'" &
                    " GROUP BY tc2.Id_trans) laba_trans ON laba_trans.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " WHERE tbl_transaksi_parent.Jenis IN ('K','C')" &
                    " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-01") & " 00:00:00'" &
                    " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-" & LASTDAYOFMONTH) & " 23:59:59'" &
                    " ORDER BY tbl_transaksi_parent.Tgl DESC"
                End Select
            Case 2
                Select Case CBJENIS.SelectedIndex
                    Case 0
                        STR = "SELECT RTRIM(tbl_barang.Kode) AS 'Kode', " &
                        " RTRIM(tbl_barang.Barang) as Barang," &
                        " RTRIM(tbl_barang.Satuan) as Satuan," &
                        " tbl_barang.Harga1," &
                        " tbl_barang.End1," &
                        " tbl_barang.Harga2," &
                        " tbl_barang.End2," &
                        " tbl_barang.Harga3," &
                        " tbl_barang.End3," &
                        " tbl_barang.Harga4," &
                        " tbl_barang.End4," &
                        " tbl_barang.Harga5," &
                        " (tbl_diskon.Tgl_awal) as 'Tgl_awal'," &
                        " (tbl_diskon.Tgl_akhir) as 'Tgl_akhir'," &
                        " (tbl_diskon.Diskon) as 'Diskon'" &
                        " FROM tbl_barang" &
                        " LEFT JOIN tbl_diskon ON (tbl_barang.Kode = tbl_diskon.Kode AND tbl_diskon.Tgl_awal <= '" & TGL_SKRG & "' AND tbl_diskon.Tgl_akhir >= '" & TGL_SKRG & "')" &
                        " ORDER BY tbl_barang.Barang ASC"
                    Case 1
                        STR = "SELECT tbl_barang.Kode AS 'Kode Barang'," &
                    " tbl_barang.Barang AS 'Nama Barang'," &
                    " tbl_barang.Satuan AS 'Satuan'," &
                    " COALESCE(masuk.total_masuk, 0) AS 'Barang Masuk'," &
                    " COALESCE(keluar.total_keluar, 0) AS 'Barang Keluar'" &
                    " FROM tbl_barang" &
                    " LEFT JOIN (SELECT tc.Kode, SUM(tc.Jumlah) AS total_masuk FROM tbl_transaksi_child tc" &
                    " INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans" &
                    " WHERE tp.Jenis IN ('M','R') GROUP BY tc.Kode) masuk ON tbl_barang.Kode = masuk.Kode" &
                    " LEFT JOIN (SELECT tc.Kode, SUM(tc.Jumlah) AS total_keluar FROM tbl_transaksi_child tc" &
                    " INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans" &
                    " WHERE tp.Jenis IN ('K','C') GROUP BY tc.Kode) keluar ON tbl_barang.Kode = keluar.Kode" &
                    " ORDER BY tbl_barang.Barang ASC"
                    Case 2
                        STR = "SELECT RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                    " RTRIM(tbl_transaksi_parent.Jenis) AS 'Jenis'," &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " RTRIM(tbl_karyawan.Nama) AS 'Kasir'," &
                    " RTRIM(tbl_transaksi_parent.Person) AS 'Supplier'," &
                    " tbl_transaksi_child.Jumlah AS 'Jumlah_item'," &
                    " RTRIM(tbl_transaksi_child.Kode) As 'Kode Barang'," &
                    " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                    " tbl_transaksi_child.Harga  AS 'Harga QTY'," &
                    " tbl_transaksi_child.Jumlah AS 'Stok Masuk'," &
                    " (tbl_transaksi_child.Harga * tbl_transaksi_child.Jumlah) AS 'Harga'," &
                    " tbl_transaksi_child.Stok AS 'Sisa Stok'" &
                    " FROM tbl_transaksi_child" &
                    " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " LEFT JOIN tbl_karyawan ON tbl_transaksi_parent.Id_kasir = tbl_karyawan.Id" &
                    " LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                    " WHERE tbl_transaksi_parent.Jenis IN ('M','R')" &
                    " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                    " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                    " AND tbl_transaksi_parent.Id_kasir = '" & My.Settings.ID_ACCOUNT & "'" &
                    " ORDER BY tbl_transaksi_parent.Tgl DESC, tbl_transaksi_child.Id DESC"
                    Case 3
                        STR = "SELECT RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                    " RTRIM(tbl_transaksi_parent.Jenis) AS 'Jenis'," &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " RTRIM(tbl_karyawan.Nama) AS 'Kasir'," &
                    " RTRIM(tbl_transaksi_parent.Person) AS 'Pembeli'," &
                    " tbl_transaksi_parent.Jumlah_item AS 'Jumlah_item'," &
                    " RTRIM(tbl_transaksi_child.Kode) As 'Kode Barang'," &
                    " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                    " (tbl_transaksi_child.Harga / tbl_transaksi_child.Jumlah)  AS 'Harga QTY'," &
                    " tbl_transaksi_child.Jumlah AS 'QTY'," &
                    " tbl_transaksi_child.Harga  AS 'Harga Jual'," &
                    " tbl_transaksi_child.Diskon AS 'Diskon'," &
                    " tbl_transaksi_child.Harga_akhir AS 'Harga'," &
                    " tbl_transaksi_parent.Harga AS 'Total'," &
                    " tbl_transaksi_parent.Diskon AS 'Diskon Transaksi'," &
                    " tbl_transaksi_parent.Harga_total AS 'Total Akhir'," &
                    " tbl_transaksi_parent.Harga_tunai AS 'Bayar'," &
                    " tbl_transaksi_parent.Harga_kembali AS 'Kembalian'" &
                    " FROM tbl_transaksi_child" &
                    " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " LEFT JOIN tbl_karyawan ON tbl_transaksi_parent.Id_kasir = tbl_karyawan.Id" &
                    " LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                    " WHERE tbl_transaksi_parent.Jenis IN ('K','C')" &
                    " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                    " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                    " AND tbl_transaksi_parent.Id_kasir = '" & My.Settings.ID_ACCOUNT & "'" &
                    " ORDER BY tbl_transaksi_parent.Tgl DESC, tbl_transaksi_child.Id DESC"
                End Select
            Case 3
                Select Case CBJENIS.SelectedIndex
                    Case 0
                        STR = "SELECT tbl_barang.Kode AS 'Kode Barang'," &
                    " tbl_barang.Barang AS 'Nama Barang'," &
                    " tbl_barang.Satuan AS 'Satuan'," &
                    " COALESCE(masuk.total_masuk, 0) AS 'Barang Masuk'," &
                    " COALESCE(keluar.total_keluar, 0) AS 'Barang Keluar'" &
                    " FROM tbl_barang" &
                    " LEFT JOIN (SELECT tc.Kode, SUM(tc.Jumlah) AS total_masuk FROM tbl_transaksi_child tc" &
                    " INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans" &
                    " WHERE tp.Jenis IN ('M','R') GROUP BY tc.Kode) masuk ON tbl_barang.Kode = masuk.Kode" &
                    " LEFT JOIN (SELECT tc.Kode, SUM(tc.Jumlah) AS total_keluar FROM tbl_transaksi_child tc" &
                    " INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans" &
                    " WHERE tp.Jenis IN ('K','C') GROUP BY tc.Kode) keluar ON tbl_barang.Kode = keluar.Kode" &
                    " ORDER BY tbl_barang.Barang ASC"
                    Case 1
                        STR = "SELECT RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                    " RTRIM(tbl_transaksi_parent.Jenis) AS 'Jenis'," &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " RTRIM(tbl_karyawan.Nama) AS 'Kasir'," &
                    " RTRIM(tbl_transaksi_parent.Person) AS 'Supplier'," &
                    " tbl_transaksi_child.Jumlah AS 'Jumlah_item'," &
                    " RTRIM(tbl_transaksi_child.Kode) As 'Kode Barang'," &
                    " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                    " tbl_transaksi_child.Harga  AS 'Harga QTY'," &
                    " tbl_transaksi_child.Jumlah AS 'Stok Masuk'," &
                    " (tbl_transaksi_child.Harga * tbl_transaksi_child.Jumlah) AS 'Harga'," &
                    " tbl_transaksi_child.Stok AS 'Sisa Stok'" &
                    " FROM tbl_transaksi_child" &
                    " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " LEFT JOIN tbl_karyawan ON tbl_transaksi_parent.Id_kasir = tbl_karyawan.Id" &
                    " LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                    " WHERE tbl_transaksi_parent.Jenis IN ('M','R')" &
                    " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                    " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                    " AND tbl_transaksi_parent.Id_kasir = '" & My.Settings.ID_ACCOUNT & "'" &
                    " ORDER BY tbl_transaksi_parent.Tgl DESC, tbl_transaksi_child.Id DESC"
                    Case 2
                        STR = "SELECT RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                    " RTRIM(tbl_transaksi_parent.Jenis) AS 'Jenis'," &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " RTRIM(tbl_karyawan.Nama) AS 'Kasir'," &
                    " RTRIM(tbl_transaksi_parent.Person) AS 'Pembeli'," &
                    " tbl_transaksi_parent.Jumlah_item AS 'Jumlah_item'," &
                    " RTRIM(tbl_transaksi_child.Kode) As 'Kode Barang'," &
                    " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                    " (tbl_transaksi_child.Harga / tbl_transaksi_child.Jumlah)  AS 'Harga QTY'," &
                    " tbl_transaksi_child.Jumlah AS 'QTY'," &
                    " tbl_transaksi_child.Harga  AS 'Harga Jual'," &
                    " tbl_transaksi_child.Diskon AS 'Diskon'," &
                    " tbl_transaksi_child.Harga_akhir AS 'Harga'," &
                    " tbl_transaksi_parent.Harga AS 'Total'," &
                    " tbl_transaksi_parent.Diskon AS 'Diskon Transaksi'," &
                    " tbl_transaksi_parent.Harga_total AS 'Total Akhir'," &
                    " tbl_transaksi_parent.Harga_tunai AS 'Bayar'," &
                    " tbl_transaksi_parent.Harga_kembali AS 'Kembalian'" &
                    " FROM tbl_transaksi_child" &
                    " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " LEFT JOIN tbl_karyawan ON tbl_transaksi_parent.Id_kasir = tbl_karyawan.Id" &
                    " LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                    " WHERE tbl_transaksi_parent.Jenis IN ('K','C')" &
                    " AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00'" &
                    " AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'" &
                    " AND tbl_transaksi_parent.Id_kasir = '" & My.Settings.ID_ACCOUNT & "'" &
                    " ORDER BY tbl_transaksi_parent.Tgl DESC, tbl_transaksi_child.Id DESC"
                End Select
        End Select

        Dim DA As New MySqlDataAdapter(STR, CONN)
        DA.SelectCommand.CommandTimeout = 60 ' 1 menit timeout
        TBL.Clear()
        TBL.Columns.Clear()
        DA.Fill(TBL)

        If TBL.Rows.Count = 0 Then
            ADA_TRANSAKSI = False
            MsgBox("Tidak ada transaksi")
        Else
            ADA_TRANSAKSI = True
            Select Case ROLE
                Case 1
                    Select Case CBJENIS.SelectedIndex
                        Case 0
                            With DT
                                .Clear()
                                .Columns.Clear()
                                .Columns.Add("Kode")
                                .Columns.Add("Nama Barang")
                                .Columns.Add("Satuan")
                                .Columns.Add("Opsi1")
                                .Columns.Add("Harga1")
                                .Columns.Add("Opsi2")
                                .Columns.Add("Harga2")
                                .Columns.Add("Opsi3")
                                .Columns.Add("Harga3")
                                .Columns.Add("Opsi4")
                                .Columns.Add("Harga4")
                                .Columns.Add("Opsi5")
                                .Columns.Add("Harga5")
                                .Columns.Add("Tanggal Diskon")
                                .Columns.Add("Diskon")
                            End With
                            For N = 0 To TBL.Rows.Count - 1
                                If TBL.Rows(N).Item(4) <> 0 And TBL.Rows(N).Item(6) <> 0 And TBL.Rows(N).Item(8) <> 0 And TBL.Rows(N).Item(10) <> 0 Then
                                    If Not IsDBNull(TBL.Rows(N).Item(14)) Then
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                Format(TBL.Rows(N).Item(6) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"),
                                                Format(TBL.Rows(N).Item(8) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(10), "##0.##"),
                                                Format(TBL.Rows(N).Item(9), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(10) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(11), "###,##"),
                                                TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                                                Format(TBL.Rows(N).Item(14), "##0.##") & "%")
                                    Else
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                Format(TBL.Rows(N).Item(6) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"),
                                                Format(TBL.Rows(N).Item(8) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(10), "##0.##"),
                                                Format(TBL.Rows(N).Item(9), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(10) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(11), "###,##"))
                                    End If
                                ElseIf TBL.Rows(N).Item(4) <> 0 And TBL.Rows(N).Item(6) <> 0 And TBL.Rows(N).Item(8) <> 0 And TBL.Rows(N).Item(10) = 0 Then
                                    If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                Format(TBL.Rows(N).Item(6) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(8) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(9), "###,##"),
                                                "",
                                                "",
                                                TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                                                Format(TBL.Rows(N).Item(14), "##0.##") & "%")
                                    Else
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                Format(TBL.Rows(N).Item(6) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(8) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(9), "###,##"))
                                    End If
                                ElseIf TBL.Rows(N).Item(4) <> 0 And TBL.Rows(N).Item(6) <> 0 And TBL.Rows(N).Item(8) = 0 And TBL.Rows(N).Item(10) = 0 Then
                                    If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(6) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"),
                                                "",
                                                "",
                                                "",
                                                "",
                                                TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                                                Format(TBL.Rows(N).Item(14), "##0.##") & "%")
                                    Else
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(6) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"))
                                    End If
                                ElseIf TBL.Rows(N).Item(4) <> 0 And TBL.Rows(N).Item(6) = 0 And TBL.Rows(N).Item(8) = 0 And TBL.Rows(N).Item(10) = 0 Then
                                    If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(4) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                                                Format(TBL.Rows(N).Item(14), "##0.##") & "%")
                                    Else
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(4) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"))
                                    End If
                                ElseIf TBL.Rows(N).Item(4) = 0 And TBL.Rows(N).Item(6) = 0 And TBL.Rows(N).Item(8) = 0 And TBL.Rows(N).Item(10) = 0 Then
                                    If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "",
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                                                Format(TBL.Rows(N).Item(14), "##0.##") & "%")
                                    Else
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "",
                                                Format(TBL.Rows(N).Item(3), "###,##"))
                                    End If
                                End If
                            Next
                        Case 2
                            ' Query langsung untuk total pembelian - lebih akurat
                            Dim cmdPembelian As New MySqlCommand(
                                "SELECT COALESCE(SUM(tbl_transaksi_child.Harga * tbl_transaksi_child.Jumlah), 0) FROM tbl_transaksi_child " &
                                "INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans " &
                                "WHERE tbl_transaksi_parent.Jenis IN ('M','R') " &
                                "AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59'", CONN)
                            TOTALPEMBELIAN = Convert.ToDouble(cmdPembelian.ExecuteScalar())

                            TOTALITEM = Convert.ToDouble(TBL.Compute("SUM(Jumlah_item)", ""))
                        Case 3
                            ' Satu query untuk semua total: penjualan, laba, item
                            Dim cmdSummary As New MySqlCommand(
                                "SELECT COALESCE(SUM(p.Harga_total), 0), " &
                                "COALESCE(SUM(COALESCE(c.total_laba, 0) - p.Diskon), 0), " &
                                "COALESCE(SUM(p.Jumlah_item), 0) " &
                                "FROM tbl_transaksi_parent p " &
                                "LEFT JOIN (SELECT tc.Id_trans, SUM(tc.Harga_akhir - tc.Harga_beli) AS total_laba FROM tbl_transaksi_child tc " &
                                "INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans " &
                                "WHERE tp.Jenis IN ('K','C') AND tp.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND tp.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "GROUP BY tc.Id_trans) c ON c.Id_trans = p.Id_trans " &
                                "WHERE p.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND p.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "AND p.Jenis IN ('K','C')", CONN)
                            Dim dtSummary As New DataTable()
                            dtSummary.Load(cmdSummary.ExecuteReader())
                            If dtSummary.Rows.Count > 0 Then
                                TOTALPENJUALAN = Convert.ToInt64(dtSummary.Rows(0)(0))
                                TOTALLABA = Convert.ToDouble(dtSummary.Rows(0)(1))
                                TOTALITEM = Math.Round(Convert.ToDouble(dtSummary.Rows(0)(2)), 2)
                            End If
                        Case 4
                            ' Satu query untuk semua total: penjualan, laba, item
                            Dim cmdSummary As New MySqlCommand(
                                "SELECT COALESCE(SUM(p.Harga_total), 0), " &
                                "COALESCE(SUM(COALESCE(c.total_laba, 0) - p.Diskon), 0), " &
                                "COALESCE(SUM(p.Jumlah_item), 0) " &
                                "FROM tbl_transaksi_parent p " &
                                "LEFT JOIN (SELECT tc.Id_trans, SUM(tc.Harga_akhir - tc.Harga_beli) AS total_laba FROM tbl_transaksi_child tc " &
                                "INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans " &
                                "WHERE tp.Jenis IN ('K','C') AND tp.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND tp.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "GROUP BY tc.Id_trans) c ON c.Id_trans = p.Id_trans " &
                                "WHERE p.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND p.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "AND p.Jenis IN ('K','C')", CONN)
                            Dim dtSummary As New DataTable()
                            dtSummary.Load(cmdSummary.ExecuteReader())
                            If dtSummary.Rows.Count > 0 Then
                                TOTALPENJUALAN = Convert.ToDouble(dtSummary.Rows(0)(0))
                                TOTALLABA = Convert.ToDouble(dtSummary.Rows(0)(1))
                                TOTALITEM = Convert.ToDouble(dtSummary.Rows(0)(2))
                            End If
                        Case 5
                            ' Total laba dengan JOIN
                            Dim cmdLaba As New MySqlCommand(
                                "SELECT COALESCE(SUM(COALESCE(c.total_laba, 0) - p.Diskon), 0) " &
                                "FROM tbl_transaksi_parent p " &
                                "LEFT JOIN (SELECT tc.Id_trans, SUM(tc.Harga_akhir - tc.Harga_beli) AS total_laba FROM tbl_transaksi_child tc " &
                                "INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans " &
                                "WHERE tp.Jenis IN ('K','C') AND tp.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND tp.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "GROUP BY tc.Id_trans) c ON c.Id_trans = p.Id_trans " &
                                "WHERE p.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND p.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "AND p.Jenis IN ('K','C')", CONN)
                            TOTALLABA = Convert.ToDouble(cmdLaba.ExecuteScalar())
                        Case 6
                            ' Satu query untuk total penjualan, laba
                            Dim cmdSummary As New MySqlCommand(
                                "SELECT COALESCE(SUM(p.Harga_total), 0), " &
                                "COALESCE(SUM(COALESCE(c.total_laba, 0) - p.Diskon), 0) " &
                                "FROM tbl_transaksi_parent p " &
                                "LEFT JOIN (SELECT tc.Id_trans, SUM(tc.Harga_akhir - tc.Harga_beli) AS total_laba FROM tbl_transaksi_child tc " &
                                "INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans " &
                                "WHERE tp.Jenis IN ('K','C') AND tp.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND tp.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "GROUP BY tc.Id_trans) c ON c.Id_trans = p.Id_trans " &
                                "WHERE p.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND p.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "AND p.Jenis IN ('K','C')", CONN)
                            Dim dtSummary As New DataTable()
                            dtSummary.Load(cmdSummary.ExecuteReader())
                            If dtSummary.Rows.Count > 0 Then
                                TOTALPENJUALAN = Convert.ToDouble(dtSummary.Rows(0)(0))
                                TOTALLABA = Convert.ToDouble(dtSummary.Rows(0)(1))
                            End If

                            TOTALITEM = Convert.ToDouble(TBL.Compute("SUM([Jumlah Item])", ""))
                        Case 7
                            For N = 1 To TBL.Rows.Count - 1
                                If TBL.Rows(N).Item(0) = TBL.Rows(N - 1).Item(0) Then
                                    TBL.Rows(N).Item(1) = 0
                                    For J = N To TBL.Rows.Count - 1
                                        If TBL.Rows(J).Item(0) = TBL.Rows(J - 1).Item(0) Then
                                            TBL.Rows(J).Item(1) = 0
                                        End If
                                    Next
                                End If
                            Next
                            TOTALITEM = Convert.ToDouble(TBL.Compute("SUM(Jumlah_item)", ""))
                        Case 8
                            For N = 1 To TBL.Rows.Count - 1
                                If TBL.Rows(N).Item(0) = TBL.Rows(N - 1).Item(0) Then
                                    TBL.Rows(N).Item(1) = 0
                                    For J = N To TBL.Rows.Count - 1
                                        If TBL.Rows(J).Item(0) = TBL.Rows(J - 1).Item(0) Then
                                            TBL.Rows(J).Item(1) = 0
                                        End If
                                    Next
                                End If
                            Next
                            TOTALITEM = Convert.ToDouble(TBL.Compute("SUM(Jumlah_item)", ""))
                        Case 10
                            ' Total laba dengan JOIN
                            Dim cmdLaba As New MySqlCommand(
                                "SELECT COALESCE(SUM(COALESCE(c.total_laba, 0) - p.Diskon), 0) " &
                                "FROM tbl_transaksi_parent p " &
                                "LEFT JOIN (SELECT tc.Id_trans, SUM(tc.Harga_akhir - tc.Harga_beli) AS total_laba FROM tbl_transaksi_child tc " &
                                "INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans " &
                                "WHERE tp.Jenis IN ('K','C') AND tp.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND tp.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "GROUP BY tc.Id_trans) c ON c.Id_trans = p.Id_trans " &
                                "WHERE p.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND p.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "AND p.Jenis IN ('K','C')", CONN)
                            TOTALLABA = Convert.ToDouble(cmdLaba.ExecuteScalar())
                        Case 11
                            ' Total laba dengan JOIN
                            Dim LASTDAYOFMONTH = DateTime.DaysInMonth(TXTTGLAKHIR.Value.ToString("yyyy"), TXTTGLAKHIR.Value.ToString("MM"))
                            Dim cmdLaba As New MySqlCommand(
                                "SELECT COALESCE(SUM(COALESCE(c.total_laba, 0) - p.Diskon), 0) " &
                                "FROM tbl_transaksi_parent p " &
                                "LEFT JOIN (SELECT tc.Id_trans, SUM(tc.Harga_akhir - tc.Harga_beli) AS total_laba FROM tbl_transaksi_child tc " &
                                "INNER JOIN tbl_transaksi_parent tp ON tc.Id_trans = tp.Id_trans " &
                                "WHERE tp.Jenis IN ('K','C') AND tp.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-01") & " 00:00:00' " &
                                "AND tp.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-" & LASTDAYOFMONTH) & " 23:59:59' " &
                                "GROUP BY tc.Id_trans) c ON c.Id_trans = p.Id_trans " &
                                "WHERE p.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-01") & " 00:00:00' " &
                                "AND p.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-" & LASTDAYOFMONTH) & " 23:59:59' " &
                                "AND p.Jenis IN ('K','C')", CONN)
                            TOTALLABA = Convert.ToDouble(cmdLaba.ExecuteScalar())
                    End Select
                Case 2
                    Select Case CBJENIS.SelectedIndex
                        Case 0
                            With DT
                                .Clear()
                                .Columns.Clear()
                                .Columns.Add("Kode")
                                .Columns.Add("Nama Barang")
                                .Columns.Add("Satuan")
                                .Columns.Add("Opsi1")
                                .Columns.Add("Harga1")
                                .Columns.Add("Opsi2")
                                .Columns.Add("Harga2")
                                .Columns.Add("Opsi3")
                                .Columns.Add("Harga3")
                                .Columns.Add("Opsi4")
                                .Columns.Add("Harga4")
                                .Columns.Add("Opsi5")
                                .Columns.Add("Harga5")
                                .Columns.Add("Tanggal Diskon")
                                .Columns.Add("Diskon")
                            End With
                            For N = 0 To TBL.Rows.Count - 1
                                If TBL.Rows(N).Item(4) <> 0 And TBL.Rows(N).Item(6) <> 0 And TBL.Rows(N).Item(8) <> 0 And TBL.Rows(N).Item(10) <> 0 Then
                                    If Not IsDBNull(TBL.Rows(N).Item(14)) Then
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                Format(TBL.Rows(N).Item(6) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"),
                                                Format(TBL.Rows(N).Item(8) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(10), "##0.##"),
                                                Format(TBL.Rows(N).Item(9), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(10) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(11), "###,##"),
                                                TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                                                Format(TBL.Rows(N).Item(14), "##0.##") & "%")
                                    Else
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                Format(TBL.Rows(N).Item(6) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"),
                                                Format(TBL.Rows(N).Item(8) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(10), "##0.##"),
                                                Format(TBL.Rows(N).Item(9), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(10) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(11), "###,##"))
                                    End If
                                ElseIf TBL.Rows(N).Item(4) <> 0 And TBL.Rows(N).Item(6) <> 0 And TBL.Rows(N).Item(8) <> 0 And TBL.Rows(N).Item(10) = 0 Then
                                    If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                Format(TBL.Rows(N).Item(6) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(8) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(9), "###,##"),
                                                "",
                                                "",
                                                TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                                                Format(TBL.Rows(N).Item(14), "##0.##") & "%")
                                    Else
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                Format(TBL.Rows(N).Item(6) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(8) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(9), "###,##"))
                                    End If
                                ElseIf TBL.Rows(N).Item(4) <> 0 And TBL.Rows(N).Item(6) <> 0 And TBL.Rows(N).Item(8) = 0 And TBL.Rows(N).Item(10) = 0 Then
                                    If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(6) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"),
                                                "",
                                                "",
                                                "",
                                                "",
                                                TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                                                Format(TBL.Rows(N).Item(14), "##0.##") & "%")
                                    Else
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                Format(TBL.Rows(N).Item(4) + 1, "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(6) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(7), "###,##"))
                                    End If
                                ElseIf TBL.Rows(N).Item(4) <> 0 And TBL.Rows(N).Item(6) = 0 And TBL.Rows(N).Item(8) = 0 And TBL.Rows(N).Item(10) = 0 Then
                                    If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(4) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"),
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                                                Format(TBL.Rows(N).Item(14), "##0.##") & "%")
                                    Else
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                " >= " & Format(TBL.Rows(N).Item(4) + 1, "##0.##"),
                                                Format(TBL.Rows(N).Item(5), "###,##"))
                                    End If
                                ElseIf TBL.Rows(N).Item(4) = 0 And TBL.Rows(N).Item(6) = 0 And TBL.Rows(N).Item(8) = 0 And TBL.Rows(N).Item(10) = 0 Then
                                    If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "",
                                                Format(TBL.Rows(N).Item(3), "###,##"),
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                                                Format(TBL.Rows(N).Item(14), "##0.##") & "%")
                                    Else
                                        DT.Rows.Add(TBL.Rows(N).Item(0),
                                                TBL.Rows(N).Item(1),
                                                TBL.Rows(N).Item(2),
                                                "",
                                                Format(TBL.Rows(N).Item(3), "###,##"))
                                    End If
                                End If
                            Next
                        Case 2
                            ' Query langsung untuk total pembelian - lebih akurat
                            Dim cmdPembelian As New MySqlCommand(
                                "SELECT COALESCE(SUM(tbl_transaksi_child.Harga * tbl_transaksi_child.Jumlah), 0) FROM tbl_transaksi_child " &
                                "INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans " &
                                "WHERE tbl_transaksi_parent.Jenis IN ('M','R') " &
                                "AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "AND tbl_transaksi_parent.Id_kasir = '" & My.Settings.ID_ACCOUNT & "'", CONN)
                            TOTALPEMBELIAN = Convert.ToDouble(cmdPembelian.ExecuteScalar())

                            TOTALITEM = Convert.ToDouble(TBL.Compute("SUM(Jumlah_item)", ""))
                        Case 3
                            ' Query langsung untuk total penjualan - lebih cepat
                            Dim cmdTotal As New MySqlCommand(
                                "SELECT COALESCE(SUM(Harga_total), 0) FROM tbl_transaksi_parent " &
                                "WHERE Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "AND Id_kasir = '" & My.Settings.ID_ACCOUNT & "' " &
                                "AND (Jenis = 'K' OR Jenis = 'C')", CONN)
                            TOTALPENJUALAN = Convert.ToInt64(cmdTotal.ExecuteScalar())

                            ' Hitung total item langsung dari database untuk menghindari duplikasi
                            Dim cmdItem As New MySqlCommand(
                                "SELECT COALESCE(SUM(Jumlah_item), 0) FROM tbl_transaksi_parent " &
                                "WHERE Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "AND Id_kasir = '" & My.Settings.ID_ACCOUNT & "' " &
                                "AND (Jenis = 'K' OR Jenis = 'C')", CONN)
                            TOTALITEM = Convert.ToDouble(cmdItem.ExecuteScalar())
                            TOTALITEM = Math.Round(TOTALITEM, 2)
                    End Select
                Case 3
                    Select Case CBJENIS.SelectedIndex
                        Case 1
                            ' Query langsung untuk total pembelian - lebih akurat
                            Dim cmdPembelian As New MySqlCommand(
                                "SELECT COALESCE(SUM(tbl_transaksi_child.Harga * tbl_transaksi_child.Jumlah), 0) FROM tbl_transaksi_child " &
                                "INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans " &
                                "WHERE tbl_transaksi_parent.Jenis IN ('M','R') " &
                                "AND tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "AND tbl_transaksi_parent.Id_kasir = '" & My.Settings.ID_ACCOUNT & "'", CONN)
                            TOTALPEMBELIAN = Convert.ToDouble(cmdPembelian.ExecuteScalar())

                            TOTALITEM = Convert.ToDouble(TBL.Compute("SUM(Jumlah_item)", ""))
                        Case 2
                            ' Query langsung untuk total penjualan - lebih cepat
                            Dim cmdTotal As New MySqlCommand(
                                "SELECT COALESCE(SUM(Harga_total), 0) FROM tbl_transaksi_parent " &
                                "WHERE Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "AND Id_kasir = '" & My.Settings.ID_ACCOUNT & "' " &
                                "AND (Jenis = 'K' OR Jenis = 'C')", CONN)
                            TOTALPENJUALAN = Convert.ToInt64(cmdTotal.ExecuteScalar())

                            ' Hitung total item langsung dari database untuk menghindari duplikasi
                            Dim cmdItem As New MySqlCommand(
                                "SELECT COALESCE(SUM(Jumlah_item), 0) FROM tbl_transaksi_parent " &
                                "WHERE Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd") & " 00:00:00' " &
                                "AND Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd") & " 23:59:59' " &
                                "AND Id_kasir = '" & My.Settings.ID_ACCOUNT & "' " &
                                "AND (Jenis = 'K' OR Jenis = 'C')", CONN)
                            TOTALITEM = Convert.ToDouble(cmdItem.ExecuteScalar())
                            TOTALITEM = Math.Round(TOTALITEM, 2)
                    End Select
            End Select

        End If

        TUTUP_KONEKSI()
    End Sub

    Sub KONDISI_AWAL()
        Label6.Visible = False
        Label7.Visible = False
        TXTTGLAWAL.Visible = False
        TXTTGLAKHIR.Visible = False
        BTNTAMPIL.Visible = False
    End Sub

    Sub KONDISI_BULAN()
        Label6.Visible = True
        Label7.Visible = True
        TXTTGLAWAL.Visible = True
        TXTTGLAKHIR.Visible = True
        BTNTAMPIL.Visible = True

        TXTTGLAWAL.ShowUpDown = True
        TXTTGLAWAL.Format = DateTimePickerFormat.Custom
        TXTTGLAWAL.CustomFormat = " MMMM yyyy"

        TXTTGLAKHIR.ShowUpDown = True
        TXTTGLAKHIR.Format = DateTimePickerFormat.Custom
        TXTTGLAKHIR.CustomFormat = " MMMM yyyy"

        Label6.Text = "Bulan"
    End Sub

    Sub KONDISI_TANGGAL()
        Label6.Visible = True
        Label7.Visible = True
        TXTTGLAWAL.Visible = True
        TXTTGLAKHIR.Visible = True
        BTNTAMPIL.Visible = True

        TXTTGLAWAL.ShowUpDown = False
        TXTTGLAWAL.Format = DateTimePickerFormat.Short

        TXTTGLAKHIR.ShowUpDown = False
        TXTTGLAKHIR.Format = DateTimePickerFormat.Short

        Label6.Text = "Tanggal"
    End Sub

    Private Sub BTNTAMPIL_Click(sender As Object, e As EventArgs) Handles BTNTAMPIL.Click
        If CBJENIS.Text <> "" Then
            Me.Cursor = Cursors.WaitCursor
            BTNTAMPIL.Enabled = False
            Application.DoEvents()
            TAMPIL()
        End If
        If ADA_TRANSAKSI Then
            ' Clear report lama sebelum set report baru
            CRV.ReportSource = Nothing
            Select Case ROLE
                Case 1
                    Select Case CBJENIS.SelectedIndex
                        Case 0
                            Dim RPT As New RPT_CETAKHARGA
                            With RPT
                                .SetDataSource(DT)
                                .SetParameterValue("datetime", LBTGL.Text)
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 1
                            Dim RPT As New RPT_STOK
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("datetime", LBTGL.Text)
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 2
                            Dim RPT As New RPT_MASUK
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("total_item", TOTALITEM)
                                .SetParameterValue("total_beli", TOTALPEMBELIAN)
                                .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 3
                            Dim RPT As New RPT_KELUAR
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("total_laba", TOTALLABA)
                                .SetParameterValue("total_item", TOTALITEM)
                                .SetParameterValue("total_penjualan", TOTALPENJUALAN)
                                .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 4
                            Dim RPT As New RPT_PENJUALAN_BARANG
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                                .SetParameterValue("total_item", TOTALITEM)
                                .SetParameterValue("total_beli", Convert.ToDouble(TBL.Compute("SUM([Harga Beli])", "")))
                                .SetParameterValue("total_jual", TOTALPENJUALAN)
                                .SetParameterValue("total_diskon", Convert.ToDouble(TBL.Compute("SUM([Diskon Trans])", "")))
                                .SetParameterValue("total_laba", TOTALLABA)
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 5
                            Dim RPT As New RPT_PENJUALAN_HARIAN
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                                .SetParameterValue("total_laba", TOTALLABA)
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 6
                            Dim RPT As New RPT_PENJUALAN_BARANG_B
                            With RPT
                                .SetDataSource(TBL)
                                Try
                                    .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                Catch ex As Exception
                                    ' Parameter tgl_mulai tidak ada
                                End Try
                                Try
                                    .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                                Catch ex As Exception
                                    ' Parameter tgl_akhir tidak ada
                                End Try
                                Try
                                    .SetParameterValue("total_item", TOTALITEM)
                                Catch ex As Exception
                                    ' Parameter total_item tidak ada
                                End Try
                                Try
                                    .SetParameterValue("total_jual", TOTALPENJUALAN)
                                Catch ex As Exception
                                    ' Parameter total_jual tidak ada
                                End Try
                                Try
                                    .SetParameterValue("total_laba", TOTALLABA)
                                Catch ex As Exception
                                    ' Parameter total_laba tidak ada
                                End Try
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 7
                            Dim RPT As New RPT_GRAFIK_PENJUALAN_HARIAN
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("total_item", TOTALITEM)
                                .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 8
                            Dim RPT As New RPT_GRAFIK_PENJUALAN_BULANAN
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("total_item", TOTALITEM)
                                .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("MMMM yyyy"))
                                .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("MMMM yyyy"))
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 9
                            Dim RPT As New RPT_GRAFIK_PENJUALAN_BARANG_HARIAN
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("total_item", TOTALITEM)
                                .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 10
                            Dim RPT As New RPT_GRAFIK_LABA_HARIAN
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("total_laba", TOTALLABA)
                                .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 11
                            Dim RPT As New RPT_GRAFIK_LABA_BULANAN
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("total_laba", TOTALLABA)
                                .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("MMMM yyyy"))
                                .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("MMMM yyyy"))
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                    End Select
                Case 2
                    Select Case CBJENIS.SelectedIndex
                        Case 0
                            Dim RPT As New RPT_CETAKHARGA
                            With RPT
                                .SetDataSource(DT)
                                .SetParameterValue("datetime", LBTGL.Text)
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 1
                            Dim RPT As New RPT_STOK
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("datetime", LBTGL.Text)
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 2
                            Dim RPT As New RPT_MASUK_OPS
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("total_item", TOTALITEM)
                                .SetParameterValue("total_beli", TOTALPEMBELIAN)
                                .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 3
                            Dim RPT As New RPT_KELUAR_KASIR
                            With RPT
                                .SetDataSource(TBL)
                                Try
                                    .SetParameterValue("total_item", TOTALITEM)
                                Catch ex As Exception
                                End Try
                                Try
                                    .SetParameterValue("total_penjualan", TOTALPENJUALAN)
                                Catch ex As Exception
                                End Try
                                Try
                                    .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                Catch ex As Exception
                                End Try
                                Try
                                    .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                                Catch ex As Exception
                                End Try
                                Try
                                    .SetParameterValue("nama_kasir", LBLUSER.Text)
                                Catch ex As Exception
                                End Try
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                    End Select
                Case 3
                    Select Case CBJENIS.SelectedIndex
                        Case 0
                            Dim RPT As New RPT_STOK
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("datetime", LBTGL.Text)
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 1
                            Dim RPT As New RPT_MASUK_OPS
                            With RPT
                                .SetDataSource(TBL)
                                .SetParameterValue("total_item", TOTALITEM)
                                .SetParameterValue("total_beli", TOTALPEMBELIAN)
                                .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                        Case 2
                            Dim RPT As New RPT_KELUAR_KASIR
                            With RPT
                                .SetDataSource(TBL)
                                Try
                                    .SetParameterValue("total_item", TOTALITEM)
                                Catch ex As Exception
                                End Try
                                Try
                                    .SetParameterValue("total_penjualan", TOTALPENJUALAN)
                                Catch ex As Exception
                                End Try
                                Try
                                    .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                                Catch ex As Exception
                                End Try
                                Try
                                    .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                                Catch ex As Exception
                                End Try
                                Try
                                    .SetParameterValue("nama_kasir", LBLUSER.Text)
                                Catch ex As Exception
                                End Try
                            End With

                            BTNCETAK.Visible = True
                            BTNEXPORT.Visible = True
                            CRV.ReportSource = RPT
                    End Select
            End Select
        End If
        Me.Cursor = Cursors.Default
        BTNTAMPIL.Enabled = True
    End Sub

    Private Sub BTNCETAK_Click(sender As Object, e As EventArgs) Handles BTNCETAK.Click
        Dim printDialog1 As New PrintDialog
        Dim printDocument1 As New System.Drawing.Printing.PrintDocument
        'Open the PrintDialog
        printDialog1.Document = printDocument1

        Dim dr As DialogResult = printDialog1.ShowDialog()

        'Here's where you can catch them aborting the print..

        If dr = System.Windows.Forms.DialogResult.OK Then
            'Get the Copy times
            Dim nCopies As Integer = printDocument1.PrinterSettings.Copies
            'Get the number of Start Page
            Dim sPage As Integer = printDocument1.PrinterSettings.FromPage
            'Get the number of End page
            Dim ePage As Integer = printDocument1.PrinterSettings.ToPage
            'Get the printer name
            Dim PrinterName As String = printDocument1.PrinterSettings.PrinterName

            Dim crReportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
            'Create an instance of a report
            crReportDocument = CRV.ReportSource
            Try
                crReportDocument.PrintOptions.PrinterName = PrinterName
                crReportDocument.PrintToPrinter(nCopies, False, sPage, ePage)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub CBJENIS_TextChanged(sender As Object, e As EventArgs) Handles CBJENIS.TextChanged
        Select Case ROLE
            Case 1
                Select Case CBJENIS.SelectedIndex
                    Case 0
                        Label6.Visible = False
                        Label7.Visible = False
                        TXTTGLAWAL.Visible = False
                        TXTTGLAKHIR.Visible = False
                        BTNTAMPIL.Visible = True
                    Case 1
                        Label6.Visible = False
                        Label7.Visible = False
                        TXTTGLAWAL.Visible = False
                        TXTTGLAKHIR.Visible = False
                        BTNTAMPIL.Visible = True
                    Case 2
                        KONDISI_TANGGAL()
                    Case 3
                        KONDISI_TANGGAL()
                    Case 4
                        KONDISI_TANGGAL()
                    Case 5
                        KONDISI_TANGGAL()
                    Case 6
                        KONDISI_TANGGAL()
                    Case 7
                        KONDISI_TANGGAL()
                    Case 8
                        KONDISI_BULAN()
                    Case 9
                        KONDISI_TANGGAL()
                    Case 10
                        KONDISI_TANGGAL()
                    Case 11
                        KONDISI_BULAN()
                End Select
            Case 2
                Select Case CBJENIS.SelectedIndex
                    Case 0
                        Label6.Visible = False
                        Label7.Visible = False
                        TXTTGLAWAL.Visible = False
                        TXTTGLAKHIR.Visible = False
                        BTNTAMPIL.Visible = True
                    Case 1
                        Label6.Visible = False
                        Label7.Visible = False
                        TXTTGLAWAL.Visible = False
                        TXTTGLAKHIR.Visible = False
                        BTNTAMPIL.Visible = True
                    Case 2
                        KONDISI_TANGGAL()
                    Case 3
                        KONDISI_TANGGAL()
                End Select
            Case 3
                Select Case CBJENIS.SelectedIndex
                    Case 0
                        Label6.Visible = False
                        Label7.Visible = False
                        TXTTGLAWAL.Visible = False
                        TXTTGLAKHIR.Visible = False
                        BTNTAMPIL.Visible = True
                    Case 1
                        KONDISI_TANGGAL()
                    Case 2
                        KONDISI_TANGGAL()
                End Select
        End Select
    End Sub

    Private Sub TXTTGLAWAL_Leave(sender As Object, e As EventArgs) Handles TXTTGLAWAL.Leave
        If TXTTGLAWAL.Value > TXTTGLAKHIR.Value Then
            TXTTGLAKHIR.Value = TXTTGLAWAL.Value
        End If
    End Sub

    Private Sub TXTTGLAKHIR_Leave(sender As Object, e As EventArgs) Handles TXTTGLAKHIR.Leave
        If TXTTGLAKHIR.Value < TXTTGLAWAL.Value Then
            MsgBox("Tanggal akhir harus lebih dari atau sama dengan tanggal awal!")
            TXTTGLAKHIR.Value = TXTTGLAWAL.Value
        End If
    End Sub

    Private Sub BTNEXPORT_Click(sender As Object, e As EventArgs) Handles BTNEXPORT.Click
        Dim formats As Integer
        formats = (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat Or CrystalDecisions.Shared.ViewerExportFormats.ExcelFormat)

        CRV.AllowedExportFormats = formats
        CRV.ExportReport()
    End Sub

    Private Sub BTNLABELADMIN_Click(sender As Object, e As EventArgs) Handles BTNLABELADMIN.Click
        BUKA_FORM(FR_CETAK_LABEL)
    End Sub

    Private Sub BTNKASIR_Click(sender As Object, e As EventArgs) Handles BTNKASIR.Click
        BUKA_FORM(FR_KASIR)
    End Sub

    Private Sub BTNBARANG_Click(sender As Object, e As EventArgs) Handles BTNBARANG.Click
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub BTNDISKON_Click(sender As Object, e As EventArgs) Handles BTNDISKON.Click
        BUKA_FORM(FR_DISKON)
    End Sub

    Private Sub BTNMASUK_Click(sender As Object, e As EventArgs) Handles BTNMASUK.Click
        BUKA_FORM(FR_MASUK)
    End Sub

    Private Sub BTNKELUAR_Click(sender As Object, e As EventArgs) Handles BTNKELUAR.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNHISTORYPENJUALAN_Click(sender As Object, e As EventArgs) Handles BTNHISTORYPENJUALAN.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNMEMBER_ADMIN_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_ADMIN.Click
        BUKA_FORM(FR_MEMBER)
    End Sub

    Private Sub BTNVOUCHER_ADMIN_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_ADMIN.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub BTNDASHBOARDOPS_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDOPS.Click
        BUKA_FORM(FR_OPS_DASHBOARD)
    End Sub

    Private Sub BTNBARANGOPS_Click(sender As Object, e As EventArgs) Handles BTNBARANGOPS.Click
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub BTNHISTORYOPS_Click(sender As Object, e As EventArgs) Handles BTNHISTORYOPS.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNKELUAROPS_Click(sender As Object, e As EventArgs) Handles BTNKELUAROPS.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNLABELOPS_Click(sender As Object, e As EventArgs) Handles BTNLABELOPS.Click
        BUKA_FORM(FR_CETAK_LABEL)
    End Sub

    Private Sub BTNMEMBER_OPS_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_OPS.Click
        BUKA_FORM(FR_MEMBER)
    End Sub

    Private Sub BTNMASUKOPS_Click(sender As Object, e As EventArgs) Handles BTNMASUKOPS.Click
        BUKA_FORM(FR_MASUK)
    End Sub

    Private Sub BTNRETURNOPS_Click(sender As Object, e As EventArgs) Handles BTNRETURNOPS.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAKOPS_Click(sender As Object, e As EventArgs) Handles BTNRUSAKOPS.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub BTNTENTANGOPS_Click(sender As Object, e As EventArgs) Handles BTNTENTANGOPS.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNVOUCHER_OPS_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_OPS.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub BTNDASHBOARDKASIR_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDKASIR.Click
        BUKA_FORM(FR_KASIR_DASHBOARD)
    End Sub

    Private Sub BTNVOUCHER_KASIR_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_KASIR.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub BTNLABELKASIR_Click(sender As Object, e As EventArgs) Handles BTNLABELKASIR.Click
        BUKA_FORM(FR_CETAK_LABEL)
    End Sub

    Private Sub BTNMASUKKASIR_Click(sender As Object, e As EventArgs) Handles BTNMASUKKASIR.Click
        BUKA_FORM(FR_MASUK)
    End Sub

    Private Sub BTNKELUARKASIR_Click(sender As Object, e As EventArgs) Handles BTNKELUARKASIR.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNHISTORYPENJUALANKASIR_Click(sender As Object, e As EventArgs) Handles BTNHISTORYPENJUALANKASIR.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNRETURNKASIR_Click(sender As Object, e As EventArgs) Handles BTNRETURNKASIR.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNMEMBER_KASIR_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_KASIR.Click
        BUKA_FORM(FR_MEMBER)
    End Sub

    Private Sub BTNSETTINGKASIR_Click(sender As Object, e As EventArgs) Handles BTNSETTINGKASIR.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub CBJENIS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBJENIS.SelectedIndexChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class