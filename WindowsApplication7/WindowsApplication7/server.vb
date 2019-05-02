Imports System.IO
Imports System.Data.SqlClient

Public Class server

    Public dreader As SqlDataReader


    Dim conector As New SqlConnection

    Dim dt As DataTable


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guardar.Click
        Dim objStreamWriter As StreamWriter
        'Pass the file path and the file name to the StreamWriter constructor.
        objStreamWriter = New StreamWriter(Directory.GetCurrentDirectory() + "\Testfile.txt")

        'Write a line of text.
        objStreamWriter.WriteLine(nombre.Text)

        'Write a second line of text.
        objStreamWriter.WriteLine(puerto.Text)
        objStreamWriter.WriteLine(bd.Text)
        objStreamWriter.WriteLine(usuario.Text)
        objStreamWriter.WriteLine(pass.Text)


        'Close the file.
        objStreamWriter.Close()
        Dim actual As String = Directory.GetCurrentDirectory()
        MsgBox(actual)
        MsgBox("datos guardados exitosamente..!")
    End Sub

    Private Sub server_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim objStreamReader As StreamReader
            objStreamReader = New StreamReader(Directory.GetCurrentDirectory() + "\Testfile.txt")

            nombre.Text = objStreamReader.ReadLine
            puerto.Text = objStreamReader.ReadLine
            bd.Text = objStreamReader.ReadLine
            usuario.Text = objStreamReader.ReadLine
            pass.Text = objStreamReader.ReadLine
            objStreamReader.Close()
            guardar.Enabled = False
        Catch ex As Exception

        End Try
       

    End Sub

    Private Sub test_con_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles test_con.Click
        Try
            conector = New SqlConnection("server=" + nombre.Text + "  ;user='" + usuario.Text + "';password= '" + pass.Text + "' ; database=" + bd.Text + "")

            conector.Open()
            Dim qry As String = "select * from usuario "
            Dim sqlcmd As New SqlCommand(qry, conector)
            Dim dr As SqlDataReader
            dr = sqlcmd.ExecuteReader


            If dr.Read() Then
                test_txt.BackColor = Color.GreenYellow
                test_txt.Text = "CONECTADO..."
                guardar.Enabled = True
            End If
            conector.Close()
        Catch ex As Exception
            conector.Close()
            test_txt.BackColor = Color.Red
            test_txt.Text = "DESCONECTADO..."
            guardar.Enabled = False

            MsgBox("Revise los datos de coneccion.!")

        End Try
    End Sub
   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FormMenuUsuario.Show()
        Me.Close()
    End Sub

  

End Class