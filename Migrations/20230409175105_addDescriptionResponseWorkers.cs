using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recruitment_agency.Migrations
{
    public partial class addDescriptionResponseWorkers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "responseWorks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "responseWorks");
        }
    }
}
