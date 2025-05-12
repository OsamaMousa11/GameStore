using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(g => g.Description)
                  .HasMaxLength(2500);

            builder.Property(g => g.Cover)
                   .HasMaxLength(500);

            builder.HasOne(g => g.Category)
                 .WithMany(c => c.Games)
                 .HasForeignKey(g => g.CategoryId);

            builder.HasMany(g => g.Devices)
                 .WithOne(gd => gd.Game)
                 .HasForeignKey(gd => gd.GameId);

            builder.ToTable("Games");
        }

      
    }
}
