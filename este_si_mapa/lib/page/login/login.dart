//import 'dart:js';

import 'package:estesimapa/models/main.dart';
import 'package:estesimapa/page/cliente.dart';
import 'package:estesimapa/page/login/crear_cuenta.dart';
import 'package:flutter/material.dart';
import 'package:estesimapa/page/principal.dart';
import 'package:mailer/mailer.dart';
import 'package:mailer/smtp_server.dart';
import 'package:scoped_model/scoped_model.dart';
import 'package:toast/toast.dart';
import 'package:http/http.dart' as http;

void main() => runApp(MyApp());

final datoususario = TextEditingController();
final datopass = TextEditingController();




class MyApp extends StatelessWidget {



  // This widget is the root of your application.hola


  @override
  Widget build(BuildContext context) {

    final MainModel _model = MainModel();
    return ScopedModel<MainModel>(
        model: _model,
        child: MaterialApp(
          title: 'Flutter Demo',
          theme: ThemeData(
            primarySwatch: Colors.blue,
          ),
          home: MyHomePage(title: 'Flutter Demo Home Page'),
        ));
  }
}


class MyHomePage extends StatefulWidget {
  MyHomePage({Key key, this.title}) : super(key: key);

  final String title;


  @override
  _MyHomePageState createState() => _MyHomePageState();
}


class _MyHomePageState extends State<MyHomePage> {
  TextEditingController txtemail = new TextEditingController();
  TextEditingController txtemail2 = new TextEditingController();


  TextEditingController txtcontrasena = new TextEditingController();
  TextEditingController txtclavecondominio = new TextEditingController();

  TextStyle style = TextStyle(fontFamily: 'Montserrat', fontSize: 20.0);
   BottomNavBar principal = BottomNavBar();




  @override
  Widget build(BuildContext context, ) {
    return ScopedModelDescendant<MainModel>(

        builder: (BuildContext context, Widget child, MainModel model) {

      var screenSize = MediaQuery.of(context).size; //sacar el largo y ancho de la pantalla
      var width = screenSize.width;
      var height = screenSize.height;

      Future<List> obtenerUsuario() async {


        var url = "http://parkii.tk/API/obtenerUsuario.php";
        final response = await http.post(url, body: {
          "usuario": datoususario.text,
          "contrasena": datopass.text
        });
        if (response.body == "CORRECTO") {
          Toast.show(
              "Bienvenido",
              context,
              duration: Toast.LENGTH_LONG,
              gravity: Toast.BOTTOM,
              backgroundColor: Colors.green,
              textColor: Colors.white

          );
          model.updateName(datoususario.text);
          Navigator.push(
              context,
              MaterialPageRoute(builder: (context) => BottomNavBar())
          );
        } else if (response.body == "ERROR") {
          Toast.show(
              "LOGIN INCORRECTO",
              context,
              duration: Toast.LENGTH_LONG,
              gravity: Toast.BOTTOM,
              backgroundColor: Colors.red,
              textColor: Colors.white
          );
        } else if (response.body == "ERROR ESTADO") {
          Toast.show(
              "CUENTA NO ACTIVADA",
              context,
              duration: Toast.LENGTH_LONG,
              gravity: Toast.BOTTOM,
              backgroundColor: Colors.red,
              textColor: Colors.white
          );
        }
      }


      _validateEmail(String value) {
        if (value.isEmpty) {
          return 'El campo Email no puede estar vacío!';
        }
        // Regex para validación de email
        String p = "[a-zA-Z0-9\+\.\_\%\-\+]{1,256}" +
            "\\@" +
            "[a-zA-Z0-9][a-zA-Z0-9\\-]{0,64}" +
            "(" +
            "\\." +
            "[a-zA-Z0-9][a-zA-Z0-9\\-]{0,25}" +
            ")+";
        RegExp regExp = new RegExp(p);
        if (regExp.hasMatch(value)) {
          return null;
        }
        return 'El Email suministrado no es válido. Intente otro correo electrónico';
      }

      final emailField = TextFormField(
        obscureText: false,
        controller: datoususario,
        validator: _validateEmail,
        keyboardType: TextInputType.emailAddress,
        style: style,
        decoration: InputDecoration(
            contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
            hintText: "Email",
            border: OutlineInputBorder(
                borderRadius: BorderRadius.circular(32.0))),
      );

      final passwordField = TextField(
        controller: datopass,
        obscureText: true,
        style: style,
        decoration: InputDecoration(
            contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
            hintText: "Password",
            border: OutlineInputBorder(
                borderRadius: BorderRadius.circular(32.0))),
      );


      final loginButon = Material(
        elevation: 5.0,
        borderRadius: BorderRadius.circular(30.0),
        color: Colors.blueGrey,
        child: MaterialButton(
          minWidth: MediaQuery
              .of(context)
              .size
              .width,
          padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          onPressed: () {
            String email = datoususario.text;
            String contra = datopass.text;
            if (email.length < 5 || email.length > 200 || contra.length < 2 ||
                contra.length > 50) {
              if (email.length < 5 || email.length > 10) {
                Toast.show(
                    "Email incorrecto",
                    context,
                    duration: Toast.LENGTH_LONG,
                    gravity: Toast.BOTTOM,
                    backgroundColor: Colors.red,
                    textColor: Colors.white
                );
              } else if (contra.length < 2 || contra.length > 50) {
                Toast.show(
                    "Contraseña incorrecta",
                    context,
                    duration: Toast.LENGTH_LONG,
                    gravity: Toast.BOTTOM,
                    backgroundColor: Colors.red,
                    textColor: Colors.white
                );
              }
            } else {
              //datopass.text=" ";
              //datoususario.text="";
              //showAlertDialog(context);
              showDialog(
                  barrierDismissible: false,
                  context: context,
                  builder: (context) {

                    Future.delayed(Duration(seconds: 5), () {
                      Navigator.of(context).pop(true);
                    });

                    return AlertDialog(
                      title: Image.asset(
                        "assets/cargando_3.gif", height: 100, width: 100,),
                      //title: Text('Cargando' , textAlign: TextAlign.center,) ,
                    );
                  });

              obtenerUsuario();
            }
            //Navigator.push(
            //context,
            //MaterialPageRoute(builder: (context) => BottomNavBar()),
          },
          child: Text("Login",
              textAlign: TextAlign.center,
              style: style.copyWith(
                  color: Colors.white, fontWeight: FontWeight.bold)),
        ),
      );
      final crearcuentaButon = Material(
        elevation: 5.0,
        borderRadius: BorderRadius.circular(30.0),
        color: Colors.blueGrey,
        child: MaterialButton(
          minWidth: MediaQuery
              .of(context)
              .size
              .width,
          padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          onPressed: () {
            showAlert(context);
            // Navigator.push(context,MaterialPageRoute(builder: (context) => crear_cuenta()), );
          },
          child: Text("Crear cuenta",
              textAlign: TextAlign.center,
              style: style.copyWith(
                  color: Colors.white, fontWeight: FontWeight.bold)),
        ),
      );
      final txt_recuperar = new FlatButton(
          onPressed: () {
           showAlert_recuperpass(context);
          },
          child: Text(
            'Recuperar contraseña',
            style: TextStyle(
              decoration: TextDecoration.underline,
            ),
          )


      );


      return Scaffold(

          body: SingleChildScrollView(

            child: Center(

              child: Container(
                color: Colors.white70,
                child: Padding(

                  padding: const EdgeInsets.all(36.0),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: <Widget>[
                      SizedBox(
                        height: 155.0,
                        child: Image.asset(
                          "assets/logo_prueba2.png",
                          fit: BoxFit.contain,
                        ),
                      ),
                      SizedBox(height: 45.0),
                      emailField,
                      SizedBox(height: 25.0),
                      passwordField,
                      SizedBox(
                        height: 35.0,
                      ),
                      loginButon,
                      SizedBox(
                        height: 15.0,
                      ),
                      SizedBox(
                        height: 15.0,
                      ),
                      crearcuentaButon,
                      txt_recuperar,
                      SizedBox(
                        height: height,
                      ),

                    ],
                  ),
                ),
              ),
            ),
          )
      );
    });

        }





  void showAlert(BuildContext context) {
    if (true){

    }
    showDialog(context: context,
        builder: (BuildContext context){
          return AlertDialog(
            backgroundColor: Colors.white,
            content: Form(
              child: Container(
                child: new SingleChildScrollView(
                  child: Column(
                    children: <Widget>[
                      SizedBox(height: 10.0),
                      Text(
                          "ingresa la clave de tu condominio",textScaleFactor: 1.0 ,  textAlign: TextAlign.right
                      ),
                     TextField(
                       controller: txtclavecondominio,
                       obscureText: true,
                       style: style,
                       decoration: InputDecoration(
                        contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                      hintText: "clave condominio...",
                          border:
                       OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
                   ),

                      SizedBox(height: 10.0),
                      Material(
                          borderRadius: BorderRadius.circular(30.0),
                          color: Colors.blueGrey,
                          child:MaterialButton(
                            onPressed: () async {
                              var url = "http://parkii.tk/API/select_condominio.php";
                              final response = await http.post(url, body: {
                                "clave": txtclavecondominio.text,
                              });
                              if (response.body == "CORRECTO") {

                                Toast.show(
                                    "CLAVE ACEPTADA",
                                    context,
                                    duration: Toast.LENGTH_LONG,
                                    gravity: Toast.BOTTOM,
                                    backgroundColor: Colors.green,
                                    textColor: Colors.white
                                );

                                Navigator.push
                                  (context,MaterialPageRoute(builder: (context) => crear_cuenta()), );

                                //Navigator.of(context).pop();

                              } else if (response.body == "ERROR") {

                                Toast.show(
                                    "CLAVE INCORRECTA",
                                    context,
                                    duration: Toast.LENGTH_LONG,
                                    gravity: Toast.BOTTOM,
                                    backgroundColor: Colors.red,
                                    textColor: Colors.white
                                );
                              }
                            },
                            minWidth: 280,
                            padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                            child: Text("verfificar" , style: style.copyWith(
                                color: Colors.white, fontWeight: FontWeight.bold , fontSize: 15)),
                          )

                      ),
                    ],
                  ),
                ),

              ),
            ),
          );
        }
    );

  }

  void showAlert_recuperpass(BuildContext context) {
    if (true){

    }
    showDialog(context: context,
        builder: (BuildContext context){
          return AlertDialog(
            backgroundColor: Colors.white,
            content: Form(
              child: Container(
                child: new SingleChildScrollView(
                  child: Column(
                    children: <Widget>[
                      SizedBox(height: 10.0),
                      Text(
                          "ingresa tu correo electronico",textScaleFactor: 1.0 ,  textAlign: TextAlign.right
                      ),
                      TextField(
                        controller: txtemail2,
                        obscureText: false,
                        style: style,
                        decoration: InputDecoration(
                            contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                            hintText: "",
                            border:
                            OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
                      ),

                      SizedBox(height: 10.0),
                      Material(
                          borderRadius: BorderRadius.circular(30.0),
                          color: Colors.blueGrey,
                          child:MaterialButton(
                            onPressed: (){
                              showDialog(
                                  barrierDismissible: false,
                                  context: context,
                                  builder: (context) {

                                    Future.delayed(Duration(seconds: 3), () {
                                      Navigator.of(context).pop(true);
                                    });

                                    return AlertDialog(
                                      title: Image.asset(
                                        "assets/cargando_3.gif", height: 100, width: 100,),
                                      //title: Text('Cargando' , textAlign: TextAlign.center,) ,
                                    );
                                  });
                              obteneremail(context);
                              Future.delayed(Duration(seconds: 4), () {
                                Navigator.of(context).pop(true);
                              });


                            },
                            minWidth: 280,
                            padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                            child: Text("enviar"),
                          )

                      ),
                    ],
                  ),
                ),

              ),
            ),
          );
        }
    );

  }

  Future<List> obteneremail(BuildContext context) async {

    var url = "http://parkii.tk/API/consultaremail.php";
    final response = await http.post(url, body: {
      "email": txtemail2.text,
      //"contrasena": pass
    });

    //String mensaje=obtenercorreo(context, txtnombre.text, txtemail.text) as String;


    //txtcontrasena.text=response.body.toString();
    if(response.body == "correcto") {
      String username = "charlshsx@gmail.com";//Your Email;
      String password = "199314hsxaux";

      final smtpServer = gmail(username, password);
      // Creating the Gmail server

      // Create our email message.
      final message = Message()
        ..from = Address(username)
        ..recipients.add(txtemail2.text) //recipent email
        ..subject = 'Recuperacion de contraseña - ${DateTime.now()}' //subject of the email
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
            "<h2><center>Listo para recuperar el acceso a tu aplicacion Parkii..!!</center> </h2>"
            "<br>"
            "<h3><center> Haz solicitado la recuperacion de tu contraseña/center></h3>"
            "<h3><center>para Actualizar tu contraseña solo necesitas hacer click en el siguiente enlace..!!</center></h3>"
            "<br>"
            "<center><a href='http://parkii.tk/API/cambiar_pass.php?email="+txtemail2.text+"' class='btn btn-primary btn-lg active' role='button' aria-pressed='true'>ACTIVA TU CUENTA</a></center>"
            "<center>"
            "<br>"
            "<br>"

            "<center><img src='http://parkii.tk/wp-includes/images/logo-parkii_v2_250x250.png' a/><img src='http://parkii.tk/wp-includes/images/macrointelligent.jpg' a/></center>"

            "<table border='0' cellpadding='0' cellspacing='0' width='100%' height='132px' id='templateFooter' background='images/fondo.jpg'>"
            "<tr>"
            "<td class='footerContent' align='center'>"
            "<a href=''>visitanos</a>"
            "<span class='hide-mobile'> | </span>"
            "<a href=''>accceso para inscribirte</a>"
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
      Toast.show(
          "se a enviado correctamente el correo",
          context,
          duration: Toast.LENGTH_LONG,
          gravity: Toast.CENTER,
          backgroundColor: Colors.green,
          textColor: Colors.white
      );

    } else if(response.body == "incorrecto") {
      Toast.show(
          "correo incorrecto o no registrado",
          context,
          duration: Toast.LENGTH_LONG,
          gravity: Toast.CENTER,
          backgroundColor: Colors.red,
          textColor: Colors.white
      );
    }
  }
}

