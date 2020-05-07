import 'package:estesimapa/page/login/login.dart';
import 'package:estesimapa/page/principal.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/painting.dart';
import 'package:flutter/services.dart';
import 'package:toast/toast.dart';
import 'package:http/http.dart' as http;

class opcion_login extends StatefulWidget {
  @override
  _opcion_loginState createState() => _opcion_loginState();
}
TextStyle style = TextStyle(fontFamily: 'Montserrat', fontSize: 20.0);
final emailField = TextField(
  obscureText: true,

  decoration: InputDecoration(
      border: OutlineInputBorder()
  ),
);

final datopatente = TextEditingController();
final datonombres = TextEditingController();
final datotelefono = TextEditingController();





final nombrefield = TextFormField(
  obscureText: false,
  controller: datonombres,
  decoration: InputDecoration(
      hintText: "Nombres Y  Apellidos",

      border: OutlineInputBorder()
  ),
);
final telefonofield = TextFormField(
  obscureText: false,
  controller: datotelefono,
  keyboardType: TextInputType.number,
  inputFormatters: <TextInputFormatter>[
    WhitelistingTextInputFormatter.digitsOnly
  ],

  decoration: InputDecoration(
      hintText: "912345678",
      border: OutlineInputBorder()
  ),
);

class _opcion_loginState extends State<opcion_login> {
  @override
  Widget build(BuildContext context) {

    showAlertDialog(BuildContext context){
      Future.delayed(Duration(seconds: 3), () {

        Navigator.pop(context);
        showAlert(context);

      });
      AlertDialog alert=AlertDialog(
        content: new Row(
          children: [
            CircularProgressIndicator(),
            Container(margin: EdgeInsets.only(left: 5),child:Text("Loading" ), ),
          ],
        ),
      );

      showDialog(barrierDismissible: false,
        context:context,
        builder:(BuildContext context){
          return alert;
        },
      );
    }

    showAlertDialog2(BuildContext context){
      Future.delayed(Duration(seconds: 1), () {
        Navigator.pop(context);

      });
      AlertDialog alert=AlertDialog(
        content: new Row(
          children: [
            CircularProgressIndicator(),
            Container(margin: EdgeInsets.only(left: 5),child:Text("Loading" ), ),
          ],
        ),
      );

      showDialog(barrierDismissible: false,
        context:context,
        builder:(BuildContext context){
          return alert;
        },
      );
    }

    Future<List> obtenerPatente() async {
      var url = "http://parkii.tk/API/consulta_patente.php";
      final response = await http.post(url, body: {
        "patente": datopatente.text,

      });
      if(response.body == "CORRECTO") {
        showAlertDialog(context);
        Toast.show(
            "PATENTE ADMITIDA",
            context,
            duration: Toast.LENGTH_LONG,
            gravity: Toast.BOTTOM,
            backgroundColor: Colors.green,
            textColor: Colors.white
        );

        //datopatente.text = "";
        //showAlert(context);
        //Navigator.of(context).pop();


        //Navigator.push(
         // context,
         // MaterialPageRoute(builder: (context) => bienvenida),
       // );
      } else if(response.body == "ERROR") {
        showAlertDialog2(context);
        Toast.show(
            "PATENTE INCORRECTA",
            context,
            duration: Toast.LENGTH_LONG,
            gravity: Toast.BOTTOM,
            backgroundColor: Colors.red,
            textColor: Colors.white
        );
      }else if(response.body == "ERROR ESTADO") {
        showAlertDialog2(context);
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

    final boton_invitado = new  Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(20.0),
      color: Colors.blueGrey,
      child: MaterialButton(
        minWidth: 130,
        padding: EdgeInsets.fromLTRB(10.0, 15.0, 10.0, 15.0),
        onPressed: () {
          showDialog(context: context,
              builder: (BuildContext context){
                return AlertDialog(
                  backgroundColor: Colors.white,
                  content: Form(
                      child: Container(
                        child: new SingleChildScrollView(
                          child: Column(
                          children: <Widget>[
                            Text(
                                "ingresa tu patente",textScaleFactor: 1.0 ,  textAlign: TextAlign.right
                            ),
                            SizedBox(height: 10,),
                            creartextfield("patente"),
                            SizedBox(height: 10,),
                            Material(
                                borderRadius: BorderRadius.circular(30.0),
                                color: Colors.blueGrey,
                                child:MaterialButton(
                                  onPressed: () {
                                     //showAlert(context);
                                    //showAlertDialog(context);
                                    obtenerPatente();
                                  },
                                  minWidth: 280,
                                  padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                                  child: Text("verificar",
                                      style: style.copyWith(
                                      color: Colors.white, fontWeight: FontWeight.bold )),

                                )
                            ),
                          ],
                      ),
                    )
                      )
                  ),
                );
              }
          );
        },
        child: Text("Invitado",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold , fontSize: 15)
        )
      ),
    );

    final boton_residente = new  Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.blueGrey,
      child: MaterialButton(
          minWidth: 150,
          padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          onPressed: () {
            Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => MyApp())
            );
          },
          child: Text("Residente",
            textAlign: TextAlign.center,
              style: style.copyWith(
                  color: Colors.white, fontWeight: FontWeight.bold , fontSize: 15)
          )
      ),
    );

    return Scaffold(
      body: Center(
       child: Container(
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
             boton_invitado,
             SizedBox(height: 45.0),
             boton_residente
           ],
         ),
       ),
      ),
    );
  }
  showAlertDialog(BuildContext context){
    Future.delayed(Duration(seconds: 3), () {
      Navigator.pop(context);
      showAlert(context);
    });
    AlertDialog alert=AlertDialog(
      content: new Row(
        children: [
          CircularProgressIndicator(),
          Container(margin: EdgeInsets.only(left: 5),child:Text("Loading" ), ),
        ],
      ),
    );
    showDialog(barrierDismissible: false,
      context:context,
      builder:(BuildContext context){
        return alert;
      },
    );
  }
  Future<List> GuardarInvitado() async {
    var url = "http://parkii.tk/API/guardar_invitado.php";

    final response = await http.post(url, body: {
      "nombre": datonombres.text,
      "telefono": datotelefono.text,

    });
    if(response.body == "ingresado" || response.body == "CORRECTO" ) {
      showAlertDialogPrincipal(context);
      Toast.show(
          "Ingresado Satisfactoriamente",
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

  showAlertDialogPrincipal(BuildContext context){
    Future.delayed(Duration(seconds: 3), () {
      Navigator.pop(context);
      Navigator.push(
          context,
          MaterialPageRoute(builder: (context) => BottomNavBar())
      );
    });
    AlertDialog alert=AlertDialog(
      content: new Row(
        children: [
          CircularProgressIndicator(),
          Container(margin: EdgeInsets.only(left: 5),child:Text("Loading" ), ),
        ],
      ),
    );

    showDialog(barrierDismissible: false,
      context:context,
      builder:(BuildContext context){
        return alert;
      },
    );
  }


  TextField creartextfield(texto){
    final emailField = TextField(
      obscureText: false,
      controller: datopatente,
      enabled: true,
      decoration: InputDecoration(
        hintText: texto,

          border: OutlineInputBorder()
      ),
    );
    return emailField;
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
                        nombrefield,
                        SizedBox(height: 10.0),
                        Text(
                            "ingresa tu numero telefonico",textScaleFactor: 1.0 ,  textAlign: TextAlign.right
                        ),
                        telefonofield,
                        SizedBox(height: 10.0),
                        Material(
                            borderRadius: BorderRadius.circular(30.0),
                            color: Colors.blueGrey,
                            child:MaterialButton(
                              minWidth: 280,
                              padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                              onPressed: () {
                                if (datonombres.text.length >200 || datonombres.text.length < 5 || datotelefono.text.length > 9 || datotelefono.text.length <9){
                                  Toast.show(
                                      "Ingrese los datos correspondientes",
                                      context,
                                      duration: Toast.LENGTH_LONG,
                                      gravity: Toast.BOTTOM,
                                      backgroundColor: Colors.red,
                                      textColor: Colors.white
                                  );
                                }else{
                                  GuardarInvitado();
                                }},
                              child: Text("Ingresar" ,
                                  style: style.copyWith(
                                  color: Colors.white, fontWeight: FontWeight.bold , fontSize: 15 )),
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