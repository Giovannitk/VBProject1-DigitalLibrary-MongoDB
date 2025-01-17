Namespace MyLibrary
    Public Class Book
        Public Property Title As String
        Public Property Author As String
        Public Property Year As Integer
        Public Property Description As String

        Public Sub New(title As String, author As String, year As Integer)
            Me.Title = Title
            Me.Author = Author
            Me.Year = Year
            Me.Description = String.Empty
        End Sub


        Public Overrides Function ToString() As String
            Return "Title: " & Me.Title & " | Author: " & Me.Author & _
                " | Publication year: " & Me.Year & _
                " | Description: " & If(String.IsNullOrEmpty(Me.Description), "Not Found", Me.Description)
        End Function

    End Class
End Namespace
