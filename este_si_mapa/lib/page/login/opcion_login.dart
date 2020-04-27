import 'file:///C:/Users/user/Documents/GitHub/este_si_mapa/lib/page/login/login.dart';
import 'package:estesimapa/page/principal.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/painting.dart';

class opcion_login extends StatefulWidget {
  @override
  _opcion_loginState createState() => _opcion_loginState();
}
final emailField = TextField(
  obscureText: true,

  decoration: InputDecoration(
      border: OutlineInputBorder()
  ),
);

class _opcion_loginState extends State<opcion_login> {
  @override
  Widget build(BuildContext context) {

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
                            creartextfield("patente"),
                            Material(
                                borderRadius: BorderRadius.circular(30.0),
                                color: Colors.blueGrey,
                                child:MaterialButton(
                                  onPressed: () {
                                    Future.delayed(const Duration(milliseconds: 200), () => showAlert(context));
                                  },
                                  minWidth: 280,
                                  padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                                  child: Text("verificar"),
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
        child: Text("invitado",
            textAlign: TextAlign.center,
        )
      ),
    );

    final boton_residente = new  Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.blueGrey,
      child: MaterialButton(
          minWidth: 280,
          padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          onPressed: () {
            Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => MyApp())
            );
          },
          child: Text("residente",
            textAlign: TextAlign.center,
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


  TextField creartextfield(texto){
    final emailField = TextField(
      obscureText: true,
      enabled: false,
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
                        creartextfield("nombre y apellido"),
                        SizedBox(height: 10.0),
                        Text(
                            "ingresa tu numero telefonico",textScaleFactor: 1.0 ,  textAlign: TextAlign.right
                        ),
                        creartextfield("9 9999999"),
                        SizedBox(height: 10.0),
                        Material(
                            borderRadius: BorderRadius.circular(30.0),
                            color: Colors.blueGrey,
                            child:MaterialButton(

                              minWidth: 280,
                              padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
                              child: Text("ingresar"),
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
