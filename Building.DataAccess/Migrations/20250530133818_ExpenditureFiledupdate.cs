using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExpenditureFiledupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Expenditures",
                newName: "ExpenditureDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Expenditures",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpenditureInvoice",
                table: "Expenditures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Expenditures");

            migrationBuilder.DropColumn(
                name: "ExpenditureInvoice",
                table: "Expenditures");

            migrationBuilder.RenameColumn(
                name: "ExpenditureDate",
                table: "Expenditures",
                newName: "Date");
        }
    }
}
