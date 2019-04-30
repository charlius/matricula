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
        Dim qry As String = "select DISTINCT year(matricula.fecha_matricula) as año from matricula,alumno where alumno.rut_alumno = matricula.rut_alumno and alumno.estado= 'activo' ORDER BY year(fecha_matricula)"
        Dim sqlcmd As New SqlCommand(qry, conector)
        'Dim drc As String
        Dim da As SqlDataAdapter = New SqlDataAdapter(sqlcmd)
        Dim ds As DataSet = New DataSet()

        Dim drc = sqlcmd.ExecuteReader
        conector.Close()
        da.Fill(ds)

        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.DisplayMember = "año"
        ComboBox1.SelectedIndex = 0

    End Sub


    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        conector.Close()
        conector.Close()
        conector.Close()
        If MsgBox("¿ Seguro que desea salir ?", vbQuestion + vbYesNo, "Pregunta") = vbYes Then
            matricula.Enabled = True
            matricula.Show()
            Me.Hide()

        End If
    End Sub
End Class