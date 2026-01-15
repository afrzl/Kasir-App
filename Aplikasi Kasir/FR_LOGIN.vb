Imports System.Web.Services.Description
Imports MySql.Data.MySqlClient
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
            Try
                BUKA_KONEKSI()

                Dim STR As String = "SELECT COUNT(*) FROM tbl_karyawan WHERE Id='" & TXTID.Text & "' AND Password='" & TXTPASSWORD.Text & "'"
                If EXECUTE_SCALAR(STR) > 0 Then

                    STR = "SELECT RTRIM(Nama) AS Nama, RTRIM(Role) AS Role FROM tbl_karyawan WHERE Id='" & TXTID.Text & "' AND Password='" & TXTPASSWORD.Text & "'"
                    Dim RD As MySqlDataReader
                    RD = EXECUTE_READER(STR)
                    While RD.Read()
                        If RD.Item("Role") = 1 Then
                                My.Settings.ID_ACCOUNT = TXTID.Text
                                NAMA_LOGIN = RD.Item("Nama").ToString.Trim
                                ROLE = RD.Item("Role")
                            ElseIf RD.Item("Role") = 2 Then
                                My.Settings.ID_ACCOUNT = TXTID.Text
                                NAMA_LOGIN = RD.Item("Nama").ToString.Trim
                                ROLE = RD.Item("Role")
                            ElseIf RD.Item("Role") = 3 Then
                                My.Settings.ID_ACCOUNT = TXTID.Text
                                NAMA_LOGIN = RD.Item("Nama").ToString.Trim
                                ROLE = RD.Item("Role")
                            End If
                    End While
                    RD.Close()
                Else
                    MsgBox("Id / password yang anda masukkan salah!")
                    TXTID.Clear()
                    TXTPASSWORD.Clear()
                    TXTID.Select()
                End If
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                TUTUP_KONEKSI()
                If ROLE = 1 Then
                    Dim FR As New FR_MENU
                    FR.Show()
                    Me.Hide()
                ElseIf ROLE = 2 Then
                    Dim FR As New FR_OPS_DASHBOARD
                    FR.Show()
                    Me.Hide()
                ElseIf ROLE = 3 Then
                    Dim FR As New FR_KASIR_DASHBOARD
                    FR.Show()
                    Me.Hide()
                End If
            End Try
        End If
    End Sub

    Private Sub FR_LOGIN_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            KONEKAN()
        Catch ex As Exception
            ' Jika gagal baru cek settings
            If My.Settings.SERVER = "" Or My.Settings.USER = "" Or My.Settings.PASSWORD = "" Or My.Settings.DATABASE = "" Then
                MsgBox("Database belum terhubung!")
                Dim FR As New FR_KONEKSI
                FR.ShowDialog()
            Else
                MsgBox("Error koneksi: " & ex.Message)
            End If
        End Try

        TXTID.Clear()
        TXTPASSWORD.Clear()
        TXTID.Select()
    End Sub

    Private Sub TXTUSER_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TXTPASSWORD.Select()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <="9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub


    Private Sub TXTID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTID.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TXTPASSWORD.Select()
        End If
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTPASSWORD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPASSWORD.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            BTNLOGIN.Select()
        End If
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        End
    End Sub
End Class