Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class FR_KELUAR
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub BTNMIN_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Function CARI_HARGA(ByVal QTY As Long) As Long
        Dim STR As String = "SELECT * FROM tbl_barang" &
            " WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            Dim END1 As Long = CLng(RD.Item("End1"))
            Dim END2 As Long = CLng(RD.Item("End2"))
            Dim END3 As Long = CLng(RD.Item("End3"))
            Dim END4 As Long = CLng(RD.Item("End4"))

            Dim HARGA1 As Long = CLng(RD.Item("Harga1"))
            Dim HARGA2 As Long = CLng(RD.Item("Harga2"))
            Dim HARGA3 As Long = CLng(RD.Item("Harga3"))
            Dim HARGA4 As Long = CLng(RD.Item("Harga4"))
            Dim HARGA5 As Long = CLng(RD.Item("Harga5"))

            If Not QTY = 0 Then
                If Not END1 = 0 Then
                    If Not END2 = 0 Then
                        If Not END3 = 0 Then
                            If Not END4 = 0 Then
                                If QTY <= END1 Then
                                    CARI_HARGA = HARGA1
                                ElseIf QTY <= END2 And QTY > END1 Then
                                    CARI_HARGA = HARGA2
                                ElseIf QTY <= END3 And QTY > END2 Then
                                    CARI_HARGA = HARGA3
                                ElseIf QTY <= END4 And QTY > END3 Then
                                    CARI_HARGA = HARGA4
                                Else
                                    CARI_HARGA = HARGA5
                                End If
                            Else
                                If QTY <= END1 Then
                                    CARI_HARGA = HARGA1
                                ElseIf QTY <= END2 And QTY > END1 Then
                                    CARI_HARGA = HARGA2
                                ElseIf QTY <= END3 And QTY > END2 Then
                                    CARI_HARGA = HARGA3
                                Else
                                    CARI_HARGA = HARGA4
                                End If
                            End If
                        Else
                            If QTY <= END1 Then
                                CARI_HARGA = HARGA1
                            ElseIf QTY <= END2 And QTY > END1 Then
                                CARI_HARGA = HARGA2
                            Else
                                CARI_HARGA = HARGA3
                            End If
                        End If
                    Else
                        If QTY <= END1 Then
                            CARI_HARGA = HARGA1
                        Else
                            CARI_HARGA = HARGA2
                        End If
                    End If
                Else
                    CARI_HARGA = HARGA1
                End If
            Else
                CARI_HARGA = 0
            End If
            RD.Close()
        Else
            RD.Close()
        End If
    End Function

    Sub MASUK_DATA()
        Dim ADA_DATA As Boolean = False
        Dim BARIS_DATA As Integer = 0

        For N = 0 To DGTAMPIL.Rows.Count - 1
            Dim Kode As String = DGTAMPIL.Item("Kode", N).Value
            If Kode = TXTKODE.Text Then
                ADA_DATA = True
                BARIS_DATA = N
                Exit For
            End If
        Next

        If ADA_DATA = True Then
            DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value = DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value + Convert.ToDouble(TXTQTY.Text)
            Dim JUMLAH_QTY As Double = DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value
            DGTAMPIL.Rows(BARIS_DATA).Cells("Harga").Value = CARI_HARGA(JUMLAH_QTY)
            DGTAMPIL.Rows(BARIS_DATA).Cells("Diskon").Value = (CInt(TXTDISKON.Text) / 100 * DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Harga").Value) * DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Qty").Value
            DGTAMPIL.Rows(BARIS_DATA).Cells("Total").Value = (DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value * DGTAMPIL.Rows(BARIS_DATA).Cells("Harga").Value) - DGTAMPIL.Rows(BARIS_DATA).Cells("Diskon").Value
        Else
            DGTAMPIL.Rows.Add()
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Kode").Value = TXTKODE.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Barang").Value = TXTBARANG.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Satuan").Value = TXTSATUAN.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Harga").Value = TXTHARGA.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Diskon").Value = CInt(TXTDISKON.Text) / 100 * DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Harga").Value
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Qty").Value = TXTQTY.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Total").Value = TXTHARGA.Text - DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Diskon").Value
        End If

        TOTAL_HARGA()
    End Sub

    Private Function CARI_STOK(ByVal Kode As String) As Double
        CARI_STOK = 0
        Dim STR As String

        STR = "SELECT Kode, RTRIM(Barang) as Barang, RTRIM(Satuan) as Satuan," &
                "(SELECT COALESCE(SUM(Stok),0) FROM tbl_transaksi_child WHERE Kode=tbl_barang.Kode And (LEFT(Id_trans,1)='M' or LEFT(Id_trans,1)='R' )) as Stok" &
                " From tbl_barang WHERE kode='" & Kode & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader

        Dim STOK_DATA As Double = 0
        If RD.HasRows Then
            RD.Read()
            STOK_DATA = RD.Item("Stok")
            RD.Close()
        Else
            RD.Close()
            STOK_DATA = 0
        End If

        Dim STOK_ORDER As Double = Convert.ToDouble(TXTQTY.Text)
        For N = 0 To DGTAMPIL.RowCount - 1
            If DGTAMPIL.Item("Kode", N).Value = Kode Then
                STOK_ORDER = STOK_ORDER + DGTAMPIL.Item("QTY", N).Value
                Exit For
            End If
        Next

        CARI_STOK = STOK_DATA - STOK_ORDER
    End Function

    Sub TOTAL_HARGA()
        Dim TOT_HARGA As Integer = 0
        For N = 0 To DGTAMPIL.Rows.Count - 1
            TOT_HARGA = TOT_HARGA + DGTAMPIL.Item("Total", N).Value
        Next

        TXTSUBTOTAL.Text = TOT_HARGA

        If Not LBTOTAL.Text = 0 Then
            TXTBAYAR.Enabled = True
        Else
            TXTBAYAR.Enabled = False
        End If
    End Sub

    Private Sub FR_KELUAR_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TXTKODE.Select()
            Case Keys.F2
                TXTBAYAR.Select()
        End Select
    End Sub

    Private Sub TXTTUNAI_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            If CInt(TXTKEMBALIAN.Text) >= 0 Then
                INPUT_DB()
            Else
                MsgBox("Pembayaran Kurang!")
            End If
        End If
    End Sub

    Private Sub DGTAMPIL_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGTAMPIL.CellMouseClick
        On Error Resume Next
        TXTKODE.Enabled = False
        TXTQTY.Enabled = True

        TXTKODE.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Kode").Value
        TXTHARGA.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Harga").Value
        TXTQTY.Text = DGTAMPIL.Rows(e.RowIndex).Cells("QTY").Value
        TXTTOTAL.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Total").Value

        BTNCANCEL.Visible = True
        BTNCARI.Visible = False
        TXTQTY.Select()
    End Sub

    Private Sub FR_KELUAR_Load(sender As Object, e As EventArgs) Handles Me.Load

        TXTKODE.Select()
        TXTKASIR.Text = NAMA_LOGIN
        TXTPEMBELI.Text = "USER"
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")

        PEWAKTU.Enabled = True
    End Sub

    Dim ID_TRANSAKSI As String
    Sub INPUT_DB()
        If DGTAMPIL.Rows.Count <= 0 Then Exit Sub
        Dim SUBTOTAL As Integer = TXTSUBTOTAL.Text
        Dim DISKON As Integer = TXTDISKON_RUPIAH.Text
        Dim HARGA_AKHIR As Integer = TXTTOTALHARGA.Text
        Dim BAYAR As Integer = TXTBAYAR.Text
        Dim KEMBALIAN As Integer = TXTKEMBALIAN.Text
        ID_TRANSAKSI = AUTOID()
        Dim JUMLAH_ITEM As Double = 0
        For Each EROW As DataGridViewRow In DGTAMPIL.Rows
            JUMLAH_ITEM += Convert.ToDouble(EROW.Cells("QTY").Value)
        Next

        Dim STR As String = "INSERT INTO tbl_transaksi_parent" &
            " (Id_trans, Id_kasir, Tgl, Jenis, Person, Harga, Diskon, Jumlah_item, Harga_total, Harga_tunai, Harga_kembali)" &
            " VALUES('" & ID_TRANSAKSI & "'," &
            " '" & My.Settings.ID_ACCOUNT & "'," &
            " '" & Format(Date.Now, "MM/dd/yyyy HH:mm:ss") & "'," &
            " 'K'," &
            " '" & TXTPEMBELI.Text & "'," &
            " '" & SUBTOTAL & "'," &
            " '" & DISKON & "'," &
            " " & JUMLAH_ITEM.ToString.Replace(",", ".") & "," &
            " '" & HARGA_AKHIR & "'," &
            " '" & BAYAR & "'," &
            " '" & KEMBALIAN & "')"
        Dim CMD As New SqlCommand(STR, CONN)
        CMD.ExecuteNonQuery()

        For Each EROW As DataGridViewRow In DGTAMPIL.Rows
            Dim KODE_PRODUK As String = EROW.Cells("Kode").Value
            Dim JUMLAH_PRODUK As Double = EROW.Cells("QTY").Value
            Dim HARGA_PRODUK As Integer = EROW.Cells("Harga").Value * JUMLAH_PRODUK
            Dim DISKON_PRODUK As Integer = EROW.Cells("Diskon").Value
            Dim HARGA_AKHIR_PRODUK As Integer = HARGA_PRODUK - DISKON_PRODUK
            Dim HARGA_BELI_PRODUK As Integer = 0

            HARGA_BELI_PRODUK = CARI_HARGA_BELI(KODE_PRODUK, JUMLAH_PRODUK)

            STR = "INSERT INTO tbl_transaksi_child (Id_trans, Kode, Jumlah, Harga_beli, Harga, Diskon, Harga_akhir) VALUES" &
                    " ('" & ID_TRANSAKSI & "'," &
                    " '" & KODE_PRODUK & "'," &
                    " " & JUMLAH_PRODUK.ToString.Replace(",", ".") & "," &
                    " '" & HARGA_BELI_PRODUK & "'," &
                    " '" & HARGA_PRODUK & "'," &
                    " '" & DISKON_PRODUK & "'," &
                    " '" & HARGA_AKHIR_PRODUK & "')"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
        Next
    End Sub

    Private Function CARI_HARGA_BELI(ByVal KODE As String, ByVal QTY As Double) As Integer
        Dim ID_TRANS As String = ""
        Dim HARGA_BELI As Integer = 0
        Dim QUANTITY As Double = QTY
        While QUANTITY <> 0
            Dim STR As String = "SELECT TOP 1 (Id_trans) AS Id_trans, Harga, Stok FROM tbl_transaksi_child WHERE LEFT(Id_trans,1)='M' AND Kode='" & KODE & "' AND Stok != 0 ORDER BY Id ASC"
            Dim CMD As SqlCommand
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Read()
                ID_TRANS = RD.Item("Id_trans")
                Dim STOKTERSEDIA As Double = RD.Item("Stok")
                If STOKTERSEDIA < QUANTITY Then
                    Dim STOK_AKHIR As Double = 0
                    QUANTITY -= STOKTERSEDIA
                    HARGA_BELI += RD.Item("Harga") * STOKTERSEDIA
                    RD.Close()
                    STR = "UPDATE tbl_transaksi_child SET Stok='" & STOK_AKHIR & "' WHERE Id_trans='" & ID_TRANS & "'"
                    CMD = New SqlCommand(STR, CONN)
                    CMD.ExecuteNonQuery()
                Else
                    Dim STOK_AKHIR As Double = STOKTERSEDIA - QUANTITY
                    HARGA_BELI += (RD.Item("Harga") * QUANTITY)
                    QUANTITY = 0
                    RD.Close()
                    STR = "UPDATE tbl_transaksi_child SET Stok=" & STOK_AKHIR.ToString.Replace(",", ".") & " WHERE Id_trans='" & ID_TRANS & "'"
                    CMD = New SqlCommand(STR, CONN)
                    CMD.ExecuteNonQuery()
                End If
                RD.Close()
            End If
        End While
        Return HARGA_BELI
    End Function

    Private Function AUTOID() As String
        Dim ID_AWAL As String = Format(Date.Now, "yyMMdd")
        Dim STR As String = "SELECT TOP 1 (Id_trans) AS Id_trans FROM tbl_transaksi_parent WHERE LEFT(Id_trans,1)='K' ORDER BY Id DESC"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            If Mid(RD.Item("Id_trans"), 2, 6) = ID_AWAL Then
                Dim ID As Integer = Mid(RD.Item("Id_trans"), 8, 3) + 1
                RD.Close()
                AUTOID = "K" + ID_AWAL + Format(ID, "000")
            Else
                RD.Close()
                AUTOID = "K" + ID_AWAL + Format(1, "000")
            End If
        Else
            RD.Close()
            AUTOID = "K" + ID_AWAL + Format(1, "000")
        End If
        RD.Close()
    End Function

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        Dim FR As New FR_MENU
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub TXTDISKON_PERSEN_TextChanged(sender As Object, e As EventArgs) Handles TXTDISKON_PERSEN.TextChanged
        HITUNGDISKON_RUPIAH()
    End Sub

    Sub HITUNGDISKON_RUPIAH()
        Dim SUBTOTAL As Integer = 0
        Dim DISKON As Integer = 0
        If Not TXTSUBTOTAL.Text = "" Then
            SUBTOTAL = CInt(TXTSUBTOTAL.Text)
        End If
        If Not TXTDISKON_PERSEN.Text = "" Then
            DISKON = CInt(TXTDISKON_PERSEN.Text)
        End If

        TXTDISKON_RUPIAH.Text = SUBTOTAL * DISKON / 100
        TXTTOTALHARGA.Text = SUBTOTAL - CInt(TXTDISKON_RUPIAH.Text)
        LBTOTAL.Text = Format(CInt(TXTTOTALHARGA.Text), "##,##0")
    End Sub

    Private Sub TXTBAYAR_TextChanged(sender As Object, e As EventArgs) Handles TXTBAYAR.TextChanged
        Dim BAYAR As Integer = 0
        If Not TXTBAYAR.Text = "" Then
            BAYAR = CInt(TXTBAYAR.Text)
        End If
        Dim TOTALHARGA As Integer = 0
        If Not TXTTOTALHARGA.Text = "" Then
            TOTALHARGA = CInt(TXTTOTALHARGA.Text)
        End If
        TXTKEMBALIAN.Text = BAYAR - TOTALHARGA
    End Sub

    Private Sub TXTBAYAR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTBAYAR.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTKEMBALIAN.Text >= "0" Then
                INPUT_DB()
                PRINT_NOTA()
                FR_KELUAR_KEMBALIAN.LBKEMBALI.Text = Format(CInt(TXTKEMBALIAN.Text), "##,##0")
                FR_KELUAR_KEMBALIAN.Show()
                FR_KELUAR_KEMBALIAN.BTNTUTUP.Select()
                Me.Enabled = False
            Else
                MsgBox("Pembayaran Kurang!")
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Sub CARI_DISKON()
        Dim TGL_SKRG As String = Format(Date.Now, "yyyy-MM-dd")

        Dim STR As String = "SELECT COALESCE(SUM(Diskon),0) AS 'Diskon' FROM tbl_diskon" &
                " WHERE Kode IS NULL" &
                " AND Min_transaksi <= '" & CInt(TXTSUBTOTAL.Text) & "'" &
                " AND Tgl_awal <= '" & TGL_SKRG & "'" &
                " And Tgl_akhir >= '" & TGL_SKRG & "'"
        Dim CMD As New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader()
        If RD.HasRows Then
            RD.Read()
            TXTDISKON_PERSEN.Text = RD.Item("Diskon")
            RD.Close()
        Else
            TXTDISKON_PERSEN.Text = 0
            RD.Close()
        End If
    End Sub

    Private Sub TXTSUBTOTAL_TextChanged(sender As Object, e As EventArgs) Handles TXTSUBTOTAL.TextChanged
        CARI_DISKON()
        HITUNGDISKON_RUPIAH()
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            Dim HARGA As Long = 0
            If TXTHARGA.Text <> "" Then
                HARGA = CLng(TXTHARGA.Text)
            End If
            Dim JUMLAH_QTY As Double = 0
            If Not TXTQTY.Text = "" Then
                JUMLAH_QTY = Convert.ToDouble(TXTQTY.Text)
            End If

            If JUMLAH_QTY = 0 Then
                Dim BARIS_DATA As Integer = 0
                For N = 0 To DGTAMPIL.Rows.Count - 1
                    Dim Kode As String = DGTAMPIL.Item("Kode", N).Value
                    If Kode = TXTKODE.Text Then
                        BARIS_DATA = N
                        Exit For
                    End If
                Next
                DGTAMPIL.Rows.RemoveAt(BARIS_DATA)
                TOTAL_HARGA()
                TXTQTY.Enabled = False
                TXTKODE.Enabled = True
                TXTKODE.Clear()
                TXTKODE.Select()
            Else
                Dim QTY As Double = Convert.ToDouble(TXTQTY.Text)
                Dim BARIS_DATA As Integer = 0
                For N = 0 To DGTAMPIL.Rows.Count - 1
                    Dim Kode As String = DGTAMPIL.Item("Kode", N).Value
                    If Kode = TXTKODE.Text Then
                        BARIS_DATA = N
                        Exit For
                    End If
                Next
                TXTQTY.Text = Convert.ToDouble(TXTQTY.Text) - DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value

                If CARI_STOK(TXTKODE.Text) < 0 Then
                    TXTQTY.Text = QTY
                    MsgBox("Stok barang tidak mencukupi!")
                    TXTQTY.Select()
                Else
                    MASUK_DATA()
                    TXTKODE.Enabled = True
                    TXTQTY.Text = QTY
                    TXTQTY.Enabled = False
                    BTNCARI.Visible = True
                    BTNCANCEL.Visible = False
                    TXTKODE.Clear()
                    TXTKODE.Select()
                End If
            End If
        End If
    End Sub

    Private Sub TXTQTY_TextChanged(sender As Object, e As EventArgs) Handles TXTQTY.TextChanged
        Dim HARGA As Long = 0
        If Not TXTHARGA.Text = "" Then
            HARGA = CLng(TXTHARGA.Text)
        End If
        Dim JUMLAH_QTY As Double = 0
        If Not TXTQTY.Text = "" Then
            JUMLAH_QTY = Convert.ToDouble(TXTQTY.Text)
        End If
        TXTHARGA.Text = CARI_HARGA(JUMLAH_QTY)
        HARGA = CLng(TXTHARGA.Text)
        TXTTOTAL.Text = HARGA * JUMLAH_QTY * (100 - CInt(TXTDISKON.Text)) / 100
    End Sub

    Private Sub TXTKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTQTY.Text = 1
            Dim JUMLAH_QTY As Integer = 0
            If Not TXTQTY.Text = "" Then
                JUMLAH_QTY = CInt(TXTQTY.Text)
            End If

            TXTHARGA.Text = CARI_HARGA(JUMLAH_QTY)
            If CARI_STOK(TXTKODE.Text) < 0 Then
                MsgBox("Stok barang tidak mencukupi!")
                TXTKODE.Clear()
            Else
                MASUK_DATA()
                TXTKODE.Clear()
                TXTKODE.Select()
            End If
        End If

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z, a-z]" _
            OrElse e.KeyChar Like "[0-9]" _
            OrElse KeyAscii = Keys.Back) Then
            KeyAscii = 0
        End If

        e.Handled = CBool(KeyAscii)
    End Sub

    Sub CARI_DATA()
        Dim TGL_SKRG As String = Format(Date.Now, "yyyy-MM-dd")

        Dim STR As String = "SELECT Barang, Satuan FROM tbl_barang" &
            " WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTBARANG.Text = RD.Item("Barang").ToString.Trim
            TXTSATUAN.Text = RD.Item("Satuan").ToString.Trim
            RD.Close()
            STR = "SELECT COALESCE(SUM(Diskon),0) AS 'Diskon' FROM tbl_diskon" &
                " WHERE Kode='" & TXTKODE.Text & "'" &
                " AND Tgl_awal <= '" & TGL_SKRG & "'" &
                " And Tgl_akhir >= '" & TGL_SKRG & "'"
            CMD = New SqlCommand(STR, CONN)
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Read()
                TXTDISKON.Text = RD.Item("Diskon")
                RD.Close()
            Else
                TXTDISKON.Text = 0
                RD.Close()
            End If
            TXTQTY.Text = 1
        Else
            RD.Close()
        End If
    End Sub

    Private Sub TXTKODE_TextChanged(sender As Object, e As EventArgs) Handles TXTKODE.TextChanged
        CARI_DATA()
        Dim HARGA As Integer = 0
        Dim JUMLAH_QTY As Integer = 0
        Dim DISKON As Integer = 0
        If Not TXTDISKON.Text = "" Then
            DISKON = CInt(TXTDISKON.Text)
        End If
        If Not TXTQTY.Text = "" Then
            JUMLAH_QTY = CInt(TXTQTY.Text)
        End If
        TXTHARGA.Text = CARI_HARGA(JUMLAH_QTY)
        If Not TXTHARGA.Text = "" Then
            HARGA = CInt(TXTHARGA.Text)
        End If
        TXTTOTAL.Text = HARGA * JUMLAH_QTY * (100 - DISKON) / 100
    End Sub

    Private Sub TXTKODE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTKODE.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                FR_KELUAR_TAMPIL.Show()
                Me.Enabled = False
        End Select
    End Sub

    Private Sub BTNCARI_Click(sender As Object, e As EventArgs) Handles BTNCARI.Click
        FR_KELUAR_TAMPIL.Show()
        Me.Enabled = False
    End Sub

    Private Sub TXTDISKON_PERSEN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTDISKON_PERSEN.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
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

    Private Function BarisBaru(jumlah_baris)
        totalBaris += jumlah_baris
        Return totalBaris * jarakBaris
    End Function

    Private Function BarisYangSama()
        Return BarisBaru(0)
    End Function

    Private Sub PRINTNOTA_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PRINTNOTA.PrintPage
        Dim textCenter, textLeft, textRight As New StringFormat
        textCenter.Alignment = StringAlignment.Center
        textLeft.Alignment = StringAlignment.Near
        textRight.Alignment = StringAlignment.Far

        e.Graphics.DrawString(NAMA_TOKO, fontJudul, Brushes.Black, lebarKertas / 2, BarisYangSama, textCenter)
        e.Graphics.DrawString(ALAMAT_TOKO, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString(NO_TOKO, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        BarisBaru(1)

        e.Graphics.DrawString(LBTGL.Text, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)

        e.Graphics.DrawString(ID_TRANSAKSI, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)
        e.Graphics.DrawString("Kasir : " & TXTKASIR.Text, fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)

        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisBaru(1), (lebarKertas - marginRight), BarisYangSama)
        BarisBaru(1)

        For Each EROW As DataGridViewRow In DGTAMPIL.Rows
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
        If CInt(TXTDISKON_RUPIAH.Text) = 0 Then
            e.Graphics.DrawString("Subtotal", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
            e.Graphics.DrawString(Format(CInt(TXTSUBTOTAL.Text), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
        Else
            e.Graphics.DrawString("Subtotal", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
            e.Graphics.DrawString(Format(CInt(TXTSUBTOTAL.Text), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

            e.Graphics.DrawString("Diskon", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
            e.Graphics.DrawString(Format(CInt(TXTDISKON_RUPIAH.Text), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
        End If

        BarisBaru(1)
        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)

        e.Graphics.DrawString("Total", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
        e.Graphics.DrawString(Format(CInt(TXTTOTALHARGA.Text), "Rp ##,##0"), fontTotal, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        e.Graphics.DrawString("Tunai", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
        e.Graphics.DrawString(Format(CInt(TXTBAYAR.Text), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        e.Graphics.DrawString("Kembali", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
        e.Graphics.DrawString(Format(CInt(TXTKEMBALIAN.Text), "Rp ##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

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
        PRINTNOTA.DefaultPageSettings.PaperSize = New PaperSize("Custom", lebarKertas, tinggiKertas + BarisBaru(DGTAMPIL.Rows.Count))
        PRINTNOTA.DefaultPageSettings.Landscape = False
        PRINTNOTA.DocumentName = "Stroke"
        PRINTNOTA.Print()
    End Sub

    Private Sub BTNCANCEL_Click(sender As Object, e As EventArgs) Handles BTNCANCEL.Click
        TXTKODE.Enabled = True
        TXTQTY.Enabled = False
        BTNCARI.Visible = True
        BTNCANCEL.Visible = False
        TXTKODE.Clear()
        TXTKODE.Select()
    End Sub

    Private Sub TXTQTY_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTQTY.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                TXTKODE.Enabled = True
                TXTQTY.Enabled = False
                BTNCARI.Visible = True
                BTNCANCEL.Visible = False
                TXTKODE.Clear()
                TXTKODE.Select()
        End Select
    End Sub

    Private Sub TXTTOTALHARGA_TextChanged(sender As Object, e As EventArgs) Handles TXTTOTALHARGA.TextChanged
        LBTOTAL.Text = Format(CInt(TXTTOTALHARGA.Text), "##,##0")
    End Sub
End Class