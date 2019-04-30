Module datos_conn
    Public servidor = "DESKTOP-AVV9E8Q"
    Public puerto = "1433"
    Public bd = "matriculas_ll"
    Public user = "charles"
    Public pass = "199314"

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
