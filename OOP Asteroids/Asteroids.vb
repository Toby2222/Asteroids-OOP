Public Class Asteroids
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
    Public collideangle As Double 'define a variable for calculating the angles between the asteroids and other objects
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
    Public Sub collides() 'function for collisions
        angleFunc(Asteroids_Game.mySpaceship.SFx, Asteroids_Game.mySpaceship.SFy, "Ship", 2) 'function for detecting collisions between the front of the ship and the asteroid
        angleFunc(Asteroids_Game.mySpaceship.SLx, Asteroids_Game.mySpaceship.SLy, "Ship", 2) 'detect the left point of the ship
        angleFunc(Asteroids_Game.mySpaceship.SRx, Asteroids_Game.mySpaceship.SRy, "Ship", 2) 'detect the right point of the ship
        For i = 0 To Asteroids_Game.bullet_array.Count - 1 'for loop to go through all the bullets
            If Asteroids_Game.bullet_array(i).inForm = True Then 'if the bullet is on screen then check for collisions
                angleFunc(Asteroids_Game.bullet_array(i).BFx, Asteroids_Game.bullet_array(i).BFy, "Bull", i) 'detect front point of the bullet
                'angleFunc(Asteroids_Game.bullet_array(i).BBx, Asteroids_Game.bullet_array(i).BBy) 'detect back point of the bullet
            End If
        Next
    End Sub
    Public Function angleFunc(x, y, type, j)
        For i = 0 To Asteroids_Game.asteroid_array.Count - 1 'loop through all asteroids
            If x > Asteroids_Game.asteroid_array(i).startX - 100 And
               x < Asteroids_Game.asteroid_array(i).startX + 100 And
               y < Asteroids_Game.asteroid_array(i).startY + 100 And
               y > Asteroids_Game.asteroid_array(i).startY - 100 Then
                collideangle = 0  'reset the angle to 0
                Dim a, b, ax, ay, bx, by, dotproduct, thisone As Double
                For j = 0 To Asteroids_Game.asteroid_array(i).numberOfPoints - 2 'loop through the points of the asteroid
                    ax = Math.Abs(x - Asteroids_Game.asteroid_array(i).xPoints(j)) 'calculate the length of one side between the point being tested and the asteroid point
                    ay = Math.Abs(y - Asteroids_Game.asteroid_array(i).yPoints(j)) 'calculate the length of the other side
                    bx = Math.Abs(x - Asteroids_Game.asteroid_array(i).xPoints(j + 1)) 'calculate the length of one side between the point being tested and the next asteroid point
                    by = Math.Abs(y - Asteroids_Game.asteroid_array(i).yPoints(j + 1)) 'calculate the length of the other side
                    a = Math.Sqrt((ax) ^ 2 + (ay) ^ 2) 'calculate the length of the hypotenuse
                    b = Math.Sqrt((bx) ^ 2 + (by) ^ 2) 'calculate the length of the hypotenuse
                    dotproduct = ((ax * bx) + (ay * by)) 'calculate the dotproduct of the length
                    thisone = Math.Acos(dotproduct / (a * b)) 'take the anti cosign of the dot product divided by the two vectors
                    collideangle += thisone 'add the angle calculated
                Next
                'same calculation for the last and first point
                ax = (x - Asteroids_Game.asteroid_array(i).xPoints(Asteroids_Game.asteroid_array(i).numberOfPoints - 1))
                ay = (y - Asteroids_Game.asteroid_array(i).yPoints(Asteroids_Game.asteroid_array(i).numberOfPoints - 1))
                bx = (x - Asteroids_Game.asteroid_array(i).xPoints(0))
                by = (y - Asteroids_Game.asteroid_array(i).yPoints(0))
                a = Math.Sqrt((ax) ^ 2 + (ay) ^ 2)
                b = Math.Sqrt((bx) ^ 2 + (by) ^ 2)
                dotproduct = ((ax * bx) + (ay * by))
                thisone = Math.Acos(dotproduct / (a * b))
                collideangle += thisone
                If collideangle >= 1.12 * Math.PI Then 'if the angle is greater than 1.12 * math.pi
                    If type = "Ship" Then
                        Form.ActiveForm.BackColor = (Color.Red)
                        Asteroids_Game.mySpaceship.SOx = Asteroids_Game.formwidth / 2
                        Asteroids_Game.mySpaceship.SOy = Asteroids_Game.formheight / 2
                    Else
                        Form.ActiveForm.BackColor = (Color.Blue)

                        If Asteroidbig = True Then
                            Asteroids_Game.tempAsteroidx = Asteroids_Game.asteroid_array(i).startX
                            Asteroids_Game.tempAsteroidy = Asteroids_Game.asteroid_array(i).startY
                            Asteroids_Game.asteroid_array(i).Finalize()
                            Asteroids_Game.asteroid_array.RemoveAt(i)
                            Asteroids_Game.asteroid = New Asteroids("s")
                            'Asteroids_Game.asteroid = New Asteroids("s")
                        Else
                            Asteroids_Game.lostasteroids = i
                        End If
                    End If
                End If
            End If
        Next
        If Asteroids_Game.lostasteroids > -1 Then 'i = 0 To Asteroids_Game.lostBullets.Length - 1
            Asteroids_Game.asteroid_array(Asteroids_Game.lostasteroids).Finalize()
            Asteroids_Game.asteroid_array.RemoveAt(Asteroids_Game.lostasteroids)
        End If
        Asteroids_Game.lostBullets = -1
    End Function

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
                Asteroids_Game.asteroid_array(i).Finalize()
                Asteroids_Game.asteroid_array.RemoveAt(i)
                Asteroids_Game.asteroid = New Asteroids("s")
            End If
        End If
    End Sub
End Class
