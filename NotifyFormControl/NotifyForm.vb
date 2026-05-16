' --------------------------------------------------------------------------------------------------------
' Datei: NotifyForm.vb
' Author: Andreas Sauer
' Datum: 06.05.2026
' --------------------------------------------------------------------------------------------------------

Namespace NotifyFormControl

    ''' <summary>
    ''' Control zum Anzeigen von Benachrichtigungsfenstern.
    ''' </summary>
    <ProvideToolboxControl("SchlumpfSoft Controls", False)>
    <System.ComponentModel.Description("Control zum Anzeigen von Benachrichtigungsfenstern.")>
    <System.ComponentModel.ToolboxItem(True)>
    <System.Drawing.ToolboxBitmap(GetType(NotifyForm), "NotifyFormControl.NotifyForm.bmp")>
    Public Class NotifyForm

#Region "Definition der Variablen"

        Private _Title As System.String
        Private _Style As NotifyFormStyle
        Private _ShowTime As System.Int32
        Private _Message As System.String
        Private _Design As NotifyFormDesign

#End Region

#Region "Definition der Eigenschaften"

        ''' <summary>
        ''' Legt das Aussehen des Benachrichtigungsfensters fest.
        ''' </summary>
        <System.ComponentModel.Browsable(True)>
        <System.ComponentModel.Category("Appearance")>
        <System.ComponentModel.Description("Legt das Aussehen des Benachrichtigungsfensters fest.")>
        Public Property Design As NotifyFormDesign
            Get
                Return _Design
            End Get
            Set
                _Design = Value
            End Set
        End Property

        ''' <summary>
        ''' Legt den Benachrichtigungstext fest der angezeigt werden soll.
        ''' </summary>
        <System.ComponentModel.Browsable(True)>
        <System.ComponentModel.Category("Appearance")>
        <System.ComponentModel.Description("Legt den Benachrichtigungstext fest der angezeigt werden soll.")>
        Public Property Message As String
            Get
                Return _Message
            End Get
            Set
                _Message = Value
            End Set
        End Property

        ''' <summary>
        ''' Legt die Anzeigedauer des Benachrichtigungsfensters in ms fest.
        ''' </summary>
        ''' <remarks>
        ''' Der Wert 0 bewirkt das kein automatisches schließen des Fensters erfolgt.
        ''' </remarks>
        <System.ComponentModel.Browsable(True)>
        <System.ComponentModel.Category("Behavior")>
        <System.ComponentModel.Description("Legt die Anzeigedauer des Benachrichtigungsfensters in ms fest.")>
        Public Property ShowTime As System.Int32
            Get
                Return _ShowTime
            End Get
            Set
                _ShowTime = Value
            End Set
        End Property

        ''' <summary>
        ''' Legt das anzuzeigende Symbol im Benachrichtigungsfensters fest.
        ''' </summary>
        <System.ComponentModel.Browsable(True)>
        <System.ComponentModel.Category("Appearance")>
        <System.ComponentModel.Description("Legt das anzuzeigende Symbol im Benachrichtigungsfensters fest.")>
        Public Property Style As NotifyFormStyle
            Get
                Return _Style
            End Get
            Set
                _Style = Value
            End Set
        End Property

        ''' <summary>
        ''' Legt den Text der Titelzeile des Benachrichtigungsfensters fest.
        ''' </summary>
        <System.ComponentModel.Browsable(True)>
        <System.ComponentModel.Category("Appearance")>
        <System.ComponentModel.Description("Legt den Text der Titelzeile des Benachrichtigungsfensters fest.")>
        Public Property Title As String
            Get
                Return _Title
            End Get
            Set
                _Title = Value
            End Set
        End Property

#End Region

#Region "öffentliche Methoden"

        ''' <summary>
        ''' Initialisiert eine neue Instanz der <see cref="NotifyForm"/> Klasse mit
        ''' Standardwerten.
        ''' </summary>
        Public Sub New()
            Me.InitializeComponent()
            Me.Title = $"Titel"
            Me.Message = $"Mitteilung"
            Me.Design = NotifyFormDesign.Bright
            Me.Style = NotifyFormStyle.Information
            Me.ShowTime = 5000
        End Sub

        ''' <summary>
        ''' Zeigt das Meldungsfenster an.
        ''' </summary>
        <System.ComponentModel.Description("Zeigt das Meldungsfenster an.")>
        Public Sub Show()
            ' Überträgt die aktuellen Einstellungen in die statischen Anzeigeparameter der Formularvorlage.
            FormTemplate.Image = Me.SetFormImage()
            FormTemplate.Title = Me.Title
            FormTemplate.Message = Me.Message
            FormTemplate.ShowTime = Me.ShowTime

            ' Wendet das gewählte Farbschema an und zeigt anschließend das Formular an.
            Me.SetFormDesign()
            Me.ShowForm()
        End Sub

#End Region

#Region "Interne Methoden"

        ''' <summary>
        ''' Erstellt eine Instanz des internen Popup-Formulars und zeigt sie an.
        ''' </summary>
        Private Sub ShowForm()
            Dim frm As New FormTemplate
            frm.Initialize()
        End Sub

        ''' <summary>
        ''' Wählt anhand der konfigurierten <see cref="Design"/>-Eigenschaft das Farbschema aus.
        ''' </summary>
        Private Sub SetFormDesign()
            Select Case Me.Design
                Case NotifyFormDesign.Bright : SetFormDesignBright()
                Case NotifyFormDesign.Colorful : SetFormDesignColorful()
                Case NotifyFormDesign.Dark : SetFormDesignDark()
            End Select
        End Sub

        ''' <summary>
        ''' Setzt das helle Design für das Benachrichtigungsformular.
        ''' </summary>
        Private Shared Sub SetFormDesignBright()
            FormTemplate.BackgroundColor = System.Drawing.Color.White
            FormTemplate.TextFieldColor = System.Drawing.Color.White
            FormTemplate.TitleBarColor = System.Drawing.Color.Gray
            FormTemplate.FontColor = System.Drawing.Color.Black
        End Sub

        ''' <summary>
        ''' Setzt das farbige Design für das Benachrichtigungsformular.
        ''' </summary>
        Private Shared Sub SetFormDesignColorful()
            FormTemplate.BackgroundColor = System.Drawing.Color.LightBlue
            FormTemplate.TextFieldColor = System.Drawing.Color.LightBlue
            FormTemplate.TitleBarColor = System.Drawing.Color.LightSeaGreen
            FormTemplate.FontColor = System.Drawing.Color.White
        End Sub

        ''' <summary>
        ''' Setzt das dunkle Design für das Benachrichtigungsformular.
        ''' </summary>
        Private Shared Sub SetFormDesignDark()
            FormTemplate.BackgroundColor = System.Drawing.Color.FromArgb(83, 79, 75)
            FormTemplate.TextFieldColor = System.Drawing.Color.FromArgb(83, 79, 75)
            FormTemplate.TitleBarColor = System.Drawing.Color.FromArgb(60, 57, 54)
            FormTemplate.FontColor = System.Drawing.Color.White
        End Sub

        ''' <summary>
        ''' Ermittelt das anzuzeigende Symbol entsprechend dem eingestellten Stil.
        ''' </summary>
        ''' <returns>
        ''' Ein Bild aus den Ressourcen, das dem aktuell gewählten <see cref="Style"/> entspricht.
        ''' </returns>
        Private Function SetFormImage() As System.Drawing.Image
            Dim result As System.Drawing.Bitmap = Nothing
            Select Case Me.Style
            ' Ordnet den ausgewählten Stil dem passenden Ressourcensymbol zu.
                Case NotifyFormStyle.CriticalError : result = My.Resources.CriticalError
                Case NotifyFormStyle.Exclamation : result = My.Resources.Warning
                Case NotifyFormStyle.Information : result = My.Resources.Information
                Case NotifyFormStyle.Question : result = My.Resources.Question
            End Select
            Return result
        End Function

#End Region

    End Class

End Namespace
