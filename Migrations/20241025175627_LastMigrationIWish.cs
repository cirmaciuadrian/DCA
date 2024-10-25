using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCA.Migrations
{
    /// <inheritdoc />
    public partial class LastMigrationIWish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investment_CoinPriceHistory_CoinPriceHistoryId",
                table: "Investment");

            migrationBuilder.DropIndex(
                name: "IX_Investment_CoinPriceHistoryId",
                table: "Investment");

            migrationBuilder.DropColumn(
                name: "CoinPriceHistoryId",
                table: "Investment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoinPriceHistoryId",
                table: "Investment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Investment_CoinPriceHistoryId",
                table: "Investment",
                column: "CoinPriceHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Investment_CoinPriceHistory_CoinPriceHistoryId",
                table: "Investment",
                column: "CoinPriceHistoryId",
                principalTable: "CoinPriceHistory",
                principalColumn: "Id");
        }
    }
}
