﻿Public Class Asteroids
    'Variables needed for all asteroids
    Public onScreen As Boolean 'boolean for wether the asteroid is on the screen
    Public alive As Boolean 'booleon for wether alove or not
    Public aAngle As Double 'double for the angle asteroids
    Public aSpeed As Integer 'integer for the speed of the asteroids
    Public xPoints() As Integer  'array for all the xcoordiantes for the points in the asteroid
    Public yPoints() As Integer  'array for all the y coordinates for the points in the asteroid
    Public AsteroidPoints() As Point
    Public startX As Integer 'starting x coordinate
    Public startY As Integer 'starting y coordinate
    Public numberOfPoints As Integer 'integer for number of points in the asteroid
    Public FixedAngles(7) As Double

    Public Sub New()
        onScreen = 1
        alive = 1
        aSpeed = Rnd() * (3) + 1
        numberOfPoints = Int(Rnd() * (4)) + 5
        For i = 1 To numberOfPoints
            FixedAngles(i - 1) = Rnd(i * (2 * Math.PI) / numberOfPoints) + (i - 1) * (2 * Math.PI) / numberOfPoints
        Next
        ReDim xPoints(numberOfPoints - 1)
        ReDim yPoints(numberOfPoints - 1)
        ReDim AsteroidPoints(numberOfPoints - 1)
        Asteroids_Game.asteroid_array.Add(Me)
        Asteroids_Game.AsteroidAngle(Asteroids_Game.asteroid_array.Count - 1)
        For i = 0 To (numberOfPoints) - 1
            Dim rand As Integer = (Rnd() * 45) + 35
            xPoints(i) = startX + ((Math.Cos(FixedAngles(i))) * (rand))
            yPoints(i) = startY + ((Math.Sin(FixedAngles(i))) * (rand))
            Dim OnePoint As New Point(xPoints(i), yPoints(i))
            AsteroidPoints(i) = (OnePoint)
        Next
    End Sub
    Public Sub Update()
        For i = 0 To Asteroids_Game.numberOfAsteroids - 1
            Asteroids_Game.asteroid_array(i).startX += ((Math.Cos(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
            Asteroids_Game.asteroid_array(i).startY += ((Math.Sin(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
            For j = 0 To Asteroids_Game.asteroid_array(i).numberOfPoints - 1
                Asteroids_Game.asteroid_array(i).xPoints(j) += ((Math.Cos(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
                Asteroids_Game.asteroid_array(i).yPoints(j) += ((Math.Sin(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
                Dim OnePoint As New Point(Asteroids_Game.asteroid_array(i).xPoints(j), Asteroids_Game.asteroid_array(i).yPoints(j))
                Asteroids_Game.asteroid_array(i).AsteroidPoints(j) = (OnePoint)
            Next
            'check if off screen
            If Asteroids_Game.asteroid_array(i).startX > Asteroids_Game.formwidth Or Asteroids_Game.asteroid_array(i).startX < 0 Then
                'MsgBox(Asteroids_Game.asteroid_array(i).startX.ToString + "start x")
                'MsgBox(formwidth.ToString + "form width")
                'AsteroidAngle(i)

                'MsgBox("test")
            End If
            If Asteroids_Game.asteroid_array(i).startY > Asteroids_Game.formheight Or Asteroids_Game.asteroid_array(i).startY < 0 Then
                Asteroids_Game.AsteroidAngle(i)
            End If
        Next
    End Sub
End Class