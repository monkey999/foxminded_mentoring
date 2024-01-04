using Microsoft.EntityFrameworkCore.Migrations;

namespace B_DataAccess.Migrations
{
    public partial class _initCreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "Description" },
                values: new object[,]
                {
                    { 1, "C#/.NET", "This course will teach you how to create phishing software" },
                    { 2, "SQL", "This course will teach you how to use SQL injections" },
                    { 3, "Algorithms and Data Structures", "This course will teach you how to bruteforce passwords" },
                    { 4, "Networks", "Learn cross-site scripting, port scanning, buffer overflow, etc." },
                    { 5, "OS architecture", "Create your rootkit" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CourseId", "GroupName" },
                values: new object[,]
                {
                    { 1, 1, "SR-01" },
                    { 5, 2, "SR-01" },
                    { 3, 3, "FR-01" },
                    { 4, 3, "FR-02" },
                    { 2, 4, "SR-02" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 9, "John", 1, "Wilson" },
                    { 36, "John", 4, "Moore" },
                    { 35, "John", 4, "Jones" },
                    { 33, "Emily", 4, "Wilson" },
                    { 32, "Sarah", 4, "Moore" },
                    { 26, "James", 4, "Williams" },
                    { 22, "William", 4, "Moore" },
                    { 20, "Emily", 4, "Davis" },
                    { 14, "David", 4, "Jones" },
                    { 11, "Olivia", 4, "Taylor" },
                    { 7, "James", 4, "Davis" },
                    { 5, "James", 4, "Johnson" },
                    { 3, "John", 4, "Moore" },
                    { 1, "John", 4, "Johnson" },
                    { 95, "Sarah", 3, "Johnson" },
                    { 93, "Olivia", 3, "Williams" },
                    { 89, "William", 3, "Davis" },
                    { 84, "Emily", 3, "Wilson" },
                    { 78, "Emma", 3, "Wilson" },
                    { 74, "David", 3, "Miller" },
                    { 68, "Emily", 3, "Johnson" },
                    { 66, "John", 3, "Moore" },
                    { 39, "Sophia", 4, "Wilson" },
                    { 59, "David", 3, "Williams" },
                    { 40, "Michael", 4, "Smith" },
                    { 43, "William", 4, "Brown" },
                    { 90, "Olivia", 2, "Moore" },
                    { 77, "Olivia", 2, "Williams" },
                    { 54, "Emma", 2, "Brown" },
                    { 47, "David", 2, "Davis" },
                    { 45, "Emma", 2, "Smith" },
                    { 34, "Emily", 2, "Jones" },
                    { 30, "Sophia", 2, "Johnson" },
                    { 8, "William", 2, "Williams" },
                    { 92, "Emily", 4, "Williams" },
                    { 88, "William", 4, "Davis" },
                    { 86, "Sophia", 4, "Jones" },
                    { 83, "William", 4, "Wilson" },
                    { 82, "Sophia", 4, "Moore" },
                    { 80, "Olivia", 4, "Davis" },
                    { 79, "James", 4, "Williams" },
                    { 72, "Sophia", 4, "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 69, "John", 4, "Miller" },
                    { 64, "Emily", 4, "Moore" },
                    { 62, "Olivia", 4, "Jones" },
                    { 51, "Emma", 4, "Moore" },
                    { 48, "James", 4, "Taylor" },
                    { 42, "Sarah", 4, "Davis" },
                    { 58, "Emily", 3, "Williams" },
                    { 46, "Sophia", 3, "Miller" },
                    { 44, "Emily", 3, "Davis" },
                    { 28, "William", 5, "Moore" },
                    { 27, "Michael", 5, "Davis" },
                    { 19, "David", 5, "Brown" },
                    { 18, "Michael", 5, "Jones" },
                    { 15, "Emily", 5, "Davis" },
                    { 13, "Emily", 5, "Jones" },
                    { 4, "Michael", 5, "Miller" },
                    { 96, "Emma", 1, "Brown" },
                    { 75, "John", 1, "Jones" },
                    { 73, "Emily", 1, "Brown" },
                    { 70, "John", 1, "Moore" },
                    { 67, "Emma", 1, "Davis" },
                    { 65, "Olivia", 1, "Williams" },
                    { 61, "Olivia", 1, "Wilson" },
                    { 60, "William", 1, "Taylor" },
                    { 57, "Sophia", 1, "Smith" },
                    { 50, "James", 1, "Brown" },
                    { 49, "Sarah", 1, "Brown" },
                    { 37, "James", 1, "Jones" },
                    { 25, "William", 1, "Miller" },
                    { 10, "Michael", 1, "Brown" },
                    { 31, "William", 5, "Smith" },
                    { 38, "Sarah", 5, "Taylor" },
                    { 52, "Sarah", 5, "Williams" },
                    { 53, "James", 5, "Taylor" },
                    { 41, "John", 3, "Jones" },
                    { 29, "Olivia", 3, "Johnson" },
                    { 24, "Sarah", 3, "Wilson" },
                    { 23, "Sarah", 3, "Davis" },
                    { 21, "Emily", 3, "Miller" },
                    { 17, "Olivia", 3, "Brown" },
                    { 16, "Michael", 3, "Wilson" },
                    { 12, "Emily", 3, "Wilson" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 6, "Sarah", 3, "Moore" },
                    { 2, "Olivia", 3, "Brown" },
                    { 99, "James", 2, "Williams" },
                    { 98, "James", 5, "Jones" },
                    { 94, "Michael", 5, "Wilson" },
                    { 91, "John", 5, "Wilson" },
                    { 87, "David", 5, "Miller" },
                    { 85, "Michael", 5, "Wilson" },
                    { 81, "Emma", 5, "Moore" },
                    { 76, "Michael", 5, "Wilson" },
                    { 71, "Michael", 5, "Johnson" },
                    { 63, "Emma", 5, "Moore" },
                    { 56, "Olivia", 5, "Williams" },
                    { 55, "John", 5, "Brown" },
                    { 97, "Olivia", 5, "Johnson" },
                    { 100, "Emily", 2, "Smith" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
