using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Course
    {
        //Each course has one department
        //Each department has multiple courses
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        //DepartmentId is a foreign key inside of course
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        //Navigation Properties
        //These are not columns in the database
        //They are only here to make our lives easier as C# developers
        //Each course has one department, but many enrollments
        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
