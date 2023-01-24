<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_MEMBER_ACTION
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_MEMBER_ACTION))
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.BTNSIMPAN = New System.Windows.Forms.Button()
        Me.TXTNOHP = New System.Windows.Forms.TextBox()
        Me.TXTJK = New System.Windows.Forms.ComboBox()
        Me.TXTALAMAT = New System.Windows.Forms.TextBox()
        Me.TXTNAMA = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LBID = New System.Windows.Forms.Label()
        Me.TXTID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.PNTOP.Size = New System.Drawing.Size(667, 40)
        Me.PNTOP.TabIndex = 22
        '
        'PNCONTROL
        '
        Me.PNCONTROL.Controls.Add(Me.BTNCLOSE)
        Me.PNCONTROL.Dock = System.Windows.Forms.DockStyle.Right
        Me.PNCONTROL.Location = New System.Drawing.Point(620, 0)
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
        Me.PNCONTENT.Controls.Add(Me.Label1)
        Me.PNCONTENT.Controls.Add(Me.TXTID)
        Me.PNCONTENT.Controls.Add(Me.BTNSIMPAN)
        Me.PNCONTENT.Controls.Add(Me.TXTNOHP)
        Me.PNCONTENT.Controls.Add(Me.TXTJK)
        Me.PNCONTENT.Controls.Add(Me.TXTALAMAT)
        Me.PNCONTENT.Controls.Add(Me.TXTNAMA)
        Me.PNCONTENT.Controls.Add(Me.Label6)
        Me.PNCONTENT.Controls.Add(Me.Label5)
        Me.PNCONTENT.Controls.Add(Me.Label10)
        Me.PNCONTENT.Controls.Add(Me.Label11)
        Me.PNCONTENT.Controls.Add(Me.LBID)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(0, 40)
        Me.PNCONTENT.Margin = New System.Windows.Forms.Padding(2)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(667, 422)
        Me.PNCONTENT.TabIndex = 23
        '
        'BTNSIMPAN
        '
        Me.BTNSIMPAN.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNSIMPAN.FlatAppearance.BorderSize = 0
        Me.BTNSIMPAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNSIMPAN.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSIMPAN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNSIMPAN.Location = New System.Drawing.Point(182, 342)
        Me.BTNSIMPAN.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNSIMPAN.Name = "BTNSIMPAN"
        Me.BTNSIMPAN.Size = New System.Drawing.Size(145, 50)
        Me.BTNSIMPAN.TabIndex = 8
        Me.BTNSIMPAN.Text = "SIMPAN"
        Me.BTNSIMPAN.UseVisualStyleBackColor = False
        '
        'TXTNOHP
        '
        Me.TXTNOHP.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOHP.Location = New System.Drawing.Point(182, 234)
        Me.TXTNOHP.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTNOHP.MaxLength = 15
        Me.TXTNOHP.Name = "TXTNOHP"
        Me.TXTNOHP.ShortcutsEnabled = False
        Me.TXTNOHP.Size = New System.Drawing.Size(249, 34)
        Me.TXTNOHP.TabIndex = 6
        '
        'TXTJK
        '
        Me.TXTJK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TXTJK.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTJK.FormattingEnabled = True
        Me.TXTJK.Items.AddRange(New Object() {"Laki-laki", "Perempuan"})
        Me.TXTJK.Location = New System.Drawing.Point(182, 288)
        Me.TXTJK.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTJK.Name = "TXTJK"
        Me.TXTJK.Size = New System.Drawing.Size(249, 36)
        Me.TXTJK.TabIndex = 5
        '
        'TXTALAMAT
        '
        Me.TXTALAMAT.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTALAMAT.Location = New System.Drawing.Point(182, 180)
        Me.TXTALAMAT.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTALAMAT.MaxLength = 100
        Me.TXTALAMAT.Name = "TXTALAMAT"
        Me.TXTALAMAT.Size = New System.Drawing.Size(439, 34)
        Me.TXTALAMAT.TabIndex = 3
        '
        'TXTNAMA
        '
        Me.TXTNAMA.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAMA.Location = New System.Drawing.Point(182, 126)
        Me.TXTNAMA.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTNAMA.MaxLength = 100
        Me.TXTNAMA.Name = "TXTNAMA"
        Me.TXTNAMA.Size = New System.Drawing.Size(439, 34)
        Me.TXTNAMA.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 237)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 28)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "No. HP"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 292)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 28)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Jenis Kelamin"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 183)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 28)
        Me.Label10.TabIndex = 45
        Me.Label10.Text = "Alamat"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 129)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 28)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Nama"
        '
        'LBID
        '
        Me.LBID.AutoSize = True
        Me.LBID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBID.Location = New System.Drawing.Point(11, 75)
        Me.LBID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBID.Name = "LBID"
        Me.LBID.Size = New System.Drawing.Size(110, 28)
        Me.LBID.TabIndex = 43
        Me.LBID.Text = "ID Member"
        '
        'TXTID
        '
        Me.TXTID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTID.Location = New System.Drawing.Point(182, 72)
        Me.TXTID.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTID.MaxLength = 100
        Me.TXTID.Name = "TXTID"
        Me.TXTID.Size = New System.Drawing.Size(439, 34)
        Me.TXTID.TabIndex = 63
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(630, 45)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "TAMBAH MEMBER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FR_MEMBER_ACTION
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(667, 462)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNTOP)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FR_MEMBER_ACTION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU MEMBER"
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
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTID As TextBox
    Friend WithEvents BTNSIMPAN As Button
    Friend WithEvents TXTNOHP As TextBox
    Friend WithEvents TXTJK As ComboBox
    Friend WithEvents TXTALAMAT As TextBox
    Friend WithEvents TXTNAMA As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LBID As Label
End Class
