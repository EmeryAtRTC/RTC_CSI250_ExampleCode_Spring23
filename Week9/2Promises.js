//A Promise in JavaScript is an alternative to using a callback function.
//A promise will have results, it is either successful (resolve) or
//unsuccessful (reject)

//The promise construction takes a function which servers as a callback
//for the promise. The function has two parameters, resolve and reject.
//resolve or reject is called once the promise has completed.

//Create a new promise
let promise1 = new Promise(function(resolve, reject){
    //Some processing happens
    //if check for success,
    resolve('Success');
    //check for failure
    reject('Failed');
});
//log the promise
//The promise is called using the then() method
//console.log(promise1.then());
//call this the correct way passing functions to the callbacks (resolve and reject)
promise1.then(
    function(value){
        document.write(value);
    },
    function(error){
        console.log(error);
    }
);

//promise that could either pass or fail
let promise2 = new Promise(function(resolve, reject){
    //Were doing some processing, maybe making aj AJAX request
    //Generate an random number between 0 and 10
    let x = Math.floor(Math.random() * 11);
    //We can ask questions about the processing
    if(x % 2 === 1){
        resolve(`Great, we like odd numbers ${x}`);
    }
    else{
        reject(`Error, no even numbers allowed ${x}`);
    }
});

//calling promise2 using a display method for success
promise2.then((success) => {
    display(success);
}, (error) => {
    console.log(error);
});
//Another way to call the reject method, using the catch
promise2.then((success) => {
    display(success)
}).catch((error) => {
    console.log(error);
});

//async and await- This is another way to create a promise.
async function getData(){
    //simulate a delay
    //create a promise
    let promise = new Promise((resolve, reject) => {
        setTimeout(() => resolve('Data retrieved'), 2000);
    });
    //calling a promise with a keyword await
    let response = await promise;
    return response;
}
//calling getData, getData returns a promise
getData().then((success) => {
    console.log(success);
});

function display(input){
    document.querySelector('p').textContent = input;
}