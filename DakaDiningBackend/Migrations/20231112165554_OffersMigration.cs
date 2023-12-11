using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DakaDiningBackend.Migrations
{
    /// <inheritdoc />
    public partial class OffersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    OfferedById = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    OfferedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Purchased = table.Column<bool>(type: "INTEGER", nullable: false),
                    PurchasedById = table.Column<string>(type: "TEXT", nullable: false),
                    PurchasedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferEntity_Users_OfferedById",
                        column: x => x.OfferedById,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferEntity_Users_PurchasedById",
                        column: x => x.PurchasedById,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferEntity_OfferedById",
                table: "OfferEntity",
                column: "OfferedById");

            migrationBuilder.CreateIndex(
                name: "IX_OfferEntity_PurchasedById",
                table: "OfferEntity",
                column: "PurchasedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferEntity");
        }
    }
}
