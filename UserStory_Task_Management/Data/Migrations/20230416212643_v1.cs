using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_UserStory_userStoryId",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "userStoryState",
                table: "UserStory",
                newName: "UserStoryState");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "UserStory",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "estimatedDuration",
                table: "UserStory",
                newName: "EstimatedDuration");

            migrationBuilder.RenameColumn(
                name: "userStoryId",
                table: "Task",
                newName: "UserStoryId");

            migrationBuilder.RenameColumn(
                name: "taskState",
                table: "Task",
                newName: "TaskState");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Task",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "estimatedDuration",
                table: "Task",
                newName: "EstimatedDuration");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Task",
                newName: "EndDate");

            migrationBuilder.RenameIndex(
                name: "IX_Task_userStoryId",
                table: "Task",
                newName: "IX_Task_UserStoryId");

            migrationBuilder.AddColumn<int>(
                name: "Complexity",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_UserStory_UserStoryId",
                table: "Task",
                column: "UserStoryId",
                principalTable: "UserStory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_UserStory_UserStoryId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Complexity",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "UserStoryState",
                table: "UserStory",
                newName: "userStoryState");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "UserStory",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EstimatedDuration",
                table: "UserStory",
                newName: "estimatedDuration");

            migrationBuilder.RenameColumn(
                name: "UserStoryId",
                table: "Task",
                newName: "userStoryId");

            migrationBuilder.RenameColumn(
                name: "TaskState",
                table: "Task",
                newName: "taskState");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Task",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EstimatedDuration",
                table: "Task",
                newName: "estimatedDuration");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Task",
                newName: "endDate");

            migrationBuilder.RenameIndex(
                name: "IX_Task_UserStoryId",
                table: "Task",
                newName: "IX_Task_userStoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_UserStory_userStoryId",
                table: "Task",
                column: "userStoryId",
                principalTable: "UserStory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
