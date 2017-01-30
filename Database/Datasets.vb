Imports Types.Types

Public Class Datasets
    'Namesets
    Public Shared italy_m() As String = {"Giovanni", "Francesco", "Alessandro", "Lorenzo", "Andrea", "Leonardo", "Mattia", "Matteo", "Gabriele", "Riccardo", "Tommaso", "Giuseppe", "Antonio", "Federico", "Marco", "Samuele", "Diego", "Luca", "Pietro", "Simone", "Nicolo", "Filippo", "Alessio", "Gabriel", "Michele", "Emanuele", "Jacopo"}
    Public Shared italy_f() As String = {"Sofia", "Giulia", "Aurora", "Giorgia", "Martina", "Emma", "Greta", "Chiara", "Sara", "Alice", "Gaia", "Anna", "Francesca", "Ginevra", "Noemi", "Alessia", "Matilde", "Vittoria", "Beatrice", "Nicole", "Giada", "Elisa", "Rebecca", "Arianna", "Mia", "Camilla", "Ludovica", "Maria"}
    Public Shared germany_m() As String = {"Klaus", "Hermann", "Daniel", "Tim", "Lukas", "Lasse", "Nils", "Paul", "Oliver", "Alexander", "Gunnar", "Jan", "Thomas", "Elias", "Sven", "Aaron", "Karl", "Uwe", "Martin", "Jens", "Hannes", "Max", "Sebastian", "Simon", "Peter", "Frank", "Sebastian", "Malte", "Jasper", "Lennard"}
    Public Shared germany_f() As String = {"Michaela", "Carolin", "Emma", "Christina", "Linda", "Dana", "Mia", "Eva", "Ida", "Julia", "Katharina", "Lana", "Daniela", "Anne", "Stella", "Inge", "Saskia", "Marion", "Helga", "Heidi", "Sophie"}
    Public Shared english_m() As String
    Public Shared english_f() As String

    Public Shared selected_nameset As String = "italy_m"
    Public Shared nameset() As String

    'Difficultys
    Public Shared skill_set() As Integer = {0, 0, 1, 2, 3, 5, 4, 6, 16}
    Public Shared reaction_set() As Integer = {0, 1, 1, 2, 3, 5, 4, 6, 16}
    Public Shared strength_set() As Integer = {0, 1, 1, 2, 3, 6, 4, 6, 20}
    Public Shared willpower_set() As Integer = {0, 0, 1, 2, 3, 6, 4, 6, 16}
    Public Shared intuition_set() As Integer = {0, 0, 1, 2, 3, 5, 4, 6, 16}
    Public Shared selfcontrol_set() As Integer = {99, 99, 3, 4, 5, 7, 5, 8, 16}
    Public Shared random_modifier_set() As Integer = {1, 1, 2, 2, 3, 3, 4, 4, 5}

    'Weapons
    Public Shared unarmed As melee_wpn
    Public Shared melee_dull() As melee_wpn
    Public Shared melee_sharp() As melee_wpn
    Public Shared melee_electro() As melee_wpn
    Public Shared ranged_pistol() As ranged_wpn
    Public Shared ranged_mp() As ranged_wpn
    Public Shared ranged_rifle() As ranged_wpn
    Public Shared ranged_shotgun() As ranged_wpn
    Public Shared ranged_machinegun() As ranged_wpn
    Public Shared ranged_precision() As ranged_wpn
    Public Shared ranged_heavy() As ranged_wpn


    'Weapon definitions
    Public Sub init_melee()
        'Unarmed
        unarmed.name = "Ubewaffnet"
        unarmed.damage = -1
        unarmed.range = 0
        unarmed.armor_pierce = 0

        'Melee Dull
        'DemoWeapon
        melee_dull(0).name = "DemoMelee"
        melee_dull(0).damage = 10
        melee_dull(0).range = 1
        melee_dull(0).armor_pierce = 10
    End Sub
    Public Sub init_ranged()
        'Ranged Pistol
        'DemoPistol
        ranged_pistol(0).name = "DemoPistol"
        ranged_pistol(0).damage = 10
        ranged_pistol(0).range = 5
        ranged_pistol(0).armor_pierce = 10
        'Ranged MP
        'DemoMP
        ranged_mp(0).name = "DemoMP"
        ranged_mp(0).damage = 10
        ranged_mp(0).range = 4
        ranged_mp(0).armor_pierce = 10
    End Sub

End Class