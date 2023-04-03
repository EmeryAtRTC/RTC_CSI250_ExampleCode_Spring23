//The document contains all of the of html elements from the page
//This is not good practice, do not do this
document.writeln(`<h3>Writing to the document</h3>`);

console.log(document);
//all of the elements as an HTMLCollection
console.log(document.all);
//refereence the head
console.log(document.head);
//we can get the other sections
console.log(document.body);
console.log(document.doctype);
console.log(document.domain);
console.log(document.URL);

//get all of the forms on the page
let forms = document.forms;
console.log(forms);
//my actual form is at index 0 of forms
console.log(forms[0]);
//access the attributes of my form
console.log(forms[0].id);
console.log(forms[0].className);
console.log(forms[0].classList);
console.log(forms[0].action);
console.log(forms[0].method);

//we could all the links on the pae
let links = document.links
console.log(links);
//links is an HTMLCollection
for(let i = 0; i < links.length; i++){
    links[i].innerHTML = `This is link ${1+i}`;
}
//we can also foreach through an HTML collection
//first we have to make it an array
let linkArray = Array.from(links);
linkArray.forEach(link => {
    link.innerHTML += ` <em>Hello From foreach</em><br>`;
});