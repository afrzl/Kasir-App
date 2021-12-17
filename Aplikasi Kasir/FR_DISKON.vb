Imports System.Data.SqlClient
Public Class FR_DISKON
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
        CBTAMPIL.Text = "Sekarang"

        TXTKODE.Select()
        TAMPIL()
    End Sub

    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 30

    Sub TAMPIL()
        Dim TGL_SKRG As String = Format(Date.Now, "yyyy-MM-dd")
        Dim STR As String = ""
        If CBTAMPIL.Text = "Semua" Then
            STR = "SELECT tbl_diskon.Id," &
                " RTRIM(tbl_diskon.Jenis) AS 'Jenis'," &
                " RTRIM(tbl_diskon.Kode) AS 'Kode Barang'," &
                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                " tbl_diskon.Min_transaksi AS 'Minimal Transaksi'," &
                " tbl_diskon.Tgl_awal as 'Tanggal Awal'," &
                " tbl_diskon.Tgl_akhir AS 'Tanggal Akhir'," &
                " RTRIM(tbl_diskon.Diskon) AS 'Diskon (%)'" &
                " FROM tbl_diskon" &
                " LEFT OUTER JOIN tbl_barang ON tbl_diskon.Kode = tbl_barang.Kode" &
                " ORDER BY tbl_diskon.Tgl_awal ASC"
        ElseIf CBTAMPIL.Text = "Berlalu" Then
            STR = "Select tbl_diskon.Id," &
                " RTRIM(tbl_diskon.Jenis) As 'Jenis'," &
                " RTRIM(tbl_diskon.Kode) AS 'Kode Barang'," &
                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                " tbl_diskon.Min_transaksi AS 'Minimal Transaksi'," &
                " tbl_diskon.Tgl_awal as 'Tanggal Awal'," &
                " tbl_diskon.Tgl_akhir AS 'Tanggal Akhir'," &
                " RTRIM(tbl_diskon.Diskon) AS 'Diskon (%)'" &
                " FROM tbl_diskon" &
                " LEFT OUTER JOIN tbl_barang ON tbl_diskon.Kode = tbl_barang.Kode" &
                " WHERE Tgl_akhir < '" & TGL_SKRG & "'" &
                " ORDER BY tbl_diskon.Tgl_awal ASC"
        ElseIf CBTAMPIL.Text = "Sekarang" Then
            STR = "SELECT tbl_diskon.Id," &
                " RTRIM(tbl_diskon.Jenis) AS 'Jenis'," &
                " RTRIM(tbl_diskon.Kode) AS 'Kode Barang'," &
                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                " tbl_diskon.Min_transaksi AS 'Minimal Transaksi'," &
                " tbl_diskon.Tgl_awal as 'Tanggal Awal'," &
                " tbl_diskon.Tgl_akhir AS 'Tanggal Akhir'," &
                " RTRIM(tbl_diskon.Diskon) AS 'Diskon (%)'" &
                " FROM tbl_diskon" &
                " LEFT OUTER JOIN tbl_barang ON tbl_diskon.Kode = tbl_barang.Kode" &
                " WHERE Tgl_awal <= '" & TGL_SKRG & "' AND Tgl_akhir >= '" & TGL_SKRG & "'" &
                " ORDER BY tbl_diskon.Tgl_awal ASC"
        ElseIf CBTAMPIL.Text = "Akan Datang" Then
            STR = "SELECT tbl_diskon.Id," &
                " RTRIM(tbl_diskon.Jenis) AS 'Jenis'," &
                " RTRIM(tbl_diskon.Kode) AS 'Kode Barang'," &
                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                " tbl_diskon.Min_transaksi AS 'Minimal Transaksi'," &
                " tbl_diskon.Tgl_awal as 'Tanggal Awal'," &
                " tbl_diskon.Tgl_akhir AS 'Tanggal Akhir'," &
                " RTRIM(tbl_diskon.Diskon) AS 'Diskon (%)'" &
                " FROM tbl_diskon" &
                " LEFT OUTER JOIN tbl_barang ON tbl_diskon.Kode = tbl_barang.Kode" &
                " WHERE Tgl_awal > '" & TGL_SKRG & "'" &
                " ORDER BY tbl_diskon.Tgl_awal ASC"
        Else
            STR = "SELECT tbl_diskon.Id," &
                " RTRIM(tbl_diskon.Jenis) AS 'Jenis'," &
                " RTRIM(tbl_diskon.Kode) AS 'Kode Barang'," &
                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                " tbl_diskon.Min_transaksi AS 'Minimal Transaksi'," &
                " tbl_diskon.Tgl_awal as 'Tanggal Awal'," &
                " tbl_diskon.Tgl_akhir AS 'Tanggal Akhir'," &
                " RTRIM(tbl_diskon.Diskon) AS 'Diskon (%)'" &
                " FROM tbl_diskon" &
                " LEFT OUTER JOIN tbl_barang ON tbl_diskon.Kode = tbl_barang.Kode" &
                " ORDER BY tbl_diskon.Tgl_awal ASC"
        End If
        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL, START_RECORD, TAMPIL_RECORD, 0)
        DGTAMPIL.DataSource = TBL.Tables(0)


        DGTAMPIL.Columns(0).Visible = False
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGTAMPIL.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGTAMPIL.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGTAMPIL.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGTAMPIL.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGTAMPIL.Columns(7).DefaultCellStyle.Format = "##%"
        DGTAMPIL.Columns(4).DefaultCellStyle.Format = "Rp ###,##"

        For N = 0 To DGTAMPIL.Rows.Count - 1
            If DGTAMPIL.Rows(N).Cells(1).Value = "A" Then
                DGTAMPIL.Rows(N).Cells(1).Value = "Semua"
            Else
                DGTAMPIL.Rows(N).Cells(1).Value = "Produk"
            End If
        Next


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

    Private Sub TXTKODE_TextChanged(sender As Object, e As EventArgs) Handles TXTKODE.TextChanged
        Dim STR As String = "SELECT Barang, Satuan FROM tbl_barang WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            LBBARANG.Text = RD.Item("Barang").ToString.Trim
            LBSATUAN.Text = RD.Item("Satuan").ToString.Trim
            RD.Close()
        Else
            RD.Close()
            LBBARANG.Text = ""
            LBSATUAN.Text = ""
        End If
        RD.Close()
    End Sub

    Private Sub TXTKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTTGLAWAL.Select()
        End If
    End Sub

    Private Sub BTNCARI_Click(sender As Object, e As EventArgs) Handles BTNCARI.Click
        TAMPIL_PNCARI()
    End Sub

    Private Sub TXTCARI_BARANG_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI_BARANG.TextChanged
        CARI_BARANG()
    End Sub

    Private Sub HapusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusToolStripMenuItem.Click
        If MsgBox("Apakah anda yakin akan menghapus data diskon?", vbYesNo) = vbYes Then
            DGTAMPIL.Columns(0).Visible = True
            Dim IDX As String = DGTAMPIL.CurrentRow.Cells("Id").Value
            Dim CMD As New SqlCommand("DELETE FROM tbl_diskon WHERE Id='" & IDX & "'", CONN)
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

    Private Sub DGCARI_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCARI.CellDoubleClick
        On Error Resume Next
        TXTKODE.Text = DGCARI.Item(0, e.RowIndex).Value
        BTNCARI.Text = "Cari (F1)"
        PNCARI.Visible = False
        DGCARI.DataSource = Nothing
    End Sub

    Private Sub TXTTGLAKHIR_ValueChanged(sender As Object, e As EventArgs) Handles TXTTGLAKHIR.ValueChanged
        If TXTTGLAKHIR.Value < TXTTGLAWAL.Value Then
            MsgBox("Tanggal akhir diskon harus lebih besar atau sama dengan tanggal awal!")
            TXTTGLAKHIR.Value = TXTTGLAWAL.Value
        End If
    End Sub

    Private Sub TXTTGLAWAL_ValueChanged(sender As Object, e As EventArgs) Handles TXTTGLAWAL.ValueChanged
        TXTTGLAKHIR.Value = TXTTGLAWAL.Value
    End Sub

    Private Sub CBTAMPIL_TextChanged(sender As Object, e As EventArgs) Handles CBTAMPIL.TextChanged
        TAMPIL()
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

    Private Sub BTNMASUK_Click(sender As Object, e As EventArgs) Handles BTNMASUK.Click
        BUKA_FORM(FR_MASUK)
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

    Private Sub TXTDISKON_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTDISKON.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If
    End Sub

    Private Sub TXTDISKON_TextChanged(sender As Object, e As EventArgs) Handles TXTDISKON.TextChanged
        Dim DISKON As Integer = 0
        If TXTDISKON.Text <> "" Then
            DISKON = CInt(TXTDISKON.Text)
        End If

        If DISKON > 100 Then
            MsgBox("Diskon maksimal 100%!")
            TXTDISKON.Text = ""
            TXTDISKON.Select()
        End If
    End Sub

    Private Sub TXTTGLAWAL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTGLAWAL.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTTGLAKHIR.Select()
        End If
    End Sub

    Private Sub TXTTGLAKHIR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTGLAKHIR.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTDISKON.Select()
        End If
    End Sub

    Private Sub DGCARI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DGCARI.KeyPress
        On Error Resume Next
        If e.KeyChar = ChrW(Keys.Enter) Then
            DGCARI.CurrentCell = DGCARI.Rows(DGCARI.CurrentRow.Index - 1).Cells(0)
            TXTKODE.Text = DGCARI.SelectedCells(0).Value
            BTNCARI.Text = "Cari (F1)"
            PNCARI.Visible = False
            DGCARI.DataSource = Nothing
            TXTTGLAWAL.Select()
        End If
    End Sub

    Private Sub TXTCARI_BARANG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI_BARANG.KeyPress
        If e.KeyChar = Chr(13) Then
            DGCARI.Select()
        End If
    End Sub

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Sub KONDISI_AWAL()
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        TXTKODE.Visible = False
        LBBARANG.Visible = False
        LBSATUAN.Visible = False
        LBSATUAN.Visible = False
        TXTTGLAWAL.Visible = False
        TXTTGLAKHIR.Visible = False
        TXTDISKON.Visible = False
        BTNSIMPAN.Visible = False
        BTNCARI.Visible = False
        Label12.Visible = False
        TXTMIN.Visible = False
        PNCARI.Visible = False
    End Sub

    Private Sub CBJENIS_TextChanged(sender As Object, e As EventArgs) Handles CBJENIS.TextChanged
        Select Case CBJENIS.SelectedIndex
            Case 0
                KONDISI_AWAL()
                Label5.Visible = True
                Label6.Visible = True
                Label7.Visible = True
                Label9.Visible = True
                Label10.Visible = True
                Label13.Visible = True
                Label14.Visible = True
                TXTKODE.Visible = True
                LBBARANG.Visible = True
                LBSATUAN.Visible = True
                LBSATUAN.Visible = True
                TXTTGLAWAL.Visible = True
                TXTTGLAKHIR.Visible = True
                TXTTGLAWAL.Location = New Point(151, 187)
                TXTTGLAKHIR.Location = New Point(151, 229)
                TXTDISKON.Location = New Point(151, 274)
                Label9.Location = New Point(10, 190)
                Label10.Location = New Point(10, 233)
                Label13.Location = New Point(10, 277)
                Label14.Location = New Point(213, 278)
                BTNSIMPAN.Location = New Point(151, 328)
                TXTDISKON.Visible = True
                BTNSIMPAN.Visible = True
                BTNCARI.Visible = True
            Case 1
                KONDISI_AWAL()
                Label12.Visible = True
                TXTMIN.Visible = True
                TXTTGLAWAL.Visible = True
                TXTTGLAKHIR.Visible = True
                Label9.Visible = True
                Label10.Visible = True
                Label13.Visible = True
                Label14.Visible = True
                TXTTGLAWAL.Location = New Point(151, 101)
                TXTTGLAKHIR.Location = New Point(151, 143)
                TXTDISKON.Location = New Point(151, 188)
                Label9.Location = New Point(10, 104)
                Label10.Location = New Point(10, 147)
                Label13.Location = New Point(10, 191)
                Label14.Location = New Point(213, 192)
                BTNSIMPAN.Location = New Point(151, 242)
                TXTDISKON.Visible = True
                BTNSIMPAN.Visible = True
        End Select
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If CBJENIS.SelectedIndex = 0 Then
            If TXTKODE.Text = "" Or LBBARANG.Text = "" Or TXTTGLAWAL.Text = "" Or TXTTGLAKHIR.Text = "" Or TXTDISKON.Text = "" Then
                MsgBox("Data tidak lengkap!")
                TXTKODE.Select()
            Else
                Dim STR As String = "INSERT INTO tbl_diskon (Jenis, Kode, Diskon, Tgl_awal, Tgl_akhir)" &
                " VALUES(" &
                " 'B'," &
                " '" & TXTKODE.Text & "'," &
                " '" & CInt(TXTDISKON.Text) & "'," &
                " '" & Format(TXTTGLAWAL.Value, "MM/dd/yyyy") & "'," &
                " '" & Format(TXTTGLAKHIR.Value, "MM/dd/yyyy") & "'" &
                " )"
                Dim CMD As New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data tersimpan")
                TXTKODE.Clear()
                TXTDISKON.Clear()
                TXTKODE.Select()
                TAMPIL()
            End If
        ElseIf CBJENIS.SelectedIndex = 1 Then
            If TXTMIN.Text = "" Or TXTTGLAWAL.Text = "" Or TXTTGLAKHIR.Text = "" Or TXTDISKON.Text = "" Then
                MsgBox("Data tidak lengkap!")
                TXTKODE.Select()
            Else
                Dim STR As String = "INSERT INTO tbl_diskon (Jenis, Min_transaksi, Diskon, Tgl_awal, Tgl_akhir)" &
                " VALUES(" &
                " 'A'," &
                " '" & TXTMIN.Text & "'," &
                " '" & TXTDISKON.Text & "'," &
                " '" & Format(TXTTGLAWAL.Value, "MM/dd/yyyy") & "'," &
                " '" & Format(TXTTGLAKHIR.Value, "MM/dd/yyyy") & "'" &
                " )"
                Dim CMD As New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data tersimpan")
                TXTMIN.Clear()
                TXTDISKON.Clear()
                CBJENIS.Select()
                TAMPIL()
            End If
        End If
    End Sub

    Private Sub TXTMIN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTMIN.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            TXTTGLAWAL.Select()
        End If
    End Sub

    Private Sub CBJENIS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBJENIS.KeyPress
        If e.KeyChar = Chr(13) Then
            If CBJENIS.SelectedIndex = 0 Then
                TXTTGLAWAL.Select()
            ElseIf CBJENIS.SelectedIndex = 1 Then
                TXTMIN.Select()
            End If
        End If
    End Sub
End Class