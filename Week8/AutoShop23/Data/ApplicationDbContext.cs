using AutoShop23.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoShop23.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //What am I mising here?
        //DBSET
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ServicePerformed> ServicesPerformed { get; set; }
        public DbSet<TechnicianStatus> TechnicianStatuses { get; set; }
        public DbSet<ServiceStatus> ServiceStatuses { get; set; }
    }
}