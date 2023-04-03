//The load event
//It is common practice to use the load event on the window object
//to register eventListeners and to get references to the document.
// window.onload = function(){
//     console.log('Hello from window.onload');
// }
//Define our fields
let groceryList;
let txtGroceryItem;
let btnAdd;
let btnRemove;
let keyPressLog;

//we can think of this as the constructor
window.addEventListener('load', function(){
    groceryList = document.getElementById('grocery-list');
    txtGroceryItem = document.getElementById('txt-grocery-item');
    btnAdd = document.getElementById('btn-add');
    btnRemove = document.getElementById('btn-remove');
    keyPressLog = document.getElementById('key-press-log');
    console.log(keyPressLog);
    //add an event listener to the input txtGroceryItem
    txtGroceryItem.addEventListener('focusin', toggleBorder);
    txtGroceryItem.addEventListener('focusout', toggleBorder);
    btnAdd.addEventListener('focusin', toggleBorder);
    btnAdd.addEventListener('focusout', toggleBorder);
    btnRemove.addEventListener('focusin', toggleBorder);
    btnRemove.addEventListener('focusout', toggleBorder);
    //we can add events to the window
    window.addEventListener('keydown', function(event){
        keyPressLog.innerHTML += `<br> ${event.key} ${event.type}`;
    });
    //similar event using arrow function
    window.addEventListener('keyup', event => {
        keyPressLog.innerHTML += `<br> ${event.key} ${event.type}`;
    });
    //now using keypress
    window.addEventListener('keypress', event => {
        keyPressLog.innerHTML += `<br> ${event.key} ${event.type}`;
    });

})

//toggleBorder function
//if we take a parameter from an eventListener, that parameter contains
//the event that happened
function toggleBorder(event){
    console.log(event);
    if(event.type == 'focusin'){
        document.getElementById(event.target.id).style.border = '3px solid red';
    }
    else{
        document.getElementById(event.target.id).style.border = '1px solid black';
    }
    
}