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
    Public numberOfAsteroids As Integer
    Public tempAsteroidx As Double
    Public tempAsteroidy As Double
    Public destroyed As Integer = 0 'integer for number of small asteroids destroyed
    Public lostasteroids As Integer = -1

    'bullet variables
    Public counter As Integer 'a counter to decide the spacing between bullets
    Public numberOfBullets As Integer = 0
    Public lostBullets() As Integer
    Public hit As Boolean = False
    Public lostbulletcounter As Integer = 0

    'collision variables
    Public collideangle As Double 'define a variable for calculating the angles between the asteroids and other objects

    'boolean for keys
    Public up As Boolean = False
    Public left As Boolean = False
    Public right As Boolean = False
    Public space As Boolean = False

    'additional function variables
    Public score As Integer = 0
    Public lives As Integer = 3
    Public level As Integer = 0
    Public PlayerAnswerVariable As String = ""
    Public answer As String
    Public Decimalanswer As Integer
    Public multiplicationFactor As Integer
    Public questionrandom As Integer
    Public questionType As Integer
    Public One1Shown As Boolean = False
    Public One2Shown As Boolean = False
    Public Zero1Shown As Boolean = False
    Public Zero2Shown As Boolean = False
    Public timeleft As Double = 600 'Total number of seconds
    Public iSpan As TimeSpan = TimeSpan.FromSeconds(timeleft)
    Public abovecentre As Point
    Public belowcentre As Point
    Public offscreen As New Point(-1000, -1000)
    Public AnswerSubstringCounter As Integer = 0

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
        For i = 0 To asteroid_array.Count - 1
            If asteroid_array(i).onScreen = True Then
                e.Graphics.DrawPolygon(pen, asteroid_array(i).AsteroidPoints) 'if the asteroid is on screen then draw it
            End If
        Next
#End Region
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'numberOfAsteroids numbers
        Randomize()
        Timer.Text = iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" &
                        iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                        iSpan.Seconds.ToString.PadLeft(2, "0"c)
        'set the starting points for the origin point within the ship
        mySpaceship.SOx = Me.Width / 2
        mySpaceship.SOy = Me.Height / 2
        formwidth = Me.Width
        'finds the starting size of the form
        formheight = Me.Height
        abovecentre = New Point(Me.Width / 2 - 150, Me.Height / 2 - 25)
        belowcentre = New Point(Me.Width / 2 - 150, Me.Height / 2 + 25)
        If GameMenu.gamemode <> "fun" Then
            ScoreBox.Hide()
            numberOfAsteroids = (Rnd() * 5) + 10 'random generates 10 to 15 asteroids
        Else
            numberOfAsteroids = (Rnd() * 5) + 5 'random generates 5 to 10 asteroids
            Zero1.Hide()
            Zero2.Hide()
            One1.Hide()
            One2.Hide()
            Timer.Hide()
            Question.Hide()
            Playeranswer.Hide()
        End If
        'populating defaults in Asteroids arrays
        ModeLoader()
        'generating the questions based on the game mode
        Questions()
    End Sub
    Public Sub ModeLoader()
        For i = 0 To numberOfAsteroids - 1
            If GameMenu.gamemode = "bincal" Or GameMenu.gamemode = "bincon" Then
                If i = 0 Then
                    asteroid = New Asteroids("b", "NewB", "1")
                ElseIf i = 1 Then
                    asteroid = New Asteroids("b", "NewB", "1")
                ElseIf i = 2 Then
                    asteroid = New Asteroids("b", "NewB", "0")
                ElseIf i = 3 Then
                    asteroid = New Asteroids("b", "NewB", "0")
                ElseIf i >= 4 Then
                    asteroid = New Asteroids("b", "NewB", "z")
                End If
            ElseIf GameMenu.gamemode = "hexcal" Or GameMenu.gamemode = "hexcon" Then
                If i = 0 Then
                    asteroid = New Asteroids("b", "NewB", Hex((Rnd() * 16)))
                ElseIf i = 1 Then
                    asteroid = New Asteroids("b", "NewB", Hex((Rnd() * 16)))
                ElseIf i = 2 Then
                    asteroid = New Asteroids("b", "NewB", Hex((Rnd() * 16)))
                ElseIf i = 3 Then
                    asteroid = New Asteroids("b", "NewB", Hex((Rnd() * 16)))
                ElseIf i >= 4 Then
                    asteroid = New Asteroids("b", "NewB", "z")
                End If
            ElseIf GameMenu.gamemode = "octcal" Or GameMenu.gamemode = "octcon" Then
                If i = 0 Then
                    asteroid = New Asteroids("b", "NewB", Oct((Rnd() * 8)))
                ElseIf i = 1 Then
                    asteroid = New Asteroids("b", "NewB", Oct((Rnd() * 8)))
                ElseIf i = 2 Then
                    asteroid = New Asteroids("b", "NewB", Oct((Rnd() * 8)))
                ElseIf i = 3 Then
                    asteroid = New Asteroids("b", "NewB", Oct((Rnd() * 8) + 1))
                ElseIf i >= 4 Then
                    asteroid = New Asteroids("b", "NewB", "z")
                End If
            Else
                asteroid = New Asteroids("b", "NewB", "z")
            End If
        Next
    End Sub
    Public Function binaryconvert(x)
        Return Convert.ToString(x, 2).ToString.PadLeft(8, "0")
    End Function
    Public Sub Questions()
#Region "binary conversions"
        If GameMenu.gamemode = "bincon" Then
            questionType = Rnd() * 2
            If questionType = 0 Then
                questionrandom = (Rnd() * 255) + 1
                Question.Text = "Convert this decimal number into an 8-bit binary number: " + questionrandom.ToString
                answer = binaryconvert(questionrandom)
            ElseIf questionType = 1 Then
                questionrandom = (Rnd() * 255) + 1
                Question.Text = "Convert this hexadecimal number into an 8-bit binary number: " + Hex(questionrandom).ToString
                answer = binaryconvert(questionrandom)

            ElseIf questionType = 2 Then
                questionrandom = (Rnd() * 255) + 1
                Question.Text = "Convert this octal number into an 8-bit binary number: " + Oct(questionrandom).ToString
                answer = binaryconvert(questionrandom)

            End If
#End Region
#Region "binary calculations"
        ElseIf GameMenu.gamemode = "bincal" Then
            questionType = Rnd() * 2
            If questionType = 0 Then 'add numbers
                Decimalanswer = (Rnd() * 255) + 1
                answer = binaryconvert(Decimalanswer)
                questionrandom = (Rnd() * (Decimalanswer - 1)) + 1
                Question.Text = "Add these binary numbers together: " + binaryconvert(questionrandom) + " + " + binaryconvert((Decimalanswer - questionrandom))
            ElseIf questionType = 1 Then 'subtract numbers
                Decimalanswer = (Rnd() * 127) + 1
                answer = binaryconvert(Decimalanswer)
                questionrandom = (Rnd() * 128) + Decimalanswer
                Question.Text = "Subtract these binary numbers : " + binaryconvert(questionrandom) + " - " + binaryconvert((questionrandom - Decimalanswer))
            ElseIf questionType = 2 Then 'multiply numbers
                multiplicationFactor = (Rnd() * (29)) + 1
                questionrandom = Math.Floor(255 / multiplicationFactor)
                answer = binaryconvert(questionrandom * multiplicationFactor)
                Question.Text = "Multiply these binary numbers together: " + binaryconvert(questionrandom) + " X " + binaryconvert(multiplicationFactor)
            End If
#End Region
#Region "hex conversions"
        ElseIf GameMenu.gamemode = "hexcon" Then
            questionType = Rnd() * 2
            If questionType = 0 Then
                questionrandom = (Rnd() * 255) + 1
                Question.Text = "Convert this decimal number into a hex number: " + questionrandom.ToString
                answer = Hex(questionrandom)
            ElseIf questionType = 1 Then
                questionrandom = (Rnd() * 255) + 1
                Question.Text = "Convert this binary number into a hex number: " + binaryconvert(questionrandom)
                answer = Hex(Int(binaryconvert(questionrandom)))

            ElseIf questionType = 2 Then
                questionrandom = (Rnd() * 255) + 1
                Question.Text = "Convert this octal number into a hex number: " + Oct(questionrandom).ToString
                answer = Hex(Oct(questionrandom))

            End If
#End Region
#Region "hex calculations"
        ElseIf GameMenu.gamemode = "hexcal" Then
            questionType = Rnd() * 1
            If questionType = 0 Then 'add numbers
                Decimalanswer = (Rnd() * 255) + 1
                answer = Hex(Decimalanswer)
                questionrandom = (Rnd() * (Decimalanswer - 1)) + 1
                Question.Text = "Add these hexadecimal numbers together: " + Hex(questionrandom) + " + " + Hex((Decimalanswer - questionrandom))
            ElseIf questionType = 1 Then 'subtract numbers
                Decimalanswer = (Rnd() * 127) + 1
                answer = Hex(Decimalanswer)
                questionrandom = (Rnd() * 255) + Decimalanswer
                Question.Text = "Subtract these hexadecimal numbers: " + Hex(questionrandom) + " - " + Hex((questionrandom - Decimalanswer))
            ElseIf questionType = 2 Then 'multiply numbers
                multiplicationFactor = (Rnd() * (29)) + 1
                questionrandom = Math.Floor(255 / multiplicationFactor)
                answer = Hex(questionrandom * multiplicationFactor)
                Question.Text = "Multiply these hexadecimal numbers: " + Hex(questionrandom) + " X " + Hex(multiplicationFactor)
            End If
#End Region
#Region "octal conversions"
        ElseIf GameMenu.gamemode = "octcon" Then
            questionType = Rnd() * 2
            If questionType = 0 Then
                questionrandom = (Rnd() * 255) + 1
                Question.Text = "Convert this decimal number into an octal number: " + questionrandom.ToString
                answer = Oct(questionrandom)
            ElseIf questionType = 1 Then
                questionrandom = (Rnd() * 255) + 1
                Question.Text = "Convert this binary number into an octal number: " + binaryconvert(questionrandom)
                answer = Oct(Int(binaryconvert(questionrandom)))

            ElseIf questionType = 2 Then
                questionrandom = (Rnd() * 255) + 1
                Question.Text = "Convert this hex number into an octal number: " + Hex(questionrandom).ToString
                answer = Oct(Hex(questionrandom))

            End If
#End Region
#Region "octal calculations"
        ElseIf GameMenu.gamemode = "octcal" Then
            questionType = Rnd() * 1
            If questionType = 0 Then 'add numbers
                Decimalanswer = (Rnd() * 255) + 1
                answer = Oct(Decimalanswer)
                questionrandom = (Rnd() * (Decimalanswer - 1)) + 1
                Question.Text = "Add these octal numbers together: " + Oct(questionrandom) + " + " + Oct((Decimalanswer - questionrandom))
            ElseIf questionType = 1 Then 'subtract numbers
                Decimalanswer = (Rnd() * 127) + 1
                answer = Oct(Decimalanswer)
                questionrandom = (Rnd() * 255) + Decimalanswer
                Question.Text = "Subtract these octal numbers: " + Oct(questionrandom) + " - " + Oct((questionrandom - Decimalanswer))
            ElseIf questionType = 2 Then 'multiply numbers
                multiplicationFactor = (Rnd() * (29)) + 1
                questionrandom = Math.Floor(255 / multiplicationFactor)
                answer = Oct(questionrandom * multiplicationFactor)
                Question.Text = "Multiply these octal numbers: " + Oct(questionrandom) + " X " + Oct(multiplicationFactor)
            End If
#End Region
        End If
    End Sub
    Public Sub AsteroidCharacters(x, i)
        If asteroid_array(i).innervalue = x And asteroid_array(i).size = "b" And One1Shown = False Then
            One1Shown = True
            One1.Show()
            Dim originpoint As New Point(asteroid_array(i).startX - 15, asteroid_array(i).startY - 15)
            One1.Location = originpoint
            One1.TabStop = True
            One1.Text = x
        ElseIf asteroid_array(i).innervalue = x And asteroid_array(i).size = "b" And One2Shown = False Then
            One2Shown = True
            One2.Show()
            Dim originpoint As New Point(asteroid_array(i).startX - 15, asteroid_array(i).startY - 15)
            One2.Location = originpoint
            One2.TabStop = True
            One2.Text = x
        ElseIf asteroid_array(i).innervalue = x And asteroid_array(i).size = "b" And Zero1Shown = False Then
            Zero1Shown = True
            Zero1.Show()
            Dim originpoint As New Point(asteroid_array(i).startX - 15, asteroid_array(i).startY - 15)
            Zero1.Location = originpoint
            Zero1.TabStop = True
            Zero1.Text = x
        ElseIf asteroid_array(i).innervalue = x And asteroid_array(i).size = "b" And Zero2Shown = False Then
            Zero2Shown = True
            Zero2.Show()
            Dim originpoint As New Point(asteroid_array(i).startX - 15, asteroid_array(i).startY - 15)
            Zero2.Location = originpoint
            Zero2.TabStop = True
            Zero2.Text = x
        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Tick.Tick
        If lives <= 0 Then
            End
        End If
        mySpaceship.Update() 'update the ship
#Region "asteroids"
        Dim i As Integer = 0
        For Each asteroid In asteroid_array.ToList
            asteroid_array(i).Update(i) 'loop through the asteroids and update them all
            If asteroid_array(i).innervalue <> "z" And (GameMenu.gamemode = "bincal" Or GameMenu.gamemode = "bincon") Then
                AsteroidCharacters(asteroid_array(i).innervalue, i)
            ElseIf asteroid_array(i).innervalue <> "z" And (GameMenu.gamemode = "hexcal" Or GameMenu.gamemode = "hexcon") Then
                AsteroidCharacters(asteroid_array(i).innervalue, i)
            ElseIf asteroid_array(i).innervalue <> "z" And (GameMenu.gamemode = "octcal" Or GameMenu.gamemode = "octcon") Then
                AsteroidCharacters(asteroid_array(i).innervalue, i)
            End If
            i += 1
        Next
        One1Shown = False
        One2Shown = False
        Zero1Shown = False
        Zero2Shown = False
        collides() 'run the collision function in the asteroid sub
        testingspace += 1 'increment this the testing variable
        If testingspace = 3 Then 'if the testing variable makes it to three then revert the background to black
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
            If counter >= 5 And numberOfBullets < 5 Then 'if the bullet spacing is 5 and there are less than 5 bullets
                counter = 0 'reset counter for the spacing
                bullet = New Bullets(mySpaceship.SOa, mySpaceship.SOx, mySpaceship.SOy) 'create a new bullet with the current spaceship x, y and angle
                numberOfBullets = bullet_array.Count
            End If
        End If
#End Region
#Region "bullets"
        If bullet_array.Count > 0 Then

            bullet.update()
        End If
        Dim j As Integer = 0
        For Each bullet In bullet_array
            If bullet.inForm = False Then
                bullet.fin(j)
                bullet_array.RemoveAt(j)
                Exit For
            End If
            j += 1
        Next
#End Region
        If PlayerAnswerVariable <> "" Then
            If AnswerCheck() = False Then
                PlayerAnswerVariable = ""
                Playeranswer.Text = PlayerAnswerVariable
            ElseIf PlayerAnswerVariable.Length = answer.Length Then
                score += 500
                ModeLoader()
                Questions()
            End If
        End If
        If asteroid_array.Count = 0 Then
            level += 1
            numberOfAsteroids = (Rnd() * (7 + level + level)) + (7 + level + level)
            ModeLoader()
        End If
        If score <= 0 Then
            score = 0
        End If
        Invalidate()
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles LevelTimer.Tick
        If GameMenu.gamemode = "fun" Then
            level += 1
            Dim i As Integer = 0
            For Each asteroid In asteroid_array
                asteroid.fin(i)
                i += 1
            Next
            i = 0
            asteroid_array.Clear()
            For Each bullet In bullet_array
                bullet.fin(i)
                i += 1
            Next
            bullet_array.Clear()
            mySpaceship.SOx = Me.Width / 2
            mySpaceship.SOy = Me.Height / 2
            numberOfAsteroids = (Rnd() * (5 + level + level)) + (5 + level + level)
            ModeLoader()
        End If
    End Sub
    Public Function AnswerCheck()
        If PlayerAnswerVariable = answer.Substring(answer.Length - PlayerAnswerVariable.Length, PlayerAnswerVariable.Length) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub collides() 'function for collisions
        angleFunc(mySpaceship.SFx, mySpaceship.SFy, "Ship", 2) 'function for detecting collisions between the front of the ship and the asteroid
        angleFunc(mySpaceship.SLx, mySpaceship.SLy, "Ship", 2) 'detect the left point of the ship
        angleFunc(mySpaceship.SRx, mySpaceship.SRy, "Ship", 2) 'detect the right point of the ship
        For i = 0 To bullet_array.Count - 1 'for loop to go through all the bullets
            If bullet_array(i).inForm = True Then 'if the bullet is on screen then check for collisions
                If angleFunc(bullet_array(i).BFx, bullet_array(i).BFy, "Bull", i) = "hit" Then
                    bullet_array(i).inForm = False
                    numberOfBullets -= 1
                End If
            End If

        Next
    End Sub
    Public Function angleFunc(x, y, type, j)
        For i = 0 To asteroid_array.Count - 1 'loop through all asteroids
            If x > asteroid_array(i).startX - 100 And
               x < asteroid_array(i).startX + 100 And
               y < asteroid_array(i).startY + 100 And
               y > asteroid_array(i).startY - 100 Then
                collideangle = 0  'reset the angle to 0
                Dim a, b, ax, ay, bx, by, dotproduct, thisone As Double
                For j = 0 To asteroid_array(i).numberOfPoints - 2 'loop through the points of the asteroid
                    ax = Math.Abs(x - asteroid_array(i).xPoints(j)) 'calculate the length of one side between the point being tested and the asteroid point
                    ay = Math.Abs(y - asteroid_array(i).yPoints(j)) 'calculate the length of the other side
                    bx = Math.Abs(x - asteroid_array(i).xPoints(j + 1)) 'calculate the length of one side between the point being tested and the next asteroid point
                    by = Math.Abs(y - asteroid_array(i).yPoints(j + 1)) 'calculate the length of the other side
                    a = Math.Sqrt((ax) ^ 2 + (ay) ^ 2) 'calculate the length of the hypotenuse
                    b = Math.Sqrt((bx) ^ 2 + (by) ^ 2) 'calculate the length of the hypotenuse
                    dotproduct = ((ax * bx) + (ay * by)) 'calculate the dot product of the length
                    thisone = Math.Acos(dotproduct / (a * b)) 'take the anti cosign of the dot product divided by the two vectors
                    collideangle += thisone 'add the angle calculated
                Next
                'same calculation for the last and first point
                ax = (x - asteroid_array(i).xPoints(asteroid_array(i).numberOfPoints - 1))
                ay = (y - asteroid_array(i).yPoints(asteroid_array(i).numberOfPoints - 1))
                bx = (x - asteroid_array(i).xPoints(0))
                by = (y - asteroid_array(i).yPoints(0))
                a = Math.Sqrt((ax) ^ 2 + (ay) ^ 2)
                b = Math.Sqrt((bx) ^ 2 + (by) ^ 2)
                dotproduct = ((ax * bx) + (ay * by))
                thisone = Math.Acos(dotproduct / (a * b))
                collideangle += thisone
                If collideangle >= 1.18 * Math.PI Then 'if the angle is greater than 1.18 * math.pi
                    If type = "Ship" Then
                        mySpaceship.SOx = formwidth / 2
                        mySpaceship.SOy = formheight / 2
                        lostasteroids = i
                        Dim temp As Char = asteroid_array(i).innervalue
                        If temp <> "z" Then
                            Zero1.Hide()
                            One1.Hide()
                            Zero2.Hide()
                            One2.Hide()
                        End If
                        PlayerAnswerVariable = ""
                        Playeranswer.Text = PlayerAnswerVariable
                        If GameMenu.gamemode = "fun" Then

                            lives -= 1
                        End If
                    Else
                        hit = True
                        'Form.ActiveForm.BackColor = (Color.Blue)
                        If asteroid_array(i).Asteroidbig = True Then
                            score += 10
                            ScoreBox.Text = "Score: " + score.ToString
                            tempAsteroidx = asteroid_array(i).startX
                            tempAsteroidy = asteroid_array(i).startY
                            Dim temp As Char = asteroid_array(i).innervalue
                            If temp <> "z" Then
                                Zero1.Hide()
                                One1.Hide()
                                Zero2.Hide()
                                One2.Hide()
                                PlayerAnswerVariable = temp.ToString + PlayerAnswerVariable
                                Playeranswer.Text = PlayerAnswerVariable
                                For Each asteroid In asteroid_array
                                    If asteroid.size = "b" And asteroid.innervalue = "z" Then
                                        asteroid.innervalue = temp
                                        Exit For
                                    End If
                                Next
                            End If
                            If GameMenu.gamemode = "bincon" Or GameMenu.gamemode = "bincal" Then 'if binary gamemode
                                For j = 0 To 3 'loop through all asteroids with a value other than z
                                    If Rnd() * 1 = 1 Then '50% chance 
                                        If AnswerSubstringCounter <= answer.Length Then 'if the counter is not grater tha the length
                                            asteroid_array(j).innervalue = answer.Substring(AnswerSubstringCounter, 1) 'make the inner value equalt to  a part of the answer
                                            AnswerSubstringCounter += 1 'increment counter
                                        End If
                                    Else
                                        If Int((Rnd() * 2) + 1) = 1 Then '50/50 of a one or a zero
                                            asteroid.innervalue = "1"
                                        Else
                                            asteroid.innervalue = "0"
                                        End If
                                    End If
                                Next
                                AnswerSubstringCounter = 0
                            ElseIf GameMenu.gamemode = "hexcon" Or GameMenu.gamemode = "hexcal" Then
                                For j = 0 To 3 'loop through all asteroids with a value other than z
                                    If Rnd() * 1 = 1 Then '50% chance 
                                        If AnswerSubstringCounter <= answer.Length Then 'if the counter is not greater than the length
                                            asteroid_array(j).innervalue = answer.Substring(AnswerSubstringCounter, 1) 'make the inner value equal to  a part of the answer
                                            AnswerSubstringCounter += 1 'increment counter
                                        End If
                                    Else
                                        asteroid_array(j).innervalue = Hex(Rnd() * 16)
                                    End If
                                Next
                                AnswerSubstringCounter = 0
                            ElseIf GameMenu.gamemode = "octcon" Or GameMenu.gamemode = "octcal" Then
                                For j = 0 To 3 'loop through all asteroids with a value other than z
                                    If Rnd() * 1 = 1 Then '50% chance 
                                        If AnswerSubstringCounter <= answer.Length Then 'if the counter is not greater than the length
                                            asteroid_array(j).innervalue = answer.Substring(AnswerSubstringCounter, 1) 'make the inner value equalt to  a part of the answer
                                            AnswerSubstringCounter += 1 'increment counter
                                        End If
                                    Else
                                        asteroid_array(j).innervalue = Oct(Rnd() * 16)
                                    End If
                                Next
                                AnswerSubstringCounter = 0
                            End If
                            'If GameMenu.gamemode = "bincon" Or GameMenu.gamemode = "bincal" Then
                            '    For Each asteroid In asteroid_array
                            '        If asteroid.innervalue <> "z" Then
                            '            If Int((Rnd() * 2) + 1) = 1 Then
                            '                asteroid.innervalue = "1"
                            '            Else
                            '                asteroid.innervalue = "0"
                            '            End If
                            '        End If
                            '    Next
                            'ElseIf GameMenu.gamemode = "hexcon" Or GameMenu.gamemode = "hexcal" Then
                            '    For Each asteroid In asteroid_array
                            '        If asteroid.innervalue <> "z" Then
                            '            asteroid.innervalue = Hex((Rnd() * 16))
                            '        End If
                            '    Next
                            'ElseIf GameMenu.gamemode = "octcon" Or GameMenu.gamemode = "octcal" Then
                            '    For Each asteroid In asteroid_array
                            '        If asteroid.innervalue <> "z" Then
                            '            asteroid.innervalue = Oct((Rnd() * 16))
                            '        End If
                            '    Next
                            'End If
                            asteroid.fin(i)
                            asteroid_array.RemoveAt(i)
                            If GameMenu.gamemode = "fun" Then
                                asteroid = New Asteroids("s", "NewS", "z")
                                asteroid = New Asteroids("s", "NewS", "z")
                                asteroid = New Asteroids("s", "NewS", "z")
                                asteroid = New Asteroids("s", "NewS", "z")
                            Else
                                asteroid = New Asteroids("s", "NewS", "z")
                                asteroid = New Asteroids("s", "NewS", "z")
                            End If
                        Else
                            score += 25
                            ScoreBox.Text = "Score: " + score.ToString
                            lostasteroids = i
                            'Dim temp As Char = asteroid_array(i).innervalue
                            'PlayerAnswerVariable = temp.ToString + PlayerAnswerVariable
                            'Playeranswer.Text = PlayerAnswerVariable
                            'For Each asteroid In asteroid_array
                            '    If asteroid.size = "b" And asteroid.innervalue = "z" Then
                            '        asteroid.innervalue = temp
                            '        Exit For
                            '    End If
                            'Next
                        End If
                        Exit For
                    End If
                End If
            Else
                hit = False
            End If
        Next
        If lostasteroids > -1 Then
            asteroid.fin(lostasteroids)
            asteroid_array.RemoveAt(lostasteroids)
        End If
        lostasteroids = -1
        If type = "Bull" And hit = True Then
            Return "hit"
        End If
    End Function
    Function AsteroidAngle(i)
        'numberOfAsteroids number to decide the starting side
        Dim side As Integer = (Rnd() * 3) + 1
        'if side is one then start at top
        If side = 3 Then
            Dim rand As Integer = (Rnd() * formwidth)
            'set the start position somewhere along the top
            asteroid_array(i).startX = rand
            asteroid_array(i).startY = 0
            'if start position is in upper third of top number then 180 to 270
            If rand > ((2 / 3) * formwidth) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.5 * Math.PI)) + Math.PI)
                'if start position is in bottom third of top number then bottom 90 to 180
            ElseIf rand < ((1 / 3) * formwidth) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.5 * Math.PI)) + (0.5 * Math.PI))
                'if start position is in middle third of top number then bottom 90 to 270
            Else
                asteroid_array(i).aAngle = ((Rnd() * (Math.PI)) + (0.5 * Math.PI))
            End If
            'if side is two then start at right
        ElseIf side = 4 Then
            Dim rand As Integer = (Rnd() * formheight)
            'set the start position somewhere along the right
            asteroid_array(i).startX = formwidth
            asteroid_array(i).startY = rand
            'if start position is in upper third of right number then 270 to 360
            If rand > ((2 / 3) * formheight) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.5 * Math.PI)) + (Math.PI * 1.5))
                'if start position is in the bottom third of right number then 180 to 270
            ElseIf rand < ((1 / 3) * formheight) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.5 * Math.PI)) + Math.PI)
                'if the start position is in the middle third of the right number then 180 to 360
            Else
                asteroid_array(i).aAngle = ((Rnd() * (Math.PI)) + (Math.PI))
            End If

        ElseIf side = 1 Then
            Dim rand As Integer = (Rnd() * formwidth)
            asteroid_array(i).startX = rand
            asteroid_array(i).startY = formheight
            'if start position is in upper third of bottom number then 270 to 360
            If rand > ((2 / 3) * formwidth) Then

                asteroid_array(i).aAngle = (Rnd() * (0.2 * Math.PI)) + (1.2 * Math.PI)
                'if start position is in the bottom third of bottom number then 0 to 90
            ElseIf rand < ((1 / 3) * formwidth) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.45 * Math.PI)) + (Math.PI * 1.53))

                'if the start position is in the middle third of the bottom number then 270 to 90
            Else
                asteroid_array(i).aAngle = ((Rnd() * (Math.PI)) + (1.5 * Math.PI))
            End If

        ElseIf side = 2 Then
            Dim rand As Integer = (Rnd() * formheight)
            asteroid_array(i).startX = 0
            asteroid_array(i).startY = rand
            'if start position is in upper third of left number then 0 to 90
            If rand > ((2 / 3) * formheight) Then
                asteroid_array(i).aAngle = (Rnd() * (0.5 * Math.PI))
                'if start position is in the bottom third of right number then 90 to 180
            ElseIf rand < ((1 / 3) * formheight) Then
                asteroid_array(i).aAngle = ((Rnd() * (0.5 * Math.PI)) + (0.5 * Math.PI))
                'if the start position is in the middle third of the right number then 0 to 180
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
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        If e.KeyCode = Keys.P Then
            Ending()
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
    Public Sub Ending()
        brushColor = Color.Black
        Zero1.Location = offscreen
        Zero2.Location = offscreen
        One1.Location = offscreen
        One2.Location = offscreen

        Invalidate()
        Timer.Hide()
        Playeranswer.Show()
        Playeranswer.Text = "Game Over"
        Playeranswer.Location = (abovecentre)
        Question.Show()
        Question.Text = "Your Score: " + score.ToString
        Question.Location = (belowcentre)
        Countdown.Stop()
        Tick.Stop()
        LevelTimer.Stop()
    End Sub
    Private Sub Countdown_Tick(sender As Object, e As EventArgs) Handles Countdown.Tick
        If timeleft > 0 Then
            timeleft -= 1
            iSpan = TimeSpan.FromSeconds(timeleft)
            Timer.Text = iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" &
                        iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                        iSpan.Seconds.ToString.PadLeft(2, "0"c)
        Else
            Ending()
        End If
    End Sub
End Class