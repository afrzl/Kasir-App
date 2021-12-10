Imports System.Data.SqlClient

Public Class FR_RETURN
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

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub FR_RETURN_Load(sender As Object, e As EventArgs) Handles Me.Load
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN

        TXTID.Select()
        TAMPIL()
    End Sub

    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Sub TAMPIL()
        Dim STR As String = "SELECT tbl_transaksi_child.Id_trans as 'ID Transaksi'," &
            " RTRIM((SELECT Nama FROM tbl_karyawan WHERE RTRIM(tbl_karyawan.Id) = RTRIM(tbl_transaksi_parent.Id_kasir))) AS 'Kasir'," &
            " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
            " RTRIM(tbl_transaksi_parent.Person) AS 'Pembeli'," &
            " tbl_transaksi_child.Harga as 'Harga Jual'" &
            " FROM tbl_transaksi_child " &
            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
            " WHERE LEFT(tbl_transaksi_child.Id_trans, 1) = 'R' AND" &
            " tbl_transaksi_child.Id_trans LIKE '%" & TXTCARI.Text & "%'"
        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGTAMPIL.DataSource = TBL

        DGTAMPIL.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGTAMPIL.Columns(4).DefaultCellStyle.Format = "Rp ###,##"
        DGTAMPIL.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Sub DATA_TRANSAKSI()
        Dim STR As String = "SELECT RTRIM(Kode) AS Kode," &
            " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode) = RTRIM(tbl_transaksi_child.Kode)) AS Barang" &
            " FROM tbl_transaksi_child" &
            " WHERE Id_trans = '" & TXTID.Text & "'"
        Dim DA As SqlDataAdapter
        Dim TBL As New DataTable
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL)

        CBKODE.DataSource = TBL
        CBKODE.DisplayMember = "Barang"
        CBKODE.ValueMember = "Kode"
    End Sub

    Private Sub TXTID_TextChanged(sender As Object, e As EventArgs) Handles TXTID.TextChanged
        CBKODE.SelectedIndex = -1
        DATA_TRANSAKSI()
    End Sub

    Sub TAMPIL_PNCARI()
        If PNCARI.Visible = False Then
            PNCARI.Visible = True
            BTNCARI.Text = "Tutup (F1)"
            TXTCARI_TRANS.Clear()
            DGCARI.DataSource = Nothing
            TXTCARI_TRANS.Select()
            CARI_TRANSAKSI()
        Else
            BTNCARI.Text = "Cari (F1)"
            PNCARI.Visible = False
            DGCARI.DataSource = Nothing
            TXTID.Select()
        End If
    End Sub

    Sub CARI_TRANSAKSI()
        Dim STR As String = "SELECT RTRIM(Id_trans) AS 'ID Transaksi'," &
            " Tgl AS 'Tanggal Transaksi'" &
            " FROM tbl_transaksi_parent WHERE LEFT(Id_trans, 1) = 'K'" &
            " AND Id_trans Like '%" & TXTCARI_TRANS.Text & "%'"
        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGCARI.DataSource = TBL
        DGCARI.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGCARI.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub BTNCARI_Click(sender As Object, e As EventArgs) Handles BTNCARI.Click
        TAMPIL_PNCARI()
    End Sub

    Private Sub TXTCARI_TRANS_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI_TRANS.TextChanged
        CARI_TRANSAKSI()
    End Sub

    Private Sub DGCARI_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCARI.CellDoubleClick
        On Error Resume Next
        TXTID.Text = DGCARI.Item(0, e.RowIndex).Value
        BTNCARI.Text = "Cari (F1)"
        CBKODE.Select()
        PNCARI.Visible = False
        DGCARI.DataSource = Nothing
    End Sub

    Private Sub CBKODE_TextChanged(sender As Object, e As EventArgs) Handles CBKODE.TextChanged
        On Error Resume Next
        Dim STR As String = "SELECT Harga_akhir, Jumlah" &
            " FROM tbl_transaksi_child WHERE Id_trans='" & TXTID.Text & "'" &
            " AND Kode = '" & CBKODE.SelectedValue & "'"
        Dim CMD As New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTHARGA.Text = CInt(RD.Item("Harga_akhir") / RD.Item("Jumlah"))
            RD.Close()
        Else
            RD.Close()
        End If
        RD.Close()
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If
    End Sub

    Private Sub TXTID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTID.KeyPress
        If e.KeyChar = Chr(13) Then
            CBKODE.Select()
        End If
    End Sub

    Private Sub CBKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTQTY.Select()
        End If
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If TXTID.Text = "" Or CBKODE.Text = "" Or TXTQTY.Text = "" Then
            MsgBox("Data tidak lengkap!")
        Else
            Dim ID_TRANS As String = "R" + Mid(TXTID.Text, 2)
            Dim PEMBELI As String = ""

            Dim STR As String
            Dim CMD As SqlCommand

            STR = "SELECT RTRIM(Person) AS Pembeli " &
                " FROM tbl_transaksi_parent" &
                " WHERE RTRIM(Id_trans) = '" & TXTID.Text & "'"
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Read()
                PEMBELI = RD.Item("Pembeli")
                RD.Close()
            Else
                RD.Close()
            End If
            RD.Close()

            STR = "INSERT INTO tbl_transaksi_parent" &
                " (Id_trans, Id_kasir, Tgl, Jenis, Person)" &
                " VALUES('" & ID_TRANS & "'," &
                " '" & My.Settings.ID_ACCOUNT & "'," &
                " '" & Format(Date.Now, "MM/dd/yyyy HH:mm:ss") & "'," &
                " 'R'," &
                " '" & PEMBELI & "')"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            STR = "INSERT INTO tbl_transaksi_child (Id_trans, Kode, Jumlah, Harga, Stok) VALUES" &
                        " ('" & ID_TRANS & "'," &
                        " '" & CBKODE.SelectedValue & "'," &
                        " '" & TXTQTY.Text & "'," &
                        " '" & TXTHARGA.Text & "'," &
                        " '" & TXTQTY.Text & "')"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            MsgBox("Return berhasil disimpan! Stok " & CBKODE.SelectedText & " ditambah.")
            TXTID.Clear()
            TXTQTY.Clear()
            TXTHARGA.Clear()
            TAMPIL()
            TXTID.Select()
        End If
    End Sub

    Private Sub TXTID_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTID.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
        End Select
    End Sub

    Private Sub TXTCARI_TRANS_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCARI_TRANS.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
        End Select
    End Sub

    Private Sub DGCARI_KeyDown(sender As Object, e As KeyEventArgs) Handles DGCARI.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
        End Select
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        Dim FR As New FR_MENU
        FR.Show()
        Me.Close()
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TXTCARI_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI.TextChanged
        TAMPIL()
    End Sub

    Private Sub HapusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusToolStripMenuItem.Click
        If MsgBox("Apakah anda yakin akan menghapus data transaksi?", vbYesNo) = vbYes Then
            Dim IDX As String = DGTAMPIL.Item(0, DGTAMPIL.CurrentRow.Index).Value
            Dim CMD As New SqlCommand("DELETE FROM tbl_transaksi_child WHERE Id_trans='" & IDX & "'", CONN)
            CMD.ExecuteNonQuery()

            CMD = New SqlCommand("DELETE FROM tbl_transaksi_parent WHERE Id_trans='" & IDX & "'", CONN)
            CMD.ExecuteNonQuery()
            TAMPIL()
            MsgBox("Data return barang berhasil dihapus")
        End If
    End Sub

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
    End Sub
End Class