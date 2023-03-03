'
'****************************************************************************************************************
'NotifyForm.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'


''' <summary>
''' Control zum anzeigen von Benachrichtigungsfenstern.
''' </summary>
<ProvideToolboxControl("SchlumpfSoft", False)>
<System.ComponentModel.ToolboxItem(True)>
<System.ComponentModel.Description("Control zum anzeigen von Benachrichtigungsfenstern.")>
Public Class NotifyForm


	Inherits System.ComponentModel.Component


	''' <summary>
	''' Legt das Aussehen des Benachrichtigungsfensters fest.
	''' </summary>
	<System.ComponentModel.Browsable(True)>
	<System.ComponentModel.Category("Appearance")>
	<System.ComponentModel.Description("Legt das Aussehen des Benachrichtigungsfensters fest.")>
	Public Property Design As NotifyFormDesign


	''' <summary>
	''' Legt den Benachrichtigungstext fest der angezeigt werden soll.
	''' </summary>
	<System.ComponentModel.Browsable(True)>
	<System.ComponentModel.Category("Appearance")>
	<System.ComponentModel.Description("Legt den Benachrichtigungstext fest der angezeigt werden soll.")>
	Public Property Message As String


	''' <summary>
	''' Legt die Anzeigedauer des Benachrichtigungsfensters in ms fest.
	''' </summary>
	''' <remarks>
	''' Der Wert 0 bewirkt das kein automatisches schließen des Fensters erfolgt.
	''' </remarks>
	<System.ComponentModel.Browsable(True)>
	<System.ComponentModel.Category("Behavior")>
	<System.ComponentModel.Description("Legt die Anzeigedauer des Benachrichtigungsfensters in ms fest. (Der Wert 0 deaktiviert das automatische schließen.)")>
	Public Property ShowTime As Integer = 5000


	''' <summary>
	''' Legt das anzuzeigende Symbol im Benachrichtigungsfensters fest.
	''' </summary>
	<System.ComponentModel.Browsable(True)>
	<System.ComponentModel.Category("Appearance")>
	<System.ComponentModel.Description("Legt das anzuzeigende Symbol des Benachrichtigungsfensters fest.")>
	Public Property Style As NotifyFormStyle


	''' <summary>
	''' Legt den Text der Titelzeile des Benachrichtigungsfensters fest.
	''' </summary>
	<System.ComponentModel.Browsable(True)>
	<System.ComponentModel.Category("Appearance")>
	<System.ComponentModel.Description("Legt den Text der Titelzeile des Benachrichtigungsfensters fest.")>
	Public Property Title As String



	''' <summary>
	''' Zeigt das Meldungsfenster an.
	''' </summary>
	Public Sub Show()

		Dim _image As System.Drawing.Image = SetFormImage()
		Form.Image = _image
		Form.Title = Title
		Form.Message = Message
		Form.Showtime = ShowTime
		SetFormDesign()

	End Sub


	''' <summary>
	''' Filter für das Design des Fensters 
	''' </summary>
	Private Sub SetFormDesign()

		Select Case Design
			Case NotifyFormDesign.Bright : SetFormDesignBright()
			Case NotifyFormDesign.Colorful : SetFormDesignColorful()
			Case NotifyFormDesign.Dark : SetFormDesignDark()
		End Select

	End Sub


	''' <summary>
	''' Setzt das Design auf Hell
	''' </summary>
	Private Shared Sub SetFormDesignBright()

		Form.Background = System.Drawing.Color.White
		Form.TextField = System.Drawing.Color.White
		Form.TitleBar = System.Drawing.Color.Gray
		Form.Fontcolor = System.Drawing.Color.Black
		Dim ini As New Form
		ini.Initialize()

	End Sub


	''' <summary>
	''' Setz das Design auf Farbig
	''' </summary>
	Private Shared Sub SetFormDesignColorful()

		Form.Background = System.Drawing.Color.LightBlue
		Form.TextField = System.Drawing.Color.LightBlue
		Form.TitleBar = System.Drawing.Color.LightSeaGreen
		Form.Fontcolor = System.Drawing.Color.White
		Dim ini As New Form
		ini.Initialize()

	End Sub


	''' <summary>
	''' Setz das Design auf Dunkel
	''' </summary>
	Private Shared Sub SetFormDesignDark()

		Form.Background = System.Drawing.Color.FromArgb(83, 79, 75)
		Form.TextField = System.Drawing.Color.FromArgb(83, 79, 75)
		Form.TitleBar = System.Drawing.Color.FromArgb(60, 57, 54)
		Form.Fontcolor = System.Drawing.Color.White
		Dim ini As New Form
		ini.Initialize()

	End Sub


	''' <summary>
	''' Gibt das Symbol für das Fenster in Abhängigkeit vom Style zurück
	''' </summary>
	''' <returns></returns>
	Private Function SetFormImage() As System.Drawing.Image

		Select Case Style
			Case NotifyFormStyle.CriticalError : Return My.Resources._Error
			Case NotifyFormStyle.Exclamation : Return My.Resources._Warning
			Case NotifyFormStyle.Information : Return My.Resources._Info
			Case NotifyFormStyle.Question : Return My.Resources._Question
			Case Else : Return Nothing
		End Select

	End Function


End Class




