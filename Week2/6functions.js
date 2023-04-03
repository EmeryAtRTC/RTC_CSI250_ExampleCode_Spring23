//Any code not in a function runs automatically
helloWorld("Josh");
helloWorld(2);
helloWorld(2 < 5);
helloWorld();
//basic function - "Hoisting"
//this is hoisted to the top of the document
//I can call it before I defined
function helloWorld(name = 'NoName'){
    console.log('Hello World ' + name);
}


//function expression
//Create a variable and set it = to a function
//function expressions are not hoisted
const calcVolume = function(length, width, height){
    return length * width * height;
}

let volume = calcVolume(4, 2, 7);
console.log('The volume is ' + volume);
//Goes to
//Arrow function
//IIFE Immediately Invokable Function Expression
((input) => {
    console.log('Arrow Function ' + input);
})('Hello');

//arrow function with 2 parameters
const areaTriangle = (base, height) => base * height / 2;

//arrow function with one parameter
const logger = input => console.log(input);

logger("arrow function one parameter")

console.log(areaTriangle(5, 10));