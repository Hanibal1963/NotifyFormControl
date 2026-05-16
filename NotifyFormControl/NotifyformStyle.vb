' --------------------------------------------------------------------------------------------------------
' Datei: NotifyformStyle.vb
' Author: Andreas Sauer
' Datum: 06.05.2026
' --------------------------------------------------------------------------------------------------------

Namespace NotifyFormControl

    ''' <summary>
    ''' Definiert die verfügbaren Symboltypen des Benachrichtigungsfensters.
    ''' </summary>
    Public Enum NotifyFormStyle As System.Int32

        ''' <summary>
        ''' Informationssymbol.
        ''' </summary>
        Information = 0

        ''' <summary>
        ''' Fragesymbol.
        ''' </summary>
        Question = 1

        ''' <summary>
        ''' Symbol für kritische Fehler.
        ''' </summary>
        CriticalError = 2

        ''' <summary>
        ''' Warnsymbol.
        ''' </summary>
        Exclamation = 3

    End Enum

End Namespace
