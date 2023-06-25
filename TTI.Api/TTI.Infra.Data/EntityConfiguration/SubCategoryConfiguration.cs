using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTI.Domain.Entity;

namespace TTI.Infra.Data.EntityConfiguration
{
    internal class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(250).IsUnicode(true);
            builder.Property(x => x.Idiom).HasMaxLength(10).IsRequired();

        }
    }
}
