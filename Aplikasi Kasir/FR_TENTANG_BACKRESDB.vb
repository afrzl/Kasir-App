Imports System.Data.SqlClient

Public Class FR_TENTANG_BACKRESDB
    Dim con As SqlConnection = New SqlConnection("SERVER=" & My.Settings.SERVER & ";USER ID=" & My.Settings.USER & ";PASSWORD=" & My.Settings.PASSWORD & ";DATABASE=Master;MultipleActiveResultSets=True;")
    Dim dr As SqlDataReader

    Dim STR As String
    Dim CMD As SqlCommand
    Sub TUTUP_FORM()
        With FR_TENTANG
            .Enabled = True
        End With
        Me.Close()
    End Sub
    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        TUTUP_FORM()
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If CB_ACTION.SelectedIndex > 0 Then
            If CB_ACTION.SelectedIndex = 1 Then
                SaveFileDialog1.FileName = "TOKO_KASIR.bak"
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    CONN.Close()
                    con.Open()
                    STR = "BACKUP DATABASE TOKO_KASIR To DISK='" & SaveFileDialog1.FileName & "'"

                    Using CMD = New SqlCommand(STR, con)
                        CMD.ExecuteNonQuery()
                    End Using

                    con.Close()
                    CONN.Open()
                    MsgBox("Database berhasil dibackup!")
                    TUTUP_FORM()
                End If
            ElseIf CB_ACTION.SelectedIndex = 2 Then
                If TXTFILE.Text = "" Then
                    MsgBox("File restore tidak ditemukan!")
                    Exit Sub
                End If
                CONN.Close()
                con.Open()
                STR = "ALTER DATABASE TOKO_KASIR SET SINGLE_USER WITH ROLLBACK IMMEDIATE"
                Using CMD = New SqlCommand(STR, con)
                    CMD.ExecuteNonQuery()
                End Using
                STR = "RESTORE DATABASE TOKO_KASIR FROM DISK = '" & TXTFILE.Text & "' WITH REPLACE"

                Using CMD = New SqlCommand(STR, con)
                    CMD.ExecuteNonQuery()
                End Using

                con.Close()
                CONN.Open()
                MsgBox("Database berhasil direstore!")
                With FR_TENTANG
                    .Enabled = True
                End With
                My.Settings.ID_ACCOUNT = 0
                FR_LOGIN.Show()
                FR_TENTANG.Close()
                Me.Close()
            End If
        Else
            MsgBox("Silahkan pilih action!")
        End If
    End Sub

    Private Sub BTN_LOCATION_Click(sender As Object, e As EventArgs) Handles BTN_LOCATION.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TXTFILE.Text = OpenFileDialog1.FileName
        End If
        BTNSIMPAN.Select()
    End Sub

    Private Sub TXTNFILE_Click(sender As Object, e As EventArgs) Handles TXTFILE.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TXTFILE.Text = OpenFileDialog1.FileName
        End If
        BTNSIMPAN.Select()
    End Sub

    Private Sub CB_ACTION_SelectedValueChanged(sender As Object, e As EventArgs) Handles CB_ACTION.SelectedValueChanged
        If CB_ACTION.SelectedIndex = 2 Then
            Label2.Visible = True
            TXTFILE.Visible = True
            BTN_LOCATION.Visible = True
        Else
            Label2.Visible = False
            TXTFILE.Visible = False
            BTN_LOCATION.Visible = False
        End If
    End Sub
End Class