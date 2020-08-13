using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeon.Mysql.Migrations
{
    public partial class ocorrenciaanexo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OccurrenceAttachmentEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OccurrenceId = table.Column<int>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccurrenceAttachmentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OccurrenceAttachmentEntity_Occurrence_OccurrenceId",
                        column: x => x.OccurrenceId,
                        principalTable: "Occurrence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OccurrenceAttachmentEntity_OccurrenceId",
                table: "OccurrenceAttachmentEntity",
                column: "OccurrenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OccurrenceAttachmentEntity");
        }
    }
}
