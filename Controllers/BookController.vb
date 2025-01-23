Imports System.Collections.Generic

Namespace Controllers
    Public Class BookController
        Private repository As Models.BookRepository

        Public Sub New()
            repository = New Models.BookRepository()
        End Sub

        Public Sub AddBook(book As Models.Book)
            repository.AddBook(book)
        End Sub

        Public Function GetBooks() As List(Of Models.Book)
            Return repository.GetAllBooks()
        End Function

        Public Function GetBook(title As String) As Models.Book
            Return repository.GetAllBooks().FirstOrDefault(Function(b) b.Title = title)
        End Function
    End Class
End Namespace
