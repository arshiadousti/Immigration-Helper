using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig_DegreeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Degrees_DegreeId",
                table: "Tests");

            migrationBuilder.AlterColumn<int>(
                name: "DegreeId",
                table: "Tests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DegreeTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeId = table.Column<int>(nullable: false),
                    TestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DegreeTests_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DegreeTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DegreeTests_DegreeId",
                table: "DegreeTests",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeTests_TestId",
                table: "DegreeTests",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Degrees_DegreeId",
                table: "Tests",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Degrees_DegreeId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "DegreeTests");

            migrationBuilder.AlterColumn<int>(
                name: "DegreeId",
                table: "Tests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Degrees_DegreeId",
                table: "Tests",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
