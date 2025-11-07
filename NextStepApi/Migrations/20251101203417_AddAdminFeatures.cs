using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_Application.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeactivatedAt",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeactivatedByAdminId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeactivationReason",
                table: "Users",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByAdminId",
                table: "Notifications",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NotificationType",
                table: "Notifications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetRole",
                table: "Notifications",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FlaggedAt",
                table: "JobPosts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFlagged",
                table: "JobPosts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "JobPosts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RemovalReason",
                table: "JobPosts",
                type: "TEXT",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedAt",
                table: "JobPosts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemovedByAdminId",
                table: "JobPosts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Employers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "Employers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedByAdminId",
                table: "Employers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RejectedAt",
                table: "Employers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "Employers",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedAt",
                table: "Employers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountActions",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionType = table.Column<int>(type: "INTEGER", nullable: false),
                    PerformedByAdminId = table.Column<int>(type: "INTEGER", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    ActionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountActions", x => x.ActionId);
                    table.ForeignKey(
                        name: "FK_AccountActions_Admins_PerformedByAdminId",
                        column: x => x.PerformedByAdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    FaqId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Answer = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    DisplayOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedByAdminId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.FaqId);
                    table.ForeignKey(
                        name: "FK_FAQs_Admins_CreatedByAdminId",
                        column: x => x.CreatedByAdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_RemovedByAdminId",
                table: "JobPosts",
                column: "RemovedByAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_ApprovedByAdminId",
                table: "Employers",
                column: "ApprovedByAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountActions_PerformedByAdminId",
                table: "AccountActions",
                column: "PerformedByAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountActions_UserId",
                table: "AccountActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_CreatedByAdminId",
                table: "FAQs",
                column: "CreatedByAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_Admins_ApprovedByAdminId",
                table: "Employers",
                column: "ApprovedByAdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobPosts_Admins_RemovedByAdminId",
                table: "JobPosts",
                column: "RemovedByAdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Admins_ApprovedByAdminId",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobPosts_Admins_RemovedByAdminId",
                table: "JobPosts");

            migrationBuilder.DropTable(
                name: "AccountActions");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropIndex(
                name: "IX_JobPosts_RemovedByAdminId",
                table: "JobPosts");

            migrationBuilder.DropIndex(
                name: "IX_Employers_ApprovedByAdminId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "DeactivatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeactivatedByAdminId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeactivationReason",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedByAdminId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotificationType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TargetRole",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "FlaggedAt",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "IsFlagged",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "RemovalReason",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "RemovedAt",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "RemovedByAdminId",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "ApprovedByAdminId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "RejectedAt",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "ReviewedAt",
                table: "Employers");
        }
    }
}
