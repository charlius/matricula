Imports System.IO

Module datos_conn
    Public servidor As String
    Public puerto As String
    Public bd As String
    Public user As String
    Public pass As String

    Public Sub cargardatos()
        Dim objStreamReader As StreamReader
        objStreamReader = New StreamReader(Directory.GetCurrentDirectory() + "\Testfile.txt")
        servidor = objStreamReader.ReadLine
        puerto = objStreamReader.ReadLine
        bd = objStreamReader.ReadLine
        user = objStreamReader.ReadLine
        pass = objStreamReader.ReadLine
        objStreamReader.Close()

    End Sub

    Public Function getservidor() As String
        Return servidor
    End Function

    Public Function getbd() As String
        Return bd
    End Function

    Public Function getuser() As String
        Return user
    End Function

    Public Function getpass() As String
        Return pass
    End Function

    Public Function getpuerto() As String
        Return puerto
    End Function
End Module
