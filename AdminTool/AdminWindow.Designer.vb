<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminWindow))
        Me.menu_preview = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClearMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScaleModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ui_updater = New System.Windows.Forms.Timer(Me.components)
        Me.menu_players = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VisibleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cb_overlay = New System.Windows.Forms.CheckBox()
        Me.menu_map = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LoadImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Rotate90ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dial_open_img = New System.Windows.Forms.OpenFileDialog()
        Me.tt_playername = New System.Windows.Forms.ToolTip(Me.components)
        Me.pb_map_09 = New System.Windows.Forms.PictureBox()
        Me.pb_map_08 = New System.Windows.Forms.PictureBox()
        Me.pb_map_07 = New System.Windows.Forms.PictureBox()
        Me.pb_map_06 = New System.Windows.Forms.PictureBox()
        Me.pb_map_05 = New System.Windows.Forms.PictureBox()
        Me.pb_map_04 = New System.Windows.Forms.PictureBox()
        Me.pb_map_03 = New System.Windows.Forms.PictureBox()
        Me.pb_map_02 = New System.Windows.Forms.PictureBox()
        Me.pb_map_01 = New System.Windows.Forms.PictureBox()
        Me.pic_map = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_hide_map = New System.Windows.Forms.CheckBox()
        Me.bt_add_mask = New System.Windows.Forms.Button()
        Me.cb_player_live_update = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.menu_mask = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_preview.SuspendLayout()
        Me.menu_players.SuspendLayout()
        Me.menu_map.SuspendLayout()
        CType(Me.pb_map_09, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_map_08, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_map_07, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_map_06, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_map_05, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_map_04, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_map_03, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_map_02, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_map_01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_map, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.menu_mask.SuspendLayout()
        Me.SuspendLayout()
        '
        'menu_preview
        '
        Me.menu_preview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearMapToolStripMenuItem, Me.ScaleModeToolStripMenuItem})
        Me.menu_preview.Name = "menu_preview"
        Me.menu_preview.Size = New System.Drawing.Size(136, 48)
        '
        'ClearMapToolStripMenuItem
        '
        Me.ClearMapToolStripMenuItem.Name = "ClearMapToolStripMenuItem"
        Me.ClearMapToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ClearMapToolStripMenuItem.Text = "Clear Map"
        '
        'ScaleModeToolStripMenuItem
        '
        Me.ScaleModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5})
        Me.ScaleModeToolStripMenuItem.Name = "ScaleModeToolStripMenuItem"
        Me.ScaleModeToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ScaleModeToolStripMenuItem.Text = "Scale Mode"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(95, 22)
        Me.ToolStripMenuItem2.Text = "1 : 1"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(95, 22)
        Me.ToolStripMenuItem3.Text = "1 : 2"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(95, 22)
        Me.ToolStripMenuItem4.Text = "1 : 4"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(95, 22)
        Me.ToolStripMenuItem5.Text = "1 : 8"
        '
        'ui_updater
        '
        Me.ui_updater.Enabled = True
        Me.ui_updater.Interval = 10
        '
        'menu_players
        '
        Me.menu_players.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VisibleToolStripMenuItem, Me.HideToolStripMenuItem, Me.MoveToolStripMenuItem})
        Me.menu_players.Name = "menu_players"
        Me.menu_players.Size = New System.Drawing.Size(105, 70)
        '
        'VisibleToolStripMenuItem
        '
        Me.VisibleToolStripMenuItem.Name = "VisibleToolStripMenuItem"
        Me.VisibleToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.VisibleToolStripMenuItem.Text = "Show"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.HideToolStripMenuItem.Text = "Hide"
        '
        'MoveToolStripMenuItem
        '
        Me.MoveToolStripMenuItem.Name = "MoveToolStripMenuItem"
        Me.MoveToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.MoveToolStripMenuItem.Text = "Move"
        '
        'cb_overlay
        '
        Me.cb_overlay.AutoSize = True
        Me.cb_overlay.Location = New System.Drawing.Point(6, 19)
        Me.cb_overlay.Name = "cb_overlay"
        Me.cb_overlay.Size = New System.Drawing.Size(92, 17)
        Me.cb_overlay.TabIndex = 10
        Me.cb_overlay.Text = "Show Overlay"
        Me.cb_overlay.UseVisualStyleBackColor = True
        '
        'menu_map
        '
        Me.menu_map.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadImageToolStripMenuItem, Me.SetMapToolStripMenuItem, Me.Rotate90ToolStripMenuItem})
        Me.menu_map.Name = "menu_map"
        Me.menu_map.Size = New System.Drawing.Size(137, 70)
        '
        'LoadImageToolStripMenuItem
        '
        Me.LoadImageToolStripMenuItem.Name = "LoadImageToolStripMenuItem"
        Me.LoadImageToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.LoadImageToolStripMenuItem.Text = "Load Image"
        '
        'SetMapToolStripMenuItem
        '
        Me.SetMapToolStripMenuItem.Name = "SetMapToolStripMenuItem"
        Me.SetMapToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.SetMapToolStripMenuItem.Text = "Set Map"
        '
        'Rotate90ToolStripMenuItem
        '
        Me.Rotate90ToolStripMenuItem.Name = "Rotate90ToolStripMenuItem"
        Me.Rotate90ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.Rotate90ToolStripMenuItem.Text = "Rotate 90°"
        '
        'dial_open_img
        '
        Me.dial_open_img.Filter = "Bilder |*.png; *.bmp; *.jpg; *.jpeg; *.gif"
        '
        'tt_playername
        '
        Me.tt_playername.IsBalloon = True
        Me.tt_playername.ToolTipTitle = "<Playername>"
        '
        'pb_map_09
        '
        Me.pb_map_09.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pb_map_09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_map_09.ContextMenuStrip = Me.menu_map
        Me.pb_map_09.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_map_09.Location = New System.Drawing.Point(614, 19)
        Me.pb_map_09.Name = "pb_map_09"
        Me.pb_map_09.Size = New System.Drawing.Size(70, 100)
        Me.pb_map_09.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_map_09.TabIndex = 9
        Me.pb_map_09.TabStop = False
        '
        'pb_map_08
        '
        Me.pb_map_08.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pb_map_08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_map_08.ContextMenuStrip = Me.menu_map
        Me.pb_map_08.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_map_08.Location = New System.Drawing.Point(538, 19)
        Me.pb_map_08.Name = "pb_map_08"
        Me.pb_map_08.Size = New System.Drawing.Size(70, 100)
        Me.pb_map_08.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_map_08.TabIndex = 8
        Me.pb_map_08.TabStop = False
        '
        'pb_map_07
        '
        Me.pb_map_07.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pb_map_07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_map_07.ContextMenuStrip = Me.menu_map
        Me.pb_map_07.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_map_07.Location = New System.Drawing.Point(462, 19)
        Me.pb_map_07.Name = "pb_map_07"
        Me.pb_map_07.Size = New System.Drawing.Size(70, 100)
        Me.pb_map_07.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_map_07.TabIndex = 7
        Me.pb_map_07.TabStop = False
        '
        'pb_map_06
        '
        Me.pb_map_06.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pb_map_06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_map_06.ContextMenuStrip = Me.menu_map
        Me.pb_map_06.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_map_06.Location = New System.Drawing.Point(386, 19)
        Me.pb_map_06.Name = "pb_map_06"
        Me.pb_map_06.Size = New System.Drawing.Size(70, 100)
        Me.pb_map_06.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_map_06.TabIndex = 6
        Me.pb_map_06.TabStop = False
        '
        'pb_map_05
        '
        Me.pb_map_05.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pb_map_05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_map_05.ContextMenuStrip = Me.menu_map
        Me.pb_map_05.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_map_05.Location = New System.Drawing.Point(310, 19)
        Me.pb_map_05.Name = "pb_map_05"
        Me.pb_map_05.Size = New System.Drawing.Size(70, 100)
        Me.pb_map_05.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_map_05.TabIndex = 5
        Me.pb_map_05.TabStop = False
        '
        'pb_map_04
        '
        Me.pb_map_04.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pb_map_04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_map_04.ContextMenuStrip = Me.menu_map
        Me.pb_map_04.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_map_04.Location = New System.Drawing.Point(234, 19)
        Me.pb_map_04.Name = "pb_map_04"
        Me.pb_map_04.Size = New System.Drawing.Size(70, 100)
        Me.pb_map_04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_map_04.TabIndex = 4
        Me.pb_map_04.TabStop = False
        '
        'pb_map_03
        '
        Me.pb_map_03.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pb_map_03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_map_03.ContextMenuStrip = Me.menu_map
        Me.pb_map_03.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_map_03.Location = New System.Drawing.Point(158, 19)
        Me.pb_map_03.Name = "pb_map_03"
        Me.pb_map_03.Size = New System.Drawing.Size(70, 100)
        Me.pb_map_03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_map_03.TabIndex = 3
        Me.pb_map_03.TabStop = False
        '
        'pb_map_02
        '
        Me.pb_map_02.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pb_map_02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_map_02.ContextMenuStrip = Me.menu_map
        Me.pb_map_02.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_map_02.Location = New System.Drawing.Point(82, 19)
        Me.pb_map_02.Name = "pb_map_02"
        Me.pb_map_02.Size = New System.Drawing.Size(70, 100)
        Me.pb_map_02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_map_02.TabIndex = 2
        Me.pb_map_02.TabStop = False
        '
        'pb_map_01
        '
        Me.pb_map_01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pb_map_01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_map_01.ContextMenuStrip = Me.menu_map
        Me.pb_map_01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_map_01.Location = New System.Drawing.Point(6, 19)
        Me.pb_map_01.Name = "pb_map_01"
        Me.pb_map_01.Size = New System.Drawing.Size(70, 100)
        Me.pb_map_01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_map_01.TabIndex = 1
        Me.pb_map_01.TabStop = False
        '
        'pic_map
        '
        Me.pic_map.BackColor = System.Drawing.Color.White
        Me.pic_map.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pic_map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_map.ContextMenuStrip = Me.menu_preview
        Me.pic_map.Location = New System.Drawing.Point(0, 0)
        Me.pic_map.Name = "pic_map"
        Me.pic_map.Size = New System.Drawing.Size(624, 275)
        Me.pic_map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pic_map.TabIndex = 0
        Me.pic_map.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chk_hide_map)
        Me.GroupBox1.Controls.Add(Me.bt_add_mask)
        Me.GroupBox1.Controls.Add(Me.cb_player_live_update)
        Me.GroupBox1.Controls.Add(Me.cb_overlay)
        Me.GroupBox1.Location = New System.Drawing.Point(631, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(146, 263)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'chk_hide_map
        '
        Me.chk_hide_map.AutoSize = True
        Me.chk_hide_map.Checked = True
        Me.chk_hide_map.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_hide_map.Location = New System.Drawing.Point(7, 66)
        Me.chk_hide_map.Name = "chk_hide_map"
        Me.chk_hide_map.Size = New System.Drawing.Size(84, 17)
        Me.chk_hide_map.TabIndex = 13
        Me.chk_hide_map.Text = "Map Hidden"
        Me.chk_hide_map.UseVisualStyleBackColor = True
        '
        'bt_add_mask
        '
        Me.bt_add_mask.Location = New System.Drawing.Point(6, 92)
        Me.bt_add_mask.Name = "bt_add_mask"
        Me.bt_add_mask.Size = New System.Drawing.Size(134, 23)
        Me.bt_add_mask.TabIndex = 12
        Me.bt_add_mask.Text = "Add Mask"
        Me.bt_add_mask.UseVisualStyleBackColor = True
        '
        'cb_player_live_update
        '
        Me.cb_player_live_update.AutoSize = True
        Me.cb_player_live_update.Location = New System.Drawing.Point(6, 42)
        Me.cb_player_live_update.Name = "cb_player_live_update"
        Me.cb_player_live_update.Size = New System.Drawing.Size(121, 17)
        Me.cb_player_live_update.TabIndex = 11
        Me.cb_player_live_update.Text = "Live Update Players"
        Me.cb_player_live_update.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pb_map_09)
        Me.GroupBox2.Controls.Add(Me.pb_map_01)
        Me.GroupBox2.Controls.Add(Me.pb_map_08)
        Me.GroupBox2.Controls.Add(Me.pb_map_02)
        Me.GroupBox2.Controls.Add(Me.pb_map_07)
        Me.GroupBox2.Controls.Add(Me.pb_map_03)
        Me.GroupBox2.Controls.Add(Me.pb_map_06)
        Me.GroupBox2.Controls.Add(Me.pb_map_04)
        Me.GroupBox2.Controls.Add(Me.pb_map_05)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 281)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(695, 127)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Maps"
        '
        'menu_mask
        '
        Me.menu_mask.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowToolStripMenuItem, Me.HideToolStripMenuItem1})
        Me.menu_mask.Name = "menu_mask"
        Me.menu_mask.Size = New System.Drawing.Size(153, 70)
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ShowToolStripMenuItem.Text = "Show"
        '
        'HideToolStripMenuItem1
        '
        Me.HideToolStripMenuItem1.Name = "HideToolStripMenuItem1"
        Me.HideToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.HideToolStripMenuItem1.Text = "Hide"
        '
        'AdminWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 411)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pic_map)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AdminWindow"
        Me.Text = "AdminTool - AdminMap"
        Me.menu_preview.ResumeLayout(False)
        Me.menu_players.ResumeLayout(False)
        Me.menu_map.ResumeLayout(False)
        CType(Me.pb_map_09, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_map_08, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_map_07, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_map_06, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_map_05, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_map_04, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_map_03, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_map_02, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_map_01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_map, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.menu_mask.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pic_map As PictureBox
    Friend WithEvents ui_updater As Timer
    Friend WithEvents menu_players As ContextMenuStrip
    Friend WithEvents VisibleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HideToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pb_map_01 As PictureBox
    Friend WithEvents menu_map As ContextMenuStrip
    Friend WithEvents LoadImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetMapToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dial_open_img As OpenFileDialog
    Friend WithEvents pb_map_08 As PictureBox
    Friend WithEvents pb_map_07 As PictureBox
    Friend WithEvents pb_map_06 As PictureBox
    Friend WithEvents pb_map_05 As PictureBox
    Friend WithEvents pb_map_04 As PictureBox
    Friend WithEvents pb_map_03 As PictureBox
    Friend WithEvents pb_map_02 As PictureBox
    Friend WithEvents pb_map_09 As PictureBox
    Friend WithEvents Rotate90ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menu_preview As ContextMenuStrip
    Friend WithEvents ClearMapToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ScaleModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents tt_playername As ToolTip
    Friend WithEvents cb_overlay As CheckBox
    Friend WithEvents MoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cb_player_live_update As CheckBox
    Friend WithEvents chk_hide_map As CheckBox
    Friend WithEvents bt_add_mask As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents menu_mask As ContextMenuStrip
    Friend WithEvents ShowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HideToolStripMenuItem1 As ToolStripMenuItem
End Class
