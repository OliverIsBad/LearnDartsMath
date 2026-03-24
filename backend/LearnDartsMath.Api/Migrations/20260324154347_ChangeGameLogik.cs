using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearnDartsMath.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGameLogik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThrowEntries");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "TrainingSessions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TurnEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainingSessionId = table.Column<int>(type: "integer", nullable: false),
                    PreviousScore = table.Column<int>(type: "integer", nullable: false),
                    EnteredScoredPoints = table.Column<int>(type: "integer", nullable: false),
                    EnteredRemainingScore = table.Column<int>(type: "integer", nullable: false),
                    CorrectRemainingScore = table.Column<int>(type: "integer", nullable: false),
                    IsScoreValid = table.Column<bool>(type: "boolean", nullable: false),
                    IsRemainingCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurnEntries_TrainingSessions_TrainingSessionId",
                        column: x => x.TrainingSessionId,
                        principalTable: "TrainingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TurnEntries_TrainingSessionId",
                table: "TurnEntries",
                column: "TrainingSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurnEntries");

            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "TrainingSessions");

            migrationBuilder.CreateTable(
                name: "ThrowEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainingSessionId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DartNumber = table.Column<int>(type: "integer", nullable: false),
                    RemainingScore = table.Column<int>(type: "integer", nullable: false),
                    ScoredPoints = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThrowEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThrowEntries_TrainingSessions_TrainingSessionId",
                        column: x => x.TrainingSessionId,
                        principalTable: "TrainingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThrowEntries_TrainingSessionId",
                table: "ThrowEntries",
                column: "TrainingSessionId");
        }
    }
}
