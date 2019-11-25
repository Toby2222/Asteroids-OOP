Public Class Ship
#Region "variables"
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
    Public SOsd As Double    'ship origin delta speed
    Public dsmax As Double    'max delta speed

    'define drag variables of ship
    Public sdrag As Double   'speed drag
#End Region
    Public Sub New()
        'give the points a value to represent the length from the origin to define the size of the ship
        SFl = 34    'ship front length
        SLl = 23    'ship left length
        SRl = 20    'ship right length

        'give the points an angle from the origin point of the ship
        SOa = 0.872664626    'ship origin angle
        SFa = 0    'ship front angle
        SLa = 1.919862177    'ship left angle
        SRa = 4.36332313    'ship right angle
        pSOa = SOa    'define previous spaceship origin angle

        'definine delta angles (rate of change of angle)
        SOad = 0    'ship origin delta angle
        SOsd = 0    'ship origin delta speed
        dsmax = 6    'max delta speed

        'define drag variables of ship
        sdrag = 0.07    'speed drag

    End Sub
    Public Sub Update()
        'update algorithm:
        'ship point x/y = ship origin x/y + cos(ship origin angle) * Ship point length
        'update front point
        Asteroids_Game.mySpaceship.SFx = Asteroids_Game.mySpaceship.SOx + (Math.Cos(Asteroids_Game.mySpaceship.SOa) * Asteroids_Game.mySpaceship.SFl)
        Asteroids_Game.mySpaceship.SFy = Asteroids_Game.mySpaceship.SOy + (Math.Sin(Asteroids_Game.mySpaceship.SOa) * Asteroids_Game.mySpaceship.SFl)
        'update left point
        Asteroids_Game.mySpaceship.SLx = Asteroids_Game.mySpaceship.SOx + (Math.Cos(Asteroids_Game.mySpaceship.SOa + Asteroids_Game.mySpaceship.SLa) * Asteroids_Game.mySpaceship.SLl)
        Asteroids_Game.mySpaceship.SLy = Asteroids_Game.mySpaceship.SOy + (Math.Sin(Asteroids_Game.mySpaceship.SOa + Asteroids_Game.mySpaceship.SLa) * Asteroids_Game.mySpaceship.SLl)
        'update right point
        Asteroids_Game.mySpaceship.SRx = Asteroids_Game.mySpaceship.SOx + (Math.Cos(Asteroids_Game.mySpaceship.SOa + Asteroids_Game.mySpaceship.SRa) * Asteroids_Game.mySpaceship.SRl)
        Asteroids_Game.mySpaceship.SRy = Asteroids_Game.mySpaceship.SOy + (Math.Sin(Asteroids_Game.mySpaceship.SOa + Asteroids_Game.mySpaceship.SRa) * Asteroids_Game.mySpaceship.SRl)
        'update the origin point by the delta of the speed
        Asteroids_Game.mySpaceship.SOx = Asteroids_Game.mySpaceship.SOx + (Math.Cos(Asteroids_Game.mySpaceship.pSOa) * Asteroids_Game.mySpaceship.SOsd)
        Asteroids_Game.mySpaceship.SOy = Asteroids_Game.mySpaceship.SOy + (Math.Sin(Asteroids_Game.mySpaceship.pSOa) * Asteroids_Game.mySpaceship.SOsd)
        'if statement for the drag to slow the ship
        If Asteroids_Game.mySpaceship.SOsd > 0 Then
            Asteroids_Game.mySpaceship.SOsd -= Asteroids_Game.mySpaceship.sdrag
        End If
        'update the angle of the ship
        Asteroids_Game.mySpaceship.SOa += Asteroids_Game.mySpaceship.SOad
        'when the ship leaves the form appear on the opposite side
        If Asteroids_Game.mySpaceship.SOx < 0 Then
            Asteroids_Game.mySpaceship.SOx = Asteroids_Game.formwidth
        End If
        If Asteroids_Game.mySpaceship.SOy < 0 Then
            Asteroids_Game.mySpaceship.SOy = Asteroids_Game.formheight
        End If
        If Asteroids_Game.mySpaceship.SOx > Asteroids_Game.formwidth Then
            Asteroids_Game.mySpaceship.SOx = 0
        End If
        If Asteroids_Game.mySpaceship.SOy > Asteroids_Game.formheight Then
            Asteroids_Game.mySpaceship.SOy = 0
        End If
    End Sub
End Class
