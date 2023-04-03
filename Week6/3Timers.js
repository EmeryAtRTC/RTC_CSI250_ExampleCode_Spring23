//create my fields
let container;
let box;
//create variables to store the timers
let boxTimer;
let containerTimer;
//Variables to store the x and y position
let xPosition;
let yPosition;
let xDirection;
let yDirection;
//field for stop button
let btnStop;


window.addEventListener('load', function(){
    container = document.getElementById('container');
    box = document.getElementById('box');
    btnStop = document.getElementById('btn-stop');
    //assign values to our variables
    xPosition = 0;
    yPosition = 0;
    //set the direction
    xDirection = 5;
    yDirection = 5;
    //setTimeout will wait 2 seconds and then call the displayContainer
    //method
    containerTimer = setTimeout(displayContainer, 2000);
    btnStop.addEventListener('click', function(){
        clearInterval(boxTimer);
    });
});

function displayContainer(){
    console.log("test");
    container.style.display = "block";
    box.style.display = "block";
    //setInterval for our moveBox() function
    boxTimer = setInterval(moveBox, 17);
}
//This is where we actually move the div
function moveBox(){
    //we have to check to see where we are before we move the box
    if(yPosition >= 370 || yPosition < 0){
        yDirection *= -1;
        box.style.setProperty('background-color', getRandomColor());
    }
    if(xPosition >= 570 || xPosition < 0){
        xDirection *= -1;
        box.style.setProperty('background-color', getRandomColor());
    }
    //This is where we actually move the box
    //first time it runs we set to the top to 2 px
    //second time is run we set it to 4
    //third time to 6
    xPosition += xDirection;
    yPosition += yDirection;
    box.style.top = yPosition + "px";
    box.style.left = xPosition + "px";
}
//Random Color
function getRandomColor(){
    let letters = '0123456789ABCDEF';
    let output = '#';
    for(let i = 0; i < 6; i++){
        output += letters[Math.floor(Math.random() *16)];
    }
    return output;
}