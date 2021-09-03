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

        'MsgBox("'확인'을 눌러 프로그램을 다시 시작합니다.", vbInformation)

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

    Public Sub InfoCopy(form As Form, Optional errortext As String = "")
        Dim cominfo As String = ""

        If Not errortext = "" Then
            cominfo += "[ERROR LOG]" + vbCr + errortext + vbCr + vbCr
        End If

        If MsgBox("프로그램 설정값을 복사하시겠습니까?" + vbCr + vbCr _
                  + "오류 보고일 경우, 더욱 정확한 조사를 위해 '예'를 눌러 복사해 주시기 바랍니다." _
                  + vbCr + "(시간표와 같은 민감한 개인 정보는 다음 대화 상자에서 포함 여부를 설정하실 수 있습니다.)",
                  vbQuestion + vbYesNo) = vbYes Then
            Dim g As Graphics = form.CreateGraphics
            Dim dpi = g.DpiX.ToString()

            cominfo += "[Device Information]" _
                + vbCr + "AppName: " + My.Application.Info.ProductName _
                + vbCr + "AppVersion: " + My.Application.Info.Version.ToString _
                + vbCr + "OS fullname: " + My.Computer.Info.OSFullName.ToString _
                + vbCr + "OS version: " + My.Computer.Info.OSVersion.ToString _
                + vbCr + "OS Platform: " + My.Computer.Info.OSPlatform.ToString _
                + vbCr + "TotalPhysicalMemory: " + My.Computer.Info.TotalPhysicalMemory.ToString _
                + vbCr + "ScreenDPI: " + dpi _
                + vbCr + "OS type: "
            If My.Computer.FileSystem.DirectoryExists("C:\Program Files (x86)") Then
                cominfo = cominfo + "64Bit OS"
            Else
                cominfo = cominfo + "32Bit OS"
            End If

            cominfo += vbCr + vbCr + "[Application Settings Value]" + vbCr
            '설정값 나열
            If My.Computer.FileSystem.FileExists(ININamePath) Then
                'My.Settings.defalutTable = OptionSave()
                cominfo += My.Computer.FileSystem.ReadAllText(ININamePath, System.Text.Encoding.GetEncoding(949))
            Else
                cominfo += "(None)"
            End If

            If MsgBox("현재 적용된 시간표 내용(Default.udata)도 포함하시겠습니까?" + vbCr _
                      + vbCr + "(해당 설정은 프로그램 오류 조사시에만 사용됩니다." _
                      + "하지만 해당 정보는 민감한 개인 정보이기 때문에 제공하기 원치 않으신 경우 " _
                      + "'아니오'를 누르시면 해당 정보는 제외된 채 정보가 복사됩니다)",
                      vbQuestion + vbYesNo) = vbYes Then
                cominfo += vbCr + vbCr + "[uTable Default Data]" + vbCr
                cominfo += readTable()
                cominfo += vbCr + "[End of Data]"
            End If

            cominfo += vbCr + vbCr

            cominfo += "[Report Time]" + vbCr + DateTime.Now.ToString
            Clipboard.SetText(cominfo)
            MsgBox("복사가 완료되었습니다.", vbInformation)
        Else
            If Not errortext = "" Then
                Clipboard.SetText(cominfo)
                MsgBox("복사가 완료되었습니다.", vbInformation)
            End If
        End If
    End Sub

#End Region

End Module
