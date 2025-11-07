using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Job_Application.Migrations
{
    /// <inheritdoc />
    public partial class AddAssessmentAssignmentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentAssignment_Assessments_AssessmentId",
                table: "AssessmentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentAssignment_JobSeekers_JobSeekerId",
                table: "AssessmentAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssessmentAssignment",
                table: "AssessmentAssignment");

            migrationBuilder.RenameTable(
                name: "AssessmentAssignment",
                newName: "AssessmentAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_AssessmentAssignment_JobSeekerId",
                table: "AssessmentAssignments",
                newName: "IX_AssessmentAssignments_JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_AssessmentAssignment_AssessmentId",
                table: "AssessmentAssignments",
                newName: "IX_AssessmentAssignments_AssessmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssessmentAssignments",
                table: "AssessmentAssignments",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentAssignments_Assessments_AssessmentId",
                table: "AssessmentAssignments",
                column: "AssessmentId",
                principalTable: "Assessments",
                principalColumn: "AssessmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentAssignments_JobSeekers_JobSeekerId",
                table: "AssessmentAssignments",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "JobSeekerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentAssignments_Assessments_AssessmentId",
                table: "AssessmentAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentAssignments_JobSeekers_JobSeekerId",
                table: "AssessmentAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssessmentAssignments",
                table: "AssessmentAssignments");

            migrationBuilder.RenameTable(
                name: "AssessmentAssignments",
                newName: "AssessmentAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_AssessmentAssignments_JobSeekerId",
                table: "AssessmentAssignment",
                newName: "IX_AssessmentAssignment_JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_AssessmentAssignments_AssessmentId",
                table: "AssessmentAssignment",
                newName: "IX_AssessmentAssignment_AssessmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssessmentAssignment",
                table: "AssessmentAssignment",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentAssignment_Assessments_AssessmentId",
                table: "AssessmentAssignment",
                column: "AssessmentId",
                principalTable: "Assessments",
                principalColumn: "AssessmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentAssignment_JobSeekers_JobSeekerId",
                table: "AssessmentAssignment",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "JobSeekerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
