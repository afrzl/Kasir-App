Imports System.Data.SqlClient

Public Class FR_KELUAR_TAMPIL
    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        FR_KELUAR.Enabled = True
        Me.Close()
    End Sub

    Sub TAMPIL()
        Dim STR As String = "SELECT RTRIM(Kode) AS Kode," &
            " RTRIM(Barang) As 'Nama Barang'," &
            " (SELECT COALESCE(SUM(Stok),0) FROM tbl_transaksi_child WHERE RTRIM(tbl_transaksi_child.Kode) = RTRIM(tbl_barang.Kode) AND LEFT(tbl_transaksi_child.Id_trans,1) = 'M') AS Stok" &
            " FROM tbl_barang WHERE Barang Like '%" & TXTCARI.Text & "%'"
        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGCARI.DataSource = TBL
        DGCARI.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGCARI.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub

    Private Sub FR_KELUAR_TAMPIL_Load(sender As Object, e As EventArgs) Handles Me.Load
        TAMPIL()
        TXTCARI.Select()
    End Sub

    Private Sub DGCARI_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCARI.CellDoubleClick
        On Error Resume Next
        FR_KELUAR.TXTKODE.Text = DGCARI.Item(0, e.RowIndex).Value
        FR_KELUAR.TXTKODE.Select()
        FR_KELUAR.Enabled = True
        Me.Close()
    End Sub

    Private Sub TXTCARI_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI.TextChanged
        TAMPIL()
    End Sub
End Class