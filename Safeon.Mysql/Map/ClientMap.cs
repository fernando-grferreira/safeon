using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class ClientMap : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClientTypeId)
                    .IsRequired();

            builder.HasOne(x => x.ClientType)
                .WithMany(x => x.Clients)
                .HasForeignKey(x => x.ClientTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Person)
                .WithOne(x => x.Client)
                .HasForeignKey<ClientEntity>(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}