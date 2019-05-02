<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class server
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nombre = New System.Windows.Forms.TextBox()
        Me.pass = New System.Windows.Forms.TextBox()
        Me.usuario = New System.Windows.Forms.TextBox()
        Me.bd = New System.Windows.Forms.TextBox()
        Me.puerto = New System.Windows.Forms.TextBox()
        Me.test_con = New System.Windows.Forms.Button()
        Me.test_txt = New System.Windows.Forms.TextBox()
        Me.guardar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre del servidor :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Puerto :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "base de datos :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Usuario de base datos :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(190, 18)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Contraseña de base datos :"
        '
        'nombre
        '
        Me.nombre.Location = New System.Drawing.Point(220, 27)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(172, 20)
        Me.nombre.TabIndex = 5
        '
        'pass
        '
        Me.pass.Location = New System.Drawing.Point(220, 198)
        Me.pass.Name = "pass"
        Me.pass.Size = New System.Drawing.Size(172, 20)
        Me.pass.TabIndex = 6
        '
        'usuario
        '
        Me.usuario.Location = New System.Drawing.Point(220, 150)
        Me.usuario.Name = "usuario"
        Me.usuario.Size = New System.Drawing.Size(172, 20)
        Me.usuario.TabIndex = 7
        '
        'bd
        '
        Me.bd.Location = New System.Drawing.Point(220, 108)
        Me.bd.Name = "bd"
        Me.bd.Size = New System.Drawing.Size(172, 20)
        Me.bd.TabIndex = 8
        '
        'puerto
        '
        Me.puerto.Location = New System.Drawing.Point(220, 66)
        Me.puerto.Name = "puerto"
        Me.puerto.Size = New System.Drawing.Size(172, 20)
        Me.puerto.TabIndex = 9
        '
        'test_con
        '
        Me.test_con.BackColor = System.Drawing.SystemColors.ControlDark
        Me.test_con.FlatAppearance.BorderSize = 2
        Me.test_con.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.test_con.Location = New System.Drawing.Point(19, 241)
        Me.test_con.Name = "test_con"
        Me.test_con.Size = New System.Drawing.Size(162, 23)
        Me.test_con.TabIndex = 10
        Me.test_con.Text = "Probar conecciòn"
        Me.test_con.UseVisualStyleBackColor = False
        '
        'test_txt
        '
        Me.test_txt.BackColor = System.Drawing.Color.Gold
        Me.test_txt.Enabled = False
        Me.test_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.test_txt.Location = New System.Drawing.Point(220, 241)
        Me.test_txt.Name = "test_txt"
        Me.test_txt.Size = New System.Drawing.Size(172, 20)
        Me.test_txt.TabIndex = 11
        Me.test_txt.Text = "  --------------------------------------"
        '
        'guardar
        '
        Me.guardar.Location = New System.Drawing.Point(146, 290)
        Me.guardar.Name = "guardar"
        Me.guardar.Size = New System.Drawing.Size(129, 28)
        Me.guardar.TabIndex = 12
        Me.guardar.Text = "Guardar conecciòn"
        Me.guardar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(345, 311)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 26)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Volver"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'server
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 349)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.guardar)
        Me.Controls.Add(Me.test_txt)
        Me.Controls.Add(Me.test_con)
        Me.Controls.Add(Me.puerto)
        Me.Controls.Add(Me.bd)
        Me.Controls.Add(Me.usuario)
        Me.Controls.Add(Me.pass)
        Me.Controls.Add(Me.nombre)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "server"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "server"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nombre As System.Windows.Forms.TextBox
    Friend WithEvents pass As System.Windows.Forms.TextBox
    Friend WithEvents usuario As System.Windows.Forms.TextBox
    Friend WithEvents bd As System.Windows.Forms.TextBox
    Friend WithEvents puerto As System.Windows.Forms.TextBox
    Friend WithEvents test_con As System.Windows.Forms.Button
    Friend WithEvents test_txt As System.Windows.Forms.TextBox
    Friend WithEvents guardar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
