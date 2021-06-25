using Microsoft.EntityFrameworkCore.Migrations;

namespace BankEfCore.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankClients_Countries_CompanyIdKey",
                table: "BankClients");

            migrationBuilder.RenameColumn(
                name: "CompanyIdKey",
                table: "BankClients",
                newName: "CountryIdKey");

            migrationBuilder.RenameIndex(
                name: "IX_BankClients_CompanyIdKey",
                table: "BankClients",
                newName: "IX_BankClients_CountryIdKey");

            migrationBuilder.AddForeignKey(
                name: "FK_BankClients_Countries_CountryIdKey",
                table: "BankClients",
                column: "CountryIdKey",
                principalTable: "Countries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankClients_Countries_CountryIdKey",
                table: "BankClients");

            migrationBuilder.RenameColumn(
                name: "CountryIdKey",
                table: "BankClients",
                newName: "CompanyIdKey");

            migrationBuilder.RenameIndex(
                name: "IX_BankClients_CountryIdKey",
                table: "BankClients",
                newName: "IX_BankClients_CompanyIdKey");

            migrationBuilder.AddForeignKey(
                name: "FK_BankClients_Countries_CompanyIdKey",
                table: "BankClients",
                column: "CompanyIdKey",
                principalTable: "Countries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
