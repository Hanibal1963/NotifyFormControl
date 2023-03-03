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
		Dim Label1 As System.Windows.Forms.Label
		Dim Label2 As System.Windows.Forms.Label
		Dim Label3 As System.Windows.Forms.Label
		Dim Label4 As System.Windows.Forms.Label
		Dim Label5 As System.Windows.Forms.Label
		Me.NotifyForm1 = New SchlumpfSoft.Controls.NotifyForm()
		Me.ButtonStart = New System.Windows.Forms.Button()
		Me.ComboBoxDesign = New System.Windows.Forms.ComboBox()
		Me.ComboBoxstyle = New System.Windows.Forms.ComboBox()
		Me.TextBoxTitle = New System.Windows.Forms.TextBox()
		Me.RichTextBoxMessage = New System.Windows.Forms.RichTextBox()
		Me.NumericUpDownTime = New System.Windows.Forms.NumericUpDown()
		Label1 = New System.Windows.Forms.Label()
		Label2 = New System.Windows.Forms.Label()
		Label3 = New System.Windows.Forms.Label()
		Label4 = New System.Windows.Forms.Label()
		Label5 = New System.Windows.Forms.Label()
		CType(Me.NumericUpDownTime, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Label1
		'
		Label1.AutoSize = True
		Label1.Location = New System.Drawing.Point(12, 18)
		Label1.Name = "Label1"
		Label1.Size = New System.Drawing.Size(73, 13)
		Label1.TabIndex = 1
		Label1.Text = "Fensterdesign"
		'
		'Label2
		'
		Label2.AutoSize = True
		Label2.Location = New System.Drawing.Point(12, 62)
		Label2.Name = "Label2"
		Label2.Size = New System.Drawing.Size(63, 13)
		Label2.TabIndex = 2
		Label2.Text = "Fensterstyle"
		'
		'Label3
		'
		Label3.AutoSize = True
		Label3.Location = New System.Drawing.Point(12, 103)
		Label3.Name = "Label3"
		Label3.Size = New System.Drawing.Size(44, 13)
		Label3.TabIndex = 6
		Label3.Text = "Titeltext"
		'
		'Label4
		'
		Label4.AutoSize = True
		Label4.Location = New System.Drawing.Point(12, 138)
		Label4.Name = "Label4"
		Label4.Size = New System.Drawing.Size(70, 13)
		Label4.TabIndex = 8
		Label4.Text = "Meldungstext"
		'
		'Label5
		'
		Label5.AutoSize = True
		Label5.Location = New System.Drawing.Point(12, 230)
		Label5.Name = "Label5"
		Label5.Size = New System.Drawing.Size(98, 13)
		Label5.TabIndex = 9
		Label5.Text = "Anzeigedauer (sec)"
		'
		'NotifyForm1
		'
		Me.NotifyForm1.Design = SchlumpfSoft.Controls.NotifyFormDesign.Bright
		Me.NotifyForm1.Message = Nothing
		Me.NotifyForm1.ShowTime = 5000
		Me.NotifyForm1.Style = SchlumpfSoft.Controls.NotifyFormStyle.Information
		Me.NotifyForm1.Title = Nothing
		'
		'ButtonStart
		'
		Me.ButtonStart.Location = New System.Drawing.Point(15, 266)
		Me.ButtonStart.Name = "ButtonStart"
		Me.ButtonStart.Size = New System.Drawing.Size(248, 29)
		Me.ButtonStart.TabIndex = 0
		Me.ButtonStart.Text = "Meldungsfenster anzeigen"
		Me.ButtonStart.UseVisualStyleBackColor = True
		'
		'ComboBoxDesign
		'
		Me.ComboBoxDesign.FormattingEnabled = True
		Me.ComboBoxDesign.Items.AddRange(New Object() {"Hell", "Farbig", "Dunkel"})
		Me.ComboBoxDesign.Location = New System.Drawing.Point(111, 18)
		Me.ComboBoxDesign.Name = "ComboBoxDesign"
		Me.ComboBoxDesign.Size = New System.Drawing.Size(155, 21)
		Me.ComboBoxDesign.TabIndex = 3
		'
		'ComboBoxstyle
		'
		Me.ComboBoxstyle.FormattingEnabled = True
		Me.ComboBoxstyle.Items.AddRange(New Object() {"Information", "Frage", "Fehler", "Warnung"})
		Me.ComboBoxstyle.Location = New System.Drawing.Point(111, 59)
		Me.ComboBoxstyle.Name = "ComboBoxstyle"
		Me.ComboBoxstyle.Size = New System.Drawing.Size(155, 21)
		Me.ComboBoxstyle.TabIndex = 4
		'
		'TextBoxTitle
		'
		Me.TextBoxTitle.Location = New System.Drawing.Point(111, 100)
		Me.TextBoxTitle.Name = "TextBoxTitle"
		Me.TextBoxTitle.Size = New System.Drawing.Size(155, 20)
		Me.TextBoxTitle.TabIndex = 5
		'
		'RichTextBoxMessage
		'
		Me.RichTextBoxMessage.Location = New System.Drawing.Point(111, 135)
		Me.RichTextBoxMessage.Name = "RichTextBoxMessage"
		Me.RichTextBoxMessage.Size = New System.Drawing.Size(155, 81)
		Me.RichTextBoxMessage.TabIndex = 7
		Me.RichTextBoxMessage.Text = ""
		'
		'NumericUpDownTime
		'
		Me.NumericUpDownTime.Location = New System.Drawing.Point(205, 228)
		Me.NumericUpDownTime.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
		Me.NumericUpDownTime.Name = "NumericUpDownTime"
		Me.NumericUpDownTime.Size = New System.Drawing.Size(58, 20)
		Me.NumericUpDownTime.TabIndex = 10
		Me.NumericUpDownTime.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
		'
		'FormMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(278, 311)
		Me.Controls.Add(Me.NumericUpDownTime)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Me.RichTextBoxMessage)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Me.TextBoxTitle)
		Me.Controls.Add(Me.ComboBoxstyle)
		Me.Controls.Add(Me.ComboBoxDesign)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(Me.ButtonStart)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "FormMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "NotifyForm Demo"
		CType(Me.NumericUpDownTime, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents NotifyForm1 As SchlumpfSoft.Controls.NotifyForm
	Friend WithEvents ButtonStart As Button
	Friend WithEvents ComboBoxDesign As ComboBox
	Friend WithEvents ComboBoxstyle As ComboBox
	Friend WithEvents TextBoxTitle As TextBox
	Friend WithEvents RichTextBoxMessage As RichTextBox
	Friend WithEvents NumericUpDownTime As NumericUpDown
End Class
