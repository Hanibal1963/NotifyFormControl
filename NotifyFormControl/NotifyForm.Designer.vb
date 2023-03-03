Namespace SchlumpfSoft.Controls
	Partial Class NotifyForm : Inherits System.ComponentModel.Component

#Region "Fields"

		'Wird vom Komponenten-Designer benötigt.
		Private components As System.ComponentModel.IContainer

#End Region


#Region "Public Constructors"

		<System.Diagnostics.DebuggerNonUserCode()>
		Public Sub New(ByVal container As System.ComponentModel.IContainer)
			MyClass.New()

			'Erforderlich für die Unterstützung des Windows.Forms-Klassenkompositions-Designers
			If (container IsNot Nothing) Then
				container.Add(Me)
			End If

		End Sub

		<System.Diagnostics.DebuggerNonUserCode()>
		Public Sub New()
			MyBase.New()

			'Dieser Aufruf ist für den Komponenten-Designer erforderlich.
			InitializeComponent()

		End Sub

#End Region

#Region "Protected Methods"

		'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
		<System.Diagnostics.DebuggerNonUserCode()>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			Try
				If disposing AndAlso components IsNot Nothing Then
					components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

#End Region

#Region "Private Methods"

		'Hinweis: Die folgende Prozedur ist für den Komponenten-Designer erforderlich.
		'Das Bearbeiten ist mit dem Komponenten-Designer möglich.
		'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
		<System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			components = New System.ComponentModel.Container()
		End Sub

#End Region

	End Class


End Namespace
