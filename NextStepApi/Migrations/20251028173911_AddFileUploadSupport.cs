using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_Application.Migrations
{
    /// <inheritdoc />
    public partial class AddFileUploadSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResumeUrl",
                table: "JobSeekers");

            migrationBuilder.AddColumn<int>(
                name: "ResumeFileId",
                table: "JobSeekers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UploadedFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OriginalFileName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    StoredFileName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: false),
                    ContentType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UploadDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UploadedByUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    FileCategory = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadedFiles_Users_UploadedByUserId",
                        column: x => x.UploadedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_ResumeFileId",
                table: "JobSeekers",
                column: "ResumeFileId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_UploadedByUserId",
                table: "UploadedFiles",
                column: "UploadedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_UploadedFiles_ResumeFileId",
                table: "JobSeekers",
                column: "ResumeFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_UploadedFiles_ResumeFileId",
                table: "JobSeekers");

            migrationBuilder.DropTable(
                name: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_JobSeekers_ResumeFileId",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "ResumeFileId",
                table: "JobSeekers");

            migrationBuilder.AddColumn<string>(
                name: "ResumeUrl",
                table: "JobSeekers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
