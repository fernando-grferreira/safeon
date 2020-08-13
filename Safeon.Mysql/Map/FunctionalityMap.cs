using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class FunctionalityMap : IEntityTypeConfiguration<FunctionalityEntity>
    {
        public void Configure(EntityTypeBuilder<FunctionalityEntity> builder)
        {
            builder.ToTable("Functionality");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");

            builder.Property(x => x.Name)
                    .HasMaxLength(256)
                    .IsRequired();
        }
    }
}
