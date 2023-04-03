const http = new FetchLibrary;

//Using the Get method on users
//Remember that Get returns a promise
//Get returns a promise, we call a promise with then.
http.get('https://jsonplaceholder.typicode.com/users')
//function that runs on resolve(succcess)
  .then(data => console.log(data))
//Catch takes a function that runs on reject
  .catch(err => console.log(err));

//Use the Post method for a new user
//lets make a user to send
let user = {
  name: 'Sir William Cram Esquire',
  username: 'SirWilliam',
  email: 'willhasanepicbear@gmail.com',
  phone: '1-206-123-4567 x5595'
};
//Post creats information
//Your Code here
http.post('https://jsonplaceholder.typicode.com/users', user)
.then(data => console.log(data))
.catch(err => console.log(`Error: ${err}`));

//Update requires the id of the record you want to update and the new data to update with
//Use the Put(Update) method to update a user
//Your Code here
http.put('https://jsonplaceholder.typicode.com/users/2', user)
.then(data => console.log(data))
.catch(error => console.log(`Error: ${error}`));

// Delete requires the id of the record you want to delete
//Use the Delete method to delete a user
//Your Code here
// This takes the id of the object you want to delete
http.delete('https://jsonplaceholder.typicode.com/users/5')
.then(data => console.log(data))
.catch(err => console.log(err));