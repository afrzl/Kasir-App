Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO

Public Class FR_CETAK_LABEL
    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
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

    Private Sub BTNKELUAR_Click(sender As Object, e As EventArgs) Handles BTNKELUAR.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNLAPORAN_Click(sender As Object, e As EventArgs) Handles BTNLAPORAN.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BTNDASHBOARDKASIR_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDKASIR.Click
        BUKA_FORM(FR_KASIR_DASHBOARD)
    End Sub

    Private Sub BTNKELUARKASIR_Click(sender As Object, e As EventArgs) Handles BTNKELUARKASIR.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNLAPORANKASIR_Click(sender As Object, e As EventArgs) Handles BTNLAPORANKASIR.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNRETURNKASIR_Click(sender As Object, e As EventArgs) Handles BTNRETURNKASIR.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNMASUK_Click(sender As Object, e As EventArgs) Handles BTNMASUK.Click
        BUKA_FORM(FR_MASUK)
    End Sub

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub BTNDASHBOARDOPS_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDOPS.Click
        BUKA_FORM(FR_OPS_DASHBOARD)
    End Sub

    Private Sub BTNMASUKOPS_Click(sender As Object, e As EventArgs) Handles BTNMASUKOPS.Click
        BUKA_FORM(FR_MASUK)
    End Sub

    Private Sub BTNKELUAROPS_Click(sender As Object, e As EventArgs) Handles BTNKELUAROPS.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNRETURNOPS_Click(sender As Object, e As EventArgs) Handles BTNRETURNOPS.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAKOPS_Click(sender As Object, e As EventArgs) Handles BTNRUSAKOPS.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub BTNLAPORANOPS_Click(sender As Object, e As EventArgs) Handles BTNLAPORANOPS.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub FR_CETAK_LABEL_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case ROLE
            Case 1
                PNADMIN.Visible = True
                PNKASIR.Visible = False
                PNOPS.Visible = False
                Label3.Text = "Administrator"
            Case 2
                PNADMIN.Visible = False
                PNKASIR.Visible = False
                PNOPS.Visible = True
                Label3.Text = "Operator"
            Case 3
                PNADMIN.Visible = False
                PNKASIR.Visible = True
                PNOPS.Visible = False
                Label3.Text = "Kasir"
        End Select

        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN
        TAMPIL_BARANG()
    End Sub

    Dim TBL_DATA As New DataTable
    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 12
    Sub TAMPIL_BARANG()
        Dim STR As String = "SELECT RTRIM(Kode) AS 'Kode Barang'," &
            " RTRIM(Barang) AS 'Nama Barang'," &
            " RTRIM(Satuan) AS 'Satuan'," &
            " Harga1 AS 'Harga Satuan' FROM tbl_barang" &
            " WHERE Barang LIKE '%" & TXTCARI.Text & "%'" &
            " ORDER BY 'Nama Barang' ASC"

        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL, START_RECORD, TAMPIL_RECORD, 0)
        DGBARANG.DataSource = TBL.Tables(0)

        DGBARANG.Columns(3).DefaultCellStyle.Format = "Rp ###,##"

        DGBARANG.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGBARANG.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGBARANG.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGBARANG.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGBARANG.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGBARANG.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        BTNPREV.Enabled = True
        BTNNEXT.Enabled = True
        Dim TOTAL_RECORD As Integer = 0

        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL_DATA)

        TOTAL_RECORD = TBL_DATA.Rows.Count

        If TOTAL_RECORD = 0 Then
            BTNPREV.Enabled = False
            BTNNEXT.Enabled = False
        ElseIf START_RECORD = 0 Then
            BTNPREV.Enabled = False
        ElseIf TOTAL_RECORD <= TAMPIL_RECORD Then
            BTNNEXT.Enabled = False
        ElseIf TOTAL_RECORD - START_RECORD <= TAMPIL_RECORD Then
            BTNNEXT.Enabled = False
        Else
            BTNPREV.Enabled = True
            BTNNEXT.Enabled = True
        End If
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

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        Dim FR As New FR_LOGIN
        My.Settings.ID_ACCOUNT = 0
        FR.Show()
        Me.Close()
    End Sub

    Private Sub BTNPREV_Click(sender As Object, e As EventArgs) Handles BTNPREV.Click
        START_RECORD -= TAMPIL_RECORD
        TAMPIL_BARANG()
    End Sub

    Private Sub BTNNEXT_Click(sender As Object, e As EventArgs) Handles BTNNEXT.Click
        START_RECORD += TAMPIL_RECORD
        TAMPIL_BARANG()
    End Sub

    Sub MASUK_DATA()
        Dim ADA_DATA As Boolean = False

        If DGBARANG.Item(0, DGBARANG.CurrentRow.Index).Value = "" Then
            MsgBox("Tidak ada data yang dipilih!")
        Else
            For N = 0 To DGCETAK.Rows.Count - 1
                Dim Kode As String = DGCETAK.Item("Kode", N).Value
                If Kode = DGBARANG.Item(0, DGBARANG.CurrentRow.Index).Value Then
                    ADA_DATA = True
                    Exit For
                End If
            Next

            If ADA_DATA = True Then
                MsgBox("Data sudah ada di dalam tabel")
            Else
                Dim STR As String
                STR = "SELECT Kode," &
                    " RTRIM(Barang) as Barang," &
                    " RTRIM(Satuan) as Satuan," &
                    " Harga1," &
                    " End1," &
                    " Harga2," &
                    " End2," &
                    " Harga3," &
                    " End3," &
                    " Harga4," &
                    " End4," &
                    " Harga5" &
                    " From tbl_barang WHERE Kode='" & DGBARANG.Item(0, DGBARANG.CurrentRow.Index).Value & "'"
                Dim CMD As SqlCommand
                CMD = New SqlCommand(STR, CONN)
                Dim RD As SqlDataReader
                RD = CMD.ExecuteReader

                If RD.HasRows Then
                    RD.Read()
                    DGCETAK.Rows.Add()
                    DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("KODE").Value = DGBARANG.Item(0, DGBARANG.CurrentRow.Index).Value
                    DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("BARANG").Value = RD.Item("Barang")
                    DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("SATUAN").Value = RD.Item("Satuan")
                    If RD.Item("End1") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("OPSI1").Value = "0 - " & Format(RD.Item("End1"), "##0.##")
                    End If
                    If RD.Item("Harga1") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("HARGA1").Value = Format(RD.Item("Harga1"), "##,##0")
                    End If
                    If RD.Item("End2") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("OPSI2").Value = Format(RD.Item("End1"), "##0.##") & " - " & Format(RD.Item("End2"), "##0.##")
                    ElseIf RD.Item("End2") = 0 And RD.Item("End1") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("OPSI2").Value = " > " & Format(RD.Item("End1"), "##0.##")
                    End If
                    If RD.Item("Harga2") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("HARGA2").Value = Format(RD.Item("Harga2"), "##,##0")
                    End If
                    If RD.Item("End3") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("OPSI3").Value = Format(RD.Item("End2"), "##0.##") & " - " & Format(RD.Item("End3"), "##0.##")
                    ElseIf RD.Item("End3") = 0 And RD.Item("End2") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("OPSI3").Value = " > " & Format(RD.Item("End2"), "##0.##")
                    End If
                    If RD.Item("Harga3") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("HARGA3").Value = Format(RD.Item("Harga3"), "##,##0")
                    End If
                    If RD.Item("End4") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("OPSI4").Value = Format(RD.Item("End3"), "##0.##") & " - " & Format(RD.Item("End4"), "##0.##")
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("OPSI5").Value = " > " & Format(RD.Item("End4"), "##0.##")
                    ElseIf RD.Item("End4") = 0 And RD.Item("End3") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("OPSI4").Value = " > " & Format(RD.Item("End3"), "##0.##")
                    End If
                    If RD.Item("Harga4") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("HARGA4").Value = Format(RD.Item("Harga4"), "##,##0")
                    End If
                    If RD.Item("Harga5") <> 0 Then
                        DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("HARGA5").Value = Format(RD.Item("Harga5"), "##,##0")
                    End If

                    DGCETAK.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGCETAK.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGCETAK.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGCETAK.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGCETAK.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGCETAK.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGCETAK.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGCETAK.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGCETAK.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGCETAK.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    DGCETAK.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    RD.Close()

                    Dim TGL_SKRG As String = Format(Date.Now, "yyyy-MM-dd")
                    STR = "SELECT Diskon AS 'Diskon'," &
                        " Tgl_awal AS 'Tanggal Awal'," &
                        " Tgl_akhir AS 'Tanggal Akhir'" &
                        " FROM tbl_diskon" &
                        " WHERE Kode='" & DGBARANG.Item(0, DGBARANG.CurrentRow.Index).Value & "'" &
                        " AND Jenis = 'B'" &
                        " AND Tgl_awal <= '" & TGL_SKRG & "'" &
                        " And Tgl_akhir >= '" & TGL_SKRG & "'"
                    CMD = New SqlCommand(STR, CONN)
                    RD = CMD.ExecuteReader
                    If RD.HasRows Then
                        RD.Read()
                        If RD.Item("Diskon") <> 0 Then
                            DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("DISKON").Value = RD.Item("Diskon") & "%"
                            DGCETAK.Rows(DGCETAK.Rows.Count - 1).Cells("TGL_DISKON").Value = RD.Item("Tanggal Awal") & " - " & RD.Item("Tanggal Akhir")
                        End If
                        RD.Close()
                    Else
                        RD.Close()
                    End If
                    RD.Close()
                Else
                    RD.Close()
                    MsgBox("Error, please contact administrator")
                End If
                RD.Close()
            End If
        End If
    End Sub

    Private Sub BTNMASUKDG_Click(sender As Object, e As EventArgs) Handles BTNMASUKDG.Click
        MASUK_DATA()
    End Sub

    Private Sub BTNKELUARDG_Click(sender As Object, e As EventArgs) Handles BTNKELUARDG.Click
        Dim BARIS_DATA As Integer = 0
        For N = 0 To DGCETAK.Rows.Count - 1
            Dim Kode As String = DGCETAK.Item("KODE", N).Value
            If Kode = DGCETAK.Item(0, DGCETAK.CurrentRow.Index).Value Then
                BARIS_DATA = N
                Exit For
            End If
        Next
        DGCETAK.Rows.RemoveAt(BARIS_DATA)
    End Sub

    Private Sub BTNPRINT_Click(sender As Object, e As EventArgs) Handles BTNPRINT.Click
        Dim DT As New DataTable
        With DT
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
        For Each EROW As DataGridViewRow In DGCETAK.Rows
            If EROW.Cells(3).Value <> "" And EROW.Cells(5).Value <> "" And EROW.Cells(7).Value <> "" And EROW.Cells(9).Value <> "" And EROW.Cells(11).Value <> "" Then
                If EROW.Cells(13).Value <> "" Then
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value,
                            EROW.Cells(5).Value,
                            EROW.Cells(6).Value,
                            EROW.Cells(7).Value,
                            EROW.Cells(8).Value,
                            EROW.Cells(9).Value,
                            EROW.Cells(10).Value,
                            EROW.Cells(11).Value,
                            EROW.Cells(12).Value,
                            "Disc. " & EROW.Cells(13).Value,
                            EROW.Cells(14).Value)
                Else
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value,
                            EROW.Cells(5).Value,
                            EROW.Cells(6).Value,
                            EROW.Cells(7).Value,
                            EROW.Cells(8).Value,
                            EROW.Cells(9).Value,
                            EROW.Cells(10).Value,
                            EROW.Cells(11).Value,
                            EROW.Cells(12).Value)
                End If
            ElseIf EROW.Cells(3).Value <> "" And EROW.Cells(5).Value <> "" And EROW.Cells(7).Value <> "" And EROW.Cells(9).Value <> "" And EROW.Cells(11).Value = "" Then
                If EROW.Cells(13).Value <> "" Then
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value,
                            EROW.Cells(5).Value,
                            EROW.Cells(6).Value,
                            EROW.Cells(7).Value,
                            EROW.Cells(8).Value,
                            EROW.Cells(9).Value,
                            EROW.Cells(10).Value,
                            "Disc. " & EROW.Cells(13).Value,
                            EROW.Cells(14).Value)
                Else
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value,
                            EROW.Cells(5).Value,
                            EROW.Cells(6).Value,
                            EROW.Cells(7).Value,
                            EROW.Cells(8).Value,
                            EROW.Cells(9).Value,
                            EROW.Cells(10).Value)
                End If
            ElseIf EROW.Cells(3).Value <> "" And EROW.Cells(5).Value <> "" And EROW.Cells(7).Value <> "" And EROW.Cells(9).Value = "" And EROW.Cells(11).Value = "" Then
                If EROW.Cells(13).Value <> "" Then
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value,
                            EROW.Cells(5).Value,
                            EROW.Cells(6).Value,
                            EROW.Cells(7).Value,
                            EROW.Cells(8).Value,
                            "Disc. " & EROW.Cells(13).Value,
                            EROW.Cells(14).Value)
                Else
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value,
                            EROW.Cells(5).Value,
                            EROW.Cells(6).Value,
                            EROW.Cells(7).Value,
                            EROW.Cells(8).Value)
                End If
            ElseIf EROW.Cells(3).Value <> "" And EROW.Cells(5).Value <> "" And EROW.Cells(7).Value = "" And EROW.Cells(9).Value = "" And EROW.Cells(11).Value = "" Then
                If EROW.Cells(13).Value <> "" Then
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value,
                            EROW.Cells(5).Value,
                            EROW.Cells(6).Value,
                            "Disc. " & EROW.Cells(13).Value,
                            EROW.Cells(14).Value)
                Else
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value,
                            EROW.Cells(5).Value,
                            EROW.Cells(6).Value)
                End If
            ElseIf EROW.Cells(3).Value <> "" And EROW.Cells(5).Value = "" And EROW.Cells(7).Value = "" And EROW.Cells(9).Value = "" And EROW.Cells(11).Value = "" Then
                If EROW.Cells(13).Value <> "" Then
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value,
                            "Disc. " & EROW.Cells(13).Value,
                            EROW.Cells(14).Value)
                Else
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value)
                End If
            ElseIf EROW.Cells(3).Value = "" And EROW.Cells(5).Value = "" And EROW.Cells(7).Value = "" And EROW.Cells(9).Value = "" And EROW.Cells(11).Value = "" Then
                If EROW.Cells(13).Value <> "" Then
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value,
                            "Disc. " & EROW.Cells(13).Value,
                            EROW.Cells(14).Value)
                Else
                    DT.Rows.Add(EROW.Cells(0).Value,
                            EROW.Cells(1).Value,
                            EROW.Cells(2).Value,
                            EROW.Cells(3).Value,
                            EROW.Cells(4).Value)
                End If
            End If
        Next

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

            Dim RPT As New RPT_CETAKLABEL
            Try
                With RPT
                    .SetDataSource(DT)
                    .PrintOptions.PrinterName = PrinterName
                    .PrintToPrinter(nCopies, False, sPage, ePage)
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub BTNPRINTALL_Click(sender As Object, e As EventArgs) Handles BTNPRINTALL.Click
        Dim STR As String = "SELECT RTRIM(tbl_barang.Kode) AS 'Kode', " &
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
                        " tbl_diskon.Tgl_awal," &
                        " tbl_diskon.Tgl_akhir," &
                        " tbl_diskon.Diskon" &
                        " FROM tbl_barang LEFT OUTER JOIN tbl_diskon On tbl_diskon.Kode = tbl_barang.Kode" &
                        " ORDER BY tbl_barang.Barang ASC"
        Dim DA As SqlDataAdapter
        Dim TBL As New DataTable
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL)

        Dim DT As New DataTable
        With DT
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
                            Format(TBL.Rows(N).Item(4), "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                            Format(TBL.Rows(N).Item(5), "###,##"),
                            Format(TBL.Rows(N).Item(6), "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                            Format(TBL.Rows(N).Item(7), "###,##"),
                            Format(TBL.Rows(N).Item(8), "##0.##") & " - " & Format(TBL.Rows(N).Item(10), "##0.##"),
                            Format(TBL.Rows(N).Item(9), "###,##"),
                            " > " & Format(TBL.Rows(N).Item(10), "##0.##"),
                            Format(TBL.Rows(N).Item(11), "###,##"),
                            "Disc. " & TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                            TBL.Rows(N).Item(14) & "%")
                Else
                    DT.Rows.Add(TBL.Rows(N).Item(0),
                            TBL.Rows(N).Item(1),
                            TBL.Rows(N).Item(2),
                            "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                            Format(TBL.Rows(N).Item(3), "###,##"),
                            Format(TBL.Rows(N).Item(4), "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                            Format(TBL.Rows(N).Item(5), "###,##"),
                            Format(TBL.Rows(N).Item(6), "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                            Format(TBL.Rows(N).Item(7), "###,##"),
                            Format(TBL.Rows(N).Item(8), "##0.##") & " - " & Format(TBL.Rows(N).Item(10), "##0.##"),
                            Format(TBL.Rows(N).Item(9), "###,##"),
                            " > " & Format(TBL.Rows(N).Item(10), "##0.##"),
                            Format(TBL.Rows(N).Item(11), "###,##"))
                End If
            ElseIf TBL.Rows(N).Item(4) <> 0 And TBL.Rows(N).Item(6) <> 0 And TBL.Rows(N).Item(8) <> 0 And TBL.Rows(N).Item(10) = 0 Then
                If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                    DT.Rows.Add(TBL.Rows(N).Item(0),
                            TBL.Rows(N).Item(1),
                            TBL.Rows(N).Item(2),
                            "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                            Format(TBL.Rows(N).Item(3), "###,##"),
                            Format(TBL.Rows(N).Item(4), "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                            Format(TBL.Rows(N).Item(5), "###,##"),
                            Format(TBL.Rows(N).Item(6), "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                            Format(TBL.Rows(N).Item(7), "###,##"),
                            " > " & Format(TBL.Rows(N).Item(8), "##0.##"),
                            Format(TBL.Rows(N).Item(9), "###,##"),
                            "Disc. " & TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                            TBL.Rows(N).Item(14) & "%")
                Else
                    DT.Rows.Add(TBL.Rows(N).Item(0),
                            TBL.Rows(N).Item(1),
                            TBL.Rows(N).Item(2),
                            "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                            Format(TBL.Rows(N).Item(3), "###,##"),
                            Format(TBL.Rows(N).Item(4), "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                            Format(TBL.Rows(N).Item(5), "###,##"),
                            Format(TBL.Rows(N).Item(6), "##0.##") & " - " & Format(TBL.Rows(N).Item(8), "##0.##"),
                            Format(TBL.Rows(N).Item(7), "###,##"),
                            " > " & Format(TBL.Rows(N).Item(8), "##0.##"),
                            Format(TBL.Rows(N).Item(9), "###,##"))
                End If
            ElseIf TBL.Rows(N).Item(4) <> 0 And TBL.Rows(N).Item(6) <> 0 And TBL.Rows(N).Item(8) = 0 And TBL.Rows(N).Item(10) = 0 Then
                If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                    DT.Rows.Add(TBL.Rows(N).Item(0),
                            TBL.Rows(N).Item(1),
                            TBL.Rows(N).Item(2),
                            "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                            Format(TBL.Rows(N).Item(3), "###,##"),
                            Format(TBL.Rows(N).Item(4), "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                            Format(TBL.Rows(N).Item(5), "###,##"),
                            " > " & Format(TBL.Rows(N).Item(6), "##0.##"),
                            Format(TBL.Rows(N).Item(7), "###,##"),
                            "Disc. " & TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                            TBL.Rows(N).Item(14) & "%")
                Else
                    DT.Rows.Add(TBL.Rows(N).Item(0),
                            TBL.Rows(N).Item(1),
                            TBL.Rows(N).Item(2),
                            "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                            Format(TBL.Rows(N).Item(3), "###,##"),
                            Format(TBL.Rows(N).Item(4), "##0.##") & " - " & Format(TBL.Rows(N).Item(6), "##0.##"),
                            Format(TBL.Rows(N).Item(5), "###,##"),
                            " > " & Format(TBL.Rows(N).Item(6), "##0.##"),
                            Format(TBL.Rows(N).Item(7), "###,##"))
                End If
            ElseIf TBL.Rows(N).Item(4) <> 0 And TBL.Rows(N).Item(6) = 0 And TBL.Rows(N).Item(8) = 0 And TBL.Rows(N).Item(10) = 0 Then
                If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                    DT.Rows.Add(TBL.Rows(N).Item(0),
                            TBL.Rows(N).Item(1),
                            TBL.Rows(N).Item(2),
                            "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                            Format(TBL.Rows(N).Item(3), "###,##"),
                            " > " & Format(TBL.Rows(N).Item(4), "##0.##"),
                            Format(TBL.Rows(N).Item(5), "###,##"),
                            "Disc. " & TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                            TBL.Rows(N).Item(14) & "%")
                Else
                    DT.Rows.Add(TBL.Rows(N).Item(0),
                            TBL.Rows(N).Item(1),
                            TBL.Rows(N).Item(2),
                            "0 - " & Format(TBL.Rows(N).Item(4), "##0.##"),
                            Format(TBL.Rows(N).Item(3), "###,##"),
                            " > " & Format(TBL.Rows(N).Item(4), "##0.##"),
                            Format(TBL.Rows(N).Item(5), "###,##"))
                End If
            ElseIf TBL.Rows(N).Item(4) = 0 And TBL.Rows(N).Item(6) = 0 And TBL.Rows(N).Item(8) = 0 And TBL.Rows(N).Item(10) = 0 Then
                If Not IsDBNull(TBL.Rows(N).Item(13)) Then
                    DT.Rows.Add(TBL.Rows(N).Item(0),
                            TBL.Rows(N).Item(1),
                            TBL.Rows(N).Item(2),
                            "",
                            Format(TBL.Rows(N).Item(3), "###,##"),
                            "Disc. " & TBL.Rows(N).Item(12) & " - " & TBL.Rows(N).Item(13),
                            TBL.Rows(N).Item(14) & "%")
                Else
                    DT.Rows.Add(TBL.Rows(N).Item(0),
                            TBL.Rows(N).Item(1),
                            TBL.Rows(N).Item(2),
                            "",
                            Format(TBL.Rows(N).Item(3), "###,##"))
                End If
            End If
        Next
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

            Dim RPT As New RPT_CETAKLABEL
            Try
                With RPT
                    .SetDataSource(DT)
                    .PrintOptions.PrinterName = PrinterName
                    .PrintToPrinter(nCopies, False, sPage, ePage)
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End If

    End Sub

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNTENTANGOPS_Click(sender As Object, e As EventArgs) Handles BTNTENTANGOPS.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNSETTINGKASIR_Click(sender As Object, e As EventArgs) Handles BTNSETTINGKASIR.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub DGBARANG_KeyDown(sender As Object, e As KeyEventArgs) Handles DGBARANG.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            e.Handled = True
            MASUK_DATA()
        End If
    End Sub
End Class