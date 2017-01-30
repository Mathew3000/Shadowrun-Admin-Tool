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
        Me.pic_map = New System.Windows.Forms.PictureBox()
        Me.ui_updater = New System.Windows.Forms.Timer(Me.components)
        Me.menu_players = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VisibleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pb_map_01 = New System.Windows.Forms.PictureBox()
        Me.menu_map = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LoadImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dial_open_img = New System.Windows.Forms.OpenFileDialog()
        CType(Me.pic_map, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menu_players.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pb_map_01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menu_map.SuspendLayout()
        Me.SuspendLayout()
        '
        'pic_map
        '
        Me.pic_map.BackColor = System.Drawing.Color.White
        Me.pic_map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic_map.Location = New System.Drawing.Point(0, 0)
        Me.pic_map.Name = "pic_map"
        Me.pic_map.Size = New System.Drawing.Size(624, 275)
        Me.pic_map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pic_map.TabIndex = 0
        Me.pic_map.TabStop = False
        '
        'ui_updater
        '
        Me.ui_updater.Enabled = True
        Me.ui_updater.Interval = 10
        '
        'menu_players
        '
        Me.menu_players.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VisibleToolStripMenuItem, Me.HideToolStripMenuItem})
        Me.menu_players.Name = "menu_players"
        Me.menu_players.Size = New System.Drawing.Size(104, 48)
        '
        'VisibleToolStripMenuItem
        '
        Me.VisibleToolStripMenuItem.Name = "VisibleToolStripMenuItem"
        Me.VisibleToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.VisibleToolStripMenuItem.Text = "Show"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.HideToolStripMenuItem.Text = "Hide"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pb_map_01)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 281)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(366, 124)
        Me.Panel1.TabIndex = 2
        '
        'pb_map_01
        '
        Me.pb_map_01.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pb_map_01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_map_01.ContextMenuStrip = Me.menu_map
        Me.pb_map_01.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_map_01.Location = New System.Drawing.Point(5, 19)
        Me.pb_map_01.Name = "pb_map_01"
        Me.pb_map_01.Size = New System.Drawing.Size(70, 100)
        Me.pb_map_01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_map_01.TabIndex = 1
        Me.pb_map_01.TabStop = False
        '
        'menu_map
        '
        Me.menu_map.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadImageToolStripMenuItem, Me.SetMapToolStripMenuItem})
        Me.menu_map.Name = "menu_map"
        Me.menu_map.Size = New System.Drawing.Size(137, 48)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Maps"
        '
        'dial_open_img
        '
        Me.dial_open_img.Filter = "Bilder |*.png; *.bmp; *.jpg; *.jpeg; *.gif"
        '
        'AdminWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 417)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pic_map)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AdminWindow"
        Me.Text = "AdminTool - AdminMap"
        CType(Me.pic_map, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menu_players.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pb_map_01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menu_map.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pic_map As PictureBox
    Friend WithEvents ui_updater As Timer
    Friend WithEvents menu_players As ContextMenuStrip
    Friend WithEvents VisibleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HideToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pb_map_01 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents menu_map As ContextMenuStrip
    Friend WithEvents LoadImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetMapToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dial_open_img As OpenFileDialog
End Class
