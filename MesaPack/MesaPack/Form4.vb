Public Class Form4

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If PictureBox1.BackColor = Color.White Then
            PictureBox1.BackColor = Color.Black

        ElseIf PictureBox1.BackColor = Color.Black Then
            PictureBox1.BackColor = Color.Red
        ElseIf PictureBox1.BackColor = Color.Red Then
            PictureBox1.BackColor = Color.Green

        ElseIf PictureBox1.BackColor = Color.Green Then
            PictureBox1.BackColor = Color.Blue

        ElseIf PictureBox1.BackColor = Color.Blue Then
            Me.Close()

        End If

    End Sub
End Class