﻿Public Class AdminWindow

    Dim mouse_down As Boolean = False
    Dim mouse_button As String = ""
    Dim mouse_down_sender As New Object
    Dim img_sender As New Object
    Dim scale_factor As Integer = 2

    Private Sub ui_updater_Tick(sender As Object, e As EventArgs) Handles ui_updater.Tick
        Me.pic_map.Width = (PlayerMap.ex_width - 16) / scale_factor
        Me.pic_map.Height = (PlayerMap.ex_height - 38) / scale_factor
        If (Me.Width < PlayerMap.ex_width / scale_factor) Then
            Me.Width = PlayerMap.ex_width / scale_factor
        End If
        If (Me.Height < (PlayerMap.ex_height / scale_factor) + 200) Then
            Me.Height = (PlayerMap.ex_height / scale_factor) + 200
        End If
        If mouse_down Then
            Dim cursor_pos As Point = Me.PointToClient(Cursor.Position) + (Me.Location - Me.Bounds.Location)
            Dim tmp_pos As Point = New Point(0, 0)
            mouse_down_sender.Location = cursor_pos - New Point(7, 7)
            PlayerMap.ex_player_command = "move"
            PlayerMap.ex_player_to_update = mouse_down_sender.name
            'Scale Movement
            tmp_pos = cursor_pos - New Point(7, 7)
            PlayerMap.ex_player_pos.X = tmp_pos.X * scale_factor
            PlayerMap.ex_player_pos.Y = tmp_pos.Y * scale_factor
        End If
        If Me.Width > 200 Then
            Panel1.Width = Me.Width - 36
        End If

    End Sub

    Public Sub drag_handler(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            mouse_down = True
        End If
        mouse_down_sender = sender
    End Sub
    Public Sub mouse_up_handler(sender As Object, ByVal e As EventArgs)
        mouse_down = False
    End Sub

    Public Sub mouse_click_handler(sender As Object, ByVal e As EventArgs)
        mouse_down_sender = sender
    End Sub

    Private Sub VisibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisibleToolStripMenuItem.Click
        Try
            PlayerMap.ex_player_command = "visibility"
            PlayerMap.ex_player_status_update = True
            PlayerMap.ex_player_to_update = mouse_down_sender.name
        Catch
            MsgBox("Could not show Player!", MessageBoxButtons.OK, "Error!")
        End Try
    End Sub

    Private Sub HideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideToolStripMenuItem.Click
        Try
            PlayerMap.ex_player_command = "visibility"
            PlayerMap.ex_player_status_update = False
            PlayerMap.ex_player_to_update = mouse_down_sender.name
        Catch
            MsgBox("Could not hide Player!", MessageBoxButtons.OK, "Error!")
        End Try
    End Sub

    Private Sub LoadImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadImageToolStripMenuItem.Click
        dial_open_img.ShowDialog()
        If dial_open_img.FileName <> "" Then
            img_sender.Image = Image.FromFile(dial_open_img.FileName)
            img_sender.ImageLocation = dial_open_img.FileName
        End If
    End Sub

    Private Sub pb_map_xx_down(sender As Object, e As EventArgs) Handles pb_map_01.MouseDown, pb_map_02.MouseDown, pb_map_03.MouseDown, pb_map_04.MouseDown, pb_map_05.MouseDown, pb_map_06.MouseDown, pb_map_07.MouseDown, pb_map_08.MouseDown, pb_map_09.MouseDown
        img_sender = sender
    End Sub

    Private Sub SetMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetMapToolStripMenuItem.Click
        If Not img_sender.Image Is Nothing Then
            Try
                pic_map.Image = img_sender.Image
                PlayerMap.ex_back_img_filename = img_sender.ImageLocation
            Catch
                MsgBox("Could not set image!", MessageBoxButtons.OK, "Error!")
            End Try
        End If
    End Sub

    Private Sub pb_map_xx_Click(sender As Object, e As EventArgs) Handles pb_map_01.Click, pb_map_02.Click, pb_map_03.Click, pb_map_04.Click, pb_map_05.Click, pb_map_06.Click, pb_map_07.Click, pb_map_08.Click, pb_map_09.Click
        Dim selection As MsgBoxResult
        selection = MsgBox("Set map?", MsgBoxStyle.YesNo, "Are you sure?")
        If selection = MsgBoxResult.Yes Then
            If Not img_sender.Image Is Nothing Then
                Try
                    pic_map.Image = img_sender.Image
                    PlayerMap.ex_back_img_filename = img_sender.ImageLocation
                    PlayerMap.ex_back_img = img_sender.image
                Catch
                    MsgBox("Could not set image!", MessageBoxButtons.OK, "Error!")
                End Try
            End If
        End If
    End Sub

    Private Sub Rotate90ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Rotate90ToolStripMenuItem.Click
        Dim tmp_image As Image
        tmp_image = img_sender.Image
        tmp_image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        img_sender.Image = tmp_image
    End Sub

    Private Sub ClearMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearMapToolStripMenuItem.Click
        pic_map.Image = Nothing
        PlayerMap.ex_back_img_filename = "CLEAR"
    End Sub

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
End Class