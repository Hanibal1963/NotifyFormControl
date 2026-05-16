' --------------------------------------------------------------------------------------------------------
' Datei: FormTemplate.vb
' Author: Andreas Sauer
' Datum: 06.05.2026
' --------------------------------------------------------------------------------------------------------

Namespace NotifyFormControl

    ''' <summary>
    ''' Formularvorlage für die Anzeige eines Benachrichtigungsfensters (Popup) mit Titel, Symbol und Nachricht.
    ''' </summary>
    Friend Class FormTemplate

        Inherits System.Windows.Forms.Form

#Region "Definition der Variablen"

        Public Shared BackgroundColor As System.Drawing.Color  ' Hintergrundfarbe des Formulars.
        Public Shared FontColor As System.Drawing.Color ' Schriftfarbe für Titel und Nachricht.
        Public Shared Image As System.Drawing.Image ' Anzuzeigendes Symbolbild.
        Public Shared Message As String ' Textnachricht die im Fenster dargestellt wird.
        Public Shared ShowTime As System.Int32 ' Zeit in Millisekunden bis zum automatischen Schließen (0 = kein Autoclose).
        Public Shared TextFieldColor As System.Drawing.Color ' Hintergrundfarbe des Nachrichtentextfeldes.
        Public Shared Title As String ' Titeltext für die Titelleiste.
        Public Shared TitleBarColor As System.Drawing.Color ' Hintergrundfarbe der Titelleiste.
        Private ReadOnly LabelClose As New System.Windows.Forms.Label  ' Label-Steuerelement zum Schließen des Fensters.
        Private ReadOnly LabelTitle As New System.Windows.Forms.Label ' Label-Steuerelement zur Anzeige des Titels.
        Private ReadOnly PanelSpacer As New System.Windows.Forms.Panel ' Trenn-Panel zwischen Symbol und Text.
        Private ReadOnly PanelTitle As New System.Windows.Forms.Panel ' Panel für die Titelleiste, enthält Titel und Schließen-Label.
        Private ReadOnly PictureBoxImage As New System.Windows.Forms.PictureBox ' Bildanzeige für das Symbol.
        Private ReadOnly RichTextBoxMessage As New System.Windows.Forms.RichTextBox ' RichTextBox zur Anzeige der Nachricht.
        Private CloseThread As System.Threading.Thread ' Hintergrundthread für das automatische Schließen.

#End Region

#Region "Definition der öffentlichen Methoden"

        ''' <summary>
        ''' Initialisiert die Form-Eigenschaften und zeigt das Popup-Fenster an.
        ''' </summary>
        Public Sub Initialize()
            With Me
                .MaximizeBox = False
                .MinimizeBox = False
                .BackColor = BackgroundColor
                .ForeColor = FontColor
                .Size = New System.Drawing.Size(504, 138)
                .FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                .StartPosition = System.Windows.Forms.FormStartPosition.Manual
            End With
            Me.Show()
        End Sub

        ''' <summary>
        ''' Gibt verwendete Ressourcen frei und ruft die Basisimplementierung auf.
        ''' </summary>
        ''' <param name="disposing">
        ''' <see langword="True"/>, wenn verwaltete Ressourcen freigegeben werden sollen; andernfalls <see langword="False"/>.
        ''' </param>
        Protected Overrides Sub Dispose(disposing As Boolean)
            'Bereinigung durchführen
            With Me
                .LabelClose.Dispose()
                .LabelTitle.Dispose()
                .PanelSpacer.Dispose()
                .PanelTitle.Dispose()
                .PictureBoxImage.Dispose()
                .RichTextBoxMessage.Dispose()
            End With
            MyBase.Dispose(disposing)
        End Sub

        ''' <summary>
        ''' Finalizer der Klasse; delegiert an den Basis-Finalizer.
        ''' </summary>
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

#End Region

#Region "Definition der internen Methoden"

        ''' <summary>
        ''' Schließt das Formular threadsicher und verwendet bei Bedarf <see cref="System.Windows.Forms.Control.Invoke(System.Delegate)"/>.
        ''' </summary>
        Private Sub CloseForm()
            If Me.InvokeRequired Then
                Dim unused = Me.Invoke(New System.Windows.Forms.MethodInvoker(AddressOf Me.CloseForm))
            Else
                Me.Close()
            End If
        End Sub

        ''' <summary>
        ''' Fügt alle benötigten Steuerelemente zur Formularoberfläche hinzu.
        ''' </summary>
        Private Sub AddControls()
            With Me.Controls
                .Add(Me.LabelTitle)
                .Add(Me.LabelClose)
                .Add(Me.PanelSpacer)
                .Add(Me.PanelTitle)
                .Add(Me.RichTextBoxMessage)
                .Add(Me.PictureBoxImage)
            End With
        End Sub

        ''' <summary>
        ''' Führt den automatischen Schließvorgang nach Ablauf der eingestellten Zeit aus.
        ''' </summary>
        Private Sub AutoClose()
            'Fenster nur automatisch schließen wenn Zeit > 0 ist.
            If ShowTime > 0 Then
                System.Threading.Thread.Sleep(ShowTime)
                Me.CloseForm()
            End If
        End Sub

        ''' <summary>
        ''' Führt beim Schließen eine kurze Ausblendanimation aus.
        ''' </summary>
        ''' <param name="sender">Das Objekt, das das Ereignis ausgelöst hat.</param>
        ''' <param name="e">Ereignisdaten für den Schließvorgang.</param>
        Private Sub Form_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
            ' Kurze Verzögerung vor dem Start der Ausblendanimation.
            System.Threading.Thread.Sleep(150)
            For iCount As System.Int32 = 90 To 10 Step -15
                Me.Opacity = iCount / 110
                Me.Refresh()
                System.Threading.Thread.Sleep(60)
            Next
        End Sub

        ''' <summary>
        ''' Initialisiert beim Laden alle Steuerelemente, positioniert das Fenster und startet den Auto-Close-Thread.
        ''' </summary>
        ''' <param name="sender">Das Objekt, das das Ereignis ausgelöst hat.</param>
        ''' <param name="e">Ereignisdaten zum Ladevorgang des Formulars.</param>
        Private Sub Form_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            With Me
                .Opacity = 0.1
                .SetPropertys_Lbl_Close()
                .SetPropertys_Panel_Spacer()
                .SetPropertys_Pb_Image()
                .SetPropertys_Panel_Title()
                .SetPropertys_Lbl_Title()
                .SetPropertys_Txt_Msg()
                .AddControls()
                .ActiveControl = .Controls.Item(1)
            End With
            'Ändern Sie die Position in die untere rechte Ecke
            Dim x As System.Int32 = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width
            Dim y As System.Int32 = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 50
            ' Schiebt das Fenster animiert von rechts in den sichtbaren Bereich.
            Do Until x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - Me.Width
                x -= 1
                Me.Location = New System.Drawing.Point(x, y)
            Loop
            AddHandler Me.LabelClose.Click, AddressOf Me.Lbl_Close_Click
            Me.FormFadeIn()
            'Starte Thread für Autoclose-Popup.
            Me.CloseThread = New System.Threading.Thread(AddressOf Me.AutoClose) With {.IsBackground = True}
            Me.CloseThread.Start()
        End Sub

        ''' <summary>
        ''' Führt die Einblendanimation des Formulars aus.
        ''' </summary>
        Private Sub FormFadeIn()
            For iCount As System.Int32 = 10 To 100 Step +15
                Me.Opacity = iCount / 100
                Me.Refresh()
                System.Threading.Thread.Sleep(60)
            Next
        End Sub

        ''' <summary>
        ''' Behandelt den Klick auf das Schließen-Label und beendet das Popup sofort.
        ''' </summary>
        ''' <param name="sender">Das Objekt, das das Ereignis ausgelöst hat.</param>
        ''' <param name="e">Ereignisdaten des Klickereignisses.</param>
        Private Sub Lbl_Close_Click(sender As Object, e As System.EventArgs)
            Me.Close()
        End Sub

        ''' <summary>
        ''' Setzt die Eigenschaften des Schließen-Labels.
        ''' </summary>
        Private Sub SetPropertys_Lbl_Close()
            With Me.LabelClose
                .AutoSize = True
                .BackColor = TitleBarColor
                .ForeColor = FontColor
                .Location = New System.Drawing.Point(478, 9)
                .Name = "LblClose"
                .Size = New System.Drawing.Size(14, 13)
                .TabIndex = 1
                .Text = "X"
            End With
        End Sub

        ''' <summary>
        ''' Setzt die Eigenschaften des Titel-Labels.
        ''' </summary>
        Private Sub SetPropertys_Lbl_Title()
            With Me.LabelTitle
                .AutoSize = True
                .BackColor = TitleBarColor
                .ForeColor = FontColor
                .Location = New System.Drawing.Point(11, 9)
                .Name = "LblTitle"
                .Size = New System.Drawing.Size(27, 13)
                .TabIndex = 0
                .Text = Title
            End With
        End Sub

        ''' <summary>
        ''' Setzt die Eigenschaften des Trenn-Panels zwischen Symbol- und Textbereich.
        ''' </summary>
        Private Sub SetPropertys_Panel_Spacer()
            With Me.PanelSpacer
                .BackColor = TitleBarColor
                .Location = New System.Drawing.Point(119, 36)
                .Name = "PanelSpacer"
                .Size = New System.Drawing.Size(1, 92)
                .TabIndex = 2
            End With
        End Sub

        ''' <summary>
        ''' Setzt die Eigenschaften des Titel-Panels.
        ''' </summary>
        Private Sub SetPropertys_Panel_Title()
            With Me.PanelTitle
                .BackColor = TitleBarColor
                .Controls.Add(Me.LabelClose)
                .Controls.Add(Me.LabelTitle)
                .Location = New System.Drawing.Point(0, -1)
                .Name = "PanelTitle"
                .Size = New System.Drawing.Size(505, 29)
                .TabIndex = 0
            End With
        End Sub

        ''' <summary>
        ''' Setzt die Eigenschaften der PictureBox für das Benachrichtigungssymbol.
        ''' </summary>
        Private Sub SetPropertys_Pb_Image()
            With Me.PictureBoxImage
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

        ''' <summary>
        ''' Setzt die Eigenschaften der RichTextBox für den Nachrichtentext.
        ''' </summary>
        Private Sub SetPropertys_Txt_Msg()
            With Me.RichTextBoxMessage
                .BackColor = TextFieldColor
                .ForeColor = FontColor
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

        ''' <summary>
        ''' Initialisiert die Designer-Komponenten des Formulars.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'FormTemplate
            '
            Me.ClientSize = New System.Drawing.Size(284, 261)
            Me.Name = "FormTemplate"
            Me.ResumeLayout(False)
        End Sub

#End Region

    End Class

End Namespace
