//JavaScript has a variety of string methods
let input = `Gianni@student.rtc.edu`;
//get a character at a give position
console.log(`The character at index 1: ${input.charAt(1)}`);
//Get the unicode value of a character
console.log(`The code for the character at index 1 ${input.charCodeAt(1)}`);

//loop through a string
// for (let index = 0; index < input.length; index++) {
//     const element = input[index];    
// }
//find the index of a certain character
console.log(`The first . is located at ${input.indexOf('.')}`);
//find the last index of a certain character
console.log(`The last . is located at ${input.lastIndexOf('.')}`);
//index of will also find a word or a string
console.log(`The rtc is located at ${input.indexOf('rtc')}`);
//We might search for something that doesnt exist
console.log(`The index of Josh in input ${input.indexOf('Josh')}`);

//We can replace values
let input2 = input.replace('student.rtc.edu', 'gmail.com');
console.log(`after replace ${input2}`);
//substr() this allows you to cut out values of a string
//This will take everything after the first occurrence of the @ symbol
//substr() is deprecated lets use substring()
let input3 = input.substring(input.indexOf('@') + 1);
console.log(input3);
let input4 = input.substring(input.indexOf('.') + 1, input.lastIndexOf('.'));
console.log(input4);
//split() will a string and return an array of string split on the character you give it
let inputArray = input.split('.');
console.log(inputArray);

//Some strings may be case sensitive and some are not
//take the string and make it upper or lower before we compare
console.log(`We can make a string uppercase ${input.toUpperCase()}`);
console.log(`We can make a string uppercase ${input.toLowerCase()}`);

//we might be interested in all of the indices of a given character
//Lets write a method that finds all the indices of a given character
let indices = findCharacters(input, 'i');
console.log(`The indices of i are ${indices}`);
//calling vowelCount
let vowelCount = countVowels(input);
console.log(`The number of vowels is ${vowelCount}`);

//this function is going to take a string, a character, a starting index
function findCharacters(inputString, searchValue, startIndex = 0){
    let result = [];
    for(let i = startIndex; i < inputString.length; i++){
        if(inputString[i] === searchValue){
            result.push(i);
        }
    }
    return result;
}
//lets write a function that takes a string as parameter and returns the 
//number of vowels in the string
//If we sent "Pizza" we should return 2
function countVowels(inputString){
    const vowels = ['A', 'E', 'I', 'O', 'U'];
    let count = 0;
    const vowelString = `AEIOU`;
    const upperString = inputString.toUpperCase();
    for(let i = 0; i < upperString.length; i++){
        if(vowels.includes(upperString.charAt(i))){
            count++;
        }
    }
    return count;
}