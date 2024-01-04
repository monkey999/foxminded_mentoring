using Microsoft.EntityFrameworkCore.Migrations;

namespace B_DataAccess.Migrations
{
    public partial class _model_upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "Groups",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Courses",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 5, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "GroupId" },
                values: new object[] { "David", 2 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 3, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 1, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 3, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "James", "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 5, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 3, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 3, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 4, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 5, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 2, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 3, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 5, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sophia", 1, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastName",
                value: "Jones");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sarah", 5, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 1, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 2, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "FirstName", "GroupId" },
                values: new object[] { "Michael", 2 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sophia", 2, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 3, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 2, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 2, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "John", "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 5, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Emily", "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 4, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 4, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 5, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 3, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 5, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 1, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 1, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 2, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 5, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sarah", 2, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 2, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 5, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 5, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 1, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Olivia", "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sophia", 3, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sarah", 4, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 5, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "James", "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 5, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Sophia", "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "FirstName", "GroupId" },
                values: new object[] { "Olivia", 4 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Sarah", "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 5, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 4, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 4, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 4, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 3, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 2, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 4, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 5, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sarah", 5, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "FirstName", "GroupId" },
                values: new object[] { "Michael", 5 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "John", "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 1, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sophia", 1, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 64,
                column: "GroupId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 2, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Sarah", "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 5, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 1, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "FirstName", "GroupId" },
                values: new object[] { "Michael", 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 4, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 3, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 2, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 5, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 5, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 5, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 1, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 5, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 1, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 5, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 3, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 4, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 2, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 3, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 5, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sophia", 1, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "John", "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 1, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 1, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 2, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 5, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 2, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 2, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sarah", 2, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 3, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "William", "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 2, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 2, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sarah", 4, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Emily", "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "William", "Moore" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Groups",
                newName: "GroupName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "CourseName");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 4, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "GroupId" },
                values: new object[] { "Olivia", 3 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 4, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 5, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 4, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Sarah", "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 4, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 2, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 1, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 1, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 4, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 3, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 5, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 4, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 5, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastName",
                value: "Wilson");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 3, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 5, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 5, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "FirstName", "GroupId" },
                values: new object[] { "Emily", 4 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 3, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 4, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sarah", 3, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sarah", 3, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "William", "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 4, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Michael", "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 5, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 3, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 2, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 5, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sarah", 4, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 4, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 2, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 4, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 4, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 1, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sarah", 5, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sophia", 4, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 4, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 3, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Sarah", "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 4, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 3, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 2, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Sophia", "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 2, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "James", "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "FirstName", "GroupId" },
                values: new object[] { "Sarah", 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "James", "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 4, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 5, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 5, "Taylor" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 2, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 5, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 5, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sophia", 1, "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 3, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 3, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "FirstName", "GroupId" },
                values: new object[] { "William", 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Olivia", "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 4, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 5, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 64,
                column: "GroupId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 1, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "John", "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 1, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 3, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "FirstName", "GroupId" },
                values: new object[] { "John", 4 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 1, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 5, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sophia", 4, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 1, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 3, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 1, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 5, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 2, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 3, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 4, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 4, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 5, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Sophia", 4, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 4, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emily", 3, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 5, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Sophia", "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "David", 5, "Miller" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "William", 4, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 3, "Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 2, "Moore" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "John", 5, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "GroupId", "LastName" },
                values: new object[] { 4, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 3, "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Michael", 5, "Wilson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Sarah", "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Emma", 1, "Brown" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "Olivia", 5, "Johnson" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "FirstName", "GroupId", "LastName" },
                values: new object[] { "James", 5, "Jones" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "James", "Williams" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Emily", "Smith" });
        }
    }
}
