Imports System.Data.SqlClient
Public Class FR_PRODUK
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy H:m:s")
    End Sub

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub BTNEXIT_Click(sender As Object, e As EventArgs)
        Dim FR As New FR_LOGIN
        My.Settings.ID_ACCOUNT = 0
        FR.Show()
        Me.Hide()
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

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        Dim FR As New FR_LOGIN
        My.Settings.ID_ACCOUNT = 0
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNKASIR_Click(sender As Object, e As EventArgs) Handles BTNKASIR.Click
        BUKA_FORM(FR_KASIR)
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub FR_PRODUK_Load(sender As Object, e As EventArgs) Handles Me.Load
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:MM:SS")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN

        TAMPIL()
        TXTKODE.Select()
    End Sub

    Sub TAMPIL()
        Dim STR As String = "SELECT RTRIM(Kode) AS 'Kode Barang',RTRIM(Barang) AS 'Nama Barang'," &
            "Satuan,Harga1 AS 'Harga Satuan' FROM tbl_barang" &
            " WHERE Barang LIKE '%" & TXTCARI.Text & "%'"
        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGTAMPIL.DataSource = TBL

        DGTAMPIL.Columns(3).DefaultCellStyle.Format = "Rp ###,##"

        DGTAMPIL.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub

    Private Sub TXTKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTNAMA.Select()
        End If
    End Sub

    Private Sub TXTNAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNAMA.KeyPress
        If e.KeyChar = Chr(13) Then
            CBSATUAN.Select()
        End If
    End Sub

    Private Sub CBSATUAN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBSATUAN.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTEND1.Select()
        End If
    End Sub

    Private Sub TXTHARGA1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA1.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTEND2.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTHARGA2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA2.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTHARGA3.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTHARGA3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA3.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTKODE_TextChanged(sender As Object, e As EventArgs) Handles TXTKODE.TextChanged
        Dim STR As String = "SELECT * FROM tbl_barang WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            Dim END1 As String = ""
            If Not RD.Item("End1") = 0 Then
                END1 = RD.Item("End1")
            End If
            Dim START2 As String = ""
            If Not RD.Item("Start2") = 0 Then
                START2 = RD.Item("Start2")
            End If
            Dim END2 As String = ""
            If Not RD.Item("End2") = 0 Then
                END2 = RD.Item("End2")
            End If
            Dim START3 As String = ""
            If Not RD.Item("Start3") = 0 Then
                START3 = RD.Item("Start3")
            End If
            Dim END3 As String = ""
            If Not RD.Item("End3") = 0 Then
                END3 = RD.Item("End3")
            End If

            TXTNAMA.Text = RD.Item("Barang").ToString.Trim
            CBSATUAN.Text = RD.Item("Satuan").ToString.Trim
            TXTHARGA1.Text = CInt(RD.Item("Harga1"))
            TXTEND1.Text = END1
            TXTSTART2.Text = START2
            TXTHARGA2.Text = CInt(RD.Item("Harga2"))
            TXTEND2.Text = END2
            TXTSTART3.Text = START3
            TXTHARGA3.Text = CInt(RD.Item("Harga3"))
            TXTEND3.Text = END3
            RD.Close()
        Else
            RD.Close()
            TXTNAMA.Clear()
            TXTEND1.Clear()
            TXTHARGA1.Clear()
            TXTSTART2.Clear()
            TXTHARGA2.Clear()
            TXTEND2.Clear()
            TXTSTART3.Clear()
            TXTHARGA3.Clear()
            TXTEND3.Clear()
        End If
        RD.Close()
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If TXTKODE.Text = "" Or TXTNAMA.Text = "" Or TXTHARGA1.Text = "" Or TXTHARGA2.Text = "" Or TXTHARGA3.Text = "" Then
            MsgBox("Isikan data secara lengkap!")
        Else
            Dim START1 As Integer = 1
            Dim END1 As Integer = 0
            Dim START2 As Integer = 0
            Dim END2 As Integer = 0
            Dim START3 As Integer = 0
            Dim END3 As Integer = 0

            If Not TXTEND1.Text = "" Then
                END1 = TXTEND1.Text
            End If
            If Not TXTSTART2.Text = "" Then
                START2 = TXTSTART2.Text
            End If
            If Not TXTEND2.Text = "" Then
                END2 = TXTEND2.Text
            End If
            If Not TXTSTART3.Text = "" Then
                START3 = TXTSTART3.Text
            End If

            Dim STR As String = "SELECT * FROM tbl_barang WHERE Kode='" & TXTKODE.Text & "'"
            Dim CMD As SqlCommand
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Close()
                STR = "UPDATE tbl_barang SET Barang='" & TXTNAMA.Text &
                    "',Satuan='" & CBSATUAN.Text &
                    "',Start1='" & START1 &
                    "',Harga1='" & TXTHARGA1.Text &
                    "',End1='" & END1 &
                    "',Start2='" & START2 &
                    "',Harga2='" & TXTHARGA2.Text &
                    "',End2='" & END2 &
                    "',Start3='" & START3 &
                    "',Harga3='" & TXTHARGA3.Text &
                    "',End3='" & END3 &
                    "' WHERE Kode='" & TXTKODE.Text & "'"
            Else
                RD.Close()
                STR = "INSERT INTO tbl_barang VALUES ('" &
                    TXTKODE.Text & "', '" &
                    TXTNAMA.Text & "', '" &
                    CBSATUAN.Text & "', '" &
                    START1 & "', '" &
                    TXTHARGA1.Text & "', '" &
                    END1 & "', '" &
                    START2 & "', '" &
                    TXTHARGA2.Text & "', '" &
                    END2 & "', '" &
                    START3 & "', '" &
                    TXTHARGA3.Text & "', '" &
                    END3 & "')"
            End If
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data produk berhasil disimpan.")
            TXTKODE.Clear()
            TXTKODE.Select()
            TAMPIL()
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
        TXTKODE.ReadOnly = True
        TXTNAMA.ReadOnly = True
        CBSATUAN.DropDownStyle = ComboBoxStyle.DropDownList
        TXTEND1.ReadOnly = True
        TXTHARGA1.ReadOnly = True
        TXTSTART2.ReadOnly = True
        TXTHARGA2.ReadOnly = True
        TXTEND2.ReadOnly = True
        TXTSTART3.ReadOnly = True
        TXTHARGA3.ReadOnly = True
        TXTEND3.ReadOnly = True
        BTNSIMPAN.Visible = False
        BTNCANCEL.Visible = True
        BTNUBAH.Visible = True
    End Sub

    Private Sub TXTEND1_TextChanged(sender As Object, e As EventArgs) Handles TXTEND1.TextChanged
        If TXTEND1.Text = "" Or TXTEND1.Text = "0" Then
            TXTSTART2.Text = ""
            TXTEND2.ReadOnly = True
            TXTEND2.Text = ""
            TXTHARGA2.ReadOnly = True
        Else
            If TXTEND1.Text > "0" Then
                TXTSTART2.Text = CInt(TXTEND1.Text + 1)
                TXTEND2.ReadOnly = False
                TXTHARGA2.ReadOnly = False
            End If
        End If
        TXTHARGA2.Text = ""
    End Sub

    Private Sub TXTEND1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTEND1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            If Not TXTEND1.Text = "" Then
                If CInt(TXTEND1.Text) <= CInt(TXTSTART1.Text) Then
                    TXTEND1.Clear()
                    MsgBox("Item harus lebih besar dari sebelumnya!")
                Else
                    TXTHARGA1.Select()
                End If
            Else
                TXTHARGA1.Select()
            End If
        End If
    End Sub

    Private Sub TXTEND2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTEND2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            If Not TXTEND2.Text = "" Then
                If CInt(TXTEND2.Text) <= CInt(TXTSTART2.Text) Then
                    TXTEND2.Clear()
                    MsgBox("Item harus lebih besar dari sebelumnya!")
                Else
                    TXTHARGA2.Select()
                End If
            Else
                TXTHARGA2.Select()
            End If
        End If
    End Sub

    Private Sub TXTEND2_TextChanged(sender As Object, e As EventArgs) Handles TXTEND2.TextChanged
        If TXTEND2.Text = "" Or TXTEND2.Text = "0" Then
            TXTSTART3.Text = ""
            TXTHARGA3.Text = ""
            TXTHARGA3.ReadOnly = True
        Else
            If TXTEND1.Text > "0" Then
                TXTHARGA3.ReadOnly = False
                TXTSTART3.Text = CInt(TXTEND2.Text + 1)
            End If
        End If
        TXTHARGA3.Text = ""
    End Sub

    Private Sub TXTHARGA1_TextChanged(sender As Object, e As EventArgs) Handles TXTHARGA1.TextChanged
        If TXTSTART2.Text = "" Then
            TXTHARGA2.Text = TXTHARGA1.Text
        End If
    End Sub

    Private Sub TXTHARGA2_TextChanged(sender As Object, e As EventArgs) Handles TXTHARGA2.TextChanged
        If TXTSTART3.Text = "" Then
            TXTHARGA3.Text = TXTHARGA2.Text
        End If
    End Sub

    Private Sub BTNUBAH_Click(sender As Object, e As EventArgs) Handles BTNUBAH.Click
        TXTKODE.ReadOnly = False
        TXTNAMA.ReadOnly = False
        TXTEND1.ReadOnly = False
        TXTHARGA1.ReadOnly = False
        TXTEND2.ReadOnly = False
        TXTHARGA2.ReadOnly = False
        TXTHARGA3.ReadOnly = False
        BTNSIMPAN.Visible = True
        BTNUBAH.Visible = False
    End Sub

    Private Sub BTNCANCEL_Click(sender As Object, e As EventArgs) Handles BTNCANCEL.Click
        TXTKODE.Clear()
        TXTKODE.ReadOnly = False
        TXTNAMA.ReadOnly = False
        TXTEND1.ReadOnly = False
        TXTHARGA1.ReadOnly = False
        BTNSIMPAN.Visible = True
        BTNUBAH.Visible = False
        BTNCANCEL.Visible = False
        TXTKODE.Select()
    End Sub
End Class