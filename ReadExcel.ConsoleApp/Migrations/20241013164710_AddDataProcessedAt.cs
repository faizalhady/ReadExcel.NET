using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadExcel.ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDataProcessedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataProcessedAt",
                table: "RejectedFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataProcessedAt",
                table: "LogData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataProcessedAt",
                table: "RejectedFiles");

            migrationBuilder.DropColumn(
                name: "DataProcessedAt",
                table: "LogData");
        }
    }
}
