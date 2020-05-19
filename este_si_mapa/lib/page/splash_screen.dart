import 'package:flutter/material.dart';
import 'dart:async';
import 'package:shimmer/shimmer.dart';
//import 'package:splash_screen_demo/home_screen.dart';
//import 'package:splash_screen_demo/login_screen.dart';
import 'package:estesimapa/page/login/login.dart';



class SplashScreen extends StatefulWidget {
  @override
  _SplashScreenState createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {

  @override
  void initState() {
    super.initState();

    _mockCheckForSession().then(
            (status) {
          if (status) {
            _navigateToHome();
          } else {
            _navigateToLogin();
          }
        }
    );
  }


  Future<bool> _mockCheckForSession() async {
    await Future.delayed(Duration(milliseconds: 5000), () {});

    return true;
  }

  void _navigateToHome() {
    Navigator.of(context).pushReplacement(
        MaterialPageRoute(
            builder: (BuildContext context) => login()
        )
    );
  }

  void _navigateToLogin() {
    Navigator.of(context).pushReplacement(
        MaterialPageRoute(
            builder: (BuildContext context) => login()
        )
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.orange,
      body: Container(
        child: Stack(
          alignment: Alignment.center,
          children: <Widget>[
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[

                Opacity(
                  opacity: 0.5,
                  //child: Image.asset('assets/logo-parkii_v2_250x250.png')
                ),
                SizedBox(height: 10,),
              ],
            ),
            Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: <Widget>[
                SizedBox(
                  height: 155.0,
                  child: Image.asset(
                    "assets/logo-parkii_v2_250x250.png",
                    fit: BoxFit.contain,
                  ),
                ), // Here place your app logo, tagline etc..

                Padding(
                  padding: EdgeInsets.only(
                    top: 30,
                    bottom: 30,
                  ),
                ),
                // Here place a gif or a loader as I did.
                CircularProgressIndicator(
                  backgroundColor: Colors.white,
                ),
              ],
            ),


          ],
        ),
      ),
    );
  }
}