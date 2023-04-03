//Exceptions are how developers talk to each other

//call a function that does not exist
//We can wrap it in a try
try{
    //calculateArea(4, 5);
    input.indexOf("A");
    //console.log("THis will not run");
}
//every try has to have a catch
catch(error){
    console.log(error);
    console.log(error.name);
    console.log(error.message);
    if(error instanceof ReferenceError){
        console.log("This is referenceError");
    }
}
//finally - finally always runs no matter what
finally{
    console.log("This always runs");
}

console.log("Start SumArray()");
let numbers = [5, 6, 7, 8];
//try
try{
    let sum = sumArray(numbers, 5, 4);
    console.log(`The sum is ${sum}`);
}
catch(exception){
    console.log(exception);
}

//lets make a function that adds up all elements of an array
//between two indices
function sumArray(numbers, startIndex, endIndex){
    if(startIndex < 0 || startIndex > endIndex){
        throw new RangeError(`${startIndex} was not in the bounds of the array`);
    }
    if(endIndex < 0 || endIndex > numbers.length){
        throw new RangeError(`${endIndex} is not in the bounds of the array`);
    }
    let sum = 0;
    for(let i = startIndex; i < endIndex; i++){
        sum += numbers[i];
    }
    return sum;
}

try{
    let num1 = validateInput('5');
    //we know logicall if we get here
    //that num1 has a value and it is numeric
    console.log(num1);
}
catch(exception){
    console.log(exception.message);
}
//As excercise
//write a function that takes in a string from the user ie: prompt()
//Check that they actually typed something in
//Check that it can be converted to an number
//Throw the right exception if you cannot convert to number
function validateInput(input){
    //checks input is empty string, if null
    if(!input){
        throw new TypeError(`${input} did not contain a value ${typeof(input)}`);
    }    
    if(!Number(input)){
        throw new TypeError(`${input} did not contain a number ${typeof(input)}`);
    }    
    return Number(input);
}

console.log(window.document);
