<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_VOUCHER_DATA_ACTION
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_VOUCHER_DATA_ACTION))
        Me.PRINTNOTA = New System.Drawing.Printing.PrintDocument()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.CB_JENIS = New System.Windows.Forms.ComboBox()
        Me.BTNSIMPAN = New System.Windows.Forms.Button()
        Me.TXTNAMA = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.TXTHARGA_JUAL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTHARGA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.LBL_ID = New System.Windows.Forms.Label()
        Me.PNCONTROL.SuspendLayout()
        Me.PNCONTENT.SuspendLayout()
        Me.PNTOP.SuspendLayout()
        Me.SuspendLayout()
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
        Me.PNCONTROL.Location = New System.Drawing.Point(577, 0)
        Me.PNCONTROL.Name = "PNCONTROL"
        Me.PNCONTROL.Size = New System.Drawing.Size(47, 40)
        Me.PNCONTROL.TabIndex = 0
        '
        'CB_JENIS
        '
        Me.CB_JENIS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_JENIS.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_JENIS.FormattingEnabled = True
        Me.CB_JENIS.Items.AddRange(New Object() {"-- Pilih Jenis Voucher --", "Voucher", "Barang"})
        Me.CB_JENIS.Location = New System.Drawing.Point(216, 71)
        Me.CB_JENIS.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_JENIS.Name = "CB_JENIS"
        Me.CB_JENIS.Size = New System.Drawing.Size(349, 36)
        Me.CB_JENIS.TabIndex = 100
        '
        'BTNSIMPAN
        '
        Me.BTNSIMPAN.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNSIMPAN.FlatAppearance.BorderSize = 0
        Me.BTNSIMPAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNSIMPAN.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSIMPAN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNSIMPAN.Location = New System.Drawing.Point(216, 291)
        Me.BTNSIMPAN.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNSIMPAN.Name = "BTNSIMPAN"
        Me.BTNSIMPAN.Size = New System.Drawing.Size(145, 47)
        Me.BTNSIMPAN.TabIndex = 82
        Me.BTNSIMPAN.Text = "SIMPAN"
        Me.BTNSIMPAN.UseVisualStyleBackColor = False
        '
        'TXTNAMA
        '
        Me.TXTNAMA.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAMA.Location = New System.Drawing.Point(216, 125)
        Me.TXTNAMA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTNAMA.Name = "TXTNAMA"
        Me.TXTNAMA.Size = New System.Drawing.Size(349, 34)
        Me.TXTNAMA.TabIndex = 70
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(27, 128)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 28)
        Me.Label8.TabIndex = 84
        Me.Label8.Text = "Nama Voucher"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(27, 75)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 28)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "Jenis Voucher"
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
        Me.Label1.Text = "TAMBAH DATA VOUCHER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PNCONTENT
        '
        Me.PNCONTENT.Controls.Add(Me.TXTHARGA_JUAL)
        Me.PNCONTENT.Controls.Add(Me.Label3)
        Me.PNCONTENT.Controls.Add(Me.TXTHARGA)
        Me.PNCONTENT.Controls.Add(Me.Label2)
        Me.PNCONTENT.Controls.Add(Me.CB_JENIS)
        Me.PNCONTENT.Controls.Add(Me.BTNSIMPAN)
        Me.PNCONTENT.Controls.Add(Me.TXTNAMA)
        Me.PNCONTENT.Controls.Add(Me.Label8)
        Me.PNCONTENT.Controls.Add(Me.Label9)
        Me.PNCONTENT.Controls.Add(Me.Label1)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(0, 40)
        Me.PNCONTENT.Margin = New System.Windows.Forms.Padding(2)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(624, 373)
        Me.PNCONTENT.TabIndex = 28
        '
        'TXTHARGA_JUAL
        '
        Me.TXTHARGA_JUAL.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHARGA_JUAL.Location = New System.Drawing.Point(216, 229)
        Me.TXTHARGA_JUAL.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTHARGA_JUAL.Name = "TXTHARGA_JUAL"
        Me.TXTHARGA_JUAL.Size = New System.Drawing.Size(349, 34)
        Me.TXTHARGA_JUAL.TabIndex = 109
        Me.TXTHARGA_JUAL.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 232)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(169, 28)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "Nilai Voucher (Rp)"
        Me.Label3.Visible = False
        '
        'TXTHARGA
        '
        Me.TXTHARGA.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHARGA.Location = New System.Drawing.Point(216, 177)
        Me.TXTHARGA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTHARGA.Name = "TXTHARGA"
        Me.TXTHARGA.Size = New System.Drawing.Size(349, 34)
        Me.TXTHARGA.TabIndex = 107
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 180)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 28)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Harga (Points)"
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.LBL_ID)
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(624, 40)
        Me.PNTOP.TabIndex = 27
        '
        'LBL_ID
        '
        Me.LBL_ID.AutoSize = True
        Me.LBL_ID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_ID.Location = New System.Drawing.Point(11, 7)
        Me.LBL_ID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBL_ID.Name = "LBL_ID"
        Me.LBL_ID.Size = New System.Drawing.Size(129, 28)
        Me.LBL_ID.TabIndex = 111
        Me.LBL_ID.Text = "Jenis Voucher"
        Me.LBL_ID.Visible = False
        '
        'FR_VOUCHER_DATA_ACTION
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
        Me.Name = "FR_VOUCHER_DATA_ACTION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU VOUCHER"
        Me.PNCONTROL.ResumeLayout(False)
        Me.PNCONTENT.ResumeLayout(False)
        Me.PNCONTENT.PerformLayout()
        Me.PNTOP.ResumeLayout(False)
        Me.PNTOP.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PRINTNOTA As Printing.PrintDocument
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents CB_JENIS As ComboBox
    Friend WithEvents BTNSIMPAN As Button
    Friend WithEvents TXTNAMA As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents PNTOP As Panel
    Friend WithEvents TXTHARGA_JUAL As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTHARGA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LBL_ID As Label
End Class
