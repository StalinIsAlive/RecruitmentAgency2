using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recruitment_agency.Migrations
{
    public partial class addVisibleProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isVisible",
                table: "vacancies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isVisible",
                table: "resumes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isVisible",
                table: "vacancies");

            migrationBuilder.DropColumn(
                name: "isVisible",
                table: "resumes");
        }
    }
}
