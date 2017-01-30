Public Class PlayerMap

    Public Shared ex_width As Integer = 100
    Public Shared ex_height As Integer = 100

    Public Shared ex_back_img_filename As String = ""

    Public Shared ex_player_to_update As String = ""
    Public Shared ex_player_command As String = ""
    Public Shared ex_player_status_update As Boolean = False
    Public Shared ex_player_pos As Point = New Point(25, 25)

    Private Sub PlayerMap_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pic_background.Width = Me.Width - 16
        pic_background.Height = Me.Height - 38
        ex_width = Me.Width
        ex_height = Me.Height
    End Sub

    Private Sub PlayerMap_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim MainWindow As New Main
    End Sub

    Private Sub ui_update_Tick(sender As Object, e As EventArgs) Handles ui_update.Tick
        'Update Player Objects
        If (ex_player_to_update <> "") Then
            Try
                Dim player_object = Me.Controls.Find(ex_player_to_update, True)
                If ex_player_command = "visibility" Then
                    player_object(0).Visible = ex_player_status_update
                    player_object(0).BringToFront()
                ElseIf ex_player_command = "move" Then
                    player_object(0).Location = ex_player_pos + ex_player_pos
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
            pic_background.Image = Image.FromFile(ex_back_img_filename)
        End If
    End Sub
End Class