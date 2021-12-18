Imports System.Data.SqlClient
Public Class FR_KASIR
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
    End Sub

    Sub TAMPIL()
        Dim STR As String = "SELECT Id as ID,RTRIM(Nama) AS 'Nama Lengkap',RTRIM(Alamat) AS Alamat," &
            " Tgl_lahir as 'Tanggal Lahir',JK as 'Jenis Kelamin',RTRIM(No_hp) AS 'Nomor HP', Role AS 'Hak Akses'" &
            " FROM tbl_karyawan WHERE Nama Like '%" & TXTCARI.Text & "%' AND ID != '" & My.Settings.ID_ACCOUNT & "'"
        Dim DA As SqlDataAdapter
        DA = New SqlDataAdapter(STR, CONN)
        Dim TBL As New DataTable
        DA.Fill(TBL)
        DGTAMPIL.DataSource = TBL

        DGTAMPIL.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        For N = 0 To DGTAMPIL.Rows.Count - 1
            If DGTAMPIL.Rows(N).Cells(4).Value = "L" Then
                DGTAMPIL.Rows(N).Cells(4).Value = "Laki-laki"
            Else
                DGTAMPIL.Rows(N).Cells(4).Value = "Perempuan"
            End If

            If DGTAMPIL.Rows(N).Cells(6).Value = 1 Then
                DGTAMPIL.Rows(N).Cells(6).Value = "Administrator"
            ElseIf DGTAMPIL.Rows(N).Cells(6).Value = 2 Then
                DGTAMPIL.Rows(N).Cells(6).Value = "Admin Barang"
            Else
                DGTAMPIL.Rows(N).Cells(6).Value = "Kasir"
            End If
        Next
    End Sub

    Private Function AUTOID() As String
        Dim ID_AWAL As String = Format(TXTTGL.Value, "yyyyMMdd")
        Dim STR As String = "SELECT TOP 1 Id FROM tbl_karyawan ORDER BY Id DESC"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows() Then
            RD.Read()
            Dim ID As Integer = Mid(RD.Item("Id"), 9, 3) + 1
            RD.Close()
            AUTOID = ID_AWAL + Format(ID, "000")
        Else
            RD.Close()
            AUTOID = ID_AWAL + Format(1, "000")
        End If
        RD.Close()
    End Function

    Private Sub BTNEXIT_Click(sender As Object, e As EventArgs)
        Dim FR As New FR_LOGIN
        My.Settings.ID_ACCOUNT = 0
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub TXTCARI_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI.TextChanged
        TAMPIL()
    End Sub

    Private Sub TXTID_TextChanged(sender As Object, e As EventArgs) Handles TXTID.TextChanged
        Dim STR As String = "SELECT * FROM tbl_karyawan WHERE Id='" & TXTID.Text & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTNAMA.Text = RD.Item("Nama").ToString.Trim
            TXTALAMAT.Text = RD.Item("Alamat").ToString.Trim
            TXTTGL.Value = RD.Item("Tgl_lahir")
            If RD.Item("JK") = "L" Then
                TXTJK.Text = "Laki-laki"
            ElseIf RD.Item("JK") = "P" Then
                TXTJK.Text = "Perempuan"
            End If
            If RD.Item("Role") = 1 Then
                CBROLE.Text = "Administrator"
            ElseIf RD.Item("Role") = 2 Then
                CBROLE.Text = "Admin barang"
            ElseIf RD.Item("Role") = 3 Then
                CBROLE.Text = "Kasir"
            End If
            TXTNOHP.Text = RD.Item("No_hp").ToString.Trim
            RD.Close()
            BTNDELETE.Visible = True
        Else
            RD.Close()
            TXTNAMA.Clear()
            TXTPASSWORD.Clear()
            TXTALAMAT.Clear()
            TXTNOHP.Clear()
            TXTNAMA.Select()
            BTNDELETE.Visible = False
        End If
        RD.Close()
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If TXTNAMA.Text = "" Or CBROLE.Text = "" Or TXTPASSWORD.Text = "" Then
            MsgBox("Data tidak lengkap!")
        Else
            Dim jk As String = ""
            If TXTJK.Text = "Laki-laki" Then
                jk = "L"
            ElseIf TXTJK.Text = "Perempuan" Then
                jk = "P"
            End If

            Dim role As Integer
            If CBROLE.SelectedIndex = 0 Then
                role = 1
            ElseIf CBROLE.SelectedIndex = 1 Then
                role = 2
            ElseIf CBROLE.SelectedIndex = 2 Then
                role = 3
            End If

            Dim ID As String = AUTOID()

            Dim STR As String
            Dim CMD As SqlCommand
            If TXTID.Text = "" Then
                STR = "INSERT INTO tbl_karyawan VALUES ('" & ID & "','" &
                    TXTNAMA.Text & "', '" & TXTPASSWORD.Text & "', '" & role & "', '" & TXTALAMAT.Text & "', '" &
                    Format(TXTTGL.Value, "MM/dd/yyyy") & "', '" & jk & "', '" &
                    TXTNOHP.Text & "')"
            Else
                STR = "SELECT * FROM tbl_karyawan WHERE Id='" & TXTID.Text & "'"
                CMD = New SqlCommand(STR, CONN)
                Dim RD As SqlDataReader
                RD = CMD.ExecuteReader
                If RD.HasRows Then
                    RD.Close()
                    ID = TXTID.Text
                    STR = "UPDATE tbl_karyawan SET Nama='" & TXTNAMA.Text &
                        "',Password='" & TXTPASSWORD.Text &
                        "',Role='" & role &
                        "',Alamat='" & TXTALAMAT.Text &
                        "',Tgl_lahir='" & Format(TXTTGL.Value, "MM/dd/yyyy") &
                        "',JK='" & jk &
                        "',No_hp='" & TXTNOHP.Text &
                        "' WHERE Id='" & TXTID.Text & "'"
                Else
                    RD.Close()
                    STR = "INSERT INTO tbl_karyawan VALUES ('" & ID & "','" &
                        TXTNAMA.Text & "', '" & TXTPASSWORD.Text & "', '" & role & "', '" & TXTALAMAT.Text & "', '" &
                        Format(TXTTGL.Value, "MM/dd/yyyy") & "', '" & jk & "', '" &
                        TXTNOHP.Text & "')"
                End If
            End If
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil disimpan dengan ID : " & ID)
            KONDISI_AWAL()
        End If
    End Sub

    Private Sub DGTAMPIL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellClick
        On Error Resume Next
        TXTID.Visible = True
        LBID.Visible = True
        TXTID.Text = DGTAMPIL.Item("Id", e.RowIndex).Value
    End Sub

    Private Sub BTNDELETE_Click(sender As Object, e As EventArgs) Handles BTNDELETE.Click
        If TXTID.Text = "" Then
            MsgBox("ID kosong!")
        Else
            If MsgBox("Apakah anda yakin akan menghapus karyawan?", vbYesNo) = vbYes Then
                Dim STR As String = "DELETE FROM tbl_karyawan WHERE Id='" & TXTID.Text & "'"
                Dim CMD As New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data berhasil dihapus!")
                TAMPIL()
                TXTID.Text = ""
                TXTID.Visible = False
                LBID.Visible = False
                TXTNAMA.Select()
            End If
        End If
    End Sub

    Sub KONDISI_AWAL()
        TXTID.Visible = False
        LBID.Visible = False
        TXTID.Text = ""
        TXTNAMA.Select()
        TXTNAMA.Text = ""
        TXTPASSWORD.Text = ""
        TXTALAMAT.Text = ""
        TXTNOHP.Text = ""
        TXTTGL.Value = DateTime.Now
        CBROLE.SelectedIndex = -1
        TXTJK.SelectedIndex = -1
        TXTID.Select()

        TAMPIL()
    End Sub

    Private Sub BTNREFRESH_Click(sender As Object, e As EventArgs) Handles BTNREFRESH.Click
        KONDISI_AWAL()
    End Sub

    Private Sub TXTNAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNAMA.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTPASSWORD.Select()
        End If

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z, a-z]" _
            OrElse e.KeyChar Like "[0-9]" _
            OrElse KeyAscii = Keys.Back) Then
            KeyAscii = 0
        End If

        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub TXTPASSWORD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPASSWORD.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTALAMAT.Select()
        End If

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z, a-z]" _
            OrElse e.KeyChar Like "[0-9]" _
            OrElse KeyAscii = Keys.Back) Then
            KeyAscii = 0
        End If

        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub TXTALAMAT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTALAMAT.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTTGL.Select()
        End If

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z, a-z]" _
            OrElse e.KeyChar Like "[0-9]" _
            OrElse KeyAscii = Keys.Back) Then
            KeyAscii = 0
        End If

        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub TXTTGL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTGL.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTJK.Select()
        End If
    End Sub

    Private Sub TXTJK_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTJK.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTNOHP.Select()
        End If
    End Sub

    Private Sub TXTNOHP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNOHP.KeyPress
        If e.KeyChar = Chr(13) Then
            CBROLE.Select()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CBROLE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBROLE.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If
    End Sub

    Private Sub FR_KASIR_Load(sender As Object, e As EventArgs) Handles Me.Load
        TAMPIL()
        TXTNAMA.Select()

        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True

        LBLUSER.Text = NAMA_LOGIN
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
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

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        Dim FR As New FR_LOGIN
        My.Settings.ID_ACCOUNT = 0
        FR.Show()
        Me.Close()
    End Sub
End Class