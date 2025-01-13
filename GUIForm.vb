Imports System.Windows.Forms

Public Class MainForm
    Inherits Form

    Public Sub New()
        ' Creazione di un pulsante
        Dim button As New Button()
        button.Text = "Cliccami!"
        button.Location = New Drawing.Point(50, 50)

        ' Associa un gestore all'evento Click del pulsante
        AddHandler button.Click, AddressOf Button_Click

        ' Aggiungi il pulsante al form
        Me.Controls.Add(button)
    End Sub

    ' Metodo gestore dell'evento Click
    Private Sub Button_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Hai cliccato il pulsante!")
    End Sub
End Class

Module Program
    Sub Main()
        Application.Run(New MainForm())
    End Sub
End Module