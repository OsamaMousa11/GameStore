using GameStore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Data.Configurations
{
    public class DeviceConfig : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x=> x.Name)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(x=> x.Icon)
              .HasMaxLength(100);


            builder.HasMany(d => d.GameDevices)
                  .WithOne(gd => gd.Device)
                  .HasForeignKey(gd => gd.DeviceId);

            builder.ToTable("Devices");
        }
    }
}
