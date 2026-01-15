Imports MySql.Data.MySqlClient

Public Class FR_RETURN_LIST

    Dim STR As String
    Dim DA As MySqlDataAdapter
    Dim TBL As DataTable

    Sub TUTUP_FORM()
        If LB_TITLE.Text = "FR_RETURN" Then
            With FR_RETURN
                .Enabled = True
                .TAMPIL()
            End With
        ElseIf LB_TITLE.Text = "FR_RUSAK" Then
            With FR_RUSAK
                .Enabled = True
                .TAMPIL()
            End With
        End If
        Me.Close()
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        TUTUP_FORM()
    End Sub

    Sub TAMPIL()
        If LB_TITLE.Text = "FR_RETURN" Then
            STR = "SELECT RTRIM(Id_trans) AS 'ID Transaksi'," &
                      " Tgl AS 'Tanggal Transaksi'" &
                      " FROM tbl_transaksi_parent WHERE LEFT(Id_trans, 1) = 'K'" &
                      " AND Tgl >= DATE_SUB(NOW(), INTERVAL 7 DAY)" &
                      " AND Id_trans Like '%" & TXTCARI_TRANS.Text & "%'" &
                      " ORDER BY Id DESC"

            DA = New MySqlDataAdapter(STR, CONN)
            TBL = New DataTable
            DA.Fill(TBL)
            With DGCARI
                .DataSource = TBL
                .Columns("ID Transaksi").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("Tanggal Transaksi").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
        ElseIf LB_TITLE.Text = "FR_RUSAK" Then
            STR = "SELECT RTRIM(Id_trans) AS 'ID Transaksi'," &
                    " Tgl AS 'Tanggal Transaksi'" &
                    " FROM tbl_transaksi_parent WHERE LEFT(Id_trans, 1) = 'M'" &
                    " AND Id_trans Like '%" & TXTCARI_TRANS.Text & "%'" &
                    " AND (SELECT COALESCE(SUM(Stok), 0) FROM tbl_transaksi_child WHERE tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans) > 0" &
                    " ORDER BY Tgl DESC"

            DA = New MySqlDataAdapter(STR, CONN)
            Dim TBL As New DataTable
            DA.Fill(TBL)
            With DGCARI
                .DataSource = TBL
                .Columns("ID Transaksi").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("Tanggal Transaksi").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
        End If
    End Sub

    Private Sub TXTCARI_TRANS_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI_TRANS.TextChanged
        TAMPIL()
    End Sub

    Private Sub TXTCARI_TRANS_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCARI_TRANS.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TUTUP_FORM()
            Case Keys.Enter
                DGCARI.Select()
        End Select
    End Sub

    Private Sub TXTCARI_TRANS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI_TRANS.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub DGCARI_KeyDown(sender As Object, e As KeyEventArgs) Handles DGCARI.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TXTCARI_TRANS.Select()
            Case Keys.Enter
                e.Handled = True
                MASUK_DATA()
        End Select
    End Sub

    Sub MASUK_DATA()
        If LB_TITLE.Text = "FR_RETURN" Then
            With FR_RETURN
                .TXTID.Text = DGCARI.SelectedCells(0).Value
                .TXTID.Select()
                .Enabled = True
                .DATA_TRANSAKSI()
                .CARI_HARGA()
            End With
        ElseIf LB_TITLE.Text = "FR_RUSAK" Then
            With FR_RUSAK
                .TXTID.Text = DGCARI.SelectedCells(0).Value
                .TXTID.Select()
                .Enabled = True
                .DATA_TRANSAKSI()
                .CARI_HARGA()
            End With
        End If
        Me.Close()
    End Sub

    Private Sub DGCARI_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCARI.CellClick
        On Error Resume Next
        If e.RowIndex >= 0 Then
            MASUK_DATA()
        End If
    End Sub
End Class