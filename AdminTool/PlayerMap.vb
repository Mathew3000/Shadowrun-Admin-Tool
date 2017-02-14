Public Class PlayerMap
    Public Shared show_last_state = False

    Public Shared ex_width As Integer = 100
    Public Shared ex_height As Integer = 100

    Public Shared ex_back_img_filename As String = ""
    Public Shared ex_back_img As Image
    Public Shared ex_show_overlay As Boolean = False

    Public Shared ex_update_text As Boolean = False
    Public Shared ex_text_to_update As String = ""

    Public Shared ex_player_to_update As String = ""
    Public Shared ex_player_command As String = ""
    Public Shared ex_player_status_update As Boolean = False
    Public Shared ex_player_pos As Point = New Point(25, 25)

    'Scale Image when resizing Window
    Private Sub PlayerMap_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pic_background.Width = Me.Width - 16
        pic_background.Height = Me.Height - 38
        ex_width = Me.Width
        ex_height = Me.Height
    End Sub

    'Close Window
    Private Sub PlayerMap_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim MainWindow As New Main
    End Sub

    'Update UI-Elements
    Private Sub ui_update_Tick(sender As Object, e As EventArgs) Handles ui_update.Tick
        'Update Player Object position and visibility
        If (ex_player_to_update <> "") Then
            Try
                Dim player_object = Me.Controls.Find(ex_player_to_update, True)
                If ex_player_command = "visibility" Then
                    player_object(0).Visible = ex_player_status_update
                    player_object(0).BringToFront()
                ElseIf ex_player_command = "move" Then
                    'player_object(0).Location = Main.player_screen_items.Find(Function(x) x.Name = ex_player_to_update).Location
                    player_object(0).BringToFront()
                End If
                ex_player_to_update = ""
                ex_player_command = ""
            Catch
                MsgBox("Player Not Found!", MessageBoxButtons.OK, "Error!")
            End Try
        End If

        'Update Background Image
        If (ex_back_img_filename <> "") Then
            If ex_back_img_filename = "CLEAR" Then
                pic_background.BackgroundImage = Nothing
            Else
                If Not ex_back_img.Equals(Nothing) Then
                    pic_background.BackgroundImage = ex_back_img
                End If
            End If
            ex_back_img_filename = ""
        End If

        'Show Overlay?
        If Not show_last_state = ex_show_overlay Then
            If ex_show_overlay Then
                pic_background.Image = AdminTool.My.Resources.Resources.hex1
            Else
                pic_background.Image = Nothing
            End If
            show_last_state = ex_show_overlay
        End If

        'Update Character Elements
        For Each element In Main.player_screen_items
            If Not Me.Controls.Contains(element) Then
                Me.Controls.Add(element)
                Me.Controls.Find(element.Name, True)(0).BringToFront()
            End If
        Next

        'Update InfoTextFields
        If ex_update_text Then
            Dim tmp_text As New RichTextBox
            Dim tmp_bmp As New Bitmap(100, 50)
            Dim tmp_pic_box As New PictureBox
            tmp_text = Me.Controls.Find(ex_text_to_update, True)(0).Controls.Find("info", True)(0)
            tmp_pic_box = Me.Controls.Find(ex_text_to_update, True)(0).Controls.Find("image", True)(0)

            tmp_text.Text = Main.texts.Find(Function(x) x.textID = ex_text_to_update).text

            tmp_text.DrawToBitmap(tmp_bmp, tmp_text.Bounds)

            pic_background.Image = tmp_bmp
            tmp_pic_box.Visible = False
            tmp_text.Visible = True
            tmp_text.BringToFront()
        End If
    End Sub
End Class