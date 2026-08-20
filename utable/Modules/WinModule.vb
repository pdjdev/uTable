Module WinModule

#Region "시작프로그램설정"

    Private Const ShortcutFileName As String = "uTable.lnk"
    Private Const AppLaunchCmd As String = "C:\Windows\explorer.exe"
    Private Const AppCode As String = "shell:appsFolder\49490PBJSoftware.uTable_fv4zvza0919de!App"
    Private Const StoreAliasName As String = "uTable.exe"
    Private Const ErrorInsufficientBuffer As Integer = 122

    <Runtime.InteropServices.DllImport("kernel32.dll", CharSet:=Runtime.InteropServices.CharSet.Unicode)>
    Private Function GetCurrentApplicationUserModelId(ByRef applicationUserModelIdLength As UInteger,
                                                      applicationUserModelId As Text.StringBuilder) As Integer
    End Function

    ' MSIX/AppX로 실행 중인 프로세스에만 AUMID가 존재한다.
    Private Function GetCurrentAppUserModelId() As String
        Try
            Dim length As UInteger = 0
            If GetCurrentApplicationUserModelId(length, Nothing) <> ErrorInsufficientBuffer Then Return Nothing

            Dim applicationUserModelId As New Text.StringBuilder(CInt(length))
            If GetCurrentApplicationUserModelId(length, applicationUserModelId) <> 0 Then Return Nothing
            Return applicationUserModelId.ToString()
        Catch ex As EntryPointNotFoundException
            ' Windows 7 등 패키지 ID API를 지원하지 않는 환경
            Return Nothing
        End Try
    End Function

    Public ReadOnly Property IsStoreApp As Boolean
        Get
            Return Not String.IsNullOrEmpty(GetCurrentAppUserModelId())
        End Get
    End Property

    Private ReadOnly Property StoreAliasPath As String
        Get
            Return IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Microsoft",
                "WindowsApps",
                StoreAliasName)
        End Get
    End Property

    Private ReadOnly Property StartupShortcutPath As String
        Get
            Return IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                ShortcutFileName)
        End Get
    End Property

    Public Function checkStartUp() As Boolean
        If Not IO.File.Exists(StartupShortcutPath) Then Return False

        Dim targetPath As String = Nothing
        Dim arguments As String = Nothing
        If Not TryReadStartupShortcut(targetPath, arguments) Then Return False

        If IsStoreApp Then
            Return PathsEqual(targetPath, StoreAliasPath) AndAlso String.IsNullOrEmpty(arguments)
        End If

        If Not PathsEqual(targetPath, Application.ExecutablePath) Then Return False
        Return String.IsNullOrEmpty(arguments)
    End Function

    Private Function TryReadStartupShortcut(ByRef targetPath As String, ByRef arguments As String) As Boolean
        Try
            Dim wsh As Object = CreateObject("WScript.Shell")
            Dim shortcut As Object = wsh.CreateShortcut(StartupShortcutPath)
            targetPath = CStr(shortcut.TargetPath)
            arguments = CStr(shortcut.Arguments).Trim()
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Function PathsEqual(firstPath As String, secondPath As String) As Boolean
        Try
            Return String.Equals(IO.Path.GetFullPath(firstPath).TrimEnd("\"c),
                                 IO.Path.GetFullPath(secondPath).TrimEnd("\"c),
                                 StringComparison.OrdinalIgnoreCase)
        Catch
            Return False
        End Try
    End Function

    Sub SetStartup()
        Dim targetPath As String

        If IsStoreApp Then
            targetPath = StoreAliasPath
            If Not IO.File.Exists(targetPath) Then
                Throw New InvalidOperationException("uTable 앱 실행 별칭을 찾을 수 없습니다: " & targetPath)
            End If
        Else
            targetPath = Application.ExecutablePath
        End If

        Dim wsh As Object = CreateObject("WScript.Shell")
        Dim myShortcut As Object = wsh.CreateShortcut(StartupShortcutPath)
        myShortcut.TargetPath = targetPath
        myShortcut.Arguments = ""
        myShortcut.WorkingDirectory = IO.Path.GetDirectoryName(targetPath)
        myShortcut.WindowStyle = 4
        myShortcut.Save()
    End Sub

    Public Sub MigrateStoreStartupShortcut()
        If Not IsStoreApp Then Return
        If Not IO.File.Exists(StartupShortcutPath) Then Return

        Dim targetPath As String = Nothing
        Dim arguments As String = Nothing
        If Not TryReadStartupShortcut(targetPath, arguments) Then Return

        If PathsEqual(targetPath, AppLaunchCmd) AndAlso
           String.Equals(arguments, AppCode, StringComparison.OrdinalIgnoreCase) Then
            Try
                SetStartup()
            Catch
                ' 기존 바로가기를 교체하지 못해도 앱 실행은 계속한다.
            End Try
        End If
    End Sub

    Sub RemoveStartup()
        If IO.File.Exists(StartupShortcutPath) Then My.Computer.FileSystem.DeleteFile(StartupShortcutPath)
    End Sub

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
                cominfo += ReadScheduleData()
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
