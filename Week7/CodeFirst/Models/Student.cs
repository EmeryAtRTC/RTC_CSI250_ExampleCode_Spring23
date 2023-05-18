using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(10)]
        public string StudentIdNumber { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        //Each student can have multiple enrollments
        //Navigation property
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
