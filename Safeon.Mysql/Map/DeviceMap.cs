using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class DeviceMap : IEntityTypeConfiguration<DeviceEntity>
    {
        public void Configure(EntityTypeBuilder<DeviceEntity> builder)
        {
            builder.ToTable("Device");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");

            builder.Property(x => x.SerialNumber)
                    .HasMaxLength(100);

            builder.Property(x => x.Model)
                    .HasMaxLength(45);

            builder.Property(x => x.Manufacturer)
                    .HasMaxLength(45);

            builder.HasOne(x => x.TrackableObject)
                .WithMany(x => x.Devices)
                .HasForeignKey(x => x.TrackableObjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}