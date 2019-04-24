Imports System.Runtime.InteropServices
Imports System.Data.SqlClient

Public Class inicio
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



    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        claveBD = "1234321"
        servidorSQL = "192.168.1.55"
        strcon = "Provider=SQLOLEDB.1;Password=" & claveBD & ";Persist Security Info=True;User ID=" & usuarioBD & ";Initial Catalog=" & basededatos & ";Data Source=" & servidorSQL & ""


        conector.Close()
    End Sub
    Private Sub txtuser_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuser.Enter


    End Sub


    Private Sub txtuser_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuser.Leave
       
    End Sub
  
    Private Sub test_login_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
       
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
     
    End Sub
    Private Sub txtpass_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.Leave
    
    End Sub
 

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub

    

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        conector.Close()
        Try
            conector.Open()
            Dim qry As String = "select * from usuario where nombre_usuario = '" & txtuser.Text & "' and pass='" & txtpass.Text & "'"
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader


            If dr.Read() Then
                matricula.Show()
                Me.Hide()
                nomUsuario = txtuser.Text
                conector.Close()

                conector.Close()

            Else
                MsgBox("Contraseña Incorrecta", MsgBoxStyle.Critical, "Atencion")
                conector.Close()
            End If
            conector.Close()
        Catch ex As Exception
            conector.Close()
            MsgBox("error" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Atencion")

        End Try

    End Sub

    Private Sub txtpass_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtpass.TextChanged

    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtuser_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtuser.TextChanged

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        FormEntrarUsuarios.Show()
        Me.Enabled = False

    End Sub
End Class
