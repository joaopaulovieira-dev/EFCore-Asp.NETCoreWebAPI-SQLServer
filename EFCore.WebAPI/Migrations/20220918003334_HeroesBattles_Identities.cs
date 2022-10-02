using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.WebAPI.Migrations
{
    public partial class HeroesBattles_Identities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Battles_BatalhaId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_BatalhaId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "BatalhaId",
                table: "Heroes");

            migrationBuilder.CreateTable(
                name: "HeroBattles",
                columns: table => new
                {
                    HeroId = table.Column<int>(nullable: false),
                    BatalhaId = table.Column<int>(nullable: false),
                    BattleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroBattles", x => new { x.BatalhaId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_HeroBattles_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeroBattles_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecretIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nomereal = table.Column<int>(nullable: false),
                    HeroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretIdentities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretIdentities_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroBattles_BattleId",
                table: "HeroBattles",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroBattles_HeroId",
                table: "HeroBattles",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentities_HeroId",
                table: "SecretIdentities",
                column: "HeroId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroBattles");

            migrationBuilder.DropTable(
                name: "SecretIdentities");

            migrationBuilder.AddColumn<int>(
                name: "BatalhaId",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_BatalhaId",
                table: "Heroes",
                column: "BatalhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Battles_BatalhaId",
                table: "Heroes",
                column: "BatalhaId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
