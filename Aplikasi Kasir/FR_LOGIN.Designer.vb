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
        Me.BTNEXIT = New Syncfusion.WinForms.Controls.SfButton()
        Me.TXTID = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.AutoLabel1 = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.AutoLabel2 = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.BTNLOGIN = New Syncfusion.WinForms.Controls.SfButton()
        Me.IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        CType(Me.TXTPASSWORD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(227, 387)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(254, 59)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Form Login"
        '
        'TXTPASSWORD
        '
        Me.TXTPASSWORD.BackColor = System.Drawing.Color.Transparent
        Me.TXTPASSWORD.BeforeTouchSize = New System.Drawing.Size(440, 43)
        Me.TXTPASSWORD.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPASSWORD.Location = New System.Drawing.Point(138, 630)
        Me.TXTPASSWORD.Name = "TXTPASSWORD"
        Me.TXTPASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.TXTPASSWORD.Size = New System.Drawing.Size(440, 43)
        Me.TXTPASSWORD.TabIndex = 2
        Me.TXTPASSWORD.UseSystemPasswordChar = True
        '
        'BTNEXIT
        '
        Me.BTNEXIT.AccessibleName = "Button"
        Me.BTNEXIT.BackColor = System.Drawing.Color.Crimson
        Me.BTNEXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNEXIT.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNEXIT.ForeColor = System.Drawing.Color.White
        Me.BTNEXIT.Location = New System.Drawing.Point(619, 12)
        Me.BTNEXIT.Name = "BTNEXIT"
        Me.BTNEXIT.Size = New System.Drawing.Size(70, 70)
        Me.BTNEXIT.Style.BackColor = System.Drawing.Color.Crimson
        Me.BTNEXIT.Style.FocusedBackColor = System.Drawing.Color.Crimson
        Me.BTNEXIT.Style.ForeColor = System.Drawing.Color.White
        Me.BTNEXIT.TabIndex = 4
        Me.BTNEXIT.Text = "X"
        Me.BTNEXIT.UseVisualStyleBackColor = False
        '
        'TXTID
        '
        Me.TXTID.BeforeTouchSize = New System.Drawing.Size(440, 43)
        Me.TXTID.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTID.Location = New System.Drawing.Point(138, 523)
        Me.TXTID.Name = "TXTID"
        Me.TXTID.Size = New System.Drawing.Size(440, 43)
        Me.TXTID.TabIndex = 1
        '
        'AutoLabel1
        '
        Me.AutoLabel1.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoLabel1.Location = New System.Drawing.Point(148, 491)
        Me.AutoLabel1.Name = "AutoLabel1"
        Me.AutoLabel1.Size = New System.Drawing.Size(76, 25)
        Me.AutoLabel1.TabIndex = 13
        Me.AutoLabel1.Text = "Id Akun"
        '
        'AutoLabel2
        '
        Me.AutoLabel2.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoLabel2.Location = New System.Drawing.Point(148, 598)
        Me.AutoLabel2.Name = "AutoLabel2"
        Me.AutoLabel2.Size = New System.Drawing.Size(91, 25)
        Me.AutoLabel2.TabIndex = 14
        Me.AutoLabel2.Text = "Password"
        '
        'BTNLOGIN
        '
        Me.BTNLOGIN.AccessibleName = "Button"
        Me.BTNLOGIN.BackColor = System.Drawing.Color.Green
        Me.BTNLOGIN.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNLOGIN.ForeColor = System.Drawing.Color.Black
        Me.BTNLOGIN.Location = New System.Drawing.Point(138, 732)
        Me.BTNLOGIN.Name = "BTNLOGIN"
        Me.BTNLOGIN.Size = New System.Drawing.Size(440, 46)
        Me.BTNLOGIN.Style.BackColor = System.Drawing.Color.Green
        Me.BTNLOGIN.Style.FocusedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BTNLOGIN.Style.ForeColor = System.Drawing.Color.Black
        Me.BTNLOGIN.TabIndex = 3
        Me.BTNLOGIN.Text = "LOGIN"
        Me.BTNLOGIN.UseVisualStyleBackColor = False
        '
        'IconPictureBox1
        '
        Me.IconPictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.User
        Me.IconPictureBox1.IconColor = System.Drawing.Color.White
        Me.IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Solid
        Me.IconPictureBox1.IconSize = 293
        Me.IconPictureBox1.Location = New System.Drawing.Point(212, 121)
        Me.IconPictureBox1.Name = "IconPictureBox1"
        Me.IconPictureBox1.Size = New System.Drawing.Size(293, 340)
        Me.IconPictureBox1.TabIndex = 16
        Me.IconPictureBox1.TabStop = False
        '
        'FR_LOGIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(701, 836)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.IconPictureBox1)
        Me.Controls.Add(Me.BTNLOGIN)
        Me.Controls.Add(Me.AutoLabel2)
        Me.Controls.Add(Me.AutoLabel1)
        Me.Controls.Add(Me.TXTID)
        Me.Controls.Add(Me.BTNEXIT)
        Me.Controls.Add(Me.TXTPASSWORD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FR_LOGIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FR_LOGIN"
        CType(Me.TXTPASSWORD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TXTPASSWORD As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents BTNEXIT As Syncfusion.WinForms.Controls.SfButton
    Friend WithEvents TXTID As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents AutoLabel1 As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents AutoLabel2 As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents BTNLOGIN As Syncfusion.WinForms.Controls.SfButton
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
End Class
