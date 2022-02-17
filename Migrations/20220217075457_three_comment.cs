using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class three_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owner_companys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descraptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    count_employee = table.Column<int>(type: "int", nullable: false),
                    Specialties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner_companys", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "owner_companys");
        }
    }
}
