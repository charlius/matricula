import 'package:scoped_model/scoped_model.dart';

class MainModel extends Model {
  String _name = "";
  String _count = "esto es un string 1";

  String get name {
    return _name;
  }

  String get count {
    return _count;
  }

  void updateName(String name) {
    _name = name;
  }

  void incrementCount() {
    _count = "nuevo string 2" ;
    notifyListeners();
  }
}