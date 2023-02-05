using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalWeb.Migrations
{
    /// <inheritdoc />
    public partial class Try4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinion_Character_OpinionHolderCharacterId",
                table: "Opinion");

            migrationBuilder.DropColumn(
                name: "OpinionOf",
                table: "Opinion");

            migrationBuilder.RenameColumn(
                name: "OpinionHolderCharacterId",
                table: "Opinion",
                newName: "OpinionOfCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Opinion_OpinionHolderCharacterId",
                table: "Opinion",
                newName: "IX_Opinion_OpinionOfCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinion_Character_OpinionOfCharacterId",
                table: "Opinion",
                column: "OpinionOfCharacterId",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinion_Character_OpinionOfCharacterId",
                table: "Opinion");

            migrationBuilder.RenameColumn(
                name: "OpinionOfCharacterId",
                table: "Opinion",
                newName: "OpinionHolderCharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_Opinion_OpinionOfCharacterId",
                table: "Opinion",
                newName: "IX_Opinion_OpinionHolderCharacterId");

            migrationBuilder.AddColumn<string>(
                name: "OpinionOf",
                table: "Opinion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinion_Character_OpinionHolderCharacterId",
                table: "Opinion",
                column: "OpinionHolderCharacterId",
                principalTable: "Character",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
