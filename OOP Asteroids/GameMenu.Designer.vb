<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GameMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameMenu))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GamemodeBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.EducationalInstructions = New System.Windows.Forms.TextBox()
        Me.NonEducational = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 45.25!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(343, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(385, 72)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ASTEROIDS"
        '
        'GamemodeBox
        '
        Me.GamemodeBox.AllowDrop = True
        Me.GamemodeBox.BackColor = System.Drawing.Color.White
        Me.GamemodeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GamemodeBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.25!)
        Me.GamemodeBox.FormattingEnabled = True
        Me.GamemodeBox.Items.AddRange(New Object() {"Binary Conversions", "Binary Calculations", "Hexadecimal Conversions", "Hexadecimal Calculations", "Octal Conversions", "Octal Calculations", "Fun (Non-Educational)"})
        Me.GamemodeBox.Location = New System.Drawing.Point(387, 169)
        Me.GamemodeBox.Name = "GamemodeBox"
        Me.GamemodeBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GamemodeBox.Size = New System.Drawing.Size(296, 30)
        Me.GamemodeBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.25!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(482, 144)
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
        Me.PlayButton.Location = New System.Drawing.Point(452, 254)
        Me.PlayButton.Margin = New System.Windows.Forms.Padding(0)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(166, 42)
        Me.PlayButton.TabIndex = 3
        Me.PlayButton.Text = "Press to Play"
        Me.PlayButton.UseVisualStyleBackColor = False
        '
        'EducationalInstructions
        '
        Me.EducationalInstructions.BackColor = System.Drawing.Color.Black
        Me.EducationalInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.EducationalInstructions.Cursor = System.Windows.Forms.Cursors.Default
        Me.EducationalInstructions.Enabled = False
        Me.EducationalInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.EducationalInstructions.ForeColor = System.Drawing.Color.White
        Me.EducationalInstructions.Location = New System.Drawing.Point(5, 216)
        Me.EducationalInstructions.Multiline = True
        Me.EducationalInstructions.Name = "EducationalInstructions"
        Me.EducationalInstructions.ReadOnly = True
        Me.EducationalInstructions.Size = New System.Drawing.Size(434, 124)
        Me.EducationalInstructions.TabIndex = 5
        Me.EducationalInstructions.Text = resources.GetString("EducationalInstructions.Text")
        '
        'NonEducational
        '
        Me.NonEducational.BackColor = System.Drawing.Color.Black
        Me.NonEducational.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.NonEducational.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.NonEducational.Enabled = False
        Me.NonEducational.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.NonEducational.ForeColor = System.Drawing.Color.White
        Me.NonEducational.Location = New System.Drawing.Point(675, 224)
        Me.NonEducational.Multiline = True
        Me.NonEducational.Name = "NonEducational"
        Me.NonEducational.ReadOnly = True
        Me.NonEducational.Size = New System.Drawing.Size(361, 101)
        Me.NonEducational.TabIndex = 6
        Me.NonEducational.Text = "     - Big asteroid = 10 points" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     - Small asteroid = 25 points" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     - Three " &
    "lives" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     - Level up when screen is clear or after two minutes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     - The hig" &
    "her the level, the more asteroids"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(699, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(172, 24)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Non-Educational:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Educational:"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Black
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(5, 34)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(205, 75)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Text = "- Arrow keys to turn and move" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Space key to shoot" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- 'P' key to pause" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- 'U' ke" &
    "y to unpause"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(8, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 24)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Controls:"
        '
        'GameMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1070, 355)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NonEducational)
        Me.Controls.Add(Me.EducationalInstructions)
        Me.Controls.Add(Me.PlayButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GamemodeBox)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1086, 394)
        Me.MinimumSize = New System.Drawing.Size(1086, 394)
        Me.Name = "GameMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asteroids Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GamemodeBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PlayButton As Button
    Friend WithEvents EducationalInstructions As TextBox
    Friend WithEvents NonEducational As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label5 As Label
End Class
