using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Department
    {
        //This is the primary key
        [Key]
        public int Id { get; set; }
        //Name property
        public string Name { get; set; }

        //Navigation Properties
        //Each department is associated with multiple courses
        public ICollection<Course> Courses { get; set; }

    }
}
