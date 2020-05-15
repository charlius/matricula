import 'dart:convert';

import 'package:estesimapa/page/principal.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:estesimapa/page/otrapage.dart';
import 'package:toast/toast.dart';
import 'package:http/http.dart' as http;



import '../main.dart';

class pagevehiculos extends StatefulWidget {

  @override
  State<StatefulWidget> createState() => misautos();

}
class misautos extends State<pagevehiculos> {

  List<String> marcas_auto = ['nissan', 'chevrolet', 'toyota', 'suzuki', 'dodge', 'kia'];
  List<String> color_auto = ['blanco', 'azul', 'rojo', 'amarillo', 'negro', 'plateado'];
  List<String> dato_auto;
  Map<String, dynamic>  seleccion_marca;
  String seleccion_color;// Option 2
  int i=1;
  List<dynamic> cont;


  @override
  Widget build(BuildContext context) {
    var n = 2;
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
      color: Colors.greenAccent,
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
                color: Colors.black, fontWeight: FontWeight.bold)),
      ),
    );
    final eliminarButton = Material(
      elevation: 5.0,
      borderRadius: BorderRadius.circular(30.0),
      color: Colors.red,
      child: MaterialButton(
        minWidth: 50,
        padding: EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => BottomNavBar()),
          );
        },
        child: Text("quitar",
            textAlign: TextAlign.center,
            style: style.copyWith(
                color: Colors.white, fontWeight: FontWeight.bold)),
      ),
    );

    autos2(int num){

          var c = new Container(

            //color: Colors.brown,
            padding: EdgeInsets.all(10),
            width: 180,
            decoration: BoxDecoration(
                color: Colors.white,
                border: Border.all(width: 3)
            ),
            child: Column(
              children: <Widget>[
                Text("patente:  "),
                Text("marca:  "),
                Text("modelo: "),
                Text("color:  "),
                SizedBox(height: 30),
                IconButton(
                  icon: Image.asset("assets/basurero.png"),
                  tooltip: 'Increase volume by 10',
                  onPressed: () {
                    setState(() {


                    });
                  },
                ),
                // eliminarButton


              ],
            ),
      );
     for(int i=0;i<3;i++){
       return c ;
     }
    }

    FetchJSON() async {
      String op ="1";
      var Response = await http.post(
        "http://parkii.tk/API/consulta_patente.php",
        body: {"op":  op},);

      if (Response.statusCode == 200) {
        final parsed = json.decode(Response.body);


        //List<String> auto = new List<String>.from(parsed);
        //print(auto.toString());
        // dato_auto= responseJSON['2'];
        Future<List<Container>> lista;
        while(parsed[i.toString()]!= null) {

          i++;



        }




        n= i;
        var isData = true;

      } else {
        print('Something went wrong. \nResponse Code : ${Response.statusCode}');
        Toast.show(
            Response.statusCode.toString(),
            context,
            duration: Toast.LENGTH_LONG,
            gravity: Toast.CENTER,
            backgroundColor: Colors.red,
            textColor: Colors.white
        );
      }
      setState(() {
        print("entro etsas " + i.toString() + " veces");
      });
    }

    autos(int num){

      return Container(

        //color: Colors.brown,
        padding: EdgeInsets.all(10),
        width: 180,
        decoration: BoxDecoration(
            color: Colors.white,
            border: Border.all(width: 3)
        ),
        child: Column(
          children: <Widget>[
            Text("patente:  "),
            Text("marca:  "),
            Text("modelo: "),
            Text("color:  "),
            SizedBox(height: 30),
            IconButton(
              icon: Image.asset("assets/basurero.png"),
              tooltip: 'Increase volume by 10',
              onPressed: () {
                setState(() {


                });
              },
            ),
            // eliminarButton


          ],
        ),
      );
    }


contenedor(){

}





    String dropdownValue = 'One';
    FetchJSON();
    return Scaffold(



        appBar: AppBar(
            backgroundColor: Colors.orangeAccent,

            // Here we take the value from the MyHomePage object that was created by
            // the App.build method, and use it to set our appbar title.
            title: Text("Vehiculos",textAlign: TextAlign.center,style: TextStyle(color: Colors.black),)
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
                SizedBox(height: 15.0),

                Container(

                    height: 180.0,
                  child:
                    ListView(

                      scrollDirection: Axis.horizontal,
                       children: List.generate(i, (index){
                              FetchJSON();
                            return autos(2);
                    }),
                    ),

                ),

              ],

            ),
          ),
        ) // This trailing comma makes auto-formatting nicer for build methods.
    );

  }

  @protected
  @mustCallSuper
  void initState() {
  // FetchJSON();
  }

}


