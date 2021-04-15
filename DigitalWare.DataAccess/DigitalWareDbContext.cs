using DigitalWare.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalWare.DataAccess
{
    public class DigitalWareDbContext : DbContext
    {
        public DigitalWareDbContext(DbContextOptions<DigitalWareDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductoFactura>()
                .HasKey(ProductoFactura => new { ProductoFactura.ProductoId, ProductoFactura.FacturaId });

        }

    }
}
