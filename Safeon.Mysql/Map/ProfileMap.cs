using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class ProfileMap : IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder.ToTable("Profile");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");

            builder.Property(x => x.Name)
                    .HasMaxLength(256)
                    .IsRequired();

            builder.Property(x => x.Active)
                    .IsRequired();
        }
    }
}
