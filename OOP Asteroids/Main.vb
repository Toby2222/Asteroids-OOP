Public Class Asteroids_Game
#Region "variables"
    'creating all the objects
    Public mySpaceship As Ship = New Ship 'ship object
    Public asteroid As Asteroids 'asteroid object
    Public asteroid_array As New List(Of Asteroids) 'array of asteroid objects
    Public bullet As Bullets 'bullet object
    Public bullet_array As New List(Of Bullets)(4) 'array of bullet objects

    'get the size of the form
    Public formwidth As Integer 'width
    Public formheight As Integer 'height

    'asteroid variables
    Public numberOfAsteroids As Integer = (Rnd() * 5) + 3 'random generates 3 - 8 asteroids

    'booleans for keys
    Public up As Boolean = False
    Public left As Boolean = False
    Public right As Boolean = False
    Public space As Boolean = False

    'defining a counter variable
    Public counter As Integer 'a counter to decide the spacing between bullets
    Public testingspace As Integer = 0 'variable deciding the length of time before the screen returns to black after a collision

    'defining the brush for painting the ship
    Public brushColor As Color = Color.White 'defining the colour of all the objects on screen
#End Region
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias 'line of code to help make the graphics smooth
        Dim pen As New Drawing.Pen(brushColor) 'create a pen element
        Dim brush As Brush
        brush = New SolidBrush(brushColor)
#Region "ship drawing"
        'define the points for the ship based off the coordinates
        Dim SL As New Point(mySpaceship.SLx, mySpaceship.SLy)
        Dim SR As New Point(mySpaceship.SRx, mySpaceship.SRy)
        Dim SO As New Point(mySpaceship.SOx, mySpaceship.SOy)
        Dim SF As New Point(mySpaceship.SFx, mySpaceship.SFy)
        Dim shipPoints As Point() = {SL, SR, SF, SL} 'creating an array of points for the ship
        e.Graphics.FillPolygon(brush, shipPoints) 'draw the ship
#End Region
#Region "bullets"
        'for loop to draw bullets from the two points given
        For i = 0 To bullet_array.Count - 1
            Dim BR As New Point(bullet_array(i).BFx, bullet_array(i).BFy)
            Dim BF As New Point(bullet_array(i).BBx, bullet_array(i).BBy)
            e.Graphics.DrawLine(pen, BR, BF)
        Next
#End Region
#Region "asteroids"
        'for loop to draw asteroids from a random number of points given
        For i = 0 To numberOfAsteroids - 1
            If asteroid_array(i).alive = True And asteroid_array(i).onScreen = True Then
                e.Graphics.DrawPolygon(pen, asteroid_array(i).AsteroidPoints) 'if the asteroid has not been destroyed and is on screen then draw it
            End If
        Next
#End Region
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        mySpaceship.Update() 'update the ship
#Region "asteroids"
        For i = 0 To numberOfAsteroids - 1
            asteroid_array(i).Update(i) 'loop through the asteroids and update them all
        Next
        asteroid.collides() 'run the collision function in the asteroid sub
        testingspace += 1 'increment this the testing variable
        If testingspace = 3 Then 'if the testing varaible makes it to three then revert the background to black
            testingspace = 0 'reset the testing variable to start the spacing
            Me.BackColor = Color.Black 'revert the background colour to black
        End If
#End Region
#Region "Key Press"
        If right = True Then
            'prevent ship turning to fast
            mySpaceship.SOa += 0.1
        End If
        If left = True Then
            'prevent ship turning to fast
            mySpaceship.SOa -= 0.1
        End If
        If up = True Then
            If right = True Or left = True Then
            ElseIf mySpaceship.pSOa <> mySpaceship.SOa Then
                mySpaceship.SOsd /= 2
            End If
            'ensure angle of movement stays constant even after turning the ship
            mySpaceship.pSOa = mySpaceship.SOa
            'stop the ship from propelling forward and turning at the same time
            'stop the ship from flying too quickly
            If mySpaceship.SOsd < mySpaceship.dsmax Then
                mySpaceship.SOsd += 0.3
            End If

        End If
        If space = True Then
            counter += 1 'increment the counter for bullet spacing
            If counter >= 10 And bullet_array.Count < 5 Then 'if the bullet spacing is ten and there are less than 5 bullets
                counter = 0 'reset counter for the spacing
                bullet = New Bullets(mySpaceship.SOa, mySpaceship.SOx, mySpaceship.SOy) 'create a new bullet with the current spaceship x, y and angle
            Else
                For i = 0 To bullet_array.Count - 1 'loop through the bullet array
                    If counter >= 10 And bullet_array(i).inForm = False Then 'if the spacing has elapsed and there is a bullet off screen 
                        bullet.fire(mySpaceship.SOa, mySpaceship.SOx, mySpaceship.SOy, i) 'fire one of the bullets from the array
                    End If
                Next
            End If
        End If
#End Region
#Region "bullets"
        If bullet_array.Count > 0 Then
            For i = 0 To bullet_array.Count - 1
                If bullet_array(i).inForm = True Then
                    bullet.update(i)
                End If
            Next
        End If
#End Region
        Invalidate()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'numberOfAsteroids numbers
        Randomize()
        'set the starting points for the origin point within the ship
        mySpaceship.SOx = 78
        mySpaceship.SOy = 96
        'finds the starting size of the form
        formwidth = Me.Width
        formheight = Me.Height
        'populating defaults in Asteroids arrays
        For i = 0 To numberOfAsteroids - 1
            asteroid = New Asteroids()
        Next
    End Sub
    Function AsteroidAngle(i)
        'numberOfAsteroids number to decde the starting side
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

                asteroid_array(i).aAngle = (Rnd() * (0.2 * Math.PI)) + (1.2 * Math.PI)
                'if start pos is in the bottom third of bottom number then 0 to 90
            ElseIf rand < ((1 / 3) * formwidth) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.45 * Math.PI)) + (Math.PI * 1.53))

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
    End Sub
    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        'updates the form size variables whenever the form size changes
        formwidth = (Me.Width)
        formheight = (Me.Height)
        Invalidate()
    End Sub
End Class