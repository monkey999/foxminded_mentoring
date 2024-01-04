using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class somechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0918725e-8c0b-4450-b8f0-1709ee3ec09e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b17ecda-b009-44a0-ad7f-447ba6bae96a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af9e4fa6-3ed8-4561-b4cf-09331dd6836e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ba715918-38f9-40de-ad5f-a7316f67d767"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bd8e87d4-3a77-4e08-a70f-629cd6285484"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("0647b65f-9c75-40f9-9606-d44ffd6dd5e1"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("55883208-4516-4a34-bc9e-0d22d87b4d03"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("7aeb1347-ca78-441d-8364-03c7c9198946"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("f6b0ea9e-eabc-4d9b-8f27-fc97abe9b434"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("fcf00ad5-c47d-4562-882c-8af6bb2d13ec"));

            migrationBuilder.DeleteData(
                table: "AccountBases",
                keyColumn: "Id",
                keyValue: new Guid("0647b65f-9c75-40f9-9606-d44ffd6dd5e1"));

            migrationBuilder.DeleteData(
                table: "AccountBases",
                keyColumn: "Id",
                keyValue: new Guid("55883208-4516-4a34-bc9e-0d22d87b4d03"));

            migrationBuilder.DeleteData(
                table: "AccountBases",
                keyColumn: "Id",
                keyValue: new Guid("7aeb1347-ca78-441d-8364-03c7c9198946"));

            migrationBuilder.DeleteData(
                table: "AccountBases",
                keyColumn: "Id",
                keyValue: new Guid("f6b0ea9e-eabc-4d9b-8f27-fc97abe9b434"));

            migrationBuilder.DeleteData(
                table: "AccountBases",
                keyColumn: "Id",
                keyValue: new Guid("fcf00ad5-c47d-4562-882c-8af6bb2d13ec"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("0918725e-8c0b-4450-b8f0-1709ee3ec09e"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("6b17ecda-b009-44a0-ad7f-447ba6bae96a"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("af9e4fa6-3ed8-4561-b4cf-09331dd6836e"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("ba715918-38f9-40de-ad5f-a7316f67d767"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("bd8e87d4-3a77-4e08-a70f-629cd6285484"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("0647b65f-9c75-40f9-9606-d44ffd6dd5e1"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("55883208-4516-4a34-bc9e-0d22d87b4d03"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("7aeb1347-ca78-441d-8364-03c7c9198946"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("f6b0ea9e-eabc-4d9b-8f27-fc97abe9b434"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("fcf00ad5-c47d-4562-882c-8af6bb2d13ec"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 12, 4, 32, 31, 784, DateTimeKind.Local).AddTicks(9261),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 1, 0, 39, 14, 135, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.InsertData(
                table: "TransactionParticipants",
                column: "Id",
                values: new object[]
                {
                    new Guid("04ce37fb-51b5-4af2-9093-ca925cd45ac3"),
                    new Guid("2335c691-79e6-4bf3-8695-db9bb56642bc"),
                    new Guid("88f63fcb-78eb-4b3d-986e-80b4d4e42992"),
                    new Guid("920caa25-e0a9-4081-9462-9a3a9e1e1a7f"),
                    new Guid("9d6b9c7d-27d2-4a9d-9b5f-2b108b50f9b4"),
                    new Guid("d9de8074-b3a5-444a-8aef-8893ea9985ef"),
                    new Guid("df333852-f567-4925-88e9-eab0c4b90abf"),
                    new Guid("e00a1a79-0d02-4d37-9fa5-f54d21521e56"),
                    new Guid("e3c1647d-e2fd-4734-abd7-7187e4ea5b05"),
                    new Guid("f00571a8-0a6f-4d8b-a199-82880a717c93")
                });

            migrationBuilder.InsertData(
                table: "AccountBases",
                columns: new[] { "Id", "Balance", "CurrencyType", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("04ce37fb-51b5-4af2-9093-ca925cd45ac3"), 123143.0, "CAD", "cwewwfre", "DebitAccount5" },
                    { new Guid("2335c691-79e6-4bf3-8695-db9bb56642bc"), 100023.2, "CHF", "cwwwecwcew", "DebitAccount2" },
                    { new Guid("920caa25-e0a9-4081-9462-9a3a9e1e1a7f"), 12321.0, "GBP", "evevrve", "DebitAccount4" },
                    { new Guid("9d6b9c7d-27d2-4a9d-9b5f-2b108b50f9b4"), 102.0, "USD", "weewfwef", "DebitAccount1" },
                    { new Guid("e00a1a79-0d02-4d37-9fa5-f54d21521e56"), 432423.0, "PLZ", "cwewecds", "DebitAccount3" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CategoryType" },
                values: new object[,]
                {
                    { new Guid("88f63fcb-78eb-4b3d-986e-80b4d4e42992"), "Coca plantation", "Income" },
                    { new Guid("d9de8074-b3a5-444a-8aef-8893ea9985ef"), "Soderzhanka", "Expense" },
                    { new Guid("df333852-f567-4925-88e9-eab0c4b90abf"), "Weapons", "Income" },
                    { new Guid("e3c1647d-e2fd-4734-abd7-7187e4ea5b05"), "Trading slaves", "Income" },
                    { new Guid("f00571a8-0a6f-4d8b-a199-82880a717c93"), "Cocaine", "Expense" }
                });

            migrationBuilder.InsertData(
                table: "DebitAccounts",
                columns: new[] { "Id", "CurrentCreditLimit", "StartCreditLimit" },
                values: new object[,]
                {
                    { new Guid("04ce37fb-51b5-4af2-9093-ca925cd45ac3"), 300.0, 1000.0 },
                    { new Guid("2335c691-79e6-4bf3-8695-db9bb56642bc"), 500.0, 1000.0 },
                    { new Guid("920caa25-e0a9-4081-9462-9a3a9e1e1a7f"), 200.0, 1000.0 },
                    { new Guid("9d6b9c7d-27d2-4a9d-9b5f-2b108b50f9b4"), 0.0, 1000.0 },
                    { new Guid("e00a1a79-0d02-4d37-9fa5-f54d21521e56"), 1000.0, 1000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("88f63fcb-78eb-4b3d-986e-80b4d4e42992"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d9de8074-b3a5-444a-8aef-8893ea9985ef"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("df333852-f567-4925-88e9-eab0c4b90abf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e3c1647d-e2fd-4734-abd7-7187e4ea5b05"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f00571a8-0a6f-4d8b-a199-82880a717c93"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("04ce37fb-51b5-4af2-9093-ca925cd45ac3"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("2335c691-79e6-4bf3-8695-db9bb56642bc"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("920caa25-e0a9-4081-9462-9a3a9e1e1a7f"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("9d6b9c7d-27d2-4a9d-9b5f-2b108b50f9b4"));

            migrationBuilder.DeleteData(
                table: "DebitAccounts",
                keyColumn: "Id",
                keyValue: new Guid("e00a1a79-0d02-4d37-9fa5-f54d21521e56"));

            migrationBuilder.DeleteData(
                table: "AccountBases",
                keyColumn: "Id",
                keyValue: new Guid("04ce37fb-51b5-4af2-9093-ca925cd45ac3"));

            migrationBuilder.DeleteData(
                table: "AccountBases",
                keyColumn: "Id",
                keyValue: new Guid("2335c691-79e6-4bf3-8695-db9bb56642bc"));

            migrationBuilder.DeleteData(
                table: "AccountBases",
                keyColumn: "Id",
                keyValue: new Guid("920caa25-e0a9-4081-9462-9a3a9e1e1a7f"));

            migrationBuilder.DeleteData(
                table: "AccountBases",
                keyColumn: "Id",
                keyValue: new Guid("9d6b9c7d-27d2-4a9d-9b5f-2b108b50f9b4"));

            migrationBuilder.DeleteData(
                table: "AccountBases",
                keyColumn: "Id",
                keyValue: new Guid("e00a1a79-0d02-4d37-9fa5-f54d21521e56"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("88f63fcb-78eb-4b3d-986e-80b4d4e42992"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("d9de8074-b3a5-444a-8aef-8893ea9985ef"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("df333852-f567-4925-88e9-eab0c4b90abf"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("e3c1647d-e2fd-4734-abd7-7187e4ea5b05"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("f00571a8-0a6f-4d8b-a199-82880a717c93"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("04ce37fb-51b5-4af2-9093-ca925cd45ac3"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("2335c691-79e6-4bf3-8695-db9bb56642bc"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("920caa25-e0a9-4081-9462-9a3a9e1e1a7f"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("9d6b9c7d-27d2-4a9d-9b5f-2b108b50f9b4"));

            migrationBuilder.DeleteData(
                table: "TransactionParticipants",
                keyColumn: "Id",
                keyValue: new Guid("e00a1a79-0d02-4d37-9fa5-f54d21521e56"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 1, 0, 39, 14, 135, DateTimeKind.Local).AddTicks(9066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 12, 4, 32, 31, 784, DateTimeKind.Local).AddTicks(9261));

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
        }
    }
}
