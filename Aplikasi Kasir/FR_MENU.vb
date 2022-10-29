Imports System.Data.SqlClient

Public Class FR_MENU
    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 15

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

    Sub TAMPIL()
        Dim STR As String = "SELECT RTRIM(Kode) AS Kode," &
            " RTRIM(Barang) As 'Nama Barang'," &
            " (SELECT Stok FROM tbl_stok WHERE tbl_stok.Kode = tbl_barang.Kode) AS Stok," &
            " RTRIM(tbl_barang.Satuan) AS 'Satuan'" &
            " FROM tbl_barang WHERE Barang Like '%" & TXTCARISTOK.Text & "%'" &
            " OR Kode = '" & TXTCARISTOK.Text & "'" &
            " AND (SELECT Stok FROM tbl_stok WHERE tbl_stok.Kode = tbl_barang.Kode) != 0" &
            " ORDER BY 'Nama Barang' ASC" &
            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"

        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
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

        Dim TOTAL_RECORD As Integer = 0
        Dim TBL_DATA As New DataTable
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL_DATA)

        STR = "SELECT COUNT(Kode) FROM tbl_barang WHERE Barang Like '%" & TXTCARISTOK.Text & "%'" &
            " OR Kode = '" & TXTCARISTOK.Text & "'" &
            " AND (SELECT Stok FROM tbl_stok WHERE tbl_stok.Kode = tbl_barang.Kode) != 0"
        Dim CMD As New SqlCommand(STR, CONN)

        TOTAL_RECORD = Convert.ToUInt64(CMD.ExecuteScalar())

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
        Dim STR As String = "SELECT * FROM tbl_transaksi_child WHERE LEFT(Id_trans, 1) = 'M'" &
            " AND Tgl_exp <= DATEADD(day,+14, GETDATE())" &
            " AND Stok != 0"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Close()
            CEK_EXPIRED = True
        Else
            RD.Close()
            CEK_EXPIRED = False
        End If
        RD.Close()
    End Function

    Private Sub FR_MENU_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        TAMPIL()
        TAMPIL_DATA()
    End Sub

    Sub TAMPIL_DATA()
        Dim TGLAWAL = Format(Date.Now, "yyyy-MM-dd")
        TGLAWAL = TGLAWAL & " 00:00:00"
        Dim TGLAKHIR = Format(Date.Now, "yyyy-MM-dd")
        TGLAKHIR = TGLAKHIR & " 23:59:59"

        Dim STR As String
        Dim CMD As SqlCommand
        STR = "SELECT COUNT(*) FROM tbl_karyawan"
        CMD = New SqlCommand(STR, CONN)
        LBKASIR.Text = Convert.ToUInt64(CMD.ExecuteScalar())

        STR = "SELECT COUNT(*) FROM tbl_barang"
        CMD = New SqlCommand(STR, CONN)
        LBBARANG.Text = Convert.ToUInt64(CMD.ExecuteScalar())

        STR = "SELECT COUNT(*) FROM tbl_transaksi_parent WHERE Jenis='M'"
        CMD = New SqlCommand(STR, CONN)
        LBMASUK.Text = Convert.ToUInt64(CMD.ExecuteScalar())

        STR = "SELECT COUNT(*) FROM tbl_transaksi_parent WHERE Jenis='K'"
        CMD = New SqlCommand(STR, CONN)
        LBKELUAR.Text = Convert.ToUInt64(CMD.ExecuteScalar())

        STR = "SELECT COUNT(*) as Count FROM tbl_transaksi_parent WHERE Jenis='K' AND (Tgl >= '" & TGLAWAL & "' AND Tgl <= '" & TGLAKHIR & "')"
        CMD = New SqlCommand(STR, CONN)
        LBKELUARHARI.Text = Convert.ToUInt64(CMD.ExecuteScalar())
        'CMD = New SqlCommand(STR, CONN)

        'Dim RD As SqlDataReader
        'RD = CMD.ExecuteReader
        'RD.Read()
        'If RD.HasRows Then
        '    LBKELUARHARI.Text = RD.Item("Counting")
        '    RD.Close()
        'Else
        '    RD.Close()
        'End If
        'RD.Close()


        ''Dim DA As SqlDataAdapter
        ''Dim TBL As New DataTable
        ''DA = New SqlDataAdapter(STR, CONN)
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
End Class
