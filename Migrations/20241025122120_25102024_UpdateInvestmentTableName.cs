using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCA.Migrations
{
    /// <inheritdoc />
    public partial class _25102024_UpdateInvestmentTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_investments_CoinPriceHistories_Symbol_Date",
                table: "investments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_investments",
                table: "investments");

            migrationBuilder.RenameTable(
                name: "investments",
                newName: "Investments");

            migrationBuilder.RenameIndex(
                name: "IX_investments_Symbol_Date",
                table: "Investments",
                newName: "IX_Investments_Symbol_Date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Investments",
                table: "Investments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_CoinPriceHistories_Symbol_Date",
                table: "Investments",
                columns: new[] { "Symbol", "Date" },
                principalTable: "CoinPriceHistories",
                principalColumns: new[] { "Symbol", "Date" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_CoinPriceHistories_Symbol_Date",
                table: "Investments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Investments",
                table: "Investments");

            migrationBuilder.RenameTable(
                name: "Investments",
                newName: "investments");

            migrationBuilder.RenameIndex(
                name: "IX_Investments_Symbol_Date",
                table: "investments",
                newName: "IX_investments_Symbol_Date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_investments",
                table: "investments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_investments_CoinPriceHistories_Symbol_Date",
                table: "investments",
                columns: new[] { "Symbol", "Date" },
                principalTable: "CoinPriceHistories",
                principalColumns: new[] { "Symbol", "Date" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
