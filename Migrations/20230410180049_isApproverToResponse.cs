using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recruitment_agency.Migrations
{
    public partial class isApproverToResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "responseVacancies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isNotApproved",
                table: "responseVacancies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "responseResumes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isNotApproved",
                table: "responseResumes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "responseVacancies");

            migrationBuilder.DropColumn(
                name: "isNotApproved",
                table: "responseVacancies");

            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "responseResumes");

            migrationBuilder.DropColumn(
                name: "isNotApproved",
                table: "responseResumes");
        }
    }
}
