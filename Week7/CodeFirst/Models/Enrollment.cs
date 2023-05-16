using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Enrollment
    {
        //Each enrollment has a course and a student
        //This is a bridge table between
        //Student and course
        [Key]
        public int Id { get; set; }
        public decimal Grade { get; set; }
        //foreign keys
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        //Navigation properties
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
