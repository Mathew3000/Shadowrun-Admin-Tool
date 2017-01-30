Imports System.Drawing

Public Class Types
    Public Class character
        Public playername As String = "<default>"
        Public name As String = "<default>"
        Public status As String = "alive"
        Public hp As Integer = 100
        Public max_hp As Integer = 100
        Public skill As Integer = 10
        Public reaction As Integer = 10
        Public strength As Integer = 10
        Public willpower As Integer = 10
        Public intuition As Integer = 10
        Public selfcontrol As Integer = 10
        Public armor As Integer = 10
        Public initiative As Integer = 10
        Public wpn_type As String = "melee"
        Public melee_weap As melee_wpn
        Public ranged_weap As ranged_wpn
        Public colour As Color = Color.White
        Public charID As String = "idMe"
    End Class

    Public Class melee_wpn
        Public name As String = "<default>"
        Public damage As Integer = 0
        Public range As Integer = 0
        Public armor_pierce As Integer = 0
    End Class

    Public Class ranged_wpn
        Public name As String = "<default>"
        Public damage As Integer = 0
        Public range As Integer = 0
        Public armor_pierce As Integer = 0
        Public precision As Integer = 0
        Public firemode As Integer = 0
        Public ammo As Integer = 0
    End Class
End Class
