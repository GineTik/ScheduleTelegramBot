using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleTelegramBot.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleWeeks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleWeeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleWeeks_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleWeekId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleDays_ScheduleWeeks_ScheduleWeekId",
                        column: x => x.ScheduleWeekId,
                        principalTable: "ScheduleWeeks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScheduleLessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonPosition = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LessonType = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleLessons_ScheduleDays_ScheduleDayId",
                        column: x => x.ScheduleDayId,
                        principalTable: "ScheduleDays",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduleLessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDays_ScheduleWeekId",
                table: "ScheduleDays",
                column: "ScheduleWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLessons_ScheduleDayId",
                table: "ScheduleLessons",
                column: "ScheduleDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleLessons_TeacherId",
                table: "ScheduleLessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWeeks_ScheduleId",
                table: "ScheduleWeeks",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleLessons");

            migrationBuilder.DropTable(
                name: "ScheduleDays");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "ScheduleWeeks");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
