using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FlatTypeNameUpdateTableFlatType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FlatTypes",
                keyColumn: "FlatTypeId",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "FlatTypes",
                newName: "FlatTypeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlatTypeName",
                table: "FlatTypes",
                newName: "Type");

            migrationBuilder.InsertData(
                table: "FlatTypes",
                columns: new[] { "FlatTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Flat" },
                    { 2, "Commercial" },
                    { 3, "Shop" }
                });
        }
    }
}
