using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class Add_Instructor_Availability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Availability",
                table: "Instructors",
                maxLength: 1,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Instructors");
        }
    }
}
