//Object Literal
let student1 = {
    firstName: "Lhoucine",
    lastName: "Zerrouki",
    studentId: 2837485,
    grades: [89, 81, 92],
    calculateAvgGrade: function(){
        console.log(this);
        let total = 0;
        this.grades.forEach(grade => {
            total += grade;
        });
        return total / this.grades.length;
    }

};
console.log(`FirstName ${student1["firstName"]} LastName ${student1.lastName}`);
//call the calculateAvgGrade function
console.log(`${student1.firstName} Avg Grade: ${student1.calculateAvgGrade()}`);

//The second way to create objects
//Objects created from a constructors
//Constructor function
function Student(firstName, lastName, studentId, grades){
    this.firstName = firstName;
    this.lastName = lastName;
    this.studentId = studentId;
    this.grades = grades;
    this.calculateAvgGrade = function(){
        let total = 0;
        this.grades.forEach(grade => {
            total += grade;
        });
        return total / this.grades.length;
    };
};
//End of our constructor function
//Creating an object from constructor function
let student2 = new Student("Gianni", "Marquez", 324908234, [84, 99, 92]);
console.log(student2);
console.log(`Student 2: ${student2.firstName} ${student2["lastName"]} ${student2.calculateAvgGrade()}`);
//Adding properties that are not in the constructor function or defined in object literal
student2.enrolled = true;
console.log(`${student2.enrolled}`);
//we can loop through
//with a for in loop
for(const key in student2){
    console.log(`The key is ${key} the value is ${student2[key]}`);
}

//Using a Map
//Maps are another type of object in JavaScript. They are similar to Object Literals and
//you may hear the terms used interchangeably. Maps have a size property. Maps can have
//an object as the key.
let student3 = new Map();
//Add key values to the map we use the set property
student3.set("firstName", "Kyle");
student3.set("lastName", "Smith");
student3.set("studentId", 30498234);
student3.set("grades", [98, 60, 99]);
student3.set("calculateAvgGrade", () => {
    let total = 0;
    student3.get("grades").forEach((grade) => {
        total+=grade;
    });
    return total / student3.get("grades").length;
});
//caling calculateAvgGrade
console.log(student3.get("calculateAvgGrade")());
//assigning to variable before calling
let average = student3.get("calculateAvgGrade")();
console.log(average);
//an object can be a key
student3.set(student1, "This is the value associated with student1");



console.log(student3.get(student1));
//looping through a map
//use the for of loop
for(const [key, value] of student3){
    console.log(`This is the key ${key}. This is the value ${value}`);
}
