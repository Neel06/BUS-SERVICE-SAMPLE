using BUS_SERVICE_SAMPLE.Models;
using Microsoft.EntityFrameworkCore;

namespace BUS_SERVICE_SAMPLE.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<PassApplication> PassApplications { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
