Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class SeleccionarAñoCurso
    Dim ipServidor As String = datos_conn.getservidor()
    Dim puerto As String = datos_conn.getpuerto()
    Dim claveBD As String = datos_conn.getpass()
    Dim basededatos As String = datos_conn.getbd()
    Dim usuarioBD As String = datos_conn.getuser()
    Dim strcon As String
    Public dreader As SqlDataReader
    Dim conector As New SqlConnection("server=" + ipServidor + "  ;user='" + usuarioBD + "';password= '" + claveBD + "' ; database=" + basededatos + "")



    Dim cmd As OleDbDataAdapter
    Dim cnn As OleDbConnection

    Private Sub SeleccionarAñoCurso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MostrarAñoParaCurso()
       
    End Sub
    Sub MostrarAñoParaCurso()

        conector.Close()
        conector.Open()
        Dim qry As String = "select year(matricula.fecha_matricula) from matricula,alumno where alumno.rut_alumno = matricula.rut_alumno and alumno.estado='activo'"
        Dim sqlcmd As New SqlCommand(qry, conector)
        Dim drc As Integer
        drc = sqlcmd.ExecuteScalar
        ComboBox1.SelectionStart = drc.ToString
        conector.Close()
        conector.Close()
        conector.Close()


    End Sub


End Class