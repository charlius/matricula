import 'package:flutter/material.dart';
import 'package:curved_navigation_bar/curved_navigation_bar.dart';
//import 'package:flutter1/Page/ajustes.dart';
import 'package:estesimapa/page/otrapage.dart';
import 'package:estesimapa/page/proveedor.dart';
import 'package:estesimapa/page/mapa.dart';
import 'package:estesimapa/page/login/login.dart';

//import 'package:flutter1/Page/estacion.dart';
//import 'package:flutter1/Page/otrapage.dart';
//import 'package:flutter1/Page/proveedor.dart';

void main() => runApp(MaterialApp(home: BottomNavBar()));

class BottomNavBar extends StatefulWidget {
  @override
  _BottomNavBarState createState() => _BottomNavBarState();

}

class _BottomNavBarState extends State<BottomNavBar> {

  int pageIndex = 0;

  //GlobalKey _bottomNavigationKey = GlobalKey();

  final MapPage mmap = MapPage();
  final desp prov = desp();
  final otrapage perfil = otrapage();
  //final estacion estacio = estacion();
  //final otrapage otra = otrapage();

  Widget showPage = new MapPage();

  Widget seleccion(int page){
    switch (page) {
      case 0:
        return mmap;
        break;
      case 1:
        return prov;
        break;
      case 2:
        return perfil;
        break;
      case 3:
     // return ajust;
        break;
      case 4:
      //return otra;
        break;
      default:
        return new Container(
          child: new Center(
            child: new Text(
              'no ha seleccionado pagina',
              style: new TextStyle(fontSize: 30),
            ),
          ),
        );
    }
  }

  @override
  Widget build(BuildContext context) {

    return Scaffold(
        bottomNavigationBar: CurvedNavigationBar(
          //key: _bottomNavigationKey,
          index: pageIndex,
          height: 50.0,
          items: <Widget>[
            Icon(Icons.call_split, size: 30,),
            Icon(Icons.format_strikethrough, size: 30),
            Icon(Icons.perm_identity, size: 30),
          ],
          color: Colors.blueGrey,
          buttonBackgroundColor: Colors.blueGrey,
          backgroundColor: Colors.white,
          animationCurve: Curves.easeInOut,
          animationDuration: Duration(milliseconds: 600),
          onTap: (int tappedIndex) {
            setState(() {
              showPage = seleccion(tappedIndex);
            });
          },
        ),
        body: Container(
          color: Colors.blueGrey,
          child: Center(
            child: showPage,
            /*child: Column(
              children: <Widget>[
                Text(page.toString(), textScaleFactor: 10.0),
                RaisedButton(
                  color: Colors.yellow,
                  child: Text('Opcion:'),
                  onPressed: () {
                    final CurvedNavigationBarState navBarState =
                        _bottomNavigationKey.currentState;
                    navBarState.setPage(1);
                  },
                )
              ],
            ),*/
          ),
        ));
  }
}


