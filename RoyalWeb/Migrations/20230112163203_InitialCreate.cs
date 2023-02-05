using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyEvent",
                columns: table => new
                {
                    DailyEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyEventName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyEvent", x => x.DailyEventId);
                });

            migrationBuilder.CreateTable(
                name: "Holding",
                columns: table => new
                {
                    HoldingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoldingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holding", x => x.HoldingId);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyHonor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.HouseId);
                });

            migrationBuilder.CreateTable(
                name: "Palace",
                columns: table => new
                {
                    PalaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PalaceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palace", x => x.PalaceId);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyEvent",
                columns: table => new
                {
                    WeeklyEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeeklyEventName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyEvent", x => x.WeeklyEventId);
                });

            migrationBuilder.CreateTable(
                name: "YearlyEvent",
                columns: table => new
                {
                    YearlyEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearlyEventName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearlyEvent", x => x.YearlyEventId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PalaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_Palace_PalaceId",
                        column: x => x.PalaceId,
                        principalTable: "Palace",
                        principalColumn: "PalaceId");
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: true),
                    Honor = table.Column<int>(type: "int", nullable: false),
                    Reputation = table.Column<int>(type: "int", nullable: false),
                    Appearance = table.Column<int>(type: "int", nullable: false),
                    Extrovertness = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Sexuality = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Alive = table.Column<bool>(type: "bit", nullable: false),
                    CourtId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Character_House_HouseId",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "HouseId");
                });

            migrationBuilder.CreateTable(
                name: "Court",
                columns: table => new
                {
                    CourtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonarchCharacterId = table.Column<int>(type: "int", nullable: false),
                    PalaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Court", x => x.CourtId);
                    table.ForeignKey(
                        name: "FK_Court_Character_MonarchCharacterId",
                        column: x => x.MonarchCharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Court_Palace_PalaceId",
                        column: x => x.PalaceId,
                        principalTable: "Palace",
                        principalColumn: "PalaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interaction",
                columns: table => new
                {
                    InteractionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InteractionHolder1CharacterId = table.Column<int>(type: "int", nullable: false),
                    InteractionHolder2CharacterId = table.Column<int>(type: "int", nullable: true),
                    InteractionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interaction", x => x.InteractionId);
                    table.ForeignKey(
                        name: "FK_Interaction_Character_InteractionHolder1CharacterId",
                        column: x => x.InteractionHolder1CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interaction_Character_InteractionHolder2CharacterId",
                        column: x => x.InteractionHolder2CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId");
                });

            migrationBuilder.CreateTable(
                name: "Opinion",
                columns: table => new
                {
                    OpinionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpinionHolderCharacterId = table.Column<int>(type: "int", nullable: false),
                    OpinionOf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpinionValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinion", x => x.OpinionId);
                    table.ForeignKey(
                        name: "FK_Opinion_Character_OpinionHolderCharacterId",
                        column: x => x.OpinionHolderCharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoldingId = table.Column<int>(type: "int", nullable: true),
                    OwnerCharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.TitleId);
                    table.ForeignKey(
                        name: "FK_Title_Character_OwnerCharacterId",
                        column: x => x.OwnerCharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_Title_Holding_HoldingId",
                        column: x => x.HoldingId,
                        principalTable: "Holding",
                        principalColumn: "HoldingId");
                });

            migrationBuilder.CreateTable(
                name: "MemoryRC",
                columns: table => new
                {
                    MemoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConnectedInteractionInteractionId = table.Column<int>(type: "int", nullable: true),
                    CharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryRC", x => x.MemoryId);
                    table.ForeignKey(
                        name: "FK_MemoryRC_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_MemoryRC_Interaction_ConnectedInteractionInteractionId",
                        column: x => x.ConnectedInteractionInteractionId,
                        principalTable: "Interaction",
                        principalColumn: "InteractionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_CourtId",
                table: "Character",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_HouseId",
                table: "Character",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Court_MonarchCharacterId",
                table: "Court",
                column: "MonarchCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Court_PalaceId",
                table: "Court",
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
                name: "IX_Opinion_OpinionHolderCharacterId",
                table: "Opinion",
                column: "OpinionHolderCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_PalaceId",
                table: "Room",
                column: "PalaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_HoldingId",
                table: "Title",
                column: "HoldingId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_OwnerCharacterId",
                table: "Title",
                column: "OwnerCharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Court_CourtId",
                table: "Character",
                column: "CourtId",
                principalTable: "Court",
                principalColumn: "CourtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Court_CourtId",
                table: "Character");

            migrationBuilder.DropTable(
                name: "DailyEvent");

            migrationBuilder.DropTable(
                name: "MemoryRC");

            migrationBuilder.DropTable(
                name: "Opinion");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "WeeklyEvent");

            migrationBuilder.DropTable(
                name: "YearlyEvent");

            migrationBuilder.DropTable(
                name: "Interaction");

            migrationBuilder.DropTable(
                name: "Holding");

            migrationBuilder.DropTable(
                name: "Court");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Palace");

            migrationBuilder.DropTable(
                name: "House");
        }
    }
}
