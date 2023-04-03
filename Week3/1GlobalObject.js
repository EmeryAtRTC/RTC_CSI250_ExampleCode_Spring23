//In JavaScript we have access to something called the global object
//This is also referred to as the window

//There is an easier way to write strings ` ` using the backticks
console.log(`Logging the global object`);
console.log(window);
console.log(this);

//The window contains a lot of use properties and functions
//alert(`Alert is part of the window`);
//window.alert(`This is the same function`);
//Any method or property you have been using so far is probably
//part of the window prompt()

//Var or a variable without let or var will be added to the
//window
var x = 3;
y = 4;
let z = 5;
//You can accidentall overwrite properties in the global 
//object if you use var 
//innerHeight = "Josh";
//innerHeight and innerWidth give you screen size
console.log(window.innerHeight);
console.log(innerWidth); 

//navigator in the window
console.log(navigator);
//location contains info about the url
console.log(location);
