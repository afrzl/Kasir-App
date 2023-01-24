<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_KELUAR_CUSTOMER_KEMBALIAN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_KELUAR_CUSTOMER_KEMBALIAN))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LBL_TOKO = New System.Windows.Forms.Label()
        Me.LABEL_3 = New System.Windows.Forms.Label()
        Me.LBL_KEMBALIAN = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1034, 65)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TERIMAKASIH TELAH BERBELANJA DI"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LBL_TOKO
        '
        Me.LBL_TOKO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBL_TOKO.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_TOKO.Location = New System.Drawing.Point(12, 74)
        Me.LBL_TOKO.Name = "LBL_TOKO"
        Me.LBL_TOKO.Size = New System.Drawing.Size(1034, 65)
        Me.LBL_TOKO.TabIndex = 1
        Me.LBL_TOKO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LABEL_3
        '
        Me.LABEL_3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LABEL_3.Font = New System.Drawing.Font("Segoe UI Semibold", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LABEL_3.ForeColor = System.Drawing.Color.Crimson
        Me.LABEL_3.Location = New System.Drawing.Point(21, 162)
        Me.LABEL_3.Name = "LABEL_3"
        Me.LABEL_3.Size = New System.Drawing.Size(1025, 63)
        Me.LABEL_3.TabIndex = 2
        Me.LABEL_3.Text = "Silahkan pastikan lagi kembalian anda sebesar Rp"
        Me.LABEL_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LBL_KEMBALIAN
        '
        Me.LBL_KEMBALIAN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBL_KEMBALIAN.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_KEMBALIAN.ForeColor = System.Drawing.Color.Crimson
        Me.LBL_KEMBALIAN.Location = New System.Drawing.Point(12, 225)
        Me.LBL_KEMBALIAN.Name = "LBL_KEMBALIAN"
        Me.LBL_KEMBALIAN.Size = New System.Drawing.Size(1034, 54)
        Me.LBL_KEMBALIAN.TabIndex = 3
        Me.LBL_KEMBALIAN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FR_KELUAR_CUSTOMER_KEMBALIAN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 320)
        Me.Controls.Add(Me.LBL_KEMBALIAN)
        Me.Controls.Add(Me.LABEL_3)
        Me.Controls.Add(Me.LBL_TOKO)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FR_KELUAR_CUSTOMER_KEMBALIAN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CUSTOMER DISPLAY"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents LBL_TOKO As Label
    Friend WithEvents LABEL_3 As Label
    Friend WithEvents LBL_KEMBALIAN As Label
End Class
