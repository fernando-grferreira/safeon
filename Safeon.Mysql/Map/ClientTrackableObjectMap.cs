using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safeon.Mysql.Map
{
    public class ClientTrackableObjectMap : IEntityTypeConfiguration<ClientTrackableObjectEntity>
    {
        public void Configure(EntityTypeBuilder<ClientTrackableObjectEntity> builder)
        {
            builder.ToTable("ClientTrackableObject");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasAnnotation("MySQL:AutoIncrement", true)
                .HasColumnType("INT(11)");

            builder.Property(x => x.ClientId)
                    .IsRequired();

            builder.Property(x => x.TrackableObjectId)
                    .IsRequired();

            builder.HasOne(x => x.Client)
                .WithMany(x => x.ClientTrackableObjects)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TrackableObject)
                .WithMany(x => x.ClientTrackableObjects)
                .HasForeignKey(x => x.TrackableObjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
