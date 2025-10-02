using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorLiveMentor.Migrations
{
    /// <inheritdoc />
    public partial class AddSelectedSubjectToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedSubject",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedSubject",
                table: "Students");
        }
    }
}
