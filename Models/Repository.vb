Imports System.Collections.Generic

Imports MongoDB.Driver
Imports MongoDB.Bson

Namespace Models
    Public Class BookRepository
        Private ReadOnly _client As MongoClient
        Private ReadOnly _database As IMongoDatabase
        Private ReadOnly _collection As IMongoCollection(Of Book)

        ' Costruttore: inizializzazione della connessione
        Public Sub New(Optional connectionString As String = "mongodb://localhost:27017", 
               Optional databaseName As String = "LibraryDB", 
               Optional collectionName As String = "Books")
            _client = New MongoClient(connectionString)
            _database = _client.GetDatabase(databaseName)
            _collection = _database.GetCollection(Of Book)(collectionName)
        End Sub


        ' Metodo per aggiungere un libro
        Public Sub AddBook(book As Book)
            _collection.InsertOne(book)
        End Sub

        ' Metodo per ottenere tutti i libri
        Public Function GetAllBooks() As List(Of Book)
            Return _collection.Find(New BsonDocument()).ToList()
        End Function

        ' Metodo per cercare un libro per titolo
        ' Public Function GetBookByTitle(title As String) As Book
        '     Return _collection.Find(Function(b) b.Title = title).FirstOrDefault()
        ' End Function

        ' Metodo per rimuovere un libro per ID
        Public Sub RemoveBookById(id As String)
            Dim filter = Builders(Of Book).Filter.Eq(Function(b) b.Id, id)
            _collection.DeleteOne(filter)
        End Sub
    End Class
End Namespace