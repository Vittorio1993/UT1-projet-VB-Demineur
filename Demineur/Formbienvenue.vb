Public Class Formbienvenue
    Private Sub btnnormal_Click(sender As Object, e As EventArgs) Handles btnnormal.Click
        FormDemineur.Show()
        Me.Hide()
    End Sub

    Private Sub btndifficile_Click(sender As Object, e As EventArgs) Handles btndifficile.Click
        FormDemineurfacile.Show()
        Me.Hide()
    End Sub

    Private Sub Formbienvenue_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class