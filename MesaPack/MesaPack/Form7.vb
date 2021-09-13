Imports System.IO


Public Class Form7

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim liste = My.Computer.FileSystem.GetDirectories("C:/users")
        For Each item In liste
            CheckedListBox1.Items.Add(item.ToString.Replace("C:\Users\", ""))
        Next
    End Sub


    Public Shared Function DirSize(ByVal d As DirectoryInfo) As Long
        Dim Size As Long = 0
        Dim fis As FileInfo() = d.GetFiles()
        Dim fi As FileInfo
        For Each fi In fis
            Size += fi.Length
        Next fi

        ' Add subdirectory sizes.
        Dim dis As DirectoryInfo() = d.GetDirectories()
        Dim di As DirectoryInfo
        For Each di In dis
            Size += DirSize(di)
        Next di
        Return Size
    End Function 'DirSize

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        Dim liste = CheckedListBox1.CheckedItems
        Dim total = 0
        For Each item1 In liste
            Dim d As New DirectoryInfo("c:\\users\\" + item1)
            Dim dsize As Long = DirSize(d)
            total += dsize

       
        Next
        FlatLabel1.Text = Format(total / 1024 / 1024, "###,0")
    End Sub

    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click
        Dim liste = CheckedListBox1.Items
        For Each esya In liste
            Try
                My.Computer.FileSystem.CopyDirectory("C:\\users\\" + esya + "\\Documents", My.Computer.FileSystem.CurrentDirectory + "\\Yedekler\\" + esya + "\\Documents")
                My.Computer.FileSystem.CopyDirectory("C:\\users\\" + esya + "\\Downloads", My.Computer.FileSystem.CurrentDirectory + "\\Yedekler\\" + esya + "\\Downloads")
                My.Computer.FileSystem.CopyDirectory("C:\\users\\" + esya + "\\Pictures", My.Computer.FileSystem.CurrentDirectory + "\\Yedekler\\" + esya + "\\Pictures")
                My.Computer.FileSystem.CopyDirectory("C:\\users\\" + esya + "\\Videos", My.Computer.FileSystem.CurrentDirectory + "\\Yedekler\\" + esya + "\\Videos")

            Catch ex As Exception

            End Try
        Next
    End Sub
End Class