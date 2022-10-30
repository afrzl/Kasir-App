Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports BarcodeLib

Public Class FR_PRODUK
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
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN

        TAMPIL()
        TXTKODE.Select()
    End Sub

    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 12
    Sub TAMPIL()
        Dim STR As String = "SELECT RTRIM(Kode) AS 'Kode Barang'," &
            " RTRIM(Barang) AS 'Nama Barang'," &
            " RTRIM(Satuan) AS 'Satuan'," &
            " Harga1 AS 'Harga Satuan' FROM tbl_barang" &
            " WHERE Barang LIKE '%" & TXTCARI.Text & "%'" &
            " OR Kode = '" & TXTCARI.Text & "'" &
            " ORDER BY 'Nama Barang' ASC"

        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL, START_RECORD, TAMPIL_RECORD, 0)
        DGTAMPIL.DataSource = TBL.Tables(0)

        DGTAMPIL.Columns(3).DefaultCellStyle.Format = "Rp ###,##"

        DGTAMPIL.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGTAMPIL.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGTAMPIL.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        BTNPREV.Enabled = True
        BTNNEXT.Enabled = True

        Dim TOTAL_RECORD As Integer = 0
        Dim TBL_DATA As New DataTable
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

    Private Sub TXTKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTNAMA.Select()
        End If

        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTNAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNAMA.KeyPress
        If e.KeyChar = Chr(13) Then
            CBSATUAN.Select()
        End If

        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub CBSATUAN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBSATUAN.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTEND1.Select()
        End If

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z, a-z]" _
            OrElse e.KeyChar Like "[0-9]" _
            OrElse KeyAscii = Keys.Back) Then
            KeyAscii = 0
        End If

        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub TXTHARGA1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA1.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTEND2.Enabled = False Then
                BTNSIMPAN.Select()
            Else
                TXTEND2.Select()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTHARGA2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA2.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTEND3.Enabled = False Then
                BTNSIMPAN.Select()
            Else
                TXTEND3.Select()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTHARGA3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA3.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTEND4.Enabled = False Then
                BTNSIMPAN.Select()
            Else
                TXTEND4.Select()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If TXTKODE.Text = "" Or TXTNAMA.Text = "" Or CBSATUAN.Text = "" Then
            MsgBox("Isikan data secara lengkap!")
            TXTKODE.Select()
        Else
            If (TXTHARGA1.Enabled = True And TXTHARGA1.Text = "") Or (TXTHARGA2.Enabled = True And TXTHARGA2.Text = "") Or (TXTHARGA3.Enabled = True And TXTHARGA3.Text = "") Or (TXTHARGA4.Enabled = True And TXTHARGA4.Text = "") Or (TXTHARGA5.Enabled = True And TXTHARGA5.Text = "") Then
                MsgBox("Isikan data secara lengkap!")
            Else
                Dim END1 As Double = 0
                Dim END2 As Double = 0
                Dim END3 As Double = 0
                Dim END4 As Double = 0

                If Not TXTEND1.Text = "" Then
                    END1 = Convert.ToDouble(TXTEND1.Text)
                End If
                If Not TXTEND2.Text = "" Then
                    END2 = Convert.ToDouble(TXTEND2.Text)
                End If
                If Not TXTEND3.Text = "" Then
                    END3 = Convert.ToDouble(TXTEND3.Text)
                End If
                If Not TXTEND4.Text = "" Then
                    END4 = Convert.ToDouble(TXTEND4.Text)
                End If

                Dim STR As String = "SELECT * FROM tbl_barang WHERE Kode='" & TXTKODE.Text & "'"
                Dim CMD As SqlCommand
                CMD = New SqlCommand(STR, CONN)
                Dim RD As SqlDataReader
                RD = CMD.ExecuteReader
                If RD.HasRows Then
                    RD.Close()
                    STR = "UPDATE tbl_barang SET Barang='" & TXTNAMA.Text & "'," &
                    "Satuan='" & CBSATUAN.Text & "'," &
                    "Harga1='" & TXTHARGA1.Text & "'," &
                    "End1=" & END1.ToString.Replace(",", ".") & "," &
                    "Harga2='" & TXTHARGA2.Text & "'," &
                    "End2=" & END2.ToString.Replace(",", ".") & "," &
                    "Harga3='" & TXTHARGA3.Text & "'," &
                    "End3=" & END3.ToString.Replace(",", ".") & "," &
                    "Harga4='" & TXTHARGA4.Text & "'," &
                    "End4=" & END4.ToString.Replace(",", ".") & "," &
                    "Harga5='" & TXTHARGA5.Text & "'" &
                    "WHERE Kode='" & TXTKODE.Text & "'"
                Else
                    RD.Close()
                    STR = "INSERT INTO tbl_barang VALUES (" &
                        "'" & TXTKODE.Text & "'," &
                        "'" & TXTNAMA.Text & "'," &
                        "'" & CBSATUAN.Text & "'," &
                        "'" & TXTHARGA1.Text & "'," &
                        END1.ToString.Replace(",", ".") & "," &
                        "'" & TXTHARGA2.Text & "'," &
                        END2.ToString.Replace(",", ".") & "," &
                        "'" & TXTHARGA3.Text & "'," &
                        END3.ToString.Replace(",", ".") & "," &
                        "'" & TXTHARGA4.Text & "'," &
                        END4.ToString.Replace(",", ".") & "," &
                        "'" & TXTHARGA5.Text &
                   "')"
                End If
                CMD = New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data produk berhasil disimpan.")
                TXTKODE.Clear()
                TXTKODE.Enabled = True
                TXTKODE.Select()
                CARI_PRODUK()
                TAMPIL()
            End If
        End If
    End Sub

    Private Sub TXTCARI_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI.TextChanged
        TAMPIL()
    End Sub

    Private Sub HapusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusToolStripMenuItem.Click
        Dim STR As String = "DELETE FROM tbl_barang WHERE RTRIM(Kode)='" &
            DGTAMPIL.Item(0, DGTAMPIL.CurrentRow.Index).Value & "'"
        If MsgBox("Apakah anda yakin akan menghapus produk ini?", vbYesNo) = vbYes Then
            Dim CMD As New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
            TAMPIL()
        End If
    End Sub

    Private Sub DGTAMPIL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellClick
        On Error Resume Next
        TXTKODE.Text = DGTAMPIL.Item(0, e.RowIndex).Value
        CARI_PRODUK()
    End Sub

    Private Sub TXTEND1_TextChanged(sender As Object, e As EventArgs) Handles TXTEND1.TextChanged
        If TXTEND1.Text = "" Or TXTEND1.Text = "0" Then
            TXTEND2.Enabled = False
            TXTEND2.Text = ""
            TXTHARGA2.Enabled = False
        Else
            If TXTEND1.Text > "0" Then
                TXTEND2.Enabled = True
                TXTHARGA2.Enabled = True
            End If
        End If
        TXTHARGA2.Text = ""
    End Sub

    Private Sub TXTEND1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTEND1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            TXTHARGA1.Select()
        End If
    End Sub

    Private Sub TXTEND2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTEND2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            TXTHARGA2.Select()
        End If
    End Sub

    Private Sub TXTEND2_TextChanged(sender As Object, e As EventArgs) Handles TXTEND2.TextChanged
        If TXTEND2.Text = "" Or TXTEND2.Text = "0" Then
            TXTEND3.Enabled = False
            TXTEND3.Text = ""
            TXTHARGA3.Enabled = False
        Else
            If TXTEND2.Text > "0" Then
                TXTEND3.Enabled = True
                TXTHARGA3.Enabled = True
            End If
        End If
        TXTHARGA3.Text = ""
    End Sub

    Private Sub BTNUBAH_Click(sender As Object, e As EventArgs) Handles BTNUBAH.Click
        Dim KODE As String = TXTKODE.Text
        TXTKODE.Text = ""
        TXTKODE.Text = KODE
        EDIT_PRODUK()
    End Sub

    Private Sub BTNCANCEL_Click(sender As Object, e As EventArgs) Handles BTNCANCEL.Click
        TXTKODE.Clear()
        CARI_PRODUK()
        TXTKODE.Select()
    End Sub

    Private Sub TXTEND3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTEND3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            TXTHARGA3.Select()
        End If
    End Sub

    Private Sub TXTEND4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTEND4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            TXTHARGA4.Select()
        End If
    End Sub

    Private Sub TXTEND3_TextChanged(sender As Object, e As EventArgs) Handles TXTEND3.TextChanged
        If TXTEND3.Text = "" Or TXTEND3.Text = "0" Then
            TXTEND4.Enabled = False
            TXTEND4.Text = ""
            TXTHARGA4.Enabled = False
        Else
            If TXTEND3.Text > "0" Then
                TXTHARGA4.Enabled = True
                TXTEND4.Enabled = True
            End If
        End If
        TXTHARGA4.Text = ""
    End Sub

    Private Sub TXTEND4_TextChanged(sender As Object, e As EventArgs) Handles TXTEND4.TextChanged
        If TXTEND4.Text = "" Or TXTEND4.Text = "0" Then
            TXTEND5.Text = ""
            TXTHARGA5.Enabled = False
        ElseIf TXTEND4.Text > "0" Then
            TXTEND5.Text = TXTEND4.Text
            TXTHARGA5.Enabled = True
        End If
    End Sub

    Private Sub TXTHARGA4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA4.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTEND4.Text = "" Then
                BTNSIMPAN.Select()
            Else
                TXTHARGA5.Select()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTHARGA5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA5.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
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

    Private Sub TXTEND2_Leave(sender As Object, e As EventArgs) Handles TXTEND2.Leave
        If TXTEND2.Text <> "" Then
            If Convert.ToDouble(TXTEND2.Text) <= Convert.ToDouble(TXTEND1.Text) Then
                TXTEND2.Clear()
                MsgBox("Item harus lebih besar dari sebelumnya!")
                TXTEND2.Select()
            Else
                TXTHARGA2.Select()
            End If
        Else
            TXTHARGA2.Select()
        End If
    End Sub

    Private Sub TXTEND3_Leave(sender As Object, e As EventArgs) Handles TXTEND3.Leave
        If TXTEND3.Text <> "" Then
            If Convert.ToDouble(TXTEND3.Text) <= Convert.ToDouble(TXTEND2.Text) Then
                TXTEND3.Clear()
                MsgBox("Item harus lebih besar dari sebelumnya!")
                TXTEND3.Select()
            Else
                TXTHARGA3.Select()
            End If
        Else
            TXTHARGA3.Select()
        End If
    End Sub

    Private Sub TXTEND4_Leave(sender As Object, e As EventArgs) Handles TXTEND4.Leave
        If TXTEND4.Text <> "" Then
            If Convert.ToDouble(TXTEND4.Text) <= Convert.ToDouble(TXTEND3.Text) Then
                TXTEND4.Clear()
                MsgBox("Item harus lebih besar dari sebelumnya!")
                TXTEND4.Select()
            Else
                TXTHARGA4.Select()
            End If
        Else
            TXTHARGA4.Select()
        End If
    End Sub

    Private Sub TXTEND1_Leave(sender As Object, e As EventArgs) Handles TXTEND1.Leave
        If TXTEND1.Text <> "" Then
            If Convert.ToDouble(TXTEND1.Text) <= 0 Then
                TXTEND1.Clear()
                MsgBox("Item harus lebih besar dari 0!")
            Else
                TXTHARGA1.Select()
            End If
        Else
            TXTHARGA1.Select()
        End If
    End Sub

    Dim WIDTH_BARCODE As Integer = 125
    Dim HEIGHT_BARCODE As Integer = 40
    Dim WIDTH_LABEL As Integer = 140
    Dim HEIGHT_LABEL As Integer = 84
    ReadOnly FONT_KODE As New Font("Segoe UI", 5, FontStyle.Regular)
    Dim PPD As New PrintDialog

    Private Sub BTNCETAK_Click(sender As Object, e As EventArgs) Handles BTNCETAK.Click
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
        Dim image As Image = barcode.Encode(TYPE.CODE128, TXTKODE.Text, foreColor, backColor, WIDTH_BARCODE, HEIGHT_BARCODE)
        Dim MyBitmap As New Bitmap(image)
        For j As Integer = 0 To 2
            e.Graphics.DrawImage(MyBitmap, X, Y, WIDTH_BARCODE, HEIGHT_BARCODE)
            e.Graphics.DrawString(TXTKODE.Text, FONT_KODE, Brushes.Black, ((j * WIDTH_LABEL) + WIDTH_LABEL / 2) - 3, Y + HEIGHT_BARCODE, textCenter)
            X += WIDTH_LABEL + 3
        Next
    End Sub

    Sub EDIT_PRODUK()
        TXTNAMA.Enabled = True
        TXTEND1.Enabled = True
        TXTHARGA1.Enabled = True
        CBSATUAN.Enabled = True
        BTNUBAH.Visible = False
        BTNSIMPAN.Visible = True
        If TXTEND2.Text <> "" Then
            TXTEND2.Enabled = True
            TXTHARGA2.Enabled = True
            TXTHARGA3.Enabled = True
        End If
        If TXTEND3.Text <> "" Then
            TXTEND3.Enabled = True
            TXTHARGA3.Enabled = True
            TXTHARGA4.Enabled = True
        End If
        If TXTEND4.Text <> "" Then
            TXTEND4.Enabled = True
            TXTHARGA4.Enabled = True
            TXTHARGA5.Enabled = True
        End If
    End Sub

    Sub CARI_PRODUK()
        Dim STR As String = "SELECT * FROM tbl_barang WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTNAMA.Enabled = True
            TXTEND1.Enabled = True
            TXTHARGA1.Enabled = True
            Dim END1 As String = ""
            If Not RD.Item("End1") = 0 Then
                END1 = Format(RD.Item("End1"), "##0.##")
            End If
            Dim END2 As String = ""
            If Not RD.Item("End2") = 0 Then
                END2 = Format(RD.Item("End2"), "##0.##")
            Else
                TXTEND2.Enabled = False
            End If
            Dim END3 As String = ""
            If Not RD.Item("End3") = 0 Then
                END3 = Format(RD.Item("End3"), "##0.##")
            Else
                TXTEND3.Enabled = False
            End If
            Dim END4 As String = ""
            If Not RD.Item("End4") = 0 Then
                END4 = Format(RD.Item("End4"), "##0.##")
            Else
                TXTEND4.Enabled = False
            End If

            TXTNAMA.Text = RD.Item("Barang").ToString.Trim
            CBSATUAN.Text = RD.Item("Satuan").ToString.Trim
            TXTHARGA1.Text = CInt(RD.Item("Harga1"))
            TXTEND1.Text = END1
            TXTHARGA2.Text = CInt(RD.Item("Harga2"))
            TXTEND2.Text = END2
            TXTHARGA3.Text = CInt(RD.Item("Harga3"))
            TXTEND3.Text = END3
            TXTHARGA4.Text = CInt(RD.Item("Harga4"))
            TXTEND4.Text = END4
            TXTHARGA5.Text = CInt(RD.Item("Harga5"))
            RD.Close()

            TXTKODE.Enabled = False
            TXTNAMA.Enabled = False
            CBSATUAN.DropDownStyle = ComboBoxStyle.DropDownList
            TXTEND1.Enabled = False
            TXTHARGA1.Enabled = False
            TXTHARGA2.Enabled = False
            TXTEND2.Enabled = False
            TXTHARGA3.Enabled = False
            TXTEND3.Enabled = False
            TXTHARGA4.Enabled = False
            TXTEND4.Enabled = False
            TXTHARGA5.Enabled = False
            BTNSIMPAN.Visible = False
            BTNCANCEL.Visible = True
            BTNUBAH.Visible = True
            BTNCETAK.Visible = True
            CBSATUAN.Enabled = False
        Else
            RD.Close()
            TXTNAMA.Clear()
            TXTEND1.Clear()
            TXTHARGA1.Clear()
            TXTHARGA2.Clear()
            TXTEND2.Clear()
            TXTHARGA3.Clear()
            TXTEND3.Clear()
            TXTHARGA4.Clear()
            TXTEND4.Clear()
            TXTHARGA5.Clear()
            CBSATUAN.SelectedIndex = -1

            TXTKODE.Enabled = True
            TXTNAMA.Enabled = True
            TXTEND1.Enabled = True
            TXTHARGA1.Enabled = True
            BTNSIMPAN.Visible = True
            BTNCANCEL.Visible = False
            BTNUBAH.Visible = False
            BTNCETAK.Visible = False
            CBSATUAN.Enabled = True
        End If
        RD.Close()
    End Sub

    Private Sub TXTKODE_Leave(sender As Object, e As EventArgs) Handles TXTKODE.Leave
        CARI_PRODUK()
    End Sub

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
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

    Private Sub BTNKASIR_Click(sender As Object, e As EventArgs) Handles BTNKASIR.Click
        BUKA_FORM(FR_KASIR)
    End Sub

    Private Sub TXTCARI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub BTNHISTORYPENJUALAN_Click(sender As Object, e As EventArgs) Handles BTNHISTORYPENJUALAN.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub
End Class