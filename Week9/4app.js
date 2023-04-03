//This app is going to use the AjaxLibrary
let ajax = new AjaxLibrary();
ajax.get('https://jsonplaceholder.typicode.com/posts/1', 
    function(err, posts){
        if(err){
            console.log(`Error: ${err}`);
        }
        else{
            console.log(posts);
        }
    }
);

let post = {
    title: 'This is the title',
    body: 'This is the body'
};
ajax.post('https://jsonplaceholder.typicode.com/posts/', post, 
function(err, post){
    if(err){
        console.log(err);
    }
    else{
        console.log(post);
    }
});