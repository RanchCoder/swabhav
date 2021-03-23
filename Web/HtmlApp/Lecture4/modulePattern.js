function makeStudent() {
  var obj = {};
  var _rollNo, _name;
  obj.setRollno = function (rollNo) {
    if (rollNo > 0) {
      _rollNo = rollNo;
    }
  };
  obj.setName = function (name) {
    _name = name;
  };
  obj.getDetails = function () {
    return "Roll no:" + _rollNo + " Name: " + _name;
  };
  return obj;
}

var s1 = makeStudent();
s1.setRollno(1);
s1.setName("Abc");

console.log(s1);
console.log(s1.getDetails());
