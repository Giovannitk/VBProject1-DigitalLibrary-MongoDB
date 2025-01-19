Imports System.Collections.Generic

Namespace Controllers
    Public Class BookController
        Private repository As New Models.BookRepository()

        Public Sub AddBook(title As String, author As String, year As Integer)
            Dim newBook As New Models.Book(title, author, year)
            repository.AddBook(newBook)
        End Sub

        Public Function GetBooks() As List(Of Models.Book)
            Return repository.GetAllBooks()
        End Function

        ' Altri metodi per aggiornare, cercare o rimuovere libri
    End Class
End Namespace
