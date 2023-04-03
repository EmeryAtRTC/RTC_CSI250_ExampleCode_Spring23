//using ES6 Class
class FetchLibrary {

  //Since we are not using ES6 we can use classes and define the methods in the class
  //block without this or prototype
  get(url) {
    return new Promise((resolve, reject) => {
      fetch(url)
        .then(
          //Inside of here you have a response
          //we parse this to json() or text()
          //we send that to the next then() method
          res => res.json())
        .then(
          //We have the data
          //We have a list of objects
          //the list of objects is data
          //we call the resolve and send the data
          data => resolve(data))
        .catch(
          //This means something went wrong
          //pass the error to the reject
          err => reject(err));
    });
  }
  //Finish with post(url, data), put(url, data) and delete(url)
  //Post is for creating a new record

  post(url, data) {
    return new Promise((resolve, reject) => {
      fetch(url,
        {
          method: 'POST',
          headers:
          {
            'Content-type': 'application/json'
          },
          body: JSON.stringify(data)
        }
      )
      .then(res => res.json())
      .then(data => resolve(data))
      .catch(err => reject(err))
    });
  }
  //put is for updating a record
  //the url is going to have an id at the end of it
  //the id is the primary key of the record we are updating
  put(url, data) {
    return new Promise((resolve, reject) => {
      fetch(url,{
        method: 'PUT',
        headers: {
          'Content-type': 'application/json'
        },
        body: JSON.stringify(data)
      })
      .then(response => response.json())
      .then(data => resolve(data))
      .catch(error => reject(error))
    });
  }

  delete(url) {
    return new Promise((resolve, reject) => {
      fetch(url, {
        method:'Delete',
        headers: {
          'Content-type': 'application/json'
        }
      })
      .then(res => res.json())
      .then((data) => resolve(`Deleted ${data}`))
      .catch(err => reject(err))
    });
  }

}