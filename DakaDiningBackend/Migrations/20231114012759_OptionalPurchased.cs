using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DakaDiningBackend.Migrations
{
    /// <inheritdoc />
    public partial class OptionalPurchased : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_PurchasedById",
                table: "Offers");

            migrationBuilder.AlterColumn<string>(
                name: "PurchasedById",
                table: "Offers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchasedAt",
                table: "Offers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_PurchasedById",
                table: "Offers",
                column: "PurchasedById",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_PurchasedById",
                table: "Offers");

            migrationBuilder.AlterColumn<string>(
                name: "PurchasedById",
                table: "Offers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchasedAt",
                table: "Offers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_PurchasedById",
                table: "Offers",
                column: "PurchasedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
