Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO

Public Class FR_HISTORYPENJUALAN_TAMPIL
    Dim STR As String
    Dim DA As SqlDataAdapter
    Dim RD As SqlDataReader
    Dim CMD As SqlCommand
    Dim TBL As DataSet
    Dim ID_TRANS As String

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        FR_HISTORYPENJUALAN.Enabled = True
        Me.Close()
    End Sub

    Private Sub FR_HISTORYPENJUALAN_TAMPIL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ID_TRANS = LBL_IDTRANS.Text

        STR = "SELECT" &
            " RTRIM(tbl_karyawan.Nama) AS'Kasir'," &
            " tbl_transaksi_parent.Tgl AS 'Tgl'," &
            " RTRIM(tbl_transaksi_parent.Id_member) AS 'Id_member'," &
            " RTRIM(tbl_transaksi_parent.Person) AS 'Person'," &
            " tbl_transaksi_parent.Harga AS 'Harga'," &
            " tbl_transaksi_parent.Diskon AS 'Diskon_trans'," &
            " tbl_transaksi_parent.Harga_total AS 'Harga_total'," &
            " tbl_transaksi_parent.Harga_tunai AS 'Bayar'," &
            " tbl_transaksi_parent.Harga_kembali AS 'Kembali'" &
            " FROM tbl_transaksi_parent" &
            " INNER JOIN tbl_karyawan ON tbl_transaksi_parent.Id_kasir = tbl_karyawan.Id" &
            " WHERE tbl_transaksi_parent.Id_trans = '" & ID_TRANS & "'"
        CMD = New SqlCommand(STR, CONN)
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            LBL_IDTRANS.Text = ": " & ID_TRANS
            LBL_TGLTRANS.Text = ": " & Format(RD.Item("Tgl"), "dd MMMM yyyy HH:mm:ss")
            If IsDBNull(RD.Item("Id_member")) Then
                LBL_PEMBELI.Text = ": " & RD.Item("Person")
            Else
                LBL_PEMBELI.Text = ": " & RD.Item("Person") & " (" & RD.Item("Id_member") & ")"
            End If
            LBL_KASIR.Text = ": " & RD.Item("Kasir")
            LBL_SUBTOTAL.Text = ": Rp" & Format(CInt(RD.Item("Harga")), "##,##0")
            LBL_DISKON.Text = ": Rp" & Format(CInt(RD.Item("Diskon_trans")), "##,##0")
            LBL_TOTAL.Text = ": Rp" & Format(CInt(RD.Item("Harga_total")), "##,##0")
            LBL_BAYAR.Text = ": Rp" & Format(CInt(RD.Item("Bayar")), "##,##0")
            LBL_KEMBALI.Text = ": Rp" & Format(CInt(RD.Item("Kembali")), "##,##0")

            RD.Close()
        Else
            RD.Close()
        End If

        STR = "SELECT" &
            " RTRIM(tbl_transaksi_child.Kode) AS 'Kode'," &
            " RTRIM(tbl_barang.Barang) AS 'Barang'," &
            " RTRIM(tbl_barang.Satuan) AS 'Satuan'," &
            " tbl_transaksi_child.Jumlah AS 'Jumlah'," &
            " tbl_transaksi_child.Harga/tbl_transaksi_child.Jumlah AS 'Harga Awal'," &
            " tbl_transaksi_child.Diskon AS 'Diskon'," &
            " tbl_transaksi_child.Harga_akhir AS 'Harga Akhir'" &
            " FROM tbl_transaksi_child" &
            " LEFT JOIN tbl_barang ON tbl_barang.Kode = tbl_transaksi_child.Kode" &
            " WHERE tbl_transaksi_child.Id_trans = '" & ID_TRANS & "'" &
            " ORDER BY tbl_transaksi_child.Id ASC"

        TBL = New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL)
        DGHISTORY.DataSource = TBL.Tables(0)

        DGHISTORY.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGHISTORY.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGHISTORY.Columns(3).DefaultCellStyle.Format = "##0.##"
        DGHISTORY.Columns(4).DefaultCellStyle.Format = "Rp ###,#0"
        DGHISTORY.Columns(5).DefaultCellStyle.Format = "Rp ###,#0"
        DGHISTORY.Columns(6).DefaultCellStyle.Format = "Rp ###,#0"

        DGHISTORY.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGHISTORY.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGHISTORY.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i = 0 To DGHISTORY.Columns.Count - 1
            DGHISTORY.Columns.Item(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        For i As Integer = 0 To DGHISTORY.Rows.Count - 1
            If IsDBNull(DGHISTORY.Item(1, i).Value) Then
                STR = "SELECT" &
                    " RTRIM(tbl_data_voucher.Nama) AS 'Nama'" &
                    " FROM tbl_transaksi_voucher" &
                    " INNER JOIN tbl_data_voucher ON tbl_data_voucher.Id = tbl_transaksi_voucher.Id_data" &
                    " WHERE tbl_transaksi_voucher.Kode = '" & DGHISTORY.Item(0, i).Value & "'"
                CMD = New SqlCommand(STR, CONN)
                RD = CMD.ExecuteReader
                If RD.HasRows Then
                    RD.Read()
                    DGHISTORY.Item(1, i).Value = RD.Item("Nama")
                    RD.Close()
                Else
                    RD.Close()
                End If
            End If
        Next
    End Sub

    Private Sub DGHISTORY_SelectionChanged(sender As Object, e As EventArgs) Handles DGHISTORY.SelectionChanged
        DGHISTORY.ClearSelection()
    End Sub

    'PRINTING
    '=================================================================================
    'KERTAS 

    ReadOnly lebarKertas As Integer = 304 'Ukuran Kertas 78 mm
    ReadOnly tinggiKertas As Integer = 400
    ReadOnly marginLeft As Integer = 20
    ReadOnly marginRight As Integer = 20
    ReadOnly jarakBaris As Integer = 20
    Dim totalBaris As Integer = 0


    'JENIS DAN UKURAN HURUF
    ReadOnly fontJudul As New Font("Segoe UI", 12, FontStyle.Bold)
    ReadOnly fontRegular As New Font("Segoe UI", 10, FontStyle.Regular)
    ReadOnly fontTotal As New Font("Segoe UI", 10, FontStyle.Bold)
    Dim countBarang As Integer = 0
    Dim pageNumber As Integer = 1

    Private Function BarisBaru(jumlah_baris)
        totalBaris += jumlah_baris
        Return totalBaris * jarakBaris
    End Function

    Private Function BarisYangSama()
        Return BarisBaru(0)
    End Function

    Private Sub PRINTNOTA_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PRINTNOTA.PrintPage
        Dim IMAGESTREAM As New MemoryStream
        IMAGESTREAM = New MemoryStream(Convert.FromBase64String(URL_LOGO))

        Dim textCenter, textLeft, textRight As New StringFormat
        textCenter.Alignment = StringAlignment.Center
        textLeft.Alignment = StringAlignment.Near
        textRight.Alignment = StringAlignment.Far
        Dim WIDTH As Single = 150
        Dim HEIGHT As Single = 75
        Dim JARAK As Single = (lebarKertas - WIDTH) / 2

        totalBaris = 0

        If pageNumber = 1 Then
            Dim IMAGE As Image = Image.FromStream(IMAGESTREAM)
            Dim MyBitmap As New Bitmap(IMAGE)
            e.Graphics.DrawImage(MyBitmap, JARAK, BarisYangSama(), WIDTH, HEIGHT)

            e.Graphics.DrawString(NAMA_TOKO, fontJudul, Brushes.Black, lebarKertas / 2, BarisBaru(HEIGHT / jarakBaris), textCenter)
            e.Graphics.DrawString(ALAMAT_TOKO, fontRegular, Brushes.Black, New Rectangle(20, BarisBaru(1), lebarKertas - 30, BarisYangSama), textCenter)
            e.Graphics.DrawString(NO_TOKO, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
            BarisBaru(1)

            e.Graphics.DrawString(LBL_TGLTRANS.Text.Remove(0, 2), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)

            e.Graphics.DrawString(LBL_IDTRANS.Text.Remove(0, 2), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)
            e.Graphics.DrawString("Kasir : " & LBL_KASIR.Text.Remove(0, 2), fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)

            e.Graphics.DrawLine(Pens.Black, marginLeft, BarisBaru(1), (lebarKertas - marginRight), BarisYangSama)
        End If

        For row As Integer = 0 To DGHISTORY.Rows.Count - 1
            If row >= countBarang And countBarang < DGHISTORY.RowCount Then
                e.Graphics.DrawString(DGHISTORY.Item("Barang", row).Value, fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
                If CInt(DGHISTORY.Item("Diskon", row).Value) = 0 Then
                    e.Graphics.DrawString(Convert.ToDouble(DGHISTORY.Item("Jumlah", row).Value) & " " & DGHISTORY.Item("Satuan", row).Value & " x " & Format(CInt(DGHISTORY.Item("Harga Awal", row).Value), "##,##0"), fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
                Else
                    e.Graphics.DrawString(Convert.ToDouble(DGHISTORY.Item("Jumlah", row).Value) & " " & DGHISTORY.Item("Satuan", row).Value & " x " & Format(CInt(DGHISTORY.Item("Harga Awal", row).Value), "##,##0") & " (Disc. " & Format(CInt(DGHISTORY.Item("Diskon", row).Value), "##,##0") & ")", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
                End If
                e.Graphics.DrawString(Format(CInt(DGHISTORY.Item("Harga Akhir", row).Value), "##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
                BarisBaru(1)
                countBarang += 1
                If totalBaris = 52 Then
                    e.HasMorePages = True
                    pageNumber += 1
                    totalBaris = 0
                    Exit Sub
                End If
            End If
        Next

        If totalBaris = 52 Then
            e.HasMorePages = True
            pageNumber += 1
            totalBaris = 0
            Exit Sub
        End If

        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)
        If CInt(LBL_DISKON.Text.Remove(0, 4)) = 0 Then
            e.Graphics.DrawString("Subtotal", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
            e.Graphics.DrawString(Format(CInt(LBL_SUBTOTAL.Text.Remove(0, 4)), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
        Else
            e.Graphics.DrawString("Subtotal", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
            e.Graphics.DrawString(Format(CInt(LBL_SUBTOTAL.Text.Remove(0, 4)), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

            e.Graphics.DrawString("Diskon", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
            e.Graphics.DrawString(Format(CInt(LBL_DISKON.Text.Remove(0, 4)), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
        End If

        BarisBaru(1)
        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)

        e.Graphics.DrawString("Total", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
        e.Graphics.DrawString(Format(CInt(LBL_TOTAL.Text.Remove(0, 4)), "Rp ##,##0"), fontTotal, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        e.Graphics.DrawString("Tunai", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
        e.Graphics.DrawString(Format(CInt(LBL_BAYAR.Text.Remove(0, 4)), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        e.Graphics.DrawString("Kembali", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
        e.Graphics.DrawString(Format(CInt(LBL_KEMBALI.Text.Remove(0, 4)), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        BarisBaru(1)
        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)

        e.Graphics.DrawString("Barang yang sudah dibeli", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString("tidak dapat ditukar/dikembalikan", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString("TERIMA KASIH", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)

        BarisBaru(1)
        pageNumber = 1
        countBarang = 0
    End Sub

    Sub PRINT_NOTA()
        Dim ps As New PrinterSettings
        PRINTNOTA.OriginAtMargins = False
        PRINTNOTA.PrinterSettings = ps
        PRINTNOTA.PrinterSettings.PrinterName = PRINTER_NOTA
        Dim total
        total = tinggiKertas + (BarisBaru(DGHISTORY.Rows.Count * 2))
        PRINTNOTA.DefaultPageSettings.PaperSize = New PaperSize("Custom", lebarKertas, total)

        PRINTNOTA.DefaultPageSettings.Landscape = False
        PRINTNOTA.DocumentName = "Stroke"
        'Dim PPD As New PrintPreviewDialog
        'PPD.Document = PRINTNOTA
        'PPD.ShowDialog()
        PRINTNOTA.Print()
    End Sub

    Private Sub BTNPRINT_Click(sender As Object, e As EventArgs) Handles BTNPRINT.Click
        PRINT_NOTA()
    End Sub
End Class