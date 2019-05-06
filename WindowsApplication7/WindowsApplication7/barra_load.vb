Public Class barra_load
    Public contador As Integer = 0
    Private Sub barra_load_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(2)
        Dim value As Integer = CInt(Int((3 * Rnd()) + 1))
        contador = contador + value
        If contador <= 100 Then
            Label2.Text = contador & "%"
        End If

        If ProgressBar1.Value = 100 Then
            matricula.Show()
            Me.Close()
            inicio1.Hide()


        End If

    End Sub
End Class