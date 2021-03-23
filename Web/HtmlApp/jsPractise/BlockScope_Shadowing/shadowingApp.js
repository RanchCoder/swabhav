var a = 10;
let b = 20;
console.log(`outside block value of a : ${a} , b : ${b}`);
{
    var a = 100;
    let b = 200;
    
console.log(`inside block value of a : ${a} , b : ${b}`);
}

console.log(`outside block value of a : ${a} , b : ${b}`);