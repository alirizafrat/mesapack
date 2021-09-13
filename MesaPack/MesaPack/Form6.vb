Public Class Form6

    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click
        Try
            If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.CurrentDirectory + "\kasa.{ED7BA470-8E54-465E-825C-99712043E01C}") Or My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.CurrentDirectory + "\kasa") Then
                My.Computer.FileSystem.RenameDirectory(My.Computer.FileSystem.CurrentDirectory + "\kasa.{ED7BA470-8E54-465E-825C-99712043E01C}", "kasa")
                Shell("attrib -s -h kasa")
            Else
                MkDir(My.Computer.FileSystem.CurrentDirectory + "\kasa.{ED7BA470-8E54-465E-825C-99712043E01C}")
                My.Computer.FileSystem.RenameDirectory(My.Computer.FileSystem.CurrentDirectory + "\kasa.{ED7BA470-8E54-465E-825C-99712043E01C}", "kasa")
                Shell("attrib -s -h kasa")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton2.Click
        Try
            If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.CurrentDirectory + "\kasa.{ED7BA470-8E54-465E-825C-99712043E01C}") Or My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.CurrentDirectory + "\kasa") Then
                My.Computer.FileSystem.RenameDirectory(My.Computer.FileSystem.CurrentDirectory + "\kasa", "kasa.{ED7BA470-8E54-465E-825C-99712043E01C}")
                Shell("attrib +s +h kasa.{ED7BA470-8E54-465E-825C-99712043E01C}")

            Else
                MkDir(My.Computer.FileSystem.CurrentDirectory + "\kasa")
                My.Computer.FileSystem.RenameDirectory(My.Computer.FileSystem.CurrentDirectory + "\kasa", "kasa.{ED7BA470-8E54-465E-825C-99712043E01C}")
                Shell("attrib +s +h kasa.{ED7BA470-8E54-465E-825C-99712043E01C}")

            End If
        Catch ex As Exception

        End Try

    End Sub
End Class