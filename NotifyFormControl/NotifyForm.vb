' ****************************************************************************************************************
' NotifyForm.vb
' © 2023 - 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Imports System.ComponentModel
Imports System.Drawing

''' <summary>Control zum anzeigen von Benachrichtigungsfenstern.</summary>
<ProvideToolboxControl("SchlumpfSoft Controls", False)>
<Description("Control zum Anzeigen von Benachrichtigungsfenstern.")>
<ToolboxItem(True)>
<ToolboxBitmap(GetType(NotifyForm), "NotifyForm.bmp")>
Public Class NotifyForm

    Inherits Component

    ''' <summary>Legt das Aussehen des Benachrichtigungsfensters fest.</summary>
    <Browsable(True)>
    <Category("Appearance")>
    <Description("Legt das Aussehen des Benachrichtigungsfensters fest.")>
    Public Property Design As FormDesign = FormDesign.Bright

    ''' <summary>Legt den Benachrichtigungstext fest der angezeigt werden soll.</summary>
    <Browsable(True)>
    <Category("Appearance")>
    <Description("Legt den Benachrichtigungstext fest der angezeigt werden soll oder gibt diesen zurück.")>
    Public Property Message As String = $"Fensternachricht"

    ''' <summary>Legt die Anzeigedauer des Benachrichtigungsfensters in ms fest.</summary>
    ''' <remarks>Der Wert 0 bewirkt das kein automatisches schließen des Fensters erfolgt.</remarks>
    <Browsable(True)>
    <Category("Behavior")>
    <Description("Legt die Anzeigedauer des Benachrichtigungsfensters in ms fest oder gibt diese zurück. (Der Wert 0 deaktiviert das automatische schließen.)")>
    Public Property ShowTime As Integer = 5000

    ''' <summary>Legt das anzuzeigende Symbol im Benachrichtigungsfensters fest.</summary>
    <Browsable(True)>
    <Category("Appearance")>
    <Description("Legt das anzuzeigende Symbol des Benachrichtigungsfensters fest oder gibt dieses zurück.")>
    Public Property Style As FormStyle = FormStyle.Information

    ''' <summary>Legt den Text der Titelzeile des Benachrichtigungsfensters fest.</summary>
    <Browsable(True)>
    <Category("Appearance")>
    <Description("Legt den Text der Titelzeile des Benachrichtigungsfensters fest oder gibt diesen zurück.")>
    Public Property Title As String = $"Fenstertitel"

    ''' <summary>Zeigt das Meldungsfenster an.</summary>
    Public Sub Show()
        Dim image As Image = Me.SetFormImage()
        FormTemplate.Image = image
        FormTemplate.Title = Me.Title
        FormTemplate.Message = Me.Message
        FormTemplate.ShowTime = Me.ShowTime
        Me.SetFormDesign()
    End Sub

    Private Sub SetFormDesign()
        Select Case Me.Design
            Case FormDesign.Bright : SetFormDesignBright()
            Case FormDesign.Colorful : SetFormDesignColorful()
            Case FormDesign.Dark : SetFormDesignDark()
        End Select
    End Sub

    Private Shared Sub SetFormDesignBright()
        FormTemplate.BackgroundColor = Color.White
        FormTemplate.TextFieldColor = Color.White
        FormTemplate.TitleBarColor = Color.Gray
        FormTemplate.FontColor = Color.Black
        Dim ini As New FormTemplate
        ini.Initialize()
    End Sub

    Private Shared Sub SetFormDesignColorful()
        FormTemplate.BackgroundColor = Color.LightBlue
        FormTemplate.TextFieldColor = Color.LightBlue
        FormTemplate.TitleBarColor = Color.LightSeaGreen
        FormTemplate.FontColor = Color.White
        Dim ini As New FormTemplate
        ini.Initialize()
    End Sub

    Private Shared Sub SetFormDesignDark()
        FormTemplate.BackgroundColor = Color.FromArgb(83, 79, 75)
        FormTemplate.TextFieldColor = Color.FromArgb(83, 79, 75)
        FormTemplate.TitleBarColor = Color.FromArgb(60, 57, 54)
        FormTemplate.FontColor = Color.White
        Dim ini As New FormTemplate
        ini.Initialize()
    End Sub

    Private Function SetFormImage() As Image
        Dim result As Bitmap = Nothing
        Select Case Me.Style
            Case FormStyle.CriticalError : result = My.Resources.CriticalError
            Case FormStyle.Exclamation : result = My.Resources.Warning
            Case FormStyle.Information : result = My.Resources.Information
            Case FormStyle.Question : result = My.Resources.Question
        End Select
        Return result
    End Function

End Class
