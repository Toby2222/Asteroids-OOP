Public Class Asteroids
    'Variables needed for all asteroids
    Public onScreen As Boolean 'boolean for wether the asteroid is on the screen
    Public alive As Boolean 'booleon for wether alove or not
    Public aAngle As Double 'double for the angle asteroids
    Public aSpeed As Double 'integer for the speed of the asteroids
    Public xPoints() As Double  'array for all the xcoordiantes for the points in the asteroid
    Public yPoints() As Double  'array for all the y coordinates for the points in the asteroid
    Public AsteroidPoints() As Point
    Public startX As Double 'starting x coordinate
    Public startY As Double 'starting y coordinate
    Public numberOfPoints As Integer 'integer for number of points in the asteroid
    Public FixedAngles(7) As Double
    Public collideAreas As Double
    Public asteroidAreas As Double
    Public x1, x2, x3, y1, y2, y3 As Double


    Public Sub New()
        onScreen = True
        alive = True
        aSpeed = 0.5 'Rnd() * (3) + 1
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
        AsteroidArea()
    End Sub

    Public Sub AsteroidArea()
        For i = 0 To Asteroids_Game.numberOfAsteroids - 1
            For j = 0 To Asteroids_Game.asteroid_array(i).numberOfPoints - 2
                x1 = Asteroids_Game.asteroid_array(i).xPoints(j)
                x2 = Asteroids_Game.asteroid_array(i).xPoints(j + 1)
                x3 = Asteroids_Game.asteroid_array(i).startX
                y1 = Asteroids_Game.asteroid_array(i).yPoints(j)
                y2 = Asteroids_Game.asteroid_array(i).yPoints(j + 1)
                y3 = Asteroids_Game.asteroid_array(i).startY
                Asteroids_Game.asteroid_array(i).asteroidAreas += Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2
                'Asteroids_Game.asteroid_array(i).asteroidAreas += Math.Abs((x2 * y1 - x1 * y2) + (x3 * y2 - x2 * y3) + (x1 * y3 - x3 * y1)) / 2
            Next
            x1 = Asteroids_Game.asteroid_array(i).xPoints(0)
            x2 = Asteroids_Game.asteroid_array(i).xPoints(Asteroids_Game.asteroid_array(i).numberOfPoints - 1)
            x3 = Asteroids_Game.asteroid_array(i).startX
            y1 = Asteroids_Game.asteroid_array(i).yPoints(0)
            y2 = Asteroids_Game.asteroid_array(i).yPoints(Asteroids_Game.asteroid_array(i).numberOfPoints - 1)
            y3 = Asteroids_Game.asteroid_array(i).startY
            Asteroids_Game.asteroid_array(i).asteroidAreas += Math.Abs(x1 * Math.Abs(y2 - y3) + x2 * Math.Abs(y3 - y1) + x3 * Math.Abs(y1 - y2)) / 2
            'Asteroids_Game.asteroid_array(i).asteroidAreas += Math.Abs((x2 * y1 - x1 * y2) + (x3 * y2 - x2 * y3) + (x1 * y3 - x3 * y1)) / 2

        Next
    End Sub
    Public Sub collidesWith()
        For i = 0 To Asteroids_Game.numberOfAsteroids - 1
            For j = 0 To Asteroids_Game.asteroid_array(i).numberOfPoints - 2
                x1 = Asteroids_Game.asteroid_array(i).xPoints(j)
                x2 = Asteroids_Game.asteroid_array(i).xPoints(j + 1)
                x3 = Asteroids_Game.mySpaceship.SFx
                y1 = Asteroids_Game.asteroid_array(i).yPoints(j)
                y2 = Asteroids_Game.asteroid_array(i).yPoints(j + 1)
                y3 = Asteroids_Game.mySpaceship.SFy
                Asteroids_Game.asteroid_array(i).collideAreas += Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2
                'Asteroids_Game.asteroid_array(i).asteroidAreas += Math.Abs((x2 * y1 - x1 * y2) + (x3 * y2 - x2 * y3) + (x1 * y3 - x3 * y1)) / 2

            Next
            x1 = Asteroids_Game.asteroid_array(i).xPoints(0)
            x2 = Asteroids_Game.asteroid_array(i).xPoints(Asteroids_Game.asteroid_array(i).numberOfPoints - 1)
            x3 = Asteroids_Game.mySpaceship.SFx
            y1 = Asteroids_Game.asteroid_array(i).yPoints(0)
            y2 = Asteroids_Game.asteroid_array(i).yPoints(Asteroids_Game.asteroid_array(i).numberOfPoints - 1)
            y3 = Asteroids_Game.mySpaceship.SFy
            Asteroids_Game.asteroid_array(i).collideAreas += Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2
            'Asteroids_Game.asteroid_array(i).asteroidAreas += Math.Abs((x2 * y1 - x1 * y2) + (x3 * y2 - x2 * y3) + (x1 * y3 - x3 * y1)) / 2

            If Math.Round((Asteroids_Game.asteroid_array(i).collideAreas) / 1000, 0) = Math.Round((Asteroids_Game.asteroid_array(i).asteroidAreas) / 1000, 0) Then
                MsgBox("collided")
            End If
            Asteroids_Game.asteroid_array(i).collideAreas = 0
        Next
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
