<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FR_KELUAR_TAMPIL
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_KELUAR_TAMPIL))
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.BTNNEXT = New System.Windows.Forms.Button()
        Me.BTNPREV = New System.Windows.Forms.Button()
        Me.DGCARI = New System.Windows.Forms.DataGridView()
        Me.TXTCARI = New System.Windows.Forms.TextBox()
        Me.KODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BARANG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SATUAN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STOK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPSI1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HARGA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPSI2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HARGA2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPSI3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HARGA3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPSI4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HARGA4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPSI5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HARGA5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PNTOP.SuspendLayout()
        Me.PNCONTROL.SuspendLayout()
        Me.PNCONTENT.SuspendLayout()
        CType(Me.DGCARI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(1300, 40)
        Me.PNTOP.TabIndex = 21
        '
        'PNCONTROL
        '
        Me.PNCONTROL.Controls.Add(Me.BTNCLOSE)
        Me.PNCONTROL.Dock = System.Windows.Forms.DockStyle.Right
        Me.PNCONTROL.Location = New System.Drawing.Point(1253, 0)
        Me.PNCONTROL.Name = "PNCONTROL"
        Me.PNCONTROL.Size = New System.Drawing.Size(47, 40)
        Me.PNCONTROL.TabIndex = 0
        '
        'BTNCLOSE
        '
        Me.BTNCLOSE.FlatAppearance.BorderSize = 0
        Me.BTNCLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNCLOSE.Image = Global.Aplikasi_Kasir.My.Resources.Resources.close15px
        Me.BTNCLOSE.Location = New System.Drawing.Point(15, 12)
        Me.BTNCLOSE.Name = "BTNCLOSE"
        Me.BTNCLOSE.Size = New System.Drawing.Size(18, 18)
        Me.BTNCLOSE.TabIndex = 0
        Me.BTNCLOSE.UseVisualStyleBackColor = True
        '
        'PNCONTENT
        '
        Me.PNCONTENT.Controls.Add(Me.BTNNEXT)
        Me.PNCONTENT.Controls.Add(Me.BTNPREV)
        Me.PNCONTENT.Controls.Add(Me.DGCARI)
        Me.PNCONTENT.Controls.Add(Me.TXTCARI)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(0, 40)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(1300, 510)
        Me.PNCONTENT.TabIndex = 22
        '
        'BTNNEXT
        '
        Me.BTNNEXT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNNEXT.BackColor = System.Drawing.Color.DarkBlue
        Me.BTNNEXT.FlatAppearance.BorderSize = 0
        Me.BTNNEXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNNEXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNNEXT.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNNEXT.Location = New System.Drawing.Point(1238, 7)
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
        Me.BTNPREV.Location = New System.Drawing.Point(1182, 7)
        Me.BTNPREV.Name = "BTNPREV"
        Me.BTNPREV.Size = New System.Drawing.Size(50, 29)
        Me.BTNPREV.TabIndex = 66
        Me.BTNPREV.Text = "<"
        Me.BTNPREV.UseVisualStyleBackColor = False
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.NullValue = "-"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGCARI.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGCARI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGCARI.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KODE, Me.BARANG, Me.SATUAN, Me.STOK, Me.OPSI1, Me.HARGA1, Me.OPSI2, Me.HARGA2, Me.OPSI3, Me.HARGA3, Me.OPSI4, Me.HARGA4, Me.OPSI5, Me.HARGA5})
        Me.DGCARI.Location = New System.Drawing.Point(12, 42)
        Me.DGCARI.MultiSelect = False
        Me.DGCARI.Name = "DGCARI"
        Me.DGCARI.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGCARI.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGCARI.RowHeadersVisible = False
        Me.DGCARI.RowHeadersWidth = 51
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGCARI.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGCARI.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGCARI.RowTemplate.Height = 30
        Me.DGCARI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCARI.Size = New System.Drawing.Size(1276, 456)
        Me.DGCARI.TabIndex = 65
        '
        'TXTCARI
        '
        Me.TXTCARI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTCARI.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCARI.Location = New System.Drawing.Point(12, 6)
        Me.TXTCARI.Name = "TXTCARI"
        Me.TXTCARI.Size = New System.Drawing.Size(1164, 30)
        Me.TXTCARI.TabIndex = 64
        '
        'KODE
        '
        Me.KODE.HeaderText = "Kode"
        Me.KODE.MinimumWidth = 6
        Me.KODE.Name = "KODE"
        Me.KODE.ReadOnly = True
        Me.KODE.Width = 78
        '
        'BARANG
        '
        Me.BARANG.HeaderText = "Nama Barang"
        Me.BARANG.MinimumWidth = 6
        Me.BARANG.Name = "BARANG"
        Me.BARANG.ReadOnly = True
        Me.BARANG.Width = 144
        '
        'SATUAN
        '
        Me.SATUAN.HeaderText = "Satuan"
        Me.SATUAN.MinimumWidth = 6
        Me.SATUAN.Name = "SATUAN"
        Me.SATUAN.ReadOnly = True
        Me.SATUAN.Width = 92
        '
        'STOK
        '
        Me.STOK.HeaderText = "Stok"
        Me.STOK.MinimumWidth = 6
        Me.STOK.Name = "STOK"
        Me.STOK.ReadOnly = True
        Me.STOK.Width = 71
        '
        'OPSI1
        '
        Me.OPSI1.HeaderText = "Opsi 1"
        Me.OPSI1.MinimumWidth = 6
        Me.OPSI1.Name = "OPSI1"
        Me.OPSI1.ReadOnly = True
        Me.OPSI1.Width = 87
        '
        'HARGA1
        '
        Me.HARGA1.HeaderText = "Harga 1"
        Me.HARGA1.MinimumWidth = 6
        Me.HARGA1.Name = "HARGA1"
        Me.HARGA1.ReadOnly = True
        Me.HARGA1.Width = 99
        '
        'OPSI2
        '
        Me.OPSI2.HeaderText = "Opsi 2"
        Me.OPSI2.MinimumWidth = 6
        Me.OPSI2.Name = "OPSI2"
        Me.OPSI2.ReadOnly = True
        Me.OPSI2.Width = 87
        '
        'HARGA2
        '
        Me.HARGA2.HeaderText = "Harga 2"
        Me.HARGA2.MinimumWidth = 6
        Me.HARGA2.Name = "HARGA2"
        Me.HARGA2.ReadOnly = True
        Me.HARGA2.Width = 99
        '
        'OPSI3
        '
        Me.OPSI3.HeaderText = "Opsi 3"
        Me.OPSI3.MinimumWidth = 6
        Me.OPSI3.Name = "OPSI3"
        Me.OPSI3.ReadOnly = True
        Me.OPSI3.Width = 87
        '
        'HARGA3
        '
        Me.HARGA3.HeaderText = "Harga 3"
        Me.HARGA3.MinimumWidth = 6
        Me.HARGA3.Name = "HARGA3"
        Me.HARGA3.ReadOnly = True
        Me.HARGA3.Width = 99
        '
        'OPSI4
        '
        Me.OPSI4.HeaderText = "Opsi 4"
        Me.OPSI4.MinimumWidth = 6
        Me.OPSI4.Name = "OPSI4"
        Me.OPSI4.ReadOnly = True
        Me.OPSI4.Width = 87
        '
        'HARGA4
        '
        Me.HARGA4.HeaderText = "Harga 4"
        Me.HARGA4.MinimumWidth = 6
        Me.HARGA4.Name = "HARGA4"
        Me.HARGA4.ReadOnly = True
        Me.HARGA4.Width = 99
        '
        'OPSI5
        '
        Me.OPSI5.HeaderText = "Opsi 5"
        Me.OPSI5.MinimumWidth = 6
        Me.OPSI5.Name = "OPSI5"
        Me.OPSI5.ReadOnly = True
        Me.OPSI5.Width = 87
        '
        'HARGA5
        '
        Me.HARGA5.HeaderText = "Harga 5"
        Me.HARGA5.MinimumWidth = 6
        Me.HARGA5.Name = "HARGA5"
        Me.HARGA5.ReadOnly = True
        Me.HARGA5.Width = 99
        '
        'FR_KELUAR_TAMPIL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1300, 550)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNTOP)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FR_KELUAR_TAMPIL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU BARANG KELUAR"
        Me.PNTOP.ResumeLayout(False)
        Me.PNCONTROL.ResumeLayout(False)
        Me.PNCONTENT.ResumeLayout(False)
        Me.PNCONTENT.PerformLayout()
        CType(Me.DGCARI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PNTOP As Panel
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents DGCARI As DataGridView
    Friend WithEvents TXTCARI As TextBox
    Friend WithEvents BTNNEXT As Button
    Friend WithEvents BTNPREV As Button
    Friend WithEvents KODE As DataGridViewTextBoxColumn
    Friend WithEvents BARANG As DataGridViewTextBoxColumn
    Friend WithEvents SATUAN As DataGridViewTextBoxColumn
    Friend WithEvents STOK As DataGridViewTextBoxColumn
    Friend WithEvents OPSI1 As DataGridViewTextBoxColumn
    Friend WithEvents HARGA1 As DataGridViewTextBoxColumn
    Friend WithEvents OPSI2 As DataGridViewTextBoxColumn
    Friend WithEvents HARGA2 As DataGridViewTextBoxColumn
    Friend WithEvents OPSI3 As DataGridViewTextBoxColumn
    Friend WithEvents HARGA3 As DataGridViewTextBoxColumn
    Friend WithEvents OPSI4 As DataGridViewTextBoxColumn
    Friend WithEvents HARGA4 As DataGridViewTextBoxColumn
    Friend WithEvents OPSI5 As DataGridViewTextBoxColumn
    Friend WithEvents HARGA5 As DataGridViewTextBoxColumn
End Class
