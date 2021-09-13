Imports System.Management
Imports Microsoft.Win32
Imports Microsoft.Win32.Registry
Imports System.IO


Public Class Form2
    Function getupdate()
        Dim kayit As RegistryKey
        Dim anahtar As String = "SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU"
        kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)

        'Oluşturma ve açma
        kayit = Registry.LocalMachine.CreateSubKey(anahtar)
        kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
        If kayit.GetValue("NoAutoUpdate") = "00000001" Then
            FlatTextBox1.Text = "Windows Update Devre Dışı"
        Else
            FlatTextBox1.Text = "Windows Update Etkin"
        End If
    End Function
    Function getdefender()
        Dim kayit As RegistryKey
        Dim anahtar As String = "SOFTWARE\\Policies\\Microsoft\\Windows Defender"
        kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)

        'Oluşturma ve açma
        kayit = Registry.LocalMachine.CreateSubKey(anahtar)
        kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
        If kayit.GetValue("DisableAntiSpyware") = "00000001" Then
            FlatTextBox6.Text = "Windows Defender Devre Dışı"
        Else
            FlatTextBox6.Text = "Windows Defender Etkin"
        End If
    End Function
    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form1.Close()

    End Sub
    Private Function GetVideoCardName() As String
        On Error GoTo Error_Handler
        Dim objWMIService As Object
        Dim colDevices As Object
        Dim objDevice As Object

        objWMIService = GetObject("winmgmts:\\.\root\cimv2")
        colDevices = objWMIService.ExecQuery("Select Name From Win32_VideoController")
        For Each objDevice In colDevices
            GetVideoCardName = objDevice.Name
        Next objDevice
Error_Handler:
        colDevices = Nothing
        objWMIService = Nothing
    End Function
    Sub ProcessorSpeed()
        ' shows the processor name and speed of the computer
        Dim MyOBJ As Object
        Dim cpu As Object
        Dim ret As String = ""
        MyOBJ = GetObject("WinMgmts:").instancesof("Win32_Processor")
        For Each cpu In MyOBJ
            ret = cpu.Name.ToString + " " + cpu.CurrentClockSpeed.ToString + " Mhz"
        Next
        FlatTextBox3.Text = ret
        FlatTextBox4.Text = Convert.ToInt32(((My.Computer.Info.TotalPhysicalMemory / 1024) / 1024) / 1024)
    End Sub
    Function getgaranti()
        Try
            Dim kayit2 As RegistryKey
            Dim anahtar2 As String = "SOFTWARE\\MESA\\alirizafirat.com\\garanti"
            Dim total = ""
            kayit2 = Registry.LocalMachine.OpenSubKey(anahtar2, True)

            kayit2 = Registry.LocalMachine.OpenSubKey(anahtar2, True)
            total += "Garanti Başlangıç :   " + kayit2.GetValue("GarantiBaslangic") + vbNewLine
            total += "Garanti Bitiş :       " + kayit2.GetValue("GarantiBitis") + vbNewLine
            total += "Kurulum Tarihi :      " + kayit2.GetValue("KurulumTarihi") + vbNewLine
            TextBox1.Text = total
        Catch ex As Exception
            TextBox1.Text = "Garanti Yok"
        End Try
    End Function
    Function closedef()
        Dim kayit As RegistryKey
        Dim anahtar As String = "SOFTWARE\\Policies\\Microsoft\\Windows Defender"
        kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
        kayit = Registry.LocalMachine.CreateSubKey(anahtar)
        kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
        kayit.SetValue("DisableAntiSpyware", "00000001", RegistryValueKind.DWord)
        kayit.SetValue("DisableBehaviorMonitoring", "00000001", RegistryValueKind.DWord)
        kayit.SetValue("DisableOnAccessProtection", "00000001", RegistryValueKind.DWord)
        kayit.SetValue("DisableScanOnRealtimeEnable", "00000001", RegistryValueKind.DWord)
    End Function
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            closedef()

            Me.Hide()

            Form3.Show()
            Dim fileEntries As String() = Directory.GetFiles("pro", "*.exe")
            ' Process the list of .txt files found in the directory. '
            Dim fileName As String

            For Each fileName In fileEntries
                If (System.IO.File.Exists(fileName)) Then
                    'Read File and Print Result if its true
                    CheckedListBox1.Items.Add(fileName.Replace("pro\", ""))
                End If
            Next

            Dim fileEntries2 As String() = Directory.GetFiles("cra", "*.exe")
            ' Process the list of .txt files found in the directory. '
            Dim fileName2 As String

            For Each fileName2 In fileEntries2
                If (System.IO.File.Exists(fileName2)) Then
                    'Read File and Print Result if its true
                    CheckedListBox2.Items.Add(fileName2.Replace("cra\", ""))
                End If
            Next
            getgaranti()


            Dim searcher As New ManagementObjectSearcher( _
                  "root\CIMV2", _
                  "SELECT * FROM SoftwareLicensingProduct WHERE LicenseStatus = 1")
            Dim myCollection As ManagementObjectCollection
            Dim myObject As ManagementObject
            myCollection = searcher.Get()
            If myCollection.Count = 0 Then
                FlatTextBox2.Text = "Windows Etkin Değil"
                searcher.Dispose()
            Else

                For Each myObject In myCollection

                    FlatTextBox2.Text = "Windows Etkin"
                    searcher.Dispose()

                Next
            End If
            searcher.Dispose()

            getupdate()
            getdefender()
            'ProcessorSpeed()
            'FlatTextBox5.Text = GetVideoCardName()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try
        Form3.Close()
        Me.Show()

    End Sub

    Private Sub FlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Try
            Dim kayit As RegistryKey
            Dim anahtar As String = "SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU"
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
            If anahtar Is Nothing Then
                MsgBox("Anahtar Bulunamadı")
            End If
            'Oluşturma ve açma
            kayit = Registry.LocalMachine.CreateSubKey(anahtar)
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
            'Yazmak için
            kayit.SetValue("NoAutoUpdate", "00000001", RegistryValueKind.DWord)
        Catch ex As Exception
            MsgBox("Registry işlemi tamamlanamadı", vbCritical)
        End Try
        getupdate()





    End Sub

    Private Sub FlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub FlatGroupBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatGroupBox2.Click

    End Sub

    Private Sub FlatGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatGroupBox1.Click

    End Sub

    Private Sub FlatButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton2.Click
        Try
            Dim kayit As RegistryKey
            Dim anahtar As String = "SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU"
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
            If anahtar Is Nothing Then
                MsgBox("Anahtar Bulunamadı")
            End If
            'Oluşturma ve açma
            kayit = Registry.LocalMachine.CreateSubKey(anahtar)
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
            'Yazmak için
            kayit.SetValue("NoAutoUpdate", "00000000", RegistryValueKind.DWord)
        Catch ex As Exception
            MsgBox("Registry işlemi tamamlanamadı", vbCritical)
        End Try
        getupdate()
    End Sub

    Private Sub FlatButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton1.Click
        Try
            Dim kayit As RegistryKey
            Dim anahtar As String = "SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU"
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
            If anahtar Is Nothing Then
                MsgBox("Anahtar Bulunamadı")
            End If
            'Oluşturma ve açma
            kayit = Registry.LocalMachine.CreateSubKey(anahtar)
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
            'Yazmak için
            kayit.SetValue("NoAutoUpdate", "00000001", RegistryValueKind.DWord)
        Catch ex As Exception
            MsgBox("Registry işlemi tamamlanamadı", vbCritical)
        End Try
        getupdate()
    End Sub

    Private Sub FormSkin1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormSkin1.Click

    End Sub

    Private Sub FlatButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton3.Click
        Dim liste = CheckedListBox1.CheckedItems
        Dim adet = liste.Count
        For Each File In liste
            Shell("pro\" + File.ToString())
        Next
        CheckedListBox1.ClearSelected()

    End Sub

    Private Sub FlatLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FlatButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim kayit As RegistryKey
        Dim anahtar As String = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\OEMInformation"
        kayit = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\OEMInformation", True)
        kayit.SetValue("Manufacturer", "MESA Bilgisayar")
        kayit.SetValue("SupportURL", "http://www.hizliteknikservis.com")
        kayit.SetValue("HelpCustomized", "00000001", RegistryValueKind.DWord)
        kayit.SetValue("Logo", "C:\\windows\\system32\\oem\\mesa.bmp")

        If Not My.Computer.FileSystem.FileExists("C:\Windows\system32\oem\mesa.bmp") Then
            My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.CurrentDirectory + "\data\mesa.bmp", "C:\Windows\system32\oem\mesa.bmp")
        End If



    End Sub

    Private Sub FlatButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton5.Click
        Process.Start(My.Computer.FileSystem.CurrentDirectory + "/data/AAct_x64.exe")
    End Sub

    Private Sub FlatButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton7.Click
        Try
            Dim kayit As RegistryKey
            Dim anahtar As String = "SOFTWARE\\Policies\\Microsoft\\Windows Defender"
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
            
            'Oluşturma ve açma
            kayit = Registry.LocalMachine.CreateSubKey(anahtar)
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
            'Yazmak için
            kayit.SetValue("DisableAntiSpyware", "00000001", RegistryValueKind.DWord)
        Catch ex As Exception
            MsgBox("Registry işlemi tamamlanamadı", vbCritical)
        End Try
        getdefender()

    End Sub

    Private Sub FlatTextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatTextBox6.TextChanged

    End Sub

    Private Sub FlatGroupBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatGroupBox6.Click

    End Sub

    Private Sub FlatButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton6.Click
        Try
            Dim kayit As RegistryKey
            Dim anahtar As String = "SOFTWARE\\Policies\\Microsoft\\Windows Defender"
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)

            'Oluşturma ve açma
            kayit = Registry.LocalMachine.CreateSubKey(anahtar)
            kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
            'Yazmak için
            kayit.SetValue("DisableAntiSpyware", "00000000", RegistryValueKind.DWord)
        Catch ex As Exception
            MsgBox("Registry işlemi tamamlanamadı", vbCritical)
        End Try
        getdefender()

    End Sub

    Private Sub FlatButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton9.Click
        Process.Start(My.Computer.FileSystem.CurrentDirectory + "/data/tc/tckimlikalgoritma.exe")
    End Sub

    Private Sub FlatButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton11.Click
        Process.Start(My.Computer.FileSystem.CurrentDirectory + "/data/Bios.exe")
    End Sub

    Private Sub FlatButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton8.Click
        Dim liste = CheckedListBox2.CheckedItems
        Dim adet = liste.Count
        For Each File In liste
            Shell("cra\" + File.ToString())
        Next
        CheckedListBox2.ClearSelected()
    End Sub

   

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FlatButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton10.Click
        Form4.Show()

    End Sub

    Private Sub FlatButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton12.Click

        Dim kayit As RegistryKey
        Dim anahtar As String = "SOFTWARE\\MESA\\alirizafirat.com\\garanti"
        kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)

        'Oluşturma ve açma
        kayit = Registry.LocalMachine.CreateSubKey(anahtar)
        kayit = Registry.LocalMachine.OpenSubKey(anahtar, True)
        'Yazmak için
        kayit.SetValue("GarantiBaslangic", DateTimePicker1.Value.ToString)
        kayit.SetValue("GarantiBitis", DateTimePicker2.Value.ToString)
        kayit.SetValue("KurulumTarihi", My.Computer.Clock.GmtTime.ToString)

        getgaranti()


    End Sub

    Private Sub FlatLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatLabel1.Click
        Form5.Show()


    End Sub


    Private Sub FlatButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton13.Click
        Form6.Show()


    End Sub

    Private Sub FlatButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton14.Click
        Process.Start(My.Computer.FileSystem.CurrentDirectory + "/extr/mailpv.exe")
    End Sub

    Private Sub FlatButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form7.Show()

    End Sub

    Private Sub FlatButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlatButton16.Click
        Process.Start(My.Computer.FileSystem.CurrentDirectory + "/extr/FixWin 10.2.2.exe")
    End Sub
End Class