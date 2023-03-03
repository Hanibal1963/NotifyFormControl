'
'****************************************************************************************************************
'FormTemplate.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'



Friend Class Form


	Inherits System.Windows.Forms.Form


	'Eigenschaften
	Public Shared Background As System.Drawing.Color
	Public Shared Fontcolor As System.Drawing.Color
	Public Shared Image As System.Drawing.Image
	Public Shared Message As String
	Public Shared Showtime As Integer
	Public Shared TextField As System.Drawing.Color
	Public Shared Title As String
	Public Shared TitleBar As System.Drawing.Color


	Private ReadOnly LblClose As New System.Windows.Forms.Label
	Private ReadOnly LblTitle As New System.Windows.Forms.Label
	Private ReadOnly PanelSpacer As New System.Windows.Forms.Panel
	Private ReadOnly PanelTitle As New System.Windows.Forms.Panel
	Private ReadOnly PicBoxImage As New System.Windows.Forms.PictureBox
	Private ReadOnly RiTxtMsg As New System.Windows.Forms.RichTextBox


	Private CloseThread As System.Threading.Thread


	Sub CloseForm()

		If InvokeRequired Then
			Dim unused = Invoke(New System.Windows.Forms.MethodInvoker(AddressOf CloseForm))
		Else
			Close()
		End If

	End Sub


	''' <summary>
	''' Initialisiert ein Fenster mit entsprechenden Eigenschaften
	''' </summary>
	Public Sub Initialize()

		With Me
			.MaximizeBox = False
			.MinimizeBox = False
			.BackColor = Background
			.ForeColor = Fontcolor
			.Size = New System.Drawing.Size(504, 138)
			.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
			.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		End With

		Show()

	End Sub


	''' <summary>
	''' Führt eine Komponentenbereinigung durch
	''' </summary>
	''' <param name="disposing"></param>
	Protected Overrides Sub Dispose(disposing As Boolean)

		'Bereinigung durchführen
		LblClose.Dispose()
		LblTitle.Dispose()
		PanelSpacer.Dispose()
		PanelTitle.Dispose()
		PicBoxImage.Dispose()
		RiTxtMsg.Dispose()

		MyBase.Dispose(disposing)

	End Sub


	''' <summary>
	''' Fügt dem Fenster die Controls hinzu
	''' </summary>
	Private Sub AddControls()

		With Controls
			.Add(LblTitle)
			.Add(LblClose)
			.Add(PanelSpacer)
			.Add(PanelTitle)
			.Add(RiTxtMsg)
			.Add(PicBoxImage)
		End With

	End Sub


	''' <summary>
	''' Führt das automatische schließen des Fensters in Abhängigkeit von der Anzeigezeit durch
	''' </summary>
	Private Sub AutoClose()

		'Fenster nur automatisch schließen wenn Zeit > 0 ist.
		If Showtime > 0 Then
			System.Threading.Thread.Sleep(Showtime)
			closeForm()
		End If

	End Sub


	''' <summary>
	''' 
	''' </summary>
	''' <param name="sender"></param>
	''' <param name="e"></param>
	Private Sub Form_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing

		System.Threading.Thread.Sleep(150)
		For iCount As Integer = 90 To 10 Step -15
			Opacity = iCount / 110
			Refresh()
			System.Threading.Thread.Sleep(60)
		Next

	End Sub


	Private Sub Form_Load(sender As Object, e As System.EventArgs) Handles Me.Load

		Opacity = 0.1
		SetPropertys_Lbl_Close()
		SetPropertys_Panel_Spacer()
		SetPropertys_Pb_Image()
		SetPropertys_Panel_Title()
		SetPropertys_Lbl_Title()
		SetPropertys_Txt_Msg()
		AddControls()
		ActiveControl = Controls.Item(1)

		'Ändern Sie die Position in die untere rechte Ecke
		Dim x As Integer = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width
		Dim y As Integer = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - Height - 50

		Do Until x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - Width
			x -= 1
			Location = New System.Drawing.Point(x, y)
		Loop

		AddHandler LblClose.Click, AddressOf Lbl_Close_Click
		FormFadeIn()

		'Starte Thread für Autoclose-Popup.
		CloseThread = New System.Threading.Thread(AddressOf AutoClose) With {.IsBackground = True}
		CloseThread.Start()

	End Sub


	''' <summary>
	''' Führt das Ausblenden des Fensters durch
	''' </summary>
	Private Sub FormFadeIn()

		For iCount As Integer = 10 To 100 Step +15
			Opacity = iCount / 100
			Refresh()
			System.Threading.Thread.Sleep(60)
		Next

	End Sub


	Private Sub Lbl_Close_Click(sender As Object, e As System.EventArgs)

		Close()

	End Sub


	Private Sub SetPropertys_Lbl_Close()

		With LblClose
			.AutoSize = True
			.BackColor = TitleBar
			.ForeColor = Fontcolor
			.Location = New System.Drawing.Point(478, 9)
			.Name = "LblClose"
			.Size = New System.Drawing.Size(14, 13)
			.TabIndex = 1
			.Text = My.Resources.NotifyFormCloseSymbol
		End With

	End Sub


	Private Sub SetPropertys_Lbl_Title()

		With LblTitle
			.AutoSize = True
			.BackColor = TitleBar
			.ForeColor = Fontcolor
			.Location = New System.Drawing.Point(11, 9)
			.Name = "LblTitle"
			.Size = New System.Drawing.Size(27, 13)
			.TabIndex = 0
			.Text = Title
		End With

	End Sub


	Private Sub SetPropertys_Panel_Spacer()

		With PanelSpacer
			.BackColor = TitleBar
			.Location = New System.Drawing.Point(119, 36)
			.Name = "PanelSpacer"
			.Size = New System.Drawing.Size(1, 92)
			.TabIndex = 2
		End With

	End Sub


	Private Sub SetPropertys_Panel_Title()

		With PanelTitle
			.BackColor = TitleBar
			.Controls.Add(LblClose)
			.Controls.Add(LblTitle)
			.Location = New System.Drawing.Point(0, -1)
			.Name = "PanelTitle"
			.Size = New System.Drawing.Size(505, 29)
			.TabIndex = 0
		End With

	End Sub


	Private Sub SetPropertys_Pb_Image()

		With PicBoxImage
			.BackColor = System.Drawing.Color.Transparent
			.Location = New System.Drawing.Point(12, 36)
			.Name = "PicBoxImage"
			.Size = New System.Drawing.Size(92, 92)
			.TabIndex = 1
			.TabStop = False
			.Image = Image
			.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			.Refresh()
		End With

	End Sub


	Private Sub SetPropertys_Txt_Msg()

		With RiTxtMsg
			.BackColor = TextField
			.ForeColor = Fontcolor
			.BorderStyle = System.Windows.Forms.BorderStyle.None
			.Location = New System.Drawing.Point(133, 37)
			.Multiline = True
			.Name = "RiTxtMsg"
			.Size = New System.Drawing.Size(361, 90)
			.TabIndex = 3
			.ReadOnly = True
			.Text = Message
			.SelectionProtected = True
			.Cursor = System.Windows.Forms.Cursors.Arrow
		End With

	End Sub



End Class
