//import 'dart:js';

import 'package:estesimapa/models/main.dart';
import 'package:estesimapa/page/login/crear_cuenta.dart';
import 'package:flutter/material.dart';
import 'package:estesimapa/page/principal.dart';
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


  // This widget is the home page of your application. It is stateful, meaning
  // that it has a State object (defined below) that contains fields that affect
  // how it looks.

  // This class is the configuration for the state. It holds the values (in this
  // case the title) provided by the parent (in this case the App widget) and
  // used by the build method of the State. Fields in a Widget subclass are
  // always marked "final".

  final String title;

  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  TextEditingController txtemail = new TextEditingController();

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
      // This method is rerun every time setState is called, for instance as done
      // by the _incrementCounter method above.
      //
      // The Flutter framework has been optimized to make rerunning build methods
      // fast, so that you can just rebuild anything that needs updating rather
      // than having to individually change instances of widgets.


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

          model.incrementCount();

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
              datopass.text=" ";
              datoususario.text="";
              //showAlertDialog(context);
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
            Navigator.pushNamed(context, "YourRoute");
          },
          child: Text(
            'Recuperar cuenta',
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
                          "ingresa tu nombre y apellido",textScaleFactor: 1.0 ,  textAlign: TextAlign.right
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
                            onPressed: (){
                              Navigator.push(context,MaterialPageRoute(builder: (context) => crear_cuenta()), );
                            },
                            minWidth: 280,
                            padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                            child: Text("verfificar"),
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



}

