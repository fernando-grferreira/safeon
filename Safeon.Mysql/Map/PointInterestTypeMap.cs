using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class PointInterestTypeMap : IEntityTypeConfiguration<PointInterestTypeEntity>
    {
        public void Configure(EntityTypeBuilder<PointInterestTypeEntity> builder)
        {
            builder.ToTable("PointInterestType");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");

            builder.Property(x => x.Description)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}