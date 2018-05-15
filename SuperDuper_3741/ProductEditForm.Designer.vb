<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductEditForm
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.nudPrice = New System.Windows.Forms.NumericUpDown()
        Me.nudPurchaseLevel = New System.Windows.Forms.NumericUpDown()
        Me.nudPriority = New System.Windows.Forms.NumericUpDown()
        Me.nudRemaining = New System.Windows.Forms.NumericUpDown()
        Me.tbxName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.nudPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPurchaseLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPriority, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudRemaining, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(195, 237)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(15, 237)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 22
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'nudPrice
        '
        Me.nudPrice.Location = New System.Drawing.Point(150, 173)
        Me.nudPrice.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.nudPrice.Name = "nudPrice"
        Me.nudPrice.Size = New System.Drawing.Size(120, 20)
        Me.nudPrice.TabIndex = 21
        Me.nudPrice.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudPurchaseLevel
        '
        Me.nudPurchaseLevel.Location = New System.Drawing.Point(150, 141)
        Me.nudPurchaseLevel.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.nudPurchaseLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPurchaseLevel.Name = "nudPurchaseLevel"
        Me.nudPurchaseLevel.Size = New System.Drawing.Size(120, 20)
        Me.nudPurchaseLevel.TabIndex = 20
        Me.nudPurchaseLevel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudPriority
        '
        Me.nudPriority.Location = New System.Drawing.Point(150, 103)
        Me.nudPriority.Maximum = New Decimal(New Integer() {1569325056, 23283064, 0, 0})
        Me.nudPriority.Name = "nudPriority"
        Me.nudPriority.Size = New System.Drawing.Size(120, 20)
        Me.nudPriority.TabIndex = 19
        '
        'nudRemaining
        '
        Me.nudRemaining.Location = New System.Drawing.Point(150, 65)
        Me.nudRemaining.Maximum = New Decimal(New Integer() {-1981284352, -1966660860, 0, 0})
        Me.nudRemaining.Name = "nudRemaining"
        Me.nudRemaining.Size = New System.Drawing.Size(120, 20)
        Me.nudRemaining.TabIndex = 18
        '
        'tbxName
        '
        Me.tbxName.Location = New System.Drawing.Point(150, 29)
        Me.tbxName.Name = "tbxName"
        Me.tbxName.Size = New System.Drawing.Size(120, 20)
        Me.tbxName.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Product Price"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Product Purchase Level"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Product Priority"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Product Remaining"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Product Name"
        '
        'ProductEditForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 289)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.nudPrice)
        Me.Controls.Add(Me.nudPurchaseLevel)
        Me.Controls.Add(Me.nudPriority)
        Me.Controls.Add(Me.nudRemaining)
        Me.Controls.Add(Me.tbxName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ProductEditForm"
        Me.Text = "ProductEditForm"
        CType(Me.nudPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPurchaseLevel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPriority, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudRemaining, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents nudPrice As NumericUpDown
    Friend WithEvents nudPurchaseLevel As NumericUpDown
    Friend WithEvents nudPriority As NumericUpDown
    Friend WithEvents nudRemaining As NumericUpDown
    Friend WithEvents tbxName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
