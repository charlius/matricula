﻿Imports System.Runtime.InteropServices
Imports System.Data.SqlClient

Public Class inicio1
    Dim ipServidor As String
    Dim puerto As String
    Dim claveBD As String
    Dim basededatos As String
    Dim usuarioBD As String

    Dim strcon As String
    Public dreader As SqlDataReader
    Public nomUsuario As String

    Dim conector As New SqlConnection

    Dim dt As DataTable






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

    Private Sub test_login_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        strcon = "Provider=SQLOLEDB.1;Password=" & claveBD & ";Persist Security Info=True;User ID=" & usuarioBD & ";Initial Catalog=" & basededatos & ";Data Source=" & servidor & ""
        conector.Close()

        Try
            cargardatos()
            conector.Open()
            Dim qry As String = "select * from usuario "
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader


            If dr.Read() Then
                ' todo bien con la coneccion
            End If
            conector.Close()
        Catch ex As Exception
            conector.Close()
            MsgBox("Porfavor contacte al administrador y revise la coneccion ala base de datos...")

        End Try

    End Sub

    Public Sub cargardatos()
        datos_conn.cargardatos()
        ipServidor = datos_conn.getservidor()
        puerto = datos_conn.getpuerto()
        claveBD = datos_conn.getpass()
        basededatos = datos_conn.getbd()
        usuarioBD = datos_conn.getuser()
        conector = New SqlConnection("server=" + ipServidor + "  ;user='" + usuarioBD + "';password= '" + claveBD + "' ; database=" + basededatos + "")

    End Sub
    





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        conector.Close()
        Try
            conector.Open()
            Dim qry As String = "select * from usuario where nombre_usuario = '" & txtuser.Text & "' and pass='" & txtpass.Text & "'"
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader


            If dr.Read() Then
                'matricula.Show()
                barra_load.Show()

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

    Private Sub txtpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.TextChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtuser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtuser.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FormEntrarUsuarios.Show()
        Me.Enabled = False

    End Sub

 

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        End
        Me.Close()
    End Sub
End Class
