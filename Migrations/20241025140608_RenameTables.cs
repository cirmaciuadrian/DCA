using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCA.Migrations
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_InvestmentSummaries_InvestmentSummaryId",
                table: "Investments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvestmentSummaries",
                table: "InvestmentSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investments",
                table: "Investments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoinPriceHistories",
                table: "CoinPriceHistories");

            migrationBuilder.RenameTable(
                name: "InvestmentSummaries",
                newName: "InvestmentSummary");

            migrationBuilder.RenameTable(
                name: "Investments",
                newName: "Investment");

            migrationBuilder.RenameTable(
                name: "CoinPriceHistories",
                newName: "CoinPriceHistory");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_InvestmentSummaryId",
                table: "Investment",
                newName: "IX_Investment_InvestmentSummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_CoinPriceHistories_Symbol_Date",
                table: "CoinPriceHistory",
                newName: "IX_CoinPriceHistory_Symbol_Date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvestmentSummary",
                table: "InvestmentSummary",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investment",
                table: "Investment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoinPriceHistory",
                table: "CoinPriceHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investment_InvestmentSummary_InvestmentSummaryId",
                table: "Investment",
                column: "InvestmentSummaryId",
                principalTable: "InvestmentSummary",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investment_InvestmentSummary_InvestmentSummaryId",
                table: "Investment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvestmentSummary",
                table: "InvestmentSummary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investment",
                table: "Investment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoinPriceHistory",
                table: "CoinPriceHistory");

            migrationBuilder.RenameTable(
                name: "InvestmentSummary",
                newName: "InvestmentSummaries");

            migrationBuilder.RenameTable(
                name: "Investment",
                newName: "Investments");

            migrationBuilder.RenameTable(
                name: "CoinPriceHistory",
                newName: "CoinPriceHistories");

            migrationBuilder.RenameIndex(
                name: "IX_Investment_InvestmentSummaryId",
                table: "Investments",
                newName: "IX_Investments_InvestmentSummaryId");

            migrationBuilder.RenameIndex(
                name: "IX_CoinPriceHistory_Symbol_Date",
                table: "CoinPriceHistories",
                newName: "IX_CoinPriceHistories_Symbol_Date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvestmentSummaries",
                table: "InvestmentSummaries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investments",
                table: "Investments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoinPriceHistories",
                table: "CoinPriceHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_InvestmentSummaries_InvestmentSummaryId",
                table: "Investments",
                column: "InvestmentSummaryId",
                principalTable: "InvestmentSummaries",
                principalColumn: "Id");
        }
    }
}
