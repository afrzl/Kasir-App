Imports MySql.Data.MySqlClient

Public Class FR_MEMBER
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Dim CMD As MySqlCommand
    Dim RD As MySqlDataReader
    Dim STR As String

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
    End Sub

    Private Sub FR_MEMBER_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case ROLE
            Case 1
                PNADMIN.Visible = True
                PNOPS.Visible = False
                PNKASIR.Visible = False
                Label3.Text = "Administrator"
            Case 2
                PNADMIN.Visible = False
                PNOPS.Visible = True
                PNKASIR.Visible = False
                Label3.Text = "Operator"
            Case 3
                PNADMIN.Visible = False
                PNOPS.Visible = False
                PNKASIR.Visible = True
                Label3.Text = "Kasir"
        End Select

        If DGTAMPIL.RowCount > 0 Then

        End If
        TAMPIL()
        LOAD_RIWAYAT()

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

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNKASIR_Click(sender As Object, e As EventArgs) Handles BTNKASIR.Click
        BUKA_FORM(FR_KASIR)
    End Sub

    Private Sub BTNBARANG_Click(sender As Object, e As EventArgs) Handles BTNBARANG.Click
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub BTNVOUCHER_ADMIN_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_ADMIN.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub BTNLABELADMIN_Click(sender As Object, e As EventArgs) Handles BTNLABELADMIN.Click
        BUKA_FORM(FR_CETAK_LABEL)
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

    Private Sub BTNHISTORYPENJUALAN_Click(sender As Object, e As EventArgs) Handles BTNHISTORYPENJUALAN.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNLAPORAN_Click(sender As Object, e As EventArgs) Handles BTNLAPORAN.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNDASHBOARDOPS_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDOPS.Click
        BUKA_FORM(FR_OPS_DASHBOARD)
    End Sub

    Private Sub BTNBARANGOPS_Click(sender As Object, e As EventArgs) Handles BTNBARANGOPS.Click
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub BTNHISTORYOPS_Click(sender As Object, e As EventArgs) Handles BTNHISTORYOPS.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNKELUAROPS_Click(sender As Object, e As EventArgs) Handles BTNKELUAROPS.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNLABELOPS_Click(sender As Object, e As EventArgs) Handles BTNLABELOPS.Click
        BUKA_FORM(FR_CETAK_LABEL)
    End Sub

    Private Sub BTNLAPORANOPS_Click(sender As Object, e As EventArgs) Handles BTNLAPORANOPS.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNMASUKOPS_Click(sender As Object, e As EventArgs) Handles BTNMASUKOPS.Click
        BUKA_FORM(FR_MASUK)
    End Sub

    Private Sub BTNRETURNOPS_Click(sender As Object, e As EventArgs) Handles BTNRETURNOPS.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAKOPS_Click(sender As Object, e As EventArgs) Handles BTNRUSAKOPS.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub BTNTENTANGOPS_Click(sender As Object, e As EventArgs) Handles BTNTENTANGOPS.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNVOUCHER_OPS_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_OPS.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub BTNDASHBOARDKASIR_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDKASIR.Click
        BUKA_FORM(FR_KASIR_DASHBOARD)
    End Sub

    Private Sub BTNVOUCHER_KASIR_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_KASIR.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub BTNLABELKASIR_Click(sender As Object, e As EventArgs) Handles BTNLABELKASIR.Click
        BUKA_FORM(FR_CETAK_LABEL)
    End Sub

    Private Sub BTNMASUKKASIR_Click(sender As Object, e As EventArgs) Handles BTNMASUKKASIR.Click
        BUKA_FORM(FR_MASUK)
    End Sub

    Private Sub BTNKELUARKASIR_Click(sender As Object, e As EventArgs) Handles BTNKELUARKASIR.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNHISTORYPENJUALANKASIR_Click(sender As Object, e As EventArgs) Handles BTNHISTORYPENJUALANKASIR.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNRETURNKASIR_Click(sender As Object, e As EventArgs) Handles BTNRETURNKASIR.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNLAPORANKASIR_Click(sender As Object, e As EventArgs) Handles BTNLAPORANKASIR.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNSETTINGKASIR_Click(sender As Object, e As EventArgs) Handles BTNSETTINGKASIR.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Sub TAMPIL()
        DGTAMPIL.Columns.Clear()
        Dim STR As String = "SELECT Id as ID," &
            "RTRIM(Nama) AS 'Nama Lengkap'," &
            "RTRIM(Alamat) AS 'Alamat'," &
            "RTRIM(No_hp) AS 'No HP'," &
            "RTRIM(JK) AS 'JK'," &
            "Points," &
            "Created_at AS 'Tanggal Pembuatan'" &
            "FROM tbl_member " &
            "WHERE Nama Like '%" & TXTCARI.Text & "%' " &
            "OR Id = '" & TXTCARI.Text & "'"
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

        DGTAMPIL.Columns(5).DefaultCellStyle.Format = "###,#0"

        For N = 0 To DGTAMPIL.Rows.Count - 1
            If DGTAMPIL.Rows(N).Cells(4).Value = "L" Then
                DGTAMPIL.Rows(N).Cells(4).Value = "Laki-laki"
            Else
                DGTAMPIL.Rows(N).Cells(4).Value = "Perempuan"
            End If
        Next

        If ROLE = 1 Or ROLE = 2 Then
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
            DGTAMPIL.Columns(6).Width = 50

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
            DGTAMPIL.Columns(7).Width = 50

            ' Tambah kolom Tukar Point
            Dim Column_tukarpoint = New DataGridViewButtonColumn
            With Column_tukarpoint
                .Text = "Tukar Point"
                .HeaderText = "Tukar Point"
                .UseColumnTextForButtonValue = True
                .FlatStyle = FlatStyle.Flat
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .CellTemplate.Style.BackColor = Color.DarkOrange
                .CellTemplate.Style.ForeColor = Color.WhiteSmoke
                .Width = 100
            End With
            DGTAMPIL.Columns.Add(Column_tukarpoint)
            DGTAMPIL.Columns(8).Width = 50

        End If
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

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        With FR_MEMBER_ACTION
            .Show()
            .Label1.Text = "TAMBAH MEMBER"
            .TXTID.Enabled = True
            .TXTID.Select()
        End With
        Me.Enabled = False
    End Sub

    Private Sub DGTAMPIL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellClick
        On Error Resume Next

        If e.RowIndex >= 0 Then
            If ROLE = 1 Or ROLE = 2 Then
                If DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Edit" Then
                    Me.Enabled = False

                    With FR_MEMBER_ACTION
                        .Show()
                        .Label1.Text = "EDIT MEMBER"
                        .TXTID.Text = DGTAMPIL.Item("Id", e.RowIndex).Value
                        .TXTID.Enabled = False
                        .TXTNAMA.Select()
                        .CARI_DATA()
                    End With
                ElseIf DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Delete" Then
                    If MsgBox("Apakah anda yakin akan menghapus member?", vbYesNo) = vbYes Then
                        STR = "DELETE tbl_member " &
                            " WHERE Id='" & DGTAMPIL.Item("Id", e.RowIndex).Value & "'"
                        CMD = New MySqlCommand(STR, CONN)
                        CMD.ExecuteNonQuery()
                        MsgBox("Data member berhasil dihapus!")
                        TAMPIL()
                        LOAD_RIWAYAT()
                    End If
                ElseIf DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Tukar Point" Then
                    Me.Enabled = False

                    With FR_TUKAR_POINT
                        .Show()
                        .LBIDMEMBER.Text = DGTAMPIL.Item("ID", e.RowIndex).Value
                        .LBNAMAMEMBER.Text = DGTAMPIL.Item("Nama Lengkap", e.RowIndex).Value
                        .LBPOINTTERSEDIA.Text = Convert.ToDecimal(DGTAMPIL.Item("Points", e.RowIndex).Value).ToString("###,##0")
                        .TXTNAMABARANG.Select()
                    End With
                End If
            End If
        End If
    End Sub

    Private Sub DGTAMPIL_SelectionChanged(sender As Object, e As EventArgs) Handles DGTAMPIL.SelectionChanged
        DGTAMPIL.ClearSelection()
    End Sub

    Sub LOAD_RIWAYAT()
        Try
            DGRIWAYAT.Columns.Clear()
            
            ' Tampilkan semua riwayat penukaran point
            STR = "SELECT " &
                  "DATE_FORMAT(tp.Created_at, '%d/%m/%Y %H:%i') AS 'Tanggal', " &
                  "m.Nama AS 'Member', " &
                  "tp.Nama_barang AS 'Nama Barang', " &
                  "tp.Point AS 'Point', " &
                  "k.Nama AS 'Kasir' " &
                  "FROM tbl_penukaran_point tp " &
                  "LEFT JOIN tbl_karyawan k ON tp.Id_kasir = k.Id " &
                  "LEFT JOIN tbl_member m ON tp.Id_member = m.Id " &
                  "ORDER BY tp.Created_at DESC " &
                  "LIMIT 50"

            Dim DA As New MySqlDataAdapter(STR, CONN)
            Dim TBL As New DataTable
            DA.Fill(TBL)
            DGRIWAYAT.DataSource = TBL

            If DGRIWAYAT.Columns.Count > 0 Then
                DGRIWAYAT.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGRIWAYAT.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGRIWAYAT.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                DGRIWAYAT.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGRIWAYAT.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                DGRIWAYAT.Columns(3).DefaultCellStyle.Format = "###,##0"
                DGRIWAYAT.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            DGRIWAYAT.ColumnHeadersHeight = 35
            DGRIWAYAT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DGRIWAYAT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For i = 0 To DGRIWAYAT.Columns.Count - 1
                DGRIWAYAT.Columns.Item(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading riwayat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class