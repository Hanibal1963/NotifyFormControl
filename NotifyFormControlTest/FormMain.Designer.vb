<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.NumericUpDown_ShowTime = New System.Windows.Forms.NumericUpDown()
        Me.Label_ShowTime = New System.Windows.Forms.Label()
        Me.TextBox_Title = New System.Windows.Forms.TextBox()
        Me.TextBox_Message = New System.Windows.Forms.TextBox()
        Me.Label_Title = New System.Windows.Forms.Label()
        Me.Label_Message = New System.Windows.Forms.Label()
        Me.ComboBox_Style = New System.Windows.Forms.ComboBox()
        Me.ComboBox_Design = New System.Windows.Forms.ComboBox()
        Me.NotifyForm = New SchlumpfSoft.Controls.NotifyFormControl.NotifyForm()
        Me.Button_ShowWindow = New System.Windows.Forms.Button()
        CType(Me.NumericUpDown_ShowTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumericUpDown_ShowTime
        '
        Me.NumericUpDown_ShowTime.Location = New System.Drawing.Point(165, 227)
        Me.NumericUpDown_ShowTime.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDown_ShowTime.Name = "NumericUpDown_ShowTime"
        Me.NumericUpDown_ShowTime.Size = New System.Drawing.Size(46, 20)
        Me.NumericUpDown_ShowTime.TabIndex = 0
        '
        'Label_ShowTime
        '
        Me.Label_ShowTime.AutoSize = True
        Me.Label_ShowTime.Location = New System.Drawing.Point(12, 229)
        Me.Label_ShowTime.Name = "Label_ShowTime"
        Me.Label_ShowTime.Size = New System.Drawing.Size(101, 13)
        Me.Label_ShowTime.TabIndex = 1
        Me.Label_ShowTime.Text = "Anzeigedauer (sec):"
        '
        'TextBox_Title
        '
        Me.TextBox_Title.Location = New System.Drawing.Point(165, 16)
        Me.TextBox_Title.Name = "TextBox_Title"
        Me.TextBox_Title.Size = New System.Drawing.Size(163, 20)
        Me.TextBox_Title.TabIndex = 2
        '
        'TextBox_Message
        '
        Me.TextBox_Message.Location = New System.Drawing.Point(165, 51)
        Me.TextBox_Message.Multiline = True
        Me.TextBox_Message.Name = "TextBox_Message"
        Me.TextBox_Message.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox_Message.Size = New System.Drawing.Size(163, 79)
        Me.TextBox_Message.TabIndex = 3
        '
        'Label_Title
        '
        Me.Label_Title.AutoSize = True
        Me.Label_Title.Location = New System.Drawing.Point(12, 19)
        Me.Label_Title.Name = "Label_Title"
        Me.Label_Title.Size = New System.Drawing.Size(96, 13)
        Me.Label_Title.TabIndex = 4
        Me.Label_Title.Text = "Text der Titelleiste:"
        '
        'Label_Message
        '
        Me.Label_Message.AutoSize = True
        Me.Label_Message.Location = New System.Drawing.Point(12, 54)
        Me.Label_Message.Name = "Label_Message"
        Me.Label_Message.Size = New System.Drawing.Size(77, 13)
        Me.Label_Message.TabIndex = 5
        Me.Label_Message.Text = "Mitteilungstext:"
        '
        'ComboBox_Style
        '
        Me.ComboBox_Style.FormattingEnabled = True
        Me.ComboBox_Style.Items.AddRange(New Object() {"Information", "Frage", "Fehler", "Warnung"})
        Me.ComboBox_Style.Location = New System.Drawing.Point(165, 148)
        Me.ComboBox_Style.Name = "ComboBox_Style"
        Me.ComboBox_Style.Size = New System.Drawing.Size(163, 21)
        Me.ComboBox_Style.TabIndex = 6
        '
        'ComboBox_Design
        '
        Me.ComboBox_Design.FormattingEnabled = True
        Me.ComboBox_Design.Items.AddRange(New Object() {"Hell", "Farbig", "Dunkel"})
        Me.ComboBox_Design.Location = New System.Drawing.Point(165, 189)
        Me.ComboBox_Design.Name = "ComboBox_Design"
        Me.ComboBox_Design.Size = New System.Drawing.Size(163, 21)
        Me.ComboBox_Design.TabIndex = 7
        '
        'NotifyForm
        '
        Me.NotifyForm.Design = SchlumpfSoft.Controls.NotifyFormControl.NotifyFormDesign.Bright
        Me.NotifyForm.Message = "Mitteilung"
        Me.NotifyForm.ShowTime = 5000
        Me.NotifyForm.Style = SchlumpfSoft.Controls.NotifyFormControl.NotifyFormStyle.Information
        Me.NotifyForm.Title = "Titel"
        '
        'Button_ShowWindow
        '
        Me.Button_ShowWindow.Location = New System.Drawing.Point(225, 266)
        Me.Button_ShowWindow.Name = "Button_ShowWindow"
        Me.Button_ShowWindow.Size = New System.Drawing.Size(103, 28)
        Me.Button_ShowWindow.TabIndex = 8
        Me.Button_ShowWindow.Text = "Fenster anzeigen"
        Me.Button_ShowWindow.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 306)
        Me.Controls.Add(Me.Button_ShowWindow)
        Me.Controls.Add(Me.ComboBox_Design)
        Me.Controls.Add(Me.ComboBox_Style)
        Me.Controls.Add(Me.Label_Message)
        Me.Controls.Add(Me.Label_Title)
        Me.Controls.Add(Me.TextBox_Message)
        Me.Controls.Add(Me.TextBox_Title)
        Me.Controls.Add(Me.Label_ShowTime)
        Me.Controls.Add(Me.NumericUpDown_ShowTime)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormMain"
        CType(Me.NumericUpDown_ShowTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents NotifyForm As SchlumpfSoft.Controls.NotifyFormControl.NotifyForm
    Private WithEvents NumericUpDown_ShowTime As NumericUpDown
    Private WithEvents Label_ShowTime As Label
    Private WithEvents TextBox_Title As TextBox
    Private WithEvents TextBox_Message As TextBox
    Private WithEvents Label_Title As Label
    Private WithEvents Label_Message As Label
    Private WithEvents ComboBox_Style As ComboBox
    Private WithEvents ComboBox_Design As ComboBox
    Private WithEvents Button_ShowWindow As Button
End Class
