Imports System.Data.SqlClient
Public Class FR_TENTANG
    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
    End Sub

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
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

    Private Sub BTNKELUAR_Click(sender As Object, e As EventArgs) Handles BTNKELUAR.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNLAPORAN_Click(sender As Object, e As EventArgs) Handles BTNLAPORAN.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub FR_TENTANG_Load(sender As Object, e As EventArgs) Handles Me.Load
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN
        TAMPIL()
    End Sub

    Sub TAMPIL()
        Dim STR As String = "SELECT * FROM tbl_karyawan WHERE RTRIM(Id)='" & My.Settings.ID_ACCOUNT & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()

            Dim ROLE As String
            If RD.Item("Role") = 1 Then
                ROLE = "Administrator"
            Else
                ROLE = "Kasir"
            End If
            Dim JK As String
            If RD.Item("JK") = "L" Then
                JK = "Laki-laki"
            Else
                JK = "Perempuan"
            End If

            LBID.Text = RD.Item("Id").ToString.Trim
            LBNAMA.Text = RD.Item("Nama").ToString.Trim
            LBROLE.Text = ROLE
            LBALAMAT.Text = RD.Item("Alamat").ToString.Trim
            LBTGLLAHIR.Text = RD.Item("Tgl_lahir")
            LBJK.Text = JK
            LBNO.Text = RD.Item("No_hp").ToString.Trim
            RD.Close()
        Else
            RD.Close()
        End If
        RD.Close()
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        Dim PASSWORD As String
        Dim STR As String = "SELECT Password FROM tbl_karyawan WHERE RTRIM(Id)='" & My.Settings.ID_ACCOUNT & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            PASSWORD = RD.Item("Password").ToString.Trim
            RD.Close()
        Else
            RD.Close()
        End If
        RD.Close()

        If TXTPWLAMA.Text = "" Or TXTPWBARU1.Text = "" Or TXTPWBARU2.Text = "" Then
            MsgBox("Data Tidak Lengkap!")
            TXTPWLAMA.Select()
        ElseIf TXTPWBARU1.Text <> TXTPWBARU2.Text Then
            MsgBox("Konfirmasi Password Tidak Sama!")
            TXTPWBARU1.Select()
        ElseIf Not TXTPWLAMA.Text = PASSWORD Then
            MsgBox("Password Lama Salah!")
            TXTPWLAMA.Select()
        Else
            STR = "UPDATE tbl_karyawan SET Password='" & TXTPWBARU1.Text & "' WHERE Id='" & My.Settings.ID_ACCOUNT & "'"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            MsgBox("Password berhasil diubah!")
            TXTPWLAMA.Clear()
            TXTPWBARU1.Clear()
            TXTPWBARU2.Clear()
        End If
    End Sub

    Private Sub TXTPWLAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPWLAMA.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTPWBARU1.Select()
        End If
    End Sub

    Private Sub TXTPWBARU1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPWBARU1.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTPWBARU2.Select()
        End If
    End Sub

    Private Sub TXTPWBARU2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPWBARU2.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        Dim FR As New FR_MENU
        FR.Show()
        Me.Close()
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class