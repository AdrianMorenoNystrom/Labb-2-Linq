using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LABB_2.Data.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "CourseClasses");

            migrationBuilder.AddColumn<int>(
                name: "FkCourseId",
                table: "CourseClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseClasses_FkCourseId",
                table: "CourseClasses",
                column: "FkCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseClasses_Courses_FkCourseId",
                table: "CourseClasses",
                column: "FkCourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseClasses_Courses_FkCourseId",
                table: "CourseClasses");

            migrationBuilder.DropIndex(
                name: "IX_CourseClasses_FkCourseId",
                table: "CourseClasses");

            migrationBuilder.DropColumn(
                name: "FkCourseId",
                table: "CourseClasses");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CourseClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
