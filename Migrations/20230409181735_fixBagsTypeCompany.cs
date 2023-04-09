using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recruitment_agency.Migrations
{
    public partial class fixBagsTypeCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employers_companyTypes_companyTypeId",
                table: "employers");

            migrationBuilder.DropIndex(
                name: "IX_employers_companyTypeId",
                table: "employers");

            migrationBuilder.DropColumn(
                name: "companyTypeId",
                table: "employers");

            migrationBuilder.CreateIndex(
                name: "IX_employers_CompanyType",
                table: "employers",
                column: "CompanyType");

            migrationBuilder.AddForeignKey(
                name: "FK_employers_companyTypes_CompanyType",
                table: "employers",
                column: "CompanyType",
                principalTable: "companyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employers_companyTypes_CompanyType",
                table: "employers");

            migrationBuilder.DropIndex(
                name: "IX_employers_CompanyType",
                table: "employers");

            migrationBuilder.AddColumn<int>(
                name: "companyTypeId",
                table: "employers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_employers_companyTypeId",
                table: "employers",
                column: "companyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_employers_companyTypes_companyTypeId",
                table: "employers",
                column: "companyTypeId",
                principalTable: "companyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
