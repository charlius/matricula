Module datos_conn
    Public servidor = "HP_ROY\SQLEXP"
    Public puerto = "1433"
    Public bd = "matriculas_ll"
    Public user = "sa"
    Public pass = "1234321"

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
