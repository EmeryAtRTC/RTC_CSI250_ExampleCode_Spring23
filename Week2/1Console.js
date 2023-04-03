//Comments in javascript
/* 
    Multi-line comment
*/
// Ctrl + / to comment or uncomment

console.log("Hello World");
//log a number
console.log(7);
//create and log a variable
let input = "Josh";
console.log(input);
//variables can change data types
input = 10;
console.log(input);
//log boolean variables
console.log(5 < 2);
console.log(10 == 10);
//create and log an array
let array = [1, 2, 3, 4];
//I can directly log an array
console.log(array);
//We have a data object called a map
let map = {x: 10, y: 20};
console.log(map);
//typeof - Check the data type of a variable
console.log(typeof(input));
console.log(typeof(map));
//Im gonna call a method that does not exist
//fakeMethod();
//any code in a js file that is not in a functions
//will run automatically
myFunction();
function myFunction(){
    alert("Hello from myFunction");
}