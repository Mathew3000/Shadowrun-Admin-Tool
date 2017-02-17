Imports Types.Types
Imports Database.Datasets

'Search for FixMe!!!

Public Class Main
    'Selected Chars
    Dim selected_char As Integer = 0
    Dim selected_enemy As Integer = 0
    'Selected TextBox
    Dim selected_text As Integer = 0
    'Character Items
    Public Shared enemys As New List(Of character)
    Public Shared players As New List(Of character)
    'TextBox Items
    Public Shared texts As New List(Of info_text)
    'UI-Elements
    Public Shared admin_screen_items As New List(Of Panel)
    Public Shared player_screen_items As New List(Of Panel)
    Public Shared info_text_boxes As New List(Of Panel)
    'Generation Paramenter
    Dim difficulty As Integer = 0

    'Generate a random value
    Public Function randomval(lowerbound As Integer, upperbound As Integer)
        Dim value As Integer = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        Return value
    End Function

    'Create random enemy(s)
    Private Sub bt_rand_Click(sender As Object, e As EventArgs) Handles bt_rand.Click
        Dim input As Object
        Dim default_input As Integer = 1
        Dim length As Integer
        Dim message, title As String

        If selected_nameset = "italy_m" Then
            nameset = italy_m
        ElseIf selected_nameset = "italy_f" Then
            nameset = italy_f
        ElseIf selected_nameset = "germany_m" Then
            nameset = germany_m
        ElseIf selected_nameset = "germany_f" Then
            nameset = germany_f
        ElseIf selected_nameset = "english_m" Then
            nameset = english_m
        ElseIf selected_nameset = "english_f" Then
            nameset = english_f
        End If

        length = nameset.Length

        message = "Anzahl der Gegner? (1-15)"
        title = "Wie viele?"

        input = InputBox(message, title, default_input)
        If input Is "" Then input = default_input

        'Characters
        For i As Integer = 0 To Int(input) - 1
            Dim name_int = randomval(0, length - 1)
            Dim rnd = random_modifier_set(difficulty)
            Dim tmp_enemy As New character
            Dim player_item As Panel
            Dim admin_item As Panel

            'Preinitialise
            enemys.Add(New character)
            'Set Enemy Name
            enemys(i).name = nameset(name_int)
            'Set Skill according to Difficulty
            enemys(i).skill = skill_set(difficulty) + randomval(0, rnd)
            'Set Reaction according to Difficulty
            enemys(i).reaction = reaction_set(difficulty) + randomval(0, rnd)
            'Set Streangth according to Difficulty
            enemys(i).strength = strength_set(difficulty) + randomval(0, rnd)
            'Set Willpower according to Difficulty
            enemys(i).willpower = willpower_set(difficulty) + randomval(0, rnd)
            'Set Intuition according to Difficulty
            enemys(i).intuition = intuition_set(difficulty) + randomval(0, rnd)
            'Set SelfControl according to Difficulty
            enemys(i).selfcontrol = selfcontrol_set(difficulty) + randomval(0, rnd)
            'Set Charisma according to Difficulty
            enemys(i).charisma = charisma_set(difficulty) + randomval(0, rnd)
            'Set Constitution according to Difficulty
            enemys(i).constitution = constitution_set(difficulty) + randomval(0, rnd)
            'Calculate HP
            enemys(i).max_hp = 8 + Math.Ceiling(enemys(i).constitution / 2)
            enemys(i).hp = enemys(i).max_hp
            'Calculate Psychic Strength
            enemys(i).psychic_max = 8 + Math.Ceiling(enemys(i).willpower / 2)
            enemys(i).psychic = enemys(i).psychic_max
            'Calculate Initiative
            enemys(i).initiative = enemys(i).intuition + enemys(i).intuition + randomval(0, rnd)
            'Declare as enemy
            enemys(i).playername = "NPC"

            'Generate enemy ID
            enemys(i).charID = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
            System.Threading.Thread.Sleep(1)
            'Add Enemy to List
            list_enemys.Items.Add(enemys(i).name & " ( " & enemys(i).hp & " | " & enemys(i).max_hp & " ) ")

            'Create a Player Item 
            player_item = New Panel
            player_item.BackColor = Color.Fuchsia
            player_item.Visible = False
            player_item.Location = New Point(50 + (2 * i), 50 + (2 * i))
            player_item.Size = New Size(25, 25)
            player_item.Name = enemys(i).charID
            player_item.BorderStyle = BorderStyle.FixedSingle
            'Add the Playeritem to the Player Screen List
            player_screen_items.Add(player_item)

            'Create an Admin Item
            admin_item = New Panel
            admin_item.Size = New Size(15, 15)
            admin_item.Location = New Point(25 + i, 25 + i)
            admin_item.Visible = True
            admin_item.Name = enemys(i).charID
            admin_item.BorderStyle = BorderStyle.FixedSingle
            admin_item.BackColor = Color.Fuchsia
            admin_item.Cursor = Cursors.Cross
            AddHandler admin_item.MouseDown, AddressOf AdminWindow.drag_handler
            AddHandler admin_item.MouseUp, AddressOf AdminWindow.mouse_up_handler
            AddHandler admin_item.Click, AddressOf AdminWindow.mouse_click_handler
            AddHandler admin_item.MouseHover, AddressOf AdminWindow.tt_open_enemy
            admin_item.ContextMenuStrip = AdminWindow.menu_players

            'Add the Adminitem to the Admin Screen List
            admin_screen_items.Add(admin_item)

            'Clear Variables
            admin_item = Nothing
            player_item = Nothing
        Next
    End Sub

    'Nameset changed
    Private Sub cb_nameset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_nameset.SelectedIndexChanged
        If cb_nameset.Text = "Italienisch (m)" Then
            selected_nameset = "italy_m"
        ElseIf cb_nameset.Text = "Italienisch (w)" Then
            selected_nameset = "italy_f"
        ElseIf cb_nameset.Text = "Deutsch (m)" Then
            selected_nameset = "germany_m"
        ElseIf cb_nameset.Text = "Deutsch (w)" Then
            selected_nameset = "germany_f"
        ElseIf cb_nameset.Text = "Englisch (m)" Then
            selected_nameset = "english_m"
        ElseIf cb_nameset.Text = "Englisch (w)" Then
            selected_nameset = "english_f"
        End If
    End Sub

    'Difficulty changed
    Private Sub cb_difficulty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_difficulty.SelectedIndexChanged
        If (cb_difficulty.SelectedIndex > 3) Then
            difficulty = cb_difficulty.SelectedIndex - 4
        ElseIf (cb_difficulty.SelectedIndex = 4) Then
            difficulty = 0
        Else
            'FixMe
            difficulty = 0
        End If
    End Sub

    'Change Player colour
    Private Sub pan_colour_Click(sender As Object, e As EventArgs) Handles pan_colour.Click
        col_diag_player.ShowDialog()
        pan_colour.BackColor = col_diag_player.Color
        If (selected_char >= 0) Then
            Dim currentID As String = players(selected_char).charID
            Dim player_object As Panel = CType(PlayerMap.Controls(currentID), Panel)
            Dim admin_object As Panel = CType(AdminWindow.Controls(currentID), Panel)
            players(selected_char).colour = col_diag_player.Color
            player_object.BackColor = col_diag_player.Color
            'player_object.Visible = True
            player_object.BringToFront()
            admin_object.BackColor = col_diag_player.Color
            admin_object.BringToFront()
        End If
    End Sub

    'Add Player Character
    Private Sub bt_add_char_Click(sender As Object, e As EventArgs) Handles bt_add_char.Click
        Dim new_player As character = New character
        Dim player_item As New Panel
        Dim admin_item As New Panel

        new_player.charID = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds

        players.Add(new_player)
        list_player.Items.Add(new_player.name)

        'Create Playeritem for Player
        player_item.BackColor = Color.White
        player_item.Visible = False
        player_item.Location = New Point(50, 50)
        player_item.Size = New Size(25, 25)
        player_item.Name = new_player.charID
        player_item.BorderStyle = BorderStyle.FixedSingle
        'Add the Playeritem to the Player Screen List
        player_screen_items.Add(player_item)

        'Create Adminitem for Player
        admin_item.Size = New Size(15, 15)
        admin_item.Location = New Point(25, 25)
        admin_item.Visible = True
        admin_item.Name = new_player.charID
        admin_item.BorderStyle = BorderStyle.FixedSingle
        admin_item.BackColor = Color.White
        admin_item.Cursor = Cursors.Cross
        AddHandler admin_item.MouseDown, AddressOf AdminWindow.drag_handler
        AddHandler admin_item.MouseUp, AddressOf AdminWindow.mouse_up_handler
        AddHandler admin_item.Click, AddressOf AdminWindow.mouse_click_handler
        AddHandler admin_item.MouseHover, AddressOf AdminWindow.tt_open_enemy
        admin_item.ContextMenuStrip = AdminWindow.menu_players
        'Add the Adminitem to the Admin Screen List
        admin_screen_items.Add(admin_item)

    End Sub

    'Player selected
    Private Sub list_player_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_player.SelectedIndexChanged
        If (list_player.SelectedIndex >= 0)
            selected_char = list_player.SelectedIndex
            txt_playername.Text = players(selected_char).playername
            txt_charname.Text = players(selected_char).name
            txt_initiative.Text = players(selected_char).initiative
            pan_colour.BackColor = players(selected_char).colour
        End If
    End Sub
    'Player name changed
    Private Sub txt_playername_TextChanged(sender As Object, e As EventArgs) Handles txt_playername.TextChanged
        If ((players.Count) < 1) Then
            Return
        Else
            players(selected_char).playername = txt_playername.Text
        End If
    End Sub
    'Player Charactername changed
    Private Sub txt_charname_TextChanged(sender As Object, e As EventArgs) Handles txt_charname.TextChanged
        If (players.Count < 1) Then
            Return
        Else
            players(selected_char).name = txt_charname.Text
            list_player.Items(selected_char) = txt_charname.Text
        End If
    End Sub
    'Player initiative changed
    Private Sub txt_initiative_TextChanged(sender As Object, e As EventArgs) Handles txt_initiative.TextChanged
        If (players.Count < 1) Then
            Return
        Else
            Try
                players(selected_char).initiative = txt_initiative.Text
            Catch
                MsgBox("Not a Number", MessageBoxButtons.OK, "Wrong input")
            End Try
        End If
    End Sub
    'Delete Player
    Private Sub bt_del_char_Click(sender As Object, e As EventArgs) Handles bt_del_char.Click
        If (selected_char < players.Count) Then
            Dim currentID As String = players(selected_char).charID
            Dim player_object As Panel = CType(PlayerMap.Controls(currentID), Panel)
            players.RemoveAt(selected_char)
            list_player.Items.RemoveAt(selected_char)
            Try
                player_object.Visible = False
            Catch
                MsgBox("Could not delete Char from Map", MessageBoxButtons.OK, "Error!")
            End Try
        End If
    End Sub

    'Roll some D6
    Private Sub bt_w_6_Click(sender As Object, e As EventArgs) Handles bt_w_6.Click
        If (txt_count_w_6.Text <> "") Then
            Dim count As Integer = 0
            Dim number As Integer = 0
            list_w_6.Items.Clear()
            list_count_w6.Items.Clear()
            For i As Integer = 0 To 5
                list_w_6.Items.Add(0)
                list_count_w6.Items.Add(i + 1)
            Next
            Try
                count = txt_count_w_6.Text
                For i As Integer = 1 To count
                    Randomize()
                    number = CInt(Int((6 * Rnd()) + 1))
                    list_w_6.Items(number - 1) = list_w_6.Items(number - 1) + 1
                Next
            Catch ex As Exception
                MsgBox("Not a valid number", MessageBoxButtons.OK, "Wrong input")
            End Try
        End If
    End Sub
    'Roll some D20
    Private Sub bt_w_20_Click(sender As Object, e As EventArgs) Handles bt_w_20.Click
        If (txt_count_w_20.Text <> "") Then
            Dim count As Integer = 0
            Dim number As Integer = 0
            list_w_20.Items.Clear()
            list_count_w_20.Items.Clear()
            For i As Integer = 0 To 19
                list_w_20.Items.Add(0)
                list_count_w_20.Items.Add(i + 1)
            Next
            Try
                count = txt_count_w_20.Text
                For i As Integer = 1 To count
                    Randomize()
                    number = CInt(Int((20 * Rnd()) + 1))
                    list_w_20.Items(number - 1) = list_w_20.Items(number - 1) + 1
                Next
            Catch ex As Exception
                MsgBox("Not a valid number", MessageBoxButtons.OK, "Wrong input")
            End Try
        End If
    End Sub

    'Player Map Menu
    Private Sub SpielerKarteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpielerKarteToolStripMenuItem.Click
        If SpielerKarteToolStripMenuItem.Checked Then
            PlayerMap.Show()
            If players.Count > 0 Then
                For Each player In players
                    Dim player_item As New Panel
                    player_item.BackColor = player.colour
                    player_item.Visible = False
                    player_item.Location = New Point(50, 50)
                    player_item.Size = New Size(25, 25)
                    player_item.Name = player.charID
                    player_item.BorderStyle = BorderStyle.FixedSingle
                    PlayerMap.Controls.Add(player_item)
                    player_item.Dispose
                Next
            End If
        Else
            PlayerMap.Close()
        End If
    End Sub
    'Admin Map menu
    Private Sub AdminKarteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminKarteToolStripMenuItem.Click
        If AdminKarteToolStripMenuItem.Checked Then
            AdminWindow.Show()
        Else
            AdminWindow.Close()
        End If
    End Sub

    'Changed the enemys name
    Private Sub enemy_info_changed(sender As Object, e As EventArgs) Handles txt_en_name.TextChanged, cb_en_status.TextChanged, txt_en_hp.TextChanged, txt_en_hp_max.TextChanged, txt_en_psychic.TextChanged, txt_en_psychic_max.TextChanged, txt_en_init.TextChanged, txt_en_skill.TextChanged, txt_en_str.TextChanged, txt_en_will.TextChanged, txt_en_self.TextChanged, txt_en_const.TextChanged, txt_en_char.TextChanged, txt_en_rea.TextChanged, txt_en_intu.TextChanged
        Dim sender_name As String
        Dim enemy As character = New character
        If Not enemys.Count > 0 Then
            Return
        End If
        Try
            sender_name = sender.Name
            enemy = enemys(selected_enemy)
        Catch
            Return
        End Try
        Try
            Select Case sender_name
                Case "txt_en_name"
                    enemy.name = sender.Text
                Case "cb_en_status"
                    enemy.status = sender.Text
                Case "txt_en_hp"
                    enemy.hp = sender.Text
                Case "txt_en_hp_max"
                    enemy.max_hp = sender.Text
                Case "txt_en_psychic"
                    enemy.psychic = sender.Text
                Case "txt_en_psychic_max"
                    enemy.psychic_max = sender.Text
                Case "txt_en_init"
                    enemy.initiative = sender.Text
                Case "txt_en_skill"
                    enemy.skill = sender.Text
                Case "txt_en_str"
                    enemy.strength = sender.Text
                Case "txt_en_will"
                    enemy.willpower = sender.Text
                Case "txt_en_self"
                    enemy.selfcontrol = sender.Text
                Case "txt_en_const"
                    enemy.constitution = sender.Text
                Case "txt_en_char"
                    enemy.charisma = sender.Text
                Case "txt_en_rea"
                    enemy.reaction = sender.Text
                Case "txt_en_intu"
                    enemy.intuition = sender.Text
                Case Else
                    MsgBox("How did you do that?", MessageBoxButtons.OK, "WTF?!")
            End Select
            update_en_list()
        Catch
            Return
        End Try
    End Sub

    'Update enemy List
    Public Sub update_en_list()
        Dim nmy As character = New character
        Dim matches() As Control
        nmy = enemys(selected_enemy)
        matches = Me.Controls.Find("rd_en_" & selected_enemy, True)
        matches(0).Text = nmy.name & " ( " & nmy.hp & " | " & nmy.max_hp & " ) "
    End Sub

    'Selected enemy changed
    Private Sub list_enemys_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_enemys.SelectedIndexChanged
        Dim enemy As New character
        If (list_enemys.SelectedIndex >= 0) Then
            selected_enemy = list_enemys.SelectedIndex
            enemy = enemys(selected_enemy)

            lb_debug.Text = enemy.charID

            txt_en_init.Text = enemy.initiative
            txt_en_name.Text = enemy.name
            txt_en_self.Text = enemy.selfcontrol
            txt_en_skill.Text = enemy.skill
            txt_en_str.Text = enemy.strength
            txt_en_will.Text = enemy.willpower
            cb_en_status.Text = enemy.status
            txt_en_hp.Text = enemy.hp
            txt_en_hp_max.Text = enemy.max_hp
            txt_en_const.Text = enemy.constitution
            txt_en_rea.Text = enemy.reaction
            txt_en_intu.Text = enemy.intuition
            txt_en_char.Text = enemy.charisma
            txt_en_psychic.Text = enemy.psychic
            txt_en_psychic_max.Text = enemy.psychic_max
        End If
    End Sub

    'Add a InfoText box
    Private Sub bt_add_Click(sender As Object, e As EventArgs) Handles bt_add_text.Click
        Dim player_item As New Panel
        Dim admin_item As New Panel
        Dim text_field As New RichTextBox
        Dim image_box As New PictureBox
        Dim tmp_text As New info_text

        If tb_text_name.Text = "" Then
            Return
        End If

        'Name the TextField
        tmp_text.name = tb_text_name.Text

        'Generate ID for items
        tmp_text.textID = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds

        'Add text name to List
        list_texts.Items.Add(tmp_text.name)

        'Add text to List
        texts.Add(tmp_text)

        'Create a RichTextField to add to the TextBox
        text_field.Name = "info"
        text_field.Location = New Point(0, 0)
        text_field.Visible = False
        text_field.BorderStyle = BorderStyle.None
        text_field.Size = New Size(200, 100)

        'Create a ImageBox to add to the TextBox
        image_box.Name = "image"
        image_box.Location = New Point(0, 0)
        image_box.Visible = True
        image_box.BorderStyle = BorderStyle.None
        image_box.Size = New Size(200, 100)

        'Create Playeritem for TextBox
        player_item.BackColor = Color.White
        player_item.Visible = False
        player_item.Location = New Point(50, 50)
        player_item.Size = New Size(200, 100)
        player_item.Name = tmp_text.textID
        player_item.BorderStyle = BorderStyle.FixedSingle
        'Add RichTextField to TextBox
        player_item.Controls.Add(text_field)
        'Add PictureBox to TextBox
        player_item.Controls.Add(image_box)
        'Add the TextBox to the Player Screen List
        player_screen_items.Add(player_item)

        'Create Adminitem for TextBox
        admin_item.Size = New Size(100, 50)
        admin_item.Location = New Point(25, 25)
        admin_item.Visible = True
        admin_item.Name = tmp_text.textID
        admin_item.BorderStyle = BorderStyle.FixedSingle
        admin_item.BackColor = Color.LightGray
        admin_item.Cursor = Cursors.Cross
        AddHandler admin_item.MouseDown, AddressOf AdminWindow.drag_handler
        AddHandler admin_item.MouseUp, AddressOf AdminWindow.mouse_up_handler
        AddHandler admin_item.Click, AddressOf AdminWindow.mouse_click_handler
        AddHandler admin_item.MouseHover, AddressOf AdminWindow.tt_open_text
        admin_item.ContextMenuStrip = AdminWindow.menu_players
        'Add the TextBox to the Admin Screen List
        admin_screen_items.Add(admin_item)
    End Sub

    'Delete a InfoText Box
    Private Sub bt_del_text_Click(sender As Object, e As EventArgs) Handles bt_del_text.Click
        Dim item As Panel
        'Search for item to delete
        item = admin_screen_items.Find(Function(x) x.Name = texts(selected_text).textID)
        admin_screen_items.Remove(item)
        player_screen_items.Remove(item)
        'Delete text from Text List
        texts.RemoveAt(selected_text)
    End Sub

    'Change Text of an InfoText Box
    Private Sub rtb_text_TextChanged(sender As Object, e As EventArgs) Handles rtb_text.TextChanged
        Dim text_box As New info_text
        text_box = texts(selected_text)
        text_box.text = rtb_text.Text
        PlayerMap.ex_update_text = True
        PlayerMap.ex_text_to_update = text_box.textID
    End Sub

    'Selected TextBox Changed
    Private Sub list_texts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_texts.SelectedIndexChanged
        Dim text_box As New info_text
        If (list_texts.SelectedIndex >= 0) Then
            selected_text = list_texts.SelectedIndex
            text_box = texts(selected_text)
            'Set Textbox text
            rtb_text.Text = text_box.text
        End If
    End Sub
End Class
