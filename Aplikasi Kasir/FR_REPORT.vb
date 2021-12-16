Imports System.Data.SqlClient

Public Class FR_REPORT
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
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

        KONDISI_AWAL()
    End Sub


    Dim STR As String = ""
    Dim TBL As New DataTable
    Dim TOTALLABA As Integer = 0
    Dim TOTALITEM As Double = 0

    Dim ADA_TRANSAKSI As Boolean
    Sub TAMPIL()
        TOTALLABA = 0
        Select Case CBJENIS.SelectedIndex
            Case 0
                STR = "SELECT Kode AS 'Kode Barang'," &
                    " Barang AS 'Nama Barang'," &
                    " Satuan AS 'Satuan'," &
                    " (SELECT COALESCE(SUM(Jumlah), 0) FROM tbl_transaksi_child WHERE LEFT(tbl_transaksi_child.Id_trans, 1) = 'M' AND tbl_transaksi_child.Kode = tbl_barang.Kode) AS 'Barang Masuk'," &
                    " (SELECT COALESCE(SUM(Jumlah), 0) FROM tbl_transaksi_child WHERE LEFT(tbl_transaksi_child.Id_trans, 1) = 'K' AND tbl_transaksi_child.Kode = tbl_barang.Kode) AS 'Barang Keluar'" &
                    " FROM tbl_barang" &
                    " ORDER BY 'Nama Barang' ASC"
            Case 1
                STR = "SELECT RTRIM(Id_trans) AS 'ID Transaksi'," &
                    " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) AS 'Supplier'," &
                    " RTRIM((SELECT Nama FROM tbl_karyawan WHERE Id = (SELECT Id_kasir FROM tbl_transaksi_parent WHERE RTRIM(Id_trans) = RTRIM(tbl_transaksi_child.Id_trans)))) AS 'Kasir'," &
                    " RTRIM(Kode) AS 'Kode Barang'," &
                    " RTRIM((SELECT Barang FROM tbl_barang WHERE kode = tbl_transaksi_child.kode)) as 'Nama Barang'," &
                    " RTRIM(Jumlah) AS 'Stok Masuk'," &
                    " Harga AS 'Harga Partai'," &
                    " RTRIM(Stok) AS 'Stok Sisa'" &
                    " FROM tbl_transaksi_child WHERE LEFT(Id_trans, 1) = 'M'" &
                    " AND (SELECT Tgl FROM tbl_transaksi_parent WHERE RTRIM(Id_trans) = rtrim(tbl_transaksi_child.Id_trans)) >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd 00:00:00") & "'" &
                    " AND (SELECT Tgl FROM tbl_transaksi_parent WHERE RTRIM(Id_trans) = rtrim(tbl_transaksi_child.Id_trans)) <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd 23:59:59") & "'" &
                    " ORDER BY Id ASC"
            Case 2
                STR = "SELECT RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                    " RTRIM(tbl_transaksi_parent.Jenis) AS 'Jenis'," &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " RTRIM((SELECT Nama FROM tbl_karyawan WHERE Id = tbl_transaksi_parent.Id_kasir)) AS 'Kasir'," &
                    " RTRIM(tbl_transaksi_parent.Person) AS 'Pembeli'," &
                    " tbl_transaksi_parent.Jumlah_item AS 'Jumlah_item'," &
                    " RTRIM(tbl_transaksi_child.Kode) As 'Kode Barang'," &
                    " RTRIM((SELECT Barang FROM tbl_barang WHERE Kode = tbl_transaksi_child.Kode)) AS 'Nama Barang'," &
                    " (tbl_transaksi_child.Harga / tbl_transaksi_child.Jumlah)  AS 'Harga QTY'," &
                    " tbl_transaksi_child.Jumlah AS 'QTY'," &
                    " tbl_transaksi_child.Harga  AS 'Harga Jual'," &
                    " tbl_transaksi_child.Diskon AS 'Diskon'," &
                    " tbl_transaksi_child.Harga_akhir AS 'Harga'," &
                    " tbl_transaksi_parent.Harga AS 'Total'," &
                    " tbl_transaksi_parent.Diskon AS 'Diskon Transaksi'," &
                    " tbl_transaksi_parent.Harga_total AS 'Total Akhir'," &
                    " tbl_transaksi_parent.Harga_tunai AS 'Bayar'," &
                    " tbl_transaksi_parent.Harga_kembali AS 'Kembalian'," &
                    " (tbl_transaksi_child.Harga_akhir - tbl_transaksi_child.Harga_beli) AS 'Laba Item'," &
                    " (SELECT COALESCE(SUM(tbl_transaksi_child.Harga_akhir), 0) - COALESCE(SUM(tbl_transaksi_child.Harga_beli), 0) FROM tbl_transaksi_child WHERE tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans) - tbl_transaksi_parent.Diskon AS 'Laba'" &
                    " From tbl_transaksi_child inner Join tbl_transaksi_parent On tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " Where (Left(tbl_transaksi_child.Id_trans, 1) = 'K' OR Left(tbl_transaksi_child.Id_trans, 1) = 'C')" &
                    " And tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd 00:00:00") & "'" &
                    " And tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd 23:59:59") & "'" &
                    " ORDER BY tbl_transaksi_child.Id ASC"
            Case 3
                STR = "SELECT" &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " tbl_transaksi_parent.Jumlah_item AS 'Jumlah_item'" &
                    " From tbl_transaksi_child inner Join tbl_transaksi_parent On tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " Where (Left(tbl_transaksi_child.Id_trans, 1) = 'K' OR Left(tbl_transaksi_child.Id_trans, 1) = 'C')" &
                    " And tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd 00:00:00") & "'" &
                    " And tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd 23:59:59") & "'" &
                    " ORDER BY tbl_transaksi_child.Id ASC"
            Case 4
                Dim LASTDAYOFMONTH = DateTime.DaysInMonth(TXTTGLAKHIR.Value.ToString("yyyy"), TXTTGLAKHIR.Value.ToString("MM"))
                STR = "SELECT" &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " tbl_transaksi_parent.Jumlah_item AS 'Jumlah_item'" &
                    " From tbl_transaksi_child inner Join tbl_transaksi_parent On tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " Where (Left(tbl_transaksi_child.Id_trans, 1) = 'K' OR Left(tbl_transaksi_child.Id_trans, 1) = 'C')" &
                    " And tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd 00:00:00") & "'" &
                    " And tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-" & LASTDAYOFMONTH & " 23:59:59") & "'" &
                    " ORDER BY tbl_transaksi_child.Id ASC"
            Case 5
                STR = "SELECT " &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " (SELECT COALESCE(SUM(tbl_transaksi_child.Harga_akhir), 0) - COALESCE(SUM(tbl_transaksi_child.Harga_beli), 0) FROM tbl_transaksi_child WHERE tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans) - tbl_transaksi_parent.Diskon AS 'Laba'" &
                    " From tbl_transaksi_child inner Join tbl_transaksi_parent On tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " Where (Left(tbl_transaksi_child.Id_trans, 1) = 'K' OR Left(tbl_transaksi_child.Id_trans, 1) = 'C')" &
                    " And tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-dd 00:00:00") & "'" &
                    " And tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-dd 23:59:59") & "'" &
                    " ORDER BY tbl_transaksi_child.Id ASC"
            Case 6
                Dim LASTDAYOFMONTH = DateTime.DaysInMonth(TXTTGLAKHIR.Value.ToString("yyyy"), TXTTGLAKHIR.Value.ToString("MM"))
                STR = "SELECT " &
                    " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
                    " (SELECT COALESCE(SUM(tbl_transaksi_child.Harga_akhir), 0) - COALESCE(SUM(tbl_transaksi_child.Harga_beli), 0) FROM tbl_transaksi_child WHERE tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans) - tbl_transaksi_parent.Diskon AS 'Laba'" &
                    " From tbl_transaksi_child inner Join tbl_transaksi_parent On tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
                    " Where (Left(tbl_transaksi_child.Id_trans, 1) = 'K' OR Left(tbl_transaksi_child.Id_trans, 1) = 'C')" &
                    " And tbl_transaksi_parent.Tgl >= '" & TXTTGLAWAL.Value.ToString("yyyy-MM-01 00:00:00") & "'" &
                    " And tbl_transaksi_parent.Tgl <= '" & TXTTGLAKHIR.Value.ToString("yyyy-MM-" & LASTDAYOFMONTH & " 23:59:59") & "'" &
                    " ORDER BY tbl_transaksi_child.Id ASC"
        End Select

        Dim DA As New SqlDataAdapter(STR, CONN)
        TBL.Clear()
        TBL.Columns.Clear()
        DA.Fill(TBL)

        If TBL.Rows.Count = 0 Then
            ADA_TRANSAKSI = False
            MsgBox("Tidak ada transaksi")
        Else
            ADA_TRANSAKSI = True
            Select Case CBJENIS.SelectedIndex
                Case 0
                ' sementara tidak ada
                Case 1

                Case 2
                    TOTALLABA = Convert.ToDouble(TBL.Compute("SUM(Laba)", ""))
                    TOTALITEM = Convert.ToDouble(TBL.Compute("SUM(Jumlah_item)", ""))
                Case 3
                    TOTALITEM = Convert.ToDouble(TBL.Compute("SUM(Jumlah_item)", ""))
                Case 4
                    TOTALITEM = Convert.ToDouble(TBL.Compute("SUM(Jumlah_item)", ""))
                Case 5
                    TOTALLABA = Convert.ToDouble(TBL.Compute("SUM(Laba)", ""))
                Case 6
                    TOTALLABA = Convert.ToDouble(TBL.Compute("SUM(Laba)", ""))
            End Select
        End If

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
        BTNTAMPIL.Location = New Point(907, 10)
        BTNCETAK.Location = New Point(1035, 10)

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
        BTNTAMPIL.Location = New Point(907, 10)
        BTNCETAK.Location = New Point(1035, 10)

        TXTTGLAWAL.ShowUpDown = False
        TXTTGLAWAL.Format = DateTimePickerFormat.Short

        TXTTGLAKHIR.ShowUpDown = False
        TXTTGLAKHIR.Format = DateTimePickerFormat.Short

        Label6.Text = "Tanggal"
    End Sub

    Private Sub BTNTAMPIL_Click(sender As Object, e As EventArgs) Handles BTNTAMPIL.Click
        If CBJENIS.Text <> "" Then
            TAMPIL()
        End If
        If ADA_TRANSAKSI Then
            Select Case CBJENIS.SelectedIndex
                Case 0
                    Dim RPT As New RPT_STOK
                    With RPT
                        .SetDataSource(TBL)
                        .SetParameterValue("datetime", LBTGL.Text)
                    End With

                    BTNCETAK.Visible = True
                    CRV.ReportSource = RPT
                Case 1
                    Dim RPT As New RPT_MASUK
                    With RPT
                        .SetDataSource(TBL)
                        .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                        .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                    End With

                    BTNCETAK.Visible = True
                    CRV.ReportSource = RPT
                Case 2
                    Dim RPT As New RPT_KELUAR
                    With RPT
                        .SetDataSource(TBL)
                        .SetParameterValue("total_laba", TOTALLABA)
                        .SetParameterValue("total_item", TOTALITEM)
                        .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                        .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                    End With

                    BTNCETAK.Visible = True
                    CRV.ReportSource = RPT
                Case 3
                    Dim RPT As New RPT_GRAFIK_PENJUALAN_HARIAN
                    With RPT
                        .SetDataSource(TBL)
                        .SetParameterValue("total_item", TOTALITEM)
                        .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                        .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                    End With

                    BTNCETAK.Visible = True
                    CRV.ReportSource = RPT
                Case 4
                    Dim RPT As New RPT_GRAFIK_PENJUALAN_BULANAN
                    With RPT
                        .SetDataSource(TBL)
                        .SetParameterValue("total_item", TOTALITEM)
                        .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("MMMM yyyy"))
                        .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("MMMM yyyy"))
                    End With

                    BTNCETAK.Visible = True
                    CRV.ReportSource = RPT
                Case 5
                    Dim RPT As New RPT_GRAFIK_LABA_HARIAN
                    With RPT
                        .SetDataSource(TBL)
                        .SetParameterValue("total_laba", TOTALLABA)
                        .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("dd MMMM yyyy"))
                        .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("dd MMMM yyyy"))
                    End With

                    BTNCETAK.Visible = True
                    CRV.ReportSource = RPT
                Case 6
                    Dim RPT As New RPT_GRAFIK_LABA_BULANAN
                    With RPT
                        .SetDataSource(TBL)
                        .SetParameterValue("total_laba", TOTALLABA)
                        .SetParameterValue("tgl_mulai", TXTTGLAWAL.Value.ToString("MMMM yyyy"))
                        .SetParameterValue("tgl_akhir", TXTTGLAKHIR.Value.ToString("MMMM yyyy"))
                    End With

                    BTNCETAK.Visible = True
                    CRV.ReportSource = RPT
            End Select
        End If
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

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub CBJENIS_TextChanged(sender As Object, e As EventArgs) Handles CBJENIS.TextChanged
        Select Case CBJENIS.SelectedIndex
            Case 0
                Label6.Visible = False
                Label7.Visible = False
                TXTTGLAWAL.Visible = False
                TXTTGLAKHIR.Visible = False
                BTNTAMPIL.Visible = True

                BTNTAMPIL.Location = New Point(362, 10)
                BTNCETAK.Location = New Point(489, 10)
            Case 1
                KONDISI_TANGGAL()
            Case 2
                KONDISI_TANGGAL()
            Case 3
                KONDISI_TANGGAL()
            Case 4
                KONDISI_BULAN()
            Case 5
                KONDISI_TANGGAL()
            Case 6
                KONDISI_BULAN()
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
End Class