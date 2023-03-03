'
'****************************************************************************************************************
'ProvideToolboxControlAttribute.vb
'(c) 2023 by Andreas Sauer
'****************************************************************************************************************
'


''' <summary>
''' Dieses Attribut fügt einen Toolbox Controls Installer-Schlüssel für die Assembly hinzu, 
''' um Toolbox-Steuerelemente aus der Assembly zu installieren.
''' </summary>
''' <remarks>
''' Zum Beispiel
'''     [$(Rootkey)\ToolboxControlsInstaller\$FullAssemblyName$]
'''         "Codebase"="$path$"
'''         "WpfControls"="1"
''' </remarks>
<system.AttributeUsage(system.AttributeTargets.Class, AllowMultiple:=False, Inherited:=True)>
<System.Runtime.InteropServices.ComVisibleAttribute(False)>
Public NotInheritable Class ProvideToolboxControlAttribute
    Inherits Microsoft.VisualStudio.Shell.RegistrationAttribute

    Private Const ToolboxControlsInstallerPath As String = "ToolboxControlsInstaller"

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0032:Automatisch generierte Eigenschaft verwenden", Justification:="<Ausstehend>")>
    Private _isWpfControls As Boolean
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0032:Automatisch generierte Eigenschaft verwenden", Justification:="<Ausstehend>")>
    Private _name As String

    ''' <summary>
    ''' Erstellt ein neues Attribut zum Bereitstellen von Toolbox-Steuerelementen, 
    ''' um die Assembly für das Installationsprogramm für Toolbox-Steuerelemente zu registrieren.
    ''' </summary>
    ''' <param name="isWpfControls">
    ''' </param>
    Public Sub New(name As String, isWpfControls As Boolean)
        If name Is Nothing Then
            Throw New System.ArgumentException(Nothing, NameOf(name))
        End If

        Me.Name = name
        Me.IsWpfControls = isWpfControls
    End Sub

    ''' <summary>
    ''' Ruft ab, ob die Toolbox-Steuerelemente für WPF bestimmt sind.
    ''' </summary>
    Private Property IsWpfControls As Boolean
        Get
            Return _isWpfControls
        End Get
        Set(value As Boolean)
            _isWpfControls = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft den Namen für die Steuerelemente ab
    ''' </summary>
    Private Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    ''' <summary>
    ''' Wird aufgerufen, um dieses Attribut im angegebenen Kontext zu registrieren.  
    ''' Der Kontext enthält den Ort, an dem die Registrierungsinformationen platziert werden sollten.
    ''' Es enthält auch andere Informationen wie den zu registrierenden Typ und Pfadinformationen.
    ''' </summary>
    ''' <param name="context">
    ''' Gegebener Kontext für die Registrierung
    ''' </param>
    Public Overrides Sub Register(context As Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)
        If context Is Nothing Then
            Throw New System.ArgumentNullException(NameOf(context))
        End If

        Using key As Key = context.CreateKey(String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}\{1}",
                                                         ToolboxControlsInstallerPath,
                                                         context.ComponentType.Assembly.FullName))
            key.SetValue(String.Empty, Name)
            key.SetValue("Codebase", context.CodeBase)
            If IsWpfControls Then
                key.SetValue("WPFControls", "1")
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Called to unregister this attribute with the given context.
    ''' </summary>
    ''' <param name="context">A registration context provided by an external registration tool. The context can be used to remove registry keys, log registration activity, and obtain information about the component being registered.</param>
    Public Overrides Sub Unregister(context As Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)
        context?.RemoveKey(String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}\{1}",
                                                         ToolboxControlsInstallerPath,
                                                         context.ComponentType.Assembly.FullName))
    End Sub
End Class