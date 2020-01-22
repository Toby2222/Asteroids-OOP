Public Class Asteroids_Game
#Region "variables"
    'creating all the objects
    Public mySpaceship As Ship = New Ship 'ship object
    Public asteroid As Asteroids 'asteroid object
    Public asteroid_array As New List(Of Asteroids) 'array of asteroid objects
    Public bullet As Bullets 'bullet object
    Public bullet_array As New List(Of Bullets)(4) 'array of bullet objects

    'get the size of the form
    Public formwidth As Integer 'width of the form given a value once loaded
    Public formheight As Integer 'height of the form given a value once loaded

    'asteroid variables
    Public numberOfAsteroids As Integer 'the number of the asteroids loaded each time the game is loaded, given a value dependant on mode and level later in program
    Public tempAsteroidx As Double 'a temporary storage of the centre coordinates of the asteroid used when a big asteroid is destroyed, to give the 'children' asteroids the same start coordinates
    Public tempAsteroidy As Double
    Public destroyed As Integer = 0 'integer for number of small asteroids destroyed
    Public lostasteroids As Integer = -1 'stores the position in the array of the asteroid that needs to be removed from the array
    Public speedFactor As Double = 1 'factor for speed
    Public allsmall As Boolean = False

    'bullet variables
    Public counter As Integer 'a counter to decide the spacing between bullets
    Public numberOfBullets As Integer = 0 'declare a variable that will hold the number of bullets at every moment of hte program
    Public hit As Boolean = False 'boolean for whether an asteroid has been hit, if the asteroid has been hit, then remove it

    'collision variables
    Public collideangle As Double 'define a variable for calculating the angles between the asteroids and other objects

    'boolean for keys
    Public up As Boolean = False
    Public left As Boolean = False
    Public right As Boolean = False
    Public space As Boolean = False

    'additional function variables
    Public score As Integer = 0 'declare a variable for storing the score of the user
    Public lives As Integer = 3 'declare and define a variable for lives
    Public level As Integer = 0 'declare and define a variable for the level to be changed within the program
    Public PlayerAnswerVariable As String = "" 'declare a variable for the string that the user builds up when answering define as "" for checking
    Public answer As String 'declare a variable for the actual answer to be compared against
    Public Decimalanswer As Integer 'declare a variable that is the decimal version of the answer to be converted between number bases and into a string for checking
    Public multiplicationfactor As Integer
    Public questionrandom As Integer 'stores the random number used in the questions
    Public questionType As Integer 'stores the number representing the type of question being generated

    'booleans for deciding which label to use for storing the characters
    Public One1Shown As Boolean = False
    Public One2Shown As Boolean = False
    Public Zero1Shown As Boolean = False
    Public Zero2Shown As Boolean = False
    Public timeleft As Double = 600 'Total number of seconds of the educational modes before game ends
    Public iSpan As TimeSpan = TimeSpan.FromSeconds(timeleft) 'used to represent the 600 seconds as minutes and seconds
    'declare the points that represent where the gameover screen will position
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
        Dim brush As Brush 'create a brush object
        brush = New SolidBrush(brushColor) 'give the brush a color 
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
        Dim i As Integer = 0 'create a counter
        For Each asteroid In asteroid_array 'destroy all the asteroids
            asteroid.fin(i)
            i += 1
        Next
        asteroid_array.Clear() 'clear the array
        speedFactor = 0.65
        'put the formatting for the timer into the text box
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
            Playeranswer.Text = ""
        Else 'if fun is chosen then hide the timer,question,playeranswer and the textboxes containing characters
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
        Dim i As Integer = 0 'create a counter
        For Each asteroid In asteroid_array 'destroy all the asteroids
            asteroid.fin(i)
            i += 1
        Next
        asteroid_array.Clear() 'clear the array
        For i = 0 To numberOfAsteroids - 1 'loop through all the asteroids
            If GameMenu.gamemode = "bincal" Or GameMenu.gamemode = "bincon" Then 'if a binary gamemode is chosen, give the asteroids a character value of 1, 0 or z
                If i = 0 Then '0,1,2,3 will contain binary digits that will be displayed in the text boxes 4 and above will contain a z which will not be displayed
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
            ElseIf GameMenu.gamemode = "hexcal" Or GameMenu.gamemode = "hexcon" Then 'if a hex gamemode is chosen then same as binary but with hex characters
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
            ElseIf GameMenu.gamemode = "octcal" Or GameMenu.gamemode = "octcon" Then ' same but octal characters
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
                asteroid = New Asteroids("b", "NewB", "z") 'all asteroids are given a value of z if fun is chosen
            End If
        Next
    End Sub
    Public Function binaryconvert(x, y) 'sub for converting numbers into binary, reuse this sub multiple times
        Return Convert.ToString(x, 2).ToString.PadLeft(y, "0")
    End Function
    Public Sub Questions()
        If GameMenu.gamemode = "bincal" Or GameMenu.gamemode = "hexcal" Or GameMenu.gamemode = "octcal" Then
            If level < 2 Then
                questionType = 0 'find which question type to generate
            ElseIf level < 5 Then
                questionType = 1
            ElseIf level < 7 Then
                questionType = 2
            Else
                questionType = Rnd() * 2
            End If
        Else
            If level < 2 Then
                questionrandom = (Rnd() * 15) + 1
            ElseIf level < 5 Then
                questionrandom = (Rnd() * 63) + 1
            Else
                questionrandom = (Rnd() * 254) + 1
            End If
        End If
#Region "binary conversions"
        If GameMenu.gamemode = "bincon" Then 'if binary conversion is chosen
            If questionType = 0 Then
                Question.Text = "Convert this decimal number into a binary number: " + questionrandom.ToString 'output the random number as a decimal
                If level < 2 Then
                    answer = binaryconvert(questionrandom, 4) 'convert the question to binary ans save the answer
                Else
                    answer = binaryconvert(questionrandom, 8) 'convert the question to binary ans save the answer
                End If
            ElseIf questionType = 1 Then
                Question.Text = "Convert this hexadecimal number into a binary number: " + Hex(questionrandom).ToString 'output the random number as a hex number
                If level < 2 Then
                    answer = binaryconvert(questionrandom, 4) 'convert the question to binary ans save the answer
                Else
                    answer = binaryconvert(questionrandom, 8) 'convert the question to binary ans save the answer
                End If
            ElseIf questionType = 2 Then
                Question.Text = "Convert this octal number into a binary number: " + Oct(questionrandom).ToString 'output the number as an octal number
                If level < 2 Then
                    answer = binaryconvert(questionrandom, 4) 'convert the question to binary ans save the answer
                Else
                    answer = binaryconvert(questionrandom, 8) 'convert the question to binary ans save the answer
                End If
            End If
#End Region
#Region "binary calculations"
        ElseIf GameMenu.gamemode = "bincal" Then 'if binary calculations is chosen
            questionType = Rnd() * 1
            If questionType = 0 Then 'add numbers
                Decimalanswer = (Rnd() * 255) + 1 'generate the decimal answer less than 256
                answer = binaryconvert(Decimalanswer, 8) 'convert the answer to binary
                questionrandom = (Rnd() * (Decimalanswer - 1)) + 1 'generate a random number less than the answer
                Question.Text = "Add these binary numbers together: " + binaryconvert(questionrandom, 8) + " + " + binaryconvert((Decimalanswer - questionrandom), 8) 'output the random number and calculate the other number in the calculation
            ElseIf questionType = 1 Then 'subtract numbers
                Decimalanswer = (Rnd() * 127) + 1 'generate the decimal answer less than 127
                answer = binaryconvert(Decimalanswer, 8) 'convert the answer to binary
                questionrandom = (Rnd() * 128) + Decimalanswer ' generate a number between the answer and 128 more max of 255
                Question.Text = "Subtract these binary numbers : " + binaryconvert(questionrandom, 8) + " - " + binaryconvert((questionrandom - Decimalanswer), 8) 'output the random number and calculate the other half of the calculation
            ElseIf questionType = 2 Then 'multiply numbers
                multiplicationfactor = (Rnd() * (29)) + 1
                questionrandom = Math.Floor(255 / multiplicationfactor)
                answer = binaryconvert((questionrandom * multiplicationfactor), 8)
                Question.Text = "Multiply these binary numbers together: " + binaryconvert(questionrandom, 8) + " X " + binaryconvert(multiplicationfactor, 8)
            End If
#End Region
#Region "hex conversions"
        ElseIf GameMenu.gamemode = "hexcon" Then 'if hexadecimal conversion is chosen - all same as binary except converted to hex
            questionType = Rnd() * 2
            If questionType = 0 Then
                Question.Text = "Convert this decimal number into a hex number: " + questionrandom.ToString
                answer = Hex(questionrandom)
            ElseIf questionType = 1 Then
                Question.Text = "Convert this binary number into a hex number: " + binaryconvert(questionrandom, 8)
                answer = Hex(Int(binaryconvert(questionrandom, 8)))

            ElseIf questionType = 2 Then
                Question.Text = "Convert this octal number into a hex number: " + Oct(questionrandom).ToString
                answer = Hex(Oct(questionrandom))

            End If
#End Region
#Region "hex calculations"
        ElseIf GameMenu.gamemode = "hexcal" Then 'if hex calculations is chosen - same as binary calculations but converted to hexadecimal
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
                multiplicationfactor = (Rnd() * (29)) + 1
                questionrandom = Math.Floor(255 / multiplicationfactor)
                answer = Hex(questionrandom * multiplicationfactor)
                Question.Text = "Multiply these hexadecimal numbers: " + Hex(questionrandom) + " X " + Hex(multiplicationfactor)
            End If
#End Region
#Region "octal conversions"
        ElseIf GameMenu.gamemode = "octcon" Then 'if octal conversion is chosen - binary conversion but octal numbers
            questionType = Rnd() * 2
            If questionType = 0 Then
                Question.Text = "Convert this decimal number into an octal number: " + questionrandom.ToString
                answer = Oct(questionrandom)
            ElseIf questionType = 1 Then
                Question.Text = "Convert this binary number into an octal number: " + binaryconvert(questionrandom, 8)
                answer = Oct(Int(binaryconvert(questionrandom, 8)))

            ElseIf questionType = 2 Then
                Question.Text = "Convert this hex number into an octal number: " + Hex(questionrandom).ToString
                answer = Oct(Hex(questionrandom))

            End If
#End Region
#Region "octal calculations"
        ElseIf GameMenu.gamemode = "octcal" Then 'if octal calculations is chosen - binary calculations but octal numbers
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
                multiplicationfactor = (Rnd() * (29)) + 1
                questionrandom = Math.Floor(255 / multiplicationfactor)
                answer = Oct(questionrandom * multiplicationfactor)
                Question.Text = "Multiply these octal numbers: " + Oct(questionrandom) + " X " + Oct(multiplicationfactor)
            End If
#End Region
        End If
    End Sub
    Public Sub AsteroidCharacters(x, i)
        If asteroid_array(i).size = "b" And One1Shown = False Then 'if the asteroid is big and the label is  not already shown
            One1Shown = True 'set the label as shown
            One1.Show() 'show the label
            Dim originpoint As New Point(asteroid_array(i).startX - 15, asteroid_array(i).startY - 15) 'create point for the asteroid centre point
            One1.Location = originpoint ' set the location to the centre point of the asteroid
            One1.TabStop = True 'disallow the user from tabbing to the label
            One1.Text = x 'make the text = the value passed into the function
        ElseIf asteroid_array(i).size = "b" And One2Shown = False Then 'same as one1
            One2Shown = True
            One2.Show()
            Dim originpoint As New Point(asteroid_array(i).startX - 15, asteroid_array(i).startY - 15)
            One2.Location = originpoint
            One2.TabStop = True
            One2.Text = x
        ElseIf asteroid_array(i).size = "b" And Zero1Shown = False Then 'same as one1
            Zero1Shown = True
            Zero1.Show()
            Dim originpoint As New Point(asteroid_array(i).startX - 15, asteroid_array(i).startY - 15)
            Zero1.Location = originpoint
            Zero1.TabStop = True
            Zero1.Text = x
        ElseIf asteroid_array(i).size = "b" And Zero2Shown = False Then 'same as one1
            Zero2Shown = True
            Zero2.Show()
            Dim originpoint As New Point(asteroid_array(i).startX - 15, asteroid_array(i).startY - 15)
            Zero2.Location = originpoint
            Zero2.TabStop = True
            Zero2.Text = x
        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Tick.Tick 'timer that is called every 15 milliseconds
        If lives <= 0 Then 'if the user has run out of lives end the game
            Ending() 'call the subroutine for ending the game
        End If
        mySpaceship.Update() 'update the ship
#Region "asteroids"
        Dim i As Integer = 0 'create a counter variable for the for each loop
        For Each asteroid In asteroid_array.ToList
            asteroid.Update(i) 'update the asteroids
            If asteroid_array(i).innervalue <> "z" Then 'if the value is not z present the charater in the appropriate asteroid by calling the character subroutine
                AsteroidCharacters(asteroid_array(i).innervalue, i) 'pass the character subroutine the value of the asteroid and its position in the array
            End If
            i += 1 'incremement the counter
        Next
        For Each asteroid In asteroid_array.ToList
            If asteroid.size = "s" Then
                allsmall = True
            Else
                allsmall = False
                Exit For
            End If
        Next
        If allsmall = True Then
            allsmall = False
            ModeLoader()
        End If
        'declare the labels as unused again
        One1Shown = False
        One2Shown = False
        Zero1Shown = False
        Zero2Shown = False
        collides() 'run the collision subroutine
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
        If bullet_array.Count > 0 Then 'if there is a bullet in the array update it
            bullet.update()
        End If
        Dim j As Integer = 0 'create a counter variable for the for each
        For Each bullet In bullet_array
            If bullet.inForm = False Then 'if the bullet is not in the form deconstruct the object and remove it from the array
                bullet.fin(j)
                bullet_array.RemoveAt(j)
                Exit For
            End If
            j += 1 'increment the counter
        Next
#End Region
        If PlayerAnswerVariable <> "" Then 'if there is an answer check it
            If AnswerCheck() = False Then 'if the check function return false reset the answer to "" and reset the displayed string
                PlayerAnswerVariable = ""
                Playeranswer.Text = PlayerAnswerVariable
            ElseIf AnswerCheck() = True And PlayerAnswerVariable.Length = answer.Length Then 'if the function returns true and the length of the answer is correct add to the score and generate a new question
                score += 500
                level += 1
                ModeLoader() 'reload the mode
                Questions() 'generate a new question
            End If
        End If
        If asteroid_array.Count = 0 Then 'if there are more asteroids in the array (they've all been destroyed)
            level += 1 'increment the level
            numberOfAsteroids = (Rnd() * (7 + level + level)) + (7 + level + level) 'increase the number of asteroids generated by more each time the level increases
            ModeLoader() 'load the mode selected
        End If
        If score <= 0 Then 'don't allow the score to drop below 0
            score = 0
            ScoreBox.Text = score.ToString
        End If
        Invalidate() 'redraw everything
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles LevelTimer.Tick 'timer that is called every two minutes
        If GameMenu.gamemode = "fun" Then 'if fun is chosen
            level += 1 'increment level
            Dim i As Integer = 0 'create counter
            For Each asteroid In asteroid_array 'destroy all the asteroids
                asteroid.fin(i)
                i += 1
            Next
            i = 0 'reet the counter
            asteroid_array.Clear() 'clear the array
            For Each bullet In bullet_array 'destroy all the bullet object
                bullet.fin(i)
                i += 1
            Next
            bullet_array.Clear() 'clear the bullet array
            'set the ship to the centre
            mySpaceship.SOx = Me.Width / 2
            mySpaceship.SOy = Me.Height / 2
            'increase the number of asteroids dependant on the level
            numberOfAsteroids = (Rnd() * (7 + level + level)) + (7 + level + level)
            ModeLoader() 'reload the appropriate gamemode
        End If
    End Sub
    Public Function AnswerCheck()
        'if the string being built up by the user is equal to that part of the answer then return true, else return false
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
                If angleFunc(bullet_array(i).BFx, bullet_array(i).BFy, "Bull", i) = "hit" Then 'if the bullet has registered a hit on a ship
                    bullet_array(i).inForm = False 'register it as off screen to be removed in the tick
                    numberOfBullets -= 1 'decrease the number of bullets
                End If
            End If

        Next
    End Sub
    Public Function angleFunc(x, y, type, j)
        For i = 0 To asteroid_array.Count - 1 'loop through all asteroids
            'if the point being tested is within 100 pixels of the centre point of the asteroid then continue otherwise stop calculating
            If x > asteroid_array(i).startX - 100 And
               x < asteroid_array(i).startX + 100 And
               y < asteroid_array(i).startY + 100 And
               y > asteroid_array(i).startY - 100 Then
                collideangle = 0  'reset the angle to 0
                Dim a, b, ax, ay, bx, by, dotproduct, thisone As Double 'define all the temporary variable needed for this collision
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
                    If type = "Ship" Then 'if the collision object is the ship
                        'set the ship location to the centre of the screen
                        mySpaceship.SOx = formwidth / 2
                        mySpaceship.SOy = formheight / 2
                        'set the current asteroid to be removed in later
                        lostasteroids = i
                        Dim temp As Char = asteroid_array(i).innervalue
                        If temp <> "z" Then 'if the value is not z hide all the labels
                            Zero1.Hide()
                            One1.Hide()
                            Zero2.Hide()
                            One2.Hide()
                        End If
                        PlayerAnswerVariable = "" 'reset the player's answer
                        Playeranswer.Text = PlayerAnswerVariable 'update the displayed string
                        If GameMenu.gamemode = "fun" Then 'if fun remove a life
                            lives -= 1
                        End If
                    Else
                        hit = True
                        If asteroid_array(i).Asteroidbig = True Then
                            score += 10
                            ScoreBox.Text = "Score: " + score.ToString
                            tempAsteroidx = asteroid_array(i).startX
                            tempAsteroidy = asteroid_array(i).startY
                            Dim temp As Char = asteroid_array(i).innervalue 'save the inner value of the asteroid
                            If temp <> "z" Then 'if the value is not z hide all labels
                                Zero1.Hide()
                                One1.Hide()
                                Zero2.Hide()
                                One2.Hide()
                                PlayerAnswerVariable = temp.ToString + PlayerAnswerVariable 'add the value to their answer and display
                                Playeranswer.Text = PlayerAnswerVariable
                                For Each asteroid In asteroid_array 'for every asteroid
                                    If asteroid.size = "b" And asteroid.innervalue = "z" Then 'If The inner value Is z keep the inner value of the new asteroid as z
                                        asteroid.innervalue = temp
                                        Exit For
                                    End If
                                Next
                            End If
                            asteroid.fin(i)
                            asteroid_array.RemoveAt(i)
                            If GameMenu.gamemode = "fun" Then 'if the gamemode is fun generate four new small asteroid
                                asteroid = New Asteroids("s", "NewS", "z")
                                asteroid = New Asteroids("s", "NewS", "z")
                                asteroid = New Asteroids("s", "NewS", "z")
                                asteroid = New Asteroids("s", "NewS", "z")
                            Else 'if not fun generate two new small asteroids
                                asteroid = New Asteroids("s", "NewS", "z")
                                asteroid = New Asteroids("s", "NewS", "z")
                            End If
                        Else 'if a small asteroid has been shot
                            score += 25 'increment score by 25
                            ScoreBox.Text = "Score: " + score.ToString 'display new score
                            lostasteroids = i 'register the current asteroid as destroy to be removed
                        End If
                        If GameMenu.gamemode = "bincon" Or GameMenu.gamemode = "bincal" Then 'if binary gamemode
                            For j = 0 To 3 'loop through all asteroids with a value other than z
                                If Rnd() * 2 = 1 Then
                                    If Int((Rnd() * 2) + 1) = 1 Then '50/50 of a one or a zero
                                        asteroid.innervalue = "1"
                                    Else
                                        asteroid.innervalue = "0"
                                    End If
                                Else
                                    If AnswerSubstringCounter <= answer.Length Then 'if the counter is not grater tha the length
                                        asteroid_array(j).innervalue = answer.Substring(AnswerSubstringCounter, 1) 'make the inner value equalt to  a part of the answer
                                        AnswerSubstringCounter += 1 'increment counter
                                    End If
                                End If
                            Next
                            AnswerSubstringCounter = 0
                        ElseIf GameMenu.gamemode = "hexcon" Or GameMenu.gamemode = "hexcal" Then
                            For j = 0 To 3 'loop through all asteroids with a value other than z
                                If Rnd() * 2 = 1 Then
                                    asteroid_array(j).innervalue = Hex(Rnd() * 16)
                                Else
                                    If AnswerSubstringCounter <= answer.Length Then 'if the counter is not greater than the length
                                        asteroid_array(j).innervalue = answer.Substring(AnswerSubstringCounter, 1) 'make the inner value equal to  a part of the answer
                                        AnswerSubstringCounter += 1 'increment counter
                                    End If
                                End If
                            Next
                            AnswerSubstringCounter = 0
                        ElseIf GameMenu.gamemode = "octcon" Or GameMenu.gamemode = "octcal" Then
                            For j = 0 To 3 'loop through all asteroids with a value other than z
                                If Rnd() * 2 = 1 Then
                                    asteroid_array(j).innervalue = Oct(Rnd() * 16)
                                Else
                                    If AnswerSubstringCounter <= answer.Length Then 'if the counter is not greater than the length
                                        asteroid_array(j).innervalue = answer.Substring(AnswerSubstringCounter, 1) 'make the inner value equalt to  a part of the answer
                                        AnswerSubstringCounter += 1 'increment counter
                                    End If
                                End If
                            Next
                            AnswerSubstringCounter = 0
                        End If
                        Exit For
                    End If
                End If
            Else 'if not a bullet
                hit = False 'hit = false
            End If
        Next
        If lostasteroids > -1 Then 'if there is a value in lost asteroids
            asteroid.fin(lostasteroids) 'destroy the asteroid
            asteroid_array.RemoveAt(lostasteroids) 'remove the asteroid
        End If
        lostasteroids = -1 'reset lost asteroid
        If type = "Bull" And hit = True Then 'if a bullet hit an asteroid
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
    Public Sub Ending()
        brushColor = Color.Black
        Zero1.Location = offscreen
        Zero2.Location = offscreen
        One1.Location = offscreen
        One2.Location = offscreen
        Invalidate()
        ScoreBox.Hide()
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
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim i As Integer = 0 'create a counter
        For Each asteroid In asteroid_array 'destroy all the asteroids
            asteroid.fin(i)
            i += 1
        Next
        asteroid_array.Clear() 'clear the array
        GameMenu.GameMenu_Reload()
    End Sub
End Class
