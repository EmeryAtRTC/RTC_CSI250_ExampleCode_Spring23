//Constructor Function
function AjaxLibrary(){
    this.xhttp = new XMLHttpRequest();
}
//I want to define
//I would add a new method to the Ajax Library through the prototype
AjaxLibrary.prototype.get = function(url, callback){
    //open a location('Request', location, true)
    this.xhttp.open('GET', url, true);   
    //we need a function to run on load
    //create a reference to this
    let self = this;
    this.xhttp.onload = function(){
        if(self.xhttp.status === 200){
            //null representing an error
            callback(null, self.xhttp.responseText);
        }
        else{
            callback(`Error ${self.xhttp.status}`, null);
        }
    }
    this.xhttp.send();
}
//Lets do a create request
AjaxLibrary.prototype.post = function(url, data, callback){
    this.xhttp.open('POST', url, true);
    this.xhttp.setRequestHeader('Content-type', 'application/json');

    let self = this;
    this.xhttp.onload = function(){
        callback(null, self.xhttp.responseText);
    }

    //we actually pass the data in the send method
    this.xhttp.send(JSON.stringify(data));
}