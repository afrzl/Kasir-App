Imports System.Data.SqlClient
Public Class FR_KASIR
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy H:m:s")
    End Sub

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Hide()
    End Sub

    Sub TAMPIL()
        Dim STR As String = "SELECT Id as ID,RTRIM(Nama) AS 'Nama Lengkap',RTRIM(Alamat) AS Alamat," &
            " Tgl_lahir as 'Tanggal Lahir',JK as 'Jenis Kelamin',RTRIM(No_hp) AS 'Nomor HP', Role AS 'Hak Akses'" &
            " FROM tbl_karyawan WHERE Nama Like '%" & TXTCARI.Text & "%'"
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
    End Sub

    Private Function AUTOID() As String
        Dim ID_AWAL As String = Format(Date.Now, "yyyyMM")
        Dim ID_AKHIR As String = ""
        Dim STR As String = "SELECT MAX(Id) AS Id FROM tbl_karyawan"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        RD.Read()
        If Not IsDBNull(RD.Item("Id")) Then
            Dim ID As Integer = Mid(RD.Item("Id"), 7, 6) + 1
            RD.Close()
            AUTOID = ID_AWAL + Format(ID, "000000")
        Else
            RD.Close()
            AUTOID = ID_AWAL + Format(1, "000000")
        End If
        RD.Close()
    End Function

    Private Sub BTNEXIT_Click(sender As Object, e As EventArgs)
        Dim FR As New FR_LOGIN
        My.Settings.ID_ACCOUNT = 0
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub BTNBARANG_Click(sender As Object, e As EventArgs) Handles BTNBARANG.Click
        BUKA_FORM(FR_PRODUK)
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
            If RD.Item("Role") = "1" Then
                CBROLE.Text = "Admin"
            ElseIf RD.Item("Role") = "2" Then
                CBROLE.Text = "Kasir"
            End If
            TXTNOHP.Text = RD.Item("No_hp").ToString.Trim
            RD.Close()
        Else
            RD.Close()
            TXTNAMA.Clear()
            TXTPASSWORD.Clear()
            TXTALAMAT.Clear()
            TXTNOHP.Clear()
            TXTNAMA.Select()
        End If
        RD.Close()
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If TXTID.Text = "" Or TXTNAMA.Text = "" Or CBROLE.Text = "" Or TXTPASSWORD.Text = "" Then
            MsgBox("ID, nama, password, dan hak akses wajib diisi!")
        Else
            Dim jk As String = ""
            If TXTJK.Text = "Laki-laki" Then
                jk = "L"
            ElseIf TXTJK.Text = "Perempuan" Then
                jk = "P"
            End If

            Dim role As Integer
            If CBROLE.Text = "Admin" Then
                role = 1
            ElseIf CBROLE.Text = "Kasir" Then
                role = 2
            End If
            Dim STR As String = "SELECT * FROM tbl_karyawan WHERE Id='" & TXTID.Text & "'"
            Dim CMD As SqlCommand
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Close()
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
                STR = "INSERT INTO tbl_karyawan VALUES ('" & TXTID.Text & "','" &
                    TXTNAMA.Text & "', '" & TXTPASSWORD.Text & "', '" & role & "', '" & TXTALAMAT.Text & "', '" &
                    Format(TXTTGL.Value, "MM/dd/yyyy") & "', '" & jk & "', '" &
                    TXTNOHP.Text & "')"
            End If
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil disimpan.")
            TXTID.Text = AUTOID()
            TAMPIL()
        End If
    End Sub

    Private Sub DGTAMPIL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellClick
        On Error Resume Next
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
                TAMPIL()
                TXTID.Text = AUTOID()
            End If
        End If
    End Sub

    Private Sub BTNREFRESH_Click(sender As Object, e As EventArgs) Handles BTNREFRESH.Click
        TXTID.Text = AUTOID()
        TXTNAMA.Text = ""
        TXTPASSWORD.Text = ""
        TXTALAMAT.Text = ""
        TXTNOHP.Text = ""
    End Sub

    Private Sub TXTNAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNAMA.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTPASSWORD.Select()
        End If
    End Sub

    Private Sub TXTPASSWORD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPASSWORD.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTALAMAT.Select()
        End If
    End Sub

    Private Sub TXTALAMAT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTALAMAT.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTTGL.Select()
        End If
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
    End Sub

    Private Sub CBROLE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBROLE.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If
    End Sub

    Private Sub FR_KASIR_Load(sender As Object, e As EventArgs) Handles Me.Load
        TAMPIL()
        TXTID.Text = AUTOID()

        TXTNAMA.Select()

        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:MM:SS")
        PEWAKTU.Enabled = True

        LBLUSER.Text = NAMA_LOGIN
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class