using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MonthEntryUpdateAndTypeIdentifireTableAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonthEntryType",
                table: "MonthEntries",
                newName: "TypeIdentifierId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "MonthEntries",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Record_creted_date",
                table: "MonthEntries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "TypeIdentifiers",
                columns: table => new
                {
                    TypeIdentifierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeIdentifierName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeIdentifiers", x => x.TypeIdentifierId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthEntries_TypeIdentifiers_TypeIdentifierId",
                table: "MonthEntries");

            migrationBuilder.DropTable(
                name: "TypeIdentifiers");

            migrationBuilder.DropIndex(
                name: "IX_MonthEntries_TypeIdentifierId",
                table: "MonthEntries");

            migrationBuilder.RenameColumn(
                name: "TypeIdentifierId",
                table: "MonthEntries",
                newName: "MonthEntryType");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "MonthEntries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Record_creted_date",
                table: "MonthEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
