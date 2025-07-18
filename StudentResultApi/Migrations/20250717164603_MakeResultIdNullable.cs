using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentResultApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeResultIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultSubjects_Results_ResultId",
                table: "ResultSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "ResultId",
                table: "ResultSubjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultSubjects_Results_ResultId",
                table: "ResultSubjects",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultSubjects_Results_ResultId",
                table: "ResultSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "ResultId",
                table: "ResultSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ResultSubjects_Results_ResultId",
                table: "ResultSubjects",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
