using GameStore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Data.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(c => c.Name)
                 .IsRequired()
                 .HasMaxLength(250);

            builder.HasMany(x => x.Games)
                  .WithOne(g => g.Category)
                  .HasForeignKey(g => g.CategoryId);

            builder.ToTable("Categories");

        }
    }
}
