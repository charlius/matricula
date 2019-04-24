Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Public Class FormEntrarUsuarios
    Public nomUsuario As String
    Dim ipServidor As String = "192.168.1.55"
    Dim claveBD As String
    Dim servidorSQL As String
    Dim basededatos As String = "matriculas_ll"
    Dim usuarioBD As String = "servidorbdd"
    Dim strcon As String


    Dim dt As DataTable




    Public dreader As SqlDataReader
    Dim conector As New SqlConnection("server=192.168.1.55,1433  ;user='servidorbdd';password= '1234321' ; database=matriculas_ll")


    Private Sub FormEntrarUsuarios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        claveBD = "1234321"
        servidorSQL = "192.168.1.55"
        strcon = "Provider=SQLOLEDB.1;Password=" & claveBD & ";Persist Security Info=True;User ID=" & usuarioBD & ";Initial Catalog=" & basededatos & ";Data Source=" & servidorSQL & ""


        conector.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
        conector.Close()
        conector.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        conector.Close()
        conector.Close()
        conector.Close()
        If MsgBox("¿ Seguro que desea salir ?", vbQuestion + vbYesNo, "Pregunta") = vbYes Then
            inicio.Enabled = True
            inicio.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        conector.Close()
        Try
            conector.Open()
            Dim qry As String = "select * from usuario where nombre_usuario = '" & TextBox1.Text & "' and pass='" & TextBox2.Text & "' and tipo_usuario = 'admin'"
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader


            If dr.Read() Then
                FormMenuUsuario.Show()
                Me.Hide()
                inicio.Hide()

                conector.Close()

                conector.Close()

            Else
                MsgBox("USUARIO o CONTRASEÑA Incorrecta", MsgBoxStyle.Critical, "Atencion")
                conector.Close()
            End If
            conector.Close()
        Catch ex As Exception
            conector.Close()
            MsgBox("error" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Atencion")

        End Try
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class