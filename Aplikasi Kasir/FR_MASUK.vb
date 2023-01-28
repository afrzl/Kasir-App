Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO

Public Class FR_MASUK

    Dim ID_TRANSAKSI As String
    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        If MsgBox("Apakah anda yakin akan logout?", vbYesNo) = vbYes Then
            Dim FR As New FR_LOGIN
            My.Settings.ID_ACCOUNT = 0
            FR.Show()
            Me.Close()
        End If
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        Select Case ROLE
            Case 1
                BUKA_FORM(FR_MENU)
            Case 2
                BUKA_FORM(FR_OPS_DASHBOARD)
        End Select
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub FR_MASUK_Load(sender As Object, e As EventArgs) Handles Me.Load
        ALAMATTOKO.Text = ALAMAT_TOKO
        Select Case ROLE
            Case 1
                PNADMIN.Visible = True
                PNOPS.Visible = False
                PNKASIR.Visible = False
                Label3.Text = "Administrator"
            Case 2
                PNADMIN.Visible = False
                PNOPS.Visible = True
                PNKASIR.Visible = False
                Label3.Text = "Operator"
            Case 3
                PNADMIN.Visible = False
                PNOPS.Visible = False
                PNKASIR.Visible = True
                Label3.Text = "Kasir"
        End Select

        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN
        CBJENISEXP.SelectedIndex = 0

        TXTSUPPLIER.Select()
    End Sub

    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 18
    Dim TOTAL_RECORD As Integer = 0

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
                        " INNER JOIN tbl_barang ON tbl_transaksi_child.Kode=tbl_barang.Kode" &
                        " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                        " ORDER BY Id DESC" &
                        " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                        " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                        " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                        " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                        " Jumlah as 'Stok Masuk'," &
                        " Harga AS 'Harga Partai'," &
                        " Stok AS 'Stok Sisa'" &
                        " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode=tbl_barang.Kode" &
                        " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                        " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                        " ORDER BY Id DESC" &
                        " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
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
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok != 0" &
                            " ORDER BY Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                            " Jumlah as 'Stok Masuk'," &
                            " Harga AS 'Harga Partai'," &
                            " Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " AND Stok != 0" &
                            " ORDER BY Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
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
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok = 0" &
                            " ORDER BY Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                            " Jumlah as 'Stok Masuk'," &
                            " Harga AS 'Harga Partai'," &
                            " Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " AND Stok = 0" &
                            " ORDER BY Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
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
                        " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                        " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                        " ORDER BY Id DESC" &
                        " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT Id, RTRIM(Id_trans) AS 'ID Transaksi'," &
                        " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                        " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                        " RTRIM((SELECT Person FROM tbl_transaksi_parent WHERE RTRIM(tbl_transaksi_parent.Id_trans) = RTRIM(tbl_transaksi_child.Id_trans))) as 'Supplier'," &
                        " Jumlah as 'Stok Masuk'," &
                        " Harga AS 'Harga Partai'," &
                        " Stok AS 'Stok Sisa'" &
                        " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                        " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                        " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                        " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                        " ORDER BY Id DESC" &
                        " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
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
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " tbl_transaksi_parent.Id_kasir = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
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
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok != 0" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok != 0" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
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
                                " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                                " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                                " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                                " AND Stok = 0" &
                                " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                                " ORDER BY tbl_transaksi_child.Id DESC" &
                                " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                                " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                                " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                                " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                                " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                                " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                                " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                                " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                                " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                                " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                                " AND Stok = 0" &
                                " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                                " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                                " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                                " ORDER BY tbl_transaksi_child.Id DESC" &
                                " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
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
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
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
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
                            " tbl_transaksi_parent.Id_kasir = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
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
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok != 0" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND Stok != 0" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
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
                                " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                                " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                                " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                                " AND Stok = 0" &
                                " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                                " ORDER BY tbl_transaksi_child.Id DESC" &
                                " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                                " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                                " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                                " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                                " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                                " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                                " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                                " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                                " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                                " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                                " AND Stok = 0" &
                                " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                                " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                                " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                                " ORDER BY tbl_transaksi_child.Id DESC" &
                                " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
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
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "'" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    Else
                        STR = "SELECT tbl_transaksi_child.Id," &
                            " RTRIM(tbl_transaksi_child.Id_trans) AS 'ID Transaksi'," &
                            " RTRIM(tbl_barang.Kode) AS 'Kode Barang'," &
                            " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                            " RTRIM(tbl_transaksi_parent.Person) as 'Supplier'," &
                            " tbl_transaksi_child.Jumlah as 'Stok Masuk'," &
                            " tbl_transaksi_child.Harga AS 'Harga Partai'," &
                            " tbl_transaksi_child.Stok AS 'Stok Sisa'" &
                            " FROM tbl_transaksi_child INNER JOIN tbl_barang ON tbl_transaksi_child.Kode = tbl_barang.Kode" &
                            " INNER JOIN tbl_transaksi_parent ON tbl_transaksi_child.Id_trans=tbl_transaksi_parent.Id_trans" &
                            " WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
                            " AND (tbl_transaksi_parent.Id_kasir) = '" & My.Settings.ID_ACCOUNT & "' AND" &
                            " (RTRIM(tbl_barang.Kode) = '" & TXTCARI.Text & "' OR" &
                            " RTRIM(tbl_barang.Barang) LIKE '%" & TXTCARI.Text & "%')" &
                            " ORDER BY tbl_transaksi_child.Id DESC" &
                            " OFFSET " & START_RECORD & " ROWS FETCH NEXT " & TAMPIL_RECORD & " ROWS ONLY"
                    End If
                End If
        End Select
        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
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

        BTNPREV.Enabled = True
        BTNNEXT.Enabled = True

        'Dim TBL_DATA As New DataTable
        'DA = New SqlDataAdapter(STR, CONN)
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

    Private Sub BTNNEXT_Click(sender As Object, e As EventArgs) Handles BTNNEXT.Click
        START_RECORD = START_RECORD + TAMPIL_RECORD
        TAMPIL()
    End Sub

    Private Sub BTNPREV_Click(sender As Object, e As EventArgs) Handles BTNPREV.Click
        START_RECORD = START_RECORD - TAMPIL_RECORD
        TAMPIL()
    End Sub

    Dim START_RECORD_CARI As Integer = 0
    Dim TAMPIL_RECORD_CARI As Integer = 5

    Sub CARI_BARANG()
        Dim STR As String = "SELECT RTRIM(Kode) AS Kode,RTRIM(Barang) AS Barang" &
            " FROM tbl_barang WHERE Barang Like '%" & TXTCARI_BARANG.Text & "%'" &
            " ORDER BY Barang ASC"
        Dim DA As SqlDataAdapter
        Dim TBL As New DataSet
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL, START_RECORD_CARI, TAMPIL_RECORD_CARI, 0)
        DGCARI.DataSource = TBL.Tables(0)

        DGCARI.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGCARI.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        BTNPREVCARI.Enabled = True
        BTNNEXTCARI.Enabled = True

        Dim TOTAL_RECORD As Integer = 0
        Dim TBL_DATA As New DataTable
        DA = New SqlDataAdapter(STR, CONN)
        DA.Fill(TBL_DATA)

        TOTAL_RECORD = TBL_DATA.Rows.Count

        If TOTAL_RECORD = 0 Then
            BTNPREVCARI.Enabled = False
            BTNNEXTCARI.Enabled = False
        ElseIf START_RECORD_CARI = 0 Then
            BTNPREVCARI.Enabled = False
        ElseIf TOTAL_RECORD <= TAMPIL_RECORD_CARI Then
            BTNNEXTCARI.Enabled = False
        ElseIf TOTAL_RECORD - START_RECORD_CARI <= TAMPIL_RECORD_CARI Then
            BTNNEXTCARI.Enabled = False
        Else
            BTNPREVCARI.Enabled = True
            BTNNEXTCARI.Enabled = True
        End If
    End Sub

    Private Sub BTNNEXTCARI_Click(sender As Object, e As EventArgs) Handles BTNNEXTCARI.Click
        START_RECORD_CARI = START_RECORD_CARI + TAMPIL_RECORD_CARI
        CARI_BARANG()
    End Sub

    Private Sub BTNPREVCARI_Click(sender As Object, e As EventArgs) Handles BTNPREVCARI.Click
        START_RECORD_CARI = START_RECORD_CARI - TAMPIL_RECORD_CARI
        CARI_BARANG()
    End Sub

    Sub TAMPIL_PNCARI()
        If PNCARI.Visible = False Then
            PNCARI.Visible = True
            BTNCARI.Text = "Tutup (F1)"
            TXTCARI_BARANG.Clear()
            DGCARI.DataSource = Nothing
            TXTCARI_BARANG.Select()
            CARI_BARANG()
        Else
            BTNCARI.Text = "Cari (F1)"
            PNCARI.Visible = False
            DGCARI.DataSource = Nothing
            TXTKODE.Select()
        End If
    End Sub

    Private Function AUTOID() As String
        Dim ID_AWAL As String = Format(Date.Now, "yyMMdd")
        Dim STR As String = "SELECT TOP 1 (Id_trans) AS Id_trans FROM tbl_transaksi_parent WHERE LEFT(Id_trans,1)='M' ORDER BY Id DESC"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            If Mid(RD.Item("Id_trans"), 2, 6) = ID_AWAL Then
                Dim ID As Integer = Mid(RD.Item("Id_trans"), 8, 3) + 1
                RD.Close()
                AUTOID = "M" + ID_AWAL + Format(ID, "000")
            Else
                RD.Close()
                AUTOID = "M" + ID_AWAL + Format(1, "000")
            End If
            RD.Close()
        Else
            RD.Close()
            AUTOID = "M" + ID_AWAL + Format(1, "000")
        End If
        RD.Close()
    End Function

    Private Sub TXTKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTJUMLAH.Select()
        End If
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTJUMLAH_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTJUMLAH.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            TXTHARGAPARTAI.Select()
        End If
    End Sub

    Private Sub TXTSUPPLIER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSUPPLIER.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTKODE.Select()
        End If
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Sub TOTAL_HARGA()
        Dim TOT_HARGA As Integer = 0
        For N = 0 To DGTAMPIL.Rows.Count - 1
            TOT_HARGA = TOT_HARGA + DGTAMPIL.Item("Total", N).Value
        Next

        LBTOTAL.Text = Format(TOT_HARGA, "##,##0")

        If LBTOTAL.Text <> 0 Then
            BTNSTOK.Visible = True
        Else
            BTNSTOK.Visible = False
        End If
    End Sub

    Sub MASUK_DATA()
        DGTAMPIL.Rows.Add()
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("KODE").Value = TXTKODE.Text
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("BARANG").Value = TXTBARANG.Text
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("SATUAN").Value = TXTSATUAN.Text
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("HARGA").Value = TXTHARGAPARTAI.Text
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("QTY").Value = TXTJUMLAH.Text
        DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("TOTAL").Value = TXTHARGAPARTAI.Text * TXTJUMLAH.Text
        If CBJENISEXP.SelectedIndex = 1 Then
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("EXPIRED").Value = Format(DTEXP.Value, "dd-MM-yyyy")
        Else
            DGTAMPIL.Rows(DGTAMPIL.Rows.Count - 1).Cells("EXPIRED").Value = "-"
        End If

        TOTAL_HARGA()
    End Sub

    Private Sub TXTHARGAPARTAI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTHARGAPARTAI.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTHARGAPARTAI.Text <> "" Then
                Dim HARGAPARTAI As Integer
                If TXTHARGAPARTAI.Text <> "" Then
                    Int32.TryParse(TXTHARGAPARTAI.Text, HARGAPARTAI)
                    If HARGAPARTAI > CInt(TXTHARGATERENDAH.Text) Then
                        MsgBox("Harga partai harus lebih rendah dari harga jual produk, silahkan ubah harga jual!")
                        TXTHARGAPARTAI.Clear()
                        TXTHARGAPARTAI.Select()
                    Else
                        CBJENISEXP.Select()
                    End If
                End If
            Else
                CBJENISEXP.Select()
            End If
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BTNCARI_Click(sender As Object, e As EventArgs) Handles BTNCARI.Click
        TAMPIL_PNCARI()
    End Sub

    Private Sub TXTCARI_BARANG_TextChanged(sender As Object, e As EventArgs) Handles TXTCARI_BARANG.TextChanged
        CARI_BARANG()
    End Sub

    Private Sub BTNTAMBAH_Click(sender As Object, e As EventArgs)
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub HapusToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        If MsgBox("Apakah anda yakin akan menghapus data transaksi?", vbYesNo) = vbYes Then
            DGHISTORY.Columns(0).Visible = False
            Dim IDX As String = DGHISTORY.Item(0, DGHISTORY.CurrentRow.Index).Value
            Dim IDTrans As String = DGHISTORY.Item(1, DGHISTORY.CurrentRow.Index).Value
            Dim CMD As New SqlCommand("DELETE FROM tbl_transaksi_child WHERE Id='" & IDX & "'", CONN)
            CMD.ExecuteNonQuery()
            CMD = New SqlCommand("UPDATE tbl_stok SET Stok-=" & DGHISTORY.Item(7, DGHISTORY.CurrentRow.Index).Value.ToString.Replace(",", ".") & ", " &
                                 " Modified_at = '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                                 " WHERE Kode='" & DGHISTORY.Item(2, DGHISTORY.CurrentRow.Index).Value & "'", CONN)
            CMD.ExecuteNonQuery()

            Dim STR As String = "SELECT * FROM tbl_transaksi_child WHERE RTRIM(Id_trans)='" & IDTrans & "'"
            CMD = New SqlCommand(STR, CONN)
            Dim RD As SqlDataReader
            RD = CMD.ExecuteReader
            If Not RD.HasRows Then
                RD.Close()
                CMD = New SqlCommand("DELETE FROM tbl_transaksi_parent WHERE Id_trans='" & IDTrans & "'", CONN)
                CMD.ExecuteNonQuery()
            End If
            RD.Close()

            TAMPIL()
            MsgBox("Data transaksi berhasil dihapus")
        End If
    End Sub

    Private Sub TXTKODE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTKODE.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
        End Select
    End Sub

    Private Sub TXTCARI_BARANG_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTCARI_BARANG.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
        End Select
    End Sub

    Private Sub DGCARI_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            On Error Resume Next
            TXTKODE.Text = DGCARI.Item(0, DGHISTORY.CurrentRow.Index).Value
            BTNCARI.Text = "Cari (F1)"
            TXTJUMLAH.Select()
            PNCARI.Visible = False
            DGCARI.DataSource = Nothing
        End If
    End Sub

    Private Sub DGCARI_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGCARI.CellDoubleClick
        On Error Resume Next
        TXTKODE.Text = DGCARI.Item(0, e.RowIndex).Value
        BTNCARI.Text = "Cari (F1)"
        TXTKODE.Select()
        PNCARI.Visible = False
        DGCARI.DataSource = Nothing
    End Sub

    Private Sub TXTCARI_BARANG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTCARI_BARANG.KeyPress
        If e.KeyChar = Chr(13) Then
            DGCARI.Select()
        End If
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub CBTAMPIL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBTAMPIL.SelectedIndexChanged
        TAMPIL()
    End Sub

    Private Sub DGTAMPIL_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGTAMPIL.CellMouseClick
        On Error Resume Next
        If DGTAMPIL.Rows.Count > 0 Then
            TXTKODE.Enabled = False
            TXTJUMLAH.Enabled = False
            TXTHARGAPARTAI.Enabled = False

            TXTKODE.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Kode").Value
            TXTHARGAPARTAI.Text = DGTAMPIL.Rows(e.RowIndex).Cells("Harga").Value
            TXTJUMLAH.Text = DGTAMPIL.Rows(e.RowIndex).Cells("QTY").Value

            BTNCANCEL.Visible = True
            BTNCARI.Visible = False
            BTNHAPUS.Visible = True
        End If
    End Sub

    Private Sub BTNCANCEL_Click(sender As Object, e As EventArgs) Handles BTNCANCEL.Click
        TXTKODE.Enabled = True
        TXTJUMLAH.Enabled = True
        TXTHARGAPARTAI.Enabled = True
        BTNCARI.Visible = True
        BTNCANCEL.Visible = False
        BTNHAPUS.Visible = False
        TXTKODE.Clear()
        TXTJUMLAH.Clear()
        TXTHARGAPARTAI.Clear()
        TXTKODE.Select()
    End Sub

    Private Sub BTNHAPUS_Click(sender As Object, e As EventArgs) Handles BTNHAPUS.Click
        Dim BARIS_DATA As Integer = 0
        For N = 0 To DGTAMPIL.Rows.Count - 1
            Dim Kode As String = DGTAMPIL.Item("Kode", N).Value
            If Kode = TXTKODE.Text Then
                BARIS_DATA = N
                Exit For
            End If
        Next
        DGTAMPIL.Rows.RemoveAt(BARIS_DATA)
        TOTAL_HARGA()
        TXTJUMLAH.Enabled = True
        TXTKODE.Enabled = True
        TXTHARGAPARTAI.Enabled = True
        BTNCARI.Visible = True
        BTNCANCEL.Visible = False
        BTNHAPUS.Visible = False
        TXTKODE.Clear()
        TXTJUMLAH.Clear()
        TXTHARGAPARTAI.Clear()
        TXTKODE.Select()
    End Sub

    Private Sub BTNSTOK_Click(sender As Object, e As EventArgs) Handles BTNSTOK.Click
        INPUT_DB()
        'PRINT_NOTA()
        'DGTAMPIL.Rows.Clear()
        'TOTAL_HARGA()

        FR_MASUK_TOTAL.LBKEMBALI.Text = Format(CInt(LBTOTAL.Text), "##,##0")
        FR_MASUK_TOTAL.ID_TRANSAKSI.Text = ID_TRANSAKSI
        FR_MASUK_TOTAL.Show()
        FR_MASUK_TOTAL.BTNTUTUP.Select()
        Me.Enabled = False
    End Sub

    Sub INPUT_DB()
        If DGTAMPIL.Rows.Count <= 0 Then Exit Sub
        ID_TRANSAKSI = AUTOID()
        Dim JUMLAH_ITEM As Double = 0
        Dim HARGA_TOTAL As Integer = 0
        For Each EROW As DataGridViewRow In DGTAMPIL.Rows
            HARGA_TOTAL += CInt(EROW.Cells("TOTAL").Value)
            JUMLAH_ITEM += Convert.ToDouble(EROW.Cells("QTY").Value)
        Next

        Dim STR As String = "INSERT INTO tbl_transaksi_parent" &
            " (Id_trans, Id_kasir, Tgl, Jenis, Person, Harga, Jumlah_item)" &
            " VALUES('" & ID_TRANSAKSI & "'," &
            " '" & My.Settings.ID_ACCOUNT & "'," &
            " '" & Format(Date.Now, "MM/dd/yyyy HH:mm:ss") & "'," &
            " 'M'," &
            " '" & TXTSUPPLIER.Text & "'," &
            " '" & HARGA_TOTAL & "'," &
            " '" & JUMLAH_ITEM.ToString.Replace(",", ".") & "')"
        Dim CMD As New SqlCommand(STR, CONN)
        CMD.ExecuteNonQuery()

        For Each EROW As DataGridViewRow In DGTAMPIL.Rows
            Dim KODE_PRODUK As String = EROW.Cells("Kode").Value
            Dim JUMLAH_PRODUK As Double = Convert.ToDouble(EROW.Cells("QTY").Value)
            Dim HARGA_PRODUK As Integer = EROW.Cells("Harga").Value
            If EROW.Cells("EXPIRED").Value = "-" Then
                STR = "INSERT INTO tbl_transaksi_child (Id_trans, Kode, Jumlah, Harga, Stok, Created_at) VALUES" &
                    " ('" & ID_TRANSAKSI & "'," &
                    " '" & KODE_PRODUK & "'," &
                    " " & JUMLAH_PRODUK.ToString.Replace(",", ".") & "," &
                    " '" & HARGA_PRODUK & "'," &
                    " '" & JUMLAH_PRODUK.ToString.Replace(",", ".") & "'," &
                    " '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "')"
            Else
                Dim TGL_EXP As String = Format(Convert.ToDateTime(EROW.Cells("EXPIRED").Value), "yyyy-MM-dd")
                STR = "INSERT INTO tbl_transaksi_child (Id_trans, Kode, Jumlah, Harga, Stok, Tgl_exp, Created_at) VALUES" &
                        " ('" & ID_TRANSAKSI & "'," &
                        " '" & KODE_PRODUK & "'," &
                        " " & JUMLAH_PRODUK.ToString.Replace(",", ".") & "," &
                        " '" & HARGA_PRODUK & "'," &
                        " '" & JUMLAH_PRODUK.ToString.Replace(",", ".") & "'," &
                        " '" & TGL_EXP & "'," &
                        " '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "')"
            End If
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            STR = "UPDATE tbl_stok SET Stok+=" & JUMLAH_PRODUK.ToString.Replace(",", ".") & ", " &
                " Modified_at = '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                " WHERE Kode='" & KODE_PRODUK & "'"
            CMD = New SqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
        Next
    End Sub

    'PRINTING
    '=================================================================================
    'KERTAS 
    ReadOnly lebarKertas As Integer = 304 'Ukuran Kertas 78 mm
    ReadOnly tinggiKertas As Integer = 304
    ReadOnly marginLeft As Integer = 20
    ReadOnly marginRight As Integer = 20
    ReadOnly jarakBaris As Integer = 20
    Dim totalBaris As Integer = 0


    'JENIS DAN UKURAN HURUF
    ReadOnly fontJudul As New Font("Segoe UI", 12, FontStyle.Bold)
    ReadOnly fontRegular As New Font("Segoe UI", 10, FontStyle.Regular)
    ReadOnly fontTotal As New Font("Segoe UI", 10, FontStyle.Bold)
    Dim countBarang As Integer = 0
    Dim pageNumber As Integer = 1

    Private Function BarisBaru(jumlah_baris)
        totalBaris += jumlah_baris
        Return totalBaris * jarakBaris
    End Function

    Private Function BarisYangSama()
        Return BarisBaru(0)
    End Function

    Private Sub PRINTNOTA_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PRINTNOTA.PrintPage
        Dim IMAGESTREAM As New MemoryStream
        IMAGESTREAM = New MemoryStream(Convert.FromBase64String(URL_LOGO))

        Dim textCenter, textLeft, textRight As New StringFormat
        textCenter.Alignment = StringAlignment.Center
        textLeft.Alignment = StringAlignment.Near
        textRight.Alignment = StringAlignment.Far
        Dim WIDTH As Single = 150
        Dim HEIGHT As Single = 75
        Dim JARAK As Single = (lebarKertas - WIDTH) / 2

        totalBaris = 0

        If pageNumber = 1 Then
            Dim IMAGE As Image = Image.FromStream(IMAGESTREAM)
            e.Graphics.DrawImage(IMAGE, JARAK, BarisYangSama(), WIDTH, HEIGHT)

            e.Graphics.DrawString(NAMA_TOKO, fontJudul, Brushes.Black, lebarKertas / 2, BarisBaru(HEIGHT / jarakBaris), textCenter)
            e.Graphics.DrawString(ALAMATTOKO.Text, fontRegular, Brushes.Black, New Rectangle(20, BarisBaru(1), lebarKertas - 30, BarisYangSama), textCenter)
            e.Graphics.DrawString(NO_TOKO, fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
            BarisBaru(1)

            e.Graphics.DrawString("BARANG MASUK", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)

            e.Graphics.DrawString(LBTGL.Text, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)

            e.Graphics.DrawString(ID_TRANSAKSI, fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisBaru(1), textRight)
            e.Graphics.DrawString("Kasir : " & LBLUSER.Text, fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)

            e.Graphics.DrawLine(Pens.Black, marginLeft, BarisBaru(1), (lebarKertas - marginRight), BarisYangSama)
        End If

        For row As Integer = 0 To DGTAMPIL.Rows.Count - 1
            If row >= countBarang And countBarang < DGTAMPIL.Rows.Count Then
                e.Graphics.DrawString(DGTAMPIL.Rows(row).Cells("BARANG").Value, fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
                e.Graphics.DrawString(Convert.ToDouble(DGTAMPIL.Rows(row).Cells("QTY").Value) & " " & DGTAMPIL.Rows(row).Cells("SATUAN").Value & " x " & Format(CInt(DGTAMPIL.Rows(row).Cells("HARGA").Value), "##,##0"), fontRegular, Brushes.Black, marginLeft, BarisBaru(1), textLeft)
                e.Graphics.DrawString(Format(CInt(DGTAMPIL.Rows(row).Cells("TOTAL").Value), "##,##0"), fontRegular, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)
                BarisBaru(1)
                countBarang += 1
                If totalBaris = 52 Then
                    e.HasMorePages = True
                    pageNumber += 1
                    totalBaris = 0
                    Exit Sub
                End If
            End If
        Next

        If totalBaris = 52 Then
            e.HasMorePages = True
            pageNumber += 1
            totalBaris = 0
            Exit Sub
        End If

        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)

        e.Graphics.DrawString("Total", fontRegular, Brushes.Black, marginLeft, BarisYangSama, textLeft)
        e.Graphics.DrawString(Format(CInt(LBTOTAL.Text), "Rp ##,##0"), fontTotal, Brushes.Black, (lebarKertas - marginRight), BarisYangSama, textRight)

        BarisBaru(1)
        e.Graphics.DrawLine(Pens.Black, marginLeft, BarisYangSama, (lebarKertas - marginRight), BarisYangSama)

        e.Graphics.DrawString("Barang yang sudah dibeli", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString("tidak dapat ditukar/dikembalikan", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)
        e.Graphics.DrawString("TERIMA KASIH", fontRegular, Brushes.Black, lebarKertas / 2, BarisBaru(1), textCenter)

        BarisBaru(1)
        pageNumber = 1
        countBarang = 0
    End Sub

    Sub PRINT_NOTA()
        Dim ps As New PrinterSettings
        PRINTNOTA.OriginAtMargins = False
        PRINTNOTA.PrinterSettings = ps
        PRINTNOTA.PrinterSettings.PrinterName = PRINTER_NOTA
        PRINTNOTA.DefaultPageSettings.PaperSize = New PaperSize("Custom", lebarKertas, tinggiKertas + BarisBaru(DGTAMPIL.Rows.Count))
        PRINTNOTA.DefaultPageSettings.Landscape = False
        PRINTNOTA.DocumentName = "Stroke"
        PRINTNOTA.Print()
    End Sub

    Private Sub BTNHISTORY_Click(sender As Object, e As EventArgs) Handles BTNHISTORY.Click
        PNHISTORY.Visible = True
        BTNSTOK.Visible = False
        BTNHISTORY.Visible = False
        BTNTRANSAKSI.Visible = True
        CBTAMPIL.SelectedIndex = 1

        'Dim str = ""

        'Select Case ROLE
        '    Case 1
        '        If CBTAMPIL.SelectedIndex = 0 Then
        '            Str = "SELECT COUNT(Id)" &
        '                    " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
        '                    " ((SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
        '                    " OR RTRIM(Kode) = '" & TXTCARI.Text & "'" &
        '                    " OR RTRIM(Id_trans) = '" & TXTCARI.Text & "')"
        '        ElseIf CBTAMPIL.SelectedIndex = 1 Then
        '            Str = "SELECT COUNT(Id)" &
        '                    " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
        '                    " ((SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
        '                    " OR RTRIM(Kode) = '" & TXTCARI.Text & "'" &
        '                    " OR RTRIM(Id_trans) = '" & TXTCARI.Text & "')" &
        '                    " AND Stok != 0"
        '        ElseIf CBTAMPIL.SelectedIndex = 2 Then
        '            Str = "SELECT COUNT(Id)" &
        '                    " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
        '                    " ((SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
        '                    " OR RTRIM(Kode) = '" & TXTCARI.Text & "'" &
        '                    " OR RTRIM(Id_trans) = '" & TXTCARI.Text & "')" &
        '                    " AND Stok = 0"
        '        Else
        '            Str = "SELECT COUNT(Id)" &
        '                    " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
        '                    " ((SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
        '                    " OR RTRIM(Kode) = '" & TXTCARI.Text & "'" &
        '                    " OR RTRIM(Id_trans) = '" & TXTCARI.Text & "')"
        '        End If
        '    Case 2
        '        If CBTAMPIL.SelectedIndex = 0 Then
        '            Str = "SELECT COUNT(*)" &
        '                    " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M' AND" &
        '                    " (SELECT Id_kasir FROM tbl_transaksi_parent WHERE tbl_transaksi_parent.Id_trans = tbl_transaksi_child.Id_trans) = '" & My.Settings.ID_ACCOUNT & "'" &
        '                    " AND ((SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
        '                    " OR RTRIM(Kode) = '" & TXTCARI.Text & "'" &
        '                    " OR RTRIM(Id_trans) = '" & TXTCARI.Text & "')"
        '        ElseIf CBTAMPIL.SelectedIndex = 1 Then
        '            Str = "SELECT COUNT(*)" &
        '                    " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
        '                    " AND Stok != 0" &
        '                    " AND (SELECT Id_kasir FROM tbl_transaksi_parent WHERE tbl_transaksi_parent.Id_trans = tbl_transaksi_child.Id_trans) = '" & My.Settings.ID_ACCOUNT & "'" &
        '                    " AND ((SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
        '                    " OR RTRIM(Kode) = '" & TXTCARI.Text & "'" &
        '                    " OR RTRIM(Id_trans) = '" & TXTCARI.Text & "')"
        '        ElseIf CBTAMPIL.SelectedIndex = 2 Then
        '            Str = "SELECT COUNT(*)" &
        '                    " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
        '                    " AND Stok = 0" &
        '                    " AND (SELECT Id_kasir FROM tbl_transaksi_parent WHERE tbl_transaksi_parent.Id_trans = tbl_transaksi_child.Id_trans) = '" & My.Settings.ID_ACCOUNT & "'" &
        '                    " AND ((SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
        '                    " OR RTRIM(Kode) = '" & TXTCARI.Text & "'" &
        '                    " OR RTRIM(Id_trans) = '" & TXTCARI.Text & "')"
        '        Else
        '            Str = "SELECT COUNT(*)" &
        '                    " FROM tbl_transaksi_child WHERE (LEFT(tbl_transaksi_child.Id_trans,1))='M'" &
        '                    " AND (SELECT Id_kasir FROM tbl_transaksi_parent WHERE tbl_transaksi_parent.Id_trans = tbl_transaksi_child.Id_trans) = '" & My.Settings.ID_ACCOUNT & "'" &
        '                    " AND ((SELECT Barang FROM tbl_barang WHERE RTRIM(Kode)=RTRIM(tbl_transaksi_child.Kode)) Like '%" & TXTCARI.Text & "%'" &
        '                    " OR RTRIM(Kode) = '" & TXTCARI.Text & "'" &
        '                    " OR RTRIM(Id_trans) = '" & TXTCARI.Text & "')"
        '        End If
        'End Select

        'Dim CMD As New SqlCommand(Str, CONN)
        'TOTAL_RECORD = Convert.ToUInt64(CMD.ExecuteScalar())

        TAMPIL()
    End Sub

    Private Sub BTNTRANSAKSI_Click(sender As Object, e As EventArgs) Handles BTNTRANSAKSI.Click
        PNHISTORY.Visible = False
        If DGTAMPIL.RowCount > 0 Then
            BTNSTOK.Visible = True
        End If
        BTNTRANSAKSI.Visible = False
        BTNHISTORY.Visible = True
    End Sub

    Sub CARI_DATA_BARANG()
        Dim STR As String = "SELECT * FROM tbl_barang WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As SqlCommand
        CMD = New SqlCommand(STR, CONN)
        Dim RD As SqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            TXTBARANG.Text = RD.Item("Barang").ToString.Trim
            TXTSATUAN.Text = RD.Item("Satuan").ToString.Trim
            Dim HARGA_TERENDAH As Integer = 0
            If RD.Item("End4") <> 0 Then
                HARGA_TERENDAH = RD.Item("Harga5")
            Else
                If RD.Item("End3") <> 0 Then
                    HARGA_TERENDAH = RD.Item("Harga4")
                Else
                    If RD.Item("End2") <> 0 Then
                        HARGA_TERENDAH = RD.Item("Harga3")
                    Else
                        If RD.Item("End1") <> 0 Then
                            HARGA_TERENDAH = RD.Item("Harga2")
                        Else
                            HARGA_TERENDAH = RD.Item("Harga1")
                        End If
                    End If
                End If
            End If

            TXTHARGATERENDAH.Text = HARGA_TERENDAH
            RD.Close()
        Else
            RD.Close()
            MsgBox("Produk tidak ditemukan")
            TXTKODE.Text = ""
            TXTKODE.Select()
            TXTBARANG.Text = ""
            TXTSATUAN.Text = ""
        End If
        RD.Close()
    End Sub

    Private Sub TXTKODE_Leave(sender As Object, e As EventArgs) Handles TXTKODE.Leave
        If TXTKODE.Text <> "" Then
            CARI_DATA_BARANG()
        End If
    End Sub

    Private Sub BTNLABELADMIN_Click(sender As Object, e As EventArgs) Handles BTNLABELADMIN.Click
        BUKA_FORM(FR_CETAK_LABEL)
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

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNKELUAR_Click(sender As Object, e As EventArgs) Handles BTNKELUAR.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNLAPORAN_Click(sender As Object, e As EventArgs) Handles BTNLAPORAN.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNHISTORYPENJUALAN_Click(sender As Object, e As EventArgs) Handles BTNHISTORYPENJUALAN.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNMEMBER_ADMIN_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_ADMIN.Click
        BUKA_FORM(FR_MEMBER)
    End Sub

    Private Sub BTNVOUCHER_ADMIN_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_ADMIN.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub BTNDASHBOARDOPS_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDOPS.Click
        BUKA_FORM(FR_OPS_DASHBOARD)
    End Sub

    Private Sub BTNBARANGOPS_Click(sender As Object, e As EventArgs) Handles BTNBARANGOPS.Click
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub BTNHISTORYOPS_Click(sender As Object, e As EventArgs) Handles BTNHISTORYOPS.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNKELUAROPS_Click(sender As Object, e As EventArgs) Handles BTNKELUAROPS.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNLABELOPS_Click(sender As Object, e As EventArgs) Handles BTNLABELOPS.Click
        BUKA_FORM(FR_CETAK_LABEL)
    End Sub

    Private Sub BTNLAPORANOPS_Click(sender As Object, e As EventArgs) Handles BTNLAPORANOPS.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNMEMBER_OPS_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_OPS.Click
        BUKA_FORM(FR_MEMBER)
    End Sub

    Private Sub BTNRETURNOPS_Click(sender As Object, e As EventArgs) Handles BTNRETURNOPS.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAKOPS_Click(sender As Object, e As EventArgs) Handles BTNRUSAKOPS.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub BTNTENTANGOPS_Click(sender As Object, e As EventArgs) Handles BTNTENTANGOPS.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNVOUCHER_OPS_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_OPS.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub CBJENISEXP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBJENISEXP.KeyPress
        If e.KeyChar = Chr(13) Then
            If CBJENISEXP.SelectedIndex = 0 Then
                If TXTKODE.Text = "" Or TXTBARANG.Text = "" Or TXTJUMLAH.Text = "" Or TXTHARGAPARTAI.Text = "" Or CBJENISEXP.Text = "" Then
                    MsgBox("Data tidak lengkap!")
                    TXTKODE.Select()
                Else
                    MASUK_DATA()
                    TXTKODE.Text = ""
                    TXTJUMLAH.Text = ""
                    TXTHARGAPARTAI.Text = ""
                    CBJENISEXP.SelectedIndex = 0
                    DTEXP.Value = Date.Now
                    TXTKODE.Select()
                End If
            ElseIf CBJENISEXP.SelectedIndex = 1 Then
                Label14.Visible = True
                DTEXP.Visible = True
                DTEXP.Select()
            End If
        End If
    End Sub

    Private Sub CBJENISEXP_TextChanged(sender As Object, e As EventArgs) Handles CBJENISEXP.TextChanged
        If CBJENISEXP.SelectedIndex = 0 Then
            Label14.Visible = False
            DTEXP.Visible = False
        ElseIf CBJENISEXP.SelectedIndex = 1 Then
            Label14.Visible = True
            DTEXP.Visible = True
        End If
    End Sub

    Private Sub TXTHARGAPARTAI_Leave(sender As Object, e As EventArgs) Handles TXTHARGAPARTAI.Leave
        Dim HARGAPARTAI As Integer
        If TXTHARGAPARTAI.Text <> "" Then
            Int32.TryParse(TXTHARGAPARTAI.Text, HARGAPARTAI)
            If HARGAPARTAI > CInt(TXTHARGATERENDAH.Text) Then
                MsgBox("Harga partai harus lebih rendah dari harga jual produk, silahkan ubah harga jual!")
                TXTHARGAPARTAI.Clear()
                TXTHARGAPARTAI.Select()
            End If
        End If
    End Sub

    Private Sub CBJENISEXP_Leave(sender As Object, e As EventArgs) Handles CBJENISEXP.Leave
        If CBJENISEXP.SelectedIndex = 0 Then
            Label14.Visible = False
            DTEXP.Visible = False
        ElseIf CBJENISEXP.SelectedIndex = 1 Then
            Label14.Visible = True
            DTEXP.Visible = True
        End If
    End Sub

    Private Sub DTEXP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTEXP.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTKODE.Text = "" Or TXTBARANG.Text = "" Or TXTJUMLAH.Text = "" Or TXTHARGAPARTAI.Text = "" Or CBJENISEXP.Text = "" Then
                MsgBox("Data tidak lengkap!")
                TXTKODE.Select()
            ElseIf DTEXP.Value <= Date.Now Then
                MsgBox("Barang masuk tidak boleh expired")
            Else
                MASUK_DATA()
                TXTKODE.Text = ""
                TXTJUMLAH.Text = ""
                TXTHARGAPARTAI.Text = ""
                CBJENISEXP.SelectedIndex = 0
                DTEXP.Value = Date.Now
                TXTKODE.Select()
            End If
        End If
    End Sub

    Private Sub TXTJUMLAH_Leave(sender As Object, e As EventArgs) Handles TXTJUMLAH.Leave
        Dim QTY As Double = 0
        If TXTJUMLAH.Text <> "" Then
            QTY = Convert.ToDouble(TXTJUMLAH.Text)
        End If
        If TXTJUMLAH.Text <> "" And QTY = 0 Then
            MsgBox("QTY harus lebih dari 0")
            TXTJUMLAH.Clear()
            TXTJUMLAH.Select()
        End If
    End Sub

    Private Sub DTEXP_Leave(sender As Object, e As EventArgs) Handles DTEXP.Leave
        If DTEXP.Value <= Date.Now Then
            MsgBox("Barang masuk tidak boleh expired")
            DTEXP.Select()
        End If
    End Sub

    Private Sub BTNINPUT_Click(sender As Object, e As EventArgs) Handles BTNINPUT.Click
        If TXTKODE.Text = "" Or TXTBARANG.Text = "" Or TXTJUMLAH.Text = "" Or TXTHARGAPARTAI.Text = "" Or CBJENISEXP.Text = "" Then
            MsgBox("Data tidak lengkap!")
            TXTKODE.Select()
        Else
            MASUK_DATA()
            TXTKODE.Text = ""
            TXTJUMLAH.Text = ""
            TXTHARGAPARTAI.Text = ""
            CBJENISEXP.SelectedIndex = 0
            DTEXP.Value = Date.Now
            TXTKODE.Select()
        End If
    End Sub

    Private Sub DGCARI_KeyDown(sender As Object, e As KeyEventArgs) Handles DGCARI.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            e.Handled = True
            DGCARI.CurrentCell = DGCARI.Rows(DGCARI.CurrentRow.Index).Cells(0)
            TXTKODE.Text = DGCARI.SelectedCells(0).Value
            BTNCARI.Text = "Cari (F1)"
            TXTKODE.Select()
            PNCARI.Visible = False
            DGCARI.DataSource = Nothing
        End If
    End Sub

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

    Private Sub BTNDASHBOARDKASIR_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARDKASIR.Click
        BUKA_FORM(FR_KASIR_DASHBOARD)
    End Sub

    Private Sub BTNVOUCHER_KASIR_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_KASIR.Click
        BUKA_FORM(FR_VOUCHER)
    End Sub

    Private Sub BTNLABELKASIR_Click(sender As Object, e As EventArgs) Handles BTNLABELKASIR.Click
        BUKA_FORM(FR_CETAK_LABEL)
    End Sub

    Private Sub BTNMEMBER_KASIR_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_KASIR.Click
        BUKA_FORM(FR_MEMBER)
    End Sub

    Private Sub BTNKELUARKASIR_Click(sender As Object, e As EventArgs) Handles BTNKELUARKASIR.Click
        BUKA_FORM(FR_KELUAR)
    End Sub

    Private Sub BTNHISTORYPENJUALANKASIR_Click(sender As Object, e As EventArgs) Handles BTNHISTORYPENJUALANKASIR.Click
        BUKA_FORM(FR_HISTORYPENJUALAN)
    End Sub

    Private Sub BTNRETURNKASIR_Click(sender As Object, e As EventArgs) Handles BTNRETURNKASIR.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNLAPORANKASIR_Click(sender As Object, e As EventArgs) Handles BTNLAPORANKASIR.Click
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub BTNSETTINGKASIR_Click(sender As Object, e As EventArgs) Handles BTNSETTINGKASIR.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub DGHISTORY_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGHISTORY.CellClick
        On Error Resume Next

        If e.RowIndex >= 0 Then
            If DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Delete" Then
                If MsgBox("Apakah anda yakin akan menghapus data transaksi?", vbYesNo) = vbYes Then
                    DGHISTORY.Columns(0).Visible = False
                    Dim IDX As String = DGHISTORY.Item(0, DGHISTORY.CurrentRow.Index).Value
                    Dim IDTrans As String = DGHISTORY.Item(1, DGHISTORY.CurrentRow.Index).Value
                    Dim CMD As New SqlCommand("DELETE FROM tbl_transaksi_child WHERE Id='" & IDX & "'", CONN)
                    CMD.ExecuteNonQuery()
                    CMD = New SqlCommand("UPDATE tbl_stok SET Stok-=" & DGHISTORY.Item(7, DGHISTORY.CurrentRow.Index).Value.ToString.Replace(",", ".") & ", " &
                                         " Modified_at = '" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & "'" &
                                         " WHERE Kode='" & DGHISTORY.Item(2, DGHISTORY.CurrentRow.Index).Value & "'", CONN)
                    CMD.ExecuteNonQuery()

                    Dim STR As String = "SELECT * FROM tbl_transaksi_child WHERE RTRIM(Id_trans)='" & IDTrans & "'"
                    CMD = New SqlCommand(STR, CONN)
                    Dim RD As SqlDataReader
                    RD = CMD.ExecuteReader
                    If Not RD.HasRows Then
                        RD.Close()
                        CMD = New SqlCommand("DELETE FROM tbl_transaksi_parent WHERE Id_trans='" & IDTrans & "'", CONN)
                        CMD.ExecuteNonQuery()
                    End If
                    RD.Close()

                    TAMPIL()
                    MsgBox("Data transaksi berhasil dihapus")
                End If
            End If
        End If
    End Sub

    Private Sub DGHISTORY_SelectionChanged(sender As Object, e As EventArgs) Handles DGHISTORY.SelectionChanged
        DGHISTORY.ClearSelection()
    End Sub
End Class