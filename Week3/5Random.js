//Random numbers are generated with the Math Object
//Math.Random() gives you a random decimal number between 0 and 1
console.log(Math.random());
//If we want a whole number in a given range
//random between 0 and 9
let number = Math.floor(Math.random() * 10);
console.log(number);

let number2 = randomWholeNumber(10, 20);
console.log(number2);

//function that gives random number with min and max
//This is upper bound exclusive
function randomWholeNumber(min, max){
    return Math.floor(Math.random() * (max - min)) + min; 
}