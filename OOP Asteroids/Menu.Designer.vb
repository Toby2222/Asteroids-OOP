<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GamemodeBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 45.25!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(85, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(385, 72)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ASTEROIDS"
        '
        'GamemodeBox
        '
        Me.GamemodeBox.AllowDrop = True
        Me.GamemodeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GamemodeBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.25!)
        Me.GamemodeBox.FormattingEnabled = True
        Me.GamemodeBox.Items.AddRange(New Object() {"Binary Conversions", "Binary Calculations", "Hexadecimal Conversions", "Hexadecimal Calculations", "Octal Conversions", "Octal Calculations", "Fun (Non-Educational)"})
        Me.GamemodeBox.Location = New System.Drawing.Point(129, 169)
        Me.GamemodeBox.Name = "GamemodeBox"
        Me.GamemodeBox.Size = New System.Drawing.Size(296, 30)
        Me.GamemodeBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.25!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(224, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Gamemode:"
        '
        'PlayButton
        '
        Me.PlayButton.BackColor = System.Drawing.Color.Red
        Me.PlayButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PlayButton.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PlayButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.PlayButton.ForeColor = System.Drawing.Color.Blue
        Me.PlayButton.Location = New System.Drawing.Point(194, 254)
        Me.PlayButton.Margin = New System.Windows.Forms.Padding(0)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(166, 42)
        Me.PlayButton.TabIndex = 3
        Me.PlayButton.Text = "Press to Play"
        Me.PlayButton.UseVisualStyleBackColor = False
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(555, 355)
        Me.Controls.Add(Me.PlayButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GamemodeBox)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Menu"
        Me.Text = "Asteroids Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GamemodeBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PlayButton As Button
End Class
