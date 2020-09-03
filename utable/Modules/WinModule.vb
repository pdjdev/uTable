Imports System.Security.Principal

Module WinModule

#Region "시작프로그램설정"

    Dim shortcutname = "\uTable.lnk"

    Public Function checkStartUp() As Boolean
        Dim destlnk As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup) & shortcutname

        If IO.File.Exists(destlnk) Then
            If GetTargetPath(destlnk) = Application.ExecutablePath Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Sub SetStartup()
        Dim Path As String
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)

        Path = Environment.GetFolderPath(Environment.SpecialFolder.Startup) & shortcutname

        Dim wsh As Object = CreateObject("WScript.Shell")

        Dim MyShortcut
        MyShortcut = wsh.CreateShortcut(Path)
        MyShortcut.TargetPath = wsh.ExpandEnvironmentStrings(Application.ExecutablePath)
        MyShortcut.WindowStyle = 4
        MyShortcut.Save()
    End Sub

    Sub RemoveStartup()
        My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.Startup) & shortcutname)
    End Sub

    '바로가기 목적지경로 리턴 2
    Function GetTargetPath(ByVal FileName As String)
        Dim Obj As Object
        Obj = CreateObject("WScript.Shell")
        Dim Shortcut As Object
        Shortcut = Obj.CreateShortcut(FileName)
        GetTargetPath = Shortcut.TargetPath
    End Function

#End Region

#Region "프로그램 실행 관리"

    '프로그램 재시작
    Public Sub reStarter()
        Dim exeFullpath As String = Application.ExecutablePath
        Dim exePath = exeFullpath.Substring(0, exeFullpath.LastIndexOf("\"))
        Dim exeName = Mid(exeFullpath, exeFullpath.LastIndexOf("\") + 2)

        MsgBox("'확인'을 눌러 프로그램을 다시 시작합니다.", vbInformation)

        Dim procStartInfo As New ProcessStartInfo
        Dim procExecuting As New Process

        With procStartInfo
            .UseShellExecute = True
            .FileName = "cmd.exe"
            .WindowStyle = ProcessWindowStyle.Hidden
            .Arguments = "/k @echo off & taskkill /f /im """ + exeName + """ >nul " _
                + " & timeout /t 1 /nobreak >nul" _
                + " & start """" """ + exeFullpath + """ & exit"
        End With

        procExecuting = Process.Start(procStartInfo)
    End Sub

#End Region

End Module
