Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Mail

Public Class Seleccion_Tipo_Matricula
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

        matricula.Enabled = True
        matricula.Show()
        Me.Hide()
        Form1.Hide()
        Form1.Close()
        Ingreso_Rut_Matricula.Hide()
        Ingreso_Rut_Matricula.Close()


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        matricula.TextBox26.Text = inicio1.nomUsuario
        conector.Close()

        

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
        matricula.TextBox19.Enabled = False
        matricula.TextBox20.Enabled = True
        matricula.TextBox21.Enabled = True
        matricula.TextBox22.Enabled = False
        matricula.TextBox23.Enabled = False
        matricula.TextBox24.Enabled = True
        matricula.TextBox25.Enabled = True
        matricula.TextBox26.Enabled = True
        matricula.TextBox27.Enabled = True
        matricula.TextBox28.Enabled = True
        matricula.TextBox29.Enabled = True
        matricula.TextBox30.Enabled = True
        matricula.TextBox37.Enabled = False

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

        matricula.calendarn.Enabled = True
        matricula.calen.Enabled = True

        matricula.Button1.Visible = True
        matricula.Button14.Visible = True
        matricula.Button2.Visible = True
        matricula.Button3.Visible = True
        matricula.Button6.Visible = True
        matricula.Button65.Visible = True
        matricula.Button9.Visible = True

        matricula.Button8.Visible = False
        matricula.Button28.Visible = False

        matricula.ComboBox1.Text = ("")
        matricula.ComboBox2.Text = ("")
        matricula.ComboBox3.Text = ("")
        matricula.ComboBox4.Text = ("")

        matricula.ComboBox6.Text = ("")

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

        conector.Close()
        conector.Close()

        matricula.TabControl1.SelectedTab = matricula.TabControl1.TabPages.Item(1)
        matricula.Enabled = True
        matricula.Show()

        Form1.Hide()
        Form1.Close()
        Me.Hide()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        matricula.Enabled = False
        Me.Enabled = False
        Ingreso_Rut_Matricula.Show()

    End Sub
End Class