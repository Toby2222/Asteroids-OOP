Public Class GameMenu
    Public gamemode As String
    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        If GamemodeBox.Text IsNot Nothing Then
            If GamemodeBox.Text = "Binary Conversions" Then
                gamemode = "bincon"
                Asteroids_Game.Show()
            ElseIf GamemodeBox.Text = "Binary Calculations" Then
                gamemode = "bincal"
                Asteroids_Game.Show()
            ElseIf GamemodeBox.Text = "Hexadecimal Conversions" Then
                gamemode = "hexcon"
                Asteroids_Game.Show()
            ElseIf GamemodeBox.Text = "Hexadecimal Calculations" Then
                gamemode = "hexcal"
                Asteroids_Game.Show()
            ElseIf GamemodeBox.Text = "Octal Conversions" Then
                gamemode = "octcon"
                Asteroids_Game.Show()
            ElseIf GamemodeBox.Text = "Octal Calculations" Then
                gamemode = "octcal"
                Asteroids_Game.Show()
            ElseIf GamemodeBox.Text = "Fun (Non-Educational)" Then
                gamemode = "fun"
                Asteroids_Game.Show()
            End If
        End If
    End Sub

    Private Sub GameMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Asteroids_Game.formheight = Me.Height
        Asteroids_Game.formwidth = Me.Width
        Asteroids_Game.speedFactor = 0.2
        For i = 0 To 0
            Asteroids_Game.asteroid = New Asteroids("b", "NewB", "z")
        Next
    End Sub
    Public Sub GameMenu_Reload()
        Asteroids_Game.formheight = Me.Height
        Asteroids_Game.formwidth = Me.Width
        Asteroids_Game.speedFactor = 0.2
        For i = 0 To 0
            Asteroids_Game.asteroid = New Asteroids("b", "NewB", "z")
        Next
    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias 'line of code to help make the graphics smooth
        For i = 0 To Asteroids_Game.asteroid_array.Count - 1
            If Asteroids_Game.asteroid_array(i).onScreen = True Then
                e.Graphics.DrawPolygon(Pens.Gray, Asteroids_Game.asteroid_array(i).AsteroidPoints) 'if the asteroid is on screen then draw it
            End If
        Next
    End Sub
    Private Sub UpdateTick_Tick(sender As Object, e As EventArgs) Handles UpdateTick.Tick
        For i = 0 To Asteroids_Game.asteroid_array.Count - 1
            Asteroids_Game.asteroid.Update(i)
        Next
        Invalidate()
    End Sub
End Class