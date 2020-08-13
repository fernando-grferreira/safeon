using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class PointInterestMap : IEntityTypeConfiguration<PointInterestEntity>
    {      
        public void Configure(EntityTypeBuilder<PointInterestEntity> builder)
        {
            builder.ToTable("PointInterest");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");            

            builder.Property(x => x.Name)
                    .HasMaxLength(256)
                    .IsRequired();

            builder.Property(x => x.Address)
                    .HasMaxLength(256);

            builder.Property(x => x.Description)
                    .HasMaxLength(256);

            builder.Property(x => x.Active)
                    .IsRequired();

            builder.HasOne(x => x.PointInterestType)
                    .WithMany(x => x.PointInterests)
                    .HasForeignKey(x => x.PointInterestTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
