<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_KELUAR_CUSTOMER
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_KELUAR_CUSTOMER))
        Me.PEWAKTU = New System.Windows.Forms.Timer(Me.components)
        Me.TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Diskon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HARGA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SATUAN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BARANG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGTAMPIL = New System.Windows.Forms.DataGridView()
        Me.LBTOTAL = New System.Windows.Forms.Label()
        Me.PNATAS = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LBL_LASTITEM_TOTAL = New System.Windows.Forms.Label()
        Me.LBL_LASTITEM_QTY = New System.Windows.Forms.Label()
        Me.LBL_LASTITEM_NAME = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TXTPEMBELI = New System.Windows.Forms.Label()
        Me.TXTKASIR = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.LBTGL = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PNBAWAH = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TXTTOTALHARGA = New System.Windows.Forms.Label()
        Me.TXTDISKON_RUPIAH = New System.Windows.Forms.Label()
        Me.TXTDISKON_PERSEN = New System.Windows.Forms.Label()
        Me.TXTSUBTOTAL = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TXTKEMBALIAN = New System.Windows.Forms.Label()
        Me.TXTBAYAR = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.DGTAMPIL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNATAS.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.PNTOP.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.PNBAWAH.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'PEWAKTU
        '
        '
        'TOTAL
        '
        Me.TOTAL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TOTAL.HeaderText = "TOTAL"
        Me.TOTAL.MinimumWidth = 6
        Me.TOTAL.Name = "TOTAL"
        Me.TOTAL.ReadOnly = True
        '
        'Diskon
        '
        Me.Diskon.HeaderText = "DISKON"
        Me.Diskon.MinimumWidth = 6
        Me.Diskon.Name = "Diskon"
        Me.Diskon.ReadOnly = True
        Me.Diskon.Width = 104
        '
        'QTY
        '
        Me.QTY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.QTY.HeaderText = "QTY"
        Me.QTY.MinimumWidth = 6
        Me.QTY.Name = "QTY"
        Me.QTY.ReadOnly = True
        '
        'HARGA
        '
        Me.HARGA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.HARGA.HeaderText = "HARGA"
        Me.HARGA.MinimumWidth = 6
        Me.HARGA.Name = "HARGA"
        Me.HARGA.ReadOnly = True
        '
        'SATUAN
        '
        Me.SATUAN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SATUAN.HeaderText = "SATUAN"
        Me.SATUAN.MinimumWidth = 6
        Me.SATUAN.Name = "SATUAN"
        Me.SATUAN.ReadOnly = True
        '
        'BARANG
        '
        Me.BARANG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.BARANG.HeaderText = "NAMA BARANG"
        Me.BARANG.MinimumWidth = 6
        Me.BARANG.Name = "BARANG"
        Me.BARANG.ReadOnly = True
        '
        'KODE
        '
        Me.KODE.HeaderText = "KODE"
        Me.KODE.MinimumWidth = 6
        Me.KODE.Name = "KODE"
        Me.KODE.ReadOnly = True
        Me.KODE.Width = 85
        '
        'DGTAMPIL
        '
        Me.DGTAMPIL.AllowUserToAddRows = False
        Me.DGTAMPIL.AllowUserToDeleteRows = False
        Me.DGTAMPIL.AllowUserToResizeColumns = False
        Me.DGTAMPIL.AllowUserToResizeRows = False
        Me.DGTAMPIL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGTAMPIL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTAMPIL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGTAMPIL.ColumnHeadersHeight = 35
        Me.DGTAMPIL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGTAMPIL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KODE, Me.BARANG, Me.SATUAN, Me.HARGA, Me.QTY, Me.Diskon, Me.TOTAL})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGTAMPIL.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGTAMPIL.Location = New System.Drawing.Point(0, 265)
        Me.DGTAMPIL.Margin = New System.Windows.Forms.Padding(2)
        Me.DGTAMPIL.MultiSelect = False
        Me.DGTAMPIL.Name = "DGTAMPIL"
        Me.DGTAMPIL.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTAMPIL.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGTAMPIL.RowHeadersVisible = False
        Me.DGTAMPIL.RowHeadersWidth = 51
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGTAMPIL.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DGTAMPIL.RowTemplate.Height = 30
        Me.DGTAMPIL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGTAMPIL.Size = New System.Drawing.Size(1366, 309)
        Me.DGTAMPIL.TabIndex = 5
        '
        'LBTOTAL
        '
        Me.LBTOTAL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBTOTAL.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBTOTAL.ForeColor = System.Drawing.Color.Black
        Me.LBTOTAL.Location = New System.Drawing.Point(109, 12)
        Me.LBTOTAL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBTOTAL.Name = "LBTOTAL"
        Me.LBTOTAL.Size = New System.Drawing.Size(805, 95)
        Me.LBTOTAL.TabIndex = 0
        Me.LBTOTAL.Text = "0"
        Me.LBTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PNATAS
        '
        Me.PNATAS.Controls.Add(Me.Panel1)
        Me.PNATAS.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNATAS.Location = New System.Drawing.Point(0, 0)
        Me.PNATAS.Margin = New System.Windows.Forms.Padding(2)
        Me.PNATAS.Name = "PNATAS"
        Me.PNATAS.Size = New System.Drawing.Size(1366, 322)
        Me.PNATAS.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.PNTOP)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1366, 322)
        Me.Panel1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LBL_LASTITEM_TOTAL)
        Me.GroupBox1.Controls.Add(Me.LBL_LASTITEM_QTY)
        Me.GroupBox1.Controls.Add(Me.LBL_LASTITEM_NAME)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(12, 169)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(1352, 92)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Last Item"
        '
        'LBL_LASTITEM_TOTAL
        '
        Me.LBL_LASTITEM_TOTAL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBL_LASTITEM_TOTAL.BackColor = System.Drawing.SystemColors.Control
        Me.LBL_LASTITEM_TOTAL.Font = New System.Drawing.Font("Segoe UI", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_LASTITEM_TOTAL.ForeColor = System.Drawing.Color.Black
        Me.LBL_LASTITEM_TOTAL.Location = New System.Drawing.Point(1013, 23)
        Me.LBL_LASTITEM_TOTAL.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.LBL_LASTITEM_TOTAL.Name = "LBL_LASTITEM_TOTAL"
        Me.LBL_LASTITEM_TOTAL.Size = New System.Drawing.Size(331, 71)
        Me.LBL_LASTITEM_TOTAL.TabIndex = 2
        Me.LBL_LASTITEM_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_LASTITEM_QTY
        '
        Me.LBL_LASTITEM_QTY.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LBL_LASTITEM_QTY.BackColor = System.Drawing.SystemColors.Control
        Me.LBL_LASTITEM_QTY.Font = New System.Drawing.Font("Segoe UI", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_LASTITEM_QTY.ForeColor = System.Drawing.Color.Black
        Me.LBL_LASTITEM_QTY.Location = New System.Drawing.Point(628, 23)
        Me.LBL_LASTITEM_QTY.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.LBL_LASTITEM_QTY.Name = "LBL_LASTITEM_QTY"
        Me.LBL_LASTITEM_QTY.Size = New System.Drawing.Size(383, 71)
        Me.LBL_LASTITEM_QTY.TabIndex = 1
        Me.LBL_LASTITEM_QTY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LBL_LASTITEM_NAME
        '
        Me.LBL_LASTITEM_NAME.BackColor = System.Drawing.SystemColors.Control
        Me.LBL_LASTITEM_NAME.Font = New System.Drawing.Font("Segoe UI", 28.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_LASTITEM_NAME.ForeColor = System.Drawing.Color.Black
        Me.LBL_LASTITEM_NAME.Location = New System.Drawing.Point(6, 23)
        Me.LBL_LASTITEM_NAME.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.LBL_LASTITEM_NAME.Name = "LBL_LASTITEM_NAME"
        Me.LBL_LASTITEM_NAME.Size = New System.Drawing.Size(620, 71)
        Me.LBL_LASTITEM_NAME.TabIndex = 0
        Me.LBL_LASTITEM_NAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TXTPEMBELI)
        Me.GroupBox4.Controls.Add(Me.TXTKASIR)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(419, 119)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        '
        'TXTPEMBELI
        '
        Me.TXTPEMBELI.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPEMBELI.Location = New System.Drawing.Point(96, 68)
        Me.TXTPEMBELI.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXTPEMBELI.Name = "TXTPEMBELI"
        Me.TXTPEMBELI.Size = New System.Drawing.Size(288, 35)
        Me.TXTPEMBELI.TabIndex = 24
        Me.TXTPEMBELI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXTKASIR
        '
        Me.TXTKASIR.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTKASIR.Location = New System.Drawing.Point(96, 24)
        Me.TXTKASIR.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXTKASIR.Name = "TXTKASIR"
        Me.TXTKASIR.Size = New System.Drawing.Size(288, 35)
        Me.TXTKASIR.TabIndex = 23
        Me.TXTKASIR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 27)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 28)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Kasir"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 71)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 28)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Pembeli"
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.LBTGL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
        Me.PNTOP.Margin = New System.Windows.Forms.Padding(2)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(1366, 40)
        Me.PNTOP.TabIndex = 20
        '
        'LBTGL
        '
        Me.LBTGL.AutoSize = True
        Me.LBTGL.Cursor = System.Windows.Forms.Cursors.Default
        Me.LBTGL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LBTGL.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBTGL.ForeColor = System.Drawing.Color.Black
        Me.LBTGL.Location = New System.Drawing.Point(18, 9)
        Me.LBTGL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBTGL.Name = "LBTGL"
        Me.LBTGL.Size = New System.Drawing.Size(192, 23)
        Me.LBTGL.TabIndex = 0
        Me.LBTGL.Text = "31 Januari 2021 88:88:88"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.LBTOTAL)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(438, 46)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(918, 119)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Total Harga"
        '
        'PNBAWAH
        '
        Me.PNBAWAH.Controls.Add(Me.GroupBox6)
        Me.PNBAWAH.Controls.Add(Me.GroupBox5)
        Me.PNBAWAH.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PNBAWAH.Location = New System.Drawing.Point(0, 574)
        Me.PNBAWAH.Margin = New System.Windows.Forms.Padding(2)
        Me.PNBAWAH.Name = "PNBAWAH"
        Me.PNBAWAH.Size = New System.Drawing.Size(1366, 194)
        Me.PNBAWAH.TabIndex = 4
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.TXTTOTALHARGA)
        Me.GroupBox6.Controls.Add(Me.TXTDISKON_RUPIAH)
        Me.GroupBox6.Controls.Add(Me.TXTDISKON_PERSEN)
        Me.GroupBox6.Controls.Add(Me.TXTSUBTOTAL)
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Location = New System.Drawing.Point(416, 8)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox6.Size = New System.Drawing.Size(464, 176)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        '
        'TXTTOTALHARGA
        '
        Me.TXTTOTALHARGA.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALHARGA.Location = New System.Drawing.Point(165, 119)
        Me.TXTTOTALHARGA.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXTTOTALHARGA.Name = "TXTTOTALHARGA"
        Me.TXTTOTALHARGA.Size = New System.Drawing.Size(288, 35)
        Me.TXTTOTALHARGA.TabIndex = 22
        Me.TXTTOTALHARGA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXTDISKON_RUPIAH
        '
        Me.TXTDISKON_RUPIAH.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDISKON_RUPIAH.Location = New System.Drawing.Point(292, 71)
        Me.TXTDISKON_RUPIAH.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXTDISKON_RUPIAH.Name = "TXTDISKON_RUPIAH"
        Me.TXTDISKON_RUPIAH.Size = New System.Drawing.Size(161, 35)
        Me.TXTDISKON_RUPIAH.TabIndex = 21
        Me.TXTDISKON_RUPIAH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXTDISKON_PERSEN
        '
        Me.TXTDISKON_PERSEN.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDISKON_PERSEN.Location = New System.Drawing.Point(165, 71)
        Me.TXTDISKON_PERSEN.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXTDISKON_PERSEN.Name = "TXTDISKON_PERSEN"
        Me.TXTDISKON_PERSEN.Size = New System.Drawing.Size(57, 35)
        Me.TXTDISKON_PERSEN.TabIndex = 20
        Me.TXTDISKON_PERSEN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXTSUBTOTAL
        '
        Me.TXTSUBTOTAL.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUBTOTAL.Location = New System.Drawing.Point(165, 23)
        Me.TXTSUBTOTAL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXTSUBTOTAL.Name = "TXTSUBTOTAL"
        Me.TXTSUBTOTAL.Size = New System.Drawing.Size(288, 35)
        Me.TXTSUBTOTAL.TabIndex = 19
        Me.TXTSUBTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(35, 122)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 28)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "Total Harga"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(231, 74)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 28)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "%  = "
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(35, 74)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 28)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Diskon"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(35, 26)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 28)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Sub Total"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.TXTKEMBALIAN)
        Me.GroupBox5.Controls.Add(Me.TXTBAYAR)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(886, 4)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Size = New System.Drawing.Size(470, 179)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'TXTKEMBALIAN
        '
        Me.TXTKEMBALIAN.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTKEMBALIAN.Location = New System.Drawing.Point(162, 97)
        Me.TXTKEMBALIAN.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXTKEMBALIAN.Name = "TXTKEMBALIAN"
        Me.TXTKEMBALIAN.Size = New System.Drawing.Size(288, 53)
        Me.TXTKEMBALIAN.TabIndex = 24
        Me.TXTKEMBALIAN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTBAYAR
        '
        Me.TXTBAYAR.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBAYAR.Location = New System.Drawing.Point(162, 35)
        Me.TXTBAYAR.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXTBAYAR.Name = "TXTBAYAR"
        Me.TXTBAYAR.Size = New System.Drawing.Size(288, 53)
        Me.TXTBAYAR.TabIndex = 23
        Me.TXTBAYAR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 107)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 32)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Kembalian"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 45)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 32)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Bayar"
        '
        'FR_KELUAR_CUSTOMER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.DGTAMPIL)
        Me.Controls.Add(Me.PNATAS)
        Me.Controls.Add(Me.PNBAWAH)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FR_KELUAR_CUSTOMER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CUSTOMER DISPLAY"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DGTAMPIL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNATAS.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.PNTOP.ResumeLayout(False)
        Me.PNTOP.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.PNBAWAH.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PEWAKTU As Timer
    Friend WithEvents TOTAL As DataGridViewTextBoxColumn
    Friend WithEvents Diskon As DataGridViewTextBoxColumn
    Friend WithEvents QTY As DataGridViewTextBoxColumn
    Friend WithEvents HARGA As DataGridViewTextBoxColumn
    Friend WithEvents SATUAN As DataGridViewTextBoxColumn
    Friend WithEvents BARANG As DataGridViewTextBoxColumn
    Friend WithEvents KODE As DataGridViewTextBoxColumn
    Friend WithEvents DGTAMPIL As DataGridView
    Friend WithEvents LBTOTAL As Label
    Friend WithEvents PNATAS As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PNTOP As Panel
    Friend WithEvents LBTGL As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PNBAWAH As Panel
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LBL_LASTITEM_NAME As Label
    Friend WithEvents LBL_LASTITEM_TOTAL As Label
    Friend WithEvents LBL_LASTITEM_QTY As Label
    Friend WithEvents TXTTOTALHARGA As Label
    Friend WithEvents TXTDISKON_RUPIAH As Label
    Friend WithEvents TXTDISKON_PERSEN As Label
    Friend WithEvents TXTSUBTOTAL As Label
    Friend WithEvents TXTKEMBALIAN As Label
    Friend WithEvents TXTBAYAR As Label
    Friend WithEvents TXTPEMBELI As Label
    Friend WithEvents TXTKASIR As Label
End Class
