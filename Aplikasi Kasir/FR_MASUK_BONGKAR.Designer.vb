<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_MASUK_BONGKAR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_MASUK_BONGKAR))
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.TXT_JMLBRG = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXT_JML = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXT_BARANGTUJUAN = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXT_BARANGAWAL = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXT_ID = New System.Windows.Forms.Label()
        Me.TXT_KODEBARANG = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BTN_CARIBARANG = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTNSIMPAN = New System.Windows.Forms.Button()
        Me.LBID = New System.Windows.Forms.Label()
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.TXT_IDBRG = New System.Windows.Forms.Label()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.PNCONTENT.SuspendLayout()
        Me.PNTOP.SuspendLayout()
        Me.PNCONTROL.SuspendLayout()
        Me.SuspendLayout()
        '
        'PNCONTENT
        '
        Me.PNCONTENT.Controls.Add(Me.TXT_JMLBRG)
        Me.PNCONTENT.Controls.Add(Me.Label3)
        Me.PNCONTENT.Controls.Add(Me.TXT_JML)
        Me.PNCONTENT.Controls.Add(Me.Label10)
        Me.PNCONTENT.Controls.Add(Me.TXT_BARANGTUJUAN)
        Me.PNCONTENT.Controls.Add(Me.Label7)
        Me.PNCONTENT.Controls.Add(Me.TXT_BARANGAWAL)
        Me.PNCONTENT.Controls.Add(Me.Label5)
        Me.PNCONTENT.Controls.Add(Me.TXT_ID)
        Me.PNCONTENT.Controls.Add(Me.Label2)
        Me.PNCONTENT.Controls.Add(Me.BTN_CARIBARANG)
        Me.PNCONTENT.Controls.Add(Me.Label1)
        Me.PNCONTENT.Controls.Add(Me.BTNSIMPAN)
        Me.PNCONTENT.Controls.Add(Me.LBID)
        Me.PNCONTENT.Controls.Add(Me.TXT_KODEBARANG)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(0, 40)
        Me.PNCONTENT.Margin = New System.Windows.Forms.Padding(2)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(611, 475)
        Me.PNCONTENT.TabIndex = 27
        '
        'TXT_JMLBRG
        '
        Me.TXT_JMLBRG.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_JMLBRG.Location = New System.Drawing.Point(216, 322)
        Me.TXT_JMLBRG.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_JMLBRG.Multiline = True
        Me.TXT_JMLBRG.Name = "TXT_JMLBRG"
        Me.TXT_JMLBRG.Size = New System.Drawing.Size(359, 41)
        Me.TXT_JMLBRG.TabIndex = 82
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 328)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 28)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Jml Isi Barang"
        '
        'TXT_JML
        '
        Me.TXT_JML.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_JML.Location = New System.Drawing.Point(216, 174)
        Me.TXT_JML.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_JML.Name = "TXT_JML"
        Me.TXT_JML.Size = New System.Drawing.Size(384, 41)
        Me.TXT_JML.TabIndex = 80
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 180)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 28)
        Me.Label10.TabIndex = 79
        Me.Label10.Text = "Jml Bongkar"
        '
        'TXT_BARANGTUJUAN
        '
        Me.TXT_BARANGTUJUAN.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_BARANGTUJUAN.Location = New System.Drawing.Point(213, 280)
        Me.TXT_BARANGTUJUAN.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXT_BARANGTUJUAN.Name = "TXT_BARANGTUJUAN"
        Me.TXT_BARANGTUJUAN.Size = New System.Drawing.Size(362, 40)
        Me.TXT_BARANGTUJUAN.TabIndex = 76
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 278)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 28)
        Me.Label7.TabIndex = 75
        Me.Label7.Text = "Barang Tujuan"
        '
        'TXT_BARANGAWAL
        '
        Me.TXT_BARANGAWAL.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_BARANGAWAL.Location = New System.Drawing.Point(213, 134)
        Me.TXT_BARANGAWAL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXT_BARANGAWAL.Name = "TXT_BARANGAWAL"
        Me.TXT_BARANGAWAL.Size = New System.Drawing.Size(362, 40)
        Me.TXT_BARANGAWAL.TabIndex = 74
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 132)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 28)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Barang Awal"
        '
        'TXT_ID
        '
        Me.TXT_ID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_ID.Location = New System.Drawing.Point(213, 86)
        Me.TXT_ID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXT_ID.Name = "TXT_ID"
        Me.TXT_ID.Size = New System.Drawing.Size(362, 40)
        Me.TXT_ID.TabIndex = 72
        '
        'TXT_KODEBARANG
        '
        Me.TXT_KODEBARANG.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_KODEBARANG.Location = New System.Drawing.Point(216, 223)
        Me.TXT_KODEBARANG.Margin = New System.Windows.Forms.Padding(2)
        Me.TXT_KODEBARANG.Name = "TXT_KODEBARANG"
        Me.TXT_KODEBARANG.Size = New System.Drawing.Size(383, 41)
        Me.TXT_KODEBARANG.TabIndex = 71
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 229)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 28)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Kode Barang Tujuan"
        '
        'BTN_CARIBARANG
        '
        Me.BTN_CARIBARANG.BackColor = System.Drawing.Color.Navy
        Me.BTN_CARIBARANG.FlatAppearance.BorderSize = 0
        Me.BTN_CARIBARANG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CARIBARANG.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CARIBARANG.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_CARIBARANG.Location = New System.Drawing.Point(481, 223)
        Me.BTN_CARIBARANG.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_CARIBARANG.Name = "BTN_CARIBARANG"
        Me.BTN_CARIBARANG.Size = New System.Drawing.Size(119, 41)
        Me.BTN_CARIBARANG.TabIndex = 65
        Me.BTN_CARIBARANG.Text = "Cari (F1)"
        Me.BTN_CARIBARANG.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(574, 45)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "BONGKAR BARANG"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTNSIMPAN
        '
        Me.BTNSIMPAN.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNSIMPAN.FlatAppearance.BorderSize = 0
        Me.BTNSIMPAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNSIMPAN.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSIMPAN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNSIMPAN.Location = New System.Drawing.Point(216, 391)
        Me.BTNSIMPAN.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNSIMPAN.Name = "BTNSIMPAN"
        Me.BTNSIMPAN.Size = New System.Drawing.Size(145, 50)
        Me.BTNSIMPAN.TabIndex = 8
        Me.BTNSIMPAN.Text = "SIMPAN"
        Me.BTNSIMPAN.UseVisualStyleBackColor = False
        '
        'LBID
        '
        Me.LBID.AutoSize = True
        Me.LBID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBID.Location = New System.Drawing.Point(13, 84)
        Me.LBID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBID.Name = "LBID"
        Me.LBID.Size = New System.Drawing.Size(113, 28)
        Me.LBID.TabIndex = 43
        Me.LBID.Text = "ID Transaksi"
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.TXT_IDBRG)
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(611, 40)
        Me.PNTOP.TabIndex = 26
        '
        'TXT_IDBRG
        '
        Me.TXT_IDBRG.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_IDBRG.Location = New System.Drawing.Point(2, 0)
        Me.TXT_IDBRG.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TXT_IDBRG.Name = "TXT_IDBRG"
        Me.TXT_IDBRG.Size = New System.Drawing.Size(389, 40)
        Me.TXT_IDBRG.TabIndex = 81
        Me.TXT_IDBRG.Text = "Id Transaksi"
        Me.TXT_IDBRG.Visible = False
        '
        'PNCONTROL
        '
        Me.PNCONTROL.Controls.Add(Me.BTNCLOSE)
        Me.PNCONTROL.Dock = System.Windows.Forms.DockStyle.Right
        Me.PNCONTROL.Location = New System.Drawing.Point(564, 0)
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
        'FR_MASUK_BONGKAR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(611, 515)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNTOP)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FR_MASUK_BONGKAR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU BARANG MASUK"
        Me.PNCONTENT.ResumeLayout(False)
        Me.PNCONTENT.PerformLayout()
        Me.PNTOP.ResumeLayout(False)
        Me.PNCONTROL.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents TXT_JML As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TXT_BARANGTUJUAN As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TXT_BARANGAWAL As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TXT_ID As Label
    Friend WithEvents TXT_KODEBARANG As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BTN_CARIBARANG As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents BTNSIMPAN As Button
    Friend WithEvents LBID As Label
    Friend WithEvents PNTOP As Panel
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents TXT_IDBRG As Label
    Friend WithEvents TXT_JMLBRG As TextBox
    Friend WithEvents Label3 As Label
End Class
