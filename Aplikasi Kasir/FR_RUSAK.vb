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
        DGEXPIRED.Columns.Clear()
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

        Dim Column_masuk = New DataGridViewButtonColumn
        With Column_masuk
            .Text = "Edit"
            .HeaderText = "Edit"
            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .CellTemplate.Style.BackColor = Color.DarkGreen
            .CellTemplate.Style.ForeColor = Color.WhiteSmoke
            .Width = 100
        End With
        DGEXPIRED.Columns.Add(Column_masuk)

        Dim Column_fr_masuk = New DataGridViewButtonColumn
        With Column_fr_masuk
            .Text = "History"
            .HeaderText = "History"
            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .CellTemplate.Style.BackColor = Color.Crimson
            .CellTemplate.Style.ForeColor = Color.WhiteSmoke
            .Width = 100
        End With
        DGEXPIRED.Columns.Add(Column_fr_masuk)

        DGEXPIRED.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Sub TAMPIL()
        DGTAMPIL.Columns.Clear()
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
        DGTAMPIL.Columns(2).Visible = False

        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
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

        Dim Column_delete = New DataGridViewButtonColumn
        With Column_delete
            .Text = "Delete"
            .HeaderText = "Delete"
            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .CellTemplate.Style.BackColor = Color.Crimson
            .CellTemplate.Style.ForeColor = Color.WhiteSmoke
            .Width = 100
        End With
        DGTAMPIL.Columns.Add(Column_delete)

        DGTAMPIL.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Sub TAMPIL_PNCARI()
        Me.Enabled = False
        With FR_RETURN_LIST
            .Show()
            .LB_TITLE.Text = "FR_RUSAK"
            .TAMPIL()
            .TXTCARI_TRANS.Select()
        End With
    End Sub

    Private Sub BTNCARI_Click(sender As Object, e As EventArgs) Handles BTNCARI.Click
        TAMPIL_PNCARI()
    End Sub

    Sub DATA_TRANSAKSI()
        Dim STR As String = "SELECT Id, RTRIM(Kode) AS Kode," &
           " (SELECT RTRIM(Barang) FROM tbl_barang WHERE RTRIM(Kode) = RTRIM(tbl_transaksi_child.Kode)) AS Barang," &
           " Tgl_exp as Tgl_exp" &
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
        If CB_JENISTRANS.SelectedIndex = 0 Then
            Dim QTY As Double = 0
            If TXTQTY.Text <> "" Then
                QTY = Convert.ToDouble(TXTQTY.Text)
            End If
            If TXTID.Text = "" Or TXTQTY.Text = "" Or CB_JENISTRANS.SelectedIndex < 0 Then
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

                STR = "INSERT INTO tbl_transaksi_child (Id_trans, Id_awal, Kode, Jumlah, Harga_beli, Harga, Harga_akhir, Created_at) VALUES" &
                        " ('" & ID_TRANS & "'," &
                        " '" & CBKODE.SelectedValue & "'," &
                        " '" & KODEBARANG & "'," &
                        " " & TXTQTY.Text.Replace(",", ".") & "," &
                        " '" & CInt(TXTHARGA.Text) * QTY & "'," &
                        " 0," &
                        " 0," &
                        " '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "')"
                CMD = New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()

                TXTSTOKAKHIR.Text = Convert.ToDouble(TXTSTOK.Text) - QTY

                STR = "UPDATE tbl_transaksi_child SET Stok=" & TXTSTOKAKHIR.Text.Replace(",", ".") & ", " &
                    " Modified_at = '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                    " WHERE Id_trans='" & TXTID.Text & "'" &
                    " AND Id = '" & CBKODE.SelectedValue & "'"
                CMD = New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()

                STR = "UPDATE tbl_stok SET Stok-=" & TXTQTY.Text.Replace(",", ".") & ", " &
                    " Modified_at = '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                    " WHERE Kode='" & KODEBARANG & "'"
                CMD = New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()

                MsgBox("Barang rusak berhasil ditambah! Stok barang " & CBKODE.Text & " berkurang.")
            End If
        ElseIf CB_JENISTRANS.SelectedIndex = 1 Then
            Dim TGL_EXP As String = Format(Convert.ToDateTime(DTEXP.Value), "yyyy-MM-dd")
            Dim STR As String = "UPDATE tbl_transaksi_child SET Tgl_exp='" & TGL_EXP & "'," &
                " Modified_at = '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                " WHERE Id_trans='" & TXTID.Text & "'" &
                " AND Id = '" & CBKODE.SelectedValue & "'"
            Dim CMD As New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Expired barang " & CBKODE.Text & " berhasil diperbarui menjadi tanggal " & Format(Convert.ToDateTime(DTEXP.Value), "dd-MM-yyyy"))

        ElseIf CB_JENISTRANS.SelectedIndex = 2 Then
            Dim STR As String = "UPDATE tbl_transaksi_child SET Tgl_exp = NULL," &
                " Modified_at = '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                " WHERE Id_trans='" & TXTID.Text & "'" &
                " AND Id = '" & CBKODE.SelectedValue & "'"
            Dim CMD As New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            MsgBox("Expired barang " & CBKODE.Text & " berhasil dihapus.")
        End If
        TXTID.Clear()
        TXTQTY.Clear()
        TXTHARGA.Text = ""
        CB_JENISTRANS.Items.Clear()
        CB_JENISTRANS.Items.Add("Hapus Produk")
        TXTSTOK.Text = 0
        CBKODE.SelectedIndex = -1
        TAMPIL()
        TAMPIL_EXPIRED()
        TXTID.Select()
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            CB_JENISTRANS.Select()
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

            Dim ID_MASUK As String = "M" + Mid(IDTRANS, 2, 9)
            Dim STOK_AWAL As Double

            Dim str As String

            str = "SELECT Jumlah AS Jumlah" &
                " FROM tbl_transaksi_child" &
                " WHERE RTRIM(Id_trans) = '" & IDTRANS & "'"
            Dim CMD As New SqlCommand(str, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Read()
                TXTQTY.Text = RD.Item("Jumlah")
                RD.Close()
            Else
                RD.Close()
            End If
            RD.Close()

            CMD = New SqlCommand("UPDATE tbl_stok SET Stok+=" & TXTQTY.Text.Replace(",", ".") & ", " &
                                 " Modified_at = '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                                 " WHERE Kode='" & KODE_BARANG & "'", CONN)
            CMD.ExecuteNonQuery()

            str = "SELECT Stok AS Stok, " &
                " (SELECT Barang FROM tbl_barang WHERE RTRIM(tbl_barang.Kode) = RTRIM(tbl_transaksi_child.Kode)) AS Nama" &
                " FROM tbl_transaksi_child WHERE Id='" & ID_AWAL & "'"
            CMD = New SqlCommand(str, CONN)
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

            str = "UPDATE tbl_transaksi_child SET Stok=" & TXTSTOKAKHIR.Text.Replace(",", ".") & ", " &
                " Modified_at = '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                " WHERE Id='" & ID_AWAL & "'"
            CMD = New SqlCommand(str, CONN)
            CMD.ExecuteNonQuery()


            CMD = New SqlCommand("DELETE FROM tbl_transaksi_parent WHERE Id_trans='" & IDTRANS & "'", CONN)
            CMD.ExecuteNonQuery()

            CMD = New SqlCommand("DELETE FROM tbl_transaksi_child WHERE Id_trans='" & IDTRANS & "'", CONN)
            CMD.ExecuteNonQuery()

            TAMPIL()
            TAMPIL_EXPIRED()
            TXTQTY.Text = ""
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
                            & "Tgl_exp AS 'Tgl_exp'," _
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
            TXTSTOK.Text = Format(RD.Item("Stok"), "##0.##")
                TXTQTY.Text = TXTSTOK.Text
                If IsDBNull(RD.Item("Tgl_exp")) Then
                    CB_JENISTRANS.Items.Clear()
                    CB_JENISTRANS.Items.Add("Hapus Produk")

                Else
                    CB_JENISTRANS.Items.Clear()
                    CB_JENISTRANS.Items.Add("Hapus Produk")
                    CB_JENISTRANS.Items.Add("Perpanjang Expired")
                    CB_JENISTRANS.Items.Add("Hapus Expired")

                    DTEXP.Value = RD.Item("Tgl_exp")
                End If
                CB_JENISTRANS.SelectedIndex = 0
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

    Private Sub BTNLABELADMIN_Click(sender As Object, e As EventArgs) Handles BTNLABELADMIN.Click
        BUKA_FORM(FR_CETAK_LABEL)
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

    Private Sub BTNLAPORAN_Click(sender As Object, e As EventArgs) Handles BTNLAPORAN.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNHISTORYPENJUALAN_Click(sender As Object, e As EventArgs) Handles BTNHISTORYPENJUALAN.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNMEMBER_ADMIN_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_ADMIN.Click
        BUKA_FORM(FR_MEMBER)
    End Sub

    Private Sub BTNVOUCHER_ADMIN_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_ADMIN.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub BTNDASHBOARDOPS_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDOPS.Click
        BUKA_FORM(FR_OPS_DASHBOARD)
    End Sub

    Private Sub BTNBARANGOPS_Click(sender As Object, e As EventArgs) Handles BTNBARANGOPS.Click
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub BTNHISTORYOPS_Click(sender As Object, e As EventArgs) Handles BTNHISTORYOPS.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNKELUAROPS_Click(sender As Object, e As EventArgs) Handles BTNKELUAROPS.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNLABELOPS_Click(sender As Object, e As EventArgs) Handles BTNLABELOPS.Click
        BUKA_FORM(FR_CETAK_LABEL)
    End Sub

    Private Sub BTNLAPORANOPS_Click(sender As Object, e As EventArgs) Handles BTNLAPORANOPS.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNMASUKOPS_Click(sender As Object, e As EventArgs) Handles BTNMASUKOPS.Click
        BUKA_FORM(FR_MASUK)
    End Sub

    Private Sub BTNRETURNOPS_Click(sender As Object, e As EventArgs) Handles BTNRETURNOPS.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNMEMBER_OPS_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_OPS.Click
        BUKA_FORM(FR_MEMBER)
    End Sub

    Private Sub BTNTENTANGOPS_Click(sender As Object, e As EventArgs) Handles BTNTENTANGOPS.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNVOUCHER_OPS_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_OPS.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub DGEXPIRED_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGEXPIRED.CellClick
        On Error Resume Next

        If e.RowIndex >= 0 Then
            If DGEXPIRED.Columns(e.ColumnIndex).HeaderText = "Edit" Then
                TXTID.Text = DGEXPIRED.Item(1, e.RowIndex).Value

                DATA_TRANSAKSI()

                DGEXPIRED.Columns(0).Visible = True
                CBKODE.SelectedValue = DGEXPIRED.Item(0, e.RowIndex).Value
                DGEXPIRED.Columns(0).Visible = False
                CARI_HARGA()
                TXTQTY.Text = TXTSTOK.Text
            ElseIf DGEXPIRED.Columns(e.ColumnIndex).HeaderText = "History" Then
                With FR_MASUK_HISTORY
                    .Show()
                    .TXTCARI.Text = DGEXPIRED.Item(1, e.RowIndex).Value
                    .TAMPIL()
                End With
                Me.Enabled = False
            End If
        End If
    End Sub

    Private Sub CBKODE_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBKODE.SelectedValueChanged
        On Error Resume Next

        CARI_HARGA()
    End Sub

    Private Sub TXTCARI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTCARI_TRANS_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTID_Leave(sender As Object, e As EventArgs) Handles TXTID.Leave
        If TXTID.Text <> "" Then
            DATA_TRANSAKSI()
            CARI_HARGA()
        Else
            TXTID.Clear()
            CBKODE.DataSource = Nothing
            CBKODE.SelectedIndex = -1
            TXTHARGA.Text = ""
            TXTSTOK.Text = ""
            TXTQTY.Clear()
            CB_JENISTRANS.Items.Clear()
            CB_JENISTRANS.Items.Add("Hapus Produk")
            CB_JENISTRANS.SelectedIndex = -1
        End If
    End Sub

    Private Sub CB_JENISTRANS_TextChanged(sender As Object, e As EventArgs) Handles CB_JENISTRANS.TextChanged
        On Error Resume Next

        If CB_JENISTRANS.SelectedIndex = 1 Then
            Label13.Visible = True
            DTEXP.Visible = True
        Else
            Label13.Visible = False
            DTEXP.Visible = False
        End If
    End Sub

    Private Sub CB_JENISTRANS_SelectedValueChanged(sender As Object, e As EventArgs) Handles CB_JENISTRANS.SelectedValueChanged
        On Error Resume Next

        If CB_JENISTRANS.SelectedIndex = 0 Then
            Label13.Visible = False
            DTEXP.Visible = False
            TXTQTY.Enabled = True
        ElseIf CB_JENISTRANS.SelectedIndex = 1 Then
            Label13.Visible = True
            DTEXP.Visible = True
            TXTQTY.Enabled = False
        ElseIf CB_JENISTRANS.SelectedIndex = 2 Then
            Label13.Visible = False
            DTEXP.Visible = False
            TXTQTY.Enabled = False
        End If
    End Sub

    Private Sub DTEXP_Leave(sender As Object, e As EventArgs) Handles DTEXP.Leave
        If DTEXP.Value <= Date.Now Then
            MsgBox("Barang masuk tidak boleh expired")
            DTEXP.Select()
        End If
    End Sub

    Private Sub CB_JENISTRANS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CB_JENISTRANS.KeyPress
        If e.KeyChar = Chr(13) Then
            If CB_JENISTRANS.SelectedIndex = 1 Then
                DTEXP.Select()
            Else
                BTNSIMPAN.Select()
            End If
        End If
    End Sub

    Private Sub DTEXP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTEXP.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If
    End Sub

    Private Sub DGTAMPIL_SelectionChanged(sender As Object, e As EventArgs) Handles DGTAMPIL.SelectionChanged
        DGTAMPIL.ClearSelection()
    End Sub

    Private Sub DGTAMPIL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellClick
        On Error Resume Next

        If e.RowIndex >= 0 Then
            If DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Delete" Then
                If MsgBox("Apakah anda yakin akan menghapus data transaksi?", vbYesNo) = vbYes Then

                    DGTAMPIL.Columns(0).Visible = True
                    DGTAMPIL.Columns(2).Visible = True
                    Dim IDTRANS As String = DGTAMPIL.Item(1, DGTAMPIL.CurrentRow.Index).Value
                    Dim KODE_BARANG As String = DGTAMPIL.Item(2, DGTAMPIL.CurrentRow.Index).Value.ToString.Trim
                    Dim NAMA_BARANG As String = DGTAMPIL.Item(3, DGTAMPIL.CurrentRow.Index).Value.ToString.Trim
                    Dim ID_AWAL As Integer = DGTAMPIL.Item(0, DGTAMPIL.CurrentRow.Index).Value
                    DGTAMPIL.Columns(0).Visible = False
                    DGTAMPIL.Columns(2).Visible = False

                    Dim ID_MASUK As String = "M" + Mid(IDTRANS, 2, 9)
                    Dim STOK_AWAL As Double

                    Dim str As String

                    str = "SELECT Jumlah AS Jumlah" &
                " FROM tbl_transaksi_child" &
                " WHERE RTRIM(Id_trans) = '" & IDTRANS & "'"
                    Dim CMD As New SqlCommand(str, CONN)
                    Dim RD As SqlDataReader
                    RD = CMD.ExecuteReader
                    If RD.HasRows Then
                        RD.Read()
                        TXTQTY.Text = RD.Item("Jumlah")
                        RD.Close()
                    Else
                        RD.Close()
                    End If
                    RD.Close()

                    str = "UPDATE tbl_stok SET Stok+=" & TXTQTY.Text.Replace(",", ".") & ", " &
                                 " Modified_at = '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                                 " WHERE Kode='" & KODE_BARANG & "'"
                    CMD = New SqlCommand(str, CONN)
                    CMD.ExecuteNonQuery()

                    str = "SELECT Stok AS Stok, " &
                            " (SELECT Barang FROM tbl_barang WHERE RTRIM(tbl_barang.Kode) = RTRIM(tbl_transaksi_child.Kode)) AS Nama" &
                            " FROM tbl_transaksi_child WHERE Id='" & ID_AWAL & "'"
                    CMD = New SqlCommand(str, CONN)
                    RD = CMD.ExecuteReader
                    If RD.HasRows Then
                        RD.Read()
                        STOK_AWAL = RD.Item("Stok")
                        NAMA_BARANG = RTrim(RD.Item("Nama"))
                        RD.Close()
                    Else
                        RD.Close()
                        STOK_AWAL = 0
                    End If
                    RD.Close()

                    TXTSTOKAKHIR.Text = STOK_AWAL + DGTAMPIL.Item(8, DGTAMPIL.CurrentRow.Index).Value

                    str = "UPDATE tbl_transaksi_child SET Stok=" & TXTSTOKAKHIR.Text.Replace(",", ".") & ", " &
                            " Modified_at = '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                            " WHERE Id='" & ID_AWAL & "'"
                    CMD = New SqlCommand(str, CONN)
                    CMD.ExecuteNonQuery()


                    CMD = New SqlCommand("DELETE FROM tbl_transaksi_parent WHERE Id_trans='" & IDTRANS & "'", CONN)
                    CMD.ExecuteNonQuery()

                    CMD = New SqlCommand("DELETE FROM tbl_transaksi_child WHERE Id_trans='" & IDTRANS & "'", CONN)
                    CMD.ExecuteNonQuery()

                    TAMPIL()
                    TAMPIL_EXPIRED()
                    TXTQTY.Text = ""
                    MsgBox("Data barang rusak berhasil dihapus, dan stok barang " & NAMA_BARANG & " ditambah.")
                End If
            End If
        End If
    End Sub

    Private Sub DGEXPIRED_SelectionChanged(sender As Object, e As EventArgs) Handles DGEXPIRED.SelectionChanged
        DGEXPIRED.ClearSelection()
    End Sub
End Class