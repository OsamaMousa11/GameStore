using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore
{
    public class GameDeviceConfig:IEntityTypeConfiguration<GameDevice>
    {
        public void Configure(EntityTypeBuilder<GameDevice> builder)
        {
            builder.HasKey(x => new { x.DeviceId, x.GameId });

            builder.HasOne(x => x.Game)
                 .WithMany(g => g.Devices)
                 .HasForeignKey(gd => gd.GameId);


            builder.HasOne(x => x.Device)
                   .WithMany(d => d.GameDevices)
                   .HasForeignKey(gd => gd.DeviceId);

            builder.ToTable("GameDevices");
        }

       
    }
}
