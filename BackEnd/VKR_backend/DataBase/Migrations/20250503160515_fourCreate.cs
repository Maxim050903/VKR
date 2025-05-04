using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class fourCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResumeEntity",
                table: "ResumeEntity");

            migrationBuilder.RenameTable(
                name: "ResumeEntity",
                newName: "Resumes");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ExperienceOnCompany",
                table: "Resumes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Experience",
                table: "Resumes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateStart",
                table: "Resumes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    idUser = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestType = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes");

            migrationBuilder.RenameTable(
                name: "Resumes",
                newName: "ResumeEntity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExperienceOnCompany",
                table: "ResumeEntity",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Experience",
                table: "ResumeEntity",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateStart",
                table: "ResumeEntity",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResumeEntity",
                table: "ResumeEntity",
                column: "Id");
        }
    }
}
