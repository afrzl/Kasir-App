Imports MySql.Data.MySqlClient

Public Class FR_MASUK_HISTORY
    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        If FR_MASUK.Enabled = False Then
            FR_MASUK.Enabled = True
        ElseIf FR_RUSAK.Enabled = False Then
            FR_RUSAK.Enabled = True
            FR_RUSAK.TAMPIL_EXPIRED()
        End If
        Me.Close()
    End Sub

    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 13
    Dim TOTAL_RECORD As Integer = 0

    Private Sub TXTCARI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        ElseIf e.KeyChar = Chr(13) Then
            START_RECORD = 0
            TAMPIL()
        End If
    End Sub

    Private Sub TXTCARI_Leave(sender As Object, e As EventArgs) Handles TXTCARI.Leave
        START_RECORD = 0
        TAMPIL()
    End Sub

    Sub TAMPIL()
        DGHISTORY.Columns.Clear()

        Dim STR As String
        Select Case ROLE
            Case 1
                If CBTAMPIL.SelectedIndex = 0 Then
                    If TXTCARI.Text = "" Then
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                        " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                        " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                        " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                        " Jumlah as 'Stok Masuk'," &
                        " Harga AS 'Harga Partai'," &
                        " Stok AS 'Stok Sisa'" &
                        " FROM tbl_transaksi_child" &
                        " LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode=tbl_barang.Kode" &
                        " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                        " ORDER BY Id DESC" &
                        " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                        " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                        " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                        " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                        " Jumlah as 'Stok Masuk'," &
                        " Harga AS 'Harga Partai'," &
                        " Stok AS 'Stok Sisa'" &
                        " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode=tbl_barang.Kode" &
                        " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                        " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                        " ORDER BY Id DESC" &
                        " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                ElseIf CBTAMPIL.SelectedIndex = 1 Then
                    If TXTCARI.Text = "" Then
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                            " Jumlah as 'Stok Masuk'," &
                            " Harga AS 'Harga Partai'," &
                            " Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok != 0" &
                            " ORDER BY Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                            " Jumlah as 'Stok Masuk'," &
                            " Harga AS 'Harga Partai'," &
                            " Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " AND Stok != 0" &
                            " ORDER BY Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                ElseIf CBTAMPIL.SelectedIndex = 2 Then
                    If TXTCARI.Text = "" Then
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                            " Jumlah as 'Stok Masuk'," &
                            " Harga AS 'Harga Partai'," &
                            " Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok = 0" &
                            " ORDER BY Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                            " Jumlah as 'Stok Masuk'," &
                            " Harga AS 'Harga Partai'," &
                            " Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " AND Stok = 0" &
                            " ORDER BY Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                Else
                    If TXTCARI.Text = "" Then
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                        " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                        " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                        " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                        " Jumlah as 'Stok Masuk'," &
                        " Harga AS 'Harga Partai'," &
                        " Stok AS 'Stok Sisa'" &
                        " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                        " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                        " ORDER BY Id DESC" &
                        " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                        " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                        " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                        " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                        " Jumlah as 'Stok Masuk'," &
                        " Harga AS 'Harga Partai'," &
                        " Stok AS 'Stok Sisa'" &
                        " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                        " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                        " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                        " ORDER BY Id DESC" &
                        " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                End If
            Case 2
                If CBTAMPIL.SelectedIndex = 0 Then
                    If TXTCARI.Text = "" Then
                        STR = "SELECT tbl_transaksi_child.Id, RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " tbl_transaksi_parent.Id_kasir = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                ElseIf CBTAMPIL.SelectedIndex = 1 Then
                    If TXTCARI.Text = "" Then
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok != 0" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok != 0" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                ElseIf CBTAMPIL.SelectedIndex = 2 Then
                    If TXTCARI.Text = "" Then
                        STR = "SELECT tbl_transaksi_child.Id," &
                                " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                                " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                                " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                                " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                                " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                                " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                                " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                                " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                                " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                                " AND Stok = 0" &
                                " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                                " ORDER BY tbl_transaksi_child.Id DESC" &
                                " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                                " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                                " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                                " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                                " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                                " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                                " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                                " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                                " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                                " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                                " AND Stok = 0" &
                                " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                                " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                                " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                                " ORDER BY tbl_transaksi_child.Id DESC" &
                                " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                Else
                    If TXTCARI.Text = "" Then
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                End If
            Case 3
                If CBTAMPIL.SelectedIndex = 0 Then
                    If TXTCARI.Text = "" Then
                        STR = "SELECT tbl_transaksi_child.Id, RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " tbl_transaksi_parent.Id_kasir = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                ElseIf CBTAMPIL.SelectedIndex = 1 Then
                    If TXTCARI.Text = "" Then
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok != 0" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok != 0" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                ElseIf CBTAMPIL.SelectedIndex = 2 Then
                    If TXTCARI.Text = "" Then
                        STR = "SELECT tbl_transaksi_child.Id," &
                                " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                                " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                                " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                                " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                                " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                                " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                                " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                                " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                                " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                                " AND Stok = 0" &
                                " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                                " ORDER BY tbl_transaksi_child.Id DESC" &
                                " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                                " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                                " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                                " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                                " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                                " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                                " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                                " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                                " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                                " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                                " AND Stok = 0" &
                                " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                                " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                                " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                                " ORDER BY tbl_transaksi_child.Id DESC" &
                                " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                Else
                    If TXTCARI.Text = "" Then
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child LEFT JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " LEFT JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_transaksi_child.Id_trans) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " LIMIT " & TAMPIL_RECORD & " OFFSET " & START_RECORD
                    End If
                End If
        End Select
        Dim DA As MySqlDataAdapter
        Dim TBL As New DataSet
        DA = New MySqlDataAdapter(STR, CONN)
        DA.Fill(TBL)
        DGHISTORY.DataSource = TBL.Tables(0)

        DGHISTORY.Columns(0).Visible = False

        DGHISTORY.Columns(5).DefaultCellStyle.Format = "##0.##"
        DGHISTORY.Columns(6).DefaultCellStyle.Format = "Rp ###,##"
        DGHISTORY.Columns(7).DefaultCellStyle.Format = "##0.##"

        DGHISTORY.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGHISTORY.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGHISTORY.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGHISTORY.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGHISTORY.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGHISTORY.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGHISTORY.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGHISTORY.Columns("Stok Masuk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGHISTORY.Columns("Stok Sisa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim Column_delete = New DataGridViewButtonColumn
        With Column_delete
            .Text = "Delete"
            .HeaderText = "Delete"
            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .CellTemplate.Style.BackColor = Color.Crimson
            .CellTemplate.Style.ForeColor = Color.WhiteSmoke
            .Width = 100
        End With
        DGHISTORY.Columns.Add(Column_delete)
        DGHISTORY.Columns(8).Width = 50

        Dim Column_pecah = New DataGridViewButtonColumn
        With Column_pecah
            .Text = "Bongkar"
            .HeaderText = "Bongkar"
            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .CellTemplate.Style.BackColor = Color.DarkGreen
            .CellTemplate.Style.ForeColor = Color.WhiteSmoke
            .Width = 100
        End With
        DGHISTORY.Columns.Add(Column_pecah)
        DGHISTORY.Columns(8).Width = 50

        BTNPREV.Enabled = True
        BTNNEXT.Enabled = True

        'Dim TBL_DATA As New DataTable
        'DA = New MySqlDataAdapter(STR, CONN)
        'DA.Fill(TBL_DATA)

        'If TOTAL_RECORD = 0 Then
        '    BTNPREV.Enabled = False
        '    BTNNEXT.Enabled = False

        If DGHISTORY.Rows.Count > 0 Then
            BTNNEXT.Enabled = True
        Else
            BTNNEXT.Enabled = False
        End If

        If START_RECORD = 0 Then
            BTNPREV.Enabled = False
        Else
            BTNPREV.Enabled = True
        End If
        'ElseIf TOTAL_RECORD <= START_RECORD Then
        '    BTNNEXT.Enabled = False
        'ElseIf TOTAL_RECORD - START_RECORD <= TAMPIL_RECORD Then
        '    BTNNEXT.Enabled = False
        'Else
        '    BTNPREV.Enabled = True
        '    BTNNEXT.Enabled = True
        'End If
    End Sub

    Private Sub FR_MASUK_HISTORY_Load(sender As Object, e As EventArgs) Handles Me.Load
        CBTAMPIL.SelectedIndex = 1
        TAMPIL()
    End Sub

    Private Sub BTNNEXT_Click(sender As Object, e As EventArgs) Handles BTNNEXT.Click
        START_RECORD = START_RECORD + TAMPIL_RECORD
        TAMPIL()
    End Sub

    Private Sub BTNPREV_Click(sender As Object, e As EventArgs) Handles BTNPREV.Click
        START_RECORD = START_RECORD - TAMPIL_RECORD
        TAMPIL()
    End Sub

    Private Sub CBTAMPIL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBTAMPIL.SelectedIndexChanged
        TAMPIL()
    End Sub

    Private Sub DGHISTORY_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGHISTORY.CellClick
        On Error Resume Next

        If e.RowIndex >= 0 Then
            If DGHISTORY.Columns(e.ColumnIndex).HeaderText = "Delete" Then
                If MsgBox("Apakah anda yakin akan menghapus data transaksi?", vbYesNo) = vbYes Then
                    DGHISTORY.Columns(0).Visible = False
                    Dim IDX As String = DGHISTORY.Item(0, DGHISTORY.CurrentRow.Index).Value
                    Dim IDTrans As String = DGHISTORY.Item(1, DGHISTORY.CurrentRow.Index).Value
                    Dim CMD As New MySqlCommand("DELETE FROM tbl_transaksi_child WHERE Id='" & IDX & "'", CONN)
                    CMD.ExecuteNonQuery()
                    CMD = New MySqlCommand("UPDATE tbl_stok SET Stok = Stok - " & DGHISTORY.Item(7, DGHISTORY.CurrentRow.Index).Value.ToString.Replace(",", ".") & ", " &
                                         " Modified_at = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                                         " WHERE Kode='" & DGHISTORY.Item(2, DGHISTORY.CurrentRow.Index).Value & "'", CONN)
                    CMD.ExecuteNonQuery()

                    Dim STR As String = "SELECT * FROM tbl_transaksi_child WHERE RTRIM(Id_trans)='" & IDTrans & "'"
                    CMD = New MySqlCommand(STR, CONN)
                    Dim RD As MySqlDataReader
                    RD = CMD.ExecuteReader
                    If Not RD.HasRows Then
                        RD.Close()
                        CMD = New MySqlCommand("DELETE FROM tbl_transaksi_parent WHERE Id_trans='" & IDTrans & "'", CONN)
                        CMD.ExecuteNonQuery()
                    End If
                    RD.Close()

                    TAMPIL()
                    MsgBox("Data transaksi berhasil dihapus")
                End If
            ElseIf DGHISTORY.Columns(e.ColumnIndex).HeaderText = "Bongkar" Then
                With FR_MASUK_BONGKAR
                    .TXT_IDBRG.Text = DGHISTORY.Item(0, DGHISTORY.CurrentRow.Index).Value
                    .Show()
                    .TXT_JML.Select()
                End With
                Me.Enabled = False
            End If
        End If
    End Sub

    Private Sub DGHISTORY_SelectionChanged(sender As Object, e As EventArgs) Handles DGHISTORY.SelectionChanged
        DGHISTORY.ClearSelection()
    End Sub
End Class