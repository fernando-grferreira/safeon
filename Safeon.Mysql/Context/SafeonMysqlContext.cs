using Microsoft.EntityFrameworkCore;
using Safeon.Domain.Contexts.Contracts;
using Safeon.Mysql.Entities;
using Safeon.Mysql.Map;

namespace Safeon.Mysql.Context
{
    public class SafeonMysqlContext : DbContext, ISafeonMysqlContext
    {
        public SafeonMysqlContext(DbContextOptions<SafeonMysqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new ClientTrackableObjectMap());
            modelBuilder.ApplyConfiguration(new ClientTypeMap());
            modelBuilder.ApplyConfiguration(new DeviceMap());
            modelBuilder.ApplyConfiguration(new ExternalSupportMap());
            modelBuilder.ApplyConfiguration(new ExternalSupportTypeMap());
            modelBuilder.ApplyConfiguration(new FunctionalityMap());
            modelBuilder.ApplyConfiguration(new LogMap());
            modelBuilder.ApplyConfiguration(new OccurrenceMap());
            modelBuilder.ApplyConfiguration(new OccurrenceStatusMap());
            modelBuilder.ApplyConfiguration(new OccurrenceTypeMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new PointInterestMap());
            modelBuilder.ApplyConfiguration(new PointInterestTypeMap());
            modelBuilder.ApplyConfiguration(new ProfileFunctionalityMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());
            modelBuilder.ApplyConfiguration(new TrackableObjectMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }


        public virtual DbSet<ClientEntity> ClientEntities { get; set; }
        public virtual DbSet<ClientTrackableObjectEntity> ClientTrackableObjectEntities { get; set; }
        public virtual DbSet<ClientTypeEntity> ClientTypeEntities { get; set; }
        public virtual DbSet<DeviceEntity> DeviceEntities { get; set; }
        public virtual DbSet<ExternalSupportEntity> ExternalSupportEntities { get; set; }
        public virtual DbSet<ExternalSupportTypeEntity> ExternalSupportTypeEntities { get; set; }
        public virtual DbSet<FunctionalityEntity> FunctionalityEntities { get; set; }
        public virtual DbSet<LogEntity> LogEntities { get; set; }
        public virtual DbSet<OccurrenceEntity> OccurrenceEntities { get; set; }
        public virtual DbSet<OccurrenceStatusEntity> OccurrenceStatusEntities { get; set; }
        public virtual DbSet<OccurrenceTypeEntity> OccurrenceTypeEntities { get; set; }
        public virtual DbSet<PersonEntity> PersonEntities { get; set; }
        public virtual DbSet<PointInterestEntity> PointInterestEntities { get; set; }
        public virtual DbSet<PointInterestTypeEntity> PointInterestTypeEntities { get; set; }
        public virtual DbSet<ProfileEntity> ProfileEntities { get; set; }
        public virtual DbSet<ProfileFunctionalityEntity> ProfileFunctionalityEntities { get; set; }
        public virtual DbSet<TrackableObjectEntity> TrackableObjectEntities { get; set; }
        public virtual DbSet<UserEntity> UserEntities { get; set; }
    }
}