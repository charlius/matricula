Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Mail
Public Class Ingreso_Rut_Matricula

    Public FechaNa_form As Date
    Public FechaMa_form As Date

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
        Seleccion_Tipo_Matricula.Enabled = True
        Seleccion_Tipo_Matricula.Show()
        Me.Hide()


    End Sub

    Private Sub textbox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Click, TextBox1.Click

        If TextBox1.Text = "INGRESE RUT ALUMNO" Then
            TextBox1.Clear()
        End If
        
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            conector.Close()

            Dim qry As String = "select TOP 1 alumno.rut_alumno ,alumno.nombres,alumno.apellidos,alumno.fecha_nacimiento, matricula.edad_alumno,curso.Nombre ,matricula.fono_urgencia_1 ,matricula.fono_urgencia_2,alumno.sexo,apoderado.rut_apoderado , apoderado.nombre_apoderado ,apoderado.domicilio , apoderado.fono  ,matricula.fecha_matricula ,matricula.escuela_procedencia ,matricula.cursos_repetidos ,matricula.domicilio_alumno ,matricula.alergico , matricula.grupo_sanguineo ,matricula.enfermedad ,matricula.grupo_pie ,matricula.nombre_padre ,matricula.nombre_madre ,matricula.rut_padre ,matricula.rut_madre ,matricula.trabajo_padre ,matricula.trabajo_madre ,matricula.escolaridad_padre ,matricula.escolaridad_madre ,matricula.vive_con ,matricula.casa_propia ,matricula.ingreso_mensual ,matricula.beneficio ,matricula.religion , usuario.nombre_usuario from alumno, apoderado, curso, matricula, usuario where matricula.rut_alumno = alumno.rut_alumno And apoderado.rut_apoderado = matricula.rut_apoderado And matricula.curso_alumno = curso.id_curso And matricula.id_usuario = usuario.id_usuario And matricula.rut_alumno ='" & TextBox1.Text & "' ORDER BY matricula.Id_registro DESC "
            conector.Open()
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader

            If dr.Read() Then

                matricula.TextBox4.Text = dr("rut_alumno")
                matricula.TextBox28.Text = dr("rut_alumno")
                matricula.TextBox3.Text = dr("nombres")
                matricula.TextBox2.Text = dr("apellidos")
                Form1.FechaNa = dr("fecha_nacimiento")
                matricula.calendarn.SetDate(Form1.FechaNa)
                matricula.TextBox1.Text = dr("edad_alumno")
                matricula.ComboBox1.Text = dr("Nombre")
                matricula.TextBox5.Text = dr("fono_urgencia_1")
                matricula.TextBox29.Text = dr("fono_urgencia_2")
                matricula.ComboBox6.Text = dr("sexo")
                matricula.TextBox9.Text = dr("rut_apoderado")
                matricula.TextBox27.Text = dr("rut_apoderado")
                matricula.TextBox8.Text = dr("nombre_apoderado")
                matricula.TextBox7.Text = dr("domicilio")
                matricula.TextBox6.Text = dr("fono")
                Form1.FechaMa = dr("fecha_matricula")
                matricula.calen.SetDate(Form1.FechaMa)
                matricula.TextBox25.Text = dr("escuela_procedencia")
                matricula.TextBox23.Text = dr("cursos_repetidos")
                matricula.TextBox24.Text = dr("domicilio_alumno")
                matricula.TextBox22.Text = dr("alergico")
                matricula.TextBox37.Text = dr("grupo_sanguineo")
                matricula.TextBox21.Text = dr("enfermedad")
                matricula.ComboBox2.Text = dr("grupo_pie")
                matricula.TextBox20.Text = dr("nombre_padre")
                matricula.TextBox10.Text = dr("nombre_madre")
                matricula.TextBox11.Text = dr("rut_padre")
                matricula.TextBox12.Text = dr("rut_madre")
                matricula.TextBox13.Text = dr("trabajo_padre")
                matricula.TextBox14.Text = dr("trabajo_madre")
                matricula.TextBox15.Text = dr("escolaridad_padre")
                matricula.TextBox16.Text = dr("escolaridad_madre")
                matricula.TextBox17.Text = dr("vive_con")
                matricula.ComboBox3.Text = dr("casa_propia")
                matricula.TextBox18.Text = dr("ingreso_mensual")
                matricula.TextBox19.Text = dr("beneficio")
                matricula.ComboBox4.Text = dr("religion")
                matricula.TextBox26.Text = dr("nombre_usuario")


                conector.Close()

                Form1.PictureBox1.Enabled = False

                matricula.TextBox1.Enabled = True
                matricula.TextBox2.Enabled = True
                matricula.TextBox3.Enabled = True
                matricula.TextBox4.Enabled = True
                matricula.TextBox5.Enabled = True
                matricula.TextBox6.Enabled = True
                matricula.TextBox7.Enabled = True
                matricula.TextBox8.Enabled = True
                matricula.TextBox9.Enabled = True
                matricula.TextBox10.Enabled = True
                matricula.TextBox11.Enabled = True
                matricula.TextBox12.Enabled = True
                matricula.TextBox13.Enabled = True
                matricula.TextBox14.Enabled = True
                matricula.TextBox15.Enabled = True
                matricula.TextBox16.Enabled = True
                matricula.TextBox17.Enabled = True
                matricula.TextBox18.Enabled = True
                matricula.TextBox19.Enabled = True
                matricula.TextBox20.Enabled = True
                matricula.TextBox21.Enabled = True
                matricula.TextBox22.Enabled = True
                matricula.TextBox23.Enabled = True
                matricula.TextBox24.Enabled = True
                matricula.TextBox25.Enabled = True
                matricula.TextBox26.Enabled = True
                matricula.TextBox27.Enabled = True
                matricula.TextBox28.Enabled = True
                matricula.TextBox29.Enabled = True
                matricula.TextBox30.Enabled = True
                matricula.TextBox37.Enabled = True

                matricula.ComboBox1.Enabled = True
                matricula.ComboBox2.Enabled = True
                matricula.ComboBox3.Enabled = True
                matricula.ComboBox4.Enabled = True

                matricula.calendarn.Enabled = True
                matricula.calen.Enabled = True

                matricula.ComboBox6.Enabled = True

              

                Form1.check_campos()

                matricula.Button26.Visible = False
                matricula.Button16.Visible = False
                matricula.Button1.Visible = True
                matricula.Button15.Visible = True
                matricula.Button14.Visible = True

                matricula.Button5.Visible = True
                matricula.Button27.Visible = False
                matricula.Button2.Visible = True
                matricula.Button3.Visible = True
                matricula.Button4.Visible = True

                matricula.Button8.Visible = False
                matricula.Button6.Visible = True
                matricula.Button9.Visible = True
                matricula.Button28.Visible = True
                matricula.Button65.Visible = True

               

                matricula.Enabled = True
                Seleccion_Tipo_Matricula.Enabled = True
                Seleccion_Tipo_Matricula.Hide()
                Seleccion_Tipo_Matricula.Close()
                Form1.Hide()
                Form1.Close()
                Me.Hide()
                Me.Close()

                matricula.TabControl1.SelectedIndex = 1
                matricula.Show()
                conector.Close()

            End If

        Catch ex As Exception
            MsgBox("ERROR" & vbCrLf & ex.Message)
            conector.Close()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        conector.Close()
        If TextBox1.TextLength = 8 Then TextBox1.Text = ValidaRut(TextBox1.Text)
    End Sub
    Public Function ValidaRut(ByVal ElNumero As String) As String
        Try
            Dim Resultado As String = ""
            Dim Multiplicador As Integer = 2
            Dim iNum As Integer = 0
            Dim Suma As Integer = 0

            For i As Integer = 8 To 1 Step -1
                iNum = Mid(ElNumero, i, 1)
                Suma += iNum * Multiplicador
                Multiplicador += 1
                If Multiplicador = 8 Then Multiplicador = 2
            Next
            Resultado = CStr(11 - (Suma Mod 11))
            If Resultado = "10" Then Resultado = "K"
            If Resultado = "11" Then Resultado = "0"
            Return ElNumero & "-" & Resultado
        Catch ex As Exception
            conector.Close()
        End Try
    End Function
End Class