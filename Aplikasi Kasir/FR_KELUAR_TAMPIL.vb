Imports System.Data.SqlClient

Public Class FR_KELUAR_TAMPIL
    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        FR_KELUAR.Enabled = True
        Me.Close()
    End Sub

    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 10

    Sub TAMPIL()
        Dim STR As String = "SELECT RTRIM(Kode) AS Kode," &
            " RTRIM(Barang) As 'Nama Barang'," &
            " (SELECT COALESCE(SUM(Stok),0) FROM tbl_transaksi_child WHERE RTRIM(tbl_transaksi_child.Kode) = RTRIM(tbl_barang.Kode) AND (LEFT(Id_trans,1)='M' or LEFT(Id_trans,1)='R')) AS Stok," &
            " RTRIM(Satuan) As 'Satuan'" &
            " FROM tbl_barang WHERE Barang Like '%" & TXTCARI.Text & "%'" &
            " ORDER BY 'Nama Barang' ASC"
        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL, START_RECORD, TAMPIL_RECORD, 0)
        DGCARI.DataSource = TBL.Tables(0)

        DGCARI.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGCARI.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGCARI.Columns(2).DefaultCellStyle.Format = "##0.##"

        For Each EROW As DataGridViewRow In DGCARI.Rows
            Dim KODE_PRODUK As String = EROW.Cells("Kode").Value
            For Each N As DataGridViewRow In FR_KELUAR.DGTAMPIL.Rows
                If N.Cells("Kode").Value = KODE_PRODUK Then
                    EROW.Cells("Stok").Value -= N.Cells("QTY").Value
                    Exit For
                End If
            Next
        Next

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

    Private Sub DGCARI_KeyDown(sender As Object, e As KeyEventArgs) Handles DGCARI.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            e.Handled = True
            DGCARI.CurrentCell = DGCARI.Rows(DGCARI.CurrentRow.Index).Cells(0)
            FR_KELUAR.TXTKODE.Text = DGCARI.SelectedCells(0).Value
            FR_KELUAR.TXTKODE.Select()
            FR_KELUAR.Enabled = True
            Me.Close()
        End If
    End Sub

    Private Sub TXTCARI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI.KeyPress
        If e.KeyChar = Chr(13) Then
            DGCARI.Select()
        End If

        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub FR_KELUAR_TAMPIL_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                FR_KELUAR.Enabled = True
                Me.Close()
        End Select
    End Sub

    Private Sub TXTCARI_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCARI.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                FR_KELUAR.Enabled = True
                Me.Close()
        End Select
    End Sub
End Class