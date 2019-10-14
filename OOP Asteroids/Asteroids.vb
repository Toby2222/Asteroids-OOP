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
            Dim OnePoint As New Point(xPoints(i), yPoints(i))
            AsteroidPoints(i) = (OnePoint)
        Next
    End Sub
    'Public Sub replace(f)
    '    Console.WriteLine(Asteroids_Game.asteroid_array(f).onScreen.ToString + " onscreen")
    '    Console.WriteLine(Me.onScreen.ToString + " me onscreen")
    '    Console.WriteLine(Asteroids_Game.asteroid_array(f).startX.ToString + " startX")
    '    Console.WriteLine(Asteroids_Game.asteroid_array(f).startY.ToString + " startY")
    '    Console.WriteLine(Me.startX.ToString + " me startX")
    '    Console.WriteLine(Me.startY.ToString + " me startY")

    '    Asteroids_Game.asteroid_array(f).onScreen = True
    '    Asteroids_Game.asteroid_array(f).alive = True
    '    Asteroids_Game.asteroid_array(f).aSpeed = Rnd() * (3) + 1
    '    Asteroids_Game.asteroid_array(f).numberOfPoints = Int(Rnd() * (4)) + 5
    '    For i = 1 To numberOfPoints
    '        Asteroids_Game.asteroid_array(f).FixedAngles(i - 1) = Rnd(i * (2 * Math.PI) / Asteroids_Game.asteroid_array(f).numberOfPoints) + (i - 1) * (2 * Math.PI) / Asteroids_Game.asteroid_array(f).numberOfPoints
    '    Next
    '    ReDim Asteroids_Game.asteroid_array(f).xPoints(Asteroids_Game.asteroid_array(f).numberOfPoints - 1)
    '    ReDim Asteroids_Game.asteroid_array(f).yPoints(Asteroids_Game.asteroid_array(f).numberOfPoints - 1)
    '    ReDim Asteroids_Game.asteroid_array(f).AsteroidPoints(Asteroids_Game.asteroid_array(f).numberOfPoints - 1)
    '    Asteroids_Game.AsteroidAngle(f)
    '    For i = 0 To (Asteroids_Game.asteroid_array(f).numberOfPoints) - 1
    '        Dim rand As Integer = (Rnd() * 45) + 35
    '        Console.WriteLine(Asteroids_Game.asteroid_array(f).startX.ToString + " startX before")
    '        Console.WriteLine(Asteroids_Game.asteroid_array(f).startY.ToString + " startY before")
    '        Console.WriteLine(Asteroids_Game.asteroid_array(f).aAngle.ToString + " Aangle")
    '        Asteroids_Game.asteroid_array(f).xPoints(i) = Asteroids_Game.asteroid_array(f).startX + ((Math.Cos(Asteroids_Game.asteroid_array(f).FixedAngles(i))) * (rand))
    '        Asteroids_Game.asteroid_array(f).yPoints(i) = Asteroids_Game.asteroid_array(f).startY + ((Math.Sin(Asteroids_Game.asteroid_array(f).FixedAngles(i))) * (rand))
    '        Dim OnePoint As New Point(Asteroids_Game.asteroid_array(f).xPoints(i), Asteroids_Game.asteroid_array(f).yPoints(i))
    '        Asteroids_Game.asteroid_array(f).AsteroidPoints(i) = (OnePoint)
    '    Next
    'End Sub
    Public Sub Update(i)
        'Console.WriteLine(Asteroids_Game.formwidth.ToString + " form width")
        'Console.WriteLine(Asteroids_Game.formheight.ToString + " form height")
        'Console.WriteLine(Asteroids_Game.asteroid_array(i).startX.ToString + " x before update")
        'Console.WriteLine(Asteroids_Game.asteroid_array(i).startY.ToString + " y before update")
        'Console.WriteLine(Int(((Math.Cos(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)).ToString + " update x by")
        'Console.WriteLine(Int(((Math.Sin(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)).ToString + " update y by")
        Asteroids_Game.asteroid_array(i).startX += ((Math.Cos(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
        Asteroids_Game.asteroid_array(i).startY += ((Math.Sin(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
        'Console.WriteLine(Asteroids_Game.asteroid_array(i).startX.ToString + " x after update")
        'Console.WriteLine(Asteroids_Game.asteroid_array(i).startY.ToString + " y after update")
        For j = 0 To Asteroids_Game.asteroid_array(i).numberOfPoints - 1
            'Console.WriteLine(Asteroids_Game.asteroid_array(i).xPoints(j).ToString + " x " + j.ToString + " before update")
            'Console.WriteLine(Asteroids_Game.asteroid_array(i).yPoints(j).ToString + " y " + j.ToString + " before update")
            Asteroids_Game.asteroid_array(i).xPoints(j) += ((Math.Cos(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
            Asteroids_Game.asteroid_array(i).yPoints(j) += ((Math.Sin(Asteroids_Game.asteroid_array(i).aAngle)) * Asteroids_Game.asteroid_array(i).aSpeed)
            'Console.WriteLine(Asteroids_Game.asteroid_array(i).xPoints(j).ToString + " x " + j.ToString + " after update")
            'Console.WriteLine(Asteroids_Game.asteroid_array(i).yPoints(j).ToString + " y " + j.ToString + " after update")
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
            'Asteroids_Game.asteroid_array(i).onScreen = True
            'Asteroids_Game.asteroid = New Asteroids
        End If
    End Sub
End Class
