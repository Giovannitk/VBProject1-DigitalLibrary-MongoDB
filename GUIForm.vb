Imports System.Windows.Forms

Public Class MainForm
    Inherits Form

    ' Dichiarazione delle variabili di classe
    Private textBoxTitle As TextBox
    Private textBoxAuthor As TextBox
    Private textBoxYear As TextBox

    Public Sub New()
        ' Chiamata al metodo per creare una nuova Label e TextBox
        textBoxTitle = CustomLabelTextbox("Title: ", 30, 30, 200, 20, 30, 50, 200, 20)
        textBoxAuthor = CustomLabelTextbox("Author: ", 30, 80, 200, 20, 30, 100, 200, 20)
        textBoxYear = CustomLabelTextbox("Year: ", 30, 130, 200, 20, 30, 150, 200, 20)

        ' Creazione di un pulsante Add
        Dim buttonAdd As New Button()
        buttonAdd.Text = "Add new book"
        buttonAdd.Location = New Drawing.Point(30, 190)
        buttonAdd.Size = New Drawing.Size(100, 40)

        ' Creazione di un pulsante View Books
        Dim buttonView As New Button()
        buttonView.Text = "View Books"
        buttonView.Location = New Drawing.Point(160, 190)
        buttonView.Size = New Drawing.Size(100, 40)

        ' Associa un gestore all'evento Click del pulsante
        AddHandler buttonAdd.Click, AddressOf Handle_ButtonAdd
        AddHandler buttonView.Click, AddressOf Handle_ButtonView

        ' Aggiungi i controlli al form
        Me.Controls.Add(buttonAdd)
        Me.Controls.Add(buttonView)
    End Sub

    ' Metodo gestore dell'evento Click del pulsante Add
    Private Sub Handle_ButtonAdd(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(textBoxTitle.Text) Or String.IsNullOrEmpty(textBoxAuthor.Text) Or String.IsNullOrEmpty(textBoxYear.Text) Then
            MessageBox.Show("Please enter a title, an author and one year.")
        Else
            MessageBox.Show("The book title is: " & textBoxTitle.Text)
        End If
    End Sub

    ' Metodo gestore dell'evento Click del pulsante View Books
    Private Sub Handle_ButtonView(sender As Object, e As EventArgs)
        MessageBox.Show("View Books button clicked!")
    End Sub

    ' Metodo per creare label e TextBox personalizzate
    Private Function CustomLabelTextbox(
        label_text As String,
        label_x As Integer, label_y As Integer,
        label_width As Integer, label_height As Integer,
        textbox_x As Integer, textbox_y As Integer,
        textbox_width As Integer, textbox_height As Integer)

        ' Creazione della Label
        Dim customLabel As New Label()
        customLabel.Text = label_text
        customLabel.Location = New Drawing.Point(label_x, label_y)
        customLabel.Size = New Drawing.Size(label_width, label_height)
        Me.Controls.Add(customLabel)

        ' Creazione della TextBox
        Dim customTextBox As New TextBox()
        customTextBox.Location = New Drawing.Point(textbox_x, textbox_y)
        customTextBox.Size = New Drawing.Size(textbox_width, textbox_height)
        Me.Controls.Add(customTextBox)

        Return customTextBox
    End Function
End Class

Module Program
    Sub Main()
        Application.Run(New MainForm())
    End Sub
End Module
