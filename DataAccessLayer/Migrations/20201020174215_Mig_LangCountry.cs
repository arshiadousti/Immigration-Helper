using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig_LangCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Languages_LangId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_LangId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "LangId",
                table: "Countries");

            migrationBuilder.CreateTable(
                name: "LangCountries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LangId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LangCountries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LangCountries_Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LangCountries_CountryId",
                table: "LangCountries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LangCountries_LangId",
                table: "LangCountries",
                column: "LangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LangCountries");

            migrationBuilder.AddColumn<int>(
                name: "LangId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LangId",
                table: "Countries",
                column: "LangId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Languages_LangId",
                table: "Countries",
                column: "LangId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
