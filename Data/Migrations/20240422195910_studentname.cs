using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LABB_2.Data.Migrations
{
    /// <inheritdoc />
    public partial class studentname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StduentName",
                table: "Students",
                newName: "StudentName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Students",
                newName: "StduentName");
        }
    }
}
