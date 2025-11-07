using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_Application.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePicturesAndCompanyLogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfilePictureFileId",
                table: "JobSeekers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyLogoFileId",
                table: "Employers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekers_ProfilePictureFileId",
                table: "JobSeekers",
                column: "ProfilePictureFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_CompanyLogoFileId",
                table: "Employers",
                column: "CompanyLogoFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_UploadedFiles_CompanyLogoFileId",
                table: "Employers",
                column: "CompanyLogoFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSeekers_UploadedFiles_ProfilePictureFileId",
                table: "JobSeekers",
                column: "ProfilePictureFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employers_UploadedFiles_CompanyLogoFileId",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSeekers_UploadedFiles_ProfilePictureFileId",
                table: "JobSeekers");

            migrationBuilder.DropIndex(
                name: "IX_JobSeekers_ProfilePictureFileId",
                table: "JobSeekers");

            migrationBuilder.DropIndex(
                name: "IX_Employers_CompanyLogoFileId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "ProfilePictureFileId",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "CompanyLogoFileId",
                table: "Employers");
        }
    }
}
