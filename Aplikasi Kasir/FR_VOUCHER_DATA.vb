Imports MySql.Data.MySqlClient

Public Class FR_VOUCHER_DATA

    Dim CMD As MySqlCommand
    Dim RD As MySqlDataReader
    Dim DA As MySqlDataAdapter
    Dim STR As String

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        FR_VOUCHER.Enabled = True
        Me.Close()
    End Sub

    Sub TAMPIL()
        DGTAMPIL.Columns.Clear()
        STR = "SELECT" &
                    " RTRIM(Id) AS 'ID'," &
                    " RTRIM(Jenis) AS 'Jenis Voucher'," &
                    " RTRIM(Nama) AS 'Nama Voucher'," &
                    " Harga AS 'Harga'," &
                    " Harga_jual AS 'Senilai'" &
                    " FROM tbl_data_voucher" &
                    " WHERE Nama Like '%" & TXTCARI.Text & "%' " &
                    " ORDER BY Id ASC"
        DA = New MySqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGTAMPIL.DataSource = TBL

        DGTAMPIL.Columns(0).Visible = False
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGTAMPIL.Columns(3).DefaultCellStyle.Format = "###,#0"
        DGTAMPIL.Columns(4).DefaultCellStyle.Format = "###,#0"

        DGTAMPIL.ColumnHeadersHeight = 35
        DGTAMPIL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGTAMPIL.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i = 0 To DGTAMPIL.Columns.Count - 1
            DGTAMPIL.Columns.Item(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        Dim Column_edit As New DataGridViewButtonColumn

        With Column_edit
            .Text = "Edit"
            .HeaderText = "Edit"
            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .CellTemplate.Style.BackColor = Color.Navy
            .CellTemplate.Style.ForeColor = Color.WhiteSmoke
            .Width = 100
        End With
        DGTAMPIL.Columns.Add(Column_edit)
        DGTAMPIL.Columns(5).Width = 50

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
        DGTAMPIL.Columns(6).Width = 50
    End Sub

    Private Sub DGTAMPIL_SelectionChanged(sender As Object, e As EventArgs) Handles DGTAMPIL.SelectionChanged
        DGTAMPIL.ClearSelection()
    End Sub

    Private Sub FR_VOUCHER_DATA_Load(sender As Object, e As EventArgs) Handles Me.Load
        TAMPIL()
    End Sub

    Private Sub TXTCARI_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI.TextChanged
        TAMPIL()
    End Sub

    Private Sub DGTAMPIL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellClick
        If e.RowIndex >= 0 Then
            If ROLE = 1 Or ROLE = 2 Then
                If DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Edit" Then
                    Me.Enabled = False

                    With FR_VOUCHER_DATA_ACTION
                        .Show()
                        .Label1.Text = "EDIT DATA VOUCHER"
                        .LBL_ID.Text = DGTAMPIL.Item("Id", e.RowIndex).Value
                        .TXTNAMA.Select()
                        .CARI_DATA()
                    End With
                ElseIf DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Delete" Then
                    If MsgBox("Apakah anda yakin akan menghapus data voucher?", vbYesNo) = vbYes Then
                        Try
                            BUKA_KONEKSI()
                        Catch ex As Exception
                            MsgBox("Koneksi database gagal: " & ex.Message, vbCritical)
                            Return
                        End Try

                        STR = "DELETE tbl_data_voucher " &
                            " WHERE Id='" & DGTAMPIL.Item("Id", e.RowIndex).Value & "'"
                        CMD = New MySqlCommand(STR, CONN)
                        CMD.ExecuteNonQuery()
                        MsgBox("Data voucher berhasil dihapus!")
                        TAMPIL()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        Me.Enabled = False
        With FR_VOUCHER_DATA_ACTION
            .Show()
            .LBL_ID.Text = ""
            .CB_JENIS.SelectedIndex = 0
            .CB_JENIS.Select()
        End With
    End Sub
End Class