let inputNumber1;
let submitNumber1;
let displayNumber1;

//elements for number 5
let containerNumber5;
let boxNumber5;
//coordinates for the location of the box
let xPos;
let yPos;
//speed of the box
let boxSpeed;

//fields for number6
let submitNumber6;
let displayNumber6;
//This is the array of cars
let carList;

//field for number 7
let selectedCar;
let inputNumber7;
let submitNumber7;



//use the load event like a constructor
//constructor assings values to the fields
window.addEventListener('load', function(){
    //Assign all my fields
    containerNumber5 = document.getElementById('containerNumber5');
    boxNumber5 = document.getElementById('boxNumber5');
    xPos = 0;
    yPos = 0;
    boxSpeed = 1;
    document.body.addEventListener('keypress', moveBox);
    //assignment for number 6
    submitNumber6 = document.getElementById('submitNumber6');
    displayNumber6 = document.getElementById('displayNumber6');
    loadCars();
    submitNumber6.addEventListener('click', displayCars);
    //number 7
    displayNumber6.addEventListener('click', getSelectedCar);
    inputNumber7 = document.getElementById('inputNumber7');
    submitNumber7 = document.getElementById('submitNumber7');
    //add a listener to submit button for number 7
    submitNumber7.addEventListener('click', updateCar);
    //references for #1
    inputNumber1 = document.getElementById('inputNumber1');
    submitNumber1 = document.getElementById('submitNumber1');
    displayNumber1 = document.getElementById('displayNumber1');
    submitNumber1.addEventListener('click', displayPrime);
    

});
function displayPrime(){
    let number = inputNumber1.value;
    if(!number){
        alert('Please enter a number');
        return;
    }
    //we need a list of the factors... if that list is empty, then I know the number is prime
    let factors = getFactors(number);
    // console.log(factors);
    if(factors.length === 0){
        displayNumber1.innerHTML = `${number} is Prime`;
    }
    //if there are factors the number is not prime
    else{
        displayNumber1.textContent = `${number} is not prime. It is divisible by: `;
        factors.forEach(x => {
            displayNumber1.textContent += `${x} `;
        })
    }
}

//method that takes a number and returns the factors
function getFactors(number){
    let result = [];
    if(number == 2 || number == 3){
        return result;
    }
    // if(number % 2 === 0){
    //     //the number is not prime, it is even
    //     result.push(2);
    //     result.push(number / 2);
    // }
    //now we are ready
    for(let i = 2; i <= Math.sqrt(number); i++){
        if(number % i == 0){
            result.push(i);
            result.push(number / i);
        }
    }
    //if we never added any numbers to the array we know that number is prime
    return result;
}

//Let's create moveBox 
//this moveBox is going to take an event
//The event can tell us about how the keypress was triggered
function moveBox(event){

    //console.log(event.key);
    if(event.key.toLowerCase() === 'w'){
        if(yPos <= 0){
            return;
        }
        //reducing the y coordinate by the speed
        yPos -= boxSpeed;
        //actually move the box
        boxNumber5.style.top = yPos + 'px';
    }
    else if(event.key.toLowerCase() === 's'){
        if(yPos >=  170){
            return;
        }
        //adding to the y coordinate by the speed
        yPos += boxSpeed;
        //actually move the box
        boxNumber5.style.top = yPos + 'px';
    }
    else if(event.key.toLowerCase() === 'd'){
        if(xPos >= 270){
            return;
        }
        //adding to the x coordinate by the speed
        xPos += boxSpeed;
        //actually move the box
        boxNumber5.style.left = xPos + 'px';
    }
    else if(event.key.toLowerCase() === 'a'){
        if(xPos <= 0){
            return;
        }
        //reducing the x coordinate by the speed
        xPos -= boxSpeed;
        //actually move the box
        boxNumber5.style.left = xPos + 'px';
    }
}

//Constructor function for a car
function Car(year, make, model, milage, price){
    this.year = year;
    this.make = make;
    this.model = model;
    this.milage = milage;
    this.price = price;
    //toString() function
    this.toString = function(){
        return `${this.year} ${this.make} ${this.model} ${this.milage} ${this.price}`;
    }
}

//function that loads the carList
function loadCars(){
    carList = [];
    carList.push(new Car(2010, 'chevy', 'fastcar', 21890, 38473));
    carList.push(new Car(2015, 'ford', 'truck', 215439, 10000));
    carList.push(new Car(2021, 'geo', 'metro', 29304, 12000));
    carList.push(new Car(1990, 'red', 'wagon', 100, 5));
    carList.push(new Car(2001, 'magic', 'carpet', 100000000, 120938120938));
    
}
//this is the function that displays the carList
function displayCars(){
    //clear the display
    displayNumber6.innerHTML = "";
    //we have to go through the list
    for(const car of carList){
        //we create a list item element
        let element = document.createElement('li');
        element.textContent = car.toString();
        displayNumber6.appendChild(element);
    }
}
//This function will take and event and then
//set the selectedCar variable to whatever car
//was click on in the list
function getSelectedCar(event){
    //Created an array from all of the list item elements
    let listItemArray = Array.from(displayNumber6.children);
    //Now I can use the indexOf()
    let clickedIndex = listItemArray.indexOf(event.target);
    //now we have the index
    //use the index to access the car
    selectedCar = carList[clickedIndex];
    //call the displayOneCar method and pass the selectedCar
    displayOneCar(selectedCar);
}

//lets make a method that takes a car and displays it into the
//inputs for #7
function displayOneCar(car){
    if(!car){
        return;
    }
    //get a reference to all of the inputs for number 7
    let carInputs = inputNumber7.querySelectorAll('input');
    // console.log(selectedCar);
    // console.log(carInputs);
    carInputs[0].value = selectedCar.year;
    carInputs[1].value = selectedCar.make;
    carInputs[2].value = selectedCar.model;
    carInputs[3].value = selectedCar.milage;
    carInputs[4].value = selectedCar.price;
}

function updateCar(){
    //if no car is selected
    if(!selectedCar){
        return;
    }
    let carInputs = inputNumber7.querySelectorAll('input');
    selectedCar.year = carInputs[0].value;
    selectedCar.make = carInputs[1].value;
    selectedCar.model = carInputs[2].value;
    selectedCar.milage = carInputs[3].value;
    selectedCar.price = carInputs[4].value;
    //call my method that displays the cars
    displayCars();
}