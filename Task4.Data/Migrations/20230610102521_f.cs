using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task4.Data.Migrations
{
    public partial class f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "LastLoginTime", "Name", "Password", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8846), "abdulloh@itransition.com", null, "Abdulloh Axmadjonov", "1234", 1, null },
                    { 2L, new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8851), "p.lebedev@itransition.com", null, "Pavel Lebedev", "1234", 1, null },
                    { 3L, new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8857), "risolass@gmail.com", null, "Risolat Nurillaeva", "1234", 1, null },
                    { 4L, new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8859), "jasur@icoud.com", null, "Jasur Rasulov", "1234", 1, null },
                    { 5L, new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8861), "normatov@gmail.com", null, "Umar Normvatov", "1234", 1, null },
                    { 6L, new DateTime(2023, 6, 10, 10, 25, 20, 931, DateTimeKind.Utc).AddTicks(8863), "buggy@gmail.com", null, "Buggy Anvarjonov", "1234", 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
