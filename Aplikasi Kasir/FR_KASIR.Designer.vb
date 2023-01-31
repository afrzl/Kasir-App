<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FR_KASIR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_KASIR))
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.TXTCARI = New System.Windows.Forms.TextBox()
        Me.DGTAMPIL = New System.Windows.Forms.DataGridView()
        Me.BTNTAMBAH = New System.Windows.Forms.Button()
        Me.PNLEFT = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBLUSER = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BTNLOGOUT = New System.Windows.Forms.Button()
        Me.PNADMIN = New System.Windows.Forms.Panel()
        Me.BTNVOUCHER_ADMIN = New System.Windows.Forms.Button()
        Me.BTNHISTORYPENJUALAN = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BTNRETURN = New System.Windows.Forms.Button()
        Me.BTNDASHBOARD = New System.Windows.Forms.Button()
        Me.BTNRUSAK = New System.Windows.Forms.Button()
        Me.BTNKASIR = New System.Windows.Forms.Button()
        Me.BTNDISKON = New System.Windows.Forms.Button()
        Me.BTNBARANG = New System.Windows.Forms.Button()
        Me.BTNMASUK = New System.Windows.Forms.Button()
        Me.BTNTENTANG = New System.Windows.Forms.Button()
        Me.BTNKELUAR = New System.Windows.Forms.Button()
        Me.BTNLAPORAN = New System.Windows.Forms.Button()
        Me.BTNLABELADMIN = New System.Windows.Forms.Button()
        Me.BTNMEMBER_ADMIN = New System.Windows.Forms.Button()
        Me.PEWAKTU = New System.Windows.Forms.Timer(Me.components)
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.LBTGL = New System.Windows.Forms.Label()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNMINIMIZE = New System.Windows.Forms.Button()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.PNCONTENT.SuspendLayout()
        CType(Me.DGTAMPIL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNLEFT.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PNADMIN.SuspendLayout()
        Me.PNTOP.SuspendLayout()
        Me.PNCONTROL.SuspendLayout()
        Me.SuspendLayout()
        '
        'PNCONTENT
        '
        Me.PNCONTENT.Controls.Add(Me.TXTCARI)
        Me.PNCONTENT.Controls.Add(Me.DGTAMPIL)
        Me.PNCONTENT.Controls.Add(Me.BTNTAMBAH)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(270, 0)
        Me.PNCONTENT.Margin = New System.Windows.Forms.Padding(2)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(1096, 768)
        Me.PNCONTENT.TabIndex = 15
        '
        'TXTCARI
        '
        Me.TXTCARI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTCARI.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCARI.Location = New System.Drawing.Point(27, 58)
        Me.TXTCARI.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTCARI.Name = "TXTCARI"
        Me.TXTCARI.Size = New System.Drawing.Size(895, 41)
        Me.TXTCARI.TabIndex = 10
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
        Me.DGTAMPIL.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTAMPIL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGTAMPIL.ColumnHeadersHeight = 35
        Me.DGTAMPIL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGTAMPIL.EnableHeadersVisualStyles = False
        Me.DGTAMPIL.Location = New System.Drawing.Point(28, 105)
        Me.DGTAMPIL.Margin = New System.Windows.Forms.Padding(2)
        Me.DGTAMPIL.MultiSelect = False
        Me.DGTAMPIL.Name = "DGTAMPIL"
        Me.DGTAMPIL.ReadOnly = True
        Me.DGTAMPIL.RowHeadersVisible = False
        Me.DGTAMPIL.RowHeadersWidth = 51
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTAMPIL.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DGTAMPIL.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTAMPIL.RowTemplate.Height = 40
        Me.DGTAMPIL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGTAMPIL.Size = New System.Drawing.Size(1042, 642)
        Me.DGTAMPIL.TabIndex = 11
        '
        'BTNTAMBAH
        '
        Me.BTNTAMBAH.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNTAMBAH.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNTAMBAH.FlatAppearance.BorderSize = 0
        Me.BTNTAMBAH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNTAMBAH.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNTAMBAH.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNTAMBAH.Location = New System.Drawing.Point(926, 58)
        Me.BTNTAMBAH.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNTAMBAH.Name = "BTNTAMBAH"
        Me.BTNTAMBAH.Size = New System.Drawing.Size(145, 43)
        Me.BTNTAMBAH.TabIndex = 8
        Me.BTNTAMBAH.Text = "TAMBAH"
        Me.BTNTAMBAH.UseVisualStyleBackColor = False
        '
        'PNLEFT
        '
        Me.PNLEFT.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PNLEFT.Controls.Add(Me.Label4)
        Me.PNLEFT.Controls.Add(Me.Label3)
        Me.PNLEFT.Controls.Add(Me.LBLUSER)
        Me.PNLEFT.Controls.Add(Me.Label2)
        Me.PNLEFT.Controls.Add(Me.Button1)
        Me.PNLEFT.Controls.Add(Me.Panel1)
        Me.PNLEFT.Controls.Add(Me.PNADMIN)
        Me.PNLEFT.Dock = System.Windows.Forms.DockStyle.Left
        Me.PNLEFT.Location = New System.Drawing.Point(0, 0)
        Me.PNLEFT.Margin = New System.Windows.Forms.Padding(2)
        Me.PNLEFT.Name = "PNLEFT"
        Me.PNLEFT.Size = New System.Drawing.Size(270, 768)
        Me.PNLEFT.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(102, 80)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
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
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
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
        Me.LBLUSER.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
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
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
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
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 80)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BTNLOGOUT)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 704)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
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
        Me.BTNLOGOUT.Location = New System.Drawing.Point(2, 18)
        Me.BTNLOGOUT.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNLOGOUT.Name = "BTNLOGOUT"
        Me.BTNLOGOUT.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNLOGOUT.Size = New System.Drawing.Size(270, 35)
        Me.BTNLOGOUT.TabIndex = 14
        Me.BTNLOGOUT.Text = "     Logout"
        Me.BTNLOGOUT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLOGOUT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNLOGOUT.UseVisualStyleBackColor = True
        '
        'PNADMIN
        '
        Me.PNADMIN.Controls.Add(Me.BTNVOUCHER_ADMIN)
        Me.PNADMIN.Controls.Add(Me.BTNHISTORYPENJUALAN)
        Me.PNADMIN.Controls.Add(Me.Label1)
        Me.PNADMIN.Controls.Add(Me.Label13)
        Me.PNADMIN.Controls.Add(Me.BTNRETURN)
        Me.PNADMIN.Controls.Add(Me.BTNDASHBOARD)
        Me.PNADMIN.Controls.Add(Me.BTNRUSAK)
        Me.PNADMIN.Controls.Add(Me.BTNKASIR)
        Me.PNADMIN.Controls.Add(Me.BTNDISKON)
        Me.PNADMIN.Controls.Add(Me.BTNBARANG)
        Me.PNADMIN.Controls.Add(Me.BTNMASUK)
        Me.PNADMIN.Controls.Add(Me.BTNTENTANG)
        Me.PNADMIN.Controls.Add(Me.BTNKELUAR)
        Me.PNADMIN.Controls.Add(Me.BTNLAPORAN)
        Me.PNADMIN.Controls.Add(Me.BTNLABELADMIN)
        Me.PNADMIN.Controls.Add(Me.BTNMEMBER_ADMIN)
        Me.PNADMIN.Location = New System.Drawing.Point(0, 145)
        Me.PNADMIN.Margin = New System.Windows.Forms.Padding(2)
        Me.PNADMIN.Name = "PNADMIN"
        Me.PNADMIN.Size = New System.Drawing.Size(278, 875)
        Me.PNADMIN.TabIndex = 62
        '
        'BTNVOUCHER_ADMIN
        '
        Me.BTNVOUCHER_ADMIN.FlatAppearance.BorderSize = 0
        Me.BTNVOUCHER_ADMIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNVOUCHER_ADMIN.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNVOUCHER_ADMIN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNVOUCHER_ADMIN.Image = Global.Aplikasi_Kasir.My.Resources.Resources.data_master
        Me.BTNVOUCHER_ADMIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNVOUCHER_ADMIN.Location = New System.Drawing.Point(0, 242)
        Me.BTNVOUCHER_ADMIN.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNVOUCHER_ADMIN.Name = "BTNVOUCHER_ADMIN"
        Me.BTNVOUCHER_ADMIN.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNVOUCHER_ADMIN.Size = New System.Drawing.Size(270, 34)
        Me.BTNVOUCHER_ADMIN.TabIndex = 56
        Me.BTNVOUCHER_ADMIN.Text = "     Data Voucher"
        Me.BTNVOUCHER_ADMIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNVOUCHER_ADMIN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNVOUCHER_ADMIN.UseVisualStyleBackColor = True
        '
        'BTNHISTORYPENJUALAN
        '
        Me.BTNHISTORYPENJUALAN.FlatAppearance.BorderSize = 0
        Me.BTNHISTORYPENJUALAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNHISTORYPENJUALAN.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNHISTORYPENJUALAN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNHISTORYPENJUALAN.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNHISTORYPENJUALAN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNHISTORYPENJUALAN.Location = New System.Drawing.Point(0, 492)
        Me.BTNHISTORYPENJUALAN.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNHISTORYPENJUALAN.Name = "BTNHISTORYPENJUALAN"
        Me.BTNHISTORYPENJUALAN.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNHISTORYPENJUALAN.Size = New System.Drawing.Size(270, 34)
        Me.BTNHISTORYPENJUALAN.TabIndex = 54
        Me.BTNHISTORYPENJUALAN.Text = "     History Penjualan"
        Me.BTNHISTORYPENJUALAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNHISTORYPENJUALAN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNHISTORYPENJUALAN.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 97)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(4, 24)
        Me.Label1.TabIndex = 48
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label13.Location = New System.Drawing.Point(8, 2)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 28)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Menu Utama"
        '
        'BTNRETURN
        '
        Me.BTNRETURN.FlatAppearance.BorderSize = 0
        Me.BTNRETURN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNRETURN.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNRETURN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNRETURN.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNRETURN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRETURN.Location = New System.Drawing.Point(0, 592)
        Me.BTNRETURN.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNRETURN.Name = "BTNRETURN"
        Me.BTNRETURN.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNRETURN.Size = New System.Drawing.Size(270, 34)
        Me.BTNRETURN.TabIndex = 50
        Me.BTNRETURN.Text = "     Barang Return"
        Me.BTNRETURN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRETURN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNRETURN.UseVisualStyleBackColor = True
        '
        'BTNDASHBOARD
        '
        Me.BTNDASHBOARD.FlatAppearance.BorderSize = 0
        Me.BTNDASHBOARD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNDASHBOARD.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNDASHBOARD.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNDASHBOARD.Image = Global.Aplikasi_Kasir.My.Resources.Resources.data_master
        Me.BTNDASHBOARD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNDASHBOARD.Location = New System.Drawing.Point(0, 42)
        Me.BTNDASHBOARD.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNDASHBOARD.Name = "BTNDASHBOARD"
        Me.BTNDASHBOARD.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNDASHBOARD.Size = New System.Drawing.Size(270, 34)
        Me.BTNDASHBOARD.TabIndex = 41
        Me.BTNDASHBOARD.Text = "     Dashboard"
        Me.BTNDASHBOARD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNDASHBOARD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNDASHBOARD.UseVisualStyleBackColor = True
        '
        'BTNRUSAK
        '
        Me.BTNRUSAK.FlatAppearance.BorderSize = 0
        Me.BTNRUSAK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNRUSAK.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNRUSAK.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNRUSAK.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNRUSAK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRUSAK.Location = New System.Drawing.Point(0, 642)
        Me.BTNRUSAK.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNRUSAK.Name = "BTNRUSAK"
        Me.BTNRUSAK.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNRUSAK.Size = New System.Drawing.Size(270, 34)
        Me.BTNRUSAK.TabIndex = 51
        Me.BTNRUSAK.Text = "     Barang Rusak"
        Me.BTNRUSAK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNRUSAK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNRUSAK.UseVisualStyleBackColor = True
        '
        'BTNKASIR
        '
        Me.BTNKASIR.FlatAppearance.BorderSize = 0
        Me.BTNKASIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNKASIR.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNKASIR.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNKASIR.Image = Global.Aplikasi_Kasir.My.Resources.Resources.data_master
        Me.BTNKASIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNKASIR.Location = New System.Drawing.Point(0, 92)
        Me.BTNKASIR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNKASIR.Name = "BTNKASIR"
        Me.BTNKASIR.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNKASIR.Size = New System.Drawing.Size(270, 34)
        Me.BTNKASIR.TabIndex = 42
        Me.BTNKASIR.Text = "     Data Kasir"
        Me.BTNKASIR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNKASIR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNKASIR.UseVisualStyleBackColor = True
        '
        'BTNDISKON
        '
        Me.BTNDISKON.FlatAppearance.BorderSize = 0
        Me.BTNDISKON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNDISKON.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNDISKON.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNDISKON.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNDISKON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNDISKON.Location = New System.Drawing.Point(0, 342)
        Me.BTNDISKON.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNDISKON.Name = "BTNDISKON"
        Me.BTNDISKON.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNDISKON.Size = New System.Drawing.Size(270, 34)
        Me.BTNDISKON.TabIndex = 49
        Me.BTNDISKON.Text = "     Diskon"
        Me.BTNDISKON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNDISKON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNDISKON.UseVisualStyleBackColor = True
        '
        'BTNBARANG
        '
        Me.BTNBARANG.FlatAppearance.BorderSize = 0
        Me.BTNBARANG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNBARANG.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBARANG.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNBARANG.Image = Global.Aplikasi_Kasir.My.Resources.Resources.data_master
        Me.BTNBARANG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNBARANG.Location = New System.Drawing.Point(0, 142)
        Me.BTNBARANG.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNBARANG.Name = "BTNBARANG"
        Me.BTNBARANG.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNBARANG.Size = New System.Drawing.Size(270, 34)
        Me.BTNBARANG.TabIndex = 43
        Me.BTNBARANG.Text = "     Data Barang"
        Me.BTNBARANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNBARANG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNBARANG.UseVisualStyleBackColor = True
        '
        'BTNMASUK
        '
        Me.BTNMASUK.FlatAppearance.BorderSize = 0
        Me.BTNMASUK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNMASUK.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMASUK.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNMASUK.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNMASUK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNMASUK.Location = New System.Drawing.Point(0, 392)
        Me.BTNMASUK.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNMASUK.Name = "BTNMASUK"
        Me.BTNMASUK.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNMASUK.Size = New System.Drawing.Size(270, 34)
        Me.BTNMASUK.TabIndex = 44
        Me.BTNMASUK.Text = "     Barang Masuk"
        Me.BTNMASUK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNMASUK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNMASUK.UseVisualStyleBackColor = True
        '
        'BTNTENTANG
        '
        Me.BTNTENTANG.FlatAppearance.BorderSize = 0
        Me.BTNTENTANG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNTENTANG.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNTENTANG.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNTENTANG.Image = Global.Aplikasi_Kasir.My.Resources.Resources.tentang
        Me.BTNTENTANG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNTENTANG.Location = New System.Drawing.Point(0, 692)
        Me.BTNTENTANG.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNTENTANG.Name = "BTNTENTANG"
        Me.BTNTENTANG.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNTENTANG.Size = New System.Drawing.Size(270, 34)
        Me.BTNTENTANG.TabIndex = 47
        Me.BTNTENTANG.Text = "     Setting"
        Me.BTNTENTANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNTENTANG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNTENTANG.UseVisualStyleBackColor = True
        '
        'BTNKELUAR
        '
        Me.BTNKELUAR.FlatAppearance.BorderSize = 0
        Me.BTNKELUAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNKELUAR.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNKELUAR.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNKELUAR.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNKELUAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNKELUAR.Location = New System.Drawing.Point(0, 442)
        Me.BTNKELUAR.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNKELUAR.Name = "BTNKELUAR"
        Me.BTNKELUAR.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNKELUAR.Size = New System.Drawing.Size(270, 34)
        Me.BTNKELUAR.TabIndex = 45
        Me.BTNKELUAR.Text = "     Barang Keluar"
        Me.BTNKELUAR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNKELUAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNKELUAR.UseVisualStyleBackColor = True
        '
        'BTNLAPORAN
        '
        Me.BTNLAPORAN.FlatAppearance.BorderSize = 0
        Me.BTNLAPORAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNLAPORAN.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNLAPORAN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNLAPORAN.Image = Global.Aplikasi_Kasir.My.Resources.Resources.laporan
        Me.BTNLAPORAN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLAPORAN.Location = New System.Drawing.Point(0, 542)
        Me.BTNLAPORAN.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNLAPORAN.Name = "BTNLAPORAN"
        Me.BTNLAPORAN.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNLAPORAN.Size = New System.Drawing.Size(270, 34)
        Me.BTNLAPORAN.TabIndex = 46
        Me.BTNLAPORAN.Text = "     Laporan"
        Me.BTNLAPORAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLAPORAN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNLAPORAN.UseVisualStyleBackColor = True
        '
        'BTNLABELADMIN
        '
        Me.BTNLABELADMIN.FlatAppearance.BorderSize = 0
        Me.BTNLABELADMIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNLABELADMIN.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNLABELADMIN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNLABELADMIN.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNLABELADMIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLABELADMIN.Location = New System.Drawing.Point(0, 292)
        Me.BTNLABELADMIN.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNLABELADMIN.Name = "BTNLABELADMIN"
        Me.BTNLABELADMIN.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNLABELADMIN.Size = New System.Drawing.Size(270, 34)
        Me.BTNLABELADMIN.TabIndex = 52
        Me.BTNLABELADMIN.Text = "     Cetak Label"
        Me.BTNLABELADMIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLABELADMIN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNLABELADMIN.UseVisualStyleBackColor = True
        '
        'BTNMEMBER_ADMIN
        '
        Me.BTNMEMBER_ADMIN.FlatAppearance.BorderSize = 0
        Me.BTNMEMBER_ADMIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNMEMBER_ADMIN.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMEMBER_ADMIN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNMEMBER_ADMIN.Image = Global.Aplikasi_Kasir.My.Resources.Resources.data_master
        Me.BTNMEMBER_ADMIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNMEMBER_ADMIN.Location = New System.Drawing.Point(0, 192)
        Me.BTNMEMBER_ADMIN.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNMEMBER_ADMIN.Name = "BTNMEMBER_ADMIN"
        Me.BTNMEMBER_ADMIN.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNMEMBER_ADMIN.Size = New System.Drawing.Size(270, 34)
        Me.BTNMEMBER_ADMIN.TabIndex = 55
        Me.BTNMEMBER_ADMIN.Text = "     Data Member"
        Me.BTNMEMBER_ADMIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNMEMBER_ADMIN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNMEMBER_ADMIN.UseVisualStyleBackColor = True
        '
        'PEWAKTU
        '
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.LBTGL)
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(270, 0)
        Me.PNTOP.Margin = New System.Windows.Forms.Padding(2)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(1096, 40)
        Me.PNTOP.TabIndex = 16
        '
        'LBTGL
        '
        Me.LBTGL.AutoSize = True
        Me.LBTGL.Cursor = System.Windows.Forms.Cursors.Default
        Me.LBTGL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LBTGL.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBTGL.ForeColor = System.Drawing.Color.Black
        Me.LBTGL.Location = New System.Drawing.Point(6, 8)
        Me.LBTGL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
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
        Me.PNCONTROL.Margin = New System.Windows.Forms.Padding(2)
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
        Me.BTNMINIMIZE.Margin = New System.Windows.Forms.Padding(2)
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
        Me.BTNCLOSE.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNCLOSE.Name = "BTNCLOSE"
        Me.BTNCLOSE.Size = New System.Drawing.Size(18, 18)
        Me.BTNCLOSE.TabIndex = 0
        Me.BTNCLOSE.UseVisualStyleBackColor = True
        '
        'FR_KASIR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.PNTOP)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNLEFT)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FR_KASIR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU KASIR"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PNCONTENT.ResumeLayout(False)
        Me.PNCONTENT.PerformLayout()
        CType(Me.DGTAMPIL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNLEFT.ResumeLayout(False)
        Me.PNLEFT.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.PNADMIN.ResumeLayout(False)
        Me.PNADMIN.PerformLayout()
        Me.PNTOP.ResumeLayout(False)
        Me.PNTOP.PerformLayout()
        Me.PNCONTROL.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents PNLEFT As Panel
    Friend WithEvents PEWAKTU As Timer
    Friend WithEvents TXTCARI As TextBox
    Friend WithEvents DGTAMPIL As DataGridView
    Friend WithEvents BTNTAMBAH As Button
    Friend WithEvents PNTOP As Panel
    Friend WithEvents LBTGL As Label
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents BTNMINIMIZE As Button
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LBLUSER As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BTNLOGOUT As Button
    Friend WithEvents PNADMIN As Panel
    Friend WithEvents BTNVOUCHER_ADMIN As Button
    Friend WithEvents BTNHISTORYPENJUALAN As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents BTNRETURN As Button
    Friend WithEvents BTNDASHBOARD As Button
    Friend WithEvents BTNRUSAK As Button
    Friend WithEvents BTNKASIR As Button
    Friend WithEvents BTNDISKON As Button
    Friend WithEvents BTNBARANG As Button
    Friend WithEvents BTNMASUK As Button
    Friend WithEvents BTNTENTANG As Button
    Friend WithEvents BTNKELUAR As Button
    Friend WithEvents BTNLAPORAN As Button
    Friend WithEvents BTNLABELADMIN As Button
    Friend WithEvents BTNMEMBER_ADMIN As Button
End Class
