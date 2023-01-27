<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_TENTANG_BACKRESDB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_TENTANG_BACKRESDB))
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.TXTFILE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BTN_LOCATION = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTNSIMPAN = New System.Windows.Forms.Button()
        Me.CB_ACTION = New System.Windows.Forms.ComboBox()
        Me.LBID = New System.Windows.Forms.Label()
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PNCONTENT.SuspendLayout()
        Me.PNTOP.SuspendLayout()
        Me.PNCONTROL.SuspendLayout()
        Me.SuspendLayout()
        '
        'PNCONTENT
        '
        Me.PNCONTENT.Controls.Add(Me.TXTFILE)
        Me.PNCONTENT.Controls.Add(Me.Label2)
        Me.PNCONTENT.Controls.Add(Me.BTN_LOCATION)
        Me.PNCONTENT.Controls.Add(Me.Label1)
        Me.PNCONTENT.Controls.Add(Me.BTNSIMPAN)
        Me.PNCONTENT.Controls.Add(Me.CB_ACTION)
        Me.PNCONTENT.Controls.Add(Me.LBID)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(0, 40)
        Me.PNCONTENT.Margin = New System.Windows.Forms.Padding(2)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(616, 303)
        Me.PNCONTENT.TabIndex = 25
        '
        'TXTFILE
        '
        Me.TXTFILE.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFILE.Location = New System.Drawing.Point(182, 133)
        Me.TXTFILE.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTFILE.Multiline = True
        Me.TXTFILE.Name = "TXTFILE"
        Me.TXTFILE.Size = New System.Drawing.Size(245, 41)
        Me.TXTFILE.TabIndex = 71
        Me.TXTFILE.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 141)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 28)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "File DB"
        Me.Label2.Visible = False
        '
        'BTN_LOCATION
        '
        Me.BTN_LOCATION.BackColor = System.Drawing.Color.Navy
        Me.BTN_LOCATION.FlatAppearance.BorderSize = 0
        Me.BTN_LOCATION.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_LOCATION.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_LOCATION.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_LOCATION.Location = New System.Drawing.Point(422, 133)
        Me.BTN_LOCATION.Margin = New System.Windows.Forms.Padding(2)
        Me.BTN_LOCATION.Name = "BTN_LOCATION"
        Me.BTN_LOCATION.Size = New System.Drawing.Size(119, 41)
        Me.BTN_LOCATION.TabIndex = 65
        Me.BTN_LOCATION.Text = "Lokasi DB"
        Me.BTN_LOCATION.UseVisualStyleBackColor = False
        Me.BTN_LOCATION.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(579, 45)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "BACKUP DAN RESTORE DB"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTNSIMPAN
        '
        Me.BTNSIMPAN.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNSIMPAN.FlatAppearance.BorderSize = 0
        Me.BTNSIMPAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNSIMPAN.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSIMPAN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNSIMPAN.Location = New System.Drawing.Point(182, 198)
        Me.BTNSIMPAN.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNSIMPAN.Name = "BTNSIMPAN"
        Me.BTNSIMPAN.Size = New System.Drawing.Size(145, 50)
        Me.BTNSIMPAN.TabIndex = 8
        Me.BTNSIMPAN.Text = "SIMPAN"
        Me.BTNSIMPAN.UseVisualStyleBackColor = False
        '
        'CB_ACTION
        '
        Me.CB_ACTION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_ACTION.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_ACTION.FormattingEnabled = True
        Me.CB_ACTION.Items.AddRange(New Object() {"-- Silahkan Pilih Action --", "Backup", "Restore"})
        Me.CB_ACTION.Location = New System.Drawing.Point(182, 72)
        Me.CB_ACTION.Margin = New System.Windows.Forms.Padding(2)
        Me.CB_ACTION.Name = "CB_ACTION"
        Me.CB_ACTION.Size = New System.Drawing.Size(359, 43)
        Me.CB_ACTION.TabIndex = 5
        '
        'LBID
        '
        Me.LBID.AutoSize = True
        Me.LBID.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBID.Location = New System.Drawing.Point(11, 75)
        Me.LBID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LBID.Name = "LBID"
        Me.LBID.Size = New System.Drawing.Size(69, 28)
        Me.LBID.TabIndex = 43
        Me.LBID.Text = "Action"
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(616, 40)
        Me.PNTOP.TabIndex = 24
        '
        'PNCONTROL
        '
        Me.PNCONTROL.Controls.Add(Me.BTNCLOSE)
        Me.PNCONTROL.Dock = System.Windows.Forms.DockStyle.Right
        Me.PNCONTROL.Location = New System.Drawing.Point(569, 0)
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FR_TENTANG_BACKRESDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(616, 343)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNTOP)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FR_TENTANG_BACKRESDB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU SETTING"
        Me.PNCONTENT.ResumeLayout(False)
        Me.PNCONTENT.PerformLayout()
        Me.PNTOP.ResumeLayout(False)
        Me.PNCONTROL.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents BTNSIMPAN As Button
    Friend WithEvents CB_ACTION As ComboBox
    Friend WithEvents LBID As Label
    Friend WithEvents PNTOP As Panel
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents BTN_LOCATION As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTFILE As TextBox
End Class
