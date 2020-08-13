using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeon.Mysql.Migrations
{
    public partial class ocorrencialog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OccurrenceLogTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrenceLogTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccurrenceLogEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OccurrenceId = table.Column<int>(nullable: false),
                    OccurrenceLogTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrenceLogEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OccurrenceLogEntity_Occurrence_OccurrenceId",
                        column: x => x.OccurrenceId,
                        principalTable: "Occurrence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OccurrenceLogEntity_OccurrenceLogTypeEntity_OccurrenceLogTyp~",
                        column: x => x.OccurrenceLogTypeId,
                        principalTable: "OccurrenceLogTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OccurrenceLogEntity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceLogEntity_OccurrenceId",
                table: "OccurrenceLogEntity",
                column: "OccurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceLogEntity_OccurrenceLogTypeId",
                table: "OccurrenceLogEntity",
                column: "OccurrenceLogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceLogEntity_UserId",
                table: "OccurrenceLogEntity",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OccurrenceLogEntity");

            migrationBuilder.DropTable(
                name: "OccurrenceLogTypeEntity");
        }
    }
}
