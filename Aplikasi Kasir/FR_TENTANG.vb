Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.IO

Public Class FR_TENTANG
    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Close()
    End Sub

    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub FR_TENTANG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label25.Text = VERSI

        Select Case ROLE
            Case 1
                GBTOKO.Visible = True
                PNADMIN.Visible = True
                PNKASIR.Visible = False
                PNOPS.Visible = False
                Label3.Text = "Administrator"
            Case 2
                GBTOKO.Visible = False
                PNADMIN.Visible = False
                PNKASIR.Visible = False
                PNOPS.Visible = True
                Label3.Text = "Operator"
            Case 3
                GBTOKO.Visible = False
                PNADMIN.Visible = False
                PNKASIR.Visible = True
                PNOPS.Visible = False
                Label3.Text = "Kasir"
        End Select

        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True
        LBLUSER.Text = NAMA_LOGIN
        KONDISI_AWAL()
        KONDISI_AWAL_TOKO()
        TAMPIL()
    End Sub

    Sub TAMPIL()
        Dim STR As String = "SELECT * FROM tbl_karyawan WHERE RTRIM(Id)='" & My.Settings.ID_ACCOUNT & "'"
        Dim RD As MySqlDataReader
        Try
            RD = EXECUTE_READER(STR)
            If RD.HasRows Then
                RD.Read()

                Dim ROLE As String
                If RD.Item("Role") = 1 Then
                    ROLE = "Administrator"
                ElseIf RD.Item("Role") = 2 Then
                    ROLE = "Admin Barang"
                Else
                    ROLE = "Kasir"
                End If
                Dim JK As String
                If RD.Item("JK") = "L" Then
                    JK = "Laki-laki"
                Else
                    JK = "Perempuan"
                End If

                LBID.Text = RD.Item("Id").ToString.Trim
                LBNAMA.Text = RD.Item("Nama").ToString.Trim
                LBROLE.Text = ROLE
                LBALAMAT.Text = RD.Item("Alamat").ToString.Trim
                LBTGLLAHIR.Text = RD.Item("Tgl_lahir")
                LBJK.Text = JK
                LBNO.Text = RD.Item("No_hp").ToString.Trim

                TXTID.Text = LBID.Text
                TXTNAMA.Text = LBNAMA.Text
                TXTROLE.Text = LBROLE.Text
                TXTALAMAT.Text = LBALAMAT.Text
                TXTTGL.Value = LBTGLLAHIR.Text
                TXTJK.Text = LBJK.Text
                TXTNO.Text = LBNO.Text
            End If
            RD.Close()
        Finally
            TUTUP_KONEKSI()
        End Try

        AMBIL_DATA_REGISTRY()
        LBNAMATOKO.Text = NAMA_TOKO
        LBALAMATTOKO.Text = ALAMAT_TOKO
        LBNOTOKO.Text = NO_TOKO
        LBPRINTER_NOTA.Text = PRINTER_NOTA
        LB_POINTMEMBER.Text = POINT_MEMBER
        If CUSTOMER_DISPLAY Then
            LB_CUSTOMER_DISPLAY.Text = "Ya"
        Else
            LB_CUSTOMER_DISPLAY.Text = "Tidak"
        End If

        TXTNAMATOKO.Text = LBNAMATOKO.Text
        TXTALAMATTOKO.Text = LBALAMATTOKO.Text
        TXTNOTOKO.Text = LBNOTOKO.Text
        TXTPRINTER_NOTA.Text = LBPRINTER_NOTA.Text
        TXT_CUSTOMER_DISPLAY.Text = LB_CUSTOMER_DISPLAY.Text
        TXT_POINTMEMBER.Text = LB_POINTMEMBER.Text
    End Sub

    Sub TAMPIL_TOKO()
        If URL_LOGO <> "" Then
            Dim IMAGESTREAM As New MemoryStream
            IMAGESTREAM = New MemoryStream(Convert.FromBase64String(URL_LOGO))
            PBLOGO.Image = Image.FromStream(IMAGESTREAM)
        End If

        TXTNAMATOKO.Text = LBNAMATOKO.Text
        TXTALAMATTOKO.Text = LBALAMATTOKO.Text
        TXTNOTOKO.Text = LBNOTOKO.Text
        TXT_CUSTOMER_DISPLAY.Text = LB_CUSTOMER_DISPLAY.Text
        TXT_POINTMEMBER.Text = LBNO.Text
    End Sub

    Private Sub BTNSIMPAN_Click(sender As Object, e As EventArgs) Handles BTNSIMPAN.Click
        Dim PASSWORD As String
        Dim STR As String = "SELECT Password FROM tbl_karyawan WHERE RTRIM(Id)='" & My.Settings.ID_ACCOUNT & "'"
        Dim CMD As MySqlCommand
        CMD = New MySqlCommand(STR, CONN)
        Dim RD As MySqlDataReader
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            RD.Read()
            PASSWORD = RD.Item("Password").ToString.Trim
            RD.Close()
        Else
            RD.Close()
        End If
        RD.Close()

        If TXTPWLAMA.Text = "" Or TXTPWBARU1.Text = "" Or TXTPWBARU2.Text = "" Then
            MsgBox("Data Tidak Lengkap!")
            TXTPWLAMA.Select()
        ElseIf TXTPWBARU1.Text <> TXTPWBARU2.Text Then
            MsgBox("Konfirmasi Password Tidak Sama!")
            TXTPWBARU1.Select()
        ElseIf Not TXTPWLAMA.Text = PASSWORD Then
            MsgBox("Password Lama Salah!")
            TXTPWLAMA.Select()
        Else
            STR = "UPDATE tbl_karyawan SET Password='" & TXTPWBARU1.Text & "', " &
                " Modified_at = '" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
                " WHERE Id='" & My.Settings.ID_ACCOUNT & "'"
            CMD = New MySqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()

            MsgBox("Password berhasil diubah!")
            TXTPWLAMA.Clear()
            TXTPWBARU1.Clear()
            TXTPWBARU2.Clear()
        End If
    End Sub

    Private Sub TXTPWLAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPWLAMA.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTPWBARU1.Select()
        End If
    End Sub

    Private Sub TXTPWBARU1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPWBARU1.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTPWBARU2.Select()
        End If
    End Sub

    Private Sub TXTPWBARU2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPWBARU2.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSIMPAN.Select()
        End If
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        Dim FR As New Form
        Select Case ROLE
            Case 1
                FR = FR_MENU
            Case 2
                FR = FR_OPS_DASHBOARD
            Case 3
                FR = FR_KASIR_DASHBOARD
        End Select
        FR.Show()
        Me.Close()
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Sub KONDISI_AWAL()
        LBID.Visible = True
        LBNAMA.Visible = True
        LBROLE.Visible = True
        LBALAMAT.Visible = True
        LBTGLLAHIR.Visible = True
        LBJK.Visible = True
        LBNO.Visible = True

        TXTID.Visible = False
        TXTNAMA.Visible = False
        TXTROLE.Visible = False
        TXTALAMAT.Visible = False
        TXTTGL.Visible = False
        TXTJK.Visible = False
        TXTNO.Visible = False
        BTNUBAH.Visible = True
        BTNSIMPANDIRI.Visible = False
        BTNCANCELDIRI.Visible = False
    End Sub

    Sub KONDISI_EDIT()
        LBID.Visible = False
        LBNAMA.Visible = False
        LBROLE.Visible = False
        LBALAMAT.Visible = False
        LBTGLLAHIR.Visible = False
        LBJK.Visible = False
        LBNO.Visible = False

        TXTID.Visible = True
        TXTNAMA.Visible = True
        TXTROLE.Visible = True
        TXTALAMAT.Visible = True
        TXTTGL.Visible = True
        TXTJK.Visible = True
        TXTNO.Visible = True
        BTNUBAH.Visible = False
        BTNSIMPANDIRI.Visible = True
        BTNCANCELDIRI.Visible = True
    End Sub

    Sub KONDISI_AWAL_TOKO()
        LBNAMATOKO.Visible = True
        LBALAMATTOKO.Visible = True
        LBNOTOKO.Visible = True
        LB_CUSTOMER_DISPLAY.Visible = True
        LB_POINTMEMBER.Visible = True

        TXTNAMATOKO.Visible = False
        TXTALAMATTOKO.Visible = False
        TXTNOTOKO.Visible = False
        TXT_CUSTOMER_DISPLAY.Visible = False
        TXT_POINTMEMBER.Visible = False

        BTNUBAHTOKO.Visible = True
        BTNSIMPANTOKO.Visible = False
        BTNCANCELTOKO.Visible = False

        LBPRINTER_NOTA.Visible = True
        TXTPRINTER_NOTA.Visible = False

        BTNBROWSE.Visible = False

        TAMPIL_TOKO()
    End Sub

    Sub KONDISI_EDIT_TOKO()
        LBNAMATOKO.Visible = False
        LBALAMATTOKO.Visible = False
        LBNOTOKO.Visible = False
        LB_CUSTOMER_DISPLAY.Visible = False
        LB_POINTMEMBER.Visible = False

        TXTNAMATOKO.Visible = True
        TXTALAMATTOKO.Visible = True
        TXTNOTOKO.Visible = True
        TXT_CUSTOMER_DISPLAY.Visible = True
        TXT_POINTMEMBER.Visible = True

        BTNUBAHTOKO.Visible = False
        BTNSIMPANTOKO.Visible = True
        BTNCANCELTOKO.Visible = True

        LBPRINTER_NOTA.Visible = False
        TXTPRINTER_NOTA.Visible = True

        BTNBROWSE.Visible = True

        TXTPRINTER_NOTA.Items.Clear()
        For Each NAMA_PRINTER As String In PrinterSettings.InstalledPrinters
            TXTPRINTER_NOTA.Items.Add(NAMA_PRINTER)
        Next
    End Sub

    Private Sub BTNUBAH_Click(sender As Object, e As EventArgs) Handles BTNUBAH.Click
        TAMPIL()
        KONDISI_EDIT()
        TXTNAMA.Select()
    End Sub

    Private Sub BTNCANCELDIRI_Click(sender As Object, e As EventArgs) Handles BTNCANCELDIRI.Click
        TAMPIL()
        KONDISI_AWAL()
    End Sub

    Private Sub TXTNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNO.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            BTNSIMPANDIRI.Select()
        End If
    End Sub

    Private Sub TXTNAMA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNAMA.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTALAMAT.Select()
        End If
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTALAMAT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTALAMAT.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTJK.Select()
        End If
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTJK_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTJK.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTNO.Select()
        End If
    End Sub

    Private Sub BTNSIMPANDIRI_Click(sender As Object, e As EventArgs) Handles BTNSIMPANDIRI.Click
        If TXTNAMA.Text = "" Or TXTROLE.Text = "" Then
            MsgBox("Data tidak lengkap!")
        Else
            Dim jk As String = ""
            If TXTJK.Text = "Laki-laki" Then
                jk = "L"
            ElseIf TXTJK.Text = "Perempuan" Then
                jk = "P"
            End If

            Dim STR As String
            Dim CMD As MySqlCommand

            STR = "SELECT * FROM tbl_karyawan WHERE Id='" & TXTID.Text & "'"
            CMD = New MySqlCommand(STR, CONN)
            Dim RD As MySqlDataReader
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Close()
                STR = "UPDATE tbl_karyawan SET Nama='" & TXTNAMA.Text &
                    "',Alamat='" & TXTALAMAT.Text &
                    "',Tgl_lahir='" & Format(TXTTGL.Value, "yyyy-MM-dd") &
                    "',JK='" & jk &
                    "',No_hp='" & TXTNO.Text &
                    "',Modified_at='" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") &
                    "' WHERE Id='" & TXTID.Text & "'"
            Else
                RD.Close()
                MsgBox("Error")
            End If
            CMD = New MySqlCommand(STR, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil diri berhasil diperbarui")
            NAMA_LOGIN = TXTNAMA.Text
            TAMPIL()
            KONDISI_AWAL()
        End If
    End Sub

    Private Sub BTNUBAHTOKO_Click(sender As Object, e As EventArgs) Handles BTNUBAHTOKO.Click
        KONDISI_EDIT_TOKO()
        TAMPIL()
        TXTNAMATOKO.Select()
    End Sub

    Private Sub BTNCANCELTOKO_Click(sender As Object, e As EventArgs) Handles BTNCANCELTOKO.Click
        TAMPIL()
        KONDISI_AWAL_TOKO()
    End Sub

    Private Sub BTNSIMPANTOKO_Click(sender As Object, e As EventArgs) Handles BTNSIMPANTOKO.Click
        Dim NOTOKO As Integer = 0

        Dim IMGBYTE As Byte() = Nothing

        ' Cek apakah ada gambar di PictureBox
        If PBLOGO.Image IsNot Nothing Then
            Dim MS As New MemoryStream
            PBLOGO.Image.Save(MS, Imaging.ImageFormat.Jpeg)
            IMGBYTE = MS.GetBuffer()
            MS.Close()
        End If


        If TXTNOTOKO.Text <> "" Then
            NOTOKO = 1
        End If
        If TXTNAMATOKO.Text = "" Or TXTALAMATTOKO.Text = "" Or NOTOKO = 0 Or TXT_CUSTOMER_DISPLAY.Text = "" Or TXT_POINTMEMBER.Text = "" Or TXTPRINTER_NOTA.Text = "" Then
            MsgBox("Data tidak lengkap!")
        ElseIf PBLOGO.Image Is Nothing Then
            MsgBox("Logo toko belum dipilih!")
        Else
            If MsgBox("Apakah anda yakin akan mengubah data toko?", vbYesNo) = vbYes Then
                Dim CUSTOMERDISPLAY As Boolean = 0
                If TXT_CUSTOMER_DISPLAY.Text = "Ya" Then
                    CUSTOMERDISPLAY = 1
                End If
                MASUK_REGISTRY(TXTNAMATOKO.Text, TXTALAMATTOKO.Text, TXTNOTOKO.Text, TXTPRINTER_NOTA.Text, IMGBYTE, CUSTOMERDISPLAY, TXT_POINTMEMBER.Text)
                KONDISI_AWAL_TOKO()
                TAMPIL()
            End If
        End If
    End Sub

    Private Sub TXTNAMATOKO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNAMATOKO.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTALAMATTOKO.Select()
        End If
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTALAMATTOKO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTALAMATTOKO.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTNOTOKO.Select()
        End If
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTNOTOKO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTNOTOKO.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTPRINTER_NOTA.Select()
        End If

        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BTNBROWSE_Click(sender As Object, e As EventArgs) Handles BTNBROWSE.Click
        Dim OPF As New OpenFileDialog
        OPF.Filter = "Choose Image(*.JPG;*.JPEG;*.PNG)|*.jpg;*.jpeg;*.png"

        If OPF.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            PBLOGO.Image = Image.FromFile(OPF.FileName)
        End If
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        If MsgBox("Apakah anda yakin akan logout?", vbYesNo) = vbYes Then
            Dim FR As New FR_LOGIN
            My.Settings.ID_ACCOUNT = 0
            FR.Show()
            Me.Close()
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

    Private Sub BTNDASHBOARD_Click(sender As Object, e As EventArgs) Handles BTNDASHBOARD.Click
        BUKA_FORM(FR_MENU)
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

    Private Sub BTNMASUKOPS_Click(sender As Object, e As EventArgs) Handles BTNMASUKOPS.Click
        BUKA_FORM(FR_MASUK)
    End Sub

    Private Sub BTNRETURNOPS_Click(sender As Object, e As EventArgs) Handles BTNRETURNOPS.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAKOPS_Click(sender As Object, e As EventArgs) Handles BTNRUSAKOPS.Click
        BUKA_FORM(FR_RUSAK)
    End Sub

    Private Sub BTNMEMBER_OPS_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_OPS.Click
        BUKA_FORM(FR_MEMBER)
    End Sub

    Private Sub BTNVOUCHER_OPS_Click(sender As Object, e As EventArgs) Handles BTNVOUCHER_OPS.Click
        BUKA_FORM(FR_VOUCHER)
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

    Private Sub BTNMASUKKASIR_Click(sender As Object, e As EventArgs) Handles BTNMASUKKASIR.Click
        BUKA_FORM(FR_MASUK)
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

    Private Sub BTNMEMBER_KASIR_Click(sender As Object, e As EventArgs) Handles BTNMEMBER_KASIR.Click
        BUKA_FORM(FR_MEMBER)
    End Sub

    Private Sub BTN_BACKRESDB_Click(sender As Object, e As EventArgs) Handles BTN_BACKRESDB.Click
        Me.Enabled = False
        With FR_TENTANG_BACKRESDB
            .Show()
            .CB_ACTION.Select()
        End With
    End Sub

    Private Sub TXT_POINTMEMBER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_POINTMEMBER.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then
            e.Handled = True
        End If

        If e.KeyChar = Chr(13) Then
            BTNSIMPANTOKO.Select()
        End If
    End Sub

    Private Sub TXT_POINTMEMBER_Validated(sender As Object, e As EventArgs) Handles TXT_POINTMEMBER.Validated
        If TXT_POINTMEMBER.Text > 100 Or TXT_POINTMEMBER.Text < 0 Then
            MsgBox("Point member harus berada dalam range 0 - 100")
        End If
    End Sub

    Private Sub TXTPRINTER_NOTA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPRINTER_NOTA.KeyPress

    End Sub
End Class