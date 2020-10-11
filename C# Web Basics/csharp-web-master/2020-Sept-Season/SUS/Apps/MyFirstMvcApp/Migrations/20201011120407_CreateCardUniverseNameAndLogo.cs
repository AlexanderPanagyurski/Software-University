using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleCards.Migrations
{
    public partial class CreateCardUniverseNameAndLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cards",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "UniverseLogoUrl",
                table: "Cards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniverseName",
                table: "Cards",
                maxLength: 40,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniverseLogoUrl",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "UniverseName",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cards",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);
        }
    }
}
