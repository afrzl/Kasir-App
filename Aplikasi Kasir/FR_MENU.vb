Imports System.Diagnostics.Eventing
Imports MySql.Data.MySqlClient


Public Class FR_MENU
    Dim CMD As MySqlCommand
    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 10

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub FR_MENU_Load(sender As Object, e As EventArgs) Handles Me.Load
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True

        LBLUSER.Text = NAMA_LOGIN
        If CEK_EXPIRED() = True Then
            MsgBox("Terdapat barang yang akan expired. Silahkan cek di menu barang rusak!")
        End If
        TAMPIL()
    End Sub

    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        If MsgBox("Apakah anda yakin akan keluar dari aplikasi?", vbYesNo) = vbYes Then
            Me.Close()
            End
        End If
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        If MsgBox("Apakah anda yakin akan logout?", vbYesNo) = vbYes Then
            Dim FR As New FR_LOGIN
            My.Settings.ID_ACCOUNT = 0
            FR.Show()
            Me.Close()
        End If
    End Sub

    Dim TOTAL_RECORD As Integer = 0

    Sub TAMPIL()
        Dim STR As String = "SELECT RTRIM(tbl_barang.Kode) AS Kode," &
            " RTRIM(Barang) As 'Nama Barang'," &
            " (tbl_stok.Stok) AS Stok," &
            " RTRIM(tbl_barang.Satuan) AS 'Satuan'" &
            " FROM tbl_barang INNER JOIN tbl_stok ON tbl_barang.Kode = tbl_stok.Kode WHERE Barang Like '%" & TXTCARISTOK.Text & "%'" &
            " OR tbl_barang.Kode = '" & TXTCARISTOK.Text & "'" &
            " AND (tbl_stok.Stok) != 0" &
            " ORDER BY 'Nama Barang' ASC" &
            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD

        Dim DA As MySqlDataAdapter
        Dim TBL As New DataSet
        DA = New MySqlDataAdapter(STR, CONN)
        DA.Fill(TBL)
        DGSTOK.DataSource = TBL.Tables(0)

        DGSTOK.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGSTOK.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGSTOK.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGSTOK.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGSTOK.Columns(2).DefaultCellStyle.Format = "##0.##"
        DGSTOK.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGSTOK.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        BTNPREV.Enabled = True
        BTNNEXT.Enabled = True

        Dim TBL_DATA As New DataTable
        DA = New MySqlDataAdapter(STR, CONN)
        DA.Fill(TBL_DATA)

        If TOTAL_RECORD = 0 Then
            BTNPREV.Enabled = False
            BTNNEXT.Enabled = False
        ElseIf START_RECORD = 0 Then
            BTNPREV.Enabled = False
        ElseIf TOTAL_RECORD <= START_RECORD Then
            BTNNEXT.Enabled = False
        ElseIf TOTAL_RECORD - START_RECORD <= TAMPIL_RECORD Then
            BTNNEXT.Enabled = False
        Else
            BTNPREV.Enabled = True
            BTNNEXT.Enabled = True
        End If

        DGSTOK.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub BTNNEXT_Click(sender As Object, e As EventArgs) Handles BTNNEXT.Click
        START_RECORD = START_RECORD + TAMPIL_RECORD
        TAMPIL()
    End Sub

    Private Sub BTNPREV_Click(sender As Object, e As EventArgs) Handles BTNPREV.Click
        START_RECORD = START_RECORD - TAMPIL_RECORD
        TAMPIL()
    End Sub

    Private Sub TXTCARISTOK_TextChanged(sender As Object, e As EventArgs) Handles TXTCARISTOK.TextChanged
        START_RECORD = 0
        TAMPIL()
    End Sub

    Private Function CEK_EXPIRED() As Boolean
        Try
            Dim STR As String = "SELECT * FROM tbl_transaksi_child WHERE LEFT(Id_trans, 1) = 'M'" &
                " AND Tgl_exp <= DATE_ADD(CURRENT_DATE, INTERVAL 14 DAY)" &
                " AND Stok != 0"
            Dim RD As MySqlDataReader
            RD = EXECUTE_READER(STR)
            While RD.Read()
                If RD.HasRows Then
                    CEK_EXPIRED = True
                Else
                    CEK_EXPIRED = False
                End If
            End While
            RD.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            TUTUP_KONEKSI()
        End Try

    End Function

    Private Sub FR_MENU_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        TAMPIL()
        TAMPIL_DATA()

        Dim Str As String

        Try
            Str = "SELECT COUNT(Kode) FROM tbl_barang WHERE Barang Like '%" & TXTCARISTOK.Text & "%'" &
            " OR Kode = '" & TXTCARISTOK.Text & "'" &
            " AND (SELECT Stok FROM tbl_stok WHERE tbl_stok.Kode = tbl_barang.Kode) != 0"

            TOTAL_RECORD = Convert.ToUInt64(EXECUTE_SCALAR(Str))
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub TAMPIL_DATA()
        Dim TGLAWAL = Format(Date.Now, "yyyy-MM-dd")
        TGLAWAL = TGLAWAL & " 00:00:00"
        Dim TGLAKHIR = Format(Date.Now, "yyyy-MM-dd")
        TGLAKHIR = TGLAKHIR & " 23:59:59"

        Dim STR As String

        Try
            STR = "SELECT COUNT(*) FROM tbl_karyawan"
            LBKASIR.Text = Convert.ToUInt64(EXECUTE_SCALAR(STR))

            STR = "SELECT COUNT(*) FROM tbl_barang"
            LBBARANG.Text = Convert.ToUInt64(EXECUTE_SCALAR(STR))

            STR = "SELECT COUNT(*) FROM tbl_transaksi_parent WHERE Jenis='M'"
            LBMASUK.Text = Convert.ToUInt64(EXECUTE_SCALAR(STR))

            STR = "SELECT COUNT(*) FROM tbl_transaksi_parent WHERE Jenis='K'"
            LBKELUAR.Text = Convert.ToUInt64(EXECUTE_SCALAR(STR))

            STR = "SELECT COUNT(*) as Count FROM tbl_transaksi_parent WHERE Jenis='K' AND (Tgl >= '" & TGLAWAL & "' AND Tgl <= '" & TGLAKHIR & "')"
            LBKELUARHARI.Text = Convert.ToUInt64(EXECUTE_SCALAR(STR))
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try

        'CMD = New MySqlCommand(STR, CONN)

        'Dim RD As MySqlDataReader
        'RD = CMD.ExecuteReader
        'RD.Read()
        'If RD.HasRows Then
        '    LBKELUARHARI.Text = RD.Item("Counting")
        '    RD.Close()
        'Else
        '    RD.Close()
        'End If
        'RD.Close()


        ''Dim DA As MySqlDataAdapter
        ''Dim TBL As New DataTable
        ''DA = New MySqlDataAdapter(STR, CONN)
        ''DA.Fill(TBL)

        ''LBKELUARHARI.Text = TBL.Rows.Count()
    End Sub

    Private Sub TXTCARISTOK_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARISTOK.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
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

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
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

    Private Sub DGSTOK_SelectionChanged(sender As Object, e As EventArgs) Handles DGSTOK.SelectionChanged
        DGSTOK.ClearSelection()
    End Sub
End Class
