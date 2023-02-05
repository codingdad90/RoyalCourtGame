using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalCourtWebapp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyEvents",
                columns: table => new
                {
                    DailyEventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DailyEventName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyEvents", x => x.DailyEventId);
                });

            migrationBuilder.CreateTable(
                name: "Holdings",
                columns: table => new
                {
                    HoldingsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HoldingsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holdings", x => x.HoldingsId);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HouseName = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyHonor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseId);
                });

            migrationBuilder.CreateTable(
                name: "Palaces",
                columns: table => new
                {
                    PalaceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PalaceName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palaces", x => x.PalaceId);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyEvents",
                columns: table => new
                {
                    WeeklyEventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeeklyEventName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyEvents", x => x.WeeklyEventId);
                });

            migrationBuilder.CreateTable(
                name: "YearlyEvents",
                columns: table => new
                {
                    YearlyEventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YearlyEventName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlyEvents", x => x.YearlyEventId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomName = table.Column<string>(type: "TEXT", nullable: false),
                    PalaceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Palaces_PalaceId",
                        column: x => x.PalaceId,
                        principalTable: "Palaces",
                        principalColumn: "PalaceId");
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterName = table.Column<string>(type: "TEXT", nullable: false),
                    HouseId = table.Column<int>(type: "INTEGER", nullable: true),
                    Honor = table.Column<int>(type: "INTEGER", nullable: false),
                    Reputation = table.Column<int>(type: "INTEGER", nullable: false),
                    Appearance = table.Column<int>(type: "INTEGER", nullable: false),
                    Extrovertness = table.Column<int>(type: "INTEGER", nullable: false),
                    Intelligence = table.Column<int>(type: "INTEGER", nullable: false),
                    Sexuality = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Alive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CourtId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "HouseId");
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    CourtId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourtName = table.Column<string>(type: "TEXT", nullable: false),
                    MonarchCharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    PalaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.CourtId);
                    table.ForeignKey(
                        name: "FK_Courts_Characters_MonarchCharacterId",
                        column: x => x.MonarchCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courts_Palaces_PalaceId",
                        column: x => x.PalaceId,
                        principalTable: "Palaces",
                        principalColumn: "PalaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interaction",
                columns: table => new
                {
                    InteractionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InteractionHolder1CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    InteractionHolder2CharacterId = table.Column<int>(type: "INTEGER", nullable: true),
                    InteractionText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interaction", x => x.InteractionId);
                    table.ForeignKey(
                        name: "FK_Interaction_Characters_InteractionHolder1CharacterId",
                        column: x => x.InteractionHolder1CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interaction_Characters_InteractionHolder2CharacterId",
                        column: x => x.InteractionHolder2CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId");
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    OpinionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OpinionHolderCharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    OpinionOf = table.Column<string>(type: "TEXT", nullable: false),
                    OpinionValue = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.OpinionId);
                    table.ForeignKey(
                        name: "FK_Opinions_Characters_OpinionHolderCharacterId",
                        column: x => x.OpinionHolderCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TitleName = table.Column<string>(type: "TEXT", nullable: false),
                    HoldingsId = table.Column<int>(type: "INTEGER", nullable: true),
                    OwnerCharacterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.TitleId);
                    table.ForeignKey(
                        name: "FK_Titles_Characters_OwnerCharacterId",
                        column: x => x.OwnerCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_Titles_Holdings_HoldingsId",
                        column: x => x.HoldingsId,
                        principalTable: "Holdings",
                        principalColumn: "HoldingsId");
                });

            migrationBuilder.CreateTable(
                name: "MemoryRC",
                columns: table => new
                {
                    MemoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemoryName = table.Column<string>(type: "TEXT", nullable: false),
                    ConnectedInteractionInteractionId = table.Column<int>(type: "INTEGER", nullable: true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryRC", x => x.MemoryId);
                    table.ForeignKey(
                        name: "FK_MemoryRC_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_MemoryRC_Interaction_ConnectedInteractionInteractionId",
                        column: x => x.ConnectedInteractionInteractionId,
                        principalTable: "Interaction",
                        principalColumn: "InteractionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CourtId",
                table: "Characters",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HouseId",
                table: "Characters",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_MonarchCharacterId",
                table: "Courts",
                column: "MonarchCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_PalaceId",
                table: "Courts",
                column: "PalaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_InteractionHolder1CharacterId",
                table: "Interaction",
                column: "InteractionHolder1CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Interaction_InteractionHolder2CharacterId",
                table: "Interaction",
                column: "InteractionHolder2CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoryRC_CharacterId",
                table: "MemoryRC",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_MemoryRC_ConnectedInteractionInteractionId",
                table: "MemoryRC",
                column: "ConnectedInteractionInteractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_OpinionHolderCharacterId",
                table: "Opinions",
                column: "OpinionHolderCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PalaceId",
                table: "Rooms",
                column: "PalaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_HoldingsId",
                table: "Titles",
                column: "HoldingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_OwnerCharacterId",
                table: "Titles",
                column: "OwnerCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Courts_CourtId",
                table: "Characters",
                column: "CourtId",
                principalTable: "Courts",
                principalColumn: "CourtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Courts_CourtId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "DailyEvents");

            migrationBuilder.DropTable(
                name: "MemoryRC");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "WeeklyEvents");

            migrationBuilder.DropTable(
                name: "YearlyEvents");

            migrationBuilder.DropTable(
                name: "Interaction");

            migrationBuilder.DropTable(
                name: "Holdings");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Palaces");

            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
