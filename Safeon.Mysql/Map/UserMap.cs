using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");

            builder.Property(x => x.Username)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(128);           

            builder.Property(x => x.Active)
                .IsRequired();

            builder.HasIndex(x => x.Username)
               .IsUnique();

            builder.HasIndex(x => x.Email)
               .IsUnique();

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Profile)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}