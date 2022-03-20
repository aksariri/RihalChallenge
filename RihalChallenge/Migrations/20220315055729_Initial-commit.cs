using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RihalChallenge.Migrations
{
    public partial class Initialcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_classes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifitedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_classes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifitedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_students",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    class_Id = table.Column<int>(type: "integer", nullable: true),
                    country_Id = table.Column<int>(type: "INTEGER", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifitedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Classes",
                        column: x => x.class_Id,
                        principalTable: "tb_classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Countries",
                        column: x => x.country_Id,
                        principalTable: "tb_countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_students_class_Id",
                table: "tb_students",
                column: "class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_students_country_Id",
                table: "tb_students",
                column: "country_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_students");

            migrationBuilder.DropTable(
                name: "tb_classes");

            migrationBuilder.DropTable(
                name: "tb_countries");
        }
    }
}
