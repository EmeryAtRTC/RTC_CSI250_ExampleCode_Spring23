//document.createElement
let btnSubmit = document.createElement('button');
btnSubmit.innerHTML = 'submit';
//to add an element to the page you have to append
//it to something
//this is not a good idea
document.body.appendChild(btnSubmit);

//lets try and get our list
//first you need a reference to the parent
const list = document.getElementById('my-list');
//create the element with document.createElement
const liElement = document.createElement('li');
//change anything about it you want to change
liElement.innerHTML = 'Item 1';
liElement.style.color = 'blue';
//add it to the page
list.appendChild(liElement);

for(let i = 2; i < 100; i++){
    let element = document.createElement('li');
    element.innerHTML = `Item ${i}`;
    element.style.color = 'blue';
    list.appendChild(element);
}