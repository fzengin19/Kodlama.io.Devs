using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DevelopmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Developer", "DevelopmentDate", "Name" },
                values: new object[] { 1, "Dennis Ritchie & Bell Labs", new DateTime(1972, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "C" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Developer", "DevelopmentDate", "Name" },
                values: new object[] { 2, "Bjarne Stroustrup (Bell Labs)", new DateTime(1983, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "C++" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Developer", "DevelopmentDate", "Name" },
                values: new object[] { 3, "Mads Torgersen (Microsoft)", new DateTime(2000, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");
        }
    }
}
