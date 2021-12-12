Imports System.Data.SqlClient

Public Class FR_RUSAK
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

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
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
        Dim STR As String = "SELECT RTRIM(tbl_transaksi_child.Id_trans) as 'ID Transaksi'," &
            " RTRIM(tbl_transaksi_child.Kode) AS 'Kode Barang'," &
            " RTRIM((SELECT Barang FROM tbl_barang WHERE RTRIM(tbl_barang.Kode) = RTRIM(tbl_transaksi_child.Kode))) AS 'Nama Barang'," &
            " RTRIM((SELECT Nama FROM tbl_karyawan WHERE RTRIM(tbl_karyawan.Id) = RTRIM(tbl_transaksi_parent.Id_kasir))) AS 'Kasir'," &
            " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
            " RTRIM(tbl_transaksi_parent.Person) AS 'Pembeli'," &
            " tbl_transaksi_child.Harga as 'Harga Beli'," &
            " RTRIM(tbl_transaksi_child.Jumlah) AS 'QTY'" &
            " FROM tbl_transaksi_child " &
            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_parent.Id_trans = tbl_transaksi_child.Id_trans" &
            " WHERE LEFT(tbl_transaksi_child.Id_trans, 1) = 'C' AND" &
            " tbl_transaksi_child.Id_trans LIKE '%" & TXTCARI.Text & "%'"
        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGTAMPIL.DataSource = TBL

        DGTAMPIL.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DGTAMPIL.Columns(6).DefaultCellStyle.Format = "Rp ###,##"
        DGTAMPIL.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGTAMPIL.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            " Tgl AS 'Tanggal Transaksi'," &
            " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(tbl_barang.Kode) = (SELECT RTRIM(Kode) FROM tbl_transaksi_child WHERE RTRIM(tbl_transaksi_child.Id_trans) = RTRIM(tbl_transaksi_parent.Id_trans))) AS 'Nama Produk'" &
            " FROM tbl_transaksi_parent WHERE LEFT(Id_trans, 1) = 'M'" &
            " AND Id_trans Like '%" & TXTCARI_TRANS.Text & "%'"
        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGCARI.DataSource = TBL
        DGCARI.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGCARI.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGCARI.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub BTNCARI_Click(sender As Object, e As EventArgs) Handles BTNCARI.Click
        TAMPIL_PNCARI()
    End Sub

    Private Sub DGCARI_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCARI.CellDoubleClick
        On Error Resume Next
        TXTQTY.Select()
        TXTID.Text = DGCARI.Item(0, e.RowIndex).Value
        BTNCARI.Text = "Cari (F1)"
        PNCARI.Visible = False
        DGCARI.DataSource = Nothing
    End Sub

    Private Sub TXTID_TextChanged(sender As Object, e As EventArgs) Handles TXTID.TextChanged
        Dim STR As String = "SELECT RTRIM(Id_trans) AS Id_trans, " &
            " RTRIM(Kode) AS Kode," &
            " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(tbl_barang.Kode) = tbl_transaksi_child.Kode) AS 'Barang'," &
            " Harga AS Harga," &
            " RTRIM(Stok) AS Stok" &
            " FROM tbl_transaksi_child WHERE RTRIM(Id_trans)='" & TXTID.Text & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTKODE.Text = RD.Item("Kode").ToString.Trim
            TXTBARANG.Text = RD.Item("Barang").ToString.Trim
            TXTHARGA.Text = CInt(RD.Item("Harga"))
            TXTSTOK.Text = CInt(RD.Item("Stok"))
            If CInt(RD.Item("Stok")) = 0 Then
                MsgBox("Stok barang masuk dengan ID " & RD.Item("Id_trans").ToString.Trim & " telah habis. Transaksi tidak dapat dilakukan")
                RD.Close()
                TXTID.Text = ""
                TXTKODE.Text = ""
                TXTBARANG.Text = ""
                TXTHARGA.Text = ""
                TXTSTOK.Text = 0
                TXTID.Select()
            End If
            RD.Close()
        Else
            RD.Close()
            TXTKODE.Text = ""
            TXTBARANG.Text = ""
            TXTHARGA.Text = ""
            TXTSTOK.Text = 0
        End If
        RD.Close()
    End Sub

    Private Function CARI_ID(ByVal ID As String) As String
        Dim ID_RUSAK As String = "C" + ID
        Dim STR As String = "SELECT TOP 1 (Id_trans) AS Id_trans FROM tbl_transaksi_parent" &
            " WHERE LEFT(Id_trans, 10)='" & ID_RUSAK & "' ORDER BY Id DESC"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            If Mid(RD.Item("Id_trans"), 1, 10) = ID_RUSAK Then
                Dim KODE As Integer = Mid(RD.Item("Id_trans"), 11, 2) + 1
                RD.Close()
                CARI_ID = Format(KODE, "00")
            Else
                RD.Close()
                CARI_ID = Format(1, "00")
            End If
        Else
            RD.Close()
            CARI_ID = Format(1, "00")
        End If
        RD.Close()
    End Function

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        Dim QTY As Integer = 0
        If TXTQTY.Text <> "" Then
            QTY = CInt(TXTQTY.Text)
        End If
        If TXTID.Text = "" Or TXTQTY.Text = "" Then
            MsgBox("Data tidak lengkap!")
        ElseIf QTY > CInt(TXTSTOK.Text) Then
            MsgBox("QTY tidak boleh lebih dari stok masuk!")
            TXTQTY.Text = ""
            TXTQTY.Select()
        Else
            Dim ID_TRANS As String = "C" + Mid(TXTID.Text, 2) + CARI_ID(Mid(TXTID.Text, 2))
            Dim SUPPLIER As String = ""

            Dim STR As String
            Dim CMD As SqlCommand

            STR = "SELECT RTRIM(Person) AS Supplier " &
                " FROM tbl_transaksi_parent" &
                " WHERE RTRIM(Id_trans) = '" & TXTID.Text & "'"
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Read()
                SUPPLIER = RD.Item("Supplier")
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
                " 'C'," &
                " '" & SUPPLIER & "')"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            STR = "INSERT INTO tbl_transaksi_child (Id_trans, Kode, Jumlah, Harga) VALUES" &
                        " ('" & ID_TRANS & "'," &
                        " '" & TXTKODE.Text & "'," &
                        " '" & TXTQTY.Text & "'," &
                        " '" & TXTHARGA.Text & "')"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            Dim STOK_AKHIR As Integer = CInt(TXTSTOK.Text) - CInt(TXTQTY.Text)

            STR = "UPDATE tbl_transaksi_child SET Stok='" & STOK_AKHIR & "' WHERE Id_trans='" & TXTID.Text & "'"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            MsgBox("Barang rusak berhasil ditambah! Stok barang " & TXTBARANG.Text & " berkurang.")
            TXTID.Clear()
            TXTQTY.Clear()
            TXTHARGA.Clear()
            TAMPIL()
            TXTID.Select()
        End If
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
            TXTQTY.Select()
        End If
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

            Dim IDTRANS As String = DGTAMPIL.Item(0, DGTAMPIL.CurrentRow.Index).Value

            Dim CMD As New SqlCommand("DELETE FROM tbl_transaksi_parent WHERE Id_trans='" & IDTRANS & "'", CONN)
            CMD.ExecuteNonQuery()

            CMD = New SqlCommand("DELETE FROM tbl_transaksi_child WHERE Id_trans='" & IDTRANS & "'", CONN)
            CMD.ExecuteNonQuery()

            Dim ID_MASUK As String = "M" + Mid(IDTRANS, 2, 9)
            Dim STOK_AWAL As Integer
            Dim NAMA_BARANG As String

            Dim STR As String = "SELECT RTRIM(Stok) AS Stok, " &
                " (SELECT Barang FROM tbl_barang WHERE RTRIM(tbl_barang.Kode) = RTRIM(tbl_transaksi_child.Kode)) AS Nama" &
                " FROM tbl_transaksi_child WHERE RTRIM(Id_trans)='" & ID_MASUK & "'"
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Read()
                STOK_AWAL = CInt(RD.Item("Stok"))
                NAMA_BARANG = RD.Item("Nama")
                RD.Close()
            Else
                RD.Close()
                STOK_AWAL = 0
            End If
            RD.Close()

            Dim STOK_AKHIR As Integer = STOK_AWAL + CInt(DGTAMPIL.Item(7, DGTAMPIL.CurrentRow.Index).Value)

            STR = "UPDATE tbl_transaksi_child SET Stok='" & STOK_AKHIR & "' WHERE Id_trans='" & ID_MASUK & "'"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            TAMPIL()
            MsgBox("Data barang rusak berhasil dihapus, dan stok barang " & DGTAMPIL.Item(2, DGTAMPIL.CurrentRow.Index).Value & " ditambah.")
        End If
    End Sub

    Private Sub TXTID_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTID.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
        End Select
    End Sub

    Private Sub BTNMASUK_Click(sender As Object, e As EventArgs) Handles BTNMASUK.Click
        BUKA_FORM(FR_MASUK)
    End Sub
End Class