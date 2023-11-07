using CalculatorAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculatorAPI.Services
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options) { }

        public DbSet<Calculation> Calculations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Calculation>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Value1).IsRequired();
                e.Property(e => e.Value2).IsRequired();
                e.Property(e => e.Operation).IsRequired();
                e.Property(e => e.Result).IsRequired();
            });
        }
    }
}
