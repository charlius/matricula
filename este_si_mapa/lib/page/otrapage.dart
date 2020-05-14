import 'dart:convert';

import 'package:estesimapa/page/principal.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:estesimapa/page/editperfil.dart';
import 'package:estesimapa/page/misvehiculos.dart';
import 'package:toast/toast.dart';
import 'package:http/http.dart' as http;
import 'dart:async';
import 'package:scoped_model/scoped_model.dart';
import 'package:estesimapa/models/main.dart';


import '../main.dart';

void main() =>runApp(otrapage());





class otrapage extends StatefulWidget{
  final String text;
  otrapage({Key key, @required this.text}) : super(key: key);

  @override
  _otraPageState createState() => _otraPageState();
}
class _otraPageState extends State<otrapage>{
  TextEditingController txtnombre = new TextEditingController();
  TextEditingController txtapellido = new TextEditingController();
  TextEditingController txttelefono = new TextEditingController();
  TextEditingController txtemail = new TextEditingController();
  //final MainModel dato_correo = " ";

  void initState() {

//    FetchJSON();
  }

  //String corr = "edderhr07@gmail.com";


  @override
  Widget build(BuildContext context) {
    String correo="", nombre="", apellido="" , telefono="";
    bool isData = false;

    TextStyle style = TextStyle(fontFamily: 'Montserrat', fontSize: 12.0);

    final editperfil editarperfil = editperfil();
    final pagevehiculos vehiculos = pagevehiculos();
    String dato_select = "jj";


    TextField Field_nombres(nombres_text) {
      final nombreField = TextField(
        obscureText: false,
        controller: txtnombre ,

        decoration: InputDecoration(
            contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
            hintText: nombres_text,
            enabled: false,
            hintStyle: TextStyle(fontSize: 12.0, color: Colors.black),
            border:
            OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),

      );
      return nombreField;
    }

    TextField Field_telefono(telefono_text) {
    final telefonolField = TextField(
      obscureText: false,
      controller: txttelefono,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: telefono_text,
          enabled: false,
          hintStyle: TextStyle(fontSize: 12.0, color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    return telefonolField;
  }
    
    TextField email_texto(email_text){
      final emailField = TextField(
        obscureText: false,
        controller: txtemail,
        decoration: InputDecoration(
            contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
            hintText: email_text,
            enabled: false,
            hintStyle: TextStyle(fontSize: 12.0 , color: Colors.black),
            border:
            OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))
        ),
      );
      return emailField;
    }

    final misvehiculosButton = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.blueGrey,
      child: MaterialButton(
        minWidth: 200,
        padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () {


           Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => vehiculos),
         );
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


    FetchJSON(String dato_correo) async {


      var Response = await http.post(
        "http://parkii.tk/API/select_usuario.php",
        body: {"correo":  dato_correo},);
      if (Response.statusCode == 200) {
        String responseBody = Response.body;
        var responseJSON = json.decode(responseBody);

        txtemail.text = responseJSON['correo'].toString();
        apellido = responseJSON['apellido'].toString();
        nombre = responseJSON['nombre'].toString();
        txtnombre.text = nombre +" "+ apellido;
        txttelefono.text = responseJSON['telefono'].toString();

        isData = true;
        setState(() {
          print('UI Updated');
        });
      } else {
        print('Something went wrong. \nResponse Code : ${Response.statusCode}');
      }
    }



    return Scaffold(

        appBar: AppBar(
            backgroundColor: Colors.blueGrey,
            actions: <Widget>[
              IconButton(icon: Icon(Icons.settings),
                onPressed:() {
                  showDialog(
                      barrierDismissible: false,
                      context: context,
                      builder: (context) {

                        Future.delayed(Duration(seconds: 2), () {
                          Navigator.of(context).pop(true);
                        });

                        return AlertDialog(
                          title: Image.asset(
                            "assets/cargando_3.gif", height: 100, width: 100,),
                          //title: Text('Cargando' , textAlign: TextAlign.center,) ,
                        );
                      });
                  Navigator.push(
                    context,
                    MaterialPageRoute(builder: (context) => editarperfil),
                  );
                },
              ),
            ],
            title: Text("Perfil",textAlign: TextAlign.center,)
        ),

        backgroundColor: Colors.white,
        body: ScopedModelDescendant<MainModel>(
    // ignore: missing_return
            builder: (BuildContext context, Widget child, MainModel model) {
              String dato_corr = model.name.toString();

              FetchJSON(dato_corr);
              return Center(

      child: new SingleChildScrollView(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[

            Text('Mi Perfil ', textScaleFactor: 1.7,
              style: style.copyWith(color: Colors.black),),
            SizedBox(height: 40.0),
            //SizedBox(height: 5.0),
            Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: <Widget>[
                //SizedBox (height: 10,),
                Text('Nombre ', textScaleFactor: 0.8,
                  style: style.copyWith(color: Colors.black),
                  textAlign: TextAlign.right,
                ),
              ],
            ),
            SizedBox(height: 5.0),
            Field_nombres(nombre + " " + apellido),

            SizedBox(height: 5.0),
            Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: <Widget>[
                SizedBox(height: 10,),
                Text('Telefono ', textScaleFactor: 0.8,
                  style: style.copyWith(color: Colors.black),
                  textAlign: TextAlign.right,),
              ],
            ),
            SizedBox(height: 5.0),
            Field_telefono(telefono),

            SizedBox(height: 5.0),
            Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: <Widget>[
                SizedBox(height: 10,),
                Text('Email ', textScaleFactor: 0.8,
                  style: style.copyWith(color: Colors.black),
                  textAlign: TextAlign.right,),
              ],
            ),
            SizedBox(height: 5.0),
            email_texto(correo),
            SizedBox(height: 20.0),
            misvehiculosButton,
            SizedBox(height: 150.0),
            cerrarsesionButton,
            SizedBox(height: 0.0),
          ],

        ),

      ),
              );
    }), // This trailing comma makes auto-formatting nicer for build methods.
    );
  }
}

