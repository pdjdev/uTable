Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Module INIModule
    Public ININame As String = "settings.ini"
    Public INIPath As String = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\"))
    Public ININamePath As String = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\")) + "\settings.ini"


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
