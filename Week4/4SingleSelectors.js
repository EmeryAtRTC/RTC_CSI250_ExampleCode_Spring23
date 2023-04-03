//getelementbyid - this gets you one element by id
const mainHeader = document.getElementById('main-header');
//first thing log it
//console.log(mainHeader);
//add a class to an element
mainHeader.classList.add('blue-background');
mainHeader.classList.remove('blue-background');
mainHeader.innerHTML = `Single Selectors Example`;

//queryselector - only gives you one element, takes css selector
const groceryHeader = document.querySelector('h2');
console.log(groceryHeader);

let listItem = document.querySelector('li');
console.log(listItem);
//psuedo selectors
listItem = document.querySelector('li:last-child');
console.log(listItem);
//nth child
listItem = document.querySelector('li:nth-child(2)');
console.log(listItem);

//adding things to the style
groceryHeader.style.background = `#aaa`;
groceryHeader.style.padding = '20px';
groceryHeader.style.color = 'white';
//groceryHeader.style.display = 'none';

//mainheader
mainHeader.innerHTML = `<em>Grocery <span style="color:blue">List</span></em>`;