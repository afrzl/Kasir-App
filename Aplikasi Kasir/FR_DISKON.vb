Imports MySql.Data.MySqlClient

Public Class FR_DISKON
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
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub FR_MASUK_Load(sender As Object, e As EventArgs) Handles Me.Load
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN
        CBTAMPIL.Text = "Sekarang"

        TXTKODE.Select()
        TAMPIL()
    End Sub

    Dim START_RECORD As Integer = 0
    Dim TAMPIL_RECORD As Integer = 30

    Sub TAMPIL()
        DGTAMPIL.Columns.Clear()

        Dim TGL_SKRG As String = Format(Date.Now, "yyyy-MM-dd")
        Dim STR As String = ""
        If CBTAMPIL.Text = "Semua" Then
            STR = "SELECT tbl_diskon.Id," &
                " RTRIM(tbl_diskon.Jenis) AS 'Jenis'," &
                " RTRIM(tbl_diskon.Kode) AS 'Kode Barang'," &
                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                " tbl_diskon.Min_transaksi AS 'Minimal Transaksi'," &
                " tbl_diskon.Tgl_awal as 'Tanggal Awal'," &
                " tbl_diskon.Tgl_akhir AS 'Tanggal Akhir'," &
                " tbl_diskon.Jenis_nominal AS 'Jenis Nominal'," &
                " tbl_diskon.Diskon AS 'Diskon'" &
                " FROM tbl_diskon" &
                " LEFT OUTER JOIN tbl_barang ON tbl_diskon.Kode = tbl_barang.Kode" &
                " ORDER BY tbl_diskon.Tgl_awal ASC"
        ElseIf CBTAMPIL.Text = "Berlalu" Then
            STR = "Select tbl_diskon.Id," &
                " RTRIM(tbl_diskon.Jenis) As 'Jenis'," &
                " RTRIM(tbl_diskon.Kode) AS 'Kode Barang'," &
                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                " tbl_diskon.Min_transaksi AS 'Minimal Transaksi'," &
                " tbl_diskon.Tgl_awal as 'Tanggal Awal'," &
                " tbl_diskon.Tgl_akhir AS 'Tanggal Akhir'," &
                " tbl_diskon.Jenis_nominal AS 'Jenis Nominal'," &
                " tbl_diskon.Diskon AS 'Diskon'" &
                " FROM tbl_diskon" &
                " LEFT OUTER JOIN tbl_barang ON tbl_diskon.Kode = tbl_barang.Kode" &
                " WHERE Tgl_akhir < '" & TGL_SKRG & "'" &
                " ORDER BY tbl_diskon.Tgl_awal ASC"
        ElseIf CBTAMPIL.Text = "Sekarang" Then
            STR = "SELECT tbl_diskon.Id," &
                " RTRIM(tbl_diskon.Jenis) AS 'Jenis'," &
                " RTRIM(tbl_diskon.Kode) AS 'Kode Barang'," &
                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                " tbl_diskon.Min_transaksi AS 'Minimal Transaksi'," &
                " tbl_diskon.Tgl_awal as 'Tanggal Awal'," &
                " tbl_diskon.Tgl_akhir AS 'Tanggal Akhir'," &
                " tbl_diskon.Jenis_nominal AS 'Jenis Nominal'," &
                " tbl_diskon.Diskon AS 'Diskon'" &
                " FROM tbl_diskon" &
                " LEFT OUTER JOIN tbl_barang ON tbl_diskon.Kode = tbl_barang.Kode" &
                " WHERE Tgl_awal <= '" & TGL_SKRG & "' AND Tgl_akhir >= '" & TGL_SKRG & "'" &
                " ORDER BY tbl_diskon.Tgl_awal ASC"
        ElseIf CBTAMPIL.Text = "Akan Datang" Then
            STR = "SELECT tbl_diskon.Id," &
                " RTRIM(tbl_diskon.Jenis) AS 'Jenis'," &
                " RTRIM(tbl_diskon.Kode) AS 'Kode Barang'," &
                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                " tbl_diskon.Min_transaksi AS 'Minimal Transaksi'," &
                " tbl_diskon.Tgl_awal as 'Tanggal Awal'," &
                " tbl_diskon.Tgl_akhir AS 'Tanggal Akhir'," &
                " tbl_diskon.Jenis_nominal AS 'Jenis Nominal'," &
                " tbl_diskon.Diskon AS 'Diskon'" &
                " FROM tbl_diskon" &
                " LEFT OUTER JOIN tbl_barang ON tbl_diskon.Kode = tbl_barang.Kode" &
                " WHERE Tgl_awal > '" & TGL_SKRG & "'" &
                " ORDER BY tbl_diskon.Tgl_awal ASC"
        Else
            STR = "SELECT tbl_diskon.Id," &
                " RTRIM(tbl_diskon.Jenis) AS 'Jenis'," &
                " RTRIM(tbl_diskon.Kode) AS 'Kode Barang'," &
                " RTRIM(tbl_barang.Barang) AS 'Nama Barang'," &
                " tbl_diskon.Min_transaksi AS 'Minimal Transaksi'," &
                " tbl_diskon.Tgl_awal as 'Tanggal Awal'," &
                " tbl_diskon.Tgl_akhir AS 'Tanggal Akhir'," &
                " tbl_diskon.Jenis_nominal AS 'Jenis Nominal'," &
                " tbl_diskon.Diskon AS 'Diskon'" &
                " FROM tbl_diskon" &
                " LEFT OUTER JOIN tbl_barang ON tbl_diskon.Kode = tbl_barang.Kode" &
                " ORDER BY tbl_diskon.Tgl_awal ASC"
        End If
        Dim DA As MySqlDataAdapter
        Dim TBL As New DataSet
        DA = New MySqlDataAdapter(STR, CONN)
        DA.Fill(TBL, START_RECORD, TAMPIL_RECORD, 0)
        DGTAMPIL.DataSource = TBL.Tables(0)


        DGTAMPIL.Columns(0).Visible = False


        DGTAMPIL.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGTAMPIL.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DGTAMPIL.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        DGTAMPIL.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGTAMPIL.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGTAMPIL.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGTAMPIL.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGTAMPIL.Columns("Minimal Transaksi").DefaultCellStyle.Format = "Rp ###,##"
        DGTAMPIL.Columns("Diskon").DefaultCellStyle.Format = "###,##.##"

        For N = 0 To DGTAMPIL.Rows.Count - 1
            If DGTAMPIL.Rows(N).Cells("Jenis").Value = "A" Then
                DGTAMPIL.Rows(N).Cells("Jenis").Value = "Semua"
            Else
                DGTAMPIL.Rows(N).Cells("Jenis").Value = "Produk"
            End If

            If DGTAMPIL.Rows(N).Cells("Jenis Nominal").Value = "R" Then
                DGTAMPIL.Rows(N).Cells("Jenis Nominal").Value = "Rupiah"
            Else
                DGTAMPIL.Rows(N).Cells("Jenis Nominal").Value = "Persen"
            End If
        Next

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
        DGTAMPIL.Columns.Add(Column_delete)

        Dim Column_cetak As New DataGridViewButtonColumn
        With Column_cetak
            .Text = "Cetak"
            .HeaderText = "Cetak"
            .UseColumnTextForButtonValue = True
            .FlatStyle = FlatStyle.Flat
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .CellTemplate.Style.BackColor = Color.DarkGreen
            .CellTemplate.Style.ForeColor = Color.WhiteSmoke
            .Width = 100
        End With
        DGTAMPIL.Columns.Add(Column_cetak)
        DGTAMPIL.ColumnHeadersHeight = 35

        DGTAMPIL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DGTAMPIL.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        For i = 0 To DGTAMPIL.Columns.Count - 1
            DGTAMPIL.Columns.Item(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        BTNPREV.Enabled = True
        BTNNEXT.Enabled = True

        Dim TOTAL_RECORD As Integer = 0
        Dim TBL_DATA As New DataTable
        DA = New MySqlDataAdapter(STR, CONN)
        DA.Fill(TBL_DATA)

        TOTAL_RECORD = TBL_DATA.Rows.Count

        If TOTAL_RECORD = 0 Then
            BTNPREV.Enabled = False
            BTNNEXT.Enabled = False
        ElseIf START_RECORD = 0 Then
            BTNPREV.Enabled = False
        ElseIf TOTAL_RECORD <= TAMPIL_RECORD Then
            BTNNEXT.Enabled = False
        ElseIf TOTAL_RECORD - START_RECORD <= TAMPIL_RECORD Then
            BTNNEXT.Enabled = False
        Else
            BTNPREV.Enabled = True
            BTNNEXT.Enabled = True
        End If
    End Sub

    Private Sub BTNNEXT_Click(sender As Object, e As EventArgs) Handles BTNNEXT.Click
        START_RECORD = START_RECORD + TAMPIL_RECORD
        TAMPIL()
    End Sub

    Private Sub BTNPREV_Click(sender As Object, e As EventArgs) Handles BTNPREV.Click
        START_RECORD = START_RECORD - TAMPIL_RECORD
        TAMPIL()
    End Sub

    Sub TAMPIL_PNCARI()
        With FR_KELUAR_TAMPIL
            .Show()
            .LB_TITLE.Text = "FR_DISKON"
        End With
        Me.Enabled = False
    End Sub

    Private Sub TXTKODE_TextChanged(sender As Object, e As EventArgs) Handles TXTKODE.TextChanged
        Try
            BUKA_KONEKSI()
        Catch ex As Exception
            MsgBox("Koneksi database gagal: " & ex.Message, vbCritical)
            Return
        End Try

        Dim STR As String = "SELECT Barang, Satuan, Harga1, Harga2, Harga3, Harga4, Harga5, End1, End2, End3, End4 FROM tbl_barang WHERE RTRIM(Kode)='" & TXTKODE.Text & "'"
        Dim CMD As MySqlCommand
        CMD = New MySqlCommand(STR, CONN)
        Dim RD As MySqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            LBBARANG.Text = RD.Item("Barang").ToString.Trim
            LBSATUAN.Text = RD.Item("Satuan").ToString.Trim

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
            LBHARGA.Text = HARGA_TERENDAH
            RD.Close()
        Else
            RD.Close()
            LBBARANG.Text = ""
            LBSATUAN.Text = ""
            LBHARGA.Text = ""
        End If
        RD.Close()
    End Sub

    Private Sub TXTKODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTKODE.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTTGLAWAL.Select()
        End If
    End Sub

    Private Sub BTNCARI_Click(sender As Object, e As EventArgs) Handles BTNCARI.Click
        TAMPIL_PNCARI()
    End Sub

    Private Sub TXTKODE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTKODE.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
        End Select
    End Sub

    Private Sub TXTCARI_BARANG_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F1
                TAMPIL_PNCARI()
        End Select
    End Sub

    Private Sub TXTTGLAKHIR_ValueChanged(sender As Object, e As EventArgs) Handles TXTTGLAKHIR.ValueChanged
        If TXTTGLAKHIR.Value < TXTTGLAWAL.Value Then
            MsgBox("Tanggal akhir diskon harus lebih besar atau sama dengan tanggal awal!")
            TXTTGLAKHIR.Value = TXTTGLAWAL.Value
        End If
    End Sub

    Private Sub TXTTGLAWAL_ValueChanged(sender As Object, e As EventArgs) Handles TXTTGLAWAL.ValueChanged
        TXTTGLAKHIR.Value = TXTTGLAWAL.Value
    End Sub

    Private Sub CBTAMPIL_TextChanged(sender As Object, e As EventArgs) Handles CBTAMPIL.TextChanged
        TAMPIL()
    End Sub

    Private Sub TXTDISKON_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTDISKON.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            TXTDISKON_RUPIAH.Select()
        End If
    End Sub

    Private Sub TXTDISKON_TextChanged(sender As Object, e As EventArgs) Handles TXTDISKON.TextChanged
        Dim DISKON As Integer = 0
        If TXTDISKON.Text <> "" Then
            DISKON = CInt(TXTDISKON.Text)
            TXTDISKON_RUPIAH.Text = ""
        Else
            DISKON = 0
        End If

        If DISKON > 100 Then
            MsgBox("Diskon maksimal 100%!")
            TXTDISKON.Text = ""
            TXTDISKON.Select()
        End If
    End Sub

    Private Sub TXTTGLAWAL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTGLAWAL.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTTGLAKHIR.Select()
        End If
    End Sub

    Private Sub TXTTGLAKHIR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTTGLAKHIR.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTDISKON.Select()
        End If
    End Sub

    Sub KONDISI_AWAL()
        Label5.Visible = False
        Label6.Visible = False
        Label16.Visible = False
        Label7.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        TXTKODE.Visible = False
        LBBARANG.Visible = False
        LBSATUAN.Visible = False
        LBHARGA.Visible = False
        TXTTGLAWAL.Visible = False
        TXTTGLAKHIR.Visible = False
        TXTDISKON.Visible = False
        TXTDISKON_RUPIAH.Visible = False
        BTNSIMPAN.Visible = False
        BTNCARI.Visible = False
        Label12.Visible = False
        TXTMIN.Visible = False
        TXTDISKON.Clear()
        TXTDISKON_RUPIAH.Clear()
    End Sub

    Private Sub CBJENIS_TextChanged(sender As Object, e As EventArgs) Handles CBJENIS.TextChanged
        Select Case CBJENIS.SelectedIndex
            Case 0
                KONDISI_AWAL()
                Label5.Visible = True
                Label6.Visible = True
                Label16.Visible = True
                Label7.Visible = True
                Label13.Visible = True
                Label14.Visible = True
                TXTTGLAWAL.Visible = True
                TXTTGLAKHIR.Visible = True
                Label9.Visible = True
                Label10.Visible = True
                TXTKODE.Visible = True
                LBBARANG.Visible = True
                LBSATUAN.Visible = True
                LBHARGA.Visible = True
                TXTDISKON.Visible = True
                TXTDISKON_RUPIAH.Visible = True
                BTNSIMPAN.Visible = True
                BTNCARI.Visible = True
            Case 1
                KONDISI_AWAL()
                Label12.Visible = True
                TXTMIN.Visible = True
                TXTTGLAWAL.Visible = True
                TXTTGLAKHIR.Visible = True
                Label9.Visible = True
                Label10.Visible = True
                Label13.Visible = True
                Label14.Visible = True
                TXTDISKON.Visible = True
                TXTDISKON_RUPIAH.Visible = True
                BTNSIMPAN.Visible = True
        End Select
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        If CBJENIS.SelectedIndex = 0 Then
            If TXTKODE.Text = "" Or LBBARANG.Text = "" Or TXTTGLAWAL.Text = "" Or TXTTGLAKHIR.Text = "" Or (TXTDISKON.Text = "" And TXTDISKON_RUPIAH.Text = "") Then
                MsgBox("Data tidak lengkap!")
                TXTKODE.Select()
            Else
                Dim STR As String = "SELECT Id FROM tbl_diskon" &
                " WHERE Kode='" & TXTKODE.Text & "'" &
                " AND Jenis = 'B'" &
                " AND ((Tgl_awal <= '" & Format(TXTTGLAWAL.Value, "yyyy-MM-dd") & "' AND Tgl_akhir >= '" & Format(TXTTGLAKHIR.Value, "yyyy-MM-dd") & "')" &
                " OR (Tgl_awal <= '" & Format(TXTTGLAKHIR.Value, "yyyy-MM-dd") & "' AND Tgl_akhir >= '" & Format(TXTTGLAKHIR.Value, "yyyy-MM-dd") & "')" &
                " OR (Tgl_awal <= '" & Format(TXTTGLAWAL.Value, "yyyy-MM-dd") & "' AND Tgl_awal >= '" & Format(TXTTGLAWAL.Value, "yyyy-MM-dd") & "')" &
                " OR (Tgl_awal >= '" & Format(TXTTGLAWAL.Value, "yyyy-MM-dd") & "' AND Tgl_akhir <= '" & Format(TXTTGLAKHIR.Value, "yyyy-MM-dd") & "'))"
                Dim CMD As New MySqlCommand(STR, CONN)
                Dim RD As MySqlDataReader
                RD = CMD.ExecuteReader
                If RD.HasRows Then
                    MsgBox("Data diskon sudah ada! Silahkan pilih barang/tanggal lain!")
                    RD.Close()
                Else
                    RD.Close()
                    If TXTDISKON.Text = "" Then
                        STR = "INSERT INTO tbl_diskon (Jenis, Kode, Jenis_nominal, Diskon, Tgl_awal, Tgl_akhir, Created_at)" &
                            " VALUES(" &
                            " 'B'," &
                            " '" & TXTKODE.Text & "'," &
                            " 'R'," &
                            " " & TXTDISKON_RUPIAH.Text.ToString.Replace(",", ".") & "," &
                            " '" & Format(TXTTGLAWAL.Value, "yyyy-MM-dd") & "'," &
                            " '" & Format(TXTTGLAKHIR.Value, "yyyy-MM-dd") & "'," &
                            " '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                            " )"
                    Else
                        STR = "INSERT INTO tbl_diskon (Jenis, Kode, Jenis_nominal, Diskon, Tgl_awal, Tgl_akhir, Created_at)" &
                            " VALUES(" &
                            " 'B'," &
                            " '" & TXTKODE.Text & "'," &
                            " 'P'," &
                            " " & TXTDISKON.Text.ToString.Replace(",", ".") & "," &
                            " '" & Format(TXTTGLAWAL.Value, "yyyy-MM-dd") & "'," &
                            " '" & Format(TXTTGLAKHIR.Value, "yyyy-MM-dd") & "'," &
                            " '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                            " )"
                    End If
                    CMD = New MySqlCommand(STR, CONN)
                    CMD.ExecuteNonQuery()
                    MsgBox("Data tersimpan")
                    TXTKODE.Clear()
                    TXTDISKON.Clear()
                    TXTDISKON_RUPIAH.Clear()
                    TXTKODE.Select()
                    TAMPIL()
                End If
            End If
        ElseIf CBJENIS.SelectedIndex = 1 Then
            If TXTMIN.Text = "" Or TXTTGLAWAL.Text = "" Or TXTTGLAKHIR.Text = "" Or (TXTDISKON.Text = "" And TXTDISKON_RUPIAH.Text = "") Then
                MsgBox("Data tidak lengkap!")
                TXTKODE.Select()
            Else
                Dim STR As String
                If TXTDISKON.Text = "" Then
                    STR = "INSERT INTO tbl_diskon (Jenis, Min_transaksi, Jenis_nominal, Diskon, Tgl_awal, Tgl_akhir, Created_at)" &
                        " VALUES(" &
                        " 'A'," &
                        " '" & TXTMIN.Text & "'," &
                        " 'R'," &
                        " " & TXTDISKON_RUPIAH.Text.ToString.Replace(",", ".") & "," &
                        " '" & Format(TXTTGLAWAL.Value, "yyyy-MM-dd") & "'," &
                        " '" & Format(TXTTGLAKHIR.Value, "yyyy-MM-dd") & "'," &
                        " '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                        " )"
                Else
                    STR = "INSERT INTO tbl_diskon (Jenis, Min_transaksi, Jenis_nominal, Diskon, Tgl_awal, Tgl_akhir, Created_at)" &
                        " VALUES(" &
                        " 'A'," &
                        " '" & TXTMIN.Text & "'," &
                        " 'P'," &
                        " " & TXTDISKON.Text.ToString.Replace(",", ".") & "," &
                        " '" & Format(TXTTGLAWAL.Value, "yyyy-MM-dd") & "'," &
                        " '" & Format(TXTTGLAKHIR.Value, "yyyy-MM-dd") & "'," &
                        " '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                        " )"
                End If
                Dim CMD As New MySqlCommand(STR, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Data tersimpan")
                TXTMIN.Clear()
                TXTDISKON.Clear()
                CBJENIS.Select()
                TAMPIL()
            End If
        End If
    End Sub

    Private Sub TXTMIN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTMIN.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            TXTTGLAWAL.Select()
        End If
    End Sub

    Private Sub CBJENIS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBJENIS.KeyPress
        If e.KeyChar = Chr(13) Then
            If CBJENIS.SelectedIndex = 0 Then
                TXTKODE.Select()
            ElseIf CBJENIS.SelectedIndex = 1 Then
                TXTMIN.Select()
            End If
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

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
    End Sub

    Private Sub BTNMASUK_Click(sender As Object, e As EventArgs) Handles BTNMASUK.Click
        BUKA_FORM(FR_MASUK)
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

    Private Sub CBTAMPIL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBTAMPIL.KeyPress
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTDISKON_RUPIAH_TextChanged(sender As Object, e As EventArgs) Handles TXTDISKON_RUPIAH.TextChanged
        Dim DISKON As Integer = 0
        If TXTDISKON_RUPIAH.Text <> "" Then
            DISKON = CInt(TXTDISKON_RUPIAH.Text)
            TXTDISKON.Clear()
        Else
            DISKON = 0
        End If

        If CBJENIS.SelectedIndex = 0 Then
            Dim HARGA_TERENDAH As Integer = 0
            If LBHARGA.Text <> "" Then
                HARGA_TERENDAH = CInt(LBHARGA.Text)
            Else
                HARGA_TERENDAH = 0
            End If

            If DISKON > HARGA_TERENDAH Then
                MsgBox("Diskon melebihi harga terendah")
                TXTDISKON_RUPIAH.Clear()
                TXTDISKON_RUPIAH.Select()
            End If
        Else
            Dim MIN_TRANS As Integer = 0
            If TXTMIN.Text <> "" Then
                MIN_TRANS = CInt(TXTMIN.Text)
            Else
                MIN_TRANS = 0
            End If

            If DISKON > MIN_TRANS Then
                MsgBox("Diskon melebihi minimal transaksi")
                TXTDISKON_RUPIAH.Clear()
                TXTDISKON_RUPIAH.Select()
            End If
        End If
    End Sub

    Private Sub TXTDISKON_RUPIAH_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTDISKON_RUPIAH.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If
    End Sub

    Private Sub DGTAMPIL_SelectionChanged(sender As Object, e As EventArgs) Handles DGTAMPIL.SelectionChanged
        DGTAMPIL.ClearSelection()
    End Sub

    Private Sub DGTAMPIL_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTAMPIL.CellClick
        Dim STR As String
        Dim CMD As MySqlCommand

        If e.RowIndex >= 0 Then
            If DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Cetak" Then
                Dim DT As New DataTable
                With DT
                    .Columns.Add("Kode")
                    .Columns.Add("Nama Barang")
                    .Columns.Add("Tanggal")
                    .Columns.Add("Diskon")
                End With
                DT.Rows.Add(DGTAMPIL.CurrentRow.Cells("Kode Barang").Value,
                    DGTAMPIL.CurrentRow.Cells("Nama Barang").Value,
                    DGTAMPIL.CurrentRow.Cells("Tanggal Awal").Value & " - " & DGTAMPIL.CurrentRow.Cells("Tanggal Akhir").Value,
                            DGTAMPIL.CurrentRow.Cells("Diskon").Value)

                Dim printDialog1 As New PrintDialog
                Dim printDocument1 As New System.Drawing.Printing.PrintDocument
                'Open the PrintDialog
                printDialog1.Document = printDocument1

                Dim dr As DialogResult = printDialog1.ShowDialog()

                'Here's where you can catch them aborting the print..

                If dr = System.Windows.Forms.DialogResult.OK Then
                    'Get the Copy times
                    Dim nCopies As Integer = printDocument1.PrinterSettings.Copies
                    'Get the number of Start Page
                    Dim sPage As Integer = printDocument1.PrinterSettings.FromPage
                    'Get the number of End page
                    Dim ePage As Integer = printDocument1.PrinterSettings.ToPage
                    'Get the printer name
                    Dim PrinterName As String = printDocument1.PrinterSettings.PrinterName

                    Dim RPT As New RPT_CETAKDISKON
                    Try
                        With RPT
                            .SetDataSource(DT)
                            .PrintOptions.PrinterName = PrinterName
                            .PrintToPrinter(nCopies, False, sPage, ePage)
                        End With
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString())
                    End Try
                End If
            ElseIf DGTAMPIL.Columns(e.ColumnIndex).HeaderText = "Delete" Then
                If MsgBox("Apakah anda yakin akan menghapus data diskon?", vbYesNo) = vbYes Then
                    DGTAMPIL.Columns(0).Visible = True
                    Dim IDX As String = DGTAMPIL.CurrentRow.Cells("Id").Value
                    DGTAMPIL.Columns(0).Visible = False
                    CMD = New MySqlCommand("DELETE FROM tbl_diskon WHERE Id='" & IDX & "'", CONN)
                    CMD.ExecuteNonQuery()
                    TAMPIL()
                    MsgBox("Data transaksi berhasil dihapus")
                End If
            End If
        End If
    End Sub
End Class