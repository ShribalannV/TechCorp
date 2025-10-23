using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechCorp.Migrations.MyDb
{
    /// <inheritdoc />
    public partial class CreateAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    AccountType = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false, defaultValue: "AA"),
                    BranchCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountId_Asc",
                table: "Accounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountType",
                table: "Accounts",
                column: "AccountType");

            migrationBuilder.CreateIndex(
                name: "IX_Account_BranchCode_Desc",
                table: "Accounts",
                column: "BranchCode",
                descending: new bool[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
