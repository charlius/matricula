import 'package:estesimapa/page/principal.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:estesimapa/page/otrapage.dart';

import '../main.dart';

class editperfil extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    TextStyle style = TextStyle(fontFamily: 'Montserrat', fontSize: 15.0);


    final otrapage perfil = otrapage();

    final nombrefield = TextField(
      obscureText: false,

      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Enrique Andres",
          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),

    );

    final telefonofield = TextField(

      obscureText: false,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "+56989676543",

          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final emailfield = TextField(
      obscureText: false,

      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "castroarias@gmail.com",

          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final apellidofield = TextField(
      obscureText: false,

      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Arias Castro",

          hintStyle: TextStyle(fontSize: 15.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );


    final guardarcambiosButton = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.blueGrey,
      child: MaterialButton(
        minWidth: 200,
        padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => BottomNavBar()),
          );
        },
        child: Text("Guardar cambios",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );






    return Scaffold(

        appBar: AppBar(leading: IconButton(
          icon: Icon(Icons.keyboard_backspace) ,
          onPressed: () {
            Navigator.pop(
              context,
              MaterialPageRoute(builder: (context) => perfil),
            );
          },
        ),
            backgroundColor: Colors.blueGrey,
            title: Text("Modificar mi perfil",)
        ),

        backgroundColor: Colors.white,
        body: Center(
          child: new SingleChildScrollView(
            child: Column(


              children: <Widget>[

                Icon(Icons.person , size: 150,),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('Nombres ',textScaleFactor: 1.0 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                //Text('Mi Perfil ',textScaleFactor: 1.7 , style: style.copyWith(color: Colors.white),),
                SizedBox(height: 5.0),
                nombrefield,
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('Apellidos ',textScaleFactor: 1.0 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                apellidofield,
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('Telefono ',textScaleFactor: 1.0 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                telefonofield,
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('Email ',textScaleFactor: 1.0 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                emailfield,
                SizedBox(height: 40.0),
                guardarcambiosButton ,

              ],
            ),
          ),
        ) // This trailing comma makes auto-formatting nicer for build methods.
    );
  }
}