let stu = new Student('Gianni', 'Marquez', '29394853');
console.log(stu);
//adding some grades
stu.addGrade(75);
stu.addGrade(89);
stu.addGrade(92);
stu.addGrade(99);
//calculateAverage()
console.log(stu.calculateAverage());
//calling a static method
console.log(Student.getCreditCost());
console.log(Student.getEnrollDeadLine());

let stu2 = new ITStudent("Lhoucine", "Zerrouki", "23098123", "CSI");
console.log(stu2);
stu2.addGrade(88);
stu2.addGrade(74);
stu2.addGrade(90);
console.log(stu2.calculateAverage());
console.log(ITStudent.getCreditCost());