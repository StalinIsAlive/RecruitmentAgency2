using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recruitment_agency.Migrations
{
    public partial class fixVacancyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacancies_professions_professionsId",
                table: "vacancies");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "vacancies");

            migrationBuilder.RenameColumn(
                name: "professionsId",
                table: "vacancies",
                newName: "ProfessionsId");

            migrationBuilder.RenameIndex(
                name: "IX_vacancies_professionsId",
                table: "vacancies",
                newName: "IX_vacancies_ProfessionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_vacancies_professions_ProfessionsId",
                table: "vacancies",
                column: "ProfessionsId",
                principalTable: "professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacancies_professions_ProfessionsId",
                table: "vacancies");

            migrationBuilder.RenameColumn(
                name: "ProfessionsId",
                table: "vacancies",
                newName: "professionsId");

            migrationBuilder.RenameIndex(
                name: "IX_vacancies_ProfessionsId",
                table: "vacancies",
                newName: "IX_vacancies_professionsId");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_vacancies_professions_professionsId",
                table: "vacancies",
                column: "professionsId",
                principalTable: "professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
