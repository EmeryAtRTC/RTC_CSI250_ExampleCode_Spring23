if(2 < 4){
    console.log('2 is less than 4');
}
//Equality in JavaScript
//If you use === for comparisons everything will behave like C# and Java
//If you use == some strange things can happen
//=== Both the value and the data type has to match
//== JavaScript will try to convert the values to the same data type
if(2 == '2'){
    console.log(`2 equals "2"`);
}
if(2 === '2'){
    console.log("This is not going to run");
}
//!== This is where the data type and value dont have to match
//!= Here there will be conversion
//Truthy and Falsy Values
//Get input from the user using prompt()
let input = prompt("Input a number");
if(Number){
    let number = Number(input);
    number += 10;
    console.log('Number is ' + number);
}
else{
    console.log("You did not type anything in");
}
//Switch
switch(input){
    case "1":
        console.log('You entered 1');
        break;
    case "2":
        console.log('You entered 2');
        break;
    default:
        console.log('You did not enter 1 or 2');
}

//Ternary Operator
//condition ? ActionIfTrue : ActionIfFalse
let number = 5;
let output = number > 10 ? "The number is greater than 10" : "The number is less than 10";
console.log(output);