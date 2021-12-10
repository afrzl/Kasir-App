Imports System.Data.SqlClient
Public Class FR_DISKON
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
        CBTAMPIL.Text = "Semua"

        TXTKODE.Select()
        TAMPIL()
    End Sub

    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 30

    Sub TAMPIL()
        Dim TGL_SKRG As String = Format(Date.Now, "yyyy-MM-dd")
        Dim STR As String = ""
        If CBTAMPIL.Text = "Semua" Then
            STR = "SELECT Id," &
                " RTRIM(Kode) AS 'Kode Barang'," &
                " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_diskon.Kode)) AS 'Nama Barang'," &
                " Tgl_awal as 'Tanggal Awal'," &
                " Tgl_akhir AS 'Tanggal Akhir'," &
                " RTRIM(Diskon) AS 'Diskon (%)'" &
                " FROM tbl_diskon" &
                " WHERE (SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_diskon.Kode)) Like '%" & TXTCARI.Text & "%' ORDER BY Tgl_awal ASC"
        ElseIf CBTAMPIL.Text = "Berlalu" Then
            STR = "SELECT Id," &
                " RTRIM(Kode) AS 'Kode Barang'," &
                " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_diskon.Kode)) AS 'Nama Barang'," &
                " Tgl_awal AS 'Tanggal Awal'," &
                " Tgl_akhir AS 'Tanggal Akhir'," &
                " RTRIM(Diskon) AS 'Diskon (%)'" &
                " FROM tbl_diskon" &
                " WHERE (SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_diskon.Kode))" &
                " Like '%" & TXTCARI.Text & "%' AND Tgl_akhir < '" & TGL_SKRG & "' ORDER BY Tgl_awal ASC"
        ElseIf CBTAMPIL.Text = "Sekarang" Then
            STR = "SELECT Id," &
                " RTRIM(Kode) AS 'Kode Barang'," &
                " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_diskon.Kode)) AS 'Nama Barang'," &
                " Tgl_awal as 'Tanggal Awal'," &
                " Tgl_akhir AS 'Tanggal Akhir'," &
                " RTRIM(Diskon) AS 'Diskon (%)'" &
                " FROM tbl_diskon" &
                " WHERE (SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_diskon.Kode))" &
                " Like '%" & TXTCARI.Text & "%' AND Tgl_awal <= '" & TGL_SKRG & "' AND Tgl_akhir >= '" & TGL_SKRG & "' ORDER BY Tgl_awal ASC"
        ElseIf CBTAMPIL.Text = "Akan Datang" Then
            STR = "SELECT Id," &
                " RTRIM(Kode) AS 'Kode Barang'," &
                " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_diskon.Kode)) AS 'Nama Barang'," &
                " Tgl_awal as 'Tanggal Awal'," &
                " Tgl_akhir AS 'Tanggal Akhir'," &
                " RTRIM(Diskon) AS 'Diskon (%)'" &
                " FROM tbl_diskon" &
                " WHERE (SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_diskon.Kode))" &
                " Like '%" & TXTCARI.Text & "%' AND Tgl_awal > '" & TGL_SKRG & "' ORDER BY Tgl_awal ASC"
        Else
            STR = "SELECT Id," &
                " RTRIM(Kode) AS 'Kode Barang'," &
                " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_diskon.Kode)) AS 'Nama Barang'," &
                " Tgl_awal as 'Tanggal Awal'," &
                " Tgl_akhir AS 'Tanggal Akhir'," &
                " RTRIM(Diskon) AS 'Diskon (%)'" &
                " FROM tbl_diskon" &
                " WHERE (SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_diskon.Kode)) Like '%" & TXTCARI.Text & "%' ORDER BY Tgl_awal ASC"
        End If
        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL, START_RECORD, TAMPIL_RECORD, 0)
        DGTAMPIL.DataSource = TBL.Tables(0)


        DGTAMPIL.Columns(0).Visible = False
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGTAMPIL.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGTAMPIL.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGTAMPIL.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGTAMPIL.Columns(5).DefaultCellStyle.Format = "##%"


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
            " FROM tbl_barang WHERE Barang LIKE '%" & TXTCARI_BARANG.Text & "%'"
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
            'TXTCARI.Clear()'
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
        Dim STR As String = "SELECT * FROM tbl_barang WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
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

    Private Sub BTNSTOK_Click(sender As Object, e As EventArgs) Handles BTNSTOK.Click
        If TXTKODE.Text = "" Or LBBARANG.Text = "" Or TXTTGLAWAL.Text = "" Or TXTTGLAKHIR.Text = "" Or TXTDISKON.Text = "" Then
            MsgBox("Data tidak lengkap!")
            TXTKODE.Select()
        Else
            Dim STR As String = "INSERT INTO tbl_diskon (Kode, Diskon, Tgl_awal, Tgl_akhir)" &
                " VALUES(" &
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

    Private Sub TXTCARI_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI.TextChanged
        START_RECORD = 0
        TAMPIL()
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
            BTNSTOK.Select()
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
End Class