using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTI.Domain.Entity;

namespace TTI.Infra.Data.EntityConfiguration
{
    internal class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(250).IsUnicode(true).IsRequired();
            builder.Property(x => x.Price).HasColumnType("smallmoney").IsRequired();
            builder.Property(x => x.IdCategory).IsRequired();
            builder.Property(e => e.Country).HasMaxLength(50);
            builder.Property(e => e.Currency).HasMaxLength(10);

            builder.HasOne(d => d.IdCategoriesNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Products_Categories");
        }
    }
}
