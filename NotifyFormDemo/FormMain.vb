Imports SchlumpfSoft.Controls

Public Class FormMain

	Private _Design As SchlumpfSoft.Controls.NotifyFormDesign
	Private _Style As SchlumpfSoft.Controls.NotifyFormStyle


	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click


		With NotifyForm1

			.Design = _Design
			.Style = _Style
			.Title = TextBoxTitle.Text
			.Message = RichTextBoxMessage.Text
			.ShowTime = CInt(NumericUpDownTime.Value * 1000)
			.Show()

		End With

	End Sub


	Private Sub ComboBoxDesign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDesign.SelectedIndexChanged

		Select Case CType(sender, ComboBox).SelectedIndex
			Case 0 : _Design = SchlumpfSoft.Controls.NotifyFormDesign.Bright
			Case 1 : _Design = SchlumpfSoft.Controls.NotifyFormDesign.Colorful
			Case 2 : _Design = SchlumpfSoft.Controls.NotifyFormDesign.Dark
		End Select

	End Sub


	Private Sub ComboBoxstyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxstyle.SelectedIndexChanged

		Select Case CType(sender, ComboBox).SelectedIndex
			Case 0 : _Style = SchlumpfSoft.Controls.NotifyFormStyle.Information
			Case 1 : _Style = SchlumpfSoft.Controls.NotifyFormStyle.Question
			Case 2 : _Style = SchlumpfSoft.Controls.NotifyFormStyle.CriticalError
			Case 4 : _Style = SchlumpfSoft.Controls.NotifyFormStyle.Exclamation
		End Select

	End Sub


	Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load

		ComboBoxDesign.SelectedIndex = 0
		ComboBoxstyle.SelectedIndex = 0
		NumericUpDownTime.Value = 5
		TextBoxTitle.Text = "Titeltext"
		RichTextBoxMessage.Text = "Meldungstext"

	End Sub


End Class
