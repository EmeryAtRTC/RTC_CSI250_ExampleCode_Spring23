function AJAXLibrary() {
    this.http = new XMLHttpRequest();
  }
  
  // Make an HTTP GET Request
  AJAXLibrary.prototype.get = function(url, callback) {
    this.http.open('GET', url, true);
  
    let self = this;
    this.http.onload = function() {
      if(self.http.status === 200) {
        callback(null, self.http.responseText);
      } else {
        callback('Error: ' + self.http.status);
      }
    }
  
    this.http.send();
  }
  
  // Make an HTTP POST Request
  AJAXLibrary.prototype.post = function(url, data, callback) {
    this.http.open('POST', url, true);
    //When sending data you have to set a request header
    this.http.setRequestHeader('Content-type', 'application/json');
  
    let self = this;
    this.http.onload = function() {
      callback(null, self.http.responseText);
    }
    //Data to send goes inside the send method
    this.http.send(JSON.stringify(data));
  }
  
  
  // Make an HTTP PUT Request
  //Put is for updating data
  AJAXLibrary.prototype.put = function(url, data, callback) {
    this.http.open('PUT', url, true);
    this.http.setRequestHeader('Content-type', 'application/json');
  
    let self = this;
    this.http.onload = function() {
      callback(null, self.http.responseText);
    }
  
    this.http.send(JSON.stringify(data));
  }
  
  // Make an HTTP DELETE Request
  //This is used when you want to delete data
  //How do we know which item to delelete?
  //The id of the post to delete is passed in the url
  AJAXLibrary.prototype.delete = function(url, callback) {
    this.http.open('DELETE', url, true);
  
    let self = this;
    this.http.onload = function() {
      if(self.http.status === 200) {
        callback(null, 'Post Deleted');
      } else {
        callback('Error: ' + self.http.status);
      }
    }
  
    this.http.send();
  }
  