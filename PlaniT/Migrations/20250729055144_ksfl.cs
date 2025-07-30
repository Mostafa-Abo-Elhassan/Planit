using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaniT.Migrations
{
    /// <inheritdoc />
    public partial class ksfl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayCards_AspNetUsers_UserId",
                table: "DayCards");

            migrationBuilder.DropForeignKey(
                name: "FK_DayTasks_AspNetUsers_UserId",
                table: "DayTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_FutureVisionItems_AspNetUsers_UserId",
                table: "FutureVisionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodayTemplateItems_AspNetUsers_UserId",
                table: "TodayTemplateItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TodayTemplateItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FutureVisionItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DayTasks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DayCards",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DayCards_AspNetUsers_UserId",
                table: "DayCards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayTasks_AspNetUsers_UserId",
                table: "DayTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FutureVisionItems_AspNetUsers_UserId",
                table: "FutureVisionItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodayTemplateItems_AspNetUsers_UserId",
                table: "TodayTemplateItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayCards_AspNetUsers_UserId",
                table: "DayCards");

            migrationBuilder.DropForeignKey(
                name: "FK_DayTasks_AspNetUsers_UserId",
                table: "DayTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_FutureVisionItems_AspNetUsers_UserId",
                table: "FutureVisionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodayTemplateItems_AspNetUsers_UserId",
                table: "TodayTemplateItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TodayTemplateItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FutureVisionItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DayTasks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "DayCards",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_DayCards_AspNetUsers_UserId",
                table: "DayCards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayTasks_AspNetUsers_UserId",
                table: "DayTasks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FutureVisionItems_AspNetUsers_UserId",
                table: "FutureVisionItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodayTemplateItems_AspNetUsers_UserId",
                table: "TodayTemplateItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
