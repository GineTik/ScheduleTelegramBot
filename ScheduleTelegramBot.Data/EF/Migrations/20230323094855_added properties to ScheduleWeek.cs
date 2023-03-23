using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleTelegramBot.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class addedpropertiestoScheduleWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ScheduleWeeks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ScheduleDays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ScheduleWeeks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ScheduleDays");
        }
    }
}
