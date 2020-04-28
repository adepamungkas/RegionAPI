using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegionAPI.Migrations
{
    public partial class init_country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 500, nullable: false, defaultValue: "Country"),
                    Motto = table.Column<string>(maxLength: 500, nullable: true),
                    Anthem = table.Column<string>(maxLength: 500, nullable: true),
                    Emblem = table.Column<string>(nullable: true),
                    OfficialLanguage = table.Column<string>(nullable: true),
                    Government = table.Column<string>(nullable: true),
                    Legislature = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: false),
                    Religion = table.Column<string>(nullable: true),
                    Capital = table.Column<string>(maxLength: 500, nullable: true),
                    Population = table.Column<double>(nullable: false),
                    Currency = table.Column<double>(nullable: false),
                    CallingCode = table.Column<string>(nullable: true),
                    Ethnics = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CountryId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyModels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "MyModels");
        }
    }
}
