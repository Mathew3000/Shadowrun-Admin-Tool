Imports Types.Types

Public Class AdminWindow

    Dim mouse_down As Boolean = False
    Dim mouse_button As String = ""
    Dim mouse_down_sender As New Object
    Dim img_sender As New Object
    Dim scale_factor As Integer = 2
    Dim last_show_state As Boolean = False

    Dim mode_draw_mask As Boolean = True
    Dim mode_drawing As Boolean = False
    Dim point_one As Point = New Point(0, 0)
    Dim point_two As Point = New Point(0, 0)

    'Update UI with changes
    Private Sub ui_updater_Tick(sender As Object, e As EventArgs) Handles ui_updater.Tick
        'Show Overlay?
        If Not cb_overlay.Checked = last_show_state Then
            If cb_overlay.Checked Then
                pic_map.Image = AdminTool.My.Resources.Resources.hex2
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

        'Rescale to fit PlayerWindow Preview
        If (Me.Width < (PlayerMap.ex_width / scale_factor) + 175) Then
            Me.Width = (PlayerMap.ex_width / scale_factor) + 175
        End If
        If (Me.Height < (PlayerMap.ex_height / scale_factor) + 200) Then
            Me.Height = (PlayerMap.ex_height / scale_factor) + 200
        End If

        'Update Moved Players
        If mouse_down Then
            Dim tmp_pos As Point = New Point(0, 0)
            Dim cursor_pos As Point = Me.PointToClient(Cursor.Position) + (Me.Location - Me.Bounds.Location)
            'Move Player on admin Screen
            mouse_down_sender.Location = cursor_pos - New Point(7, 7)
            'Save Player Position in element (admin and player)
            Main.admin_screen_items.Find(Function(x) x.Name = mouse_down_sender.name).Location = mouse_down_sender.Location
            If cb_player_live_update.Checked Then
                tmp_pos = cursor_pos - New Point(7, 7)
                Main.player_screen_items.Find(Function(x) x.Name = mouse_down_sender.name).Location =
                    New Point(tmp_pos.X * scale_factor, tmp_pos.Y * scale_factor)
            End If
        End If

        'Rescale Maps Selection Box
        If Me.Width > 200 Then
            Panel1.Width = Me.Width - 36
        End If

        'Rescale Options Box
        If Me.Height > 160 Then
            GroupBox1.Height = Me.Height - 220
        End If

        'Update Character Elements
        For Each element In Main.admin_screen_items
            If Not Me.Controls.Contains(element) Then
                Me.Controls.Add(element)
                Me.Controls.Find(element.Name, True)(0).BringToFront()
            End If
        Next


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
            Catch
                MsgBox("Could not set image!", MessageBoxButtons.OK, "Error!")
            End Try
        End If
    End Sub

    'Set Maps onClick
    Private Sub pb_map_xx_Click(sender As Object, e As EventArgs) Handles pb_map_01.Click, pb_map_02.Click, pb_map_03.Click, pb_map_04.Click, pb_map_05.Click, pb_map_06.Click, pb_map_07.Click, pb_map_08.Click, pb_map_09.Click
        Dim selection As MsgBoxResult
        If mode_draw_mask Then
            Return
        End If
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
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        scale_factor = 1
    End Sub
    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        scale_factor = 2
    End Sub
    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        scale_factor = 4
    End Sub
    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        scale_factor = 8
    End Sub

    Private Sub pb_map_xx_down(sender As Object, e As MouseEventArgs) Handles pb_map_09.MouseDown, pb_map_08.MouseDown, pb_map_07.MouseDown, pb_map_06.MouseDown, pb_map_05.MouseDown, pb_map_04.MouseDown, pb_map_03.MouseDown, pb_map_02.MouseDown, pb_map_01.MouseDown

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
        mode_draw_mask = True
        Me.Cursor = Cursors.Cross
    End Sub
    Private Sub handle_click(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If mode_draw_mask Then
            If mode_drawing = False Then
                'Get First Point
                mode_drawing = True
                'Add Panel
                Dim mask As New Panel
                mask.Location = MousePosition
            Else
                'Get Second Point
                mode_drawing = False
                point_two = MousePosition

            End If
        End If
    End Sub
End Class