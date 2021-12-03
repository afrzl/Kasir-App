Imports System.Data.SqlClient

Public Class FR_KELUAR
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        Dim FR As New FR_MENU
        FR.Show()
        Me.Close()
    End Sub

    Private Sub BTNMIN_Click(sender As Object, e As EventArgs) Handles BTNMIN.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TXTKODE_TextChanged(sender As Object, e As EventArgs) Handles TXTKODE.TextChanged
        Dim STR As String = "SELECT Kode, Barang, Satuan, Harga_jual FROM tbl_barang WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTBARANG.Text = RD.Item("Barang").ToString.Trim
            TXTSATUAN.Text = RD.Item("Satuan").ToString.Trim
            TXTHARGA.Text = CInt(RD.Item("Harga_jual"))
            RD.Close()
            If CARI_STOK(TXTKODE.Text) <= 0 Then
                MsgBox("Stok barang tidak mencukupi!")
                TXTKODE.Clear()
                Exit Sub
            End If
            MASUK_DATA()
            TXTKODE.Clear()
            TXTKODE.Select()
        Else
            RD.Close()
        End If
    End Sub

    Sub MASUK_DATA()
        Dim QTY As Integer = 0
        Dim ADA_DATA As Boolean = False
        Dim BARIS_DATA As Integer = 0

        For N = 0 To DGTAMPIL.Rows.Count - 1
            Dim Kode As String = DGTAMPIL.Item("Kode", N).Value
            If Kode = TXTKODE.Text Then
                ADA_DATA = True
                BARIS_DATA = N
                Exit For
            End If
        Next

        If ADA_DATA = True Then
            DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value = DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value + 1
            DGTAMPIL.Rows(BARIS_DATA).Cells("Total").Value = DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value * DGTAMPIL.Rows(BARIS_DATA).Cells("Harga").Value
        Else
            DGTAMPIL.Rows.Add()
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Kode").Value = TXTKODE.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Barang").Value = TXTBARANG.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Satuan").Value = TXTSATUAN.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Harga").Value = TXTHARGA.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Qty").Value = "1"
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Total").Value = TXTHARGA.Text
        End If

        TOTAL_HARGA()
    End Sub

    Private Sub DGTAMPIL_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellEndEdit
        If e.ColumnIndex = 4 Then
            Dim QTY As String = ""
            QTY = DGTAMPIL.Item("Qty", e.RowIndex).Value
            Dim KODEBR As String = DGTAMPIL.Item("Kode", e.RowIndex).Value
            If IsNumeric(QTY) Then
                If CARI_STOK(KODEBR) < 0 Then
                    MsgBox("Stok barang tidak mencukupi!")
                    DGTAMPIL.Item("Qty", e.RowIndex).Value = QTY_AWAL
                Else
                    DGTAMPIL.Item("Total", e.RowIndex).Value = QTY * DGTAMPIL.Item("Harga", e.RowIndex).Value
                    TOTAL_HARGA()
                End If
            Else
                MsgBox("QTY tidak valid!")
                DGTAMPIL.Item("Qty", e.RowIndex).Value = QTY_AWAL
            End If
        End If
    End Sub

    Dim QTY_AWAL As Integer = 0
    Private Sub DGTAMPIL_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DGTAMPIL.CellBeginEdit
        If e.ColumnIndex = 4 Then
            QTY_AWAL = DGTAMPIL.Item("Qty", e.RowIndex).Value
        End If
    End Sub

    Private Function CARI_STOK(ByVal Kode As String) As Integer
        CARI_STOK = 0
        Dim STR As String
        STR = "SELECT Kode, RTRIM(Barang) as Barang, RTRIM(Satuan) as Satuan, Harga_jual," &
            " ((SELECT COALESCE(SUM(jumlah),0) FROM tbl_transaksi_child WHERE Kode=tbl_barang.Kode And LEFT(Id_trans,1)='M')-(SELECT COALESCE(SUM(jumlah),0)" &
            " FROM tbl_transaksi_child WHERE Kode=tbl_barang.Kode And LEFT(Id_trans,1)='K')) as Stok FROM tbl_barang WHERE kode='" & Kode & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader

        Dim STOK_DATA As Integer = 0
        If RD.HasRows Then
            RD.Read()
            STOK_DATA = RD.Item("Stok")
            RD.Close()
        Else
            RD.Close()
            STOK_DATA = 0
        End If

        Dim STOK_ORDER As Integer = 0
        For N = 0 To DGTAMPIL.RowCount - 1
            If DGTAMPIL.Item("Kode", N).Value = Kode Then
                STOK_ORDER = STOK_ORDER + DGTAMPIL.Item("QTY", N).Value
                Exit For
            End If
        Next

        CARI_STOK = STOK_DATA - STOK_ORDER
    End Function

    Sub TOTAL_HARGA()
        Dim TOT_HARGA As Integer = 0
        For N = 0 To DGTAMPIL.Rows.Count - 1
            TOT_HARGA = TOT_HARGA + DGTAMPIL.Item("Total", N).Value
        Next

        LBTOTAL.Text = FormatCurrency(TOT_HARGA, 0)
    End Sub

    Private Sub BTNCARI_Click(sender As Object, e As EventArgs) Handles BTNCARI.Click
        BUKA_FORM_CARI()
    End Sub

    Private Sub TXTCARI_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI.TextChanged
        Dim STR As String = "SELECT TOP 10 RTRIM(Kode) as Kode, RTRIM(Barang) AS Barang, RTRIM(Satuan) AS Satuan, Harga_jual" &
            " From tbl_barang Where BARANG Like '%" & TXTCARI.Text & "%'"
        Dim DA As New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGCARI.DataSource = TBL
    End Sub

    Private Sub DGCARI_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCARI.CellDoubleClick
        TXTKODE.Text = DGCARI.Item("Kode", e.RowIndex).Value
        PNCARI.Visible = False
    End Sub

    Private Sub FR_KELUAR_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                If PNCARI.Visible = False Then
                    BUKA_FORM_CARI()
                Else
                    TUTUP_FORM_CARI()
                End If
            Case Keys.F2
                If PNBAYAR.Visible = False Then
                    BUKA_FORM_BAYAR()
                Else
                    TUTUP_FORM_BAYAR()
                End If
        End Select
    End Sub

    Sub BUKA_FORM_CARI()
        PNBAYAR.Visible = False
        PNCARI.Visible = True
        TXTCARI.Clear()
        TXTCARI.Select()
    End Sub
    Sub BUKA_FORM_BAYAR()
        TXTBAYAR.Text = CInt(LBTOTAL.Text)
        If TXTBAYAR.Text <= 0 Then Exit Sub

        DGTAMPIL.Enabled = False
        PNCARI.Visible = False
        PNBAYAR.Visible = True
        TXTTUNAI.Clear()
        TXTTUNAI.Select()
    End Sub

    Sub TUTUP_FORM_CARI()
        PNCARI.Visible = False
        TXTKODE.Select()
    End Sub

    Sub TUTUP_FORM_BAYAR()
        DGTAMPIL.Enabled = True
        PNBAYAR.Visible = False
        TXTKODE.Select()
    End Sub

    Private Sub BTNBAYAR_Click(sender As Object, e As EventArgs) Handles BTNBAYAR.Click
        BUKA_FORM_BAYAR()
    End Sub

    Private Sub BTNBAYAR_CLOSE_Click(sender As Object, e As EventArgs) Handles BTNBAYAR_CLOSE.Click
        TUTUP_FORM_BAYAR()
    End Sub

    Private Sub BTNCARI_CLOSE_Click(sender As Object, e As EventArgs) Handles BTNCARI_CLOSE.Click
        TUTUP_FORM_CARI()
    End Sub

    Private Sub TXTTUNAI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTUNAI.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            If CInt(TXTKEMBALIAN.Text) >= 0 Then
                INPUT_DB()
            Else
                MsgBox("Pembayaran Kurang!")
            End If
        End If
    End Sub

    Private Sub TXTTUNAI_TextChanged(sender As Object, e As EventArgs) Handles TXTTUNAI.TextChanged
        If TXTTUNAI.Text = "" Then Exit Sub
        TXTKEMBALIAN.Text = TXTTUNAI.Text - TXTBAYAR.Text
        If TXTKEMBALIAN.Text < 0 Then
            TXTKEMBALIAN.Text = ""
        End If
    End Sub

    Private Sub DGTAMPIL_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGTAMPIL.CellMouseClick
        If DGTAMPIL.Rows.Count > 0 AndAlso e.RowIndex >= 0 Then
            CLICK_KANAN.Show(Cursor.Position.X, Cursor.Position.Y)
        End If
    End Sub

    Private Sub HapusBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusBarangToolStripMenuItem.Click
        For Each ECELL As DataGridViewCell In DGTAMPIL.SelectedCells
            DGTAMPIL.Rows.RemoveAt(ECELL.RowIndex)
        Next
        TOTAL_HARGA()
    End Sub

    Private Sub FR_KELUAR_Load(sender As Object, e As EventArgs) Handles Me.Load
        TXTKODE.Select()
        TXTKASIR.Text = NAMA_LOGIN
        TXTPEMBELI.Text = "USER"

        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy H:m:s")
        Timer1.Enabled = True
    End Sub

    Sub INPUT_DB()
        If DGTAMPIL.Rows.Count <= 0 Then Exit Sub
        Dim HARGA_TOTAL As Integer = TXTBAYAR.Text
        Dim HARGA_TUNAI As Integer = TXTTUNAI.Text
        Dim HARGA_KEMBALI As Integer = TXTKEMBALIAN.Text
        Dim ID_TRANS As String = AUTOID()
        Dim STR As String = "INSERT INTO tbl_transaksi_parent (Id_trans,Id_kasir,Tgl,Jenis,Person,Harga_total,Harga_tunai,Harga_kembali)" &
                " VALUES('" & ID_TRANS & "','" & My.Settings.ID_ACCOUNT & "','" & Format(Date.Now, "MM/dd/yyyy h:m:s") & "','K','" & TXTPEMBELI.Text &
                "','" & HARGA_TOTAL & "','" & HARGA_TUNAI & "','" & HARGA_KEMBALI & "')"
        Dim CMD As New SqlCommand(STR, CONN)
        CMD.ExecuteNonQuery()

        For Each EROW As DataGridViewRow In DGTAMPIL.Rows
            Dim KODE As String = EROW.Cells("Kode").Value
            Dim JUMLAH As Integer = EROW.Cells("QTY").Value
            Dim HARGA As Integer = EROW.Cells("Total").Value

            STR = "INSERT INTO tbl_transaksi_child (Id_trans,Kode,Jumlah,Harga) VALUES" &
            " ('" & ID_TRANS & "','" & KODE & "','" & JUMLAH & "','" & HARGA & "')"

            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
        Next


        MsgBox("Transaksi Berhasil Dilakukan")
        TUTUP_FORM_BAYAR()
        DGTAMPIL.Rows.Clear()
        TOTAL_HARGA()
        TXTKODE.Select()
    End Sub

    Private Function AUTOID() As String
        Dim ID_AWAL As String = Format(Date.Now, "yyMMdd")
        Dim STR As String = "SELECT TOP 1 (Id_trans) AS Id_trans FROM tbl_transaksi_parent WHERE LEFT(Id_trans,1)='K' ORDER BY Id DESC"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            If Mid(RD.Item("Id_trans"), 2, 6) = ID_AWAL Then
                Dim ID As Integer = Mid(RD.Item("Id_trans"), 8, 3) + 1
                RD.Close()
                AUTOID = "K" + ID_AWAL + Format(ID, "000")
            Else
                RD.Close()
                AUTOID = "K" + ID_AWAL + Format(1, "000")
            End If
        Else
            RD.Close()
            AUTOID = "K" + ID_AWAL + Format(1, "000")
        End If
        RD.Close()
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy H:m:s")
    End Sub

End Class