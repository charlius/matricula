Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class SeleccionarAñoCurso

    Public añoform As String
    Public rut_form As String
    Public cover_año As Integer

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
        Dim qry As String = "select DISTINCT matricula.año_academico from matricula,alumno where alumno.rut_alumno = matricula.rut_alumno and matricula.estado= 'activo' select DISTINCT matricula.año_academico from matricula,alumno where alumno.rut_alumno = matricula.rut_alumno and matricula.estado= 'activo' ORDER BY (matricula.año_academico)"
        Dim sqlcmd As New SqlCommand(qry, conector)
        'Dim drc As String
        Dim da As SqlDataAdapter = New SqlDataAdapter(sqlcmd)
        Dim ds As DataSet = New DataSet()

        Dim drc = sqlcmd.ExecuteReader
        conector.Close()
        da.Fill(ds)

        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.DisplayMember = "año_academico"
        ComboBox1.SelectedItem = 0

        matricula.seleccion_año = ComboBox1.Text

    End Sub


    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        conector.Close()
        conector.Close()
        conector.Close()

        matricula.Enabled = True
        matricula.Show()
        Me.Hide()


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        matricula.seleccion_año = ComboBox1.Text

        añoform = ComboBox1.Text



        primero_activas()
        segundo_activas()
        tercero_activas()
        cuarto_activas()
        quinto_activas()
        sexto_activas()
        septimo_activas()
        octavo_activas()
        kinder_activas()
        prekinder_activas()

        matricula.Label43.Text = "HAS ELEGIDO EL AÑO " + añoform

        matricula.TabControl1.SelectedTab = matricula.TabControl1.TabPages.Item(5)
        matricula.Enabled = True
        matricula.Show()

        Me.Hide()
    End Sub
    Sub primero_activas()
        conector.Close()
        Try
            cover_año = añoform
            conector.Close()
            conector.Open()
            Dim qryc As String = "select count (alumno.rut_alumno) from matricula,alumno where matricula.estado='activo' and matricula.curso_alumno= 1 and matricula.rut_alumno=alumno.rut_alumno and matricula.año_academico= " & cover_año & ""
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar




            matricula.Button29.Text = "1° Basico" + vbCrLf + "(" + drc.ToString + " Alumnos)"


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub segundo_activas()
        conector.Close()
        cover_año = añoform
        Try
            conector.Close()
            conector.Open()
            Dim qryc As String = "select count (alumno.rut_alumno) from matricula,alumno where matricula.estado='activo' and matricula.curso_alumno=2 and matricula.rut_alumno=alumno.rut_alumno and matricula.año_academico= " & cover_año & ""
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar




            matricula.Button30.Text = "2° Basico" + vbCrLf + "(" + drc.ToString + " Alumnos)"


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub tercero_activas()
        cover_año = añoform
        conector.Close()
        Try
            conector.Close()
            conector.Open()
            Dim qryc As String = "select count (alumno.rut_alumno) from matricula,alumno where matricula.estado='activo' and matricula.curso_alumno=3 and matricula.rut_alumno=alumno.rut_alumno and matricula.año_academico= " & cover_año & ""
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar




            matricula.Button33.Text = "3° Basico" + vbCrLf + "(" + drc.ToString + " Alumnos)"


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub cuarto_activas()
        cover_año = añoform
        conector.Close()
        Try
            conector.Close()
            conector.Open()
            Dim qryc As String = "select count (alumno.rut_alumno) from matricula,alumno where matricula.estado='activo' and matricula.curso_alumno=4 and matricula.rut_alumno=alumno.rut_alumno and matricula.año_academico= " & cover_año & ""
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar




            matricula.Button34.Text = "4° Basico" + vbCrLf + "(" + drc.ToString + " Alumnos)"


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub quinto_activas()
        cover_año = añoform
        conector.Close()
        Try
            conector.Close()
            conector.Open()
            Dim qryc As String = "select count (alumno.rut_alumno) from matricula,alumno where matricula.estado='activo' and matricula.curso_alumno=5 and matricula.rut_alumno=alumno.rut_alumno and matricula.año_academico= " & cover_año & ""
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar




            matricula.Button31.Text = "5° Basico" + vbCrLf + "(" + drc.ToString + " Alumnos)"


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub sexto_activas()
        cover_año = añoform
        conector.Close()
        Try
            conector.Close()
            conector.Open()
            Dim qryc As String = "select count (alumno.rut_alumno) from matricula,alumno where matricula.estado='activo' and matricula.curso_alumno=6 and matricula.rut_alumno=alumno.rut_alumno and matricula.año_academico= " & cover_año & ""
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar




            matricula.Button32.Text = "6° Basico" + vbCrLf + "(" + drc.ToString + " Alumnos)"


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub septimo_activas()
        cover_año = añoform
        conector.Close()
        Try
            conector.Close()
            conector.Open()
            Dim qryc As String = "select count (alumno.rut_alumno) from matricula,alumno where matricula.estado='activo' and matricula.curso_alumno=7 and matricula.rut_alumno=alumno.rut_alumno and matricula.año_academico= " & cover_año & ""
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar




            matricula.Button35.Text = "7° Basico" + vbCrLf + "(" + drc.ToString + " Alumnos)"


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub octavo_activas()
        cover_año = añoform
        conector.Close()
        Try
            conector.Close()
            conector.Open()
            Dim qryc As String = "select count (alumno.rut_alumno) from matricula,alumno where matricula.estado='activo' and matricula.curso_alumno=8 and matricula.rut_alumno=alumno.rut_alumno and matricula.año_academico= " & cover_año & ""
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar




            matricula.Button36.Text = "8° Basico" + vbCrLf + "(" + drc.ToString + " Alumnos)"


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub kinder_activas()
        cover_año = añoform
        conector.Close()
        Try
            conector.Close()
            conector.Open()
            Dim qryc As String = "select count (alumno.rut_alumno) from matricula,alumno where matricula.estado='activo' and matricula.curso_alumno=9 and matricula.rut_alumno=alumno.rut_alumno and matricula.año_academico= " & cover_año & ""
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar




            matricula.Button37.Text = "Kinder" + vbCrLf + "(" + drc.ToString + " Alumnos)"


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub prekinder_activas()
        cover_año = añoform
        conector.Close()
        Try
            conector.Close()
            conector.Open()
            Dim qryc As String = "select count (alumno.rut_alumno) from matricula,alumno where matricula.estado='activo' and matricula.curso_alumno=10 and matricula.rut_alumno=alumno.rut_alumno and matricula.año_academico= " & cover_año & ""
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar




            matricula.Button38.Text = "Pre-Kinder" + vbCrLf + "(" + drc.ToString + " Alumnos)"


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        conector.Close()

        añoform = ComboBox1.Text
        cover_año = añoform


        Try
            matricula.rut_pdf_alumno = matricula.TextBox28.Text
            conector.Open()
            Dim qry As String = "select alumno.rut_alumno ,alumno.nombres,alumno.apellidos,alumno.fecha_nacimiento, matricula.edad_alumno,curso.Nombre ,matricula.fono_urgencia_1 ,matricula.fono_urgencia_2,alumno.sexo,apoderado.rut_apoderado , apoderado.nombre_apoderado ,apoderado.domicilio , apoderado.fono  ,matricula.fecha_matricula ,matricula.escuela_procedencia ,matricula.cursos_repetidos ,matricula.domicilio_alumno ,matricula.alergico , matricula.grupo_sanguineo ,matricula.enfermedad ,matricula.grupo_pie ,matricula.nombre_padre ,matricula.nombre_madre ,matricula.rut_padre ,matricula.rut_madre ,matricula.trabajo_padre ,matricula.trabajo_madre ,matricula.escolaridad_padre ,matricula.escolaridad_madre ,matricula.vive_con ,matricula.casa_propia ,matricula.ingreso_mensual ,matricula.beneficio ,matricula.religion , usuario.nombre_usuario, matricula.año_academico from alumno, apoderado, curso, matricula, usuario where matricula.rut_alumno = alumno.rut_alumno And apoderado.rut_apoderado = matricula.rut_apoderado And matricula.curso_alumno = curso.id_curso And matricula.id_usuario = usuario.id_usuario And matricula.rut_alumno ='" & rut_form & "' and year(matricula.fecha_matricula)= " & cover_año & " "
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader
            If dr.Read() Then

                Form1.Label1.Text = dr("rut_alumno")
                Form1.Label2.Text = dr("nombres")
                Form1.Label3.Text = dr("apellidos")
                Form1.Label4.Text = dr("fecha_nacimiento")
                Form1.Label5.Text = dr("edad_alumno")
                Form1.Label6.Text = dr("Nombre")
                Form1.Label7.Text = dr("fono_urgencia_1")
                Form1.Label8.Text = dr("fono_urgencia_2")
                Form1.Label67.Text = dr("sexo")
                Form1.Label9.Text = dr("rut_apoderado")
                Form1.Label10.Text = dr("nombre_apoderado")
                Form1.Label11.Text = dr("domicilio")
                Form1.Label12.Text = dr("fono")
                Form1.Label13.Text = dr("fecha_matricula")
                Form1.Label14.Text = dr("escuela_procedencia")
                Form1.Label15.Text = dr("cursos_repetidos")
                Form1.Label16.Text = dr("domicilio_alumno")
                Form1.Label17.Text = dr("alergico")
                Form1.Label18.Text = dr("grupo_sanguineo")
                Form1.Label19.Text = dr("enfermedad")
                Form1.Label20.Text = dr("grupo_pie")
                Form1.Label21.Text = dr("nombre_padre")
                Form1.Label22.Text = dr("nombre_madre")
                Form1.Label23.Text = dr("rut_padre")
                Form1.Label24.Text = dr("rut_madre")
                Form1.Label25.Text = dr("trabajo_padre")
                Form1.Label26.Text = dr("trabajo_madre")
                Form1.Label27.Text = dr("escolaridad_padre")
                Form1.Label28.Text = dr("escolaridad_madre")
                Form1.Label29.Text = dr("vive_con")
                Form1.Label30.Text = dr("casa_propia")
                Form1.Label31.Text = dr("ingreso_mensual")
                Form1.Label32.Text = dr("beneficio")
                Form1.Label33.Text = dr("religion")
                Form1.Label34.Text = dr("nombre_usuario")
                Form1.Label69.Text = dr("año_academico")

                conector.Close()
                Form1.Show()
                matricula.Enabled = True
                matricula.Hide()
                Me.Hide()
            End If
            conector.Close()
            conector.Close()
        Catch ex As Exception
            MsgBox("ERROR INTENTE EN OTRO MOMENTO" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "ALERTA")
            conector.Close()
        End Try
        conector.Close()
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

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        conector.Close()
        conector.Close()
        conector.Close()

        matricula.Enabled = True
        matricula.Show()
        Me.Close()
    End Sub
End Class