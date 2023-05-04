// See https://aka.ms/new-console-template for more information
using DBAccess;

Console.WriteLine("Hello, World!");
Repository repo = new Repository();
List<Course> courses = repo.GetAllCourses();
foreach (Course course in courses)
{
    Console.WriteLine($"ID - {course.CourseId}");
    Console.WriteLine($"Title - {course.Title}");
    Console.WriteLine($"Credits - {course.Credits}");
    Console.WriteLine($"Department - {course.DepartmentID}");
}
Course c = repo.GetCourseById(1045);
Console.WriteLine("===Get one course===");
Console.WriteLine($"ID - {c.CourseId}");
Console.WriteLine($"Title - {c.Title}");
Console.WriteLine($"Credits - {c.Credits}");
Console.WriteLine($"Department - {c.DepartmentID}");

Console.ReadLine();
