import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:estesimapa/page/otrapage.dart';
import 'package:flutter/services.dart';
import 'package:mailer/mailer.dart';
import 'package:mailer/smtp_server.dart';

import 'package:toast/toast.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:crypto/crypto.dart';



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
          hintText: "Nombres",
          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),

    );

    final telefonofield = TextField(
      controller: txttelefono,
      obscureText: false,
      keyboardType: TextInputType.number,
      inputFormatters: <TextInputFormatter>[
        WhitelistingTextInputFormatter.digitsOnly
      ],
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Telefono",
          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final emailfield = TextField(
      controller: txtemail,
      keyboardType: TextInputType.emailAddress,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "correo@gmail.com",

          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final apellidofield = TextField(
      controller: txtapellido,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Apellidos",

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
        onPressed: () async {
          if (txttelefono.text.length>9 || txttelefono.text.length <9 ||
              txtcontrasena.text.length < 6 || txtcontrasena.text.length > 30 ||
              txtnombre.text.length < 5 || txtnombre.text.length > 150 ||
              txtapellido.text.length > 150 || txtapellido.text.length < 5){

            Toast.show(
                "Ingrese datos correctos",
                context,
                duration: Toast.LENGTH_LONG,
                gravity: Toast.BOTTOM,
                backgroundColor: Colors.red,
                textColor: Colors.white
            );

          }else {
            var url = "http://parkii.tk/API/consultaremail.php";
            final response = await http.post(url, body: {
              "email": txtemail.text,
            });
            if (response.body == "correcto") {
              Toast.show(
                  "Este Email ya tiene una cuenta asociada",
                  context,
                  duration: Toast.LENGTH_LONG,
                  gravity: Toast.BOTTOM,
                  backgroundColor: Colors.red,
                  textColor: Colors.white
              );


              //Navigator.of(context).pop();

            } else if (response.body == "incorrecto") {
              Toast.show(
                  "Correo aceptado",
                  context,
                  duration: Toast.LENGTH_LONG,
                  gravity: Toast.BOTTOM,
                  backgroundColor: Colors.green,
                  textColor: Colors.white
              );
              obtenerUsuario(context);
            }
          }

          //Navigator.push(context,MaterialPageRoute(builder: (context) => BottomNavBar()),);
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
    String hash =generateMd5();
    var url = "http://parkii.tk/API/crearusuario.php";
    final response = await http.post(url, body: {
      "email": txtemail.text,
      "nombre":txtnombre.text,
      "apellido":txtapellido.text,
      "telefono":txttelefono.text,
      "pass":txtcontrasena.text,
      "cod_condominio":"1",
      "hash": hash
      //"contrasena": pass
    });
    //String mensaje=obtenercorreo(context, txtnombre.text, txtemail.text) as String;
    var url2 = "http://parkii.tk/API/obtenercorreo.php";
    final response2 = await http.post(url2, body: {
      "email": txtemail.text,
      "nombre":txtnombre.text,

    });

    String username = "charlshsx@gmail.com";//Your Email;
    String password = "199314hsxaux";

    final smtpServer = gmail(username, password);
    // Creating the Gmail server

    // Create our email message.
    final message = Message()
      ..from = Address(username)
      ..recipients.add(txtemail.text) //recipent email
      ..subject = 'Recuperacion de contraseña - ${DateTime.now().day}' //subject of the email
      ..text = 'Este correo se a enviado para acttualizar tu contraseña\nSi tu no as solicitado el cambio de contraseña ignora este correo.' //body of the email
      ..html = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>"
          "    <html xmlns='http://www.w3.org/1999/xhtml'>"
          "    <head>"
          "    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css' integrity='sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm' crossorigin='anonymous'>"
          "    <meta http-equiv='Content-Type' content='text/html; charset=utf-8' />"
          "    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no'>"
          "    <style type='text/css'>"
          "        .ExternalClass,.ExternalClass div,.ExternalClass font,.ExternalClass p,.ExternalClass span,.ExternalClass td,h1,img{line-height:100%}h1,h2{display:block;font-family:Helvetica;font-style:normal;font-weight:700}#outlook a{padding:0}.ExternalClass,.ReadMsgBody{width:100%}a,blockquote,body,li,p,table,td{-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%}table,td{mso-table-lspace:0;mso-table-rspace:0}img{-ms-interpolation-mode:bicubic;border:0;height:auto;outline:0;text-decoration:none}table{border-collapse:collapse!important}#bodyCell,#bodyTable,body{height:100%!important;margin:0;padding:0;width:100%!important}#bodyCell{padding:20px;}#templateContainer{width:800px;border:1px solid #ddd;background-color:#fff}#bodyTable,body{background-color:#FAFAFA}h1{color:#202020!important;font-size:26px;letter-spacing:normal;text-align:left;margin:0 0 10px}h2{color:#404040!important;font-size:20px;line-height:100%;letter-spacing:normal;text-align:left;margin:0 0 10px}h3,h4{display:block;font-style:italic;font-weight:400;letter-spacing:normal;text-align:left;margin:0 0 10px;font-family:Helvetica;line-height:100%}h3{color:#606060!important;font-size:16px}h4{color:grey!important;font-size:14px}.headerContent{background-color:#f8f8f8;border-bottom:1px solid #ddd;color:#505050;font-family:Helvetica;font-size:20px;font-weight:700;line-height:100%;text-align:left;vertical-align:middle;padding:0}.bodyContent,.footerContent{font-family:Helvetica;line-height:150%;text-align:left;}.footerContent{text-align:center}.bodyContent pre{padding:15px;background-color:#444;color:#f8f8f8;border:0}.bodyContent pre code{white-space:pre;word-break:normal;word-wrap:normal}.bodyContent table{margin:10px 0;background-color:#fff;border:1px solid #ddd}.bodyContent table th{padding:4px 10px;background-color:#f8f8f8;border:1px solid #ddd;font-weight:700;text-align:center}.bodyContent table td{padding:3px 8px;border:1px solid #ddd}.table-responsive{border:0}.bodyContent a{word-break:break-all}.headerContent a .yshortcuts,.headerContent a:link,.headerContent a:visited{color:#1f5d8c;font-weight:400;text-decoration:underline}#headerImage{height:auto;max-width:600px;padding:20px}#templateBody{background-color:#fff}.bodyContent{color:#505050;font-size:14px;padding:20px}.bodyContent a .yshortcuts,.bodyContent a:link,.bodyContent a:visited{color:#1f5d8c;font-weight:400;text-decoration:underline}.bodyContent a:hover{text-decoration:none}.bodyContent .datos{height: 20px}.bodyContent img{display:inline;height:auto;max-width:360px}.footerContent{color:grey;font-size:12px;padding:20px}.footerContent a .yshortcuts,.footerContent a span,.footerContent a:link,.footerContent a:visited{color:#606060;font-weight:400;text-decoration:underline}@media only screen and (max-width:640px){h1,h2,h3,h4{line-height:100%!important}#templateContainer{max-width:800px!important;width:100%!important}#templateContainer,body{width:100%!important}a,blockquote,body,li,p,table,td{-webkit-text-size-adjust:none!important}body{min-width:100%!important}#bodyCell{padding:10px!important}h1{font-size:24px!important}h2{font-size:20px!important}h3{font-size:18px!important}h4{font-size:16px!important}#templatePreheader{display:none!important}.headerContent{font-size:20px!important;line-height:125%!important}.footerContent{font-size:14px!important;line-height:115%!important}.footerContent a{display:block!important}.hide-mobile{display:none;}}"
          "    </style>"
          ""
          "    </head>"
          "    <body leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>"
          "   <center><img src='http://parkii.tk/wp-includes/images/logo-parkii_v2_250x250.png' a/>"
          "  </center>"
          " <H1><center>Parkii SmartControl</center> </H1>"
          "<br>"
          "<br>"
          "<h2><center>Bienvenido "+txtnombre.text+" a tu aplicacion Parkii..!!</center> </h2>"
          "<br>"
          "<h3><center> Haz creado tu cuenta con exito en la aplicacion Parkii</center></h3>"
          "<h3><center>ahora solo necesitas activar la cuenta haciendo click en el siguiente enlace, recuerda ingresar la contraseña creada para tu usuario.!</center></h3>"
          "<br>"
          "<center><a href='http://www.parkii.tk/API/generarcorreo.php?email="+txtemail.text+"&sha="+hash+"' class='btn btn-primary btn-lg active' role='button' aria-pressed='true'>ACTIVA TU CUENTA</a></center>"
          "<center>"
          "<br>"
          "<br>"

          "<center><img src='http://parkii.tk/wp-includes/images/logo-parkii_v2_250x250.png' a/><img src='http://parkii.tk/wp-includes/images/macrointelligent.jpg' a/></center>"

          "<table border='0' cellpadding='0' cellspacing='0' width='100%' height='132px' id='templateFooter' background='images/fondo.jpg'>"
          "<tr>"
          "<td class='footerContent' align='center'>"
          "<a href='https://solucionessysmat3d.com.ve/'>visitanos</a>"
          "<span class='hide-mobile'> | </span>"
          "<a href='https://solucionessysmat3d.com.ve/login-registro/'>accceso para inscribirte</a>"
          "<span class='hide-mobile'> | </span>"
          "<br />"
          "Copyright © macrointeligent, All rights reserved."
          "<p>Diseño <a href='http://www.macrointeligent.cl'>macrointeligent</a> - design </p>"
          "</td>"
          "</tr>"
          "</table>"
          "</body>"
          "</html>"                      ;

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
  String generateMd5() {
    return md5.convert(utf8.encode("hola")).toString();
  }


}
