using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ApplicatoionDbContext
{
    public class ProductManagementDbContext : DbContext
    {
        public ProductManagementDbContext()
        {}
        public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> dbContext) : base(dbContext)
        {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-VR5Q1VS\\MSSQLSERVER16;Initial Catalog=WpfDB;User ID=sa;Password=@##0913Aslani;Trust Server Certificate=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
