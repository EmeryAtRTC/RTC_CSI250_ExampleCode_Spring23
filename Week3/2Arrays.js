//An array is a collection of values called elements
//Arrays in JS are gonna be similar to ArrayList in Java or List in C#
const numbers = [1,2];
//access by index
//numbers[0] = 3;
console.log(numbers);
//add elements to the array
//push() adds to the end
numbers.push(3);
numbers.push(4);
numbers.push(5);
console.log(numbers);
//we also have a pop() method
//removes and returns the last element
let removedNumber = numbers.pop();
console.log(numbers);
console.log(removedNumber);
//shift() method removes and returns the first element
let removedNumber2 = numbers.shift();
console.log(numbers);
console.log(removedNumber2);
//unshift() adds to the beginning
numbers.unshift(1);
console.log(numbers);
//splice() removes from a certain point and a given number of elements
let smallerArray = numbers.splice(1, 2);
console.log(numbers);
console.log(smallerArray);
//Here we go to index 1, we remove 0 elements, but we add 5, 6, and 7 to the array
//at index 1
numbers.splice(1, 0, 5, 6, 7);
console.log(numbers);

//for of loop - Closest thing to a traditional foreach loop
for(const x of numbers){
    console.log(`The element is ${x}`);
}
