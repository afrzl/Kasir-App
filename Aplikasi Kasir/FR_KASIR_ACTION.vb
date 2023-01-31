Imports System.Data.SqlClient

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
                CBROLE.Text = "Operator"
            ElseIf RD.Item("Role") = 3 Then
                CBROLE.Text = "Kasir"
            End If
            TXTNOHP.Text = RD.Item("No_hp").ToString.Trim
            RD.Close()
        Else
            RD.Close()
            TXTNAMA.Clear()
            TXTALAMAT.Clear()
            TXTNOHP.Clear()
            TXTNAMA.Select()
        End If
        RD.Close()
    End Sub

    Private Sub FR_KASIR_ACTION_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Function AUTOID() As String
        Dim ID_AWAL As String = Format(TXTTGL.Value, "yyyyMMdd")
        Dim STR As String = "SELECT TOP 1 Id FROM tbl_karyawan ORDER BY Auto_id DESC"
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
            Dim CMD As SqlCommand
            If TXTID.Text = "" Then
                STR = "INSERT INTO tbl_karyawan (Id, Nama, Password, Role, Alamat, Tgl_lahir, JK, No_hp, Created_at) VALUES ('" & ID & "','" &
                    TXTNAMA.Text & "', '123456', '" & role & "', '" & TXTALAMAT.Text & "', '" &
                    Format(TXTTGL.Value, "MM/dd/yyyy") & "', '" & jk & "', '" &
                    TXTNOHP.Text & "', '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "')"
                CMD = New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data berhasil disimpan dengan ID : " & ID & " dan Password : 123456")
            Else
                STR = "SELECT * FROM tbl_karyawan WHERE Id='" & TXTID.Text & "'"
                CMD = New SqlCommand(STR, CONN)
                Dim RD As SqlDataReader
                RD = CMD.ExecuteReader
                If RD.HasRows Then
                    RD.Close()
                    ID = TXTID.Text
                    STR = "UPDATE tbl_karyawan SET Nama='" & TXTNAMA.Text &
                        "',Role='" & role &
                        "',Alamat='" & TXTALAMAT.Text &
                        "',Tgl_lahir='" & Format(TXTTGL.Value, "MM/dd/yyyy") &
                        "',JK='" & jk &
                        "',No_hp='" & TXTNOHP.Text &
                        "',Modified_at='" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") &
                        "' WHERE Id='" & TXTID.Text & "'"
                Else
                    RD.Close()
                    STR = "INSERT INTO tbl_karyawan (Id, Nama, Password, Role, Alamat, Tgl_lahir, JK, No_hp, Created_at) VALUES ('" & ID & "','" &
                        TXTNAMA.Text & "', '123456', '" & role & "', '" & TXTALAMAT.Text & "', '" &
                        Format(TXTTGL.Value, "MM/dd/yyyy") & "', '" & jk & "', '" &
                        TXTNOHP.Text & "', '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "')"
                End If
                CMD = New SqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("ID : " & TXTID.Text & " berhasil diubah!")
            End If
            FR_KASIR.Enabled = True
            FR_KASIR.TAMPIL()
            Me.Close()
        End If
    End Sub
End Class