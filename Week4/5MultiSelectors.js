//get elements by classname
const listItems = document.getElementsByClassName('grocery-item');
console.log(listItems);
listItems[1].innerHTML = `<em>Cookies</em>`;
//get elements by tag name
const listItems2 = document.getElementsByTagName('li');
console.log(listItems2);
//HTML collections they can be accessed by index
//before you can foreach through you have to make it an array
let listArray = Array.from(listItems);
listArray.forEach(item => {
    console.log(item);
});
//QuerySelecterAll - Uses CSS Syntax to select multiple elements
const listItems3 = document.querySelectorAll('li');
console.log(listItems3);
listItems3.forEach(item => {
    console.log(item);
})