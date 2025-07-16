using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlatTypes",
                columns: table => new
                {
                    FlatTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatTypes", x => x.FlatTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    FloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.FloorId);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    FlatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FlatSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatRent = table.Column<double>(type: "float", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: true),
                    FlatTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.FlatId);
                    table.ForeignKey(
                        name: "FK_Flats_FlatTypes_FlatTypeId",
                        column: x => x.FlatTypeId,
                        principalTable: "FlatTypes",
                        principalColumn: "FlatTypeId");
                    table.ForeignKey(
                        name: "FK_Flats_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "FloorId");
                });

            migrationBuilder.InsertData(
                table: "FlatTypes",
                columns: new[] { "FlatTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Flat" },
                    { 2, "Commercial" },
                    { 3, "Shop" }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "FloorId", "FloorName" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" },
                    { 3, "3" }
                });

            migrationBuilder.InsertData(
                table: "Flats",
                columns: new[] { "FlatId", "FlatName", "FlatRent", "FlatSize", "FlatTypeId", "FloorId" },
                values: new object[,]
                {
                    { 1, "101-A", 10000.0, "1200", 1, 1 },
                    { 2, "101-B", 20000.0, "1400", 1, 1 },
                    { 3, "103-C", 25000.0, "1600", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flats_FlatTypeId",
                table: "Flats",
                column: "FlatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_FloorId",
                table: "Flats",
                column: "FloorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "FlatTypes");

            migrationBuilder.DropTable(
                name: "Floors");
        }
    }
}
