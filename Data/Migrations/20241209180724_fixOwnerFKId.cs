using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonReviewApp.Data.Migrations
{
    public partial class fixOwnerFKId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonOwners_Owners_PokemonId",
                table: "PokemonOwners");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonOwners_OwnerId",
                table: "PokemonOwners",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonOwners_Owners_OwnerId",
                table: "PokemonOwners",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonOwners_Owners_OwnerId",
                table: "PokemonOwners");

            migrationBuilder.DropIndex(
                name: "IX_PokemonOwners_OwnerId",
                table: "PokemonOwners");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonOwners_Owners_PokemonId",
                table: "PokemonOwners",
                column: "PokemonId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
