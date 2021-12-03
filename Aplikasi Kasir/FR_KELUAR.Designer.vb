<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FR_KELUAR
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
        Me.PNATAS = New System.Windows.Forms.Panel()
        Me.BTNMIN = New System.Windows.Forms.Button()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PNBAYAR = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TXTBAYAR = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BTNBAYAR_CLOSE = New System.Windows.Forms.Button()
        Me.TXTKEMBALIAN = New System.Windows.Forms.TextBox()
        Me.TXTTUNAI = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PNCARI = New System.Windows.Forms.Panel()
        Me.BTNCARI_CLOSE = New System.Windows.Forms.Button()
        Me.DGCARI = New System.Windows.Forms.DataGridView()
        Me.TXTCARI = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LBTOTAL = New System.Windows.Forms.Label()
        Me.LBTGL = New System.Windows.Forms.Label()
        Me.TXTPEMBELI = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTKASIR = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTNCARI = New System.Windows.Forms.Button()
        Me.TXTHARGA = New System.Windows.Forms.TextBox()
        Me.TXTSATUAN = New System.Windows.Forms.TextBox()
        Me.TXTBARANG = New System.Windows.Forms.TextBox()
        Me.TXTKODE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PNBAWAH = New System.Windows.Forms.Panel()
        Me.BTNBAYAR = New System.Windows.Forms.Button()
        Me.DGTAMPIL = New System.Windows.Forms.DataGridView()
        Me.KODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BARANG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SATUAN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HARGA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLICK_KANAN = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HapusBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PNATAS.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PNBAYAR.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.PNCARI.SuspendLayout()
        CType(Me.DGCARI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PNBAWAH.SuspendLayout()
        CType(Me.DGTAMPIL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CLICK_KANAN.SuspendLayout()
        Me.SuspendLayout()
        '
        'PNATAS
        '
        Me.PNATAS.Controls.Add(Me.BTNMIN)
        Me.PNATAS.Controls.Add(Me.BTNCLOSE)
        Me.PNATAS.Controls.Add(Me.Panel1)
        Me.PNATAS.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNATAS.Location = New System.Drawing.Point(0, 0)
        Me.PNATAS.Name = "PNATAS"
        Me.PNATAS.Size = New System.Drawing.Size(1497, 349)
        Me.PNATAS.TabIndex = 0
        '
        'BTNMIN
        '
        Me.BTNMIN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNMIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMIN.Location = New System.Drawing.Point(1392, 3)
        Me.BTNMIN.Name = "BTNMIN"
        Me.BTNMIN.Size = New System.Drawing.Size(48, 35)
        Me.BTNMIN.TabIndex = 2
        Me.BTNMIN.Text = "-"
        Me.BTNMIN.UseVisualStyleBackColor = True
        '
        'BTNCLOSE
        '
        Me.BTNCLOSE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNCLOSE.BackColor = System.Drawing.Color.Red
        Me.BTNCLOSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCLOSE.Location = New System.Drawing.Point(1446, 3)
        Me.BTNCLOSE.Name = "BTNCLOSE"
        Me.BTNCLOSE.Size = New System.Drawing.Size(48, 35)
        Me.BTNCLOSE.TabIndex = 1
        Me.BTNCLOSE.Text = "X"
        Me.BTNCLOSE.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PNBAYAR)
        Me.Panel1.Controls.Add(Me.PNCARI)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.LBTGL)
        Me.Panel1.Controls.Add(Me.TXTPEMBELI)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TXTKASIR)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1497, 349)
        Me.Panel1.TabIndex = 3
        '
        'PNBAYAR
        '
        Me.PNBAYAR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PNBAYAR.Controls.Add(Me.GroupBox3)
        Me.PNBAYAR.Location = New System.Drawing.Point(6, 94)
        Me.PNBAYAR.Name = "PNBAYAR"
        Me.PNBAYAR.Size = New System.Drawing.Size(1488, 252)
        Me.PNBAYAR.TabIndex = 4
        Me.PNBAYAR.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.TXTBAYAR)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.BTNBAYAR_CLOSE)
        Me.GroupBox3.Controls.Add(Me.TXTKEMBALIAN)
        Me.GroupBox3.Controls.Add(Me.TXTTUNAI)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(15, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1470, 227)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Form Pembayaran"
        '
        'TXTBAYAR
        '
        Me.TXTBAYAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBAYAR.Location = New System.Drawing.Point(146, 37)
        Me.TXTBAYAR.Name = "TXTBAYAR"
        Me.TXTBAYAR.ReadOnly = True
        Me.TXTBAYAR.Size = New System.Drawing.Size(385, 75)
        Me.TXTBAYAR.TabIndex = 7
        Me.TXTBAYAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(598, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 25)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Kembali"
        '
        'BTNBAYAR_CLOSE
        '
        Me.BTNBAYAR_CLOSE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNBAYAR_CLOSE.BackColor = System.Drawing.Color.Red
        Me.BTNBAYAR_CLOSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBAYAR_CLOSE.Location = New System.Drawing.Point(1422, -3)
        Me.BTNBAYAR_CLOSE.Name = "BTNBAYAR_CLOSE"
        Me.BTNBAYAR_CLOSE.Size = New System.Drawing.Size(48, 35)
        Me.BTNBAYAR_CLOSE.TabIndex = 3
        Me.BTNBAYAR_CLOSE.Text = "X"
        Me.BTNBAYAR_CLOSE.UseVisualStyleBackColor = False
        '
        'TXTKEMBALIAN
        '
        Me.TXTKEMBALIAN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTKEMBALIAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTKEMBALIAN.Location = New System.Drawing.Point(603, 66)
        Me.TXTKEMBALIAN.Name = "TXTKEMBALIAN"
        Me.TXTKEMBALIAN.ReadOnly = True
        Me.TXTKEMBALIAN.Size = New System.Drawing.Size(861, 143)
        Me.TXTKEMBALIAN.TabIndex = 5
        Me.TXTKEMBALIAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTTUNAI
        '
        Me.TXTTUNAI.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTUNAI.Location = New System.Drawing.Point(146, 133)
        Me.TXTTUNAI.Name = "TXTTUNAI"
        Me.TXTTUNAI.Size = New System.Drawing.Size(385, 75)
        Me.TXTTUNAI.TabIndex = 4
        Me.TXTTUNAI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 25)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Total Bayar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 25)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Tunai"
        '
        'PNCARI
        '
        Me.PNCARI.Controls.Add(Me.BTNCARI_CLOSE)
        Me.PNCARI.Controls.Add(Me.DGCARI)
        Me.PNCARI.Controls.Add(Me.TXTCARI)
        Me.PNCARI.Location = New System.Drawing.Point(12, 142)
        Me.PNCARI.Name = "PNCARI"
        Me.PNCARI.Size = New System.Drawing.Size(560, 196)
        Me.PNCARI.TabIndex = 3
        Me.PNCARI.Visible = False
        '
        'BTNCARI_CLOSE
        '
        Me.BTNCARI_CLOSE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNCARI_CLOSE.BackColor = System.Drawing.Color.Red
        Me.BTNCARI_CLOSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCARI_CLOSE.Location = New System.Drawing.Point(509, 2)
        Me.BTNCARI_CLOSE.Name = "BTNCARI_CLOSE"
        Me.BTNCARI_CLOSE.Size = New System.Drawing.Size(48, 35)
        Me.BTNCARI_CLOSE.TabIndex = 6
        Me.BTNCARI_CLOSE.Text = "X"
        Me.BTNCARI_CLOSE.UseVisualStyleBackColor = False
        '
        'DGCARI
        '
        Me.DGCARI.AllowUserToAddRows = False
        Me.DGCARI.AllowUserToDeleteRows = False
        Me.DGCARI.AllowUserToResizeColumns = False
        Me.DGCARI.AllowUserToResizeRows = False
        Me.DGCARI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGCARI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGCARI.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGCARI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGCARI.Location = New System.Drawing.Point(3, 42)
        Me.DGCARI.Name = "DGCARI"
        Me.DGCARI.ReadOnly = True
        Me.DGCARI.RowHeadersVisible = False
        Me.DGCARI.RowTemplate.Height = 24
        Me.DGCARI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCARI.Size = New System.Drawing.Size(554, 151)
        Me.DGCARI.TabIndex = 9
        '
        'TXTCARI
        '
        Me.TXTCARI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTCARI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCARI.Location = New System.Drawing.Point(3, 6)
        Me.TXTCARI.Name = "TXTCARI"
        Me.TXTCARI.Size = New System.Drawing.Size(500, 27)
        Me.TXTCARI.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.LBTOTAL)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(578, 142)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(907, 176)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Total Harga"
        '
        'LBTOTAL
        '
        Me.LBTOTAL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBTOTAL.Font = New System.Drawing.Font("Arial Black", 50.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBTOTAL.Location = New System.Drawing.Point(6, 29)
        Me.LBTOTAL.Name = "LBTOTAL"
        Me.LBTOTAL.Size = New System.Drawing.Size(895, 144)
        Me.LBTOTAL.TabIndex = 0
        Me.LBTOTAL.Text = "0"
        Me.LBTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBTGL
        '
        Me.LBTGL.AutoSize = True
        Me.LBTGL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBTGL.Location = New System.Drawing.Point(433, 24)
        Me.LBTGL.Name = "LBTGL"
        Me.LBTGL.Size = New System.Drawing.Size(64, 20)
        Me.LBTGL.TabIndex = 11
        Me.LBTGL.Text = "LBTGL"
        '
        'TXTPEMBELI
        '
        Me.TXTPEMBELI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPEMBELI.Location = New System.Drawing.Point(111, 56)
        Me.TXTPEMBELI.Name = "TXTPEMBELI"
        Me.TXTPEMBELI.Size = New System.Drawing.Size(286, 28)
        Me.TXTPEMBELI.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(19, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 20)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Pembeli"
        '
        'TXTKASIR
        '
        Me.TXTKASIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTKASIR.Location = New System.Drawing.Point(111, 16)
        Me.TXTKASIR.Name = "TXTKASIR"
        Me.TXTKASIR.ReadOnly = True
        Me.TXTKASIR.Size = New System.Drawing.Size(286, 28)
        Me.TXTKASIR.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(19, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 20)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Kasir"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNCARI)
        Me.GroupBox1.Controls.Add(Me.TXTHARGA)
        Me.GroupBox1.Controls.Add(Me.TXTSATUAN)
        Me.GroupBox1.Controls.Add(Me.TXTBARANG)
        Me.GroupBox1.Controls.Add(Me.TXTKODE)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(540, 176)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Barang"
        '
        'BTNCARI
        '
        Me.BTNCARI.Location = New System.Drawing.Point(425, 29)
        Me.BTNCARI.Name = "BTNCARI"
        Me.BTNCARI.Size = New System.Drawing.Size(109, 33)
        Me.BTNCARI.TabIndex = 0
        Me.BTNCARI.Text = "Cari (F1)"
        Me.BTNCARI.UseVisualStyleBackColor = True
        '
        'TXTHARGA
        '
        Me.TXTHARGA.Location = New System.Drawing.Point(133, 137)
        Me.TXTHARGA.Name = "TXTHARGA"
        Me.TXTHARGA.ReadOnly = True
        Me.TXTHARGA.Size = New System.Drawing.Size(401, 26)
        Me.TXTHARGA.TabIndex = 7
        '
        'TXTSATUAN
        '
        Me.TXTSATUAN.Location = New System.Drawing.Point(133, 102)
        Me.TXTSATUAN.Name = "TXTSATUAN"
        Me.TXTSATUAN.ReadOnly = True
        Me.TXTSATUAN.Size = New System.Drawing.Size(401, 26)
        Me.TXTSATUAN.TabIndex = 6
        '
        'TXTBARANG
        '
        Me.TXTBARANG.Location = New System.Drawing.Point(133, 67)
        Me.TXTBARANG.Name = "TXTBARANG"
        Me.TXTBARANG.ReadOnly = True
        Me.TXTBARANG.Size = New System.Drawing.Size(401, 26)
        Me.TXTBARANG.TabIndex = 5
        '
        'TXTKODE
        '
        Me.TXTKODE.Location = New System.Drawing.Point(133, 32)
        Me.TXTKODE.Name = "TXTKODE"
        Me.TXTKODE.Size = New System.Drawing.Size(286, 26)
        Me.TXTKODE.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Harga"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Satuan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Barang"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kode Barang"
        '
        'PNBAWAH
        '
        Me.PNBAWAH.Controls.Add(Me.BTNBAYAR)
        Me.PNBAWAH.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PNBAWAH.Location = New System.Drawing.Point(0, 740)
        Me.PNBAWAH.Name = "PNBAWAH"
        Me.PNBAWAH.Size = New System.Drawing.Size(1497, 63)
        Me.PNBAWAH.TabIndex = 1
        '
        'BTNBAYAR
        '
        Me.BTNBAYAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBAYAR.Location = New System.Drawing.Point(12, 16)
        Me.BTNBAYAR.Name = "BTNBAYAR"
        Me.BTNBAYAR.Size = New System.Drawing.Size(120, 35)
        Me.BTNBAYAR.TabIndex = 0
        Me.BTNBAYAR.Text = "Bayar (F2)"
        Me.BTNBAYAR.UseVisualStyleBackColor = True
        '
        'DGTAMPIL
        '
        Me.DGTAMPIL.AllowUserToAddRows = False
        Me.DGTAMPIL.AllowUserToDeleteRows = False
        Me.DGTAMPIL.AllowUserToResizeColumns = False
        Me.DGTAMPIL.AllowUserToResizeRows = False
        Me.DGTAMPIL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTAMPIL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGTAMPIL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGTAMPIL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KODE, Me.BARANG, Me.SATUAN, Me.HARGA, Me.QTY, Me.TOTAL})
        Me.DGTAMPIL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGTAMPIL.Location = New System.Drawing.Point(0, 349)
        Me.DGTAMPIL.Name = "DGTAMPIL"
        Me.DGTAMPIL.RowHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGTAMPIL.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DGTAMPIL.RowTemplate.Height = 30
        Me.DGTAMPIL.Size = New System.Drawing.Size(1497, 391)
        Me.DGTAMPIL.TabIndex = 2
        '
        'KODE
        '
        Me.KODE.HeaderText = "KODE"
        Me.KODE.Name = "KODE"
        Me.KODE.ReadOnly = True
        Me.KODE.Width = 94
        '
        'BARANG
        '
        Me.BARANG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.BARANG.HeaderText = "NAMA BARANG"
        Me.BARANG.Name = "BARANG"
        Me.BARANG.ReadOnly = True
        '
        'SATUAN
        '
        Me.SATUAN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SATUAN.HeaderText = "SATUAN"
        Me.SATUAN.Name = "SATUAN"
        Me.SATUAN.ReadOnly = True
        '
        'HARGA
        '
        Me.HARGA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.HARGA.HeaderText = "HARGA"
        Me.HARGA.Name = "HARGA"
        Me.HARGA.ReadOnly = True
        '
        'QTY
        '
        Me.QTY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.QTY.HeaderText = "QTY"
        Me.QTY.Name = "QTY"
        '
        'TOTAL
        '
        Me.TOTAL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TOTAL.HeaderText = "TOTAL"
        Me.TOTAL.Name = "TOTAL"
        Me.TOTAL.ReadOnly = True
        '
        'CLICK_KANAN
        '
        Me.CLICK_KANAN.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.CLICK_KANAN.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HapusBarangToolStripMenuItem})
        Me.CLICK_KANAN.Name = "CLICK_KANAN"
        Me.CLICK_KANAN.Size = New System.Drawing.Size(172, 28)
        '
        'HapusBarangToolStripMenuItem
        '
        Me.HapusBarangToolStripMenuItem.Name = "HapusBarangToolStripMenuItem"
        Me.HapusBarangToolStripMenuItem.Size = New System.Drawing.Size(171, 24)
        Me.HapusBarangToolStripMenuItem.Text = "Hapus Barang"
        '
        'Timer1
        '
        '
        'FR_KELUAR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1497, 803)
        Me.Controls.Add(Me.DGTAMPIL)
        Me.Controls.Add(Me.PNBAWAH)
        Me.Controls.Add(Me.PNATAS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FR_KELUAR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FR_KELUAR"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PNATAS.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PNBAYAR.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.PNCARI.ResumeLayout(False)
        Me.PNCARI.PerformLayout()
        CType(Me.DGCARI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PNBAWAH.ResumeLayout(False)
        CType(Me.DGTAMPIL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CLICK_KANAN.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PNATAS As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LBTOTAL As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTNCARI As Button
    Friend WithEvents TXTHARGA As TextBox
    Friend WithEvents TXTSATUAN As TextBox
    Friend WithEvents TXTBARANG As TextBox
    Friend WithEvents TXTKODE As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PNBAWAH As Panel
    Friend WithEvents BTNBAYAR As Button
    Friend WithEvents DGTAMPIL As DataGridView
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents BTNMIN As Button
    Friend WithEvents KODE As DataGridViewTextBoxColumn
    Friend WithEvents BARANG As DataGridViewTextBoxColumn
    Friend WithEvents SATUAN As DataGridViewTextBoxColumn
    Friend WithEvents HARGA As DataGridViewTextBoxColumn
    Friend WithEvents QTY As DataGridViewTextBoxColumn
    Friend WithEvents TOTAL As DataGridViewTextBoxColumn
    Friend WithEvents PNCARI As Panel
    Friend WithEvents DGCARI As DataGridView
    Friend WithEvents TXTCARI As TextBox
    Friend WithEvents PNBAYAR As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BTNBAYAR_CLOSE As Button
    Friend WithEvents TXTKEMBALIAN As TextBox
    Friend WithEvents TXTTUNAI As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BTNCARI_CLOSE As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CLICK_KANAN As ContextMenuStrip
    Friend WithEvents HapusBarangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label8 As Label
    Friend WithEvents TXTKASIR As TextBox
    Friend WithEvents TXTPEMBELI As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LBTGL As Label
    Friend WithEvents TXTBAYAR As TextBox
    Friend WithEvents Label5 As Label
End Class
