//get references to the html Elements
let btnGetText;
let btnGetJSON;
let btnGetAPI;
let displayArea;

window.addEventListener('load', function(){
    btnGetText = document.getElementById("btnGetText");
    btnGetJSON = document.getElementById("btnGetJSON");
    btnGetAPI = document.getElementById("btnGetAPI");
    displayArea = document.querySelector('p');
    //add listeners for the buttons
    btnGetText.addEventListener('click', getText);
    btnGetJSON.addEventListener('click', getJSON);
    btnGetAPI.addEventListener('click', getAPI);
});
function getText(){
    //fetch(location of the data)
    //fetch returns a promise
    fetch('text.txt')
    .then(function(response){
        //This is going to run on success
        //response contains information about the request
        console.log(response);
        //return the response text
        return response.text();
    })
    .then(function(text){
        //inside of here I have the text from the request
        displayArea.innerHTML = text;
    })
    .catch(function(error){
        displayArea.innerHTML = error;
    });
}

function getJSON(){
    fetch('JSONText.JSON')
    .then((response) => {
        //here you have the response object
        console.log(response);
        //we pass the json to the next then method
        return response.json();
    })
    .then((json) => {
        //here you have the objects
        console.log(json);
        let output = '';
        //loop through the objects
        json.forEach(element => {
            output += `Title: ${element.title}, Year: ${element.year}</br>`;
        })
        displayArea.innerHTML = output;
    })
    .catch((error) => {
        console.log(error);
    });
}

function getAPI(){
    fetch('https://jsonplaceholder.typicode.com/posts')
    .then(response =>{
        console.log(response);
        return response.json();
    })
    .then(json => {
        let output = '';
        //These are JS Objects, not string
        json.forEach(post => {
            output += `Id: ${post.id} User Id: ${post.userId} Title: ${post.title} Body: ${post.body}</br>`;
        })
        displayArea.innerHTML = output;
    })
    .catch(error => {

    });

}