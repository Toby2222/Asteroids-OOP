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
        Me.ScoreBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText
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
        Me.HighscoreBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.HighscoreBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.HighscoreBox.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.HighscoreBox.Location = New System.Drawing.Point(561, 9)
        Me.HighscoreBox.Name = "HighscoreBox"
        Me.HighscoreBox.Size = New System.Drawing.Size(227, 24)
        Me.HighscoreBox.TabIndex = 2
        Me.HighscoreBox.Text = "Highscore: Example 9999"
        '
        'Asteroids_Game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.HighscoreBox)
        Me.Controls.Add(Me.ScoreBox)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "Asteroids_Game"
        Me.Text = "Asteroids"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents ScoreBox As Label
    Friend WithEvents HighscoreBox As Label
End Class
