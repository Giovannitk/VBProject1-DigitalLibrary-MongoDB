Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace Controllers
    Public Class BookController
        Private repository As Models.BookRepository

        Public Sub New(connectionString As String, databaseName As String, collectionName As String)
            repository = New Models.BookRepository(connectionString, databaseName, collectionName)
        End Sub

        Public Sub AddBook(book As Models.Book)
            repository.AddBook(book)
        End Sub

        Public Function GetBooks() As List(Of Models.Book)
            Return repository.GetAllBooks()
        End Function

        Public Function GetBook(title As String, year As Integer) As Models.Book
            Return repository.GetAllBooks().FirstOrDefault(Function(b) b.Title = title And b.Year = year)
        End Function

        Public Sub RemoveBook(title As String, year As Integer)
            repository.RemoveBookById(Me.GetBook(title, year).Id)
        End Sub 
    End Class
End Namespace
