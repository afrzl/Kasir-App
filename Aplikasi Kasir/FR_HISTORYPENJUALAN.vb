Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO

Public Class FR_HISTORYPENJUALAN
    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 20

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Hide()
    End Sub

    Sub TAMPIL()
        Dim STR As String = ""
        If TXTCARI.Text = "" Then
            STR = "SELECT" &
            " RTRIM(tbl_transaksi_parent.Id_trans) AS 'Id Transaksi'," &
            " RTRIM(tbl_karyawan.Nama) AS 'Nama Kasir'," &
            " tbl_transaksi_parent.Tgl AS 'Tanggal Transaksi'" &
            " FROM tbl_transaksi_parent" &
            " INNER JOIN tbl_karyawan ON tbl_transaksi_parent.Id_kasir = tbl_karyawan.Id" &
            " WHERE Left(tbl_transaksi_parent.Id_trans, 1) = 'K'" &
            " AND Tgl >= DATEADD(day,-20, GETDATE())" &
            " ORDER BY Tgl DESC" &
            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
        Else
            STR = "SELECT" &
            " RTRIM(tbl_transaksi_parent.Id_trans) AS 'Id Transaksi'," &
            " RTRIM(tbl_karyawan.Nama) AS 'Nama Kasir'," &
            " tbl_transaksi_parent.Tgl AS 'Tanggal Transaksi'" &
            " FROM tbl_transaksi_parent" &
            " INNER JOIN tbl_karyawan ON tbl_transaksi_parent.Id_kasir = tbl_karyawan.Id" &
            " WHERE Left(tbl_transaksi_parent.Id_trans, 1) = 'K'" &
            " AND Tgl >= DATEADD(day,-20, GETDATE())" &
            " AND tbl_transaksi_parent.Id_trans = '" & TXTCARI.Text & "'" &
            " ORDER BY Tgl DESC" &
            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
        End If

        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL)
        DGHISTORY.DataSource = TBL.Tables(0)

        DGHISTORY.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGHISTORY.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGHISTORY.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        BTNPREV.Enabled = True
        BTNNEXT.Enabled = True

        If START_RECORD = 0 Then
            BTNPREV.Enabled = False
        Else
            BTNPREV.Enabled = True
        End If
    End Sub

    Private Sub FR_HISTORYPENJUALAN_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case ROLE
            Case 1
                PNADMIN.Visible = True
                PNKASIR.Visible = False
                PNOPS.Visible = False
                Label3.Text = "Administrator"
            Case 2
                PNADMIN.Visible = False
                PNKASIR.Visible = False
                PNOPS.Visible = True
                Label3.Text = "Operator"
            Case 3
                PNADMIN.Visible = False
                PNKASIR.Visible = True
                PNOPS.Visible = False
                Label3.Text = "Kasir"
        End Select

        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True

        LBLUSER.Text = NAMA_LOGIN
        TAMPIL()
        TXTCARI.Select()
    End Sub

    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
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

    Private Sub BTNKASIR_Click(sender As Object, e As EventArgs) Handles BTNKASIR.Click
        BUKA_FORM(FR_KASIR)
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

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNNEXT_Click(sender As Object, e As EventArgs) Handles BTNNEXT.Click
        START_RECORD += TAMPIL_RECORD
        TAMPIL()
    End Sub

    Private Sub BTNPREV_Click(sender As Object, e As EventArgs) Handles BTNPREV.Click
        START_RECORD -= TAMPIL_RECORD
        TAMPIL()
    End Sub

    'PRINTING
    '=================================================================================
    'KERTAS 
    Dim transaksi As New DataSet

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

        Dim IMAGE As Image = Image.FromStream(IMAGESTREAM)
        Dim MyBitmap As New Bitmap(IMAGE)
        e.Graphics.DrawImage(MyBitmap, JARAK, BarisYangSama(), WIDTH, HEIGHT)

        e.Graphics.DrawString(NAMA_TOKO, fontJudul, Brushes.Black, lebarKertas / 2, BarisBaru(HEIGHT / jarakBaris), textCenter)
        e.Graphics.DrawString(ALAMAT_TOKO, fontRegular, Brushes.Black, New Rectangle(20, BarisBaru(1), lebarKertas - 30, BarisYangSama), textCenter)
        e.Graphics.DrawString(NO_TOKO, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        BarisBaru(1)

        e.Graphics.DrawString(DGHISTORY.SelectedCells(2).Value, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)

        e.Graphics.DrawString(DGHISTORY.SelectedCells(0).Value, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)
        e.Graphics.DrawString("Kasir : " & DGHISTORY.SelectedCells(1).Value, fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)

        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisBaru(1), (lebarKertas - marginRight), BarisYangSama)

        For row As Integer = 0 To transaksi.Tables(0).Rows.Count - 1
            If row >= countBarang And countBarang < transaksi.Tables(0).Rows.Count Then
                e.Graphics.DrawString(transaksi.Tables(0).Rows(row).Item("Barang"), fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
                If CInt(transaksi.Tables(0).Rows(row).Item("Diskon Barang")) = 0 Then
                    e.Graphics.DrawString(Convert.ToDouble(transaksi.Tables(0).Rows(row).Item("Jumlah")) & " " & transaksi.Tables(0).Rows(row).Item("Satuan") & " x " & Format(CInt(transaksi.Tables(0).Rows(row).Item("Harga Awal")), "##,##0"), fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
                Else
                    e.Graphics.DrawString(Convert.ToDouble(transaksi.Tables(0).Rows(row).Item("Jumlah")) & " " & transaksi.Tables(0).Rows(row).Item("Satuan") & " x " & Format(CInt(transaksi.Tables(0).Rows(row).Item("Harga Awal")), "##,##0") & " (Disc. " & Format(CInt(transaksi.Tables(0).Rows(row).Item("Diskon Barang")), "##,##0") & ")", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
                End If
                e.Graphics.DrawString(Format(CInt(transaksi.Tables(0).Rows(row).Item("Harga Akhir")), "##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
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
        If CInt(transaksi.Tables(0).Rows(0).Item("Diskon Trans")) = 0 Then
            e.Graphics.DrawString("Subtotal", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
            e.Graphics.DrawString(Format(CInt(transaksi.Tables(0).Rows(0).Item("Harga Trans")), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
        Else
            e.Graphics.DrawString("Subtotal", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
            e.Graphics.DrawString(Format(CInt(transaksi.Tables(0).Rows(0).Item("Harga Trans")), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

            e.Graphics.DrawString("Diskon", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
            e.Graphics.DrawString(Format(CInt(transaksi.Tables(0).Rows(0).Item("Diskon Trans")), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
        End If

        BarisBaru(1)
        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)

        e.Graphics.DrawString("Total", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
        e.Graphics.DrawString(Format(CInt(transaksi.Tables(0).Rows(0).Item("Harga Total")), "Rp ##,##0"), fontTotal, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        e.Graphics.DrawString("Tunai", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
        e.Graphics.DrawString(Format(CInt(transaksi.Tables(0).Rows(0).Item("Bayar")), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        e.Graphics.DrawString("Kembali", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
        e.Graphics.DrawString(Format(CInt(transaksi.Tables(0).Rows(0).Item("Kembali")), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        BarisBaru(1)
        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)

        e.Graphics.DrawString("Barang yang sudah dibeli", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString("tidak dapat ditukar/dikembalikan", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString("TERIMA KASIH", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)

        BarisBaru(1)
    End Sub

    Sub PRINT_NOTA()
        Dim ps As New PrinterSettings
        PRINTNOTA.OriginAtMargins = False
        PRINTNOTA.PrinterSettings = ps
        PRINTNOTA.PrinterSettings.PrinterName = PRINTER_NOTA
        Dim total
        total = tinggiKertas + (BarisBaru(transaksi.Tables(0).Rows.Count * 2))
        PRINTNOTA.DefaultPageSettings.PaperSize = New PaperSize("Custom", lebarKertas, total)

        PRINTNOTA.DefaultPageSettings.Landscape = False
        PRINTNOTA.DocumentName = "Stroke"
        'Dim PPD As New PrintPreviewDialog
        'PPD.Document = PRINTNOTA
        'PPD.ShowDialog()
        PRINTNOTA.Print()
    End Sub

    Private Sub BTNPRINT_Click(sender As Object, e As EventArgs) Handles BTNPRINT.Click
        Dim STR As String = "SELECT" &
            " RTRIM(tbl_barang.Barang) AS 'Barang'," &
            " RTRIM(tbl_barang.Satuan) AS 'Satuan'," &
            " tbl_transaksi_child.Jumlah AS 'Jumlah'," &
            " tbl_transaksi_child.Harga/tbl_transaksi_child.Jumlah AS 'Harga Awal'," &
            " tbl_transaksi_child.Harga_akhir AS 'Harga Akhir'," &
            " tbl_transaksi_child.Diskon AS 'Diskon Barang'," &
            " tbl_transaksi_parent.Harga AS 'Harga Trans'," &
            " tbl_transaksi_parent.Harga_total AS 'Harga Total'," &
            " tbl_transaksi_parent.Diskon AS 'Diskon Trans'," &
            " tbl_transaksi_parent.Harga_tunai AS 'Bayar'," &
            " tbl_transaksi_parent.Harga_kembali AS 'Kembali'" &
            " FROM tbl_transaksi_child" &
            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans = tbl_transaksi_parent.Id_trans" &
            " INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
            " WHERE tbl_transaksi_child.Id_trans = '" & DGHISTORY.SelectedCells(0).Value & "'"

        transaksi.Clear()
        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(transaksi)

        PRINT_NOTA()
    End Sub

    Private Sub TXTCARI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        ElseIf e.KeyChar = Chr(13) Then
            START_RECORD = 0
            TAMPIL()
        End If
    End Sub

    Private Sub TXTCARI_Leave(sender As Object, e As EventArgs) Handles TXTCARI.Leave
        START_RECORD = 0
        TAMPIL()
    End Sub

    Private Sub BTNDASHBOARDOPS_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDOPS.Click
        BUKA_FORM(FR_OPS_DASHBOARD)
    End Sub

    Private Sub BTNBARANGOPS_Click(sender As Object, e As EventArgs) Handles BTNBARANGOPS.Click
        BUKA_FORM(FR_PRODUK)
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

    Private Sub BTNDASHBOARDKASIR_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDKASIR.Click
        BUKA_FORM(FR_KASIR_DASHBOARD)
    End Sub

    Private Sub BTNLABELKASIR_Click(sender As Object, e As EventArgs) Handles BTNLABELKASIR.Click
        BUKA_FORM(FR_CETAK_LABEL)
    End Sub

    Private Sub BTNKELUARKASIR_Click(sender As Object, e As EventArgs) Handles BTNKELUARKASIR.Click
        BUKA_FORM(FR_KELUAR)
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
End Class
