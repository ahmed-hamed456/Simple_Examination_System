using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examination_System.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Head = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    answer_stud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ins_id = table.Column<int>(type: "int", nullable: true),
                    Ex_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_questions_exams_Ex_id",
                        column: x => x.Ex_id,
                        principalTable: "exams",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_questions_instructors_ins_id",
                        column: x => x.ins_id,
                        principalTable: "instructors",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsMine = table.Column<bool>(type: "bit", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    ins_id = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_students_instructors_ins_id",
                        column: x => x.ins_id,
                        principalTable: "instructors",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "std_Exams",
                columns: table => new
                {
                    std_id = table.Column<int>(type: "int", nullable: false),
                    ex_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_std_Exams", x => new { x.std_id, x.ex_id });
                    table.ForeignKey(
                        name: "FK_std_Exams_exams_ex_id",
                        column: x => x.ex_id,
                        principalTable: "exams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_std_Exams_students_std_id",
                        column: x => x.std_id,
                        principalTable: "students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_Ex_id",
                table: "questions",
                column: "Ex_id");

            migrationBuilder.CreateIndex(
                name: "IX_questions_ins_id",
                table: "questions",
                column: "ins_id");

            migrationBuilder.CreateIndex(
                name: "IX_std_Exams_ex_id",
                table: "std_Exams",
                column: "ex_id");

            migrationBuilder.CreateIndex(
                name: "IX_students_ins_id",
                table: "students",
                column: "ins_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "std_Exams");

            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "instructors");
        }
    }
}
