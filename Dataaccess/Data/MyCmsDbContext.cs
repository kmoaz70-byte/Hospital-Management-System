using HospitalManagementSystemweb.Models;
using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace HospitalManagementSystemweb.Dataaccess.Data
{
    public class MyCmsDbContext : DbContext
    {
        public MyCmsDbContext(DbContextOptions<MyCmsDbContext> options) : base(options)
        {

        }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
