<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_KONEKSI
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTSERVER = New System.Windows.Forms.TextBox()
        Me.TXTUSER = New System.Windows.Forms.TextBox()
        Me.TXTDATABASE = New System.Windows.Forms.TextBox()
        Me.TXTPASSWORD = New System.Windows.Forms.TextBox()
        Me.BTNCONNECT = New System.Windows.Forms.Button()
        Me.BTNEXIT = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(56, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SERVER"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(56, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "USER"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(56, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 28)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "DATABASE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(56, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 28)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "PASSWORD"
        '
        'TXTSERVER
        '
        Me.TXTSERVER.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSERVER.Location = New System.Drawing.Point(236, 59)
        Me.TXTSERVER.Name = "TXTSERVER"
        Me.TXTSERVER.Size = New System.Drawing.Size(400, 31)
        Me.TXTSERVER.TabIndex = 4
        '
        'TXTUSER
        '
        Me.TXTUSER.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUSER.Location = New System.Drawing.Point(236, 102)
        Me.TXTUSER.Name = "TXTUSER"
        Me.TXTUSER.Size = New System.Drawing.Size(400, 31)
        Me.TXTUSER.TabIndex = 5
        '
        'TXTDATABASE
        '
        Me.TXTDATABASE.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDATABASE.Location = New System.Drawing.Point(236, 188)
        Me.TXTDATABASE.Name = "TXTDATABASE"
        Me.TXTDATABASE.Size = New System.Drawing.Size(400, 31)
        Me.TXTDATABASE.TabIndex = 7
        '
        'TXTPASSWORD
        '
        Me.TXTPASSWORD.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPASSWORD.Location = New System.Drawing.Point(236, 145)
        Me.TXTPASSWORD.Name = "TXTPASSWORD"
        Me.TXTPASSWORD.Size = New System.Drawing.Size(400, 31)
        Me.TXTPASSWORD.TabIndex = 6
        '
        'BTNCONNECT
        '
        Me.BTNCONNECT.BackColor = System.Drawing.Color.DarkGreen
        Me.BTNCONNECT.FlatAppearance.BorderSize = 0
        Me.BTNCONNECT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNCONNECT.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCONNECT.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNCONNECT.Location = New System.Drawing.Point(511, 254)
        Me.BTNCONNECT.Name = "BTNCONNECT"
        Me.BTNCONNECT.Size = New System.Drawing.Size(125, 35)
        Me.BTNCONNECT.TabIndex = 8
        Me.BTNCONNECT.Text = "CONNECT"
        Me.BTNCONNECT.UseVisualStyleBackColor = False
        '
        'BTNEXIT
        '
        Me.BTNEXIT.BackColor = System.Drawing.Color.Maroon
        Me.BTNEXIT.FlatAppearance.BorderSize = 0
        Me.BTNEXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNEXIT.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNEXIT.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BTNEXIT.Location = New System.Drawing.Point(236, 254)
        Me.BTNEXIT.Name = "BTNEXIT"
        Me.BTNEXIT.Size = New System.Drawing.Size(109, 35)
        Me.BTNEXIT.TabIndex = 9
        Me.BTNEXIT.Text = "EXIT"
        Me.BTNEXIT.UseVisualStyleBackColor = False
        '
        'FR_KONEKSI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(705, 356)
        Me.Controls.Add(Me.BTNEXIT)
        Me.Controls.Add(Me.BTNCONNECT)
        Me.Controls.Add(Me.TXTDATABASE)
        Me.Controls.Add(Me.TXTPASSWORD)
        Me.Controls.Add(Me.TXTUSER)
        Me.Controls.Add(Me.TXTSERVER)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FR_KONEKSI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KONEKSI DATABASE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTSERVER As TextBox
    Friend WithEvents TXTUSER As TextBox
    Friend WithEvents TXTDATABASE As TextBox
    Friend WithEvents TXTPASSWORD As TextBox
    Friend WithEvents BTNCONNECT As Button
    Friend WithEvents BTNEXIT As Button
End Class
