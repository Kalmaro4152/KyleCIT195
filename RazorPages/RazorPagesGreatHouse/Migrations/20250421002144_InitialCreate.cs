using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RazorPagesGreatHouse.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Clan = table.Column<int>(type: "INTEGER", nullable: false),
                    Slaver = table.Column<bool>(type: "INTEGER", nullable: false),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Characteristic = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Race = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    HouseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_House_HouseId",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "House",
                columns: new[] { "Id", "Characteristic", "Clan", "Slaver", "Strength" },
                values: new object[,]
                {
                    { 1, "Greedy", 0, false, 50000 },
                    { 2, "Traditionalist", 1, false, 10000 }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Health", "HouseId", "Level", "Name", "Race" },
                values: new object[,]
                {
                    { 1, 50, 1, 10, "Umbacano", 7 },
                    { 2, 25, 1, 5, "Zainsubani", 8 },
                    { 3, 200, 2, 30, "Smelrik", 6 },
                    { 4, 200, 2, 50, "Sotha", 8 },
                    { 5, 30, 2, 4, "Gamer", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_HouseId",
                table: "Person",
                column: "HouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "House");
        }
    }
}
