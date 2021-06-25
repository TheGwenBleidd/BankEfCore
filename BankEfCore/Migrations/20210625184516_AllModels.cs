using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankEfCore.Migrations
{
    public partial class AllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "varchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "varchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BankClients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientFullName = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CompanyIdKey = table.Column<long>(type: "bigint", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CityIdKey = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniqueIdentityNumber = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientBirthday = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankClients", x => x.Id);
                    table.UniqueConstraint("AK_BankClients_UniqueIdentityNumber", x => x.UniqueIdentityNumber);
                    table.ForeignKey(
                        name: "FK_BankClients_Cities_CityIdKey",
                        column: x => x.CityIdKey,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankClients_Countries_CompanyIdKey",
                        column: x => x.CompanyIdKey,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BankClientId = table.Column<int>(type: "int", nullable: false),
                    BankClientIdKey = table.Column<long>(type: "bigint", nullable: true),
                    AccountNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Balance = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Accounts_BankClients_BankClientIdKey",
                        column: x => x.BankClientIdKey,
                        principalTable: "BankClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TransactionType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientSenderId = table.Column<int>(type: "int", nullable: true),
                    ClientSenderIdKey = table.Column<long>(type: "bigint", nullable: true),
                    ClientSenderAccountId = table.Column<int>(type: "int", nullable: true),
                    ClientSenderAccountIdKey = table.Column<long>(type: "bigint", nullable: true),
                    ClientReceiverId = table.Column<int>(type: "int", nullable: true),
                    ClientReceiverIdKey = table.Column<long>(type: "bigint", nullable: true),
                    ClientReceiverAccountId = table.Column<int>(type: "int", nullable: true),
                    ClientReceiverAccountIdKey = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_ClientReceiverAccountIdKey",
                        column: x => x.ClientReceiverAccountIdKey,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_ClientSenderAccountIdKey",
                        column: x => x.ClientSenderAccountIdKey,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_BankClients_ClientReceiverIdKey",
                        column: x => x.ClientReceiverIdKey,
                        principalTable: "BankClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_BankClients_ClientSenderIdKey",
                        column: x => x.ClientSenderIdKey,
                        principalTable: "BankClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BankClientIdKey",
                table: "Accounts",
                column: "BankClientIdKey");

            migrationBuilder.CreateIndex(
                name: "IX_BankClients_CityIdKey",
                table: "BankClients",
                column: "CityIdKey");

            migrationBuilder.CreateIndex(
                name: "IX_BankClients_CompanyIdKey",
                table: "BankClients",
                column: "CompanyIdKey");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientReceiverAccountIdKey",
                table: "Transactions",
                column: "ClientReceiverAccountIdKey");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientReceiverIdKey",
                table: "Transactions",
                column: "ClientReceiverIdKey");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientSenderAccountIdKey",
                table: "Transactions",
                column: "ClientSenderAccountIdKey");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientSenderIdKey",
                table: "Transactions",
                column: "ClientSenderIdKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "BankClients");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "Countries",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldMaxLength: 400)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Cities",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldMaxLength: 400)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
