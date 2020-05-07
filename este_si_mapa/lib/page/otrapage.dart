import 'dart:convert';

import 'package:estesimapa/page/principal.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:estesimapa/page/editperfil.dart';
import 'package:estesimapa/page/misvehiculos.dart';
import 'package:toast/toast.dart';
import 'package:http/http.dart' as http;
import 'dart:async';

import '../main.dart';

void main() =>runApp(otrapage(persona : fetchPost()));

Future<Persona> fetchPost()async{
  final response = await http.get("http://parkii.tk/API/select_usuario.php");
  if (response.statusCode == 200){
    return Persona.fromJson(json.decode(response.body));

  }else{
    throw Exception ("fallo");
  }
}



class Persona{

  final String correo ;
  final String nombre;
  final String telefono;

  Persona({this.correo, this.nombre, this.telefono});
  factory Persona.fromJson(Map<String,dynamic> json){
    return Persona(
      correo: json['correo'],
      nombre: json['nombre'],
      telefono: json['telefono'],

    );
  }

}


class otrapage extends StatelessWidget {

  final Future<Persona> persona;
  otrapage({ Key key, this.persona }) :super (key: key);

  @override
  Widget build(BuildContext context) {
    TextStyle style = TextStyle(fontFamily: 'Montserrat', fontSize: 12.0);

    final editperfil editarperfil = editperfil();
    final pagevehiculos vehiculos = pagevehiculos();
    String dato_select = "jj";



    final nombrefield = TextField(
      obscureText: false,

      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Nombre",
          enabled: false,
          hintStyle: TextStyle(fontSize: 12.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),

    );

    final telefonofield = TextField(

      obscureText: false,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "912345678",
          enabled: false,
          hintStyle: TextStyle(fontSize: 12.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final emailfield = TextField(
      obscureText: false,

      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "correo@gmail.com",
          enabled: false,
          hintStyle: TextStyle(fontSize: 12.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final misvehiculosButton = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.blueGrey,
      child: MaterialButton(
        minWidth: 200,
        padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () {

         dato_select= "nuevo";
          // Navigator.push(
           // context,
           // MaterialPageRoute(builder: (context) => vehiculos),
         // );
        },
        child: Text("Mis vehiculos",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );



    final cerrarsesionButton = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.red,
      child: MaterialButton(
        minWidth: 200,
        padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () {
          //Navigator.push(
            //context,
            //MaterialPageRoute(builder: (context) => BottomNavBar()),
          //);
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
            actions: <Widget>[
              IconButton(icon: Icon(Icons.settings),
                onPressed:() {
                  Navigator.push(
                    context,
                    MaterialPageRoute(builder: (context) => editarperfil),
                  );
                },
              ),
            ],
            // Here we take the value from the MyHomePage object that was created by
            // the App.build method, and use it to set our appbar title.
            title: Text("Perfil",textAlign: TextAlign.center,)
        ),

        backgroundColor: Colors.white,
        body: Center(

          child: new SingleChildScrollView(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                Text('Mi Perfil ',textScaleFactor: 1.7 , style: style.copyWith(color: Colors.black),),
                SizedBox(height: 40.0),
                //SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    //SizedBox (height: 10,),
                    Text('Nombre ',textScaleFactor: 0.8 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                nombrefield,
                Material(
                    borderRadius: BorderRadius.circular(30.0),
                    color: Colors.blueGrey,
                    child:MaterialButton(
                      onPressed: (){

                        SizedBox(height: 15);

                        new FutureBuilder<Persona>(
                          future: persona,
                          // ignore: missing_return
                          builder: (context, snaptshot){
                            if (snaptshot.hasData){
                              Toast.show(
                                  "holo 1",
                                  context,
                                  duration: Toast.LENGTH_LONG,
                                  gravity: Toast.BOTTOM,
                                  backgroundColor: Colors.black,
                                  textColor: Colors.white
                              );
                              return Text(snaptshot.data.nombre);

                            }else if (snaptshot.hasError){
                              Toast.show(
                                  "holo 2",
                                  context,
                                  duration: Toast.LENGTH_LONG,
                                  gravity: Toast.BOTTOM,
                                  backgroundColor: Colors.black,
                                  textColor: Colors.white
                              );
                              return Text("${snaptshot.error}");
                            }
                          },
                        );

                      },
                      minWidth: 280,
                      padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                      child: Text("verfificar"),
                    )

                ),
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('Telefono ',textScaleFactor: 0.8 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                telefonofield,
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('Email ',textScaleFactor: 0.8 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                emailfield,
                SizedBox(height: 20.0),
                misvehiculosButton,
                SizedBox(height: 150.0),
                cerrarsesionButton,
                SizedBox(height: 0.0),
              ],
            ),
          ),
        ) // This trailing comma makes auto-formatting nicer for build methods.
    );
  }
}
