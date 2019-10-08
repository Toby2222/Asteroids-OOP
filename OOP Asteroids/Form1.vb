Public Class Asteroids_Game
    Dim random As Integer = (Rnd() * 5) + 3
    'creating all the objects
    Dim mySpaceship As Ship = New Ship
    Dim asteroid As Asteroids
    Dim asteroid_array As New List(Of Asteroids)(random)
    Dim bullet As Bullets
    Dim bullet_array As New List(Of Bullets)()

    'get the size of the form
    Dim formwidth As Integer
    Dim formheight As Integer

    'asteroid angles
    Dim AsteroidAngles As Double() = {0.1, 1, 2.5, 3.2, 4, 5.8}

    'booleans for keys
    Dim up As Boolean = False
    Dim left As Boolean = False
    Dim right As Boolean = False
    Dim space As Boolean = False
    Dim test As Boolean = False

    'defining a counter variable
    Dim counter As Integer

    'defining the brush for painting the ship
    Dim brushColor As Color = Color.White

    Class Ship
        'define all the point coordinate for the ship
        Public SLx, SLy, SRx, SRy, SFx, SFy, SOx, SOy As Integer

        'give the points a value to represent the length from the origin to define the size of the ship
        Public SFl As Integer    'ship front length
        Public SLl As Integer    'ship left length
        Public SRl As Integer    'ship right length

        'give the points an angle from the origin point of the ship
        Public SOa As Double    'ship origin angle
        Public SFa As Integer    'ship front angle
        Public SLa As Integer    'ship left angle
        Public SRa As Integer    'ship right angle
        Public pSOa As Double   'define previous spaceship origin angle

        'definine delta angles (rate of change of angle)
        Public SOad As Double    'ship origin delta angle
        Public damax As Double    'max turn speed
        Public SOsd As Double    'ship origin delta speed
        Public dsmax As Double    'max delta speed

        'defining ship variables
        Public curSpeed As Double
        Public maxSpeed As Double
        Public curAngleSpeed As Double
        Public maxAngleSpeed As Double

        'define drag variables of ship
        Public adrag As Double   'angle drag
        Public sdrag As Double   'speed drag

        Public Sub New()
            'give the points a value to represent the length from the origin to define the size of the ship
            SFl = 34    'ship front length
            SLl = 56    'ship left length
            SRl = 56    'ship right length

            'give the points an angle from the origin point of the ship
            SOa = 0.872664626    'ship origin angle
            SFa = 0    'ship front angle
            SLa = 1.919862177    'ship left angle
            SRa = 4.36332313    'ship right angle
            pSOa = SOa    'define previous spaceship origin angle

            'definine delta angles (rate of change of angle)
            SOad = 0    'ship origin delta angle
            damax = 0.22    'max turn speed
            SOsd = 0    'ship origin delta speed
            dsmax = 10    'max delta speed

            'defining ship variables
            maxSpeed = 10
            maxAngleSpeed = 0.12

            'define drag variables of ship
            adrag = 0.003    'angle drag
            sdrag = 0.07    'speed drag

        End Sub
    End Class

    Class Asteroids
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
            aSpeed = Rnd() * (5) + 1
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
    End Class

    Class Bullets
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
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim pen As New Drawing.Pen(brushColor) 'create a pen element
        Dim brush As Brush
        brush = New SolidBrush(Color.White)
        'define the points for the ship based off the coordinates
        Dim SL As New Point(mySpaceship.SLx, mySpaceship.SLy)
        Dim SR As New Point(mySpaceship.SRx, mySpaceship.SRy)
        Dim SO As New Point(mySpaceship.SOx, mySpaceship.SOy)
        Dim SF As New Point(mySpaceship.SFx, mySpaceship.SFy)
        Dim shipPoints As Point() = {SL, SO, SR, SF, SL}

        For i = 0 To Me.bullet_array.Count - 1
            Dim BR As New Point(bullet_array(i).BFx, bullet_array(i).BFy)
            Dim BF As New Point(bullet_array(i).BBx, bullet_array(i).BBy)
            e.Graphics.DrawLine(pen, BR, BF)
        Next
        For i = 0 To random - 1
            If asteroid_array(i).alive = True And asteroid_array(i).onScreen = True Then
                e.Graphics.DrawPolygon(pen, asteroid_array(i).AsteroidPoints)
            End If
        Next
        '    For i = 0 To 4
        'If BA(14, i) = 1 Then
        'Dim BA1 As New Point(BA(2, i), BA(8, i))
        'Dim BA2 As New Point(BA(3, i), BA(9, i))
        'Dim BA3 As New Point(BA(4, i), BA(10, i))
        'Dim BA4 As New Point(BA(5, i), BA(11, i))
        'Dim BA5 As New Point(BA(6, i), BA(12, i))
        'Dim BA6 As New Point(BA(7, i), BA(13, i))
        'Dim asteroid As Point() = {BA1, BA2, BA3, BA4, BA5, BA6, BA1}
        '            e.Graphics.DrawPolygon(pen, asteroid)
        'End If
        'Next

        'draw the ship
        e.Graphics.FillPolygon(brush, shipPoints)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'update the ship angle and position
        'update front point
        mySpaceship.SFx = mySpaceship.SOx + ((Math.Cos(mySpaceship.SOa)) * mySpaceship.SFl)
        mySpaceship.SFy = mySpaceship.SOy + ((Math.Sin(mySpaceship.SOa)) * mySpaceship.SFl)
        'update left point
        mySpaceship.SLx = mySpaceship.SOx + ((Math.Cos(mySpaceship.SOa + mySpaceship.SLa)) * mySpaceship.SLl)
        mySpaceship.SLy = mySpaceship.SOy + ((Math.Sin(mySpaceship.SOa + mySpaceship.SLa)) * mySpaceship.SLl)
        'update right point
        mySpaceship.SRx = mySpaceship.SOx + ((Math.Cos(mySpaceship.SOa + mySpaceship.SRa)) * mySpaceship.SRl)
        mySpaceship.SRy = mySpaceship.SOy + ((Math.Sin(mySpaceship.SOa + mySpaceship.SRa)) * mySpaceship.SRl)
        'update the origin point by the delta of the speed
        mySpaceship.SOx = mySpaceship.SOx + ((Math.Cos(mySpaceship.pSOa)) * mySpaceship.SOsd)
        mySpaceship.SOy = mySpaceship.SOy + ((Math.Sin(mySpaceship.pSOa)) * mySpaceship.SOsd)
        'if statement for the drag to slow the ship
        If mySpaceship.SOsd > 0 Then
            mySpaceship.SOsd -= mySpaceship.sdrag
        End If
        'update the angle of the ship
        mySpaceship.SOa += mySpaceship.SOad
        'if statement to define the drag of turning the ship
        'If mySpaceship.SOad < -0.003 Then
        '    mySpaceship.SOad += mySpaceship.adrag
        'ElseIf mySpaceship.SOad > 0.003 Then
        '    mySpaceship.SOad -= mySpaceship.adrag
        'Else
        '    mySpaceship.SOad = 0
        'End If
        'when the ship leaves the form appear on the opposite side
        If mySpaceship.SOx < 0 Then

            mySpaceship.SOx = formwidth
        End If
        If mySpaceship.SOy < 0 Then
            mySpaceship.SOy = formheight
        End If
        If mySpaceship.SOx > formwidth Then
            mySpaceship.SOx = 0
        End If
        If mySpaceship.SOy > formheight Then
            mySpaceship.SOy = 0
        End If

        'update the asteroid points
        For i = 0 To 4
            asteroid_array(i).startX += ((Math.Cos(asteroid_array(i).aAngle)) * asteroid_array(i).aSpeed)
            asteroid_array(i).startY += ((Math.Sin(asteroid_array(i).aAngle)) * asteroid_array(i).aSpeed)
            For j = 0 To asteroid_array(i).numberOfPoints - 1
                asteroid_array(i).xPoints(j) += ((Math.Cos(asteroid_array(i).aAngle)) * asteroid_array(i).aSpeed)
                asteroid_array(i).yPoints(j) += ((Math.Sin(asteroid_array(i).aAngle)) * asteroid_array(i).aSpeed)
            Next
        Next
        'check if off screen
        For i = 0 To 4
            If asteroid_array(i).startX > formwidth Or asteroid_array(i).startX < 0 Then
                AsteroidAngle(i)
            End If
            If asteroid_array(i).startY > formheight Or asteroid_array(i).startY < 0 Then
                AsteroidAngle(i)
            End If
        Next
        'key press booleans
        'If right = True Then
        '    'prevent ship turning to fast
        '    If mySpaceship.SOad < mySpaceship.damax Then
        '        mySpaceship.SOad += 0.007
        '    End If
        'End If
        'If left = True Then
        '    'prevent ship turning to fast
        '    If mySpaceship.SOad > (0 - mySpaceship.damax) Then
        '        mySpaceship.SOad -= 0.007
        '    End If
        'End If
        If right = True Then
            'prevent ship turning to fast
            mySpaceship.SOa += 0.1
        End If
        If left = True Then
            'prevent ship turning to fast
            mySpaceship.SOa -= 0.1
        End If
        If up = True Then
            'ensure angle of movement stays constant even after turning the ship
            mySpaceship.pSOa = mySpaceship.SOa
            'stop the ship from propelling forward and turning at the same time
            'stop the ship from flying too quickly
            If mySpaceship.SOsd < mySpaceship.dsmax Then
                mySpaceship.SOsd += 0.3
            End If

        End If
        If space = True Then
            counter += 1
            If counter = 10 Then
                counter = 0
                bullet = New Bullets(mySpaceship.SOa, mySpaceship.SOx, mySpaceship.SOy)
            End If
        End If
        'If test = True Then
        '    asteroid = New Asteroids
        'End If
        If bullet_array.Count > 0 Then
            bullet.update()
        End If
        Invalidate()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'random numbers
        Randomize()

        'set the starting points for the origin point within the ship
        mySpaceship.SOx = 78
        mySpaceship.SOy = 96
        'finds the starting size of the form
        formwidth = Me.Width
        formheight = Me.Height
        'populating defaults in Asteroids arrays
        For i = 0 To random - 1
            asteroid = New Asteroids
        Next

    End Sub
    Function AsteroidAngle(i)
        'random number to decde the starting side
        Dim side As Integer = (Rnd() * 3) + 1
        'if side is one then start at top
        If side = 3 Then
            Dim rand As Integer = (Rnd() * formwidth)
            'set the start pos somewhere along the top
            asteroid_array(i).startX = rand
            asteroid_array(i).startY = 0
            'if start pos is in upper third of top number then 180 to 270
            If rand > ((2 / 3) * formwidth) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.5 * Math.PI)) + Math.PI)
                'if start pos is in bottom third of top number then bottom 90 to 180
            ElseIf rand < ((1 / 3) * formwidth) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.5 * Math.PI)) + (0.5 * Math.PI))
                'if start pos is in middle thid of top number then bottom 90 to 270
            Else
                asteroid_array(i).aAngle = ((Rnd() * (Math.PI)) + (0.5 * Math.PI))
            End If
            'if side is two then start at right
        ElseIf side = 4 Then
            Dim rand As Integer = (Rnd() * formheight)
            'set the start pos somewhere along the right
            asteroid_array(i).startX = formwidth
            asteroid_array(i).startY = rand
            'if start pos is in upper third of right number then 270 to 360
            If rand > ((2 / 3) * formheight) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.5 * Math.PI)) + (Math.PI * 1.5))
                'if start pos is in the bottom third of right number then 180 to 270
            ElseIf rand < ((1 / 3) * formheight) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.5 * Math.PI)) + Math.PI)
                'if the start pos is in the middle third of the right number then 180 to 360
            Else
                asteroid_array(i).aAngle = ((Rnd() * (Math.PI)) + (Math.PI))
            End If
        ElseIf side = 1 Then
            Dim rand As Integer = (Rnd() * formwidth)
            asteroid_array(i).startX = rand
            asteroid_array(i).startY = formheight
            'if start pos is in upper third of bottom number then 270 to 360
            If rand > ((2 / 3) * formwidth) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.5 * Math.PI)) + (Math.PI * 1.5))
                'if start pos is in the bottom third of bottom number then 0 to 90
            ElseIf rand < ((1 / 3) * formwidth) Then
                asteroid_array(i).aAngle = (Rnd() * (0.5 * Math.PI))
                'if the start pos is in the middle third of the bottom number then 270 to 90
            Else
                asteroid_array(i).aAngle = ((Rnd() * (Math.PI)) + (1.5 * Math.PI))
            End If
        ElseIf side = 2 Then
            Dim rand As Integer = (Rnd() * formheight)
            asteroid_array(i).startX = 0
            asteroid_array(i).startY = rand
            'if start pos is in upper third of left number then 0 to 90
            If rand > ((2 / 3) * formheight) Then
                asteroid_array(i).aAngle = (Rnd() * (0.5 * Math.PI))
                'if start pos is in the bottom third of right number then 90 to 180
            ElseIf rand < ((1 / 3) * formheight) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.5 * Math.PI)) + (0.5 * Math.PI))
                'if the start pos is in the middle third of the right number then 0 to 180
            Else
                asteroid_array(i).aAngle = (Rnd() * (Math.PI))
            End If
        End If
    End Function

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown


        If e.KeyCode = Keys.Right Then
            right = True
        End If
        If e.KeyCode = Keys.Left Then
            left = True
        End If
        If e.KeyCode = Keys.Up Then
            up = True
        End If
        If e.KeyCode = Keys.Space Then
            space = True
        End If
        If e.KeyCode = Keys.Q Then
            test = True
        End If

    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp


        If e.KeyCode = Keys.Right Then
            right = False
        End If
        If e.KeyCode = Keys.Left Then
            left = False
        End If
        If e.KeyCode = Keys.Up Then
            up = False
        End If
        If e.KeyCode = Keys.Space Then
            space = False
        End If
        If e.KeyCode = Keys.Q Then
            test = False
        End If

    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        'updates the form size variables whenever the form size changes
        formwidth = (Me.Width)
        formheight = (Me.Height)
        Invalidate()
    End Sub
End Class