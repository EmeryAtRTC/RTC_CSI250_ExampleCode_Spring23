//As of ES6 JavaScript objects can be created with similar syntax to C# or Java
//This does not actually change how JavaScript works
class Student{
    //fields
    enrolled = false;
    grades = [];
    //constructor
    constructor(firstName, lastName, studentId){
        this.firstName = firstName;
        this.lastName = lastName;
        this.studentId = studentId;
    }
    //Methods
    //method that enrolls a student
    enrollStudent(){
        this.enrolled = true;
    }
    //add a grade to the array
    addGrade(grade){
        if(isNaN(grade)){
           let error = new TypeError("Must be a number");
           return error;
        }    
        this.grades.push(grade);
    }
    //function that goes through the grades and returns the average
    calculateAverage(){
        if(this.grades.length === 0){
            return 0;
        }
        //if we get down here we know logically that there were grades in the array
        let total = 0;
        this.grades.forEach(grade =>{
            total += grade;
        });
        return total / this.grades.length;
    }
    //Static methods are methods that can be called without creating an instance.
    //Static methods do not have acces to the fields
    static getCreditCost(){
        return 100.00;
    }
    static getEnrollDeadLine(){
        return '8-20-2023';
    }
}
class ITStudent extends Student{
    constructor(firstName, lastName, studentId, department){
        super(firstName, lastName, studentId);
        this.department = department;
    }
    static getCreditCost(){
        return 125.00;
    }
}
