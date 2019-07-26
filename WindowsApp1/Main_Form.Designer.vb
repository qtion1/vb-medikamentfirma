<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Form
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
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Button_Refresh = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button_Clear = New System.Windows.Forms.Button()
        Me.Button_Cancel = New System.Windows.Forms.Button()
        Me.Button_View = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll
        Me.TreeView1.HideSelection = False
        Me.TreeView1.Location = New System.Drawing.Point(12, 12)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.Size = New System.Drawing.Size(209, 368)
        Me.TreeView1.TabIndex = 5
        '
        'Button_Refresh
        '
        Me.Button_Refresh.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button_Refresh.Location = New System.Drawing.Point(21, 386)
        Me.Button_Refresh.Name = "Button_Refresh"
        Me.Button_Refresh.Size = New System.Drawing.Size(99, 32)
        Me.Button_Refresh.TabIndex = 6
        Me.Button_Refresh.Text = "Aktualisieren"
        Me.Button_Refresh.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(227, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1023, 647)
        Me.DataGridView1.TabIndex = 7
        '
        'Button_Clear
        '
        Me.Button_Clear.Location = New System.Drawing.Point(126, 386)
        Me.Button_Clear.Name = "Button_Clear"
        Me.Button_Clear.Size = New System.Drawing.Size(82, 32)
        Me.Button_Clear.TabIndex = 8
        Me.Button_Clear.Text = "Löschen"
        Me.Button_Clear.UseVisualStyleBackColor = True
        '
        'Button_Cancel
        '
        Me.Button_Cancel.Location = New System.Drawing.Point(126, 424)
        Me.Button_Cancel.Name = "Button_Cancel"
        Me.Button_Cancel.Size = New System.Drawing.Size(82, 32)
        Me.Button_Cancel.TabIndex = 9
        Me.Button_Cancel.Text = "Abbrechen"
        Me.Button_Cancel.UseVisualStyleBackColor = True
        '
        'Button_View
        '
        Me.Button_View.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button_View.Location = New System.Drawing.Point(21, 424)
        Me.Button_View.Name = "Button_View"
        Me.Button_View.Size = New System.Drawing.Size(82, 32)
        Me.Button_View.TabIndex = 10
        Me.Button_View.Text = "View"
        Me.Button_View.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(28, 462)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 32)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Bearbeitungstools"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Location = New System.Drawing.Point(12, 500)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(209, 159)
        Me.Panel1.TabIndex = 12
        Me.Panel1.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(26, 108)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(148, 37)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "DELETE"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(26, 61)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(148, 37)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "UPDATE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(26, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(148, 37)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "INSERT"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Main_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1262, 671)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button_View)
        Me.Controls.Add(Me.Button_Cancel)
        Me.Controls.Add(Me.Button_Clear)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button_Refresh)
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "Main_Form"
        Me.Text = "Main Form"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button_Refresh As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents Button_Clear As Button
    Friend WithEvents Button_Cancel As Button
    Friend WithEvents Button_View As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
End Class
