Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text

Public Class FR_VOUCHER_ACTION

    Dim CMD As MySqlCommand
    Dim RD As MySqlDataReader
    Dim DA As MySqlDataAdapter
    Dim STR As String

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        FR_VOUCHER.Enabled = True
        Me.Close()
    End Sub

    Private Sub FR_VOUCHER_ACTION_Load(sender As Object, e As EventArgs) Handles Me.Load

        STR = "SELECT Id," &
            " RTRIM(Jenis) AS Jenis," &
            " RTRIM(Nama) AS Nama" &
            " FROM tbl_data_voucher" &
            " ORDER BY Nama ASC"
        Dim TBL As New DataTable
        DA = New MySqlDataAdapter(STR, CONN)
        DA.Fill(TBL)

        If TBL.Rows.Count > 0 Then
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add("", "-- Silahkan pilih jenis voucher --")
            For Each i As DataRow In TBL.Rows
                comboSource.Add(i.Item("Id"), i.Item("Nama"))
            Next
            With CB_DATA
                .DataSource = New BindingSource(comboSource, Nothing)
                .DisplayMember = "Value"
                .ValueMember = "Key"
                .SelectedIndex = 0
                .Select()
            End With
        End If
    End Sub

    Sub CARI_HARGA()
        STR = "SELECT Id," &
            " Harga AS Harga" &
            " FROM tbl_data_voucher" &
            " WHERE Id = '" & CB_DATA.SelectedValue & "'"
        CMD = New MySqlCommand(STR, CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            LBL_HARGA.Text = ": " & Format(RD.Item("Harga"), "##,##0")
            RD.Close()
        Else
            RD.Close()
        End If
    End Sub

    Private Sub CB_DATA_SelectedValueChanged(sender As Object, e As EventArgs) Handles CB_DATA.SelectedValueChanged
        On Error Resume Next

        If CB_DATA.SelectedIndex > 0 Then
            CARI_HARGA()
        Else
            LBL_HARGA.Text = ": "
        End If
    End Sub

    Private Sub CB_DATA_TextChanged(sender As Object, e As EventArgs) Handles CB_DATA.TextChanged
        On Error Resume Next

        If CB_DATA.SelectedIndex > 0 Then
            CARI_HARGA()
        Else
            LBL_HARGA.Text = ": "
        End If
    End Sub

    Private Sub TXTNAMA_Validated(sender As Object, e As EventArgs) Handles TXTID_MEMBER.Validated
        STR = "SELECT Id," &
            " RTRIM(Nama) AS Nama," &
            " Points AS Points" &
            " FROM tbl_member" &
            " WHERE Id = '" & TXTID_MEMBER.Text & "'"
        CMD = New MySqlCommand(STR, CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            LBL_NAMA_MEMBER.Text = ": " & RD.Item("Nama")
            LBL_POINT_MEMBER.Text = ": " & Format(RD.Item("Points"), "##,##0")
            RD.Close()
        Else
            LBL_NAMA_MEMBER.Text = ": "
            LBL_POINT_MEMBER.Text = ": "
            RD.Close()
        End If
    End Sub

    Dim Kode

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If CB_DATA.SelectedIndex < 1 Or TXTID_MEMBER.Text = "" Then
            MsgBox("Data tidak lengkap!")
            CB_DATA.Select()
        ElseIf LBL_NAMA_MEMBER.Text.Remove(0, 2) = "" Then
            MsgBox("Member tidak ditemukan!")
            TXTID_MEMBER.Select()
        Else
            If LBL_POINT_MEMBER.Text.Remove(0, 2) - LBL_HARGA.Text.Remove(0, 2) < 0 Then
                MsgBox("Point member tidak cukup!")
                TXTID_MEMBER.Select()
            Else
                STR = "UPDATE tbl_member SET Points-='" & LBL_HARGA.Text.Remove(0, 2) & "', " &
                    " Modified_at = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                    " WHERE Id='" & TXTID_MEMBER.Text & "'"
                CMD = New MySqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()

                Dim validchars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"

                Dim sb As New StringBuilder()
                Dim rand As New Random()
                For j As Integer = 0 To 1 Step 0
                    For i As Integer = 1 To 10
                        Dim idx As Integer = rand.Next(0, validchars.Length)
                        Dim randomChar As Char = validchars(idx)
                        sb.Append(randomChar)
                    Next i
                    STR = "SELECT Id" &
                            " FROM tbl_transaksi_voucher" &
                            " WHERE Kode = '" & sb.ToString & "'"
                    CMD = New MySqlCommand(STR, CONN)
                    RD = CMD.ExecuteReader
                    RD.Read()
                    If RD.HasRows Then
                        RD.Close()
                    Else
                        RD.Close()
                        Exit For
                    End If
                Next

                Kode = sb.ToString()

                STR = "INSERT INTO tbl_transaksi_voucher (Id_data, Id_kasir, Id_member, Harga, Kode, Created_at) VALUES (" &
                            "'" & CB_DATA.SelectedValue & "'," &
                            "'" & My.Settings.ID_ACCOUNT & "'," &
                            "'" & TXTID_MEMBER.Text & "'," &
                            "'" & LBL_HARGA.Text.Remove(0, 2) & "'," &
                            "'" & Kode & "'," &
                            "'" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                            ")"
                CMD = New MySqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()

                MsgBox("Transaksi berhasil dilakukan.")
                PRINT_NOTA()
                With FR_VOUCHER
                    .Enabled = True
                    .TAMPIL()
                End With
                Me.Close()
            End If
        End If
    End Sub

    'PRINTING
    '=================================================================================
    'KERTAS 
    ReadOnly lebarKertas As Integer = 304 'Ukuran Kertas 78 mm
    ReadOnly tinggiKertas As Integer = 304
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
            e.Graphics.DrawImage(IMAGE, JARAK, BarisYangSama(), WIDTH, HEIGHT)

            e.Graphics.DrawString(NAMA_TOKO, fontJudul, Brushes.Black, lebarKertas / 2, BarisBaru(HEIGHT / jarakBaris), textCenter)
            e.Graphics.DrawString(ALAMAT_TOKO, fontRegular, Brushes.Black, New Rectangle(20, BarisBaru(1), lebarKertas - 30, BarisYangSama), textCenter)
            e.Graphics.DrawString(NO_TOKO, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
            BarisBaru(1)

            e.Graphics.DrawString("PENUKARAN POINTS", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
            e.Graphics.DrawString(Format(Date.Now, "dd MMMM yyyy HH:mm:ss"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)
            e.Graphics.DrawLine(Pens.Black, marginLeft, BarisBaru(1), (lebarKertas - marginRight), BarisYangSama)
        End If
        e.Graphics.DrawString(CB_DATA.Text, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString("KODE VOUCHER : ", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString(Kode, fontJudul, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        BarisBaru(1)
        e.Graphics.DrawString("ID Member : " & TXTID_MEMBER.Text, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString("Nama Member : " & LBL_NAMA_MEMBER.Text.Remove(0, 2), fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString("Point Member Sekarang : " & LBL_POINT_MEMBER.Text.Remove(0, 2) - LBL_HARGA.Text.Remove(0, 2), fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)

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
        PRINTNOTA.DefaultPageSettings.PaperSize = New PaperSize("Custom", lebarKertas, tinggiKertas)
        PRINTNOTA.DefaultPageSettings.Landscape = False
        PRINTNOTA.DocumentName = "Stroke"
        PRINTNOTA.Print()
    End Sub

    Private Sub CB_DATA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CB_DATA.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TXTID_MEMBER.Select()
        End If
    End Sub

    Private Sub TXTID_MEMBER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTID_MEMBER.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            BTNSIMPAN.Select()
        End If
    End Sub
End Class