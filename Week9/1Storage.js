//Local storage and session storage is a location where information
//can be saved. They take information in key/value pairs as a string.
//It is possible to store complex objects in the storage, we would 
//need to convert it to JSON use json.stringify(). Similarly
//if we are retrieving an object from storage it comes out as a string
//You have to parse to JSON before it can be used like an object

//add a key value parir to localStorage
//use a method called setItem(key, value)
localStorage.setItem("Number", "1");
//to retrieve we use a method called getItem(key);
let value = localStorage.getItem("Number");
console.log(value);
console.log(typeof(value));
console.log(localStorage);
//clear() method epties local storage
// localStorage.clear();
// console.log(localStorage);
//removeItem
// localStorage.removeItem("Number");
// console.log(localStorage);
//use storage with an object

let character = {
    name: "Josh",
    class: "Wizard",
    level: 20,
    maxHealth: 100,
    gold: 5000
}

//how to store the object, we have to stringify
console.log(character);
console.log(JSON.stringify(character));

localStorage.setItem("Player1", JSON.stringify(character));
console.log(localStorage);

let loadedInformation = localStorage.getItem("Player1");
console.log(loadedInformation);
//I have to parse the string before I can use it like an object
//JSON.Parse()
let loadedCharacter = JSON.parse(loadedInformation);
console.log(loadedCharacter);

// SessionStorage is very similar for adding, removing etc...
// SessionStorage is temporary and empties when the browser is closed
//create an array
let grades = [25, 95, 80, 100];
sessionStorage.setItem("Grades", JSON.stringify(grades));
console.log(sessionStorage);
//retrieve from sessionStorage
let gradesString = sessionStorage.getItem('Grades');
console.log(gradesString);
console.log(JSON.parse(gradesString));