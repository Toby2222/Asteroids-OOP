﻿Public Class Asteroids
#Region "variables"
    'Variables needed for all asteroids
    Public onScreen As Boolean 'boolean for wether the asteroid is on the screen
    Public alive As Boolean 'booleon for wether alove or not
    Public aAngle As Double 'double for the angle asteroids
    Public aSpeed As Double 'integer for the speed of the asteroids
    Public xPoints() As Double  'array for all the xcoordiantes for the points in the asteroid
    Public yPoints() As Double  'array for all the y coordinates for the points in the asteroid
    Public AsteroidPoints() As Point 'array for all points of the asteroid
    Public startX As Double 'starting x coordinate
    Public startY As Double 'starting y coordinate
    Public numberOfPoints As Integer 'integer for number of points in the asteroid
    Public FixedAngles(7) As Double 'array of angles for each asteroid with a max of 8 angles
    Public collideangle As Double 'define a variable for calculating the angles between the asteroids and other objects
#End Region
    Public Sub New() 'instantiating an asteroid
        onScreen = True
        alive = True
        aSpeed = Rnd() * (3) + 1 'random speed varaible between 1 and 4
        numberOfPoints = Int(Rnd() * (6)) + 5 'random number of points between 5 and 9
        For i = 1 To numberOfPoints 'loop through the number of points and calculate angles between the points based on the number of points and random numbers
            FixedAngles(i - 1) = Rnd(i * (2 * Math.PI) / numberOfPoints) + (i - 1) * (2 * Math.PI) / numberOfPoints
        Next
        ReDim xPoints(numberOfPoints - 1) 'define the size of the array of x coordinates
        ReDim yPoints(numberOfPoints - 1) 'define the size of the array of y coordinates
        ReDim AsteroidPoints(numberOfPoints - 1) 'define the size of the array of points of the asteroid
        Asteroids_Game.asteroid_array.Add(Me) 'add the asteroid to the array
        Asteroids_Game.AsteroidAngle(Asteroids_Game.asteroid_array.Count - 1) 'call the asteroid angle function to decide where the asteroid should start and the angle it travels at
        For i = 0 To (numberOfPoints) - 1
            Dim rand As Integer = (Rnd() * 45) + 35 'create a random variable to define the distance from the origin point for the points
            xPoints(i) = startX + ((Math.Cos(FixedAngles(i))) * (rand)) 'the x points = the origin x + an angle * the random distance
            yPoints(i) = startY + ((Math.Sin(FixedAngles(i))) * (rand)) 'the y points = the origin y + an angle * the random distance
            Dim OnePoint As New Point(xPoints(i), yPoints(i)) 'make a point variable from the x and y defined
            AsteroidPoints(i) = (OnePoint) 'add the point to an array
        Next
    End Sub
    Public Sub collides() 'function for 
        angleFunc(Asteroids_Game.mySpaceship.SFx, Asteroids_Game.mySpaceship.SFy)
        angleFunc(Asteroids_Game.mySpaceship.SLx, Asteroids_Game.mySpaceship.SLy)
        angleFunc(Asteroids_Game.mySpaceship.SRx, Asteroids_Game.mySpaceship.SRy)
        For i = 0 To Asteroids_Game.bullet_array.Count - 1
            If Asteroids_Game.bullet_array(i).inForm = True Then
                angleFunc(Asteroids_Game.bullet_array(i).BFx, Asteroids_Game.bullet_array(i).BFy)
                angleFunc(Asteroids_Game.bullet_array(i).BBx, Asteroids_Game.bullet_array(i).BBy)
            End If
        Next
    End Sub
    Public Function angleFunc(x, y)
        For i = 0 To Asteroids_Game.asteroid_array.Count - 1
            collideangle = 0
            Dim a, b, ax, ay, bx, by, dotproduct, thisone As Double
            For j = 0 To Asteroids_Game.asteroid_array(i).numberOfPoints - 2
                ax = Math.Abs(x - Asteroids_Game.asteroid_array(i).xPoints(j))
                ay = Math.Abs(y - Asteroids_Game.asteroid_array(i).yPoints(j))
                bx = Math.Abs(x - Asteroids_Game.asteroid_array(i).xPoints(j + 1))
                by = Math.Abs(y - Asteroids_Game.asteroid_array(i).yPoints(j + 1))
                a = Math.Sqrt((ax) ^ 2 + (ay) ^ 2)
                b = Math.Sqrt((bx) ^ 2 + (by) ^ 2)
                dotproduct = ((ax * bx) + (ay * by))
                thisone = Math.Acos(dotproduct / (a * b))
                collideangle += thisone
            Next
            ax = (x - Asteroids_Game.asteroid_array(i).xPoints(Asteroids_Game.asteroid_array(i).numberOfPoints - 1))
            ay = (y - Asteroids_Game.asteroid_array(i).yPoints(Asteroids_Game.asteroid_array(i).numberOfPoints - 1))
            bx = (x - Asteroids_Game.asteroid_array(i).xPoints(0))
            by = (y - Asteroids_Game.asteroid_array(i).yPoints(0))
            a = Math.Sqrt((ax) ^ 2 + (ay) ^ 2)
            b = Math.Sqrt((bx) ^ 2 + (by) ^ 2)
            dotproduct = ((ax * bx) + (ay * by))
            thisone = Math.Acos(dotproduct / (a * b))
            collideangle += thisone
            If collideangle >= 1.12 * Math.PI Then
                Form.ActiveForm.BackColor = (Color.Red)
            End If
        Next
    End Function

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
