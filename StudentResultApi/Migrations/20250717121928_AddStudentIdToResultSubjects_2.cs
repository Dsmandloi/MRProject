using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentResultApi.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentIdToResultSubjects_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "ResultSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ResultSubjects");
        }
    }
}
