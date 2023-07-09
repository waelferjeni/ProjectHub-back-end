using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class add_attributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_UserStory_UserStoryId",
                table: "Task");

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

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Task",
                newName: "employeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_UserStoryId",
                table: "Task",
                newName: "IX_Task_userStoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "projectId",
                table: "Task",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "sprintId",
                table: "Task",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Task_UserStory_userStoryId",
                table: "Task",
                column: "userStoryId",
                principalTable: "UserStory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_UserStory_userStoryId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "projectId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "sprintId",
                table: "Task");

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

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "Task",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_userStoryId",
                table: "Task",
                newName: "IX_Task_UserStoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_UserStory_UserStoryId",
                table: "Task",
                column: "UserStoryId",
                principalTable: "UserStory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
