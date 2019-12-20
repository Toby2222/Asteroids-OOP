Public Class Menu

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        If GamemodeBox.Text IsNot Nothing Then
            If GamemodeBox.Text = "Binary Conversions" Then

            ElseIf GamemodeBox.Text = "Binary Calculations" Then
                Asteroids_Game.Show()

            ElseIf GamemodeBox.Text = "Hexadecimal Conversions" Then
                Asteroids_Game.Show()

            ElseIf GamemodeBox.Text = "Hexadecimal Calculations" Then
                Asteroids_Game.Show()

            ElseIf GamemodeBox.Text = "Octal Conversions" Then
                Asteroids_Game.Show()

            ElseIf GamemodeBox.Text = "Octal Calculations" Then
                Asteroids_Game.Show()

            ElseIf GamemodeBox.Text = "Fun (Non-Educational)" Then
                Asteroids_Game.Show()
            End If
        End If
    End Sub
End Class