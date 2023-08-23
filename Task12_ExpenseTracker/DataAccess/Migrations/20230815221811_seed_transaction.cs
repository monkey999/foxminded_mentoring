using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seed_transaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("045b5038-1587-498b-a6e6-259a7ddbf0f6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("06b21267-e006-4365-8d8c-acf4719324ed"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3fe0a406-2a1c-4462-8349-ae18deb2c136"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("505487c1-ee03-4a57-b86a-33c95716ca40"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7df2de64-acf8-4cbf-a461-49d1c5e77424"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("49057bde-0378-48d5-bd49-b3a6fb2fa595"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("4bdf41e6-048a-4e70-bc2b-22033b89070d"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("579f5a24-88c4-4179-9dfc-9c4bed7658a6"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("643c6c48-0045-4e84-97b8-9a4812b98c19"));

            migrationBuilder.DeleteData(
                table: "CreditAccounts",
                keyColumn: "Id",
                keyValue: new Guid("a32567b5-76fc-4326-823e-2212b38ba5d3"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("337089f4-928a-4f31-a24e-86b43829a579"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("384d33fa-eff3-494e-8dac-934cde251982"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("81002b18-ef8f-4006-8bac-64dd6700b6bd"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("ad24dfa8-ea1c-46b0-bdba-c4582cb2a22e"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("f2eee489-44fa-4f73-808a-96e4466b65ef"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("36b5d2e9-12ea-481a-86e8-66f9dd9b542c"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("7d6fb732-5d5f-4352-8ecd-a3ea168a09d1"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("a94cb3c2-2b32-4d7c-a097-91fea0bb41f5"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("c91c461d-48ca-49c4-817f-f102bd2f1bee"));

            migrationBuilder.DeleteData(
                table: "InvestAccounts",
                keyColumn: "Id",
                keyValue: new Guid("fe7fd360-4232-4ea3-a6fe-d1d3c5168f8b"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("045b5038-1587-498b-a6e6-259a7ddbf0f6"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("06b21267-e006-4365-8d8c-acf4719324ed"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("337089f4-928a-4f31-a24e-86b43829a579"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("36b5d2e9-12ea-481a-86e8-66f9dd9b542c"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("384d33fa-eff3-494e-8dac-934cde251982"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("3fe0a406-2a1c-4462-8349-ae18deb2c136"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("49057bde-0378-48d5-bd49-b3a6fb2fa595"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("4bdf41e6-048a-4e70-bc2b-22033b89070d"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("505487c1-ee03-4a57-b86a-33c95716ca40"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("579f5a24-88c4-4179-9dfc-9c4bed7658a6"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("643c6c48-0045-4e84-97b8-9a4812b98c19"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("7d6fb732-5d5f-4352-8ecd-a3ea168a09d1"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("7df2de64-acf8-4cbf-a461-49d1c5e77424"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("81002b18-ef8f-4006-8bac-64dd6700b6bd"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("a32567b5-76fc-4326-823e-2212b38ba5d3"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("a94cb3c2-2b32-4d7c-a097-91fea0bb41f5"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("ad24dfa8-ea1c-46b0-bdba-c4582cb2a22e"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("c91c461d-48ca-49c4-817f-f102bd2f1bee"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("f2eee489-44fa-4f73-808a-96e4466b65ef"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("fe7fd360-4232-4ea3-a6fe-d1d3c5168f8b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 16, 1, 18, 11, 550, DateTimeKind.Local).AddTicks(6602),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 16, 0, 44, 51, 269, DateTimeKind.Local).AddTicks(6632));

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
                    { new Guid("4a14bb19-3366-4fa6-b001-19cd863e5d46"), 234234.0, new DateTime(2023, 8, 16, 1, 18, 11, 555, DateTimeKind.Local).AddTicks(6492), new Guid("058eabfc-acd6-488c-aeff-b71e977cb963"), new Guid("083a3f91-7128-49cb-90bd-c74e54634778"), "Income" },
                    { new Guid("7fee494f-5be4-470f-b146-0e2ec7af2a80"), 2342323.0, new DateTime(2023, 8, 16, 1, 18, 11, 555, DateTimeKind.Local).AddTicks(6605), new Guid("0b69154d-c3f8-43dc-814b-735cfdb217ee"), new Guid("2436690b-9144-4159-80b8-510efe615885"), "Expense" },
                    { new Guid("992edc44-c733-4adf-b8d0-2dc8227cd718"), 12545.0, new DateTime(2023, 8, 16, 1, 18, 11, 555, DateTimeKind.Local).AddTicks(6610), new Guid("2f83360e-3e1f-4320-9658-90ef74c1e6d8"), new Guid("3a95dff6-8454-41f6-a743-72bdbfe53a73"), "Income" },
                    { new Guid("c5f3a083-5c71-4947-a18b-2e6bcacdd53b"), 2342423.0, new DateTime(2023, 8, 16, 1, 18, 11, 555, DateTimeKind.Local).AddTicks(6578), new Guid("48f5aff8-8ab2-4a50-a8aa-09a3dd51e30d"), new Guid("5990d12f-a1d2-41b2-8eb2-d1dd8efb9fd2"), "DebtBorrowing" },
                    { new Guid("ee054331-1122-4509-a3b8-bf00ea64a03d"), 54343.0, new DateTime(2023, 8, 16, 1, 18, 11, 555, DateTimeKind.Local).AddTicks(6585), new Guid("62895748-7eea-4e5d-a2db-566f5f5845af"), new Guid("6d175ec7-87a2-4c3e-a870-bc3f2481d6d5"), "DebtRepayment" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 8, 16, 0, 44, 51, 269, DateTimeKind.Local).AddTicks(6632),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 16, 1, 18, 11, 550, DateTimeKind.Local).AddTicks(6602));

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
        }
    }
}
