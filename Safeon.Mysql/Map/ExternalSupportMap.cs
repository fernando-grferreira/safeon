using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class ExternalSupportMap : IEntityTypeConfiguration<ExternalSupportEntity>
    {
        public void Configure(EntityTypeBuilder<ExternalSupportEntity> builder)
        {
            builder.ToTable("ExternalSupport");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.City)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.UF)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(128);

            builder.Property(x => x.Active)
                .IsRequired();

            builder.HasOne(x => x.ExternalSupportType)
                .WithMany(x => x.ExternalSupports)
                .HasForeignKey(x => x.ExternalSupportTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
