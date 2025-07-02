using Microsoft.EntityFrameworkCore;
using ProjectAlfajor.Api.Models;

namespace ProjectAlfajor.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }  //Tabela Produto
        public DbSet<DailySale> DailySales { get; set; } //Tabela DailySales
        public DbSet<CreditCustomer> CreditCustomers { get; set; } //Tabela CreditCustumers
    }
}
