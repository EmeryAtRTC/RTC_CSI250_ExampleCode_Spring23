//The Callback function we have been using since the
//beginning has been with for each
//A callback function is a way of passing a function
//as a parameter to another function
getSomeData(function(data){
    console.log(data);
});
//using arrow function
getSomeData(data => {
    console.log(`Display from arrow function ${data}`);
});
//calling getSomeData using displayToConsole function
getSomeData(displayToConsole)
//calling getSomeData using displayToUL function
getSomeData(displayToUL);

function displayToConsole(data){
    console.log(`Display from displayToConsole function ${data}`);
}
function displayToUL(data){
    let ul = document.querySelector('ul');
    //console.log(ul);
    data.forEach(x => {
        let li = document.createElement('li');
        li.textContent = x;
        ul.appendChild(li);
    });
}
function getSomeData(callBack){
    let array = [];
    for(let i = 0; i < 5; i++){
        array[i] = Math.floor(Math.random() * 11);
    }
    //when our processing is done
    callBack(array);
}

let array = [1, 4, 5, 6, 7];
array.forEach(x => {
    console.log(x);
});

getSomeData(data => {
    data.forEach(x => {
        console.log(x);
    })
});