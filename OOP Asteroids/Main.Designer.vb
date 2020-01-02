<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Asteroids_Game
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ScoreBox = New System.Windows.Forms.Label()
        Me.HighscoreBox = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 15
        '
        'ScoreBox
        '
        Me.ScoreBox.AutoSize = True
        Me.ScoreBox.BackColor = System.Drawing.Color.Transparent
        Me.ScoreBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.ScoreBox.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ScoreBox.Location = New System.Drawing.Point(12, 9)
        Me.ScoreBox.Name = "ScoreBox"
        Me.ScoreBox.Size = New System.Drawing.Size(80, 24)
        Me.ScoreBox.TabIndex = 1
        Me.ScoreBox.Text = "Score: 0"
        '
        'HighscoreBox
        '
        Me.HighscoreBox.AutoSize = True
        Me.HighscoreBox.BackColor = System.Drawing.Color.Transparent
        Me.HighscoreBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.HighscoreBox.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.HighscoreBox.Location = New System.Drawing.Point(1549, 9)
        Me.HighscoreBox.Name = "HighscoreBox"
        Me.HighscoreBox.Size = New System.Drawing.Size(227, 24)
        Me.HighscoreBox.TabIndex = 3
        Me.HighscoreBox.Text = "Highscore: Example 9999"
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 45000
        '
        'TextBox9
        '
        Me.TextBox9.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.TextBox9.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox9.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBox9.Enabled = False
        Me.TextBox9.Location = New System.Drawing.Point(679, 185)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(206, 13)
        Me.TextBox9.TabIndex = 0
        Me.TextBox9.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(494, 230)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(176, 13)
        Me.TextBox1.TabIndex = 0
        '
        'Asteroids_Game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1816, 738)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.HighscoreBox)
        Me.Controls.Add(Me.ScoreBox)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1832, 777)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1832, 777)
        Me.Name = "Asteroids_Game"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asteroids"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents ScoreBox As Label
    Friend WithEvents HighscoreBox As Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox1 As TextBox
End Class
