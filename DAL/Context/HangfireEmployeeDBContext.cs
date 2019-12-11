namespace DAL.Context
{
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;
    public class HangfireEmployeeDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.; database=HangfireEmployeeDB; Integrated Security=true");
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Event> Event { get; set; }
    }
}