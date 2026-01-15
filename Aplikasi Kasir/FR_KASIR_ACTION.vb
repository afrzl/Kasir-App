Imports MySql.Data.MySqlClient

Public Class FR_KASIR_ACTION
    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        With FR_KASIR
            .Enabled = True
        End With
        Me.Close()
    End Sub

    Private Sub TXTNAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNAMA.KeyPress
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

        If e.KeyChar = "'" Then
            e.Handled = True
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
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CBROLE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBROLE.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If
    End Sub

    Sub CARI_DATA()
        Dim RD As MySqlDataReader

        Try
            Dim STR As String = "SELECT * FROM tbl_karyawan WHERE Id='" & TXTID.Text & "'"
            RD = EXECUTE_READER(STR)

            While RD.Read()
                TXTNAMA.Text = RD.GetString("Nama")
                TXTALAMAT.Text = RD.GetString("Alamat")
                TXTTGL.Value = RD.GetDateTime("Tgl_lahir")
                If RD.Item("JK") = "L" Then
                    TXTJK.Text = "Laki-laki"
                ElseIf RD.Item("JK") = "P" Then
                    TXTJK.Text = "Perempuan"
                End If
                If RD.Item("Role") = 1 Then
                    CBROLE.Text = "Administrator"
                ElseIf RD.Item("Role") = 2 Then
                    CBROLE.Text = "Operator"
                ElseIf RD.Item("Role") = 3 Then
                    CBROLE.Text = "Kasir"
                End If
                TXTNOHP.Text = RD.Item("No_hp").ToString.Trim
            End While
            RD.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            TUTUP_KONEKSI()
        End Try
    End Sub

    Private Sub FR_KASIR_ACTION_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Function AUTOID() As String
        Dim RD As MySqlDataReader
        Dim ID_AWAL As String = Format(TXTTGL.Value, "yyyyMMdd")

        Try
            Dim STR As String = "SELECT Id FROM tbl_karyawan ORDER BY Created_at DESC LIMIT 1"
            RD = EXECUTE_READER(STR)

            While RD.Read()
                If RD.HasRows() Then
                    Dim ID As Integer = Mid(RD.Item("Id"), 9, 3) + 1
                    AUTOID = ID_AWAL + Format(ID, "000")
                Else
                    AUTOID = ID_AWAL + Format(1, "000")
                End If
            End While
            RD.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            TUTUP_KONEKSI()
        End Try

    End Function

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If TXTNAMA.Text = "" Or CBROLE.Text = "" Then
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
            Dim CMD As MySqlCommand
            If TXTID.Text = "" Then
                Try
                    STR = "INSERT INTO tbl_karyawan (Id, Nama, Password, Role, Alamat, Tgl_lahir, JK, No_hp, Created_at) VALUES ('" & ID & "','" &
                    TXTNAMA.Text & "', '123456', '" & role & "', '" & TXTALAMAT.Text & "', '" &
                    Format(TXTTGL.Value, "yyyy-MM-dd") & "', '" & jk & "', '" &
                    TXTNOHP.Text & "', '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"
                    EXECUTE_NONQUERY(STR)
                    MsgBox("Data berhasil disimpan dengan ID : " & ID & " dan Password : 123456")
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
                End Try
            Else
                Try
                    STR = "SELECT * FROM tbl_karyawan WHERE Id='" & TXTID.Text & "'"
                    Dim RD As MySqlDataReader
                    RD = EXECUTE_READER(STR)

                    While RD.Read()
                        If RD.HasRows Then
                            ID = TXTID.Text
                            STR = "UPDATE tbl_karyawan SET Nama='" & TXTNAMA.Text &
                                "',Role='" & role &
                                "',Alamat='" & TXTALAMAT.Text &
                                "',Tgl_lahir='" & Format(TXTTGL.Value, "yyyy-MM-dd") &
                                "',JK='" & jk &
                                "',No_hp='" & TXTNOHP.Text &
                                "',Modified_at='" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") &
                                "' WHERE Id='" & TXTID.Text & "'"
                        Else
                            STR = "INSERT INTO tbl_karyawan (Id, Nama, Password, Role, Alamat, Tgl_lahir, JK, No_hp, Created_at) VALUES ('" & ID & "','" &
                                TXTNAMA.Text & "', '123456', '" & role & "', '" & TXTALAMAT.Text & "', '" &
                                Format(TXTTGL.Value, "yyyy-MM-dd") & "', '" & jk & "', '" &
                                TXTNOHP.Text & "', '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"
                        End If
                    End While
                    RD.Close()
                    TUTUP_KONEKSI()

                    EXECUTE_NONQUERY(STR)
                    MsgBox("ID : " & TXTID.Text & " berhasil diubah!")

                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
                End Try


            End If
            FR_KASIR.Enabled = True
            FR_KASIR.TAMPIL()
            Me.Close()
        End If
    End Sub
End Class