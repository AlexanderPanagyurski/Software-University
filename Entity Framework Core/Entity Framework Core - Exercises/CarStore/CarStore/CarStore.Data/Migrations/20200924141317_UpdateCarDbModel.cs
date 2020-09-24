using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarStore.Data.Migrations
{
    public partial class UpdateCarDbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ArchivedOn",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BannedOn",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedOn",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBanned",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPromoted",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReported",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PromotedOn",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PromotedUntil",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportedOn",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Cars",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchivedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "BannedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EditedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsBanned",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsPromoted",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsReported",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PromotedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PromotedUntil",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ReportedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Cars");
        }
    }
}
