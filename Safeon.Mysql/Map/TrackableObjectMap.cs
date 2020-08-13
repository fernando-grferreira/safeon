using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class TrackableObjectMap : IEntityTypeConfiguration<TrackableObjectEntity>
    {
        public void Configure(EntityTypeBuilder<TrackableObjectEntity> builder)
        {
            builder.ToTable("TrackableObject");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");

            builder.Property(x => x.ClientCode)
                    .HasMaxLength(100);

            builder.Property(x => x.Plate)
                    .HasMaxLength(10);

            builder.Property(x => x.Chassis)
                    .HasMaxLength(50);

            builder.Property(x => x.Color)
                    .HasMaxLength(45);

            builder.Property(x => x.Brand)
                    .HasMaxLength(100);

            builder.Property(x => x.Model)
                   .HasMaxLength(100);

            builder.Property(x => x.Manufacturer)
                    .HasMaxLength(100);

            builder.Property(x => x.Fipe)
                    .HasMaxLength(45);
        }
    }
}