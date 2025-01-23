Imports System.Windows.Forms
Imports System.Drawing

Namespace View
    Public Class OtherOptionsForm
        Inherits Form

        Private mainForm As Form

        ' Costruttore
        Public Sub New(parentForm As Form)
            Me.mainForm = parentForm

            ' Configurazione base della finestra
            Me.Text = "Other Options"
            Me.Size = New Size(400, 300)

            ' Aggiungi un pulsante per "Inserisci Didascalia"
            CustomButton("Enter Description", 30, 30, 300, 40, AddressOf Handle_AddDescription)

            ' Aggiungi un pulsante "Torna Indietro"
            CustomButton("Go Back", 30, 100, 300, 40, AddressOf Handle_Back)
        End Sub

        ' Metodo per creare pulsanti (puoi riutilizzare questa logica)
        Private Function CustomButton(text_button As String, button_x As Integer,
            button_y As Integer, button_width As Integer, button_height As Integer,
            clickHandler As EventHandler) As Button

            Dim button As New Button()
            button.Text = text_button
            button.Location = New Point(button_x, button_y)
            button.Size = New Size(button_width, button_height)
            AddHandler button.Click, clickHandler
            Me.Controls.Add(button)
            Return button
        End Function

        ' Gestore evento per aggiungere una didascalia
        Private Sub Handle_AddDescription(sender As Object, e As EventArgs)
            Me.Hide()

            Dim inputForm As New EnterDescriptionForm(Me)
            inputForm.ShowDialog() ' Mostra una finestra popup per l'inserimento

            Me.Show()
        End Sub

        ' Gestore evento per chiudere la finestra
        Private Sub Handle_Back(sender As Object, e As EventArgs)
            Me.Close() ' Chiude la finestra attuale
        End Sub
    End Class
End Namespace