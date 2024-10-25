using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCA.Migrations
{
    /// <inheritdoc />
    public partial class AddInvestmentSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Investments_CoinPriceHistories_Symbol_Date",
                table: "Investments");

            migrationBuilder.DropIndex(
                name: "IX_Investments_Symbol_Date",
                table: "Investments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoinPriceHistories",
                table: "CoinPriceHistories");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "Investments");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Investments",
                newName: "FiatAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "CryptoAmount",
                table: "Investments",
                type: "decimal(18,5)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CoinPriceHistories",
                type: "decimal(18,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CoinPriceHistories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoinPriceHistories",
                table: "CoinPriceHistories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CoinPriceHistories_Symbol_Date",
                table: "CoinPriceHistories",
                columns: new[] { "Symbol", "Date" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CoinPriceHistories",
                table: "CoinPriceHistories");

            migrationBuilder.DropIndex(
                name: "IX_CoinPriceHistories_Symbol_Date",
                table: "CoinPriceHistories");

            migrationBuilder.DropColumn(
                name: "CryptoAmount",
                table: "Investments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CoinPriceHistories");

            migrationBuilder.RenameColumn(
                name: "FiatAmount",
                table: "Investments",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "Investments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "CoinPriceHistories",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoinPriceHistories",
                table: "CoinPriceHistories",
                columns: new[] { "Symbol", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_Investments_Symbol_Date",
                table: "Investments",
                columns: new[] { "Symbol", "Date" });

            migrationBuilder.AddForeignKey(
                name: "FK_Investments_CoinPriceHistories_Symbol_Date",
                table: "Investments",
                columns: new[] { "Symbol", "Date" },
                principalTable: "CoinPriceHistories",
                principalColumns: new[] { "Symbol", "Date" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
