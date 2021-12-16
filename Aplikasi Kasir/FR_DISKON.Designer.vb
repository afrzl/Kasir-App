<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FR_DISKON
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGTAMPIL = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HapusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CBTAMPIL = New System.Windows.Forms.ComboBox()
        Me.BTNNEXT = New System.Windows.Forms.Button()
        Me.BTNPREV = New System.Windows.Forms.Button()
        Me.PNCARI = New System.Windows.Forms.Panel()
        Me.DGCARI = New System.Windows.Forms.DataGridView()
        Me.TXTCARI_BARANG = New System.Windows.Forms.TextBox()
        Me.LBSATUAN = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LBBARANG = New System.Windows.Forms.Label()
        Me.BTNCARI = New System.Windows.Forms.Button()
        Me.BTNSIMPAN = New System.Windows.Forms.Button()
        Me.TXTKODE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TXTMIN = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CBJENIS = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXTDISKON = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTTGLAKHIR = New System.Windows.Forms.DateTimePicker()
        Me.TXTTGLAWAL = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.LBTGL = New System.Windows.Forms.Label()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNMINIMIZE = New System.Windows.Forms.Button()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.PEWAKTU = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BTNLOGOUT = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBLUSER = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PNLEFT = New System.Windows.Forms.Panel()
        Me.BTNRUSAK = New System.Windows.Forms.Button()
        Me.BTNRETURN = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTNDISKON = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BTNTENTANG = New System.Windows.Forms.Button()
        Me.BTNLAPORAN = New System.Windows.Forms.Button()
        Me.BTNKELUAR = New System.Windows.Forms.Button()
        Me.BTNMASUK = New System.Windows.Forms.Button()
        Me.BTNBARANG = New System.Windows.Forms.Button()
        Me.BTNKASIR = New System.Windows.Forms.Button()
        Me.BTNDASHBOARD = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DGTAMPIL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PNCARI.SuspendLayout()
        CType(Me.DGCARI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNCONTENT.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PNTOP.SuspendLayout()
        Me.PNCONTROL.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PNLEFT.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGTAMPIL
        '
        Me.DGTAMPIL.AllowUserToAddRows = False
        Me.DGTAMPIL.AllowUserToDeleteRows = False
        Me.DGTAMPIL.AllowUserToResizeColumns = False
        Me.DGTAMPIL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGTAMPIL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTAMPIL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGTAMPIL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGTAMPIL.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DGTAMPIL.Location = New System.Drawing.Point(532, 98)
        Me.DGTAMPIL.Name = "DGTAMPIL"
        Me.DGTAMPIL.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTAMPIL.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGTAMPIL.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTAMPIL.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGTAMPIL.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTAMPIL.RowTemplate.Height = 30
        Me.DGTAMPIL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGTAMPIL.Size = New System.Drawing.Size(552, 658)
        Me.DGTAMPIL.TabIndex = 22
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HapusToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(121, 28)
        '
        'HapusToolStripMenuItem
        '
        Me.HapusToolStripMenuItem.Name = "HapusToolStripMenuItem"
        Me.HapusToolStripMenuItem.Size = New System.Drawing.Size(120, 24)
        Me.HapusToolStripMenuItem.Text = "Hapus"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.CBTAMPIL)
        Me.Panel3.Controls.Add(Me.BTNNEXT)
        Me.Panel3.Controls.Add(Me.BTNPREV)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(517, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(579, 61)
        Me.Panel3.TabIndex = 21
        '
        'CBTAMPIL
        '
        Me.CBTAMPIL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CBTAMPIL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTAMPIL.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CBTAMPIL.FormattingEnabled = True
        Me.CBTAMPIL.Items.AddRange(New Object() {"Semua", "Berlalu", "Sekarang", "Akan Datang"})
        Me.CBTAMPIL.Location = New System.Drawing.Point(15, 15)
        Me.CBTAMPIL.Name = "CBTAMPIL"
        Me.CBTAMPIL.Size = New System.Drawing.Size(435, 31)
        Me.CBTAMPIL.TabIndex = 20
        '
        'BTNNEXT
        '
        Me.BTNNEXT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNNEXT.BackColor = System.Drawing.Color.DarkBlue
        Me.BTNNEXT.FlatAppearance.BorderSize = 0
        Me.BTNNEXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNNEXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNNEXT.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNNEXT.Location = New System.Drawing.Point(512, 14)
        Me.BTNNEXT.Name = "BTNNEXT"
        Me.BTNNEXT.Size = New System.Drawing.Size(50, 29)
        Me.BTNNEXT.TabIndex = 19
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
        Me.BTNPREV.Location = New System.Drawing.Point(456, 14)
        Me.BTNPREV.Name = "BTNPREV"
        Me.BTNPREV.Size = New System.Drawing.Size(50, 29)
        Me.BTNPREV.TabIndex = 18
        Me.BTNPREV.Text = "<"
        Me.BTNPREV.UseVisualStyleBackColor = False
        '
        'PNCARI
        '
        Me.PNCARI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PNCARI.Controls.Add(Me.DGCARI)
        Me.PNCARI.Controls.Add(Me.TXTCARI_BARANG)
        Me.PNCARI.Location = New System.Drawing.Point(3, 425)
        Me.PNCARI.Name = "PNCARI"
        Me.PNCARI.Size = New System.Drawing.Size(517, 303)
        Me.PNCARI.TabIndex = 15
        Me.PNCARI.Visible = False
        '
        'DGCARI
        '
        Me.DGCARI.AllowUserToAddRows = False
        Me.DGCARI.AllowUserToDeleteRows = False
        Me.DGCARI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGCARI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGCARI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGCARI.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DGCARI.Location = New System.Drawing.Point(3, 35)
        Me.DGCARI.Name = "DGCARI"
        Me.DGCARI.ReadOnly = True
        Me.DGCARI.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGCARI.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DGCARI.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGCARI.RowTemplate.Height = 30
        Me.DGCARI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCARI.Size = New System.Drawing.Size(505, 256)
        Me.DGCARI.TabIndex = 23
        '
        'TXTCARI_BARANG
        '
        Me.TXTCARI_BARANG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTCARI_BARANG.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCARI_BARANG.Location = New System.Drawing.Point(3, 3)
        Me.TXTCARI_BARANG.Name = "TXTCARI_BARANG"
        Me.TXTCARI_BARANG.Size = New System.Drawing.Size(505, 26)
        Me.TXTCARI_BARANG.TabIndex = 16
        '
        'LBSATUAN
        '
        Me.LBSATUAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBSATUAN.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBSATUAN.Location = New System.Drawing.Point(151, 145)
        Me.LBSATUAN.Name = "LBSATUAN"
        Me.LBSATUAN.Size = New System.Drawing.Size(343, 26)
        Me.LBSATUAN.TabIndex = 14
        Me.LBSATUAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LBSATUAN.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 23)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Satuan"
        Me.Label7.Visible = False
        '
        'LBBARANG
        '
        Me.LBBARANG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBBARANG.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBBARANG.Location = New System.Drawing.Point(151, 104)
        Me.LBBARANG.Name = "LBBARANG"
        Me.LBBARANG.Size = New System.Drawing.Size(343, 26)
        Me.LBBARANG.TabIndex = 11
        Me.LBBARANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LBBARANG.Visible = False
        '
        'BTNCARI
        '
        Me.BTNCARI.BackColor = System.Drawing.Color.Navy
        Me.BTNCARI.FlatAppearance.BorderSize = 0
        Me.BTNCARI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNCARI.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCARI.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNCARI.Location = New System.Drawing.Point(371, 61)
        Me.BTNCARI.Name = "BTNCARI"
        Me.BTNCARI.Size = New System.Drawing.Size(123, 30)
        Me.BTNCARI.TabIndex = 10
        Me.BTNCARI.Text = "Cari (F1)"
        Me.BTNCARI.UseVisualStyleBackColor = False
        Me.BTNCARI.Visible = False
        '
        'BTNSIMPAN
        '
        Me.BTNSIMPAN.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNSIMPAN.FlatAppearance.BorderSize = 0
        Me.BTNSIMPAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNSIMPAN.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSIMPAN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNSIMPAN.Location = New System.Drawing.Point(151, 242)
        Me.BTNSIMPAN.Name = "BTNSIMPAN"
        Me.BTNSIMPAN.Size = New System.Drawing.Size(189, 51)
        Me.BTNSIMPAN.TabIndex = 5
        Me.BTNSIMPAN.Text = "Simpan Diskon"
        Me.BTNSIMPAN.UseVisualStyleBackColor = False
        Me.BTNSIMPAN.Visible = False
        '
        'TXTKODE
        '
        Me.TXTKODE.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTKODE.Location = New System.Drawing.Point(151, 61)
        Me.TXTKODE.Name = "TXTKODE"
        Me.TXTKODE.Size = New System.Drawing.Size(214, 30)
        Me.TXTKODE.TabIndex = 1
        Me.TXTKODE.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 23)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Kode Barang"
        Me.Label5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 23)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Nama Barang"
        Me.Label6.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 147)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 23)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Akhir Diskon"
        Me.Label10.Visible = False
        '
        'PNCONTENT
        '
        Me.PNCONTENT.Controls.Add(Me.DGTAMPIL)
        Me.PNCONTENT.Controls.Add(Me.Panel3)
        Me.PNCONTENT.Controls.Add(Me.Panel2)
        Me.PNCONTENT.Controls.Add(Me.PNTOP)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(270, 0)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(1096, 768)
        Me.PNCONTENT.TabIndex = 22
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TXTMIN)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.CBJENIS)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.TXTDISKON)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.TXTTGLAKHIR)
        Me.Panel2.Controls.Add(Me.TXTTGLAWAL)
        Me.Panel2.Controls.Add(Me.PNCARI)
        Me.Panel2.Controls.Add(Me.LBSATUAN)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.LBBARANG)
        Me.Panel2.Controls.Add(Me.BTNCARI)
        Me.Panel2.Controls.Add(Me.BTNSIMPAN)
        Me.Panel2.Controls.Add(Me.TXTKODE)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(517, 728)
        Me.Panel2.TabIndex = 20
        '
        'TXTMIN
        '
        Me.TXTMIN.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMIN.Location = New System.Drawing.Point(151, 61)
        Me.TXTMIN.Name = "TXTMIN"
        Me.TXTMIN.Size = New System.Drawing.Size(343, 30)
        Me.TXTMIN.TabIndex = 26
        Me.TXTMIN.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 23)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Minimum Trans"
        Me.Label12.Visible = False
        '
        'CBJENIS
        '
        Me.CBJENIS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBJENIS.FormattingEnabled = True
        Me.CBJENIS.Items.AddRange(New Object() {"Diskon Barang", "Diskon Transaksi"})
        Me.CBJENIS.Location = New System.Drawing.Point(151, 19)
        Me.CBJENIS.Name = "CBJENIS"
        Me.CBJENIS.Size = New System.Drawing.Size(343, 31)
        Me.CBJENIS.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 23)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Jenis Diskon"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(213, 192)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 23)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "%"
        Me.Label14.Visible = False
        '
        'TXTDISKON
        '
        Me.TXTDISKON.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDISKON.Location = New System.Drawing.Point(151, 188)
        Me.TXTDISKON.Name = "TXTDISKON"
        Me.TXTDISKON.Size = New System.Drawing.Size(56, 30)
        Me.TXTDISKON.TabIndex = 20
        Me.TXTDISKON.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 191)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 23)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Diskon"
        Me.Label13.Visible = False
        '
        'TXTTGLAKHIR
        '
        Me.TXTTGLAKHIR.Location = New System.Drawing.Point(151, 143)
        Me.TXTTGLAKHIR.Name = "TXTTGLAKHIR"
        Me.TXTTGLAKHIR.Size = New System.Drawing.Size(298, 30)
        Me.TXTTGLAKHIR.TabIndex = 19
        Me.TXTTGLAKHIR.Visible = False
        '
        'TXTTGLAWAL
        '
        Me.TXTTGLAWAL.Location = New System.Drawing.Point(151, 101)
        Me.TXTTGLAWAL.Name = "TXTTGLAWAL"
        Me.TXTTGLAWAL.Size = New System.Drawing.Size(298, 30)
        Me.TXTTGLAWAL.TabIndex = 18
        Me.TXTTGLAWAL.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 23)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Awal Diskon"
        Me.Label9.Visible = False
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.LBTGL)
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(1096, 40)
        Me.PNTOP.TabIndex = 19
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
        'PEWAKTU
        '
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(98, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Administrator"
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
        'PNLEFT
        '
        Me.PNLEFT.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PNLEFT.Controls.Add(Me.BTNRUSAK)
        Me.PNLEFT.Controls.Add(Me.BTNRETURN)
        Me.PNLEFT.Controls.Add(Me.Label1)
        Me.PNLEFT.Controls.Add(Me.BTNDISKON)
        Me.PNLEFT.Controls.Add(Me.Label8)
        Me.PNLEFT.Controls.Add(Me.BTNTENTANG)
        Me.PNLEFT.Controls.Add(Me.BTNLAPORAN)
        Me.PNLEFT.Controls.Add(Me.BTNKELUAR)
        Me.PNLEFT.Controls.Add(Me.BTNMASUK)
        Me.PNLEFT.Controls.Add(Me.BTNBARANG)
        Me.PNLEFT.Controls.Add(Me.BTNKASIR)
        Me.PNLEFT.Controls.Add(Me.BTNDASHBOARD)
        Me.PNLEFT.Controls.Add(Me.Label4)
        Me.PNLEFT.Controls.Add(Me.Label3)
        Me.PNLEFT.Controls.Add(Me.LBLUSER)
        Me.PNLEFT.Controls.Add(Me.Label2)
        Me.PNLEFT.Controls.Add(Me.Button1)
        Me.PNLEFT.Controls.Add(Me.Panel1)
        Me.PNLEFT.Dock = System.Windows.Forms.DockStyle.Left
        Me.PNLEFT.Location = New System.Drawing.Point(0, 0)
        Me.PNLEFT.Name = "PNLEFT"
        Me.PNLEFT.Size = New System.Drawing.Size(270, 768)
        Me.PNLEFT.TabIndex = 21
        '
        'BTNRUSAK
        '
        Me.BTNRUSAK.FlatAppearance.BorderSize = 0
        Me.BTNRUSAK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNRUSAK.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNRUSAK.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNRUSAK.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNRUSAK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRUSAK.Location = New System.Drawing.Point(4, 605)
        Me.BTNRUSAK.Name = "BTNRUSAK"
        Me.BTNRUSAK.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNRUSAK.Size = New System.Drawing.Size(270, 35)
        Me.BTNRUSAK.TabIndex = 53
        Me.BTNRUSAK.Text = "     Barang Rusak"
        Me.BTNRUSAK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRUSAK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNRUSAK.UseVisualStyleBackColor = True
        '
        'BTNRETURN
        '
        Me.BTNRETURN.FlatAppearance.BorderSize = 0
        Me.BTNRETURN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNRETURN.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNRETURN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNRETURN.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNRETURN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRETURN.Location = New System.Drawing.Point(4, 553)
        Me.BTNRETURN.Name = "BTNRETURN"
        Me.BTNRETURN.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNRETURN.Size = New System.Drawing.Size(270, 35)
        Me.BTNRETURN.TabIndex = 52
        Me.BTNRETURN.Text = "     Barang Return"
        Me.BTNRETURN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRETURN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNRETURN.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 350)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(5, 25)
        Me.Label1.TabIndex = 38
        '
        'BTNDISKON
        '
        Me.BTNDISKON.FlatAppearance.BorderSize = 0
        Me.BTNDISKON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNDISKON.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNDISKON.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNDISKON.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNDISKON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNDISKON.Location = New System.Drawing.Point(0, 345)
        Me.BTNDISKON.Name = "BTNDISKON"
        Me.BTNDISKON.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNDISKON.Size = New System.Drawing.Size(270, 35)
        Me.BTNDISKON.TabIndex = 39
        Me.BTNDISKON.Text = "     Diskon"
        Me.BTNDISKON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNDISKON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNDISKON.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Location = New System.Drawing.Point(7, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 28)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Menu Utama"
        '
        'BTNTENTANG
        '
        Me.BTNTENTANG.FlatAppearance.BorderSize = 0
        Me.BTNTENTANG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNTENTANG.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNTENTANG.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNTENTANG.Image = Global.Aplikasi_Kasir.My.Resources.Resources.tentang
        Me.BTNTENTANG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNTENTANG.Location = New System.Drawing.Point(0, 657)
        Me.BTNTENTANG.Name = "BTNTENTANG"
        Me.BTNTENTANG.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNTENTANG.Size = New System.Drawing.Size(270, 35)
        Me.BTNTENTANG.TabIndex = 37
        Me.BTNTENTANG.Text = "     Setting"
        Me.BTNTENTANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNTENTANG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNTENTANG.UseVisualStyleBackColor = True
        '
        'BTNLAPORAN
        '
        Me.BTNLAPORAN.FlatAppearance.BorderSize = 0
        Me.BTNLAPORAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNLAPORAN.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNLAPORAN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNLAPORAN.Image = Global.Aplikasi_Kasir.My.Resources.Resources.laporan
        Me.BTNLAPORAN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLAPORAN.Location = New System.Drawing.Point(0, 501)
        Me.BTNLAPORAN.Name = "BTNLAPORAN"
        Me.BTNLAPORAN.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNLAPORAN.Size = New System.Drawing.Size(270, 35)
        Me.BTNLAPORAN.TabIndex = 36
        Me.BTNLAPORAN.Text = "     Laporan"
        Me.BTNLAPORAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLAPORAN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNLAPORAN.UseVisualStyleBackColor = True
        '
        'BTNKELUAR
        '
        Me.BTNKELUAR.FlatAppearance.BorderSize = 0
        Me.BTNKELUAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNKELUAR.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNKELUAR.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNKELUAR.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNKELUAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNKELUAR.Location = New System.Drawing.Point(0, 449)
        Me.BTNKELUAR.Name = "BTNKELUAR"
        Me.BTNKELUAR.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNKELUAR.Size = New System.Drawing.Size(270, 35)
        Me.BTNKELUAR.TabIndex = 35
        Me.BTNKELUAR.Text = "     Barang Keluar"
        Me.BTNKELUAR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNKELUAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNKELUAR.UseVisualStyleBackColor = True
        '
        'BTNMASUK
        '
        Me.BTNMASUK.FlatAppearance.BorderSize = 0
        Me.BTNMASUK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNMASUK.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMASUK.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNMASUK.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNMASUK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNMASUK.Location = New System.Drawing.Point(0, 397)
        Me.BTNMASUK.Name = "BTNMASUK"
        Me.BTNMASUK.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNMASUK.Size = New System.Drawing.Size(270, 35)
        Me.BTNMASUK.TabIndex = 34
        Me.BTNMASUK.Text = "     Barang Masuk"
        Me.BTNMASUK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNMASUK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNMASUK.UseVisualStyleBackColor = True
        '
        'BTNBARANG
        '
        Me.BTNBARANG.FlatAppearance.BorderSize = 0
        Me.BTNBARANG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNBARANG.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBARANG.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNBARANG.Image = Global.Aplikasi_Kasir.My.Resources.Resources.data_master
        Me.BTNBARANG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNBARANG.Location = New System.Drawing.Point(0, 293)
        Me.BTNBARANG.Name = "BTNBARANG"
        Me.BTNBARANG.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNBARANG.Size = New System.Drawing.Size(270, 35)
        Me.BTNBARANG.TabIndex = 33
        Me.BTNBARANG.Text = "     Data Barang"
        Me.BTNBARANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNBARANG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNBARANG.UseVisualStyleBackColor = True
        '
        'BTNKASIR
        '
        Me.BTNKASIR.FlatAppearance.BorderSize = 0
        Me.BTNKASIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNKASIR.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNKASIR.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNKASIR.Image = Global.Aplikasi_Kasir.My.Resources.Resources.data_master
        Me.BTNKASIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNKASIR.Location = New System.Drawing.Point(0, 241)
        Me.BTNKASIR.Name = "BTNKASIR"
        Me.BTNKASIR.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNKASIR.Size = New System.Drawing.Size(270, 35)
        Me.BTNKASIR.TabIndex = 32
        Me.BTNKASIR.Text = "     Data Kasir"
        Me.BTNKASIR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNKASIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNKASIR.UseVisualStyleBackColor = True
        '
        'BTNDASHBOARD
        '
        Me.BTNDASHBOARD.FlatAppearance.BorderSize = 0
        Me.BTNDASHBOARD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNDASHBOARD.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNDASHBOARD.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNDASHBOARD.Image = Global.Aplikasi_Kasir.My.Resources.Resources.data_master
        Me.BTNDASHBOARD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNDASHBOARD.Location = New System.Drawing.Point(0, 189)
        Me.BTNDASHBOARD.Name = "BTNDASHBOARD"
        Me.BTNDASHBOARD.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNDASHBOARD.Size = New System.Drawing.Size(270, 35)
        Me.BTNDASHBOARD.TabIndex = 31
        Me.BTNDASHBOARD.Text = "     Dashboard"
        Me.BTNDASHBOARD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNDASHBOARD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNDASHBOARD.UseVisualStyleBackColor = True
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
        'FR_DISKON
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNLEFT)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FR_DISKON"
        Me.Text = "FR_DISKON"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DGTAMPIL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.PNCARI.ResumeLayout(False)
        Me.PNCARI.PerformLayout()
        CType(Me.DGCARI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNCONTENT.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PNTOP.ResumeLayout(False)
        Me.PNTOP.PerformLayout()
        Me.PNCONTROL.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PNLEFT.ResumeLayout(False)
        Me.PNLEFT.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGTAMPIL As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents HapusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BTNNEXT As Button
    Friend WithEvents BTNPREV As Button
    Friend WithEvents TXTCARI As TextBox
    Friend WithEvents PNCARI As Panel
    Friend WithEvents DGCARI As DataGridView
    Friend WithEvents TXTCARI_BARANG As TextBox
    Friend WithEvents LBSATUAN As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LBBARANG As Label
    Friend WithEvents BTNCARI As Button
    Friend WithEvents BTNSIMPAN As Button
    Friend WithEvents TXTKODE As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents PNTOP As Panel
    Friend WithEvents LBTGL As Label
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents BTNMINIMIZE As Button
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents PEWAKTU As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BTNLOGOUT As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LBLUSER As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PNLEFT As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents TXTTGLAKHIR As DateTimePicker
    Friend WithEvents TXTTGLAWAL As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents TXTDISKON As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents CBTAMPIL As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BTNDISKON As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents BTNTENTANG As Button
    Friend WithEvents BTNLAPORAN As Button
    Friend WithEvents BTNKELUAR As Button
    Friend WithEvents BTNMASUK As Button
    Friend WithEvents BTNBARANG As Button
    Friend WithEvents BTNKASIR As Button
    Friend WithEvents BTNDASHBOARD As Button
    Friend WithEvents BTNRUSAK As Button
    Friend WithEvents BTNRETURN As Button
    Friend WithEvents CBJENIS As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTMIN As TextBox
    Friend WithEvents Label12 As Label
End Class
