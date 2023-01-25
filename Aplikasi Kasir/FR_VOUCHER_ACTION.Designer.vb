<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_VOUCHER_ACTION
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_VOUCHER_ACTION))
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.LBL_POINT_MEMBER = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LBL_NAMA_MEMBER = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LBL_HARGA = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CB_DATA = New System.Windows.Forms.ComboBox()
        Me.BTNSIMPAN = New System.Windows.Forms.Button()
        Me.TXTID_MEMBER = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PRINTNOTA = New System.Drawing.Printing.PrintDocument()
        Me.PNTOP.SuspendLayout()
        Me.PNCONTROL.SuspendLayout()
        Me.PNCONTENT.SuspendLayout()
        Me.SuspendLayout()
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(624, 40)
        Me.PNTOP.TabIndex = 25
        '
        'PNCONTROL
        '
        Me.PNCONTROL.Controls.Add(Me.BTNCLOSE)
        Me.PNCONTROL.Dock = System.Windows.Forms.DockStyle.Right
        Me.PNCONTROL.Location = New System.Drawing.Point(577, 0)
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
        Me.PNCONTENT.Controls.Add(Me.LBL_POINT_MEMBER)
        Me.PNCONTENT.Controls.Add(Me.Label10)
        Me.PNCONTENT.Controls.Add(Me.LBL_NAMA_MEMBER)
        Me.PNCONTENT.Controls.Add(Me.Label5)
        Me.PNCONTENT.Controls.Add(Me.LBL_HARGA)
        Me.PNCONTENT.Controls.Add(Me.Label2)
        Me.PNCONTENT.Controls.Add(Me.CB_DATA)
        Me.PNCONTENT.Controls.Add(Me.BTNSIMPAN)
        Me.PNCONTENT.Controls.Add(Me.TXTID_MEMBER)
        Me.PNCONTENT.Controls.Add(Me.Label8)
        Me.PNCONTENT.Controls.Add(Me.Label9)
        Me.PNCONTENT.Controls.Add(Me.Label1)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(0, 40)
        Me.PNCONTENT.Margin = New System.Windows.Forms.Padding(2)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(624, 373)
        Me.PNCONTENT.TabIndex = 26
        '
        'LBL_POINT_MEMBER
        '
        Me.LBL_POINT_MEMBER.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_POINT_MEMBER.Location = New System.Drawing.Point(193, 249)
        Me.LBL_POINT_MEMBER.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBL_POINT_MEMBER.Name = "LBL_POINT_MEMBER"
        Me.LBL_POINT_MEMBER.Size = New System.Drawing.Size(349, 28)
        Me.LBL_POINT_MEMBER.TabIndex = 106
        Me.LBL_POINT_MEMBER.Text = ": "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(27, 249)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 28)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Point Member"
        '
        'LBL_NAMA_MEMBER
        '
        Me.LBL_NAMA_MEMBER.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_NAMA_MEMBER.Location = New System.Drawing.Point(193, 208)
        Me.LBL_NAMA_MEMBER.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBL_NAMA_MEMBER.Name = "LBL_NAMA_MEMBER"
        Me.LBL_NAMA_MEMBER.Size = New System.Drawing.Size(349, 28)
        Me.LBL_NAMA_MEMBER.TabIndex = 104
        Me.LBL_NAMA_MEMBER.Text = ": "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 208)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 28)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Nama Member"
        '
        'LBL_HARGA
        '
        Me.LBL_HARGA.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_HARGA.Location = New System.Drawing.Point(193, 120)
        Me.LBL_HARGA.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBL_HARGA.Name = "LBL_HARGA"
        Me.LBL_HARGA.Size = New System.Drawing.Size(349, 28)
        Me.LBL_HARGA.TabIndex = 102
        Me.LBL_HARGA.Text = ": "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 120)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 28)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Harga"
        '
        'CB_DATA
        '
        Me.CB_DATA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_DATA.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_DATA.FormattingEnabled = True
        Me.CB_DATA.Location = New System.Drawing.Point(193, 71)
        Me.CB_DATA.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_DATA.Name = "CB_DATA"
        Me.CB_DATA.Size = New System.Drawing.Size(349, 36)
        Me.CB_DATA.TabIndex = 100
        '
        'BTNSIMPAN
        '
        Me.BTNSIMPAN.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNSIMPAN.FlatAppearance.BorderSize = 0
        Me.BTNSIMPAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNSIMPAN.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSIMPAN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNSIMPAN.Location = New System.Drawing.Point(198, 302)
        Me.BTNSIMPAN.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNSIMPAN.Name = "BTNSIMPAN"
        Me.BTNSIMPAN.Size = New System.Drawing.Size(145, 47)
        Me.BTNSIMPAN.TabIndex = 82
        Me.BTNSIMPAN.Text = "SIMPAN"
        Me.BTNSIMPAN.UseVisualStyleBackColor = False
        '
        'TXTID_MEMBER
        '
        Me.TXTID_MEMBER.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTID_MEMBER.Location = New System.Drawing.Point(193, 161)
        Me.TXTID_MEMBER.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTID_MEMBER.Name = "TXTID_MEMBER"
        Me.TXTID_MEMBER.Size = New System.Drawing.Size(349, 34)
        Me.TXTID_MEMBER.TabIndex = 70
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(27, 164)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 28)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "ID Member"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(27, 75)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 28)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Nama Voucher"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(587, 45)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "TRANSAKSI VOUCHER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PRINTNOTA
        '
        '
        'FR_VOUCHER_ACTION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(624, 413)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNTOP)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FR_VOUCHER_ACTION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU VOUCHER"
        Me.PNTOP.ResumeLayout(False)
        Me.PNCONTROL.ResumeLayout(False)
        Me.PNCONTENT.ResumeLayout(False)
        Me.PNCONTENT.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PNTOP As Panel
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents LBL_HARGA As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CB_DATA As ComboBox
    Friend WithEvents BTNSIMPAN As Button
    Friend WithEvents TXTID_MEMBER As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LBL_POINT_MEMBER As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LBL_NAMA_MEMBER As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PRINTNOTA As Printing.PrintDocument
End Class
