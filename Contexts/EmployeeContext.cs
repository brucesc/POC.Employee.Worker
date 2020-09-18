using Microsoft.EntityFrameworkCore;
using POC.Employee.Worker.Contexts.Configs;
using POC.Employee.Worker.Models;

namespace POC.Employee.Worker.Contexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options)
            : base(options) { }

        public DbSet<EmployeeCT> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeCTConfig());
        }
    }
}
