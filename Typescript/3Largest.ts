let numberArray = [10,20,30];

console.log(" Maximum number : " + numberArray.reduce((a,b)=>{return Math.max(a,b)}));

numberArray.sort((a,b)=>{return b - a});