Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports BarcodeLib

Public Class FR_PRODUK

    Dim KODE_PRODUK As String

    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        If MsgBox("Apakah anda yakin akan logout?", vbYesNo) = vbYes Then
            Dim FR As New FR_LOGIN
            My.Settings.ID_ACCOUNT = 0
            FR.Show()
            Me.Close()
        End If
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub FR_PRODUK_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case ROLE
            Case 1
                PNADMIN.Visible = True
                PNOPS.Visible = False
                Label3.Text = "Administrator"
            Case 2
                PNADMIN.Visible = False
                PNOPS.Visible = True
                Label3.Text = "Operator"
        End Select

        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN

        TAMPIL()
    End Sub

    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 21
    Sub TAMPIL()
        DGTAMPIL.Columns.Clear()
        Dim STR As String = "SELECT RTRIM(Kode) AS 'Kode Barang'," &
            " RTRIM(Barang) AS 'Nama Barang'," &
            " RTRIM(Satuan) AS 'Satuan'," &
            " Harga1 AS 'Harga Satuan' FROM tbl_barang" &
            " WHERE Barang LIKE '%" & TXTCARI.Text & "%'" &
            " OR Kode = '" & TXTCARI.Text & "'" &
            " ORDER BY 'Nama Barang' ASC"

        Dim DA As MySqlDataAdapter
        Dim TBL As New DataSet
        DA = New MySqlDataAdapter(STR, CONN)
        DA.Fill(TBL, START_RECORD, TAMPIL_RECORD, 0)
        DGTAMPIL.DataSource = TBL.Tables(0)

        DGTAMPIL.Columns(3).DefaultCellStyle.Format = "Rp ###,##"

        DGTAMPIL.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGTAMPIL.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGTAMPIL.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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
        DGTAMPIL.Columns(4).Width = 50

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
        DGTAMPIL.Columns(5).Width = 50

        Dim Column_cetak = New DataGridViewButtonColumn
        With Column_cetak
            .Text = "Cetak"
            .HeaderText = "Cetak"
            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .CellTemplate.Style.BackColor = Color.DarkGreen
            .CellTemplate.Style.ForeColor = Color.WhiteSmoke
            .Width = 100
        End With
        DGTAMPIL.Columns.Add(Column_cetak)
        DGTAMPIL.Columns(6).Width = 50

        DGTAMPIL.ColumnHeadersHeight = 35
        DGTAMPIL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGTAMPIL.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i = 0 To DGTAMPIL.Columns.Count - 1
            DGTAMPIL.Columns.Item(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        BTNPREV.Enabled = True
        BTNNEXT.Enabled = True

        Dim TOTAL_RECORD As Integer = 0
        Dim TBL_DATA As New DataTable
        DA = New MySqlDataAdapter(STR, CONN)
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


    Private Sub TXTCARI_Validated(sender As Object, e As EventArgs) Handles TXTCARI.Validated
        TAMPIL()
    End Sub

    Private Sub DGTAMPIL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellClick
        Dim STR As String
        Dim CMD As MySqlCommand

        If e.RowIndex >= 0 Then
            If DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Edit" Then
                Me.Enabled = False

                With FR_PRODUK_ACTION
                    .Show()
                    .Label1.Text = "EDIT PRODUK"
                    .TXTKODE.Text = DGTAMPIL.Item(0, e.RowIndex).Value
                    .TXTKODE.Enabled = False
                    .TXTNAMA.Select()
                    .CARI_PRODUK()
                End With
            ElseIf DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Delete" Then
                If MsgBox("Apakah anda yakin akan menghapus produk?", vbYesNo) = vbYes Then
                    Try
                        STR = "DELETE FROM tbl_barang " &
                            " WHERE Kode='" & DGTAMPIL.Item(0, e.RowIndex).Value & "'"
                        EXECUTE_NONQUERY(STR)
                        MsgBox("Data produk berhasil dihapus!")
                    Catch ex As MySqlException
                        MessageBox.Show(ex.Message)
                    Finally
                        TAMPIL()
                    End Try

                End If
            ElseIf DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Cetak" Then
                KODE_PRODUK = DGTAMPIL.Item(0, e.RowIndex).Value
                PPD.Document = PRINTBARCODE
                PPD.PrinterSettings = PRINTBARCODE.PrinterSettings
                PRINTBARCODE.DefaultPageSettings.PaperSize = New PaperSize("Custom", 430, 200)
                PPD.AllowSomePages = True

                If PPD.ShowDialog = DialogResult.OK Then
                    PRINTBARCODE.PrinterSettings = PRINTBARCODE.PrinterSettings
                    PRINTBARCODE.Print()
                End If
            End If
        End If
    End Sub

    Private Sub BTNNEXT_Click(sender As Object, e As EventArgs) Handles BTNNEXT.Click
        START_RECORD += TAMPIL_RECORD
        TAMPIL()
    End Sub

    Private Sub BTNPREV_Click(sender As Object, e As EventArgs) Handles BTNPREV.Click
        START_RECORD = START_RECORD - TAMPIL_RECORD
        TAMPIL()
    End Sub

    Dim WIDTH_BARCODE As Integer = 125
    Dim HEIGHT_BARCODE As Integer = 40
    Dim WIDTH_LABEL As Integer = 140
    Dim HEIGHT_LABEL As Integer = 84
    ReadOnly FONT_KODE As New Font("Segoe UI", 5, FontStyle.Regular)
    Dim PPD As New PrintDialog

    Private Sub BTNCETAK_Click(sender As Object, e As EventArgs)
        PPD.Document = PRINTBARCODE
        PPD.PrinterSettings = PRINTBARCODE.PrinterSettings
        PPD.PrinterSettings.PrinterName = "ZDesigner ZD220-203dpi ZPL"
        PRINTBARCODE.DefaultPageSettings.PaperSize = New PaperSize("Custom", 430, 200)
        PPD.AllowSomePages = True

        If PPD.ShowDialog = DialogResult.OK Then
            PRINTBARCODE.PrinterSettings = PRINTBARCODE.PrinterSettings
            PRINTBARCODE.Print()
        End If
    End Sub

    Private Sub PRINTBARCODE_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PRINTBARCODE.PrintPage
        Dim X As Integer = 2
        Dim Y As Integer = 10
        Dim textCenter As New StringFormat
        textCenter.Alignment = StringAlignment.Center

        Dim barcode As Barcode = New Barcode()
        Dim foreColor As Color = Color.Black
        Dim backColor As Color = Color.Transparent
        Dim image As Image = barcode.Encode(TYPE.CODE128, KODE_PRODUK, foreColor, backColor, WIDTH_BARCODE, HEIGHT_BARCODE)
        Dim MyBitmap As New Bitmap(image)
        For j As Integer = 0 To 2
            e.Graphics.DrawImage(MyBitmap, X, Y, WIDTH_BARCODE, HEIGHT_BARCODE)
            e.Graphics.DrawString(KODE_PRODUK, FONT_KODE, Brushes.Black, ((j * WIDTH_LABEL) + WIDTH_LABEL / 2) - 3, Y + HEIGHT_BARCODE, textCenter)
            X += WIDTH_LABEL + 3
        Next
    End Sub

    'Sub EDIT_PRODUK()
    '    TXTNAMA.Enabled = True
    '    TXTEND1.Enabled = True
    '    TXTHARGA1.Enabled = True
    '    CBSATUAN.Enabled = True
    '    BTNUBAH.Visible = False
    '    BTNSIMPAN.Visible = True
    '    If TXTEND2.Text <> "" Then
    '        TXTEND2.Enabled = True
    '        TXTHARGA2.Enabled = True
    '        TXTHARGA3.Enabled = True
    '    End If
    '    If TXTEND3.Text <> "" Then
    '        TXTEND3.Enabled = True
    '        TXTHARGA3.Enabled = True
    '        TXTHARGA4.Enabled = True
    '    End If
    '    If TXTEND4.Text <> "" Then
    '        TXTEND4.Enabled = True
    '        TXTHARGA4.Enabled = True
    '        TXTHARGA5.Enabled = True
    '    End If
    'End Sub

    Private Sub BTNLABELADMIN_Click(sender As Object, e As EventArgs) Handles BTNLABELADMIN.Click
        BUKA_FORM(FR_CETAK_LABEL)
    End Sub

    Private Sub BTNKASIR_Click(sender As Object, e As EventArgs) Handles BTNKASIR.Click
        BUKA_FORM(FR_KASIR)
    End Sub

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
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

    Private Sub BTNMEMBER_ADMIN_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_ADMIN.Click
        BUKA_FORM(FR_MEMBER)
    End Sub

    Private Sub BTNVOUCHER_ADMIN_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_ADMIN.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub TXTCARI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            TAMPIL()
        End If
    End Sub

    Private Sub BTNHISTORYPENJUALAN_Click(sender As Object, e As EventArgs) Handles BTNHISTORYPENJUALAN.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNDASHBOARDOPS_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDOPS.Click
        BUKA_FORM(FR_OPS_DASHBOARD)
    End Sub

    Private Sub BTNMEMBER_OPS_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_OPS.Click
        BUKA_FORM(FR_MEMBER)
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

    Private Sub BTNTAMBAH_Click(sender As Object, e As EventArgs) Handles BTNTAMBAH.Click
        Me.Enabled = False
        With FR_PRODUK_ACTION
            .Show()
            .Label1.Text = "TAMBAH PRODUK"
            .TXTKODE.Enabled = True
            .TXTKODE.Select()
        End With

    End Sub

    Private Sub DGTAMPIL_SelectionChanged(sender As Object, e As EventArgs) Handles DGTAMPIL.SelectionChanged
        DGTAMPIL.ClearSelection()
    End Sub
End Class