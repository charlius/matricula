Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Mail

Public Class Form1

    Public FechaNa As Date
    Public FechaMa As Date

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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        SaveFileDialog1.DefaultExt = "pdf"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim DOCUMENTO As New Document
                Dim ESCRITOR As PdfWriter = PdfWriter.GetInstance(DOCUMENTO, New FileStream(SaveFileDialog1.FileName, FileMode.Create))
                DOCUMENTO.Open()
                DOCUMENTO.Add(New Paragraph("Rut Del Alumno: " + Label1.Text + " Nombres del Alumno:  " + Label2.Text))
                DOCUMENTO.Add(New Paragraph("Apellidos Del Alumno " + Label3.Text + " Fecha De Nacimiento Del Alumno " + Label4.Text + " Edad " + Label5.Text + " Curso " + Label6.Text + " Fono Urgencia 1 " + Label7.Text + " Fono Urgencia 2 " + Label8.Text + " Rut Del Apoderado " + Label9.Text + " Nombre Del Apoderado " + Label10.Text + " Domicilio Apoderado " + Label11.Text + " Fono Apoderado " + Label12.Text + " Fecha Matricula " + Label13.Text + " Escuela Procedencia " + Label14.Text + " Cursos Repetidos " + Label15.Text + " Domicilio Alumno " + Label16.Text + " Alergia Alumno " + Label17.Text + " Grupo Sanguineo Alumno " + Label18.Text + " Enfermedad Alumno " + Label19.Text + " Pertenece Grupo PIE " + Label20.Text + " Nombre Del Padre " + Label21.Text + " Nombre Madre " + Label22.Text + " Rut Padre " + Label23.Text + " Rut Madre " + Label24.Text + " Trabajo Padre " + Label25.Text + " Trabajo Madre " + Label26.Text + " Escolaridad Padre " + Label27.Text + " Escolaridad Madre " + Label28.Text + " Alumno Vive Con " + Label29.Text + " Casa Propia " + Label30.Text + " Ingreso Mensual " + Label31.Text + " Beneficios " + Label32.Text + " Religion " + Label33.Text + " Nombre Matriculador " + Label34.Text))

                DOCUMENTO.Close()
                conector.Close()
                MsgBox("CREADO ARCHIVO PDF")
            Catch ex As Exception
                MsgBox(ex.Message)
                conector.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)


    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = Bitmap.FromFile(OpenFileDialog1.FileName)
            conector.Close()
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        conector.Close()

        PictureBox1.Enabled = False
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub

    Private Sub Label52_Click(sender As System.Object, e As System.EventArgs) Handles Label52.Click

    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        SaveFileDialog1.DefaultExt = "pdf"
        SaveFileDialog1.FileName = Label2.Text + " " + Label3.Text + " Curso " + Label6.Text.ToUpper
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim alo As String = "Rut Del Alumno: "
                Dim DOCUMENTO As New Document
                Dim ESCRITOR As PdfWriter = PdfWriter.GetInstance(DOCUMENTO, New FileStream(SaveFileDialog1.FileName, FileMode.Create))
                DOCUMENTO.Open()

                Dim im As Image = Image.GetInstance("C:\WindowsApplication7\WindowsApplication7\Resourses\ficha.jpg")

                DOCUMENTO.Add(im)


                DOCUMENTO.Add(New Paragraph("Rut Del Alumno: " + Label1.Text + "         Nombres del Alumno: " + Label2.Text))
                DOCUMENTO.Add(New Paragraph("Apellidos Del Alumno: " + Label3.Text + "          Fecha De Nacimiento Del Alumno: " + Label4.Text))
                DOCUMENTO.Add(New Paragraph("Edad al 30 de Marzo: " + Label5.Text + "      Curso: " + Label6.Text + "        Fono Urgencia 1: " + Label7.Text + "      Fono Urgencia 2: " + Label8.Text))
                DOCUMENTO.Add(New Paragraph("Sexo: " + Label67.Text))
                DOCUMENTO.Add(New Paragraph(vbCr))
                DOCUMENTO.Add(New Paragraph("Rut Del Apoderado: " + Label9.Text + "         Nombre Del Apoderado: " + Label10.Text))
                DOCUMENTO.Add(New Paragraph("Domicilio Apoderado: " + Label11.Text + "        Fono Apoderado: " + Label12.Text))
                DOCUMENTO.Add(New Paragraph(vbCr))
                DOCUMENTO.Add(New Paragraph("Escuela Procedencia: " + Label14.Text + "          Cursos Repetidos: " + Label15.Text))
                DOCUMENTO.Add(New Paragraph("Domicilio Alumno: " + Label16.Text + "           Alergia Alumno: " + Label17.Text + "        Grupo Sanguineo Alumno " + Label18.Text))
                DOCUMENTO.Add(New Paragraph("Enfermedad Alumno: " + Label19.Text + "           Pertenece Grupo PIE: " + Label20.Text))
                DOCUMENTO.Add(New Paragraph(vbCr))
                DOCUMENTO.Add(New Paragraph("Nombre Del Padre: " + Label21.Text + "        Nombre Madre: " + Label22.Text))
                DOCUMENTO.Add(New Paragraph("Rut Padre: " + Label23.Text + "           Rut Madre: " + Label24.Text))
                DOCUMENTO.Add(New Paragraph("Trabajo Padre: " + Label25.Text + "          Trabajo Madre: " + Label26.Text))
                DOCUMENTO.Add(New Paragraph("Escolaridad Padre: " + Label27.Text + "          Escolaridad Madre: " + Label28.Text + "    Alumno Vive Con: " + Label29.Text))
                DOCUMENTO.Add(New Paragraph("Casa Propia: " + Label30.Text + "          Ingreso Mensual: " + Label31.Text + "      Beneficios: " + Label32.Text))
                DOCUMENTO.Add(New Paragraph("Religion: " + Label33.Text + "           Nombre Matriculador: " + Label34.Text + "       Fecha Matricula: " + Label13.Text))
                DOCUMENTO.Add(New Paragraph(vbCr))
                DOCUMENTO.Add(New Paragraph("NOTA: El apoderado firmante se compromete a respetar y hacer cumplir a su pupilo las normas del reglamento interno y de evaluación del colegio, además de reforzar en su pupilo la asistencia, puntualidad, buena presentación personal y modales de acuerdo a su calidad de alumno. "))
                DOCUMENTO.Add(New Paragraph("El apoderado también deberá cumplir su rol como integrante del Centro General de Padres, asistiendo a reuniones y cada vez que el profesor jefe o de asignatura, inspectoría o unidad pedagógica lo cite "))
                DOCUMENTO.Add(New Paragraph(vbCr))
                DOCUMENTO.Add(New Paragraph("              ""EL TRABAJO EN CONJUNTO, GENERA MEJORES LOGROS """))
                DOCUMENTO.Add(New Paragraph(vbCr))
                DOCUMENTO.Add(New Paragraph("FIRMA APODERADO      _______________________________"))




                DOCUMENTO.Close()
                MsgBox("PDF GUARDADO EXITOSAMENTE", MsgBoxStyle.Information, "Operacion Exitosa")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button66_Click(sender As System.Object, e As System.EventArgs) Handles Button66.Click

        conector.Close()

        matricula.Show()
        matricula.TabControl1.SelectedIndex = 0
        Me.Hide()

        Label1.Text = "XXXX"
        Label2.Text = "XXXX"
        Label3.Text = "XXXX"
        Label4.Text = "XXXX"
        Label5.Text = "XXXX"
        Label6.Text = "XXXX"
        Label7.Text = "XXXX"
        Label8.Text = "XXXX"
        Label9.Text = "XXXX"
        Label10.Text = "XXXX"
        Label11.Text = "XXXX"
        Label12.Text = "XXXX"
        Label13.Text = "XXXX"
        Label14.Text = "XXXX"
        Label5.Text = "XXXX"
        Label6.Text = "XXXX"
        Label7.Text = "XXXX"
        Label8.Text = "XXXX"
        Label9.Text = "XXXX"
        Label20.Text = "XXXX"
        Label21.Text = "XXXX"
        Label22.Text = "XXXX"
        Label23.Text = "XXXX"
        Label24.Text = "XXXX"
        Label25.Text = "XXXX"
        Label26.Text = "XXXX"
        Label27.Text = "XXXX"
        Label28.Text = "XXXX"
        Label29.Text = "XXXX"
        Label30.Text = "XXXX"
        Label31.Text = "XXXX"
        Label32.Text = "XXXX"
        Label33.Text = "XXXX"
        Label34.Text = "XXXX"
        Label67.Text = "XXXX"

        PictureBox1.Enabled = False

        matricula.matriculas_activas()
        matricula.matriculas_total()
        matricula.primero_activas()
        matricula.segundo_activas()
        matricula.tercero_activas()
        matricula.cuarto_activas()
        matricula.quinto_activas()
        matricula.sexto_activas()
        matricula.septimo_activas()
        matricula.octavo_activas()
        matricula.kinder_activas()
        matricula.prekinder_activas()


       
       
    End Sub

    Private Sub Button64_Click(sender As System.Object, e As System.EventArgs) Handles Button64.Click

        Try
            conector.Close()

            matricula.Show()
            matricula.TabControl1.SelectedIndex = 1
            Me.Hide()

            Label1.Text = "XXXX"
            Label2.Text = "XXXX"
            Label3.Text = "XXXX"
            Label4.Text = "XXXX"
            Label5.Text = "XXXX"
            Label6.Text = "XXXX"
            Label7.Text = "XXXX"
            Label8.Text = "XXXX"
            Label9.Text = "XXXX"
            Label10.Text = "XXXX"
            Label11.Text = "XXXX"
            Label12.Text = "XXXX"
            Label13.Text = "XXXX"
            Label14.Text = "XXXX"
            Label5.Text = "XXXX"
            Label6.Text = "XXXX"
            Label7.Text = "XXXX"
            Label8.Text = "XXXX"
            Label9.Text = "XXXX"
            Label20.Text = "XXXX"
            Label21.Text = "XXXX"
            Label22.Text = "XXXX"
            Label23.Text = "XXXX"
            Label24.Text = "XXXX"
            Label25.Text = "XXXX"
            Label26.Text = "XXXX"
            Label27.Text = "XXXX"
            Label28.Text = "XXXX"
            Label29.Text = "XXXX"
            Label30.Text = "XXXX"
            Label31.Text = "XXXX"
            Label32.Text = "XXXX"
            Label33.Text = "XXXX"
            Label34.Text = "XXXX"
            Label67.Text = "XXXX"

            PictureBox1.Enabled = False



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
            matricula.ComboBox6.Enabled = True

            matricula.CheckBox1.Enabled = True
            matricula.CheckBox2.Enabled = True
            matricula.CheckBox3.Enabled = True
            matricula.CheckBox4.Enabled = True
            matricula.CheckBox5.Enabled = True
            matricula.CheckBox6.Enabled = True
            matricula.CheckBox7.Enabled = True
            matricula.CheckBox8.Enabled = True

            matricula.CheckBox1.CheckState = False
            matricula.CheckBox2.CheckState = False
            matricula.CheckBox3.CheckState = False
            matricula.CheckBox4.CheckState = False
            matricula.CheckBox5.CheckState = False
            matricula.CheckBox6.CheckState = False
            matricula.CheckBox7.CheckState = False
            matricula.CheckBox8.CheckState = False

            matricula.TextBox1.Text = ("")
            matricula.TextBox2.Text = ("")
            matricula.TextBox3.Text = ("")
            matricula.TextBox4.Text = ("")
            matricula.TextBox5.Text = ("")
            matricula.TextBox6.Text = ("")
            matricula.TextBox7.Text = ("")
            matricula.TextBox8.Text = ("")
            matricula.TextBox9.Text = ("")
            matricula.TextBox10.Text = ("")
            matricula.TextBox11.Text = ("")
            matricula.TextBox12.Text = ("")
            matricula.TextBox13.Text = ("")
            matricula.TextBox14.Text = ("")
            matricula.TextBox15.Text = ("")
            matricula.TextBox16.Text = ("")
            matricula.TextBox17.Text = ("")
            matricula.TextBox18.Text = ("")
            matricula.TextBox19.Text = ("")
            matricula.TextBox20.Text = ("")
            matricula.TextBox21.Text = ("")
            matricula.TextBox22.Text = ("")
            matricula.TextBox23.Text = ("")
            matricula.TextBox24.Text = ("")
            matricula.TextBox25.Text = ("")
            matricula.TextBox26.Text = ("")
            matricula.TextBox27.Text = ("")
            matricula.TextBox28.Text = ("")
            matricula.TextBox29.Text = ("")
            matricula.TextBox30.Text = ("")
            matricula.TextBox37.Text = ("")

            matricula.ComboBox1.Text = ("")
            matricula.ComboBox2.Text = ("")
            matricula.ComboBox3.Text = ("")
            matricula.ComboBox4.Text = ("")

            matricula.ComboBox6.Text = ("")

            matricula.calen.Enabled = True
            matricula.calendarn.Enabled = True


            matricula.Button16.Visible = True
            matricula.Button15.Visible = False
            matricula.Button14.Visible = False
            matricula.Button4.Visible = False
            matricula.Button8.Visible = False
            matricula.Button5.Visible = True
            matricula.Button9.Visible = True


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub check_campos()
        If matricula.TextBox22.Text = "NO ES ALERGICO" Then
            matricula.CheckBox3.Checked = True
        Else
            matricula.TextBox22.Enabled = False
            matricula.CheckBox3.Checked = False
            matricula.CheckBox4.Checked = True
        End If
        If matricula.TextBox23.Text = "NO HA REPETIDO" Then
            matricula.CheckBox2.Checked = True
        Else
            matricula.TextBox23.Enabled = False
            matricula.CheckBox2.Checked = False
            matricula.CheckBox1.Checked = True
        End If
        If matricula.TextBox19.Text = "NO TIENE BENEFICIO" Then
            matricula.CheckBox5.Checked = True
        Else
            matricula.TextBox19.Enabled = False
            matricula.CheckBox5.Checked = False
            matricula.CheckBox6.Checked = True
        End If
        If matricula.TextBox37.Text = "NO SABE" Then
            matricula.CheckBox7.Checked = True
        Else
            matricula.TextBox37.Enabled = False
            matricula.CheckBox7.Checked = False
            matricula.CheckBox8.Checked = True
        End If
    End Sub
    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
      

        Try
            conector.Close()

            Dim qry As String = "select alumno.rut_alumno ,alumno.nombres,alumno.apellidos,alumno.fecha_nacimiento, matricula.edad_alumno,curso.Nombre ,matricula.fono_urgencia_1 ,matricula.fono_urgencia_2,alumno.sexo,apoderado.rut_apoderado , apoderado.nombre_apoderado ,apoderado.domicilio , apoderado.fono  ,matricula.fecha_matricula ,matricula.escuela_procedencia ,matricula.cursos_repetidos ,matricula.domicilio_alumno ,matricula.alergico , matricula.grupo_sanguineo ,matricula.enfermedad ,matricula.grupo_pie ,matricula.nombre_padre ,matricula.nombre_madre ,matricula.rut_padre ,matricula.rut_madre ,matricula.trabajo_padre ,matricula.trabajo_madre ,matricula.escolaridad_padre ,matricula.escolaridad_madre ,matricula.vive_con ,matricula.casa_propia ,matricula.ingreso_mensual ,matricula.beneficio ,matricula.religion , usuario.nombre_usuario from alumno, apoderado, curso, matricula, usuario where matricula.rut_alumno = alumno.rut_alumno And apoderado.rut_apoderado = matricula.rut_apoderado And matricula.curso_alumno = curso.id_curso And matricula.id_usuario = usuario.id_usuario And matricula.rut_alumno ='" & Label1.Text & "'"
            conector.Open()
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader

            If dr.Read() Then

                matricula.TextBox4.Text = dr("rut_alumno")
                matricula.TextBox28.Text = dr("rut_alumno")
                matricula.TextBox3.Text = dr("nombres")
                matricula.TextBox2.Text = dr("apellidos")
                FechaNa = dr("fecha_nacimiento")
                matricula.calendarn.SetDate(FechaNa)
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
                FechaMa = dr("fecha_matricula")
                matricula.calen.SetDate(FechaMa)
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

                PictureBox1.Enabled = False

                matricula.TextBox1.Enabled = False
                matricula.TextBox2.Enabled = False
                matricula.TextBox3.Enabled = False
                matricula.TextBox4.Enabled = False
                matricula.TextBox5.Enabled = False
                matricula.TextBox6.Enabled = False
                matricula.TextBox7.Enabled = False
                matricula.TextBox8.Enabled = False
                matricula.TextBox9.Enabled = False
                matricula.TextBox10.Enabled = False
                matricula.TextBox11.Enabled = False
                matricula.TextBox12.Enabled = False
                matricula.TextBox13.Enabled = False
                matricula.TextBox14.Enabled = False
                matricula.TextBox15.Enabled = False
                matricula.TextBox16.Enabled = False
                matricula.TextBox17.Enabled = False
                matricula.TextBox18.Enabled = False
                matricula.TextBox19.Enabled = False
                matricula.TextBox20.Enabled = False
                matricula.TextBox21.Enabled = False
                matricula.TextBox22.Enabled = False
                matricula.TextBox23.Enabled = False
                matricula.TextBox24.Enabled = False
                matricula.TextBox25.Enabled = False
                matricula.TextBox26.Enabled = False
                matricula.TextBox27.Enabled = False
                matricula.TextBox28.Enabled = False
                matricula.TextBox29.Enabled = False
                matricula.TextBox30.Enabled = False
                matricula.TextBox37.Enabled = False

                matricula.ComboBox1.Enabled = False
                matricula.ComboBox2.Enabled = False
                matricula.ComboBox3.Enabled = False
                matricula.ComboBox4.Enabled = False

                matricula.ComboBox6.Enabled = False

                matricula.CheckBox1.Enabled = False
                matricula.CheckBox2.Enabled = False
                matricula.CheckBox3.Enabled = False
                matricula.CheckBox4.Enabled = False
                matricula.CheckBox5.Enabled = False
                matricula.CheckBox6.Enabled = False
                matricula.CheckBox7.Enabled = False
                matricula.CheckBox8.Enabled = False

                check_campos()

                matricula.calendarn.Enabled = False
                matricula.calen.Enabled = False
                matricula.Show()
                matricula.TabControl1.SelectedIndex = 3
                Me.Hide()
                conector.Close()
            End If

        Catch ex As Exception
            MsgBox("ERROR" & vbCrLf & ex.Message)
            conector.Close()
        End Try

      
    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs)
        conector.Close()
        Try
            conector.Open()
            Dim qry As String = "select alumno.rut_alumno ,alumno.nombres,alumno.apellidos,alumno.fecha_nacimiento, alumno.edad,curso.Nombre ,alumno.fono_urgencia ,alumno.fono_urgencia_otro,alumno.sexo,apoderado.rut_apoderado , apoderado.nombre_apoderado ,apoderado.domicilio , apoderado.fono  ,matricula.fecha_matricula ,matricula.escuela_procedencia ,matricula.cursos_repetidos ,matricula.domicilio_alumno ,matricula.alergico , matricula.grupo_sanguineo ,matricula.enfermedad ,matricula.grupo_pie ,matricula.nombre_padre ,matricula.nombre_madre ,matricula.rut_padre ,matricula.rut_madre ,matricula.trabajo_padre ,matricula.trabajo_madre ,matricula.escolaridad_padre ,matricula.escolaridad_madre ,matricula.vive_con ,matricula.casa_propia ,matricula.ingreso_mensual ,matricula.beneficio ,matricula.religion , usuario.nombre_usuario from alumno, apoderado, curso, matricula, usuario where matricula.rut_alumno = alumno.rut_alumno And apoderado.rut_apoderado = matricula.rut_apoderado And alumno.curso = curso.id_curso And matricula.id_usuario = usuario.id_usuario And matricula.rut_alumno =  '" & matricula.rut_pdf_alumno & "' "
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader


            If dr.Read() Then

                Label1.Text = dr("rut_alumno")
                Label2.Text = dr("nombres")
                Label3.Text = dr("apellidos")
                Label4.Text = dr("fecha_nacimiento")
                Label5.Text = dr("edad")
                Label6.Text = dr("Nombre")
                Label7.Text = dr("fono_urgencia")
                Label8.Text = dr("fono_urgencia_otro")
                Label67.Text = dr("sexo")
                Label9.Text = dr("rut_apoderado")
                Label10.Text = dr("nombre_apoderado")
                Label11.Text = dr("domicilio")
                Label12.Text = dr("fono")
                Label13.Text = dr("fecha_matricula")
                Label14.Text = dr("escuela_procedencia")
                Label15.Text = dr("cursos_repetidos")
                Label16.Text = dr("domicilio_alumno")
                Label17.Text = dr("alergico")
                Label18.Text = dr("grupo_sanguineo")
                Label19.Text = dr("enfermedad")
                Label20.Text = dr("grupo_pie")
                Label21.Text = dr("nombre_padre")
                Label22.Text = dr("nombre_madre")
                Label23.Text = dr("rut_padre")
                Label24.Text = dr("rut_madre")
                Label25.Text = dr("trabajo_padre")
                Label26.Text = dr("trabajo_madre")
                Label27.Text = dr("escolaridad_padre")
                Label28.Text = dr("escolaridad_madre")
                Label29.Text = dr("vive_con")
                Label30.Text = dr("casa_propia")
                Label31.Text = dr("ingreso_mensual")
                Label32.Text = dr("beneficio")
                Label33.Text = dr("religion")
                Label34.Text = dr("nombre_usuario")


                conector.Close()

            End If

        Catch ex As Exception
            conector.Close()
            MsgBox("error" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub PictureBox2_Click_1(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        conector.Close()
        conector.Close()
        conector.Close()
        If MsgBox("¿ Seguro que desea salir ?", vbQuestion + vbYesNo, "Pregunta") = vbYes Then
            End
            Me.Close()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
        conector.Close()
        conector.Close()
    End Sub
End Class
