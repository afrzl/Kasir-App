<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class nitip
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BTNNEXT = New System.Windows.Forms.Button()
        Me.TXTCARI = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BTNPREV = New System.Windows.Forms.Button()
        Me.LBSATUAN = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BTNTAMBAH = New System.Windows.Forms.Button()
        Me.LBBARANG = New System.Windows.Forms.Label()
        Me.BTNCARI = New System.Windows.Forms.Button()
        Me.BTNSTOK = New System.Windows.Forms.Button()
        Me.DGCARI = New System.Windows.Forms.DataGridView()
        Me.TXTCARI_BARANG = New System.Windows.Forms.TextBox()
        Me.PNCARI = New System.Windows.Forms.Panel()
        Me.HapusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DGTAMPIL = New System.Windows.Forms.DataGridView()
        Me.TXTKODE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTHARGAPARTAI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTSUPPLIER = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTJUMLAH = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        CType(Me.DGCARI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNCARI.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DGTAMPIL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTNNEXT
        '
        Me.BTNNEXT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNNEXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNNEXT.Location = New System.Drawing.Point(764, 14)
        Me.BTNNEXT.Name = "BTNNEXT"
        Me.BTNNEXT.Size = New System.Drawing.Size(50, 29)
        Me.BTNNEXT.TabIndex = 19
        Me.BTNNEXT.Text = ">"
        Me.BTNNEXT.UseVisualStyleBackColor = True
        '
        'TXTCARI
        '
        Me.TXTCARI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTCARI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCARI.Location = New System.Drawing.Point(15, 15)
        Me.TXTCARI.Name = "TXTCARI"
        Me.TXTCARI.Size = New System.Drawing.Size(687, 26)
        Me.TXTCARI.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BTNNEXT)
        Me.Panel2.Controls.Add(Me.BTNPREV)
        Me.Panel2.Controls.Add(Me.TXTCARI)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(517, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(831, 61)
        Me.Panel2.TabIndex = 14
        '
        'BTNPREV
        '
        Me.BTNPREV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNPREV.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNPREV.Location = New System.Drawing.Point(708, 14)
        Me.BTNPREV.Name = "BTNPREV"
        Me.BTNPREV.Size = New System.Drawing.Size(50, 29)
        Me.BTNPREV.TabIndex = 18
        Me.BTNPREV.Text = "<"
        Me.BTNPREV.UseVisualStyleBackColor = True
        '
        'LBSATUAN
        '
        Me.LBSATUAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBSATUAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBSATUAN.Location = New System.Drawing.Point(151, 96)
        Me.LBSATUAN.Name = "LBSATUAN"
        Me.LBSATUAN.Size = New System.Drawing.Size(343, 26)
        Me.LBSATUAN.TabIndex = 14
        Me.LBSATUAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Satuan"
        '
        'BTNTAMBAH
        '
        Me.BTNTAMBAH.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNTAMBAH.Location = New System.Drawing.Point(348, 137)
        Me.BTNTAMBAH.Name = "BTNTAMBAH"
        Me.BTNTAMBAH.Size = New System.Drawing.Size(146, 29)
        Me.BTNTAMBAH.TabIndex = 12
        Me.BTNTAMBAH.Text = "Tambah Barang"
        Me.BTNTAMBAH.UseVisualStyleBackColor = True
        '
        'LBBARANG
        '
        Me.LBBARANG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBBARANG.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBBARANG.Location = New System.Drawing.Point(151, 55)
        Me.LBBARANG.Name = "LBBARANG"
        Me.LBBARANG.Size = New System.Drawing.Size(343, 26)
        Me.LBBARANG.TabIndex = 11
        Me.LBBARANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTNCARI
        '
        Me.BTNCARI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCARI.Location = New System.Drawing.Point(348, 11)
        Me.BTNCARI.Name = "BTNCARI"
        Me.BTNCARI.Size = New System.Drawing.Size(123, 29)
        Me.BTNCARI.TabIndex = 10
        Me.BTNCARI.Text = "Cari (F1)"
        Me.BTNCARI.UseVisualStyleBackColor = True
        '
        'BTNSTOK
        '
        Me.BTNSTOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSTOK.Location = New System.Drawing.Point(151, 273)
        Me.BTNSTOK.Name = "BTNSTOK"
        Me.BTNSTOK.Size = New System.Drawing.Size(189, 51)
        Me.BTNSTOK.TabIndex = 9
        Me.BTNSTOK.Text = "Tambah Stok"
        Me.BTNSTOK.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGCARI.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGCARI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGCARI.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGCARI.Location = New System.Drawing.Point(3, 35)
        Me.DGCARI.Name = "DGCARI"
        Me.DGCARI.ReadOnly = True
        Me.DGCARI.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGCARI.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGCARI.RowTemplate.Height = 24
        Me.DGCARI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCARI.Size = New System.Drawing.Size(514, 261)
        Me.DGCARI.TabIndex = 17
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
        'PNCARI
        '
        Me.PNCARI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PNCARI.Controls.Add(Me.DGCARI)
        Me.PNCARI.Controls.Add(Me.TXTCARI_BARANG)
        Me.PNCARI.Location = New System.Drawing.Point(3, 425)
        Me.PNCARI.Name = "PNCARI"
        Me.PNCARI.Size = New System.Drawing.Size(517, 296)
        Me.PNCARI.TabIndex = 15
        Me.PNCARI.Visible = False
        '
        'HapusToolStripMenuItem
        '
        Me.HapusToolStripMenuItem.Name = "HapusToolStripMenuItem"
        Me.HapusToolStripMenuItem.Size = New System.Drawing.Size(120, 24)
        Me.HapusToolStripMenuItem.Text = "Hapus"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HapusToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(121, 28)
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTAMPIL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGTAMPIL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGTAMPIL.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGTAMPIL.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGTAMPIL.Location = New System.Drawing.Point(517, 60)
        Me.DGTAMPIL.Name = "DGTAMPIL"
        Me.DGTAMPIL.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGTAMPIL.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGTAMPIL.RowHeadersVisible = False
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGTAMPIL.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DGTAMPIL.RowTemplate.Height = 24
        Me.DGTAMPIL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGTAMPIL.Size = New System.Drawing.Size(644, 662)
        Me.DGTAMPIL.TabIndex = 12
        '
        'TXTKODE
        '
        Me.TXTKODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTKODE.Location = New System.Drawing.Point(151, 12)
        Me.TXTKODE.Name = "TXTKODE"
        Me.TXTKODE.Size = New System.Drawing.Size(189, 26)
        Me.TXTKODE.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kode Barang"
        '
        'TXTHARGAPARTAI
        '
        Me.TXTHARGAPARTAI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHARGAPARTAI.Location = New System.Drawing.Point(151, 224)
        Me.TXTHARGAPARTAI.Name = "TXTHARGAPARTAI"
        Me.TXTHARGAPARTAI.Size = New System.Drawing.Size(135, 26)
        Me.TXTHARGAPARTAI.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Barang"
        '
        'TXTSUPPLIER
        '
        Me.TXTSUPPLIER.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUPPLIER.Location = New System.Drawing.Point(151, 181)
        Me.TXTSUPPLIER.Name = "TXTSUPPLIER"
        Me.TXTSUPPLIER.Size = New System.Drawing.Size(343, 26)
        Me.TXTSUPPLIER.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Jumlah"
        '
        'TXTJUMLAH
        '
        Me.TXTJUMLAH.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTJUMLAH.Location = New System.Drawing.Point(151, 138)
        Me.TXTJUMLAH.Name = "TXTJUMLAH"
        Me.TXTJUMLAH.Size = New System.Drawing.Size(189, 26)
        Me.TXTJUMLAH.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Supplier"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 227)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Harga Partai"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PNCARI)
        Me.Panel1.Controls.Add(Me.LBSATUAN)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.BTNTAMBAH)
        Me.Panel1.Controls.Add(Me.LBBARANG)
        Me.Panel1.Controls.Add(Me.BTNCARI)
        Me.Panel1.Controls.Add(Me.BTNSTOK)
        Me.Panel1.Controls.Add(Me.TXTKODE)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TXTHARGAPARTAI)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TXTSUPPLIER)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TXTJUMLAH)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(517, 721)
        Me.Panel1.TabIndex = 13
        '
        'nitip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1348, 721)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.DGTAMPIL)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "nitip"
        Me.Text = "nitip"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGCARI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNCARI.ResumeLayout(False)
        Me.PNCARI.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DGTAMPIL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BTNNEXT As Button
    Friend WithEvents TXTCARI As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BTNPREV As Button
    Friend WithEvents LBSATUAN As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BTNTAMBAH As Button
    Friend WithEvents LBBARANG As Label
    Friend WithEvents BTNCARI As Button
    Friend WithEvents BTNSTOK As Button
    Friend WithEvents DGCARI As DataGridView
    Friend WithEvents TXTCARI_BARANG As TextBox
    Friend WithEvents PNCARI As Panel
    Friend WithEvents HapusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DGTAMPIL As DataGridView
    Friend WithEvents TXTKODE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTHARGAPARTAI As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTSUPPLIER As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTJUMLAH As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
End Class
