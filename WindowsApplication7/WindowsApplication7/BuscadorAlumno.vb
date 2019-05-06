Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class BuscadorAlumno
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

    Public rut_alumno_para_data
    Public fecha_matricula_para_data

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        MostrarRegistroAlumno()
    End Sub
    Sub MostrarRegistroAlumno()

        conector.Close()

        Dim da As New SqlDataAdapter("select matricula.rut_alumno 'RUT DEL ALUMNO' , alumno.nombres 'NOMBRES ALUMNO', alumno.apellidos 'APELLIDOS ALUMNO' , matricula.fecha_matricula 'FECHA DE MATRICULA' from matricula , alumno where matricula.rut_alumno = alumno.rut_alumno and matricula.rut_alumno = '" & TextBox1.Text & "' ", conector)
        Dim ds As New DataSet
        conector.Open()

        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Button2.Visible = True
        conector.Close()
        conector.Close()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            rut_alumno_para_data = DataGridView1.Rows(e.RowIndex).Cells("RUT DEL ALUMNO").Value.ToString()
            fecha_matricula_para_data = DataGridView1.Rows(e.RowIndex).Cells("FECHA DE MATRICULA").Value.ToString()

        Catch
        End Try

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        conector.Close()
        Try
            matricula.rut_pdf_alumno = matricula.TextBox28.Text
            conector.Open()
            Dim qry As String = "select alumno.rut_alumno ,alumno.nombres,alumno.apellidos,alumno.fecha_nacimiento, matricula.edad_alumno,curso.Nombre ,matricula.fono_urgencia_1 ,matricula.fono_urgencia_2,alumno.sexo,apoderado.rut_apoderado , apoderado.nombre_apoderado ,apoderado.domicilio , apoderado.fono  ,matricula.fecha_matricula ,matricula.escuela_procedencia ,matricula.cursos_repetidos ,matricula.domicilio_alumno ,matricula.alergico , matricula.grupo_sanguineo ,matricula.enfermedad ,matricula.grupo_pie ,matricula.nombre_padre ,matricula.nombre_madre ,matricula.rut_padre ,matricula.rut_madre ,matricula.trabajo_padre ,matricula.trabajo_madre ,matricula.escolaridad_padre ,matricula.escolaridad_madre ,matricula.vive_con ,matricula.casa_propia ,matricula.ingreso_mensual ,matricula.beneficio ,matricula.religion , usuario.nombre_usuario, matricula.año_academico from alumno, apoderado, curso, matricula, usuario where matricula.rut_alumno = alumno.rut_alumno And apoderado.rut_apoderado = matricula.rut_apoderado And matricula.curso_alumno = curso.id_curso And matricula.id_usuario = usuario.id_usuario And matricula.rut_alumno ='" & rut_alumno_para_data & "' and matricula.fecha_matricula= '" & fecha_matricula_para_data & "' "
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

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        conector.Close()
        conector.Close()
        conector.Close()

        matricula.Enabled = True
        matricula.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        conector.Close()
        conector.Close()
        conector.Close()

        matricula.Enabled = True
        matricula.Show()
        Me.Close()

    End Sub

    
End Class