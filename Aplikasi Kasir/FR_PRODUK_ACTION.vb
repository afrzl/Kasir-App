Imports System.Data.SqlClient

Public Class FR_PRODUK_ACTION
    Dim CMD As SQLCOMMAND

    Private Sub TXTKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            TXTNAMA.Select()
        End If

        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTNAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNAMA.KeyPress
        If e.KeyChar = Chr(13) Then
            CBSATUAN.Select()
        End If

        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub CBSATUAN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBSATUAN.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTEND1.Select()
        End If

        Dim KeyAscii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[A-Z, a-z]" _
            OrElse e.KeyChar Like "[0-9]" _
            OrElse KeyAscii = Keys.Back) Then
            KeyAscii = 0
        End If

        e.Handled = CBool(KeyAscii)
    End Sub

    Private Sub TXTHARGA1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA1.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTEND2.Enabled = False Then
                BTNSIMPAN.Select()
            Else
                TXTEND2.Select()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTHARGA2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA2.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTEND3.Enabled = False Then
                BTNSIMPAN.Select()
            Else
                TXTEND3.Select()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTHARGA3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA3.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTEND4.Enabled = False Then
                BTNSIMPAN.Select()
            Else
                TXTEND4.Select()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTEND1_TextChanged(sender As Object, e As EventArgs) Handles TXTEND1.TextChanged
        If TXTEND1.Text = "" Or TXTEND1.Text = "0" Then
            TXTEND2.Enabled = False
            TXTEND2.Text = ""
            TXTHARGA2.Enabled = False
        Else
            If TXTEND1.Text > "0" Then
                TXTEND2.Enabled = True
                TXTHARGA2.Enabled = True
            End If
        End If
        TXTHARGA2.Text = ""
    End Sub

    Private Sub TXTEND1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTEND1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            TXTHARGA1.Select()
        End If
    End Sub

    Private Sub TXTEND2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTEND2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            TXTHARGA2.Select()
        End If
    End Sub

    Private Sub TXTEND2_TextChanged(sender As Object, e As EventArgs) Handles TXTEND2.TextChanged
        If TXTEND2.Text = "" Or TXTEND2.Text = "0" Then
            TXTEND3.Enabled = False
            TXTEND3.Text = ""
            TXTHARGA3.Enabled = False
        Else
            If TXTEND2.Text > "0" Then
                TXTEND3.Enabled = True
                TXTHARGA3.Enabled = True
            End If
        End If
        TXTHARGA3.Text = ""
    End Sub

    Private Sub TXTEND3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTEND3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            TXTHARGA3.Select()
        End If
    End Sub

    Private Sub TXTEND4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTEND4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            TXTHARGA4.Select()
        End If
    End Sub

    Private Sub TXTEND3_TextChanged(sender As Object, e As EventArgs) Handles TXTEND3.TextChanged
        If TXTEND3.Text = "" Or TXTEND3.Text = "0" Then
            TXTEND4.Enabled = False
            TXTEND4.Text = ""
            TXTHARGA4.Enabled = False
        Else
            If TXTEND3.Text > "0" Then
                TXTHARGA4.Enabled = True
                TXTEND4.Enabled = True
            End If
        End If
        TXTHARGA4.Text = ""
    End Sub

    Private Sub TXTEND4_TextChanged(sender As Object, e As EventArgs) Handles TXTEND4.TextChanged
        If TXTEND4.Text = "" Or TXTEND4.Text = "0" Then
            TXTEND5.Text = ""
            TXTHARGA5.Enabled = False
        ElseIf TXTEND4.Text > "0" Then
            TXTEND5.Text = TXTEND4.Text
            TXTHARGA5.Enabled = True
        End If
    End Sub

    Private Sub TXTHARGA4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA4.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTEND4.Text = "" Then
                BTNSIMPAN.Select()
            Else
                TXTHARGA5.Select()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTHARGA5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGA5.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTEND2_Leave(sender As Object, e As EventArgs) Handles TXTEND2.Leave
        If TXTEND2.Text <> "" Then
            If Convert.ToDouble(TXTEND2.Text) <= Convert.ToDouble(TXTEND1.Text) Then
                TXTEND2.Clear()
                MsgBox("Item harus lebih besar dari sebelumnya!")
                TXTEND2.Select()
            Else
                TXTHARGA2.Select()
            End If
        Else
            TXTHARGA2.Select()
        End If
    End Sub

    Private Sub TXTEND3_Leave(sender As Object, e As EventArgs) Handles TXTEND3.Leave
        If TXTEND3.Text <> "" Then
            If Convert.ToDouble(TXTEND3.Text) <= Convert.ToDouble(TXTEND2.Text) Then
                TXTEND3.Clear()
                MsgBox("Item harus lebih besar dari sebelumnya!")
                TXTEND3.Select()
            Else
                TXTHARGA3.Select()
            End If
        Else
            TXTHARGA3.Select()
        End If
    End Sub

    Private Sub TXTEND4_Leave(sender As Object, e As EventArgs) Handles TXTEND4.Leave
        If TXTEND4.Text <> "" Then
            If Convert.ToDouble(TXTEND4.Text) <= Convert.ToDouble(TXTEND3.Text) Then
                TXTEND4.Clear()
                MsgBox("Item harus lebih besar dari sebelumnya!")
                TXTEND4.Select()
            Else
                TXTHARGA4.Select()
            End If
        Else
            TXTHARGA4.Select()
        End If
    End Sub

    Private Sub TXTEND1_Leave(sender As Object, e As EventArgs) Handles TXTEND1.Leave
        If TXTEND1.Text <> "" Then
            If Convert.ToDouble(TXTEND1.Text) <= 0 Then
                TXTEND1.Clear()
                MsgBox("Item harus lebih besar dari 0!")
            Else
                TXTHARGA1.Select()
            End If
        Else
            TXTHARGA1.Select()
        End If
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If TXTKODE.Text = "" Or TXTNAMA.Text = "" Or CBSATUAN.Text = "" Then
            MsgBox("Isikan data secara lengkap!")
            TXTKODE.Select()
        Else
            If (TXTHARGA1.Enabled = True And TXTHARGA1.Text = "") Or (TXTHARGA2.Enabled = True And TXTHARGA2.Text = "") Or (TXTHARGA3.Enabled = True And TXTHARGA3.Text = "") Or (TXTHARGA4.Enabled = True And TXTHARGA4.Text = "") Or (TXTHARGA5.Enabled = True And TXTHARGA5.Text = "") Then
                MsgBox("Isikan data secara lengkap!")
            Else
                Dim END1 As Double = 0
                Dim END2 As Double = 0
                Dim END3 As Double = 0
                Dim END4 As Double = 0

                If Not TXTEND1.Text = "" Then
                    END1 = Convert.ToDouble(TXTEND1.Text)
                End If
                If Not TXTEND2.Text = "" Then
                    END2 = Convert.ToDouble(TXTEND2.Text)
                End If
                If Not TXTEND3.Text = "" Then
                    END3 = Convert.ToDouble(TXTEND3.Text)
                End If
                If Not TXTEND4.Text = "" Then
                    END4 = Convert.ToDouble(TXTEND4.Text)
                End If

                Dim STR As String
                Dim CMD As SqlCommand


                If TXTKODE.Enabled = False Then
                    STR = "UPDATE tbl_barang SET Barang='" & TXTNAMA.Text & "'," &
                    "Satuan='" & CBSATUAN.Text & "'," &
                    "Harga1='" & TXTHARGA1.Text & "'," &
                    "End1=" & END1.ToString.Replace(",", ".") & "," &
                    "Harga2='" & TXTHARGA2.Text & "'," &
                    "End2=" & END2.ToString.Replace(",", ".") & "," &
                    "Harga3='" & TXTHARGA3.Text & "'," &
                    "End3=" & END3.ToString.Replace(",", ".") & "," &
                    "Harga4='" & TXTHARGA4.Text & "'," &
                    "End4=" & END4.ToString.Replace(",", ".") & "," &
                    "Harga5='" & TXTHARGA5.Text & "'," &
                    "Modified_at='" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                    "WHERE Kode='" & TXTKODE.Text & "'"
                    CMD = New SqlCommand(STR, CONN)
                    CMD.ExecuteNonQuery()
                    MsgBox("Data produk berhasil diubah.")
                    With FR_PRODUK
                        .Enabled = True
                        .TAMPIL()
                    End With
                    Me.Close()
                Else
                    STR = "SELECT * FROM tbl_barang WHERE Kode='" & TXTKODE.Text & "'"
                    CMD = New SqlCommand(STR, CONN)
                    Dim RD As SqlDataReader
                    RD = CMD.ExecuteReader
                    If RD.HasRows Then
                        RD.Close()
                        MsgBox("Kode produk telah digunakan.")
                        TXTKODE.Select()
                    Else
                        RD.Close()
                        STR = "INSERT INTO tbl_barang" &
                            " (Kode, Barang, Satuan, Harga1, End1, Harga2, End2, Harga3, End3, Harga4, End4, Harga5, Created_at)" &
                            " VALUES (" &
                            "'" & TXTKODE.Text & "'," &
                            "'" & TXTNAMA.Text & "'," &
                            "'" & CBSATUAN.Text & "'," &
                            "'" & TXTHARGA1.Text & "'," &
                            END1.ToString.Replace(",", ".") & "," &
                            "'" & TXTHARGA2.Text & "'," &
                            END2.ToString.Replace(",", ".") & "," &
                            "'" & TXTHARGA3.Text & "'," &
                            END3.ToString.Replace(",", ".") & "," &
                            "'" & TXTHARGA4.Text & "'," &
                            END4.ToString.Replace(",", ".") & "," &
                            "'" & TXTHARGA5.Text & "'," &
                            "'" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                            ")"
                        CMD = New SqlCommand(STR, CONN)
                        CMD.ExecuteNonQuery()

                        STR = "INSERT INTO tbl_stok" &
                            " (Kode, Stok, Created_at)" &
                            " VALUES (" &
                            "'" & TXTKODE.Text & "'," &
                            "0, " &
                            "'" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                            ")"
                        CMD = New SqlCommand(STR, CONN)
                        CMD.ExecuteNonQuery()
                        MsgBox("Data produk berhasil disimpan.")
                        With FR_PRODUK
                            .Enabled = True
                            .TAMPIL()
                        End With
                        Me.Close()
                    End If
                    RD.Close()
                End If
            End If
        End If
    End Sub

    Sub CARI_PRODUK()
        Dim STR As String = "SELECT * FROM tbl_barang WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTNAMA.Enabled = True
            TXTEND1.Enabled = True
            TXTHARGA1.Enabled = True
            Dim END1 As String = ""
            If Not RD.Item("End1") = 0 Then
                END1 = Format(RD.Item("End1"), "##0.##")
            End If
            Dim END2 As String = ""
            If Not RD.Item("End2") = 0 Then
                END2 = Format(RD.Item("End2"), "##0.##")
            Else
                TXTEND2.Enabled = False
            End If
            Dim END3 As String = ""
            If Not RD.Item("End3") = 0 Then
                END3 = Format(RD.Item("End3"), "##0.##")
            Else
                TXTEND3.Enabled = False
            End If
            Dim END4 As String = ""
            If Not RD.Item("End4") = 0 Then
                END4 = Format(RD.Item("End4"), "##0.##")
            Else
                TXTEND4.Enabled = False
            End If

            TXTNAMA.Text = RD.Item("Barang").ToString.Trim
            CBSATUAN.Text = RD.Item("Satuan").ToString.Trim
            TXTHARGA1.Text = CInt(RD.Item("Harga1"))
            TXTEND1.Text = END1
            TXTHARGA2.Text = CInt(RD.Item("Harga2"))
            TXTEND2.Text = END2
            TXTHARGA3.Text = CInt(RD.Item("Harga3"))
            TXTEND3.Text = END3
            TXTHARGA4.Text = CInt(RD.Item("Harga4"))
            TXTEND4.Text = END4
            TXTHARGA5.Text = CInt(RD.Item("Harga5"))
            RD.Close()

            'TXTKODE.Enabled = False
            'TXTNAMA.Enabled = False
            CBSATUAN.DropDownStyle = ComboBoxStyle.DropDownList
            'TXTEND1.Enabled = False
            'TXTHARGA1.Enabled = False
            'TXTHARGA2.Enabled = False
            'TXTEND2.Enabled = False
            'TXTHARGA3.Enabled = False
            'TXTEND3.Enabled = False
            'TXTHARGA4.Enabled = False
            'TXTEND4.Enabled = False
            'TXTHARGA5.Enabled = False
            'BTNSIMPAN.Visible = False
            'BTNCANCEL.Visible = True
            'BTNUBAH.Visible = True
            'CBSATUAN.Enabled = False
        Else
            RD.Close()
        End If
        RD.Close()
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        FR_PRODUK.Enabled = True
        Me.Close()
    End Sub
End Class