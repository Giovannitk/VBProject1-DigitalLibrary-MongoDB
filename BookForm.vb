Namespace MyLibrary
    Public Class Book
        Private title As String
        Private autore As String
        Private anno As Integer
        Public Property descrizione As String

        Public Sub New(title As String, autore As String, anno As Integer)
            Me.title = title
            Me.autore = autore
            Me.anno = anno
            Me.descrizione = String.Empty
        End Sub

        Public Overrides Function ToString() As String
            Return "Title: " & Me.title & " | Author: " & Me.autore &
                " | Publication year: " & Me.anno &
                " | Description: " & If(String.IsNullOrEmpty(Me.descrizione), "Not Found", Me.descrizione)
        End Function

    End Class
End Namespace
