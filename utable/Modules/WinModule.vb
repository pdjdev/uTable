Module WinModule

#Region "시작프로그램설정"

    Private Const ShortcutName As String = "\uTable.lnk"
    Private Const AppLaunchCmd As String = "C:\Windows\explorer.exe"
    Private Const AppCode As String = "shell:appsFolder\49490PBJSoftware.uTable_fv4zvza0919de!App"
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

    Public Function checkStartUp() As Boolean
        Dim destlnk As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup) & ShortcutName
        If Not IO.File.Exists(destlnk) Then Return False

        Dim wsh As Object = CreateObject("WScript.Shell")
        Dim shortcut As Object = wsh.CreateShortcut(destlnk)
        Dim targetPath As String = CStr(shortcut.TargetPath)
        Dim arguments As String = CStr(shortcut.Arguments).Trim()

        ' MSIX 바로가기는 Explorer가 AppsFolder 경로를 실행한다.
        If IsStoreApp AndAlso PathsEqual(targetPath, AppLaunchCmd) AndAlso
           String.Equals(arguments, AppCode, StringComparison.OrdinalIgnoreCase) Then Return True

        ' 일반 exe 바로가기 및 이전 버전이 남긴 "exe + shell:appsFolder" 형식도 인정한다.
        If Not PathsEqual(targetPath, Application.ExecutablePath) Then Return False
        Return String.IsNullOrEmpty(arguments) OrElse arguments.StartsWith("shell:appsFolder\", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function PathsEqual(firstPath As String, secondPath As String) As Boolean
        Return String.Equals(IO.Path.GetFullPath(firstPath).TrimEnd("\"c),
                             IO.Path.GetFullPath(secondPath).TrimEnd("\"c),
                             StringComparison.OrdinalIgnoreCase)
    End Function

    Sub SetStartup()
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup) & ShortcutName
        Dim wsh As Object = CreateObject("WScript.Shell")
        Dim myShortcut As Object = wsh.CreateShortcut(path)

        If IsStoreApp Then
            myShortcut.TargetPath = wsh.ExpandEnvironmentStrings(AppLaunchCmd)
            myShortcut.Arguments = AppCode
        Else
            myShortcut.TargetPath = wsh.ExpandEnvironmentStrings(Application.ExecutablePath)
            myShortcut.Arguments = ""
        End If

        myShortcut.WindowStyle = 4
        myShortcut.Save()
    End Sub

    Sub RemoveStartup()
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup) & ShortcutName
        If IO.File.Exists(path) Then My.Computer.FileSystem.DeleteFile(path)
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
