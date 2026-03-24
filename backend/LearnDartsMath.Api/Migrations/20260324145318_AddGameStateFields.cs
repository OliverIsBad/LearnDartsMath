using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnDartsMath.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddGameStateFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartetAt",
                table: "TrainingSessions",
                newName: "StartedAt");

            migrationBuilder.AddColumn<int>(
                name: "CurrentScore",
                table: "TrainingSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "TrainingSessions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StartScore",
                table: "TrainingSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ThrowEntries",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentScore",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "StartScore",
                table: "TrainingSessions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ThrowEntries");

            migrationBuilder.RenameColumn(
                name: "StartedAt",
                table: "TrainingSessions",
                newName: "StartetAt");
        }
    }
}
