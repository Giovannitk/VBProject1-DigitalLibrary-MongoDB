Imports System.Windows.Forms
Imports MyLibrary
Imports System.Collections.Generic
Imports System.Drawing ' Import per Size

Public Class MainForm
    Inherits Form

    ' Variabili di classe
    Private textBoxTitle As TextBox
    Private textBoxAuthor As TextBox
    Private textBoxYear As TextBox
    Private bookList As New List(Of Book)()

    ' Costruttore
    Public Sub New()
        Me.Size = New Size(300, 350)

        ' Creazione delle TextBox e Label
        textBoxTitle = CustomLabelTextbox("Title: ", 30, 30, 200, 20, 30, 50, 200, 20)
        textBoxAuthor = CustomLabelTextbox("Author: ", 30, 80, 200, 20, 30, 100, 200, 20)
        textBoxYear = CustomLabelTextbox("Year: ", 30, 130, 200, 20, 30, 150, 200, 20)

        ' Creazione dei pulsanti con i rispettivi gestori di eventi
        CustomButton("Add new Book", 30, 190, 100, 40, AddressOf Handle_ButtonAdd)
        CustomButton("View Books", 160, 190, 100, 40, AddressOf Handle_ButtonView)
        CustomButton("Search Book", 30, 250, 100, 40, AddressOf Handle_ButtonSearch)
        CustomButton("Remove Book", 160, 250, 100, 40, AddressOf Handle_ButtonRemove)
    End Sub

    Private Sub Handle_ButtonAdd(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(textBoxTitle.Text) OrElse String.IsNullOrEmpty(textBoxAuthor.Text) OrElse String.IsNullOrEmpty(textBoxYear.Text) Then
            MessageBox.Show("Please enter a title, an author, and a year.")
            Return
        End If

        Dim year As Integer
        If Not Integer.TryParse(textBoxYear.Text, year) Then
            MessageBox.Show("Please enter a valid year.")
            Return
        End If

        Dim newBook As New Book(textBoxTitle.Text, textBoxAuthor.Text, year)
        bookList.Add(newBook)
        MessageBox.Show("Book added successfully: " & Environment.NewLine & newBook.ToString())

        textBoxTitle.Text = ""
        textBoxAuthor.Text = ""
        textBoxYear.Text = ""
    End Sub

    Private Sub Handle_ButtonView(sender As Object, e As EventArgs)
        If bookList.Count = 0 Then
            MessageBox.Show("No books available.")
        Else
            Dim booksInfo As String = String.Join(Environment.NewLine, bookList.Select(Function(b) b.ToString()))
            MessageBox.Show("Books in the library: " & Environment.NewLine & booksInfo)
        End If
    End Sub

    Private Sub Handle_ButtonSearch(sender As Object, e As EventArgs)
        If bookList.Count = 0 Then
            MessageBox.Show("No books available.")
        Else
            If String.IsNullOrEmpty(textBoxTitle.Text) Then
                MessageBox.Show("Please enter a title to search a book.")
                Return
            End If

            For Each book As Book In bookList
                If book.Title.Equals(textBoxTitle.Text, StringComparison.OrdinalIgnoreCase) Then
                    MessageBox.Show("Book searched: " & book.ToString())
                    textBoxTitle.Text = ""
                    Return
                End If
            Next
            MessageBox.Show("Book '" & textBoxTitle.Text & "' not found!")
            textBoxTitle.Text = ""
        End If
    End Sub

    Private Sub Handle_ButtonRemove(sender As Object, e As EventArgs)
        If bookList.Count = 0 Then
            MessageBox.Show("No books available.")
        Else
            If String.IsNullOrEmpty(textBoxTitle.Text) Or String.IsNullOrEmpty(textBoxYear.Text) Then
                MessageBox.Show("Please enter a title and an year to remove a book.")
                Return
            End If

            For Each book As Book In bookList
                If book.Title.Equals(textBoxTitle.Text, StringComparison.OrdinalIgnoreCase) And book.Year = cint(textBoxYear.Text) Then
                    Dim Msg, Style, Title, Response
                    Msg = "Are you sure?"    ' Define message.
                    Style = vbYesNo    ' Define buttons.
                    Title = "Msg Confirm"    ' Define title.

                    Response = MsgBox(Msg, Style, Title)
                    If Response = vbYes Then    ' User chose Yes.
                        bookList.Remove(book)
                        MessageBox.Show("Book deleted: " & book.ToString())
                    Else    ' User chose No.
                        Return
                    End If
                    textBoxTitle.Text = ""
                    textBoxYear.Text = ""
                    Return
                End If
            Next
            MessageBox.Show("Book '" & textBoxTitle.Text & " [" & textBoxYear.Text & "]" & "' not found!")
            textBoxTitle.Text = ""
            textBoxYear.Text = ""
        End If
    End Sub

    Private Function CustomLabelTextbox(
        label_text As String,
        label_x As Integer, label_y As Integer,
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

End Class

Module Program
    Sub Main()
        Application.Run(New MainForm())
    End Sub
End Module
