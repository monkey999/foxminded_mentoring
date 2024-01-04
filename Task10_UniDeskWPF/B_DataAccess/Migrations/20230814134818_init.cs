using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace B_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true)
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
                name: "TeacherCourses",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new { x.CourseId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutors_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
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
                    GroupId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "TutorGroups",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorGroups", x => new { x.TutorId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_TutorGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorGroups_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This course will teach you how to create phishing software", "C#/.NET" },
                    { 2, "This course will teach you how to use SQL injections", "SQL" },
                    { 3, "This course will teach you how to bruteforce passwords", "Algorithms and Data Structures" },
                    { 4, "Learn cross-site scripting, port scanning, buffer overflow, etc.", "Networks" },
                    { 5, "Create your rootkit", "OS architecture" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Jane", "Smith" },
                    { 3, "Ivan", "Ivanov" },
                    { 4, "Petr", "Petrov" },
                    { 5, "Michael", "Michaelson" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CourseId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "SR-01" },
                    { 2, 4, "SR-02" },
                    { 3, 3, "FR-01" },
                    { 4, 3, "FR-02" },
                    { 5, 2, "SR-01" }
                });

            migrationBuilder.InsertData(
                table: "TeacherCourses",
                columns: new[] { "CourseId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tutors",
                columns: new[] { "Id", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName" },
                values: new object[,]
                {
                    { 1, "Emily", 1, "Smith" },
                    { 2, "Emily", 4, "Johnson" },
                    { 3, "John", 5, "Miller" },
                    { 4, "Emily", 3, "Williams" },
                    { 5, "Sophia", 5, "Johnson" },
                    { 6, "Emma", 4, "Brown" },
                    { 7, "Michael", 1, "Moore" },
                    { 8, "Emma", 2, "Taylor" },
                    { 9, "William", 1, "Taylor" },
                    { 10, "Sophia", 5, "Miller" },
                    { 11, "Sarah", 5, "Jones" },
                    { 12, "Michael", 1, "Jones" },
                    { 13, "Michael", 4, "Miller" },
                    { 14, "John", 4, "Davis" },
                    { 15, "David", 2, "Moore" },
                    { 16, "Emily", 4, "Williams" },
                    { 17, "William", 5, "Brown" },
                    { 18, "Olivia", 5, "Brown" },
                    { 19, "Michael", 4, "Taylor" },
                    { 20, "James", 2, "Jones" },
                    { 21, "Emma", 3, "Miller" },
                    { 22, "Michael", 2, "Wilson" },
                    { 23, "Sarah", 2, "Taylor" },
                    { 24, "Sophia", 1, "Johnson" },
                    { 25, "Emma", 1, "Wilson" },
                    { 26, "Emily", 4, "Miller" },
                    { 27, "Sarah", 4, "Jones" },
                    { 28, "Michael", 3, "Taylor" },
                    { 29, "William", 3, "Davis" },
                    { 30, "Sarah", 2, "Wilson" },
                    { 31, "David", 5, "Johnson" },
                    { 32, "William", 5, "Johnson" },
                    { 33, "Sophia", 2, "Johnson" },
                    { 34, "David", 1, "Miller" },
                    { 35, "Sophia", 5, "Smith" },
                    { 36, "John", 3, "Taylor" },
                    { 37, "Emma", 5, "Moore" },
                    { 38, "Olivia", 3, "Williams" },
                    { 39, "Sarah", 5, "Wilson" },
                    { 40, "Olivia", 2, "Miller" },
                    { 41, "Emma", 2, "Taylor" },
                    { 42, "William", 3, "Smith" },
                    { 43, "William", 5, "Wilson" },
                    { 44, "John", 1, "Brown" },
                    { 45, "Sophia", 1, "Jones" },
                    { 46, "John", 1, "Johnson" },
                    { 47, "Sarah", 5, "Johnson" },
                    { 48, "James", 3, "Wilson" },
                    { 49, "Emily", 5, "Brown" },
                    { 50, "Emma", 4, "Johnson" },
                    { 51, "Sophia", 5, "Davis" },
                    { 52, "Emma", 2, "Johnson" },
                    { 53, "James", 5, "Miller" },
                    { 54, "Michael", 3, "Moore" },
                    { 55, "Emma", 2, "Miller" },
                    { 56, "John", 3, "Brown" },
                    { 57, "Olivia", 4, "Moore" },
                    { 58, "Sophia", 4, "Davis" },
                    { 59, "Sophia", 5, "Miller" },
                    { 60, "Emma", 1, "Miller" },
                    { 61, "John", 3, "Brown" },
                    { 62, "John", 2, "Williams" },
                    { 63, "Sophia", 1, "Moore" },
                    { 64, "Sophia", 5, "Wilson" },
                    { 65, "William", 4, "Williams" },
                    { 66, "William", 5, "Johnson" },
                    { 67, "Michael", 3, "Moore" },
                    { 68, "Sarah", 2, "Brown" },
                    { 69, "Sarah", 5, "Miller" },
                    { 70, "Sarah", 1, "Miller" },
                    { 71, "Sophia", 2, "Taylor" },
                    { 72, "Olivia", 5, "Miller" },
                    { 73, "William", 1, "Smith" },
                    { 74, "William", 1, "Davis" },
                    { 75, "Michael", 4, "Moore" },
                    { 76, "John", 5, "Smith" },
                    { 77, "Emma", 2, "Williams" },
                    { 78, "Olivia", 2, "Williams" },
                    { 79, "David", 3, "Moore" },
                    { 80, "John", 4, "Miller" },
                    { 81, "Michael", 5, "Smith" },
                    { 82, "Emily", 3, "Brown" },
                    { 83, "Emma", 1, "Taylor" },
                    { 84, "John", 2, "Miller" },
                    { 85, "Emma", 1, "Moore" },
                    { 86, "Emma", 5, "Johnson" },
                    { 87, "Emma", 1, "Johnson" },
                    { 88, "James", 5, "Davis" },
                    { 89, "John", 4, "Moore" },
                    { 90, "Sophia", 1, "Davis" },
                    { 91, "Emma", 3, "Moore" },
                    { 92, "Emily", 5, "Johnson" },
                    { 93, "Sarah", 4, "Miller" },
                    { 94, "Michael", 3, "Taylor" },
                    { 95, "David", 5, "Miller" },
                    { 96, "David", 1, "Brown" },
                    { 97, "Sarah", 4, "Miller" },
                    { 98, "David", 1, "Johnson" },
                    { 99, "John", 2, "Brown" },
                    { 100, "John", 3, "Moore" }
                });

            migrationBuilder.InsertData(
                table: "TutorGroups",
                columns: new[] { "GroupId", "TutorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 4, 5 },
                    { 5, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorGroups_GroupId",
                table: "TutorGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutors_TeacherId",
                table: "Tutors",
                column: "TeacherId",
                unique: true,
                filter: "[TeacherId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "TutorGroups");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Tutors");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
