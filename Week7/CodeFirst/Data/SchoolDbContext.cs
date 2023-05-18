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
        //I can override a method in DbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Inside of OnModelCreating we can seed our database
            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 1, Name = "IT"},
                new Department() { Id = 2, Name = "Business" },
                new Department() { Id = 3, Name = "Math" }
                );
            modelBuilder.Entity<Course>().HasData(
                new Course() { Id = 1, DepartmentId = 1, Title = "Programming I", Credits = 5},
                new Course() { Id = 2, DepartmentId = 2, Title = "Project Management", Credits = 5 },
                new Course() { Id = 3, DepartmentId = 3, Title = "Calculus I", Credits = 5 }
                );
            base.OnModelCreating(modelBuilder);
        }
        

    }
}
