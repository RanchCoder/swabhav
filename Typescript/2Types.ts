let found : boolean = true;
let grade : number = 4.5;
let firstname : string = "vishal";

console.log(`boolean : ${found} , number : ${grade} , string : ${firstname}`);

function greet(){
    console.log("Hello user , this is a function");
}
greet();

let arr = ["a","b","c"];

console.log("array items");
arr.forEach(item=>console.log(item));