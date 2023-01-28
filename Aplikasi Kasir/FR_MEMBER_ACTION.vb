Imports System.Data.SqlClient

Public Class FR_MEMBER_ACTION
    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        FR_MEMBER.Enabled = True
        Me.Close()
    End Sub

    Private Sub TXTID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTID.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TXTNAMA.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTNAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNAMA.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TXTALAMAT.Select()
        End If
    End Sub

    Private Sub TXTALAMAT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTALAMAT.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TXTNOHP.Select()
        End If
    End Sub

    Private Sub TXTNOHP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNOHP.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TXTJK.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTJK_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTJK.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            BTNSIMPAN.Select()
        End If
    End Sub

    Dim CMD As SqlCommand
    Dim RD As SqlDataReader
    Dim STR As String

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If TXTID.Text = "" Or TXTNAMA.Text = "" Or TXTALAMAT.Text = "" Or TXTNOHP.Text = "" Or TXTJK.Text = "" Then
            MsgBox("Data tidak lengkap!")
        Else
            Dim jk As String = ""
            If TXTJK.Text = "Laki-laki" Then
                jk = "L"
            ElseIf TXTJK.Text = "Perempuan" Then
                jk = "P"
            End If

            If TXTID.Enabled = True Then

                STR = "SELECT * FROM tbl_member WHERE Id='" & TXTID.Text & "'"
                CMD = New SqlCommand(STR, CONN)
                RD = CMD.ExecuteReader
                If RD.HasRows Then
                    RD.Close()
                    MsgBox("Id member telah digunakan!")
                Else
                    RD.Close()

                    STR = "INSERT INTO tbl_member VALUES (" &
                            "'" & TXTID.Text & "'," &
                            "'" & TXTNAMA.Text & "'," &
                            "'" & TXTALAMAT.Text & "'," &
                            "'" & TXTNOHP.Text & "'," &
                            "'" & jk & "'," &
                            "'" & 0 & "'," &
                            "'" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                            ")"
                    CMD = New SqlCommand(STR, CONN)
                    CMD.ExecuteNonQuery()
                    MsgBox("Data member berhasil disimpan!")
                End If
            Else
                STR = "UPDATE tbl_member SET Nama='" & TXTNAMA.Text & "'," &
                    " Alamat='" & TXTALAMAT.Text & "'," &
                    " No_hp='" & TXTNOHP.Text & "'," &
                    " JK='" & jk & "'," &
                    " Modified_at='" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                    " WHERE Id='" & TXTID.Text & "'"
                CMD = New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data member berhasil diubah!")
            End If

            FR_MEMBER.Enabled = True
            FR_MEMBER.TAMPIL()
            Me.Close()
        End If
    End Sub

    Sub CARI_DATA()
        STR = "SELECT RTRIM(Id) AS 'Id'," &
            " RTRIM(Nama) AS 'Nama'," &
            " RTRIM(Alamat) AS 'Alamat'," &
            " RTRIM(No_hp) AS 'No_hp'," &
            " RTRIM(JK) AS 'JK'," &
            " Points" &
            " FROM tbl_member WHERE Id='" & TXTID.Text & "'"
        CMD = New SqlCommand(STR, CONN)
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTNAMA.Text = RD.Item("Nama")
            TXTALAMAT.Text = RD.Item("Alamat")
            TXTNOHP.Text = RD.Item("No_hp")
            If RD.Item("JK") = "L" Then
                TXTJK.SelectedIndex = 0
            Else
                TXTJK.SelectedIndex = 1
            End If
            RD.Close()
        Else
            RD.Close()
        End If
        RD.Close()
    End Sub
End Class