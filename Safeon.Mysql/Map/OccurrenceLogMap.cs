using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class OccurrenceLogMap : IEntityTypeConfiguration<OccurrenceLogEntity>
    {
        public void Configure(EntityTypeBuilder<OccurrenceLogEntity> builder)
        {
            builder.ToTable("OccurrenceLog");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");

            builder.Property(x => x.OccurrenceId)
                .IsRequired();

            builder.Property(x => x.OccurrenceLogTypeId)
                .IsRequired();

            builder.Property(x => x.DateTime)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.Description)
                    .HasMaxLength(512);

            builder.HasOne(x => x.OccurrenceLogType)
                .WithMany(x => x.OccurrenceLogs)
                .HasForeignKey(x => x.OccurrenceLogTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Occurrence)
                .WithMany(x => x.OccurrenceLogs)
                .HasForeignKey(x => x.OccurrenceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany(x => x.OccurrenceLogs)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}