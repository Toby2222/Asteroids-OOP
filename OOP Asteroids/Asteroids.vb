Imports System.Windows
Public Class Asteroids
    'Variables needed for all asteroids
    Public onScreen As Boolean 'boolean for wether the asteroid is on the screen
    Public alive As Boolean 'booleon for wether alive or not
    Public aAngle As Double 'double for the angle asteroids
    Public aSpeed As Double 'integer for the speed of the asteroids
    Public xPoints() As Double  'array for all the xcoordiantes for the points in the asteroid
    Public yPoints() As Double  'array for all the y coordinates for the points in the asteroid
    Public AsteroidPoints() As Point
    Public startX As Double 'starting x coordinate
    Public startY As Double 'starting y coordinate
    Public startPoint As Point
    Public numberOfPoints As Integer 'integer for number of points in the asteroid
    Public FixedAngles(7) As Double
    Public count As Integer
    Public count2 As Integer


    Public Sub New()
        onScreen = True
        alive = True
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
            AsteroidPoints(i) = New Point(xPoints(i), yPoints(i))
        Next
        startPoint = New Point(startX, startY)
        ConvexHull()
    End Sub
    Public Sub ConvexHull()
        Dim count As Integer = 2
        For i = 0 To Asteroids_Game.asteroid_array.Count - 1
            count = 2
            count2 = 1
            For j = 0 To Asteroids_Game.asteroid_array(i).AsteroidPoints.Count - 1
                If j >= Asteroids_Game.asteroid_array(i).AsteroidPoints.Count - 3 Then
                    count = 0
                End If
                If j >= Asteroids_Game.asteroid_array(i).AsteroidPoints.Count - 2 Then
                    count2 = 0
                End If
                Dim v1 As Double = (Asteroids_Game.asteroid_array(i).xPoints(j) - Asteroids_Game.asteroid_array(i).startX) + (Asteroids_Game.asteroid_array(i).yPoints(j) - Asteroids_Game.asteroid_array(i).startY)
                Dim v2 As Double = (Asteroids_Game.asteroid_array(i).xPoints(count) - Asteroids_Game.asteroid_array(i).startX) + (Asteroids_Game.asteroid_array(i).yPoints(count) - Asteroids_Game.asteroid_array(i).startY)
                Console.WriteLine("J: " + j.ToString)
                Console.WriteLine("v2: " + v2.ToString)
                Console.WriteLine("v1: " + v1.ToString)
                Dim checkV As Double = (Asteroids_Game.asteroid_array(i).xPoints(count2) - Asteroids_Game.asteroid_array(i).startX) + (Asteroids_Game.asteroid_array(i).yPoints(count2) - Asteroids_Game.asteroid_array(i).startY)
                Console.WriteLine("checkV: " + checkV.ToString)
                Dim beta As Double = ((0.7 * v1) - checkV) / v2
                Console.WriteLine("beta: " + beta.ToString)
                If beta <> 0.3 Then
                    Console.WriteLine("delete point: " + (j + 1).ToString)
                Else
                    Console.WriteLine("convex already" + j.ToString + (j + 1).ToString + (j + 2).ToString)
                End If
                count += 1
                count2 += 1
                'Dim value As Double = (0.4 * Asteroids_Game.asteroid_array(i).AsteroidPoints(j), Asteroids_Game.asteroid_array(i).startPoint) + (0.6 * 0.4 * Asteroids_Game.asteroid_array(i).AsteroidPoints(j + 2), Asteroids_Game.asteroid_array(i).startPoint)
            Next
        Next
        Console.WriteLine("test")
    End Sub
    Public Sub Update(i)

        Asteroids_Game.asteroid_array(i).startX += ((Math.Cos(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
        Asteroids_Game.asteroid_array(i).startY += ((Math.Sin(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)

        For j = 0 To Asteroids_Game.asteroid_array(i).numberOfPoints - 1

            Asteroids_Game.asteroid_array(i).xPoints(j) += ((Math.Cos(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
            Asteroids_Game.asteroid_array(i).yPoints(j) += ((Math.Sin(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)

            Dim OnePoint As New Point(Asteroids_Game.asteroid_array(i).xPoints(j), Asteroids_Game.asteroid_array(i).yPoints(j))
            Asteroids_Game.asteroid_array(i).AsteroidPoints(j) = (OnePoint)
            'check if off screen
        Next
        If Asteroids_Game.asteroid_array(i).startX > Asteroids_Game.formwidth Or Asteroids_Game.asteroid_array(i).startX < 0 Then
            Asteroids_Game.asteroid_array(i).onScreen = False

        ElseIf Asteroids_Game.asteroid_array(i).startY > Asteroids_Game.formheight Or Asteroids_Game.asteroid_array(i).startY < 0 Then
            Asteroids_Game.asteroid_array(i).onScreen = False
        Else
            Asteroids_Game.asteroid_array(i).onScreen = True
        End If
        If Asteroids_Game.asteroid_array(i).onScreen = False Then
            Asteroids_Game.asteroid_array(i).Finalize()
            Asteroids_Game.asteroid_array.RemoveAt(i)
            Asteroids_Game.asteroid = New Asteroids()

        End If
    End Sub
End Class
