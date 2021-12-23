<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FR_OPS_DASHBOARD
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
        Me.PNLEFT = New System.Windows.Forms.Panel()
        Me.PNOPS = New System.Windows.Forms.Panel()
        Me.BTNMASUKOPS = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.BTNKELUAROPS = New System.Windows.Forms.Button()
        Me.BTNLAPORANOPS = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.BTNRETURNOPS = New System.Windows.Forms.Button()
        Me.BTNRUSAKOPS = New System.Windows.Forms.Button()
        Me.BTNTENTANGOPS = New System.Windows.Forms.Button()
        Me.BTNLABELOPS = New System.Windows.Forms.Button()
        Me.BTNDASHBOARDOPS = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBLUSER = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BTNLOGOUT = New System.Windows.Forms.Button()
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.LBTGL = New System.Windows.Forms.Label()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNMINIMIZE = New System.Windows.Forms.Button()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.LBKELUARHARI = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LBKELUAR = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTNNEXT = New System.Windows.Forms.Button()
        Me.BTNPREV = New System.Windows.Forms.Button()
        Me.DGSTOK = New System.Windows.Forms.DataGridView()
        Me.TXTCARISTOK = New System.Windows.Forms.TextBox()
        Me.LBMASUKHARI = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.LBMASUK = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.PEWAKTU = New System.Windows.Forms.Timer(Me.components)
        Me.PNLEFT.SuspendLayout()
        Me.PNOPS.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PNTOP.SuspendLayout()
        Me.PNCONTROL.SuspendLayout()
        Me.PNCONTENT.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGSTOK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PNLEFT
        '
        Me.PNLEFT.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PNLEFT.Controls.Add(Me.PNOPS)
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
        Me.PNLEFT.TabIndex = 11
        '
        'PNOPS
        '
        Me.PNOPS.Controls.Add(Me.BTNMASUKOPS)
        Me.PNOPS.Controls.Add(Me.Label23)
        Me.PNOPS.Controls.Add(Me.BTNKELUAROPS)
        Me.PNOPS.Controls.Add(Me.BTNLAPORANOPS)
        Me.PNOPS.Controls.Add(Me.Label24)
        Me.PNOPS.Controls.Add(Me.BTNRETURNOPS)
        Me.PNOPS.Controls.Add(Me.BTNRUSAKOPS)
        Me.PNOPS.Controls.Add(Me.BTNTENTANGOPS)
        Me.PNOPS.Controls.Add(Me.BTNLABELOPS)
        Me.PNOPS.Controls.Add(Me.BTNDASHBOARDOPS)
        Me.PNOPS.Location = New System.Drawing.Point(0, 112)
        Me.PNOPS.Name = "PNOPS"
        Me.PNOPS.Size = New System.Drawing.Size(270, 508)
        Me.PNOPS.TabIndex = 59
        '
        'BTNMASUKOPS
        '
        Me.BTNMASUKOPS.FlatAppearance.BorderSize = 0
        Me.BTNMASUKOPS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNMASUKOPS.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMASUKOPS.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNMASUKOPS.Image = Global.Aplikasi_Kasir.My.Resources.Resources.transaksi
        Me.BTNMASUKOPS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNMASUKOPS.Location = New System.Drawing.Point(0, 179)
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
        Me.BTNKELUAROPS.Location = New System.Drawing.Point(0, 230)
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
        Me.BTNLAPORANOPS.Location = New System.Drawing.Point(0, 383)
        Me.BTNLAPORANOPS.Name = "BTNLAPORANOPS"
        Me.BTNLAPORANOPS.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNLAPORANOPS.Size = New System.Drawing.Size(270, 35)
        Me.BTNLAPORANOPS.TabIndex = 26
        Me.BTNLAPORANOPS.Text = "     Laporan"
        Me.BTNLAPORANOPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLAPORANOPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNLAPORANOPS.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label24.Location = New System.Drawing.Point(0, 82)
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
        Me.BTNRETURNOPS.Location = New System.Drawing.Point(0, 281)
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
        Me.BTNRUSAKOPS.Location = New System.Drawing.Point(0, 332)
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
        Me.BTNTENTANGOPS.Location = New System.Drawing.Point(0, 434)
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
        Me.BTNLABELOPS.Location = New System.Drawing.Point(0, 128)
        Me.BTNLABELOPS.Name = "BTNLABELOPS"
        Me.BTNLABELOPS.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.BTNLABELOPS.Size = New System.Drawing.Size(270, 35)
        Me.BTNLABELOPS.TabIndex = 56
        Me.BTNLABELOPS.Text = "     Cetak Label"
        Me.BTNLABELOPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNLABELOPS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTNLABELOPS.UseVisualStyleBackColor = True
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
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.LBTGL)
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(270, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(1096, 40)
        Me.PNTOP.TabIndex = 12
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
        'PNCONTENT
        '
        Me.PNCONTENT.Controls.Add(Me.LBKELUARHARI)
        Me.PNCONTENT.Controls.Add(Me.Button2)
        Me.PNCONTENT.Controls.Add(Me.Button3)
        Me.PNCONTENT.Controls.Add(Me.LBKELUAR)
        Me.PNCONTENT.Controls.Add(Me.Button4)
        Me.PNCONTENT.Controls.Add(Me.Button5)
        Me.PNCONTENT.Controls.Add(Me.GroupBox1)
        Me.PNCONTENT.Controls.Add(Me.LBMASUKHARI)
        Me.PNCONTENT.Controls.Add(Me.Button10)
        Me.PNCONTENT.Controls.Add(Me.Button11)
        Me.PNCONTENT.Controls.Add(Me.LBMASUK)
        Me.PNCONTENT.Controls.Add(Me.Button8)
        Me.PNCONTENT.Controls.Add(Me.Button9)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(270, 40)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(1096, 728)
        Me.PNCONTENT.TabIndex = 13
        '
        'LBKELUARHARI
        '
        Me.LBKELUARHARI.BackColor = System.Drawing.Color.Silver
        Me.LBKELUARHARI.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBKELUARHARI.Location = New System.Drawing.Point(814, 40)
        Me.LBKELUARHARI.Name = "LBKELUARHARI"
        Me.LBKELUARHARI.Size = New System.Drawing.Size(258, 127)
        Me.LBKELUARHARI.TabIndex = 47
        Me.LBKELUARHARI.Text = "Label8"
        Me.LBKELUARHARI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button2.Location = New System.Drawing.Point(814, 170)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(258, 35)
        Me.Button2.TabIndex = 46
        Me.Button2.Text = "Penjualan Hari Ini"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Silver
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(814, 40)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(258, 165)
        Me.Button3.TabIndex = 45
        Me.Button3.UseVisualStyleBackColor = False
        '
        'LBKELUAR
        '
        Me.LBKELUAR.BackColor = System.Drawing.Color.Silver
        Me.LBKELUAR.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBKELUAR.Location = New System.Drawing.Point(550, 40)
        Me.LBKELUAR.Name = "LBKELUAR"
        Me.LBKELUAR.Size = New System.Drawing.Size(258, 127)
        Me.LBKELUAR.TabIndex = 44
        Me.LBKELUAR.Text = "Label8"
        Me.LBKELUAR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button4.Location = New System.Drawing.Point(550, 170)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(258, 35)
        Me.Button4.TabIndex = 43
        Me.Button4.Text = "Jumlah Transaksi Keluar"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Silver
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(550, 40)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(258, 165)
        Me.Button5.TabIndex = 42
        Me.Button5.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BTNNEXT)
        Me.GroupBox1.Controls.Add(Me.BTNPREV)
        Me.GroupBox1.Controls.Add(Me.DGSTOK)
        Me.GroupBox1.Controls.Add(Me.TXTCARISTOK)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 227)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1074, 489)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stok Barang Tersedia"
        '
        'BTNNEXT
        '
        Me.BTNNEXT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNNEXT.BackColor = System.Drawing.Color.DarkBlue
        Me.BTNNEXT.FlatAppearance.BorderSize = 0
        Me.BTNNEXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNNEXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNNEXT.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNNEXT.Location = New System.Drawing.Point(1018, 40)
        Me.BTNNEXT.Name = "BTNNEXT"
        Me.BTNNEXT.Size = New System.Drawing.Size(50, 29)
        Me.BTNNEXT.TabIndex = 21
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
        Me.BTNPREV.Location = New System.Drawing.Point(962, 40)
        Me.BTNPREV.Name = "BTNPREV"
        Me.BTNPREV.Size = New System.Drawing.Size(50, 29)
        Me.BTNPREV.TabIndex = 20
        Me.BTNPREV.Text = "<"
        Me.BTNPREV.UseVisualStyleBackColor = False
        '
        'DGSTOK
        '
        Me.DGSTOK.AllowUserToAddRows = False
        Me.DGSTOK.AllowUserToDeleteRows = False
        Me.DGSTOK.AllowUserToResizeColumns = False
        Me.DGSTOK.AllowUserToResizeRows = False
        Me.DGSTOK.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.NullValue = "-"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGSTOK.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGSTOK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGSTOK.Location = New System.Drawing.Point(22, 75)
        Me.DGSTOK.MultiSelect = False
        Me.DGSTOK.Name = "DGSTOK"
        Me.DGSTOK.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGSTOK.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGSTOK.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGSTOK.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGSTOK.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGSTOK.RowTemplate.Height = 30
        Me.DGSTOK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGSTOK.ShowCellErrors = False
        Me.DGSTOK.ShowEditingIcon = False
        Me.DGSTOK.ShowRowErrors = False
        Me.DGSTOK.Size = New System.Drawing.Size(1046, 408)
        Me.DGSTOK.TabIndex = 67
        '
        'TXTCARISTOK
        '
        Me.TXTCARISTOK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTCARISTOK.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCARISTOK.Location = New System.Drawing.Point(22, 39)
        Me.TXTCARISTOK.Name = "TXTCARISTOK"
        Me.TXTCARISTOK.Size = New System.Drawing.Size(934, 30)
        Me.TXTCARISTOK.TabIndex = 66
        '
        'LBMASUKHARI
        '
        Me.LBMASUKHARI.BackColor = System.Drawing.Color.Silver
        Me.LBMASUKHARI.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBMASUKHARI.Location = New System.Drawing.Point(286, 40)
        Me.LBMASUKHARI.Name = "LBMASUKHARI"
        Me.LBMASUKHARI.Size = New System.Drawing.Size(258, 127)
        Me.LBMASUKHARI.TabIndex = 40
        Me.LBMASUKHARI.Text = "Label8"
        Me.LBMASUKHARI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button10.Location = New System.Drawing.Point(286, 170)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(258, 35)
        Me.Button10.TabIndex = 39
        Me.Button10.Text = "Barang Masuk Hari Ini"
        Me.Button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.Silver
        Me.Button11.FlatAppearance.BorderSize = 0
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Location = New System.Drawing.Point(286, 40)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(258, 165)
        Me.Button11.TabIndex = 38
        Me.Button11.UseVisualStyleBackColor = False
        '
        'LBMASUK
        '
        Me.LBMASUK.BackColor = System.Drawing.Color.Silver
        Me.LBMASUK.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBMASUK.Location = New System.Drawing.Point(22, 40)
        Me.LBMASUK.Name = "LBMASUK"
        Me.LBMASUK.Size = New System.Drawing.Size(258, 127)
        Me.LBMASUK.TabIndex = 37
        Me.LBMASUK.Text = "Label8"
        Me.LBMASUK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button8.Location = New System.Drawing.Point(22, 170)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(258, 35)
        Me.Button8.TabIndex = 36
        Me.Button8.Text = "Jumlah Transaksi Masuk"
        Me.Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Silver
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Location = New System.Drawing.Point(22, 40)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(258, 165)
        Me.Button9.TabIndex = 35
        Me.Button9.UseVisualStyleBackColor = False
        '
        'PEWAKTU
        '
        '
        'FR_OPS_DASHBOARD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNTOP)
        Me.Controls.Add(Me.PNLEFT)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FR_OPS_DASHBOARD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DASHBOARD"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PNLEFT.ResumeLayout(False)
        Me.PNLEFT.PerformLayout()
        Me.PNOPS.ResumeLayout(False)
        Me.PNOPS.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.PNTOP.ResumeLayout(False)
        Me.PNTOP.PerformLayout()
        Me.PNCONTROL.ResumeLayout(False)
        Me.PNCONTENT.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGSTOK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PNLEFT As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LBLUSER As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BTNLOGOUT As Button
    Friend WithEvents PNTOP As Panel
    Friend WithEvents LBTGL As Label
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents BTNMINIMIZE As Button
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTNNEXT As Button
    Friend WithEvents BTNPREV As Button
    Friend WithEvents DGSTOK As DataGridView
    Friend WithEvents TXTCARISTOK As TextBox
    Friend WithEvents LBMASUKHARI As Label
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents LBMASUK As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents LBKELUARHARI As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents LBKELUAR As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents PEWAKTU As Timer
    Friend WithEvents PNOPS As Panel
    Friend WithEvents BTNMASUKOPS As Button
    Friend WithEvents Label23 As Label
    Friend WithEvents BTNKELUAROPS As Button
    Friend WithEvents BTNLAPORANOPS As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents BTNRETURNOPS As Button
    Friend WithEvents BTNRUSAKOPS As Button
    Friend WithEvents BTNTENTANGOPS As Button
    Friend WithEvents BTNLABELOPS As Button
    Friend WithEvents BTNDASHBOARDOPS As Button
End Class
