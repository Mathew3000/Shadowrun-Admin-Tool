Imports Types.Types
Imports Database.Datasets

'Search for FixMe!!!

Public Class Main

    Dim enemys(15) As character
    Dim players As New List(Of character)
    Dim difficulty As Integer = 0
    Dim selected_char As Integer = 0

    Dim selected_enemy As Integer = 0

    Public Function randomval(lowerbound As Integer, upperbound As Integer)
        Dim value As Integer = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        Return value
    End Function

    Private Sub bt_rand_Click(sender As Object, e As EventArgs) Handles bt_rand.Click
        Dim input As Object
        Dim default_input As Integer = 1
        Dim length As Integer
        Dim message, title As String
        Dim matches() As Control

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

        enemys = New character(15) {}

        length = nameset.Length

        message = "Anzahl der Gegner? (1-15)"
        title = "Wie viele?"

        input = InputBox(message, title, default_input)
        If input Is "" Then input = default_input

        'Characters
        For i As Integer = 1 To Int(input)
            Dim name_int = randomval(0, length - 1)
            Dim rnd = random_modifier_set(difficulty)
            matches = Me.Controls.Find("rd_en_" & i, True)
            'Preinitialise
            enemys(i) = New character
            'Set Enemy Name
            enemys(i).name = nameset(name_int)
            matches(0).Text = enemys(i).name
            matches(0).Visible = True
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
            'Calculate Initiative
            enemys(i).initiative = enemys(i).intuition + enemys(i).intuition + randomval(0, rnd)


        Next
        For i As Integer = Int(input) To 14
            If input < 15 Then
                matches = Me.Controls.Find("rd_en_" & (i + 1), True)
                matches(0).Visible = False
            End If
        Next
    End Sub

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

    Private Sub selected_changed(sender As Object, e As EventArgs) Handles rd_en_1.CheckedChanged, rd_en_2.CheckedChanged, rd_en_3.CheckedChanged, rd_en_4.CheckedChanged, rd_en_5.CheckedChanged, rd_en_6.CheckedChanged, rd_en_7.CheckedChanged, rd_en_8.CheckedChanged, rd_en_9.CheckedChanged, rd_en_10.CheckedChanged, rd_en_11.CheckedChanged, rd_en_12.CheckedChanged, rd_en_13.CheckedChanged, rd_en_14.CheckedChanged, rd_en_15.CheckedChanged
        Dim enemy As character = New character
        If rd_en_1.Checked = True Then
            selected_enemy = 1
        ElseIf rd_en_2.Checked = True Then
            selected_enemy = 2
        ElseIf rd_en_3.Checked = True Then
            selected_enemy = 3
        ElseIf rd_en_4.Checked = True Then
            selected_enemy = 4
        ElseIf rd_en_5.Checked = True Then
            selected_enemy = 5
        ElseIf rd_en_6.Checked = True Then
            selected_enemy = 6
        ElseIf rd_en_7.Checked = True Then
            selected_enemy = 7
        ElseIf rd_en_8.Checked = True Then
            selected_enemy = 8
        ElseIf rd_en_9.Checked = True Then
            selected_enemy = 9
        ElseIf rd_en_10.Checked = True Then
            selected_enemy = 10
        ElseIf rd_en_11.Checked = True Then
            selected_enemy = 11
        ElseIf rd_en_12.Checked = True Then
            selected_enemy = 12
        ElseIf rd_en_13.Checked = True Then
            selected_enemy = 13
        ElseIf rd_en_14.Checked = True Then
            selected_enemy = 14
        ElseIf rd_en_15.Checked = True Then
            selected_enemy = 15
        End If
        enemy = enemys(selected_enemy)

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

    End Sub

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

    Private Sub pan_colour_Click(sender As Object, e As EventArgs) Handles pan_colour.Click
        col_diag_player.ShowDialog()
        pan_colour.BackColor = col_diag_player.Color
        If (selected_char >= 0) Then
            Dim currentID As String = players(selected_char).charID
            Dim player_object As Panel = CType(PlayerMap.Controls(currentID), Panel)
            Dim admin_object As Panel = CType(AdminWindow.Controls(currentID), Panel)
            players(selected_char).colour = col_diag_player.Color
            player_object.BackColor = col_diag_player.Color
            player_object.Visible = True
            player_object.BringToFront()
            admin_object.BackColor = col_diag_player.Color
            admin_object.BringToFront()
        End If
    End Sub

    Private Sub bt_add_char_Click(sender As Object, e As EventArgs) Handles bt_add_char.Click
        Dim new_player As character = New character
        Dim player_item As New Panel
        Dim admin_item As New Panel

        new_player.charID = TimeString

        players.Add(new_player)
        list_player.Items.Add(new_player.name)


        player_item.BackColor = Color.White
        player_item.Visible = False
        player_item.Location = New Point(50, 50)
        player_item.Size = New Size(25, 25)
        player_item.Name = new_player.charID
        player_item.BorderStyle = BorderStyle.FixedSingle
        Try
            PlayerMap.Controls.Add(player_item)
        Catch
            player_item.Name = "failed"
        End Try

        admin_item.Size = New Size(15, 15)
        admin_item.Location = New Point(25, 25)
        admin_item.Visible = True
        admin_item.Name = new_player.charID
        admin_item.BorderStyle = BorderStyle.FixedSingle
        admin_item.BackColor = Color.White
        admin_item.Cursor = Cursors.Cross
        Try
        AdminWindow.Controls.Add(admin_item)
        Catch
            admin_item.Name = "failed"
        End Try
        Dim admin_object As Panel = CType(AdminWindow.Controls(new_player.charID), Panel)
        Dim player_object As Panel = CType(PlayerMap.Controls(new_player.charID), Panel)
        AddHandler admin_object.MouseDown, AddressOf AdminWindow.drag_handler
        AddHandler admin_object.MouseUp, AddressOf AdminWindow.mouse_up_handler
        AddHandler admin_object.Click, AddressOf AdminWindow.mouse_click_handler
        admin_object.ContextMenuStrip = AdminWindow.menu_players
        admin_object.BringToFront()
        player_object.BringToFront()

    End Sub

    Private Sub list_player_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_player.SelectedIndexChanged
        If (list_player.SelectedIndex >= 0)
            selected_char = list_player.SelectedIndex
            txt_playername.Text = players(selected_char).playername
            txt_charname.Text = players(selected_char).name
            txt_initiative.Text = players(selected_char).initiative
            pan_colour.BackColor = players(selected_char).colour
        End If
    End Sub

    Private Sub txt_playername_TextChanged(sender As Object, e As EventArgs) Handles txt_playername.TextChanged
        If ((players.Count) < 1) Then
            Return
        Else
            players(selected_char).playername = txt_playername.Text
        End If
    End Sub

    Private Sub txt_charname_TextChanged(sender As Object, e As EventArgs) Handles txt_charname.TextChanged
        If (players.Count < 1) Then
            Return
        Else
            players(selected_char).name = txt_charname.Text
            list_player.Items(selected_char) = txt_charname.Text
        End If
    End Sub

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

    Private Sub AdminKarteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminKarteToolStripMenuItem.Click
        If AdminKarteToolStripMenuItem.Checked Then
            AdminWindow.Show()
        Else
            AdminWindow.Close()
        End If
    End Sub
End Class
