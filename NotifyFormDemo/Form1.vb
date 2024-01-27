' ****************************************************************************************************************
' Form1.vb
' (c) 2023 by Andreas Sauer
' ****************************************************************************************************************
'

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.ComboBox1.SelectedIndex = 0
        Me.ComboBox2.SelectedIndex = 0

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With Me.NotifyForm1

            'Auswahl des Designs
            Select Case Me.ComboBox1.SelectedIndex

                Case 0
                    'Helles Desing
                    .Design = SchlumpfSoft.Controls.NotifyFormControl.FormDesign.Bright

                Case 1
                    'Farbiges Desing
                    .Design = SchlumpfSoft.Controls.NotifyFormControl.FormDesign.Colorful

                Case 2
                    'Dunkles Desing
                    .Design = SchlumpfSoft.Controls.NotifyFormControl.FormDesign.Dark

            End Select

            'Auswahl des Styles
            Select Case Me.ComboBox2.SelectedIndex

                Case 0
                    'Infosymbol
                    .Style = SchlumpfSoft.Controls.NotifyFormControl.FormStyle.Information

                Case 1
                    'Fragesymbol
                    .Style = SchlumpfSoft.Controls.NotifyFormControl.FormStyle.Question

                Case 2
                    'Fehlersymbol
                    .Style = SchlumpfSoft.Controls.NotifyFormControl.FormStyle.CriticalError

                Case 3
                    'Hinweissymbol
                    .Style = SchlumpfSoft.Controls.NotifyFormControl.FormStyle.Exclamation

            End Select

            'Anzeigezeit des Fensters
            .ShowTime = CInt(Me.NumericUpDown1.Value * 1000)

            'Titelzeilentext
            .Title = Me.TextBox1.Text

            'Mitteilungstext
            .Message = Me.TextBox2.Text

            'Fenster anzeigen
            .Show()

        End With

    End Sub

End Class
