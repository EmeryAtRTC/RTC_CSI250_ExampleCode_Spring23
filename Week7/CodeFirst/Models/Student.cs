using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentIdNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        //Each student can have multiple enrollments
        //Navigation property
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
