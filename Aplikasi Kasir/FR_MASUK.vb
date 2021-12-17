﻿Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO

Public Class FR_MASUK

    Dim ID_TRANSAKSI As String
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

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
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

    Private Sub FR_MASUK_Load(sender As Object, e As EventArgs) Handles Me.Load
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN

        TXTSUPPLIER.Select()
    End Sub

    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 50

    Sub TAMPIL()
        Dim STR As String
        If CBTAMPIL.SelectedIndex = 0 Then
            STR = "SELECT RTRIM(Id_trans) AS 'ID Transaksi'," &
            " RTRIM(Kode) AS 'Kode Barang'," &
            " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) AS 'Nama Barang'," &
            " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
            " Jumlah as 'Stok Masuk'," &
            " Harga AS 'Harga Partai'," &
            " Stok AS 'Stok Sisa'" &
            " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
            " (SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
            " ORDER BY Id ASC"
        ElseIf CBTAMPIL.SelectedIndex = 1 Then
            STR = "SELECT RTRIM(Id_trans) AS 'ID Transaksi'," &
            " RTRIM(Kode) AS 'Kode Barang'," &
            " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) AS 'Nama Barang'," &
            " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
            " Jumlah as 'Stok Masuk'," &
            " Harga AS 'Harga Partai'," &
            " Stok AS 'Stok Sisa'" &
            " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
            " (SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
            " AND Stok != 0" &
            " ORDER BY Id ASC"
        ElseIf CBTAMPIL.SelectedIndex = 2 Then
            STR = "SELECT RTRIM(Id_trans) AS 'ID Transaksi'," &
            " RTRIM(Kode) AS 'Kode Barang'," &
            " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) AS 'Nama Barang'," &
            " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
            " Jumlah as 'Stok Masuk'," &
            " Harga AS 'Harga Partai'," &
            " Stok AS 'Stok Sisa'" &
            " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
            " (SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
            " AND Stok = 0" &
            " ORDER BY Id ASC"
        Else
            STR = "SELECT RTRIM(Id_trans) AS 'ID Transaksi'," &
            " RTRIM(Kode) AS 'Kode Barang'," &
            " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) AS 'Nama Barang'," &
            " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
            " Jumlah as 'Stok Masuk'," &
            " Harga AS 'Harga Partai'," &
            " Stok AS 'Stok Sisa'" &
            " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
            " (SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
            " ORDER BY Id ASC"
        End If
        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL, START_RECORD, TAMPIL_RECORD, 0)
        DGHISTORY.DataSource = TBL.Tables(0)

        DGHISTORY.Columns(4).DefaultCellStyle.Format = "###.##"
        DGHISTORY.Columns(5).DefaultCellStyle.Format = "Rp ###,##"
        DGHISTORY.Columns(6).DefaultCellStyle.Format = "###.##"

        DGHISTORY.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGHISTORY.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGHISTORY.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGHISTORY.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGHISTORY.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGHISTORY.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        BTNPREV.Enabled = True
        BTNNEXT.Enabled = True

        Dim TOTAL_RECORD As Integer = 0
        Dim TBL_DATA As New DataTable
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

    Private Sub BTNNEXT_Click(sender As Object, e As EventArgs) Handles BTNNEXT.Click
        START_RECORD = START_RECORD + TAMPIL_RECORD
        TAMPIL()
    End Sub

    Private Sub BTNPREV_Click(sender As Object, e As EventArgs) Handles BTNPREV.Click
        START_RECORD = START_RECORD - TAMPIL_RECORD
        TAMPIL()
    End Sub

    Sub CARI_BARANG()
        Dim STR As String = "SELECT RTRIM(Kode) AS Kode,RTRIM(Barang) AS Barang" &
            " FROM tbl_barang WHERE Barang Like '%" & TXTCARI_BARANG.Text & "%'"
        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGCARI.DataSource = TBL
        DGCARI.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Sub TAMPIL_PNCARI()
        If PNCARI.Visible = False Then
            PNCARI.Visible = True
            BTNCARI.Text = "Tutup (F1)"
            TXTCARI_BARANG.Clear()
            DGCARI.DataSource = Nothing
            TXTCARI_BARANG.Select()
            CARI_BARANG()
        Else
            BTNCARI.Text = "Cari (F1)"
            PNCARI.Visible = False
            DGCARI.DataSource = Nothing
            TXTKODE.Select()
        End If
    End Sub

    Private Function CEK_HARGA() As Boolean
        Dim STR As String = "SELECT * FROM tbl_barang WHERE Kode='" & TXTKODE.Text & "'"
        Dim CMD As New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        RD.Read()
        Dim HARGA_TERENDAH As Integer = 0
        If RD.Item("End4") <> 0 Then
            HARGA_TERENDAH = RD.Item("Harga5")
        Else
            If RD.Item("End3") <> 0 Then
                HARGA_TERENDAH = RD.Item("Harga4")
            Else
                If RD.Item("End3") <> 0 Then
                    HARGA_TERENDAH = RD.Item("Harga3")
                Else
                    If RD.Item("End2") <> 0 Then
                        HARGA_TERENDAH = RD.Item("Harga2")
                    Else
                        HARGA_TERENDAH = RD.Item("Harga1")
                    End If
                End If
            End If
        End If

        RD.Close()

        If CInt(TXTHARGAPARTAI.Text) < HARGA_TERENDAH Then
            CEK_HARGA = True
        Else
            CEK_HARGA = False
        End If
    End Function

    Private Function AUTOID() As String
        Dim ID_AWAL As String = Format(Date.Now, "yyMMdd")
        Dim STR As String = "SELECT TOP 1 (Id_trans) AS Id_trans FROM tbl_transaksi_parent WHERE LEFT(Id_trans,1)='M' ORDER BY Id DESC"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            If Mid(RD.Item("Id_trans"), 2, 6) = ID_AWAL Then
                Dim ID As Integer = Mid(RD.Item("Id_trans"), 8, 3) + 1
                RD.Close()
                AUTOID = "M" + ID_AWAL + Format(ID, "000")
            Else
                RD.Close()
                AUTOID = "M" + ID_AWAL + Format(1, "000")
            End If
        Else
            RD.Close()
            AUTOID = "M" + ID_AWAL + Format(1, "000")
        End If
        RD.Close()
    End Function

    Private Sub TXTKODE_TextChanged(sender As Object, e As EventArgs) Handles TXTKODE.TextChanged
        Dim STR As String = "SELECT * FROM tbl_barang WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTBARANG.Text = RD.Item("Barang").ToString.Trim
            TXTSATUAN.Text = RD.Item("Satuan").ToString.Trim
            RD.Close()
        Else
            RD.Close()
            TXTBARANG.Text = ""
            TXTSATUAN.Text = ""
        End If
        RD.Close()
    End Sub

    Private Sub TXTKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTJUMLAH.Select()
        End If
    End Sub

    Private Sub TXTJUMLAH_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTJUMLAH.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            TXTHARGAPARTAI.Select()
        End If
    End Sub

    Private Sub TXTSUPPLIER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSUPPLIER.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTKODE.Select()
        End If
    End Sub

    Sub TOTAL_HARGA()
        Dim TOT_HARGA As Integer = 0
        For N = 0 To DGTAMPIL.Rows.Count - 1
            TOT_HARGA = TOT_HARGA + DGTAMPIL.Item("Total", N).Value
        Next

        LBTOTAL.Text = Format(TOT_HARGA, "##,##0")

        If LBTOTAL.Text <> 0 Then
            BTNSTOK.Visible = True
        Else
            BTNSTOK.Visible = False
        End If
    End Sub

    Sub MASUK_DATA()
        DGTAMPIL.Rows.Add()
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("KODE").Value = TXTKODE.Text
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("BARANG").Value = TXTBARANG.Text
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("SATUAN").Value = TXTSATUAN.Text
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("HARGA").Value = TXTHARGAPARTAI.Text
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("QTY").Value = TXTJUMLAH.Text
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("TOTAL").Value = TXTHARGAPARTAI.Text * TXTJUMLAH.Text

        TOTAL_HARGA()
    End Sub

    Private Sub TXTHARGAPARTAI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGAPARTAI.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTKODE.Text = "" Or TXTBARANG.Text = "" Or TXTJUMLAH.Text = "" Or TXTHARGAPARTAI.Text = "" Then
                MsgBox("Data tidak lengkap!")
                TXTKODE.Select()
            ElseIf CInt(TXTJUMLAH.Text) <= 0 Then
                MsgBox("Jumlah barang harus lebih dari 0!")
            Else
                If CEK_HARGA() = True Then
                    MASUK_DATA()
                    TXTKODE.Text = ""
                    TXTJUMLAH.Text = ""
                    TXTHARGAPARTAI.Text = ""
                    TXTKODE.Select()
                Else
                    MsgBox("Harga partai harus lebih rendah dari harga jual produk, silahkan ubah harga jual!")
                    TXTHARGAPARTAI.Clear()
                    TXTHARGAPARTAI.Select()
                End If
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BTNCARI_Click(sender As Object, e As EventArgs) Handles BTNCARI.Click
        TAMPIL_PNCARI()
    End Sub

    Private Sub TXTCARI_BARANG_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI_BARANG.TextChanged
        CARI_BARANG()
    End Sub

    Private Sub BTNTAMBAH_Click(sender As Object, e As EventArgs)
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub HapusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusToolStripMenuItem.Click
        If MsgBox("Apakah anda yakin akan menghapus data transaksi?", vbYesNo) = vbYes Then
            Dim IDX As String = DGHISTORY.Item(0, DGHISTORY.CurrentRow.Index).Value
            Dim CMD As New SqlCommand("DELETE FROM tbl_transaksi_child WHERE Id_trans='" & IDX & "'", CONN)
            CMD.ExecuteNonQuery()

            CMD = New SqlCommand("DELETE FROM tbl_transaksi_parent WHERE Id_trans='" & IDX & "'", CONN)
            CMD.ExecuteNonQuery()
            TAMPIL()
            MsgBox("Data transaksi berhasil dihapus")
        End If
    End Sub

    Private Sub TXTKODE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTKODE.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
        End Select
    End Sub

    Private Sub TXTCARI_BARANG_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCARI_BARANG.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
        End Select
    End Sub

    Private Sub DGCARI_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            On Error Resume Next
            TXTKODE.Text = DGCARI.Item(0, DGHISTORY.CurrentRow.Index).Value
            BTNCARI.Text = "Cari (F1)"
            TXTJUMLAH.Select()
            PNCARI.Visible = False
            DGCARI.DataSource = Nothing
        End If
    End Sub

    Private Sub TXTCARI_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI.TextChanged
        START_RECORD = 0
        TAMPIL()
    End Sub

    Private Sub DGCARI_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCARI.CellDoubleClick
        On Error Resume Next
        TXTKODE.Text = DGCARI.Item(0, e.RowIndex).Value
        BTNCARI.Text = "Cari (F1)"
        TXTJUMLAH.Select()
        PNCARI.Visible = False
        DGCARI.DataSource = Nothing
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

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub DGCARI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGCARI.KeyPress
        On Error Resume Next
        If e.KeyChar = ChrW(Keys.Enter) Then
            If DGCARI.Rows.Count - 1 = DGCARI.CurrentRow.Index Then
                DGCARI.CurrentCell = DGCARI.Rows(DGCARI.CurrentRow.Index).Cells(0)
            Else
                DGCARI.CurrentCell = DGCARI.Rows(DGCARI.CurrentRow.Index - 1).Cells(0)
            End If
            TXTKODE.Text = DGCARI.SelectedCells(0).Value
            BTNCARI.Text = "Cari (F1)"
            TXTJUMLAH.Select()
            PNCARI.Visible = False
            DGCARI.DataSource = Nothing
        End If
    End Sub

    Private Sub TXTCARI_BARANG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI_BARANG.KeyPress
        If e.KeyChar = Chr(13) Then
            DGCARI.Select()
        End If
    End Sub

    Private Sub CBTAMPIL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBTAMPIL.SelectedIndexChanged
        TAMPIL()
    End Sub

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub DGTAMPIL_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGTAMPIL.CellMouseClick
        On Error Resume Next
        TXTKODE.Enabled = False
        TXTJUMLAH.Enabled = False
        TXTHARGAPARTAI.Enabled = False

        TXTKODE.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Kode").Value
        TXTHARGAPARTAI.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Harga").Value
        TXTJUMLAH.Text = DGTAMPIL.Rows(e.RowIndex).Cells("QTY").Value

        BTNCANCEL.Visible = True
        BTNCARI.Visible = False
        BTNHAPUS.Visible = True
    End Sub

    Private Sub BTNCANCEL_Click(sender As Object, e As EventArgs) Handles BTNCANCEL.Click
        TXTKODE.Enabled = True
        TXTJUMLAH.Enabled = True
        TXTHARGAPARTAI.Enabled = True
        BTNCARI.Visible = True
        BTNCANCEL.Visible = False
        BTNHAPUS.Visible = False
        TXTKODE.Clear()
        TXTJUMLAH.Clear()
        TXTHARGAPARTAI.Clear()
        TXTKODE.Select()
    End Sub

    Private Sub BTNHAPUS_Click(sender As Object, e As EventArgs) Handles BTNHAPUS.Click
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
        TXTJUMLAH.Enabled = True
        TXTKODE.Enabled = True
        TXTHARGAPARTAI.Enabled = True
        TXTKODE.Clear()
        TXTJUMLAH.Clear()
        TXTHARGAPARTAI.Clear()
        TXTKODE.Select()
    End Sub

    Private Sub BTNSTOK_Click(sender As Object, e As EventArgs) Handles BTNSTOK.Click
        INPUT_DB()
        PRINT_NOTA()
        MsgBox("Data pembelian sukses disimpan. Stok barang ditambah")
        DGTAMPIL.Rows.Clear()
        TOTAL_HARGA()
    End Sub

    Sub INPUT_DB()
        If DGTAMPIL.Rows.Count <= 0 Then Exit Sub
        ID_TRANSAKSI = AUTOID()
        Dim JUMLAH_ITEM As Integer = DGTAMPIL.Rows.Count
        Dim HARGA_TOTAL As Integer = 0
        For Each EROW As DataGridViewRow In DGTAMPIL.Rows
            HARGA_TOTAL += CInt(EROW.Cells("TOTAL").Value)
        Next

        Dim STR As String = "INSERT INTO tbl_transaksi_parent" &
            " (Id_trans, Id_kasir, Tgl, Jenis, Person, Harga, Jumlah_item)" &
            " VALUES('" & ID_TRANSAKSI & "'," &
            " '" & My.Settings.ID_ACCOUNT & "'," &
            " '" & Format(Date.Now, "MM/dd/yyyy HH:mm:ss") & "'," &
            " 'M'," &
            " '" & TXTSUPPLIER.Text & "'," &
            " '" & HARGA_TOTAL & "'," &
            " '" & JUMLAH_ITEM & "')"
        Dim CMD As New SqlCommand(STR, CONN)
        CMD.ExecuteNonQuery()

        For Each EROW As DataGridViewRow In DGTAMPIL.Rows
            Dim KODE_PRODUK As String = EROW.Cells("Kode").Value
            Dim JUMLAH_PRODUK As Double = EROW.Cells("QTY").Value.ToString.Replace(",", ".")
            Dim HARGA_PRODUK As Integer = EROW.Cells("Harga").Value

            STR = "INSERT INTO tbl_transaksi_child (Id_trans, Kode, Jumlah, Harga, Stok) VALUES" &
                    " ('" & ID_TRANSAKSI & "'," &
                    " '" & KODE_PRODUK & "'," &
                    " " & JUMLAH_PRODUK & "," &
                    " '" & HARGA_PRODUK & "'," &
                    " '" & JUMLAH_PRODUK & "')"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
        Next
    End Sub

    'PRINTING
    '=================================================================================
    'KERTAS 
    ReadOnly lebarKertas As Integer = 304 'Ukuran Kertas 78 mm
    ReadOnly tinggiKertas As Integer = 304
    ReadOnly marginLeft As Integer = 20
    ReadOnly marginRight As Integer = 20
    ReadOnly jarakBaris As Integer = 20
    Dim totalBaris As Integer = 0


    'JENIS DAN UKURAN HURUF
    ReadOnly fontJudul As New Font("Segoe UI", 12, FontStyle.Bold)
    ReadOnly fontRegular As New Font("Segoe UI", 10, FontStyle.Regular)
    ReadOnly fontTotal As New Font("Segoe UI", 10, FontStyle.Bold)

    Private Function BarisBaru(jumlah_baris)
        totalBaris += jumlah_baris
        Return totalBaris * jarakBaris
    End Function

    Private Function BarisYangSama()
        Return BarisBaru(0)
    End Function

    Private Sub PRINTNOTA_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PRINTNOTA.PrintPage
        Dim IMAGESTREAM As New MemoryStream
        IMAGESTREAM = New MemoryStream(Convert.FromBase64String(URL_LOGO))

        Dim textCenter, textLeft, textRight As New StringFormat
        textCenter.Alignment = StringAlignment.Center
        textLeft.Alignment = StringAlignment.Near
        textRight.Alignment = StringAlignment.Far
        Dim WIDTH As Single = 150
        Dim HEIGHT As Single = 100
        Dim JARAK As Single = (lebarKertas - WIDTH) / 2

        Dim IMAGE As Image = IMAGE.FromStream(IMAGESTREAM)
        e.Graphics.DrawImage(IMAGE, JARAK, BarisYangSama(), WIDTH, HEIGHT)

        e.Graphics.DrawString(NAMA_TOKO, fontJudul, Brushes.Black, lebarKertas / 2, BarisBaru(HEIGHT / jarakBaris), textCenter)
        e.Graphics.DrawString(ALAMAT_TOKO, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString(NO_TOKO, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        BarisBaru(1)

        e.Graphics.DrawString("PEMBELIAN BARANG", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)

        e.Graphics.DrawString(LBTGL.Text, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)

        e.Graphics.DrawString(ID_TRANSAKSI, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)
        e.Graphics.DrawString("Kasir : " & LBLUSER.Text, fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)

        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisBaru(1), (lebarKertas - marginRight), BarisYangSama)

        For Each EROW As DataGridViewRow In DGTAMPIL.Rows
            e.Graphics.DrawString(EROW.Cells("BARANG").Value, fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
            e.Graphics.DrawString(Convert.ToDouble(EROW.Cells("QTY").Value) & " " & EROW.Cells("SATUAN").Value & " x " & Format(CInt(EROW.Cells("HARGA").Value), "##,##0"), fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
            e.Graphics.DrawString(Format(CInt(EROW.Cells("TOTAL").Value), "##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
            BarisBaru(1)
        Next
        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)

        e.Graphics.DrawString("Total", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
        e.Graphics.DrawString(Format(CInt(LBTOTAL.Text), "Rp ##,##0"), fontTotal, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        BarisBaru(1)
        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)

        e.Graphics.DrawString("Barang yang sudah dibeli", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString("tidak dapat ditukar/dikembalikan", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString("TERIMA KASIH", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)

        BarisBaru(1)
    End Sub

    Sub PRINT_NOTA()
        Dim ps As New PrinterSettings
        PRINTNOTA.OriginAtMargins = False
        PRINTNOTA.PrinterSettings = ps
        PRINTNOTA.PrinterSettings.PrinterName = PRINTER_NOTA
        PRINTNOTA.DefaultPageSettings.PaperSize = New PaperSize("Custom", lebarKertas, tinggiKertas + BarisBaru(DGTAMPIL.Rows.Count))
        PRINTNOTA.DefaultPageSettings.Landscape = False
        PRINTNOTA.DocumentName = "Stroke"
        PRINTNOTA.Print()
    End Sub

    Private Sub BTNHISTORY_Click(sender As Object, e As EventArgs) Handles BTNHISTORY.Click
        PNHISTORY.Visible = True
        BTNSTOK.Visible = False
        BTNHISTORY.Visible = False
        BTNTRANSAKSI.Visible = True
        CBTAMPIL.SelectedIndex = 1
        TAMPIL()
    End Sub

    Private Sub BTNTRANSAKSI_Click(sender As Object, e As EventArgs) Handles BTNTRANSAKSI.Click
        PNHISTORY.Visible = False
        BTNSTOK.Visible = True
        BTNTRANSAKSI.Visible = False
        BTNHISTORY.Visible = True
    End Sub
End Class