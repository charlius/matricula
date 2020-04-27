import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';



class desp extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => despl();
}
class despl extends State<desp> {
//  List<String> _locations = ['Please choose a location', 'A', 'B', 'C', 'D']; // Option 1
//  String _selectedLocation = 'Please choose a location'; // Option 1
  List<String> _locations = ['nissan', 'chevrolet', 'toyota', 'kia']; // Option 2
  String _selectedLocation; // Option 2


  SizedBox imagensubir(url) {
    final imagenp = SizedBox(
      width: 150,
      child: Image.asset(url,
        fit: BoxFit.contain,
      ),
    );
    return imagenp;
  }

  MaterialApp imagenes() {
    final imagenscaz = MaterialApp(
      home : Scaffold(
          body: Center(
            child: Column(
                children: <Widget>[
                  SizedBox(height: 100,),
                  Text(
                    'boton presionado',
                  ),
                ]
            ),
          )
      ),
    );
    return imagenscaz;
  }


  @override
  Widget build(BuildContext context) {
    TextStyle style = TextStyle(fontFamily: 'Montserrat', fontSize: 12.0);
    return MaterialApp(
        home: Scaffold(
          body: Center(
            child: Column(
                children: <Widget>[
                  SizedBox(height: 100,),
                  imagensubir("assets/barrera_arriba.png"),
                  SizedBox(height: 200,),
                  MaterialButton(
                    minWidth: 200.0,
                    height: 40.0,
                    onPressed: () {
                      showDialog(
                          context: context,
                          builder: (BuildContext context){
                            return AlertDialog (
                              title: Text ("Subiendo", textAlign: TextAlign.center,),
                              content: Image.asset("assets/subir_gif.gif"),
                            );
                          }
                      );
                    },
                    color: Colors.blueGrey,
                    child: Text('Subir Barrera', style: TextStyle(color: Colors.white)),
                  ),
                  SizedBox(height: 20),
                  MaterialButton(
                    minWidth: 200.0,
                    height: 40.0,
                    onPressed: () {
                      showDialog(
                          context: context,
                          builder: (BuildContext context){
                            return AlertDialog (
                              title: Text ("Bajando" , textAlign: TextAlign.center,),
                              content: Image.asset("assets/bajar_gif.gif"),
                            );
                          }
                      );
                    },
                    color: Colors.blueGrey,
                    child: Text('Bajar Barrera', style: TextStyle(color: Colors.white)),
                  ),
                ]
            ),
          ),
        )
    );
  }
}