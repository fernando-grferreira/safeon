using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safeon.Mysql.Entities;

namespace Safeon.Mysql.Map
{
    public class ProfileFunctionalityMap : IEntityTypeConfiguration<ProfileFunctionalityEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileFunctionalityEntity> builder)
        {
            builder.ToTable("ProfileFunctionality");

            builder.Property(x => x.ProfileId);
            builder.Property(x => x.FunctionalityId);

            builder.HasKey(x => new { x.ProfileId, x.FunctionalityId });

            builder.HasOne(x => x.Functionality)
                .WithMany(y => y.ProfileFunctionalities)
                .HasForeignKey(x => x.FunctionalityId);

            builder.HasOne(x => x.Functionality)
                .WithMany(y => y.ProfileFunctionalities)
                .HasForeignKey(x => x.ProfileId);
        }
    }
}