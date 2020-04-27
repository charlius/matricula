import 'package:estesimapa/page/principal.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:estesimapa/page/otrapage.dart';



import '../main.dart';

class pagevehiculos extends StatefulWidget {

  @override
  State<StatefulWidget> createState() => misautos();

}
class misautos extends State<pagevehiculos> {

  List<String> marcas_auto = ['nissan', 'chevrolet', 'toyota', 'suzuki', 'dodge', 'kia'];
  List<String> color_auto = ['blanco', 'azul', 'rojo', 'amarillo', 'negro', 'plateado'];
  String seleccion_marca;
  String seleccion_color;// Option 2

  @override
  Widget build(BuildContext context) {
    TextStyle style = TextStyle(fontFamily: 'Montserrat', fontSize: 12.0);

    final pagevehiculos vehiculos = pagevehiculos();

    final patentefield = TextField(
      obscureText: false,

      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Patente",
          //enabled: false,
          hintStyle: TextStyle(fontSize: 12.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),

    );

    final marcafield = TextField(

      obscureText: false,
      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Marca",
          //enabled: false,
          hintStyle: TextStyle(fontSize: 12.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final modelofield = TextField(
      obscureText: false,

      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Modelo",
          //enabled: false,
          hintStyle: TextStyle(fontSize: 12.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );
    final colorfield = TextField(
      obscureText: false,

      decoration: InputDecoration(
          contentPadding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Color",
          //enabled: false,
          hintStyle: TextStyle(fontSize: 12.0 , color: Colors.black),
          border:
          OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final registrarButton = Material(
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
        child: Text("Registrar Vehiculo",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );



    String dropdownValue = 'One';

    return Scaffold(


        appBar: AppBar(
            backgroundColor: Colors.blueGrey,
            // Here we take the value from the MyHomePage object that was created by
            // the App.build method, and use it to set our appbar title.
            title: Text("Vehiculos",textAlign: TextAlign.center,)
        ),
        backgroundColor: Colors.white,
        body: Center(



          child: new SingleChildScrollView(
            child: Column(

              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[

                Text('Registrar nuevo vehiculo ',textScaleFactor: 1.3 , style: style.copyWith(color: Colors.black),),
                SizedBox(height: 15.0),
                //SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[

                    //SizedBox (height: 10,),
                    Text('Patente ',textScaleFactor: 0.8 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                patentefield,
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 5,),
                    Text('Marca ',textScaleFactor: 0.8 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,

                  children: <Widget>[


                    new DropdownButton(
                      hint: Text('Marca',textAlign: TextAlign.start, textScaleFactor: 1.0,style: style.copyWith(color: Colors.black)), // Not necessary for Option 1
                      value: seleccion_marca,


                      onChanged: (newValue) {
                        setState(() {
                          seleccion_marca = newValue;
                        });
                      },
                      items: marcas_auto.map((location) {
                        return DropdownMenuItem(
                          child: new Text(location),
                          value: location,
                        );
                      }).toList(),
                    ),
                  ],
                ),

                //marcafield,
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 5,),
                    Text('Modelo ',textScaleFactor: 0.8 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                modelofield,
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 5,),
                    Text('Color ',textScaleFactor: 0.8 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 5.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.center,

                  children: <Widget>[


                    new DropdownButton(
                      hint: Text('Color',textAlign: TextAlign.start, textScaleFactor: 1.0,style: style.copyWith(color: Colors.black)), // Not necessary for Option 1
                      value: seleccion_color,


                      onChanged: (newValue) {
                        setState(() {
                          seleccion_color = newValue;
                        });
                      },
                      items: color_auto.map((location) {
                        return DropdownMenuItem(
                          child: new Text(location),
                          value: location,
                        );
                      }).toList(),
                    ),
                  ],
                ),
                SizedBox(height: 7.0),
                registrarButton,
                SizedBox(height: 7.0),
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: <Widget>[
                    SizedBox (height: 10,),
                    Text('Mis vehiculos ',textScaleFactor: 0.8 , style: style.copyWith(color: Colors.black), textAlign: TextAlign.right,),
                  ],
                ),
                SizedBox(height: 200.0),

              ],
            ),
          ),
        ) // This trailing comma makes auto-formatting nicer for build methods.
    );
  }
}