using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaniT.Migrations
{
    /// <inheritdoc />
    public partial class sdkfdsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FutureVisionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureVisionItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodayTemplateItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodayTemplateItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DayTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayTasks_DayCards_DayCardId",
                        column: x => x.DayCardId,
                        principalTable: "DayCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayTasks_DayCardId",
                table: "DayTasks",
                column: "DayCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayTasks");

            migrationBuilder.DropTable(
                name: "FutureVisionItems");

            migrationBuilder.DropTable(
                name: "TodayTemplateItems");

            migrationBuilder.DropTable(
                name: "DayCards");
        }
    }
}
