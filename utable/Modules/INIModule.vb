Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Module INIModule
    Public ININame As String = "settings.ini"
    ' Store 패키지는 설치 폴더(WindowsApps)에 쓸 수 없으므로 사용자 데이터 폴더를 사용한다.
    ' 일반/포터블 실행은 기존 호환성을 위해 실행 파일과 같은 폴더를 기본 저장소로 유지한다.
    Public ReadOnly INIPath As String = GetDefaultStorageDirectory()
    Public ReadOnly ININamePath As String = Path.Combine(INIPath, ININame)

    Public Function GetDefaultStorageDirectory() As String
        If IsStoreApp Then
            Dim storageDirectory As String = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "uTable")
            Directory.CreateDirectory(storageDirectory)
            Return storageDirectory
        End If

        Return Path.GetDirectoryName(Application.ExecutablePath)
    End Function


#Region "INI 관련 함수들"

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Function GetPrivateProfileString(ByVal lpAppName As String,
                                                    ByVal lpKeyName As String,
                                                    ByVal lpDefault As String,
                                                    ByVal lpReturnedString As StringBuilder,
                                                    ByVal nSize As Integer,
                                                    ByVal lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Function WritePrivateProfileString(ByVal lpAppName As String,
                                                      ByVal lpKeyName As String,
                                                      ByVal lpString As String,
                                                      ByVal lpFileName As String) As Boolean
    End Function

    Public Function SetINI(ByVal strAppName As String,
                            ByVal strKey As String,
                            ByVal strValue As String,
                            ByVal strFilePath As String) As Boolean
        SetINI = WritePrivateProfileString(strAppName, strKey, strValue, strFilePath)
    End Function

    Public Function GetINI(ByVal strAppName As String,
                            ByVal strKey As String,
                            ByVal strValue As String,
                            ByVal strFilePath As String) As String

        Dim strbTmp As StringBuilder = New StringBuilder(255)
        GetPrivateProfileString(strAppName, strKey, strValue, strbTmp, strbTmp.Capacity, strFilePath)
        GetINI = strbTmp.ToString()
    End Function

    Public Function Create_INIFile(ByVal strPath As String, ByVal strFileName As String) As Boolean
        If Dir(strPath & "\" & strFileName) <> "" Then
            '이미 존재하는 경우
            Return True
            Exit Function
        End If

        Try
            Using sw As StreamWriter = New StreamWriter(strPath & "\" & strFileName, False)
                sw.WriteLine(vbCrLf)
                sw.Flush()
                sw.Close()
            End Using
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

#End Region

End Module
