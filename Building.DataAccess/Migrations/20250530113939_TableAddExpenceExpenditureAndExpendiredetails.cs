using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Building.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TableAddExpenceExpenditureAndExpendiredetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expences",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expences", x => x.ExpenseId);
                });

            migrationBuilder.CreateTable(
                name: "Expenditures",
                columns: table => new
                {
                    ExpenditureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenditures", x => x.ExpenditureId);
                });

            migrationBuilder.CreateTable(
                name: "ExpenditureDetails",
                columns: table => new
                {
                    ExpenditureDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenditureId = table.Column<int>(type: "int", nullable: false),
                    ExpenseId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenditureDetails", x => x.ExpenditureDetailId);
                    table.ForeignKey(
                        name: "FK_ExpenditureDetails_Expences_ExpenditureId",
                        column: x => x.ExpenditureId,
                        principalTable: "Expences",
                        principalColumn: "ExpenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenditureDetails_Expenditures_ExpenditureId",
                        column: x => x.ExpenditureId,
                        principalTable: "Expenditures",
                        principalColumn: "ExpenditureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenditureDetails_ExpenditureId",
                table: "ExpenditureDetails",
                column: "ExpenditureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenditureDetails");

            migrationBuilder.DropTable(
                name: "Expences");

            migrationBuilder.DropTable(
                name: "Expenditures");
        }
    }
}
