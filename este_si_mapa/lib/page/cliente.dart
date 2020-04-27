import 'package:flutter/material.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import 'principal.dart';

class otrapage extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    TextStyle style = TextStyle(fontFamily: 'Montserrat', fontSize: 20.0);

    var screenSize = MediaQuery.of(context).size;//sacar el largo y ancho de la pantalla
    var width = screenSize.width;
    var height = screenSize.height;

    final nombrefield = TextField(
      obscureText: false,

      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Nombre",
          hintStyle: TextStyle(fontSize: 20.0 , color: Colors.white),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),

    );

    final telefonofield = TextField(

      obscureText: false,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Telefono",
          hintStyle: TextStyle(fontSize: 20.0 , color: Colors.white),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final emailfield = TextField(
      obscureText: false,

      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Email",
          hintStyle: TextStyle(fontSize: 20.0 , color: Colors.white),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final misvehiculosButton = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Color(0xff01A0C7),
      child: MaterialButton(
        minWidth: MediaQuery.of(context).size.width,
        padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => BottomNavBar()),
          );
        },
        child: Text("Mis vehiculos",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );

    final mediodepagoButton = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Color(0xff01A0C7),
      child: MaterialButton(
        minWidth: MediaQuery.of(context).size.width,
        padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => BottomNavBar()),
          );
        },
        child: Text("Medio de pago",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );

    final cerrarsesionButton = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Color(0xff01A0C7),
      child: MaterialButton(
        minWidth: MediaQuery.of(context).size.width,
        padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => BottomNavBar()),
          );
        },
        child: Text("Cerrar sesion",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );



    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.blueGrey,


        // Here we take the value from the MyHomePage object that was created by
        // the App.build method, and use it to set our appbar title.
        title:  FloatingActionButton(

          child: Icon(Icons.error),

        ),
      ),


      backgroundColor: Colors.blueGrey,
      body: Center(


        child: Column(

          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[

            SizedBox(height: 10.0 ),
            Text('Mi Perfil ',textScaleFactor: 1.5 , style: style.copyWith(color: Colors.white),),
            SizedBox(height: 40.0),
            nombrefield,
            SizedBox(height: 15.0),
            telefonofield,
            SizedBox(height: 15.0),
            emailfield,
            SizedBox(height: 30.0),
            misvehiculosButton,
            SizedBox(height: 10.0),
            mediodepagoButton,
            SizedBox(height: 10.0),
            cerrarsesionButton,
            SizedBox(
              height: height,
            )
          ],
        ),
      ),
      // This trailing comma makes auto-formatting nicer for build methods.
    );
  }
}