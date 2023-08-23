using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionParticipants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_TransactionParticipants_Id",
                        column: x => x.Id,
                        principalTable: "TransactionParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CurrencyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditAccounts_TransactionParticipants_Id",
                        column: x => x.Id,
                        principalTable: "TransactionParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DebitAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CurrencyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebitAccounts_TransactionParticipants_Id",
                        column: x => x.Id,
                        principalTable: "TransactionParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvestAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CurrencyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestAccounts_TransactionParticipants_Id",
                        column: x => x.Id,
                        principalTable: "TransactionParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 8, 16, 0, 44, 51, 269, DateTimeKind.Local).AddTicks(6632))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionParticipants_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "TransactionParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionParticipants_SenderId",
                        column: x => x.SenderId,
                        principalTable: "TransactionParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TransactionParticipants",
                column: "Id",
                values: new object[]
                {
                    new Guid("045b5038-1587-498b-a6e6-259a7ddbf0f6"),
                    new Guid("06b21267-e006-4365-8d8c-acf4719324ed"),
                    new Guid("337089f4-928a-4f31-a24e-86b43829a579"),
                    new Guid("36b5d2e9-12ea-481a-86e8-66f9dd9b542c"),
                    new Guid("384d33fa-eff3-494e-8dac-934cde251982"),
                    new Guid("3fe0a406-2a1c-4462-8349-ae18deb2c136"),
                    new Guid("49057bde-0378-48d5-bd49-b3a6fb2fa595"),
                    new Guid("4bdf41e6-048a-4e70-bc2b-22033b89070d"),
                    new Guid("505487c1-ee03-4a57-b86a-33c95716ca40"),
                    new Guid("579f5a24-88c4-4179-9dfc-9c4bed7658a6"),
                    new Guid("643c6c48-0045-4e84-97b8-9a4812b98c19"),
                    new Guid("7d6fb732-5d5f-4352-8ecd-a3ea168a09d1"),
                    new Guid("7df2de64-acf8-4cbf-a461-49d1c5e77424"),
                    new Guid("81002b18-ef8f-4006-8bac-64dd6700b6bd"),
                    new Guid("a32567b5-76fc-4326-823e-2212b38ba5d3"),
                    new Guid("a94cb3c2-2b32-4d7c-a097-91fea0bb41f5"),
                    new Guid("ad24dfa8-ea1c-46b0-bdba-c4582cb2a22e"),
                    new Guid("c91c461d-48ca-49c4-817f-f102bd2f1bee"),
                    new Guid("f2eee489-44fa-4f73-808a-96e4466b65ef"),
                    new Guid("fe7fd360-4232-4ea3-a6fe-d1d3c5168f8b")
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CategoryType" },
                values: new object[,]
                {
                    { new Guid("045b5038-1587-498b-a6e6-259a7ddbf0f6"), "Salary", "Income" },
                    { new Guid("06b21267-e006-4365-8d8c-acf4719324ed"), "Crypto", "Income" },
                    { new Guid("3fe0a406-2a1c-4462-8349-ae18deb2c136"), "Bank loan", "Debt" },
                    { new Guid("505487c1-ee03-4a57-b86a-33c95716ca40"), "Stocks", "Asset" },
                    { new Guid("7df2de64-acf8-4cbf-a461-49d1c5e77424"), "Food", "Expense" }
                });

            migrationBuilder.InsertData(
                table: "CreditAccounts",
                columns: new[] { "Id", "Balance", "CurrencyType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("49057bde-0378-48d5-bd49-b3a6fb2fa595"), 321532452.0, "CAD", "cwewwfre", "CreditAccount5" },
                    { new Guid("4bdf41e6-048a-4e70-bc2b-22033b89070d"), 102.0, "USD", "weewfwef", "CreditAccount1" },
                    { new Guid("579f5a24-88c4-4179-9dfc-9c4bed7658a6"), 100023.2, "CHF", "cwwwecwcew", "CreditAccount2" },
                    { new Guid("643c6c48-0045-4e84-97b8-9a4812b98c19"), 123131.0, "PLZ", "cwewecds", "CreditAccount3" },
                    { new Guid("a32567b5-76fc-4326-823e-2212b38ba5d3"), 432423432.0, "GBP", "evevrve", "CreditAccount4" }
                });

            migrationBuilder.InsertData(
                table: "DebitAccounts",
                columns: new[] { "Id", "Balance", "CurrencyType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("337089f4-928a-4f31-a24e-86b43829a579"), 123143.0, "CAD", "cwewwfre", "DebitAccount5" },
                    { new Guid("384d33fa-eff3-494e-8dac-934cde251982"), 432423.0, "PLZ", "cwewecds", "DebitAccount3" },
                    { new Guid("81002b18-ef8f-4006-8bac-64dd6700b6bd"), 12321.0, "GBP", "evevrve", "DebitAccount4" },
                    { new Guid("ad24dfa8-ea1c-46b0-bdba-c4582cb2a22e"), 100023.2, "CHF", "cwwwecwcew", "DebitAccount2" },
                    { new Guid("f2eee489-44fa-4f73-808a-96e4466b65ef"), 102.0, "USD", "weewfwef", "DebitAccount1" }
                });

            migrationBuilder.InsertData(
                table: "InvestAccounts",
                columns: new[] { "Id", "Balance", "CurrencyType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("36b5d2e9-12ea-481a-86e8-66f9dd9b542c"), 12542342.0, "CAD", "cwewwfre", "InvestAccount5" },
                    { new Guid("7d6fb732-5d5f-4352-8ecd-a3ea168a09d1"), 12312.0, "PLZ", "cwewecds", "InvestAccount3" },
                    { new Guid("a94cb3c2-2b32-4d7c-a097-91fea0bb41f5"), 242342.0, "GBP", "evevrve", "InvestAccount4" },
                    { new Guid("c91c461d-48ca-49c4-817f-f102bd2f1bee"), 102.0, "USD", "weewfwef", "InvestAccount1" },
                    { new Guid("fe7fd360-4232-4ea3-a6fe-d1d3c5168f8b"), 31231.0, "CHF", "cwwwecwcew", "InvestAccount2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ReceiverId",
                table: "Transactions",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SenderId",
                table: "Transactions",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CreditAccounts");

            migrationBuilder.DropTable(
                name: "DebitAccounts");

            migrationBuilder.DropTable(
                name: "InvestAccounts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionParticipants");
        }
    }
}
