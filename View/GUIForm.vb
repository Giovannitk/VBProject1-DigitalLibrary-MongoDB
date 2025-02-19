Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Drawing ' Import for Size

'Imports Models 'To access the Book class
'Imports MyLibrary.GUI 'To  access others windows, such as OtherOptionsForm

Namespace View
    Public Class MainForm
        Inherits Form

        ' Class variables
        Private textBoxTitle As TextBox
        Private textBoxAuthor As TextBox
        Private textBoxYear As TextBox
        Private bookList As New List(Of Models.Book)()

        Private bookController As New Controllers.BookController("mongodb://localhost:27017", 
               "LibraryDB", 
               "Books")

        ' Constructor
        Public Sub New()
            Me.Size = New Size(300, 400)

            ' Creation of TextBox and Label
            textBoxTitle = CustomLabelTextbox("Title: ", 30, 30, 200, 20, 30, 50, 200, 20)
            textBoxAuthor = CustomLabelTextbox("Author: ", 30, 80, 200, 20, 30, 100, 200, 20)
            textBoxYear = CustomLabelTextbox("Year: ", 30, 130, 200, 20, 30, 150, 200, 20)

            ' Creation of buttons with respective event handlers.
            CustomButton("Add new Book", 30, 190, 100, 40, AddressOf Handle_ButtonAdd)
            CustomButton("View Books", 160, 190, 100, 40, AddressOf Handle_ButtonView)
            CustomButton("Search Book", 30, 250, 100, 40, AddressOf Handle_ButtonSearch)
            CustomButton("Remove Book", 160, 250, 100, 40, AddressOf Handle_ButtonRemove)

            CustomButton("Other Options", 30, 310, 230, 40, AddressOf Handle_ButtonOtherOptions)
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

            Dim newBook As New models.Book With {
                .Title = textBoxTitle.Text,
                .Author = textBoxAuthor.Text,
                .Year = Convert.ToInt32(textBoxYear.Text)
            }
            bookController.AddBook(newBook)

            MessageBox.Show("Book added successfully: " & Environment.NewLine & newBook.ToString())

            textBoxTitle.Text = ""
            textBoxAuthor.Text = ""
            textBoxYear.Text = ""
        End Sub

        Private Sub Handle_ButtonView(sender As Object, e As EventArgs)
            bookList = bookController.GetBooks()
            If bookList.Count = 0 Then
                MessageBox.Show("No books available.")
            Else
                Dim booksInfo As String = String.Join(Environment.NewLine, bookList.Select(Function(b) b.ToString()))
                MessageBox.Show("Books in the library: " & Environment.NewLine & booksInfo)
            End If
        End Sub

        Private Sub Handle_ButtonSearch(sender As Object, e As EventArgs)
            Try
                bookList = bookController.GetBooks()
                If bookList.Count = 0 Then
                    MessageBox.Show("No books available.")
                Else
                    If String.IsNullOrEmpty(textBoxTitle.Text) Or String.IsNullOrEmpty(textBoxYear.Text) Then
                        MessageBox.Show("Please enter a title and an year to search a book.")
                        Return
                    End If

                    Dim book As New models.Book
                    book = bookController.GetBook(textBoxTitle.Text, Convert.ToInt32(textBoxYear.Text))
                    If book IsNot Nothing Then
                        MessageBox.Show("Book searched: " & book.ToString())
                        textBoxTitle.Text = ""
                        textBoxYear.Text = ""
                    Else
                        MessageBox.Show($"Book {textBoxTitle.Text} from {textBoxYear.Text}  not found!")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
                MessageBox.Show("Stack Trace: " & vbCrLf & ex.StackTrace)
            End Try
        End Sub

        Private Sub Handle_ButtonRemove(sender As Object, e As EventArgs)
            Try
                bookList = bookController.GetBooks()
                If bookList.Count = 0 Then
                    MessageBox.Show("No books available.")
                Else
                    If String.IsNullOrEmpty(textBoxTitle.Text) Or String.IsNullOrEmpty(textBoxYear.Text) Then
                        MessageBox.Show("Please enter a title and an year to remove a book.")
                        Return
                    End If

                    Dim book As New models.Book
                    book = bookController.GetBook(textBoxTitle.Text, Convert.ToInt32(textBoxYear.Text))
                    If book IsNot Nothing Then
                        Dim Msg, Style, Title, Response
                        Msg = "Are you sure?"    ' Define message.
                        Style = vbYesNo    ' Define buttons.
                        Title = "Msg Confirm"    ' Define title.

                        Response = MsgBox(Msg, Style, Title)
                        If Response = vbYes Then    ' User chooses Yes.
                            bookController.RemoveBook(book.Title, book.Year)
                            MessageBox.Show("Book deleted: " & book.ToString())
                        Else    ' User chooses No.
                            Return
                        End If
                        textBoxTitle.Text = ""
                        textBoxYear.Text = ""
                    Else
                        MessageBox.Show($"Book {textBoxTitle.Text} from {textBoxYear.Text} not found!")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
                MessageBox.Show("Stack Trace: " & vbCrLf & ex.StackTrace)
            End Try
        End Sub

        ' Event handler to open the secondary window
        Private Sub Handle_ButtonOtherOptions(sender As Object, e As EventArgs)
            ' Hide the main window
            Me.Hide()

            ' Open the window of other options
            Dim otherOptionsForm As New OtherOptionsForm(Me) ' Pass the current window as parameter
            otherOptionsForm.ShowDialog()

            ' Show the main window again after closing OtherOptionsForm
            Me.Show()
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
End Namespace

Module Program
    Sub Main()
        Application.Run(New View.MainForm())
    End Sub
End Module
