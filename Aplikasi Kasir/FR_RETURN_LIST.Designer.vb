<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_RETURN_LIST
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_RETURN_LIST))
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.DGCARI = New System.Windows.Forms.DataGridView()
        Me.TXTCARI_TRANS = New System.Windows.Forms.TextBox()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.LB_TITLE = New System.Windows.Forms.Label()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.PNCONTENT.SuspendLayout()
        CType(Me.DGCARI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNCONTROL.SuspendLayout()
        Me.PNTOP.SuspendLayout()
        Me.SuspendLayout()
        '
        'PNCONTENT
        '
        Me.PNCONTENT.Controls.Add(Me.DGCARI)
        Me.PNCONTENT.Controls.Add(Me.TXTCARI_TRANS)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(0, 40)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Size = New System.Drawing.Size(1230, 642)
        Me.PNCONTENT.TabIndex = 24
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
        Me.DGCARI.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGCARI.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGCARI.ColumnHeadersHeight = 35
        Me.DGCARI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGCARI.EnableHeadersVisualStyles = False
        Me.DGCARI.Location = New System.Drawing.Point(17, 59)
        Me.DGCARI.Margin = New System.Windows.Forms.Padding(2)
        Me.DGCARI.MultiSelect = False
        Me.DGCARI.Name = "DGCARI"
        Me.DGCARI.ReadOnly = True
        Me.DGCARI.RowHeadersVisible = False
        Me.DGCARI.RowHeadersWidth = 51
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGCARI.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DGCARI.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGCARI.RowTemplate.Height = 30
        Me.DGCARI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCARI.Size = New System.Drawing.Size(1199, 572)
        Me.DGCARI.TabIndex = 25
        '
        'TXTCARI_TRANS
        '
        Me.TXTCARI_TRANS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXTCARI_TRANS.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCARI_TRANS.Location = New System.Drawing.Point(15, 14)
        Me.TXTCARI_TRANS.Margin = New System.Windows.Forms.Padding(2)
        Me.TXTCARI_TRANS.Name = "TXTCARI_TRANS"
        Me.TXTCARI_TRANS.Size = New System.Drawing.Size(1201, 41)
        Me.TXTCARI_TRANS.TabIndex = 24
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
        'LB_TITLE
        '
        Me.LB_TITLE.AutoSize = True
        Me.LB_TITLE.Location = New System.Drawing.Point(12, 10)
        Me.LB_TITLE.Name = "LB_TITLE"
        Me.LB_TITLE.Size = New System.Drawing.Size(84, 28)
        Me.LB_TITLE.TabIndex = 68
        Me.LB_TITLE.Text = "LB_TITLE"
        Me.LB_TITLE.Visible = False
        '
        'PNCONTROL
        '
        Me.PNCONTROL.Controls.Add(Me.BTNCLOSE)
        Me.PNCONTROL.Dock = System.Windows.Forms.DockStyle.Right
        Me.PNCONTROL.Location = New System.Drawing.Point(1183, 0)
        Me.PNCONTROL.Name = "PNCONTROL"
        Me.PNCONTROL.Size = New System.Drawing.Size(47, 40)
        Me.PNCONTROL.TabIndex = 0
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.LB_TITLE)
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(1230, 40)
        Me.PNTOP.TabIndex = 23
        '
        'FR_RETURN_LIST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1230, 682)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNTOP)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FR_RETURN_LIST"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU BARANG RETURN"
        Me.PNCONTENT.ResumeLayout(False)
        Me.PNCONTENT.PerformLayout()
        CType(Me.DGCARI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNCONTROL.ResumeLayout(False)
        Me.PNTOP.ResumeLayout(False)
        Me.PNTOP.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents LB_TITLE As Label
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents PNTOP As Panel
    Friend WithEvents DGCARI As DataGridView
    Friend WithEvents TXTCARI_TRANS As TextBox
End Class
