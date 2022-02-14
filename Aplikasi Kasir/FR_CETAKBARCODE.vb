Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports BarcodeLib

Public Class FR_CETAKBARCODE
    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
    End Sub

    Private Sub BTNDASHBOARDOPS_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDOPS.Click
        BUKA_FORM(FR_OPS_DASHBOARD)
    End Sub

    Private Sub BTNLABELOPS_Click(sender As Object, e As EventArgs) Handles BTNLABELOPS.Click
        BUKA_FORM(FR_CETAK_LABEL)
    End Sub

    Private Sub BTNMASUKOPS_Click(sender As Object, e As EventArgs) Handles BTNMASUKOPS.Click
        BUKA_FORM(FR_MASUK)
    End Sub

    Private Sub BTNKELUAROPS_Click(sender As Object, e As EventArgs) Handles BTNKELUAROPS.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNRETURNOPS_Click(sender As Object, e As EventArgs) Handles BTNRETURNOPS.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAKOPS_Click(sender As Object, e As EventArgs) Handles BTNRUSAKOPS.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub BTNLAPORANOPS_Click(sender As Object, e As EventArgs) Handles BTNLAPORANOPS.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNTENTANGOPS_Click(sender As Object, e As EventArgs) Handles BTNTENTANGOPS.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        Select Case ROLE
            Case 1
                BUKA_FORM(FR_MENU)
            Case 2
                BUKA_FORM(FR_OPS_DASHBOARD)
            Case 3
                BUKA_FORM(FR_KASIR_DASHBOARD)
        End Select
    End Sub

    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub FR_CETAKBARCODE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN
        TAMPIL_BARANG()
    End Sub

    Dim TBL_DATA As New DataTable
    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 30

    Sub TAMPIL_BARANG()
        Dim STR As String = "SELECT RTRIM(Kode) AS 'Kode Barang'," &
            " RTRIM(Barang) AS 'Nama Barang'," &
            " RTRIM(Satuan) AS 'Satuan'," &
            " Harga1 AS 'Harga Satuan' FROM tbl_barang" &
            " WHERE Barang LIKE '%" & TXTCARI.Text & "%'" &
            " ORDER BY 'Nama Barang' ASC"

        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL, START_RECORD, TAMPIL_RECORD, 0)
        DGBARANG.DataSource = TBL.Tables(0)

        DGBARANG.Columns(3).DefaultCellStyle.Format = "Rp ###,##"

        DGBARANG.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGBARANG.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGBARANG.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGBARANG.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGBARANG.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGBARANG.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        BTNPREV.Enabled = True
        BTNNEXT.Enabled = True
        Dim TOTAL_RECORD As Integer = 0

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

    Private Sub BTNPREV_Click(sender As Object, e As EventArgs) Handles BTNPREV.Click
        START_RECORD -= TAMPIL_RECORD
        TAMPIL_BARANG()
    End Sub

    Private Sub BTNNEXT_Click(sender As Object, e As EventArgs) Handles BTNNEXT.Click
        START_RECORD += TAMPIL_RECORD
        TAMPIL_BARANG()
    End Sub

    Dim WIDTH_BARCODE As Integer = 121
    Dim HEIGHT_BARCODE As Integer = 40
    Dim WIDTH_LABEL As Integer = 140
    Dim HEIGHT_LABEL As Integer = 84
    ReadOnly FONT_KODE As New Font("Segoe UI", 5, FontStyle.Regular)
    Dim PPD As New PrintDialog

    Private Sub BTNCETAK_Click(sender As Object, e As EventArgs) Handles BTNCETAK.Click
        PPD.Document = PRINTBARCODE
        PPD.PrinterSettings = PRINTBARCODE.PrinterSettings
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
        Dim image As Image = barcode.Encode(TYPE.CODE128, DGBARANG.Item(0, DGBARANG.CurrentRow.Index).Value, foreColor, backColor, WIDTH_BARCODE, HEIGHT_BARCODE)
        Dim MyBitmap As New Bitmap(image)
        For j As Integer = 0 To 2
            e.Graphics.DrawImage(MyBitmap, X, Y, WIDTH_BARCODE, HEIGHT_BARCODE)
            e.Graphics.DrawString(DGBARANG.Item(0, DGBARANG.CurrentRow.Index).Value, FONT_KODE, Brushes.Black, ((j * WIDTH_LABEL) + WIDTH_LABEL / 2) - 3, Y + HEIGHT_BARCODE, textCenter)
            X += WIDTH_LABEL + 3
        Next
    End Sub

    Private Sub TXTCARI_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI.TextChanged
        TAMPIL_BARANG()
    End Sub
End Class