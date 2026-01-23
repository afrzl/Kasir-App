<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FR_TUKAR_POINT
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
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PNCONTENT = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LBPOINTTERSEDIA = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LBNAMAMEMBER = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBIDMEMBER = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BTNTUKAR = New System.Windows.Forms.Button()
        Me.BTNBATAL = New System.Windows.Forms.Button()
        Me.TXTPOINTDIGUNAKAN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTNAMABARANG = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PNTOP.SuspendLayout()
        Me.PNCONTROL.SuspendLayout()
        Me.PNCONTENT.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.Silver
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Controls.Add(Me.Label1)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(900, 50)
        Me.PNTOP.TabIndex = 0
        '
        'PNCONTROL
        '
        Me.PNCONTROL.Controls.Add(Me.BTNCLOSE)
        Me.PNCONTROL.Dock = System.Windows.Forms.DockStyle.Right
        Me.PNCONTROL.Location = New System.Drawing.Point(500, 0)
        Me.PNCONTROL.Name = "PNCONTROL"
        Me.PNCONTROL.Size = New System.Drawing.Size(50, 50)
        Me.PNCONTROL.TabIndex = 1
        '
        'BTNCLOSE
        '
        Me.BTNCLOSE.BackColor = System.Drawing.Color.Crimson
        Me.BTNCLOSE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BTNCLOSE.FlatAppearance.BorderSize = 0
        Me.BTNCLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNCLOSE.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCLOSE.ForeColor = System.Drawing.Color.White
        Me.BTNCLOSE.Location = New System.Drawing.Point(0, 0)
        Me.BTNCLOSE.Name = "BTNCLOSE"
        Me.BTNCLOSE.Size = New System.Drawing.Size(50, 50)
        Me.BTNCLOSE.TabIndex = 0
        Me.BTNCLOSE.Text = "X"
        Me.BTNCLOSE.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(450, 50)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TUKAR POINT MEMBER"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PNCONTENT
        '
        Me.PNCONTENT.BackColor = System.Drawing.Color.White
        Me.PNCONTENT.Controls.Add(Me.Panel1)
        Me.PNCONTENT.Controls.Add(Me.BTNTUKAR)
        Me.PNCONTENT.Controls.Add(Me.BTNBATAL)
        Me.PNCONTENT.Controls.Add(Me.TXTPOINTDIGUNAKAN)
        Me.PNCONTENT.Controls.Add(Me.Label6)
        Me.PNCONTENT.Controls.Add(Me.TXTNAMABARANG)
        Me.PNCONTENT.Controls.Add(Me.Label5)
        Me.PNCONTENT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNCONTENT.Location = New System.Drawing.Point(0, 50)
        Me.PNCONTENT.Name = "PNCONTENT"
        Me.PNCONTENT.Padding = New System.Windows.Forms.Padding(20)
        Me.PNCONTENT.Size = New System.Drawing.Size(900, 370)
        Me.PNCONTENT.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LBPOINTTERSEDIA)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LBNAMAMEMBER)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LBIDMEMBER)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(20, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(15)
        Me.Panel1.Size = New System.Drawing.Size(860, 150)
        Me.Panel1.TabIndex = 0
        '
        'LBPOINTTERSEDIA
        '
        Me.LBPOINTTERSEDIA.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBPOINTTERSEDIA.ForeColor = System.Drawing.Color.DarkGreen
        Me.LBPOINTTERSEDIA.Location = New System.Drawing.Point(530, 100)
        Me.LBPOINTTERSEDIA.Name = "LBPOINTTERSEDIA"
        Me.LBPOINTTERSEDIA.Size = New System.Drawing.Size(310, 30)
        Me.LBPOINTTERSEDIA.TabIndex = 5
        Me.LBPOINTTERSEDIA.Text = "0"
        Me.LBPOINTTERSEDIA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Point Tersedia :"
        '
        'LBNAMAMEMBER
        '
        Me.LBNAMAMEMBER.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBNAMAMEMBER.Location = New System.Drawing.Point(530, 55)
        Me.LBNAMAMEMBER.Name = "LBNAMAMEMBER"
        Me.LBNAMAMEMBER.Size = New System.Drawing.Size(310, 30)
        Me.LBNAMAMEMBER.TabIndex = 3
        Me.LBNAMAMEMBER.Text = "-"
        Me.LBNAMAMEMBER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nama Member :"
        '
        'LBIDMEMBER
        '
        Me.LBIDMEMBER.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBIDMEMBER.Location = New System.Drawing.Point(530, 10)
        Me.LBIDMEMBER.Name = "LBIDMEMBER"
        Me.LBIDMEMBER.Size = New System.Drawing.Size(310, 30)
        Me.LBIDMEMBER.TabIndex = 1
        Me.LBIDMEMBER.Text = "-"
        Me.LBIDMEMBER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "ID Member :"
        '
        'BTNTUKAR
        '
        Me.BTNTUKAR.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNTUKAR.FlatAppearance.BorderSize = 0
        Me.BTNTUKAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNTUKAR.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNTUKAR.ForeColor = System.Drawing.Color.White
        Me.BTNTUKAR.Location = New System.Drawing.Point(20, 350)
        Me.BTNTUKAR.Name = "BTNTUKAR"
        Me.BTNTUKAR.Size = New System.Drawing.Size(420, 45)
        Me.BTNTUKAR.TabIndex = 4
        Me.BTNTUKAR.Text = "TUKAR"
        Me.BTNTUKAR.UseVisualStyleBackColor = False
        '
        'BTNBATAL
        '
        Me.BTNBATAL.BackColor = System.Drawing.Color.Crimson
        Me.BTNBATAL.FlatAppearance.BorderSize = 0
        Me.BTNBATAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNBATAL.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBATAL.ForeColor = System.Drawing.Color.White
        Me.BTNBATAL.Location = New System.Drawing.Point(460, 350)
        Me.BTNBATAL.Name = "BTNBATAL"
        Me.BTNBATAL.Size = New System.Drawing.Size(420, 45)
        Me.BTNBATAL.TabIndex = 5
        Me.BTNBATAL.Text = "BATAL"
        Me.BTNBATAL.UseVisualStyleBackColor = False
        '
        'TXTPOINTDIGUNAKAN
        '
        Me.TXTPOINTDIGUNAKAN.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPOINTDIGUNAKAN.Location = New System.Drawing.Point(20, 310)
        Me.TXTPOINTDIGUNAKAN.Name = "TXTPOINTDIGUNAKAN"
        Me.TXTPOINTDIGUNAKAN.Size = New System.Drawing.Size(860, 31)
        Me.TXTPOINTDIGUNAKAN.TabIndex = 3
        Me.TXTPOINTDIGUNAKAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 285)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 20)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Point Digunakan *"
        '
        'TXTNAMABARANG
        '
        Me.TXTNAMABARANG.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAMABARANG.Location = New System.Drawing.Point(20, 220)
        Me.TXTNAMABARANG.MaxLength = 100
        Me.TXTNAMABARANG.Multiline = True
        Me.TXTNAMABARANG.Name = "TXTNAMABARANG"
        Me.TXTNAMABARANG.Size = New System.Drawing.Size(860, 55)
        Me.TXTNAMABARANG.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Nama Barang *"
        '
        'FR_TUKAR_POINT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(900, 470)
        Me.Controls.Add(Me.PNCONTENT)
        Me.Controls.Add(Me.PNTOP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FR_TUKAR_POINT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tukar Point Member"
        Me.PNTOP.ResumeLayout(False)
        Me.PNCONTROL.ResumeLayout(False)
        Me.PNCONTENT.ResumeLayout(False)
        Me.PNCONTENT.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PNTOP As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PNCONTENT As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LBIDMEMBER As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LBPOINTTERSEDIA As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LBNAMAMEMBER As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTNAMABARANG As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTPOINTDIGUNAKAN As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents BTNTUKAR As Button
    Friend WithEvents BTNBATAL As Button
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents BTNCLOSE As Button

End Class
