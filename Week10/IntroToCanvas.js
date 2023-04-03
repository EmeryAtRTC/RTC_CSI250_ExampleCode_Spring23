//get a reference to the canvas
let canvas = document.querySelector('canvas');
console.log(canvas.getBoundingClientRect());

//lets add a mouse move event
canvas.addEventListener('mousemove', showCoordinates);

//I can create my showCoorindates
function showCoordinates(event){
    console.log(event);
    //client x and client y are where the cursor is
    //on your webpage
    //we can calculte where we are on the canvas by
    //subtracting the x and y of the canvasrectangle
    //from the clientx and client y
    let domRect = canvas.getBoundingClientRect();
    let x = event.clientX - domRect.left;
    let y = event.clientY - domRect.top;
    document.querySelector('p').innerHTML = `Coordinates within the Canvas X:${x} Y:${y}`;
}

//get the context
let ctx = canvas.getContext('2d');
ctx.beginPath();
ctx.moveTo(25, 25);
ctx.lineTo(25, 125);
ctx.strokeStyle = '#398fde'
ctx.stroke();