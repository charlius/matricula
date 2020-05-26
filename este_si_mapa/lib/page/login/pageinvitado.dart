import 'dart:convert';

import 'package:estesimapa/models/main.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:toast/toast.dart';
import 'package:scoped_model/scoped_model.dart';
import 'package:http/http.dart' as http;

import '../principal.dart';
import 'login.dart';

void main() => runApp(pageinvitado());

class pageinvitado extends StatefulWidget{
  final String text;
  pageinvitado({Key key, @required this.text}) : super(key: key);

  @override
  _pageinvitadoState createState() => _pageinvitadoState();
}
class _pageinvitadoState extends State<pageinvitado>{

  TextEditingController txt_nombre_invitado = new TextEditingController();
  TextEditingController txt_patente_invitado = new TextEditingController();
  TextEditingController txt_telefono_invitado = new TextEditingController();

  TextStyle style = TextStyle(fontFamily: 'Montserrat', fontSize: 12.0);

  String codigo_condominio ;
  String _mySelection;

  bool _txt1Enabled = false;
  bool _txt2Enabled = true;

  final String url = "http://parkii.tk/API/consulta_condominio_nombre.php";

  List data = List(); //edited line

  Future<String> getSWData() async {
    var res = await http
        .get(Uri.encodeFull(url), headers: {"Accept": "application/json"});
    var resBody = json.decode(res.body);

    setState(() {
      data = resBody;
    });

    print(resBody);

    return "Sucess";
  }

  @override
  void initState() {
    super.initState();
    this.getSWData();
  }



  @override
  Widget build(BuildContext context) {
    return ScopedModelDescendant<MainModel>(
        // ignore: missing_return
        builder: (BuildContext context, Widget child, MainModel model) {

          Future<List> obtenerPatente() async {
            var url = "http://parkii.tk/API/consulta_patente.php";
            final response = await http.post(url, body: {
              "patente": txt_patente_invitado.text,
              "cod_condominio": _mySelection,

            });
            if(response.body == "CORRECTO") {
              Toast.show(
                  "PATENTE ADMITIDA",
                  context,
                  duration: Toast.LENGTH_LONG,
                  gravity: Toast.BOTTOM,
                  backgroundColor: Colors.green,
                  textColor: Colors.white
              );
              model.updateCodCondominio(_mySelection);
              setState((){
                _txt1Enabled  = true;
                _txt2Enabled = false;
              });

            } else if(response.body == "ERROR") {
              //showAlertDialog2(context);
              Toast.show(
                  "PATENTE INCORRECTA",
                  context,
                  duration: Toast.LENGTH_LONG,
                  gravity: Toast.BOTTOM,
                  backgroundColor: Colors.red,
                  textColor: Colors.white
              );
            }else if(response.body == "ERROR ESTADO") {
              //showAlertDialog2(context);
              Toast.show(
                  "VEHICULO DADO DE BAJA",
                  context,
                  duration: Toast.LENGTH_LONG,
                  gravity: Toast.BOTTOM,
                  backgroundColor: Colors.red,
                  textColor: Colors.white
              );
            }
          }

          final VerificarButton = Material(
            elevation: 5.0,
            borderRadius: BorderRadius.circular(30.0),
            color: Colors.greenAccent,
            child: MaterialButton(
              minWidth: 200,
              padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
              onPressed: () {
                showDialog(
                    barrierDismissible: false,
                    context: context,
                    builder: (context) {
                      Future.delayed(Duration(seconds: 2), () {
                        Navigator.of(context).pop();
                      });
                      return AlertDialog(
                        title: Image.asset(
                          "assets/cargando_3.gif", height: 100, width: 100,),
                      );
                    });
                obtenerPatente();
              },
              child: Text("Verificar",
                  textAlign: TextAlign.center,
                  style: style.copyWith(
                      color: Colors.black, fontWeight: FontWeight.bold)),
            ),
          );
          final GuardarButton = Material(
            elevation: 5.0,
            borderRadius: BorderRadius.circular(30.0),
            color: Colors.greenAccent,
            child: MaterialButton(
              minWidth: 200,
              padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
              onPressed: () async {
                if (_txt1Enabled == false){
                  Toast.show(
                      "Verifique patente y condominio antes de ingresar",
                      context,
                      duration: Toast.LENGTH_LONG,
                      gravity: Toast.BOTTOM,
                      backgroundColor: Colors.red,
                      textColor: Colors.white
                  );
                }else if (txt_nombre_invitado.text.length >200 || txt_nombre_invitado.text.length < 5 || txt_telefono_invitado.text.length > 9 || txt_telefono_invitado.text.length <9){
                  Toast.show(
                      "Ingrese los datos correspondientes",
                      context,
                      duration: Toast.LENGTH_LONG,
                      gravity: Toast.BOTTOM,
                      backgroundColor: Colors.red,
                      textColor: Colors.white
                  );
                }else{
                  var url = "http://parkii.tk/API/guardar_invitado.php";

                  final response = await http.post(url, body: {
                    "nombre": txt_nombre_invitado.text,
                    "telefono": txt_telefono_invitado.text,

                  });
                  if(response.body == "ingresado" || response.body == "CORRECTO" ) {
                    Toast.show(
                        "Ingresado Satisfactoriamente",
                        context,
                        duration: Toast.LENGTH_LONG,
                        gravity: Toast.BOTTOM,
                        backgroundColor: Colors.green,
                        textColor: Colors.white
                    );
                    Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => BottomNavBar())
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
                  }
                }},
              child: Text("Ingresar",
                  textAlign: TextAlign.center,
                  style: style.copyWith(
                      color: Colors.black, fontWeight: FontWeight.bold)),
            ),
          );

          return Scaffold(

            appBar: AppBar(
              backgroundColor: Colors.orangeAccent,
              title: Text("Invitado",textAlign: TextAlign.center,style: TextStyle(color: Colors.black)),
              leading: IconButton(
                icon: Icon(Icons.keyboard_backspace,color: Colors.black,) ,
                onPressed: () {
                  Navigator.push(
                      context,
                      MaterialPageRoute(builder: (context) => login())
                  );
                },
              ),
            ),

            backgroundColor: Colors.white,
            body: ScopedModelDescendant<MainModel>(
              // ignore: missing_return
                builder: (BuildContext context, Widget child, MainModel model) {
                  return Center(
                    child: new SingleChildScrollView(
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: <Widget>[
                          Row(
                            mainAxisAlignment: MainAxisAlignment.start,
                            children: <Widget>[
                              SizedBox(height: 10,),
                              Text('Seleccione Condominio', textScaleFactor: 1.0,
                                style: style.copyWith(color: Colors.black),
                                textAlign: TextAlign.right,),
                            ],
                          ),
                          SizedBox(height: 5.0),
                          new DropdownButton(
                              hint: Text('Selecciona Condominio',textAlign: TextAlign.left, textScaleFactor: 1.0,),
                            items: data.map((item) {
                              return new DropdownMenuItem(
                                child: new Text(item['nombre']),
                                value: item['cod_condiminio'].toString(),
                              );
                            }).toList(),
                            onChanged: (newVal) {
                              setState(() {
                                _mySelection = newVal;
                              });
                            },
                            value: _mySelection,
                          ),
                          Row(
                            mainAxisAlignment: MainAxisAlignment.start,
                            children: <Widget>[
                              //SizedBox (height: 10,),
                              Text('Ingrese Patente ', textScaleFactor: 1.0,
                                style: style.copyWith(color: Colors.black),
                                textAlign: TextAlign.right,
                              ),
                            ],
                          ),
                          SizedBox(height: 5.0),
                        TextField(
                          obscureText: false,
                          controller: txt_patente_invitado,
                          decoration: InputDecoration(
                              contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                              labelText: 'Ingrese Patente',
                              enabled: _txt2Enabled,
                              labelStyle: TextStyle(fontSize: 10.0),
                              border:
                              OutlineInputBorder(
                                  borderRadius: BorderRadius.circular(32.0))),
                        ),
                          SizedBox(height: 15.0),
                          VerificarButton,
                          SizedBox(height: 55.0),
                          Row(
                            mainAxisAlignment: MainAxisAlignment.start,
                            children: <Widget>[
                              //SizedBox (height: 10,),
                              Text('Ingrese Nombre y Apellido ', textScaleFactor: 1.0,
                                style: style.copyWith(color: Colors.black),
                                textAlign: TextAlign.right,
                              ),
                            ],
                          ),
                          TextField(
                            obscureText: false,
                            controller: txt_nombre_invitado,
                            decoration: InputDecoration(
                                contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                                labelText: 'Nombre y Apellido',
                                enabled: _txt1Enabled,
                                labelStyle: TextStyle(fontSize:10.0),
                                border:
                                OutlineInputBorder(
                                    borderRadius: BorderRadius.circular(32.0))),
                          ),
                        SizedBox(height: 20.0),
                          Row(
                            mainAxisAlignment: MainAxisAlignment.start,
                            children: <Widget>[
                              //SizedBox (height: 10,),
                              Text('Ingrese Numero Telefonico ', textScaleFactor: 1.0,
                                style: style.copyWith(color: Colors.black),
                                textAlign: TextAlign.right,
                              ),
                            ],
                          ),
                        TextField(
                          obscureText: false,
                          controller: txt_telefono_invitado,
                          decoration: InputDecoration(
                              contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                              labelText: 'Numero Telefono',
                              enabled: _txt1Enabled,
                              labelStyle: TextStyle(fontSize:10.0),
                              border:
                              OutlineInputBorder(
                                  borderRadius: BorderRadius.circular(32.0))),
                        ),
                          SizedBox(height: 22.0),
                          GuardarButton,

                        ],
                      ),
                    ),
                  );
                }), // This trailing comma makes auto-formatting nicer for build methods.
          );



        }
    );
  }

}
