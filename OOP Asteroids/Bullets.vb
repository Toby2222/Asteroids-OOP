﻿Public Class Bullets
#Region "variables"
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
#End Region

    Public Sub New(currentAngle, frontx, fronty) 'sub for instantiating a bullet
        fired = False
        inForm = True
        bLength = 2 'bullets length 2
        bSpeed = 10 'bullet speed 10
        BFx = frontx 'bullet front x = current ship front x passed into the sub
        BFy = fronty 'bullet front y = current ship front y passed into the sub
        BBx = BFx + ((Math.Cos(Asteroids_Game.mySpaceship.SOa)) * bLength) 'back x = front x + angle times length
        BBy = BFy + ((Math.Cos(Asteroids_Game.mySpaceship.SOa)) * bLength) 'backy = front y + angle times length
        bAngle = currentAngle 'bullet angle = current ship angle passed into the sub
        Asteroids_Game.bullet_array.Add(Me) 'add the instantiated bullet object into the array
    End Sub
    Public Sub fire(currentAngle, frontx, fronty, i) 'same as instantiation sub without adding the bullet to an array updating a current bullet
        Asteroids_Game.bullet_array(i).fired = False
        Asteroids_Game.bullet_array(i).inForm = True
        Asteroids_Game.bullet_array(i).BFx = frontx
        Asteroids_Game.bullet_array(i).BFy = fronty
        Asteroids_Game.bullet_array(i).BBx = Asteroids_Game.bullet_array(i).BFx + ((Math.Cos(Asteroids_Game.mySpaceship.SOa)) * bLength)
        Asteroids_Game.bullet_array(i).BBy = Asteroids_Game.bullet_array(i).BFy + ((Math.Cos(Asteroids_Game.mySpaceship.SOa)) * bLength)
        bAngle = currentAngle
    End Sub
    Public Sub update(i)
        'back x = front x + cos(angle)*length
        Asteroids_Game.bullet_array(i).BBx = Asteroids_Game.bullet_array(i).BFx + ((Math.Sin(Asteroids_Game.bullet_array(i).bAngle)) * bLength) 'back x
        Asteroids_Game.bullet_array(i).BBy = Asteroids_Game.bullet_array(i).BFy + ((Math.Cos(Asteroids_Game.bullet_array(i).bAngle)) * bLength) 'back y
        Asteroids_Game.bullet_array(i).BFx = Asteroids_Game.bullet_array(i).BFx + ((Math.Cos(Asteroids_Game.bullet_array(i).bAngle)) * (bSpeed + Asteroids_Game.mySpaceship.SOsd)) 'front x
        Asteroids_Game.bullet_array(i).BFy = Asteroids_Game.bullet_array(i).BFy + ((Math.Sin(Asteroids_Game.bullet_array(i).bAngle)) * (bSpeed + Asteroids_Game.mySpaceship.SOsd)) 'front y
        'if outside the form change the variable
        If Asteroids_Game.bullet_array(i).BFx >= Asteroids_Game.formwidth Or Asteroids_Game.bullet_array(i).BFx < 0 Then
            Asteroids_Game.bullet_array(i).inForm = False
        End If
        If Asteroids_Game.bullet_array(i).BFy >= Asteroids_Game.formheight Or Asteroids_Game.bullet_array(i).BFy < 0 Then
            Asteroids_Game.bullet_array(i).inForm = False
        End If
        'hide the unused bullets off screen
        If Asteroids_Game.bullet_array(i).inForm = False Then
            Asteroids_Game.bullet_array(i).BBx = -1
            Asteroids_Game.bullet_array(i).BBy = -1
            Asteroids_Game.bullet_array(i).BFx = -1
            Asteroids_Game.bullet_array(i).BFy = -1
        End If
    End Sub
End Class
