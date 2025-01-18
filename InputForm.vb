Imports System.Windows.Forms
Imports System.Drawing

Namespace MyLibrary.GUI
    Public Class InputForm
        Inherits Form

        Private textBoxTitle As TextBox
        Private textBoxYear As TextBox
        Private textBoxDescription As TextBox

        Private mainForm As Form

        ' Costruttore
        Public Sub New(parentForm As Form)
            Me.mainForm = parentForm

            ' Configurazione base della finestra
            Me.Text = "Enter description"
            Me.Size = New Size(400, 300)

            ' Creazione delle TextBox e Label
            textBoxTitle = CustomLabelTextbox("Book Title:", 30, 30, 300, 20, 30, 50, 300, 20)
            textBoxYear = CustomLabelTextbox("Year:", 30, 80, 300, 20, 30, 100, 300, 20)
            textBoxDescription = CustomLabelTextbox("Description:", 30, 130, 300, 20, 30, 150, 300, 20)

            ' Aggiungi pulsante "Conferma"
            CustomButton("Confirm", 30, 200, 100, 40, AddressOf Handle_Confirm)

            ' Aggiungi pulsante "Annulla"
            CustomButton("Cancel", 150, 200, 100, 40, AddressOf Handle_Cancel)
        End Sub

        ' Metodo per creare Label e TextBox
        Private Function CustomLabelTextbox(label_text As String, label_x As Integer, label_y As Integer,
            label_width As Integer, label_height As Integer,
            textbox_x As Integer, textbox_y As Integer,
            textbox_width As Integer, textbox_height As Integer) As TextBox

            Dim customLabel As New Label()
            customLabel.Text = label_text
            customLabel.Location = New Point(label_x, label_y)
            customLabel.Size = New Size(label_width, label_height)
            Me.Controls.Add(customLabel)

            Dim customTextBox As New TextBox()
            customTextBox.Location = New Point(textbox_x, textbox_y)
            customTextBox.Size = New Size(textbox_width, textbox_height)
            Me.Controls.Add(customTextBox)

            Return customTextBox
        End Function

        ' Metodo per creare pulsanti
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

        ' Gestore evento per confermare l'inserimento
        Private Sub Handle_Confirm(sender As Object, e As EventArgs)
            If String.IsNullOrEmpty(textBoxTitle.Text) OrElse String.IsNullOrEmpty(textBoxYear.Text) OrElse String.IsNullOrEmpty(textBoxDescription.Text) Then
                MessageBox.Show("Please fill in all fields.")
                Return
            End If

            Dim year As Integer
            If Not Integer.TryParse(textBoxYear.Text, year) Then
                MessageBox.Show("Year not valid.")
                Return
            End If

            ' Qui puoi integrare la logica per aggiornare la descrizione del libro nel database o nella lista
            MessageBox.Show("Added description for the book: " & textBoxTitle.Text)

            Me.Close()
        End Sub

        ' Gestore evento per annullare l'inserimento
        Private Sub Handle_Cancel(sender As Object, e As EventArgs)
            Me.Close()
        End Sub
    End Class
End Namespace