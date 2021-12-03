Imports System.Data.SqlClient
Public Class FR_PRODUK
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

    Private Sub FR_PRODUK_Load(sender As Object, e As EventArgs) Handles Me.Load
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:MM:SS")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN

        TAMPIL()
        TXTKODE.Select()
    End Sub

    Sub TAMPIL()
        Dim STR As String = "SELECT RTRIM(Kode) AS 'Kode Barang',RTRIM(Barang) AS 'Nama Barang'," &
            "Satuan,Harga AS 'Harga <= 5 item',Harga_set_lusin AS 'Harga 6-11 item',Harga_lusin AS 'Harga >= 12 item' FROM tbl_barang" &
            " WHERE Barang LIKE '%" & TXTCARI.Text & "%'"
        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGTAMPIL.DataSource = TBL

        DGTAMPIL.Columns(3).DefaultCellStyle.Format = "Rp ###,##"
        DGTAMPIL.Columns(4).DefaultCellStyle.Format = "Rp ###,##"
        DGTAMPIL.Columns(5).DefaultCellStyle.Format = "Rp ###,##"

        DGTAMPIL.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub

    Private Sub TXTKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTNAMA.Select()
        End If
    End Sub

    Private Sub TXTNAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNAMA.KeyPress
        If e.KeyChar = Chr(13) Then
            CBSATUAN.Select()
        End If
    End Sub

    Private Sub CBSATUAN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBSATUAN.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTSATUAN.Select()
        End If
    End Sub

    Private Sub TXTSATUAN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSATUAN.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTSETLUSIN.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTSETLUSIN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSETLUSIN.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTLUSIN.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTLUSIN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTLUSIN.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
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
            TXTNAMA.Text = RD.Item("Barang").ToString.Trim
            CBSATUAN.Text = RD.Item("Satuan").ToString.Trim
            TXTSATUAN.Text = CInt(RD.Item("Harga"))
            TXTSETLUSIN.Text = CInt(RD.Item("Harga_set_lusin"))
            TXTLUSIN.Text = CInt(RD.Item("Harga_lusin"))
            RD.Close()
        Else
            RD.Close()
            TXTNAMA.Clear()
            TXTSATUAN.Clear()
            TXTSETLUSIN.Clear()
            TXTLUSIN.Clear()
        End If
        RD.Close()
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If TXTKODE.Text = "" Or TXTNAMA.Text = "" Or TXTSATUAN.Text = "" Or TXTSETLUSIN.Text = "" Or TXTLUSIN.Text = "" Then
            MsgBox("Isikan data secara lengkap!")
        Else
            Dim STR As String = "SELECT * FROM tbl_barang WHERE Kode='" & TXTKODE.Text & "'"
            Dim CMD As SqlCommand
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Close()
                STR = "UPDATE tbl_barang SET Barang='" & TXTNAMA.Text &
                    "',Satuan='" & CBSATUAN.Text &
                    "',Harga='" & TXTSATUAN.Text &
                    "',Harga_set_lusin='" & TXTSETLUSIN.Text &
                    "',Harga_lusin='" & TXTLUSIN.Text &
                    "' WHERE Kode='" & TXTKODE.Text & "'"
            Else
                RD.Close()
                STR = "INSERT INTO tbl_barang VALUES ('" & TXTKODE.Text & "','" &
                    TXTNAMA.Text & "', '" & CBSATUAN.Text & "', '" &
                    TXTSATUAN.Text & "', '" & TXTSETLUSIN.Text & "', '" & TXTLUSIN.Text & "')"
            End If
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data produk berhasil disimpan.")
            TXTKODE.Clear()
            TXTKODE.Select()
            TAMPIL()
        End If
    End Sub

    Private Sub TXTCARI_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI.TextChanged
        TAMPIL()
    End Sub

    Private Sub HapusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusToolStripMenuItem.Click
        Dim STR As String = "DELETE FROM tbl_barang WHERE RTRIM(Kode)='" &
            DGTAMPIL.Item(0, DGTAMPIL.CurrentRow.Index).Value & "'"
        If MsgBox("Apakah anda yakin akan menghapus produk ini?", vbYesNo) = vbYes Then
            Dim CMD As New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
            TAMPIL()
        End If
    End Sub

    Private Sub DGTAMPIL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellClick
        On Error Resume Next
        TXTKODE.Text = DGTAMPIL.Item(0, e.RowIndex).Value
    End Sub
End Class