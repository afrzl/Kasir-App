Imports System.Data.SqlClient

Public Class FR_REPORT
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub BTNEXIT_Click(sender As Object, e As EventArgs)
        Dim FR As New FR_LOGIN
        My.Settings.ID_ACCOUNT = 0
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
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

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        Dim FR As New FR_LOGIN
        My.Settings.ID_ACCOUNT = 0
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub FR_REPORT_Load(sender As Object, e As EventArgs) Handles Me.Load
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN
    End Sub


    Dim STR As String = ""
    Dim TBL As New DataTable
    Sub TAMPIL()
        Select Case CBJENIS.SelectedIndex
            Case 0
                STR = "SELECT RTRIM(Id_trans) AS 'ID Transaksi'," &
                    " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) AS 'Supplier'," &
                    " RTRIM((SELECT Nama FROM tbl_karyawan WHERE Id = (SELECT Id_kasir FROM tbl_transaksi_parent WHERE RTRIM(Id_trans) = RTRIM(tbl_transaksi_child.Id_trans)))) AS 'Kasir'," &
                    " RTRIM(Kode) AS 'Kode Barang'," &
                    " RTRIM((SELECT Barang FROM tbl_barang WHERE kode = tbl_transaksi_child.kode)) as 'Nama Barang'," &
                    " RTRIM(Jumlah) AS 'Stok Masuk'," &
                    " Harga AS 'Harga Partai'," &
                    " RTRIM(Stok) AS 'Stok Sisa'" &
                    " FROM tbl_transaksi_child WHERE LEFT(Id_trans, 1) = 'M'" &
                    " AND (SELECT Tgl FROM tbl_transaksi_parent WHERE RTRIM(Id_trans) = rtrim(tbl_transaksi_child.Id_trans)) >= '" & Format(TXTTGLAWAL.Value, "yyyy-MM-dd") & "'" &
                    " AND (SELECT Tgl FROM tbl_transaksi_parent WHERE RTRIM(Id_trans) = rtrim(tbl_transaksi_child.Id_trans)) <= '" & Format(TXTTGLAKHIR.Value, "yyyy-MM-dd") & "'" &
                    " ORDER BY Id ASC"
            Case 1
                STR = "SELECT RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " RTRIM((SELECT Nama FROM tbl_karyawan WHERE Id = tbl_transaksi_parent.Id_kasir)) AS 'Kasir'," &
                    " RTRIM(tbl_transaksi_parent.Person) AS 'Pembeli'," &
                    " RTRIM(tbl_transaksi_parent.Jumlah_item) AS 'Jumlah Item'," &
                    " RTRIM(tbl_transaksi_child.Kode) As 'Kode Barang'," &
                    " RTRIM((SELECT Barang FROM tbl_barang WHERE Kode = tbl_transaksi_child.Kode)) AS 'Nama Barang'," &
                    " tbl_transaksi_child.Harga AS 'Harga Jual'," &
                    " tbl_transaksi_child.Diskon AS 'Diskon'," &
                    " tbl_transaksi_child.Harga_akhir AS 'Harga'," &
                    " tbl_transaksi_parent.Harga AS 'Total'," &
                    " tbl_transaksi_parent.Diskon AS 'Diskon Transaksi'," &
                    " tbl_transaksi_parent.Harga_total AS 'Total Akhir'," &
                    " tbl_transaksi_parent.Harga_tunai AS 'Bayar'," &
                    " tbl_transaksi_parent.Harga_kembali AS 'Kembalian'," &
                    " (SELECT COALESCE(SUM(tbl_transaksi_child.Harga_akhir), 0) - COALESCE(SUM(tbl_transaksi_child.Harga_beli), 0) FROM tbl_transaksi_child WHERE tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans) - tbl_transaksi_parent.Diskon AS 'Laba'" &
                    " From tbl_transaksi_child inner Join tbl_transaksi_parent On tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " Where Left(tbl_transaksi_child.Id_trans, 1) = 'K'" &
                    " And tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd 00:00:00") & "'" &
                    " And tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd 23:59:59") & "'" &
                    " ORDER BY tbl_transaksi_child.Id ASC"
        End Select

        Dim DA As New SqlDataAdapter(STR, CONN)
        TBL.Clear()
        TBL.Columns.Clear()
        DA.Fill(TBL)
        DGTAMPIL.DataSource = TBL

        For Each ECOLUMN As DataGridViewColumn In DGTAMPIL.Columns
            ECOLUMN.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        Select Case CBJENIS.SelectedIndex
            Case 0
                DGTAMPIL.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGTAMPIL.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGTAMPIL.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                DGTAMPIL.Columns(6).DefaultCellStyle.Format = "###,###,###"
            Case 1
                DGTAMPIL.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGTAMPIL.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGTAMPIL.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGTAMPIL.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGTAMPIL.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGTAMPIL.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGTAMPIL.Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                For N = 1 To DGTAMPIL.Rows.Count - 1
                    DGTAMPIL.Columns(7).DefaultCellStyle.Format = "###,###,###"
                    DGTAMPIL.Columns(8).DefaultCellStyle.Format = "###,###,###"
                    DGTAMPIL.Columns(9).DefaultCellStyle.Format = "###,###,###"
                    DGTAMPIL.Columns(10).DefaultCellStyle.Format = "###,###,###"
                    DGTAMPIL.Columns(11).DefaultCellStyle.Format = "###,###,###"
                    DGTAMPIL.Columns(12).DefaultCellStyle.Format = "###,###,###"
                    DGTAMPIL.Columns(13).DefaultCellStyle.Format = "###,###,###"
                    DGTAMPIL.Columns(14).DefaultCellStyle.Format = "###,###,###"
                    DGTAMPIL.Columns(15).DefaultCellStyle.Format = "###,###,###"
                Next
        End Select
    End Sub

    Private Sub BTNTAMPIL_Click(sender As Object, e As EventArgs) Handles BTNTAMPIL.Click
        If CBJENIS.Text <> "" Then
            TAMPIL()
        End If
    End Sub

    Private Sub TXTTGLAWAL_ValueChanged(sender As Object, e As EventArgs) Handles TXTTGLAWAL.ValueChanged
        If TXTTGLAWAL.Value > TXTTGLAKHIR.Value Then
            TXTTGLAKHIR.Value = TXTTGLAWAL.Value
        End If
    End Sub

    Private Sub TXTTGLAKHIR_ValueChanged(sender As Object, e As EventArgs) Handles TXTTGLAKHIR.ValueChanged
        If TXTTGLAKHIR.Value < TXTTGLAWAL.Value Then
            MsgBox("Tanggal akhir harus lebih dari atau sama dengan tanggal awal!")
            TXTTGLAKHIR.Value = TXTTGLAWAL.Value
        End If
    End Sub

    Private Sub BTNCETAK_Click(sender As Object, e As EventArgs) Handles BTNCETAK.Click
        If DGTAMPIL.Rows.Count > 0 Then
            Select Case CBJENIS.SelectedIndex
                Case 0
                    Dim RPT As New RPT_MASUK
                    With RPT
                        .SetDataSource(TBL)
                        .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value)
                        .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value)
                    End With

                    Dim FR As New FR_PREVIEW
                    With FR
                        .CRV.ReportSource = RPT
                        .ShowDialog()
                    End With
                Case 1
                    Dim RPT As New RPT_KELUAR
                    With RPT
                        .SetDataSource(TBL)
                        .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value)
                        .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value)
                    End With

                    Dim FR As New FR_PREVIEW
                    With FR
                        .CRV.ReportSource = RPT
                        .ShowDialog()
                    End With
            End Select
        End If
    End Sub
End Class