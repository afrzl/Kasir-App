Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO

Public Class FR_KELUAR
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub BTNMIN_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Function CARI_HARGA(ByVal QTY As Double) As Long
        Dim STR As String = "SELECT * FROM tbl_barang" &
            " WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            Dim END1 As Double = RD.Item("End1")
            Dim END2 As Double = RD.Item("End2")
            Dim END3 As Double = RD.Item("End3")
            Dim END4 As Double = RD.Item("End4")

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
            If Label6.Text = "%" Then
                DGTAMPIL.Rows(BARIS_DATA).Cells("Diskon").Value = CInt((TXTDISKON.Text / 100 * DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Harga").Value) * DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Qty").Value)
            ElseIf Label6.Text = "Rp" Then
                DGTAMPIL.Rows(BARIS_DATA).Cells("Diskon").Value = CInt(TXTDISKON.Text * DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Qty").Value)
            End If
            DGTAMPIL.Rows(BARIS_DATA).Cells("Total").Value = CInt((DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value * DGTAMPIL.Rows(BARIS_DATA).Cells("Harga").Value) - DGTAMPIL.Rows(BARIS_DATA).Cells("Diskon").Value)
        Else
            DGTAMPIL.Rows.Add()
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Kode").Value = TXTKODE.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Barang").Value = TXTBARANG.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Satuan").Value = TXTSATUAN.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Harga").Value = CARI_HARGA(TXTQTY.Text)
            If Label6.Text = "%" Then
                DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Diskon").Value = CInt((TXTDISKON.Text / 100 * DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Harga").Value) * TXTQTY.Text)
            ElseIf Label6.Text = "Rp" Then
                DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Diskon").Value = CInt(TXTDISKON.Text * TXTQTY.Text)
            End If
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Qty").Value = TXTQTY.Text
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("Total").Value = TXTTOTAL.Text
        End If

        TOTAL_HARGA()
        CARI_KEMBALIAN()
        DGTAMPIL.FirstDisplayedScrollingRowIndex = DGTAMPIL.RowCount - 1
        DGTAMPIL.ClearSelection()
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Selected = True
    End Sub

    Private Function CARI_STOK(ByVal Kode As String) As Double
        CARI_STOK = 0
        Dim STR As String

        STR = "SELECT Kode, RTRIM(Barang) as Barang, RTRIM(Satuan) as Satuan," &
                "(SELECT Stok FROM tbl_stok WHERE tbl_stok.Kode = tbl_barang.Kode) as Stok" &
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
            Case Keys.F3
                If DGTAMPIL.Rows.Count > 0 Then
                    TXTKODE.Enabled = False
                    TXTQTY.Enabled = True

                    TXTKODE.Text = DGTAMPIL.SelectedRows(0).Cells("Kode").Value
                    TXTHARGA.Text = DGTAMPIL.SelectedRows(0).Cells("Harga").Value
                    TXTQTY.Text = DGTAMPIL.SelectedRows(0).Cells("QTY").Value
                    TXTTOTAL.Text = DGTAMPIL.SelectedRows(0).Cells("Total").Value

                    BTNCANCEL.Visible = True
                    BTNCARI.Visible = False
                    TXTQTY.Select()
                End If
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
        If DGTAMPIL.Rows.Count > 0 Then
            TXTKODE.Enabled = False
            TXTQTY.Enabled = True

            TXTKODE.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Kode").Value
            TXTHARGA.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Harga").Value
            TXTQTY.Text = DGTAMPIL.Rows(e.RowIndex).Cells("QTY").Value
            TXTTOTAL.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Total").Value

            BTNCANCEL.Visible = True
            BTNCARI.Visible = False
            TXTQTY.Select()
        End If
    End Sub

    Private Sub FR_KELUAR_Load(sender As Object, e As EventArgs) Handles Me.Load
        TXTKODE.Select()
        TXTKASIR.Text = NAMA_LOGIN
        TXTPEMBELI.Text = "USER"
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")

        PEWAKTU.Enabled = True

        ALAMATTOKO.Text = ALAMAT_TOKO
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
            " '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'," &
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

            STR = "UPDATE tbl_stok SET Stok-=" & JUMLAH_PRODUK.ToString.Replace(",", ".") & " WHERE Kode='" & KODE_PRODUK & "'"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
        Next
        TXTDISKON_RUPIAH.Text = "0"
        TXTDISKON_PERSEN.Text = "0"
    End Sub

    Private Function CARI_HARGA_BELI(ByVal KODE As String, ByVal QTY As Double) As Integer
        Dim ID_TRANS As String = ""
        Dim HARGA_BELI As Integer = 0
        Dim QUANTITY As Double = QTY
        While QUANTITY <> 0
            Dim STR As String = "SELECT TOP 1 Id," &
                " Id_trans," &
                " Harga," &
                " Stok" &
                " FROM tbl_transaksi_child WHERE (LEFT(Id_trans,1)='M' or LEFT(Id_trans,1)='R')" &
                " And Kode='" & KODE & "' AND Stok != 0 ORDER BY Id ASC"
            Dim CMD As SqlCommand
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Read()
                ID_TRANS = RD.Item("Id_trans")
                Dim ID As Integer = RD.Item("Id")
                Dim STOKTERSEDIA As Double = RD.Item("Stok")
                If STOKTERSEDIA < QUANTITY Then
                    Dim STOK_AKHIR As Double = 0
                    QUANTITY -= STOKTERSEDIA
                    HARGA_BELI += RD.Item("Harga") * STOKTERSEDIA
                    RD.Close()
                    STR = "UPDATE tbl_transaksi_child SET Stok='" & STOK_AKHIR & "' WHERE Id='" & ID & "'"
                    CMD = New SqlCommand(STR, CONN)
                    CMD.ExecuteNonQuery()
                Else
                    Dim STOK_AKHIR As Double = STOKTERSEDIA - QUANTITY
                    HARGA_BELI += (RD.Item("Harga") * QUANTITY)
                    QUANTITY = 0
                    RD.Close()
                    STR = "UPDATE tbl_transaksi_child SET Stok=" & STOK_AKHIR.ToString.Replace(",", ".") & " WHERE Id='" & ID & "'"
                    CMD = New SqlCommand(STR, CONN)
                    CMD.ExecuteNonQuery()
                End If
                RD.Close()
            End If
            RD.Close()
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
        Dim FR As Form
        If ROLE = 1 Then
            FR = New FR_MENU
        ElseIf role = 2 Then
            FR = New FR_OPS_DASHBOARD
        ElseIf ROLE = 3 Then
            FR = New FR_KASIR_DASHBOARD
        End If
        FR.Show()
        Me.Close()
    End Sub

    Private Sub TXTDISKON_PERSEN_TextChanged(sender As Object, e As EventArgs) Handles TXTDISKON_PERSEN.TextChanged
        HITUNGDISKON_RUPIAH()
    End Sub

    Sub HITUNGDISKON_RUPIAH()
        Dim SUBTOTAL As Integer = 0
        Dim DISKON As Double = 0
        If Not TXTSUBTOTAL.Text = "" Then
            SUBTOTAL = CInt(TXTSUBTOTAL.Text)
        End If
        If Not TXTDISKON_PERSEN.Text = "" Then
            DISKON = TXTDISKON_PERSEN.Text
        End If

        If DISKON <> 0 Then
            TXTDISKON_RUPIAH.Text = CInt(SUBTOTAL * DISKON / 100)
        End If
        TXTTOTALHARGA.Text = SUBTOTAL - CInt(TXTDISKON_RUPIAH.Text)
        LBTOTAL.Text = Format(CInt(TXTTOTALHARGA.Text), "##,##0")
    End Sub

    Sub CARI_KEMBALIAN()
        Dim BAYAR As Integer = 0
        If Not TXTBAYAR.Text = "" Then
            BAYAR = TXTBAYAR.Text.Replace(".", "")
            TXTBAYAR.Text = Format(CInt(TXTBAYAR.Text), "##,##0")
            TXTBAYAR.SelectionStart = Len(TXTBAYAR.Text)
        End If
        Dim TOTALHARGA As Integer = 0
        If Not TXTTOTALHARGA.Text = "" Then
            TOTALHARGA = CInt(TXTTOTALHARGA.Text)
        End If
        TXTKEMBALIAN.Text = Format(BAYAR - TOTALHARGA, "##,##0")
    End Sub

    Private Sub TXTBAYAR_TextChanged(sender As Object, e As EventArgs) Handles TXTBAYAR.TextChanged
        CARI_KEMBALIAN()
    End Sub

    Private Sub TXTBAYAR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTBAYAR.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTKEMBALIAN.Text >= "0" Then
                INPUT_DB()
                PRINT_NOTA()
                FR_KELUAR_KEMBALIAN.LBKEMBALI.Text = Format(CInt(TXTKEMBALIAN.Text), "##,##0")
                FR_KELUAR_KEMBALIAN.ID_TRANSAKSI.Text = ID_TRANSAKSI
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

        Dim STR As String = "SELECT Diskon AS 'Diskon', Jenis_nominal AS 'Jenis_nominal' FROM tbl_diskon" &
                " WHERE Kode IS NULL" &
                " AND Min_transaksi <= '" & CInt(TXTSUBTOTAL.Text) & "'" &
                " AND Tgl_awal <= '" & TGL_SKRG & "'" &
                " And Tgl_akhir >= '" & TGL_SKRG & "'"
        Dim CMD As New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader()
        If RD.HasRows Then
            RD.Read()
            If RD.Item("Jenis_nominal") = "R" Then
                TXTDISKON_RUPIAH.Text = Format(RD.Item("Diskon"), "##0.##")
            ElseIf RD.Item("Jenis_nominal") = "P" Then
                TXTDISKON_PERSEN.Text = Format(RD.Item("Diskon"), "##0.##")
            End If
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
            If TXTKODE.Enabled = True Then
                Dim STR As String = "SELECT Barang" &
                                    " From tbl_barang WHERE kode='" & TXTKODE.Text & "'"
                Dim CMD As SqlCommand
                CMD = New SqlCommand(STR, CONN)
                Dim RD As SqlDataReader
                RD = CMD.ExecuteReader

                If RD.HasRows Then
                    RD.Close()
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
                Else
                    RD.Close()
                    MsgBox("Barang tidak ditemukan!")
                    TXTKODE.Text = ""
                    TXTKODE.Select()
                End If
                RD.Close()
            Else
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
                    TXTKODE.Enabled = True
                    BTNCARI.Visible = True
                    BTNCANCEL.Visible = False
                    TXTKODE.Clear()
                    TXTKODE.Select()
                Else
                    Dim QTY As Double = Convert.ToDouble(TXTQTY.Text)
                    Dim BARIS_DATA As Integer = -1
                    For N = 0 To DGTAMPIL.Rows.Count - 1
                        Dim Kode As String = DGTAMPIL.Item("Kode", N).Value
                        If Kode = TXTKODE.Text Then
                            BARIS_DATA = N
                            Exit For
                        End If
                    Next

                    If BARIS_DATA > -1 Then
                        TXTQTY.Text = Convert.ToDouble(TXTQTY.Text) - DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value
                    End If

                    If CARI_STOK(TXTKODE.Text) < 0 Then
                        TXTQTY.Text = QTY
                        MsgBox("Stok barang tidak mencukupi!")
                        If BARIS_DATA = -1 Then
                            TXTQTY.Text = 1
                            TXTKODE.Clear()
                            TXTKODE.Select()
                        Else
                            TXTQTY.Text = DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value
                        End If
                        TXTQTY.Select()
                    Else
                        MASUK_DATA()
                        TXTKODE.Enabled = True
                        TXTQTY.Text = QTY
                        BTNCARI.Visible = True
                        BTNCANCEL.Visible = False
                        TXTKODE.Clear()
                        TXTKODE.Select()
                    End If
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
        If TXTQTY.Text = "," Then
            TXTQTY.Text = "0,"
        End If
        If Not TXTQTY.Text = "" Then
            JUMLAH_QTY = Convert.ToDouble(TXTQTY.Text)
        End If
        TXTHARGA.Text = CARI_HARGA(JUMLAH_QTY)
        HARGA = CLng(TXTHARGA.Text)
        If Label6.Text = "%" Then
            TXTTOTAL.Text = CInt(HARGA * JUMLAH_QTY * (100 - TXTDISKON.Text) / 100)
        ElseIf Label6.Text = "Rp" Then
            TXTTOTAL.Text = CInt((HARGA * JUMLAH_QTY) - (TXTDISKON.Text * JUMLAH_QTY))
        End If
    End Sub

    Private Sub TXTKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim STR As String = "SELECT Barang" &
                                " From tbl_barang WHERE kode='" & TXTKODE.Text & "'"
            Dim CMD As SqlCommand
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader

            If RD.HasRows Then
                RD.Close()
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
            Else
                RD.Close()
                MsgBox("Barang tidak ditemukan!")
                TXTKODE.Text = ""
                TXTKODE.Select()
            End If
            RD.Close()
        End If

        If e.KeyChar = "'" Then
            e.Handled = True
        End If
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
            TXTQTY.Enabled = True
            RD.Close()
            STR = "SELECT Diskon AS 'Diskon', Jenis_nominal AS 'Jenis_nominal' FROM tbl_diskon" &
                " WHERE Kode='" & TXTKODE.Text & "'" &
                " AND Jenis = 'B'" &
                " AND Tgl_awal <= '" & TGL_SKRG & "'" &
                " And Tgl_akhir >= '" & TGL_SKRG & "'"
            CMD = New SqlCommand(STR, CONN)
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Read()
                If RD.Item("Jenis_nominal") = "R" Then
                    Label6.Text = "Rp"
                ElseIf RD.Item("Jenis_nominal") = "P" Then
                    Label6.Text = "%"
                End If
                TXTDISKON.Text = Format(RD.Item("Diskon"), "##0.##")
                RD.Close()
            Else
                TXTDISKON.Text = 0
                RD.Close()
            End If
            TXTQTY.Text = 1
        Else
            TXTQTY.Enabled = False
            RD.Close()
        End If
    End Sub

    Private Sub TXTKODE_TextChanged(sender As Object, e As EventArgs) Handles TXTKODE.TextChanged
        If TXTKODE.Text <> "" Then
            CARI_DATA()
            Dim HARGA As Integer = 0
            Dim JUMLAH_QTY As Integer = 0
            Dim DISKON As Double = 0
            If Not TXTDISKON.Text = "" Then
                DISKON = TXTDISKON.Text
            End If
            If Not TXTQTY.Text = "" Then
                JUMLAH_QTY = CInt(TXTQTY.Text)
            End If
            TXTHARGA.Text = CARI_HARGA(JUMLAH_QTY)
            If Not TXTHARGA.Text = "" Then
                HARGA = CInt(TXTHARGA.Text)
            End If
            If Label6.Text = "%" Then
                TXTTOTAL.Text = CInt(HARGA * JUMLAH_QTY * (100 - DISKON) / 100)
            ElseIf Label6.Text = "Rp" Then
                TXTTOTAL.Text = CInt(HARGA - DISKON)
            End If
        End If
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
            e.Graphics.DrawImage(IMAGE, JARAK, BarisYangSama(), WIDTH, HEIGHT)

            e.Graphics.DrawString(NAMA_TOKO, fontJudul, Brushes.Black, lebarKertas / 2, BarisBaru(HEIGHT / jarakBaris), textCenter)
            e.Graphics.DrawString(ALAMATTOKO.Text, fontRegular, Brushes.Black, New Rectangle(20, BarisBaru(1), lebarKertas - 30, BarisYangSama), textCenter)
            e.Graphics.DrawString(NO_TOKO, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
            BarisBaru(1)

            e.Graphics.DrawString(LBTGL.Text, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)

            e.Graphics.DrawString(ID_TRANSAKSI, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)
            e.Graphics.DrawString("Kasir : " & TXTKASIR.Text, fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)

            e.Graphics.DrawLine(Pens.Black, marginLeft, BarisBaru(1), (lebarKertas - marginRight), BarisYangSama)
        End If

        For row As Integer = 0 To DGTAMPIL.Rows.Count - 1
            If row >= countBarang And countBarang < DGTAMPIL.Rows.Count Then
                e.Graphics.DrawString(DGTAMPIL.Rows(row).Cells("BARANG").Value, fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
                If CInt(DGTAMPIL.Rows(row).Cells("DISKON").Value) = 0 Then
                    e.Graphics.DrawString(Convert.ToDouble(DGTAMPIL.Rows(row).Cells("QTY").Value) & " " & DGTAMPIL.Rows(row).Cells("SATUAN").Value & " x " & Format(CInt(DGTAMPIL.Rows(row).Cells("HARGA").Value), "##,##0"), fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
                Else
                    e.Graphics.DrawString(Convert.ToDouble(DGTAMPIL.Rows(row).Cells("QTY").Value) & " " & DGTAMPIL.Rows(row).Cells("SATUAN").Value & " x " & Format(CInt(DGTAMPIL.Rows(row).Cells("HARGA").Value), "##,##0") & " (Disc. " & Format(CInt(DGTAMPIL.Rows(row).Cells("DISKON").Value), "##,##0") & ")", fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
                End If
                e.Graphics.DrawString(Format(CInt(DGTAMPIL.Rows(row).Cells("TOTAL").Value), "##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
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

        pageNumber = 1
        countBarang = 0
    End Sub

    Sub PRINT_NOTA()
        Dim ps As New PrinterSettings
        PRINTNOTA.OriginAtMargins = False
        PRINTNOTA.PrinterSettings = ps
        PRINTNOTA.PrinterSettings.PrinterName = PRINTER_NOTA
        Dim total
        total = tinggiKertas + (BarisBaru(DGTAMPIL.Rows.Count * 2))
        PRINTNOTA.DefaultPageSettings.PaperSize = New PaperSize("Custom", lebarKertas, total)

        PRINTNOTA.DefaultPageSettings.Landscape = False
        PRINTNOTA.DocumentName = "Stroke"
        PRINTNOTA.Print()
    End Sub

    Private Sub BTNCANCEL_Click(sender As Object, e As EventArgs) Handles BTNCANCEL.Click
        TXTKODE.Enabled = True
        BTNCARI.Visible = True
        BTNCANCEL.Visible = False
        TXTKODE.Clear()
        TXTKODE.Select()
    End Sub

    Private Sub TXTQTY_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTQTY.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                TXTKODE.Enabled = True
                BTNCARI.Visible = True
                BTNCANCEL.Visible = False
                TXTKODE.Clear()
                TXTKODE.Select()
        End Select
    End Sub

    Private Sub TXTTOTALHARGA_TextChanged(sender As Object, e As EventArgs) Handles TXTTOTALHARGA.TextChanged
        LBTOTAL.Text = Format(CInt(TXTTOTALHARGA.Text), "##,##0")
    End Sub

    Private Sub BTNINPUT_Click(sender As Object, e As EventArgs) Handles BTNINPUT.Click
        If TXTKODE.Enabled = True Then
            Dim STR As String = "SELECT Barang" &
                                " From tbl_barang WHERE kode='" & TXTKODE.Text & "'"
            Dim CMD As SqlCommand
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader

            If RD.HasRows Then
                RD.Close()
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
            Else
                RD.Close()
                MsgBox("Barang tidak ditemukan!")
                TXTKODE.Text = ""
                TXTKODE.Select()
            End If
            RD.Close()
        Else
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
                TXTKODE.Enabled = True
                BTNCARI.Visible = True
                BTNCANCEL.Visible = False
                TXTKODE.Clear()
                TXTKODE.Select()
            Else
                Dim QTY As Double = Convert.ToDouble(TXTQTY.Text)
                Dim BARIS_DATA As Integer = -1
                For N = 0 To DGTAMPIL.Rows.Count - 1
                    Dim Kode As String = DGTAMPIL.Item("Kode", N).Value
                    If Kode = TXTKODE.Text Then
                        BARIS_DATA = N
                        Exit For
                    End If
                Next

                If BARIS_DATA > -1 Then
                    TXTQTY.Text = Convert.ToDouble(TXTQTY.Text) - DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value
                End If

                If CARI_STOK(TXTKODE.Text) < 0 Then
                    TXTQTY.Text = QTY
                    MsgBox("Stok barang tidak mencukupi!")
                    If BARIS_DATA = -1 Then
                        TXTQTY.Text = 1
                        TXTKODE.Clear()
                        TXTKODE.Select()
                    Else
                        TXTQTY.Text = DGTAMPIL.Rows(BARIS_DATA).Cells("Qty").Value
                    End If
                    TXTQTY.Select()
                Else
                    MASUK_DATA()
                    TXTKODE.Enabled = True
                    TXTQTY.Text = QTY
                    BTNCARI.Visible = True
                    BTNCANCEL.Visible = False
                    TXTKODE.Clear()
                    TXTKODE.Select()
                End If
            End If
        End If

    End Sub

    Private Sub TXTPEMBELI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPEMBELI.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub
End Class