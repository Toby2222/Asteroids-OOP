﻿Public Class Bullets
    'variables needed for all bullets
    Public fired As Boolean 'boolean to say wether the bullets has been shot yet
    Public inForm As Boolean  'boolean to say wether the bullet is within the form
    Public BFx As Integer 'x coordinate of the front of the bullet
    Public BFy As Integer 'y coordinate of the front of the bullet
    Public BBx As Integer 'x coordinate of the back of the bullet
    Public BBy As Integer 'y coordinate of the back of the bullet
    Public bSpeed As Integer 'integer for the speed of the bullets
    Public bLength As Integer 'integer to define the length of the bullets
    Public bAngle As Double 'double for the angle of the bullet

    Public Sub New(currentAngle, frontx, fronty)
        fired = False
        inForm = True
        bLength = 2
        bSpeed = 10
        BFx = frontx
        BFy = fronty
        BBx = BFx + ((Math.Cos(Asteroids_Game.mySpaceship.SOa)) * bLength)
        BBy = BFy + ((Math.Cos(Asteroids_Game.mySpaceship.SOa)) * bLength)
        bAngle = currentAngle
        Asteroids_Game.bullet_array.Add(Me)
    End Sub
    Public Sub update()
        For i = 0 To Asteroids_Game.bullet_array.Count - 1
            If Asteroids_Game.bullet_array(i).inForm = True Then
                Asteroids_Game.bullet_array(i).BBx = Asteroids_Game.bullet_array(i).BFx + ((Math.Sin(Asteroids_Game.bullet_array(i).bAngle)) * bLength)
                Asteroids_Game.bullet_array(i).BBy = Asteroids_Game.bullet_array(i).BFy + ((Math.Cos(Asteroids_Game.bullet_array(i).bAngle)) * bLength)
                Asteroids_Game.bullet_array(i).BFx = Asteroids_Game.bullet_array(i).BFx + ((Math.Cos(Asteroids_Game.bullet_array(i).bAngle)) * (bSpeed + Asteroids_Game.mySpaceship.SOsd))
                Asteroids_Game.bullet_array(i).BFy = Asteroids_Game.bullet_array(i).BFy + ((Math.Sin(Asteroids_Game.bullet_array(i).bAngle)) * (bSpeed + Asteroids_Game.mySpaceship.SOsd))
                If Asteroids_Game.bullet_array(i).BFx >= Asteroids_Game.formwidth Or Asteroids_Game.bullet_array(i).BFx < 0 Then
                    Asteroids_Game.bullet_array(i).inForm = False
                End If
                If Asteroids_Game.bullet_array(i).BFy >= Asteroids_Game.formheight Or Asteroids_Game.bullet_array(i).BFy < 0 Then
                    Asteroids_Game.bullet_array(i).inForm = False
                End If
            Else
                Asteroids_Game.bullet_array(i).BFx = -1
                Asteroids_Game.bullet_array(i).BFy = -1
                Asteroids_Game.bullet_array(i).BBx = -1
                Asteroids_Game.bullet_array(i).BBy = -1
            End If
        Next
    End Sub
End Class