<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnCheck = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.txtInitialDirectory = New System.Windows.Forms.TextBox
        Me.txtDirectoryToCheck = New System.Windows.Forms.TextBox
        Me.btnFolder1 = New System.Windows.Forms.Button
        Me.btnFolder2 = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCheck
        '
        Me.btnCheck.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCheck.Location = New System.Drawing.Point(219, 244)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(75, 23)
        Me.btnCheck.TabIndex = 0
        Me.btnCheck.Text = "Verify Files"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(12, 62)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(503, 176)
        Me.TextBox1.TabIndex = 1
        '
        'txtInitialDirectory
        '
        Me.txtInitialDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInitialDirectory.Location = New System.Drawing.Point(12, 9)
        Me.txtInitialDirectory.Name = "txtInitialDirectory"
        Me.txtInitialDirectory.Size = New System.Drawing.Size(392, 20)
        Me.txtInitialDirectory.TabIndex = 2
        '
        'txtDirectoryToCheck
        '
        Me.txtDirectoryToCheck.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDirectoryToCheck.Location = New System.Drawing.Point(12, 35)
        Me.txtDirectoryToCheck.Name = "txtDirectoryToCheck"
        Me.txtDirectoryToCheck.Size = New System.Drawing.Size(392, 20)
        Me.txtDirectoryToCheck.TabIndex = 3
        '
        'btnFolder1
        '
        Me.btnFolder1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFolder1.Location = New System.Drawing.Point(410, 8)
        Me.btnFolder1.Name = "btnFolder1"
        Me.btnFolder1.Size = New System.Drawing.Size(105, 21)
        Me.btnFolder1.TabIndex = 4
        Me.btnFolder1.Text = "Source Folder"
        Me.btnFolder1.UseVisualStyleBackColor = True
        '
        'btnFolder2
        '
        Me.btnFolder2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFolder2.Location = New System.Drawing.Point(410, 35)
        Me.btnFolder2.Name = "btnFolder2"
        Me.btnFolder2.Size = New System.Drawing.Size(105, 21)
        Me.btnFolder2.TabIndex = 5
        Me.btnFolder2.Text = "Target Folder"
        Me.btnFolder2.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(345, 244)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(170, 23)
        Me.ProgressBar1.TabIndex = 6
        Me.ProgressBar1.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 270)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(533, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 292)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnFolder2)
        Me.Controls.Add(Me.btnFolder1)
        Me.Controls.Add(Me.txtDirectoryToCheck)
        Me.Controls.Add(Me.txtInitialDirectory)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnCheck)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Directory Compare"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtInitialDirectory As System.Windows.Forms.TextBox
    Friend WithEvents txtDirectoryToCheck As System.Windows.Forms.TextBox
    Friend WithEvents btnFolder1 As System.Windows.Forms.Button
    Friend WithEvents btnFolder2 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel

End Class
