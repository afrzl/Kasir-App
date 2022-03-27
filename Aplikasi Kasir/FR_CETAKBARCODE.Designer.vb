<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_CETAKBARCODE
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_CETAKBARCODE))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BTNCETAK = New System.Windows.Forms.Button()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNMINIMIZE = New System.Windows.Forms.Button()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BTNLOGOUT = New System.Windows.Forms.Button()
        Me.LBTGL = New System.Windows.Forms.Label()
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.BTNNEXT = New System.Windows.Forms.Button()
        Me.BTNPREV = New System.Windows.Forms.Button()
        Me.DGBARANG = New System.Windows.Forms.DataGridView()
        Me.TXTCARI = New System.Windows.Forms.TextBox()
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.PNOPS = New System.Windows.Forms.Panel()
        Me.BTNMASUKOPS = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.BTNKELUAROPS = New System.Windows.Forms.Button()
        Me.BTNLAPORANOPS = New System.Windows.Forms.Button()
        Me.BTNDASHBOARDOPS = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.BTNRETURNOPS = New System.Windows.Forms.Button()
        Me.BTNRUSAKOPS = New System.Windows.Forms.Button()
        Me.BTNTENTANGOPS = New System.Windows.Forms.Button()
        Me.BTNLABELOPS = New System.Windows.Forms.Button()
        Me.BTNBARCODEOPS = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBLUSER = New System.Windows.Forms.Label()
        Me.PNLEFT = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PEWAKTU = New System.Windows.Forms.Timer(Me.components)
        Me.PRINTBARCODE = New System.Drawing.Printing.PrintDocument()
        Me.PNCONTROL.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PNCONTENT.SuspendLayout()
        CType(Me.DGBARANG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNTOP.SuspendLayout()
        Me.PNOPS.SuspendLayout()
        Me.PNLEFT.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(102, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 1)
        Me.Label4.TabIndex = 17
        '
        'BTNCETAK
        '
        Me.BTNCETAK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNCETAK.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNCETAK.FlatAppearance.BorderSize = 0
        Me.BTNCETAK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNCETAK.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCETAK.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNCETAK.Location = New System.Drawing.Point(881, 677)
        Me.BTNCETAK.Name = "BTNCETAK"
        Me.BTNCETAK.Size = New System.Drawing.Size(168, 39)
        Me.BTNCETAK.TabIndex = 74
        Me.BTNCETAK.Text = "Cetak Barcode"
        Me.BTNCETAK.UseVisualStyleBackColor = False
        '
        'PNCONTROL
        '
        Me.PNCONTROL.Controls.Add(Me.BTNMINIMIZE)
        Me.PNCONTROL.Controls.Add(Me.BTNCLOSE)
        Me.PNCONTROL.Dock = System.Windows.Forms.DockStyle.Right
        Me.PNCONTROL.Location = New System.Drawing.Point(1020, 0)
        Me.PNCONTROL.Name = "PNCONTROL"
        Me.PNCONTROL.Size = New System.Drawing.Size(76, 40)
        Me.PNCONTROL.TabIndex = 0
        '
        'BTNMINIMIZE
        '
        Me.BTNMINIMIZE.FlatAppearance.BorderSize = 0
        Me.BTNMINIMIZE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNMINIMIZE.Image = Global.Aplikasi_Kasir.My.Resources.Resources.minimize15px
        Me.BTNMINIMIZE.Location = New System.Drawing.Point(11, 10)
        Me.BTNMINIMIZE.Name = "BTNMINIMIZE"
        Me.BTNMINIMIZE.Size = New System.Drawing.Size(18, 18)
        Me.BTNMINIMIZE.TabIndex = 2
        Me.BTNMINIMIZE.UseVisualStyleBackColor = True
        '
        'BTNCLOSE
        '
        Me.BTNCLOSE.FlatAppearance.BorderSize = 0
        Me.BTNCLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNCLOSE.Image = Global.Aplikasi_Kasir.My.Resources.Resources.close15px
        Me.BTNCLOSE.Location = New System.Drawing.Point(46, 10)
        Me.BTNCLOSE.Name = "BTNCLOSE"
        Me.BTNCLOSE.Size = New System.Drawing.Size(18, 18)
        Me.BTNCLOSE.TabIndex = 0
        Me.BTNCLOSE.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BTNLOGOUT)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 704)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(270, 64)
        Me.Panel1.TabIndex = 0
        '
        'BTNLOGOUT
        '
        Me.BTNLOGOUT.FlatAppearance.BorderSize = 0
        Me.BTNLOGOUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNLOGOUT.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNLOGOUT.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNLOGOUT.Image = Global.Aplikasi_Kasir.My.Resources.Resources.logout
        Me.BTNLOGOUT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLOGOUT.Location = New System.Drawing.Point(3, 17)
        Me.BTNLOGOUT.Name = "BTNLOGOUT"
        Me.BTNLOGOUT.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNLOGOUT.Size = New System.Drawing.Size(270, 35)
        Me.BTNLOGOUT.TabIndex = 14
        Me.BTNLOGOUT.Text = "     Logout"
        Me.BTNLOGOUT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLOGOUT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNLOGOUT.UseVisualStyleBackColor = True
        '
        'LBTGL
        '
        Me.LBTGL.AutoSize = True
        Me.LBTGL.Cursor = System.Windows.Forms.Cursors.Default
        Me.LBTGL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LBTGL.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBTGL.ForeColor = System.Drawing.Color.Black
        Me.LBTGL.Location = New System.Drawing.Point(6, 8)
        Me.LBTGL.Name = "LBTGL"
        Me.LBTGL.Size = New System.Drawing.Size(192, 23)
        Me.LBTGL.TabIndex = 0
        Me.LBTGL.Text = "31 Januari 2021 88:88:88"
        '
        'PNCONTENT
        '
        Me.PNCONTENT.Controls.Add(Me.BTNCETAK)
        Me.PNCONTENT.Controls.Add(Me.BTNNEXT)
        Me.PNCONTENT.Controls.Add(Me.BTNPREV)
        Me.PNCONTENT.Controls.Add(Me.DGBARANG)
        Me.PNCONTENT.Controls.Add(Me.TXTCARI)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(270, 40)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(1096, 728)
        Me.PNCONTENT.TabIndex = 18
        '
        'BTNNEXT
        '
        Me.BTNNEXT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNNEXT.BackColor = System.Drawing.Color.DarkBlue
        Me.BTNNEXT.FlatAppearance.BorderSize = 0
        Me.BTNNEXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNNEXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNNEXT.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNNEXT.Location = New System.Drawing.Point(999, 13)
        Me.BTNNEXT.Name = "BTNNEXT"
        Me.BTNNEXT.Size = New System.Drawing.Size(50, 29)
        Me.BTNNEXT.TabIndex = 67
        Me.BTNNEXT.Text = ">"
        Me.BTNNEXT.UseVisualStyleBackColor = False
        '
        'BTNPREV
        '
        Me.BTNPREV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNPREV.BackColor = System.Drawing.Color.DarkBlue
        Me.BTNPREV.FlatAppearance.BorderSize = 0
        Me.BTNPREV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNPREV.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNPREV.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNPREV.Location = New System.Drawing.Point(943, 13)
        Me.BTNPREV.Name = "BTNPREV"
        Me.BTNPREV.Size = New System.Drawing.Size(50, 29)
        Me.BTNPREV.TabIndex = 66
        Me.BTNPREV.Text = "<"
        Me.BTNPREV.UseVisualStyleBackColor = False
        '
        'DGBARANG
        '
        Me.DGBARANG.AllowUserToAddRows = False
        Me.DGBARANG.AllowUserToDeleteRows = False
        Me.DGBARANG.AllowUserToResizeColumns = False
        Me.DGBARANG.AllowUserToResizeRows = False
        Me.DGBARANG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGBARANG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.NullValue = "-"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGBARANG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGBARANG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGBARANG.Location = New System.Drawing.Point(24, 49)
        Me.DGBARANG.MultiSelect = False
        Me.DGBARANG.Name = "DGBARANG"
        Me.DGBARANG.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGBARANG.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGBARANG.RowHeadersVisible = False
        Me.DGBARANG.RowHeadersWidth = 51
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGBARANG.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGBARANG.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGBARANG.RowTemplate.Height = 30
        Me.DGBARANG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGBARANG.Size = New System.Drawing.Size(1025, 622)
        Me.DGBARANG.TabIndex = 65
        '
        'TXTCARI
        '
        Me.TXTCARI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTCARI.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCARI.Location = New System.Drawing.Point(22, 13)
        Me.TXTCARI.Name = "TXTCARI"
        Me.TXTCARI.Size = New System.Drawing.Size(915, 30)
        Me.TXTCARI.TabIndex = 64
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.LBTGL)
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(270, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(1096, 40)
        Me.PNTOP.TabIndex = 17
        '
        'PNOPS
        '
        Me.PNOPS.Controls.Add(Me.BTNMASUKOPS)
        Me.PNOPS.Controls.Add(Me.Label23)
        Me.PNOPS.Controls.Add(Me.BTNKELUAROPS)
        Me.PNOPS.Controls.Add(Me.BTNLAPORANOPS)
        Me.PNOPS.Controls.Add(Me.BTNDASHBOARDOPS)
        Me.PNOPS.Controls.Add(Me.Label24)
        Me.PNOPS.Controls.Add(Me.BTNRETURNOPS)
        Me.PNOPS.Controls.Add(Me.BTNRUSAKOPS)
        Me.PNOPS.Controls.Add(Me.BTNTENTANGOPS)
        Me.PNOPS.Controls.Add(Me.BTNLABELOPS)
        Me.PNOPS.Controls.Add(Me.BTNBARCODEOPS)
        Me.PNOPS.Location = New System.Drawing.Point(0, 112)
        Me.PNOPS.Name = "PNOPS"
        Me.PNOPS.Size = New System.Drawing.Size(270, 541)
        Me.PNOPS.TabIndex = 58
        '
        'BTNMASUKOPS
        '
        Me.BTNMASUKOPS.FlatAppearance.BorderSize = 0
        Me.BTNMASUKOPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNMASUKOPS.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMASUKOPS.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNMASUKOPS.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNMASUKOPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNMASUKOPS.Location = New System.Drawing.Point(0, 224)
        Me.BTNMASUKOPS.Name = "BTNMASUKOPS"
        Me.BTNMASUKOPS.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNMASUKOPS.Size = New System.Drawing.Size(270, 35)
        Me.BTNMASUKOPS.TabIndex = 54
        Me.BTNMASUKOPS.Text = "     Barang Masuk"
        Me.BTNMASUKOPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNMASUKOPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNMASUKOPS.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label23.Location = New System.Drawing.Point(7, 34)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(125, 28)
        Me.Label23.TabIndex = 20
        Me.Label23.Text = "Menu Utama"
        '
        'BTNKELUAROPS
        '
        Me.BTNKELUAROPS.FlatAppearance.BorderSize = 0
        Me.BTNKELUAROPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNKELUAROPS.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNKELUAROPS.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNKELUAROPS.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNKELUAROPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNKELUAROPS.Location = New System.Drawing.Point(0, 273)
        Me.BTNKELUAROPS.Name = "BTNKELUAROPS"
        Me.BTNKELUAROPS.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNKELUAROPS.Size = New System.Drawing.Size(270, 35)
        Me.BTNKELUAROPS.TabIndex = 25
        Me.BTNKELUAROPS.Text = "     Barang Keluar"
        Me.BTNKELUAROPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNKELUAROPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNKELUAROPS.UseVisualStyleBackColor = True
        '
        'BTNLAPORANOPS
        '
        Me.BTNLAPORANOPS.FlatAppearance.BorderSize = 0
        Me.BTNLAPORANOPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNLAPORANOPS.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNLAPORANOPS.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNLAPORANOPS.Image = Global.Aplikasi_Kasir.My.Resources.Resources.laporan
        Me.BTNLAPORANOPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLAPORANOPS.Location = New System.Drawing.Point(0, 420)
        Me.BTNLAPORANOPS.Name = "BTNLAPORANOPS"
        Me.BTNLAPORANOPS.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNLAPORANOPS.Size = New System.Drawing.Size(270, 35)
        Me.BTNLAPORANOPS.TabIndex = 26
        Me.BTNLAPORANOPS.Text = "     Laporan"
        Me.BTNLAPORANOPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLAPORANOPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNLAPORANOPS.UseVisualStyleBackColor = True
        '
        'BTNDASHBOARDOPS
        '
        Me.BTNDASHBOARDOPS.FlatAppearance.BorderSize = 0
        Me.BTNDASHBOARDOPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNDASHBOARDOPS.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNDASHBOARDOPS.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNDASHBOARDOPS.Image = Global.Aplikasi_Kasir.My.Resources.Resources.data_master
        Me.BTNDASHBOARDOPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNDASHBOARDOPS.Location = New System.Drawing.Point(0, 77)
        Me.BTNDASHBOARDOPS.Name = "BTNDASHBOARDOPS"
        Me.BTNDASHBOARDOPS.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNDASHBOARDOPS.Size = New System.Drawing.Size(270, 35)
        Me.BTNDASHBOARDOPS.TabIndex = 21
        Me.BTNDASHBOARDOPS.Text = "     Dashboard"
        Me.BTNDASHBOARDOPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNDASHBOARDOPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNDASHBOARDOPS.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label24.Location = New System.Drawing.Point(0, 131)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(5, 25)
        Me.Label24.TabIndex = 28
        '
        'BTNRETURNOPS
        '
        Me.BTNRETURNOPS.FlatAppearance.BorderSize = 0
        Me.BTNRETURNOPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNRETURNOPS.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNRETURNOPS.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNRETURNOPS.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNRETURNOPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRETURNOPS.Location = New System.Drawing.Point(0, 322)
        Me.BTNRETURNOPS.Name = "BTNRETURNOPS"
        Me.BTNRETURNOPS.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNRETURNOPS.Size = New System.Drawing.Size(270, 35)
        Me.BTNRETURNOPS.TabIndex = 53
        Me.BTNRETURNOPS.Text = "     Barang Return"
        Me.BTNRETURNOPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRETURNOPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNRETURNOPS.UseVisualStyleBackColor = True
        '
        'BTNRUSAKOPS
        '
        Me.BTNRUSAKOPS.FlatAppearance.BorderSize = 0
        Me.BTNRUSAKOPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNRUSAKOPS.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNRUSAKOPS.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNRUSAKOPS.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNRUSAKOPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRUSAKOPS.Location = New System.Drawing.Point(0, 371)
        Me.BTNRUSAKOPS.Name = "BTNRUSAKOPS"
        Me.BTNRUSAKOPS.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNRUSAKOPS.Size = New System.Drawing.Size(270, 35)
        Me.BTNRUSAKOPS.TabIndex = 55
        Me.BTNRUSAKOPS.Text = "     Barang Rusak"
        Me.BTNRUSAKOPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRUSAKOPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNRUSAKOPS.UseVisualStyleBackColor = True
        '
        'BTNTENTANGOPS
        '
        Me.BTNTENTANGOPS.FlatAppearance.BorderSize = 0
        Me.BTNTENTANGOPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNTENTANGOPS.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNTENTANGOPS.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNTENTANGOPS.Image = Global.Aplikasi_Kasir.My.Resources.Resources.tentang
        Me.BTNTENTANGOPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNTENTANGOPS.Location = New System.Drawing.Point(0, 469)
        Me.BTNTENTANGOPS.Name = "BTNTENTANGOPS"
        Me.BTNTENTANGOPS.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNTENTANGOPS.Size = New System.Drawing.Size(270, 35)
        Me.BTNTENTANGOPS.TabIndex = 27
        Me.BTNTENTANGOPS.Text = "     Setting"
        Me.BTNTENTANGOPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNTENTANGOPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNTENTANGOPS.UseVisualStyleBackColor = True
        '
        'BTNLABELOPS
        '
        Me.BTNLABELOPS.FlatAppearance.BorderSize = 0
        Me.BTNLABELOPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNLABELOPS.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNLABELOPS.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNLABELOPS.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNLABELOPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLABELOPS.Location = New System.Drawing.Point(0, 175)
        Me.BTNLABELOPS.Name = "BTNLABELOPS"
        Me.BTNLABELOPS.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNLABELOPS.Size = New System.Drawing.Size(270, 35)
        Me.BTNLABELOPS.TabIndex = 56
        Me.BTNLABELOPS.Text = "     Cetak Label"
        Me.BTNLABELOPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLABELOPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNLABELOPS.UseVisualStyleBackColor = True
        '
        'BTNBARCODEOPS
        '
        Me.BTNBARCODEOPS.FlatAppearance.BorderSize = 0
        Me.BTNBARCODEOPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNBARCODEOPS.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBARCODEOPS.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNBARCODEOPS.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNBARCODEOPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNBARCODEOPS.Location = New System.Drawing.Point(0, 126)
        Me.BTNBARCODEOPS.Name = "BTNBARCODEOPS"
        Me.BTNBARCODEOPS.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNBARCODEOPS.Size = New System.Drawing.Size(270, 35)
        Me.BTNBARCODEOPS.TabIndex = 57
        Me.BTNBARCODEOPS.Text = "     Cetak Barcode"
        Me.BTNBARCODEOPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNBARCODEOPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNBARCODEOPS.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(98, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Operator"
        '
        'LBLUSER
        '
        Me.LBLUSER.AutoSize = True
        Me.LBLUSER.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUSER.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LBLUSER.Location = New System.Drawing.Point(98, 52)
        Me.LBLUSER.Name = "LBLUSER"
        Me.LBLUSER.Size = New System.Drawing.Size(95, 23)
        Me.LBLUSER.TabIndex = 15
        Me.LBLUSER.Text = "Nama User"
        '
        'PNLEFT
        '
        Me.PNLEFT.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PNLEFT.Controls.Add(Me.PNOPS)
        Me.PNLEFT.Controls.Add(Me.Panel1)
        Me.PNLEFT.Controls.Add(Me.Label4)
        Me.PNLEFT.Controls.Add(Me.Label3)
        Me.PNLEFT.Controls.Add(Me.LBLUSER)
        Me.PNLEFT.Controls.Add(Me.Label2)
        Me.PNLEFT.Controls.Add(Me.Button1)
        Me.PNLEFT.Dock = System.Windows.Forms.DockStyle.Left
        Me.PNLEFT.Location = New System.Drawing.Point(0, 0)
        Me.PNLEFT.Name = "PNLEFT"
        Me.PNLEFT.Size = New System.Drawing.Size(270, 768)
        Me.PNLEFT.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(98, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Selamat datang,"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.Aplikasi_Kasir.My.Resources.Resources.avatar50px
        Me.Button1.Location = New System.Drawing.Point(12, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 80)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PEWAKTU
        '
        '
        'PRINTBARCODE
        '
        '
        'FR_CETAKBARCODE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNTOP)
        Me.Controls.Add(Me.PNLEFT)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FR_CETAKBARCODE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU CETAK BARCODE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PNCONTROL.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PNCONTENT.ResumeLayout(False)
        Me.PNCONTENT.PerformLayout()
        CType(Me.DGBARANG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNTOP.ResumeLayout(False)
        Me.PNTOP.PerformLayout()
        Me.PNOPS.ResumeLayout(False)
        Me.PNOPS.PerformLayout()
        Me.PNLEFT.ResumeLayout(False)
        Me.PNLEFT.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As Label
    Friend WithEvents BTNCETAK As Button
    Friend WithEvents BTNMINIMIZE As Button
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BTNLOGOUT As Button
    Friend WithEvents LBTGL As Label
    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents BTNNEXT As Button
    Friend WithEvents BTNPREV As Button
    Friend WithEvents DGBARANG As DataGridView
    Friend WithEvents PNTOP As Panel
    Friend WithEvents PNOPS As Panel
    Friend WithEvents BTNMASUKOPS As Button
    Friend WithEvents Label23 As Label
    Friend WithEvents BTNKELUAROPS As Button
    Friend WithEvents BTNLAPORANOPS As Button
    Friend WithEvents BTNDASHBOARDOPS As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents BTNRETURNOPS As Button
    Friend WithEvents BTNRUSAKOPS As Button
    Friend WithEvents BTNTENTANGOPS As Button
    Friend WithEvents BTNLABELOPS As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents LBLUSER As Label
    Friend WithEvents PNLEFT As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents PEWAKTU As Timer
    Friend WithEvents TXTCARI As TextBox
    Friend WithEvents BTNBARCODEOPS As Button
    Friend WithEvents PRINTBARCODE As Printing.PrintDocument
End Class
