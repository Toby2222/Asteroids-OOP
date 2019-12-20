Public Class GameMenu
    Public gamemode As String
    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        If GamemodeBox.Text IsNot Nothing Then
            If GamemodeBox.Text = "Binary Conversions" Then
                Asteroids_Game.Show()
                gamemode = "bincon"
            ElseIf GamemodeBox.Text = "Binary Calculations" Then
                Asteroids_Game.Show()
                gamemode = "bincal"

            ElseIf GamemodeBox.Text = "Hexadecimal Conversions" Then
                Asteroids_Game.Show()
                gamemode = "hexcon"

            ElseIf GamemodeBox.Text = "Hexadecimal Calculations" Then
                Asteroids_Game.Show()
                gamemode = "hexcal"

            ElseIf GamemodeBox.Text = "Octal Conversions" Then
                Asteroids_Game.Show()
                gamemode = "octcon"

            ElseIf GamemodeBox.Text = "Octal Calculations" Then
                Asteroids_Game.Show()
                gamemode = "octcal"

            ElseIf GamemodeBox.Text = "Fun (Non-Educational)" Then
                Asteroids_Game.Show()
                gamemode = "fun"

            End If
        End If
    End Sub
End Class