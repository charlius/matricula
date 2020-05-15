import 'dart:convert';

import 'package:estesimapa/models/main.dart';
import 'package:estesimapa/page/principal.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:estesimapa/page/otrapage.dart';
import 'package:flutter/services.dart';
import 'package:scoped_model/scoped_model.dart';
import 'package:http/http.dart' as http;
import 'package:toast/toast.dart';

import '../main.dart';

void main() =>runApp(editperfil());

class editperfil extends StatefulWidget{
  final String text;

  editperfil({Key key, @required this.text}) : super(key: key);

  @override
  _editPerfilState createState() => _editPerfilState();
}


class _editPerfilState extends State<editperfil> {

  TextEditingController txtnombre = new TextEditingController();
  TextEditingController txtapellido = new TextEditingController();
  TextEditingController txttelefono = new TextEditingController();
  TextEditingController txtemail = new TextEditingController();


  void initState() {

//    FetchJSON();
  }

  @override
  Widget build(BuildContext context) {

    TextStyle style = TextStyle(fontFamily: 'Montserrat', fontSize: 15.0);
    final otrapage perfil = otrapage();
    bool isData = false;



    TextField Field_nombres() {
      final nombreField = TextField(
        obscureText: false,
        controller: txtnombre ,

        decoration: InputDecoration(
            contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
            enabled: true,
            hintStyle: TextStyle(fontSize: 12.0, color: Colors.black),
            border:
            OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),

      );
      return nombreField;
    }
    TextField Field_apellido() {
      final apellidoField = TextField(
        obscureText: false,
        controller: txtapellido ,

        decoration: InputDecoration(
            contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
            enabled: true,
            hintStyle: TextStyle(fontSize: 12.0, color: Colors.black),
            border:
            OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),

      );
      return apellidoField;
    }

    TextField Field_telefono() {
      final telefonolField = TextField(
        obscureText: false,
        controller: txttelefono,
        keyboardType: TextInputType.number,
        inputFormatters: <TextInputFormatter>[
          WhitelistingTextInputFormatter.digitsOnly
        ],
        decoration: InputDecoration(
            contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
            enabled: true,
            hintStyle: TextStyle(fontSize: 12.0, color: Colors.black),
            border:
            OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
      );
      return telefonolField;
    }

    TextField Field_email() {
      final emailField = TextField(
        obscureText: false,
        controller: txtemail ,

        decoration: InputDecoration(
            contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
            enabled: false,
            hintStyle: TextStyle(fontSize: 12.0, color: Colors.black),
            border:
            OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),

      );
      return emailField;
    }

    FetchJSON(String dato_correo) async {
      print (dato_correo);

      var Response = await http.post(
        "http://parkii.tk/API/select_usuario.php",
        body: {"correo":  dato_correo},);
      if (Response.statusCode == 200) {
        String responseBody = Response.body;
        var responseJSON = json.decode(responseBody);

        txtemail.text = responseJSON['correo'].toString();
        txtapellido.text = responseJSON['apellido'].toString();
        txtnombre.text = responseJSON['nombre'].toString();
        txttelefono.text = responseJSON['telefono'].toString();

        isData = false;


      } else {
        print('Something went wrong. \nResponse Code : ${Response.statusCode}');
      }
    }


    Future<List> ModificarUsuario() async {
      var url = "http://parkii.tk/API/modificar_usuario.php";

      final response = await http.post(url, body: {
        "nombre": txtnombre.text,
        "apellido": txtapellido.text,
        "telefono": txttelefono.text,
        "email": txtemail.text,
      });
      if( response.body == "CORRECTO" ) {
        Toast.show(
            "Operacion exitosa",
            context,
            duration: Toast.LENGTH_LONG,
            gravity: Toast.BOTTOM,
            backgroundColor: Colors.green,
            textColor: Colors.white
        );

      } else  {
        //   showAlertDialog2(context);
        Toast.show(
            "Error al ingresar",
            context,
            duration: Toast.LENGTH_LONG,
            gravity: Toast.BOTTOM,
            backgroundColor: Colors.red,
            textColor: Colors.white
        );
      }}


    return Scaffold(

        appBar: AppBar(leading: IconButton(
          icon: Icon(Icons.keyboard_backspace,color: Colors.black,) ,
          onPressed: () {
            Navigator.pop(
              context,
              MaterialPageRoute(builder: (context) => perfil),
            );
          },
        ),
            backgroundColor: Colors.orangeAccent,
            title: Text("Modificar mi perfil",style: TextStyle(color: Colors.black),)
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
                      children: <Widget>[

                        Icon(Icons.person, size: 150,),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.start,
                          children: <Widget>[
                            SizedBox(height: 10,),
                            Text('Nombres ', textScaleFactor: 1.0,
                              style: style.copyWith(color: Colors.black),
                              textAlign: TextAlign.right,),
                          ],
                        ),
                        //Text('Mi Perfil ',textScaleFactor: 1.7 , style: style.copyWith(color: Colors.white),),
                        SizedBox(height: 5.0),
                        Field_nombres(),
                        SizedBox(height: 5.0),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.start,
                          children: <Widget>[
                            SizedBox(height: 10,),
                            Text('Apellidos ', textScaleFactor: 1.0,
                              style: style.copyWith(color: Colors.black),
                              textAlign: TextAlign.right,),
                          ],
                        ),
                        SizedBox(height: 5.0),
                        Field_apellido(),
                        SizedBox(height: 5.0),
                        Row(

                          mainAxisAlignment: MainAxisAlignment.start,
                          children: <Widget>[
                            SizedBox(height: 10,),
                            Text('Telefono ', textScaleFactor: 1.0,
                              style: style.copyWith(color: Colors.black),
                              textAlign: TextAlign.right,),
                          ],
                        ),
                        SizedBox(height: 5.0),
                        Field_telefono(),
                        SizedBox(height: 5.0),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.start,
                          children: <Widget>[
                            SizedBox(height: 10,),
                            Text('Email ', textScaleFactor: 1.0,
                              style: style.copyWith(color: Colors.black),
                              textAlign: TextAlign.right,),
                          ],
                        ),
                        SizedBox(height: 5.0),
                        Field_email(),
                        SizedBox(height: 40.0),
                        Material(
                            elevation: 5.0,
                            borderRadius: BorderRadius.circular(30.0),
                            color: Colors.greenAccent,
                            child: MaterialButton(
                              minWidth: 200,
                              padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                              onPressed: () {
                                if (txttelefono.text.length<9 || txttelefono.text.length>9 ||
                                    txtnombre.text.length<6 || txtnombre.text.length>150 ||
                                    txtapellido.text.length < 5 || txtapellido.text.length>150){
                                  Toast.show(
                                      "Datos Invalidos",
                                      context,
                                      duration: Toast.LENGTH_LONG,
                                      gravity: Toast.BOTTOM,
                                      backgroundColor: Colors.red,
                                      textColor: Colors.white
                                  );
                                }else{
                                  ModificarUsuario();
                                  FetchJSON(dato_corr);
                                }

                              },
                              child: Text("Guardar cambios",
                                  textAlign: TextAlign.center,
                                  style: style.copyWith(
                                      color: Colors.black, fontWeight: FontWeight.bold)),
                            )
                        ),
                      ],
                    ),
                  )
              );
            }) // This trailing comma makes auto-formatting nicer for build methods.
    );

  }
}