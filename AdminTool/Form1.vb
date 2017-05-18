Imports Types.Types
Imports Database.Datasets

'Search for FixMe!!!

Public Class Main
#If DEBUG Then
    Public Shared debugging As Boolean = True
#Else
    Public Shared debugging as Boolean = False
#End If

    'Selected Chars
    Dim selected_char As Integer = 0
    Dim selected_enemy As Integer = 0
    'Selected TextBox
    Dim selected_text As Integer = 100000
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

    'Helper for UI-Updater
    Dim last_show_state As Boolean = False
    Dim scale_factor As Integer = 2

    'Store Clicked Object
    Dim mouse_down_sender As New Object
    Dim mouse_down As Boolean = False
    Dim img_sender As New Object

    'Mask Draw Mode
    Dim mode_drawing As Boolean = False
    Dim mode_draw_mask As Boolean = False
    Dim mask_sender As String = ""

    'Form load event
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Debugging Options
        If Not debugging Then
            tc_main.TabPages.Remove(tab_info)
        End If
        bt_enemy_regenerate.Visible = debugging

        'Create PlayerMap
        PlayerMap.Show()
        PlayerMap.Hide()
        pb_map_01.ContextMenuStrip = menu_map
        pb_map_02.ContextMenuStrip = menu_map
        pb_map_03.ContextMenuStrip = menu_map
        pb_map_04.ContextMenuStrip = menu_map
        pb_map_05.ContextMenuStrip = menu_map
        pb_map_06.ContextMenuStrip = menu_map
        pb_map_07.ContextMenuStrip = menu_map
        pb_map_08.ContextMenuStrip = menu_map
        pb_map_09.ContextMenuStrip = menu_map
        pic_map.ContextMenuStrip = menu_preview
    End Sub

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
            AddHandler admin_item.MouseDown, AddressOf Me.drag_handler
            AddHandler admin_item.MouseUp, AddressOf Me.mouse_up_handler
            AddHandler admin_item.Click, AddressOf Me.mouse_click_handler
            AddHandler admin_item.MouseHover, AddressOf Me.tt_open_enemy
            admin_item.ContextMenuStrip = Me.menu_players

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
            Dim admin_object As Panel = pan_img.Controls.Find(currentID, True)(0)
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
        AddHandler admin_item.MouseDown, AddressOf Me.drag_handler
        AddHandler admin_item.MouseUp, AddressOf Me.mouse_up_handler
        AddHandler admin_item.Click, AddressOf Me.mouse_click_handler
        AddHandler admin_item.MouseHover, AddressOf Me.tt_open_enemy
        admin_item.ContextMenuStrip = Me.menu_players
        'Add the Adminitem to the Admin Screen List
        admin_screen_items.Add(admin_item)

    End Sub

    'Player selected
    Private Sub list_player_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_player.SelectedIndexChanged
        If (list_player.SelectedIndex >= 0) Then
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
                rem_item(currentID)
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
        text_field.Size = New Size(75, 15)

        'Create a ImageBox to add to the TextBox
        image_box.Name = "image"
        image_box.Location = New Point(0, 0)
        image_box.Visible = True
        image_box.BorderStyle = BorderStyle.None
        image_box.Size = New Size(75, 15)

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
        AddHandler admin_item.MouseDown, AddressOf Me.drag_handler
        AddHandler admin_item.MouseUp, AddressOf Me.mouse_up_handler
        AddHandler admin_item.Click, AddressOf Me.mouse_click_handler
        AddHandler admin_item.MouseHover, AddressOf Me.tt_open_text
        admin_item.ContextMenuStrip = Me.menu_players
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
    Private Sub rtb_text_TextChanged(sender As Object, e As EventArgs) Handles rtb_text.TextChanged, tb_info_width.TextChanged, tb_info_height.TextChanged
        Dim text_box As New info_text
        Dim tmp_size As New Size

        If selected_text < 100000 Then
            Try
                text_box = texts(selected_text)
                text_box.text = rtb_text.Text
            Catch
                MsgBox("Could not change Size!", MessageBoxButtons.OK, "Error!")
            End Try
        Else
            Return
        End If

        Try
            tmp_size.Width = tb_info_width.Text
        Catch
            MsgBox("Not a valid input!", MessageBoxButtons.OK, "Error!")
            tmp_size.Width = 50
        End Try
        Try
            tmp_size.Height = tb_info_height.Text
        Catch
            MsgBox("Not a valid input!", MessageBoxButtons.OK, "Error!")
            tmp_size.Height = 15
        End Try

        PlayerMap.ex_text_field_size = tmp_size
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

    Private Sub ui_updater_Tick(sender As Object, e As EventArgs) Handles ui_updater.Tick
        'Show Overlay?
        If Not cb_overlay.Checked = last_show_state Then
            If cb_overlay.Checked Then
                If scale_factor = 1 Then
                    pic_map.Image = AdminTool.My.Resources.Resources.hex1   'Original Scale
                ElseIf scale_factor = 4 Then
                    pic_map.Image = AdminTool.My.Resources.Resources.hex3   'Quarter Scale
                ElseIf scale_factor = 8 Then
                    pic_map.Image = AdminTool.My.Resources.Resources.hex4   'Eigth Scale
                Else
                    pic_map.Image = AdminTool.My.Resources.Resources.hex2   'Half Scale (Default)
                End If
                PlayerMap.ex_show_overlay = True
            Else
                pic_map.Image = Nothing
                PlayerMap.ex_show_overlay = False
            End If
            last_show_state = cb_overlay.Checked
        End If

        'Scale Preview
        Me.pic_map.Width = (PlayerMap.ex_width - 16) / scale_factor
        Me.pic_map.Height = (PlayerMap.ex_height - 38) / scale_factor

        'Update Moved Players
        If mouse_down Then
            Dim tmp_pos As Point = New Point(0, 0)
            Dim cursor_pos As Point = pic_map.PointToClient(Cursor.Position) + (pic_map.Location - pic_map.Bounds.Location)
            'Move Player on admin Screen
            mouse_down_sender.Location = cursor_pos - New Point(7, 7)
            'Save Player Position in element (admin and player)
            Main.admin_screen_items.Find(Function(x) x.Name = mouse_down_sender.name).Location = mouse_down_sender.Location
            If cb_player_live_update.Checked Then
                tmp_pos = cursor_pos - New Point(7, 7)
                Main.player_screen_items.Find(Function(x) x.Name = mouse_down_sender.name).Location =
                    New Point(tmp_pos.X * scale_factor + 6, tmp_pos.Y * scale_factor + 6)
            End If
        End If

        'Update Character Elements
        For Each element In Main.admin_screen_items
            If Not pic_map.Controls.Contains(element) Then
                pic_map.Controls.Add(element)
                pic_map.Controls.Find(element.Name, True)(0).BringToFront()
            End If
        Next

        'Delete old Elements
        For Each element In pic_map.Controls.OfType(Of Panel)
            If Not Main.admin_screen_items.Contains(element) Then
                pic_map.Controls.Remove(element)
            End If
        Next

        'Draw Mask
        If mode_drawing Then
            Dim cursor_pos As Point = pic_map.PointToClient(Cursor.Position) + (pic_map.Location - pic_map.Bounds.Location)
            Dim mask As Panel = pic_map.Controls.Find(mask_sender, True)(0)
            mask.Bounds = New Rectangle(mask.Location, cursor_pos - mask.Location)
            mask.BringToFront()
        End If
    End Sub

    'Handler for dragging a Character Object
    Public Sub drag_handler(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            mouse_down = True
        End If
        mouse_down_sender = sender
    End Sub

    'Handler for releasing the Mouse
    Public Sub mouse_up_handler(sender As Object, ByVal e As EventArgs)
        mouse_down = False
    End Sub

    'Get clicked element
    Public Sub mouse_click_handler(sender As Object, ByVal e As EventArgs)
        mouse_down_sender = sender
    End Sub

    'Character Submenu Show
    Private Sub VisibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisibleToolStripMenuItem.Click
        Try
            PlayerMap.ex_player_command = "visibility"
            PlayerMap.ex_player_status_update = True
            PlayerMap.ex_player_to_update = mouse_down_sender.name
        Catch
            MsgBox("Could not show Player!", MessageBoxButtons.OK, "Error!")
        End Try
    End Sub

    'Character Submenu Hide
    Private Sub HideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideToolStripMenuItem.Click
        Try
            PlayerMap.ex_player_command = "visibility"
            PlayerMap.ex_player_status_update = False
            PlayerMap.ex_player_to_update = mouse_down_sender.name
        Catch
            MsgBox("Could not hide Player!", MessageBoxButtons.OK, "Error!")
        End Try
    End Sub

    'Preload Map Image
    Private Sub LoadImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadImageToolStripMenuItem.Click
        dial_open_img.ShowDialog()
        If dial_open_img.FileName <> "" Then
            img_sender.Image = Image.FromFile(dial_open_img.FileName)
            img_sender.ImageLocation = dial_open_img.FileName
        End If
    End Sub

    'Get Map Selector ID
    Private Sub pb_map_xx_down(sender As Object, e As EventArgs) Handles pb_map_01.MouseDown, pb_map_02.MouseDown, pb_map_03.MouseDown, pb_map_04.MouseDown, pb_map_05.MouseDown, pb_map_06.MouseDown, pb_map_07.MouseDown, pb_map_08.MouseDown, pb_map_09.MouseDown
        img_sender = sender
    End Sub

    'Set Maps in Menu
    Private Sub SetMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetMapToolStripMenuItem.Click
        If Not img_sender.Image Is Nothing Then
            Try
                pic_map.BackgroundImage = img_sender.Image
                PlayerMap.ex_back_img_filename = img_sender.ImageLocation
                PlayerMap.ex_back_img = img_sender.image
            Catch
                MsgBox("Could not set image!", MessageBoxButtons.OK, "Error!")
            End Try
        End If
    End Sub

    'Set Maps onClick
    Private Sub pb_map_xx_Click(sender As Object, e As MouseEventArgs) Handles pb_map_01.Click, pb_map_02.Click, pb_map_03.Click, pb_map_04.Click, pb_map_05.Click, pb_map_06.Click, pb_map_07.Click, pb_map_08.Click, pb_map_09.Click
        Dim selection As MsgBoxResult
        If mode_draw_mask Then
            Return
        End If
        If e.Button = System.Windows.Forms.MouseButtons.Right Then

        Else

            If Not img_sender.Image Is Nothing Then
                selection = MsgBox("Set map?", MsgBoxStyle.YesNo, "Are you sure?")
                If selection = MsgBoxResult.Yes Then
                    Try
                        pic_map.BackgroundImage = img_sender.Image
                        PlayerMap.ex_back_img_filename = img_sender.ImageLocation
                        PlayerMap.ex_back_img = img_sender.image
                    Catch
                        MsgBox("Could not set image!", MessageBoxButtons.OK, "Error!")
                    End Try

                End If
            Else
                dial_open_img.ShowDialog()
                If dial_open_img.FileName <> "" Then
                    img_sender.Image = Image.FromFile(dial_open_img.FileName)
                    img_sender.ImageLocation = dial_open_img.FileName
                End If
            End If
        End If
    End Sub

    'Rotate Map
    Private Sub Rotate90ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Rotate90ToolStripMenuItem.Click
        Dim tmp_image As Image
        tmp_image = img_sender.Image
        tmp_image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        img_sender.Image = tmp_image
    End Sub

    'Character Name ToolTip
    Public Sub tt_open_enemy(sender As Object, e As EventArgs)
        Dim tmp_char As character = New character
        tmp_char = Main.enemys.Find(Function(p) p.charID = sender.name)
        Try
            tt_playername.SetToolTip(sender, tmp_char.playername)
            tt_playername.ToolTipTitle = tmp_char.name
            tt_playername.Active = True
        Catch
        End Try
    End Sub
    Public Sub tt_open_player(sender As Object, e As EventArgs)
        Dim tmp_char As character = New character
        tmp_char = Main.players.Find(Function(p) p.charID = sender.name)
        tt_playername.SetToolTip(sender, tmp_char.playername)
        tt_playername.ToolTipTitle = tmp_char.name
        tt_playername.Active = True
    End Sub
    Public Sub tt_open_text(sender As Object, e As EventArgs)
        Dim tmp_txt As info_text = New info_text
        tmp_txt = Main.texts.Find(Function(p) p.textID = sender.name)
        tt_playername.SetToolTip(sender, " ")
        tt_playername.ToolTipTitle = tmp_txt.name
        tt_playername.Active = True
    End Sub

    'Clear Map Content
    Private Sub ClearMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearMapToolStripMenuItem.Click
        pic_map.Image = Nothing
        PlayerMap.ex_back_img_filename = "CLEAR"
    End Sub

    'Set Map Scale Factor
    Private Sub OneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OneToolStripMenuItem.Click
        scale_factor = 1
    End Sub
    Private Sub TwoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TwoToolStripMenuItem.Click
        scale_factor = 2
    End Sub
    Private Sub FourToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FourToolStripMenuItem.Click
        scale_factor = 4
    End Sub
    Private Sub EightToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EightToolStripMenuItem.Click
        scale_factor = 8
    End Sub

    'Update Player Movement
    Private Sub MoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveToolStripMenuItem.Click
        Dim tmp_pos As Point = New Point(0, 0)
        PlayerMap.ex_player_command = "move"
        PlayerMap.ex_player_to_update = mouse_down_sender.name
        tmp_pos = Main.admin_screen_items.Find(Function(x) x.Name = mouse_down_sender.name).Location
        Main.player_screen_items.Find(Function(x) x.Name = mouse_down_sender.name).Location =
            New Point(tmp_pos.X * scale_factor, tmp_pos.Y * scale_factor)
    End Sub

    'Add Masks Button / Handler
    Private Sub bt_add_mask_Click(sender As Object, e As EventArgs) Handles bt_add_mask.Click
        If mode_draw_mask Then
            mode_draw_mask = False
            bt_add_mask.Text = "Add Mask"
            Me.Cursor = Cursors.Default
        Else
            mode_draw_mask = True
            bt_add_mask.Text = "Stop Mask"
            Me.Cursor = Cursors.Cross
        End If
    End Sub
    Private Sub handle_click(sender As Object, e As MouseEventArgs) Handles pan_img.MouseClick, pic_map.MouseClick
        If mode_draw_mask Then
            If mode_drawing = False Then
                'Get First Point
                mode_drawing = True
                'Add Panel to Admin Window
                Dim mask As New Panel
                mask.Name = (DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds
                mask_sender = mask.Name
                mask.Location = pic_map.PointToClient(Cursor.Position) + (pic_map.Location - pic_map.Bounds.Location)
                mask.BorderStyle = BorderStyle.FixedSingle
                mask.Width = 1
                mask.Height = 1
                mask.ContextMenuStrip = menu_mask
                AddHandler mask.MouseDown, AddressOf mouse_click_handler
                Main.admin_screen_items.Add(mask)
                pic_map.Controls.Add(mask)
            Else
                'Stop Drawing
                mode_drawing = False
                'Add Panel to Player Window
                Dim mask As Panel = Me.Controls.Find(mask_sender, True)(0)
                Dim fog_mask As New Panel
                Dim start As Point = New Point(mask.Location.X * scale_factor, mask.Location.Y * scale_factor)
                fog_mask.Name = mask.Name
                fog_mask.Location = start
                fog_mask.Width = mask.Width * scale_factor
                fog_mask.Height = mask.Height * scale_factor
                Main.player_screen_items.Add(fog_mask)
            End If
        End If
    End Sub

    'Mask Submenu Hide
    Private Sub HideToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HideToolStripMenuItem1.Click
        Try
            rem_item(mouse_down_sender.name)
        Catch
            MsgBox("Could not hide Mask!", MessageBoxButtons.OK, "Error!")
        End Try
    End Sub

    'Remove Panel
    Private Sub rem_item(item_name As String)
        Dim admin_item As New Panel
        Dim player_item As New Panel
        Try
            admin_item = Main.admin_screen_items.Find(Function(x) x.Name = item_name)
            player_item = Main.player_screen_items.Find(Function(x) x.Name = item_name)
            Main.admin_screen_items.Remove(admin_item)
            Main.player_screen_items.Remove(player_item)
        Catch ex As Exception
            MsgBox("Error while deleting Element! (Not found)", MessageBoxButtons.OK, "Error!")
        End Try
    End Sub

    'Player Map Menu
    Private Sub cb_show_player_map_CheckedChanged(sender As Object, e As EventArgs) Handles cb_show_player_map.CheckedChanged
        If cb_show_player_map.Checked Then
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
                    player_item.Dispose()
                Next
            End If
        Else
            PlayerMap.Hide()
        End If

    End Sub

    Private Sub bt_delete_Click(sender As Object, e As EventArgs) Handles bt_delete.Click
        Dim enemy As New character
        If (list_enemys.SelectedIndex >= 0) Then
            selected_enemy = list_enemys.SelectedIndex
            enemy = enemys(selected_enemy)
            rem_item(enemy.charID)
            list_enemys.Items.RemoveAt(list_enemys.SelectedIndex)
        End If
    End Sub
End Class
