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
        Me.Tick = New System.Windows.Forms.Timer(Me.components)
        Me.ScoreBox = New System.Windows.Forms.Label()
        Me.LevelTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Question = New System.Windows.Forms.Label()
        Me.Zero2 = New System.Windows.Forms.Label()
        Me.Playeranswer = New System.Windows.Forms.Label()
        Me.One2 = New System.Windows.Forms.Label()
        Me.One1 = New System.Windows.Forms.Label()
        Me.Zero1 = New System.Windows.Forms.Label()
        Me.Countdown = New System.Windows.Forms.Timer(Me.components)
        Me.Timer = New System.Windows.Forms.Label()
        Me.livesbox = New System.Windows.Forms.Label()
        Me.Levelbox = New System.Windows.Forms.Label()
        Me.GameoverBox = New System.Windows.Forms.Label()
        Me.FinalScoreBox = New System.Windows.Forms.Label()
        Me.FinalInstructionBox = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Tick
        '
        Me.Tick.Enabled = True
        Me.Tick.Interval = 15
        '
        'ScoreBox
        '
        Me.ScoreBox.AutoSize = True
        Me.ScoreBox.BackColor = System.Drawing.Color.Transparent
        Me.ScoreBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.25!)
        Me.ScoreBox.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ScoreBox.Location = New System.Drawing.Point(12, 9)
        Me.ScoreBox.Name = "ScoreBox"
        Me.ScoreBox.Size = New System.Drawing.Size(139, 38)
        Me.ScoreBox.TabIndex = 1
        Me.ScoreBox.Text = "Score: 0"
        '
        'LevelTimer
        '
        Me.LevelTimer.Enabled = True
        Me.LevelTimer.Interval = 45000
        '
        'Question
        '
        Me.Question.AutoSize = True
        Me.Question.BackColor = System.Drawing.Color.Transparent
        Me.Question.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.25!)
        Me.Question.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Question.Location = New System.Drawing.Point(12, 9)
        Me.Question.Name = "Question"
        Me.Question.Size = New System.Drawing.Size(292, 38)
        Me.Question.TabIndex = 1
        Me.Question.Text = "Template Quesiton"
        '
        'Zero2
        '
        Me.Zero2.AutoSize = True
        Me.Zero2.BackColor = System.Drawing.Color.Transparent
        Me.Zero2.Enabled = False
        Me.Zero2.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.25!)
        Me.Zero2.ForeColor = System.Drawing.Color.White
        Me.Zero2.Location = New System.Drawing.Point(460, 244)
        Me.Zero2.Name = "Zero2"
        Me.Zero2.Size = New System.Drawing.Size(32, 36)
        Me.Zero2.TabIndex = 5
        Me.Zero2.Text = "h"
        '
        'Playeranswer
        '
        Me.Playeranswer.AutoSize = True
        Me.Playeranswer.BackColor = System.Drawing.Color.Transparent
        Me.Playeranswer.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.25!)
        Me.Playeranswer.ForeColor = System.Drawing.Color.Red
        Me.Playeranswer.Location = New System.Drawing.Point(19, 56)
        Me.Playeranswer.Name = "Playeranswer"
        Me.Playeranswer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Playeranswer.Size = New System.Drawing.Size(0, 44)
        Me.Playeranswer.TabIndex = 6
        '
        'One2
        '
        Me.One2.AutoSize = True
        Me.One2.BackColor = System.Drawing.Color.Transparent
        Me.One2.Enabled = False
        Me.One2.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.25!)
        Me.One2.ForeColor = System.Drawing.Color.White
        Me.One2.Location = New System.Drawing.Point(1265, 285)
        Me.One2.Name = "One2"
        Me.One2.Size = New System.Drawing.Size(32, 36)
        Me.One2.TabIndex = 7
        Me.One2.Text = "h"
        '
        'One1
        '
        Me.One1.AutoSize = True
        Me.One1.BackColor = System.Drawing.Color.Transparent
        Me.One1.Enabled = False
        Me.One1.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.25!)
        Me.One1.ForeColor = System.Drawing.Color.White
        Me.One1.Location = New System.Drawing.Point(892, 351)
        Me.One1.Name = "One1"
        Me.One1.Size = New System.Drawing.Size(32, 36)
        Me.One1.TabIndex = 8
        Me.One1.Text = "h"
        '
        'Zero1
        '
        Me.Zero1.AutoSize = True
        Me.Zero1.BackColor = System.Drawing.Color.Transparent
        Me.Zero1.Enabled = False
        Me.Zero1.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.25!)
        Me.Zero1.ForeColor = System.Drawing.Color.White
        Me.Zero1.Location = New System.Drawing.Point(1029, 388)
        Me.Zero1.Name = "Zero1"
        Me.Zero1.Size = New System.Drawing.Size(32, 36)
        Me.Zero1.TabIndex = 9
        Me.Zero1.Text = "h"
        '
        'Countdown
        '
        Me.Countdown.Enabled = True
        Me.Countdown.Interval = 1000
        '
        'Timer
        '
        Me.Timer.AutoSize = True
        Me.Timer.BackColor = System.Drawing.Color.Transparent
        Me.Timer.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.25!)
        Me.Timer.ForeColor = System.Drawing.Color.MediumBlue
        Me.Timer.Location = New System.Drawing.Point(1435, 9)
        Me.Timer.Name = "Timer"
        Me.Timer.Size = New System.Drawing.Size(41, 44)
        Me.Timer.TabIndex = 10
        Me.Timer.Text = "h"
        '
        'livesbox
        '
        Me.livesbox.AutoSize = True
        Me.livesbox.BackColor = System.Drawing.Color.Transparent
        Me.livesbox.Enabled = False
        Me.livesbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.25!)
        Me.livesbox.ForeColor = System.Drawing.Color.White
        Me.livesbox.Location = New System.Drawing.Point(1494, 17)
        Me.livesbox.Name = "livesbox"
        Me.livesbox.Size = New System.Drawing.Size(32, 36)
        Me.livesbox.TabIndex = 11
        Me.livesbox.Text = "h"
        '
        'Levelbox
        '
        Me.Levelbox.AutoSize = True
        Me.Levelbox.BackColor = System.Drawing.Color.Transparent
        Me.Levelbox.Enabled = False
        Me.Levelbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.25!)
        Me.Levelbox.ForeColor = System.Drawing.Color.White
        Me.Levelbox.Location = New System.Drawing.Point(1243, 16)
        Me.Levelbox.Name = "Levelbox"
        Me.Levelbox.Size = New System.Drawing.Size(32, 36)
        Me.Levelbox.TabIndex = 12
        Me.Levelbox.Text = "h"
        '
        'GameoverBox
        '
        Me.GameoverBox.AutoSize = True
        Me.GameoverBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GameoverBox.ForeColor = System.Drawing.Color.Red
        Me.GameoverBox.Location = New System.Drawing.Point(689, 266)
        Me.GameoverBox.Name = "GameoverBox"
        Me.GameoverBox.Size = New System.Drawing.Size(249, 55)
        Me.GameoverBox.TabIndex = 13
        Me.GameoverBox.Text = "Gameover"
        '
        'FinalScoreBox
        '
        Me.FinalScoreBox.AutoSize = True
        Me.FinalScoreBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FinalScoreBox.ForeColor = System.Drawing.Color.Blue
        Me.FinalScoreBox.Location = New System.Drawing.Point(720, 327)
        Me.FinalScoreBox.Name = "FinalScoreBox"
        Me.FinalScoreBox.Size = New System.Drawing.Size(107, 33)
        Me.FinalScoreBox.TabIndex = 14
        Me.FinalScoreBox.Text = "Score: "
        '
        'FinalInstructionBox
        '
        Me.FinalInstructionBox.AutoSize = True
        Me.FinalInstructionBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FinalInstructionBox.ForeColor = System.Drawing.Color.White
        Me.FinalInstructionBox.Location = New System.Drawing.Point(625, 387)
        Me.FinalInstructionBox.Name = "FinalInstructionBox"
        Me.FinalInstructionBox.Size = New System.Drawing.Size(376, 33)
        Me.FinalInstructionBox.TabIndex = 15
        Me.FinalInstructionBox.Text = "Press Esc to return to menu"
        '
        'Asteroids_Game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1626, 687)
        Me.Controls.Add(Me.FinalInstructionBox)
        Me.Controls.Add(Me.FinalScoreBox)
        Me.Controls.Add(Me.GameoverBox)
        Me.Controls.Add(Me.Levelbox)
        Me.Controls.Add(Me.livesbox)
        Me.Controls.Add(Me.Timer)
        Me.Controls.Add(Me.Zero1)
        Me.Controls.Add(Me.One1)
        Me.Controls.Add(Me.One2)
        Me.Controls.Add(Me.Playeranswer)
        Me.Controls.Add(Me.Zero2)
        Me.Controls.Add(Me.Question)
        Me.Controls.Add(Me.ScoreBox)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1642, 726)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1642, 726)
        Me.Name = "Asteroids_Game"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asteroids"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Tick As Timer
    Friend WithEvents ScoreBox As Label
    Friend WithEvents LevelTimer As Timer
    Friend WithEvents Question As Label
    Friend WithEvents Zero2 As Label
    Friend WithEvents Playeranswer As Label
    Friend WithEvents One2 As Label
    Friend WithEvents One1 As Label
    Friend WithEvents Zero1 As Label
    Friend WithEvents Countdown As Timer
    Friend WithEvents Timer As Label
    Friend WithEvents livesbox As Label
    Friend WithEvents Levelbox As Label
    Friend WithEvents GameoverBox As Label
    Friend WithEvents FinalScoreBox As Label
    Friend WithEvents FinalInstructionBox As Label
End Class
