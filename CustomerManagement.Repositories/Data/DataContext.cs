using CustomerManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Persistence.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {    
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasIndex(c => c.NumeroDocumento).IsUnique();
        }
    }
}
