Imports System.Data.SqlClient

Public Class FR_KELUAR_TAMPIL
    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        FR_KELUAR.Enabled = True
        Me.Close()
    End Sub

    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 10

    Sub TAMPIL()
        If START_RECORD = 0 Then
            BTNPREV.Enabled = False
        End If

        DGCARI.Rows.Clear()

        Dim STR As String
        STR = "SELECT RTRIM(tbl_barang.Kode) as Kode," &
                    " RTRIM(Barang) as Barang," &
                    " RTRIM(Satuan) as Satuan," &
                    " (tbl_stok.Stok) AS Stok," &
                    " Harga1," &
                    " End1," &
                    " Harga2," &
                    " End2," &
                    " Harga3," &
                    " End3," &
                    " Harga4," &
                    " End4," &
                    " Harga5" &
                    " FROM tbl_barang" &
                    " INNER JOIN tbl_stok ON tbl_barang.Kode = tbl_stok.Kode" &
                    " WHERE Barang" &
                    " Like '%" & TXTCARI.Text & "%'" &
                    " OR tbl_barang.Kode Like '%" & TXTCARI.Text & "%'" &
                    " ORDER BY 'Barang' ASC" &
                    " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"

        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL)

        For Each EROW As DataRow In TBL.Tables(0).Rows
            DGCARI.Rows.Add()
            DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("KODE").Value = EROW.Item("Kode")
            DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("BARANG").Value = EROW.Item("Barang")
            DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("SATUAN").Value = EROW.Item("Satuan")
            DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("STOK").Value = Format(EROW.Item("Stok"), "##0.##")
            If EROW.Item("End1") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("OPSI1").Value = "0 - " & Format(EROW.Item("End1"), "##0.##")
            End If
            If EROW.Item("Harga1") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("HARGA1").Value = Format(EROW.Item("Harga1"), "##,##0")
            End If
            If EROW.Item("End2") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("OPSI2").Value = Format(EROW.Item("End1") + 1, "##0.##") & " - " & Format(EROW.Item("End2"), "##0.##")
            ElseIf EROW.Item("End2") = 0 And EROW.Item("End1") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("OPSI2").Value = ">= " & Format(EROW.Item("End1") + 1, "##0.##")
            End If
            If EROW.Item("Harga2") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("HARGA2").Value = Format(EROW.Item("Harga2"), "##,##0")
            End If
            If EROW.Item("End3") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("OPSI3").Value = Format(EROW.Item("End2") + 1, "##0.##") & " - " & Format(EROW.Item("End3"), "##0.##")
            ElseIf EROW.Item("End3") = 0 And EROW.Item("End2") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("OPSI3").Value = ">= " & Format(EROW.Item("End2") + 1, "##0.##")
            End If
            If EROW.Item("Harga3") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("HARGA3").Value = Format(EROW.Item("Harga3"), "##,##0")
            End If
            If EROW.Item("End4") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("OPSI4").Value = Format(EROW.Item("End3") + 1, "##0.##") & " - " & Format(EROW.Item("End4"), "##0.##")
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("OPSI5").Value = ">= " & Format(EROW.Item("End4") + 1, "##0.##")
            ElseIf EROW.Item("End4") = 0 And EROW.Item("End3") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("OPSI4").Value = ">= " & Format(EROW.Item("End3") + 1, "##0.##")
            End If
            If EROW.Item("Harga4") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("HARGA4").Value = Format(EROW.Item("Harga4"), "##,##0")
            End If
            If EROW.Item("Harga5") <> 0 Then
                DGCARI.Rows(DGCARI.Rows.Count - 1).Cells("HARGA5").Value = Format(EROW.Item("Harga5"), "##,##0")
            End If
        Next

        DGCARI.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGCARI.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGCARI.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGCARI.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DGCARI.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGCARI.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGCARI.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGCARI.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGCARI.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGCARI.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGCARI.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGCARI.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGCARI.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGCARI.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGCARI.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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

        'Dim TOTAL_RECORD As Integer = 0
        'Dim TBL_DATA As New DataTable
        'DA = New SqlDataAdapter(STR, CONN)
        'DA.Fill(TBL_DATA)

        'STR = "SELECT COUNT(*) FROM tbl_barang WHERE Barang Like '%" & TXTCARI.Text & "%'" &
        '            " OR Kode = '" & TXTCARI.Text & "'"
        'Dim CMD As New SqlCommand(STR, CONN)

        'TOTAL_RECORD = Convert.ToUInt64(CMD.ExecuteScalar())

        'If TOTAL_RECORD = 0 Then
        '    BTNPREV.Enabled = False
        '    BTNNEXT.Enabled = False
        If START_RECORD = 0 Then
            BTNPREV.Enabled = False
        Else
            BTNPREV.Enabled = True
        End If
        'ElseIf TOTAL_RECORD <= START_RECORD Then
        '    BTNNEXT.Enabled = False
        'ElseIf TOTAL_RECORD - START_RECORD <= TAMPIL_RECORD Then
        '    BTNNEXT.Enabled = False
        'Else
        '    BTNPREV.Enabled = True
        '    BTNNEXT.Enabled = True
        'End If
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
        START_RECORD = 0
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
        ElseIf (e.KeyCode = Keys.F1) Then
            TXTCARI.Select()
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

    Private Sub DGCARI_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCARI.CellClick
        On Error Resume Next
        FR_KELUAR.TXTKODE.Text = DGCARI.Item(0, e.RowIndex).Value
        FR_KELUAR.TXTKODE.Select()
        FR_KELUAR.Enabled = True
        Me.Close()
    End Sub
End Class