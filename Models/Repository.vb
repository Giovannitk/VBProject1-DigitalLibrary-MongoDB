Imports System.Collections.Generic

Imports MongoDB.Driver
Imports MongoDB.Bson

Namespace Models
    Public Class BookRepository
        Private ReadOnly _client As MongoClient
        Private ReadOnly _database As IMongoDatabase
        Private ReadOnly _collection As IMongoCollection(Of Book)

        ' Constructor: initialization of the connection
        Public Sub New(Optional connectionString As String = "mongodb://localhost:27017", 
               Optional databaseName As String = "LibraryDB", 
               Optional collectionName As String = "Books")
            _client = New MongoClient(connectionString)
            _database = _client.GetDatabase(databaseName)
            _collection = _database.GetCollection(Of Book)(collectionName)
        End Sub


        ' Method to add a book
        Public Sub AddBook(book As Book)
            _collection.InsertOne(book)
        End Sub

        ' Method to get all the books
        Public Function GetAllBooks() As List(Of Book)
            Return _collection.Find(New BsonDocument()).ToList()
        End Function

        ' Method to remove a book by ID
        Public Sub RemoveBookById(id As String)
            Dim filter = Builders(Of Book).Filter.Eq(Function(b) b.Id, id)
            _collection.DeleteOne(filter)
        End Sub
    End Class
End Namespace