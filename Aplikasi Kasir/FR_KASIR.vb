Imports MySql.Data.MySqlClient
Public Class FR_KASIR
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
    End Sub

    Sub TAMPIL()
        DGTAMPIL.Columns.Clear()
        Dim STR As String = "SELECT RTRIM(Id) as ID,RTRIM(Nama) AS 'Nama Lengkap',RTRIM(Alamat) AS Alamat," &
            " Tgl_lahir as 'Tanggal Lahir',JK as 'Jenis Kelamin',RTRIM(No_hp) AS 'Nomor HP', Role AS 'Hak Akses'" &
            " FROM tbl_karyawan WHERE Nama Like '%" & TXTCARI.Text & "%' AND ID != '" & My.Settings.ID_ACCOUNT & "'"
        Dim DA As MySqlDataAdapter
        DA = New MySqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGTAMPIL.DataSource = TBL

        DGTAMPIL.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGTAMPIL.Columns("Tanggal Lahir").DefaultCellStyle.Format = "dd MMMM yyyy"

        For N = 0 To DGTAMPIL.Rows.Count - 1
            If DGTAMPIL.Rows(N).Cells(4).Value = "L" Then
                DGTAMPIL.Rows(N).Cells(4).Value = "Laki-laki"
            Else
                DGTAMPIL.Rows(N).Cells(4).Value = "Perempuan"
            End If

            If DGTAMPIL.Rows(N).Cells(6).Value = 1 Then
                DGTAMPIL.Rows(N).Cells(6).Value = "Administrator"
            ElseIf DGTAMPIL.Rows(N).Cells(6).Value = 2 Then
                DGTAMPIL.Rows(N).Cells(6).Value = "Operator"
            Else
                DGTAMPIL.Rows(N).Cells(6).Value = "Kasir"
            End If
        Next

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

        Dim Column_reset As New DataGridViewButtonColumn

        With Column_reset
            .Text = "Reset"
            .HeaderText = "Reset"
            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .CellTemplate.Style.BackColor = Color.DarkGreen
            .CellTemplate.Style.ForeColor = Color.WhiteSmoke
            .Width = 100
        End With
        DGTAMPIL.Columns.Add(Column_reset)

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

        DGTAMPIL.ColumnHeadersHeight = 35
        DGTAMPIL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGTAMPIL.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i = 0 To DGTAMPIL.Columns.Count - 1
            DGTAMPIL.Columns.Item(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i
    End Sub

    Private Sub TXTCARI_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI.TextChanged
        TAMPIL()
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNTAMBAH.Click
        With FR_KASIR_ACTION
            .Show()
            .Label1.Text = "TAMBAH KASIR"
            .TXTID.Enabled = False
            .TXTNAMA.Select()
        End With
        Me.Enabled = False
    End Sub

    Private Sub DGTAMPIL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellClick
        'TXTID.Visible = True
        'LBID.Visible = True
        'TXTID.Text = DGTAMPIL.Item("Id", e.RowIndex).Value

        Dim STR As String
        Dim CMD As MySqlCommand

        If e.RowIndex >= 0 Then
            If DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Edit" Then
                Me.Enabled = False

                With FR_KASIR_ACTION
                    .Show()
                    .Label1.Text = "EDIT KASIR"
                    .TXTID.Text = DGTAMPIL.Item("Id", e.RowIndex).Value
                    .TXTID.Visible = True
                    .LBID.Visible = True
                    .TXTNAMA.Select()
                    .CARI_DATA()
                End With
            ElseIf DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Delete" Then
                If MsgBox("Apakah anda yakin akan menghapus kasir?", vbYesNo) = vbYes Then
                    Try
                        CONN.Open()

                        STR = "DELETE FROM tbl_karyawan " &
                            " WHERE Id='" & DGTAMPIL.Item("Id", e.RowIndex).Value & "'"
                        CMD = New MySqlCommand(STR, CONN)
                        CMD.ExecuteNonQuery()

                        CONN.Close()
                    Catch ex As MySqlException
                        MessageBox.Show(ex.Message)
                    Finally
                        CONN.Dispose()
                        MsgBox("Data kasir berhasil dihapus!")
                        TAMPIL()
                    End Try

                End If
            ElseIf DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Reset" Then
                Dim message As String = "Apakah anda yakin akan mereset password akun " & DGTAMPIL.Item("Nama Lengkap", e.RowIndex).Value & " ke 123456?"
                If MsgBox(message, vbYesNo) = vbYes Then
                    Try
                        CONN.Open()

                        STR = "UPDATE tbl_karyawan set Password = '123456', " &
                        " Modified_at = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                        " WHERE Id='" & DGTAMPIL.Item("Id", e.RowIndex).Value & "'"
                        CMD = New MySqlCommand(STR, CONN)
                        CMD.ExecuteNonQuery()

                        CONN.Close()
                    Catch ex As MySqlException
                        MessageBox.Show(ex.Message)
                    Finally
                        CONN.Dispose()
                        MsgBox("Password berhasil direset ke 123456!")
                        TAMPIL()
                    End Try

                End If
            End If
        End If
    End Sub


    Private Sub FR_KASIR_Load(sender As Object, e As EventArgs) Handles Me.Load
        TAMPIL()

        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True

        LBLUSER.Text = NAMA_LOGIN
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        BUKA_FORM(FR_MENU)
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

    Private Sub BTNLABELADMIN_Click(sender As Object, e As EventArgs) Handles BTNLABELADMIN.Click
        BUKA_FORM(FR_CETAK_LABEL)
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

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub DGTAMPIL_SelectionChanged(sender As Object, e As EventArgs) Handles DGTAMPIL.SelectionChanged
        DGTAMPIL.ClearSelection()
    End Sub
End Class