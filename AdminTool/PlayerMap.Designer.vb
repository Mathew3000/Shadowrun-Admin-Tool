<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PlayerMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlayerMap))
        Me.ui_update = New System.Windows.Forms.Timer(Me.components)
        Me.pic_background = New System.Windows.Forms.PictureBox()
        CType(Me.pic_background, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ui_update
        '
        Me.ui_update.Enabled = True
        Me.ui_update.Interval = 10
        '
        'pic_background
        '
        Me.pic_background.BackColor = System.Drawing.Color.White
        Me.pic_background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pic_background.Location = New System.Drawing.Point(0, 0)
        Me.pic_background.Name = "pic_background"
        Me.pic_background.Size = New System.Drawing.Size(715, 331)
        Me.pic_background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pic_background.TabIndex = 0
        Me.pic_background.TabStop = False
        '
        'PlayerMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 331)
        Me.Controls.Add(Me.pic_background)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PlayerMap"
        Me.Text = "Admin Tool - PlayerMap"
        CType(Me.pic_background, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pic_background As PictureBox
    Friend WithEvents ui_update As Timer
End Class
