import 'package:estesimapa/page/principal.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:estesimapa/page/otrapage.dart';
import 'package:mailer/mailer.dart';
import 'package:mailer/smtp_server.dart';

import 'package:toast/toast.dart';
import 'package:http/http.dart' as http;

import '../../main.dart';

class crear_cuenta extends StatelessWidget {
  TextEditingController txtemail = new TextEditingController();
  TextEditingController txtnombre = new TextEditingController();
  TextEditingController txtapellido = new TextEditingController();
  TextEditingController txttelefono = new TextEditingController();
  TextEditingController txtcontrasena = new TextEditingController();
  TextEditingController txtcod_condominio = new TextEditingController();
  @override
  Widget build(BuildContext context) {
    TextStyle style = TextStyle(fontFamily: 'Montserrat', fontSize: 15.0);


    final otrapage perfil = otrapage();

    final nombrefield = TextField(
      controller: txtnombre,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "nombre...",
          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),

    );

    final telefonofield = TextField(
      controller: txttelefono,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "telefono...",
          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final emailfield = TextField(
      controller: txtemail,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "castroarias@gmail.com",

          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final apellidofield = TextField(
      controller: txtapellido,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Arias Castro",

          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final contrasenafield = TextField(
      controller: txtcontrasena,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "****",

          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );


    final crearcuentaButton = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.blueGrey,
      child: MaterialButton(
        minWidth: 200,
        padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () {
          //Navigator.push(context,MaterialPageRoute(builder: (context) => BottomNavBar()),);
          obtenerUsuario(context);
        },
        child: Text("Crear cuenta",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );






    return Scaffold(

        appBar: AppBar(leading: IconButton(
          icon: Icon(Icons.keyboard_backspace) ,
          onPressed: () {
            Navigator.pop(
              context,
              MaterialPageRoute(builder: (context) => perfil),
            );
          },
        ),
            backgroundColor: Colors.blueGrey,
            title: Text("Crea tu cuenta",)
        ),

        backgroundColor: Colors.white,
        body: Center(
          child: new SingleChildScrollView(
            child: Column(


              children: <Widget>[

                Icon(Icons.person , size: 80,),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('Email ',textScaleFactor: 1.0 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                emailfield,
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('Nombres ',textScaleFactor: 1.0 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                //Text('Mi Perfil ',textScaleFactor: 1.7 , style: style.copyWith(color: Colors.white),),
                SizedBox(height: 5.0),
                nombrefield,
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('Apellidos ',textScaleFactor: 1.0 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                apellidofield,
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('Telefono ',textScaleFactor: 1.0 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                telefonofield,
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('contraseña ',textScaleFactor: 1.0 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                contrasenafield,
                SizedBox(height: 40.0),
                crearcuentaButton ,

              ],
            ),
          ),
        ) // This trailing comma makes auto-formatting nicer for build methods.
    );

  }
  Future<List> obtenerUsuario(BuildContext context) async {
    var url = "http://parkii.tk/API/crearusuario.php";
    final response = await http.post(url, body: {
      "email": txtemail.text,
      "nombre":txtnombre.text,
      "apellido":txtapellido.text,
      "telefono":txttelefono.text,
      "pass":txtcontrasena.text,
      "cod_condominio":"1"

      //"contrasena": pass
    });
    String username = "charlshsx@gmail.com";//Your Email;
    String password = "199314hsxaux";

    final smtpServer = gmail(username, password);
    // Creating the Gmail server

    // Create our email message.
    final message = Message()
      ..from = Address(username)
      ..recipients.add('charlshsx@gmail.com') //recipent email
      ..ccRecipients.addAll(['destCc1@example.com', 'destCc2@example.com']) //cc Recipents emails
      ..bccRecipients.add(Address('bccAddress@example.com')) //bcc Recipents emails
      ..subject = 'Test Dart Mailer library :: 😀 :: ${DateTime.now()}' //subject of the email
      ..text = 'This is the plain text.\nThis is line 2 of the text part.'; //body of the email

    try {
      final sendReport = await send(message, smtpServer);
      print('Message sent: ' + sendReport.toString()); //print if the email is sent
    } on MailerException catch (e) {
      print('Message not sent. \n'+ e.toString()); //print if the email is not sent
      // e.toString() will show why the email is not sending
    }

  //txtcontrasena.text=response.body.toString();
    Toast.show(
        response.body.toString(),
        context,
        duration: Toast.LENGTH_LONG,
        gravity: Toast.CENTER,
        backgroundColor: Colors.green,
        textColor: Colors.white
    );
    if(response.body == "correcto") {
      Toast.show(
          "LOGIN CORRECTO",
          context,
          duration: Toast.LENGTH_LONG,
          gravity: Toast.CENTER,
          backgroundColor: Colors.green,
          textColor: Colors.white
      );
    } else if(response.body == "error") {
      Toast.show(
          "LOGIN INCORRECTO",
          context,
          duration: Toast.LENGTH_LONG,
          gravity: Toast.CENTER,
          backgroundColor: Colors.red,
          textColor: Colors.white
      );
    }
  }


}

