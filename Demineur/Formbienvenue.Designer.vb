<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Formbienvenue
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Formbienvenue))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btndifficile = New System.Windows.Forms.Button()
        Me.btnnormal = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Monotype Corsiva", 22.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(208, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 68)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = " Bonjour !" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btndifficile
        '
        Me.btndifficile.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btndifficile.Font = New System.Drawing.Font("Monotype Corsiva", 14.0!, System.Drawing.FontStyle.Italic)
        Me.btndifficile.Location = New System.Drawing.Point(135, 328)
        Me.btndifficile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btndifficile.Name = "btndifficile"
        Me.btndifficile.Size = New System.Drawing.Size(351, 58)
        Me.btndifficile.TabIndex = 6
        Me.btndifficile.Text = "Difficile"
        Me.btndifficile.UseVisualStyleBackColor = False
        '
        'btnnormal
        '
        Me.btnnormal.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnnormal.Font = New System.Drawing.Font("Monotype Corsiva", 14.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnormal.Location = New System.Drawing.Point(135, 215)
        Me.btnnormal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnnormal.Name = "btnnormal"
        Me.btnnormal.Size = New System.Drawing.Size(351, 66)
        Me.btnnormal.TabIndex = 5
        Me.btnnormal.Text = "Normal"
        Me.btnnormal.UseVisualStyleBackColor = False
        '
        'Formbienvenue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(609, 535)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btndifficile)
        Me.Controls.Add(Me.btnnormal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Formbienvenue"
        Me.Text = "Bienvenue"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents btndifficile As Button
    Friend WithEvents btnnormal As Button
End Class
