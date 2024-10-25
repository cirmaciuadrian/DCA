using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCA.Migrations
{
    /// <inheritdoc />
    public partial class AddInvestmentSummary2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvestmentSummaryId",
                table: "Investments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvestmentSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Days = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentSummaries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investments_InvestmentSummaryId",
                table: "Investments",
                column: "InvestmentSummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_InvestmentSummaries_InvestmentSummaryId",
                table: "Investments",
                column: "InvestmentSummaryId",
                principalTable: "InvestmentSummaries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_InvestmentSummaries_InvestmentSummaryId",
                table: "Investments");

            migrationBuilder.DropTable(
                name: "InvestmentSummaries");

            migrationBuilder.DropIndex(
                name: "IX_Investments_InvestmentSummaryId",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "InvestmentSummaryId",
                table: "Investments");
        }
    }
}
