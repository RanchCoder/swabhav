var found = true;
var grade = 4.5;
var firstname = "vishal";
console.log("boolean : " + found + " , number : " + grade + " , string : " + firstname);
function greet() {
    console.log("Hello user , this is a function");
}
greet();
var arr = ["a", "b", "c"];
console.log("array items");
arr.forEach(function (item) { return console.log(item); });
