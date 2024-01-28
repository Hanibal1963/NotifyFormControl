' ****************************************************************************************************************
' EnumDefinitions.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

''' <summary>Auflistung der Styles</summary>
Public Enum FormStyle As Integer

    ''' <summary>Infosymbol</summary>
    Information = 0

    ''' <summary>Fragesymbol</summary>
    Question = 1

    ''' <summary>Fehlersymbol</summary>
    CriticalError = 2

    ''' <summary>Warnungssymbol</summary>
    Exclamation = 3

End Enum

''' <summary>Auflistung der Deigns</summary>
Public Enum FormDesign As Integer

    ''' <summary>Helles Design</summary>
    Bright = 0

    ''' <summary>Farbiges Design</summary>
    Colorful = 1

    ''' <summary>Dunkles Design</summary>
    Dark = 2

End Enum
