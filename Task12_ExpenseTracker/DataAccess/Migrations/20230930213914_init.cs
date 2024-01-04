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
                name: "AccountBases",
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
                    table.PrimaryKey("PK_AccountBases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountBases_TransactionParticipants_Id",
                        column: x => x.Id,
                        principalTable: "TransactionParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 10, 1, 0, 39, 14, 135, DateTimeKind.Local).AddTicks(9066))
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

            migrationBuilder.CreateTable(
                name: "DebitAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentCreditLimit = table.Column<double>(type: "float", nullable: false),
                    StartCreditLimit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebitAccounts_AccountBases_Id",
                        column: x => x.Id,
                        principalTable: "AccountBases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TransactionParticipants",
                column: "Id",
                values: new object[]
                {
                    new Guid("0647b65f-9c75-40f9-9606-d44ffd6dd5e1"),
                    new Guid("0918725e-8c0b-4450-b8f0-1709ee3ec09e"),
                    new Guid("55883208-4516-4a34-bc9e-0d22d87b4d03"),
                    new Guid("6b17ecda-b009-44a0-ad7f-447ba6bae96a"),
                    new Guid("7aeb1347-ca78-441d-8364-03c7c9198946"),
                    new Guid("af9e4fa6-3ed8-4561-b4cf-09331dd6836e"),
                    new Guid("ba715918-38f9-40de-ad5f-a7316f67d767"),
                    new Guid("bd8e87d4-3a77-4e08-a70f-629cd6285484"),
                    new Guid("f6b0ea9e-eabc-4d9b-8f27-fc97abe9b434"),
                    new Guid("fcf00ad5-c47d-4562-882c-8af6bb2d13ec")
                });

            migrationBuilder.InsertData(
                table: "AccountBases",
                columns: new[] { "Id", "Balance", "CurrencyType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0647b65f-9c75-40f9-9606-d44ffd6dd5e1"), 123143.0, "CAD", "cwewwfre", "DebitAccount5" },
                    { new Guid("55883208-4516-4a34-bc9e-0d22d87b4d03"), 102.0, "USD", "weewfwef", "DebitAccount1" },
                    { new Guid("7aeb1347-ca78-441d-8364-03c7c9198946"), 100023.2, "CHF", "cwwwecwcew", "DebitAccount2" },
                    { new Guid("f6b0ea9e-eabc-4d9b-8f27-fc97abe9b434"), 12321.0, "GBP", "evevrve", "DebitAccount4" },
                    { new Guid("fcf00ad5-c47d-4562-882c-8af6bb2d13ec"), 432423.0, "PLZ", "cwewecds", "DebitAccount3" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CategoryType" },
                values: new object[,]
                {
                    { new Guid("0918725e-8c0b-4450-b8f0-1709ee3ec09e"), "Weapons", "Income" },
                    { new Guid("6b17ecda-b009-44a0-ad7f-447ba6bae96a"), "Soderzhanka", "Expense" },
                    { new Guid("af9e4fa6-3ed8-4561-b4cf-09331dd6836e"), "Coca plantation", "Income" },
                    { new Guid("ba715918-38f9-40de-ad5f-a7316f67d767"), "Cocaine", "Expense" },
                    { new Guid("bd8e87d4-3a77-4e08-a70f-629cd6285484"), "Trading slaves", "Income" }
                });

            migrationBuilder.InsertData(
                table: "DebitAccounts",
                columns: new[] { "Id", "CurrentCreditLimit", "StartCreditLimit" },
                values: new object[,]
                {
                    { new Guid("0647b65f-9c75-40f9-9606-d44ffd6dd5e1"), 300.0, 1000.0 },
                    { new Guid("55883208-4516-4a34-bc9e-0d22d87b4d03"), 0.0, 1000.0 },
                    { new Guid("7aeb1347-ca78-441d-8364-03c7c9198946"), 500.0, 1000.0 },
                    { new Guid("f6b0ea9e-eabc-4d9b-8f27-fc97abe9b434"), 200.0, 1000.0 },
                    { new Guid("fcf00ad5-c47d-4562-882c-8af6bb2d13ec"), 1000.0, 1000.0 }
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
                name: "DebitAccounts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AccountBases");

            migrationBuilder.DropTable(
                name: "TransactionParticipants");
        }
    }
}
