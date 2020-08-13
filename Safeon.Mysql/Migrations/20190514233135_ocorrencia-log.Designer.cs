﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Safeon.Mysql.Context;

namespace Safeon.Mysql.Migrations
{
    [DbContext(typeof(SafeonMysqlContext))]
    [Migration("20190514233135_ocorrencia-log")]
    partial class ocorrencialog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Safeon.Mysql.Entities.ClientEntity", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("ClientTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ClientTypeId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.ClientTrackableObjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<int>("ClientId");

                    b.Property<int>("TrackableObjectId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("TrackableObjectId");

                    b.ToTable("ClientTrackableObject");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.ClientTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("ClientType");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.DeviceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(45);

                    b.Property<string>("Model")
                        .HasMaxLength(45);

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(100);

                    b.Property<int>("TrackableObjectId");

                    b.HasKey("Id");

                    b.HasIndex("TrackableObjectId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.ExternalSupportEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<bool>("Active");

                    b.Property<string>("CellPhoneNumber");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<int>("ExternalSupportTypeId");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Note");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("ExternalSupportTypeId");

                    b.ToTable("ExternalSupport");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.ExternalSupportTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("ExternalSupportType");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.FunctionalityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<int>("Name")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Functionality");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.LogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TIMESTAMP")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("EntityId");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Record")
                        .HasMaxLength(2048);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.OccurrenceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<int>("ClientTrackableObjectId");

                    b.Property<DateTime>("DateTimeEnd");

                    b.Property<DateTime>("DateTimeRegister");

                    b.Property<DateTime>("DateTimeStart");

                    b.Property<string>("Note")
                        .HasMaxLength(512);

                    b.Property<int>("OccurrenceStatusId");

                    b.Property<int>("OccurrenceTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ClientTrackableObjectId");

                    b.HasIndex("OccurrenceStatusId");

                    b.HasIndex("OccurrenceTypeId");

                    b.ToTable("Occurrence");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.OccurrenceLogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Description");

                    b.Property<int>("OccurrenceId");

                    b.Property<int>("OccurrenceLogTypeId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OccurrenceId");

                    b.HasIndex("OccurrenceLogTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("OccurrenceLogEntity");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.OccurrenceLogTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("OccurrenceLogTypeEntity");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.OccurrenceStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("OccurrenceStatus");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.OccurrenceTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("OccurrenceType");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("PersonType")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("SocialName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Document")
                        .IsUnique();

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.PointInterestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .HasMaxLength(256);

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<float>("Latitude");

                    b.Property<float>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("PointInterestTypeId");

                    b.HasKey("Id");

                    b.HasIndex("PointInterestTypeId");

                    b.ToTable("PointInterest");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.PointInterestTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("PointInterestType");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.ProfileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<bool>("Active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.ProfileFunctionalityEntity", b =>
                {
                    b.Property<int>("ProfileId");

                    b.Property<int>("FunctionalityId");

                    b.HasKey("ProfileId", "FunctionalityId");

                    b.ToTable("ProfileFunctionality");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.TrackableObjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<string>("Brand")
                        .HasMaxLength(100);

                    b.Property<string>("Chassis")
                        .HasMaxLength(50);

                    b.Property<string>("ClientCode")
                        .HasMaxLength(100);

                    b.Property<string>("Color")
                        .HasMaxLength(45);

                    b.Property<string>("Fipe")
                        .HasMaxLength(45);

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(100);

                    b.Property<string>("Model")
                        .HasMaxLength(100);

                    b.Property<string>("Plate")
                        .HasMaxLength(10);

                    b.Property<int>("YearManufacture");

                    b.Property<int>("YearModel");

                    b.HasKey("Id");

                    b.ToTable("TrackableObject");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)")
                        .HasAnnotation("MySQL:AutoIncrement", true);

                    b.Property<bool>("Active");

                    b.Property<string>("Email")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("PersonId");

                    b.Property<int>("ProfileId");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PersonId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.ClientEntity", b =>
                {
                    b.HasOne("Safeon.Mysql.Entities.ClientTypeEntity", "ClientType")
                        .WithMany("Clients")
                        .HasForeignKey("ClientTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Safeon.Mysql.Entities.PersonEntity", "Person")
                        .WithOne("Client")
                        .HasForeignKey("Safeon.Mysql.Entities.ClientEntity", "Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.ClientTrackableObjectEntity", b =>
                {
                    b.HasOne("Safeon.Mysql.Entities.ClientEntity", "Client")
                        .WithMany("ClientTrackableObjects")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Safeon.Mysql.Entities.TrackableObjectEntity", "TrackableObject")
                        .WithMany("ClientTrackableObjects")
                        .HasForeignKey("TrackableObjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.DeviceEntity", b =>
                {
                    b.HasOne("Safeon.Mysql.Entities.TrackableObjectEntity", "TrackableObject")
                        .WithMany("Devices")
                        .HasForeignKey("TrackableObjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.ExternalSupportEntity", b =>
                {
                    b.HasOne("Safeon.Mysql.Entities.ExternalSupportTypeEntity", "ExternalSupportType")
                        .WithMany("ExternalSupports")
                        .HasForeignKey("ExternalSupportTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.LogEntity", b =>
                {
                    b.HasOne("Safeon.Mysql.Entities.UserEntity", "User")
                        .WithMany("Logs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.OccurrenceEntity", b =>
                {
                    b.HasOne("Safeon.Mysql.Entities.ClientTrackableObjectEntity", "ClientTrackableObject")
                        .WithMany("Occurrences")
                        .HasForeignKey("ClientTrackableObjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Safeon.Mysql.Entities.OccurrenceStatusEntity", "OccurrenceStatus")
                        .WithMany("Occurrences")
                        .HasForeignKey("OccurrenceStatusId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Safeon.Mysql.Entities.OccurrenceTypeEntity", "OccurrenceType")
                        .WithMany("Occurrences")
                        .HasForeignKey("OccurrenceTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.OccurrenceLogEntity", b =>
                {
                    b.HasOne("Safeon.Mysql.Entities.OccurrenceEntity", "Occurrence")
                        .WithMany("OccurrenceLogs")
                        .HasForeignKey("OccurrenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Safeon.Mysql.Entities.OccurrenceLogTypeEntity", "OccurrenceLogType")
                        .WithMany("OccurrenceLogs")
                        .HasForeignKey("OccurrenceLogTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Safeon.Mysql.Entities.UserEntity", "User")
                        .WithMany("OccurrenceLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.PointInterestEntity", b =>
                {
                    b.HasOne("Safeon.Mysql.Entities.PointInterestTypeEntity", "PointInterestType")
                        .WithMany("PointInterests")
                        .HasForeignKey("PointInterestTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.ProfileFunctionalityEntity", b =>
                {
                    b.HasOne("Safeon.Mysql.Entities.FunctionalityEntity", "Functionality")
                        .WithMany("ProfileFunctionalities")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Safeon.Mysql.Entities.ProfileEntity", "Profile")
                        .WithMany("ProfileFunctionalities")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Safeon.Mysql.Entities.UserEntity", b =>
                {
                    b.HasOne("Safeon.Mysql.Entities.PersonEntity", "Person")
                        .WithMany("Users")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Safeon.Mysql.Entities.ProfileEntity", "Profile")
                        .WithMany("Users")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
