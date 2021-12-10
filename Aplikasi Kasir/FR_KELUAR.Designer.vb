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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TXTKASIR = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTPEMBELI = New System.Windows.Forms.TextBox()
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.LBTGL = New System.Windows.Forms.Label()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNMINIMIZE = New System.Windows.Forms.Button()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LBTOTAL = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTDISKON = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTTOTAL = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTQTY = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
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
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TXTTOTALHARGA = New System.Windows.Forms.TextBox()
        Me.TXTDISKON_RUPIAH = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXTDISKON_PERSEN = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TXTSUBTOTAL = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXTKEMBALIAN = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTBAYAR = New System.Windows.Forms.TextBox()
        Me.DGTAMPIL = New System.Windows.Forms.DataGridView()
        Me.KODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BARANG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SATUAN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HARGA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Diskon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLICK_KANAN = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HapusBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PEWAKTU = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.PNATAS.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.PNTOP.SuspendLayout()
        Me.PNCONTROL.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PNBAWAH.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DGTAMPIL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CLICK_KANAN.SuspendLayout()
        Me.SuspendLayout()
        '
        'PNATAS
        '
        Me.PNATAS.Controls.Add(Me.Panel1)
        Me.PNATAS.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNATAS.Location = New System.Drawing.Point(0, 0)
        Me.PNATAS.Name = "PNATAS"
        Me.PNATAS.Size = New System.Drawing.Size(1366, 322)
        Me.PNATAS.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.PNTOP)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1366, 322)
        Me.Panel1.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TXTKASIR)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.TXTPEMBELI)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(419, 119)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        '
        'TXTKASIR
        '
        Me.TXTKASIR.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTKASIR.Location = New System.Drawing.Point(97, 24)
        Me.TXTKASIR.Name = "TXTKASIR"
        Me.TXTKASIR.ReadOnly = True
        Me.TXTKASIR.Size = New System.Drawing.Size(286, 31)
        Me.TXTKASIR.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 23)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Kasir"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 23)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Pembeli"
        '
        'TXTPEMBELI
        '
        Me.TXTPEMBELI.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPEMBELI.Location = New System.Drawing.Point(97, 64)
        Me.TXTPEMBELI.Name = "TXTPEMBELI"
        Me.TXTPEMBELI.Size = New System.Drawing.Size(286, 31)
        Me.TXTPEMBELI.TabIndex = 9
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.LBTGL)
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
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
        Me.PNCONTROL.Location = New System.Drawing.Point(1290, 0)
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.LBTOTAL)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Crimson
        Me.GroupBox2.Location = New System.Drawing.Point(437, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(917, 119)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Total Harga"
        '
        'LBTOTAL
        '
        Me.LBTOTAL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBTOTAL.Font = New System.Drawing.Font("DS-Digital", 49.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBTOTAL.Location = New System.Drawing.Point(6, 24)
        Me.LBTOTAL.Name = "LBTOTAL"
        Me.LBTOTAL.Size = New System.Drawing.Size(905, 92)
        Me.LBTOTAL.TabIndex = 0
        Me.LBTOTAL.Text = "0"
        Me.LBTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TXTDISKON)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TXTTOTAL)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TXTQTY)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.BTNCARI)
        Me.GroupBox1.Controls.Add(Me.TXTHARGA)
        Me.GroupBox1.Controls.Add(Me.TXTSATUAN)
        Me.GroupBox1.Controls.Add(Me.TXTBARANG)
        Me.GroupBox1.Controls.Add(Me.TXTKODE)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 173)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1342, 133)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Barang"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1105, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 23)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "%"
        '
        'TXTDISKON
        '
        Me.TXTDISKON.Location = New System.Drawing.Point(1010, 55)
        Me.TXTDISKON.Name = "TXTDISKON"
        Me.TXTDISKON.ReadOnly = True
        Me.TXTDISKON.Size = New System.Drawing.Size(89, 30)
        Me.TXTDISKON.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1010, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 23)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Diskon"
        '
        'TXTTOTAL
        '
        Me.TXTTOTAL.Location = New System.Drawing.Point(1304, 55)
        Me.TXTTOTAL.Name = "TXTTOTAL"
        Me.TXTTOTAL.ReadOnly = True
        Me.TXTTOTAL.Size = New System.Drawing.Size(172, 30)
        Me.TXTTOTAL.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(814, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 23)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Harga"
        '
        'TXTQTY
        '
        Me.TXTQTY.Location = New System.Drawing.Point(1157, 55)
        Me.TXTQTY.Name = "TXTQTY"
        Me.TXTQTY.ReadOnly = True
        Me.TXTQTY.Size = New System.Drawing.Size(120, 30)
        Me.TXTQTY.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(1157, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 23)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "QTY"
        '
        'BTNCARI
        '
        Me.BTNCARI.BackColor = System.Drawing.Color.Navy
        Me.BTNCARI.FlatAppearance.BorderSize = 0
        Me.BTNCARI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNCARI.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNCARI.Location = New System.Drawing.Point(11, 92)
        Me.BTNCARI.Name = "BTNCARI"
        Me.BTNCARI.Size = New System.Drawing.Size(109, 33)
        Me.BTNCARI.TabIndex = 0
        Me.BTNCARI.Text = "Cari (F1)"
        Me.BTNCARI.UseVisualStyleBackColor = False
        '
        'TXTHARGA
        '
        Me.TXTHARGA.Location = New System.Drawing.Point(811, 55)
        Me.TXTHARGA.Name = "TXTHARGA"
        Me.TXTHARGA.ReadOnly = True
        Me.TXTHARGA.Size = New System.Drawing.Size(172, 30)
        Me.TXTHARGA.TabIndex = 7
        '
        'TXTSATUAN
        '
        Me.TXTSATUAN.Location = New System.Drawing.Point(664, 55)
        Me.TXTSATUAN.Name = "TXTSATUAN"
        Me.TXTSATUAN.ReadOnly = True
        Me.TXTSATUAN.Size = New System.Drawing.Size(120, 30)
        Me.TXTSATUAN.TabIndex = 6
        '
        'TXTBARANG
        '
        Me.TXTBARANG.Location = New System.Drawing.Point(271, 55)
        Me.TXTBARANG.Name = "TXTBARANG"
        Me.TXTBARANG.ReadOnly = True
        Me.TXTBARANG.Size = New System.Drawing.Size(366, 30)
        Me.TXTBARANG.TabIndex = 5
        '
        'TXTKODE
        '
        Me.TXTKODE.Location = New System.Drawing.Point(10, 55)
        Me.TXTKODE.Name = "TXTKODE"
        Me.TXTKODE.Size = New System.Drawing.Size(234, 30)
        Me.TXTKODE.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1304, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Total"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(664, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Satuan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(271, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kode"
        '
        'PNBAWAH
        '
        Me.PNBAWAH.Controls.Add(Me.GroupBox6)
        Me.PNBAWAH.Controls.Add(Me.GroupBox5)
        Me.PNBAWAH.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PNBAWAH.Location = New System.Drawing.Point(0, 574)
        Me.PNBAWAH.Name = "PNBAWAH"
        Me.PNBAWAH.Size = New System.Drawing.Size(1366, 194)
        Me.PNBAWAH.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.TXTTOTALHARGA)
        Me.GroupBox6.Controls.Add(Me.TXTDISKON_RUPIAH)
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Controls.Add(Me.TXTDISKON_PERSEN)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.TXTSUBTOTAL)
        Me.GroupBox6.Location = New System.Drawing.Point(416, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(464, 176)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(35, 127)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 23)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "Total Harga"
        '
        'TXTTOTALHARGA
        '
        Me.TXTTOTALHARGA.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOTALHARGA.Location = New System.Drawing.Point(174, 123)
        Me.TXTTOTALHARGA.Name = "TXTTOTALHARGA"
        Me.TXTTOTALHARGA.ReadOnly = True
        Me.TXTTOTALHARGA.Size = New System.Drawing.Size(262, 31)
        Me.TXTTOTALHARGA.TabIndex = 17
        Me.TXTTOTALHARGA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTDISKON_RUPIAH
        '
        Me.TXTDISKON_RUPIAH.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDISKON_RUPIAH.Location = New System.Drawing.Point(280, 77)
        Me.TXTDISKON_RUPIAH.Name = "TXTDISKON_RUPIAH"
        Me.TXTDISKON_RUPIAH.ReadOnly = True
        Me.TXTDISKON_RUPIAH.Size = New System.Drawing.Size(156, 31)
        Me.TXTDISKON_RUPIAH.TabIndex = 16
        Me.TXTDISKON_RUPIAH.Text = "0"
        Me.TXTDISKON_RUPIAH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(231, 81)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 23)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "%  = "
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(35, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 23)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Diskon"
        '
        'TXTDISKON_PERSEN
        '
        Me.TXTDISKON_PERSEN.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDISKON_PERSEN.Location = New System.Drawing.Point(174, 77)
        Me.TXTDISKON_PERSEN.Name = "TXTDISKON_PERSEN"
        Me.TXTDISKON_PERSEN.Size = New System.Drawing.Size(51, 31)
        Me.TXTDISKON_PERSEN.TabIndex = 13
        Me.TXTDISKON_PERSEN.Text = "0"
        Me.TXTDISKON_PERSEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(35, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 23)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Sub Total"
        '
        'TXTSUBTOTAL
        '
        Me.TXTSUBTOTAL.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUBTOTAL.Location = New System.Drawing.Point(174, 31)
        Me.TXTSUBTOTAL.Name = "TXTSUBTOTAL"
        Me.TXTSUBTOTAL.ReadOnly = True
        Me.TXTSUBTOTAL.Size = New System.Drawing.Size(262, 31)
        Me.TXTSUBTOTAL.TabIndex = 11
        Me.TXTSUBTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.TXTKEMBALIAN)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.TXTBAYAR)
        Me.GroupBox5.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(886, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(470, 179)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 107)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(127, 32)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Kembalian"
        '
        'TXTKEMBALIAN
        '
        Me.TXTKEMBALIAN.Font = New System.Drawing.Font("DS-Digital", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTKEMBALIAN.Location = New System.Drawing.Point(164, 100)
        Me.TXTKEMBALIAN.Name = "TXTKEMBALIAN"
        Me.TXTKEMBALIAN.ReadOnly = True
        Me.TXTKEMBALIAN.Size = New System.Drawing.Size(286, 47)
        Me.TXTKEMBALIAN.TabIndex = 13
        Me.TXTKEMBALIAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 32)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Bayar (F2)"
        '
        'TXTBAYAR
        '
        Me.TXTBAYAR.Font = New System.Drawing.Font("DS-Digital", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBAYAR.Location = New System.Drawing.Point(164, 39)
        Me.TXTBAYAR.Name = "TXTBAYAR"
        Me.TXTBAYAR.ReadOnly = True
        Me.TXTBAYAR.Size = New System.Drawing.Size(286, 47)
        Me.TXTBAYAR.TabIndex = 11
        Me.TXTBAYAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.DGTAMPIL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KODE, Me.BARANG, Me.SATUAN, Me.HARGA, Me.QTY, Me.Diskon, Me.TOTAL})
        Me.DGTAMPIL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGTAMPIL.Location = New System.Drawing.Point(0, 322)
        Me.DGTAMPIL.Name = "DGTAMPIL"
        Me.DGTAMPIL.RowHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGTAMPIL.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DGTAMPIL.RowTemplate.Height = 30
        Me.DGTAMPIL.Size = New System.Drawing.Size(1366, 252)
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
        'Diskon
        '
        Me.Diskon.HeaderText = "DISKON"
        Me.Diskon.Name = "Diskon"
        Me.Diskon.ReadOnly = True
        Me.Diskon.Width = 113
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
        'PEWAKTU
        '
        '
        'FR_KELUAR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1366, 768)
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
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.PNTOP.ResumeLayout(False)
        Me.PNTOP.PerformLayout()
        Me.PNCONTROL.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PNBAWAH.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
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
    Friend WithEvents DGTAMPIL As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CLICK_KANAN As ContextMenuStrip
    Friend WithEvents HapusBarangToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label8 As Label
    Friend WithEvents TXTKASIR As TextBox
    Friend WithEvents TXTPEMBELI As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents PEWAKTU As Timer
    Friend WithEvents PNTOP As Panel
    Friend WithEvents LBTGL As Label
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents BTNMINIMIZE As Button
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TXTQTY As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TXTTOTAL As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TXTBAYAR As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TXTKEMBALIAN As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label18 As Label
    Friend WithEvents TXTTOTALHARGA As TextBox
    Friend WithEvents TXTDISKON_RUPIAH As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents TXTDISKON_PERSEN As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TXTSUBTOTAL As TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTDISKON As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents KODE As DataGridViewTextBoxColumn
    Friend WithEvents BARANG As DataGridViewTextBoxColumn
    Friend WithEvents SATUAN As DataGridViewTextBoxColumn
    Friend WithEvents HARGA As DataGridViewTextBoxColumn
    Friend WithEvents QTY As DataGridViewTextBoxColumn
    Friend WithEvents Diskon As DataGridViewTextBoxColumn
    Friend WithEvents TOTAL As DataGridViewTextBoxColumn
End Class
