import 'dart:convert';

import 'package:http/http.dart' as http;

class datovehiculo{
  String patente;
  String marca;
  String modelo;
  String color;
  String estado;
  String correo;
  datovehiculo({this.patente, this.marca, this.modelo, this.color, this.estado,this.correo});

  factory datovehiculo.fromJson(Map<String, dynamic> parsedjsn){
    return datovehiculo(
      patente :parsedjsn["patente"],
        marca :parsedjsn["marca"],
      modelo :parsedjsn["modelo"],
      color :parsedjsn["color"],
      estado :parsedjsn["esatado"],
        correo :parsedjsn["correo"]

    );
      }



}