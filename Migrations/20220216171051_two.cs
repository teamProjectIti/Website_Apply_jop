using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Cat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Describations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Details_jops",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleJop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePublisher = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContentJop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required_jop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cat_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details_jops", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Details_jops_categorys_cat_Id",
                        column: x => x.cat_Id,
                        principalTable: "categorys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Details_jops_cat_Id",
                table: "Details_jops",
                column: "cat_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details_jops");

            migrationBuilder.DropTable(
                name: "categorys");
        }
    }
}
