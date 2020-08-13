using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class OccurrenceMap : IEntityTypeConfiguration<OccurrenceEntity>
    {
        public void Configure(EntityTypeBuilder<OccurrenceEntity> builder)
        {
            builder.ToTable("Occurrence");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");

            builder.Property(x => x.OccurrenceTypeId)
                .IsRequired();

            builder.Property(x => x.OccurrenceStatusId)
                .IsRequired();
            
            builder.Property(x => x.DateTimeRegister)
                .IsRequired();

            builder.Property(x => x.Note)
                    .HasMaxLength(512);

            builder.HasOne(x => x.OccurrenceStatus)
                .WithMany(x => x.Occurrences)
                .HasForeignKey(x => x.OccurrenceStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.OccurrenceType)
                .WithMany(x => x.Occurrences)
                .HasForeignKey(x => x.OccurrenceTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}