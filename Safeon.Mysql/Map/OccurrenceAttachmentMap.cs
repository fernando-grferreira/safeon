using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class OccurrenceAttachmentMap : IEntityTypeConfiguration<OccurrenceAttachmentEntity>
    {
        public void Configure(EntityTypeBuilder<OccurrenceAttachmentEntity> builder)
        {
            builder.ToTable("OccurrenceAttachment");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");

            builder.Property(x => x.OccurrenceId)
                .IsRequired();

            builder.Property(x => x.Filename)
                    .HasMaxLength(256)
                    .IsRequired();

            builder.Property(x => x.Location)
                    .HasMaxLength(256)
                    .IsRequired();

            builder.HasOne(x => x.Occurrence)
                .WithMany(x => x.OccurrenceAttachments)
                .HasForeignKey(x => x.OccurrenceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}