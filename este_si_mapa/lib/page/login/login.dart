import 'package:estesimapa/page/login/crear_cuenta.dart';
import 'package:flutter/material.dart';
import 'package:estesimapa/page/principal.dart';


void main() => runApp(MyApp());

class MyApp extends StatelessWidget {

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        // This is the theme of your application.
        //
        // Try running your application with "flutter run". You'll see the
        // application has a blue toolbar. Then, without quitting the app, try
        // changing the primarySwatch below to Colors.green and then invoke
        // "hot reload" (press "r" in the console where you ran "flutter run",
        // or simply save your changes to "hot reload" in a Flutter IDE).
        // Notice that the counter didn't reset back to zero; the application
        // is not restarted.
        primarySwatch: Colors.blue,
      ),
      home: MyHomePage(title: 'Flutter Login'),

    );
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
  Widget build(BuildContext context) {
    var screenSize = MediaQuery.of(context).size;//sacar el largo y ancho de la pantalla
    var width = screenSize.width;
    var height = screenSize.height;
    // This method is rerun every time setState is called, for instance as done
    // by the _incrementCounter method above.
    //
    // The Flutter framework has been optimized to make rerunning build methods
    // fast, so that you can just rebuild anything that needs updating rather
    // than having to individually change instances of widgets.

    final emailField = TextField(
      controller: txtemail,
      obscureText: true,
      style: style,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Email",
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final passwordField = TextField(
      controller: txtcontrasena,
      obscureText: true,
      style: style,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Password",
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );



    final loginButon = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.blueGrey,
      child: MaterialButton(
        minWidth: MediaQuery.of(context).size.width,
        padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => BottomNavBar()),
          );
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
        minWidth: MediaQuery.of(context).size.width,
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
      child:  Text(
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

