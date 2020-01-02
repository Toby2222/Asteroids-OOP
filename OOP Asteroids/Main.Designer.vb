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
        Me.Question = New System.Windows.Forms.Label()
        Me.Zero = New System.Windows.Forms.Label()
        Me.Playeranswer = New System.Windows.Forms.Label()
        Me.One = New System.Windows.Forms.Label()
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
        'Question
        '
        Me.Question.AutoSize = True
        Me.Question.BackColor = System.Drawing.Color.Transparent
        Me.Question.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.25!)
        Me.Question.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Question.Location = New System.Drawing.Point(9, 9)
        Me.Question.Name = "Question"
        Me.Question.Size = New System.Drawing.Size(292, 38)
        Me.Question.TabIndex = 4
        Me.Question.Text = "Template Quesiton"
        '
        'Zero
        '
        Me.Zero.AutoSize = True
        Me.Zero.BackColor = System.Drawing.Color.Transparent
        Me.Zero.Enabled = False
        Me.Zero.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.25!)
        Me.Zero.ForeColor = System.Drawing.Color.White
        Me.Zero.Location = New System.Drawing.Point(460, 244)
        Me.Zero.Name = "Zero"
        Me.Zero.Size = New System.Drawing.Size(32, 36)
        Me.Zero.TabIndex = 5
        Me.Zero.Text = "h"
        '
        'Playeranswer
        '
        Me.Playeranswer.AutoSize = True
        Me.Playeranswer.BackColor = System.Drawing.Color.Transparent
        Me.Playeranswer.Enabled = False
        Me.Playeranswer.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.25!)
        Me.Playeranswer.ForeColor = System.Drawing.Color.White
        Me.Playeranswer.Location = New System.Drawing.Point(1623, 9)
        Me.Playeranswer.Name = "Playeranswer"
        Me.Playeranswer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Playeranswer.Size = New System.Drawing.Size(0, 44)
        Me.Playeranswer.TabIndex = 6
        Me.Playeranswer.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'One
        '
        Me.One.AutoSize = True
        Me.One.BackColor = System.Drawing.Color.Transparent
        Me.One.Enabled = False
        Me.One.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.25!)
        Me.One.ForeColor = System.Drawing.Color.White
        Me.One.Location = New System.Drawing.Point(1265, 285)
        Me.One.Name = "One"
        Me.One.Size = New System.Drawing.Size(32, 36)
        Me.One.TabIndex = 7
        Me.One.Text = "h"
        '
        'Asteroids_Game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1816, 738)
        Me.Controls.Add(Me.One)
        Me.Controls.Add(Me.Playeranswer)
        Me.Controls.Add(Me.Zero)
        Me.Controls.Add(Me.Question)
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
    Friend WithEvents Question As Label
    Friend WithEvents Zero As Label
    Friend WithEvents Playeranswer As Label
    Friend WithEvents One As Label
End Class
