using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineeManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class updateTaskAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignment_LearningTasks_LearningTaskId",
                table: "TaskAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignment_Mentors_MentorId",
                table: "TaskAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignment_Trainees_TraineeId",
                table: "TaskAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskAssignment",
                table: "TaskAssignment");

            migrationBuilder.RenameTable(
                name: "TaskAssignment",
                newName: "TaskAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignment_TraineeId",
                table: "TaskAssignments",
                newName: "IX_TaskAssignments_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignment_MentorId",
                table: "TaskAssignments",
                newName: "IX_TaskAssignments_MentorId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignment_LearningTaskId",
                table: "TaskAssignments",
                newName: "IX_TaskAssignments_LearningTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskAssignments",
                table: "TaskAssignments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignments_LearningTasks_LearningTaskId",
                table: "TaskAssignments",
                column: "LearningTaskId",
                principalTable: "LearningTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignments_Mentors_MentorId",
                table: "TaskAssignments",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignments_Trainees_TraineeId",
                table: "TaskAssignments",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignments_LearningTasks_LearningTaskId",
                table: "TaskAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignments_Mentors_MentorId",
                table: "TaskAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssignments_Trainees_TraineeId",
                table: "TaskAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskAssignments",
                table: "TaskAssignments");

            migrationBuilder.RenameTable(
                name: "TaskAssignments",
                newName: "TaskAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignments_TraineeId",
                table: "TaskAssignment",
                newName: "IX_TaskAssignment_TraineeId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignments_MentorId",
                table: "TaskAssignment",
                newName: "IX_TaskAssignment_MentorId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskAssignments_LearningTaskId",
                table: "TaskAssignment",
                newName: "IX_TaskAssignment_LearningTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskAssignment",
                table: "TaskAssignment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignment_LearningTasks_LearningTaskId",
                table: "TaskAssignment",
                column: "LearningTaskId",
                principalTable: "LearningTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignment_Mentors_MentorId",
                table: "TaskAssignment",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssignment_Trainees_TraineeId",
                table: "TaskAssignment",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
