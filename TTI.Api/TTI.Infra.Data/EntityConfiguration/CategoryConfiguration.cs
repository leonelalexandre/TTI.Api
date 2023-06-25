using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTI.Domain.Entity;

namespace TTI.Infra.Data.EntityConfiguration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(250).IsUnicode(true);
            builder.Property(x => x.IdSubCategory).IsRequired();
            builder.Property(e => e.Idiom).IsRequired().HasMaxLength(10);

            builder.HasOne(d => d.IdSubCategoryNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.IdSubCategory)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Categories_SubCategories");
        }
    }
}
