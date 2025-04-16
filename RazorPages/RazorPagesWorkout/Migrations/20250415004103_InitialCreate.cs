using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RazorPagesWorkout.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    Equipment = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    MuscleGroup = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Reps = table.Column<int>(type: "INTEGER", nullable: true),
                    Sets = table.Column<int>(type: "INTEGER", nullable: true),
                    Weight = table.Column<int>(type: "INTEGER", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExerciseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutLog_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutLog_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Duration", "Equipment", "MuscleGroup", "Name", "Reps", "Sets", "Type", "Weight" },
                values: new object[,]
                {
                    { 1, null, "", "Quads", "Legs", 15, 3, 1, null },
                    { 2, null, "", "Hamstrings", "Legs", 15, 3, 1, null },
                    { 3, null, "", "Abs", "Abs", 100, 3, 1, null },
                    { 4, null, "", "Biceps", "Arms", 10, 3, 1, null },
                    { 5, 120, "", "All", "Speed Walking", null, null, 0, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "morrilk@mail.nmc.edu", "Kyle Morrill" },
                    { 2, "lbalbach@nmc.edu", "Lisa Balbach" }
                });

            migrationBuilder.InsertData(
                table: "WorkoutLog",
                columns: new[] { "Id", "Date", "ExerciseId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Local), 1, 1 },
                    { 2, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Local), 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLog_ExerciseId",
                table: "WorkoutLog",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLog_UserId",
                table: "WorkoutLog",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutLog");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
