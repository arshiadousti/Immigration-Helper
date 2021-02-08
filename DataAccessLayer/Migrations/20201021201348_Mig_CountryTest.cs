using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig_CountryTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestCountries");

            migrationBuilder.CreateTable(
                name: "CountryTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTests_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountryTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryTests_CountryId",
                table: "CountryTests",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTests_TestId",
                table: "CountryTests",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryTests");

            migrationBuilder.CreateTable(
                name: "TestCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CountryId1 = table.Column<int>(type: "int", nullable: true),
                    CountryId2 = table.Column<int>(type: "int", nullable: false),
                    TestUserId = table.Column<int>(type: "int", nullable: true),
                    TestUserId1 = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCountries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestCountries_Countries_CountryId1",
                        column: x => x.CountryId1,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCountries_Tests_TestUserId",
                        column: x => x.TestUserId,
                        principalTable: "Tests",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestCountries_Tests_UserId",
                        column: x => x.UserId,
                        principalTable: "Tests",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestCountries_CountryId",
                table: "TestCountries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCountries_CountryId1",
                table: "TestCountries",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_TestCountries_TestUserId",
                table: "TestCountries",
                column: "TestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCountries_UserId",
                table: "TestCountries",
                column: "UserId");
        }
    }
}
