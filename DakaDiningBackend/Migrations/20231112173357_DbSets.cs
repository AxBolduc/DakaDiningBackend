using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DakaDiningBackend.Migrations
{
    /// <inheritdoc />
    public partial class DbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferEntity_Users_OfferedById",
                table: "OfferEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferEntity_Users_PurchasedById",
                table: "OfferEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestEntity_Users_FilledById",
                table: "RequestEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestEntity_Users_RequestedById",
                table: "RequestEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionEntity_Users_UserId",
                table: "SessionEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionEntity",
                table: "SessionEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestEntity",
                table: "RequestEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferEntity",
                table: "OfferEntity");

            migrationBuilder.RenameTable(
                name: "SessionEntity",
                newName: "Sessions");

            migrationBuilder.RenameTable(
                name: "RequestEntity",
                newName: "Requests");

            migrationBuilder.RenameTable(
                name: "OfferEntity",
                newName: "Offers");

            migrationBuilder.RenameIndex(
                name: "IX_SessionEntity_UserId",
                table: "Sessions",
                newName: "IX_Sessions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestEntity_RequestedById",
                table: "Requests",
                newName: "IX_Requests_RequestedById");

            migrationBuilder.RenameIndex(
                name: "IX_RequestEntity_FilledById",
                table: "Requests",
                newName: "IX_Requests_FilledById");

            migrationBuilder.RenameIndex(
                name: "IX_OfferEntity_PurchasedById",
                table: "Offers",
                newName: "IX_Offers_PurchasedById");

            migrationBuilder.RenameIndex(
                name: "IX_OfferEntity_OfferedById",
                table: "Offers",
                newName: "IX_Offers_OfferedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_OfferedById",
                table: "Offers",
                column: "OfferedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_PurchasedById",
                table: "Offers",
                column: "PurchasedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_FilledById",
                table: "Requests",
                column: "FilledById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_RequestedById",
                table: "Requests",
                column: "RequestedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_OfferedById",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_PurchasedById",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_FilledById",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_RequestedById",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.RenameTable(
                name: "Sessions",
                newName: "SessionEntity");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "RequestEntity");

            migrationBuilder.RenameTable(
                name: "Offers",
                newName: "OfferEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_UserId",
                table: "SessionEntity",
                newName: "IX_SessionEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestedById",
                table: "RequestEntity",
                newName: "IX_RequestEntity_RequestedById");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_FilledById",
                table: "RequestEntity",
                newName: "IX_RequestEntity_FilledById");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_PurchasedById",
                table: "OfferEntity",
                newName: "IX_OfferEntity_PurchasedById");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_OfferedById",
                table: "OfferEntity",
                newName: "IX_OfferEntity_OfferedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionEntity",
                table: "SessionEntity",
                column: "SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestEntity",
                table: "RequestEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferEntity",
                table: "OfferEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferEntity_Users_OfferedById",
                table: "OfferEntity",
                column: "OfferedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferEntity_Users_PurchasedById",
                table: "OfferEntity",
                column: "PurchasedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestEntity_Users_FilledById",
                table: "RequestEntity",
                column: "FilledById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestEntity_Users_RequestedById",
                table: "RequestEntity",
                column: "RequestedById",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionEntity_Users_UserId",
                table: "SessionEntity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
