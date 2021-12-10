Public Class FR_MENU
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim FR As New FR_LOGIN
        My.Settings.ID_ACCOUNT = 0
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Sub BUKA_FORM(ByVal FR As Form)
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub DataKaryawanToolStripMenuItem_Click(sender As Object, e As EventArgs)
        BUKA_FORM(FR_KASIR)
    End Sub

    Private Sub DataBarangToolStripMenuItem_Click(sender As Object, e As EventArgs)
        BUKA_FORM(FR_PRODUK)
    End Sub

    Private Sub BarangMasukToolStripMenuItem_Click(sender As Object, e As EventArgs)
        BUKA_FORM(FR_MASUK)
    End Sub

    Private Sub BarangKeluarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'BUKA_FORM(FR_KELUAR)'
        Dim FR As New FR_KELUAR
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub LaporanToolStripMenuItem_Click(sender As Object, e As EventArgs)
        BUKA_FORM(FR_REPORT)
    End Sub

    Private Sub TentangToolStripMenuItem_Click(sender As Object, e As EventArgs)
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub FR_MENU_Load(sender As Object, e As EventArgs) Handles Me.Load
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
        PEWAKTU.Enabled = True

        LBLUSER.Text = NAMA_LOGIN
    End Sub

    Private Sub PEWAKTU_Tick(sender As Object, e As EventArgs) Handles PEWAKTU.Tick
        LBTGL.Text = Format(Date.Now, "dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub FR_MENU_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub BTNEXIT_Click(sender As Object, e As EventArgs)
        Dim FR As New FR_LOGIN
        My.Settings.ID_ACCOUNT = 0
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub BTNCLOSE_Click(sender As Object, e As EventArgs) Handles BTNCLOSE.Click
        Me.Close()
    End Sub

    Private Sub BTNMINIMIZE_Click(sender As Object, e As EventArgs) Handles BTNMINIMIZE.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BTNDISKON_Click(sender As Object, e As EventArgs) Handles BTNDISKON.Click
        BUKA_FORM(FR_DISKON)
    End Sub

    Private Sub BTNKASIR_Click(sender As Object, e As EventArgs) Handles BTNKASIR.Click
        BUKA_FORM(FR_KASIR)
    End Sub

    Private Sub BTNBARANG_Click(sender As Object, e As EventArgs) Handles BTNBARANG.Click
        BUKA_FORM(FR_PRODUK)
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

    Private Sub BTNTENTANG_Click(sender As Object, e As EventArgs) Handles BTNTENTANG.Click
        BUKA_FORM(FR_TENTANG)
    End Sub

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
        Dim FR As New FR_LOGIN
        My.Settings.ID_ACCOUNT = 0
        FR.Show()
        Me.Hide()
    End Sub

    Private Sub BTNRETURN_Click(sender As Object, e As EventArgs) Handles BTNRETURN.Click
        BUKA_FORM(FR_RETURN)
    End Sub

    Private Sub BTNRUSAK_Click(sender As Object, e As EventArgs) Handles BTNRUSAK.Click
        BUKA_FORM(FR_RUSAK)
    End Sub
End Class
