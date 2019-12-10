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
    Public Asteroidbig As Boolean 'boolean for if the asteroid is a large one
    Public numberOfPoints As Integer 'integer for number of points in the asteroid
    Public FixedAngles(7) As Double 'array of angles for each asteroid with a max of 8 angles
    Public size As String 'variable for the size of the asteroid
#End Region
    Public Sub New(asize) 'instantiating an asteroid
        onScreen = True
        alive = True
        size = asize
        aSpeed = Rnd() * (2) + 1 'random speed varaible between 1 and 4
        numberOfPoints = Int(Rnd() * (4)) + 5 'random number of points between 5 and 9
        For i = 1 To numberOfPoints 'loop through the number of points and calculate angles between the points based on the number of points and random numbers
            FixedAngles(i - 1) = Rnd(i * (2 * Math.PI) / numberOfPoints) + (i - 1) * (2 * Math.PI) / numberOfPoints
        Next
        ReDim xPoints(numberOfPoints - 1) 'define the size of the array of x coordinates
        ReDim yPoints(numberOfPoints - 1) 'define the size of the array of y coordinates
        ReDim AsteroidPoints(numberOfPoints - 1) 'define the size of the array of points of the asteroid
        Asteroids_Game.asteroid_array.Add(Me) 'add the asteroid to the array
        Asteroids_Game.AsteroidAngle(Asteroids_Game.asteroid_array.Count - 1) 'call the asteroid angle function to decide where the asteroid should start and the angle it travels at
        For i = 0 To (numberOfPoints) - 1
            Dim rand As Integer
            If size = "b" Then
                rand = (Rnd() * 45) + 35 'create a random variable to define the distance from the origin point for the points
                Asteroidbig = True
            Else
                Asteroidbig = False
                startX = Asteroids_Game.tempAsteroidx
                startY = Asteroids_Game.tempAsteroidy
                rand = (Rnd() * 25) + 15 'create a random variable to define the distance from the origin point for the points
            End If
            xPoints(i) = startX + ((Math.Cos(FixedAngles(i))) * (rand)) 'the x points = the origin x + an angle * the random distance
            yPoints(i) = startY + ((Math.Sin(FixedAngles(i))) * (rand)) 'the y points = the origin y + an angle * the random distance
            Dim OnePoint As New Point(xPoints(i), yPoints(i)) 'make a point variable from the x and y defined
            AsteroidPoints(i) = (OnePoint) 'add the point to an array
        Next
    End Sub
    Public Sub fin(i)
        Asteroids_Game.asteroid_array(i).Finalize()
    End Sub
    Public Sub Update(i)
        'update the origin point of the asteroids
        Asteroids_Game.asteroid_array(i).startX += ((Math.Cos(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
        Asteroids_Game.asteroid_array(i).startY += ((Math.Sin(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
        For j = 0 To Asteroids_Game.asteroid_array(i).numberOfPoints - 1 'loop through the points of the asteroid
            Asteroids_Game.asteroid_array(i).xPoints(j) += ((Math.Cos(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed) 'update the x coordinates    
            Asteroids_Game.asteroid_array(i).yPoints(j) += ((Math.Sin(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed) 'update the y coordinates
            Dim OnePoint As New Point(Asteroids_Game.asteroid_array(i).xPoints(j), Asteroids_Game.asteroid_array(i).yPoints(j)) 'combining the coordiantes into a point
            Asteroids_Game.asteroid_array(i).AsteroidPoints(j) = (OnePoint) 'add the point to the array
        Next
        'if offscreen chagne the variable
        If Asteroids_Game.asteroid_array(i).startX > Asteroids_Game.formwidth Or Asteroids_Game.asteroid_array(i).startX < 0 Then
            Asteroids_Game.asteroid_array(i).onScreen = False
        ElseIf Asteroids_Game.asteroid_array(i).startY > Asteroids_Game.formheight Or Asteroids_Game.asteroid_array(i).startY < 0 Then
            Asteroids_Game.asteroid_array(i).onScreen = False
        Else
            Asteroids_Game.asteroid_array(i).onScreen = True
        End If
        'if offscreen remove all the data from the variables and remove the asteroid from the array, and create a new asteroid
        If Asteroids_Game.asteroid_array(i).onScreen = False Then
            If Asteroids_Game.asteroid_array(i).size = "b" Then
                Asteroids_Game.asteroid_array(i).Finalize()
                Asteroids_Game.asteroid_array.RemoveAt(i)
                Asteroids_Game.asteroid = New Asteroids("b")
            ElseIf Asteroids_Game.asteroid_array(i).size = "s" Then
                fin(i)



                Asteroids_Game.asteroid_array.RemoveAt(i)
                Asteroids_Game.asteroid = New Asteroids("s")
            End If
        End If
    End Sub
End Class
