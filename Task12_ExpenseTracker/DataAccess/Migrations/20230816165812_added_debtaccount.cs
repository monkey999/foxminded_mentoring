using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class added_debtaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2436690b-9144-4159-80b8-510efe615885"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d175ec7-87a2-4c3e-a870-bc3f2481d6d5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("942aef6c-e78e-4656-be07-3df08ff385c9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa4db7e4-3a4b-4e3d-b311-d0ebf6628c5c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b8f73c60-7286-4ba2-9b77-dec1b8c1e680"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("0b69154d-c3f8-43dc-814b-735cfdb217ee"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("2f83360e-3e1f-4320-9658-90ef74c1e6d8"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("48f5aff8-8ab2-4a50-a8aa-09a3dd51e30d"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("740bcb1c-caa2-40ca-a9c3-3d78747f6ed6"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("a69b8a7d-7c6f-4344-b318-a3985ab5b6e8"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("083a3f91-7128-49cb-90bd-c74e54634778"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("5990d12f-a1d2-41b2-8eb2-d1dd8efb9fd2"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("6ad8efd9-1633-4133-a782-ca5d81a3532b"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("7aa90dec-211a-4116-84a4-0d42b1d5458b"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("a0f103ac-5383-44c8-acf7-dd6e753aa6c8"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("058eabfc-acd6-488c-aeff-b71e977cb963"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("3a95dff6-8454-41f6-a743-72bdbfe53a73"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("62895748-7eea-4e5d-a2db-566f5f5845af"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("742dcedd-0b72-4215-9871-5f50c9292812"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("c65677e5-18d2-4468-b129-ded425f6b22e"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("4a14bb19-3366-4fa6-b001-19cd863e5d46"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("7fee494f-5be4-470f-b146-0e2ec7af2a80"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("992edc44-c733-4adf-b8d0-2dc8227cd718"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("c5f3a083-5c71-4947-a18b-2e6bcacdd53b"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("ee054331-1122-4509-a3b8-bf00ea64a03d"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("058eabfc-acd6-488c-aeff-b71e977cb963"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("083a3f91-7128-49cb-90bd-c74e54634778"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("0b69154d-c3f8-43dc-814b-735cfdb217ee"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("2436690b-9144-4159-80b8-510efe615885"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("2f83360e-3e1f-4320-9658-90ef74c1e6d8"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("3a95dff6-8454-41f6-a743-72bdbfe53a73"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("48f5aff8-8ab2-4a50-a8aa-09a3dd51e30d"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("5990d12f-a1d2-41b2-8eb2-d1dd8efb9fd2"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("62895748-7eea-4e5d-a2db-566f5f5845af"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("6ad8efd9-1633-4133-a782-ca5d81a3532b"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("6d175ec7-87a2-4c3e-a870-bc3f2481d6d5"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("740bcb1c-caa2-40ca-a9c3-3d78747f6ed6"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("742dcedd-0b72-4215-9871-5f50c9292812"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("7aa90dec-211a-4116-84a4-0d42b1d5458b"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("942aef6c-e78e-4656-be07-3df08ff385c9"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("a0f103ac-5383-44c8-acf7-dd6e753aa6c8"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("a69b8a7d-7c6f-4344-b318-a3985ab5b6e8"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("aa4db7e4-3a4b-4e3d-b311-d0ebf6628c5c"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("b8f73c60-7286-4ba2-9b77-dec1b8c1e680"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("c65677e5-18d2-4468-b129-ded425f6b22e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 16, 19, 58, 12, 454, DateTimeKind.Local).AddTicks(1560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 16, 1, 18, 11, 550, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.CreateTable(
                name: "DebtAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebtAccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CurrencyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DebtAccounts_TransactionParticipants_Id",
                        column: x => x.Id,
                        principalTable: "TransactionParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TransactionParticipants",
                column: "Id",
                values: new object[]
                {
                    new Guid("20bf392e-34f3-4830-9585-0ac8aa4f10ef"),
                    new Guid("20c8d451-72f4-4718-9517-563bc41b65ea"),
                    new Guid("29137c6f-d907-4b9b-83b1-723d6d6cba6c"),
                    new Guid("2c50561c-7a7a-4cd8-85cd-34e824ba45a5"),
                    new Guid("43688a64-8620-4c81-ab12-4418d35ddb87"),
                    new Guid("4879229a-411b-446b-9c6e-62d9923c1ec9"),
                    new Guid("56a2d3c8-1698-41bf-8638-17c26fac6132"),
                    new Guid("596b724e-84cc-4498-806a-655e87f1f838"),
                    new Guid("5d233358-bf5c-492f-b8c7-06b6f1111125"),
                    new Guid("684b1c00-3637-418f-bdae-fcf68d01be9c"),
                    new Guid("69ef6585-ccb0-4afc-8284-257f12b94729"),
                    new Guid("7117684e-890e-4806-96df-d335046ae0d3"),
                    new Guid("84769db7-61f7-4287-8f56-b176ac99c339"),
                    new Guid("86c0d76d-69a7-4ac5-b9a6-b78f6455db63"),
                    new Guid("93819667-c3cc-4b5e-84fd-a07713b755c3"),
                    new Guid("9ccd1bc6-e225-481b-8508-521cf8d50446"),
                    new Guid("a1d97e61-3873-4ae7-86e7-de301c002e48"),
                    new Guid("ae2cdd68-9886-4aaf-8c58-18d6a92c8575"),
                    new Guid("bf0acc84-73c6-4d36-9121-54ecc7fe3190"),
                    new Guid("cefed0d7-72fb-4ca5-8a3c-08ec3eda1099"),
                    new Guid("d313e7c2-5f3b-4a28-be53-b1f3d7283051"),
                    new Guid("e91367db-2be5-4566-870a-3a5c699bacc4"),
                    new Guid("efecfbca-3e80-4b5a-920b-ae2d91a3578b"),
                    new Guid("f39df7f9-19d0-4c69-a44e-8bd2dddd0c9d"),
                    new Guid("f450166d-92ed-4d17-8906-226480d7abb8")
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Date", "ReceiverId", "SenderId", "TransactionType" },
                values: new object[,]
                {
                    { new Guid("18634549-c6b9-4c47-98b9-0862f8ae16bf"), 2342423.0, new DateTime(2023, 8, 16, 19, 58, 12, 460, DateTimeKind.Local).AddTicks(3922), new Guid("20bf392e-34f3-4830-9585-0ac8aa4f10ef"), new Guid("20c8d451-72f4-4718-9517-563bc41b65ea"), "IGiveLoan" },
                    { new Guid("4b62006c-a7c9-4fc1-94c6-9a61aaa3ad88"), 234234.0, new DateTime(2023, 8, 16, 19, 58, 12, 460, DateTimeKind.Local).AddTicks(3831), new Guid("29137c6f-d907-4b9b-83b1-723d6d6cba6c"), new Guid("56a2d3c8-1698-41bf-8638-17c26fac6132"), "Income" },
                    { new Guid("7281c33f-41fa-4e2f-adc2-8e9ebfb061f5"), 2342323.0, new DateTime(2023, 8, 16, 19, 58, 12, 460, DateTimeKind.Local).AddTicks(3991), new Guid("2c50561c-7a7a-4cd8-85cd-34e824ba45a5"), new Guid("596b724e-84cc-4498-806a-655e87f1f838"), "Expense" },
                    { new Guid("b3d19982-c77d-4afd-a129-e5373e9f5b21"), 54343.0, new DateTime(2023, 8, 16, 19, 58, 12, 460, DateTimeKind.Local).AddTicks(3929), new Guid("43688a64-8620-4c81-ab12-4418d35ddb87"), new Guid("5d233358-bf5c-492f-b8c7-06b6f1111125"), "RepaysMeLoan" },
                    { new Guid("bd48bff0-3f5e-473c-ab25-b21ae0b6546c"), 12545.0, new DateTime(2023, 8, 16, 19, 58, 12, 460, DateTimeKind.Local).AddTicks(3997), new Guid("4879229a-411b-446b-9c6e-62d9923c1ec9"), new Guid("684b1c00-3637-418f-bdae-fcf68d01be9c"), "Income" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CategoryType" },
                values: new object[,]
                {
                    { new Guid("4879229a-411b-446b-9c6e-62d9923c1ec9"), "Bank loan", "Expense" },
                    { new Guid("86c0d76d-69a7-4ac5-b9a6-b78f6455db63"), "Crypto", "Income" },
                    { new Guid("9ccd1bc6-e225-481b-8508-521cf8d50446"), "Food", "Expense" },
                    { new Guid("e91367db-2be5-4566-870a-3a5c699bacc4"), "Salary", "Income" },
                    { new Guid("f39df7f9-19d0-4c69-a44e-8bd2dddd0c9d"), "Stocks", "Income" }
                });

            migrationBuilder.InsertData(
                table: "CreditAccounts",
                columns: new[] { "Id", "Balance", "CurrencyType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("20bf392e-34f3-4830-9585-0ac8aa4f10ef"), 100023.2, "CHF", "cwwwecwcew", "CreditAccount2" },
                    { new Guid("29137c6f-d907-4b9b-83b1-723d6d6cba6c"), 432423432.0, "GBP", "evevrve", "CreditAccount4" },
                    { new Guid("2c50561c-7a7a-4cd8-85cd-34e824ba45a5"), 102.0, "USD", "weewfwef", "CreditAccount1" },
                    { new Guid("684b1c00-3637-418f-bdae-fcf68d01be9c"), 321532452.0, "CAD", "cwewwfre", "CreditAccount5" },
                    { new Guid("bf0acc84-73c6-4d36-9121-54ecc7fe3190"), 123131.0, "PLZ", "cwewecds", "CreditAccount3" }
                });

            migrationBuilder.InsertData(
                table: "DebitAccounts",
                columns: new[] { "Id", "Balance", "CurrencyType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("20c8d451-72f4-4718-9517-563bc41b65ea"), 100023.2, "CHF", "cwwwecwcew", "DebitAccount2" },
                    { new Guid("596b724e-84cc-4498-806a-655e87f1f838"), 123143.0, "CAD", "cwewwfre", "DebitAccount5" },
                    { new Guid("7117684e-890e-4806-96df-d335046ae0d3"), 432423.0, "PLZ", "cwewecds", "DebitAccount3" },
                    { new Guid("a1d97e61-3873-4ae7-86e7-de301c002e48"), 12321.0, "GBP", "evevrve", "DebitAccount4" },
                    { new Guid("efecfbca-3e80-4b5a-920b-ae2d91a3578b"), 102.0, "USD", "weewfwef", "DebitAccount1" }
                });

            migrationBuilder.InsertData(
                table: "DebtAccounts",
                columns: new[] { "Id", "Balance", "CurrencyType", "DebtAccountType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("56a2d3c8-1698-41bf-8638-17c26fac6132"), 432423.0, "PLZ", "IDebtGiver", "cwewecds", "DebtAccount3" },
                    { new Guid("93819667-c3cc-4b5e-84fd-a07713b755c3"), 12321.0, "GBP", "IDebtGiver", "evevrve", "DebtAccount4" },
                    { new Guid("ae2cdd68-9886-4aaf-8c58-18d6a92c8575"), 100023.2, "CHF", "IDebtTaker", "cwwwecwcew", "DebtAccount2" },
                    { new Guid("cefed0d7-72fb-4ca5-8a3c-08ec3eda1099"), 123143.0, "CAD", "IDebtGiver", "cwewwfre", "DebtAccount5" },
                    { new Guid("f450166d-92ed-4d17-8906-226480d7abb8"), 102.0, "USD", "IDebtGiver", "weewfwef", "DebtAccount1" }
                });

            migrationBuilder.InsertData(
                table: "InvestAccounts",
                columns: new[] { "Id", "Balance", "CurrencyType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("43688a64-8620-4c81-ab12-4418d35ddb87"), 102.0, "USD", "weewfwef", "InvestAccount1" },
                    { new Guid("5d233358-bf5c-492f-b8c7-06b6f1111125"), 12312.0, "PLZ", "cwewecds", "InvestAccount3" },
                    { new Guid("69ef6585-ccb0-4afc-8284-257f12b94729"), 31231.0, "CHF", "cwwwecwcew", "InvestAccount2" },
                    { new Guid("84769db7-61f7-4287-8f56-b176ac99c339"), 12542342.0, "CAD", "cwewwfre", "InvestAccount5" },
                    { new Guid("d313e7c2-5f3b-4a28-be53-b1f3d7283051"), 242342.0, "GBP", "evevrve", "InvestAccount4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtAccounts");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4879229a-411b-446b-9c6e-62d9923c1ec9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("86c0d76d-69a7-4ac5-b9a6-b78f6455db63"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9ccd1bc6-e225-481b-8508-521cf8d50446"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e91367db-2be5-4566-870a-3a5c699bacc4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f39df7f9-19d0-4c69-a44e-8bd2dddd0c9d"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("20bf392e-34f3-4830-9585-0ac8aa4f10ef"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("29137c6f-d907-4b9b-83b1-723d6d6cba6c"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("2c50561c-7a7a-4cd8-85cd-34e824ba45a5"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("684b1c00-3637-418f-bdae-fcf68d01be9c"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("bf0acc84-73c6-4d36-9121-54ecc7fe3190"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("20c8d451-72f4-4718-9517-563bc41b65ea"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("596b724e-84cc-4498-806a-655e87f1f838"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("7117684e-890e-4806-96df-d335046ae0d3"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("a1d97e61-3873-4ae7-86e7-de301c002e48"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("efecfbca-3e80-4b5a-920b-ae2d91a3578b"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("43688a64-8620-4c81-ab12-4418d35ddb87"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("5d233358-bf5c-492f-b8c7-06b6f1111125"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("69ef6585-ccb0-4afc-8284-257f12b94729"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("84769db7-61f7-4287-8f56-b176ac99c339"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("d313e7c2-5f3b-4a28-be53-b1f3d7283051"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("56a2d3c8-1698-41bf-8638-17c26fac6132"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("93819667-c3cc-4b5e-84fd-a07713b755c3"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("ae2cdd68-9886-4aaf-8c58-18d6a92c8575"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("cefed0d7-72fb-4ca5-8a3c-08ec3eda1099"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("f450166d-92ed-4d17-8906-226480d7abb8"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("18634549-c6b9-4c47-98b9-0862f8ae16bf"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("4b62006c-a7c9-4fc1-94c6-9a61aaa3ad88"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("7281c33f-41fa-4e2f-adc2-8e9ebfb061f5"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("b3d19982-c77d-4afd-a129-e5373e9f5b21"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: new Guid("bd48bff0-3f5e-473c-ab25-b21ae0b6546c"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("20bf392e-34f3-4830-9585-0ac8aa4f10ef"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("20c8d451-72f4-4718-9517-563bc41b65ea"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("29137c6f-d907-4b9b-83b1-723d6d6cba6c"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("2c50561c-7a7a-4cd8-85cd-34e824ba45a5"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("43688a64-8620-4c81-ab12-4418d35ddb87"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("4879229a-411b-446b-9c6e-62d9923c1ec9"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("596b724e-84cc-4498-806a-655e87f1f838"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("5d233358-bf5c-492f-b8c7-06b6f1111125"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("684b1c00-3637-418f-bdae-fcf68d01be9c"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("69ef6585-ccb0-4afc-8284-257f12b94729"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("7117684e-890e-4806-96df-d335046ae0d3"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("84769db7-61f7-4287-8f56-b176ac99c339"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("86c0d76d-69a7-4ac5-b9a6-b78f6455db63"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("9ccd1bc6-e225-481b-8508-521cf8d50446"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("a1d97e61-3873-4ae7-86e7-de301c002e48"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("bf0acc84-73c6-4d36-9121-54ecc7fe3190"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("d313e7c2-5f3b-4a28-be53-b1f3d7283051"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("e91367db-2be5-4566-870a-3a5c699bacc4"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("efecfbca-3e80-4b5a-920b-ae2d91a3578b"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("f39df7f9-19d0-4c69-a44e-8bd2dddd0c9d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 16, 1, 18, 11, 550, DateTimeKind.Local).AddTicks(6602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 16, 19, 58, 12, 454, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.InsertData(
                table: "TransactionParticipants",
                column: "Id",
                values: new object[]
                {
                    new Guid("058eabfc-acd6-488c-aeff-b71e977cb963"),
                    new Guid("083a3f91-7128-49cb-90bd-c74e54634778"),
                    new Guid("0b69154d-c3f8-43dc-814b-735cfdb217ee"),
                    new Guid("2436690b-9144-4159-80b8-510efe615885"),
                    new Guid("2f83360e-3e1f-4320-9658-90ef74c1e6d8"),
                    new Guid("3a95dff6-8454-41f6-a743-72bdbfe53a73"),
                    new Guid("48f5aff8-8ab2-4a50-a8aa-09a3dd51e30d"),
                    new Guid("5990d12f-a1d2-41b2-8eb2-d1dd8efb9fd2"),
                    new Guid("62895748-7eea-4e5d-a2db-566f5f5845af"),
                    new Guid("6ad8efd9-1633-4133-a782-ca5d81a3532b"),
                    new Guid("6d175ec7-87a2-4c3e-a870-bc3f2481d6d5"),
                    new Guid("740bcb1c-caa2-40ca-a9c3-3d78747f6ed6"),
                    new Guid("742dcedd-0b72-4215-9871-5f50c9292812"),
                    new Guid("7aa90dec-211a-4116-84a4-0d42b1d5458b"),
                    new Guid("942aef6c-e78e-4656-be07-3df08ff385c9"),
                    new Guid("a0f103ac-5383-44c8-acf7-dd6e753aa6c8"),
                    new Guid("a69b8a7d-7c6f-4344-b318-a3985ab5b6e8"),
                    new Guid("aa4db7e4-3a4b-4e3d-b311-d0ebf6628c5c"),
                    new Guid("b8f73c60-7286-4ba2-9b77-dec1b8c1e680"),
                    new Guid("c65677e5-18d2-4468-b129-ded425f6b22e")
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Date", "ReceiverId", "SenderId", "TransactionType" },
                values: new object[,]
                {
                    { new Guid("4a14bb19-3366-4fa6-b001-19cd863e5d46"), 234234.0, new DateTime(2023, 8, 16, 1, 18, 11, 555, DateTimeKind.Local).AddTicks(6492), new Guid("f0086e2e-5979-4093-8126-566cfc287053"), new Guid("c39a989b-6e36-4bf5-a7f9-c622aefbe542"), "Income" },
                    { new Guid("7fee494f-5be4-470f-b146-0e2ec7af2a80"), 2342323.0, new DateTime(2023, 8, 16, 1, 18, 11, 555, DateTimeKind.Local).AddTicks(6605), new Guid("19e588e3-835f-4713-92b4-2ddd2edf162f"), new Guid("8a5cf21a-d36c-4e50-b284-51859a896b77"), "Expense" },
                    { new Guid("992edc44-c733-4adf-b8d0-2dc8227cd718"), 12545.0, new DateTime(2023, 8, 16, 1, 18, 11, 555, DateTimeKind.Local).AddTicks(6610), new Guid("9b0609a1-a97e-4b1c-9ffc-1e3e50b42a8c"), new Guid("cf582266-c161-492b-833f-e025922d466f"), "Income" },
                    { new Guid("c5f3a083-5c71-4947-a18b-2e6bcacdd53b"), 2342423.0, new DateTime(2023, 8, 16, 1, 18, 11, 555, DateTimeKind.Local).AddTicks(6578), new Guid("78fa7702-dc9d-44aa-8e64-3dd33f94bf5f"), new Guid("feb5376f-cf8c-4409-8c5d-8c94e128e439"), "DebtBorrowing" },
                    { new Guid("ee054331-1122-4509-a3b8-bf00ea64a03d"), 54343.0, new DateTime(2023, 8, 16, 1, 18, 11, 555, DateTimeKind.Local).AddTicks(6585), new Guid("8e6f821c-6e5c-468f-9305-51f4d5242d6e"), new Guid("7f308b64-9e48-4682-aaff-6f1ff6d85baa"), "DebtRepayment" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CategoryType" },
                values: new object[,]
                {
                    { new Guid("2436690b-9144-4159-80b8-510efe615885"), "Bank loan", "Debt" },
                    { new Guid("6d175ec7-87a2-4c3e-a870-bc3f2481d6d5"), "Food", "Expense" },
                    { new Guid("942aef6c-e78e-4656-be07-3df08ff385c9"), "Crypto", "Income" },
                    { new Guid("aa4db7e4-3a4b-4e3d-b311-d0ebf6628c5c"), "Stocks", "Asset" },
                    { new Guid("b8f73c60-7286-4ba2-9b77-dec1b8c1e680"), "Salary", "Income" }
                });

            migrationBuilder.InsertData(
                table: "CreditAccounts",
                columns: new[] { "Id", "Balance", "CurrencyType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0b69154d-c3f8-43dc-814b-735cfdb217ee"), 321532452.0, "CAD", "cwewwfre", "CreditAccount5" },
                    { new Guid("2f83360e-3e1f-4320-9658-90ef74c1e6d8"), 100023.2, "CHF", "cwwwecwcew", "CreditAccount2" },
                    { new Guid("48f5aff8-8ab2-4a50-a8aa-09a3dd51e30d"), 432423432.0, "GBP", "evevrve", "CreditAccount4" },
                    { new Guid("740bcb1c-caa2-40ca-a9c3-3d78747f6ed6"), 123131.0, "PLZ", "cwewecds", "CreditAccount3" },
                    { new Guid("a69b8a7d-7c6f-4344-b318-a3985ab5b6e8"), 102.0, "USD", "weewfwef", "CreditAccount1" }
                });

            migrationBuilder.InsertData(
                table: "DebitAccounts",
                columns: new[] { "Id", "Balance", "CurrencyType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("083a3f91-7128-49cb-90bd-c74e54634778"), 432423.0, "PLZ", "cwewecds", "DebitAccount3" },
                    { new Guid("5990d12f-a1d2-41b2-8eb2-d1dd8efb9fd2"), 100023.2, "CHF", "cwwwecwcew", "DebitAccount2" },
                    { new Guid("6ad8efd9-1633-4133-a782-ca5d81a3532b"), 12321.0, "GBP", "evevrve", "DebitAccount4" },
                    { new Guid("7aa90dec-211a-4116-84a4-0d42b1d5458b"), 102.0, "USD", "weewfwef", "DebitAccount1" },
                    { new Guid("a0f103ac-5383-44c8-acf7-dd6e753aa6c8"), 123143.0, "CAD", "cwewwfre", "DebitAccount5" }
                });

            migrationBuilder.InsertData(
                table: "InvestAccounts",
                columns: new[] { "Id", "Balance", "CurrencyType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("058eabfc-acd6-488c-aeff-b71e977cb963"), 102.0, "USD", "weewfwef", "InvestAccount1" },
                    { new Guid("3a95dff6-8454-41f6-a743-72bdbfe53a73"), 12312.0, "PLZ", "cwewecds", "InvestAccount3" },
                    { new Guid("62895748-7eea-4e5d-a2db-566f5f5845af"), 242342.0, "GBP", "evevrve", "InvestAccount4" },
                    { new Guid("742dcedd-0b72-4215-9871-5f50c9292812"), 12542342.0, "CAD", "cwewwfre", "InvestAccount5" },
                    { new Guid("c65677e5-18d2-4468-b129-ded425f6b22e"), 31231.0, "CHF", "cwwwecwcew", "InvestAccount2" }
                });
        }
    }
}
