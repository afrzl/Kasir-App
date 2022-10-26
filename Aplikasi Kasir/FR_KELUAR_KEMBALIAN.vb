Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO

Public Class FR_KELUAR_KEMBALIAN
    Private Sub BTNTUTUP_Click(sender As Object, e As EventArgs) Handles BTNTUTUP.Click
        With FR_KELUAR
            .TXTPEMBELI.Text = "USER"
            .TXTBAYAR.Text = ""
            .TXTDISKON_PERSEN.Text = 0
            .DGTAMPIL.Rows.Clear()
            .TXTKEMBALIAN.Clear()
            .TOTAL_HARGA()
            .TXTKODE.Select()

            .Enabled = True
        End With
        Me.Close()
    End Sub

    Private Sub FR_KELUAR_KEMBALIAN_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                With FR_KELUAR
                    .TXTPEMBELI.Text = "USER"
                    .TXTBAYAR.Text = ""
                    .TXTDISKON_PERSEN.Text = 0
                    .DGTAMPIL.Rows.Clear()
                    .TXTKEMBALIAN.Clear()
                    .TOTAL_HARGA()
                    .TXTKODE.Select()

                    .Enabled = True
                End With
                Me.Close()
        End Select
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
        e.Graphics.DrawString(FR_KELUAR.ALAMATTOKO.Text, fontRegular, Brushes.Black, New Rectangle(20, BarisBaru(1), lebarKertas - 30, BarisYangSama), textCenter)
        e.Graphics.DrawString(NO_TOKO, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        BarisBaru(1)

        e.Graphics.DrawString(FR_KELUAR.LBTGL.Text, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)

        e.Graphics.DrawString(ID_TRANSAKSI.Text, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)
        e.Graphics.DrawString("Kasir : " & FR_KELUAR.TXTKASIR.Text, fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)

        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisBaru(1), (lebarKertas - marginRight), BarisYangSama)

        For Each EROW As DataGridViewRow In FR_KELUAR.DGTAMPIL.Rows
            e.Graphics.DrawString(EROW.Cells("BARANG").Value, fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
            If CInt(EROW.Cells("DISKON").Value) = 0 Then
                e.Graphics.DrawString(Convert.ToDouble(EROW.Cells("QTY").Value) & " " & EROW.Cells("SATUAN").Value & " x " & Format(CInt(EROW.Cells("HARGA").Value), "##,##0"), fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
            Else
                e.Graphics.DrawString(Convert.ToDouble(EROW.Cells("QTY").Value) & " " & EROW.Cells("SATUAN").Value & " x " & Format(CInt(EROW.Cells("HARGA").Value), "##,##0") & " (Disc. " & Format(CInt(EROW.Cells("DISKON").Value), "##,##0") & ")", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
            End If
            e.Graphics.DrawString(Format(CInt(EROW.Cells("TOTAL").Value), "##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
            BarisBaru(1)
        Next

        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)
        If CInt(FR_KELUAR.TXTDISKON_RUPIAH.Text) = 0 Then
            e.Graphics.DrawString("Subtotal", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
            e.Graphics.DrawString(Format(CInt(FR_KELUAR.TXTSUBTOTAL.Text), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
        Else
            e.Graphics.DrawString("Subtotal", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
            e.Graphics.DrawString(Format(CInt(FR_KELUAR.TXTSUBTOTAL.Text), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

            e.Graphics.DrawString("Diskon", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
            e.Graphics.DrawString(Format(CInt(FR_KELUAR.TXTDISKON_RUPIAH.Text), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
        End If

        BarisBaru(1)
        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)

        e.Graphics.DrawString("Total", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
        e.Graphics.DrawString(Format(CInt(FR_KELUAR.TXTTOTALHARGA.Text), "Rp ##,##0"), fontTotal, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        e.Graphics.DrawString("Tunai", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
        e.Graphics.DrawString(Format(CInt(FR_KELUAR.TXTBAYAR.Text), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        e.Graphics.DrawString("Kembali", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
        e.Graphics.DrawString(Format(CInt(FR_KELUAR.TXTKEMBALIAN.Text), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

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
        total = tinggiKertas + (BarisBaru(FR_KELUAR.DGTAMPIL.Rows.Count * 2))
        PRINTNOTA.DefaultPageSettings.PaperSize = New PaperSize("Custom", lebarKertas, total)

        PRINTNOTA.DefaultPageSettings.Landscape = False
        PRINTNOTA.DocumentName = "Stroke"
        'Dim PPD As New PrintPreviewDialog
        'PPD.Document = PRINTNOTA
        'PPD.ShowDialog()
        PRINTNOTA.Print()
    End Sub

    Private Sub BTN_CETAKNOTA_Click(sender As Object, e As EventArgs) Handles BTN_CETAKNOTA.Click
        PRINT_NOTA()
        BTNTUTUP.Select()
    End Sub
End Class