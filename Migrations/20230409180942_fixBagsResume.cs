using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recruitment_agency.Migrations
{
    public partial class fixBagsResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resumes_professions_professionsId",
                table: "resumes");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "resumes");

            migrationBuilder.RenameColumn(
                name: "professionsId",
                table: "resumes",
                newName: "ProfessionsId");

            migrationBuilder.RenameIndex(
                name: "IX_resumes_professionsId",
                table: "resumes",
                newName: "IX_resumes_ProfessionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_resumes_professions_ProfessionsId",
                table: "resumes",
                column: "ProfessionsId",
                principalTable: "professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resumes_professions_ProfessionsId",
                table: "resumes");

            migrationBuilder.RenameColumn(
                name: "ProfessionsId",
                table: "resumes",
                newName: "professionsId");

            migrationBuilder.RenameIndex(
                name: "IX_resumes_ProfessionsId",
                table: "resumes",
                newName: "IX_resumes_professionsId");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "resumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_resumes_professions_professionsId",
                table: "resumes",
                column: "professionsId",
                principalTable: "professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
