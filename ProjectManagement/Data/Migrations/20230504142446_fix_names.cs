using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class fix_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Projects_Fk_ProjectId",
                table: "Sprints");

            migrationBuilder.RenameColumn(
                name: "Fk_ProjectId",
                table: "Sprints",
                newName: "projectId");

            migrationBuilder.RenameColumn(
                name: "DurationEstimated",
                table: "Sprints",
                newName: "realDuration");

            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Sprints",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "Sprints",
                newName: "endDate");

            migrationBuilder.RenameIndex(
                name: "IX_Sprints_Fk_ProjectId",
                table: "Sprints",
                newName: "IX_Sprints_projectId");

            migrationBuilder.AddColumn<int>(
                name: "estimatedDuration",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Projects_projectId",
                table: "Sprints",
                column: "projectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Projects_projectId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "estimatedDuration",
                table: "Sprints");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Sprints",
                newName: "DateStart");

            migrationBuilder.RenameColumn(
                name: "realDuration",
                table: "Sprints",
                newName: "DurationEstimated");

            migrationBuilder.RenameColumn(
                name: "projectId",
                table: "Sprints",
                newName: "Fk_ProjectId");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Sprints",
                newName: "DateEnd");

            migrationBuilder.RenameIndex(
                name: "IX_Sprints_projectId",
                table: "Sprints",
                newName: "IX_Sprints_Fk_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Projects_Fk_ProjectId",
                table: "Sprints",
                column: "Fk_ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
