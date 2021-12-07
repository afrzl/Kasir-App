<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FR_LOGIN
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTPASSWORD = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TXTID = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.AutoLabel1 = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.AutoLabel2 = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.BTNLOGIN = New Syncfusion.WinForms.Controls.SfButton()
        Me.PNTOP = New System.Windows.Forms.Panel()
        Me.PNCONTROL = New System.Windows.Forms.Panel()
        Me.BTNMINIMIZE = New System.Windows.Forms.Button()
        Me.BTNCLOSE = New System.Windows.Forms.Button()
        Me.IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        CType(Me.TXTPASSWORD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNTOP.SuspendLayout()
        Me.PNCONTROL.SuspendLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(138, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(254, 59)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Form Login"
        '
        'TXTPASSWORD
        '
        Me.TXTPASSWORD.BackColor = System.Drawing.Color.Transparent
        Me.TXTPASSWORD.BeforeTouchSize = New System.Drawing.Size(364, 43)
        Me.TXTPASSWORD.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPASSWORD.Location = New System.Drawing.Point(83, 481)
        Me.TXTPASSWORD.Name = "TXTPASSWORD"
        Me.TXTPASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.TXTPASSWORD.Size = New System.Drawing.Size(364, 43)
        Me.TXTPASSWORD.TabIndex = 2
        Me.TXTPASSWORD.UseSystemPasswordChar = True
        '
        'TXTID
        '
        Me.TXTID.BeforeTouchSize = New System.Drawing.Size(364, 43)
        Me.TXTID.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTID.Location = New System.Drawing.Point(83, 374)
        Me.TXTID.Name = "TXTID"
        Me.TXTID.Size = New System.Drawing.Size(364, 43)
        Me.TXTID.TabIndex = 1
        '
        'AutoLabel1
        '
        Me.AutoLabel1.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoLabel1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AutoLabel1.Location = New System.Drawing.Point(110, 339)
        Me.AutoLabel1.Name = "AutoLabel1"
        Me.AutoLabel1.Size = New System.Drawing.Size(76, 25)
        Me.AutoLabel1.TabIndex = 13
        Me.AutoLabel1.Text = "Id Akun"
        '
        'AutoLabel2
        '
        Me.AutoLabel2.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoLabel2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AutoLabel2.Location = New System.Drawing.Point(110, 446)
        Me.AutoLabel2.Name = "AutoLabel2"
        Me.AutoLabel2.Size = New System.Drawing.Size(91, 25)
        Me.AutoLabel2.TabIndex = 14
        Me.AutoLabel2.Text = "Password"
        '
        'BTNLOGIN
        '
        Me.BTNLOGIN.AccessibleName = "Button"
        Me.BTNLOGIN.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNLOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNLOGIN.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNLOGIN.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNLOGIN.Location = New System.Drawing.Point(83, 563)
        Me.BTNLOGIN.Name = "BTNLOGIN"
        Me.BTNLOGIN.Size = New System.Drawing.Size(364, 46)
        Me.BTNLOGIN.Style.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNLOGIN.Style.FocusedBackColor = System.Drawing.Color.DarkGreen
        Me.BTNLOGIN.Style.FocusedForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNLOGIN.Style.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNLOGIN.Style.HoverBackColor = System.Drawing.Color.DarkGreen
        Me.BTNLOGIN.Style.HoverForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNLOGIN.Style.PressedBackColor = System.Drawing.Color.DarkGreen
        Me.BTNLOGIN.Style.PressedForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNLOGIN.TabIndex = 3
        Me.BTNLOGIN.Text = "LOGIN"
        Me.BTNLOGIN.UseVisualStyleBackColor = False
        '
        'PNTOP
        '
        Me.PNTOP.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.PNTOP.Controls.Add(Me.PNCONTROL)
        Me.PNTOP.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNTOP.Location = New System.Drawing.Point(0, 0)
        Me.PNTOP.Name = "PNTOP"
        Me.PNTOP.Size = New System.Drawing.Size(531, 40)
        Me.PNTOP.TabIndex = 17
        '
        'PNCONTROL
        '
        Me.PNCONTROL.Controls.Add(Me.BTNMINIMIZE)
        Me.PNCONTROL.Controls.Add(Me.BTNCLOSE)
        Me.PNCONTROL.Dock = System.Windows.Forms.DockStyle.Right
        Me.PNCONTROL.Location = New System.Drawing.Point(455, 0)
        Me.PNCONTROL.Name = "PNCONTROL"
        Me.PNCONTROL.Size = New System.Drawing.Size(76, 40)
        Me.PNCONTROL.TabIndex = 0
        '
        'BTNMINIMIZE
        '
        Me.BTNMINIMIZE.FlatAppearance.BorderSize = 0
        Me.BTNMINIMIZE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNMINIMIZE.Image = Global.Aplikasi_Kasir.My.Resources.Resources.minimize15px
        Me.BTNMINIMIZE.Location = New System.Drawing.Point(11, 10)
        Me.BTNMINIMIZE.Name = "BTNMINIMIZE"
        Me.BTNMINIMIZE.Size = New System.Drawing.Size(18, 18)
        Me.BTNMINIMIZE.TabIndex = 2
        Me.BTNMINIMIZE.UseVisualStyleBackColor = True
        '
        'BTNCLOSE
        '
        Me.BTNCLOSE.FlatAppearance.BorderSize = 0
        Me.BTNCLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNCLOSE.Image = Global.Aplikasi_Kasir.My.Resources.Resources.close15px
        Me.BTNCLOSE.Location = New System.Drawing.Point(46, 10)
        Me.BTNCLOSE.Name = "BTNCLOSE"
        Me.BTNCLOSE.Size = New System.Drawing.Size(18, 18)
        Me.BTNCLOSE.TabIndex = 0
        Me.BTNCLOSE.UseVisualStyleBackColor = True
        '
        'IconPictureBox1
        '
        Me.IconPictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.User
        Me.IconPictureBox1.IconColor = System.Drawing.Color.White
        Me.IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Solid
        Me.IconPictureBox1.IconSize = 166
        Me.IconPictureBox1.Location = New System.Drawing.Point(182, 71)
        Me.IconPictureBox1.Name = "IconPictureBox1"
        Me.IconPictureBox1.Size = New System.Drawing.Size(166, 170)
        Me.IconPictureBox1.TabIndex = 16
        Me.IconPictureBox1.TabStop = False
        '
        'FR_LOGIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(531, 663)
        Me.Controls.Add(Me.PNTOP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.IconPictureBox1)
        Me.Controls.Add(Me.BTNLOGIN)
        Me.Controls.Add(Me.AutoLabel2)
        Me.Controls.Add(Me.AutoLabel1)
        Me.Controls.Add(Me.TXTID)
        Me.Controls.Add(Me.TXTPASSWORD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FR_LOGIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FR_LOGIN"
        CType(Me.TXTPASSWORD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNTOP.ResumeLayout(False)
        Me.PNCONTROL.ResumeLayout(False)
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TXTPASSWORD As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TXTID As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents AutoLabel1 As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents AutoLabel2 As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents BTNLOGIN As Syncfusion.WinForms.Controls.SfButton
    Friend WithEvents PNTOP As Panel
    Friend WithEvents PNCONTROL As Panel
    Friend WithEvents BTNMINIMIZE As Button
    Friend WithEvents BTNCLOSE As Button
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
End Class
