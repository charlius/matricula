Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Public Class FormMenuUsuario
    Dim ipServidor As String = datos_conn.getservidor()
    Dim puerto As String = datos_conn.getpuerto()
    Dim claveBD As String = datos_conn.getpass()
    Dim basededatos As String = datos_conn.getbd()
    Dim usuarioBD As String = datos_conn.getuser()
    Dim strcon As String
    Public dreader As SqlDataReader
    Dim conector As New SqlConnection("server=" + ipServidor + "  ;user='" + usuarioBD + "';password= '" + claveBD + "' ; database=" + basededatos + "")

    Public nombre_del_usuario_mod As String


    Dim dt As DataTable










    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TabPage2_Click(sender As System.Object, e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(2)
        TextBox3.Enabled = False
        ComboBox2.Enabled = False
        Button7.Visible = False
        Label8.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        inicio1.Enabled = True
        inicio1.Show()
        Me.Hide()
        FormEntrarUsuarios.txtuser.Text = ""
        FormEntrarUsuarios.txtpass.Text = ""

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(0)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(0)
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        conector.Close()



        If (TextBox1.Text = "" Or TextBox2.Text = "" Or ComboBox1.Text = "") Then
            MsgBox("No deje campos en blanco", MsgBoxStyle.Critical, "Atencion")
            TextBox1.Select()
            conector.Close()
        Else
            conector.Close()
            conector.Open()
            Dim qry As String = "select * from usuario where nombre_usuario = '" & TextBox1.Text & "'"
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader
            If dr.Read() Then

                conector.Close()

                MsgBox("Nombre de Usuario ya Registrado", MsgBoxStyle.Critical, "ALERTA")


                conector.Close()

            Else
                Try
                    conector.Close()

                    Dim cadena As String
                    cadena = String.Format("INSERT INTO usuario (nombre_usuario, pass, tipo_usuario) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & ComboBox1.SelectedItem & "')")

                    Dim insertar As New SqlCommand(cadena, conector)
                    conector.Open()
                    insertar.ExecuteNonQuery()

                    conector.Close()
                    MsgBox("Usuario Ingresado Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")

                    conector.Close()



                Catch ex As Exception
                    conector.Close()
                    conector.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub FormMenuUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        strcon = "Provider=SQLOLEDB.1;Password=" & claveBD & ";Persist Security Info=True;User ID=" & usuarioBD & ";Initial Catalog=" & basededatos & ";Data Source=" & servidor & ""


        conector.Close()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            conector.Open()
            Dim qry As String = "select usuario.nombre_usuario, usuario.pass, usuario.tipo_usuario from usuario where usuario.nombre_usuario ='" & TextBox4.Text & "' "
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader
            If dr.Read() Then
                nombre_del_usuario_mod = dr("nombre_usuario")
                TextBox3.Text = dr("pass")
                ComboBox2.Text = dr("tipo_usuario")


                conector.Close()
                Button7.Visible = True
                Label8.Enabled = True
                TextBox3.Enabled = True
                ComboBox2.Enabled = True
            Else

                MsgBox("ERROR NOMBRE USUARIO NO VALIDO", MsgBoxStyle.Critical, "Atencion")
                conector.Close()
            End If
            conector.Close()
        Catch ex As Exception
            conector.Close()
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        conector.Close()

        If (TextBox3.Text = "" Or TextBox3.Text = "" Or ComboBox2.Text = "") Then
            MsgBox("No deje campos en blanco", MsgBoxStyle.Critical, "Atencion")
            TextBox1.Select()
        Else
            Try
                conector.Close()
                Dim cadena As String
                cadena = String.Format("UPDATE usuario SET nombre_usuario = '" & TextBox4.Text & "' , pass ='" & TextBox3.Text & "', tipo_usuario = '" & ComboBox2.SelectedItem & "'  WHERE nombre_usuario = '" & nombre_del_usuario_mod & "'")
                Dim insertar As New SqlCommand(cadena, conector)
                conector.Open()
                insertar.ExecuteNonQuery()
                conector.Close()
                MsgBox("Usuario Actualizado Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")
                TextBox3.Enabled = False
                ComboBox2.Enabled = False
                Button7.Visible = False
                Label8.Enabled = False


            Catch ex As Exception
                conector.Close()
            End Try
            conector.Close()
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Label39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        conector.Close()
        conector.Close()
        conector.Close()
        If MsgBox("¿ Seguro que desea salir ?", vbQuestion + vbYesNo, "Pregunta") = vbYes Then
            inicio1.Enabled = True
            inicio1.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub PictureBox3_Click_1(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
        conector.Close()
        conector.Close()
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub
End Class