using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenditureDetails_Expences_ExpenditureId",
                table: "ExpenditureDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expences",
                table: "Expences");

            migrationBuilder.RenameTable(
                name: "Expences",
                newName: "Expenses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenditureDetails_Expenses_ExpenditureId",
                table: "ExpenditureDetails",
                column: "ExpenditureId",
                principalTable: "Expenses",
                principalColumn: "ExpenseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenditureDetails_Expenses_ExpenditureId",
                table: "ExpenditureDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expences");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expences",
                table: "Expences",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenditureDetails_Expences_ExpenditureId",
                table: "ExpenditureDetails",
                column: "ExpenditureId",
                principalTable: "Expences",
                principalColumn: "ExpenseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
