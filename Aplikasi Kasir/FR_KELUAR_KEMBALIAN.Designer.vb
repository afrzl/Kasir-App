<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_KELUAR_KEMBALIAN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_KELUAR_KEMBALIAN))
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.BTN_CETAKNOTA = New System.Windows.Forms.Button()
        Me.ID_TRANSAKSI = New System.Windows.Forms.Label()
        Me.BTNTUTUP = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LBKEMBALI = New System.Windows.Forms.Label()
        Me.PRINTNOTA = New System.Drawing.Printing.PrintDocument()
        Me.PNCONTENT.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PNCONTENT
        '
        Me.PNCONTENT.Controls.Add(Me.BTN_CETAKNOTA)
        Me.PNCONTENT.Controls.Add(Me.ID_TRANSAKSI)
        Me.PNCONTENT.Controls.Add(Me.BTNTUTUP)
        Me.PNCONTENT.Controls.Add(Me.GroupBox2)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(0, 0)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(923, 282)
        Me.PNCONTENT.TabIndex = 24
        '
        'BTN_CETAKNOTA
        '
        Me.BTN_CETAKNOTA.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_CETAKNOTA.BackColor = System.Drawing.Color.Crimson
        Me.BTN_CETAKNOTA.FlatAppearance.BorderSize = 0
        Me.BTN_CETAKNOTA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CETAKNOTA.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CETAKNOTA.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_CETAKNOTA.Location = New System.Drawing.Point(746, 166)
        Me.BTN_CETAKNOTA.Name = "BTN_CETAKNOTA"
        Me.BTN_CETAKNOTA.Size = New System.Drawing.Size(168, 45)
        Me.BTN_CETAKNOTA.TabIndex = 5
        Me.BTN_CETAKNOTA.Text = "Cetak Nota"
        Me.BTN_CETAKNOTA.UseVisualStyleBackColor = False
        '
        'ID_TRANSAKSI
        '
        Me.ID_TRANSAKSI.AutoSize = True
        Me.ID_TRANSAKSI.Location = New System.Drawing.Point(119, 194)
        Me.ID_TRANSAKSI.Name = "ID_TRANSAKSI"
        Me.ID_TRANSAKSI.Size = New System.Drawing.Size(51, 17)
        Me.ID_TRANSAKSI.TabIndex = 4
        Me.ID_TRANSAKSI.Text = "Label1"
        Me.ID_TRANSAKSI.Visible = False
        '
        'BTNTUTUP
        '
        Me.BTNTUTUP.BackColor = System.Drawing.Color.Navy
        Me.BTNTUTUP.FlatAppearance.BorderSize = 0
        Me.BTNTUTUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNTUTUP.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNTUTUP.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNTUTUP.Location = New System.Drawing.Point(322, 167)
        Me.BTNTUTUP.Name = "BTNTUTUP"
        Me.BTNTUTUP.Size = New System.Drawing.Size(273, 103)
        Me.BTNTUTUP.TabIndex = 3
        Me.BTNTUTUP.Text = "Tutup"
        Me.BTNTUTUP.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.LBKEMBALI)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Crimson
        Me.GroupBox2.Location = New System.Drawing.Point(3, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(917, 119)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Kembalian"
        '
        'LBKEMBALI
        '
        Me.LBKEMBALI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBKEMBALI.Font = New System.Drawing.Font("Microsoft Sans Serif", 49.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBKEMBALI.Location = New System.Drawing.Point(6, 24)
        Me.LBKEMBALI.Name = "LBKEMBALI"
        Me.LBKEMBALI.Size = New System.Drawing.Size(905, 110)
        Me.LBKEMBALI.TabIndex = 0
        Me.LBKEMBALI.Text = "0"
        Me.LBKEMBALI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PRINTNOTA
        '
        '
        'FR_KELUAR_KEMBALIAN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 282)
        Me.Controls.Add(Me.PNCONTENT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FR_KELUAR_KEMBALIAN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU BARANG KELUAR"
        Me.PNCONTENT.ResumeLayout(False)
        Me.PNCONTENT.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LBKEMBALI As Label
    Friend WithEvents BTNTUTUP As Button
    Friend WithEvents PRINTNOTA As Printing.PrintDocument
    Friend WithEvents ID_TRANSAKSI As Label
    Friend WithEvents BTN_CETAKNOTA As Button
End Class
