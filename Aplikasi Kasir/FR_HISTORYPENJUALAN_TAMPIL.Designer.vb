<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_HISTORYPENJUALAN_TAMPIL
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_HISTORYPENJUALAN_TAMPIL))
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.LBL_SUBTOTAL = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BTNPRINT = New System.Windows.Forms.Button()
        Me.LBL_KEMBALI = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LBL_BAYAR = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LBL_DISKON = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LBL_TOTAL = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DGHISTORY = New System.Windows.Forms.DataGridView()
        Me.LBL_KASIR = New System.Windows.Forms.Label()
        Me.LBL_PEMBELI = New System.Windows.Forms.Label()
        Me.LBL_TGLTRANS = New System.Windows.Forms.Label()
        Me.LBL_IDTRANS = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.PRINTNOTA = New System.Drawing.Printing.PrintDocument()
        Me.PNCONTENT.SuspendLayout()
        CType(Me.DGHISTORY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNCONTROL.SuspendLayout()
        Me.PNTOP.SuspendLayout()
        Me.SuspendLayout()
        '
        'PNCONTENT
        '
        Me.PNCONTENT.Controls.Add(Me.LBL_SUBTOTAL)
        Me.PNCONTENT.Controls.Add(Me.Label7)
        Me.PNCONTENT.Controls.Add(Me.BTNPRINT)
        Me.PNCONTENT.Controls.Add(Me.LBL_KEMBALI)
        Me.PNCONTENT.Controls.Add(Me.Label12)
        Me.PNCONTENT.Controls.Add(Me.LBL_BAYAR)
        Me.PNCONTENT.Controls.Add(Me.Label10)
        Me.PNCONTENT.Controls.Add(Me.LBL_DISKON)
        Me.PNCONTENT.Controls.Add(Me.Label8)
        Me.PNCONTENT.Controls.Add(Me.LBL_TOTAL)
        Me.PNCONTENT.Controls.Add(Me.Label6)
        Me.PNCONTENT.Controls.Add(Me.DGHISTORY)
        Me.PNCONTENT.Controls.Add(Me.LBL_KASIR)
        Me.PNCONTENT.Controls.Add(Me.LBL_PEMBELI)
        Me.PNCONTENT.Controls.Add(Me.LBL_TGLTRANS)
        Me.PNCONTENT.Controls.Add(Me.LBL_IDTRANS)
        Me.PNCONTENT.Controls.Add(Me.Label4)
        Me.PNCONTENT.Controls.Add(Me.Label3)
        Me.PNCONTENT.Controls.Add(Me.Label2)
        Me.PNCONTENT.Controls.Add(Me.Label1)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(0, 40)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(986, 728)
        Me.PNCONTENT.TabIndex = 24
        '
        'LBL_SUBTOTAL
        '
        Me.LBL_SUBTOTAL.Location = New System.Drawing.Point(691, 505)
        Me.LBL_SUBTOTAL.Name = "LBL_SUBTOTAL"
        Me.LBL_SUBTOTAL.Size = New System.Drawing.Size(271, 35)
        Me.LBL_SUBTOTAL.TabIndex = 35
        Me.LBL_SUBTOTAL.Text = ": "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(599, 505)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 28)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Subtotal"
        '
        'BTNPRINT
        '
        Me.BTNPRINT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNPRINT.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNPRINT.FlatAppearance.BorderSize = 0
        Me.BTNPRINT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNPRINT.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNPRINT.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNPRINT.Location = New System.Drawing.Point(840, 20)
        Me.BTNPRINT.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNPRINT.Name = "BTNPRINT"
        Me.BTNPRINT.Size = New System.Drawing.Size(122, 45)
        Me.BTNPRINT.TabIndex = 33
        Me.BTNPRINT.Text = "PRINT"
        Me.BTNPRINT.UseVisualStyleBackColor = False
        '
        'LBL_KEMBALI
        '
        Me.LBL_KEMBALI.Location = New System.Drawing.Point(691, 677)
        Me.LBL_KEMBALI.Name = "LBL_KEMBALI"
        Me.LBL_KEMBALI.Size = New System.Drawing.Size(271, 35)
        Me.LBL_KEMBALI.TabIndex = 32
        Me.LBL_KEMBALI.Text = ": "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(599, 677)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 28)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Kembali"
        '
        'LBL_BAYAR
        '
        Me.LBL_BAYAR.Location = New System.Drawing.Point(691, 634)
        Me.LBL_BAYAR.Name = "LBL_BAYAR"
        Me.LBL_BAYAR.Size = New System.Drawing.Size(271, 35)
        Me.LBL_BAYAR.TabIndex = 30
        Me.LBL_BAYAR.Text = ": "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(599, 634)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 28)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Bayar"
        '
        'LBL_DISKON
        '
        Me.LBL_DISKON.Location = New System.Drawing.Point(691, 548)
        Me.LBL_DISKON.Name = "LBL_DISKON"
        Me.LBL_DISKON.Size = New System.Drawing.Size(271, 35)
        Me.LBL_DISKON.TabIndex = 28
        Me.LBL_DISKON.Text = ": "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(599, 548)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 28)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Diskon"
        '
        'LBL_TOTAL
        '
        Me.LBL_TOTAL.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_TOTAL.Location = New System.Drawing.Point(691, 591)
        Me.LBL_TOTAL.Name = "LBL_TOTAL"
        Me.LBL_TOTAL.Size = New System.Drawing.Size(271, 35)
        Me.LBL_TOTAL.TabIndex = 26
        Me.LBL_TOTAL.Text = ": "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(599, 591)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 28)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Total"
        '
        'DGHISTORY
        '
        Me.DGHISTORY.AllowUserToAddRows = False
        Me.DGHISTORY.AllowUserToDeleteRows = False
        Me.DGHISTORY.AllowUserToResizeColumns = False
        Me.DGHISTORY.AllowUserToResizeRows = False
        Me.DGHISTORY.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGHISTORY.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGHISTORY.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGHISTORY.ColumnHeadersHeight = 30
        Me.DGHISTORY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGHISTORY.Location = New System.Drawing.Point(29, 239)
        Me.DGHISTORY.Margin = New System.Windows.Forms.Padding(2)
        Me.DGHISTORY.MultiSelect = False
        Me.DGHISTORY.Name = "DGHISTORY"
        Me.DGHISTORY.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGHISTORY.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGHISTORY.RowHeadersVisible = False
        Me.DGHISTORY.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGHISTORY.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGHISTORY.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGHISTORY.RowTemplate.Height = 30
        Me.DGHISTORY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGHISTORY.ShowCellErrors = False
        Me.DGHISTORY.ShowCellToolTips = False
        Me.DGHISTORY.ShowEditingIcon = False
        Me.DGHISTORY.ShowRowErrors = False
        Me.DGHISTORY.Size = New System.Drawing.Size(933, 245)
        Me.DGHISTORY.TabIndex = 24
        '
        'LBL_KASIR
        '
        Me.LBL_KASIR.Location = New System.Drawing.Point(241, 181)
        Me.LBL_KASIR.Name = "LBL_KASIR"
        Me.LBL_KASIR.Size = New System.Drawing.Size(405, 30)
        Me.LBL_KASIR.TabIndex = 7
        Me.LBL_KASIR.Text = ": "
        '
        'LBL_PEMBELI
        '
        Me.LBL_PEMBELI.Location = New System.Drawing.Point(241, 133)
        Me.LBL_PEMBELI.Name = "LBL_PEMBELI"
        Me.LBL_PEMBELI.Size = New System.Drawing.Size(405, 30)
        Me.LBL_PEMBELI.TabIndex = 6
        Me.LBL_PEMBELI.Text = ": "
        '
        'LBL_TGLTRANS
        '
        Me.LBL_TGLTRANS.Location = New System.Drawing.Point(241, 85)
        Me.LBL_TGLTRANS.Name = "LBL_TGLTRANS"
        Me.LBL_TGLTRANS.Size = New System.Drawing.Size(405, 30)
        Me.LBL_TGLTRANS.TabIndex = 5
        Me.LBL_TGLTRANS.Text = ": "
        '
        'LBL_IDTRANS
        '
        Me.LBL_IDTRANS.Location = New System.Drawing.Point(241, 37)
        Me.LBL_IDTRANS.Name = "LBL_IDTRANS"
        Me.LBL_IDTRANS.Size = New System.Drawing.Size(405, 30)
        Me.LBL_IDTRANS.TabIndex = 4
        Me.LBL_IDTRANS.Text = ": "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 28)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nama Kasir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 28)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nama Pembeli"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tanggal Transaksi"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Transaksi"
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
        'PNCONTROL
        '
        Me.PNCONTROL.Controls.Add(Me.BTNCLOSE)
        Me.PNCONTROL.Dock = System.Windows.Forms.DockStyle.Right
        Me.PNCONTROL.Location = New System.Drawing.Point(939, 0)
        Me.PNCONTROL.Name = "PNCONTROL"
        Me.PNCONTROL.Size = New System.Drawing.Size(47, 40)
        Me.PNCONTROL.TabIndex = 0
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(986, 40)
        Me.PNTOP.TabIndex = 23
        '
        'PRINTNOTA
        '
        '
        'FR_HISTORYPENJUALAN_TAMPIL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(986, 768)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNTOP)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FR_HISTORYPENJUALAN_TAMPIL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HISTORY PENJUALAN"
        Me.PNCONTENT.ResumeLayout(False)
        Me.PNCONTENT.PerformLayout()
        CType(Me.DGHISTORY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNCONTROL.ResumeLayout(False)
        Me.PNTOP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents PNTOP As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LBL_KASIR As Label
    Friend WithEvents LBL_PEMBELI As Label
    Friend WithEvents LBL_TGLTRANS As Label
    Friend WithEvents LBL_IDTRANS As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LBL_KEMBALI As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents LBL_BAYAR As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LBL_DISKON As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LBL_TOTAL As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents DGHISTORY As DataGridView
    Friend WithEvents BTNPRINT As Button
    Friend WithEvents PRINTNOTA As Printing.PrintDocument
    Friend WithEvents LBL_SUBTOTAL As Label
    Friend WithEvents Label7 As Label
End Class
