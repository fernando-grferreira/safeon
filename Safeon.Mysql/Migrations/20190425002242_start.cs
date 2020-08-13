using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeon.Mysql.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalSupportType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalSupportType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Functionality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<int>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functionality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccurrenceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrenceStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccurrenceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrenceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    SocialName = table.Column<string>(maxLength: 256, nullable: true),
                    Document = table.Column<string>(maxLength: 20, nullable: false),
                    PersonType = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointInterestType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointInterestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackableObject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientCode = table.Column<string>(maxLength: 100, nullable: true),
                    Plate = table.Column<string>(maxLength: 10, nullable: true),
                    Chassis = table.Column<string>(maxLength: 50, nullable: true),
                    Color = table.Column<string>(maxLength: 45, nullable: true),
                    Brand = table.Column<string>(maxLength: 100, nullable: true),
                    Model = table.Column<string>(maxLength: 100, nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 100, nullable: true),
                    Fipe = table.Column<string>(maxLength: 45, nullable: true),
                    YearModel = table.Column<int>(nullable: false),
                    YearManufacture = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackableObject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalSupport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    ExternalSupportTypeId = table.Column<int>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    City = table.Column<string>(maxLength: 256, nullable: false),
                    UF = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CellPhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalSupport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalSupport_ExternalSupportType_ExternalSupportTypeId",
                        column: x => x.ExternalSupportTypeId,
                        principalTable: "ExternalSupportType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ClientTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_ClientType_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "ClientType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    Username = table.Column<string>(maxLength: 128, nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PointInterest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Address = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    PointInterestTypeId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointInterest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointInterest_PointInterestType_PointInterestTypeId",
                        column: x => x.PointInterestTypeId,
                        principalTable: "PointInterestType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileFunctionality",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false),
                    FunctionalityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileFunctionality", x => new { x.ProfileId, x.FunctionalityId });
                    table.ForeignKey(
                        name: "FK_ProfileFunctionality_Functionality_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Functionality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileFunctionality_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SerialNumber = table.Column<string>(maxLength: 100, nullable: true),
                    Model = table.Column<string>(maxLength: 45, nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 45, nullable: true),
                    TrackableObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_TrackableObject_TrackableObjectId",
                        column: x => x.TrackableObjectId,
                        principalTable: "TrackableObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientTrackableObject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    TrackableObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTrackableObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientTrackableObject_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientTrackableObject_TrackableObject_TrackableObjectId",
                        column: x => x.TrackableObjectId,
                        principalTable: "TrackableObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntityName = table.Column<string>(maxLength: 256, nullable: false),
                    EntityId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(type: "TIMESTAMP", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Record = table.Column<string>(maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Occurrence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OccurrenceTypeId = table.Column<int>(nullable: false),
                    OccurrenceStatusId = table.Column<int>(nullable: false),
                    DateTimeRegister = table.Column<DateTime>(nullable: false),
                    DateTimeStart = table.Column<DateTime>(nullable: false),
                    DateTimeEnd = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(maxLength: 512, nullable: true),
                    ClientTrackableObjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurrence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occurrence_ClientTrackableObject_ClientTrackableObjectId",
                        column: x => x.ClientTrackableObjectId,
                        principalTable: "ClientTrackableObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Occurrence_OccurrenceStatus_OccurrenceStatusId",
                        column: x => x.OccurrenceStatusId,
                        principalTable: "OccurrenceStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Occurrence_OccurrenceType_OccurrenceTypeId",
                        column: x => x.OccurrenceTypeId,
                        principalTable: "OccurrenceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientTypeId",
                table: "Client",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTrackableObject_ClientId",
                table: "ClientTrackableObject",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTrackableObject_TrackableObjectId",
                table: "ClientTrackableObject",
                column: "TrackableObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_TrackableObjectId",
                table: "Device",
                column: "TrackableObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalSupport_ExternalSupportTypeId",
                table: "ExternalSupport",
                column: "ExternalSupportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_UserId",
                table: "Log",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Occurrence_ClientTrackableObjectId",
                table: "Occurrence",
                column: "ClientTrackableObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Occurrence_OccurrenceStatusId",
                table: "Occurrence",
                column: "OccurrenceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Occurrence_OccurrenceTypeId",
                table: "Occurrence",
                column: "OccurrenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Document",
                table: "Person",
                column: "Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PointInterest_PointInterestTypeId",
                table: "PointInterest",
                column: "PointInterestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "ExternalSupport");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Occurrence");

            migrationBuilder.DropTable(
                name: "PointInterest");

            migrationBuilder.DropTable(
                name: "ProfileFunctionality");

            migrationBuilder.DropTable(
                name: "ExternalSupportType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ClientTrackableObject");

            migrationBuilder.DropTable(
                name: "OccurrenceStatus");

            migrationBuilder.DropTable(
                name: "OccurrenceType");

            migrationBuilder.DropTable(
                name: "PointInterestType");

            migrationBuilder.DropTable(
                name: "Functionality");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "TrackableObject");

            migrationBuilder.DropTable(
                name: "ClientType");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
