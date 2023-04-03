let numbers = [5, 6, 7, 8];

//for loop
for(let i = 0; i < numbers.length; i++){
    console.log('The element ' + numbers[i]);
}
//while
let counter = 0;
while (counter < numbers.length){
    console.log('The element ' + numbers[counter]);
    counter++;
}
//foreach loop
//foreach is a method
//a method is a function that runs on an object
//in this case it will run on numbers
//callback function
//foreach takes a function as a parameter
numbers.forEach(display);

//make a function
function display(element){
    console.log(element);
}

//foreach using arrow function
numbers.forEach((element, index) =>
    console.log('The element ' + element + ' The index ' + index));