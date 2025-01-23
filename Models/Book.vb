Imports MongoDB.Bson
Imports MongoDB.Bson.Serialization.Attributes

Namespace Models
    Public Class Book
        ' Indica che questa proprietà è l'identificatore del documento
        <BsonId>
        <BsonRepresentation(BsonType.ObjectId)>
        Public Property Id As String

        Public Property Title As String
        Public Property Author As String
        Public Property Year As Integer

        Public Overrides Function ToString() As String
            Return "Title: " & Title & ", Author: " & Author & ", Year: " & Year
        End Function
    End Class
End Namespace
