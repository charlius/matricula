Imports System.Runtime.InteropServices
Imports System.Data.SqlClient

Public Class inicio
    Public nomUsuario As String
    Dim ipServidor As String = "DESKTOP-AVV9E8Q"
    Dim claveBD As String
    Dim servidorSQL As String
    Dim basededatos As String = "matriculas_ll"
    Dim usuarioBD As String = "charles"
    Dim strcon As String


    Dim dt As DataTable




    Public dreader As SqlDataReader
    Dim conector As New SqlConnection("server=DESKTOP-AVV9E8Q  ;user='charles';password= '199314' ; database=matriculas_ll")

    'ARRASTRAR FORMULARIO
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub txtuser_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuser.Enter
        If txtuser.Text = "USUARIO" Then
            txtuser.Text = ""
            txtuser.ForeColor = Color.Black

        End If

    End Sub

    Private Sub txtuser_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuser.Leave
        If txtuser.Text = "" Then
            txtuser.Text = "USUARIO"
            txtuser.ForeColor = Color.Black

        End If
    End Sub


    Private Sub txtpass_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.Enter
        If txtpass.Text = "PASSWORD" Then
            txtpass.Text = ""
            txtpass.ForeColor = Color.LightGray

        End If
    End Sub

    Private Sub txtpass_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.Leave
        If txtpass.Text = "" Then
            txtpass.Text = "PASSWORD"
            txtpass.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub test_login_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        claveBD = "199314"
        servidorSQL = "DESKTOP-AVV9E8Q"
        strcon = "Provider=SQLOLEDB.1;Password=" & claveBD & ";Persist Security Info=True;User ID=" & usuarioBD & ";Initial Catalog=" & basededatos & ";Data Source=" & servidorSQL & ""


        conector.Close()
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

    Private Sub salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles salir.Click
        Me.Close()
    End Sub
End Class
