using Microsoft.EntityFrameworkCore;
using TTI.Domain.Entity;

#nullable disable

namespace TTI.Infra.Data.Context
{
    public partial class TTIContext : DbContext
    {
        public TTIContext()
        {
        }

        public TTIContext(DbContextOptions<TTIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS02;Database=tti;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TTIContext).Assembly);
        }

    }
}
