Public Class GameMenu
    Public gamemode As String
    Public asteroid As Asteroids
    Public asteroid_array As New List(Of Asteroids) 'array of asteroid objects

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
        For i = 0 To 7
            asteroid = New Asteroids("b", "NewB", "z")
        Next
    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        For i = 0 To asteroid_array.Count - 1
            If asteroid_array(i).onScreen = True Then
                e.Graphics.DrawPolygon(Pens.Black, asteroid_array(i).AsteroidPoints) 'if the asteroid is on screen then draw it
            End If
        Next
    End Sub

    Private Sub UpdateTick_Tick(sender As Object, e As EventArgs) Handles UpdateTick.Tick
        For i = 0 To 2
            asteroid_array(i).Update(i)
        Next
        Invalidate()
    End Sub
End Class