import 'dart:async';
import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class Job {
  final String cod_vehiculo;
  final String patente;
  final String marca;
  final String modelo;
  final String color;
  final String estado;
  final String cod_usuario;
  final String cod_condominio;

  Job({this.cod_vehiculo, this.patente, this.marca,this.modelo,this.color,this.estado,this.cod_usuario,this.cod_condominio});

  factory Job.fromJson(Map<String, dynamic> json) {
    return Job(
      cod_vehiculo: json['cod_vehiculo'],
      patente: json['patente'],
      marca: json['marca'],
      modelo: json['modelo'],
      color: json['color'],
      estado: json['estado'],
      cod_usuario: json['cod_usuario'],
      cod_condominio: json['cod_condominio']

    );
  }
}

class vehiculosListView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return FutureBuilder<List<Job>>(
      future: _fetchJobs(),
      builder: (context, snapshot) {
        if (snapshot.hasData) {
          List<Job> data = snapshot.data;
          return _jobsListView1(data);
        } else if (snapshot.hasError) {
          return Text("${snapshot.error}");
        }
        return CircularProgressIndicator();
      },
    );
  }

  Future<List<Job>> _fetchJobs() async {

    final jobsListAPIUrl = 'http://parkii.tk/API/consulta_patente.php?op1=1';
    final response = await http.get(jobsListAPIUrl);

    if (response.statusCode == 200) {
      List jsonResponse = json.decode(response.body);
      return jsonResponse.map((job) => new Job.fromJson(job)).toList();
    } else {
      throw Exception('Failed to load jobs from API');
    }
  }

  ListView _jobsListView(data) {
    return ListView.builder(
        itemCount: data.length,
        itemBuilder: (context, index) {
          return _tile(data[index].patente, data[index].marca, IconButton(
              icon: Icon(Icons.delete),
              onPressed:() {
                print("hvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv");
              }));
        });
  }
  ListView _jobsListView1(data) {
    return ListView.builder(
        scrollDirection: Axis.horizontal,
        itemCount: data.length,
        itemBuilder: (context, index) {
          return autos(data[index].patente, data[index].marca, data[index].modelo, data[index].color);
        });
  }


  ListTile _tile(String title, String subtitle, IconButton icon) => ListTile(
      title: Text(title,
          style: TextStyle(
            fontWeight: FontWeight.w500,
            fontSize: 20,
          )),
      subtitle: Text(subtitle),
      leading: icon
  );

  Future<List<Job>> _borrarvehiculo() async {

    final jobsListAPIUrl = 'http://parkii.tk/API/consulta_patente.php?op1=1';
    final response = await http.get(jobsListAPIUrl);

    if (response.statusCode == 200) {
      List jsonResponse = json.decode(response.body);
      return jsonResponse.map((job) => new Job.fromJson(job)).toList();
    } else {
      throw Exception('Failed to load jobs from API');
    }
  }

 Container autos(String patente,String marca, String modelo, String color) =>Container(

    child: Container(

      //color: Colors.brown,
      padding: EdgeInsets.all(10),
      width: 180,
      decoration: BoxDecoration(
          color: Colors.white,
          border: Border.all(width: 3)
      ),
      child: Column(
        children: <Widget>[
          Text("patente:  "+patente),
          Text("marca:  "+marca),
          Text("modelo: "+modelo),
          Text("color:  "+color),
          SizedBox(height: 30),
          IconButton(
            icon: Image.asset("assets/basurero.png"),
            //icon: Icon(Icons.delete),
            tooltip: 'Increase volume by 10',
            
            onPressed: () {



            },
          ),
          // eliminarButton


        ],
      ),
    )
  );
}