Imports System.Data.SqlClient

Public Class FR_RUSAK
    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
    End Sub

    Private Sub FR_RETURN_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case ROLE
            Case 1
                PNADMIN.Visible = True
                PNOPS.Visible = False
                Label3.Text = "Administrator"
            Case 2
                PNADMIN.Visible = False
                PNOPS.Visible = True
                Label3.Text = "Operator"
        End Select
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN

        TXTID.Select()
        TAMPIL()
        TAMPIL_EXPIRED()
    End Sub

    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Sub TAMPIL_EXPIRED()
        Dim TANGGAL_HARI_INI As String = Format(Date.Now, "yyyy-MM-dd")

        Dim STR As String = "SELECT tbl_transaksi_child.Id," &
            " RTRIM(tbl_transaksi_child.Id_trans) As 'ID Transaksi'," &
            " RTRIM(tbl_transaksi_child.Kode) AS 'Kode Barang'," &
            " RTRIM((SELECT Barang FROM tbl_barang WHERE RTRIM(tbl_barang.Kode) = RTRIM(tbl_transaksi_child.Kode))) AS 'Nama Barang'," &
            " tbl_transaksi_parent.Tgl AS 'Tanggal Masuk'," &
            " RTRIM(tbl_transaksi_parent.Person) AS 'Supplier'," &
            " tbl_transaksi_child.Stok AS 'QTY'," &
            " tbl_transaksi_child.Tgl_exp AS 'Tanggal Expired'" &
            " FROM tbl_transaksi_child " &
            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_parent.Id_trans = tbl_transaksi_child.Id_trans" &
            " WHERE LEFT(tbl_transaksi_child.Id_trans, 1) = 'M' AND" &
            " tbl_transaksi_child.Stok != 0 AND" &
            " tbl_transaksi_child.Tgl_exp <= DATEADD(day,+14, GETDATE())"

        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGEXPIRED.DataSource = TBL

        DGEXPIRED.Columns(0).Visible = False
        DGEXPIRED.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGEXPIRED.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGEXPIRED.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGEXPIRED.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGEXPIRED.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGEXPIRED.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGEXPIRED.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGEXPIRED.Columns(6).DefaultCellStyle.Format = "##0.##"
        DGEXPIRED.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Sub TAMPIL()
        Dim STR As String
        Select Case ROLE
            Case 1
                STR = "SELECT Id_awal, " &
                    " RTRIM(tbl_transaksi_child.Id_trans) As 'ID Transaksi'," &
            " RTRIM(tbl_transaksi_child.Kode) AS 'Kode Barang'," &
            " RTRIM((SELECT Barang FROM tbl_barang WHERE RTRIM(tbl_barang.Kode) = RTRIM(tbl_transaksi_child.Kode))) AS 'Nama Barang'," &
            " RTRIM((SELECT Nama FROM tbl_karyawan WHERE RTRIM(tbl_karyawan.Id) = RTRIM(tbl_transaksi_parent.Id_kasir))) AS 'Kasir'," &
            " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
            " RTRIM(tbl_transaksi_parent.Person) AS 'Supplier'," &
            " tbl_transaksi_child.Harga_beli as 'Rugi'," &
            " tbl_transaksi_child.Jumlah AS 'QTY'" &
            " FROM tbl_transaksi_child " &
            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_parent.Id_trans = tbl_transaksi_child.Id_trans" &
            " WHERE LEFT(tbl_transaksi_child.Id_trans, 1) = 'C' AND" &
            " tbl_transaksi_child.Id_trans LIKE '%" & TXTCARI.Text & "%'"
            Case 2
                STR = "SELECT Id_awal, " &
                    " RTRIM(tbl_transaksi_child.Id_trans) as 'ID Transaksi'," &
            " RTRIM(tbl_transaksi_child.Kode) AS 'Kode Barang'," &
            " RTRIM((SELECT Barang FROM tbl_barang WHERE RTRIM(tbl_barang.Kode) = RTRIM(tbl_transaksi_child.Kode))) AS 'Nama Barang'," &
            " RTRIM((SELECT Nama FROM tbl_karyawan WHERE RTRIM(tbl_karyawan.Id) = RTRIM(tbl_transaksi_parent.Id_kasir))) AS 'Kasir'," &
            " tbl_transaksi_parent.Tgl AS 'Tanggal'," &
            " RTRIM(tbl_transaksi_parent.Person) AS 'Supplier'," &
            " tbl_transaksi_child.Harga_beli as 'Rugi'," &
            " tbl_transaksi_child.Jumlah AS 'QTY'" &
            " FROM tbl_transaksi_child " &
            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_parent.Id_trans = tbl_transaksi_child.Id_trans" &
            " WHERE LEFT(tbl_transaksi_child.Id_trans, 1) = 'C'" &
            " AND tbl_transaksi_parent.Id_kasir = '" & My.Settings.ID_ACCOUNT & "'" &
            " AND tbl_transaksi_child.Id_trans LIKE '%" & TXTCARI.Text & "%'"
        End Select

        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGTAMPIL.DataSource = TBL

        DGTAMPIL.Columns(0).Visible = False
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DGTAMPIL.Columns(7).DefaultCellStyle.Format = "Rp ###,##"
        DGTAMPIL.Columns(8).DefaultCellStyle.Format = "##0.##"
        DGTAMPIL.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGTAMPIL.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            " FROM tbl_transaksi_parent WHERE LEFT(Id_trans, 1) = 'M'" &
            " AND Id_trans Like '%" & TXTCARI_TRANS.Text & "%'" &
            " AND (SELECT COALESCE(SUM(Stok), 0) FROM tbl_transaksi_child WHERE tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans) > 0" &
            " ORDER BY Tgl DESC"
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

    Private Sub DGCARI_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCARI.CellDoubleClick
        On Error Resume Next
        TXTID.Select()
        TXTID.Text = DGCARI.Item(0, e.RowIndex).Value
        BTNCARI.Text = "Cari (F1)"
        PNCARI.Visible = False
        DGCARI.DataSource = Nothing
    End Sub

    Sub DATA_TRANSAKSI()
        Dim STR As String = "SELECT Id, RTRIM(Kode) AS Kode," &
           " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode) = RTRIM(tbl_transaksi_child.Kode)) AS Barang" &
           " FROM tbl_transaksi_child" &
           " WHERE Id_trans = '" & TXTID.Text & "'" &
           " AND (SELECT COALESCE(SUM(Stok), 0) FROM tbl_transaksi_child WHERE tbl_transaksi_child.Id_trans = tbl_transaksi_child.Id_trans) > 0"
        Dim DA As SqlDataAdapter
        Dim TBL As New DataTable
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL)

        If TBL.Rows.Count = 0 Then
            MsgBox("Transaksi tidak ditemukan")
            TXTID.Clear()
            CBKODE.DataSource = Nothing
            CBKODE.SelectedIndex = -1
            TXTHARGA.Text = ""
            TXTSTOK.Text = ""
            TXTID.Select()
        Else
            CBKODE.DataSource = TBL
            CBKODE.DisplayMember = "Barang"
            CBKODE.ValueMember = "Id"
            CBKODE.SelectedIndex = 0
            CBKODE.Select()
        End If
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
        Dim QTY As Double = 0
        If TXTQTY.Text <> "" Then
            QTY = Convert.ToDouble(TXTQTY.Text)
        End If
        If TXTID.Text = "" Or TXTQTY.Text = "" Then
            MsgBox("Data tidak lengkap!")
        ElseIf QTY > TXTSTOK.Text Then
            MsgBox("QTY tidak boleh lebih dari stok tersedia!")
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
                " (Id_trans, Id_kasir, Tgl, Jenis, Person, Harga, Diskon, Jumlah_item, Harga_total)" &
                " VALUES('" & ID_TRANS & "'," &
                " '" & My.Settings.ID_ACCOUNT & "'," &
                " '" & Format(Date.Now, "MM/dd/yyyy HH:mm:ss") & "'," &
                " 'C'," &
                " '" & SUPPLIER & "'," &
                " 0," &
                " 0," &
                " " & TXTQTY.Text.Replace(",", ".") & "," &
                " 0)"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            STR = "INSERT INTO tbl_transaksi_child (Id_trans, Id_awal, Kode, Jumlah, Harga_beli, Harga, Harga_akhir) VALUES" &
                        " ('" & ID_TRANS & "'," &
                        " '" & CBKODE.SelectedValue & "'," &
                        " '" & KODEBARANG & "'," &
                        " " & TXTQTY.Text.Replace(",", ".") & "," &
                        " '" & CInt(TXTHARGA.Text) * QTY & "'," &
                        " 0," &
                        " 0)"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            TXTSTOKAKHIR.Text = Convert.ToDouble(TXTSTOK.Text) - QTY

            STR = "UPDATE tbl_transaksi_child SET Stok=" & TXTSTOKAKHIR.Text.Replace(",", ".") & " WHERE Id_trans='" & TXTID.Text & "'" &
                " AND Id = '" & CBKODE.SelectedValue & "'"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            STR = "UPDATE tbl_stok SET Stok-=" & TXTQTY.Text.Replace(",", ".") & " WHERE Kode='" & KODEBARANG & "'"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            MsgBox("Barang rusak berhasil ditambah! Stok barang " & CBKODE.Text & " berkurang.")
            TXTID.Clear()
            TXTQTY.Clear()
            TXTHARGA.Clear()
            TXTSTOK.Text = 0
            CBKODE.SelectedIndex = -1
            TAMPIL()
            TAMPIL_EXPIRED()
            TXTID.Select()
        End If
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
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
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        Dim FR As New Form
        Select Case ROLE
            Case 1
                FR = FR_MENU
            Case 2
                FR = FR_OPS_DASHBOARD
        End Select
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

            DGTAMPIL.Columns(0).Visible = True
            Dim IDTRANS As String = DGTAMPIL.Item(1, DGTAMPIL.CurrentRow.Index).Value
            Dim KODE_BARANG As String = DGTAMPIL.Item(2, DGTAMPIL.CurrentRow.Index).Value.ToString.Trim
            Dim NAMA_BARANG As String = DGTAMPIL.Item(3, DGTAMPIL.CurrentRow.Index).Value.ToString.Trim
            Dim ID_AWAL As Integer = DGTAMPIL.Item(0, DGTAMPIL.CurrentRow.Index).Value
            DGTAMPIL.Columns(0).Visible = False

            Dim CMD As New SqlCommand("DELETE FROM tbl_transaksi_parent WHERE Id_trans='" & IDTRANS & "'", CONN)
            CMD.ExecuteNonQuery()

            CMD = New SqlCommand("DELETE FROM tbl_transaksi_child WHERE Id_trans='" & IDTRANS & "'", CONN)
            CMD.ExecuteNonQuery()

            Dim ID_MASUK As String = "M" + Mid(IDTRANS, 2, 9)
            Dim STOK_AWAL As Double

            Dim STR As String = "SELECT Stok AS Stok, " &
                " (SELECT Barang FROM tbl_barang WHERE RTRIM(tbl_barang.Kode) = RTRIM(tbl_transaksi_child.Kode)) AS Nama" &
                " FROM tbl_transaksi_child WHERE Id='" & ID_AWAL & "'"
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Read()
                STOK_AWAL = RD.Item("Stok")
                NAMA_BARANG = RD.Item("Nama")
                RD.Close()
            Else
                RD.Close()
                STOK_AWAL = 0
            End If
            RD.Close()

            TXTSTOKAKHIR.Text = STOK_AWAL + DGTAMPIL.Item(8, DGTAMPIL.CurrentRow.Index).Value

            STR = "UPDATE tbl_transaksi_child SET Stok=" & TXTSTOKAKHIR.Text.Replace(",", ".") & " WHERE Id='" & ID_AWAL & "'"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            TAMPIL()
            TAMPIL_EXPIRED()
            MsgBox("Data barang rusak berhasil dihapus, dan stok barang " & NAMA_BARANG & " ditambah.")
        End If
    End Sub

    Private Sub TXTID_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTID.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
        End Select
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        If MsgBox("Apakah anda yakin akan logout?", vbYesNo) = vbYes Then
            Dim FR As New FR_LOGIN
            My.Settings.ID_ACCOUNT = 0
            FR.Show()
            Me.Close()
        End If
    End Sub

    Sub CARI_HARGA()
        Dim STR As String

        STR = "SELECT RTRIM(Kode) AS Kode " &
                " FROM tbl_transaksi_child" &
                " WHERE Id = '" & CBKODE.SelectedValue & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            KODEBARANG = RD.Item("Kode")
            RD.Close()
        Else
            RD.Close()
        End If
        RD.Close()

        STR = "SELECT Harga AS 'Harga'," _
                            & "(COALESCE(Stok, 0)) AS 'Stok'" _
                            & " FROM tbl_transaksi_child WHERE Id='" _
                            & CBKODE.SelectedValue _
                            & "'" _
                            & " AND Kode = '" _
                            & KODEBARANG _
                            & "'"
        CMD = New SqlCommand(STR, CONN)
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTHARGA.Text = CInt(RD.Item("Harga"))
            If RD.Item("Stok") <> 0 Then
                TXTSTOK.Text = Format(RD.Item("Stok"), "##0.##")
            Else
                TXTSTOK.Text = 0
            End If
            RD.Close()
        Else
            RD.Close()
        End If
        RD.Close()
    End Sub

    Dim KODEBARANG As String
    Private Sub CBKODE_TextChanged(sender As Object, e As EventArgs) Handles CBKODE.TextChanged
        On Error Resume Next

        CARI_HARGA()
    End Sub

    Private Sub CBKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTQTY.Select()
        End If
    End Sub

    Private Sub BTNKASIR_Click(sender As Object, e As EventArgs) Handles BTNKASIR.Click
        BUKA_FORM(FR_KASIR)
    End Sub

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNBARANG_Click(sender As Object, e As EventArgs) Handles BTNBARANG.Click
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub BTNLABELADMIN_Click(sender As Object, e As EventArgs) Handles BTNLABELADMIN.Click
        BUKA_FORM(FR_CETAK_LABEL)
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

    Private Sub BTNLAPORAN_Click(sender As Object, e As EventArgs) Handles BTNLAPORAN.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNDASHBOARDOPS_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDOPS.Click
        BUKA_FORM(FR_OPS_DASHBOARD)
    End Sub

    Private Sub BTNLABELOPS_Click(sender As Object, e As EventArgs) Handles BTNLABELOPS.Click
        BUKA_FORM(FR_CETAK_LABEL)
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

    Private Sub BTNLAPORANOPS_Click(sender As Object, e As EventArgs) Handles BTNLAPORANOPS.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNTENTANGOPS_Click(sender As Object, e As EventArgs) Handles BTNTENTANGOPS.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub DGEXPIRED_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGEXPIRED.CellClick
        On Error Resume Next
        TXTID.Text = DGEXPIRED.Item(1, e.RowIndex).Value

        DATA_TRANSAKSI()

        DGEXPIRED.Columns(0).Visible = True
        CBKODE.SelectedValue = DGEXPIRED.Item(0, e.RowIndex).Value
        DGEXPIRED.Columns(0).Visible = False
        CARI_HARGA()
        TXTQTY.Text = TXTSTOK.Text
    End Sub

    Private Sub CBKODE_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBKODE.SelectedValueChanged
        On Error Resume Next

        CARI_HARGA()
    End Sub

    Private Sub TXTCARI_TRANS_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCARI_TRANS.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
            Case Keys.Enter
                DGCARI.Select()
        End Select
    End Sub

    Private Sub DGCARI_KeyDown(sender As Object, e As KeyEventArgs) Handles DGCARI.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
            Case Keys.Enter
                e.Handled = True
                DGCARI.CurrentCell = DGCARI.Rows(DGCARI.CurrentRow.Index).Cells(0)
                TXTID.Text = DGCARI.SelectedCells(0).Value
                BTNCARI.Text = "Cari (F1)"
                TXTID.Select()
                PNCARI.Visible = False
                DGCARI.DataSource = Nothing
        End Select
    End Sub

    Private Sub TXTCARI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTCARI_TRANS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI_TRANS.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub BTNBARCODEOPS_Click(sender As Object, e As EventArgs) Handles BTNBARCODEOPS.Click
        BUKA_FORM(FR_CETAKBARCODE)
    End Sub

    Private Sub TXTID_Leave(sender As Object, e As EventArgs) Handles TXTID.Leave
        If TXTID.Text <> "" Then
            DATA_TRANSAKSI()
            CARI_HARGA()
        End If
    End Sub

    Private Sub BTNHISTORYPENJUALAN_Click(sender As Object, e As EventArgs) Handles BTNHISTORYPENJUALAN.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub
End Class