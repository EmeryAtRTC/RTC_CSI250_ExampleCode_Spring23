const canvas = document.querySelector('canvas');
const ctx = canvas.getContext('2d');

const btnDrawLine = document.getElementById('draw-line');
const btnDrawManyLines = document.getElementById('draw-many-lines');
const btnDrawCircle = document.getElementById('draw-circle');
const btnClear = document.getElementById('clear');
const btnDrawAnimatedCircle = document.getElementById('draw-animated-circle');

btnDrawLine.addEventListener('click', drawLine);
btnDrawManyLines.addEventListener('click', drawManyLines);
btnClear.addEventListener('click', clear);
btnDrawCircle.addEventListener('click', drawCircle);
btnDrawAnimatedCircle.addEventListener('click', drawAnimatedCircle);

function drawLine(){
    //begin the path
    ctx.beginPath();
    //start drawing from a random position
    //generate random x and y
    let x = Math.ceil(Math.random() * 100);
    let y = Math.ceil(Math.random() * 100);
    let x2 = Math.ceil(Math.random() * 600);
    let y2 = Math.ceil(Math.random() * 600);
    ctx.moveTo(x, y);
    ctx.lineTo(x2, y2);

    //set width
    ctx.lineWidth = Math.ceil(Math.random() * 7) + 1;
    //set color ctx.strokeStyle
    ctx.stroke();  

}

function drawManyLines(){
    //draw multiple lines starting at the same point
    ctx.beginPath();
    ctx.strokeStyle = '#0000ff';
    ctx.lineWidth = 3;
    ctx.clearRect(0, 0, 600, 600);
    for (let index = 0; index < 100; index++) {
        let x2 = Math.ceil(Math.random() * 600);
        let y2 = Math.ceil(Math.random() * 600);
        ctx.moveTo(0, 0);
        ctx.lineTo(x2, y2);
        ctx.stroke();        
    }
}

function drawCircle(){
    
    //center of canves
    let x = canvas.width / 2;
    let y = canvas.height / 2;
    let radius = 150;
    let start = 0;
    let end = 2 * Math.PI
    //draw the circle
    ctx.beginPath();
    //arc method (x, y, radius, startAngle, endAngle)
    ctx.arc(x, y, radius, start, end);
    ctx.strokeStyle = '#0000ff';
    ctx.fill()
    ctx.stroke();
}

function Point(x, y){
    this.x = x;
    this.y = y;
}

function drawAnimatedCircle(){
    console.log('test');
    let p1 = new Point(canvas.width / 2, canvas.height / 2);
    //determine dimensions of the canvas
    let min = Math.min(canvas.width, canvas.height);
    //p2 
    let p2 = new Point(p1.x, 50);
    let radius = Math.sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y -p2.y));
    //ready to draw the line
    let angle = 0;
    function rotateLine(){
        //ctx.clearRect(0, 0, canvas.width, canvas.height);
        angle = (angle + 1) % 360;
        p2.x = p1.x + radius * Math.cos(angle * Math.PI /180);
        p2.y = p1.y + radius * Math.sin(angle * Math.PI /180);
        //draw the new line
        ctx.beginPath();
        ctx.moveTo(p1.x, p1.y);
        ctx.lineTo(p2.x, p2.y);
        ctx.stroke();
    }
    let timer;
    timer = setInterval(rotateLine, 16)

}

function clear(){
    //clearRect method starting x and y and ending x and y 
    //clears all the space inside
    ctx.clearRect(0, 0, 600, 600);
}