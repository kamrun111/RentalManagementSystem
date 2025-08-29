using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TypeIdentifiedTableAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthEntries_TypeIdentifiers_TypeIdentifierId",
                table: "MonthEntries");

            migrationBuilder.DropIndex(
                name: "IX_MonthEntries_TypeIdentifierId",
                table: "MonthEntries");

            migrationBuilder.DropColumn(
                name: "TypeIdentifierId",
                table: "MonthEntries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeIdentifierId",
                table: "MonthEntries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonthEntries_TypeIdentifierId",
                table: "MonthEntries",
                column: "TypeIdentifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthEntries_TypeIdentifiers_TypeIdentifierId",
                table: "MonthEntries",
                column: "TypeIdentifierId",
                principalTable: "TypeIdentifiers",
                principalColumn: "TypeIdentifierId");
        }
    }
}
