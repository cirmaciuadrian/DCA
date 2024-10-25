using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCA.Migrations
{
    /// <inheritdoc />
    public partial class SoItWasNotTheLast2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investment_CoinPriceHistory_CoinPriceHistoryId",
                table: "Investment");

            migrationBuilder.AlterColumn<int>(
                name: "CoinPriceHistoryId",
                table: "Investment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Investment_CoinPriceHistory_CoinPriceHistoryId",
                table: "Investment",
                column: "CoinPriceHistoryId",
                principalTable: "CoinPriceHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investment_CoinPriceHistory_CoinPriceHistoryId",
                table: "Investment");

            migrationBuilder.AlterColumn<int>(
                name: "CoinPriceHistoryId",
                table: "Investment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Investment_CoinPriceHistory_CoinPriceHistoryId",
                table: "Investment",
                column: "CoinPriceHistoryId",
                principalTable: "CoinPriceHistory",
                principalColumn: "Id");
        }
    }
}
