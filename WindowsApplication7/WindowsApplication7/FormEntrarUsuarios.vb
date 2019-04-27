Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Public Class FormEntrarUsuarios
    Dim ipServidor As String = datos_conn.getservidor()
    Dim puerto As String = datos_conn.getpuerto()
    Dim claveBD As String = datos_conn.getpass()
    Dim basededatos As String = datos_conn.getbd()
    Dim usuarioBD As String = datos_conn.getuser()
    Dim strcon As String
    Public dreader As SqlDataReader
    Dim conector As New SqlConnection("server=" + ipServidor + "  ;user='" + usuarioBD + "';password= '" + claveBD + "' ; database=" + basededatos + "")



    Dim dt As DataTable







    Private Sub txtuser_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtuser.Text = "USUARIO" Then
            txtuser.Text = ""
            txtuser.ForeColor = Color.Black

        End If

    End Sub

    Private Sub txtuser_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtuser.Text = "" Then
            txtuser.Text = "USUARIO"
            txtuser.ForeColor = Color.LightGray

        End If
    End Sub


    Private Sub txtpass_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.Enter
        If txtpass.Text = "PASSWORD" Then
            txtpass.Text = ""
            txtpass.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtpass_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.Leave
        If txtpass.Text = "" Then
            txtpass.Text = "PASSWORD"
            txtpass.ForeColor = Color.LightGray
        End If
    End Sub
    Private Sub FormEntrarUsuarios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        
        strcon = "Provider=SQLOLEDB.1;Password=" & claveBD & ";Persist Security Info=True;User ID=" & usuarioBD & ";Initial Catalog=" & basededatos & ";Data Source=" & servidor & ""


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
            inicio1.Enabled = True
            inicio1.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        conector.Close()
        Try
            conector.Open()
            Dim qry As String = "select * from usuario where nombre_usuario = '" & txtuser.Text & "' and pass='" & txtpass.Text & "' and tipo_usuario = 'admin'"
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader


            If dr.Read() Then
                FormMenuUsuario.Show()
                Me.Hide()
                inicio1.Hide()

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
    Private Sub textbox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuser.Click, TextBox1.Click

        If txtuser.Text = "NOMBRE DE USUARIO" Then
            txtuser.Clear()
        End If
        If txtpass.Text = "" Then
            txtpass.Text = "PASSWORD"
        End If
    End Sub
    Private Sub textbox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpass.GotFocus
        If txtpass.Text = "PASSWORD" Then
            txtpass.Clear()
        End If
        If txtuser.Text = "" Then
            txtuser.Text = "NOMBRE DE USUARIO"
        End If
    End Sub
    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class