Imports System.Data.SqlClient

Public Class FR_MASUK
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy H:m:s")
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

    Private Sub BTNKELUAR_Click(sender As Object, e As EventArgs) Handles BTNKELUAR.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNLAPORAN_Click(sender As Object, e As EventArgs) Handles BTNLAPORAN.Click
        BUKA_FORM(FR_REPORT)
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

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNKASIR_Click(sender As Object, e As EventArgs) Handles BTNKASIR.Click
        BUKA_FORM(FR_KASIR)
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BTNBARANG_Click(sender As Object, e As EventArgs) Handles BTNBARANG.Click
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub FR_MASUK_Load(sender As Object, e As EventArgs) Handles Me.Load
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:MM:SS")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN

        TXTKODE.Select()
        TAMPIL()
    End Sub

    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 2

    Sub TAMPIL()
        'Dim STR As String = "SELECT Id, RTRIM(Kode) AS Kode," &
        '" (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) AS Barang,Jumlah,RTRIM(Supplier) AS Supplier," &
        '" Harga, Tgl, (SELECT RTRIM(Nama) FROM tbl_karyawan WHERE RTRIM(Id)=RTRIM(tbl_transaksi.Id_kasir)) As Kasir" &
        '" FROM tbl_transaksi WHERE Jenis='M' AND (SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi.Kode))" &
        '" LIKE '%" & TXTCARI.Text & "%'"

        Dim STR As String = "SELECT RTRIM(Id_trans) AS 'ID Transaksi', RTRIM(Kode) AS 'Kode Barang'," &
            " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) AS 'Nama Barang'," &
            " Jumlah as 'Stok Masuk', Harga AS 'Harga Partai' FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
            " (SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%' ORDER BY Id ASC"
        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL, START_RECORD, TAMPIL_RECORD, 0)
        DGTAMPIL.DataSource = TBL.Tables(0)

        DGTAMPIL.Columns(4).DefaultCellStyle.Format = "Rp ###,##"

        DGTAMPIL.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

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

    Private Function CEK_HARGA() As Boolean
        Dim STR As String = "SELECT * FROM tbl_barang WHERE Kode='" & TXTKODE.Text & "'"
        Dim CMD As New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        RD.Read()
        Dim HARGA_TERENDAH As Integer = 0
        If Not RD.Item("Start5") = 0 Then
            HARGA_TERENDAH = RD.Item("Harga5")
        Else
            If Not RD.Item("Start4") = 0 Then
                HARGA_TERENDAH = RD.Item("Harga4")
            Else
                If Not RD.Item("Start3") = 0 Then
                    HARGA_TERENDAH = RD.Item("Harga3")
                Else
                    If Not RD.Item("Start2") = 0 Then
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
            TXTJUMLAH.Select()
        End If
    End Sub

    Private Sub TXTJUMLAH_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTJUMLAH.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            TXTSUPPLIER.Select()
        End If
    End Sub

    Private Sub TXTSUPPLIER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSUPPLIER.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTHARGAPARTAI.Select()
        End If
    End Sub

    Private Sub TXTHARGAPARTAI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGAPARTAI.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSTOK.Select()
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

    Private Sub BTNTAMBAH_Click(sender As Object, e As EventArgs) Handles BTNTAMBAH.Click
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub BTNSTOK_Click(sender As Object, e As EventArgs) Handles BTNSTOK.Click
        If TXTKODE.Text = "" Or LBBARANG.Text = "" Or TXTJUMLAH.Text = "" Or TXTHARGAPARTAI.Text = "" Then
            MsgBox("Data tidak lengkap!")
            TXTKODE.Select()
        ElseIf CInt(TXTJUMLAH.Text) <= 0 Then
            MsgBox("Jumlah barang harus lebih dari 0!")
        Else
            If CEK_HARGA() = True Then
                Dim ID_TRANS As String = AUTOID()
                Dim STR As String = "INSERT INTO tbl_transaksi_child (Id_trans, Kode, Jumlah, Harga)" &
                " VALUES('" & ID_TRANS & "','" & TXTKODE.Text & "','" & CInt(TXTJUMLAH.Text) & "','" &
                CInt(TXTHARGAPARTAI.Text) & "')"
                Dim CMD As New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()

                STR = "INSERT INTO tbl_transaksi_parent (Id_trans, Id_kasir, Tgl, Jenis, Person) VALUES" &
                "('" & ID_TRANS & "','" & My.Settings.ID_ACCOUNT & "','" & Format(Date.Now, "MM/dd/yyyy h:m:s") & "','M','" & TXTSUPPLIER.Text & "')"
                CMD = New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data tersimpan")
                TXTKODE.Clear()
                TXTJUMLAH.Clear()
                TXTHARGAPARTAI.Clear()
                TXTSUPPLIER.Clear()
                TXTKODE.Select()
                TAMPIL()
            Else
                MsgBox("Harga partai harus lebih rendah dari harga jual produk, silahkan ubah harga jual!")
                TXTHARGAPARTAI.Clear()
                TXTHARGAPARTAI.Select()
            End If
        End If
    End Sub

    Private Sub HapusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusToolStripMenuItem.Click
        If MsgBox("Apakah anda yakin akan menghapus data transaksi?", vbYesNo) = vbYes Then
            Dim IDX As String = DGTAMPIL.Item(0, DGTAMPIL.CurrentRow.Index).Value
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
            TXTKODE.Text = DGCARI.Item(0, DGTAMPIL.CurrentRow.Index).Value
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
End Class