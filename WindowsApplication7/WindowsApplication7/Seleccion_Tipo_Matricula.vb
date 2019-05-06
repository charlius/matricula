Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Mail

Public Class Seleccion_Tipo_Matricula
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
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        conector.Close()
        conector.Close()
        conector.Close()

        matricula.Enabled = True
        matricula.Show()
        Me.Hide()
        Form1.Hide()
        Form1.Close()
        Ingreso_Rut_Matricula.Hide()
        Ingreso_Rut_Matricula.Close()


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FormAñoAcademico.Enabled = True
        FormAñoAcademico.Show()
        FormAñoAcademico.Button1.Visible = True
        FormAñoAcademico.Button2.Visible = False
        Form1.Hide()
        Form1.Close()
        matricula.Enabled = False
        Me.Enabled = False

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        FormAñoAcademico.Enabled = True
        FormAñoAcademico.Show()
        FormAñoAcademico.Button1.Visible = False
        FormAñoAcademico.Button2.Visible = True
        Form1.Hide()
        Form1.Close()
        matricula.Enabled = False
        Me.Enabled = False
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        conector.Close()
        conector.Close()
        conector.Close()

        matricula.Enabled = True
        matricula.Show()
        Me.Close()
        Form1.Hide()
        Form1.Close()
        Ingreso_Rut_Matricula.Hide()
        Ingreso_Rut_Matricula.Close()
    End Sub
End Class