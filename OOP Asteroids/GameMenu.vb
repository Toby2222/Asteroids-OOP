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
End Class