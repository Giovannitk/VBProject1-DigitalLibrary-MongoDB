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
    Return "Titolo: " & Me.title & " | Autore: " & Me.autore & 
            " | Anno di pubblicazione: " & Me.anno & 
            " | Descrizione: " & Me.descrizione
  End Function 
End Class

Module Program
  Sub Main()
    Dim book = New Book("Viaggio al centro della Terra","Jules Verne",1864)

    Console.WriteLine("--> " & book.ToString())

    book.descrizione = "Libro di fantascienza."

    Console.WriteLine("--> " & book.ToString())
  End Sub
End Module