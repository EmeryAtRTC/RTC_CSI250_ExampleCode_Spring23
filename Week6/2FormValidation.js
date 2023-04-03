//Create the fields
let form;
let userName;
let email;
let password;
let password2;

//use the load event kind of like constructor
window.addEventListener('load', function(){
    form = document.getElementById('signup-form');    
    userName = document.getElementById('username');    
    email = document.getElementById('email');    
    password = document.getElementById('password');    
    password2 = document.getElementById('password2');
    //add an eventListener to the form
    form.addEventListener('submit', validateForm);
    
});

function validateForm(event){
    
    //We can prevent the default behavior of an event
    event.preventDefault();
    //call the checkRequired function
    //checks if any of the inputs are blank
    checkRequired([userName, email, password, password2]);
    //call checkLength
    checkLength(userName, 8, 20);
    //password has to be between 10 and 20
    checkLength(password, 10, 20);
}

function checkRequired(inputArray){
    //go through the array and see if any of the inputs are empty
    inputArray.forEach(function(input) {
        if(input.value === ''){
            //display an error message
            //instead of hardcoding the error message
            //make a function that sets the error message
            showError(input, `${input.id} is required, cannot be blank`);
        }
        else{
            //success
            showSuccess(input); 
        }
    });
}

//error message function
function showError(input, message){
    //get the container that has the input, label, and error message
    let formControl = input.parentElement;
    formControl.className = 'form-control error';
    //get small 
    let small = formControl.querySelector('small');
    small.innerHTML = message;
}

//success 
function showSuccess(input){
    //get the container
    let formControl = input.parentElement;
    //change the class
    formControl.className = 'form-control success';
}

//check length
function checkLength(input, min, max){
    if(input.value.length < min){
        showError(input, `${input.id} must be more than ${min} characters long`);
    }
    else if(input.value.length > max){
        showError(input, `${input.id} must be less than ${max} characters long`);
    }
    else{
        showSuccess(input);
    }
}