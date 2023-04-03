//create your fields
let groceryList;
//we use a load event to assign the fields
window.addEventListener('load', function(){
    //assign the fields
    groceryList = document.getElementById('grocery-list');
    
    //add some events
    groceryList.addEventListener('click', groceryClick);
    document.body.addEventListener('click', bodyClick);
});
//This will fire whenever the UL is clicked
function groceryClick(event){
    console.log('=====Grocery Click=====');
        //event.target is the element
        console.log(event.target);
        //We can also find out which listener fired
        //event.currentTarget
        console.log(event.currentTarget);
        //we have a method called stopPropagation()
        //What this does is prevents the event from bubbling up
        //event.stopPropagation();
}
//this will fire whenever the body is clicked
function bodyClick(event){
    console.log('=====Body Click=====');
    //log the target - This gives you the element that got clicked
    //event.target is the element
    console.log(event.target);
    //We can also find out which listener fired
    //event.currentTarget
    console.log(event.currentTarget);
}