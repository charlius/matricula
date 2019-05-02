﻿Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Mail
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf



Imports System.IO
Imports System.Net



Public Class matricula

    
    Public rut_alumno_para_matricular As String
    Public rut_apoderado_para_matricular As String


    Public rut_completo_buscar As String
    Public rut_completo_apoderado As String
    Public rut_pdf_alumno As String
    Public seleccion_año As String
    Public ingreso_rut_buscador As String
    Public int_año As Integer


    Public fechadenaci As Date
    Public fechadematri As Date

    Dim año_para_bajar As Date
    Dim codigo_de_curso As Integer

    Dim fecha As String
    Dim fecha_ma As String
    Dim cos As Integer
    Dim q1 As Integer
    Dim san As String
    Dim pie As String
    Dim casa As String
    Dim re As String
    Dim rutAlumno As String
    Dim usu As Integer
    Dim cursogu As Integer
    Dim cursomo As Integer
    Dim sex As String




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
    Dim dt As DataTable




    

    'ARRASTRAR FORMULARIO
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub


    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub test_login_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub



    Private Sub matricula_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        Label39.Text = DateTime.Now.ToLongDateString()
        TextBox23.Enabled = False
        mostraralumnocursoprimero()
        mostraralumnocursosegundo()
        mostraralumnocursotercero()
        mostraralumnocursocuarto()
        mostraralumnocursoquinto()
        mostraralumnocursosexto()
        mostraralumnocursoseptimo()
        mostraralumnocursooctavo()
        mostraralumnocursokinder()
        mostraralumnocursoprekinder()
        matriculas_activas()
        matriculas_total()
        'SeleccionarAñoCurso.primero_activas()
        'SeleccionarAñoCurso.segundo_activas()
        'SeleccionarAñoCurso.tercero_activas()
        ' SeleccionarAñoCurso.cuarto_activas()
        ' SeleccionarAñoCurso.quinto_activas()
        ' SeleccionarAñoCurso.sexto_activas()
        ' SeleccionarAñoCurso.septimo_activas()
        ' SeleccionarAñoCurso.octavo_activas()
        ' SeleccionarAñoCurso.kinder_activas()
        ' SeleccionarAñoCurso.prekinder_activas()


       
        strcon = "Provider=SQLOLEDB.1;Password=" & claveBD & ";Persist Security Info=True;User ID=" & usuarioBD & ";Initial Catalog=" & basededatos & ";Data Source=" & servidor & ""

        conector.Close()
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

    End Sub
  
    Sub matriculas_activas()
        Dim fecha_hoy = CDate(Today.Date.Year & "-" & Today.Date.Month & "-" & Today.Day)
        Dim fecha_de_ayer = CDate(Today.Date.Year - 1 & "-" & 12 & "-" & 1)

        conector.Close()
        Dim año_actual = Year(Now)
        Try
            conector.Close()
            conector.Open()
            Dim qryc As String = "SELECT count(matricula.rut_alumno) FROM matricula,alumno where matricula.rut_alumno= alumno.rut_alumno and matricula.estado='activo' and matricula.fecha_matricula BETWEEN '" & fecha_de_ayer & "' AND '" & fecha_hoy & "'"
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar




            Label46.Text = drc.ToString


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub
    Sub matriculas_total()
        conector.Close()
        Try
            conector.Close()
            conector.Open()
            Dim qryc As String = "SELECT count(matricula.rut_alumno) FROM matricula,alumno where matricula.rut_alumno= alumno.rut_alumno "
            Dim sqlcmdc As New SqlCommand(qryc, conector)
            Dim drc As Integer
            drc = sqlcmdc.ExecuteScalar


            conector.Close()
            conector.Close()

        Catch ex As Exception
            conector.Close()
            MsgBox("error fun" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
      
        conector.Close()
    End Sub

    Private Sub Button1_Click_2(sender As System.Object, e As System.EventArgs)
        TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
        conector.Close()
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        'TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
        TextBox26.Text = inicio1.nomUsuario
       
        Seleccion_Tipo_Matricula.Show()
        Me.Enabled = False

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click

        If (calendarn.SelectionRange.Start.Year >= Year(Now) Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Verifique campos en blanco O Fecha de Nacimiento invalida", MsgBoxStyle.Critical, "Atencion")
            TextBox1.Select()
            conector.Close()
        Else

            funcion_buscar_alumno_matricular()
            TextBox26.Text = inicio1.nomUsuario
            TabControl1.SelectedTab = TabControl1.TabPages.Item(2)
            TextBox28.Text = TextBox4.Text
            conector.Close()

        End If



    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If (TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "") Then
            MsgBox("No deje campos en blanco", MsgBoxStyle.Critical, "Atencion")
            TextBox1.Select()
            conector.Close()
        Else

            funncion_buscar_apoderado_matricular()
            TextBox26.Text = inicio1.nomUsuario
            TextBox27.Text = TextBox9.Text
            TabControl1.SelectedTab = TabControl1.TabPages.Item(3)

            TextBox23.Enabled = False
            TextBox19.Enabled = False
            TextBox22.Enabled = False

            TextBox26.Enabled = False
            TextBox27.Enabled = False
            TextBox28.Enabled = False
            conector.Close()

        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        conector.Close()


    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        TabControl1.SelectedTab = TabControl1.TabPages.Item(2)
        conector.Close()

        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
        conector.Close()
       

    End Sub

    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(0)
        conector.Close()
        matriculas_activas()
        matriculas_total()

    End Sub
    Sub funcion_buscar_alumno_matricular()
        conector.Close()
        Try
            conector.Open()
            Dim qry As String = "select alumno.rut_alumno,alumno.nombres,alumno.apellidos,alumno.fecha_nacimiento,alumno.sexo from alumno where alumno.rut_alumno='" & TextBox4.Text & "'"
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader
            If dr.Read() Then
                rut_alumno_para_matricular = dr("rut_alumno")

            Else
                rut_alumno_para_matricular = "x"
            End If
        Catch ex As Exception
            MsgBox("error" & vbCrLf & ex.Message)

        End Try

    End Sub

    Sub funncion_buscar_apoderado_matricular()
        conector.Close()
        Try
            conector.Open()
            Dim qry As String = "select * from apoderado where apoderado.rut_apoderado = '" & TextBox9.Text & "'"
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader
            If dr.Read() Then
                rut_apoderado_para_matricular = dr("rut_apoderado")
            Else
                rut_apoderado_para_matricular = "x"
            End If
        Catch ex As Exception
            MsgBox("error" & vbCrLf & ex.Message)

        End Try
    End Sub

    Sub funcion_insert_alumno()
        conector.Close()
        conector.Close()
        sex = ComboBox6.Text


        id_curso()

        rut_completo_buscar = TextBox4.Text
        fecha = calendarn.SelectionRange.End
        TextBox28.Text = TextBox4.Text
        conector.Close()

        Try
            conector.Close()

            Dim cadena As String
            cadena = String.Format("INSERT INTO alumno VALUES ('" & rut_completo_buscar & "', '" & TextBox3.Text & "', '" & TextBox2.Text & "','" & fecha & "','" & sex & "')")

            Dim insertar As New SqlCommand(cadena, conector)
            conector.Open()
            insertar.ExecuteNonQuery()

            conector.Close()
            MsgBox("Datos Ingresados Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")


            

            TextBox28.Text = rut_completo_buscar
            conector.Close()

        Catch ex As Exception
            MsgBox("error" & vbCrLf & ex.Message)
            conector.Close()
        End Try

    End Sub

    Sub funcion_update_alumno()
        conector.Close()
        id_curso()
        fecha = calendarn.SelectionRange.End
        rut_completo_buscar = TextBox4.Text
        conector.Close()
        Try

            Dim cadena As String
            cadena = String.Format("UPDATE alumno SET nombres = '" & TextBox3.Text & "' , apellidos ='" & TextBox2.Text & "', fecha_nacimiento = '" & fecha & "' , sexo = '" & ComboBox6.SelectedItem & "' WHERE alumno.rut_alumno = '" & rut_completo_buscar & "'")
            Dim insertar As New SqlCommand(cadena, conector)
            conector.Open()
            insertar.ExecuteNonQuery()
            conector.Close()
            MsgBox("Registro Actualizado Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")
           


           

            TextBox28.Text = rut_completo_buscar
            conector.Close()

        Catch ex As Exception
            MsgBox("ERROR INTENTE DE NUEVO", MsgBoxStyle.Critical, "Alerta" & vbCrLf & ex.Message)
            conector.Close()
            conector.Close()
        End Try
        conector.Close()

    End Sub


    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        conector.Close()
        conector.Close()
        sex = ComboBox6.Text


        id_curso()

        rut_completo_buscar = TextBox4.Text
        fecha = calendarn.SelectionRange.End
        TextBox28.Text = TextBox4.Text
        conector.Close()



        If (calendarn.SelectionRange.Start.Year >= Year(Now) Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Verifique campos en blanco O Fecha de Nacimiento invalida", MsgBoxStyle.Critical, "Atencion")
            TextBox1.Select()
            conector.Close()


        Else
            conector.Close()
            conector.Open()
            Dim qry As String = "select alumno.rut_alumno,alumno.nombres,alumno.apellidos,alumno.fecha_nacimiento,alumno.sexo from alumno where alumno.rut_alumno='" & TextBox4.Text & "'"
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader
            If dr.Read() Then

                TextBox3.Text = dr("nombres")
                TextBox2.Text = dr("apellidos")
                fechadenaci = dr("fecha_nacimiento")
                calendarn.SetDate(fechadenaci)
                ComboBox6.Text = dr("sexo")
                conector.Close()
                conector.Close()
                MsgBox("El Alumno Ya Fue Ingresado", MsgBoxStyle.Information, "Operacion Exitosa")
                TextBox28.Text = rut_completo_buscar






                conector.Close()

            Else
                Try
                    conector.Close()

                    Dim cadena As String
                    cadena = String.Format("INSERT INTO alumno VALUES ('" & rut_completo_buscar & "', '" & TextBox3.Text & "', '" & TextBox2.Text & "','" & fecha & "','" & sex & "')")

                    Dim insertar As New SqlCommand(cadena, conector)
                    conector.Open()
                    insertar.ExecuteNonQuery()

                    conector.Close()
                    MsgBox("Datos Ingresados Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")





                    TextBox28.Text = rut_completo_buscar
                    conector.Close()

                Catch ex As Exception
                    MsgBox("error" & vbCrLf & ex.Message)
                    conector.Close()
                End Try
            End If
        End If


    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click
        conector.Close()
    End Sub

    Sub funcion_insert_apoderado()
        conector.Close()
        rut_completo_apoderado = TextBox9.Text
        Try
            conector.Close()

            Dim cadena As String
            cadena = String.Format("INSERT INTO apoderado VALUES ('" & rut_completo_apoderado & "', '" & TextBox8.Text & "', '" & TextBox7.Text & "','" & TextBox6.Text & "')")

            Dim insertar As New SqlCommand(cadena, conector)
            conector.Open()
            insertar.ExecuteNonQuery()

            conector.Close()
            MsgBox("Datos Ingresados Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")

            TextBox27.Text = rut_completo_apoderado

           


            conector.Close()



        Catch ex As Exception
            conector.Close()
            conector.Close()
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        conector.Close()

        rut_completo_apoderado = TextBox9.Text

        If (TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "") Then
            MsgBox("No deje campos en blanco", MsgBoxStyle.Critical, "Atencion")
            TextBox1.Select()
            conector.Close()
        Else
            conector.Close()
            conector.Open()
            Dim qry As String = "select * from apoderado where rut_apoderado = '" & rut_completo_apoderado & "'"
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader
            If dr.Read() Then
                TextBox8.Text = dr("nombre_apoderado")
                TextBox7.Text = dr("domicilio")
                TextBox6.Text = dr("fono")
                conector.Close()

                MsgBox("Apoderado ya Registrado", MsgBoxStyle.Information, "Operacion Exitosa")

                TextBox27.Text = rut_completo_apoderado


                conector.Close()

            Else
                Try
                    conector.Close()

                    Dim cadena As String
                    cadena = String.Format("INSERT INTO apoderado VALUES ('" & rut_completo_apoderado & "', '" & TextBox8.Text & "', '" & TextBox7.Text & "','" & TextBox6.Text & "')")

                    Dim insertar As New SqlCommand(cadena, conector)
                    conector.Open()
                    insertar.ExecuteNonQuery()

                    conector.Close()
                    MsgBox("Datos Ingresados Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")

                    TextBox27.Text = rut_completo_apoderado



                    conector.Close()



                Catch ex As Exception
                    conector.Close()
                    conector.Close()
                End Try
            End If
        End If



    End Sub
    Sub check_no()
        If CheckBox3.Checked = True Then
            TextBox22.Text = "No es Alergico"
        End If
        If CheckBox2.Checked = True Then
            TextBox23.Text = "No ha repetido"
        End If
        If CheckBox5.Checked = True Then
            TextBox19.Text = "No tiene Beneficio"
        End If
        If CheckBox7.Checked = True Then
            TextBox37.Text = "No Sabe"
        End If
    End Sub
    Sub select_usuario()
        conector.Close()
        Try

            conector.Close()
            conector.Open()
            Dim qry As String = "select usuario.id_usuario from usuario where usuario.nombre_usuario = '" & TextBox26.Text & "'"
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader
            If dr.Read() Then

                usu = dr("id_usuario")
                conector.Close()
                conector.Close()

            End If
        Catch ex As Exception
            MsgBox("error" & vbCrLf & ex.Message)

        End Try
        conector.Close()
    End Sub

    Sub insert_matricula()
        conector.Close()
        id_curso()
        conector.Close()
        fecha_ma = calen.SelectionRange.End

        pie = ComboBox2.Text
        casa = ComboBox3.Text
        re = ComboBox4.Text
        rutAlumno = TextBox4.Text

        Dim rut_completo_madre As String
        Dim rut_completo_padre As String

        rut_completo_madre = TextBox12.Text
        rut_completo_padre = TextBox11.Text
        conector.Close()


        Try
            conector.Close()
            Dim cadena As String
            cadena = String.Format("INSERT INTO matricula (rut_alumno,rut_apoderado,id_usuario,fecha_matricula,escuela_procedencia,cursos_repetidos,domicilio_alumno,alergico,grupo_sanguineo,enfermedad,grupo_pie,nombre_padre,nombre_madre,rut_padre,rut_madre,trabajo_padre,trabajo_madre,escolaridad_padre,escolaridad_madre,vive_con,casa_propia,ingreso_mensual,beneficio,religion,curso_alumno,fono_urgencia_1,fono_urgencia_2,edad_alumno,estado) VALUES ('" & TextBox28.Text & "', '" & TextBox27.Text & "', " & usu & ",'" & fecha_ma & "','" & TextBox25.Text & "','" & TextBox23.Text & "', '" & TextBox24.Text & "', '" & TextBox22.Text & "', '" & TextBox37.Text & "', '" & TextBox21.Text & "', '" & pie & "', '" & TextBox20.Text & "', '" & TextBox10.Text & "', '" & rut_completo_padre & "', '" & rut_completo_madre & "', '" & TextBox13.Text & "', '" & TextBox14.Text & "', '" & TextBox15.Text & "', '" & TextBox16.Text & "', '" & TextBox17.Text & "', '" & casa & "', " & TextBox18.Text & ", '" & TextBox19.Text & "', '" & re & "'," & codigo_de_curso & " ," & TextBox5.Text & "," & TextBox29.Text & ",'" & TextBox1.Text & "','activo')")

            Dim insertar As New SqlCommand(cadena, conector)

            conector.Open()
            insertar.ExecuteNonQuery()
            conector.Close()
            MsgBox("Matricula Ingresada Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")
            rut_completo_buscar = TextBox28.Text

            

            TextBox1.Enabled = False
            TextBox18.Enabled = False
            TextBox19.Enabled = False
            TextBox5.Enabled = False
            TextBox29.Enabled = False
            TextBox20.Enabled = False
            TextBox21.Enabled = False
            TextBox22.Enabled = False
            TextBox23.Enabled = False
            TextBox24.Enabled = False
            TextBox25.Enabled = False
            TextBox26.Enabled = False
            TextBox27.Enabled = False
            TextBox28.Enabled = False
            TextBox10.Enabled = False
            TextBox11.Enabled = False
            TextBox12.Enabled = False
            TextBox13.Enabled = False
            TextBox14.Enabled = False
            TextBox15.Enabled = False
            TextBox16.Enabled = False
            TextBox17.Enabled = False
            TextBox37.Enabled = False

            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            ComboBox4.Enabled = False

            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
            CheckBox5.Enabled = False
            CheckBox6.Enabled = False
            CheckBox7.Enabled = False
            CheckBox8.Enabled = False

            calen.Enabled = False

            'TODO: esta línea de código carga datos en la tabla 'DataSet1.proc_matriculas' Puede moverla o quitarla según sea necesario.


            conector.Close()

            conector.Close()
        Catch ex As Exception
            MsgBox("error" & vbCrLf & ex.Message)


            conector.Close()
            conector.Close()
        End Try
        conector.Close()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        conector.Close()
        select_usuario()
        conector.Close()
        funcion_buscar_alumno_matricular()
        funncion_buscar_apoderado_matricular()
        conector.Close()

        If rut_alumno_para_matricular = "x" And rut_apoderado_para_matricular = "x" Then
            check_no()
            funcion_insert_alumno()
            conector.Close()
            funcion_insert_apoderado()
            conector.Close()
            insert_matricula()
            conector.Close()
        End If
        If rut_alumno_para_matricular <> "x" And rut_apoderado_para_matricular <> "x" Then
            check_no()
            insert_matricula()
            conector.Close()
        End If
        If rut_apoderado_para_matricular = "x" And rut_alumno_para_matricular <> "x" Then
            funcion_insert_apoderado()
            insert_matricula()

        End If
    End Sub



    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        conector.Close()
        conector.Close()
        conector.Close()
        If MsgBox("¿ Seguro que desea salir ?", vbQuestion + vbYesNo, "Pregunta") = vbYes Then
            conector.Close()
            conector.Close()
            End

            Me.Close()
        End If
    End Sub



    Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click
        conector.Close()
        conector.Close()

    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
        conector.Close()
        conector.Close()
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(2)
        conector.Close()


    End Sub

    Private Sub Textbox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        e.Handled = ValidaChar(e.KeyChar)
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True



        ComboBox6.Enabled = True

        calendarn.Enabled = True

      

        conector.Close()
    End Sub

    Sub id_curso()
        conector.Close()
        conector.Open()
        Dim qry As String = "select curso.id_curso from curso where curso.Nombre = '" & ComboBox1.SelectedItem & "'"
        Dim sqlcmd As New SqlCommand(qry, conector)
        Dim dr As SqlDataReader
        dr = sqlcmd.ExecuteReader
        If dr.Read() Then
            codigo_de_curso = dr("id_curso")


            conector.Close()
            conector.Close()
            conector.Close()

        End If
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        conector.Close()
        id_curso()
        fecha = calendarn.SelectionRange.End


        rut_completo_buscar = TextBox4.Text

        conector.Close()
        If (calendarn.SelectionRange.Start.Year >= Year(Now) Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("No deje campos en blanco O Fecha Nacimineto Invalida", MsgBoxStyle.Critical, "Atencion")
            TextBox1.Select()
        Else
            Try
                Dim cadena As String
                cadena = String.Format("UPDATE alumno SET nombres = '" & TextBox3.Text & "' , apellidos ='" & TextBox2.Text & "', fecha_nacimiento = '" & fecha & "' , sexo = '" & ComboBox6.SelectedItem & "' WHERE alumno.rut_alumno = '" & rut_completo_buscar & "'")
                Dim insertar As New SqlCommand(cadena, conector)
                conector.Open()
                insertar.ExecuteNonQuery()
                conector.Close()
                MsgBox("Registro Actualizado Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")
                Button14.Visible = True
                Button3.Visible = True
               

                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False


                ComboBox6.Enabled = False
                calendarn.Enabled = False

                TextBox28.Text = rut_completo_buscar
                conector.Close()

            Catch ex As Exception
                MsgBox("ERROR INTENTE DE NUEVO", MsgBoxStyle.Critical, "Alerta" & vbCrLf & ex.Message)
                conector.Close()
                conector.Close()
            End Try
            conector.Close()
        End If
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        TextBox9.Enabled = True

      
        conector.Close()
    End Sub

    Sub funcion_update_apoderado()
        conector.Close()
        rut_completo_apoderado = TextBox9.Text

        Try
            conector.Close()
            Dim cadena As String
            cadena = String.Format("UPDATE apoderado SET nombre_apoderado = '" & TextBox8.Text & "' , domicilio ='" & TextBox7.Text & "', fono = '" & TextBox6.Text & "'  WHERE rut_apoderado = '" & rut_completo_apoderado & "'")
            Dim insertar As New SqlCommand(cadena, conector)
            conector.Open()
            insertar.ExecuteNonQuery()
            conector.Close()
            MsgBox("Registro Actualizado Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")
            TextBox6.Enabled = False
            TextBox7.Enabled = False
            TextBox8.Enabled = False
            TextBox9.Enabled = False


            Button3.Visible = True

            TextBox27.Text = rut_completo_apoderado
        Catch ex As Exception
            conector.Close()
        End Try
        conector.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        conector.Close()
        rut_completo_apoderado = TextBox9.Text
        If (TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "") Then
            MsgBox("No deje campos en blanco", MsgBoxStyle.Critical, "Atencion")
            TextBox1.Select()
        Else
            Try
                conector.Close()
                Dim cadena As String
                cadena = String.Format("UPDATE apoderado SET nombre_apoderado = '" & TextBox8.Text & "' , domicilio ='" & TextBox7.Text & "', fono = '" & TextBox6.Text & "'  WHERE rut_apoderado = '" & rut_completo_apoderado & "'")
                Dim insertar As New SqlCommand(cadena, conector)
                conector.Open()
                insertar.ExecuteNonQuery()
                conector.Close()
                MsgBox("Registro Actualizado Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")
                TextBox6.Enabled = False
                TextBox7.Enabled = False
                TextBox8.Enabled = False
                TextBox9.Enabled = False


                Button3.Visible = True

                TextBox27.Text = rut_completo_apoderado
            Catch ex As Exception
                conector.Close()
            End Try
            conector.Close()
        End If
    End Sub
    Sub update_matricula()
        id_curso()
        fecha_ma = calen.SelectionRange.Start
        conector.Close()
        Try
            check_no()
            conector.Close()
            Dim cadena As String
            cadena = String.Format("UPDATE matricula SET escuela_procedencia ='" & TextBox25.Text & "', cursos_repetidos = '" & TextBox23.Text & "', domicilio_alumno = '" & TextBox24.Text & "', alergico = '" & TextBox22.Text & "', grupo_sanguineo = '" & TextBox37.Text & "', enfermedad ='" & TextBox21.Text & "', grupo_pie ='" & ComboBox2.Text & "', nombre_padre = '" & TextBox20.Text & "', nombre_madre = '" & TextBox10.Text & "', rut_padre = '" & TextBox11.Text & "', rut_madre ='" & TextBox12.Text & "', trabajo_padre = '" & TextBox13.Text & "', trabajo_madre = '" & TextBox14.Text & "', escolaridad_padre = '" & TextBox15.Text & "', escolaridad_madre ='" & TextBox16.Text & "', vive_con = '" & TextBox17.Text & "', casa_propia = '" & ComboBox3.Text & "', ingreso_mensual= " & TextBox18.Text & ", beneficio = '" & TextBox19.Text & "', religion ='" & ComboBox4.Text & "', curso_alumno =" & codigo_de_curso & ", fono_urgencia_1 ='" & TextBox5.Text & "',fono_urgencia_2 ='" & TextBox29.Text & "', edad_alumno = '" & TextBox1.Text & "', estado = 'activo' where matricula.rut_alumno = '" & TextBox28.Text & "' and year(matricula.fecha_matricula)= " & calen.SelectionRange.Start.Year & " ")
            Dim insertar As New SqlCommand(cadena, conector)
            conector.Open()
            insertar.ExecuteNonQuery()
            conector.Close()
            MsgBox("Registro Actualizado Correctamente", MsgBoxStyle.Information, "Operacion Exitosa")

            Button65.Visible = True
            Button9.Visible = False
            Button8.Visible = False

            TextBox5.Enabled = False
            TextBox29.Enabled = False
            TextBox18.Enabled = False
            TextBox19.Enabled = False
            TextBox20.Enabled = False
            TextBox21.Enabled = False
            TextBox22.Enabled = False
            TextBox23.Enabled = False
            TextBox24.Enabled = False
            TextBox25.Enabled = False
            TextBox26.Enabled = False
            TextBox27.Enabled = False
            TextBox28.Enabled = False
            TextBox10.Enabled = False
            TextBox11.Enabled = False
            TextBox12.Enabled = False
            TextBox13.Enabled = False
            TextBox14.Enabled = False
            TextBox15.Enabled = False
            TextBox16.Enabled = False
            TextBox17.Enabled = False
            TextBox37.Enabled = False

            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            ComboBox4.Enabled = False

            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
            CheckBox5.Enabled = False
            CheckBox6.Enabled = False
            CheckBox7.Enabled = False
            CheckBox8.Enabled = False


            calen.Enabled = False

            conector.Close()
        Catch ex As Exception
            MsgBox("ERROR INTENTE DE NUEVO", MsgBoxStyle.Critical, "Alerta" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        funcion_update_alumno()
        funcion_update_apoderado()
        update_matricula()
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        conector.Close()

        campo_no()
        TextBox18.Enabled = True

        TextBox20.Enabled = True
        TextBox21.Enabled = True
        TextBox1.Enabled = True
        TextBox5.Enabled = True
        TextBox29.Enabled = True
        TextBox24.Enabled = True
        TextBox25.Enabled = True
        TextBox26.Enabled = True
        TextBox27.Enabled = True
        TextBox28.Enabled = True
        TextBox10.Enabled = True
        TextBox11.Enabled = True
        TextBox12.Enabled = True
        TextBox13.Enabled = True
        TextBox14.Enabled = True
        TextBox15.Enabled = True
        TextBox16.Enabled = True
        TextBox17.Enabled = True

        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True

        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        CheckBox4.Enabled = True
        CheckBox5.Enabled = True
        CheckBox6.Enabled = True
        CheckBox7.Enabled = True
        CheckBox8.Enabled = True


        calen.Enabled = True

        Button9.Visible = False
        Button8.Visible = True

    End Sub
    Sub campo_no()
        If TextBox22.Text = "NO ES ALERGICO" Then
            TextBox22.Enabled = False
        Else
            TextBox22.Enabled = True
        End If
        If TextBox23.Text = "NO HA REPETIDO" Then
            TextBox23.Enabled = False
        Else
            TextBox23.Enabled = True
        End If
        If TextBox19.Text = "NO TIENE BENEFICIO" Then
            TextBox19.Enabled = False
        Else
            TextBox19.Enabled = True
        End If
        If TextBox37.Text = "NO SABE" Then
            TextBox37.Enabled = False
        Else
            TextBox37.Enabled = True
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        'TabControl1.SelectedTab = TabControl1.TabPages.Item(5)
        'primero_activas()
        'segundo_activas()
        'tercero_activas()
        'cuarto_activas()
        'quinto_activas()
        'sexto_activas()
        'septimo_activas()
        'octavo_activas()
        'kinder_activas()
        'prekinder_activas()

        SeleccionarAñoCurso.MostrarAñoParaCurso()
        SeleccionarAñoCurso.TextBox1.Visible = False
        SeleccionarAñoCurso.Button2.Visible = False
        SeleccionarAñoCurso.ComboBox1.Visible = True
        SeleccionarAñoCurso.Button1.Visible = True
        SeleccionarAñoCurso.Label1.Text = "SELECCIONE AÑO"

        SeleccionarAñoCurso.Show()
        Me.Enabled = False


    End Sub
    Sub mostraralumnocursosegundo()
        conector.Close()
        int_año = (seleccion_año)
        Dim da As New SqlDataAdapter("select alumno.rut_alumno'Rut del Alumno', alumno.nombres'Nombre',alumno.apellidos'Apellidos',alumno.fecha_nacimiento'Fecha Nacimiento',matricula.edad_alumno'Edad',matricula.fono_urgencia_1'Fono Urgencia 1',matricula.fono_urgencia_2'Fono Ugencia 2' from alumno,matricula where matricula.curso_alumno= 2 and matricula.estado= 'activo' and matricula.rut_alumno = alumno.rut_alumno and year(matricula.fecha_matricula) = " & int_año & "", conector)
        Dim ds As New DataSet
        conector.Open()

        da.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conector.Close()
        conector.Close()
    End Sub

    Sub mostraralumnocursotercero()
        conector.Close()
        int_año = (seleccion_año)
        Dim da As New SqlDataAdapter("select alumno.rut_alumno'Rut del Alumno', alumno.nombres'Nombre',alumno.apellidos'Apellidos',alumno.fecha_nacimiento'Fecha Nacimiento',matricula.edad_alumno'Edad',matricula.fono_urgencia_1'Fono Urgencia 1',matricula.fono_urgencia_2'Fono Ugencia 2' from alumno,matricula where matricula.curso_alumno= 3 and matricula.estado= 'activo' and matricula.rut_alumno = alumno.rut_alumno and year(matricula.fecha_matricula) = " & int_año & "", conector)
        Dim ds As New DataSet
        conector.Open()

        da.Fill(ds)
        DataGridView3.DataSource = ds.Tables(0)
        conector.Close()
        conector.Close()
    End Sub
    Sub mostraralumnocursocuarto()
        conector.Close()
        int_año = (seleccion_año)
        Dim da As New SqlDataAdapter("select alumno.rut_alumno'Rut del Alumno', alumno.nombres'Nombre',alumno.apellidos'Apellidos',alumno.fecha_nacimiento'Fecha Nacimiento',matricula.edad_alumno'Edad',matricula.fono_urgencia_1'Fono Urgencia 1',matricula.fono_urgencia_2'Fono Ugencia 2' from alumno,matricula where matricula.curso_alumno= 4 and matricula.estado= 'activo' and matricula.rut_alumno = alumno.rut_alumno and year(matricula.fecha_matricula) = " & int_año & "", conector)
        Dim ds As New DataSet
        conector.Open()

        da.Fill(ds)
        DataGridView4.DataSource = ds.Tables(0)
        conector.Close()
        conector.Close()
    End Sub
    Sub mostraralumnocursosexto()
        conector.Close()
        int_año = (seleccion_año)
        Dim da As New SqlDataAdapter("select alumno.rut_alumno'Rut del Alumno', alumno.nombres'Nombre',alumno.apellidos'Apellidos',alumno.fecha_nacimiento'Fecha Nacimiento',matricula.edad_alumno'Edad',matricula.fono_urgencia_1'Fono Urgencia 1',matricula.fono_urgencia_2'Fono Ugencia 2' from alumno,matricula where matricula.curso_alumno= 6 and matricula.estado= 'activo' and matricula.rut_alumno = alumno.rut_alumno and year(matricula.fecha_matricula) = " & int_año & "", conector)
        Dim ds As New DataSet
        conector.Open()

        da.Fill(ds)
        DataGridView6.DataSource = ds.Tables(0)
        conector.Close()
        conector.Close()
    End Sub
    Sub mostraralumnocursoquinto()
        conector.Close()
        int_año = (seleccion_año)
        Dim da As New SqlDataAdapter("select alumno.rut_alumno'Rut del Alumno', alumno.nombres'Nombre',alumno.apellidos'Apellidos',alumno.fecha_nacimiento'Fecha Nacimiento',matricula.edad_alumno'Edad',matricula.fono_urgencia_1'Fono Urgencia 1',matricula.fono_urgencia_2'Fono Ugencia 2' from alumno,matricula where matricula.curso_alumno= 5 and matricula.estado= 'activo' and matricula.rut_alumno = alumno.rut_alumno and year(matricula.fecha_matricula) = " & int_año & "", conector)
        Dim ds As New DataSet
        conector.Open()

        da.Fill(ds)
        DataGridView5.DataSource = ds.Tables(0)
        conector.Close()
        conector.Close()
    End Sub
    Sub mostraralumnocursoseptimo()
        conector.Close()
        int_año = (seleccion_año)
        Dim da As New SqlDataAdapter("select alumno.rut_alumno'Rut del Alumno', alumno.nombres'Nombre',alumno.apellidos'Apellidos',alumno.fecha_nacimiento'Fecha Nacimiento',matricula.edad_alumno'Edad',matricula.fono_urgencia_1'Fono Urgencia 1',matricula.fono_urgencia_2'Fono Ugencia 2' from alumno,matricula where matricula.curso_alumno= 7 and matricula.estado= 'activo' and matricula.rut_alumno = alumno.rut_alumno and year(matricula.fecha_matricula) = " & int_año & "", conector)
        Dim ds As New DataSet
        conector.Open()

        da.Fill(ds)
        DataGridView7.DataSource = ds.Tables(0)
        conector.Close()
        conector.Close()
    End Sub
    Sub mostraralumnocursooctavo()
        conector.Close()
        int_año = (seleccion_año)
        Dim da As New SqlDataAdapter("select alumno.rut_alumno'Rut del Alumno', alumno.nombres'Nombre',alumno.apellidos'Apellidos',alumno.fecha_nacimiento'Fecha Nacimiento',matricula.edad_alumno'Edad',matricula.fono_urgencia_1'Fono Urgencia 1',matricula.fono_urgencia_2'Fono Ugencia 2' from alumno,matricula where matricula.curso_alumno= 8 and matricula.estado= 'activo' and matricula.rut_alumno = alumno.rut_alumno and year(matricula.fecha_matricula) = " & int_año & "", conector)
        Dim ds As New DataSet
        conector.Open()

        da.Fill(ds)
        DataGridView8.DataSource = ds.Tables(0)
        conector.Close()
        conector.Close()
    End Sub
    Sub mostraralumnocursokinder()
        conector.Close()
        int_año = (seleccion_año)
        Dim da As New SqlDataAdapter("select alumno.rut_alumno'Rut del Alumno', alumno.nombres'Nombre',alumno.apellidos'Apellidos',alumno.fecha_nacimiento'Fecha Nacimiento',matricula.edad_alumno'Edad',matricula.fono_urgencia_1'Fono Urgencia 1',matricula.fono_urgencia_2'Fono Ugencia 2' from alumno,matricula where matricula.curso_alumno= 9 and matricula.estado= 'activo' and matricula.rut_alumno = alumno.rut_alumno and year(matricula.fecha_matricula) = " & int_año & "", conector)
        Dim ds As New DataSet
        conector.Open()

        da.Fill(ds)
        DataGridView9.DataSource = ds.Tables(0)
        conector.Close()
        conector.Close()
    End Sub
    Sub mostraralumnocursoprekinder()
        conector.Close()
        int_año = (seleccion_año)
        Dim da As New SqlDataAdapter("select alumno.rut_alumno'Rut del Alumno', alumno.nombres'Nombre',alumno.apellidos'Apellidos',alumno.fecha_nacimiento'Fecha Nacimiento',matricula.edad_alumno'Edad',matricula.fono_urgencia_1'Fono Urgencia 1',matricula.fono_urgencia_2'Fono Ugencia 2' from alumno,matricula where matricula.curso_alumno= 10 and matricula.estado= 'activo' and matricula.rut_alumno = alumno.rut_alumno and year(matricula.fecha_matricula) = " & int_año & "", conector)
        Dim ds As New DataSet
        conector.Open()

        da.Fill(ds)
        DataGridView10.DataSource = ds.Tables(0)
        conector.Close()
        conector.Close()

    End Sub
    Sub mostraralumnocursoprimero()
        conector.Close()
        int_año = (seleccion_año)
        Dim da As New SqlDataAdapter("select alumno.rut_alumno'Rut del Alumno', alumno.nombres'Nombre',alumno.apellidos'Apellidos',alumno.fecha_nacimiento'Fecha Nacimiento',matricula.edad_alumno'Edad',matricula.fono_urgencia_1'Fono Urgencia 1',matricula.fono_urgencia_2'Fono Ugencia 2' from alumno,matricula where matricula.curso_alumno= 1 and matricula.estado= 'activo' and matricula.rut_alumno = alumno.rut_alumno and year(matricula.fecha_matricula) = " & int_año & "", conector)
        Dim ds As New DataSet
        conector.Open()

        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conector.Close()
        conector.Close()

    End Sub


    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(6)
        mostraralumnocursoprimero()
        conector.Close()
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(7)
        mostraralumnocursosegundo()
        conector.Close()
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(8)
        mostraralumnocursotercero()
        conector.Close()
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(9)
        mostraralumnocursocuarto()
        conector.Close()
    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(10)
        mostraralumnocursoquinto()
        conector.Close()
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(11)
        mostraralumnocursosexto()
        conector.Close()
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(12)
        mostraralumnocursoseptimo()
        conector.Close()
    End Sub

    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(13)
        mostraralumnocursooctavo()
        conector.Close()
    End Sub

    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(14)
        mostraralumnocursokinder()
        conector.Close()
    End Sub

    Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button38.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(15)
        mostraralumnocursoprekinder()
        conector.Close()
    End Sub

    Private Sub Button39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(0)
        conector.Close()
    End Sub

    Private Sub Button41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(5)
        SeleccionarAñoCurso.primero_activas()
        SeleccionarAñoCurso.segundo_activas()
        SeleccionarAñoCurso.tercero_activas()
        SeleccionarAñoCurso.cuarto_activas()
        SeleccionarAñoCurso.quinto_activas()
        SeleccionarAñoCurso.sexto_activas()
        SeleccionarAñoCurso.septimo_activas()
        SeleccionarAñoCurso.octavo_activas()
        SeleccionarAñoCurso.kinder_activas()
        SeleccionarAñoCurso.prekinder_activas()

        conector.Close()
    End Sub

    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(5)
        conector.Close()
        SeleccionarAñoCurso.primero_activas()
        SeleccionarAñoCurso.segundo_activas()
        SeleccionarAñoCurso.tercero_activas()
        SeleccionarAñoCurso.cuarto_activas()
        SeleccionarAñoCurso.quinto_activas()
        SeleccionarAñoCurso.sexto_activas()
        SeleccionarAñoCurso.septimo_activas()
        SeleccionarAñoCurso.octavo_activas()
        SeleccionarAñoCurso.kinder_activas()
        SeleccionarAñoCurso.prekinder_activas()

    End Sub

    Private Sub Button42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button42.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(5)
        conector.Close()
        SeleccionarAñoCurso.primero_activas()
        SeleccionarAñoCurso.segundo_activas()
        SeleccionarAñoCurso.tercero_activas()
        SeleccionarAñoCurso.cuarto_activas()
        SeleccionarAñoCurso.quinto_activas()
        SeleccionarAñoCurso.sexto_activas()
        SeleccionarAñoCurso.septimo_activas()
        SeleccionarAñoCurso.octavo_activas()
        SeleccionarAñoCurso.kinder_activas()
        SeleccionarAñoCurso.prekinder_activas()

    End Sub

    Private Sub Button43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button43.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(5)
        conector.Close()
        SeleccionarAñoCurso.primero_activas()
        SeleccionarAñoCurso.segundo_activas()
        SeleccionarAñoCurso.tercero_activas()
        SeleccionarAñoCurso.cuarto_activas()
        SeleccionarAñoCurso.quinto_activas()
        SeleccionarAñoCurso.sexto_activas()
        SeleccionarAñoCurso.septimo_activas()
        SeleccionarAñoCurso.octavo_activas()
        SeleccionarAñoCurso.kinder_activas()
        SeleccionarAñoCurso.prekinder_activas()

    End Sub

    Private Sub Button44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button44.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(5)
        conector.Close()
        SeleccionarAñoCurso.primero_activas()
        SeleccionarAñoCurso.segundo_activas()
        SeleccionarAñoCurso.tercero_activas()
        SeleccionarAñoCurso.cuarto_activas()
        SeleccionarAñoCurso.quinto_activas()
        SeleccionarAñoCurso.sexto_activas()
        SeleccionarAñoCurso.septimo_activas()
        SeleccionarAñoCurso.octavo_activas()
        SeleccionarAñoCurso.kinder_activas()
        SeleccionarAñoCurso.prekinder_activas()

    End Sub

    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(5)
        conector.Close()
        SeleccionarAñoCurso.primero_activas()
        SeleccionarAñoCurso.segundo_activas()
        SeleccionarAñoCurso.tercero_activas()
        SeleccionarAñoCurso.cuarto_activas()
        SeleccionarAñoCurso.quinto_activas()
        SeleccionarAñoCurso.sexto_activas()
        SeleccionarAñoCurso.septimo_activas()
        SeleccionarAñoCurso.octavo_activas()
        SeleccionarAñoCurso.kinder_activas()
        SeleccionarAñoCurso.prekinder_activas()

    End Sub

    Private Sub Button46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button46.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(5)
        conector.Close()
        SeleccionarAñoCurso.primero_activas()
        SeleccionarAñoCurso.segundo_activas()
        SeleccionarAñoCurso.tercero_activas()
        SeleccionarAñoCurso.cuarto_activas()
        SeleccionarAñoCurso.quinto_activas()
        SeleccionarAñoCurso.sexto_activas()
        SeleccionarAñoCurso.septimo_activas()
        SeleccionarAñoCurso.octavo_activas()
        SeleccionarAñoCurso.kinder_activas()
        SeleccionarAñoCurso.prekinder_activas()

    End Sub

    Private Sub Button47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button47.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(5)
        conector.Close()
        SeleccionarAñoCurso.primero_activas()
        SeleccionarAñoCurso.segundo_activas()
        SeleccionarAñoCurso.tercero_activas()
        SeleccionarAñoCurso.cuarto_activas()
        SeleccionarAñoCurso.quinto_activas()
        SeleccionarAñoCurso.sexto_activas()
        SeleccionarAñoCurso.septimo_activas()
        SeleccionarAñoCurso.octavo_activas()
        SeleccionarAñoCurso.kinder_activas()
        SeleccionarAñoCurso.prekinder_activas()

    End Sub

    Private Sub Button48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button48.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(5)
        conector.Close()
        SeleccionarAñoCurso.primero_activas()
        SeleccionarAñoCurso.segundo_activas()
        SeleccionarAñoCurso.tercero_activas()
        SeleccionarAñoCurso.cuarto_activas()
        SeleccionarAñoCurso.quinto_activas()
        SeleccionarAñoCurso.sexto_activas()
        SeleccionarAñoCurso.septimo_activas()
        SeleccionarAñoCurso.octavo_activas()
        SeleccionarAñoCurso.kinder_activas()
        SeleccionarAñoCurso.prekinder_activas()

    End Sub

    Private Sub Button49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button49.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(5)
        conector.Close()
        SeleccionarAñoCurso.primero_activas()
        SeleccionarAñoCurso.segundo_activas()
        SeleccionarAñoCurso.tercero_activas()
        SeleccionarAñoCurso.cuarto_activas()
        SeleccionarAñoCurso.quinto_activas()
        SeleccionarAñoCurso.sexto_activas()
        SeleccionarAñoCurso.septimo_activas()
        SeleccionarAñoCurso.octavo_activas()
        SeleccionarAñoCurso.kinder_activas()
        SeleccionarAñoCurso.prekinder_activas()

    End Sub

    Private Sub Button60_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button60.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(16)
        conector.Close()
     
        TextBox30.Text = ("")
        TextBox30.Enabled = True

        TextBox32.Enabled = False
        TextBox33.Enabled = False
        TextBox34.Enabled = False


        Button62.Visible = False
    End Sub

    Private Sub Button62_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button62.Click
        Dim fecha_hoy = CDate(Today.Date.Year & "-" & Today.Date.Month & "-" & Today.Day)
        Dim fecha_de_ayer = CDate(Today.Date.Year - 1 & "-" & 12 & "-" & 1)

        Try
            Dim cadena As String
            cadena = String.Format("UPDATE matricula SET estado = ' inactivo '  WHERE matricula.fecha_matricula BETWEEN '" & fecha_de_ayer & "' AND '" & fecha_hoy & "'  and matricula.rut_alumno = '" & TextBox30.Text & "'")
            Dim insertar As New SqlCommand(cadena, conector)
            conector.Open()
            insertar.ExecuteNonQuery()
            conector.Close()
            MsgBox("Matricula Retirada", MsgBoxStyle.Information, "Operacion Exitosa")
            TextBox30.Text = ""

            TextBox32.Text = ""
            TextBox33.Text = ""
            TextBox34.Text = ""

        Catch ex As Exception
            conector.Close()
        End Try
    End Sub

    Private Sub Button61_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button61.Click
        Dim fecha_hoy = CDate(Today.Date.Year & "-" & Today.Date.Month & "-" & Today.Day)
        Dim fecha_de_ayer = CDate(Today.Date.Year - 1 & "-" & 12 & "-" & 1)


        Try
            conector.Open()
            Dim qry As String = "select alumno.rut_alumno, alumno.nombres,alumno.apellidos,alumno.fecha_nacimiento,matricula.fecha_matricula from alumno,matricula where matricula.rut_alumno = alumno.rut_alumno and matricula.fecha_matricula BETWEEN '" & fecha_de_ayer & "' AND '" & fecha_hoy & "' and alumno.rut_alumno='" & TextBox30.Text & "' and matricula.estado = 'activo' "
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader
            If dr.Read() Then
                TextBox32.Text = dr("nombres")
                TextBox33.Text = dr("apellidos")
                TextBox34.Text = dr("fecha_nacimiento")
                año_para_bajar = dr("fecha_matricula")

                conector.Close()
                Button62.Visible = True
            Else

                MsgBox("ERROR RUT NO VALIDO", MsgBoxStyle.Critical, "Atencion")
                conector.Close()
            End If
            conector.Close()
        Catch ex As Exception
            MsgBox("error" & vbCrLf & ex.Message)
            conector.Close()
        End Try
    End Sub

    Private Sub Button63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button63.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(0)
        conector.Close()
        matriculas_activas()
        matriculas_total()
        SeleccionarAñoCurso.primero_activas()
        SeleccionarAñoCurso.segundo_activas()
        SeleccionarAñoCurso.tercero_activas()
        SeleccionarAñoCurso.cuarto_activas()
        SeleccionarAñoCurso.quinto_activas()
        SeleccionarAñoCurso.sexto_activas()
        SeleccionarAñoCurso.septimo_activas()
        SeleccionarAñoCurso.octavo_activas()
        SeleccionarAñoCurso.kinder_activas()
        SeleccionarAñoCurso.prekinder_activas()

    End Sub

    Private Sub Button64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button64.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
        conector.Close()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        TextBox9.Enabled = True
        TextBox10.Enabled = True
        TextBox11.Enabled = True
        TextBox12.Enabled = True
        TextBox13.Enabled = True
        TextBox14.Enabled = True
        TextBox15.Enabled = True
        TextBox16.Enabled = True
        TextBox17.Enabled = True
        TextBox18.Enabled = True
        TextBox19.Enabled = True
        TextBox20.Enabled = True
        TextBox21.Enabled = True
        TextBox22.Enabled = True
        TextBox23.Enabled = True
        TextBox24.Enabled = True
        TextBox25.Enabled = True
        TextBox26.Enabled = True
        TextBox27.Enabled = True
        TextBox28.Enabled = True
        TextBox29.Enabled = True
        TextBox30.Enabled = True
    End Sub

    Private Sub Button66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button66.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(0)
        conector.Close()
    End Sub

    Private Sub Button65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button65.Click
        conector.Close()
        Dim fecha_para_form = calen.SelectionRange.Start.Year

        Try
            rut_pdf_alumno = TextBox28.Text
            conector.Open()
            Dim qry As String = "select alumno.rut_alumno ,alumno.nombres,alumno.apellidos,alumno.fecha_nacimiento, matricula.edad_alumno,curso.Nombre ,matricula.fono_urgencia_1 ,matricula.fono_urgencia_2,alumno.sexo,apoderado.rut_apoderado , apoderado.nombre_apoderado ,apoderado.domicilio , apoderado.fono  ,matricula.fecha_matricula ,matricula.escuela_procedencia ,matricula.cursos_repetidos ,matricula.domicilio_alumno ,matricula.alergico , matricula.grupo_sanguineo ,matricula.enfermedad ,matricula.grupo_pie ,matricula.nombre_padre ,matricula.nombre_madre ,matricula.rut_padre ,matricula.rut_madre ,matricula.trabajo_padre ,matricula.trabajo_madre ,matricula.escolaridad_padre ,matricula.escolaridad_madre ,matricula.vive_con ,matricula.casa_propia ,matricula.ingreso_mensual ,matricula.beneficio ,matricula.religion , usuario.nombre_usuario from alumno, apoderado, curso, matricula, usuario where matricula.rut_alumno = alumno.rut_alumno And apoderado.rut_apoderado = matricula.rut_apoderado And matricula.curso_alumno = curso.id_curso And matricula.id_usuario = usuario.id_usuario And matricula.rut_alumno ='" & rut_pdf_alumno & "' and year (matricula.fecha_matricula)= " & fecha_para_form & " "
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

                conector.Close()
                Form1.Show()
                Me.Hide()
            End If
            conector.Close()
            conector.Close()
        Catch ex As Exception
            MsgBox("ERROR INTENTE EN OTRO MOMENTO", MsgBoxStyle.Critical, "ALERTA")
            conector.Close()
        End Try
        conector.Close()
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, _
                              ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                              Handles TextBox3.KeyPress

        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If



    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, _
                             ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                             Handles TextBox2.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub




    Private Sub textbox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyData
            Case Keys.A To Keys.Z Or Keys.Space

                ' Números del 0 al 9

                e.SuppressKeyPress = True
        End Select
    End Sub
    Private Sub textbox29_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyData
            Case Keys.A To Keys.Z Or Keys.Space

                ' Números del 0 al 9

                e.SuppressKeyPress = True
        End Select
    End Sub


    Private Sub textbox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown
        Select Case e.KeyData
            Case Keys.A To Keys.Z Or Keys.Space

                ' Números del 0 al 9

                e.SuppressKeyPress = True
        End Select
    End Sub
    Private Sub textbox18_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox18.KeyDown
        Select Case e.KeyData
            Case Keys.A To Keys.Z Or Keys.Space

                ' Números del 0 al 9

                e.SuppressKeyPress = True
        End Select
    End Sub
    Private Sub TextBox8_KeyPress(ByVal sender As Object, _
                            ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                            Handles TextBox8.KeyPress

        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox20_KeyPress(ByVal sender As Object, _
                           ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                           Handles TextBox20.KeyPress

        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox10_KeyPress(ByVal sender As Object, _
                          ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                          Handles TextBox10.KeyPress

        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged
        If TextBox11.TextLength = 8 Then TextBox11.Text = ValidaRut(TextBox11.Text)
        conector.Close()
    End Sub


    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        TextBox26.Text = inicio1.nomUsuario
        'TabControl1.SelectedTab = TabControl1.TabPages.Item(17)

        'TextBox41.Text = ("")
        conector.Close()

        SeleccionarAñoCurso.MostrarAñoParaCurso()

        SeleccionarAñoCurso.TextBox1.Text = ""
        SeleccionarAñoCurso.ComboBox1.Visible = True
        SeleccionarAñoCurso.TextBox1.Visible = True
        SeleccionarAñoCurso.Button2.Visible = True
        SeleccionarAñoCurso.Button1.Visible = False
        SeleccionarAñoCurso.Label1.Text = "INGRESE RUT ALUMNO" & vbCr & "Y AÑO DE MATRICULA"

        SeleccionarAñoCurso.Show()
        Me.Enabled = False
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
    Private Sub TxtRut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        e.Handled = ValidaChar(e.KeyChar)
    End Sub

    Public Function ValidaChar(ByVal car As Char) As Boolean
        ' sólo admitimos números y tecla retroceso
        If Char.IsNumber(car, 0) = True Or Char.IsControl(car) = True Then
            Return (False)
        Else
            Return (True)
        End If
    End Function

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        conector.Close()
        Try
            rut_pdf_alumno = TextBox41.Text
            conector.Close()
            conector.Open()
            Dim qry As String = "select alumno.rut_alumno ,alumno.nombres,alumno.apellidos,alumno.fecha_nacimiento, matricula.edad_alumno,curso.Nombre ,matricula.fono_urgencia_1 ,matricula.fono_urgencia_2,alumno.sexo,apoderado.rut_apoderado , apoderado.nombre_apoderado ,apoderado.domicilio , apoderado.fono  ,matricula.fecha_matricula ,matricula.escuela_procedencia ,matricula.cursos_repetidos ,matricula.domicilio_alumno ,matricula.alergico , matricula.grupo_sanguineo ,matricula.enfermedad ,matricula.grupo_pie ,matricula.nombre_padre ,matricula.nombre_madre ,matricula.rut_padre ,matricula.rut_madre ,matricula.trabajo_padre ,matricula.trabajo_madre ,matricula.escolaridad_padre ,matricula.escolaridad_madre ,matricula.vive_con ,matricula.casa_propia ,matricula.ingreso_mensual ,matricula.beneficio ,matricula.religion , usuario.nombre_usuario from alumno, apoderado, curso, matricula, usuario where matricula.rut_alumno = alumno.rut_alumno And apoderado.rut_apoderado = matricula.rut_apoderado And matricula.curso_alumno = curso.id_curso And matricula.id_usuario = usuario.id_usuario And matricula.rut_alumno ='" & rut_pdf_alumno & "' "
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
                conector.Close()


                Form1.Show()
                Me.Hide()
            Else
                MsgBox("RUT NO VALIDO", MsgBoxStyle.Critical, "Atencion")
                conector.Close()
                conector.Close()
            End If

        Catch ex As Exception
            conector.Close()
        End Try

    End Sub

    Private Sub Button67_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button67.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(0)
        conector.Close()
    End Sub

    Private Sub TextBox28_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox28.TextChanged
        conector.Close()
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(3)
        TextBox26.Text = inicio1.nomUsuario
        conector.Close()
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        TextBox26.Text = inicio1.nomUsuario
        conector.Close()
        TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        TextBox26.Text = inicio1.nomUsuario
        TabControl1.SelectedTab = TabControl1.TabPages.Item(2)
        conector.Close()
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        TextBox26.Text = inicio1.nomUsuario
        TabControl1.SelectedTab = TabControl1.TabPages.Item(3)
        conector.Close()
    End Sub

    Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles Button25.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(1)
        conector.Close()
    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(2)
        conector.Close()
    End Sub

    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        TabControl1.SelectedTab = TabControl1.TabPages.Item(3)
        conector.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
        conector.Close()
        conector.Close()
    End Sub

    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox4.TextChanged
        conector.Close()
        If TextBox4.TextLength = 8 Then TextBox4.Text = ValidaRut(TextBox4.Text)
    End Sub



    Private Sub TextBox9_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox9.TextChanged
        If TextBox9.TextLength = 8 Then TextBox9.Text = ValidaRut(TextBox9.Text)
        conector.Close()
    End Sub

    Private Sub TextBox12_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox12.TextChanged
        If TextBox12.TextLength = 8 Then TextBox12.Text = ValidaRut(TextBox12.Text)
        conector.Close()
    End Sub

    Private Sub TextBox30_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox30.TextChanged
        If TextBox30.TextLength = 8 Then TextBox30.Text = ValidaRut(TextBox30.Text)
        conector.Close()
    End Sub

    Private Sub TextBox41_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox41.TextChanged
        If TextBox41.TextLength = 8 Then TextBox41.Text = ValidaRut(TextBox41.Text)
        conector.Close()
    End Sub

    Private Sub textbox30_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox30.KeyDown
        Select Case e.KeyData
            Case Keys.A To Keys.Z Or Keys.Space

                ' Números del 0 al 9

                e.SuppressKeyPress = True
        End Select
    End Sub

    Private Sub textbox12_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox12.KeyDown
        Select Case e.KeyData
            Case Keys.A To Keys.Z Or Keys.Space

                ' Números del 0 al 9

                e.SuppressKeyPress = True
        End Select
    End Sub
    Private Sub textbox11_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox11.KeyDown
        Select Case e.KeyData
            Case Keys.A To Keys.Z Or Keys.Space

                ' Números del 0 al 9

                e.SuppressKeyPress = True
        End Select
    End Sub
    Private Sub textbox41_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox41.KeyDown
        Select Case e.KeyData
            Case Keys.A To Keys.Z Or Keys.Space

                ' Números del 0 al 9

                e.SuppressKeyPress = True
        End Select
    End Sub




    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged

        TextBox3.Text = UCase(TextBox3.Text)
        TextBox3.SelectionStart = TextBox3.TextLength + 1

    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged

        TextBox2.Text = UCase(TextBox2.Text)
        TextBox2.SelectionStart = TextBox2.TextLength + 1
    End Sub

    Private Sub TextBox8_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox8.TextChanged

        TextBox8.Text = UCase(TextBox8.Text)
        TextBox8.SelectionStart = TextBox8.TextLength + 1
    End Sub

    Private Sub TextBox7_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox7.TextChanged

        TextBox7.Text = UCase(TextBox7.Text)
        TextBox7.SelectionStart = TextBox7.TextLength + 1
    End Sub

    Private Sub TextBox25_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox25.TextChanged

        TextBox25.Text = UCase(TextBox25.Text)
        TextBox25.SelectionStart = TextBox25.TextLength + 1
    End Sub

    Private Sub TextBox24_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox24.TextChanged

        TextBox24.Text = UCase(TextBox24.Text)
        TextBox24.SelectionStart = TextBox24.TextLength + 1
    End Sub

    Private Sub TextBox22_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox22.TextChanged

        TextBox22.Text = UCase(TextBox22.Text)
        TextBox22.SelectionStart = TextBox22.TextLength + 1
    End Sub

    Private Sub TextBox21_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox21.TextChanged

        TextBox21.Text = UCase(TextBox21.Text)
        TextBox21.SelectionStart = TextBox21.TextLength + 1
    End Sub

    Private Sub TextBox23_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox23.TextChanged

        TextBox23.Text = UCase(TextBox23.Text)
        TextBox23.SelectionStart = TextBox23.TextLength + 1
    End Sub

    Private Sub TextBox20_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox20.TextChanged

        TextBox20.Text = UCase(TextBox20.Text)
        TextBox20.SelectionStart = TextBox20.TextLength + 1
    End Sub

    Private Sub TextBox10_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox10.TextChanged

        TextBox10.Text = UCase(TextBox10.Text)
        TextBox10.SelectionStart = TextBox10.TextLength + 1
    End Sub

    Private Sub TextBox13_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox13.TextChanged

        TextBox13.Text = UCase(TextBox13.Text)
        TextBox13.SelectionStart = TextBox13.TextLength + 1
    End Sub

    Private Sub TextBox14_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox14.TextChanged

        TextBox14.Text = UCase(TextBox14.Text)
        TextBox14.SelectionStart = TextBox14.TextLength + 1
    End Sub

    Private Sub TextBox15_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox15.TextChanged

        TextBox15.Text = UCase(TextBox15.Text)
        TextBox15.SelectionStart = TextBox15.TextLength + 1
    End Sub

    Private Sub TextBox16_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox16.TextChanged

        TextBox16.Text = UCase(TextBox16.Text)
        TextBox16.SelectionStart = TextBox16.TextLength + 1
    End Sub

    Private Sub TextBox17_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox17.TextChanged

        TextBox17.Text = UCase(TextBox17.Text)
        TextBox17.SelectionStart = TextBox17.TextLength + 1
    End Sub

    Private Sub TextBox19_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox19.TextChanged

        TextBox19.Text = UCase(TextBox19.Text)
        TextBox19.SelectionStart = TextBox19.TextLength + 1
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox23.Enabled = True
            CheckBox2.Checked = False


        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            TextBox23.Enabled = False
            CheckBox1.Checked = False
            TextBox23.Text = "NO HA REPETIDO"
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            TextBox22.Enabled = True
            CheckBox3.Checked = False

        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.CheckState = CheckState.Checked Then
            TextBox22.Enabled = False
            CheckBox4.Checked = False
            TextBox22.Text = "NO ES ALERGICO"
        End If
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.CheckState = CheckState.Checked Then
            TextBox19.Enabled = False
            CheckBox6.Checked = False
            TextBox19.Text = "NO TIENE BENEFICIO"
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            TextBox19.Enabled = True
            CheckBox5.Checked = False

        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.CheckState = CheckState.Checked Then
            TextBox37.Enabled = False
            CheckBox8.Checked = False
            TextBox37.Text = "NO SABE"
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked = True Then
            TextBox37.Enabled = True
            CheckBox7.Checked = False

        End If
    End Sub

    Private Sub TabPage3_Click(sender As System.Object, e As System.EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub TextBox37_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox37.TextChanged

        TextBox37.Text = UCase(TextBox37.Text)
        TextBox37.SelectionStart = TextBox37.TextLength + 1
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Panel5_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel5.Paint

    End Sub
End Class