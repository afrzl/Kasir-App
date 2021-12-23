Imports System.Data.SqlClient
Public Class FR_LOGIN
    Private Sub BTNLOGIN_Click(sender As Object, e As EventArgs) Handles BTNLOGIN.Click
        If TXTID.Text = "" Then
            MsgBox("ID akun harus diisi!")
            TXTID.Select()
        ElseIf TXTPASSWORD.Text = "" Then
            MsgBox("Password harus diisi!")
            TXTPASSWORD.Select()
        ElseIf TXTID.Text = "0000" And TXTPASSWORD.Text = "0000" Then
            With My.Settings
                .SERVER = ""
                .USER = ""
                .PASSWORD = ""
                .DATABASE = ""
                .Save()
            End With
            Dim FR As New FR_KONEKSI
            FR.Show()
            Me.Hide()
        Else
            Dim STR As String = "SELECT RTRIM(Nama) AS Nama, RTRIM(Role) AS Role FROM tbl_karyawan WHERE Id='" & TXTID.Text & "' AND Password='" & TXTPASSWORD.Text & "'"
            Dim CMD As SqlCommand
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Read()
                If RD.Item("Role") = 1 Then
                    My.Settings.ID_ACCOUNT = TXTID.Text
                    NAMA_LOGIN = RD.Item("Nama").ToString.Trim
                    ROLE = RD.Item("Role")
                    RD.Close()

                    Dim FR As New FR_MENU
                    FR.Show()
                    Me.Hide()
                ElseIf RD.Item("Role") = 2 Then
                    My.Settings.ID_ACCOUNT = TXTID.Text
                    NAMA_LOGIN = RD.Item("Nama").ToString.Trim
                    ROLE = RD.Item("Role")
                    RD.Close()

                    Dim FR As New FR_OPS_DASHBOARD
                    FR.Show()
                    Me.Hide()
                ElseIf RD.Item("Role") = 3 Then
                    My.Settings.ID_ACCOUNT = TXTID.Text
                    NAMA_LOGIN = RD.Item("Nama").ToString.Trim
                    ROLE = RD.Item("Role")
                    RD.Close()

                    Dim FR As New FR_KASIR_DASHBOARD
                    FR.Show()
                    Me.Hide()
                End If
                RD.Close()
            Else
                RD.Close()
                MsgBox("Id / password yang anda masukkan salah!")
                TXTID.Clear()
                TXTPASSWORD.Clear()
                TXTID.Select()
            End If
            RD.Close()
        End If
    End Sub

    Private Sub FR_LOGIN_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Settings.SERVER = "" Or My.Settings.USER = "" Or My.Settings.PASSWORD = "" Or My.Settings.DATABASE = "" Then
            MsgBox("Database belum terhubung!")
            Dim FR As New FR_KONEKSI
            FR.ShowDialog()
        Else
            KONEKAN()
        End If

        TXTID.Clear()
        TXTPASSWORD.Clear()
        TXTID.Select()
    End Sub

    Private Sub TXTUSER_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            TXTPASSWORD.Select()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub


    Private Sub TXTID_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles TXTID.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTPASSWORD.Select()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTPASSWORD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPASSWORD.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNLOGIN.Select()
        End If
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        End
    End Sub
End Class