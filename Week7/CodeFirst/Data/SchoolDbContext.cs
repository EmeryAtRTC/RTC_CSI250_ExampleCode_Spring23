using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Data
{
    public class SchoolDbContext : DbContext
    {
        //Constructor
        //This constructor is used by the services collection
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) 
        {
            
        }
        //The next thing we need is a set of properties that represent the
        //tables in the database
        //They are super similar to List
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
